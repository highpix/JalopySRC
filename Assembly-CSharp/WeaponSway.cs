using System;
using UnityEngine;

// Token: 0x0200012D RID: 301
public class WeaponSway : MonoBehaviour
{
	// Token: 0x06000C42 RID: 3138 RVA: 0x00129175 File Offset: 0x00127575
	private void Start()
	{
		this.def = base.transform.localRotation;
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x00129188 File Offset: 0x00127588
	private void Update()
	{
		float num = Input.GetAxis("Mouse Y") * this.amount;
		float num2 = -Input.GetAxis("Mouse X") * this.amount;
		float num3 = 0f * this.amount;
		if (!this.Paused)
		{
			if (num > this.maxamount)
			{
				num = this.maxamount;
			}
			if (num < -this.maxamount)
			{
				num = -this.maxamount;
			}
			if (num2 > this.maxamount)
			{
				num2 = this.maxamount;
			}
			if (num2 < -this.maxamount)
			{
				num2 = -this.maxamount;
			}
			if (num3 > this.maxamount)
			{
				num3 = this.maxamount;
			}
			if (num3 < -this.maxamount)
			{
				num3 = -this.maxamount;
			}
			Quaternion b = Quaternion.Euler(this.def.x + num, this.def.y + num2, this.def.z + num3);
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, b, Time.time * this.smooth);
		}
	}

	// Token: 0x040010D5 RID: 4309
	public float amount = 0.02f;

	// Token: 0x040010D6 RID: 4310
	public float maxamount = 0.03f;

	// Token: 0x040010D7 RID: 4311
	public float smooth = 3f;

	// Token: 0x040010D8 RID: 4312
	private Quaternion def;

	// Token: 0x040010D9 RID: 4313
	private bool Paused;
}
