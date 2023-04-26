using System;
using UnityEngine;

// Token: 0x0200006A RID: 106
public class CraneControl_QR2 : MonoBehaviour
{
	// Token: 0x060001DC RID: 476 RVA: 0x00019204 File Offset: 0x00017604
	private void Update()
	{
		if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
		{
			this.rotationVelocity += this.rotationAccel * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			this.rotationVelocity -= this.rotationAccel * Time.deltaTime;
		}
		else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			this.rotationVelocity *= this.rotationDampening;
		}
		this.rotationVelocity = Mathf.Clamp(this.rotationVelocity, -this.maxRotationVelocity, this.maxRotationVelocity);
		this.craneRotationObject.Rotate(0f, this.rotationVelocity * Time.deltaTime, 0f);
		if (!Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
		{
			this.trollyVelocity += this.trollyAccel * 0.1f * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
		{
			this.trollyVelocity -= this.trollyAccel * 0.1f * Time.deltaTime;
		}
		else if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
		{
			this.trollyVelocity *= this.trollyDampening;
		}
		this.trollyVelocity = Mathf.Clamp(this.trollyVelocity, -this.maxTrollyVelocity * 0.1f, this.maxTrollyVelocity * 0.1f);
		this.trollyPosition += this.trollyVelocity * Time.deltaTime;
		this.trollyPosition = Mathf.Clamp(this.trollyPosition, 0f, 1f);
		if (this.trollyPosition == 0f || this.trollyPosition == 1f)
		{
			this.trollyVelocity = 0f;
		}
		this.trollyObject.transform.position = this.trollyInStop.position + (this.trollyOutStop.position - this.trollyInStop.position) * this.trollyPosition;
	}

	// Token: 0x04000317 RID: 791
	public Transform craneRotationObject;

	// Token: 0x04000318 RID: 792
	public Transform trollyObject;

	// Token: 0x04000319 RID: 793
	public Transform trollyInStop;

	// Token: 0x0400031A RID: 794
	public Transform trollyOutStop;

	// Token: 0x0400031B RID: 795
	private float rotationVelocity;

	// Token: 0x0400031C RID: 796
	public float rotationAccel = 3f;

	// Token: 0x0400031D RID: 797
	public float maxRotationVelocity = 7f;

	// Token: 0x0400031E RID: 798
	public float rotationDampening = 0.985f;

	// Token: 0x0400031F RID: 799
	private float trollyVelocity;

	// Token: 0x04000320 RID: 800
	public float trollyAccel = 3f;

	// Token: 0x04000321 RID: 801
	public float maxTrollyVelocity = 7f;

	// Token: 0x04000322 RID: 802
	public float trollyDampening = 0.985f;

	// Token: 0x04000323 RID: 803
	private float trollyPosition = 0.5f;
}
