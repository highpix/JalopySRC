using System;
using UnityEngine;

namespace SoftMasking.Samples
{
	// Token: 0x0200013A RID: 314
	public class ItemsGenerator : MonoBehaviour
	{
		// Token: 0x06000C7E RID: 3198 RVA: 0x0012BFE0 File Offset: 0x0012A3E0
		public void Generate()
		{
			this.DestroyChildren();
			int num = UnityEngine.Random.Range(0, ItemsGenerator.colors.Length - 1);
			for (int i = 0; i < this.count; i++)
			{
				Item item = UnityEngine.Object.Instantiate<Item>(this.itemPrefab);
				item.transform.SetParent(this.target, false);
				item.Set(string.Format("{0} {1:D2}", this.baseName, i + 1), this.image, ItemsGenerator.colors[(num + i) % ItemsGenerator.colors.Length], UnityEngine.Random.Range(0.4f, 1f), UnityEngine.Random.Range(0.4f, 1f));
			}
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0012C094 File Offset: 0x0012A494
		private void DestroyChildren()
		{
			while (this.target.childCount > 0)
			{
				UnityEngine.Object.DestroyImmediate(this.target.GetChild(0).gameObject);
			}
		}

		// Token: 0x04001130 RID: 4400
		public RectTransform target;

		// Token: 0x04001131 RID: 4401
		public Sprite image;

		// Token: 0x04001132 RID: 4402
		public int count;

		// Token: 0x04001133 RID: 4403
		public string baseName;

		// Token: 0x04001134 RID: 4404
		public Item itemPrefab;

		// Token: 0x04001135 RID: 4405
		private static Color[] colors = new Color[]
		{
			Color.red,
			Color.green,
			Color.blue,
			Color.cyan,
			Color.yellow,
			Color.magenta,
			Color.gray
		};
	}
}
