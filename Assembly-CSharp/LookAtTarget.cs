using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
[AddComponentMenu("NGUI/Examples/Look At Target")]
public class LookAtTarget : MonoBehaviour
{
	// Token: 0x060001AD RID: 429 RVA: 0x0001842E File Offset: 0x0001682E
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x0001843C File Offset: 0x0001683C
	private void LateUpdate()
	{
		if (this.target != null)
		{
			Vector3 forward = this.target.position - this.mTrans.position;
			float magnitude = forward.magnitude;
			if (magnitude > 0.001f)
			{
				Quaternion b = Quaternion.LookRotation(forward);
				this.mTrans.rotation = Quaternion.Slerp(this.mTrans.rotation, b, Mathf.Clamp01(this.speed * Time.deltaTime));
			}
		}
	}

	// Token: 0x040002E7 RID: 743
	public int level;

	// Token: 0x040002E8 RID: 744
	public Transform target;

	// Token: 0x040002E9 RID: 745
	public float speed = 8f;

	// Token: 0x040002EA RID: 746
	private Transform mTrans;
}
