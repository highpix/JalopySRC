using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
[AddComponentMenu("NGUI/Examples/Window Auto-Yaw")]
public class WindowAutoYaw : MonoBehaviour
{
	// Token: 0x060001C7 RID: 455 RVA: 0x00018E06 File Offset: 0x00017206
	private void OnDisable()
	{
		this.mTrans.localRotation = Quaternion.identity;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00018E18 File Offset: 0x00017218
	private void OnEnable()
	{
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.mTrans = base.transform;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00018E50 File Offset: 0x00017250
	private void Update()
	{
		if (this.uiCamera != null)
		{
			Vector3 vector = this.uiCamera.WorldToViewportPoint(this.mTrans.position);
			this.mTrans.localRotation = Quaternion.Euler(0f, (vector.x * 2f - 1f) * this.yawAmount, 0f);
		}
	}

	// Token: 0x04000302 RID: 770
	public int updateOrder;

	// Token: 0x04000303 RID: 771
	public Camera uiCamera;

	// Token: 0x04000304 RID: 772
	public float yawAmount = 20f;

	// Token: 0x04000305 RID: 773
	private Transform mTrans;
}
