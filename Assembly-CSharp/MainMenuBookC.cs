using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000C8 RID: 200
public class MainMenuBookC : MonoBehaviour
{
	// Token: 0x0600075A RID: 1882 RVA: 0x000991F0 File Offset: 0x000975F0
	public void ChangeMusic()
	{
		AudioListener.volume = this.masterVolumeScroller.GetComponent<UIScrollBar>().value;
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00099208 File Offset: 0x00097608
	public void UpdateFontsToChinese()
	{
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			if (this.frontPageContents[i].GetComponent<UILabel>())
			{
				this.frontPageContents[i].GetComponent<UILabel>().font = this.chineseFont;
			}
		}
		for (int j = 0; j < this.newGameTexts.Length; j++)
		{
			if (this.newGameTexts[j].GetComponent<UILabel>())
			{
				this.newGameTexts[j].GetComponent<UILabel>().font = this.chineseFont;
			}
		}
		for (int k = 0; k < this.exitGameTexts.Length; k++)
		{
			if (this.exitGameTexts[k].GetComponent<UILabel>())
			{
				this.exitGameTexts[k].GetComponent<UILabel>().font = this.chineseFont;
			}
		}
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x000992F0 File Offset: 0x000976F0
	public void UpdateFontsToNonEnglish()
	{
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			if (this.frontPageContents[i].GetComponent<UILabel>())
			{
				this.frontPageContents[i].GetComponent<UILabel>().font = this.nonEnglishFont;
			}
		}
		for (int j = 0; j < this.newGameTexts.Length; j++)
		{
			if (this.newGameTexts[j].GetComponent<UILabel>())
			{
				this.newGameTexts[j].GetComponent<UILabel>().font = this.nonEnglishFont;
			}
		}
		for (int k = 0; k < this.exitGameTexts.Length; k++)
		{
			if (this.exitGameTexts[k].GetComponent<UILabel>())
			{
				this.exitGameTexts[k].GetComponent<UILabel>().font = this.nonEnglishFont;
			}
		}
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x000993D8 File Offset: 0x000977D8
	public void LocaliseDropDowns()
	{
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN && this.aiTrafficDensityTextObj != null)
		{
			this.aiTrafficDensityTextObj.active = false;
		}
		if (languageCode == LanguageCode.FR)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[0];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[1];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[2];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[3];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[4];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[5];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[6];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[7];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[8];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[9];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[10];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[11];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[12];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[13];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[14];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[15];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[16];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[17];
		}
		else if (languageCode == LanguageCode.SV)
		{
			this.aiTrafficDensityTextObj = this.aiTrafficDensityLocalisedObj[18];
		}
		if (this.aiTrafficDensityTextObj != null)
		{
			this.aiTrafficDensityTextObj.active = true;
		}
		if (languageCode != LanguageCode.EN && this.vSyncTextObj != null)
		{
			this.vSyncTextObj.active = false;
		}
		if (languageCode == LanguageCode.FR)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[0];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[1];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[2];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[3];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[4];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[5];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[6];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[7];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[8];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[9];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[10];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[11];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[12];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[13];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[14];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[15];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[16];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[17];
		}
		else if (languageCode == LanguageCode.SV)
		{
			this.vSyncTextObj = this.vSyncLocalisedObj[18];
		}
		if (this.vSyncTextObj != null)
		{
			this.vSyncTextObj.active = true;
		}
		if (languageCode != LanguageCode.EN && this.fullScreenTextObj != null)
		{
			this.fullScreenTextObj.active = false;
		}
		if (languageCode == LanguageCode.FR)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[0];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[1];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[2];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[3];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[4];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[5];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[6];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[7];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[8];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[9];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[10];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[11];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[12];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[13];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[14];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[15];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[16];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[17];
		}
		else if (languageCode == LanguageCode.SV)
		{
			this.fullScreenTextObj = this.fullScreenLocalisedObj[18];
		}
		if (this.fullScreenTextObj != null)
		{
			this.fullScreenTextObj.active = true;
		}
		if (languageCode != LanguageCode.EN && this.qualityTextObj != null)
		{
			this.qualityTextObj.active = false;
		}
		if (languageCode == LanguageCode.FR)
		{
			this.qualityTextObj = this.qualityLocalisedObj[0];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.qualityTextObj = this.qualityLocalisedObj[1];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.qualityTextObj = this.qualityLocalisedObj[2];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.qualityTextObj = this.qualityLocalisedObj[3];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.qualityTextObj = this.qualityLocalisedObj[4];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.qualityTextObj = this.qualityLocalisedObj[5];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.qualityTextObj = this.qualityLocalisedObj[6];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.qualityTextObj = this.qualityLocalisedObj[7];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.qualityTextObj = this.qualityLocalisedObj[8];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.qualityTextObj = this.qualityLocalisedObj[9];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.qualityTextObj = this.qualityLocalisedObj[10];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.qualityTextObj = this.qualityLocalisedObj[11];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.qualityTextObj = this.qualityLocalisedObj[12];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.qualityTextObj = this.qualityLocalisedObj[13];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.qualityTextObj = this.qualityLocalisedObj[14];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.qualityTextObj = this.qualityLocalisedObj[15];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.qualityTextObj = this.qualityLocalisedObj[16];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.qualityTextObj = this.qualityLocalisedObj[17];
		}
		else if (languageCode == LanguageCode.SV)
		{
			this.qualityTextObj = this.qualityLocalisedObj[18];
		}
		if (this.qualityTextObj != null)
		{
			this.qualityTextObj.active = true;
		}
		if (languageCode != LanguageCode.EN && this.flickeringLightsTextObj != null)
		{
			this.flickeringLightsTextObj.active = false;
		}
		if (languageCode == LanguageCode.FR)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[0];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[1];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[2];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[3];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[4];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[5];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[6];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[7];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[8];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[9];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[10];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[11];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[12];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[13];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[14];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[15];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[16];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[17];
		}
		else if (languageCode == LanguageCode.SV)
		{
			this.flickeringLightsTextObj = this.flickeringLightsLocalisedObj[18];
		}
		if (this.flickeringLightsTextObj != null)
		{
			this.flickeringLightsTextObj.active = true;
		}
		if (languageCode != LanguageCode.EN && this.ssaoTextObj != null)
		{
			this.ssaoTextObj.active = false;
		}
		if (languageCode == LanguageCode.FR)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[0];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[1];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[2];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[3];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[4];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[5];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[6];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[7];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[8];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[9];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[10];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[11];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[12];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[13];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[14];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[15];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[16];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[17];
		}
		else if (languageCode == LanguageCode.SV)
		{
			this.ssaoTextObj = this.ssaoLocalisedObj[18];
		}
		if (this.ssaoTextObj != null)
		{
			this.ssaoTextObj.active = true;
		}
		this.mirrorTextObj.active = false;
		if (this.mirrorTextObj != null)
		{
			this.mirrorTextObj.active = true;
		}
		if (languageCode != LanguageCode.EN && this.aaTextObj != null)
		{
			this.aaTextObj.active = false;
		}
		if (languageCode == LanguageCode.FR)
		{
			this.aaTextObj = this.aaLocalisedObj[0];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.aaTextObj = this.aaLocalisedObj[1];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.aaTextObj = this.aaLocalisedObj[2];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.aaTextObj = this.aaLocalisedObj[3];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.aaTextObj = this.aaLocalisedObj[4];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.aaTextObj = this.aaLocalisedObj[5];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.aaTextObj = this.aaLocalisedObj[6];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.aaTextObj = this.aaLocalisedObj[7];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.aaTextObj = this.aaLocalisedObj[8];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.aaTextObj = this.aaLocalisedObj[9];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.aaTextObj = this.aaLocalisedObj[10];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.aaTextObj = this.aaLocalisedObj[11];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.aaTextObj = this.aaLocalisedObj[12];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.aaTextObj = this.aaLocalisedObj[13];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.aaTextObj = this.aaLocalisedObj[14];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.aaTextObj = this.aaLocalisedObj[15];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.aaTextObj = this.aaLocalisedObj[16];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.aaTextObj = this.aaLocalisedObj[17];
		}
		else if (languageCode == LanguageCode.SV)
		{
			this.aaTextObj = this.aaLocalisedObj[18];
		}
		if (this.aaTextObj != null)
		{
			this.aaTextObj.active = true;
		}
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x0009A4DE File Offset: 0x000988DE
	public void StartFade(float delay)
	{
		this.splashImage.DOColor(Color.clear, 0.3f).SetDelay(delay);
		this.loadingSprite.DOColor(Color.clear, 0.3f).SetDelay(delay);
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x0009A518 File Offset: 0x00098918
	private void Awake()
	{
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x0009A52C File Offset: 0x0009892C
	public void Start()
	{
		DOTween.KillAll(false);
		this.splashImage.DOColor(Color.clear, 0.7f);
		this.loadingSprite.DOColor(Color.clear, 0.7f);
		this.loadingSprite.transform.DORotate(Vector3.forward * 90f, 0.3f, RotateMode.Fast).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
		this.cameraObj.GetComponent<MenuMouseInteractionsC>().restrictRay = true;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.ZH || languageCode == LanguageCode.JA || languageCode == LanguageCode.KO)
		{
			this.UpdateFontsToChinese();
		}
		else if (languageCode != LanguageCode.EN)
		{
			this.UpdateFontsToNonEnglish();
		}
		this.CloseNoticeBoard();
		this.LocaliseDropDowns();
		this.noticeBoardTexts[1].GetComponent<UILabel>().text = Language.Get("ui_noticeboard_01", "Inspector_UI");
		this.noticeBoardTexts[2].GetComponent<UILabel>().text = Language.Get("fe_generic_01", "Inspector_UI");
		this.noticeBoardTexts[3].GetComponent<UILabel>().text = Language.Get("fe_mentitle_03", "Inspector_UI");
		this.noticeBoardTexts[4].GetComponent<UILabel>().text = Language.Get("fe_mentitle_04", "Inspector_UI");
		this.noticeBoardTexts[5].GetComponent<UILabel>().text = Language.Get("fe_mentitle_05", "Inspector_UI");
		this.noticeBoardTexts[6].GetComponent<UILabel>().text = Language.Get("fe_mentitle_07", "Inspector_UI");
		this.noticeBoardTexts[7].GetComponent<UILabel>().text = Language.Get("fe_mentitle_08", "Inspector_UI");
		this.noticeBoardTexts[8].GetComponent<UILabel>().text = Language.Get("fe_mentitle_06", "Inspector_UI");
		this.noticeBoardTexts[9].GetComponent<UILabel>().text = Language.Get("opt_game_02", "Inspector_UI");
		this.noticeBoardTexts[10].GetComponent<UILabel>().text = Language.Get("ui_pickup_01", "Inspector_UI");
		this.noticeBoardTexts[11].GetComponent<UILabel>().text = Language.Get("opt_audio_01", "Inspector_UI");
		this.noticeBoardTexts[12].GetComponent<UILabel>().text = Language.Get("ui_pickup_02", "Inspector_UI");
		this.noticeBoardTexts[13].GetComponent<UILabel>().text = Language.Get("ui_pickup_03", "Inspector_UI");
		this.noticeBoardTexts[14].GetComponent<UILabel>().text = Language.Get("opt_pause_02", "Inspector_UI");
		this.noticeBoardTexts[15].GetComponent<UILabel>().text = Language.Get("ui_pickup_04", "Inspector_UI");
		this.noticeBoardTexts[16].GetComponent<UILabel>().text = Language.Get("ui_pickup_05", "Inspector_UI");
		this.noticeBoardTexts[17].GetComponent<UILabel>().text = Language.Get("ui_pickup_06", "Inspector_UI");
		this.noticeBoardTexts[18].GetComponent<UILabel>().text = Language.Get("ui_pickup_07", "Inspector_UI");
		this.noticeBoardTexts[19].GetComponent<UILabel>().text = Language.Get("ui_pickup_08", "Inspector_UI");
		this.noticeBoardTexts[20].GetComponent<UILabel>().text = Language.Get("ui_pickup_09", "Inspector_UI");
		this.noticeBoardTexts[21].GetComponent<UILabel>().text = Language.Get("ui_pickup_10", "Inspector_UI");
		this.noticeBoardTexts[22].GetComponent<UILabel>().text = Language.Get("ui_pickup_11", "Inspector_UI");
		this.noticeBoardTexts[23].GetComponent<UILabel>().text = Language.Get("ui_pickup_12", "Inspector_UI");
		this.keyInputTexts[0].GetComponent<UILabel>().text = Language.Get("input_keys_01", "Inspector_UI");
		this.keyInputTexts[1].GetComponent<UILabel>().text = Language.Get("input_keys_02", "Inspector_UI");
		this.keyInputTexts[2].GetComponent<UILabel>().text = Language.Get("input_keys_03", "Inspector_UI");
		this.keyInputTexts[3].GetComponent<UILabel>().text = Language.Get("input_keys_04", "Inspector_UI");
		this.keyInputTexts[4].GetComponent<UILabel>().text = Language.Get("input_keys_05", "Inspector_UI");
		this.keyInputTexts[5].GetComponent<UILabel>().text = Language.Get("input_keys_06", "Inspector_UI");
		this.keyInputTexts[6].GetComponent<UILabel>().text = Language.Get("input_keys_07", "Inspector_UI");
		this.keyInputTexts[7].GetComponent<UILabel>().text = Language.Get("input_keys_08", "Inspector_UI");
		this.keyInputTexts[8].GetComponent<UILabel>().text = Language.Get("input_keys_09", "Inspector_UI");
		this.keyInputTexts[9].GetComponent<UILabel>().text = Language.Get("input_keys_10", "Inspector_UI");
		this.keyInputTexts[10].GetComponent<UILabel>().text = Language.Get("input_keys_11", "Inspector_UI");
		this.keyInputTexts[11].GetComponent<UILabel>().text = Language.Get("input_keys_12", "Inspector_UI");
		this.keyInputTexts[12].GetComponent<UILabel>().text = Language.Get("input_keys_13", "Inspector_UI");
		this.keyInputTexts[13].GetComponent<UILabel>().text = Language.Get("input_keys_14", "Inspector_UI");
		this.keyInputTexts[14].GetComponent<UILabel>().text = Language.Get("input_keys_15", "Inspector_UI");
		this.keyInputTexts[15].GetComponent<UILabel>().text = Language.Get("input_keys_16", "Inspector_UI");
		this.keyInputTexts[16].GetComponent<UILabel>().text = Language.Get("input_keys_17", "Inspector_UI");
		this.SelectBackDrops();
		this.SetTexts();
		this.SetLists();
		this.LoadGameplaySettings();
		this.LoadVideoSettings();
		this.LoadAudioSettings();
		this.LoadMoney();
		this.LoadPaint();
		this.LoadDoor();
		this.LoadKeyBindings();
		Screen.lockCursor = false;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.pos[1],
			"time",
			0.6,
			"easetype",
			this.easeType[1],
			"oncomplete",
			"DropAudio",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rot[0],
			"time",
			0.6,
			"easetype",
			this.easeType[0]
		}));
		Time.timeScale = 1f;
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x0009AC6C File Offset: 0x0009906C
	public void LoadDoor()
	{
		if (ES3.Exists("carDoorRepaired"))
		{
			bool flag = ES3.LoadBool("carDoorRepaired");
			if (flag)
			{
				this.carDoorMeshTransform.GetComponent<MeshFilter>().mesh = this.carDoorMeshData;
			}
		}
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x0009ACB0 File Offset: 0x000990B0
	public void SelectBackDrops()
	{
		if (ES3.Exists("routeLevel"))
		{
			int num = ES3.LoadInt("routeLevel");
			if (num == 1)
			{
				this.backDrops[0].active = false;
				this.backDrops[1].active = true;
			}
			else if (num == 2)
			{
				this.backDrops[0].active = false;
				this.backDrops[2].active = true;
			}
			else if (num == 3)
			{
				this.backDrops[0].active = false;
				this.backDrops[3].active = true;
			}
			else if (num == 4)
			{
				this.backDrops[0].active = false;
				this.backDrops[3].active = true;
			}
			else if (num == 5)
			{
				this.backDrops[0].active = false;
				this.backDrops[4].active = true;
			}
			else if (num == 6)
			{
				this.backDrops[0].active = false;
				this.backDrops[5].active = true;
			}
		}
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x0009ADC4 File Offset: 0x000991C4
	public void SetTexts()
	{
		this.headerUIs[0].GetComponent<UILabel>().text = Language.Get("opt_gen_03", "Inspector_UI");
		this.headerUIs[1].GetComponent<UILabel>().text = Language.Get("opt_gen_04", "Inspector_UI");
		this.headerUIs[2].GetComponent<UILabel>().text = Language.Get("opt_gen_05", "Inspector_UI");
		this.headerUIs[3].GetComponent<UILabel>().text = Language.Get("opt_gen_06", "Inspector_UI");
		this.headerUIs[4].GetComponent<UILabel>().text = Language.Get("opt_gen_07", "Inspector_UI");
		this.headerUIs[5].GetComponent<UILabel>().text = Language.Get("opt_gen_08", "Inspector_UI");
		this.headerUIs[6].GetComponent<UILabel>().text = Language.Get("opt_gen_09", "Inspector_UI");
		this.headerUIs[7].GetComponent<UILabel>().text = Language.Get("opt_gen_10", "Inspector_UI");
		for (int i = 0; i < this.saveUIs.Length; i++)
		{
			this.saveUIs[i].GetComponent<UILabel>().text = Language.Get("opt_gen_01", "Inspector_UI");
		}
		for (int j = 0; j < this.backUIs.Length; j++)
		{
			this.backUIs[j].GetComponent<UILabel>().text = Language.Get("opt_gen_02", "Inspector_UI");
		}
		for (int k = 0; k < this.acceptUIs.Length; k++)
		{
			this.acceptUIs[k].GetComponent<UILabel>().text = Language.Get("opt_gen_11", "Inspector_UI");
		}
		for (int l = 0; l < this.setDefaultUIs.Length; l++)
		{
			this.setDefaultUIs[l].GetComponent<UILabel>().text = Language.Get("opt_gen_12", "Inspector_UI");
		}
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x0009AFC4 File Offset: 0x000993C4
	public void SetLists()
	{
		int num = this.newMonitorIndex + 1;
		if (ES3.Exists("newMonitorIndex"))
		{
			PlayerPrefs.SetInt("UnitySelectMonitor", this.newMonitorIndex);
			this.screenMonitorTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_26", "Inspector_UI") + " " + num.ToString();
		}
		else
		{
			this.screenMonitorTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_26", "Inspector_UI") + " " + num.ToString();
		}
		if (ES3.Exists("resolutionX"))
		{
			this.resolutionX = ES3.LoadInt("resolutionX");
			this.resolutionY = ES3.LoadInt("resolutionY");
			if (this.resolutionX <= 640)
			{
				this.resolutionX = Screen.width;
				this.resolutionY = Screen.height;
			}
			this.screenResTextObj.GetComponent<UIPopupList>().items.Clear();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = resolutions.Length - 1; i > 0; i--)
			{
				string item = resolutions[i].ToString().Split(new char[]
				{
					'@'
				})[0];
				if (!this.screenResTextObj.GetComponent<UIPopupList>().items.Contains(resolutions[i].ToString().Split(new char[]
				{
					'@'
				})[0]))
				{
					this.screenResTextObj.GetComponent<UIPopupList>().items.Add(item);
				}
			}
			this.screenResTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_03", "Inspector_UI") + this.resolutionX.ToString() + " x " + this.resolutionY.ToString();
		}
		else
		{
			this.resolutionX = Screen.width;
			this.resolutionY = Screen.height;
			this.screenResTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_03", "Inspector_UI") + this.resolutionX.ToString() + " x " + this.resolutionY.ToString();
		}
		if (Screen.fullScreen)
		{
			this.fullScreenTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_04", "Inspector_UI");
		}
		else
		{
			this.fullScreenTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_05", "Inspector_UI");
		}
		this.fullScreenTextObj.GetComponent<UIPopupList>().items.Clear();
		this.fullScreenTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_04", "Inspector_UI"));
		this.fullScreenTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_05", "Inspector_UI"));
		if (ES3.Exists("vSyncState"))
		{
			this.vSyncState = ES3.LoadInt("vSyncState");
			if (this.vSyncState == 0)
			{
				QualitySettings.vSyncCount = 0;
				Application.targetFrameRate = 120;
				this.vSyncTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_08", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			}
			else if (this.vSyncState == 1)
			{
				QualitySettings.vSyncCount = 1;
				Application.targetFrameRate = 120;
				this.vSyncTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_08", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			}
			else
			{
				this.vSyncTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_08", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
				this.vSyncState = 0;
				QualitySettings.vSyncCount = 0;
				Application.targetFrameRate = 120;
			}
		}
		else
		{
			this.vSyncTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_08", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			this.vSyncState = 0;
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 120;
		}
		this.vSyncTextObj.GetComponent<UIPopupList>().items.Clear();
		this.vSyncTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_06", "Inspector_UI"));
		this.vSyncTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_07", "Inspector_UI"));
		if (ES3.Exists("preventFlickeringLights"))
		{
			this.preventFlickeringLights = ES3.LoadBool("preventFlickeringLights");
			if (!this.preventFlickeringLights)
			{
				this.flickeringLightsTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_17", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			}
			else if (this.preventFlickeringLights)
			{
				this.flickeringLightsTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_17", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			}
		}
		else
		{
			this.flickeringLightsTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_17", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			this.preventFlickeringLights = false;
		}
		if (ES3.Exists("aiCount"))
		{
			this.aiTrafficDensitySetting = ES3.LoadInt("aiCount");
			if (this.aiTrafficDensitySetting == 4)
			{
				this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_18", "Inspector_UI");
			}
			else if (this.aiTrafficDensitySetting == 3)
			{
				this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_11", "Inspector_UI");
			}
			else if (this.aiTrafficDensitySetting == 2)
			{
				this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_12", "Inspector_UI");
			}
			else if (this.aiTrafficDensitySetting == 1)
			{
				this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_13", "Inspector_UI");
			}
			else if (this.aiTrafficDensitySetting == 0)
			{
				this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			}
		}
		else
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_18", "Inspector_UI");
			this.aiTrafficDensitySetting = 2;
		}
		if (ES3.Exists("ssaoSetting"))
		{
			this.ssaoSetting = ES3.LoadBool("ssaoSetting");
		}
		else
		{
			this.ssaoSetting = true;
		}
		this.UpdateSSAO();
		if (ES3.Exists("aaSetting"))
		{
			this.aaSetting = ES3.LoadBool("aaSetting");
		}
		else
		{
			this.aaSetting = true;
		}
		this.UpdateAA();
		if (ES3.Exists("mirrorEnabled"))
		{
			this.mirrorEnabled = ES3.LoadBool("mirrorEnabled");
		}
		else
		{
			this.mirrorEnabled = false;
		}
		this.mirrorState = ES3.LoadInt("mirrorState");
		MirrorReflection.qualityValue = this.mirrorState;
		this.UpdateMirrorSettings();
		if (ES3.Exists("qualityState"))
		{
			this.qualityState = ES3.LoadInt("qualityState");
			if (this.qualityState == 0)
			{
				this.qualityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_16", "Inspector_UI") + Language.Get("opt_video_15", "Inspector_UI");
				QualitySettings.SetQualityLevel(5);
			}
			else if (this.qualityState == 1)
			{
				this.qualityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_16", "Inspector_UI") + Language.Get("opt_video_11", "Inspector_UI");
				QualitySettings.SetQualityLevel(4);
			}
			else if (this.qualityState == 2)
			{
				this.qualityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_16", "Inspector_UI") + Language.Get("opt_video_12", "Inspector_UI");
				QualitySettings.SetQualityLevel(2);
			}
			else if (this.qualityState == 3)
			{
				this.qualityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_16", "Inspector_UI") + Language.Get("opt_video_13", "Inspector_UI");
				QualitySettings.SetQualityLevel(1);
			}
			else if (this.qualityState == 4)
			{
				this.qualityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_16", "Inspector_UI") + Language.Get("opt_video_14", "Inspector_UI");
				QualitySettings.SetQualityLevel(0);
			}
		}
		else
		{
			this.qualityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_16", "Inspector_UI") + Language.Get("opt_video_15", "Inspector_UI");
			QualitySettings.SetQualityLevel(5);
			this.qualityState = 0;
		}
		this.qualityTextObj.GetComponent<UIPopupList>().items.Clear();
		this.qualityTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_15", "Inspector_UI"));
		this.qualityTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_11", "Inspector_UI"));
		this.qualityTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_12", "Inspector_UI"));
		this.qualityTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_13", "Inspector_UI"));
		this.qualityTextObj.GetComponent<UIPopupList>().items.Add(Language.Get("opt_video_14", "Inspector_UI"));
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x0009BA48 File Offset: 0x00099E48
	public void LoadGameplaySettings()
	{
		if (ES3.Exists("lookInvert"))
		{
			this.lookInvert = ES3.LoadBool("lookInvert");
		}
		if (ES3.Exists("mouseSensitivity"))
		{
			this.mouseSensitivity = ES3.LoadFloat("mouseSensitivity");
		}
		if (ES3.Exists("padInput2"))
		{
			this.padInput = ES3.LoadInt("padInput2");
			if (this.padInput == 1)
			{
				this._camera.SendMessage("PadInputOn");
			}
			else
			{
				this._camera.SendMessage("PadInputOff");
			}
		}
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x0009BAE4 File Offset: 0x00099EE4
	public void LoadVideoSettings()
	{
		if (ES3.Exists("mirrorEnabled"))
		{
			this.mirrorEnabled = ES3.LoadBool("mirrorEnabled");
		}
		this.mirrorState = ES3.LoadInt("mirrorState");
		MirrorReflection.qualityValue = this.mirrorState;
		if (ES3.Exists("fov"))
		{
			this.fov = ES3.LoadFloat("fov");
		}
		if (ES3.Exists("resolutionX"))
		{
			this.resolutionX = ES3.LoadInt("resolutionX");
			this.resolutionY = ES3.LoadInt("resolutionY");
			this.screenResTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_03", "Inspector_UI") + this.resolutionX.ToString() + " x " + this.resolutionY.ToString();
		}
		else
		{
			this.resolutionX = 1920;
			this.resolutionY = 1080;
			this.screenResTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_03", "Inspector_UI") + this.resolutionX.ToString() + " x " + this.resolutionY.ToString();
		}
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x0009BC2C File Offset: 0x0009A02C
	public void LoadAudioSettings()
	{
		if (ES3.Exists("masterVolume"))
		{
			this.masterVolume = ES3.LoadFloat("masterVolume");
			AudioListener.volume = this.masterVolume;
		}
		else
		{
			AudioListener.volume = 1f;
		}
		if (ES3.Exists("effectsVolume"))
		{
			this.effectsVolume = ES3.LoadFloat("effectsVolume");
		}
		if (ES3.Exists("musicVolume"))
		{
			this.musicVolume = ES3.LoadFloat("musicVolume");
		}
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x0009BCB0 File Offset: 0x0009A0B0
	public void LoadMoney()
	{
		int num = 0;
		if (ES3.Exists("moneyAmount"))
		{
			num = Mathf.RoundToInt(ES3.LoadFloat("moneyAmount"));
		}
		if (num <= 0)
		{
			num = 100;
		}
		this.walletNumber.GetComponent<TextMesh>().text = Mathf.Round((float)num).ToString();
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x0009BD10 File Offset: 0x0009A110
	public void LoadPaint()
	{
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		if (ES3.LoadColor("customPaintBonnet") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().bonnetObj.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintBonnet");
		}
		if (ES3.LoadColor("customMetallicPaintBonnet") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().bonnetObj.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintBonnet"));
		}
		if (ES3.LoadColor("customPaintFrame") != Color.white)
		{
			for (int i = 0; i < gameObject.GetComponent<PaintCanRelayC>().targets.Length; i++)
			{
				gameObject.GetComponent<PaintCanRelayC>().targets[i].GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintFrame");
			}
		}
		if (ES3.LoadColor("customMetallicPaintFrame") != Color.white)
		{
			for (int j = 0; j < gameObject.GetComponent<PaintCanRelayC>().targets.Length; j++)
			{
				gameObject.GetComponent<PaintCanRelayC>().targets[j].GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintFrame"));
			}
		}
		if (ES3.LoadColor("customPaintIntFloor") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().carInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
			gameObject.GetComponent<CarLogicC>().lDoorInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
			gameObject.GetComponent<CarLogicC>().rDoorInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
			gameObject.GetComponent<CarLogicC>().trunkInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
		}
		if (ES3.LoadColor("customMetallicPaintIntFloor") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().carInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
			gameObject.GetComponent<CarLogicC>().lDoorInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
			gameObject.GetComponent<CarLogicC>().rDoorInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
			gameObject.GetComponent<CarLogicC>().trunkInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
		}
		if (ES3.LoadColor("customPaintLDoor") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().leftDoor.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintLDoor");
		}
		if (ES3.LoadColor("customMetallicPaintLDoor") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().leftDoor.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintLDoor"));
		}
		if (ES3.LoadColor("customPaintRDoor") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().rightDoor.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintRDoor");
		}
		if (ES3.LoadColor("customMetallicPaintRDoor") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().rightDoor.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintRDoor"));
		}
		if (ES3.LoadColor("customPaintLHLight") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().lHLight.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintLHLight");
		}
		if (ES3.LoadColor("customMetallicPaintLHLight") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().lHLight.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintLHLight"));
		}
		if (ES3.LoadColor("customPaintRHLight") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().rHLight.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintRHLight");
		}
		if (ES3.LoadColor("customMetallicPaintRHLight") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().rHLight.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintRHLight"));
		}
		if (ES3.LoadColor("customPaintRoof") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().roof.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintRoof");
		}
		if (ES3.LoadColor("customMetallicPaintRoof") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().roof.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintRoof"));
		}
		if (ES3.LoadColor("customPaintTrunk") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().bootLid.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintTrunk");
		}
		if (ES3.LoadColor("customPaintTrunk") != Color.white)
		{
			gameObject.GetComponent<CarLogicC>().bootLid.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintTrunk"));
		}
		if (ES3.Exists("customDecal"))
		{
			Color decalColour = ES3.LoadColor("customDecalColor");
			int num = ES3.LoadInt("customDecal");
			if (num == 0)
			{
				gameObject.GetComponent<ExtraUpgradesC>().decalColour = new Color(0f, 0f, 0f, 0f);
			}
			else
			{
				gameObject.GetComponent<ExtraUpgradesC>().decalColour = decalColour;
			}
			gameObject.GetComponent<ExtraUpgradesC>().NewDecal(this.decalMatCatalogue[num]);
		}
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x0009C38C File Offset: 0x0009A78C
	public void TweenCameraBlurUp()
	{
		iTween.ValueTo(base.gameObject, iTween.Hash(new object[]
		{
			"from",
			0.2,
			"to",
			1.5,
			"time",
			0.6,
			"onupdatetarget",
			base.gameObject,
			"onupdate",
			"tweenOnUpdateCallBack",
			"easetype",
			iTween.EaseType.easeOutQuad
		}));
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x0009C430 File Offset: 0x0009A830
	public void TweenCameraBlurDown()
	{
		iTween.ValueTo(base.gameObject, iTween.Hash(new object[]
		{
			"from",
			1.5,
			"to",
			0.2,
			"time",
			0.6,
			"onupdatetarget",
			base.gameObject,
			"onupdate",
			"tweenOnUpdateCallBack",
			"easetype",
			iTween.EaseType.easeOutQuad
		}));
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x0009C4D4 File Offset: 0x0009A8D4
	public void tweenOnUpdateCallBack(float newValue)
	{
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x0009C4D8 File Offset: 0x0009A8D8
	public void DropAudio()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.bookDropAudio, 1f);
		for (int i = 0; i < this.dustParticles.Length; i++)
		{
			this.dustParticles[i].GetComponent<ParticleSystem>().Play();
		}
		this.CloseBookFirstDrop();
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x0009C52C File Offset: 0x0009A92C
	public void CloseBookFirstDrop()
	{
		this.bookClosed = true;
		this.TweenCameraBlurDown();
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			this.frontPageContents[i].active = false;
		}
		for (int j = 0; j < this.newGameTexts.Length; j++)
		{
			this.newGameTexts[j].active = false;
		}
		for (int k = 0; k < this.exitGameTexts.Length; k++)
		{
			this.exitGameTexts[k].active = false;
		}
		this.animBook.GetComponent<Animator>().SetBool("isBookOpen", false);
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackHover", false);
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackGo", false);
		this.animBook.GetComponent<Animator>().SetBool("page1FoldGo", false);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.pos[1],
			"time",
			0.3,
			"easetype",
			this.easeType[1]
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rot[0],
			"delay",
			0.1,
			"time",
			0.2,
			"easetype",
			this.easeType[0]
		}));
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x0009C6F2 File Offset: 0x0009AAF2
	public void TurnPageAudio()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.turnPageAudio, 1f);
	}

	// Token: 0x06000770 RID: 1904 RVA: 0x0009C70A File Offset: 0x0009AB0A
	private void OnDestroy()
	{
		ES3.SaveFiles();
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x0009C714 File Offset: 0x0009AB14
	public void Update()
	{
		if (Input.GetKeyDown("mouse 1") && !this.bookClosed)
		{
			this.CloseBook();
		}
		else if (Input.GetButtonDown("Cancel") && !this.bookClosed)
		{
			this.CloseBook();
		}
		else if (Input.GetKeyDown("escape") && !this.bookClosed)
		{
			this.CloseBook();
		}
		if (this.changeInputID != 0)
		{
			this.CheckForKeyboardInputChange();
		}
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.renderTarget.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000772 RID: 1906 RVA: 0x0009C7D8 File Offset: 0x0009ABD8
	public void CloseBook()
	{
		if (this.bookClosed)
		{
			this.CloseNoticeBoard();
			return;
		}
		this.bookClosed = true;
		this.TweenCameraBlurDown();
		base.GetComponent<AudioSource>().PlayOneShot(this.bookCloseAudio, 1f);
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			this.frontPageContents[i].active = false;
		}
		for (int j = 0; j < this.newGameTexts.Length; j++)
		{
			this.newGameTexts[j].active = false;
		}
		for (int k = 0; k < this.exitGameTexts.Length; k++)
		{
			this.exitGameTexts[k].active = false;
		}
		this.animBook.GetComponent<Animator>().SetBool("isBookOpen", false);
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackHover", false);
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackGo", false);
		this.animBook.GetComponent<Animator>().SetBool("page1FoldGo", false);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.pos[1],
			"time",
			0.3,
			"easetype",
			this.easeType[1],
			"oncomplete",
			"EnableCollider",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rot[0],
			"delay",
			0.1,
			"time",
			0.2,
			"easetype",
			this.easeType[0]
		}));
	}

	// Token: 0x06000773 RID: 1907 RVA: 0x0009C9EC File Offset: 0x0009ADEC
	public void CloseBookNoParticle()
	{
		this.bookClosed = true;
		this.TweenCameraBlurDown();
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			this.frontPageContents[i].active = false;
		}
		for (int j = 0; j < this.newGameTexts.Length; j++)
		{
			this.newGameTexts[j].active = false;
		}
		for (int k = 0; k < this.exitGameTexts.Length; k++)
		{
			this.exitGameTexts[k].active = false;
		}
		this.animBook.GetComponent<Animator>().SetBool("isBookOpen", false);
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackHover", false);
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackGo", false);
		this.animBook.GetComponent<Animator>().SetBool("page1FoldGo", false);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.pos[1],
			"time",
			0.3,
			"easetype",
			this.easeType[1],
			"oncomplete",
			"EnableColliderNoParticle",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rot[0],
			"delay",
			0.1,
			"time",
			0.2,
			"easetype",
			this.easeType[0]
		}));
	}

	// Token: 0x06000774 RID: 1908 RVA: 0x0009CBD5 File Offset: 0x0009AFD5
	public void EnableCollider()
	{
		this.DropAudio();
		base.GetComponent<Collider>().enabled = true;
		this.cameraObj.SendMessage("ExitMenu");
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x0009CBF9 File Offset: 0x0009AFF9
	public void EnableColliderNoParticle()
	{
		base.GetComponent<Collider>().enabled = true;
		this.cameraObj.SendMessage("ExitMenu");
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x0009CC17 File Offset: 0x0009B017
	public void Action()
	{
		if (this.bookClosed)
		{
			this.Rotate();
			base.GetComponent<AudioSource>().PlayOneShot(this.pickupAudio, 1f);
			this.TweenCameraBlurUp();
		}
	}

	// Token: 0x06000777 RID: 1911 RVA: 0x0009CC48 File Offset: 0x0009B048
	public void Rotate()
	{
		base.GetComponent<Collider>().enabled = false;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.pos[0],
			"time",
			0.3,
			"easetype",
			this.easeType[1]
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rot[1],
			"delay",
			0.1,
			"time",
			0.2,
			"easetype",
			"easeinoutback",
			"oncomplete",
			"Open",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000778 RID: 1912 RVA: 0x0009CD64 File Offset: 0x0009B164
	private IEnumerator Open()
	{
		this.animBook.GetComponent<Animator>().SetBool("isBookOpen", true);
		base.GetComponent<AudioSource>().PlayOneShot(this.bookOpenAudio, 1f);
		yield return new WaitForSeconds(0.25f);
		base.GetComponent<AudioSource>().PlayOneShot(this.bookManyPagesAudio, 1f);
		yield return new WaitForSeconds(0.2f);
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			this.frontPageContents[i].active = true;
		}
		this.bookClosed = false;
		yield break;
	}

	// Token: 0x06000779 RID: 1913 RVA: 0x0009CD80 File Offset: 0x0009B180
	private IEnumerator NewGameStopper()
	{
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			this.frontPageContents[i].active = false;
		}
		this.newGameSelected = true;
		yield return new WaitForSeconds(0.05f);
		this.animBook.GetComponent<Animator>().SetBool("page1FoldGo", false);
		yield break;
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x0009CD9C File Offset: 0x0009B19C
	private IEnumerator NewGameConfirmer()
	{
		yield return new WaitForSeconds(0.04f);
		for (int i = 0; i < this.newGameTexts.Length; i++)
		{
			this.newGameTexts[i].active = true;
		}
		yield break;
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x0009CDB8 File Offset: 0x0009B1B8
	private IEnumerator NewGameMenuStopper()
	{
		for (int i = 0; i < this.newGameTexts.Length; i++)
		{
			this.newGameTexts[i].active = false;
		}
		yield return new WaitForSeconds(0.05f);
		this.animBook.GetComponent<Animator>().SetBool("page1FoldGo", false);
		yield break;
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x0009CDD4 File Offset: 0x0009B1D4
	private IEnumerator ExitGameConfirmer()
	{
		yield return new WaitForSeconds(0.04f);
		for (int i = 0; i < this.exitGameTexts.Length; i++)
		{
			this.exitGameTexts[i].active = true;
		}
		yield break;
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x0009CDF0 File Offset: 0x0009B1F0
	private IEnumerator ExitPageStopper()
	{
		for (int i = 0; i < this.exitGameTexts.Length; i++)
		{
			this.exitGameTexts[i].active = false;
		}
		yield return new WaitForSeconds(0.05f);
		this.animBook.GetComponent<Animator>().SetBool("page1FoldGo", false);
		yield break;
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x0009CE0C File Offset: 0x0009B20C
	private IEnumerator ReturnToFrontPage()
	{
		this.animBook.GetComponent<Animator>().SetBool("page1FoldGo", false);
		yield return new WaitForSeconds(0.04f);
		for (int i = 0; i < this.frontPageContents.Length; i++)
		{
			this.frontPageContents[i].active = true;
		}
		this.newGameSelected = false;
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackHover", false);
		this.animBook.GetComponent<Animator>().SetBool("page2FoldBackGo", false);
		yield break;
	}

	// Token: 0x0600077F RID: 1919 RVA: 0x0009CE27 File Offset: 0x0009B227
	public void TurnToNewGame()
	{
	}

	// Token: 0x06000780 RID: 1920 RVA: 0x0009CE29 File Offset: 0x0009B229
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.renderTarget.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x0009CE48 File Offset: 0x0009B248
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.renderTarget.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x0009CE68 File Offset: 0x0009B268
	public void CloseEyes()
	{
		this.StartFade(0f);
		this.cameraObj.GetComponent<MenuMouseInteractionsC>().restrictRay = true;
		this.CloseBook();
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			178.9124,
			"time",
			0.6,
			"delay",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-181.0876,
			"time",
			0.6,
			"delay",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeoutbounce",
			"oncomplete",
			"LoadNewGame",
			"oncompletetarget",
			base.gameObject
		}));
		if (ES3.Exists("uncleTutorialCompleted"))
		{
			return;
		}
		this.carDoor.GetComponent<Rigidbody>().isKinematic = false;
		this.carDoor.GetComponent<Rigidbody>().useGravity = true;
		this.carDoor.GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x0009D006 File Offset: 0x0009B406
	public void LoadNewGame()
	{
		Application.LoadLevel(2);
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x0009D010 File Offset: 0x0009B410
	public void OpenOptions()
	{
		for (int i = 0; i < this.optionsBackdrops.Length; i++)
		{
			this.optionsBackdrops[i].active = true;
		}
		for (int j = 0; j < this.optionsMenuMain.Length; j++)
		{
			this.optionsMenuMain[j].active = true;
		}
		this.cameraObj.GetComponent<MenuMouseInteractionsC>().restrictRay = true;
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x0009D07C File Offset: 0x0009B47C
	public void ChangeOptionsPage()
	{
	}

	// Token: 0x06000786 RID: 1926 RVA: 0x0009D080 File Offset: 0x0009B480
	public void OpenOptionsGameplay()
	{
		for (int i = 0; i < this.optionsMenuMain.Length; i++)
		{
			this.optionsMenuMain[i].active = false;
		}
		for (int j = 0; j < this.optionsMenuGameplay.Length; j++)
		{
			this.optionsMenuGameplay[j].active = true;
		}
		this.SetGameplayValues();
	}

	// Token: 0x06000787 RID: 1927 RVA: 0x0009D0E4 File Offset: 0x0009B4E4
	public void OpenOptionsKeyInput()
	{
		for (int i = 0; i < this.optionsMenuGameplay.Length; i++)
		{
			this.optionsMenuGameplay[i].active = false;
		}
		this.optionsKeyInputs.active = true;
		for (int j = 0; j < this.keyboardInputAssigned.Length; j++)
		{
			this.keyboardInputAssignedPrev[j] = this.keyboardInputAssigned[j];
		}
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x0009D150 File Offset: 0x0009B550
	public void OpenOptionsVideo()
	{
		for (int i = 0; i < this.optionsMenuMain.Length; i++)
		{
			this.optionsMenuMain[i].active = false;
		}
		for (int j = 0; j < this.optionsMenuVideo.Length; j++)
		{
			this.optionsMenuVideo[j].active = true;
		}
		this.SetLists();
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x0009D1B4 File Offset: 0x0009B5B4
	public void OpenOptionsCredits()
	{
		for (int i = 0; i < this.optionsMenuMain.Length; i++)
		{
			this.optionsMenuMain[i].active = false;
		}
		for (int j = 0; j < this.optionsMenuCredits.Length; j++)
		{
			this.optionsMenuCredits[j].active = true;
		}
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x0009D210 File Offset: 0x0009B610
	public void OpenOptionsAudio()
	{
		for (int i = 0; i < this.optionsMenuMain.Length; i++)
		{
			this.optionsMenuMain[i].active = false;
		}
		for (int j = 0; j < this.optionsMenuAudio.Length; j++)
		{
			this.optionsMenuAudio[j].active = true;
		}
		this.SetAudioValues();
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x0009D274 File Offset: 0x0009B674
	public void CloseOptionsGameplay()
	{
		for (int i = 0; i < this.optionsMenuGameplay.Length; i++)
		{
			this.optionsMenuGameplay[i].active = false;
		}
		this.SetGameplayValues();
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x0009D2AE File Offset: 0x0009B6AE
	public void CloseOptionsInputBack()
	{
		this.optionsKeyInputs.active = false;
		this.ResetKeyBindingsToPrevSetting();
		this.OpenOptionsGameplay();
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x0009D2C8 File Offset: 0x0009B6C8
	public void CloseOptionsInputAccept()
	{
		this.optionsKeyInputs.active = false;
		this.SaveKeyBindings();
		this.OpenOptionsGameplay();
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x0009D2E4 File Offset: 0x0009B6E4
	public void CloseNoticeBoard()
	{
		for (int i = 0; i < this.optionsMenuGameplay.Length; i++)
		{
			this.optionsMenuNoticeboard[i].active = false;
		}
		this.cameraObj.GetComponent<MenuMouseInteractionsC>().restrictRay = false;
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x0009D32C File Offset: 0x0009B72C
	public void SaveOptionsGameplay()
	{
		for (int i = 0; i < this.optionsMenuGameplay.Length; i++)
		{
			this.optionsMenuGameplay[i].active = false;
		}
		this.SaveGameplayValues();
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x0009D368 File Offset: 0x0009B768
	public void SaveGameplayValues()
	{
		if (this.lookInvertObj.GetComponent<UILabel>().text == Language.Get("opt_game_01", "Inspector_UI"))
		{
			this.lookInvert = false;
		}
		else
		{
			this.lookInvert = true;
		}
		ES3.Save(this.lookInvert, "lookInvert");
		this.mouseSmooth = false;
		ES3.Save(this.mouseSmooth, "mouseSmooth");
		if (this.padInputObj.GetComponent<UILabel>().text == Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_07", "Inspector_UI"))
		{
			this.padInput = 0;
			this._camera.SendMessage("PadInputOff");
		}
		else if (this.padInputObj.GetComponent<UILabel>().text == Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_08", "Inspector_UI"))
		{
			this.padInput = 1;
			this._camera.SendMessage("PadInputOn");
		}
		else if (this.padInputObj.GetComponent<UILabel>().text == Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_09", "Inspector_UI"))
		{
			this.padInput = 2;
			this._camera.SendMessage("PadInputOffWheel");
		}
		else if (this.padInputObj.GetComponent<UILabel>().text == Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_10", "Inspector_UI"))
		{
			this.padInput = 3;
		}
		ES3.Save(this.padInput, "padInput");
		this.mouseSensitivity = this.mouseSensitivityObj.GetComponent<UIScrollBar>().value;
		ES3.Save(this.mouseSensitivity, "mouseSensitivity");
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			XboxController.SaveData();
		}
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x0009D570 File Offset: 0x0009B970
	public void SetGameplayValues()
	{
		this.lookInvertTemp = this.lookInvert;
		if (!this.lookInvert)
		{
			this.lookInvertObj.GetComponent<UILabel>().text = Language.Get("opt_game_01", "Inspector_UI");
		}
		else
		{
			this.lookInvertObj.GetComponent<UILabel>().text = Language.Get("opt_game_01_b", "Inspector_UI");
		}
		this.mouseSmoothTemp = this.mouseSmooth;
		ES3.Save(this.aiTrafficDensitySetting, "aiCount");
		this.mouseSensitivityObj.GetComponent<UIScrollBar>().value = this.mouseSensitivity;
		this.padInputTemp = this.padInput;
		if (this.padInput == 0)
		{
			this.padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_07", "Inspector_UI");
		}
		else if (this.padInput == 1)
		{
			this.padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_08", "Inspector_UI");
		}
		else if (this.padInput == 2)
		{
			this.padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_09", "Inspector_UI");
		}
		else if (this.padInput == 3)
		{
			this.padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_10", "Inspector_UI");
		}
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x0009D720 File Offset: 0x0009BB20
	public void SaveOptionsVideo()
	{
		for (int i = 0; i < this.optionsMenuVideo.Length; i++)
		{
			this.optionsMenuVideo[i].active = false;
		}
		this.SaveVideoValues();
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x0009D75C File Offset: 0x0009BB5C
	public void SaveVideoValues()
	{
		ES3.Save(this.resolutionX, "resolutionX");
		ES3.Save(this.resolutionY, "resolutionY");
		ES3.Save(this.fullScreenState, "fullScreenState");
		ES3.Save(this.newMonitorIndex, "newMonitorIndex");
		PlayerPrefs.SetInt("UnitySelectMonitor", this.newMonitorIndex);
		Screen.SetResolution(this.resolutionX, this.resolutionY, this.fullScreenState);
		ES3.Save(this.vSyncState, "vSyncState");
		QualitySettings.vSyncCount = this.vSyncState;
		ES3.Save(this.preventFlickeringLights, "preventFlickeringLights");
		ES3.Save(this.ssaoSetting, "ssaoSetting");
		ES3.Save(this.aaSetting, "aaSetting");
		ES3.Save(this.mirrorEnabled, "mirrorEnabled");
		ES3.Save(this.mirrorState, "mirrorState");
		ES3.Save(this.qualityState, "qualityState");
		if (this.qualityState == 0)
		{
			QualitySettings.SetQualityLevel(5);
		}
		else if (this.qualityState == 1)
		{
			QualitySettings.SetQualityLevel(4);
		}
		else if (this.qualityState == 2)
		{
			QualitySettings.SetQualityLevel(2);
		}
		else if (this.qualityState == 3)
		{
			QualitySettings.SetQualityLevel(1);
		}
		else if (this.qualityState == 4)
		{
			QualitySettings.SetQualityLevel(0);
		}
		this.fov = this.fovSliderObj.GetComponent<UIScrollBar>().value;
		ES3.Save(this.fov, "fov");
		this.SetFOVText();
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x0009D8E4 File Offset: 0x0009BCE4
	public void SaveOptionsAudio()
	{
		for (int i = 0; i < this.optionsMenuAudio.Length; i++)
		{
			this.optionsMenuAudio[i].active = false;
		}
		this.SaveAudioValues();
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x0009D920 File Offset: 0x0009BD20
	public void SaveAudioValues()
	{
		this.masterVolume = this.masterVolumeScroller.GetComponent<UIScrollBar>().value;
		ES3.Save(this.masterVolume, "masterVolume");
		AudioListener.volume = this.masterVolume;
		this.effectsVolume = this.effectsVolumeScroller.GetComponent<UIScrollBar>().value;
		ES3.Save(this.effectsVolume, "effectsVolume");
		this.musicVolume = this.musicVolumeScroller.GetComponent<UIScrollBar>().value;
		ES3.Save(this.musicVolume, "musicVolume");
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x0009D9AC File Offset: 0x0009BDAC
	public void SetFOVText()
	{
		if ((double)this.fov == 0.0)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 80";
		}
		else if ((double)this.fov == 0.25)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 85";
		}
		else if ((double)this.fov == 0.5)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 90";
		}
		else if ((double)this.fov == 0.75)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 95";
		}
		else if ((double)this.fov == 1.0)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 100";
		}
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x0009DB04 File Offset: 0x0009BF04
	public void ChangeGamma()
	{
		if ((double)UIProgressBar.current.value == 0.0)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_09", "Inspector_UI") + " -4";
		}
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x0009DB54 File Offset: 0x0009BF54
	public void ChangeQuality()
	{
		this.qualityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_16", "Inspector_UI") + UIPopupList.current.value.ToString();
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_15", "Inspector_UI"))
		{
			this.qualityState = 0;
			this.aiTrafficDensitySetting = 2;
			this.ssaoSetting = true;
			this.aaSetting = true;
			this.mirrorEnabled = true;
			this.mirrorState = 4;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_11", "Inspector_UI"))
		{
			this.qualityState = 1;
			this.aiTrafficDensitySetting = 2;
			this.ssaoSetting = true;
			this.aaSetting = true;
			this.mirrorEnabled = true;
			this.mirrorState = 2;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_12", "Inspector_UI"))
		{
			this.qualityState = 2;
			this.aiTrafficDensitySetting = 2;
			this.ssaoSetting = true;
			this.aaSetting = false;
			this.mirrorEnabled = false;
			this.mirrorState = 0;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_13", "Inspector_UI"))
		{
			this.qualityState = 3;
			this.aiTrafficDensitySetting = 1;
			this.ssaoSetting = false;
			this.aaSetting = false;
			this.mirrorEnabled = false;
			this.mirrorState = 0;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_14", "Inspector_UI"))
		{
			this.qualityState = 4;
			this.aiTrafficDensitySetting = 0;
			this.ssaoSetting = false;
			this.aaSetting = false;
			this.mirrorEnabled = false;
			this.mirrorState = 0;
		}
		this.UpdateAITrafficDensity();
		this.UpdateSSAO();
		this.UpdateAA();
		this.UpdateMirrorSettings();
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x0009DD5C File Offset: 0x0009C15C
	public void ChangeShadows()
	{
		this.shadowTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_10", "Inspector_UI") + UIPopupList.current.value.ToString();
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_11", "Inspector_UI"))
		{
			this.shadowQualityState = 0;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_12", "Inspector_UI"))
		{
			this.shadowQualityState = 1;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_13", "Inspector_UI"))
		{
			this.shadowQualityState = 2;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_07", "Inspector_UI"))
		{
			this.shadowQualityState = 3;
		}
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x0009DE68 File Offset: 0x0009C268
	public void ChangeFOVSensitivity()
	{
		float value = UIProgressBar.current.value;
		if ((double)value == 0.0)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " 80";
		}
		else if ((double)value == 0.25)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 85";
		}
		else if ((double)value == 0.5)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 90";
		}
		else if ((double)value == 0.75)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 95";
		}
		else if ((double)value == 1.0)
		{
			this.fovTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_02", "Inspector_UI") + " : 100";
		}
	}

	// Token: 0x0600079B RID: 1947 RVA: 0x0009DFB4 File Offset: 0x0009C3B4
	public void ChangeFullScreen()
	{
		string value = UIPopupList.current.value;
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_04", "Inspector_UI"))
		{
			this.fullScreenTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_04", "Inspector_UI");
			this.fullScreenState = true;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_05", "Inspector_UI"))
		{
			this.fullScreenTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_05", "Inspector_UI");
			this.fullScreenState = false;
		}
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x0009E070 File Offset: 0x0009C470
	public void ChangeResolution()
	{
		string value = UIPopupList.current.value;
		this.screenResTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_03", "Inspector_UI") + UIPopupList.current.value.ToString();
		int.TryParse(UIPopupList.current.value.ToString().Split(new char[]
		{
			'x'
		})[0], out this.resolutionX);
		int.TryParse(UIPopupList.current.value.ToString().Split(new char[]
		{
			'x'
		})[1], out this.resolutionY);
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x0009E118 File Offset: 0x0009C518
	public void ChangeMonitor()
	{
		string value = UIPopupList.current.value;
		Debug.Log("Selection: " + UIPopupList.current);
		this.newMonitorIndex = 0;
		if (UIPopupList.current.value.ToString() == "1")
		{
			this.newMonitorIndex = 0;
		}
		if (UIPopupList.current.value.ToString() == "2")
		{
			if (Display.displays.Length > 1)
			{
				this.newMonitorIndex = 1;
			}
			else
			{
				this.newMonitorIndex = 0;
			}
		}
		if (UIPopupList.current.value.ToString() == "3")
		{
			if (Display.displays.Length > 2)
			{
				this.newMonitorIndex = 2;
			}
			else
			{
				this.newMonitorIndex = 0;
			}
		}
		int num = this.newMonitorIndex + 1;
		this.screenMonitorTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_26", "Inspector_UI") + " " + num.ToString();
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x0009E22C File Offset: 0x0009C62C
	public void ChangeVSync()
	{
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_06", "Inspector_UI"))
		{
			this.vSyncTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_08", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			this.vSyncState = 1;
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = 120;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_07", "Inspector_UI"))
		{
			this.vSyncTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_08", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			this.vSyncState = 0;
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 120;
		}
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x0009E31C File Offset: 0x0009C71C
	public void ChangeFlickeringLights()
	{
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_06", "Inspector_UI"))
		{
			this.flickeringLightsTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_17", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			this.preventFlickeringLights = true;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_07", "Inspector_UI"))
		{
			this.flickeringLightsTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_17", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			this.preventFlickeringLights = false;
		}
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x0009E3F4 File Offset: 0x0009C7F4
	public void UpdateAITrafficDensity()
	{
		if (this.aiTrafficDensitySetting == 4)
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_18", "Inspector_UI");
		}
		else if (this.aiTrafficDensitySetting == 3)
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_11", "Inspector_UI");
		}
		else if (this.aiTrafficDensitySetting == 2)
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_12", "Inspector_UI");
		}
		else if (this.aiTrafficDensitySetting == 1)
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_13", "Inspector_UI");
		}
		else if (this.aiTrafficDensitySetting == 0)
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
		}
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x0009E550 File Offset: 0x0009C950
	public void ChangeAITrafficDensity()
	{
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_18", "Inspector_UI"))
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_18", "Inspector_UI");
			this.aiTrafficDensitySetting = 4;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_11", "Inspector_UI"))
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_11", "Inspector_UI");
			this.aiTrafficDensitySetting = 3;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_12", "Inspector_UI"))
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_12", "Inspector_UI");
			this.aiTrafficDensitySetting = 2;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_13", "Inspector_UI"))
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_13", "Inspector_UI");
			this.aiTrafficDensitySetting = 1;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_07", "Inspector_UI"))
		{
			this.aiTrafficDensityTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_19", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			this.aiTrafficDensitySetting = 0;
		}
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x0009E75C File Offset: 0x0009CB5C
	public void UpdateSSAO()
	{
		if (this.ssaoSetting)
		{
			this.ssaoTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_20", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			this.cameraObj.GetComponent<SSAOPro>().enabled = true;
		}
		else if (!this.ssaoSetting)
		{
			this.ssaoTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_20", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			this.cameraObj.GetComponent<SSAOPro>().enabled = false;
		}
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x0009E80C File Offset: 0x0009CC0C
	public void ChangeSSAO()
	{
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_06", "Inspector_UI"))
		{
			this.ssaoTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_20", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			this.ssaoSetting = true;
			this.cameraObj.GetComponent<SSAOPro>().enabled = true;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_07", "Inspector_UI"))
		{
			this.ssaoTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_20", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			this.ssaoSetting = false;
			this.cameraObj.GetComponent<SSAOPro>().enabled = false;
		}
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x0009E904 File Offset: 0x0009CD04
	public void UpdateAA()
	{
		if (this.aaSetting)
		{
			this.aaTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_25", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
		}
		else if (!this.aaSetting)
		{
			this.aaTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_25", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
		}
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x0009E994 File Offset: 0x0009CD94
	public void ChangeAA()
	{
		if (UIPopupList.current.value.ToString() == Language.Get("opt_video_06", "Inspector_UI"))
		{
			this.aaTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_25", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			this.aaSetting = true;
		}
		else if (UIPopupList.current.value.ToString() == Language.Get("opt_video_07", "Inspector_UI"))
		{
			this.aaTextObj.GetComponent<UILabel>().text = Language.Get("opt_video_25", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			this.aaSetting = false;
		}
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x0009EA6C File Offset: 0x0009CE6C
	public void UpdateMirrorSettings()
	{
		if (this.mirrorState == 0)
		{
			this.mirrorTextObj.GetComponent<UILabel>().text = "Mirrors are off";
		}
		if (this.mirrorState == 1)
		{
			this.mirrorTextObj.GetComponent<UILabel>().text = "Low quality mirrors";
		}
		if (this.mirrorState == 2)
		{
			this.mirrorTextObj.GetComponent<UILabel>().text = "Medium quality mirrors";
		}
		if (this.mirrorState == 3)
		{
			this.mirrorTextObj.GetComponent<UILabel>().text = "High quality mirrors";
		}
		if (this.mirrorState == 4)
		{
			this.mirrorTextObj.GetComponent<UILabel>().text = "Highest quality mirrors";
		}
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x0009EB20 File Offset: 0x0009CF20
	public void ChangeMirrorSettings()
	{
		if (UIPopupList.current.value.ToString() == "Off")
		{
			this.mirrorEnabled = false;
			this.mirrorState = 0;
		}
		if (UIPopupList.current.value.ToString() == "Low")
		{
			this.mirrorEnabled = true;
			this.mirrorState = 1;
		}
		if (UIPopupList.current.value.ToString() == "Medium")
		{
			this.mirrorEnabled = true;
			this.mirrorState = 2;
		}
		if (UIPopupList.current.value.ToString() == "High")
		{
			this.mirrorEnabled = true;
			this.mirrorState = 3;
		}
		if (UIPopupList.current.value.ToString() == "Highest")
		{
			this.mirrorEnabled = true;
			this.mirrorState = 4;
		}
		this.UpdateMirrorSettings();
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x0009EC0F File Offset: 0x0009D00F
	public void SetVideoValues()
	{
		this.fovSliderObj.GetComponent<UIScrollBar>().value = this.fov;
		this.SetFOVText();
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x0009EC30 File Offset: 0x0009D030
	public void SetAudioValues()
	{
		this.masterVolumeScroller.GetComponent<UIScrollBar>().value = this.masterVolume;
		this.effectsVolumeScroller.GetComponent<UIScrollBar>().value = this.effectsVolume;
		this.musicVolumeScroller.GetComponent<UIScrollBar>().value = this.musicVolume;
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x0009EC80 File Offset: 0x0009D080
	public void CloseOptionsVideo()
	{
		for (int i = 0; i < this.optionsMenuVideo.Length; i++)
		{
			this.optionsMenuVideo[i].active = false;
		}
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x0009ECB4 File Offset: 0x0009D0B4
	public void CloseOptionsCredits()
	{
		for (int i = 0; i < this.optionsMenuCredits.Length; i++)
		{
			this.optionsMenuCredits[i].active = false;
		}
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x0009ECE8 File Offset: 0x0009D0E8
	public void TurnCreditsLoc()
	{
		if (this.creditsPickup[3].GetComponent<UILabel>().text == ">>>")
		{
			this.creditsPickup[3].GetComponent<UILabel>().text = "<<<";
			this.creditsPickup[0].active = false;
			this.creditsPickup[2].active = true;
		}
		else
		{
			this.creditsPickup[3].GetComponent<UILabel>().text = ">>>";
			this.creditsPickup[2].active = false;
			this.creditsPickup[0].active = true;
		}
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x0009ED84 File Offset: 0x0009D184
	public void CloseOptionsAudio()
	{
		for (int i = 0; i < this.optionsMenuAudio.Length; i++)
		{
			this.optionsMenuAudio[i].active = false;
		}
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x0009EDB8 File Offset: 0x0009D1B8
	public void CloseOptions()
	{
		for (int i = 0; i < this.optionsBackdrops.Length; i++)
		{
			this.optionsBackdrops[i].active = false;
		}
		for (int j = 0; j < this.optionsMenuMain.Length; j++)
		{
			this.optionsMenuMain[j].active = false;
		}
		this.cameraObj.GetComponent<MenuMouseInteractionsC>().restrictRay = false;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			XboxController.SaveData();
		}
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x0009EE38 File Offset: 0x0009D238
	public void SaveKeyBindings()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < this.assignedInputstrings.Length; i++)
		{
			MonoBehaviour.print(this.assignedInputstrings[i].ToString());
			list.Add(this.assignedInputstrings[i].ToString());
		}
		ES3.Save(list, "assignedInputstrings");
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x0009EE94 File Offset: 0x0009D294
	public void LoadKeyBindings()
	{
		if (ES3.Exists("assignedInputstrings"))
		{
			List<string> list = new List<string>();
			list = ES3.LoadListString("assignedInputstrings");
			if (list.Count == 0)
			{
				this.ResetKeyInputToDefault();
			}
			if (this.assignedInputstrings == null || this.assignedInputstrings.Length < 1)
			{
				this.assignedInputstrings = new string[list.Count];
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.assignedInputstrings[i] = list[i];
				this.UpdateKeyboardInputChange(this.assignedInputstrings[i].ToString(), i);
			}
		}
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x0009EF38 File Offset: 0x0009D338
	public void ResetKeyInputToDefault()
	{
		this.assignedInputstrings = new string[this.keyboardInputAssigned.Length];
		this.UpdateKeyboardInputChange("w", 0);
		this.UpdateKeyboardInputChange("w", 1);
		this.UpdateKeyboardInputChange("s", 2);
		this.UpdateKeyboardInputChange("s", 3);
		this.UpdateKeyboardInputChange("a", 4);
		this.UpdateKeyboardInputChange("a", 5);
		this.UpdateKeyboardInputChange("d", 6);
		this.UpdateKeyboardInputChange("d", 7);
		this.UpdateKeyboardInputChange("w", 8);
		this.UpdateKeyboardInputChange("w", 9);
		this.UpdateKeyboardInputChange("s", 10);
		this.UpdateKeyboardInputChange("s", 11);
		this.UpdateKeyboardInputChange("a", 12);
		this.UpdateKeyboardInputChange("a", 13);
		this.UpdateKeyboardInputChange("d", 14);
		this.UpdateKeyboardInputChange("d", 15);
		this.UpdateKeyboardInputChange("mouse 0", 16);
		this.UpdateKeyboardInputChange("mouse 0", 17);
		this.UpdateKeyboardInputChange("mouse 2", 18);
		this.UpdateKeyboardInputChange("q", 19);
		this.UpdateKeyboardInputChange("mouse 1", 20);
		this.UpdateKeyboardInputChange("mouse 1", 21);
		this.UpdateKeyboardInputChange("1", 22);
		this.UpdateKeyboardInputChange("1", 23);
		this.UpdateKeyboardInputChange("2", 24);
		this.UpdateKeyboardInputChange("2", 25);
		this.UpdateKeyboardInputChange("3", 26);
		this.UpdateKeyboardInputChange("3", 27);
		this.UpdateKeyboardInputChange("left ctrl", 28);
		this.UpdateKeyboardInputChange("left ctrl", 29);
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x0009F0D8 File Offset: 0x0009D4D8
	public void UpdateKeyboardInputChange(string inputstring, int i)
	{
		int num;
		if (inputstring == "backspace")
		{
			num = 1;
		}
		else if (inputstring == "delete")
		{
			num = 3;
		}
		else if (inputstring == "tab")
		{
			num = 5;
		}
		else if (inputstring == "clear")
		{
			num = 7;
		}
		else if (inputstring == "return")
		{
			num = 9;
		}
		else if (inputstring == "pause")
		{
			num = 11;
		}
		else if (inputstring == "escape")
		{
			num = 13;
		}
		else if (inputstring == "space")
		{
			num = 15;
		}
		else if (inputstring == "up")
		{
			num = 17;
		}
		else if (inputstring == "down")
		{
			num = 19;
		}
		else if (inputstring == "right")
		{
			num = 21;
		}
		else if (inputstring == "left")
		{
			num = 23;
		}
		else if (inputstring == "insert")
		{
			num = 25;
		}
		else if (inputstring == "home")
		{
			num = 27;
		}
		else if (inputstring == "end")
		{
			num = 29;
		}
		else if (inputstring == "page up")
		{
			num = 31;
		}
		else if (inputstring == "page down")
		{
			num = 33;
		}
		else if (inputstring == "f1")
		{
			num = 35;
		}
		else if (inputstring == "f2")
		{
			num = 37;
		}
		else if (inputstring == "f3")
		{
			num = 39;
		}
		else if (inputstring == "f4")
		{
			num = 41;
		}
		else if (inputstring == "f5")
		{
			num = 43;
		}
		else if (inputstring == "f6")
		{
			num = 45;
		}
		else if (inputstring == "f7")
		{
			num = 47;
		}
		else if (inputstring == "f8")
		{
			num = 49;
		}
		else if (inputstring == "f9")
		{
			num = 51;
		}
		else if (inputstring == "f10")
		{
			num = 53;
		}
		else if (inputstring == "f11")
		{
			num = 55;
		}
		else if (inputstring == "f12")
		{
			num = 57;
		}
		else if (inputstring == "0")
		{
			num = 59;
		}
		else if (inputstring == "1")
		{
			num = 61;
		}
		else if (inputstring == "2")
		{
			num = 63;
		}
		else if (inputstring == "3")
		{
			num = 65;
		}
		else if (inputstring == "4")
		{
			num = 67;
		}
		else if (inputstring == "5")
		{
			num = 69;
		}
		else if (inputstring == "6")
		{
			num = 71;
		}
		else if (inputstring == "7")
		{
			num = 73;
		}
		else if (inputstring == "8")
		{
			num = 75;
		}
		else if (inputstring == "9")
		{
			num = 77;
		}
		else if (inputstring == "!")
		{
			num = 79;
		}
		else if (inputstring == "\"")
		{
			num = 81;
		}
		else if (inputstring == "#")
		{
			num = 83;
		}
		else if (inputstring == "$")
		{
			num = 85;
		}
		else if (inputstring == "&")
		{
			num = 87;
		}
		else if (inputstring == "'")
		{
			num = 89;
		}
		else if (inputstring == "(")
		{
			num = 91;
		}
		else if (inputstring == ")")
		{
			num = 93;
		}
		else if (inputstring == "*")
		{
			num = 95;
		}
		else if (inputstring == "+")
		{
			num = 97;
		}
		else if (inputstring == ",")
		{
			num = 99;
		}
		else if (inputstring == "-")
		{
			num = 101;
		}
		else if (inputstring == ".")
		{
			num = 103;
		}
		else if (inputstring == "/")
		{
			num = 105;
		}
		else if (inputstring == ":")
		{
			num = 107;
		}
		else if (inputstring == ";")
		{
			num = 109;
		}
		else if (inputstring == "<")
		{
			num = 111;
		}
		else if (inputstring == "=")
		{
			num = 113;
		}
		else if (inputstring == ">")
		{
			num = 115;
		}
		else if (inputstring == "?")
		{
			num = 117;
		}
		else if (inputstring == "@")
		{
			num = 119;
		}
		else if (inputstring == "[")
		{
			num = 121;
		}
		else if (inputstring == "\\")
		{
			num = 123;
		}
		else if (inputstring == "]")
		{
			num = 125;
		}
		else if (inputstring == "^")
		{
			num = 127;
		}
		else if (inputstring == "_")
		{
			num = 129;
		}
		else if (inputstring == "`")
		{
			num = 131;
		}
		else if (inputstring == "a")
		{
			num = 133;
		}
		else if (inputstring == "b")
		{
			num = 135;
		}
		else if (inputstring == "c")
		{
			num = 137;
		}
		else if (inputstring == "d")
		{
			num = 139;
		}
		else if (inputstring == "e")
		{
			num = 141;
		}
		else if (inputstring == "f")
		{
			num = 143;
		}
		else if (inputstring == "g")
		{
			num = 145;
		}
		else if (inputstring == "h")
		{
			num = 147;
		}
		else if (inputstring == "i")
		{
			num = 149;
		}
		else if (inputstring == "j")
		{
			num = 151;
		}
		else if (inputstring == "k")
		{
			num = 153;
		}
		else if (inputstring == "l")
		{
			num = 155;
		}
		else if (inputstring == "m")
		{
			num = 157;
		}
		else if (inputstring == "n")
		{
			num = 159;
		}
		else if (inputstring == "o")
		{
			num = 161;
		}
		else if (inputstring == "p")
		{
			num = 163;
		}
		else if (inputstring == "q")
		{
			num = 165;
		}
		else if (inputstring == "r")
		{
			num = 167;
		}
		else if (inputstring == "s")
		{
			num = 169;
		}
		else if (inputstring == "t")
		{
			num = 171;
		}
		else if (inputstring == "u")
		{
			num = 173;
		}
		else if (inputstring == "v")
		{
			num = 175;
		}
		else if (inputstring == "w")
		{
			num = 177;
		}
		else if (inputstring == "x")
		{
			num = 179;
		}
		else if (inputstring == "y")
		{
			num = 181;
		}
		else if (inputstring == "z")
		{
			num = 183;
		}
		else if (inputstring == "numlock")
		{
			num = 185;
		}
		else if (inputstring == "caps lock")
		{
			num = 187;
		}
		else if (inputstring == "scroll lock")
		{
			num = 189;
		}
		else if (inputstring == "right shift")
		{
			num = 191;
		}
		else if (inputstring == "left shift")
		{
			num = 193;
		}
		else if (inputstring == "right ctrl")
		{
			num = 195;
		}
		else if (inputstring == "left ctrl")
		{
			num = 197;
		}
		else if (inputstring == "right alt")
		{
			num = 199;
		}
		else if (inputstring == "left alt")
		{
			num = 201;
		}
		else if (inputstring == "mouse 0")
		{
			num = 203;
		}
		else if (inputstring == "mouse 1")
		{
			num = 205;
		}
		else
		{
			if (!(inputstring == "mouse 2"))
			{
				return;
			}
			num = 207;
		}
		this.keyboardInputTarget[i].GetComponent<UI2DSprite>().sprite2D = this.keyboardInputUI[num - 1];
		this.keyboardInputTarget[i].GetComponent<UIButton>().normalSprite2D = this.keyboardInputUI[num - 1];
		this.keyboardInputTarget[i].GetComponent<UIButton>().hoverSprite2D = this.keyboardInputUI[num - 1];
		this.keyboardInputAssigned[i] = num - 1;
		this.assignedInputstrings[i] = this.inputStringLibrary[this.keyboardInputAssigned[i]];
		this.changeInputID = 0;
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x0009FB9C File Offset: 0x0009DF9C
	public void ResetKeyBindingsToPrevSetting()
	{
		for (int i = 0; i < this.keyboardInputAssigned.Length; i++)
		{
			this.keyboardInputAssigned[i] = this.keyboardInputAssignedPrev[i];
			this.keyboardInputTarget[i].GetComponent<UI2DSprite>().sprite2D = this.keyboardInputUI[this.keyboardInputAssignedPrev[i]];
			this.keyboardInputTarget[i].GetComponent<UIButton>().normalSprite2D = this.keyboardInputUI[this.keyboardInputAssignedPrev[i]];
			this.keyboardInputTarget[i].GetComponent<UIButton>().hoverSprite2D = this.keyboardInputUI[this.keyboardInputAssignedPrev[i]];
			this.keyboardInputAssigned[i] = this.keyboardInputAssignedPrev[i];
			this.assignedInputstrings[i] = this.inputStringLibrary[this.keyboardInputAssignedPrev[i]];
		}
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x0009FC5C File Offset: 0x0009E05C
	public void CheckForKeyboardInputChange()
	{
		if (Input.anyKey)
		{
			int num;
			if (Input.GetKey("backspace"))
			{
				num = 1;
			}
			else if (Input.GetKey("delete"))
			{
				num = 3;
			}
			else if (Input.GetKey("tab"))
			{
				num = 5;
			}
			else if (Input.GetKey("clear"))
			{
				num = 7;
			}
			else if (Input.GetKey("return"))
			{
				num = 9;
			}
			else if (Input.GetKey("pause"))
			{
				num = 11;
			}
			else if (Input.GetKey("escape"))
			{
				num = 13;
			}
			else if (Input.GetKey("space"))
			{
				num = 15;
			}
			else if (Input.GetKey("up"))
			{
				num = 17;
			}
			else if (Input.GetKey("down"))
			{
				num = 19;
			}
			else if (Input.GetKey("right"))
			{
				num = 21;
			}
			else if (Input.GetKey("left"))
			{
				num = 23;
			}
			else if (Input.GetKey("insert"))
			{
				num = 25;
			}
			else if (Input.GetKey("home"))
			{
				num = 27;
			}
			else if (Input.GetKey("end"))
			{
				num = 29;
			}
			else if (Input.GetKey("page up"))
			{
				num = 31;
			}
			else if (Input.GetKey("page down"))
			{
				num = 33;
			}
			else if (Input.GetKey("f1"))
			{
				num = 35;
			}
			else if (Input.GetKey("f2"))
			{
				num = 37;
			}
			else if (Input.GetKey("f3"))
			{
				num = 39;
			}
			else if (Input.GetKey("f4"))
			{
				num = 41;
			}
			else if (Input.GetKey("f5"))
			{
				num = 43;
			}
			else if (Input.GetKey("f6"))
			{
				num = 45;
			}
			else if (Input.GetKey("f7"))
			{
				num = 47;
			}
			else if (Input.GetKey("f8"))
			{
				num = 49;
			}
			else if (Input.GetKey("f9"))
			{
				num = 51;
			}
			else if (Input.GetKey("f10"))
			{
				num = 53;
			}
			else if (Input.GetKey("f11"))
			{
				num = 55;
			}
			else if (Input.GetKey("f12"))
			{
				num = 57;
			}
			else if (Input.GetKey("0"))
			{
				num = 59;
			}
			else if (Input.GetKey("1"))
			{
				num = 61;
			}
			else if (Input.GetKey("2"))
			{
				num = 63;
			}
			else if (Input.GetKey("3"))
			{
				num = 65;
			}
			else if (Input.GetKey("4"))
			{
				num = 67;
			}
			else if (Input.GetKey("5"))
			{
				num = 69;
			}
			else if (Input.GetKey("6"))
			{
				num = 71;
			}
			else if (Input.GetKey("7"))
			{
				num = 73;
			}
			else if (Input.GetKey("8"))
			{
				num = 75;
			}
			else if (Input.GetKey("9"))
			{
				num = 77;
			}
			else if (Input.GetKey("!"))
			{
				num = 79;
			}
			else if (Input.GetKey("\""))
			{
				num = 81;
			}
			else if (Input.GetKey("#"))
			{
				num = 83;
			}
			else if (Input.GetKey("$"))
			{
				num = 85;
			}
			else if (Input.GetKey("&"))
			{
				num = 87;
			}
			else if (Input.GetKey("'"))
			{
				num = 89;
			}
			else if (Input.GetKey("("))
			{
				num = 91;
			}
			else if (Input.GetKey(")"))
			{
				num = 93;
			}
			else if (Input.GetKey("*"))
			{
				num = 95;
			}
			else if (Input.GetKey("+"))
			{
				num = 97;
			}
			else if (Input.GetKey(","))
			{
				num = 99;
			}
			else if (Input.GetKey("-"))
			{
				num = 101;
			}
			else if (Input.GetKey("."))
			{
				num = 103;
			}
			else if (Input.GetKey("/"))
			{
				num = 105;
			}
			else if (Input.GetKey(":"))
			{
				num = 107;
			}
			else if (Input.GetKey(";"))
			{
				num = 109;
			}
			else if (Input.GetKey("<"))
			{
				num = 111;
			}
			else if (Input.GetKey("="))
			{
				num = 113;
			}
			else if (Input.GetKey(">"))
			{
				num = 115;
			}
			else if (Input.GetKey("?"))
			{
				num = 117;
			}
			else if (Input.GetKey("@"))
			{
				num = 119;
			}
			else if (Input.GetKey("["))
			{
				num = 121;
			}
			else if (Input.GetKey("\\"))
			{
				num = 123;
			}
			else if (Input.GetKey("]"))
			{
				num = 125;
			}
			else if (Input.GetKey("^"))
			{
				num = 127;
			}
			else if (Input.GetKey("_"))
			{
				num = 129;
			}
			else if (Input.GetKey("`"))
			{
				num = 131;
			}
			else if (Input.GetKey("a"))
			{
				num = 133;
			}
			else if (Input.GetKey("b"))
			{
				num = 135;
			}
			else if (Input.GetKey("c"))
			{
				num = 137;
			}
			else if (Input.GetKey("d"))
			{
				num = 139;
			}
			else if (Input.GetKey("e"))
			{
				num = 141;
			}
			else if (Input.GetKey("f"))
			{
				num = 143;
			}
			else if (Input.GetKey("g"))
			{
				num = 145;
			}
			else if (Input.GetKey("h"))
			{
				num = 147;
			}
			else if (Input.GetKey("i"))
			{
				num = 149;
			}
			else if (Input.GetKey("j"))
			{
				num = 151;
			}
			else if (Input.GetKey("k"))
			{
				num = 153;
			}
			else if (Input.GetKey("l"))
			{
				num = 155;
			}
			else if (Input.GetKey("m"))
			{
				num = 157;
			}
			else if (Input.GetKey("n"))
			{
				num = 159;
			}
			else if (Input.GetKey("o"))
			{
				num = 161;
			}
			else if (Input.GetKey("p"))
			{
				num = 163;
			}
			else if (Input.GetKey("q"))
			{
				num = 165;
			}
			else if (Input.GetKey("r"))
			{
				num = 167;
			}
			else if (Input.GetKey("s"))
			{
				num = 169;
			}
			else if (Input.GetKey("t"))
			{
				num = 171;
			}
			else if (Input.GetKey("u"))
			{
				num = 173;
			}
			else if (Input.GetKey("v"))
			{
				num = 175;
			}
			else if (Input.GetKey("w"))
			{
				num = 177;
			}
			else if (Input.GetKey("x"))
			{
				num = 179;
			}
			else if (Input.GetKey("y"))
			{
				num = 181;
			}
			else if (Input.GetKey("z"))
			{
				num = 183;
			}
			else if (Input.GetKey("numlock"))
			{
				num = 185;
			}
			else if (Input.GetKey("caps lock"))
			{
				num = 187;
			}
			else if (Input.GetKey("scroll lock"))
			{
				num = 189;
			}
			else if (Input.GetKey("right shift"))
			{
				num = 191;
			}
			else if (Input.GetKey("left shift"))
			{
				num = 193;
			}
			else if (Input.GetKey("right ctrl"))
			{
				num = 195;
			}
			else if (Input.GetKey("left ctrl"))
			{
				num = 197;
			}
			else if (Input.GetKey("right alt"))
			{
				num = 199;
			}
			else if (Input.GetKey("left alt"))
			{
				num = 201;
			}
			else if (Input.GetKey("mouse 0"))
			{
				num = 203;
			}
			else if (Input.GetKey("mouse 1"))
			{
				num = 205;
			}
			else
			{
				if (!Input.GetKey("mouse 2"))
				{
					return;
				}
				num = 207;
			}
			this.keyboardInputTarget[this.changeInputID - 1].GetComponent<UI2DSprite>().sprite2D = this.keyboardInputUI[num - 1];
			this.keyboardInputTarget[this.changeInputID - 1].GetComponent<UIButton>().normalSprite2D = this.keyboardInputUI[num - 1];
			this.keyboardInputTarget[this.changeInputID - 1].GetComponent<UIButton>().hoverSprite2D = this.keyboardInputUI[num - 1];
			this.keyboardInputAssigned[this.changeInputID - 1] = num - 1;
			this.assignedInputstrings[this.changeInputID - 1] = this.inputStringLibrary[num - 1];
			this.changeInputID = 0;
		}
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x000A06DD File Offset: 0x0009EADD
	public void ChangeKeyboardInputWalkingForward1()
	{
		this.changeInputID = 1;
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x000A06E6 File Offset: 0x0009EAE6
	public void ChangeKeyboardInputWalkingForward2()
	{
		this.changeInputID = 2;
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x000A06EF File Offset: 0x0009EAEF
	public void ChangeKeyboardInputWalkingBackward1()
	{
		this.changeInputID = 3;
	}

	// Token: 0x060007B8 RID: 1976 RVA: 0x000A06F8 File Offset: 0x0009EAF8
	public void ChangeKeyboardInputWalkingBackward2()
	{
		this.changeInputID = 4;
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x000A0701 File Offset: 0x0009EB01
	public void ChangeKeyboardInputStrafeLeft1()
	{
		this.changeInputID = 5;
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x000A070A File Offset: 0x0009EB0A
	public void ChnageKeyboardInputStrafeLeft2()
	{
		this.changeInputID = 6;
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x000A0713 File Offset: 0x0009EB13
	public void ChangeKeyboardInputStrafeRight1()
	{
		this.changeInputID = 7;
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x000A071C File Offset: 0x0009EB1C
	public void ChangeKeyboardInputStrafeRight2()
	{
		this.changeInputID = 8;
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x000A0725 File Offset: 0x0009EB25
	public void ChangeKeyboardInputAccelerate1()
	{
		this.changeInputID = 9;
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x000A072F File Offset: 0x0009EB2F
	public void ChangeKeyboardInputAccelerate2()
	{
		this.changeInputID = 10;
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000A0739 File Offset: 0x0009EB39
	public void ChangeKeyboardInputBrakeRev1()
	{
		this.changeInputID = 11;
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x000A0743 File Offset: 0x0009EB43
	public void ChangeKeyboardInputBrakeRev2()
	{
		this.changeInputID = 12;
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x000A074D File Offset: 0x0009EB4D
	public void ChangeKeyboardInputSteerLeft1()
	{
		this.changeInputID = 13;
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000A0757 File Offset: 0x0009EB57
	public void ChangeKeyboardInputSteerLeft2()
	{
		this.changeInputID = 14;
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x000A0761 File Offset: 0x0009EB61
	public void ChangeKeyboardInputSteerRight1()
	{
		this.changeInputID = 15;
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000A076B File Offset: 0x0009EB6B
	public void ChangeKeyboardInputSteerRight2()
	{
		this.changeInputID = 16;
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x000A0775 File Offset: 0x0009EB75
	public void ChangeKeyboardPickup1()
	{
		this.changeInputID = 17;
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x000A077F File Offset: 0x0009EB7F
	public void ChangeKeyboardPickup2()
	{
		this.changeInputID = 18;
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x000A0789 File Offset: 0x0009EB89
	public void ChangeKeyboardDrop1()
	{
		this.changeInputID = 19;
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x000A0793 File Offset: 0x0009EB93
	public void ChangeKeyboardDrop2()
	{
		this.changeInputID = 20;
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x000A079D File Offset: 0x0009EB9D
	public void ChangeKeyboardZoom1()
	{
		this.changeInputID = 21;
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x000A07A7 File Offset: 0x0009EBA7
	public void ChangeKeyboardZoom2()
	{
		this.changeInputID = 22;
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x000A07B1 File Offset: 0x0009EBB1
	public void ChangeKeyboardItem11()
	{
		this.changeInputID = 23;
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x000A07BB File Offset: 0x0009EBBB
	public void ChangeKeyboardItem12()
	{
		this.changeInputID = 24;
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x000A07C5 File Offset: 0x0009EBC5
	public void ChangeKeyboardItem21()
	{
		this.changeInputID = 25;
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x000A07CF File Offset: 0x0009EBCF
	public void ChangeKeyboardItem22()
	{
		this.changeInputID = 26;
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x000A07D9 File Offset: 0x0009EBD9
	public void ChangeKeyboardItem31()
	{
		this.changeInputID = 27;
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x000A07E3 File Offset: 0x0009EBE3
	public void ChangeKeyboardItem32()
	{
		this.changeInputID = 28;
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x000A07ED File Offset: 0x0009EBED
	public void ChangeKeyboardCrouch1()
	{
		this.changeInputID = 29;
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x000A07F7 File Offset: 0x0009EBF7
	public void ChangeKeyboardCrouch2()
	{
		this.changeInputID = 30;
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x000A0801 File Offset: 0x0009EC01
	public void changeKeyboardInputStop()
	{
		this.changeInputID = 0;
	}

	// Token: 0x040009D7 RID: 2519
	public Image splashImage;

	// Token: 0x040009D8 RID: 2520
	public Image loadingSprite;

	// Token: 0x040009D9 RID: 2521
	private GameObject _camera;

	// Token: 0x040009DA RID: 2522
	public GameObject cameraObj;

	// Token: 0x040009DB RID: 2523
	public GameObject animBook;

	// Token: 0x040009DC RID: 2524
	public GameObject loadingText;

	// Token: 0x040009DD RID: 2525
	public GameObject walletNumber;

	// Token: 0x040009DE RID: 2526
	public GameObject[] backDrops = new GameObject[0];

	// Token: 0x040009DF RID: 2527
	public GameObject carDoor;

	// Token: 0x040009E0 RID: 2528
	public bool bookClosed = true;

	// Token: 0x040009E1 RID: 2529
	public bool isGlowing;

	// Token: 0x040009E2 RID: 2530
	public GameObject[] dustParticles = new GameObject[0];

	// Token: 0x040009E3 RID: 2531
	public AudioClip pickupAudio;

	// Token: 0x040009E4 RID: 2532
	public AudioClip bookDropAudio;

	// Token: 0x040009E5 RID: 2533
	public AudioClip turnPageAudio;

	// Token: 0x040009E6 RID: 2534
	public AudioClip bookCloseAudio;

	// Token: 0x040009E7 RID: 2535
	public AudioClip bookOpenAudio;

	// Token: 0x040009E8 RID: 2536
	public AudioClip bookManyPagesAudio;

	// Token: 0x040009E9 RID: 2537
	public Vector3[] pos = new Vector3[0];

	// Token: 0x040009EA RID: 2538
	public Vector3[] rot = new Vector3[0];

	// Token: 0x040009EB RID: 2539
	public string[] easeType = new string[0];

	// Token: 0x040009EC RID: 2540
	public GameObject[] frontPageContents = new GameObject[0];

	// Token: 0x040009ED RID: 2541
	public GameObject[] newGameTexts = new GameObject[0];

	// Token: 0x040009EE RID: 2542
	public GameObject[] exitGameTexts = new GameObject[0];

	// Token: 0x040009EF RID: 2543
	public GameObject renderTarget;

	// Token: 0x040009F0 RID: 2544
	public Material glowMaterial;

	// Token: 0x040009F1 RID: 2545
	public Material startMaterial;

	// Token: 0x040009F2 RID: 2546
	public GameObject topEyeLid;

	// Token: 0x040009F3 RID: 2547
	public GameObject bottomEyeLid;

	// Token: 0x040009F4 RID: 2548
	public Material[] decalMatCatalogue = new Material[0];

	// Token: 0x040009F5 RID: 2549
	public GameObject[] optionsBackdrops = new GameObject[0];

	// Token: 0x040009F6 RID: 2550
	public GameObject[] optionsMenuMain = new GameObject[0];

	// Token: 0x040009F7 RID: 2551
	public GameObject[] optionsMenuGameplay = new GameObject[0];

	// Token: 0x040009F8 RID: 2552
	public GameObject[] optionsMenuVideo = new GameObject[0];

	// Token: 0x040009F9 RID: 2553
	public GameObject[] optionsMenuAudio = new GameObject[0];

	// Token: 0x040009FA RID: 2554
	public GameObject[] optionsMenuCredits = new GameObject[0];

	// Token: 0x040009FB RID: 2555
	public GameObject[] optionsMenuNoticeboard = new GameObject[0];

	// Token: 0x040009FC RID: 2556
	public GameObject[] headerUIs = new GameObject[0];

	// Token: 0x040009FD RID: 2557
	public GameObject[] saveUIs = new GameObject[0];

	// Token: 0x040009FE RID: 2558
	public GameObject[] backUIs = new GameObject[0];

	// Token: 0x040009FF RID: 2559
	public GameObject[] acceptUIs = new GameObject[0];

	// Token: 0x04000A00 RID: 2560
	public GameObject[] setDefaultUIs = new GameObject[0];

	// Token: 0x04000A01 RID: 2561
	public bool lookInvert;

	// Token: 0x04000A02 RID: 2562
	public bool lookInvertTemp;

	// Token: 0x04000A03 RID: 2563
	public GameObject lookInvertObj;

	// Token: 0x04000A04 RID: 2564
	public int padInput;

	// Token: 0x04000A05 RID: 2565
	public int padInputTemp;

	// Token: 0x04000A06 RID: 2566
	public GameObject padInputObj;

	// Token: 0x04000A07 RID: 2567
	public float mouseSensitivity;

	// Token: 0x04000A08 RID: 2568
	public GameObject mouseSensitivityObj;

	// Token: 0x04000A09 RID: 2569
	public bool mouseSmooth;

	// Token: 0x04000A0A RID: 2570
	public bool mouseSmoothTemp;

	// Token: 0x04000A0B RID: 2571
	public GameObject mouseSmoothObj;

	// Token: 0x04000A0C RID: 2572
	public float fov;

	// Token: 0x04000A0D RID: 2573
	public GameObject fovTextObj;

	// Token: 0x04000A0E RID: 2574
	public GameObject fovSliderObj;

	// Token: 0x04000A0F RID: 2575
	public GameObject screenResTextObj;

	// Token: 0x04000A10 RID: 2576
	public GameObject screenMonitorTextObj;

	// Token: 0x04000A11 RID: 2577
	public int resolutionX;

	// Token: 0x04000A12 RID: 2578
	public int resolutionY;

	// Token: 0x04000A13 RID: 2579
	public bool fullScreenState = true;

	// Token: 0x04000A14 RID: 2580
	public GameObject fullScreenTextObj;

	// Token: 0x04000A15 RID: 2581
	public GameObject vSyncTextObj;

	// Token: 0x04000A16 RID: 2582
	public int vSyncState;

	// Token: 0x04000A17 RID: 2583
	public GameObject flickeringLightsTextObj;

	// Token: 0x04000A18 RID: 2584
	public bool preventFlickeringLights;

	// Token: 0x04000A19 RID: 2585
	public GameObject aiTrafficDensityTextObj;

	// Token: 0x04000A1A RID: 2586
	public int aiTrafficDensitySetting;

	// Token: 0x04000A1B RID: 2587
	public GameObject ssaoTextObj;

	// Token: 0x04000A1C RID: 2588
	public bool ssaoSetting = true;

	// Token: 0x04000A1D RID: 2589
	public GameObject aaTextObj;

	// Token: 0x04000A1E RID: 2590
	public bool aaSetting = true;

	// Token: 0x04000A1F RID: 2591
	public GameObject mirrorTextObj;

	// Token: 0x04000A20 RID: 2592
	public bool mirrorEnabled;

	// Token: 0x04000A21 RID: 2593
	public int mirrorState;

	// Token: 0x04000A22 RID: 2594
	public GameObject shadowTextObj;

	// Token: 0x04000A23 RID: 2595
	public int shadowQualityState;

	// Token: 0x04000A24 RID: 2596
	public GameObject qualityTextObj;

	// Token: 0x04000A25 RID: 2597
	public int qualityState;

	// Token: 0x04000A26 RID: 2598
	public int newMonitorIndex;

	// Token: 0x04000A27 RID: 2599
	public float masterVolume = 1f;

	// Token: 0x04000A28 RID: 2600
	public GameObject masterVolumeScroller;

	// Token: 0x04000A29 RID: 2601
	public float effectsVolume = 1f;

	// Token: 0x04000A2A RID: 2602
	public GameObject effectsVolumeScroller;

	// Token: 0x04000A2B RID: 2603
	public float musicVolume = 1f;

	// Token: 0x04000A2C RID: 2604
	public GameObject musicVolumeScroller;

	// Token: 0x04000A2D RID: 2605
	private AsyncOperation async;

	// Token: 0x04000A2E RID: 2606
	public Transform carDoorMeshTransform;

	// Token: 0x04000A2F RID: 2607
	public Mesh carDoorMeshData;

	// Token: 0x04000A30 RID: 2608
	public GameObject optionsKeyInputs;

	// Token: 0x04000A31 RID: 2609
	public int changeInputID;

	// Token: 0x04000A32 RID: 2610
	public GameObject[] keyboardInputTarget = new GameObject[0];

	// Token: 0x04000A33 RID: 2611
	public Sprite[] keyboardInputUI = new Sprite[0];

	// Token: 0x04000A34 RID: 2612
	public int[] keyboardInputAssigned = new int[0];

	// Token: 0x04000A35 RID: 2613
	public int[] keyboardInputAssignedPrev = new int[0];

	// Token: 0x04000A36 RID: 2614
	public string[] inputStringLibrary = new string[0];

	// Token: 0x04000A37 RID: 2615
	public string[] assignedInputstrings = new string[0];

	// Token: 0x04000A38 RID: 2616
	public string[] assignedInputStrings = new string[0];

	// Token: 0x04000A39 RID: 2617
	public GameObject[] noticeBoardTexts = new GameObject[0];

	// Token: 0x04000A3A RID: 2618
	public GameObject[] keyInputTexts = new GameObject[0];

	// Token: 0x04000A3B RID: 2619
	public UIFont chineseFont;

	// Token: 0x04000A3C RID: 2620
	public UIFont nonEnglishFont;

	// Token: 0x04000A3D RID: 2621
	public GameObject[] aiTrafficDensityLocalisedObj = new GameObject[0];

	// Token: 0x04000A3E RID: 2622
	public GameObject[] vSyncLocalisedObj = new GameObject[0];

	// Token: 0x04000A3F RID: 2623
	public GameObject[] fullScreenLocalisedObj = new GameObject[0];

	// Token: 0x04000A40 RID: 2624
	public GameObject[] qualityLocalisedObj = new GameObject[0];

	// Token: 0x04000A41 RID: 2625
	public GameObject[] flickeringLightsLocalisedObj = new GameObject[0];

	// Token: 0x04000A42 RID: 2626
	public GameObject[] ssaoLocalisedObj = new GameObject[0];

	// Token: 0x04000A43 RID: 2627
	public GameObject[] mirrorLocalisedObj = new GameObject[0];

	// Token: 0x04000A44 RID: 2628
	public GameObject[] aaLocalisedObj = new GameObject[0];

	// Token: 0x04000A45 RID: 2629
	public GameObject[] creditsPickup = new GameObject[0];

	// Token: 0x04000A46 RID: 2630
	public bool newGameSelected;
}
