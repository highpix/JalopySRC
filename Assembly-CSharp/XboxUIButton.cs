using System;
using UnityEngine;

// Token: 0x0200016A RID: 362
public class XboxUIButton : MonoBehaviour
{
	// Token: 0x06000DC2 RID: 3522 RVA: 0x0013489E File Offset: 0x00132C9E
	private void Start()
	{
		this.xboxButton.SetActive(Application.platform == RuntimePlatform.XboxOne);
		if (Application.platform != RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x001348C8 File Offset: 0x00132CC8
	private void Update()
	{
		if (base.gameObject.activeInHierarchy && Input.GetKeyDown(this.whichKey))
		{
			if (base.GetComponent<UIButton>())
			{
				base.GetComponent<UIButton>().OnClick();
			}
			if (base.GetComponent<CatalogueBuyButtonC>())
			{
				base.GetComponent<CatalogueBuyButtonC>().Trigger();
			}
			if (base.GetComponent<BuyHomeStorageC>())
			{
				base.GetComponent<BuyHomeStorageC>().Trigger();
			}
		}
	}

	// Token: 0x0400126C RID: 4716
	public GameObject xboxButton;

	// Token: 0x0400126D RID: 4717
	public KeyCode whichKey;
}
