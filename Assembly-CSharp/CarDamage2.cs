using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class CarDamage2 : MonoBehaviour
{
	// Token: 0x06000005 RID: 5 RVA: 0x00002134 File Offset: 0x00000534
	public void Start()
	{
		if (this.optionalMeshList.Length > 0)
		{
			this.meshfilters = this.optionalMeshList;
		}
		else
		{
			this.meshfilters = base.GetComponentsInChildren<MeshFilter>();
		}
		this.sqrDemRange = this.demolutionRange * this.demolutionRange;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002174 File Offset: 0x00000574
	public void OnCollisionEnter(Collision collision)
	{
		Vector3 relativeVelocity = collision.relativeVelocity;
		relativeVelocity.y *= this.YforceDamp;
		Vector3 vector = base.transform.position - collision.contacts[0].point;
		float num = relativeVelocity.magnitude * Vector3.Dot(collision.contacts[0].normal, vector.normalized);
		this.OnMeshForce(collision.contacts[0].point, Mathf.Clamp01(num / this.maxCollisionStrength));
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002208 File Offset: 0x00000608
	public void OnMeshForce(Vector4 originPosAndForce)
	{
		this.OnMeshForce(originPosAndForce, originPosAndForce.w);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002220 File Offset: 0x00000620
	public void OnMeshForce(Vector3 originPos, float force)
	{
		force = Mathf.Clamp01(force);
		for (int i = 0; i < this.meshfilters.Length; i++)
		{
			Vector3[] vertices = this.meshfilters[i].mesh.vertices;
			for (int j = 0; j < vertices.Length; j++)
			{
				Vector3 point = Vector3.Scale(vertices[j], base.transform.localScale);
				Vector3 vector = this.meshfilters[i].transform.position + this.meshfilters[i].transform.rotation * point;
				Vector3 a = vector - originPos;
				Vector3 b = base.transform.position - vector;
				b.y = 0f;
				if (a.sqrMagnitude < this.sqrDemRange)
				{
					float num = Mathf.Clamp01(a.sqrMagnitude / this.sqrDemRange);
					float d = force * (1f - num) * this.maxMoveDelta;
					Vector3 point2 = Vector3.Slerp(a, b, this.impactDirManipulator).normalized * d;
					vertices[j] += Quaternion.Inverse(base.transform.rotation) * point2;
				}
			}
			this.meshfilters[i].mesh.vertices = vertices;
			this.meshfilters[i].mesh.RecalculateBounds();
		}
	}

	// Token: 0x04000004 RID: 4
	public float maxMoveDelta = 1f;

	// Token: 0x04000005 RID: 5
	public float maxCollisionStrength = 50f;

	// Token: 0x04000006 RID: 6
	public float YforceDamp = 0.1f;

	// Token: 0x04000007 RID: 7
	public float demolutionRange = 0.5f;

	// Token: 0x04000008 RID: 8
	public float impactDirManipulator;

	// Token: 0x04000009 RID: 9
	public MeshFilter[] optionalMeshList;

	// Token: 0x0400000A RID: 10
	private MeshFilter[] meshfilters;

	// Token: 0x0400000B RID: 11
	private float sqrDemRange;
}
