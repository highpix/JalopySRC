using System;
using TMPro;
using UnityEngine;

// Token: 0x020000E0 RID: 224
public class PageLogicC : MonoBehaviour
{
	// Token: 0x060008CA RID: 2250 RVA: 0x000BE8FC File Offset: 0x000BCCFC
	private void Start()
	{
		if (this.magazine == null)
		{
			this.magazine = base.transform.parent.gameObject;
		}
		if (this.magazine != null && !this.magazine.GetComponent<MagazineLogicC>())
		{
			this.magazine = this.magazine.transform.parent.gameObject;
		}
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x000BE974 File Offset: 0x000BCD74
	[ContextMenu("Do")]
	public void DebugDo()
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			if (base.transform.GetChild(i).gameObject.name == "PageTurner")
			{
				this.pageTurner = base.transform.GetChild(i).gameObject;
				break;
			}
		}
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x000BE9E0 File Offset: 0x000BCDE0
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		PageLogic component = base.GetComponent<PageLogic>();
		this.pageTurner = (component.pageTurner as GameObject);
		this.pageReturner = (component.pageReturner as GameObject);
		component.pageDetails.Copy(ref this.pageDetails);
		component.pageDetailStrings.Copy(ref this.pageDetailStrings);
		this.allowZoom = component.allowZoom;
		this.magazine = (component.magazine as GameObject);
		component.fontResizeTargets.Copy(ref this.fontResizeTargets);
		component.fontResize.Copy(ref this.fontResize);
		component.enabled = false;
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x000BEA8C File Offset: 0x000BCE8C
	public void PageGo()
	{
		LanguageCode languageCode = Language.CurrentLanguage();
		for (int i = 0; i < this.pageDetails.Length; i++)
		{
			if (this.pageDetails[i] != null)
			{
				this.pageDetails[i].active = true;
				if (languageCode != LanguageCode.EN && this.fontChange != null)
				{
					if (this.pageDetails[i].name.Contains("Title") && this.pageDetails[i].GetComponent<TextMeshPro>())
					{
						this.pageDetails[i].GetComponent<TextMeshPro>().lineLength = 170.04f;
					}
					if (this.pageDetails[i].GetComponent<TextMeshPro>() && LocalFonts.ReturnFont(languageCode) != null)
					{
						if (this.pageDetails[i].GetComponent<TextMeshPro>().fontSize == 250f && languageCode == LanguageCode.PT_BR)
						{
							this.pageDetails[i].GetComponent<TextMeshPro>().fontSize = 166.35f;
						}
						if (this.pageDetails[i].GetComponent<TextMeshPro>().fontSize == 190f && languageCode == LanguageCode.PT_BR)
						{
							this.pageDetails[i].GetComponent<TextMeshPro>().fontSize = 138.9f;
						}
						if (this.pageDetails[i].GetComponent<TextMeshPro>().fontSize == 220f && languageCode == LanguageCode.PT_BR)
						{
							this.pageDetails[i].GetComponent<TextMeshPro>().fontSize = 183.9f;
						}
						this.pageDetails[i].GetComponent<TextMeshPro>().font = LocalFonts.ReturnFont(languageCode);
					}
				}
			}
		}
		for (int j = 0; j < this.pageDetailStrings.Length; j++)
		{
			if (this.pageDetails[j].GetComponent<TextMeshPro>())
			{
				this.pageDetails[j].GetComponent<TextMeshPro>().text = Language.Get(this.pageDetailStrings[j], "Inspector_UI");
				this.pageDetails[j].GetComponent<TextMeshPro>().text = this.pageDetails[j].GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
			}
		}
		if (languageCode != LanguageCode.EN)
		{
		}
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x000BECC8 File Offset: 0x000BD0C8
	public void PageClose()
	{
		for (int i = 0; i < this.pageDetails.Length; i++)
		{
			this.pageDetails[i].active = false;
		}
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x000BECFC File Offset: 0x000BD0FC
	public void Close()
	{
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x000BED00 File Offset: 0x000BD100
	public void Trigger()
	{
		if (!this.magazine.gameObject.GetComponent<MagazineLogicC>().isZoomed && this.allowZoom)
		{
			this.magazine.gameObject.GetComponent<MagazineLogicC>().Zoom();
		}
		else if (this.magazine.gameObject.GetComponent<MagazineLogicC>().isZoomed && this.allowZoom)
		{
			this.magazine.gameObject.GetComponent<MagazineLogicC>().ZoomOut();
		}
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x000BED86 File Offset: 0x000BD186
	[ContextMenu("Turn Page")]
	public void TurnPage()
	{
		base.StartCoroutine(this.magazine.gameObject.GetComponent<MagazineLogicC>().TurnPage());
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x000BEDA4 File Offset: 0x000BD1A4
	public void ReturnPage()
	{
		base.StartCoroutine(this.magazine.gameObject.GetComponent<MagazineLogicC>().ReturnPage());
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x000BEDC2 File Offset: 0x000BD1C2
	public void RaycastEnter()
	{
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x000BEDC4 File Offset: 0x000BD1C4
	public void RaycastExit()
	{
	}

	// Token: 0x04000BBE RID: 3006
	public GameObject pageTurner;

	// Token: 0x04000BBF RID: 3007
	public GameObject pageReturner;

	// Token: 0x04000BC0 RID: 3008
	public GameObject[] pageDetails = new GameObject[0];

	// Token: 0x04000BC1 RID: 3009
	public string[] pageDetailStrings = new string[0];

	// Token: 0x04000BC2 RID: 3010
	public bool allowZoom = true;

	// Token: 0x04000BC3 RID: 3011
	public GameObject magazine;

	// Token: 0x04000BC4 RID: 3012
	public TextMeshProFont fontChange;

	// Token: 0x04000BC5 RID: 3013
	public GameObject[] fontResizeTargets = new GameObject[0];

	// Token: 0x04000BC6 RID: 3014
	public float[] fontResize = new float[0];
}
