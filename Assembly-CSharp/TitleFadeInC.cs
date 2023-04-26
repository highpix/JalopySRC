using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000109 RID: 265
public class TitleFadeInC : MonoBehaviour
{
	// Token: 0x06000A70 RID: 2672 RVA: 0x000F8954 File Offset: 0x000F6D54
	private IEnumerator LateStart()
	{
		yield return new WaitForSeconds(0.2f);
		iTween.MoveTo(this.rect1, iTween.Hash(new object[]
		{
			"position",
			this.rect1Pos1,
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeoutsine",
			"oncomplete",
			"FireText",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.rect2, iTween.Hash(new object[]
		{
			"position",
			this.rect2Pos1,
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeoutsine"
		}));
		yield return new WaitForSeconds(0.1f);
		base.GetComponent<AudioSource>().PlayOneShot(this.stingAudio, 1f);
		yield break;
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x000F8970 File Offset: 0x000F6D70
	private void Start()
	{
		for (int i = 0; i < this.languageObjects.Length; i++)
		{
			TweenAlpha.Begin(this.languageObjects[i], 0f, 0f);
			this.languageObjects[i].GetComponent<Collider>().enabled = false;
		}
		TweenAlpha.Begin(this.rect2, 0f, 0f);
		this.rect1.transform.localPosition = this.rect1Pos2;
		this.rect2.transform.localPosition = this.rect2Pos2;
		base.StartCoroutine(this.LateStart());
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x000F8A10 File Offset: 0x000F6E10
	private void Update()
	{
		if (Time.timeScale != 1f)
		{
			Time.timeScale = 1f;
		}
	}

	// Token: 0x06000A73 RID: 2675 RVA: 0x000F8A2C File Offset: 0x000F6E2C
	public IEnumerator FireText()
	{
		yield return new WaitForSeconds(0.1f);
		TweenAlpha.Begin(this.textObject1, 1f, 1f);
		yield return new WaitForSeconds(3f);
		TweenAlpha.Begin(this.textObject1, 0.5f, 0f);
		TweenAlpha.Begin(this.rect2, 0.5f, 0f);
		yield return new WaitForSeconds(0.5f);
		this.FadeInLanguage();
		yield break;
	}

	// Token: 0x06000A74 RID: 2676 RVA: 0x000F8A48 File Offset: 0x000F6E48
	public void FadeInLanguage()
	{
		for (int i = 0; i < this.languageObjects.Length; i++)
		{
			TweenAlpha.Begin(this.languageObjects[i], 1f, 1f);
			this.languageObjects[i].GetComponent<Collider>().enabled = true;
		}
		if (Application.platform == RuntimePlatform.XboxOne || Application.platform == RuntimePlatform.WindowsEditor)
		{
		}
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x000F8AB0 File Offset: 0x000F6EB0
	public void SelectLanguage(LanguageCode ID)
	{
		Language.SwitchLanguage(ID);
		base.Invoke("StartGame", 0.9f);
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x000F8AC9 File Offset: 0x000F6EC9
	public void LanguageENSelected()
	{
		Language.SwitchLanguage(LanguageCode.EN);
		this.StartGame();
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x000F8AD9 File Offset: 0x000F6ED9
	public void LanguageFRSelected()
	{
		Language.SwitchLanguage(LanguageCode.FR);
		this.StartGame();
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x000F8AE9 File Offset: 0x000F6EE9
	public void LanguageDESelected()
	{
		Language.SwitchLanguage(LanguageCode.DE);
		this.StartGame();
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x000F8AF9 File Offset: 0x000F6EF9
	public void LanguageITSelected()
	{
		Language.SwitchLanguage(LanguageCode.IT);
		this.StartGame();
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x000F8B09 File Offset: 0x000F6F09
	public void LanguageSPSelected()
	{
		Language.SwitchLanguage(LanguageCode.ES);
		this.StartGame();
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x000F8B19 File Offset: 0x000F6F19
	public void LanguagePTBRSelected()
	{
		Language.SwitchLanguage(LanguageCode.PT_BR);
		this.StartGame();
	}

	// Token: 0x06000A7C RID: 2684 RVA: 0x000F8B2C File Offset: 0x000F6F2C
	public void LanguageTRSelected()
	{
		Language.SwitchLanguage(LanguageCode.TR);
		this.StartGame();
	}

	// Token: 0x06000A7D RID: 2685 RVA: 0x000F8B3F File Offset: 0x000F6F3F
	public void LanguageHUSelected()
	{
		Language.SwitchLanguage(LanguageCode.HU);
		this.StartGame();
	}

	// Token: 0x06000A7E RID: 2686 RVA: 0x000F8B4F File Offset: 0x000F6F4F
	public void LanguageZHSelected()
	{
		Language.SwitchLanguage(LanguageCode.ZH);
		this.StartGame();
	}

	// Token: 0x06000A7F RID: 2687 RVA: 0x000F8B62 File Offset: 0x000F6F62
	public void LanguageNLSelected()
	{
		Language.SwitchLanguage(LanguageCode.NL);
		this.StartGame();
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x000F8B75 File Offset: 0x000F6F75
	public void LanguageFISelected()
	{
		Language.SwitchLanguage(LanguageCode.FI);
		this.StartGame();
	}

	// Token: 0x06000A81 RID: 2689 RVA: 0x000F8B85 File Offset: 0x000F6F85
	public void LanguageJASelected()
	{
		Language.SwitchLanguage(LanguageCode.JA);
		this.StartGame();
	}

	// Token: 0x06000A82 RID: 2690 RVA: 0x000F8B95 File Offset: 0x000F6F95
	public void LanguagePLSelected()
	{
		Language.SwitchLanguage(LanguageCode.PL);
		this.StartGame();
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x000F8BA8 File Offset: 0x000F6FA8
	public void LanguageRUSelected()
	{
		Language.SwitchLanguage(LanguageCode.RU);
		this.StartGame();
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x000F8BBB File Offset: 0x000F6FBB
	public void LanguageSKSelected()
	{
		Language.SwitchLanguage(LanguageCode.SK);
		this.StartGame();
	}

	// Token: 0x06000A85 RID: 2693 RVA: 0x000F8BCE File Offset: 0x000F6FCE
	public void LanguageHRSelected()
	{
		Language.SwitchLanguage(LanguageCode.HR);
		this.StartGame();
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x000F8BDE File Offset: 0x000F6FDE
	public void LanguageROSelected()
	{
		Language.SwitchLanguage(LanguageCode.RO);
		this.StartGame();
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x000F8BF1 File Offset: 0x000F6FF1
	public void LanguageKOSelected()
	{
		Language.SwitchLanguage(LanguageCode.KO);
		this.StartGame();
	}

	// Token: 0x06000A88 RID: 2696 RVA: 0x000F8C01 File Offset: 0x000F7001
	public void LanguageNOSelected()
	{
		Language.SwitchLanguage(LanguageCode.NO);
		this.StartGame();
	}

	// Token: 0x06000A89 RID: 2697 RVA: 0x000F8C14 File Offset: 0x000F7014
	public void LanguageLTSelected()
	{
		Language.SwitchLanguage(LanguageCode.LT);
		this.StartGame();
	}

	// Token: 0x06000A8A RID: 2698 RVA: 0x000F8C24 File Offset: 0x000F7024
	public void LanguageSWSelected()
	{
		Language.SwitchLanguage(LanguageCode.SW);
		this.StartGame();
	}

	// Token: 0x06000A8B RID: 2699 RVA: 0x000F8C37 File Offset: 0x000F7037
	public void StartGame()
	{
		SceneManager.LoadSceneAsync(1);
	}

	// Token: 0x04000E8A RID: 3722
	public JalopyCursor jalopyCursor;

	// Token: 0x04000E8B RID: 3723
	public GameObject textObject1;

	// Token: 0x04000E8C RID: 3724
	public GameObject textObject2;

	// Token: 0x04000E8D RID: 3725
	public GameObject rect1;

	// Token: 0x04000E8E RID: 3726
	public GameObject rect2;

	// Token: 0x04000E8F RID: 3727
	public Vector3 rect1Pos1;

	// Token: 0x04000E90 RID: 3728
	public Vector3 rect1Pos2;

	// Token: 0x04000E91 RID: 3729
	public Vector3 rect2Pos1;

	// Token: 0x04000E92 RID: 3730
	public Vector3 rect2Pos2;

	// Token: 0x04000E93 RID: 3731
	public AudioClip stingAudio;

	// Token: 0x04000E94 RID: 3732
	public GameObject[] languageObjects;
}
