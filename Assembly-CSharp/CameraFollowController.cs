using System;
using UnityEngine;

// Token: 0x02000096 RID: 150
public class CameraFollowController : MonoBehaviour
{
	// Token: 0x060004B1 RID: 1201 RVA: 0x0004EFD4 File Offset: 0x0004D3D4
	public void LookAtTarget()
	{
		Vector3 forward = this.objectToFollow.position - base.transform.position;
		Quaternion b = Quaternion.LookRotation(forward, Vector3.up);
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, this.lookSpeed * Time.deltaTime);
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x0004F034 File Offset: 0x0004D434
	public void MoveToTarget()
	{
		Vector3 b = this.objectToFollow.position + this.objectToFollow.forward * this.offset.z + this.objectToFollow.right * this.offset.x + this.objectToFollow.up * this.offset.y;
		base.transform.position = Vector3.Lerp(base.transform.position, b, this.followSpeed * Time.deltaTime);
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x0004F0D5 File Offset: 0x0004D4D5
	private void FixedUpdate()
	{
		this.LookAtTarget();
		this.MoveToTarget();
	}

	// Token: 0x040006CF RID: 1743
	public Transform objectToFollow;

	// Token: 0x040006D0 RID: 1744
	public Vector3 offset;

	// Token: 0x040006D1 RID: 1745
	public float followSpeed = 10f;

	// Token: 0x040006D2 RID: 1746
	public float lookSpeed = 10f;
}
