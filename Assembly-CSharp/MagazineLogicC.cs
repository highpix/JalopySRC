using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000C5 RID: 197
public class MagazineLogicC : MonoBehaviour
{
	// Token: 0x06000722 RID: 1826 RVA: 0x0008CD4C File Offset: 0x0008B14C
	private void Start()
	{
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this._camera = Camera.main.gameObject;
		this.startMaterial = this.glowTargets[0].GetComponent<Renderer>().material;
		this.holdingPosition = GameObject.FindWithTag("Director").GetComponent<DirectorC>().laikaCatalogueHolder;
		this.LocalisationPickup();
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x0008CDB4 File Offset: 0x0008B1B4
	public void LocalisationPickup()
	{
		LanguageCode languageCode = Language.CurrentLanguage();
		if (this.localisationFixTarget != null && languageCode != LanguageCode.EN)
		{
			this.localisationFixTarget.GetComponent<MeshRenderer>().material = this.localisationFixMaterial;
		}
		if (this.page.Length == 11)
		{
			if (languageCode == LanguageCode.FR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[0].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[0].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[0].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[0].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[0].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[0].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[0].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[0].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[0].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[0].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[0].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.IT)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[1].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[1].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[1].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[1].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[1].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[1].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[1].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[1].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[1].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[1].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[1].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.DE)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[2].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[2].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[2].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[2].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[2].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[2].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[2].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[2].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[2].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[2].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[2].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.ES)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[3].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[3].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[3].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[3].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[3].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[3].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[3].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[3].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[3].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[3].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[3].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.PT_BR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[4].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[4].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[4].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[4].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[4].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[4].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[4].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[4].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[4].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[4].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[4].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.TR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[5].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[5].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[5].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[5].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[5].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[5].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[5].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[5].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[5].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[5].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[5].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.HU)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[6].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[6].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[6].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[6].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[6].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[6].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[6].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[6].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[6].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[6].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[6].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.NL)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[7].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[7].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[7].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[7].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[7].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[7].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[7].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[7].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[7].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[7].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[7].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.NL)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[7].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[7].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[7].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[7].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[7].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[7].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[7].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[7].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[7].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[7].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[7].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.FI)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[8].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[8].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[8].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[8].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[8].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[8].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[8].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[8].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[8].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[8].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[8].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.PL)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[9].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[9].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[9].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[9].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[9].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[9].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[9].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[9].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[9].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[9].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[9].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.RU)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[10].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[10].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[10].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[10].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[10].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[10].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[10].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[10].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[10].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[10].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[10].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.SK)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[11].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[11].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[11].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[11].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[11].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[11].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[11].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[11].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[11].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[11].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[11].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.HR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[12].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[12].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[12].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[12].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[12].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[12].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[12].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[12].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[12].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[12].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[12].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.RO)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[13].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[13].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[13].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[13].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[13].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[13].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[13].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[13].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[13].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[13].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[13].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.NO)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[14].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[14].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[14].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[14].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[14].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[14].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[14].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[14].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[14].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[14].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[14].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.ZH)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[15].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[15].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[15].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[15].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[15].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[15].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[15].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[15].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[15].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[15].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[15].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.JA)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[16].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[16].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[16].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[16].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[16].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[16].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[16].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[16].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[16].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[16].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[16].transform.GetChild(10).gameObject;
			}
			if (languageCode == LanguageCode.KO)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[17].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[17].transform.GetChild(1).gameObject;
				this.page[2] = this.localisationObj[17].transform.GetChild(2).gameObject;
				this.page[3] = this.localisationObj[17].transform.GetChild(3).gameObject;
				this.page[4] = this.localisationObj[17].transform.GetChild(4).gameObject;
				this.page[5] = this.localisationObj[17].transform.GetChild(5).gameObject;
				this.page[6] = this.localisationObj[17].transform.GetChild(6).gameObject;
				this.page[7] = this.localisationObj[17].transform.GetChild(7).gameObject;
				this.page[8] = this.localisationObj[17].transform.GetChild(8).gameObject;
				this.page[9] = this.localisationObj[17].transform.GetChild(9).gameObject;
				this.page[10] = this.localisationObj[17].transform.GetChild(10).gameObject;
			}
			this.pageMatTargets[0] = this.page[0].transform.GetChild(1).gameObject;
			this.pageMatTargets[1] = this.page[1].transform.GetChild(1).gameObject;
			this.pageMatTargets[2] = this.page[2].transform.GetChild(1).gameObject;
			this.pageMatTargets[3] = this.page[3].transform.GetChild(1).gameObject;
			this.pageMatTargets[4] = this.page[4].transform.GetChild(1).gameObject;
			this.pageMatTargets[5] = this.page[5].transform.GetChild(1).gameObject;
			this.pageMatTargets[6] = this.page[6].transform.GetChild(1).gameObject;
			this.pageMatTargets[7] = this.page[7].transform.GetChild(1).gameObject;
			this.pageMatTargets[9] = this.page[8].transform.GetChild(1).gameObject;
			this.pageMatTargets[10] = this.page[9].transform.GetChild(1).gameObject;
			this.pageMatTargets[11] = this.page[10].transform.GetChild(1).gameObject;
		}
		else if (this.page.Length == 2)
		{
			if (languageCode == LanguageCode.FR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[0].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[0].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.IT)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[1].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[1].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.DE)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[2].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[2].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.ES)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[3].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[3].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.PT_BR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[4].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[4].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.TR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[5].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[5].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.HU)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[6].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[6].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.ZH)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[7].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[7].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.NL)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[8].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[8].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.FI)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[9].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[9].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.JA)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[10].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[10].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.PL)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[11].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[11].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.RU)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[12].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[12].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.SK)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[13].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[13].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.HR)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[14].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[14].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.RO)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[15].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[15].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.KO)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[16].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[16].transform.GetChild(1).gameObject;
			}
			if (languageCode == LanguageCode.NO)
			{
				this.page[0].active = false;
				this.page[0] = this.localisationObj[17].transform.GetChild(0).gameObject;
				this.page[1] = this.localisationObj[17].transform.GetChild(1).gameObject;
			}
			this.pageMatTargets[0] = this.page[0].transform.GetChild(1).gameObject;
			this.pageMatTargets[1] = this.page[1].transform.GetChild(16).gameObject;
		}
	}

	// Token: 0x06000724 RID: 1828 RVA: 0x0008F288 File Offset: 0x0008D688
	public void PickUp()
	{
		base.transform.parent = this.dropOffPoint;
		this.StopGlow();
		this._camera.GetComponent<DragRigidbodyC>().StartCoroutine("DropAllItems");
		MainMenuC.Global.restrictPause = true;
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		this.TweenCameraPos();
		Transform parent = this._camera.transform.parent;
		if (!parent.GetComponent<Rigidbody>().isKinematic)
		{
			parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		this._camera.GetComponent<MouseLook>().enabled = false;
		parent.gameObject.GetComponent<MouseLook>().enabled = false;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = false;
		base.gameObject.GetComponent<Collider>().enabled = false;
		MainMenuC.Global.lockCursor = false;
		Screen.lockCursor = false;
		this._camera.GetComponent<DragRigidbodyC>().onlyInteractWithPickUpLayer = true;
		if (this.specificationDetails.Length > 0)
		{
			this.SetCarOverviewDetails();
		}
		this.SetStorageDetails();
		if (base.GetComponent<HomeStorageClipboardC>())
		{
			base.GetComponent<HomeStorageClipboardC>().PageGo();
		}
		if (!parent.GetComponent<Rigidbody>().isKinematic)
		{
			parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}

	// Token: 0x06000725 RID: 1829 RVA: 0x0008F3D0 File Offset: 0x0008D7D0
	public void SetCarOverviewDetails()
	{
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.FR)
		{
			this.SetCarOverviewDetailsFR();
			return;
		}
		if (languageCode == LanguageCode.IT)
		{
			this.SetCarOverviewDetailsIT();
			return;
		}
		if (languageCode == LanguageCode.DE)
		{
			this.SetCarOverviewDetailsDE();
			return;
		}
		if (languageCode == LanguageCode.ES)
		{
			this.SetCarOverviewDetailsES();
			return;
		}
		if (languageCode == LanguageCode.PT_BR)
		{
			this.SetCarOverviewDetailsPT_BR();
			return;
		}
		if (languageCode == LanguageCode.TR)
		{
			this.SetCarOverviewDetailsTR();
			return;
		}
		if (languageCode == LanguageCode.HU)
		{
			this.SetCarOverviewDetailsHU();
			return;
		}
		if (languageCode == LanguageCode.NL)
		{
			this.SetCarOverviewDetailsNL();
			return;
		}
		if (languageCode == LanguageCode.FI)
		{
			this.SetCarOverviewDetailsFI();
			return;
		}
		if (languageCode == LanguageCode.PL)
		{
			this.SetCarOverviewDetailsPL();
			return;
		}
		if (languageCode == LanguageCode.RU)
		{
			this.SetCarOverviewDetailsRU();
			return;
		}
		if (languageCode == LanguageCode.SK)
		{
			this.SetCarOverviewDetailsSK();
			return;
		}
		if (languageCode == LanguageCode.HR)
		{
			this.SetCarOverviewDetailsHR();
			return;
		}
		if (languageCode == LanguageCode.RO)
		{
			this.SetCarOverviewDetailsRO();
			return;
		}
		if (languageCode == LanguageCode.NO)
		{
			this.SetCarOverviewDetailsNO();
			return;
		}
		if (languageCode == LanguageCode.ZH)
		{
			this.SetCarOverviewDetailsZH();
			return;
		}
		if (languageCode == LanguageCode.JA)
		{
			this.SetCarOverviewDetailsJA();
			return;
		}
		if (languageCode == LanguageCode.KO)
		{
			this.SetCarOverviewDetailsKO();
			return;
		}
		if (languageCode == LanguageCode.SV)
		{
			this.SetCarOverviewDetailsSV();
			return;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[0].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[0].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[1].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[1].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[3].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[3].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[4].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[4].GetComponent<TextMesh>().text = "none";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[4].GetComponent<TextMesh>().text = "lean";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[4].GetComponent<TextMesh>().text = "optimal";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[4].GetComponent<TextMesh>().text = "rich";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[5].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[6].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x0008FA78 File Offset: 0x0008DE78
	public void SetCarOverviewDetailsFR()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[7].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[7].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[8].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[8].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[10].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[10].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[11].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[11].GetComponent<TextMesh>().text = "Pas de carburant mélangé";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[11].GetComponent<TextMesh>().text = "Mélange de carburant pauvre";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[11].GetComponent<TextMesh>().text = "Mélange de carburant optimal";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[11].GetComponent<TextMesh>().text = "Mélange de carburant riche";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[12].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[13].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x0008FFE8 File Offset: 0x0008E3E8
	public void SetCarOverviewDetailsIT()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[14].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[14].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[15].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[15].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[17].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[17].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[18].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[18].GetComponent<TextMesh>().text = "Miscela Senza Olio";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[18].GetComponent<TextMesh>().text = "Miscela Povera";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[18].GetComponent<TextMesh>().text = "Miscela Ottimale";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[18].GetComponent<TextMesh>().text = "Miscela ricca";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[19].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[20].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x0009055C File Offset: 0x0008E95C
	public void SetCarOverviewDetailsDE()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[21].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[21].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[22].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[22].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[24].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[24].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[25].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[25].GetComponent<TextMesh>().text = "Kein Öl";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[25].GetComponent<TextMesh>().text = "magere Öl-Mischung";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[25].GetComponent<TextMesh>().text = "Optimale Öl-Mischung";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[25].GetComponent<TextMesh>().text = "fette Öl-Mischung";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[26].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[27].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x00090AD0 File Offset: 0x0008EED0
	public void SetCarOverviewDetailsES()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[28].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[28].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[29].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[29].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[31].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[31].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[32].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[32].GetComponent<TextMesh>().text = "No hay mezcla de aceite";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[32].GetComponent<TextMesh>().text = "Mezcla de aceite suave";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[32].GetComponent<TextMesh>().text = "Mezcla de aceite óptima";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[32].GetComponent<TextMesh>().text = "Mezcla de aceite fuerte";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[33].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[34].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x00091044 File Offset: 0x0008F444
	public void SetCarOverviewDetailsPT_BR()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[35].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[35].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[36].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[36].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[38].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[38].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[39].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[39].GetComponent<TextMesh>().text = "Sem Mistura de Óleo";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[39].GetComponent<TextMesh>().text = "Mistura de óleo Fraca";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[39].GetComponent<TextMesh>().text = "Mistura de Óleo Otimizada";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[39].GetComponent<TextMesh>().text = "Mistura de Óleo Rica";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[40].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[41].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x000915B8 File Offset: 0x0008F9B8
	public void SetCarOverviewDetailsTR()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[42].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[42].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[43].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[43].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[45].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[45].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[46].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[46].GetComponent<TextMesh>().text = "Yağ karışımı yok";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[46].GetComponent<TextMesh>().text = "Yalın yağ karışımı";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[46].GetComponent<TextMesh>().text = "Optimum yağ karışımı";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[46].GetComponent<TextMesh>().text = "Zengin yağ karışımı";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[47].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[48].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x00091B2C File Offset: 0x0008FF2C
	public void SetCarOverviewDetailsHU()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[49].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[49].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[50].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[50].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[52].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[52].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[53].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[53].GetComponent<TextMesh>().text = "Olajmentes keverék";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[53].GetComponent<TextMesh>().text = "Sovány Keverék";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[53].GetComponent<TextMesh>().text = "Optimális Keverék";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[53].GetComponent<TextMesh>().text = "Dús Keverék";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[54].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[55].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x000920A0 File Offset: 0x000904A0
	public void SetCarOverviewDetailsNL()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[56].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[56].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[57].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[57].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[59].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[59].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[60].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[60].GetComponent<TextMesh>().text = "Geen oliemix";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[60].GetComponent<TextMesh>().text = "Weinig olie";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[60].GetComponent<TextMesh>().text = "Optimale hoeveelheid olie";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[60].GetComponent<TextMesh>().text = "Veel olie";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[61].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[62].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x00092614 File Offset: 0x00090A14
	public void SetCarOverviewDetailsFI()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[63].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[63].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[64].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[64].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[66].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[66].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[67].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[67].GetComponent<TextMesh>().text = "Ei öljyseosta";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[67].GetComponent<TextMesh>().text = "Laiha öljyseos";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[67].GetComponent<TextMesh>().text = "Optimaalinen öljyseos";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[67].GetComponent<TextMesh>().text = "Rikas öljyseos";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[68].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[69].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x00092B88 File Offset: 0x00090F88
	public void SetCarOverviewDetailsPL()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[70].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[70].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[71].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[71].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[73].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[73].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[74].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[74].GetComponent<TextMesh>().text = "Brak mieszanki oleju";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[74].GetComponent<TextMesh>().text = "Uboga mieszanka";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[74].GetComponent<TextMesh>().text = "Optymalna mieszanka oleju";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[74].GetComponent<TextMesh>().text = "Bogata mieszanka";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[75].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[76].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x000930FC File Offset: 0x000914FC
	public void SetCarOverviewDetailsRU()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[77].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[77].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[78].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[78].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[80].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[80].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[81].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[81].GetComponent<TextMesh>().text = "Без смеси масла";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[81].GetComponent<TextMesh>().text = "Слабая смесь";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[81].GetComponent<TextMesh>().text = "Оптимальная смесь";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[81].GetComponent<TextMesh>().text = "Насыщенная смесь";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[82].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[83].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x00093670 File Offset: 0x00091A70
	public void SetCarOverviewDetailsSK()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[84].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[84].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[85].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[85].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[87].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[87].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[88].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[88].GetComponent<TextMesh>().text = "Žiadna zmes oleja";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[88].GetComponent<TextMesh>().text = "Slabá zmes oleja";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[88].GetComponent<TextMesh>().text = "Optimálna zmes oleja";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[88].GetComponent<TextMesh>().text = "Bohatá zmes oleja";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[89].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[90].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x00093BE4 File Offset: 0x00091FE4
	public void SetCarOverviewDetailsHR()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[91].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[91].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[92].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[92].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[94].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[94].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[95].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[95].GetComponent<TextMesh>().text = "Nema mješavine goriva";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[95].GetComponent<TextMesh>().text = "Slaba mješavina goriva";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[95].GetComponent<TextMesh>().text = "Optimalna mješavina goriva";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[95].GetComponent<TextMesh>().text = "Bogata mješavina goriva";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[96].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[97].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x00094158 File Offset: 0x00092558
	public void SetCarOverviewDetailsRO()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[98].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[98].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[99].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[99].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[101].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[101].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[102].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[102].GetComponent<TextMesh>().text = "Mixtură Fără Ulei";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[102].GetComponent<TextMesh>().text = "Mixtură Săracă în Ulei";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[102].GetComponent<TextMesh>().text = "Mixtură Optimă de Ulei";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[102].GetComponent<TextMesh>().text = "Mixtură Bogată de Ulei";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[103].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[104].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x000946CC File Offset: 0x00092ACC
	public void SetCarOverviewDetailsNO()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[105].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[105].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[106].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[106].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[108].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[108].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[109].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[109].GetComponent<TextMesh>().text = "ingen olje mikset inn";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[109].GetComponent<TextMesh>().text = "lite olje mikset inn";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[109].GetComponent<TextMesh>().text = "optimal mengde olje mikset inn";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[109].GetComponent<TextMesh>().text = "mye olje mikset inn";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[110].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[111].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x00094C40 File Offset: 0x00093040
	public void SetCarOverviewDetailsZH()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[112].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[112].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[113].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[113].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[115].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[115].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[116].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[116].GetComponent<TextMesh>().text = "无混合油";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[116].GetComponent<TextMesh>().text = "少混合油";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[116].GetComponent<TextMesh>().text = "最优混合油";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[116].GetComponent<TextMesh>().text = "过混合油";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[117].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[118].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x000951B4 File Offset: 0x000935B4
	public void SetCarOverviewDetailsJA()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[119].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[119].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[120].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[120].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[122].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[122].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[123].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[123].GetComponent<TextMesh>().text = "オイルなし";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[123].GetComponent<TextMesh>().text = "オイル少量";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[123].GetComponent<TextMesh>().text = "オイル適量";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[123].GetComponent<TextMesh>().text = "オイル大量";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[124].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[125].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x00095728 File Offset: 0x00093B28
	public void SetCarOverviewDetailsKO()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[126].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[126].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[127].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[127].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[129].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[129].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[130].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[130].GetComponent<TextMesh>().text = "오일 믹스 없음";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[130].GetComponent<TextMesh>().text = "부족한 연료 혼합비";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[130].GetComponent<TextMesh>().text = "적당한 연료 혼합비";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[130].GetComponent<TextMesh>().text = "과다한 연료 혼합비";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[131].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[132].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x00095CB4 File Offset: 0x000940B4
	public void SetCarOverviewDetailsSV()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[133].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[133].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().acceleration.ToString() + " sec";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			this.specificationDetails[134].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[134].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().TopSpeed.ToString() + "km/h";
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
		{
			this.specificationDetails[136].GetComponent<TextMesh>().text = "-";
		}
		else
		{
			this.specificationDetails[136].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().fuelConsumptionRate.ToString();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			this.specificationDetails[137].GetComponent<TextMesh>().text = "-";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			this.specificationDetails[137].GetComponent<TextMesh>().text = "Ingen olje mix";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			this.specificationDetails[137].GetComponent<TextMesh>().text = "Len olje mix";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			this.specificationDetails[137].GetComponent<TextMesh>().text = "Optimal olje mix";
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
		{
			this.specificationDetails[137].GetComponent<TextMesh>().text = "Rik olje mix";
		}
		float num = 0f;
		float num2 = 0f;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			num += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability;
			num2 += this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition;
		}
		this.specificationDetails[138].GetComponent<TextMesh>().text = num2.ToString() + " / " + num.ToString();
		float num3 = this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight + 60f;
		this.specificationDetails[139].GetComponent<TextMesh>().text = num3.ToString() + "kg";
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x0009624C File Offset: 0x0009464C
	public void SetStorageDetails()
	{
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x00096250 File Offset: 0x00094650
	public void TweenCameraPos()
	{
		Transform parent = this._camera.transform.parent;
		this._camera.SendMessage("ForceZoomOut");
		if (this.carLogic.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().isSat)
		{
			iTween.RotateTo(parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				new Vector3(0f, 180f, 0f),
				"time",
				0.5,
				"islocal",
				true,
				"easetype",
				"easeInQuad",
				"oncomplete",
				"TweenBookPos",
				"oncompletetarget",
				base.gameObject
			}));
			this.storeCamRote = this._camera.transform.localEulerAngles;
			iTween.RotateTo(this._camera.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				Vector3.zero,
				"time",
				0.4,
				"islocal",
				true,
				"easetype",
				"easeInQuad"
			}));
		}
		else
		{
			this.storeCamRote = this._camera.transform.localEulerAngles;
			iTween.RotateTo(this._camera.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				Vector3.zero,
				"time",
				0.4,
				"islocal",
				true,
				"easetype",
				"easeInQuad",
				"oncomplete",
				"TweenBookPos",
				"oncompletetarget",
				base.gameObject
			}));
		}
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x00096460 File Offset: 0x00094860
	public void TweenBookPos()
	{
		Hashtable hashtable = new Hashtable();
		hashtable.Add("path", this.dropOffPointPath);
		hashtable.Add("time", 1.0);
		hashtable.Add("islocal", false);
		hashtable.Add("easetype", "easeinquad");
		hashtable.Add("oncomplete", "OpenBook");
		hashtable.Add("oncompletetarget", base.gameObject);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.holdingPosition,
			"time",
			1.0,
			"islocal",
			false,
			"easetype",
			"easeinquad",
			"oncomplete",
			"OpenBook",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.holdingPosition,
			"delay",
			0.2,
			"time",
			0.5,
			"easetype",
			"easeinquad"
		}));
	}

	// Token: 0x0600073C RID: 1852 RVA: 0x000965D0 File Offset: 0x000949D0
	public void TweenReceiptOn()
	{
		this.clipBoardReceipt.active = true;
		iTween.MoveTo(this.clipBoardReceipt, iTween.Hash(new object[]
		{
			"position",
			this.receiptPos[0],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquad",
			"oncomplete",
			"ReceiptOn",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x0600073D RID: 1853 RVA: 0x0009667F File Offset: 0x00094A7F
	public void ReceiptOn()
	{
		this.SetLayerRecursively(this.clipBoardReceipt, 11);
		if (base.GetComponent<HomeStorageClipboardC>())
		{
			base.GetComponent<HomeStorageClipboardC>().TweenWallet();
		}
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x000966AC File Offset: 0x00094AAC
	public void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				this.SetLayerRecursively(transform.gameObject, newLayer);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x0600073F RID: 1855 RVA: 0x00096720 File Offset: 0x00094B20
	public void TweenReceiptOff()
	{
		this.SetLayerRecursively(this.clipBoardReceipt, 0);
		iTween.MoveTo(this.clipBoardReceipt, iTween.Hash(new object[]
		{
			"position",
			this.receiptPos[1],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquad",
			"oncomplete",
			"ReceiptOff",
			"oncompleteTarget",
			base.gameObject
		}));
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x000967D0 File Offset: 0x00094BD0
	public void ReceiptOff()
	{
		this.clipBoardReceipt.active = false;
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x000967E0 File Offset: 0x00094BE0
	public void SendReceiptOff()
	{
		iTween.MoveTo(this.clipBoardReceipt, iTween.Hash(new object[]
		{
			"position",
			this.receiptPos[2],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquad",
			"oncomplete",
			"ReceiptReturn",
			"oncompleteTarget",
			base.gameObject
		}));
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x00096884 File Offset: 0x00094C84
	public void ReceiptReturn()
	{
		base.GetComponent<HomeStorageClipboardC>().ClearOrder();
		iTween.MoveTo(this.clipBoardReceipt, iTween.Hash(new object[]
		{
			"position",
			this.receiptPos[0],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquad"
		}));
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x00096910 File Offset: 0x00094D10
	public IEnumerator OpenBook()
	{
		if (this.page.Length > 0)
		{
			this.page[0].active = false;
		}
		base.transform.position = this.holdingPosition.position;
		base.transform.parent = this.holdingPosition.transform;
		base.transform.localEulerAngles = Vector3.zero;
		VfAnimCursor.TurnOffXbox = true;
		if (this.clipBoardReceipt)
		{
			this.TweenReceiptOn();
		}
		base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		for (int i = 0; i < this.pageMatTargets.Length; i++)
		{
			this.pageMatTargets[i].layer = LayerMask.NameToLayer("PickUp");
		}
		this.isBookOpen = true;
		if (base.gameObject.GetComponent<Animator>())
		{
			base.gameObject.GetComponent<Animator>().SetBool("open", true);
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.audioLetterOpen, 1f);
		yield return new WaitForSeconds(0.1f);
		if (this.rearPage)
		{
			this.rearPage.layer = LayerMask.NameToLayer("PickUp");
		}
		if (this.page.Length > 0)
		{
			this.page[0].GetComponent<Collider>().enabled = true;
			this.page[0].active = true;
			if (this.page[0].GetComponent<PageLogicC>().pageTurner != null)
			{
				this.page[0].GetComponent<PageLogicC>().pageTurner.active = true;
			}
			yield return new WaitForSeconds(0.3f);
			this.page[0].SendMessage("PageGo");
			yield return new WaitForSeconds(0.7f);
		}
		if (!this.isBookOpen)
		{
			yield break;
		}
		yield break;
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x0009692C File Offset: 0x00094D2C
	public IEnumerator TurnPage()
	{
		if (this.page.Length == 0)
		{
			yield break;
		}
		if (this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner.active = false;
		}
		this.pageNumber++;
		yield return new WaitForSeconds(0.1f);
		this.page[this.pageNumber].active = true;
		this.page[this.pageNumber].SendMessage("PageGo");
		if (this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner.active = true;
		}
		int prevPage2 = this.pageNumber - 1;
		this.page[prevPage2].SendMessage("PageClose");
		int prevPage3 = this.pageNumber - 2;
		if (this.page.Length > 0 && prevPage3 >= 0 && this.page[prevPage3] != null && this.page[prevPage3].GetComponent<PageLogicC>().pageReturner != null)
		{
			this.page[prevPage3].GetComponent<PageLogicC>().pageReturner.active = false;
		}
		yield break;
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x00096948 File Offset: 0x00094D48
	public void TurnToPage(int num)
	{
		this.pageNumber = num;
		if (this.page[0].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[0].GetComponent<PageLogicC>().pageTurner.active = false;
		}
		if (this.page[0].GetComponent<PageLogicC>().pageReturner != null)
		{
			this.page[0].GetComponent<PageLogicC>().pageReturner.active = false;
		}
		this.page[0].active = false;
		this.page[1].SendMessage("PageClose");
		this.page[1].GetComponent<Animator>().SetBool("isHoverCorner", true);
		this.page[1].GetComponent<Animator>().SetBool("isPageTurned", true);
		if (this.page[1].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[1].GetComponent<PageLogicC>().pageTurner.active = false;
		}
		if (this.page[1].GetComponent<PageLogicC>().pageReturner != null)
		{
			this.page[1].GetComponent<PageLogicC>().pageReturner.active = false;
		}
		this.page[1].active = false;
		int num2 = num - 1;
		for (int i = 0; i < num2; i++)
		{
			this.page[i].active = true;
			this.page[i].SendMessage("PageClose");
			this.page[i].GetComponent<Animator>().SetBool("isPageTurned", true);
			this.page[i].GetComponent<Animator>().SetTrigger("ForcePageTurn");
			if (this.page[i].GetComponent<PageLogicC>().pageTurner != null)
			{
				this.page[i].GetComponent<PageLogicC>().pageTurner.active = false;
			}
			if (this.page[i].GetComponent<PageLogicC>().pageReturner != null)
			{
				this.page[i].GetComponent<PageLogicC>().pageReturner.active = false;
			}
			this.page[i].GetComponent<Animator>().SetBool("isHoverCorner", false);
		}
		if (this.page[num2] != null)
		{
			this.page[num2].active = true;
		}
		this.page[num2].SendMessage("PageClose");
		this.page[num2].GetComponent<Animator>().SetBool("isPageTurned", true);
		this.page[num2].GetComponent<Animator>().SetTrigger("ForcePageTurn");
		if (this.page[num2].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[num2].GetComponent<PageLogicC>().pageTurner.active = false;
		}
		if (this.page[num2].GetComponent<PageLogicC>().pageReturner != null)
		{
			this.page[num2].GetComponent<PageLogicC>().pageReturner.active = true;
		}
		this.page[1].GetComponent<Animator>().SetBool("isHoverCorner", false);
		this.page[num2].GetComponent<Animator>().SetBool("isHoverCorner", false);
		this.page[num].active = true;
		this.page[num].SendMessage("PageGo");
		if (this.page[num].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[num].GetComponent<PageLogicC>().pageTurner.active = true;
		}
		if (this.page[num].GetComponent<PageLogicC>().pageReturner != null)
		{
			this.page[num].GetComponent<PageLogicC>().pageReturner.active = false;
		}
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x00096CFC File Offset: 0x000950FC
	public IEnumerator ReturnPage()
	{
		if (this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner.active = false;
		}
		this.pageNumber--;
		if (this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner != null)
		{
			this.page[this.pageNumber].GetComponent<PageLogicC>().pageTurner.active = true;
		}
		yield return new WaitForSeconds(0.25f);
		if (this.page[this.pageNumber] != null)
		{
			this.page[this.pageNumber].SendMessage("PageGo");
		}
		int prevPage = this.pageNumber + 1;
		if (prevPage >= 0 && this.page[prevPage] != null)
		{
			this.page[prevPage].SendMessage("PageClose");
			this.page[prevPage].active = false;
		}
		int prevPage2 = this.pageNumber - 1;
		if (prevPage2 >= 0 && this.page[prevPage2] != null && this.page[prevPage2].GetComponent<PageLogicC>().pageReturner != null)
		{
			this.page[prevPage2].GetComponent<PageLogicC>().pageReturner.active = true;
		}
		yield break;
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x00096D18 File Offset: 0x00095118
	public void Zoom()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[1],
			"delay",
			0.0,
			"time",
			1.0,
			"islocal",
			true,
			"easetype",
			"easeinquad"
		}));
		this.isZoomed = true;
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x00096DB8 File Offset: 0x000951B8
	public void ZoomOut()
	{
		this.isZoomed = false;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[0],
			"delay",
			0.0,
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeinquad"
		}));
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x00096E58 File Offset: 0x00095258
	public void ZoomOutClose()
	{
		this.isZoomed = false;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[0],
			"delay",
			0.0,
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeinquad",
			"oncomplete",
			"Close",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x00096F20 File Offset: 0x00095320
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			for (int i = 0; i < this.glowTargets.Length; i++)
			{
				this.glowTargets[i].GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
		if ((Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) && this.isBookOpen && !this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress) || (Input.GetButtonDown("Pause") && this.isBookOpen && !this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress))
		{
			this.isBookOpen = false;
			iTween.Stop(base.gameObject);
			this.Close();
			MainMenuC.Global.restrictPause = false;
		}
		else if ((Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) && this.isBookOpen && !this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress) || (Input.GetButtonDown("Pause") && this.isBookOpen && !this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress))
		{
			this.isBookOpen = false;
			iTween.Stop(base.gameObject);
			this.Close();
			MainMenuC.Global.restrictPause = false;
		}
		else if ((Input.GetButtonDown("Drop") && this.isBookOpen && !this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress) || (Input.GetButtonDown("Pause") && this.isBookOpen && !this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress))
		{
			this.isBookOpen = false;
			iTween.Stop(base.gameObject);
			this.Close();
			MainMenuC.Global.restrictPause = false;
		}
		else if ((Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) && this.isBookOpen && this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress) || (Input.GetButtonDown("Pause") && this.isBookOpen && this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress))
		{
			this.isBookOpen = false;
			iTween.Stop(base.gameObject);
			this.ZoomOutClose();
			base.gameObject.GetComponent<Collider>().enabled = true;
			MainMenuC.Global.restrictPause = false;
		}
		else if ((Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) && this.isBookOpen && this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress) || (Input.GetButtonDown("Pause") && this.isBookOpen && this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress))
		{
			this.isBookOpen = false;
			iTween.Stop(base.gameObject);
			this.ZoomOutClose();
			base.gameObject.GetComponent<Collider>().enabled = true;
			MainMenuC.Global.restrictPause = false;
		}
		else if ((Input.GetButtonDown("Drop") && this.isBookOpen && this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress) || (Input.GetButtonDown("Pause") && this.isBookOpen && this.isZoomed && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress))
		{
			this.isBookOpen = false;
			iTween.Stop(base.gameObject);
			this.ZoomOutClose();
			base.gameObject.GetComponent<Collider>().enabled = true;
			MainMenuC.Global.restrictPause = false;
		}
		if (this.isZoomed)
		{
			Vector3 mousePosition = Input.mousePosition;
			float y = mousePosition.y / this.mousePosSens;
			Vector3 vector = this._camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mousePosition.x, y, 10f));
			base.transform.localPosition.SetY(Mathf.Clamp(vector.y / this.wantedPosSens, -0.22f, 0.18f));
		}
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x000973EC File Offset: 0x000957EC
	public void Close()
	{
		this.pageNumber = 0;
		VfAnimCursor.TurnOffXbox = false;
		if (base.GetComponent<HomeStorageClipboardC>())
		{
			base.GetComponent<HomeStorageClipboardC>().TweenWalletBack();
		}
		if (this.clipBoardReceipt)
		{
			this.TweenReceiptOff();
		}
		if (base.gameObject.GetComponent<Animator>())
		{
			base.gameObject.GetComponent<Animator>().SetBool("open", false);
		}
		for (int i = 0; i < this.page.Length; i++)
		{
			if (this.page[i].GetComponent<PageLogicC>().pageTurner != null)
			{
				this.page[i].GetComponent<PageLogicC>().pageTurner.active = false;
			}
			this.page[i].SendMessage("Close", SendMessageOptions.DontRequireReceiver);
			this.page[i].GetComponent<Collider>().enabled = false;
			this.page[i].active = false;
		}
		base.gameObject.layer = LayerMask.NameToLayer("Interactor");
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		for (int j = 0; j < this.pageMatTargets.Length; j++)
		{
			this.pageMatTargets[j].layer = LayerMask.NameToLayer("Interactor");
		}
		if (this.rearPage)
		{
			this.rearPage.layer = LayerMask.NameToLayer("Interactor");
		}
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.dropOffPoint,
			"delay",
			0.5,
			"time",
			1.0,
			"islocal",
			false,
			"easetype",
			"easeinquad",
			"oncomplete",
			"ResumeCamera",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.dropOffPoint,
			"delay",
			0.5,
			"time",
			0.3,
			"easetype",
			"easeinquad"
		}));
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x00097664 File Offset: 0x00095A64
	public IEnumerator ResumeCamera()
	{
		base.transform.parent = this.dropOffPoint.transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localEulerAngles = Vector3.zero;
		iTween.RotateTo(this._camera.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.storeCamRote,
			"time",
			0.4,
			"islocal",
			true,
			"easetype",
			"easeInQuad"
		}));
		yield return new WaitForSeconds(0.4f);
		this._camera.GetComponent<DragRigidbodyC>().onlyInteractWithPickUpLayer = false;
		MainMenuC.Global.lockCursor = false;
		Screen.lockCursor = true;
		Transform player = this._camera.transform.parent;
		this._camera.GetComponent<MouseLook>().enabled = true;
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		player.gameObject.GetComponent<MouseLook>().enabled = true;
		player.gameObject.GetComponent<RigidbodyControllerC>().enabled = true;
		base.gameObject.GetComponent<Collider>().enabled = true;
		yield break;
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x00097680 File Offset: 0x00095A80
	public void RaycastEnter()
	{
		this.isGlowing = true;
		for (int i = 0; i < this.glowTargets.Length; i++)
		{
			this.glowTargets[i].GetComponent<Renderer>().material = this.glowMaterial;
		}
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x000976C8 File Offset: 0x00095AC8
	public void RaycastExit()
	{
		this.isGlowing = false;
		for (int i = 0; i < this.glowTargets.Length; i++)
		{
			this.glowTargets[i].GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x0009770D File Offset: 0x00095B0D
	public void AddStorageToReceipt()
	{
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x00097710 File Offset: 0x00095B10
	public void StopGlow()
	{
		this.isGlowing = false;
		for (int i = 0; i < this.glowTargets.Length; i++)
		{
			this.glowTargets[i].GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x0400099F RID: 2463
	private GameObject _camera;

	// Token: 0x040009A0 RID: 2464
	public GameObject carLogic;

	// Token: 0x040009A1 RID: 2465
	public GameObject[] page;

	// Token: 0x040009A2 RID: 2466
	public Transform holdingPosition;

	// Token: 0x040009A3 RID: 2467
	public Material startMaterial;

	// Token: 0x040009A4 RID: 2468
	public Material glowMaterial;

	// Token: 0x040009A5 RID: 2469
	public GameObject[] glowTargets;

	// Token: 0x040009A6 RID: 2470
	public GameObject[] pageMatTargets;

	// Token: 0x040009A7 RID: 2471
	private bool isGlowing;

	// Token: 0x040009A8 RID: 2472
	public bool isBookOpen;

	// Token: 0x040009A9 RID: 2473
	public bool isZoomed;

	// Token: 0x040009AA RID: 2474
	public Vector3[] envelopePos;

	// Token: 0x040009AB RID: 2475
	public Transform dropOffPoint;

	// Token: 0x040009AC RID: 2476
	public Transform dropOffPointPath;

	// Token: 0x040009AD RID: 2477
	public GameObject envelope;

	// Token: 0x040009AE RID: 2478
	public AudioClip audioLetterOpen;

	// Token: 0x040009AF RID: 2479
	public float mousePosSens;

	// Token: 0x040009B0 RID: 2480
	public float wantedPosSens;

	// Token: 0x040009B1 RID: 2481
	public float minUnit = -15f;

	// Token: 0x040009B2 RID: 2482
	public float maxUnit = 0.5f;

	// Token: 0x040009B3 RID: 2483
	public float mouseYAdd;

	// Token: 0x040009B4 RID: 2484
	public int pageNumber;

	// Token: 0x040009B5 RID: 2485
	private Vector3 storeCamRote;

	// Token: 0x040009B6 RID: 2486
	public GameObject rearPage;

	// Token: 0x040009B7 RID: 2487
	public GameObject[] specificationDetails;

	// Token: 0x040009B8 RID: 2488
	public GameObject clipBoardReceipt;

	// Token: 0x040009B9 RID: 2489
	public Vector3[] receiptPos;

	// Token: 0x040009BA RID: 2490
	public GameObject[] localisationObj;

	// Token: 0x040009BB RID: 2491
	public GameObject localisationFixTarget;

	// Token: 0x040009BC RID: 2492
	public Material localisationFixMaterial;
}
