using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000072 RID: 114
[Serializable]
public class QuickRope2 : MonoBehaviour
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x060001E5 RID: 485 RVA: 0x000197C4 File Offset: 0x00017BC4
	// (remove) Token: 0x060001E6 RID: 486 RVA: 0x000197FC File Offset: 0x00017BFC
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event Action OnInitializeMesh;

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x060001E7 RID: 487 RVA: 0x00019832 File Offset: 0x00017C32
	// (set) Token: 0x060001E8 RID: 488 RVA: 0x0001983A File Offset: 0x00017C3A
	public GameObject JointPrefab
	{
		get
		{
			return this.jointPrefab;
		}
		set
		{
			this.jointPrefab = value;
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x060001E9 RID: 489 RVA: 0x00019843 File Offset: 0x00017C43
	// (set) Token: 0x060001EA RID: 490 RVA: 0x0001984B File Offset: 0x00017C4B
	public float JointScale
	{
		get
		{
			return this.jointScale;
		}
		set
		{
			this.jointScale = value;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x060001EB RID: 491 RVA: 0x00019854 File Offset: 0x00017C54
	// (set) Token: 0x060001EC RID: 492 RVA: 0x0001985C File Offset: 0x00017C5C
	public bool AlternateJoints
	{
		get
		{
			return this.alternateJoints;
		}
		set
		{
			this.alternateJoints = value;
		}
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x060001ED RID: 493 RVA: 0x00019865 File Offset: 0x00017C65
	// (set) Token: 0x060001EE RID: 494 RVA: 0x0001986D File Offset: 0x00017C6D
	public bool FirstJointAlternated
	{
		get
		{
			return this.firstJointAlternated;
		}
		set
		{
			this.firstJointAlternated = value;
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x060001EF RID: 495 RVA: 0x00019876 File Offset: 0x00017C76
	// (set) Token: 0x060001F0 RID: 496 RVA: 0x0001987E File Offset: 0x00017C7E
	public List<Vector3> ControlPoints
	{
		get
		{
			return this.controlPoints;
		}
		set
		{
			this.controlPoints = value;
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x060001F1 RID: 497 RVA: 0x00019887 File Offset: 0x00017C87
	public List<Vector3> SplinePoints
	{
		get
		{
			return this.splinePoints;
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x060001F2 RID: 498 RVA: 0x00019890 File Offset: 0x00017C90
	public Vector3[] JointPositions
	{
		get
		{
			if (this.Joints.Count == 0)
			{
				return new Vector3[]
				{
					Vector3.zero
				};
			}
			Vector3[] array = new Vector3[this.Joints.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.Joints[i].transform.position;
			}
			return array;
		}
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x060001F3 RID: 499 RVA: 0x00019910 File Offset: 0x00017D10
	public Quaternion[] JointRotations
	{
		get
		{
			Quaternion[] array = new Quaternion[this.Joints.Count];
			array[0] = Quaternion.LookRotation(this.Joints[0].transform.position - this.Joints[1].transform.position);
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = Quaternion.LookRotation(this.Joints[i - 1].transform.position - this.Joints[i].transform.position);
			}
			return array;
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x060001F4 RID: 500 RVA: 0x000199CC File Offset: 0x00017DCC
	public float RopeLength
	{
		get
		{
			if (this.prevJointcount != this.Joints.Count)
			{
				this.ropeLength = 0f;
				for (int i = 1; i < this.Joints.Count; i++)
				{
					this.ropeLength += Vector3.Distance(this.Joints[i - 1].transform.position, this.Joints[i].transform.position);
				}
				this.prevJointcount = this.Joints.Count;
			}
			return this.ropeLength;
		}
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x060001F5 RID: 501 RVA: 0x00019A6D File Offset: 0x00017E6D
	// (set) Token: 0x060001F6 RID: 502 RVA: 0x00019A78 File Offset: 0x00017E78
	public bool FreeFallMode
	{
		get
		{
			return this.freeFallMode;
		}
		set
		{
			this.freeFallMode = value;
			if (value)
			{
				this.Joints[0].GetComponent<ConfigurableJoint>().connectedBody = null;
				this.Joints[1].transform.parent = this.Joints[0].transform;
			}
			else
			{
				this.Joints[0].GetComponent<ConfigurableJoint>().connectedBody = this.Joints[1].GetComponent<Rigidbody>();
				this.Joints[1].transform.parent = null;
			}
		}
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00019B14 File Offset: 0x00017F14
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		for (int i = 2; i < this.splinePoints.Count - 1; i++)
		{
			Gizmos.DrawLine(this.splinePoints[i], this.splinePoints[i - 1]);
		}
		for (int j = 1; j < this.controlPoints.Count; j++)
		{
			Gizmos.DrawLine(this.controlPoints[j], this.controlPoints[j - 1]);
		}
		if (this.enablePhysics && this.colliderType != RopeColliderType.DEFAULT)
		{
			Gizmos.color = new Color(0.1f, 0.7f, 0.4f);
			foreach (GameObject gameObject in this.Joints)
			{
				Gizmos.DrawWireSphere(gameObject.transform.position, this.colliderRadius);
			}
		}
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00019C44 File Offset: 0x00018044
	private void OnDrawGizmos()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if (this.splinePoints.Count > 3)
		{
			Gizmos.color = Color.black;
			Vector3 to = this.CalcPositionAtTime(0f);
			for (int i = 1; i <= 100; i++)
			{
				float t = (float)i / 100f;
				Vector3 vector = this.CalcPositionAtTime(t);
				Gizmos.DrawLine(vector, to);
				to = vector;
			}
			Gizmos.color = Color.white;
		}
		if (this.ropeEnd && QuickRope2Helper.HasMoved(ref this.pRopeEndPos, this.ropeEnd.transform.position))
		{
			this.ApplyRopeSettings();
		}
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00019CF0 File Offset: 0x000180F0
	private void OnDestroy()
	{
		if (this.enablePhysics && Application.isPlaying)
		{
			foreach (RopeAttachedObject ropeAttachedObject in this.attachedObjects)
			{
				UnityEngine.Object.Destroy(ropeAttachedObject.jointRef);
			}
		}
		this.ClearJointObjects();
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00019D6C File Offset: 0x0001816C
	private void Start()
	{
		if (this.ropeEnd == null)
		{
			return;
		}
		if (!this.initialized)
		{
			this.ApplyRopeSettings();
			this.AttachObjects();
		}
		this.distBetweenJoints = Vector3.Distance(this.Joints[0].transform.position, this.Joints[1].transform.position);
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00019DDC File Offset: 0x000181DC
	private void FixedUpdate()
	{
		if (!this.enablePhysics)
		{
			return;
		}
		if (this.freeFallMode)
		{
			this.UpdateFreeFall();
			return;
		}
		if (!this.enableRopeController)
		{
			return;
		}
		bool flag = false;
		if (Input.GetKey(this.extendRopeKey))
		{
			this.currentVelocity += this.acceleration * Time.deltaTime;
			flag = true;
		}
		if (Input.GetKey(this.retractRopeKey))
		{
			this.currentVelocity -= this.acceleration * Time.deltaTime;
			flag = true;
		}
		this.currentVelocity = Mathf.Clamp(this.currentVelocity, -this.maxVelocity, this.maxVelocity);
		if ((this.RopeLength < this.minRopeLength && this.currentVelocity < 0f) || (this.RopeLength > this.maxRopeLength && this.currentVelocity > 0f))
		{
			this.currentVelocity = 0f;
		}
		if (this.currentVelocity > 0f)
		{
			this.ExtendRope(this.currentVelocity);
		}
		if (this.currentVelocity < 0f)
		{
			this.RetractRope(this.currentVelocity);
		}
		if (!flag)
		{
			this.currentVelocity *= this.dampening;
			if (this.currentVelocity != 0f && Mathf.Abs(this.currentVelocity) < this.sleepVelocity)
			{
				this.currentVelocity = 0f;
			}
		}
	}

	// Token: 0x060001FC RID: 508 RVA: 0x00019F58 File Offset: 0x00018358
	private void RetractRope(float velocity)
	{
		this.Joints[1].transform.parent = this.Joints[0].transform;
		this.Joints[0].GetComponent<ConfigurableJoint>().connectedBody = null;
		this.Joints[1].GetComponent<Rigidbody>().isKinematic = true;
		this.Joints[1].transform.position = Vector3.MoveTowards(this.Joints[1].transform.position, this.Joints[0].transform.position, Time.deltaTime * velocity * -1f);
		if (Vector3.Distance(this.Joints[1].transform.position, this.Joints[0].transform.position) <= 0.001f)
		{
			GameObject obj = this.Joints[1];
			this.Joints.RemoveAt(1);
			this.Joints.TrimExcess();
			UnityEngine.Object.Destroy(obj);
		}
		this.Joints[0].GetComponent<ConfigurableJoint>().connectedBody = this.Joints[1].GetComponent<Rigidbody>();
		this.Joints[1].GetComponent<Rigidbody>().isKinematic = false;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x0001A0B4 File Offset: 0x000184B4
	private void ExtendRope(float velocity)
	{
		this.Joints[0].GetComponent<ConfigurableJoint>().connectedBody = null;
		this.Joints[1].GetComponent<Rigidbody>().isKinematic = true;
		this.Joints[1].transform.position = Vector3.MoveTowards(this.Joints[1].transform.position, this.Joints[1].transform.position - (this.Joints[0].transform.position - this.Joints[2].transform.position).normalized, Time.deltaTime * velocity);
		if (Vector3.Distance(this.Joints[1].transform.position, this.Joints[0].transform.position) > this.distBetweenJoints * 1.5f)
		{
			GameObject gameObject;
			if (this.JointPrefab != null)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.JointPrefab, this.Joints[1].transform.position - (this.Joints[1].transform.position - this.Joints[0].transform.position).normalized * this.distBetweenJoints, Quaternion.LookRotation(this.Joints[0].transform.position - this.Joints[1].transform.position));
				float zAngle = (float)((!this.alternateJoints) ? 0 : ((!this.firstJointAlternated) ? ((this.Joints.Count % 2 != 0) ? 90 : 0) : ((this.Joints.Count % 2 != 0) ? 0 : 90)));
				gameObject.transform.Rotate(0f, 0f, zAngle);
				gameObject.transform.localScale = Vector3.one * this.jointScale;
			}
			else
			{
				gameObject = new GameObject("Jnt_" + this.Joints.Count);
				gameObject.transform.position = this.Joints[1].transform.position - (this.Joints[1].transform.position - this.Joints[0].transform.position).normalized * this.distBetweenJoints;
				gameObject.transform.rotation = Quaternion.LookRotation(this.Joints[0].transform.position - this.Joints[1].transform.position);
				float zAngle2 = (float)((!this.alternateJoints) ? 0 : ((!this.firstJointAlternated) ? ((this.Joints.Count % 2 != 0) ? 0 : 90) : ((this.Joints.Count % 2 != 0) ? 90 : 0)));
				gameObject.transform.Rotate(0f, 0f, zAngle2);
			}
			gameObject.layer = base.gameObject.layer;
			gameObject.tag = base.gameObject.tag;
			if (!this.showJoints)
			{
				gameObject.hideFlags = (HideFlags.HideInHierarchy | HideFlags.NotEditable);
			}
			if (gameObject.GetComponent<Collider>())
			{
				gameObject.GetComponent<Collider>().enabled = false;
			}
			this.AddConfigJoint(gameObject).connectedBody = this.Joints[1].GetComponent<Rigidbody>();
			RopeColliderType ropeColliderType = this.colliderType;
			if (ropeColliderType != RopeColliderType.Sphere)
			{
				if (ropeColliderType == RopeColliderType.Capsule)
				{
					float num = Vector3.Distance(gameObject.transform.position, this.Joints[1].transform.position);
					CapsuleCollider capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
					capsuleCollider.radius = this.colliderRadius;
					capsuleCollider.center = new Vector3(0f, 0f, num / 2f);
					capsuleCollider.direction = 2;
					capsuleCollider.height = num + (capsuleCollider.radius + capsuleCollider.radius);
					if (this.physicsMaterial != null)
					{
						capsuleCollider.sharedMaterial = this.physicsMaterial;
					}
				}
			}
			else
			{
				SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
				sphereCollider.radius = this.colliderRadius;
				sphereCollider.center = Vector3.zero;
				if (this.physicsMaterial != null)
				{
					sphereCollider.sharedMaterial = this.physicsMaterial;
				}
			}
			this.Joints[1].GetComponent<Rigidbody>().isKinematic = false;
			this.Joints.Insert(1, gameObject);
			this.Joints.TrimExcess();
		}
		this.Joints[1].GetComponent<Rigidbody>().isKinematic = false;
		this.Joints[0].GetComponent<ConfigurableJoint>().connectedBody = this.Joints[1].GetComponent<Rigidbody>();
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0001A614 File Offset: 0x00018A14
	private void UpdateFreeFall()
	{
		if (this.RopeLength > this.maxRopeLength)
		{
			this.FreeFallMode = false;
			return;
		}
		if (Vector3.Distance(this.Joints[1].transform.position, this.Joints[0].transform.position) > this.distBetweenJoints)
		{
			GameObject gameObject;
			if (this.JointPrefab != null)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.JointPrefab, this.Joints[1].transform.position - (this.Joints[1].transform.position - this.Joints[0].transform.position).normalized * this.distBetweenJoints, Quaternion.identity);
				gameObject.transform.LookAt(this.Joints[0].transform.position);
				float zAngle = (float)((!this.alternateJoints) ? 0 : ((!this.firstJointAlternated) ? ((this.Joints.Count % 2 != 0) ? 90 : 0) : ((this.Joints.Count % 2 != 0) ? 0 : 90)));
				gameObject.transform.Rotate(0f, 0f, zAngle);
				gameObject.transform.localScale = Vector3.one * this.jointScale;
			}
			else
			{
				gameObject = new GameObject("Jnt_NULL");
				gameObject.transform.position = this.Joints[1].transform.position - (this.Joints[1].transform.position - this.Joints[0].transform.position).normalized * this.distBetweenJoints;
				gameObject.transform.rotation = Quaternion.identity;
			}
			gameObject.layer = base.gameObject.layer;
			gameObject.tag = base.gameObject.tag;
			if (!this.showJoints)
			{
				gameObject.hideFlags = (HideFlags.HideInHierarchy | HideFlags.NotEditable);
			}
			if (gameObject.GetComponent<Collider>())
			{
				gameObject.GetComponent<Collider>().enabled = false;
			}
			this.AddConfigJoint(gameObject).connectedBody = this.Joints[1].GetComponent<Rigidbody>();
			this.Joints[1].transform.parent = null;
			this.Joints.Insert(1, gameObject);
			this.Joints.TrimExcess();
			this.Joints[1].transform.parent = this.Joints[0].transform;
		}
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0001A8F0 File Offset: 0x00018CF0
	public void GenerateJointObjects()
	{
		this.ClearJointObjects();
		this.Joints.Add(base.gameObject);
		for (int i = 1; i < this.SplinePoints.Count - 1; i++)
		{
			GameObject gameObject;
			if (this.JointPrefab != null)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.JointPrefab, this.SplinePoints[i], this.calculatedRotations[i]);
				if (this.alternateJoints)
				{
					int num = (!this.firstJointAlternated) ? 0 : 1;
					gameObject.transform.Rotate(0f, 0f, (float)((i % 2 != num) ? 0 : 90));
				}
				gameObject.transform.localScale = this.jointPrefab.transform.localScale * this.jointScale;
			}
			else
			{
				gameObject = new GameObject("Jnt_" + i.ToString());
				gameObject.transform.position = this.SplinePoints[i];
				gameObject.transform.rotation = this.calculatedRotations[i];
			}
			gameObject.layer = base.gameObject.layer;
			gameObject.tag = base.gameObject.tag;
			if (!Application.isPlaying)
			{
				gameObject.transform.parent = base.transform;
			}
			if (!this.showJoints)
			{
				gameObject.hideFlags = (HideFlags.HideInHierarchy | HideFlags.NotEditable);
			}
			if (gameObject.GetComponent<Collider>())
			{
				gameObject.GetComponent<Collider>().enabled = false;
			}
			this.Joints.Add(gameObject);
		}
		this.Joints.Add(this.ropeEnd);
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0001AAB8 File Offset: 0x00018EB8
	public void ClearJointObjects()
	{
		for (int i = 0; i < this.Joints.Count; i++)
		{
			if (this.Joints[i].GetInstanceID() != base.gameObject.GetInstanceID() && this.Joints[i].GetInstanceID() != this.ropeEnd.GetInstanceID())
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(this.Joints[i]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(this.Joints[i]);
				}
			}
		}
		this.Joints.Clear();
		this.Joints.TrimExcess();
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0001AB70 File Offset: 0x00018F70
	private void PreCalculateRotations()
	{
		this.calculatedRotations = new Quaternion[this.SplinePoints.Count];
		this.calculatedRotations[0] = Quaternion.LookRotation(this.SplinePoints[0] - this.SplinePoints[1]);
		for (int i = 1; i < this.calculatedRotations.Length; i++)
		{
			this.calculatedRotations[i] = Quaternion.LookRotation(this.SplinePoints[i - 1] - this.SplinePoints[i]);
		}
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0001AC14 File Offset: 0x00019014
	public Quaternion[] GetRotations(Vector3[] points)
	{
		Vector3[] array = new Vector3[points.Length];
		Quaternion[] array2 = new Quaternion[points.Length];
		for (int i = 0; i < points.Length - 1; i++)
		{
			array[i] = points[i + 1] - points[i];
		}
		array[points.Length - 1] = array[points.Length - 2];
		Vector3 vector;
		if (this.pastUp == Vector3.zero)
		{
			vector = ((array[0].x != 0f || array[0].z != 0f) ? Vector3.up : Vector3.right);
		}
		else
		{
			vector = this.pastUp;
		}
		for (int j = 0; j < points.Length; j++)
		{
			Vector3 vector2;
			if (j != 0 && j != points.Length - 1)
			{
				vector2 = array[j] + array[j - 1];
			}
			else if (points[0] == points[points.Length - 1])
			{
				vector2 = array[points.Length - 1] + array[0];
			}
			else
			{
				vector2 = array[j];
			}
			if (vector2 == Vector3.zero)
			{
				array2[j] = Quaternion.identity;
			}
			else
			{
				vector2.Normalize();
				Vector3 vector3 = Vector3.Cross(vector, vector2);
				if (vector3 == Vector3.zero)
				{
					vector3 = Vector3.Cross(new Vector3(-0.3f, 0.1f, 0f), new Vector3(0f, 0f, 0.4f));
				}
				vector = Vector3.Cross(vector2, vector3);
				if (j == 0)
				{
					this.pastUp = vector;
				}
				if (vector3 != Vector3.zero)
				{
					array2[j].SetLookRotation(-vector3, vector);
				}
			}
		}
		return array2;
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0001AE5C File Offset: 0x0001925C
	private Vector3 CalcPositionAtTime(float t)
	{
		int num = this.calculatedPositions.Count - 3;
		int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
		float num3 = t * (float)num - (float)num2;
		Vector3 a = this.calculatedPositions[num2];
		Vector3 a2 = this.calculatedPositions[num2 + 1];
		Vector3 vector = this.calculatedPositions[num2 + 2];
		Vector3 b = this.calculatedPositions[num2 + 3];
		return 0.5f * ((-a + 3f * a2 - 3f * vector + b) * (num3 * num3 * num3) + (2f * a - 5f * a2 + 4f * vector - b) * (num3 * num3) + (-a + vector) * num3 + 2f * a2);
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0001AF7C File Offset: 0x0001937C
	private void UpdatePhysics()
	{
		if (this.Joints.Count == 0 || !this.enablePhysics)
		{
			return;
		}
		for (int i = 0; i < this.Joints.Count; i++)
		{
			GameObject gameObject = this.Joints[i];
			if (gameObject == null)
			{
				return;
			}
			if (gameObject.GetComponent<Rigidbody>() == null)
			{
				gameObject.AddComponent<Rigidbody>();
			}
			switch (this.constraint)
			{
			case RopeConstraint.NONE:
				gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				break;
			case RopeConstraint.X_Y:
				gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)56;
				break;
			case RopeConstraint.Y_Z:
				gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)98;
				break;
			case RopeConstraint.Z_X:
				gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)84;
				break;
			}
			if (this.solverOverride != -1 && this.solverOverride > 1)
			{
				gameObject.GetComponent<Rigidbody>().solverIterations = this.solverOverride;
			}
			gameObject.GetComponent<Rigidbody>().mass = this.mass;
			gameObject.GetComponent<Rigidbody>().angularDrag = this.angDrag;
			gameObject.GetComponent<Rigidbody>().drag = this.drag;
			gameObject.GetComponent<Rigidbody>().useGravity = this.useGravity;
		}
		if (Application.isPlaying)
		{
			for (int j = 0; j < this.Joints.Count - 1; j++)
			{
				this.AddConfigJoint(this.Joints[j]).connectedBody = this.Joints[j + 1].GetComponent<Rigidbody>();
			}
			if (this.colliderType != RopeColliderType.DEFAULT)
			{
				this.AddColliders();
			}
		}
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0001B12C File Offset: 0x0001952C
	private ConfigurableJoint AddConfigJoint(GameObject joint)
	{
		if (Application.isPlaying)
		{
			UnityEngine.Object.Destroy(joint.GetComponent<ConfigurableJoint>());
		}
		else
		{
			UnityEngine.Object.DestroyImmediate(joint.GetComponent<ConfigurableJoint>());
		}
		if (Application.isPlaying && joint.GetComponent<Collider>() && this.colliderType == RopeColliderType.DEFAULT)
		{
			joint.GetComponent<Collider>().enabled = true;
		}
		ConfigurableJoint configurableJoint = joint.AddComponent<ConfigurableJoint>();
		configurableJoint.anchor = Vector3.zero;
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Locked;
		configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
		configurableJoint.lowAngularXLimit = new SoftJointLimit
		{
			limit = this.LowAngXLimit,
			bounciness = this.LTLBounce
		};
		configurableJoint.highAngularXLimit = new SoftJointLimit
		{
			limit = this.HighAngXLimit,
			bounciness = this.LTLBounce
		};
		configurableJoint.angularYLimit = new SoftJointLimit
		{
			limit = this.AngYLimit,
			bounciness = this.S1LBounce
		};
		configurableJoint.angularZLimit = new SoftJointLimit
		{
			limit = this.AngZLimit,
			bounciness = this.S1LBounce
		};
		if (!this.enableRopeController)
		{
			configurableJoint.breakForce = this.breakForce;
			configurableJoint.breakTorque = this.breakTorque;
		}
		return configurableJoint;
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0001B294 File Offset: 0x00019694
	private void AddColliders()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		RopeColliderType ropeColliderType = this.colliderType;
		if (ropeColliderType != RopeColliderType.Sphere)
		{
			if (ropeColliderType == RopeColliderType.Capsule)
			{
				for (int i = 1; i < this.Joints.Count; i++)
				{
					float num = Vector3.Distance(this.Joints[i].transform.position, this.Joints[i - 1].transform.position);
					if (num >= this.colliderRadius)
					{
						CapsuleCollider capsuleCollider = this.Joints[i].AddComponent<CapsuleCollider>();
						capsuleCollider.radius = this.colliderRadius;
						capsuleCollider.center = new Vector3(0f, 0f, num / 2f);
						capsuleCollider.direction = 2;
						capsuleCollider.height = num + (capsuleCollider.radius + capsuleCollider.radius);
						if (this.physicsMaterial != null)
						{
							capsuleCollider.sharedMaterial = this.physicsMaterial;
						}
					}
				}
			}
		}
		else
		{
			for (int j = 1; j < this.Joints.Count - 1; j++)
			{
				SphereCollider sphereCollider = this.Joints[j].AddComponent<SphereCollider>();
				sphereCollider.radius = this.colliderRadius;
				sphereCollider.center = Vector3.zero;
				if (this.physicsMaterial != null)
				{
					sphereCollider.sharedMaterial = this.physicsMaterial;
				}
			}
		}
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0001B414 File Offset: 0x00019814
	private void AttachObjects()
	{
		if (this.enablePhysics && Application.isPlaying)
		{
			foreach (RopeAttachedObject ropeAttachedObject in this.attachedObjects)
			{
				if (!(ropeAttachedObject.go == null))
				{
					if (ropeAttachedObject.jointIndex > this.Joints.Count - 1)
					{
						ropeAttachedObject.jointIndex = this.Joints.Count - 1;
					}
					RopeAttachmentJointType jointType = ropeAttachedObject.jointType;
					if (jointType != RopeAttachmentJointType.Fixed)
					{
						if (jointType == RopeAttachmentJointType.Hinge)
						{
							ropeAttachedObject.jointRef = ropeAttachedObject.go.AddComponent<HingeJoint>();
							(ropeAttachedObject.jointRef as HingeJoint).axis = ropeAttachedObject.hingeAxis;
							ropeAttachedObject.jointRef.connectedBody = this.Joints[ropeAttachedObject.jointIndex].GetComponent<Rigidbody>();
						}
					}
					else
					{
						ropeAttachedObject.jointRef = this.Joints[ropeAttachedObject.jointIndex].AddComponent<FixedJoint>();
						ropeAttachedObject.jointRef.connectedBody = ropeAttachedObject.go.GetComponent<Rigidbody>();
					}
				}
			}
		}
	}

	// Token: 0x06000208 RID: 520 RVA: 0x0001B55C File Offset: 0x0001995C
	[ContextMenu("Apply")]
	public void ApplyRopeSettings()
	{
		if (this.ropeEnd == null)
		{
			return;
		}
		this.calculatedPositions.Clear();
		this.calculatedPositions.TrimExcess();
		this.calculatedPositions.Add(base.transform.position);
		this.calculatedPositions.AddRange(this.controlPoints);
		this.calculatedPositions.Add(this.ropeEnd.transform.position);
		this.calculatedPositions.Insert(0, base.transform.position - (this.calculatedPositions[1] - this.calculatedPositions[0]).normalized);
		this.calculatedPositions.Add(this.calculatedPositions[this.calculatedPositions.Count - 1] + (this.calculatedPositions[this.calculatedPositions.Count - 1] - this.calculatedPositions[this.calculatedPositions.Count - 2]).normalized);
		float num = 0f;
		Vector3 zero = Vector3.zero;
		this.splinePoints.Clear();
		this.splinePoints.TrimExcess();
		this.splinePoints.Add(this.CalcPositionAtTime(num));
		while (num <= 1f)
		{
			Vector3 vector = this.CalcPositionAtTime(num);
			if (Vector3.Distance(this.splinePoints[this.splinePoints.Count - 1], vector + zero) >= this.jointSpacing)
			{
				this.splinePoints.Add(vector);
			}
			num += 0.01f;
		}
		this.splinePoints.Add(this.CalcPositionAtTime(1f));
		this.PreCalculateRotations();
		base.transform.rotation = this.calculatedRotations[0];
		this.ropeEnd.transform.rotation = this.calculatedRotations[this.calculatedRotations.Length - 1];
		if (base.gameObject.GetComponent<QuickRope2Prefab>() == null && base.gameObject.GetComponent<QuickRope2Cloth>() == null)
		{
			this.GenerateJointObjects();
		}
		this.JointPrefab = null;
		if (this.OnInitializeMesh != null)
		{
			this.OnInitializeMesh();
		}
		if (base.gameObject.GetComponent<QuickRope2Cloth>() == null)
		{
			this.UpdatePhysics();
		}
		this.initialized = true;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0001B7DF File Offset: 0x00019BDF
	public void RebuildMesh()
	{
		if (!this.initialized)
		{
			return;
		}
		if (this.OnInitializeMesh != null)
		{
			this.OnInitializeMesh();
		}
	}

	// Token: 0x0600020A RID: 522 RVA: 0x0001B804 File Offset: 0x00019C04
	public void AttachObject(GameObject obj, int jointIndex, RopeAttachmentJointType jointType, Vector3 hingeAxis, bool centerOnIndex)
	{
		if (base.gameObject.GetComponent<QuickRope2Cloth>())
		{
			UnityEngine.Debug.LogError("You must use the \"Cloth\" component to attach objects when using the Cloth mesh type.");
			return;
		}
		RopeAttachedObject ropeAttachedObject = new RopeAttachedObject();
		ropeAttachedObject.go = obj;
		ropeAttachedObject.jointIndex = jointIndex;
		ropeAttachedObject.jointType = jointType;
		ropeAttachedObject.hingeAxis = hingeAxis;
		if (centerOnIndex)
		{
			ropeAttachedObject.go.transform.position = this.Joints[ropeAttachedObject.jointIndex].transform.position;
		}
		this.attachedObjects.Add(ropeAttachedObject);
		if (Application.isPlaying)
		{
			if (ropeAttachedObject.go == null)
			{
				return;
			}
			RopeAttachmentJointType jointType2 = ropeAttachedObject.jointType;
			if (jointType2 != RopeAttachmentJointType.Fixed)
			{
				if (jointType2 == RopeAttachmentJointType.Hinge)
				{
					ropeAttachedObject.jointRef = ropeAttachedObject.go.AddComponent<HingeJoint>();
					(ropeAttachedObject.jointRef as HingeJoint).axis = ropeAttachedObject.hingeAxis;
					ropeAttachedObject.jointRef.connectedBody = this.Joints[ropeAttachedObject.jointIndex].GetComponent<Rigidbody>();
				}
			}
			else
			{
				ropeAttachedObject.jointRef = this.Joints[ropeAttachedObject.jointIndex].AddComponent<FixedJoint>();
				ropeAttachedObject.jointRef.connectedBody = ropeAttachedObject.go.GetComponent<Rigidbody>();
			}
		}
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0001B94B File Offset: 0x00019D4B
	public void AttachObject(GameObject obj, int jointIndex, RopeAttachmentJointType jointType, bool centerOnIndex)
	{
		this.AttachObject(obj, jointIndex, jointType, Vector3.forward, centerOnIndex);
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0001B95D File Offset: 0x00019D5D
	public void AttachObject(GameObject obj, int jointIndex, bool centerOnIndex)
	{
		this.AttachObject(obj, jointIndex, RopeAttachmentJointType.Fixed, centerOnIndex);
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0001B96C File Offset: 0x00019D6C
	public void DetachObject(GameObject obj)
	{
		foreach (RopeAttachedObject ropeAttachedObject in this.attachedObjects)
		{
			if (ropeAttachedObject.go.GetInstanceID() == obj.GetInstanceID())
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(ropeAttachedObject.jointRef);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(ropeAttachedObject.jointRef);
				}
				this.attachedObjects.Remove(ropeAttachedObject);
				this.attachedObjects.TrimExcess();
				break;
			}
		}
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0001BA1C File Offset: 0x00019E1C
	public static QuickRope2 Create(GameObject pointA, GameObject pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		QuickRope2 quickRope = pointA.AddComponent<QuickRope2>();
		quickRope.ropeEnd = pointB;
		switch (ropeType)
		{
		case BasicRopeTypes.Line:
			quickRope.gameObject.AddComponent<QuickRope2Line>();
			break;
		case BasicRopeTypes.Prefab:
			quickRope.gameObject.AddComponent<QuickRope2Prefab>();
			break;
		case BasicRopeTypes.Mesh:
			quickRope.gameObject.AddComponent<QuickRope2Mesh>();
			break;
		case BasicRopeTypes.Cloth:
			quickRope.gameObject.AddComponent<QuickRope2Cloth>();
			break;
		}
		quickRope.ApplyRopeSettings();
		return quickRope;
	}

	// Token: 0x0600020F RID: 527 RVA: 0x0001BAA8 File Offset: 0x00019EA8
	public static QuickRope2 Create(Vector3 pointA, Vector3 pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		GameObject gameObject = new GameObject("Rope");
		GameObject gameObject2 = new GameObject("Rope_End");
		gameObject.transform.position = pointA;
		gameObject2.transform.position = pointB;
		return QuickRope2.Create(gameObject, gameObject2, curvePoints, ropeType);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x0001BAEC File Offset: 0x00019EEC
	public static QuickRope2 Create(GameObject pointA, Vector3 pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		return QuickRope2.Create(pointA, new GameObject("Rope_End")
		{
			transform = 
			{
				position = pointB
			}
		}, curvePoints, ropeType);
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0001BB1C File Offset: 0x00019F1C
	public static QuickRope2 Create(Vector3 pointA, GameObject pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		return QuickRope2.Create(new GameObject("Rope")
		{
			transform = 
			{
				position = pointA
			}
		}, pointB, curvePoints, ropeType);
	}

	// Token: 0x06000212 RID: 530 RVA: 0x0001BB49 File Offset: 0x00019F49
	public static QuickRope2 Create(GameObject pointA, GameObject pointB, BasicRopeTypes ropeType)
	{
		return QuickRope2.Create(pointA, pointB, null, ropeType);
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0001BB54 File Offset: 0x00019F54
	public static QuickRope2 Create(Vector3 pointA, GameObject pointB, BasicRopeTypes ropeType)
	{
		return QuickRope2.Create(pointA, pointB, null, ropeType);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x0001BB5F File Offset: 0x00019F5F
	public static QuickRope2 Create(GameObject pointA, Vector3 pointB, BasicRopeTypes ropeType)
	{
		return QuickRope2.Create(pointA, pointB, null, ropeType);
	}

	// Token: 0x06000215 RID: 533 RVA: 0x0001BB6A File Offset: 0x00019F6A
	public static QuickRope2 Create(Vector3 pointA, Vector3 pointB, BasicRopeTypes ropeType)
	{
		return QuickRope2.Create(pointA, pointB, null, ropeType);
	}

	// Token: 0x0400033C RID: 828
	public const float PRECISION = 0.01f;

	// Token: 0x0400033D RID: 829
	public const int MAX_JOINT_COUNT = 500;

	// Token: 0x0400033E RID: 830
	public const float MAX_JOINT_SPACING = 50f;

	// Token: 0x0400033F RID: 831
	public const float MIN_JOINT_SPACING = 0.1f;

	// Token: 0x04000340 RID: 832
	public GameObject ropeEnd;

	// Token: 0x04000341 RID: 833
	public LayerMask layer;

	// Token: 0x04000342 RID: 834
	public float jointSpacing = 1f;

	// Token: 0x04000343 RID: 835
	public bool showJoints;

	// Token: 0x04000345 RID: 837
	[HideInInspector]
	[SerializeField]
	private GameObject jointPrefab;

	// Token: 0x04000346 RID: 838
	[HideInInspector]
	[SerializeField]
	private float jointScale = 1f;

	// Token: 0x04000347 RID: 839
	[HideInInspector]
	[SerializeField]
	private bool alternateJoints = true;

	// Token: 0x04000348 RID: 840
	[HideInInspector]
	[SerializeField]
	private bool firstJointAlternated;

	// Token: 0x04000349 RID: 841
	[SerializeField]
	private List<Vector3> controlPoints = new List<Vector3>();

	// Token: 0x0400034A RID: 842
	[SerializeField]
	public List<Vector3> splinePoints = new List<Vector3>();

	// Token: 0x0400034B RID: 843
	[SerializeField]
	public List<GameObject> Joints = new List<GameObject>();

	// Token: 0x0400034C RID: 844
	[SerializeField]
	private List<Vector3> calculatedPositions = new List<Vector3>();

	// Token: 0x0400034D RID: 845
	[HideInInspector]
	[SerializeField]
	private Quaternion[] calculatedRotations;

	// Token: 0x0400034E RID: 846
	[HideInInspector]
	[SerializeField]
	public List<RopeAttachedObject> attachedObjects = new List<RopeAttachedObject>();

	// Token: 0x0400034F RID: 847
	private int prevJointcount;

	// Token: 0x04000350 RID: 848
	private float ropeLength;

	// Token: 0x04000351 RID: 849
	private bool freeFallMode;

	// Token: 0x04000352 RID: 850
	private Vector3 pastUp = Vector3.zero;

	// Token: 0x04000353 RID: 851
	private Vector3 pRopeEndPos = Vector3.zero;

	// Token: 0x04000354 RID: 852
	private bool initialized;

	// Token: 0x04000355 RID: 853
	public bool enablePhysics;

	// Token: 0x04000356 RID: 854
	public RopeColliderType colliderType;

	// Token: 0x04000357 RID: 855
	public PhysicMaterial physicsMaterial;

	// Token: 0x04000358 RID: 856
	public float colliderRadius = 0.25f;

	// Token: 0x04000359 RID: 857
	public RopeConstraint constraint;

	// Token: 0x0400035A RID: 858
	public float mass = 1f;

	// Token: 0x0400035B RID: 859
	public float drag = 0.2f;

	// Token: 0x0400035C RID: 860
	public float angDrag = 0.05f;

	// Token: 0x0400035D RID: 861
	public bool useGravity = true;

	// Token: 0x0400035E RID: 862
	public float LowAngXLimit = -60f;

	// Token: 0x0400035F RID: 863
	public float HighAngXLimit = 60f;

	// Token: 0x04000360 RID: 864
	public float LTLBounce;

	// Token: 0x04000361 RID: 865
	public float LTLSpring;

	// Token: 0x04000362 RID: 866
	public float LTLDamper;

	// Token: 0x04000363 RID: 867
	public float AngYLimit = 35f;

	// Token: 0x04000364 RID: 868
	public float AngZLimit = 35f;

	// Token: 0x04000365 RID: 869
	public float S1LBounce;

	// Token: 0x04000366 RID: 870
	public float S1LSpring;

	// Token: 0x04000367 RID: 871
	public float S1LDamper;

	// Token: 0x04000368 RID: 872
	public float breakForce = float.PositiveInfinity;

	// Token: 0x04000369 RID: 873
	public float breakTorque = float.PositiveInfinity;

	// Token: 0x0400036A RID: 874
	public int solverOverride = -1;

	// Token: 0x0400036B RID: 875
	private float distBetweenJoints;

	// Token: 0x0400036C RID: 876
	private float currentVelocity;

	// Token: 0x0400036D RID: 877
	public bool enableRopeController;

	// Token: 0x0400036E RID: 878
	public KeyCode extendRopeKey = KeyCode.DownArrow;

	// Token: 0x0400036F RID: 879
	public KeyCode retractRopeKey = KeyCode.UpArrow;

	// Token: 0x04000370 RID: 880
	public float acceleration = 10f;

	// Token: 0x04000371 RID: 881
	public float dampening = 0.96f;

	// Token: 0x04000372 RID: 882
	public float sleepVelocity = 0.5f;

	// Token: 0x04000373 RID: 883
	public float minRopeLength = 5f;

	// Token: 0x04000374 RID: 884
	public float maxRopeLength = 25f;

	// Token: 0x04000375 RID: 885
	public float maxVelocity = 5f;

	// Token: 0x04000376 RID: 886
	[HideInInspector]
	public int EDITOR_TAB_SELECTED;

	// Token: 0x04000377 RID: 887
	[HideInInspector]
	public static float EDITOR_GUI_SCALE = 0.5f;

	// Token: 0x04000378 RID: 888
	[HideInInspector]
	public bool EDITOR_SHOW_RIGIDBODY = true;

	// Token: 0x04000379 RID: 889
	[HideInInspector]
	public bool EDITOR_SHOW_JOINTSETTINGS;

	// Token: 0x0400037A RID: 890
	[HideInInspector]
	public bool EDITOR_SHOW_COLLIDERSETTINGS;
}
