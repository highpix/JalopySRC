using System;
using UnityEngine;

// Token: 0x0200015C RID: 348
public class TextureSorter
{
	// Token: 0x06000D68 RID: 3432 RVA: 0x00131CBC File Offset: 0x001300BC
	public void Sort(Texture2D[] array)
	{
		if (array.Length <= 1)
		{
			return;
		}
		string name = array[0].name;
		this._texNameNumericIndex = this.FindTextureNameNumeric(name);
		if (this._texNameNumericIndex < 0)
		{
			return;
		}
		Array.Sort<Texture2D>(array, new Comparison<Texture2D>(this.NumericTextureSort));
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x00131D08 File Offset: 0x00130108
	private int NumericTextureSort(Texture2D a, Texture2D b)
	{
		int numericOf = this.GetNumericOf(a.name, this._texNameNumericIndex);
		int numericOf2 = this.GetNumericOf(b.name, this._texNameNumericIndex);
		if (numericOf == numericOf2)
		{
			return 0;
		}
		if (numericOf < numericOf2)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x06000D6A RID: 3434 RVA: 0x00131D50 File Offset: 0x00130150
	private int GetNumericOf(string s, int index)
	{
		int result;
		try
		{
			if (s == null || s.Length <= index)
			{
				result = -1;
			}
			else
			{
				string s2 = s.Substring(index);
				int num;
				if (int.TryParse(s2, out num))
				{
					result = num;
				}
				else
				{
					result = -1;
				}
			}
		}
		catch (Exception)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Could not get numeric of texture name [",
				s,
				"] at index ",
				index,
				".  Either rename the textures to end with incrementing numbers, or turn off AutoSortTextures."
			}));
			result = -1;
		}
		return result;
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x00131DE8 File Offset: 0x001301E8
	private int FindTextureNameNumeric(string texName)
	{
		if (string.IsNullOrEmpty(texName))
		{
			return -1;
		}
		int i = texName.Length - 1;
		while (i >= 0)
		{
			if (!char.IsDigit(texName[i]))
			{
				if (i + 1 < texName.Length)
				{
					return i + 1;
				}
				return -1;
			}
			else
			{
				i--;
			}
		}
		return -1;
	}

	// Token: 0x04001203 RID: 4611
	private int _texNameNumericIndex;
}
