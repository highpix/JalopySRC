using System;
using UnityEngine;

// Token: 0x02000058 RID: 88
[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour
{
	// Token: 0x060001A6 RID: 422 RVA: 0x00018334 File Offset: 0x00016734
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00018344 File Offset: 0x00016744
	private void Interpolate(float delta)
	{
		Transform parent = this.mTrans.parent;
		if (parent != null)
		{
			this.mAbsolute = Quaternion.Slerp(this.mAbsolute, parent.rotation * this.mRelative, delta * this.speed);
			this.mTrans.rotation = this.mAbsolute;
		}
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x000183A4 File Offset: 0x000167A4
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mRelative = this.mTrans.localRotation;
		this.mAbsolute = this.mTrans.rotation;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x000183D4 File Offset: 0x000167D4
	private void Update()
	{
		this.Interpolate((!this.ignoreTimeScale) ? Time.deltaTime : RealTime.deltaTime);
	}

	// Token: 0x040002E1 RID: 737
	public float speed = 10f;

	// Token: 0x040002E2 RID: 738
	public bool ignoreTimeScale;

	// Token: 0x040002E3 RID: 739
	private Transform mTrans;

	// Token: 0x040002E4 RID: 740
	private Quaternion mRelative;

	// Token: 0x040002E5 RID: 741
	private Quaternion mAbsolute;
}
