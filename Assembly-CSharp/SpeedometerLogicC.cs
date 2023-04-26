using System;
using UnityEngine;

// Token: 0x02000089 RID: 137
public class SpeedometerLogicC : MonoBehaviour
{
	// Token: 0x06000425 RID: 1061 RVA: 0x00043B16 File Offset: 0x00041F16
	private void Start()
	{
		this.rot0 = base.transform.localRotation;
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x00043B2C File Offset: 0x00041F2C
	public void SetNeedle(float vel)
	{
		if (vel > 215f)
		{
			vel = 215f;
		}
		float x = vel * this.maxAngle / this.maxVel;
		base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, Quaternion.Euler(x, 0f, 0f) * this.rot0, Time.deltaTime * 5f);
	}

	// Token: 0x0400060D RID: 1549
	public float maxAngle = 100f;

	// Token: 0x0400060E RID: 1550
	public float maxVel = 99f;

	// Token: 0x0400060F RID: 1551
	private Quaternion rot0;
}
