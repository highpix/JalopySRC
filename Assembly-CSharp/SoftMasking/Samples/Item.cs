using System;
using UnityEngine;
using UnityEngine.UI;

namespace SoftMasking.Samples
{
	// Token: 0x02000139 RID: 313
	public class Item : MonoBehaviour
	{
		// Token: 0x06000C7C RID: 3196 RVA: 0x0012BF10 File Offset: 0x0012A310
		public void Set(string name, Sprite sprite, Color color, float health, float damage)
		{
			if (this.image)
			{
				this.image.sprite = sprite;
				this.image.color = color;
			}
			if (this.title)
			{
				this.title.text = name;
			}
			if (this.description)
			{
				this.description.text = "The short description of " + name;
			}
			if (this.healthBar)
			{
				this.healthBar.anchorMax = new Vector2(health, 1f);
			}
			if (this.damageBar)
			{
				this.damageBar.anchorMax = new Vector2(damage, 1f);
			}
		}

		// Token: 0x0400112B RID: 4395
		public Image image;

		// Token: 0x0400112C RID: 4396
		public Text title;

		// Token: 0x0400112D RID: 4397
		public Text description;

		// Token: 0x0400112E RID: 4398
		public RectTransform healthBar;

		// Token: 0x0400112F RID: 4399
		public RectTransform damageBar;
	}
}
