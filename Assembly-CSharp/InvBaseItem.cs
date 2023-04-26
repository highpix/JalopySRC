using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000049 RID: 73
[Serializable]
public class InvBaseItem
{
	// Token: 0x0400028E RID: 654
	public int id16;

	// Token: 0x0400028F RID: 655
	public string name;

	// Token: 0x04000290 RID: 656
	public string description;

	// Token: 0x04000291 RID: 657
	public InvBaseItem.Slot slot;

	// Token: 0x04000292 RID: 658
	public int minItemLevel = 1;

	// Token: 0x04000293 RID: 659
	public int maxItemLevel = 50;

	// Token: 0x04000294 RID: 660
	public List<InvStat> stats = new List<InvStat>();

	// Token: 0x04000295 RID: 661
	public GameObject attachment;

	// Token: 0x04000296 RID: 662
	public Color color = Color.white;

	// Token: 0x04000297 RID: 663
	public UIAtlas iconAtlas;

	// Token: 0x04000298 RID: 664
	public string iconName = string.Empty;

	// Token: 0x0200004A RID: 74
	public enum Slot
	{
		// Token: 0x0400029A RID: 666
		None,
		// Token: 0x0400029B RID: 667
		Weapon,
		// Token: 0x0400029C RID: 668
		Shield,
		// Token: 0x0400029D RID: 669
		Body,
		// Token: 0x0400029E RID: 670
		Shoulders,
		// Token: 0x0400029F RID: 671
		Bracers,
		// Token: 0x040002A0 RID: 672
		Boots,
		// Token: 0x040002A1 RID: 673
		Trinket,
		// Token: 0x040002A2 RID: 674
		_LastDoNotUse
	}
}
