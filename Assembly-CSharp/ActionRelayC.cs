using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class ActionRelayC : MonoBehaviour
{
	// Token: 0x0600000A RID: 10 RVA: 0x000023A3 File Offset: 0x000007A3
	public void Trigger()
	{
		this.relayTarget.SendMessage("ActionRelay");
	}

	// Token: 0x0400000C RID: 12
	public GameObject relayTarget;
}
