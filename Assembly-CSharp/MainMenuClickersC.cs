using System;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class MainMenuClickersC : MonoBehaviour
{
	// Token: 0x060007D5 RID: 2005 RVA: 0x000A0E88 File Offset: 0x0009F288
	public void NewGame()
	{
		this.book.transform.GetChild(0).GetComponent<Animator>().SetBool("page1FoldGo", true);
		this.book.SendMessage("NewGameConfirmer");
		this.book.SendMessage("NewGameStopper");
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x000A0ED6 File Offset: 0x0009F2D6
	public void ClickAudioOnly()
	{
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x000A0EF4 File Offset: 0x0009F2F4
	public void StartNewGame()
	{
		if (ES3.loadedSave == null)
		{
			ES3.loadedSave = new SaveFile();
		}
		bool mirrorEnabled = ES3.loadedSave.mirrorEnabled;
		int mirrorState = ES3.loadedSave.mirrorState;
		float masterVolume = ES3.loadedSave.masterVolume;
		bool lookInvert = ES3.loadedSave.lookInvert;
		float mouseSensitivity = ES3.loadedSave.mouseSensitivity;
		int padInput = ES3.loadedSave.padInput2;
		int aiCount = ES3.loadedSave.aiCount;
		this.EraseSaveData();
		ES3.loadedSave.reticule = false;
		ES3.loadedSave.aiCount = aiCount;
		ES3.loadedSave.mirrorEnabled = mirrorEnabled;
		ES3.loadedSave.padInput2 = padInput;
		ES3.loadedSave.lookInvert = lookInvert;
		ES3.loadedSave.mouseSensitivity = mouseSensitivity;
		ES3.loadedSave.masterVolume = masterVolume;
		ES3.loadedSave.mirrorState = mirrorState;
		this.book.SendMessage("CloseEyes");
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x000A0FD8 File Offset: 0x0009F3D8
	public void StartNewGameSkipTutorial()
	{
		if (ES3.loadedSave == null)
		{
			ES3.loadedSave = new SaveFile();
		}
		int aiCount = ES3.loadedSave.aiCount;
		int padInput = ES3.loadedSave.padInput2;
		float masterVolume = ES3.loadedSave.masterVolume;
		bool lookInvert = ES3.loadedSave.lookInvert;
		float mouseSensitivity = ES3.loadedSave.mouseSensitivity;
		bool mirrorEnabled = ES3.loadedSave.mirrorEnabled;
		int mirrorState = ES3.loadedSave.mirrorState;
		this.EraseSaveData();
		ES3.loadedSave.reticule = false;
		ES3.loadedSave.aiCount = aiCount;
		ES3.loadedSave.mirrorEnabled = mirrorEnabled;
		ES3.loadedSave.lookInvert = lookInvert;
		ES3.loadedSave.mouseSensitivity = mouseSensitivity;
		ES3.loadedSave.masterVolume = masterVolume;
		ES3.loadedSave.padInput2 = padInput;
		ES3.loadedSave.mirrorState = mirrorState;
		ES3.Save(true, "uncleTutorialCompleted");
		ES3.Save(true, "doorFitted");
		ES3.Save(1, "carEngineID");
		ES3.Save(3f, "carEngineCondition");
		ES3.Save(1, "ignitionCoilID");
		ES3.Save(3f, "ignitionCoilCondition");
		ES3.Save(1, "fuelTankID");
		ES3.Save(3f, "fuelTankCondition");
		ES3.Save(10f, "fuelTankFuelAmount");
		ES3.Save(3, "fuelTankFuelMix");
		ES3.Save(1, "carburettorID");
		ES3.Save(3f, "carburettorCondition");
		ES3.Save(1, "airFilterID");
		ES3.Save(3f, "airFilterCondition");
		ES3.Save(1, "waterTankID");
		ES3.Save(3f, "waterTankCondition");
		ES3.Save(4, "waterTankWaterCharges");
		ES3.Save(1, "batteryID");
		ES3.Save(3f, "batteryCondition");
		ES3.Save(100f, "batteryCharges");
		ES3.Save(1, "flWheelID");
		ES3.Save(0f, "flCompoundID");
		ES3.Save(3f, "flWheelCondition");
		ES3.Save(1, "frWheelID");
		ES3.Save(0f, "frCompoundID");
		ES3.Save(3f, "frWheelCondition");
		ES3.Save(1, "rlWheelID");
		ES3.Save(0f, "rlCompoundID");
		ES3.Save(3f, "rlWheelCondition");
		ES3.Save(1, "rrWheelID");
		ES3.Save(0f, "rrCompoundID");
		ES3.Save(3f, "rrWheelCondition");
		this.book.SendMessage("CloseEyes");
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x000A125E File Offset: 0x0009F65E
	public void ContinueGame()
	{
		this.book.SendMessage("CloseEyes");
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x000A1270 File Offset: 0x0009F670
	public void TurnToExitPage()
	{
		this.book.transform.GetChild(0).GetComponent<Animator>().SetBool("page1FoldGo", true);
		this.book.SendMessage("ExitGameConfirmer");
		this.book.SendMessage("NewGameStopper");
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000A12C0 File Offset: 0x0009F6C0
	public void ReturnToFrontPage()
	{
		this.book.SendMessage("ExitPageStopper");
		this.book.SendMessage("ReturnToFrontPage");
		this.book.SendMessage("NewGameMenuStopper");
		this.book.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackHover", true);
		this.book.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackGo", true);
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x000A133F File Offset: 0x0009F73F
	public void ExitNotice()
	{
		this._noticeOnlyOptionsObject.GetComponent<BoxCollider>().enabled = true;
		this._noticeOnlyBookObject.GetComponent<BoxCollider>().enabled = true;
		UnityEngine.Object.Destroy(base.transform.parent.gameObject);
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x000A1378 File Offset: 0x0009F778
	public void ExitGame()
	{
		Application.Quit();
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x000A137F File Offset: 0x0009F77F
	public void CloseBook()
	{
		this.book.SendMessage("CloseBook");
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x000A1391 File Offset: 0x0009F791
	public void OpenOptions()
	{
		this.book.SendMessage("CloseBook");
		this.book.SendMessage("OpenOptions");
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x000A13B3 File Offset: 0x0009F7B3
	public void OpenOptionsGameplay()
	{
		this.book.SendMessage("ChangeOptionsPage");
		this.book.SendMessage("OpenOptionsGameplay");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x000A13F0 File Offset: 0x0009F7F0
	public void GameplayOptionsBack()
	{
		this.book.SendMessage("CloseOptionsGameplay");
		this.book.SendMessage("OpenOptions");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x000A142D File Offset: 0x0009F82D
	public void GameplayOptionsAccept()
	{
		this.book.SendMessage("SaveOptionsGameplay");
		this.book.SendMessage("OpenOptions");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x000A146A File Offset: 0x0009F86A
	public void OpenOptionsVideo()
	{
		this.book.SendMessage("ChangeOptionsPage");
		this.book.SendMessage("OpenOptionsVideo");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x000A14A7 File Offset: 0x0009F8A7
	public void OpenOptionsCredits()
	{
		this.book.SendMessage("ChangeOptionsPage");
		this.book.SendMessage("OpenOptionsCredits");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x000A14E4 File Offset: 0x0009F8E4
	public void VideoOptionsBack()
	{
		this.book.SendMessage("CloseOptionsVideo");
		this.book.SendMessage("OpenOptions");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x000A1521 File Offset: 0x0009F921
	public void VideoOptionsAccept()
	{
		this.book.SendMessage("SaveOptionsVideo");
		this.book.SendMessage("OpenOptions");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x000A155E File Offset: 0x0009F95E
	public void CreditsBack()
	{
		this.book.SendMessage("CloseOptionsCredits");
		this.book.SendMessage("OpenOptions");
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x000A1580 File Offset: 0x0009F980
	public void CreditsTurnToLoc()
	{
		this.book.SendMessage("TurnCreditsLoc");
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x000A1592 File Offset: 0x0009F992
	public void ExitOptions()
	{
		this.book.SendMessage("CloseOptions");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x000A15C0 File Offset: 0x0009F9C0
	public void InvertLookToggle()
	{
		if (!this.book.GetComponent<MainMenuBookC>().lookInvertTemp)
		{
			this.book.GetComponent<MainMenuBookC>().lookInvertTemp = true;
			this.book.GetComponent<MainMenuBookC>().lookInvertObj.GetComponent<UILabel>().text = Language.Get("opt_game_01_b", "Inspector_UI");
		}
		else
		{
			this.book.GetComponent<MainMenuBookC>().lookInvertTemp = false;
			this.book.GetComponent<MainMenuBookC>().lookInvertObj.GetComponent<UILabel>().text = Language.Get("opt_game_01", "Inspector_UI");
		}
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x000A165C File Offset: 0x0009FA5C
	public void PadInputToggle()
	{
		if (this.book.GetComponent<MainMenuBookC>().padInputTemp == 0)
		{
			this.book.GetComponent<MainMenuBookC>().padInputTemp = 1;
			this.book.GetComponent<MainMenuBookC>().padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_08", "Inspector_UI");
		}
		else if (this.book.GetComponent<MainMenuBookC>().padInputTemp == 1)
		{
			this.book.GetComponent<MainMenuBookC>().padInputTemp = 2;
			this.book.GetComponent<MainMenuBookC>().padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_09", "Inspector_UI");
		}
		else if (this.book.GetComponent<MainMenuBookC>().padInputTemp == 2)
		{
			this.book.GetComponent<MainMenuBookC>().padInputTemp = 3;
			this.book.GetComponent<MainMenuBookC>().padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_10", "Inspector_UI");
		}
		else if (this.book.GetComponent<MainMenuBookC>().padInputTemp == 3)
		{
			this.book.GetComponent<MainMenuBookC>().padInputTemp = 0;
			this.book.GetComponent<MainMenuBookC>().padInputObj.GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_07", "Inspector_UI");
		}
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x000A1808 File Offset: 0x0009FC08
	public void MouseSmoothToggle()
	{
		if (!this.book.GetComponent<MainMenuBookC>().mouseSmoothTemp)
		{
			this.book.GetComponent<MainMenuBookC>().mouseSmoothTemp = true;
			this.book.GetComponent<MainMenuBookC>().mouseSmoothObj.GetComponent<UILabel>().text = Language.Get("opt_game_04", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
		}
		else
		{
			this.book.GetComponent<MainMenuBookC>().mouseSmoothTemp = false;
			this.book.GetComponent<MainMenuBookC>().mouseSmoothObj.GetComponent<UILabel>().text = Language.Get("opt_game_04", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
		}
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x000A18CC File Offset: 0x0009FCCC
	public void OpenOptionsAudio()
	{
		if (this.book == null)
		{
			return;
		}
		this.book.SendMessage("ChangeOptionsPage");
		this.book.SendMessage("OpenOptionsAudio");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x000A1926 File Offset: 0x0009FD26
	public void AudioOptionsBack()
	{
		this.book.SendMessage("CloseOptionsAudio");
		this.book.SendMessage("OpenOptions");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x000A1963 File Offset: 0x0009FD63
	public void AudioOptionsAccept()
	{
		this.book.SendMessage("SaveOptionsAudio");
		this.book.SendMessage("OpenOptions");
		this.book.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x000A19A0 File Offset: 0x0009FDA0
	public void EraseSaveData()
	{
		ES3.loadedSave = new SaveFile();
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x000A19AC File Offset: 0x0009FDAC
	public void CloseNoticeBoard()
	{
		this.book.SendMessage("CloseNoticeBoard");
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x000A19BE File Offset: 0x0009FDBE
	public void SliderUp()
	{
		base.transform.parent.GetComponent<UIScrollBar>().value += 0.1f;
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x000A19E1 File Offset: 0x0009FDE1
	public void SliderDown()
	{
		base.transform.parent.GetComponent<UIScrollBar>().value -= 0.1f;
	}

	// Token: 0x04000A47 RID: 2631
	public GameObject book;

	// Token: 0x04000A48 RID: 2632
	public AudioClip audioClip;

	// Token: 0x04000A49 RID: 2633
	public GameObject _noticeOnlyOptionsObject;

	// Token: 0x04000A4A RID: 2634
	public GameObject _noticeOnlyBookObject;
}
