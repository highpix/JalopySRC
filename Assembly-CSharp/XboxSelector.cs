using System;
using UnityEngine;

// Token: 0x02000169 RID: 361
public class XboxSelector : MonoBehaviour
{
	// Token: 0x06000DBC RID: 3516 RVA: 0x001344D3 File Offset: 0x001328D3
	private void OnEnable()
	{
		this.SelectID(0, 0);
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x001344E0 File Offset: 0x001328E0
	public void SelectID(int ID, int selectID)
	{
		for (int i = 0; i < this.chosenList.Length; i++)
		{
			this.chosenList[i].RaycastExit();
		}
		for (int j = 0; j < this.chosenList2.Length; j++)
		{
			this.chosenList2[j].RaycastExit();
		}
		if (selectID == 0)
		{
			ID = Mathf.Clamp(ID, 0, this.chosenList.Length - 1);
			while (!this.chosenList[ID].gameObject.activeInHierarchy)
			{
				ID--;
			}
			this.cursorSelector.localScale = new Vector3(0.1100172f, 0.1100172f, 0.1100172f);
			this.cursorSelector.localEulerAngles = Vector3.forward * 18.23316f;
			this.cursorSelector.localPosition = new Vector3(0.1668f, this.chosenList[ID].transform.localPosition.y, 0.007f);
			this.chosenList[ID].RaycastEnter();
		}
		if (selectID == 1)
		{
			ID = Mathf.Clamp(ID, 0, this.chosenList2.Length - 1);
			while (!this.chosenList2[ID].gameObject.activeInHierarchy)
			{
				ID--;
			}
			this.cursorSelector.localScale = new Vector3(-0.1100172f, 0.1100172f, 0.1100172f);
			this.cursorSelector.localEulerAngles = Vector3.forward * -11.08142f;
			this.cursorSelector.localPosition = new Vector3(-0.1535f, this.chosenList2[ID].transform.localPosition.y - 0.013f, 0.007f);
			this.chosenList2[ID].RaycastEnter();
		}
		this.currentChoice = ID;
		this.currentType = selectID;
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x001346B6 File Offset: 0x00132AB6
	public void PlaySelect()
	{
		this.menuSound.Play();
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x001346C3 File Offset: 0x00132AC3
	private void Awake()
	{
		if (Application.platform != RuntimePlatform.XboxOne)
		{
			this.cursorSelector.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x001346E4 File Offset: 0x00132AE4
	public void Update()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			flag = Input.GetKeyDown(KeyCode.JoystickButton0);
			if (!this.dPadPressed)
			{
				flag2 = (Input.GetAxisRaw("JoypadDpadY") < 0f);
				flag3 = (Input.GetAxisRaw("JoypadDpadY") > 0f);
				flag4 = (Input.GetAxisRaw("JoypadDpadX") < 0f);
				flag5 = (Input.GetAxisRaw("JoypadDpadX") > 0f);
				this.dPadPressed = (Mathf.Abs(Input.GetAxisRaw("JoypadDpadY")) > 0f || Mathf.Abs(Input.GetAxisRaw("JoypadDpadX")) > 0f);
			}
			else if (Mathf.Abs(Input.GetAxis("JoypadDpadY")) < 0.5f && Mathf.Abs(Input.GetAxis("JoypadDpadX")) < 0.5f)
			{
				this.dPadPressed = false;
			}
			if (flag2 || flag3 || flag4 || flag5)
			{
				this.PlaySelect();
			}
		}
		if (flag)
		{
			if (this.currentType == 0)
			{
				this.chosenList[this.currentChoice].Trigger();
			}
			if (this.currentType == 1)
			{
				this.chosenList2[this.currentChoice].Trigger();
				this.SelectID(0, 0);
			}
		}
		if (flag2)
		{
			this.SelectID(this.currentChoice + 1, this.currentType);
		}
		if (flag3)
		{
			this.SelectID(this.currentChoice - 1, this.currentType);
		}
		if (flag4)
		{
			this.SelectID(0, 0);
		}
		if (flag5)
		{
			this.SelectID(0, 1);
		}
	}

	// Token: 0x04001265 RID: 4709
	public CataloguePagePurchaseRelayC[] chosenList;

	// Token: 0x04001266 RID: 4710
	public MagazineCatalogueRelayC[] chosenList2;

	// Token: 0x04001267 RID: 4711
	public int currentChoice = -1;

	// Token: 0x04001268 RID: 4712
	public int currentType = -1;

	// Token: 0x04001269 RID: 4713
	public Transform cursorSelector;

	// Token: 0x0400126A RID: 4714
	private bool dPadPressed;

	// Token: 0x0400126B RID: 4715
	public AudioSource menuSound;
}
