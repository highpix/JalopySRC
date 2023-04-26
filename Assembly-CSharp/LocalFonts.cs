using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x0200003B RID: 59
public class LocalFonts : MonoBehaviour
{
	// Token: 0x06000137 RID: 311 RVA: 0x00013938 File Offset: 0x00011D38
	private void Awake()
	{
		LocalFonts.Global = this;
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00013940 File Offset: 0x00011D40
	private void OnDestroy()
	{
		LocalFonts.Global = null;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00013948 File Offset: 0x00011D48
	public static TextMeshProFont ReturnFont(LanguageCode lang)
	{
		for (int i = 0; i < LocalFonts.Global.fonts.Count; i++)
		{
			if (LocalFonts.Global.fonts[i].whichLanguage == lang)
			{
				return LocalFonts.Global.fonts[i].thisFont;
			}
		}
		return null;
	}

	// Token: 0x04000259 RID: 601
	public static LocalFonts Global;

	// Token: 0x0400025A RID: 602
	public List<FontHolder> fonts = new List<FontHolder>();
}
