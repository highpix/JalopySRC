using System;
using UnityEngine;

// Token: 0x02000136 RID: 310
public class SceneReset : MonoBehaviour
{
	// Token: 0x06000C74 RID: 3188 RVA: 0x0012BE74 File Offset: 0x0012A274
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "AI")
		{
			Application.LoadLevel(0);
		}
	}
}
