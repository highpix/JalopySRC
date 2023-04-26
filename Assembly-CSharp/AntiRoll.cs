using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200010B RID: 267
public class AntiRoll : MonoBehaviour
{
	// Token: 0x06000A92 RID: 2706 RVA: 0x000F9106 File Offset: 0x000F7506
	private void Start()
	{
	}

	// Token: 0x06000A93 RID: 2707 RVA: 0x000F9108 File Offset: 0x000F7508
	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "MainMenu")
		{
			return;
		}
		float num = 1f;
		float num2 = 1f;
		WheelHit wheelHit;
		bool groundHit = this.wheelL.GetGroundHit(out wheelHit);
		if (groundHit)
		{
			num = (-this.wheelL.transform.InverseTransformPoint(wheelHit.point).y - this.wheelL.radius) / this.wheelL.suspensionDistance;
		}
		bool groundHit2 = this.wheelR.GetGroundHit(out wheelHit);
		if (groundHit2)
		{
			num2 = (-this.wheelR.transform.InverseTransformPoint(wheelHit.point).y - this.wheelR.radius) / this.wheelR.suspensionDistance;
		}
		float num3 = (num - num2) * this.antiRollVal;
		if (groundHit)
		{
			base.GetComponent<Rigidbody>().AddForceAtPosition(this.wheelL.transform.up * -num3, this.wheelL.transform.position);
		}
		if (groundHit2)
		{
			base.GetComponent<Rigidbody>().AddForceAtPosition(this.wheelR.transform.up * num3, this.wheelR.transform.position);
		}
	}

	// Token: 0x04000E9B RID: 3739
	public WheelCollider wheelL;

	// Token: 0x04000E9C RID: 3740
	public WheelCollider wheelR;

	// Token: 0x04000E9D RID: 3741
	public float antiRollVal = 5000f;
}
