using System;
using UnityEngine;

// Token: 0x02000161 RID: 353
public class XboxChangeSprite : MonoBehaviour
{
	// Token: 0x06000D91 RID: 3473 RVA: 0x00132C36 File Offset: 0x00131036
	private void Start()
	{
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.xboxSprite;
			base.transform.localScale *= 1.2f;
		}
	}

	// Token: 0x04001227 RID: 4647
	public Sprite xboxSprite;
}
