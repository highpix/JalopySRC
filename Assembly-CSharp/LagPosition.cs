using System;
using UnityEngine;

// Token: 0x02000057 RID: 87
[AddComponentMenu("NGUI/Examples/Lag Position")]
public class LagPosition : MonoBehaviour
{
	// Token: 0x060001A1 RID: 417 RVA: 0x000181D0 File Offset: 0x000165D0
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x000181E0 File Offset: 0x000165E0
	private void Interpolate(float delta)
	{
		Transform parent = this.mTrans.parent;
		if (parent != null)
		{
			Vector3 vector = parent.position + parent.rotation * this.mRelative;
			this.mAbsolute.x = Mathf.Lerp(this.mAbsolute.x, vector.x, Mathf.Clamp01(delta * this.speed.x));
			this.mAbsolute.y = Mathf.Lerp(this.mAbsolute.y, vector.y, Mathf.Clamp01(delta * this.speed.y));
			this.mAbsolute.z = Mathf.Lerp(this.mAbsolute.z, vector.z, Mathf.Clamp01(delta * this.speed.z));
			this.mTrans.position = this.mAbsolute;
		}
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x000182CF File Offset: 0x000166CF
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mAbsolute = this.mTrans.position;
		this.mRelative = this.mTrans.localPosition;
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x000182FF File Offset: 0x000166FF
	private void Update()
	{
		this.Interpolate((!this.ignoreTimeScale) ? Time.deltaTime : RealTime.deltaTime);
	}

	// Token: 0x040002DC RID: 732
	public Vector3 speed = new Vector3(10f, 10f, 10f);

	// Token: 0x040002DD RID: 733
	public bool ignoreTimeScale;

	// Token: 0x040002DE RID: 734
	private Transform mTrans;

	// Token: 0x040002DF RID: 735
	private Vector3 mRelative;

	// Token: 0x040002E0 RID: 736
	private Vector3 mAbsolute;
}
