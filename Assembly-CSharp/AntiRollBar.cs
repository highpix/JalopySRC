using System;
using UnityEngine;

// Token: 0x02000134 RID: 308
public class AntiRollBar : MonoBehaviour
{
	// Token: 0x06000C6B RID: 3179 RVA: 0x0012BA09 File Offset: 0x00129E09
	private void Start()
	{
		base.InvokeRepeating("SlowUpdate", 0f, 0.25f);
	}

	// Token: 0x06000C6C RID: 3180 RVA: 0x0012BA20 File Offset: 0x00129E20
	private void SlowUpdate()
	{
		float num = 1f;
		float num2 = 1f;
		WheelHit wheelHit;
		bool groundHit = this.WheelL.GetGroundHit(out wheelHit);
		if (groundHit)
		{
			num = (-this.WheelL.transform.InverseTransformPoint(wheelHit.point).y - this.WheelL.radius) / this.WheelL.suspensionDistance;
		}
		bool groundHit2 = this.WheelR.GetGroundHit(out wheelHit);
		if (groundHit2)
		{
			num2 = (-this.WheelR.transform.InverseTransformPoint(wheelHit.point).y - this.WheelR.radius) / this.WheelR.suspensionDistance;
		}
		float num3 = (num - num2) * this.AntiRoll;
		if (groundHit)
		{
			base.GetComponent<Rigidbody>().AddForceAtPosition(this.WheelL.transform.up * -num3, this.WheelL.transform.position);
		}
		if (groundHit2)
		{
			base.GetComponent<Rigidbody>().AddForceAtPosition(this.WheelR.transform.up * num3, this.WheelR.transform.position);
		}
	}

	// Token: 0x0400111B RID: 4379
	public WheelCollider WheelL;

	// Token: 0x0400111C RID: 4380
	public WheelCollider WheelR;

	// Token: 0x0400111D RID: 4381
	public float AntiRoll = 5000f;
}
