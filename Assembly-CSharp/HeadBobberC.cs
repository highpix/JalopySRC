using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class HeadBobberC : MonoBehaviour
{
	// Token: 0x06000685 RID: 1669 RVA: 0x0008348C File Offset: 0x0008188C
	private void Update()
	{
		float num = 0f;
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		if (Mathf.Abs(axis) == 0f && Mathf.Abs(axis2) == 0f)
		{
			this.timer = 0f;
		}
		else
		{
			num = Mathf.Sin(this.timer);
			this.timer += this.bobbingSpeed * Time.deltaTime;
			if (this.timer > 6.2831855f)
			{
				this.timer -= 6.2831855f;
			}
		}
		if (num != 0f)
		{
			float num2 = num * this.bobbingAmount;
			float num3 = Mathf.Abs(axis) + Mathf.Abs(axis2);
			num3 = Mathf.Clamp(num3, 0f, 1f);
			num2 = num3 * num2;
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.midpoint + num2, base.transform.localPosition.z);
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.midpoint, base.transform.localPosition.z);
		}
	}

	// Token: 0x040008B0 RID: 2224
	private float timer;

	// Token: 0x040008B1 RID: 2225
	public float bobbingSpeed = 0.18f;

	// Token: 0x040008B2 RID: 2226
	public float bobbingAmount = 0.2f;

	// Token: 0x040008B3 RID: 2227
	public float midpoint = 2f;
}
