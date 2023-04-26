using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000167 RID: 359
public class XboxPause : MonoBehaviour
{
	// Token: 0x06000DAE RID: 3502 RVA: 0x00133C08 File Offset: 0x00132008
	public IEnumerator NumerSelectUp()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		this.SelectUp();
		yield break;
	}

	// Token: 0x06000DAF RID: 3503 RVA: 0x00133C23 File Offset: 0x00132023
	private void Awake()
	{
		XboxPause.Global = this;
	}

	// Token: 0x06000DB0 RID: 3504 RVA: 0x00133C2B File Offset: 0x0013202B
	private void OnDestroy()
	{
		XboxPause.Global = null;
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x00133C33 File Offset: 0x00132033
	public void PlaySelect()
	{
		this.menuSound.Play();
	}

	// Token: 0x06000DB2 RID: 3506 RVA: 0x00133C40 File Offset: 0x00132040
	public void PauseStart()
	{
		if (Application.platform != RuntimePlatform.XboxOne)
		{
			return;
		}
		this.pauseType = 0;
		this.canControl = true;
		this.currentlySelected = 0;
		base.StartCoroutine(this.NumerSelectUp());
		for (int i = 0; i < this.nonConsoleObjects.Length; i++)
		{
			this.nonConsoleObjects[i].transform.localPosition = Vector3.up * 9000f;
		}
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x00133CB6 File Offset: 0x001320B6
	public void PauseStop()
	{
		this.canControl = false;
	}

	// Token: 0x06000DB4 RID: 3508 RVA: 0x00133CC0 File Offset: 0x001320C0
	public void Update()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (Application.platform == RuntimePlatform.XboxOne && this.canControl)
		{
			bool keyDown = Input.GetKeyDown(KeyCode.JoystickButton0);
			if (!this.dPadPressed)
			{
				flag = (Input.GetAxisRaw("JoypadDpadY") < 0f);
				flag2 = (Input.GetAxisRaw("JoypadDpadY") > 0f);
				flag3 = (Input.GetAxisRaw("JoypadDpadX") < 0f);
				flag4 = (Input.GetAxisRaw("JoypadDpadX") > 0f);
				keyDown = Input.GetKeyDown(KeyCode.JoystickButton0);
				this.dPadPressed = (keyDown || Mathf.Abs(Input.GetAxisRaw("JoypadDpadY")) > 0f || Mathf.Abs(Input.GetAxisRaw("JoypadDpadX")) > 0f);
			}
			else if (Mathf.Abs(Input.GetAxis("JoypadDpadY")) < 0.5f && Mathf.Abs(Input.GetAxis("JoypadDpadX")) < 0.5f)
			{
				this.dPadPressed = false;
			}
			if (flag || flag2 || flag3 || flag4)
			{
				this.PlaySelect();
			}
			if (flag)
			{
				this.SelectDown();
			}
			if (flag2)
			{
				this.SelectUp();
			}
			if (keyDown)
			{
				this.ClickSelected();
			}
			if (this.pauseType == 1 && this.currentlySelected == 2)
			{
				if (flag3)
				{
					this.optionsButtons[this.currentlySelected].GetComponent<UIScrollBar>().value -= 0.1f;
				}
				if (flag4)
				{
					this.optionsButtons[this.currentlySelected].GetComponent<UIScrollBar>().value += 0.1f;
				}
			}
			if (this.pauseType == 2)
			{
				if (flag3)
				{
					this.currentlySelected = 0;
					this.restartButtons[0].OnHover(true);
					this.restartButtons[1].OnHover(false);
				}
				if (flag4)
				{
					this.currentlySelected = 1;
					this.restartButtons[0].OnHover(false);
					this.restartButtons[1].OnHover(true);
				}
			}
			if (this.pauseType == 3)
			{
				if (flag3)
				{
					this.currentlySelected = 0;
					this.returnButtons[0].OnHover(true);
					this.returnButtons[1].OnHover(false);
				}
				if (flag4)
				{
					this.currentlySelected = 1;
					this.returnButtons[0].OnHover(false);
					this.returnButtons[1].OnHover(true);
				}
			}
			if (this.pauseType == 4)
			{
				if (flag3)
				{
					this.currentlySelected = 0;
					this.saveButtons[0].OnHover(true);
					this.saveButtons[1].OnHover(false);
				}
				if (flag4)
				{
					this.currentlySelected = 1;
					this.saveButtons[0].OnHover(false);
					this.saveButtons[1].OnHover(true);
				}
			}
		}
	}

	// Token: 0x06000DB5 RID: 3509 RVA: 0x00133FA0 File Offset: 0x001323A0
	public void SelectDown()
	{
		if (this.pauseType == 0)
		{
			if (this.currentlySelected != -1)
			{
				this.mainButtons[this.currentlySelected].OnHover(false);
			}
			this.currentlySelected = Mathf.Clamp(this.currentlySelected + 1, 0, this.mainButtons.Length - 1);
			this.mainButtons[this.currentlySelected].OnHover(true);
		}
		if (this.pauseType == 1)
		{
			if (this.currentlySelected != -1)
			{
				this.optionsButtons[this.currentlySelected].OnHover(false);
			}
			this.currentlySelected = Mathf.Clamp(this.currentlySelected + 1, 0, this.optionsButtons.Length - 1);
			this.optionsButtons[this.currentlySelected].OnHover(true);
		}
	}

	// Token: 0x06000DB6 RID: 3510 RVA: 0x00134064 File Offset: 0x00132464
	public void SelectUp()
	{
		if (this.pauseType == 0)
		{
			if (this.currentlySelected != -1)
			{
				this.mainButtons[this.currentlySelected].OnHover(false);
			}
			this.currentlySelected = Mathf.Clamp(this.currentlySelected - 1, 0, this.mainButtons.Length - 1);
			this.mainButtons[this.currentlySelected].OnHover(true);
		}
		if (this.pauseType == 1)
		{
			if (this.currentlySelected != -1)
			{
				this.optionsButtons[this.currentlySelected].OnHover(false);
			}
			this.currentlySelected = Mathf.Clamp(this.currentlySelected - 1, 0, this.optionsButtons.Length - 1);
			this.optionsButtons[this.currentlySelected].OnHover(true);
		}
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x00134128 File Offset: 0x00132528
	public void ClickSelected()
	{
		int num = this.currentlySelected;
		if (this.pauseType == 0)
		{
			this.mainButtons[num].OnClick();
			if (this.currentlySelected == 0)
			{
				for (int i = 0; i < this.nonConsoleObjects.Length; i++)
				{
					this.nonConsoleObjects[i].transform.localPosition = Vector3.up * 9000f;
				}
				this.pauseType = 1;
				this.currentlySelected = 0;
				base.StartCoroutine(this.NumerSelectUp());
			}
			if (this.currentlySelected == 1)
			{
				this.currentlySelected = 0;
				this.pauseType = 2;
				this.restartButtons[0].OnHover(true);
				this.restartButtons[1].OnHover(false);
			}
			if (this.currentlySelected == 2)
			{
				this.currentlySelected = 0;
				this.pauseType = 3;
				this.returnButtons[0].OnHover(true);
				this.returnButtons[1].OnHover(false);
			}
			if (this.currentlySelected == 3)
			{
				this.currentlySelected = 0;
				this.pauseType = 4;
				this.saveButtons[0].OnHover(true);
				this.saveButtons[1].OnHover(false);
			}
			return;
		}
		if (this.pauseType == 1)
		{
			if (num != -1)
			{
				this.optionsButtons[num].OnClick();
			}
			if (this.currentlySelected == 3)
			{
				this.pauseType = 0;
				this.currentlySelected = 0;
				base.StartCoroutine(this.NumerSelectUp());
			}
			if (this.currentlySelected == 4)
			{
				this.pauseType = 0;
				this.currentlySelected = 0;
				base.StartCoroutine(this.NumerSelectUp());
			}
			return;
		}
		if (this.pauseType == 2)
		{
			this.restartButtons[this.currentlySelected].OnClick();
			if (this.currentlySelected == 1)
			{
				this.PauseStart();
			}
			return;
		}
		if (this.pauseType == 3)
		{
			this.returnButtons[this.currentlySelected].OnClick();
			if (this.currentlySelected == 1)
			{
				this.PauseStart();
			}
			return;
		}
		if (this.pauseType == 4)
		{
			this.saveButtons[this.currentlySelected].OnClick();
			if (this.currentlySelected == 1)
			{
				this.PauseStart();
			}
			return;
		}
	}

	// Token: 0x04001255 RID: 4693
	public static XboxPause Global;

	// Token: 0x04001256 RID: 4694
	public UIButton[] mainButtons;

	// Token: 0x04001257 RID: 4695
	public UIButton[] optionsButtons;

	// Token: 0x04001258 RID: 4696
	public UIButton[] restartButtons;

	// Token: 0x04001259 RID: 4697
	public UIButton[] returnButtons;

	// Token: 0x0400125A RID: 4698
	public UIButton[] saveButtons;

	// Token: 0x0400125B RID: 4699
	public GameObject[] nonConsoleObjects;

	// Token: 0x0400125C RID: 4700
	public AudioSource menuSound;

	// Token: 0x0400125D RID: 4701
	private bool dPadPressed;

	// Token: 0x0400125E RID: 4702
	public int currentlySelected = -1;

	// Token: 0x0400125F RID: 4703
	public bool canControl;

	// Token: 0x04001260 RID: 4704
	public int pauseType;
}
