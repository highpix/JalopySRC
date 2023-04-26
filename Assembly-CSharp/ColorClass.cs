using System;
using UnityEngine;

// Token: 0x0200002D RID: 45
[Serializable]
public class ColorClass
{
	// Token: 0x06000108 RID: 264 RVA: 0x000122D4 File Offset: 0x000106D4
	public ColorClass()
	{
	}

	// Token: 0x06000109 RID: 265 RVA: 0x000122F3 File Offset: 0x000106F3
	public ColorClass(Color col)
	{
		this.ConvertColor(col);
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00012319 File Offset: 0x00010719
	public void ConvertColor(Color col)
	{
		this.values = new float[]
		{
			col.r,
			col.g,
			col.b,
			col.a
		};
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00012350 File Offset: 0x00010750
	public Color ConvertToColor()
	{
		if (this.values == null || this.values.Length < 1 || this.values[0] == -1f)
		{
			return Color.white;
		}
		return new Color(this.values[0], this.values[1], this.values[2], this.values[3]);
	}

	// Token: 0x04000216 RID: 534
	public float[] values = new float[]
	{
		-1f,
		-1f,
		-1f,
		-1f
	};
}
