using System;
using TMPro;
using UnityEngine;

// Token: 0x02000156 RID: 342
public class UpdateText : MonoBehaviour
{
	// Token: 0x06000D50 RID: 3408 RVA: 0x0012FA10 File Offset: 0x0012DE10
	private void Start()
	{
		base.GetComponent<TextMeshPro>().enabled = true;
		TextMeshPro component = base.GetComponent<TextMeshPro>();
		component.text += ".";
	}

	// Token: 0x040011CD RID: 4557
	public string text;
}
