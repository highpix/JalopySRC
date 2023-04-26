using System;
using UnityEngine;

// Token: 0x02000090 RID: 144
public class BootNavRelayC : MonoBehaviour
{
	// Token: 0x06000461 RID: 1121 RVA: 0x0004960D File Offset: 0x00047A0D
	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "BorderGuard")
		{
			col.transform.parent.SendMessage("GuardArrivedAtBoot");
		}
	}
}
