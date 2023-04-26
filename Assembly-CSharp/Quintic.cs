using System;

// Token: 0x0200007E RID: 126
public class Quintic
{
	// Token: 0x0600025A RID: 602 RVA: 0x0001E439 File Offset: 0x0001C839
	public static float In(float k)
	{
		return k * k * k * k * k;
	}

	// Token: 0x0600025B RID: 603 RVA: 0x0001E444 File Offset: 0x0001C844
	public static float Out(float k)
	{
		return 1f + (k -= 1f) * k * k * k * k;
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0001E460 File Offset: 0x0001C860
	public static float InOut(float k)
	{
		if ((k *= 2f) < 1f)
		{
			return 0.5f * k * k * k * k * k;
		}
		return 0.5f * ((k -= 2f) * k * k * k * k + 2f);
	}
}
