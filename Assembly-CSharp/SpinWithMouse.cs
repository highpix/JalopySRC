using System;
using UnityEngine;

// Token: 0x02000060 RID: 96
[AddComponentMenu("NGUI/Examples/Spin With Mouse")]
public class SpinWithMouse : MonoBehaviour
{
	// Token: 0x060001BF RID: 447 RVA: 0x00018B39 File Offset: 0x00016F39
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00018B48 File Offset: 0x00016F48
	private void OnDrag(Vector2 delta)
	{
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
		if (this.target != null)
		{
			this.target.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * this.speed, 0f) * this.target.localRotation;
		}
		else
		{
			this.mTrans.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * this.speed, 0f) * this.mTrans.localRotation;
		}
	}

	// Token: 0x040002FB RID: 763
	public Transform target;

	// Token: 0x040002FC RID: 764
	public float speed = 1f;

	// Token: 0x040002FD RID: 765
	private Transform mTrans;
}
