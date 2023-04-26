using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	// Token: 0x060001CB RID: 459 RVA: 0x00018ECC File Offset: 0x000172CC
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mLastPos = this.mTrans.position;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00018EEC File Offset: 0x000172EC
	private void Update()
	{
		Vector3 vector = this.mTrans.position - this.mLastPos;
		this.mLastPos = this.mTrans.position;
		this.mAngle += vector.x * this.degrees;
		this.mAngle = NGUIMath.SpringLerp(this.mAngle, 0f, 20f, Time.deltaTime);
		this.mTrans.localRotation = Quaternion.Euler(0f, 0f, -this.mAngle);
	}

	// Token: 0x04000306 RID: 774
	public int updateOrder;

	// Token: 0x04000307 RID: 775
	public float degrees = 30f;

	// Token: 0x04000308 RID: 776
	private Vector3 mLastPos;

	// Token: 0x04000309 RID: 777
	private Transform mTrans;

	// Token: 0x0400030A RID: 778
	private float mAngle;
}
