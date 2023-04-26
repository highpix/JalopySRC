using System;
using UnityEngine;

// Token: 0x02000164 RID: 356
public class XboxEngineMagazine : MonoBehaviour
{
	// Token: 0x06000D95 RID: 3477 RVA: 0x00132C90 File Offset: 0x00131090
	private void Update()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			if (!this.dPadPressed)
			{
				flag = (Input.GetAxisRaw("JoypadDpadY") < 0f);
				flag2 = (Input.GetAxisRaw("JoypadDpadY") > 0f);
				this.dPadPressed = (Mathf.Abs(Input.GetAxisRaw("JoypadDpadY")) > 0f || Mathf.Abs(Input.GetAxisRaw("JoypadDpadX")) > 0f);
			}
			else if (Mathf.Abs(Input.GetAxis("JoypadDpadY")) < 0.5f && Mathf.Abs(Input.GetAxis("JoypadDpadX")) < 0.5f)
			{
				this.dPadPressed = false;
			}
			if (flag)
			{
				this.PressDown();
			}
			if (flag2)
			{
				this.PressUp();
			}
		}
	}

	// Token: 0x06000D96 RID: 3478 RVA: 0x00132D7C File Offset: 0x0013117C
	private void OnEnable()
	{
		for (int i = 0; i < this.items.Length; i++)
		{
			this.items[i].RaycastExit();
		}
		this.currentChoice = 0;
		base.Invoke("PressDown", 0.3f);
		base.Invoke("PressDown", 0.6f);
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x00132DD8 File Offset: 0x001311D8
	private void PressDown()
	{
		if (this.currentChoice < this.items.Length && this.currentChoice > -1)
		{
			this.items[this.currentChoice].RaycastExit();
		}
		this.currentChoice++;
		if (this.currentChoice > this.items.Length - 1)
		{
			this.currentChoice = 0;
		}
		this.items[this.currentChoice].RaycastEnter();
		this.items[this.currentChoice].Trigger();
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x00132E64 File Offset: 0x00131264
	private void PressUp()
	{
		if (this.currentChoice < this.items.Length && this.currentChoice > -1)
		{
			this.items[this.currentChoice].RaycastExit();
		}
		this.currentChoice--;
		if (this.currentChoice < 0)
		{
			this.currentChoice = this.items.Length - 1;
		}
		this.items[this.currentChoice].RaycastEnter();
		this.items[this.currentChoice].Trigger();
	}

	// Token: 0x04001232 RID: 4658
	public int currentChoice;

	// Token: 0x04001233 RID: 4659
	public MagazineComponentRelayC[] items;

	// Token: 0x04001234 RID: 4660
	private bool dPadPressed;
}
