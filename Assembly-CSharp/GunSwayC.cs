using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class GunSwayC : MonoBehaviour
{
	// Token: 0x06000682 RID: 1666 RVA: 0x000831E9 File Offset: 0x000815E9
	private void Start()
	{
		this.def = base.transform.localPosition;
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x000831FC File Offset: 0x000815FC
	private void Update()
	{
		float num = -Input.GetAxis("Mouse X") * this.amount;
		float num2 = -Input.GetAxis("Mouse Y") * this.amountY;
		if ((double)Input.GetAxis("RJoystick X") > 0.1 || (double)Input.GetAxis("RJoystick X") < -0.1)
		{
			num = -Input.GetAxis("RJoystick X") * this.amount * 2f;
		}
		if ((double)Input.GetAxis("RJoystick Y") > 0.1 || (double)Input.GetAxis("RJoystick Y") < -0.1)
		{
			num = -Input.GetAxis("RJoystick Y") * this.amountY * 2f;
		}
		if (num > this.maxAmount)
		{
			num = this.maxAmount;
		}
		if (num < -this.maxAmount)
		{
			num = -this.maxAmount;
		}
		if (num2 > this.maxAmountY)
		{
			num2 = this.maxAmountY;
		}
		if (num2 < -this.maxAmount)
		{
			num2 = -this.maxAmountY;
		}
		Vector3 b = new Vector3(this.def.x + num, this.def.y + num2, this.def.z);
		base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, b, Time.deltaTime * this.Smooth);
		float z = Input.GetAxis("Mouse X") * (float)this.tiltAngle;
		float x = Input.GetAxis("Mouse Y") * (float)this.tiltAngle;
		if ((double)Input.GetAxis("RJoystick X") > 0.1 || (double)Input.GetAxis("RJoystick X") < -0.1)
		{
			z = Input.GetAxis("RJoystick X") * (float)this.tiltAngle * 2f;
		}
		if ((double)Input.GetAxis("RJoystick Y") > 0.1 || (double)Input.GetAxis("RJoystick Y") < -0.1)
		{
			x = Input.GetAxis("RJoystick Y") * (float)this.tiltAngle * 2f;
		}
		Quaternion b2 = Quaternion.Euler(x, 0f, z);
		base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, b2, Time.deltaTime * (float)this.SmoothRotation);
	}

	// Token: 0x040008A8 RID: 2216
	public float amount = 0.02f;

	// Token: 0x040008A9 RID: 2217
	public float amountY = 0.02f;

	// Token: 0x040008AA RID: 2218
	public float maxAmount = 0.03f;

	// Token: 0x040008AB RID: 2219
	public float maxAmountY = 0.03f;

	// Token: 0x040008AC RID: 2220
	public float Smooth = 3f;

	// Token: 0x040008AD RID: 2221
	public int SmoothRotation = 2;

	// Token: 0x040008AE RID: 2222
	public int tiltAngle = 25;

	// Token: 0x040008AF RID: 2223
	private Vector3 def;
}
