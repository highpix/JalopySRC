using System;
using UnityEngine;

// Token: 0x02000168 RID: 360
public class XboxPromptAnimation : MonoBehaviour
{
	// Token: 0x06000DB9 RID: 3513 RVA: 0x00134411 File Offset: 0x00132811
	private void Start()
	{
		this.sRender = base.GetComponent<SpriteRenderer>();
		if (Application.platform != RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06000DBA RID: 3514 RVA: 0x00134438 File Offset: 0x00132838
	private void Update()
	{
		this.passTime += Time.deltaTime;
		if (this.passTime > this.frameCount)
		{
			this.passTime = 0f;
			for (int i = 0; i < this.frames.Length; i++)
			{
				if (this.sRender.sprite != this.frames[i])
				{
					this.sRender.sprite = this.frames[i];
					return;
				}
			}
		}
	}

	// Token: 0x04001261 RID: 4705
	public Sprite[] frames = new Sprite[0];

	// Token: 0x04001262 RID: 4706
	public float frameCount = 0.12f;

	// Token: 0x04001263 RID: 4707
	private float passTime;

	// Token: 0x04001264 RID: 4708
	private SpriteRenderer sRender;
}
