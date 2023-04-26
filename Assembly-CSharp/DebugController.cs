using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class DebugController : MonoBehaviour
{
	// Token: 0x0600002C RID: 44 RVA: 0x00003E92 File Offset: 0x00002292
	private void Awake()
	{
		DebugController.Global = this;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00003E9C File Offset: 0x0000229C
	private void Start()
	{
		this.rigid = this.target.GetComponent<Rigidbody>();
		this.startPos = this.target.position;
		this.startRot = this.target.rotation;
		base.Invoke("LateStart", 3f);
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003EEC File Offset: 0x000022EC
	private void LateStart()
	{
		this.components.AddRange(GameObject.Find("FrameHolder").GetComponentsInChildren<EngineComponentC>());
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00003F08 File Offset: 0x00002308
	private void UpdateRPM()
	{
		this.frontLeftRPM = this.wheelColliders[0].rpm;
		this.frontRightRPM = this.wheelColliders[1].rpm;
		this.rearLeftRPM = this.wheelColliders[2].rpm;
		this.rearRightRPM = this.wheelColliders[3].rpm;
		this.frontLeftTorque = this.wheelColliders[0].motorTorque;
		this.frontRightTorque = this.wheelColliders[1].motorTorque;
		this.rearLeftTorque = this.wheelColliders[2].motorTorque;
		this.rearRightTorque = this.wheelColliders[3].motorTorque;
	}

	// Token: 0x0400003B RID: 59
	public static DebugController Global;

	// Token: 0x0400003C RID: 60
	public Transform target;

	// Token: 0x0400003D RID: 61
	private Rigidbody rigid;

	// Token: 0x0400003E RID: 62
	private Vector3 startPos;

	// Token: 0x0400003F RID: 63
	private Quaternion startRot;

	// Token: 0x04000040 RID: 64
	[HideInInspector]
	public List<SphereCollider> wheelSphereColliders;

	// Token: 0x04000041 RID: 65
	public List<WheelCollider> wheelColliders;

	// Token: 0x04000042 RID: 66
	public List<EngineComponentC> components;

	// Token: 0x04000043 RID: 67
	public CarControleScriptC carControle;

	// Token: 0x04000044 RID: 68
	[SerializeField]
	private float carSpeed;

	// Token: 0x04000045 RID: 69
	[Header("Wheel Debug")]
	[SerializeField]
	private float frontLeftRPM;

	// Token: 0x04000046 RID: 70
	[SerializeField]
	private float frontLeftTorque;

	// Token: 0x04000047 RID: 71
	[SerializeField]
	private float frontRightRPM;

	// Token: 0x04000048 RID: 72
	[SerializeField]
	private float frontRightTorque;

	// Token: 0x04000049 RID: 73
	[SerializeField]
	private float rearLeftRPM;

	// Token: 0x0400004A RID: 74
	[SerializeField]
	private float rearLeftTorque;

	// Token: 0x0400004B RID: 75
	[SerializeField]
	private float rearRightRPM;

	// Token: 0x0400004C RID: 76
	[SerializeField]
	private float rearRightTorque;

	// Token: 0x0400004D RID: 77
	[Header("Wheel Debug")]
	public float torqueMultiplier = 1f;
}
