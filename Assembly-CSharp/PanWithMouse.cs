using System;
using UnityEngine;

// Token: 0x0200005C RID: 92
[AddComponentMenu("NGUI/Examples/Pan With Mouse")]
public class PanWithMouse : MonoBehaviour
{
	// Token: 0x060001B2 RID: 434 RVA: 0x00018538 File Offset: 0x00016938
	private void Start()
	{
		this.mTrans = base.transform;
		this.mStart = this.mTrans.localRotation;
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00018558 File Offset: 0x00016958
	private void Update()
	{
		float deltaTime = RealTime.deltaTime;
		Vector3 mousePosition = Input.mousePosition;
		float num = (float)Screen.width * 0.5f;
		float num2 = (float)Screen.height * 0.5f;
		if (this.range < 0.1f)
		{
			this.range = 0.1f;
		}
		float x = Mathf.Clamp((mousePosition.x - num) / num / this.range, -1f, 1f);
		float y = Mathf.Clamp((mousePosition.y - num2) / num2 / this.range, -1f, 1f);
		this.mRot = Vector2.Lerp(this.mRot, new Vector2(x, y), deltaTime * 5f);
		this.mTrans.localRotation = this.mStart * Quaternion.Euler(-this.mRot.y * this.degrees.y, this.mRot.x * this.degrees.x, 0f);
	}

	// Token: 0x040002EB RID: 747
	public Vector2 degrees = new Vector2(5f, 3f);

	// Token: 0x040002EC RID: 748
	public float range = 1f;

	// Token: 0x040002ED RID: 749
	private Transform mTrans;

	// Token: 0x040002EE RID: 750
	private Quaternion mStart;

	// Token: 0x040002EF RID: 751
	private Vector2 mRot = Vector2.zero;
}
