using System;
using UnityEngine;

// Token: 0x0200007F RID: 127
public class Elastic
{
	// Token: 0x0600025E RID: 606 RVA: 0x0001E4B8 File Offset: 0x0001C8B8
	public static float In(float k)
	{
		if (k == 0f)
		{
			return 0f;
		}
		if (k == 1f)
		{
			return 1f;
		}
		return -Mathf.Pow(2f, 10f * (k -= 1f)) * Mathf.Sin((k - 0.1f) * 6.2831855f / 0.4f);
	}

	// Token: 0x0600025F RID: 607 RVA: 0x0001E51C File Offset: 0x0001C91C
	public static float Out(float k)
	{
		if (k == 0f)
		{
			return 0f;
		}
		if (k == 1f)
		{
			return 1f;
		}
		return Mathf.Pow(2f, -10f * k) * Mathf.Sin((k - 0.1f) * 6.2831855f / 0.4f) + 1f;
	}

	// Token: 0x06000260 RID: 608 RVA: 0x0001E57C File Offset: 0x0001C97C
	public static float InOut(float k)
	{
		if ((k *= 2f) < 1f)
		{
			return -0.5f * Mathf.Pow(2f, 10f * (k -= 1f)) * Mathf.Sin((k - 0.1f) * 6.2831855f / 0.4f);
		}
		return Mathf.Pow(2f, -10f * (k -= 1f)) * Mathf.Sin((k - 0.1f) * 6.2831855f / 0.4f) * 0.5f + 1f;
	}
}
