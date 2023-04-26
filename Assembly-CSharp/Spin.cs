using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
	// Token: 0x060001BA RID: 442 RVA: 0x00018A45 File Offset: 0x00016E45
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRb = base.GetComponent<Rigidbody>();
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00018A5F File Offset: 0x00016E5F
	private void Update()
	{
		if (this.mRb == null)
		{
			this.ApplyDelta((!this.ignoreTimeScale) ? Time.deltaTime : RealTime.deltaTime);
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00018A92 File Offset: 0x00016E92
	private void FixedUpdate()
	{
		if (this.mRb != null)
		{
			this.ApplyDelta(Time.deltaTime);
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00018AB0 File Offset: 0x00016EB0
	public void ApplyDelta(float delta)
	{
		delta *= 360f;
		Quaternion rhs = Quaternion.Euler(this.rotationsPerSecond * delta);
		if (this.mRb == null)
		{
			this.mTrans.rotation = this.mTrans.rotation * rhs;
		}
		else
		{
			this.mRb.MoveRotation(this.mRb.rotation * rhs);
		}
	}

	// Token: 0x040002F7 RID: 759
	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

	// Token: 0x040002F8 RID: 760
	public bool ignoreTimeScale;

	// Token: 0x040002F9 RID: 761
	private Rigidbody mRb;

	// Token: 0x040002FA RID: 762
	private Transform mTrans;
}
