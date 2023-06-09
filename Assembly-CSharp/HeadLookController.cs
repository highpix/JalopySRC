﻿using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class HeadLookController : MonoBehaviour
{
	// Token: 0x06000120 RID: 288 RVA: 0x00012B14 File Offset: 0x00010F14
	private void Start()
	{
		if (this.rootNode == null)
		{
			this.rootNode = base.transform;
		}
		foreach (BendingSegment bendingSegment in this.segments)
		{
			Quaternion rotation = bendingSegment.firstTransform.parent.rotation;
			Quaternion lhs = Quaternion.Inverse(rotation);
			bendingSegment.referenceLookDir = lhs * this.rootNode.rotation * this.headLookVector.normalized;
			bendingSegment.referenceUpDir = lhs * this.rootNode.rotation * this.headUpVector.normalized;
			bendingSegment.angleH = 0f;
			bendingSegment.angleV = 0f;
			bendingSegment.dirUp = bendingSegment.referenceUpDir;
			bendingSegment.chainLength = 1;
			Transform transform = bendingSegment.lastTransform;
			while (transform != bendingSegment.firstTransform && transform != transform.root)
			{
				bendingSegment.chainLength++;
				transform = transform.parent;
			}
			bendingSegment.origRotations = new Quaternion[bendingSegment.chainLength];
			transform = bendingSegment.lastTransform;
			for (int j = bendingSegment.chainLength - 1; j >= 0; j--)
			{
				bendingSegment.origRotations[j] = transform.localRotation;
				transform = transform.parent;
			}
		}
	}

	// Token: 0x06000121 RID: 289 RVA: 0x00012C90 File Offset: 0x00011090
	private void HeadLookControllerOff()
	{
		this.headLookOff = true;
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00012C99 File Offset: 0x00011099
	private void HeadLookControllerOn()
	{
		this.headLookOff = false;
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00012CA4 File Offset: 0x000110A4
	private void LateUpdate()
	{
		if (Time.deltaTime == 0f)
		{
			return;
		}
		if (this.headLookOff)
		{
			return;
		}
		Vector3[] array = new Vector3[this.nonAffectedJoints.Length];
		for (int i = 0; i < this.nonAffectedJoints.Length; i++)
		{
			IEnumerator enumerator = this.nonAffectedJoints[i].joint.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					Transform transform = (Transform)enumerator.Current;
					array[i] = transform.position - this.nonAffectedJoints[i].joint.position;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		foreach (BendingSegment bendingSegment in this.segments)
		{
			Transform transform2 = bendingSegment.lastTransform;
			if (this.overrideAnimation)
			{
				for (int k = bendingSegment.chainLength - 1; k >= 0; k--)
				{
					transform2.localRotation = bendingSegment.origRotations[k];
					transform2 = transform2.parent;
				}
			}
			Quaternion rotation = bendingSegment.firstTransform.parent.rotation;
			Quaternion rotation2 = Quaternion.Inverse(rotation);
			Vector3 normalized = (this.target - bendingSegment.lastTransform.position).normalized;
			Vector3 vector = rotation2 * normalized;
			float num = HeadLookController.AngleAroundAxis(bendingSegment.referenceLookDir, vector, bendingSegment.referenceUpDir);
			Vector3 axis = Vector3.Cross(bendingSegment.referenceUpDir, vector);
			Vector3 dirA = vector - Vector3.Project(vector, bendingSegment.referenceUpDir);
			float num2 = HeadLookController.AngleAroundAxis(dirA, vector, axis);
			float f = Mathf.Max(0f, Mathf.Abs(num) - bendingSegment.thresholdAngleDifference) * Mathf.Sign(num);
			float f2 = Mathf.Max(0f, Mathf.Abs(num2) - bendingSegment.thresholdAngleDifference) * Mathf.Sign(num2);
			num = Mathf.Max(Mathf.Abs(f) * Mathf.Abs(bendingSegment.bendingMultiplier), Mathf.Abs(num) - bendingSegment.maxAngleDifference) * Mathf.Sign(num) * Mathf.Sign(bendingSegment.bendingMultiplier);
			num2 = Mathf.Max(Mathf.Abs(f2) * Mathf.Abs(bendingSegment.bendingMultiplier), Mathf.Abs(num2) - bendingSegment.maxAngleDifference) * Mathf.Sign(num2) * Mathf.Sign(bendingSegment.bendingMultiplier);
			num = Mathf.Clamp(num, -bendingSegment.maxBendingAngle, bendingSegment.maxBendingAngle);
			num2 = Mathf.Clamp(num2, -bendingSegment.maxBendingAngle, bendingSegment.maxBendingAngle);
			Vector3 axis2 = Vector3.Cross(bendingSegment.referenceUpDir, bendingSegment.referenceLookDir);
			bendingSegment.angleH = Mathf.Lerp(bendingSegment.angleH, num, Time.deltaTime * bendingSegment.responsiveness);
			bendingSegment.angleV = Mathf.Lerp(bendingSegment.angleV, num2, Time.deltaTime * bendingSegment.responsiveness);
			vector = Quaternion.AngleAxis(bendingSegment.angleH, bendingSegment.referenceUpDir) * Quaternion.AngleAxis(bendingSegment.angleV, axis2) * bendingSegment.referenceLookDir;
			Vector3 referenceUpDir = bendingSegment.referenceUpDir;
			Vector3.OrthoNormalize(ref vector, ref referenceUpDir);
			Vector3 forward = vector;
			bendingSegment.dirUp = Vector3.Slerp(bendingSegment.dirUp, referenceUpDir, Time.deltaTime * 5f);
			Vector3.OrthoNormalize(ref forward, ref bendingSegment.dirUp);
			Quaternion b = rotation * Quaternion.LookRotation(forward, bendingSegment.dirUp) * Quaternion.Inverse(rotation * Quaternion.LookRotation(bendingSegment.referenceLookDir, bendingSegment.referenceUpDir));
			Quaternion lhs = Quaternion.Slerp(Quaternion.identity, b, this.effect / (float)bendingSegment.chainLength);
			transform2 = bendingSegment.lastTransform;
			for (int l = 0; l < bendingSegment.chainLength; l++)
			{
				transform2.rotation = lhs * transform2.rotation;
				transform2 = transform2.parent;
			}
		}
		for (int m = 0; m < this.nonAffectedJoints.Length; m++)
		{
			Vector3 vector2 = Vector3.zero;
			IEnumerator enumerator2 = this.nonAffectedJoints[m].joint.GetEnumerator();
			try
			{
				if (enumerator2.MoveNext())
				{
					Transform transform3 = (Transform)enumerator2.Current;
					vector2 = transform3.position - this.nonAffectedJoints[m].joint.position;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
			Vector3 toDirection = Vector3.Slerp(array[m], vector2, this.nonAffectedJoints[m].effect);
			this.nonAffectedJoints[m].joint.rotation = Quaternion.FromToRotation(vector2, toDirection) * this.nonAffectedJoints[m].joint.rotation;
		}
	}

	// Token: 0x06000124 RID: 292 RVA: 0x000131EC File Offset: 0x000115EC
	public static float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
	{
		dirA -= Vector3.Project(dirA, axis);
		dirB -= Vector3.Project(dirB, axis);
		float num = Vector3.Angle(dirA, dirB);
		return num * (float)((Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) >= 0f) ? 1 : -1);
	}

	// Token: 0x0400023D RID: 573
	public Transform rootNode;

	// Token: 0x0400023E RID: 574
	public BendingSegment[] segments;

	// Token: 0x0400023F RID: 575
	public NonAffectedJoints[] nonAffectedJoints;

	// Token: 0x04000240 RID: 576
	public Vector3 headLookVector = Vector3.forward;

	// Token: 0x04000241 RID: 577
	public Vector3 headUpVector = Vector3.up;

	// Token: 0x04000242 RID: 578
	public Vector3 target = Vector3.zero;

	// Token: 0x04000243 RID: 579
	public float effect = 1f;

	// Token: 0x04000244 RID: 580
	public bool overrideAnimation;

	// Token: 0x04000245 RID: 581
	public bool headLookOff;
}
