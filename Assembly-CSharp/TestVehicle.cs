using System;
using UnityEngine;

// Token: 0x0200014F RID: 335
public class TestVehicle : MonoBehaviour
{
	// Token: 0x06000D29 RID: 3369 RVA: 0x0012E985 File Offset: 0x0012CD85
	private void Awake()
	{
	}

	// Token: 0x06000D2A RID: 3370 RVA: 0x0012E987 File Offset: 0x0012CD87
	private void GetInput()
	{
		this.horizontalInput = Input.GetAxis("Horizontal");
		this.verticalInput = Input.GetAxis("Vertical");
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x0012E9A9 File Offset: 0x0012CDA9
	private void Steer()
	{
		this.steeringAngle = this.maxSteerAngle * this.horizontalInput;
		this.frontLeft.steerAngle = this.steeringAngle;
		this.frontRight.steerAngle = this.steeringAngle;
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x0012E9E0 File Offset: 0x0012CDE0
	private void Accelerate()
	{
		this.frontLeft.motorTorque = this.verticalInput * this.motorForce;
		this.frontRight.motorTorque = this.verticalInput * this.motorForce;
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x0012EA12 File Offset: 0x0012CE12
	private void UpdateWheelPoses()
	{
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x0012EA14 File Offset: 0x0012CE14
	private void UpdateWheelPose(WheelCollider wc)
	{
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x0012EA16 File Offset: 0x0012CE16
	private void FixedUpdate()
	{
		this.GetInput();
		this.Steer();
		this.Accelerate();
		this.UpdateWheelPoses();
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x0012EA30 File Offset: 0x0012CE30
	private void Update()
	{
	}

	// Token: 0x0400119F RID: 4511
	public WheelCollider frontLeft;

	// Token: 0x040011A0 RID: 4512
	public WheelCollider frontRight;

	// Token: 0x040011A1 RID: 4513
	public WheelCollider rearLeft;

	// Token: 0x040011A2 RID: 4514
	public WheelCollider rearRight;

	// Token: 0x040011A3 RID: 4515
	public float maxSteerAngle = 30f;

	// Token: 0x040011A4 RID: 4516
	public float motorForce = 50f;

	// Token: 0x040011A5 RID: 4517
	private float horizontalInput;

	// Token: 0x040011A6 RID: 4518
	private float verticalInput;

	// Token: 0x040011A7 RID: 4519
	private float steeringAngle;
}
