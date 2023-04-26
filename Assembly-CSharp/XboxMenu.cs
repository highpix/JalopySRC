using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000166 RID: 358
public class XboxMenu : MonoBehaviour
{
	// Token: 0x06000DA2 RID: 3490 RVA: 0x0013317B File Offset: 0x0013157B
	public void PlaySelect()
	{
		this.menuSound.Play();
	}

	// Token: 0x06000DA3 RID: 3491 RVA: 0x00133188 File Offset: 0x00131588
	private void Start()
	{
		for (int i = 0; i < this.consoleObjects.Count; i++)
		{
			this.consoleObjects[i].SetActive(Application.platform == RuntimePlatform.XboxOne);
		}
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			this.selectedAudio.transform.parent.localPosition += Vector3.up * 23f;
		}
	}

	// Token: 0x06000DA4 RID: 3492 RVA: 0x00133208 File Offset: 0x00131608
	private void DisableNonConsole()
	{
		for (int i = 0; i < this.nonConsoleObjects.Count; i++)
		{
			if (this.nonConsoleObjects[i] != null)
			{
				this.nonConsoleObjects[i].SetActive(Application.platform != RuntimePlatform.XboxOne);
			}
		}
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x00133268 File Offset: 0x00131668
	private void Update()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
		}
		if (Application.platform != RuntimePlatform.XboxOne)
		{
			return;
		}
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		this.bookObject.qualityState = 0;
		this.bookObject.aiTrafficDensitySetting = 2;
		this.bookObject.ssaoSetting = true;
		this.bookObject.aaSetting = true;
		this.bookObject.mirrorEnabled = false;
		this.bookObject.mirrorState = 0;
		this.bookObject.UpdateSSAO();
		this.bookObject.UpdateAITrafficDensity();
		this.bookObject.UpdateAA();
		this.DisableNonConsole();
		if (!this.dPadPressed)
		{
			flag2 = (Input.GetAxisRaw("JoypadDpadY") < 0f);
			flag3 = (Input.GetAxisRaw("JoypadDpadY") > 0f);
			flag4 = (Input.GetAxisRaw("JoypadDpadX") < 0f);
			flag5 = (Input.GetAxisRaw("JoypadDpadX") > 0f);
			flag = Input.GetKeyDown(KeyCode.JoystickButton0);
			this.dPadPressed = (Input.GetKey(KeyCode.Joystick1Button0) || Mathf.Abs(Input.GetAxisRaw("JoypadDpadY")) > 0f || Mathf.Abs(Input.GetAxisRaw("JoypadDpadX")) > 0f);
		}
		else if (Mathf.Abs(Input.GetAxis("JoypadDpadY")) < 0.5f && Mathf.Abs(Input.GetAxis("JoypadDpadX")) < 0.5f)
		{
			this.dPadPressed = false;
		}
		if (flag2 || flag3 || flag4 || flag5)
		{
			this.PlaySelect();
		}
		this.selectedMasterVolume.SetActive(this.audioPanel.activeInHierarchy);
		if (this.audioPanel.activeInHierarchy)
		{
			if (flag4)
			{
				this.masterDown.GetComponent<UIButton>().OnClick();
			}
			if (flag5)
			{
				this.masterUp.GetComponent<UIButton>().OnClick();
			}
			return;
		}
		if (this.gameplayPanel.activeInHierarchy)
		{
			if (flag3)
			{
				this.SelectGameplayOptions(this.selectedChoice - 1);
			}
			if (flag2)
			{
				this.SelectGameplayOptions(this.selectedChoice + 1);
			}
			if (this.selectedChoice == 0 && flag)
			{
				this.selectedInvert.transform.parent.GetComponent<UIButton>().OnClick();
			}
			if (this.selectedChoice == 1)
			{
				if (flag4)
				{
					this.sensitivityDown.GetComponent<UIButton>().OnClick();
				}
				if (flag5)
				{
					this.sensitivityUp.GetComponent<UIButton>().OnClick();
				}
			}
			return;
		}
		if (this.mainOptionsPanel.activeInHierarchy)
		{
			if (flag3)
			{
				this.SelectOptions(this.selectedChoice - 1);
			}
			if (flag2)
			{
				this.SelectOptions(this.selectedChoice + 1);
			}
			if (flag)
			{
				this.ClickOptions();
			}
			return;
		}
		if (this.bookObject.newGameSelected)
		{
			if (flag4)
			{
				this.SelectNewGame(this.selectedChoice - 1);
			}
			if (flag5)
			{
				this.SelectNewGame(this.selectedChoice + 1);
			}
			if (flag)
			{
				this.ClickNewGame();
			}
			return;
		}
		if (!this.bookObject.bookClosed)
		{
			if (flag2)
			{
				this.SelectBook(this.selectedChoice + 1);
			}
			if (flag3)
			{
				this.SelectBook(this.selectedChoice - 1);
			}
			if (flag)
			{
				this.ClickBook();
			}
			this.consoleObjects[0].SetActive(false);
			return;
		}
		this.consoleObjects[0].SetActive(true);
		if (flag && this.bookObject.bookClosed)
		{
			this.bookObject.Action();
			this.SelectBook(0);
		}
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x0013362C File Offset: 0x00131A2C
	private void ClickOptions()
	{
		if (this.blockBuild || !this.mainOptionsPanel.activeInHierarchy)
		{
			return;
		}
		int num = this.selectedChoice;
		if (num != 1)
		{
			if (num != 2)
			{
				this.selectedGameplay.transform.parent.GetComponent<UIButton>().OnClick();
				this.SelectGameplayOptions(0);
			}
			else
			{
				this.selectedCredits.transform.parent.GetComponent<UIButton>().OnClick();
			}
		}
		else
		{
			this.selectedAudio.transform.parent.GetComponent<UIButton>().OnClick();
		}
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x001336D4 File Offset: 0x00131AD4
	private void ClickBook()
	{
		if (this.blockBuild || this.bookObject.bookClosed)
		{
			return;
		}
		switch (this.selectedChoice)
		{
		case 1:
			this.selectedContinue.transform.parent.GetComponent<UIButton>().OnClick();
			break;
		case 2:
			this.selectedOptions.transform.parent.GetComponent<UIButton>().OnClick();
			this.SelectOptions(0);
			break;
		case 3:
			this.selectedCloseBook.transform.parent.GetComponent<UIButton>().OnClick();
			break;
		default:
			this.selectedNewGame.transform.parent.GetComponent<UIButton>().OnClick();
			this.SelectNewGame(0);
			break;
		}
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x001337A8 File Offset: 0x00131BA8
	private void ClickNewGame()
	{
		if (this.blockBuild || this.bookObject.bookClosed)
		{
			return;
		}
		int num = this.selectedChoice;
		if (num != 1)
		{
			if (num != 2)
			{
				this.selectedTutorial.transform.parent.GetComponent<UIButton>().OnClick();
			}
			else
			{
				this.selectedBackNewGame.transform.parent.GetComponent<UIButton>().OnClick();
				this.SelectBook(0);
			}
		}
		else
		{
			this.selectedSkipTutorial.transform.parent.GetComponent<UIButton>().OnClick();
		}
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x00133850 File Offset: 0x00131C50
	private void SelectBook(int value)
	{
		if (this.blockBuild)
		{
			this.selectedNewGame.SetActive(false);
			this.selectedContinue.SetActive(false);
			this.selectedOptions.SetActive(false);
			this.selectedCloseBook.SetActive(false);
			return;
		}
		this.selectedChoice = Mathf.Clamp(value, 0, 3);
		switch (this.selectedChoice)
		{
		case 1:
			this.selectedNewGame.SetActive(false);
			this.selectedContinue.SetActive(true);
			this.selectedOptions.SetActive(false);
			this.selectedCloseBook.SetActive(false);
			break;
		case 2:
			this.selectedNewGame.SetActive(false);
			this.selectedContinue.SetActive(false);
			this.selectedOptions.SetActive(true);
			this.selectedCloseBook.SetActive(false);
			break;
		case 3:
			this.selectedNewGame.SetActive(false);
			this.selectedContinue.SetActive(false);
			this.selectedOptions.SetActive(false);
			this.selectedCloseBook.SetActive(true);
			break;
		default:
			this.selectedNewGame.SetActive(true);
			this.selectedContinue.SetActive(false);
			this.selectedOptions.SetActive(false);
			this.selectedCloseBook.SetActive(false);
			break;
		}
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x0013399C File Offset: 0x00131D9C
	private void SelectNewGame(int value)
	{
		if (this.blockBuild)
		{
			this.selectedBackNewGame.SetActive(false);
			this.selectedTutorial.SetActive(false);
			this.selectedSkipTutorial.SetActive(false);
			return;
		}
		this.selectedChoice = Mathf.Clamp(value, 0, 2);
		int num = this.selectedChoice;
		if (num != 1)
		{
			if (num != 2)
			{
				this.selectedBackNewGame.SetActive(false);
				this.selectedTutorial.SetActive(true);
				this.selectedSkipTutorial.SetActive(false);
			}
			else
			{
				this.selectedBackNewGame.SetActive(true);
				this.selectedTutorial.SetActive(false);
				this.selectedSkipTutorial.SetActive(false);
			}
		}
		else
		{
			this.selectedBackNewGame.SetActive(false);
			this.selectedTutorial.SetActive(false);
			this.selectedSkipTutorial.SetActive(true);
		}
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x00133A7C File Offset: 0x00131E7C
	private void SelectOptions(int value)
	{
		if (this.blockBuild)
		{
			this.selectedGameplay.SetActive(false);
			this.selectedAudio.SetActive(false);
			this.selectedCredits.SetActive(false);
			return;
		}
		this.selectedChoice = Mathf.Clamp(value, 0, 2);
		int num = this.selectedChoice;
		if (num != 1)
		{
			if (num != 2)
			{
				this.selectedGameplay.SetActive(true);
				this.selectedAudio.SetActive(false);
				this.selectedCredits.SetActive(false);
			}
			else
			{
				this.selectedGameplay.SetActive(false);
				this.selectedAudio.SetActive(false);
				this.selectedCredits.SetActive(true);
			}
		}
		else
		{
			this.selectedGameplay.SetActive(false);
			this.selectedAudio.SetActive(true);
			this.selectedCredits.SetActive(false);
		}
	}

	// Token: 0x06000DAC RID: 3500 RVA: 0x00133B5C File Offset: 0x00131F5C
	private void SelectGameplayOptions(int value)
	{
		if (this.blockBuild || !this.gameplayPanel.activeInHierarchy)
		{
			this.selectedInvert.SetActive(false);
			this.selectedSensitivity.SetActive(false);
			return;
		}
		this.selectedChoice = Mathf.Clamp(value, 0, 1);
		int num = this.selectedChoice;
		if (num != 1)
		{
			this.selectedInvert.SetActive(true);
			this.selectedSensitivity.SetActive(false);
		}
		else
		{
			this.selectedInvert.SetActive(false);
			this.selectedSensitivity.SetActive(true);
		}
	}

	// Token: 0x0400123A RID: 4666
	public AudioSource menuSound;

	// Token: 0x0400123B RID: 4667
	public List<GameObject> consoleObjects = new List<GameObject>();

	// Token: 0x0400123C RID: 4668
	public List<GameObject> nonConsoleObjects = new List<GameObject>();

	// Token: 0x0400123D RID: 4669
	public MainMenuBookC bookObject;

	// Token: 0x0400123E RID: 4670
	public int selectedChoice;

	// Token: 0x0400123F RID: 4671
	[Header("Book")]
	public GameObject selectedNewGame;

	// Token: 0x04001240 RID: 4672
	public GameObject selectedContinue;

	// Token: 0x04001241 RID: 4673
	public GameObject selectedOptions;

	// Token: 0x04001242 RID: 4674
	public GameObject selectedCloseBook;

	// Token: 0x04001243 RID: 4675
	[Header("New Game")]
	public GameObject selectedTutorial;

	// Token: 0x04001244 RID: 4676
	public GameObject selectedSkipTutorial;

	// Token: 0x04001245 RID: 4677
	public GameObject selectedBackNewGame;

	// Token: 0x04001246 RID: 4678
	public bool blockBuild;

	// Token: 0x04001247 RID: 4679
	public bool dPadPressed;

	// Token: 0x04001248 RID: 4680
	[Header("Options")]
	public GameObject mainOptionsPanel;

	// Token: 0x04001249 RID: 4681
	public GameObject selectedGameplay;

	// Token: 0x0400124A RID: 4682
	public GameObject selectedAudio;

	// Token: 0x0400124B RID: 4683
	public GameObject selectedCredits;

	// Token: 0x0400124C RID: 4684
	[Header("Gameplay")]
	public GameObject gameplayPanel;

	// Token: 0x0400124D RID: 4685
	public GameObject selectedInvert;

	// Token: 0x0400124E RID: 4686
	public GameObject selectedSensitivity;

	// Token: 0x0400124F RID: 4687
	public GameObject sensitivityDown;

	// Token: 0x04001250 RID: 4688
	public GameObject sensitivityUp;

	// Token: 0x04001251 RID: 4689
	[Header("Audio")]
	public GameObject audioPanel;

	// Token: 0x04001252 RID: 4690
	public GameObject selectedMasterVolume;

	// Token: 0x04001253 RID: 4691
	public GameObject masterDown;

	// Token: 0x04001254 RID: 4692
	public GameObject masterUp;
}
