using System;
using UnityEngine;

// Token: 0x020000B0 RID: 176
public class QuitScript : MonoBehaviour
{
	// Token: 0x06000680 RID: 1664 RVA: 0x00083179 File Offset: 0x00081579
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
			return;
		}
	}
}
