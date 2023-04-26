using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200014D RID: 333
public class SplashScreen : MonoBehaviour
{
	// Token: 0x1700004F RID: 79
	// (get) Token: 0x06000D22 RID: 3362 RVA: 0x0012E104 File Offset: 0x0012C504
	// (set) Token: 0x06000D23 RID: 3363 RVA: 0x0012E10C File Offset: 0x0012C50C
	public int Selection
	{
		get
		{
			return this.selection;
		}
		set
		{
			this.selection = value;
			this.languageArrows[0].gameObject.SetActive(value > 0);
			this.languageArrows[1].gameObject.SetActive(value < 18);
			string arg = "English";
			this.selectedLanguage = LanguageCode.EN;
			if (value == 1)
			{
				arg = "French";
				this.selectedLanguage = LanguageCode.FR;
			}
			if (value == 2)
			{
				arg = "German";
				this.selectedLanguage = LanguageCode.DE;
			}
			if (value == 3)
			{
				arg = "Italian";
				this.selectedLanguage = LanguageCode.IT;
			}
			if (value == 4)
			{
				arg = "Spanish";
				this.selectedLanguage = LanguageCode.ES;
			}
			if (value == 5)
			{
				arg = "Portuguese";
				this.selectedLanguage = LanguageCode.PT_BR;
			}
			if (value == 6)
			{
				arg = "Turkish";
				this.selectedLanguage = LanguageCode.TR;
			}
			if (value == 7)
			{
				arg = "Hungarian";
				this.selectedLanguage = LanguageCode.HU;
			}
			if (value == 8)
			{
				arg = "Simplified Chinese";
				this.selectedLanguage = LanguageCode.ZH;
			}
			if (value == 9)
			{
				arg = "Dutch";
				this.selectedLanguage = LanguageCode.NL;
			}
			if (value == 10)
			{
				arg = "Finnish";
				this.selectedLanguage = LanguageCode.FI;
			}
			if (value == 11)
			{
				arg = "Japanese";
				this.selectedLanguage = LanguageCode.JA;
			}
			if (value == 12)
			{
				arg = "Polish";
				this.selectedLanguage = LanguageCode.PL;
			}
			if (value == 13)
			{
				arg = "Russian";
				this.selectedLanguage = LanguageCode.RU;
			}
			if (value == 14)
			{
				arg = "Slovenian";
				this.selectedLanguage = LanguageCode.SK;
			}
			if (value == 15)
			{
				arg = "Croatian";
				this.selectedLanguage = LanguageCode.HR;
			}
			if (value == 16)
			{
				arg = "Romanian";
				this.selectedLanguage = LanguageCode.RO;
			}
			if (value == 17)
			{
				arg = "Korean";
				this.selectedLanguage = LanguageCode.KO;
			}
			if (value == 18)
			{
				arg = "Norwegian";
				this.selectedLanguage = LanguageCode.NO;
			}
			this.selectLanguage.text = string.Format("Press any key to load {0}", arg);
		}
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x0012E310 File Offset: 0x0012C710
	private void Start()
	{
		float num = 1f;
		Time.timeScale = 1f;
		this.minskLogo.color = Color.clear;
		this.selectLanguage.color = Color.clear;
		this.pressKey.color = Color.clear;
		this.pressKey.text = ((Application.platform != RuntimePlatform.XboxOne) ? "Press any key to start" : "Press A to start");
		this.splashImage.DOColor(Color.clear, 1f).SetDelay(1f + num);
		this.jalopyLogo.rectTransform.DOLocalMoveY(76.13f, 1.5f, false).SetDelay(2f + num).SetEase(Ease.OutBack);
		this.jalopyLogo.transform.DOScale(0.19f, 1.5f).SetDelay(2f + num).SetEase(Ease.OutBack);
		this.minskLogo.DOColor(Color.white, 1f).SetDelay(3f + num);
		this.pressKey.DOColor(Color.white, 1f).SetDelay(3f + num);
		this.pressKey.transform.DOLocalMoveY(-81f, 0.5f, false).SetLoops(-1, LoopType.Yoyo);
		this.languageMover.parent.parent.localPosition = new Vector3(0f, -400f, 0f);
		this.languageArrows[0].DOAnchorPosY(18.7f, 0.4f, false).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
		this.languageArrows[1].DOAnchorPosY(-31.6f, 0.4f, false).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
		this.selectorTransform.DOLocalMoveX(-48.14f, 1f, false).SetEase(Ease.InOutBack).SetLoops(-1, LoopType.Yoyo);
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i] == "-fixedTime")
			{
				string s = commandLineArgs[i + 1];
				Debug.LogError(float.Parse(s) + " Is the refresh rate");
				Time.fixedDeltaTime = float.Parse(s);
			}
		}
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x0012E55C File Offset: 0x0012C95C
	private void Pressed()
	{
		this.anyPressed = true;
		this.pressKey.DOColor(Color.clear, 1f);
		this.selectLanguage.DOColor(Color.white, 2f).SetDelay(1f);
		this.languageMover.parent.parent.DOLocalMoveY(-78.2f, 1f, false).SetEase(Ease.InOutQuint);
		this.timePass = 8.5f;
	}

	// Token: 0x06000D26 RID: 3366 RVA: 0x0012E5DC File Offset: 0x0012C9DC
	private void Update()
	{
		bool flag;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			flag = Input.GetKeyDown(KeyCode.JoystickButton0);
		}
		else
		{
			flag = Input.anyKeyDown;
		}
		if (this.updateDone)
		{
			return;
		}
		bool flag2 = Input.GetKeyDown(KeyCode.UpArrow) || (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0.1f && Input.GetAxis("Mouse ScrollWheel") > 0.1f) || Input.GetKeyDown(KeyCode.W) || (Input.GetAxisRaw("JoypadDpadY") > 0f && !this.pressed);
		bool flag3 = Input.GetKeyDown(KeyCode.DownArrow) || (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0.1f && Input.GetAxis("Mouse ScrollWheel") < 0.1f) || Input.GetKeyDown(KeyCode.S) || (Input.GetAxisRaw("JoypadDpadY") < 0f && !this.pressed);
		this.timePass += Time.deltaTime;
		if (Mathf.Abs(Input.GetAxis("JoypadDpadY")) < 0.5f && Mathf.Abs(Input.GetAxis("JoypadDpadX")) < 0.5f)
		{
			this.pressed = false;
		}
		if (this.timePass < 5.5f)
		{
			return;
		}
		if (!this.anyPressed && flag)
		{
			this.Pressed();
		}
		if (!this.anyPressed)
		{
			return;
		}
		if (flag2 && !this.pressed)
		{
			this.Selection = Mathf.Clamp(this.Selection - 1, 0, 18);
			base.GetComponent<AudioSource>().Play();
			this.pressed = true;
		}
		if (flag3 && !this.pressed)
		{
			this.Selection = Mathf.Clamp(this.Selection + 1, 0, 18);
			base.GetComponent<AudioSource>().Play();
			this.pressed = true;
		}
		this.languageMover.transform.localPosition = Vector3.Lerp(this.languageMover.transform.localPosition, new Vector3(0f, -106.4f + 29.93f * (float)this.Selection, 0f), Time.deltaTime * 8f);
		if (this.timePass > 9f && flag && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && Mathf.Abs(Input.GetAxisRaw("JoypadDpadY")) <= 0.1f)
		{
			this.updateDone = true;
			this.jalopyLogo.rectTransform.DOLocalMoveY(356f, 0.7f, false).SetEase(Ease.InBack);
			this.selectLanguage.DOColor(Color.clear, 0.7f);
			this.languageMover.parent.parent.DOLocalMoveY(-311.2f, 0.7f, false).SetEase(Ease.InOutQuint);
			this.minskLogo.DOColor(Color.clear, 0.7f);
			this.loadingSprite.DOColor(Color.white, 0.5f);
			this.loadingSprite.transform.DORotate(Vector3.forward * 90f, 0.3f, RotateMode.Fast).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
			this.fadeCode.SelectLanguage(this.selectedLanguage);
		}
	}

	// Token: 0x0400118E RID: 4494
	public RectTransform[] languageArrows;

	// Token: 0x0400118F RID: 4495
	public RawImage splashImage;

	// Token: 0x04001190 RID: 4496
	public RawImage jalopyLogo;

	// Token: 0x04001191 RID: 4497
	public Image minskLogo;

	// Token: 0x04001192 RID: 4498
	public Text pressKey;

	// Token: 0x04001193 RID: 4499
	public Transform selectorTransform;

	// Token: 0x04001194 RID: 4500
	public Transform languageMover;

	// Token: 0x04001195 RID: 4501
	private int selection;

	// Token: 0x04001196 RID: 4502
	private bool anyPressed;

	// Token: 0x04001197 RID: 4503
	public Text selectLanguage;

	// Token: 0x04001198 RID: 4504
	private float timePass;

	// Token: 0x04001199 RID: 4505
	public Image loadingSprite;

	// Token: 0x0400119A RID: 4506
	private LanguageCode selectedLanguage = LanguageCode.EN;

	// Token: 0x0400119B RID: 4507
	private bool updateDone;

	// Token: 0x0400119C RID: 4508
	private bool pressed;

	// Token: 0x0400119D RID: 4509
	public TitleFadeInC fadeCode;
}
