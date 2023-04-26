using System;
using UnityEngine;

// Token: 0x020000E1 RID: 225
public class PageReturnerC : MonoBehaviour
{
	// Token: 0x060008D6 RID: 2262 RVA: 0x000BEDCE File Offset: 0x000BD1CE
	private void Start()
	{
		if (this.xboxPrompt)
		{
			this.xboxPrompt.SetActive(Application.platform == RuntimePlatform.XboxOne);
		}
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x000BEDF4 File Offset: 0x000BD1F4
	public void Trigger()
	{
		this.returnPage.GetComponent<Animator>().SetBool("isPageTurned", false);
		this.returnPage.GetComponent<Animator>().SetBool("isHoverReturn", false);
		this.parentPage.gameObject.GetComponent<PageLogicC>().ReturnPage();
		base.gameObject.active = false;
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x000BEE4E File Offset: 0x000BD24E
	private void Update()
	{
		if (base.gameObject.activeInHierarchy && Application.platform == RuntimePlatform.XboxOne && Input.GetKeyDown(KeyCode.JoystickButton4))
		{
			this.Trigger();
		}
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000BEE81 File Offset: 0x000BD281
	public void RaycastEnter()
	{
		this.returnPage.GetComponent<Animator>().SetBool("isHoverReturn", true);
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x000BEE99 File Offset: 0x000BD299
	public void RaycastExit()
	{
		this.returnPage.GetComponent<Animator>().SetBool("isHoverReturn", false);
	}

	// Token: 0x04000BC7 RID: 3015
	public GameObject returnPage;

	// Token: 0x04000BC8 RID: 3016
	public GameObject parentPage;

	// Token: 0x04000BC9 RID: 3017
	public GameObject xboxPrompt;
}
