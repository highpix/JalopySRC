using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
public class AutoRotateObject : MonoBehaviour
{
	// Token: 0x06000132 RID: 306 RVA: 0x0001384C File Offset: 0x00011C4C
	private void Start()
	{
		base.GetComponent<Animation>().GetClip("idle1").wrapMode = WrapMode.Loop;
		base.GetComponent<Animation>().Play("idle1");
		this.speed += UnityEngine.Random.Range(-10f, 10f);
		this.rotating = true;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x000138A3 File Offset: 0x00011CA3
	private void Update()
	{
		if (this.rotating)
		{
			base.transform.Rotate(Vector3.up * 60f * Time.deltaTime * (float)this.dir);
		}
	}

	// Token: 0x06000134 RID: 308 RVA: 0x000138E0 File Offset: 0x00011CE0
	private void OnMouseDown()
	{
		this.rotating = !this.rotating;
		if (this.rotating)
		{
			this.dir = ((this.dir >= 0) ? -1 : 1);
		}
	}

	// Token: 0x04000254 RID: 596
	public int dir = 1;

	// Token: 0x04000255 RID: 597
	private bool rotating;

	// Token: 0x04000256 RID: 598
	private float speed = 50f;
}
