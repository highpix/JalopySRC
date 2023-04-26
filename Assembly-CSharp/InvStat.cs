using System;

// Token: 0x0200004F RID: 79
[Serializable]
public class InvStat
{
	// Token: 0x0600018F RID: 399 RVA: 0x00017B2B File Offset: 0x00015F2B
	public static string GetName(InvStat.Identifier i)
	{
		return i.ToString();
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00017B3C File Offset: 0x00015F3C
	public static string GetDescription(InvStat.Identifier i)
	{
		switch (i)
		{
		case InvStat.Identifier.Strength:
			return "Strength increases melee damage";
		case InvStat.Identifier.Constitution:
			return "Constitution increases health";
		case InvStat.Identifier.Agility:
			return "Agility increases armor";
		case InvStat.Identifier.Intelligence:
			return "Intelligence increases mana";
		case InvStat.Identifier.Damage:
			return "Damage adds to the amount of damage done in combat";
		case InvStat.Identifier.Crit:
			return "Crit increases the chance of landing a critical strike";
		case InvStat.Identifier.Armor:
			return "Armor protects from damage";
		case InvStat.Identifier.Health:
			return "Health prolongs life";
		case InvStat.Identifier.Mana:
			return "Mana increases the number of spells that can be cast";
		default:
			return null;
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00017BB0 File Offset: 0x00015FB0
	public static int CompareArmor(InvStat a, InvStat b)
	{
		int num = (int)a.id;
		int num2 = (int)b.id;
		if (a.id == InvStat.Identifier.Armor)
		{
			num -= 10000;
		}
		else if (a.id == InvStat.Identifier.Damage)
		{
			num -= 5000;
		}
		if (b.id == InvStat.Identifier.Armor)
		{
			num2 -= 10000;
		}
		else if (b.id == InvStat.Identifier.Damage)
		{
			num2 -= 5000;
		}
		if (a.amount < 0)
		{
			num += 1000;
		}
		if (b.amount < 0)
		{
			num2 += 1000;
		}
		if (a.modifier == InvStat.Modifier.Percent)
		{
			num += 100;
		}
		if (b.modifier == InvStat.Modifier.Percent)
		{
			num2 += 100;
		}
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00017C84 File Offset: 0x00016084
	public static int CompareWeapon(InvStat a, InvStat b)
	{
		int num = (int)a.id;
		int num2 = (int)b.id;
		if (a.id == InvStat.Identifier.Damage)
		{
			num -= 10000;
		}
		else if (a.id == InvStat.Identifier.Armor)
		{
			num -= 5000;
		}
		if (b.id == InvStat.Identifier.Damage)
		{
			num2 -= 10000;
		}
		else if (b.id == InvStat.Identifier.Armor)
		{
			num2 -= 5000;
		}
		if (a.amount < 0)
		{
			num += 1000;
		}
		if (b.amount < 0)
		{
			num2 += 1000;
		}
		if (a.modifier == InvStat.Modifier.Percent)
		{
			num += 100;
		}
		if (b.modifier == InvStat.Modifier.Percent)
		{
			num2 += 100;
		}
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x040002BD RID: 701
	public InvStat.Identifier id;

	// Token: 0x040002BE RID: 702
	public InvStat.Modifier modifier;

	// Token: 0x040002BF RID: 703
	public int amount;

	// Token: 0x02000050 RID: 80
	public enum Identifier
	{
		// Token: 0x040002C1 RID: 705
		Strength,
		// Token: 0x040002C2 RID: 706
		Constitution,
		// Token: 0x040002C3 RID: 707
		Agility,
		// Token: 0x040002C4 RID: 708
		Intelligence,
		// Token: 0x040002C5 RID: 709
		Damage,
		// Token: 0x040002C6 RID: 710
		Crit,
		// Token: 0x040002C7 RID: 711
		Armor,
		// Token: 0x040002C8 RID: 712
		Health,
		// Token: 0x040002C9 RID: 713
		Mana,
		// Token: 0x040002CA RID: 714
		Other
	}

	// Token: 0x02000051 RID: 81
	public enum Modifier
	{
		// Token: 0x040002CC RID: 716
		Added,
		// Token: 0x040002CD RID: 717
		Percent
	}
}
