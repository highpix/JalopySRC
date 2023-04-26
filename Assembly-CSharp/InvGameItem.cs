using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200004D RID: 77
[Serializable]
public class InvGameItem
{
	// Token: 0x06000186 RID: 390 RVA: 0x0001770A File Offset: 0x00015B0A
	public InvGameItem(int id)
	{
		this.mBaseItemID = id;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00017727 File Offset: 0x00015B27
	public InvGameItem(int id, InvBaseItem bi)
	{
		this.mBaseItemID = id;
		this.mBaseItem = bi;
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000188 RID: 392 RVA: 0x0001774B File Offset: 0x00015B4B
	public int baseItemID
	{
		get
		{
			return this.mBaseItemID;
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000189 RID: 393 RVA: 0x00017753 File Offset: 0x00015B53
	public InvBaseItem baseItem
	{
		get
		{
			if (this.mBaseItem == null)
			{
				this.mBaseItem = InvDatabase.FindByID(this.baseItemID);
			}
			return this.mBaseItem;
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x0600018A RID: 394 RVA: 0x00017777 File Offset: 0x00015B77
	public string name
	{
		get
		{
			if (this.baseItem == null)
			{
				return null;
			}
			return this.quality.ToString() + " " + this.baseItem.name;
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600018B RID: 395 RVA: 0x000177AC File Offset: 0x00015BAC
	public float statMultiplier
	{
		get
		{
			float num = 0f;
			switch (this.quality)
			{
			case InvGameItem.Quality.Broken:
				num = 0f;
				break;
			case InvGameItem.Quality.Cursed:
				num = -1f;
				break;
			case InvGameItem.Quality.Damaged:
				num = 0.25f;
				break;
			case InvGameItem.Quality.Worn:
				num = 0.9f;
				break;
			case InvGameItem.Quality.Sturdy:
				num = 1f;
				break;
			case InvGameItem.Quality.Polished:
				num = 1.1f;
				break;
			case InvGameItem.Quality.Improved:
				num = 1.25f;
				break;
			case InvGameItem.Quality.Crafted:
				num = 1.5f;
				break;
			case InvGameItem.Quality.Superior:
				num = 1.75f;
				break;
			case InvGameItem.Quality.Enchanted:
				num = 2f;
				break;
			case InvGameItem.Quality.Epic:
				num = 2.5f;
				break;
			case InvGameItem.Quality.Legendary:
				num = 3f;
				break;
			}
			float num2 = (float)this.itemLevel / 50f;
			return num * Mathf.Lerp(num2, num2 * num2, 0.5f);
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600018C RID: 396 RVA: 0x000178A8 File Offset: 0x00015CA8
	public Color color
	{
		get
		{
			Color result = Color.white;
			switch (this.quality)
			{
			case InvGameItem.Quality.Broken:
				result = new Color(0.4f, 0.2f, 0.2f);
				break;
			case InvGameItem.Quality.Cursed:
				result = Color.red;
				break;
			case InvGameItem.Quality.Damaged:
				result = new Color(0.4f, 0.4f, 0.4f);
				break;
			case InvGameItem.Quality.Worn:
				result = new Color(0.7f, 0.7f, 0.7f);
				break;
			case InvGameItem.Quality.Sturdy:
				result = new Color(1f, 1f, 1f);
				break;
			case InvGameItem.Quality.Polished:
				result = NGUIMath.HexToColor(3774856959U);
				break;
			case InvGameItem.Quality.Improved:
				result = NGUIMath.HexToColor(2480359935U);
				break;
			case InvGameItem.Quality.Crafted:
				result = NGUIMath.HexToColor(1325334783U);
				break;
			case InvGameItem.Quality.Superior:
				result = NGUIMath.HexToColor(12255231U);
				break;
			case InvGameItem.Quality.Enchanted:
				result = NGUIMath.HexToColor(1937178111U);
				break;
			case InvGameItem.Quality.Epic:
				result = NGUIMath.HexToColor(2516647935U);
				break;
			case InvGameItem.Quality.Legendary:
				result = NGUIMath.HexToColor(4287627519U);
				break;
			}
			return result;
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x000179E8 File Offset: 0x00015DE8
	public List<InvStat> CalculateStats()
	{
		List<InvStat> list = new List<InvStat>();
		if (this.baseItem != null)
		{
			float statMultiplier = this.statMultiplier;
			List<InvStat> stats = this.baseItem.stats;
			int i = 0;
			int count = stats.Count;
			while (i < count)
			{
				InvStat invStat = stats[i];
				int num = Mathf.RoundToInt(statMultiplier * (float)invStat.amount);
				if (num != 0)
				{
					bool flag = false;
					int j = 0;
					int count2 = list.Count;
					while (j < count2)
					{
						InvStat invStat2 = list[j];
						if (invStat2.id == invStat.id && invStat2.modifier == invStat.modifier)
						{
							invStat2.amount += num;
							flag = true;
							break;
						}
						j++;
					}
					if (!flag)
					{
						list.Add(new InvStat
						{
							id = invStat.id,
							amount = num,
							modifier = invStat.modifier
						});
					}
				}
				i++;
			}
			List<InvStat> list2 = list;
			if (InvGameItem.<>f__mg$cache0 == null)
			{
				InvGameItem.<>f__mg$cache0 = new Comparison<InvStat>(InvStat.CompareArmor);
			}
			list2.Sort(InvGameItem.<>f__mg$cache0);
		}
		return list;
	}

	// Token: 0x040002AA RID: 682
	[SerializeField]
	private int mBaseItemID;

	// Token: 0x040002AB RID: 683
	public InvGameItem.Quality quality = InvGameItem.Quality.Sturdy;

	// Token: 0x040002AC RID: 684
	public int itemLevel = 1;

	// Token: 0x040002AD RID: 685
	private InvBaseItem mBaseItem;

	// Token: 0x040002AE RID: 686
	[CompilerGenerated]
	private static Comparison<InvStat> <>f__mg$cache0;

	// Token: 0x0200004E RID: 78
	public enum Quality
	{
		// Token: 0x040002B0 RID: 688
		Broken,
		// Token: 0x040002B1 RID: 689
		Cursed,
		// Token: 0x040002B2 RID: 690
		Damaged,
		// Token: 0x040002B3 RID: 691
		Worn,
		// Token: 0x040002B4 RID: 692
		Sturdy,
		// Token: 0x040002B5 RID: 693
		Polished,
		// Token: 0x040002B6 RID: 694
		Improved,
		// Token: 0x040002B7 RID: 695
		Crafted,
		// Token: 0x040002B8 RID: 696
		Superior,
		// Token: 0x040002B9 RID: 697
		Enchanted,
		// Token: 0x040002BA RID: 698
		Epic,
		// Token: 0x040002BB RID: 699
		Legendary,
		// Token: 0x040002BC RID: 700
		_LastDoNotUse
	}
}
