using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000046 RID: 70
[AddComponentMenu("NGUI/Examples/UI Item Storage")]
public class UIItemStorage : MonoBehaviour
{
	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000169 RID: 361 RVA: 0x00016F40 File Offset: 0x00015340
	public List<InvGameItem> items
	{
		get
		{
			while (this.mItems.Count < this.maxItemCount)
			{
				this.mItems.Add(null);
			}
			return this.mItems;
		}
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00016F6F File Offset: 0x0001536F
	public InvGameItem GetItem(int slot)
	{
		return (slot >= this.items.Count) ? null : this.mItems[slot];
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00016F94 File Offset: 0x00015394
	public InvGameItem Replace(int slot, InvGameItem item)
	{
		if (slot < this.maxItemCount)
		{
			InvGameItem result = this.items[slot];
			this.mItems[slot] = item;
			return result;
		}
		return item;
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00016FCC File Offset: 0x000153CC
	private void Start()
	{
		if (this.template != null)
		{
			int num = 0;
			Bounds bounds = default(Bounds);
			for (int i = 0; i < this.maxRows; i++)
			{
				for (int j = 0; j < this.maxColumns; j++)
				{
					GameObject gameObject = NGUITools.AddChild(base.gameObject, this.template);
					Transform transform = gameObject.transform;
					transform.localPosition = new Vector3((float)this.padding + ((float)j + 0.5f) * (float)this.spacing, (float)(-(float)this.padding) - ((float)i + 0.5f) * (float)this.spacing, 0f);
					UIStorageSlot component = gameObject.GetComponent<UIStorageSlot>();
					if (component != null)
					{
						component.storage = this;
						component.slot = num;
					}
					bounds.Encapsulate(new Vector3((float)this.padding * 2f + (float)((j + 1) * this.spacing), (float)(-(float)this.padding) * 2f - (float)((i + 1) * this.spacing), 0f));
					if (++num >= this.maxItemCount)
					{
						if (this.background != null)
						{
							this.background.transform.localScale = bounds.size;
						}
						return;
					}
				}
			}
			if (this.background != null)
			{
				this.background.transform.localScale = bounds.size;
			}
		}
	}

	// Token: 0x04000281 RID: 641
	public int maxItemCount = 8;

	// Token: 0x04000282 RID: 642
	public int maxRows = 4;

	// Token: 0x04000283 RID: 643
	public int maxColumns = 4;

	// Token: 0x04000284 RID: 644
	public GameObject template;

	// Token: 0x04000285 RID: 645
	public UIWidget background;

	// Token: 0x04000286 RID: 646
	public int spacing = 128;

	// Token: 0x04000287 RID: 647
	public int padding = 10;

	// Token: 0x04000288 RID: 648
	private List<InvGameItem> mItems = new List<InvGameItem>();
}
