using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class IconRelayC : MonoBehaviour
{
	// Token: 0x060006C8 RID: 1736 RVA: 0x00088E43 File Offset: 0x00087243
	public void UnlockIcon()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.unlockedIcon;
		this.isUnlocked = true;
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x00088E60 File Offset: 0x00087260
	public void RaycastEnter()
	{
		base.transform.localScale = this.bigScale;
		this.bigIcon.GetComponent<SpriteRenderer>().sprite = base.gameObject.GetComponent<SpriteRenderer>().sprite;
		if (this.isUnlocked)
		{
			this.title.GetComponent<TextMesh>().text = Language.Get(this.stringTitle, "Inspector_UI");
			this.description.GetComponent<TextMesh>().text = Language.Get(this.stringDescription, "Inspector_UI");
			for (int i = 0; i < this.bigSprites.Length; i++)
			{
				this.bigSprites[i].SetActive(false);
			}
			this.bigSprites[this._id].SetActive(true);
		}
		else
		{
			this.title.GetComponent<TextMesh>().text = "???";
			this.description.GetComponent<TextMesh>().text = "???";
		}
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00088F54 File Offset: 0x00087354
	public void RaycastExit()
	{
		base.transform.localScale = this.smallScale;
		this.bigIcon.GetComponent<SpriteRenderer>().sprite = this.defaultSprite;
		this.title.GetComponent<TextMesh>().text = string.Empty;
		this.description.GetComponent<TextMesh>().text = string.Empty;
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00088FB2 File Offset: 0x000873B2
	public void UnlockStamp()
	{
		this.isUnlocked = true;
		base.transform.GetChild(0).gameObject.SetActive(true);
	}

	// Token: 0x0400093B RID: 2363
	public bool isUnlocked;

	// Token: 0x0400093C RID: 2364
	public string stringTitle = string.Empty;

	// Token: 0x0400093D RID: 2365
	public string stringDescription = string.Empty;

	// Token: 0x0400093E RID: 2366
	public GameObject bigIcon;

	// Token: 0x0400093F RID: 2367
	public GameObject title;

	// Token: 0x04000940 RID: 2368
	public GameObject description;

	// Token: 0x04000941 RID: 2369
	public Sprite unlockedIcon;

	// Token: 0x04000942 RID: 2370
	public Sprite defaultSprite;

	// Token: 0x04000943 RID: 2371
	public Vector3 smallScale;

	// Token: 0x04000944 RID: 2372
	public Vector3 bigScale;

	// Token: 0x04000945 RID: 2373
	public GameObject[] bigSprites = new GameObject[0];

	// Token: 0x04000946 RID: 2374
	public int _id;
}
