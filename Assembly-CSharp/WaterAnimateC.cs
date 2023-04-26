using System;
using UnityEngine;

// Token: 0x02000129 RID: 297
public class WaterAnimateC : MonoBehaviour
{
	// Token: 0x06000C25 RID: 3109 RVA: 0x00127730 File Offset: 0x00125B30
	private void LateUpdate()
	{
		this.uvOffset += this.uvAnimationRate * Time.deltaTime;
		if (base.GetComponent<Renderer>().enabled)
		{
			base.GetComponent<Renderer>().materials[this.materialIndex].SetTextureOffset(this.textureName, this.uvOffset);
		}
	}

	// Token: 0x040010A3 RID: 4259
	public int materialIndex;

	// Token: 0x040010A4 RID: 4260
	public Vector2 uvAnimationRate = new Vector2(1f, 0f);

	// Token: 0x040010A5 RID: 4261
	public string textureName = "_MainTex";

	// Token: 0x040010A6 RID: 4262
	public Vector2 uvOffset = Vector2.zero;
}
