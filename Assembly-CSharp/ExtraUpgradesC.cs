using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class ExtraUpgradesC : MonoBehaviour
{
	// Token: 0x060005DD RID: 1501 RVA: 0x000754B6 File Offset: 0x000738B6
	private void Start()
	{
		this.SetLicensePlate();
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x000754C0 File Offset: 0x000738C0
	public void UpdateManualWithRegDetails(int plateStringID)
	{
		if (this.manualRegNumber == null)
		{
			return;
		}
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.FR)
		{
			this.UpdateManualWithRegDetailsFR(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.IT)
		{
			this.UpdateManualWithRegDetailsIT(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.DE)
		{
			this.UpdateManualWithRegDetailsDE(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.ES)
		{
			this.UpdateManualWithRegDetailsES(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.PT_BR)
		{
			this.UpdateManualWithRegDetailsPT_BR(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.TR)
		{
			this.UpdateManualWithRegDetailsTR(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.HU)
		{
			this.UpdateManualWithRegDetailsHU(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.NL)
		{
			this.UpdateManualWithRegDetailsNL(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.FI)
		{
			this.UpdateManualWithRegDetailsFI(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.PL)
		{
			this.UpdateManualWithRegDetailsPL(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.RU)
		{
			this.UpdateManualWithRegDetailsRU(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.SK)
		{
			this.UpdateManualWithRegDetailsSK(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.HR)
		{
			this.UpdateManualWithRegDetailsHR(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.RO)
		{
			this.UpdateManualWithRegDetailsRO(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.NO)
		{
			this.UpdateManualWithRegDetailsNO(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.ZH)
		{
			this.UpdateManualWithRegDetailsZH(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.JA)
		{
			this.UpdateManualWithRegDetailsJA(plateStringID);
			return;
		}
		if (languageCode == LanguageCode.KO)
		{
			this.UpdateManualWithRegDetailsKO(plateStringID);
			return;
		}
		this.manualRegNumber.GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLoc != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLoc.GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumber.GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDate.GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x00075994 File Offset: 0x00073D94
	public void UpdateManualWithRegDetailsFR(int plateStringID)
	{
		this.manualRegNumbers[0].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[0] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[0].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[0].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[0].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x00075D3C File Offset: 0x0007413C
	public void UpdateManualWithRegDetailsIT(int plateStringID)
	{
		this.manualRegNumbers[1].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[1] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[1].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[1].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[1].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x000760E4 File Offset: 0x000744E4
	public void UpdateManualWithRegDetailsDE(int plateStringID)
	{
		this.manualRegNumbers[2].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[2] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[2].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[2].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[2].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x0007648C File Offset: 0x0007488C
	public void UpdateManualWithRegDetailsES(int plateStringID)
	{
		this.manualRegNumbers[3].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[3] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[3].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[3].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[3].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x00076834 File Offset: 0x00074C34
	public void UpdateManualWithRegDetailsPT_BR(int plateStringID)
	{
		this.manualRegNumbers[4].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[4] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[4].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[4].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[4].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x00076BDC File Offset: 0x00074FDC
	public void UpdateManualWithRegDetailsTR(int plateStringID)
	{
		this.manualRegNumbers[5].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[5] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[5].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[5].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[5].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x00076F84 File Offset: 0x00075384
	public void UpdateManualWithRegDetailsHU(int plateStringID)
	{
		this.manualRegNumbers[6].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[6] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[6].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[6].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[6].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x0007732C File Offset: 0x0007572C
	public void UpdateManualWithRegDetailsNL(int plateStringID)
	{
		this.manualRegNumbers[7].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[7] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[7].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[7].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[7].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x000776D4 File Offset: 0x00075AD4
	public void UpdateManualWithRegDetailsFI(int plateStringID)
	{
		this.manualRegNumbers[8].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[8] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[8].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[8].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[8].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x00077A7C File Offset: 0x00075E7C
	public void UpdateManualWithRegDetailsPL(int plateStringID)
	{
		this.manualRegNumbers[9].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[9] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[9].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[9].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[9].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x00077E38 File Offset: 0x00076238
	public void UpdateManualWithRegDetailsRU(int plateStringID)
	{
		this.manualRegNumbers[10].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[10] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[10].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[10].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[10].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x000781F4 File Offset: 0x000765F4
	public void UpdateManualWithRegDetailsSK(int plateStringID)
	{
		this.manualRegNumbers[11].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[11] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[11].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[11].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[11].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x000785B0 File Offset: 0x000769B0
	public void UpdateManualWithRegDetailsHR(int plateStringID)
	{
		this.manualRegNumbers[12].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[12] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[12].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[12].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[12].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x0007896C File Offset: 0x00076D6C
	public void UpdateManualWithRegDetailsRO(int plateStringID)
	{
		Debug.Log("licences plate string number = " + plateStringID);
		this.manualRegNumbers[13].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[13] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[13].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[13].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[13].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x00078D3C File Offset: 0x0007713C
	public void UpdateManualWithRegDetailsNO(int plateStringID)
	{
		this.manualRegNumbers[14].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[14] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[14].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[14].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[14].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x000790F8 File Offset: 0x000774F8
	public void UpdateManualWithRegDetailsZH(int plateStringID)
	{
		this.manualRegNumbers[15].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[15] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[15].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[15].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[15].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x000794B4 File Offset: 0x000778B4
	public void UpdateManualWithRegDetailsJA(int plateStringID)
	{
		this.manualRegNumbers[16].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[16] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[16].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[16].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[16].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00079870 File Offset: 0x00077C70
	public void UpdateManualWithRegDetailsKO(int plateStringID)
	{
		this.manualRegNumbers[17].GetComponent<TextMesh>().text = Language.Get(this.licencePlateStrings[plateStringID], "Inspector_UI");
		if (this.manualRegLocs[17] != null)
		{
			if (plateStringID < 5)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Rostock";
			}
			else if (plateStringID >= 5 && plateStringID < 10)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Schwerin";
			}
			else if (plateStringID >= 10 && plateStringID < 15)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Neubrandenburg";
			}
			else if (plateStringID >= 15 && plateStringID < 20)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Potsdam";
			}
			else if (plateStringID >= 20 && plateStringID < 25)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Frankfurt";
			}
			else if (plateStringID >= 25 && plateStringID < 30)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Erfurt";
			}
			else if (plateStringID >= 30 && plateStringID < 35)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Magdeburg";
			}
			else if (plateStringID >= 35 && plateStringID < 40)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "East Berlin";
			}
			else if (plateStringID >= 40 && plateStringID < 45)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Halle";
			}
			else if (plateStringID >= 45 && plateStringID < 50)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Gera";
			}
			else if (plateStringID >= 50 && plateStringID < 55)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Suhl";
			}
			else if (plateStringID >= 55 && plateStringID < 60)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Dresden";
			}
			else if (plateStringID >= 60 && plateStringID < 65)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Leipzig";
			}
			else if (plateStringID >= 65 && plateStringID < 70)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Karl-Marx-Stadt";
			}
			else if (plateStringID >= 70 && plateStringID < 75)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "Cottbus";
			}
			else if (plateStringID >= 75)
			{
				this.manualRegLocs[17].GetComponent<TextMesh>().text = "East Berlin";
			}
		}
		int num;
		if (this.manualRegNumbers[17].GetComponent<TextMesh>().text[2] == ' ')
		{
			if (ES3.Exists("plateStringIDDate"))
			{
				num = ES3.LoadInt("plateStringIDDate");
			}
			else
			{
				num = UnityEngine.Random.Range(0, this.plateDateStrings.Length - 5);
				ES3.Save(num, "plateStringIDDate");
			}
		}
		else if (ES3.Exists("plateStringIDDate"))
		{
			num = ES3.LoadInt("plateStringIDDate");
		}
		else
		{
			num = UnityEngine.Random.Range(10, this.plateDateStrings.Length);
			ES3.Save(num, "plateStringIDDate");
		}
		this.manualRegDates[17].GetComponent<TextMesh>().text = this.plateDateStrings[num];
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00079C2C File Offset: 0x0007802C
	public void SetLicensePlate()
	{
		int num;
		if (ES3.Exists("plateStringID"))
		{
			num = ES3.LoadInt("plateStringID");
		}
		else
		{
			num = UnityEngine.Random.Range(0, this.licencePlateStrings.Count - 6);
			ES3.Save(num, "plateStringID");
		}
		if (num == 0)
		{
			num = UnityEngine.Random.Range(0, this.licencePlateStrings.Count - 6);
			ES3.Save(num, "plateStringID");
		}
		this.UpdateManualWithRegDetails(num);
		if (num >= 75)
		{
			if (this.rearPlate != null)
			{
				this.rearPlate.GetComponent<MeshFilter>().mesh = this.licencePlateMeshChange[3];
			}
			this.licencePlateTexts[0].SetActive(false);
			this.licencePlateTexts[1].SetActive(false);
			this.licencePlateTexts[2].SetActive(true);
			this.licencePlateTexts[3].SetActive(true);
		}
		else
		{
			if (this.rearPlate != null)
			{
				this.rearPlate.GetComponent<MeshFilter>().mesh = this.licencePlateMeshChange[1];
			}
			this.licencePlateTexts[0].SetActive(true);
			this.licencePlateTexts[1].SetActive(true);
			this.licencePlateTexts[2].SetActive(false);
			this.licencePlateTexts[3].SetActive(false);
		}
		this.licencePlateTexts[0].GetComponent<TextMeshPro>().text = Language.Get(this.licencePlateStrings[num], "Inspector_UI");
		this.licencePlateTexts[1].GetComponent<TextMeshPro>().text = Language.Get(this.licencePlateStrings[num], "Inspector_UI");
		this.licencePlateTexts[2].GetComponent<TextMeshPro>().text = Language.Get(this.licencePlateStrings[num], "Inspector_UI");
		this.licencePlateTexts[3].GetComponent<TextMeshPro>().text = Language.Get(this.licencePlateStrings[num], "Inspector_UI");
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00079E14 File Offset: 0x00078214
	public void LoadExtras()
	{
		if (this.roofRackInstalled)
		{
			this.RoofRackFitted(this.roofRackWeight);
		}
		if (this.bullBarInstalled)
		{
			this.BullBarFitted(this.bullBarWeight);
		}
		if (this.mudGuardsInstalled)
		{
			this.MudGuardsFitted(this.mudGuardsWeight);
		}
		if (this.dashUIInstalled)
		{
			this.DigitalDashFitted(this.dashUIWeight);
		}
		if (this.lightRackInstalled)
		{
			this.LightRackFitted(this.lightRackWeight);
		}
		if (this.toolRackInstalled)
		{
			this.ToolRackLoad(this.toolRackWeight, this.toolRackLevel);
		}
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00079EB1 File Offset: 0x000782B1
	public void RoofRackGlow()
	{
		this.roofRack.GetComponent<ExtraReceiverC>().GlowMesh();
		this.roofRack.GetComponent<ExtraReceiverC>().CollisionsOn();
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x00079ED3 File Offset: 0x000782D3
	public void RoofRackGlowStop()
	{
		this.roofRack.GetComponent<ExtraReceiverC>().GlowStop();
		this.roofRack.GetComponent<ExtraReceiverC>().CollisionsOff();
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x00079EF8 File Offset: 0x000782F8
	public void RoofRackFitted(int weight)
	{
		this.roofRack.GetComponent<ExtraReceiverC>().Action();
		base.GetComponent<CarPerformanceC>().carExtrasWeight += (float)weight;
		base.GetComponent<CarPerformanceC>().totalCarWeight += (float)weight;
		this.roofRackInstalled = true;
		this.roofRack.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.roofRackWeight = weight;
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x00079F5B File Offset: 0x0007835B
	public void BullBarGlow()
	{
		this.bullBar.GetComponent<ExtraReceiverC>().GlowMesh();
		this.bullBar.GetComponent<ExtraReceiverC>().CollisionsOn();
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x00079F7D File Offset: 0x0007837D
	public void BullBarGlowStop()
	{
		this.bullBar.GetComponent<ExtraReceiverC>().GlowStop();
		this.bullBar.GetComponent<ExtraReceiverC>().CollisionsOff();
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x00079FA0 File Offset: 0x000783A0
	public void BullBarFitted(int weight)
	{
		this.bullBar.GetComponent<ExtraReceiverC>().Action();
		base.GetComponent<CarPerformanceC>().carExtrasWeight += (float)weight;
		base.GetComponent<CarPerformanceC>().totalCarWeight += (float)weight;
		this.bullBarInstalled = true;
		this.bullBar.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.bullBarWeight = weight;
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x0007A003 File Offset: 0x00078403
	public void MudGuardsGlow()
	{
		this.mudGuards.GetComponent<ExtraReceiverC>().GlowMesh();
		this.mudGuards.GetComponent<ExtraReceiverC>().CollisionsOn();
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x0007A025 File Offset: 0x00078425
	public void MudGuardsGlowStop()
	{
		this.mudGuards.GetComponent<ExtraReceiverC>().GlowStop();
		this.mudGuards.GetComponent<ExtraReceiverC>().CollisionsOff();
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x0007A048 File Offset: 0x00078448
	public void MudGuardsFitted(int weight)
	{
		this.mudGuards.GetComponent<ExtraReceiverC>().Action();
		base.GetComponent<CarPerformanceC>().carExtrasWeight += (float)weight;
		base.GetComponent<CarPerformanceC>().totalCarWeight += (float)weight;
		this.mudGuardsInstalled = true;
		this.mudGuards.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.mudGuardMudTargets[0].GetComponent<MeshFilter>().mesh = this.mudGuardMesh[0];
		this.mudGuardMudTargets[1].GetComponent<MeshFilter>().mesh = this.mudGuardMesh[1];
		this.mudGuardMudTargets[2].GetComponent<MeshFilter>().mesh = this.mudGuardMesh[2];
		this.mudGuardMudTargets[3].GetComponent<MeshFilter>().mesh = this.mudGuardMesh[3];
		this.mudGuardsWeight = weight;
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x0007A113 File Offset: 0x00078513
	public void DigitalDashGlow()
	{
		this.dashUI.GetComponent<ExtraReceiverC>().GlowMesh();
		this.dashUI.GetComponent<ExtraReceiverC>().CollisionsOn();
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x0007A135 File Offset: 0x00078535
	public void DigitalDashGlowStop()
	{
		this.dashUI.GetComponent<ExtraReceiverC>().GlowStop();
		this.dashUI.GetComponent<ExtraReceiverC>().CollisionsOff();
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x0007A158 File Offset: 0x00078558
	public void DigitalDashFitted(int weight)
	{
		this.dashUI.GetComponent<ExtraReceiverC>().Action();
		base.GetComponent<CarPerformanceC>().carExtrasWeight += (float)weight;
		base.GetComponent<CarPerformanceC>().totalCarWeight += (float)weight;
		this.dashUIInstalled = true;
		this.dashUI.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.dashUIWeight = weight;
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x0007A1BB File Offset: 0x000785BB
	public void LightRackGlow()
	{
		this.lightRack.GetComponent<ExtraReceiverC>().GlowMesh();
		this.lightRack.GetComponent<ExtraReceiverC>().CollisionsOn();
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x0007A1DD File Offset: 0x000785DD
	public void LightRackGlowStop()
	{
		this.lightRack.GetComponent<ExtraReceiverC>().GlowStop();
		this.lightRack.GetComponent<ExtraReceiverC>().CollisionsOff();
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x0007A200 File Offset: 0x00078600
	public void LightRackFitted(int weight)
	{
		this.lightRack.GetComponent<ExtraReceiverC>().Action();
		base.GetComponent<CarPerformanceC>().carExtrasWeight += (float)weight;
		base.GetComponent<CarPerformanceC>().totalCarWeight += (float)weight;
		this.lightRackInstalled = true;
		this.lightRack.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.lightRackWeight = weight;
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x0007A263 File Offset: 0x00078663
	public void ToolRackGlow()
	{
		this.toolRack.GetComponent<ExtraReceiverC>().GlowMesh();
		this.toolRack.GetComponent<ExtraReceiverC>().CollisionsOn();
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x0007A285 File Offset: 0x00078685
	public void ToolRackGlowStop()
	{
		this.toolRack.GetComponent<ExtraReceiverC>().GlowStop();
		this.toolRack.GetComponent<ExtraReceiverC>().CollisionsOff();
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x0007A2A8 File Offset: 0x000786A8
	public void ToolRackFitted(int weight, int lvl)
	{
		if (this.toolRackLevel == 0)
		{
			base.GetComponent<CarPerformanceC>().carExtrasWeight += (float)weight;
			base.GetComponent<CarPerformanceC>().totalCarWeight += (float)weight;
		}
		this.toolRackInstalled = true;
		this.toolRackLevel = lvl;
		if (this.toolRackLevel == 1)
		{
			this.toolRack.GetComponent<ExtraReceiverC>().Action();
		}
		else if (this.toolRackLevel == 2)
		{
			this.toolRack.GetComponent<ExtraReceiverC>().ToolRackToLvl2();
		}
		else if (this.toolRackLevel == 3)
		{
			this.toolRack.GetComponent<ExtraReceiverC>().ToolRackToLvl3();
		}
		this.toolRack.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.toolRackWeight = weight;
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x0007A36C File Offset: 0x0007876C
	public void ToolRackLoad(int weight, int lvl)
	{
		base.GetComponent<CarPerformanceC>().carExtrasWeight += (float)weight;
		base.GetComponent<CarPerformanceC>().totalCarWeight += (float)weight;
		this.toolRack.GetComponent<ExtraReceiverC>().Action();
		this.toolRackInstalled = true;
		this.toolRackLevel = lvl;
		if (this.toolRackLevel == 2)
		{
			this.toolRack.GetComponent<ExtraReceiverC>().ToolRackToLvl2();
		}
		else if (this.toolRackLevel == 3)
		{
			this.toolRack.GetComponent<ExtraReceiverC>().ToolRackToLvl3();
		}
		this.toolRack.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.toolRackWeight = weight;
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x0007A414 File Offset: 0x00078814
	public void SetDecals(Material mat, bool applyDecal = false)
	{
		if (applyDecal)
		{
			this.currentDecal = mat;
		}
		Material[] materials = this.decalTargets[0].GetComponent<Renderer>().materials;
		materials[1] = mat;
		this.decalTargets[0].GetComponent<Renderer>().materials = materials;
		this.decalTargets[0].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials2 = this.decalTargets[1].GetComponent<Renderer>().materials;
		materials2[1] = mat;
		this.decalTargets[1].GetComponent<Renderer>().materials = materials2;
		this.decalTargets[1].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials3 = this.decalTargets[2].GetComponent<Renderer>().materials;
		materials3[1] = mat;
		this.decalTargets[2].GetComponent<Renderer>().materials = materials3;
		this.decalTargets[2].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials4 = this.decalTargets[3].GetComponent<Renderer>().materials;
		materials4[1] = mat;
		this.decalTargets[3].GetComponent<Renderer>().materials = materials4;
		this.decalTargets[3].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials5 = this.decalTargets[4].GetComponent<Renderer>().materials;
		materials5[1] = mat;
		this.decalTargets[4].GetComponent<Renderer>().materials = materials5;
		this.decalTargets[4].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials6 = this.decalTargets[5].GetComponent<Renderer>().materials;
		materials6[1] = mat;
		this.decalTargets[5].GetComponent<Renderer>().materials = materials6;
		this.decalTargets[5].GetComponent<Renderer>().materials[1].color = this.decalColour;
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x0007A5EA File Offset: 0x000789EA
	public void DecalGlow()
	{
		this.decalCol.GetComponent<ExtraReceiverC>().GlowDecal();
		this.decalCol.GetComponent<ExtraReceiverC>().CollisionsOn();
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x0007A60C File Offset: 0x00078A0C
	public void DecalGlowStop()
	{
		this.decalCol.GetComponent<ExtraReceiverC>().CollisionsOff();
		Material[] materials = this.decalTargets[0].GetComponent<Renderer>().materials;
		materials[1] = this.installedDecal;
		this.decalTargets[0].GetComponent<Renderer>().materials = materials;
		this.decalTargets[0].GetComponent<Renderer>().materials[1].color = this.installedDecalColor;
		Material[] materials2 = this.decalTargets[1].GetComponent<Renderer>().materials;
		materials2[1] = this.installedDecal;
		this.decalTargets[1].GetComponent<Renderer>().materials = materials2;
		this.decalTargets[1].GetComponent<Renderer>().materials[1].color = this.installedDecalColor;
		Material[] materials3 = this.decalTargets[2].GetComponent<Renderer>().materials;
		materials3[1] = this.installedDecal;
		this.decalTargets[2].GetComponent<Renderer>().materials = materials3;
		this.decalTargets[2].GetComponent<Renderer>().materials[1].color = this.installedDecalColor;
		Material[] materials4 = this.decalTargets[3].GetComponent<Renderer>().materials;
		materials4[1] = this.installedDecal;
		this.decalTargets[3].GetComponent<Renderer>().materials = materials4;
		this.decalTargets[3].GetComponent<Renderer>().materials[1].color = this.installedDecalColor;
		Material[] materials5 = this.decalTargets[4].GetComponent<Renderer>().materials;
		materials5[1] = this.installedDecal;
		this.decalTargets[4].GetComponent<Renderer>().materials = materials5;
		this.decalTargets[4].GetComponent<Renderer>().materials[1].color = this.installedDecalColor;
		Material[] materials6 = this.decalTargets[5].GetComponent<Renderer>().materials;
		materials6[1] = this.installedDecal;
		this.decalTargets[5].GetComponent<Renderer>().materials = materials6;
		this.decalTargets[5].GetComponent<Renderer>().materials[1].color = this.installedDecalColor;
		this.decalCol.GetComponent<ExtraReceiverC>().GlowStop();
		this.decalCol.GetComponent<ExtraReceiverC>().CollisionsOff();
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x0007A824 File Offset: 0x00078C24
	public void NewDecal(Material mat)
	{
		this.installedDecalColor = this.decalColour;
		this.installedDecal = mat;
		this.decalCol.GetComponent<ExtraReceiverC>().CollisionsOff();
		this.decalCol.GetComponent<ExtraReceiverC>().glowGo = false;
		Material[] materials = this.decalTargets[0].GetComponent<Renderer>().materials;
		materials[1] = mat;
		this.decalTargets[0].GetComponent<Renderer>().materials = materials;
		this.decalTargets[0].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials2 = this.decalTargets[1].GetComponent<Renderer>().materials;
		materials2[1] = mat;
		this.decalTargets[1].GetComponent<Renderer>().materials = materials2;
		this.decalTargets[1].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials3 = this.decalTargets[2].GetComponent<Renderer>().materials;
		materials3[1] = mat;
		this.decalTargets[2].GetComponent<Renderer>().materials = materials3;
		this.decalTargets[2].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials4 = this.decalTargets[3].GetComponent<Renderer>().materials;
		materials4[1] = mat;
		this.decalTargets[3].GetComponent<Renderer>().materials = materials4;
		this.decalTargets[3].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials5 = this.decalTargets[4].GetComponent<Renderer>().materials;
		materials5[1] = mat;
		this.decalTargets[4].GetComponent<Renderer>().materials = materials5;
		this.decalTargets[4].GetComponent<Renderer>().materials[1].color = this.decalColour;
		Material[] materials6 = this.decalTargets[5].GetComponent<Renderer>().materials;
		materials6[1] = mat;
		this.decalTargets[5].GetComponent<Renderer>().materials = materials6;
		this.decalTargets[5].GetComponent<Renderer>().materials[1].color = this.decalColour;
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x0007AA24 File Offset: 0x00078E24
	public void ParticlesAndAnim(GameObject particlePrefab)
	{
		GameObject obj = UnityEngine.Object.Instantiate<GameObject>(particlePrefab, base.transform.position, Quaternion.identity);
		UnityEngine.Object.Destroy(obj, 0.55f);
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x0007AA54 File Offset: 0x00078E54
	public void IgnitionCheckAllUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		CarPerformanceC component = base.GetComponent<CarPerformanceC>();
		if (base.GetComponent<CarPerformanceC>().installedFuelTank)
		{
			double num = (double)component.installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount * 0.34;
			if ((double)component.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount <= num)
			{
				this.LowFuelUI();
			}
			else if ((double)component.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount <= 0.0)
			{
				this.FuelEmptyOnOffUI();
			}
			else
			{
				this.HighFuelUI();
			}
			double num2 = (double)component.installedFuelTank.GetComponent<EngineComponentC>().durability * 0.34;
			if ((double)component.installedFuelTank.GetComponent<EngineComponentC>().Condition < num2 && (double)component.installedFuelTank.GetComponent<EngineComponentC>().Condition > 0.0)
			{
				this.FuelTankConditionOrangeUI();
			}
			else if ((double)component.installedFuelTank.GetComponent<EngineComponentC>().Condition <= 0.0)
			{
				this.FuelTankConditionRedUI();
			}
			else
			{
				this.FuelTankConditionGreenUI();
			}
		}
		else
		{
			this.FuelTankMissingUI();
		}
		if (base.GetComponent<CarPerformanceC>().installedCarburettor)
		{
			double num3 = (double)component.installedCarburettor.GetComponent<EngineComponentC>().durability * 0.34;
			if ((double)component.installedCarburettor.GetComponent<EngineComponentC>().Condition < num3 && component.installedCarburettor.GetComponent<EngineComponentC>().Condition > 0f)
			{
				this.CarburettorConditionOrangeUI();
			}
			else if ((double)component.installedCarburettor.GetComponent<EngineComponentC>().Condition <= 0.0)
			{
				this.CarburettorConditionRedUI();
			}
			else
			{
				this.CarburettorConditionGreenUI();
			}
		}
		else
		{
			this.CarburettorMissingUI();
		}
		if (base.GetComponent<CarPerformanceC>().InstalledEngine)
		{
			float num4 = component.InstalledEngine.GetComponent<EngineComponentC>().durability * 0.34f;
			if (component.InstalledEngine.GetComponent<EngineComponentC>().Condition < num4 && component.InstalledEngine.GetComponent<EngineComponentC>().Condition > 0f)
			{
				this.EngineBlockConditionOrangeUI();
			}
			else if (component.InstalledEngine.GetComponent<EngineComponentC>().Condition <= 0f)
			{
				this.EngineBlockConditionRedUI();
			}
			else
			{
				this.EngineBlockConditionGreenUI();
			}
		}
		else
		{
			this.EngineBlockMissingUI();
		}
		if (base.GetComponent<CarPerformanceC>().installedAirFilter)
		{
			float num5 = component.installedAirFilter.GetComponent<EngineComponentC>().durability * 0.34f;
			if (component.installedAirFilter.GetComponent<EngineComponentC>().Condition < num5 && component.installedAirFilter.GetComponent<EngineComponentC>().Condition > 0f)
			{
				this.AirFilterConditionOrangeUI();
			}
			else if (component.installedAirFilter.GetComponent<EngineComponentC>().Condition <= 0f)
			{
				this.AirFilterConditionRedUI();
			}
			else
			{
				this.AirFilterConditionGreenUI();
			}
		}
		else
		{
			this.AirFilterMissingUI();
		}
		if (base.GetComponent<CarPerformanceC>().installedIgnitionCoil)
		{
			double num6 = (double)component.installedIgnitionCoil.GetComponent<EngineComponentC>().durability * 0.34;
			if ((double)component.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition < num6 && (double)component.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition > 0.0)
			{
				this.IgnitionCoilConditionOrangeUI();
			}
			else if ((double)component.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition <= 0.0)
			{
				this.IgnitionCoilConditionRedUI();
			}
			else
			{
				this.IgnitionCoilConditionGreenUI();
			}
		}
		else
		{
			this.IgnitionCoilMissingUI();
		}
		if (base.GetComponent<CarPerformanceC>().installedBattery)
		{
			double num7 = (double)component.installedBattery.GetComponent<EngineComponentC>().durability * 0.34;
			if ((double)component.installedBattery.GetComponent<EngineComponentC>().Condition < num7 && (double)component.installedBattery.GetComponent<EngineComponentC>().Condition > 0.0)
			{
				this.BatteryConditionOrangeUI();
			}
			else if ((double)component.installedBattery.GetComponent<EngineComponentC>().Condition <= 0.0)
			{
				this.BatteryConditionRedUI();
			}
			else
			{
				this.BatteryConditionGreenUI();
			}
		}
		else
		{
			this.BatteryMissingUI();
		}
		if (base.GetComponent<CarPerformanceC>().installedBattery)
		{
			double num8 = 34.0;
			if ((double)component.installedBattery.GetComponent<EngineComponentC>().charge < num8 && (double)component.installedBattery.GetComponent<EngineComponentC>().charge > 0.0)
			{
				this.LowChargeUI();
			}
			else if ((double)component.installedBattery.GetComponent<EngineComponentC>().charge <= 0.0)
			{
				this.OutOfChargeUI();
			}
			else
			{
				this.HighChargeUI();
			}
		}
		if (base.GetComponent<CarPerformanceC>().waterTankObj)
		{
			double num9 = (double)component.waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges * 0.34;
			if ((double)component.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges < num9 && (double)component.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges > 0.0)
			{
				this.LowWaterUI();
			}
			else if ((double)component.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges <= 0.0)
			{
				this.OutOfWaterUI();
			}
			else
			{
				this.HighWaterUI();
			}
		}
		if (base.GetComponent<CarPerformanceC>().waterTankObj)
		{
			double num10 = (double)component.waterTankObj.GetComponent<EngineComponentC>().durability * 0.34;
			if ((double)component.waterTankObj.GetComponent<EngineComponentC>().Condition < num10 && (double)component.waterTankObj.GetComponent<EngineComponentC>().Condition > 0.0)
			{
				this.WaterTankConditionOrangeUI();
			}
			else if ((double)component.waterTankObj.GetComponent<EngineComponentC>().Condition <= 0.0)
			{
				this.WaterTankConditionRedUI();
			}
			else
			{
				this.WaterTankConditionGreenUI();
			}
		}
		else
		{
			this.WaterTankMissingUI();
		}
		if (base.GetComponent<CarPerformanceC>().carBootWeight >= 180f)
		{
			this.WeightRedUI();
		}
		else if (base.GetComponent<CarPerformanceC>().carBootWeight >= 120f)
		{
			this.WeightOrangeUI();
		}
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x0007B0F4 File Offset: 0x000794F4
	public void IgnitionAllUIOff()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.TyreHighUI(0);
		this.TyreHighUI(1);
		this.TyreHighUI(2);
		this.TyreHighUI(3);
		this.HighFuelUI();
		this.GoodOilUI();
		this.FuelTankConditionGreenUI();
		this.CarburettorConditionGreenUI();
		this.EngineBlockConditionGreenUI();
		this.IgnitionCoilConditionGreenUI();
		this.AirFilterConditionGreenUI();
		this.BatteryConditionGreenUI();
		this.HighChargeUI();
		this.WaterTankConditionGreenUI();
		this.HighWaterUI();
		this.WeightGreenUI();
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x0007B171 File Offset: 0x00079571
	public void TyreFlatUI(int iD)
	{
		base.StartCoroutine(this.CTyreFlatUI(iD));
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x0007B184 File Offset: 0x00079584
	private IEnumerator CTyreFlatUI(int iD)
	{
		if (this.dashUIInstalled)
		{
			int tyreID = 0;
			int damageID = 0;
			if (iD == 0)
			{
				tyreID = 20;
				damageID = 21;
			}
			else if (iD == 1)
			{
				tyreID = 22;
				damageID = 23;
			}
			else if (iD == 2)
			{
				tyreID = 24;
				damageID = 25;
			}
			else if (iD == 3)
			{
				tyreID = 26;
				damageID = 27;
			}
			Debug.Log(" Tyre UI Called - Flat ");
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x0007B1A6 File Offset: 0x000795A6
	public void TyreLowUI(int iD)
	{
		base.StartCoroutine(this.CTyreLowUI(iD));
	}

	// Token: 0x06000610 RID: 1552 RVA: 0x0007B1B8 File Offset: 0x000795B8
	private IEnumerator CTyreLowUI(int iD)
	{
		if (this.dashUIInstalled)
		{
			int tyreID = 0;
			int damageID = 0;
			if (iD == 0)
			{
				tyreID = 20;
				damageID = 21;
			}
			else if (iD == 1)
			{
				tyreID = 22;
				damageID = 23;
			}
			else if (iD == 2)
			{
				tyreID = 24;
				damageID = 25;
			}
			else if (iD == 3)
			{
				tyreID = 26;
				damageID = 27;
			}
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[tyreID].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[damageID].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000611 RID: 1553 RVA: 0x0007B1DC File Offset: 0x000795DC
	public void TyreHighUI(int iD)
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		if (iD == 0)
		{
			num = 20;
			num2 = 21;
		}
		else if (iD == 1)
		{
			num = 22;
			num2 = 23;
		}
		else if (iD == 2)
		{
			num = 24;
			num2 = 25;
		}
		else if (iD == 3)
		{
			num = 26;
			num2 = 27;
		}
		this.dashUIComponents[num].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[num2].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x06000612 RID: 1554 RVA: 0x0007B26F File Offset: 0x0007966F
	public void OutOfFuelUI()
	{
		base.StartCoroutine(this.COutOfFuelUI());
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x0007B280 File Offset: 0x00079680
	private IEnumerator COutOfFuelUI()
	{
		if (this.dashUIInstalled)
		{
			this.fuelUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x0007B29B File Offset: 0x0007969B
	public void FuelEmptyOnOffUI()
	{
		base.StartCoroutine(this.CFuelEmptyOnOffUI());
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x0007B2AC File Offset: 0x000796AC
	private IEnumerator CFuelEmptyOnOffUI()
	{
		if (this.dashUIInstalled)
		{
			this.fuelUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.HighFuelUI();
		}
		yield break;
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x0007B2C7 File Offset: 0x000796C7
	public void FuelTankMissingUI()
	{
		base.StartCoroutine(this.CFuelTankMissingUI());
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x0007B2D8 File Offset: 0x000796D8
	private IEnumerator CFuelTankMissingUI()
	{
		if (this.dashUIInstalled)
		{
			this.fuelTankConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.FuelTankConditionGreenUI();
		}
		yield break;
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x0007B2F3 File Offset: 0x000796F3
	public void LowFuelUI()
	{
		base.StartCoroutine(this.CLowFuelUI());
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x0007B304 File Offset: 0x00079704
	private IEnumerator CLowFuelUI()
	{
		if (this.dashUIInstalled)
		{
			this.fuelUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x0007B31F File Offset: 0x0007971F
	public void HighFuelUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.fuelUIState = 0;
		this.dashUIComponents[4].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x0007B34E File Offset: 0x0007974E
	public void OutOfOilUI()
	{
		base.StartCoroutine(this.COutOfOilUI());
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x0007B360 File Offset: 0x00079760
	private IEnumerator COutOfOilUI()
	{
		if (this.dashUIInstalled)
		{
			this.oilUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x0007B37B File Offset: 0x0007977B
	public void BadOilUI()
	{
		base.StartCoroutine(this.CBadOilUI());
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x0007B38C File Offset: 0x0007978C
	private IEnumerator CBadOilUI()
	{
		if (this.dashUIInstalled)
		{
			this.oilUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x0007B3A7 File Offset: 0x000797A7
	public void GoodOilUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.oilUIState = 0;
		this.dashUIComponents[5].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x0007B3D6 File Offset: 0x000797D6
	public void FuelTankConditionRedUI()
	{
		base.StartCoroutine(this.CFuelTankConditionRedUI());
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x0007B3E8 File Offset: 0x000797E8
	private IEnumerator CFuelTankConditionRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.fuelTankConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x0007B403 File Offset: 0x00079803
	public void FuelTankConditionOrangeUI()
	{
		base.StartCoroutine(this.CFuelTankConditionOrangeUI());
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x0007B414 File Offset: 0x00079814
	private IEnumerator CFuelTankConditionOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.fuelTankConditionUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x0007B430 File Offset: 0x00079830
	public void FuelTankConditionGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.fuelTankConditionUIState = 0;
		this.dashUIComponents[2].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[3].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x0007B484 File Offset: 0x00079884
	public void CarburettorConditionRedUI()
	{
		base.StartCoroutine(this.CCarburettorConditionRedUI());
	}

	// Token: 0x06000626 RID: 1574 RVA: 0x0007B494 File Offset: 0x00079894
	private IEnumerator CCarburettorConditionRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.carburettorConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x0007B4AF File Offset: 0x000798AF
	public void CarburettorConditionOrangeUI()
	{
		base.StartCoroutine(this.CCarburettorConditionOrangeUI());
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x0007B4C0 File Offset: 0x000798C0
	private IEnumerator CCarburettorConditionOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.carburettorConditionUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x0007B4DC File Offset: 0x000798DC
	public void CarburettorConditionGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.carburettorConditionUIState = 0;
		this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[9].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x0007B531 File Offset: 0x00079931
	public void CarburettorMissingUI()
	{
		base.StartCoroutine(this.CCarburettorMissingUI());
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x0007B540 File Offset: 0x00079940
	private IEnumerator CCarburettorMissingUI()
	{
		if (this.dashUIInstalled)
		{
			this.carburettorConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[8].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.CarburettorConditionGreenUI();
		}
		yield break;
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x0007B55B File Offset: 0x0007995B
	public void EngineBlockConditionRedUI()
	{
		base.StartCoroutine(this.CEngineBlockConditionRedUI());
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x0007B56C File Offset: 0x0007996C
	private IEnumerator CEngineBlockConditionRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.engineBlockConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x0007B587 File Offset: 0x00079987
	public void EngineBlockConditionOrangeUI()
	{
		base.StartCoroutine(this.CEngineBlockConditionOrangeUI());
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x0007B598 File Offset: 0x00079998
	private IEnumerator CEngineBlockConditionOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.engineBlockConditionUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x0007B5B4 File Offset: 0x000799B4
	public void EngineBlockConditionGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.engineBlockConditionUIState = 0;
		this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[1].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0007B608 File Offset: 0x00079A08
	public void EngineBlockMissingUI()
	{
		base.StartCoroutine(this.CEngineBlockMissingUI());
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0007B618 File Offset: 0x00079A18
	private IEnumerator CEngineBlockMissingUI()
	{
		if (this.dashUIInstalled)
		{
			this.engineBlockConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[0].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.EngineBlockConditionGreenUI();
		}
		yield break;
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x0007B633 File Offset: 0x00079A33
	public void IgnitionCoilConditionRedUI()
	{
		base.StartCoroutine(this.CIgnitionCoilConditionRedUI());
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x0007B644 File Offset: 0x00079A44
	private IEnumerator CIgnitionCoilConditionRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.ignitionCoilConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.IgnitionCoilConditionGreenUI();
		}
		yield break;
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x0007B65F File Offset: 0x00079A5F
	public void IgnitionCoilConditionRemovedUI()
	{
		base.StartCoroutine(this.CIgnitionCoilConditionRemovedUI());
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x0007B670 File Offset: 0x00079A70
	private IEnumerator CIgnitionCoilConditionRemovedUI()
	{
		if (this.dashUIInstalled)
		{
			this.ignitionCoilConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x0007B68B File Offset: 0x00079A8B
	public void IgnitionCoilConditionOrangeUI()
	{
		base.StartCoroutine(this.CIgnitionCoilConditionOrangeUI());
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x0007B69C File Offset: 0x00079A9C
	private IEnumerator CIgnitionCoilConditionOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.ignitionCoilConditionUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x0007B6B8 File Offset: 0x00079AB8
	public void IgnitionCoilConditionGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.ignitionCoilConditionUIState = 0;
		this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[7].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x0007B70C File Offset: 0x00079B0C
	public void IgnitionCoilMissingUI()
	{
		base.StartCoroutine(this.CIgnitionCoilMissingUI());
	}

	// Token: 0x0600063B RID: 1595 RVA: 0x0007B71C File Offset: 0x00079B1C
	private IEnumerator CIgnitionCoilMissingUI()
	{
		if (this.dashUIInstalled)
		{
			this.ignitionCoilConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[6].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.IgnitionCoilConditionGreenUI();
		}
		yield break;
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0007B737 File Offset: 0x00079B37
	public void AirFilterConditionRedUI()
	{
		base.StartCoroutine(this.CAirFilterConditionRedUI());
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x0007B748 File Offset: 0x00079B48
	private IEnumerator CAirFilterConditionRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.airFilterConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x0007B763 File Offset: 0x00079B63
	public void AirFilterConditionOrangeUI()
	{
		base.StartCoroutine(this.CAirFilterConditionOrangeUI());
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x0007B774 File Offset: 0x00079B74
	private IEnumerator CAirFilterConditionOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.airFilterConditionUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x0007B790 File Offset: 0x00079B90
	public void AirFilterConditionGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.airFilterConditionUIState = 0;
		this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[11].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x0007B7E6 File Offset: 0x00079BE6
	public void AirFilterMissingUI()
	{
		base.StartCoroutine(this.CAirFilterMissingUI());
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x0007B7F8 File Offset: 0x00079BF8
	private IEnumerator CAirFilterMissingUI()
	{
		if (this.dashUIInstalled)
		{
			this.airFilterConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[10].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000643 RID: 1603 RVA: 0x0007B813 File Offset: 0x00079C13
	public void BatteryConditionRedUI()
	{
		base.StartCoroutine(this.CBatteryConditionRedUI());
	}

	// Token: 0x06000644 RID: 1604 RVA: 0x0007B824 File Offset: 0x00079C24
	private IEnumerator CBatteryConditionRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.batteryConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.BatteryConditionGreenUI();
		}
		yield break;
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x0007B83F File Offset: 0x00079C3F
	public void BatteryConditionRedUI2()
	{
		base.StartCoroutine(this.CBatteryConditionRedUI2());
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x0007B850 File Offset: 0x00079C50
	private IEnumerator CBatteryConditionRedUI2()
	{
		if (this.dashUIInstalled)
		{
			this.batteryConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x0007B86B File Offset: 0x00079C6B
	public void BatteryConditionOrangeUI()
	{
		base.StartCoroutine(this.CBatteryConditionOrangeUI());
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x0007B87C File Offset: 0x00079C7C
	private IEnumerator CBatteryConditionOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.batteryConditionUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x0007B898 File Offset: 0x00079C98
	public void BatteryConditionGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.batteryConditionUIState = 0;
		this.dashUIComponents[13].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x0007B8EE File Offset: 0x00079CEE
	public void OutOfChargeUI()
	{
		base.StartCoroutine(this.COutOfChargeUI());
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x0007B900 File Offset: 0x00079D00
	private IEnumerator COutOfChargeUI()
	{
		if (this.dashUIInstalled)
		{
			this.chargeUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.HighChargeUI();
		}
		yield break;
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x0007B91B File Offset: 0x00079D1B
	public void OutOfChargeUI2()
	{
		base.StartCoroutine(this.COutOfChargeUI2());
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0007B92C File Offset: 0x00079D2C
	private IEnumerator COutOfChargeUI2()
	{
		if (this.dashUIInstalled)
		{
			this.chargeUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0007B947 File Offset: 0x00079D47
	public void LowChargeUI()
	{
		base.StartCoroutine(this.CLowChargeUI());
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x0007B958 File Offset: 0x00079D58
	private IEnumerator CLowChargeUI()
	{
		if (this.dashUIInstalled)
		{
			this.chargeUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x0007B973 File Offset: 0x00079D73
	public void HighChargeUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.chargeUIState = 0;
		this.dashUIComponents[14].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0007B9A3 File Offset: 0x00079DA3
	public void BatteryMissingUI()
	{
		base.StartCoroutine(this.CBatteryMissingUI());
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x0007B9B4 File Offset: 0x00079DB4
	private IEnumerator CBatteryMissingUI()
	{
		if (this.dashUIInstalled)
		{
			this.batteryConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[12].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.BatteryConditionGreenUI();
		}
		yield break;
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0007B9CF File Offset: 0x00079DCF
	public void WaterTankConditionRedUI()
	{
		base.StartCoroutine(this.CWaterTankConditionRedUI());
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x0007B9E0 File Offset: 0x00079DE0
	private IEnumerator CWaterTankConditionRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.waterTankConditionUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0007B9FB File Offset: 0x00079DFB
	public void WaterTankConditionOrangeUI()
	{
		base.StartCoroutine(this.CWaterTankConditionOrangeUI());
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0007BA0C File Offset: 0x00079E0C
	private IEnumerator CWaterTankConditionOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.waterTankConditionUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0007BA28 File Offset: 0x00079E28
	public void WaterTankConditionGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.waterTankConditionUIState = 0;
		this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[16].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x0007BA7E File Offset: 0x00079E7E
	public void WaterTankMissingUI()
	{
		base.StartCoroutine(this.CWaterTankMissingUI());
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x0007BA90 File Offset: 0x00079E90
	private IEnumerator CWaterTankMissingUI()
	{
		if (this.dashUIInstalled)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[15].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x0007BAAB File Offset: 0x00079EAB
	public void OutOfWaterUI()
	{
		base.StartCoroutine(this.COutOfWaterUI());
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x0007BABC File Offset: 0x00079EBC
	private IEnumerator COutOfWaterUI()
	{
		if (this.dashUIInstalled)
		{
			this.waterUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x0007BAD7 File Offset: 0x00079ED7
	public void LowWaterUI()
	{
		base.StartCoroutine(this.CLowWaterUI());
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x0007BAE8 File Offset: 0x00079EE8
	private IEnumerator CLowWaterUI()
	{
		if (this.dashUIInstalled)
		{
			this.waterUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x0007BB03 File Offset: 0x00079F03
	public void HighWaterUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.waterUIState = 0;
		this.dashUIComponents[17].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x0007BB33 File Offset: 0x00079F33
	public void WeightRedUI()
	{
		base.StartCoroutine(this.CWeightRedUI());
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x0007BB44 File Offset: 0x00079F44
	private IEnumerator CWeightRedUI()
	{
		if (this.dashUIInstalled)
		{
			this.weightUIState = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[2];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[2];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[2];
		}
		yield break;
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x0007BB5F File Offset: 0x00079F5F
	public void WeightOrangeUI()
	{
		base.StartCoroutine(this.CWeightOrangeUI());
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x0007BB70 File Offset: 0x00079F70
	private IEnumerator CWeightOrangeUI()
	{
		if (this.dashUIInstalled)
		{
			this.weightUIState = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.beepAudio, 0.3f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[1];
			yield return new WaitForSeconds(0.15f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[0];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[0];
			yield return new WaitForSeconds(0.1f);
			this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[1];
			this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[1];
		}
		yield break;
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x0007BB8C File Offset: 0x00079F8C
	public void WeightGreenUI()
	{
		if (!this.dashUIInstalled)
		{
			return;
		}
		this.weightUIState = 0;
		this.dashUIComponents[18].GetComponent<Renderer>().material = this.dashUIMats[0];
		this.dashUIComponents[19].GetComponent<Renderer>().material = this.dashUIMats[0];
	}

	// Token: 0x04000855 RID: 2133
	public GameObject roofRack;

	// Token: 0x04000856 RID: 2134
	public bool roofRackInstalled;

	// Token: 0x04000857 RID: 2135
	public int roofRackWeight;

	// Token: 0x04000858 RID: 2136
	public GameObject bullBar;

	// Token: 0x04000859 RID: 2137
	public bool bullBarInstalled;

	// Token: 0x0400085A RID: 2138
	public GameObject bullBarMudTarget;

	// Token: 0x0400085B RID: 2139
	public Mesh bullBarMudMesh;

	// Token: 0x0400085C RID: 2140
	public int bullBarWeight;

	// Token: 0x0400085D RID: 2141
	public GameObject mudGuards;

	// Token: 0x0400085E RID: 2142
	public bool mudGuardsInstalled;

	// Token: 0x0400085F RID: 2143
	public GameObject[] mudGuardMudTargets = new GameObject[0];

	// Token: 0x04000860 RID: 2144
	public Mesh[] mudGuardMesh = new Mesh[0];

	// Token: 0x04000861 RID: 2145
	public int mudGuardsWeight;

	// Token: 0x04000862 RID: 2146
	public bool dashUIInstalled;

	// Token: 0x04000863 RID: 2147
	public GameObject dashUI;

	// Token: 0x04000864 RID: 2148
	public GameObject[] dashUIComponents = new GameObject[0];

	// Token: 0x04000865 RID: 2149
	public Material[] dashUIMats = new Material[0];

	// Token: 0x04000866 RID: 2150
	public int dashUIWeight;

	// Token: 0x04000867 RID: 2151
	public AudioClip beepAudio;

	// Token: 0x04000868 RID: 2152
	public bool lightRackInstalled;

	// Token: 0x04000869 RID: 2153
	public GameObject lightRack;

	// Token: 0x0400086A RID: 2154
	public int lightRackWeight;

	// Token: 0x0400086B RID: 2155
	public GameObject lightRackLight;

	// Token: 0x0400086C RID: 2156
	public GameObject[] lightRackMatTarget = new GameObject[0];

	// Token: 0x0400086D RID: 2157
	public bool toolRackInstalled;

	// Token: 0x0400086E RID: 2158
	public GameObject toolRack;

	// Token: 0x0400086F RID: 2159
	public int toolRackWeight;

	// Token: 0x04000870 RID: 2160
	public int toolRackLevel;

	// Token: 0x04000871 RID: 2161
	public List<string> licencePlateStrings = new List<string>();

	// Token: 0x04000872 RID: 2162
	public GameObject frontPlate;

	// Token: 0x04000873 RID: 2163
	public GameObject rearPlate;

	// Token: 0x04000874 RID: 2164
	public GameObject[] licencePlateTexts = new GameObject[0];

	// Token: 0x04000875 RID: 2165
	public Mesh[] licencePlateMeshChange = new Mesh[0];

	// Token: 0x04000876 RID: 2166
	public int fuelUIState;

	// Token: 0x04000877 RID: 2167
	public int oilUIState;

	// Token: 0x04000878 RID: 2168
	public int fuelTankConditionUIState;

	// Token: 0x04000879 RID: 2169
	public int carburettorConditionUIState;

	// Token: 0x0400087A RID: 2170
	public int engineBlockConditionUIState;

	// Token: 0x0400087B RID: 2171
	public int ignitionCoilConditionUIState;

	// Token: 0x0400087C RID: 2172
	public int airFilterConditionUIState;

	// Token: 0x0400087D RID: 2173
	public int batteryConditionUIState;

	// Token: 0x0400087E RID: 2174
	public int chargeUIState;

	// Token: 0x0400087F RID: 2175
	public int waterUIState;

	// Token: 0x04000880 RID: 2176
	public int waterTankConditionUIState;

	// Token: 0x04000881 RID: 2177
	public int weightUIState;

	// Token: 0x04000882 RID: 2178
	[Header("Custom Decals")]
	public GameObject[] decalTargets = new GameObject[0];

	// Token: 0x04000883 RID: 2179
	public GameObject decalCol;

	// Token: 0x04000884 RID: 2180
	public Color decalColour;

	// Token: 0x04000885 RID: 2181
	public Material installedDecal;

	// Token: 0x04000886 RID: 2182
	public Color installedDecalColor;

	// Token: 0x04000887 RID: 2183
	public int installedDecalID;

	// Token: 0x04000888 RID: 2184
	public GameObject manualRegNumber;

	// Token: 0x04000889 RID: 2185
	public GameObject manualRegLoc;

	// Token: 0x0400088A RID: 2186
	public GameObject manualRegDate;

	// Token: 0x0400088B RID: 2187
	public string[] plateDateStrings = new string[0];

	// Token: 0x0400088C RID: 2188
	public GameObject[] manualRegNumbers = new GameObject[0];

	// Token: 0x0400088D RID: 2189
	public GameObject[] manualRegLocs = new GameObject[0];

	// Token: 0x0400088E RID: 2190
	public GameObject[] manualRegDates = new GameObject[0];

	// Token: 0x0400088F RID: 2191
	public Material currentDecal;
}
