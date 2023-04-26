using System;
using UnityEngine;

// Token: 0x0200005B RID: 91
public class OpenURLOnClick : MonoBehaviour
{
	// Token: 0x060001B0 RID: 432 RVA: 0x000184C8 File Offset: 0x000168C8
	private void OnClick()
	{
		UILabel component = base.GetComponent<UILabel>();
		if (component != null)
		{
			string urlAtPosition = component.GetUrlAtPosition(UICamera.lastWorldPosition);
			if (!string.IsNullOrEmpty(urlAtPosition))
			{
				Application.OpenURL(urlAtPosition);
			}
		}
	}
}
