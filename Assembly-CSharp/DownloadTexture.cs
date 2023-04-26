using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000053 RID: 83
[RequireComponent(typeof(UITexture))]
public class DownloadTexture : MonoBehaviour
{
	// Token: 0x06000197 RID: 407 RVA: 0x00017E80 File Offset: 0x00016280
	private IEnumerator Start()
	{
		WWW www = new WWW(this.url);
		yield return www;
		this.mTex = www.texture;
		if (this.mTex != null)
		{
			UITexture component = base.GetComponent<UITexture>();
			component.mainTexture = this.mTex;
			if (this.pixelPerfect)
			{
				component.MakePixelPerfect();
			}
		}
		www.Dispose();
		yield break;
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00017E9B File Offset: 0x0001629B
	private void OnDestroy()
	{
		if (this.mTex != null)
		{
			UnityEngine.Object.Destroy(this.mTex);
		}
	}

	// Token: 0x040002D1 RID: 721
	public string url = "http://www.yourwebsite.com/logo.png";

	// Token: 0x040002D2 RID: 722
	public bool pixelPerfect = true;

	// Token: 0x040002D3 RID: 723
	private Texture2D mTex;
}
