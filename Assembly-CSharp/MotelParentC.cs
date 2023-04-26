using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class MotelParentC : MonoBehaviour
{
	// Token: 0x06000858 RID: 2136 RVA: 0x000AD84E File Offset: 0x000ABC4E
	public void WakeUpInTown()
	{
		this.motelLogic.GetComponent<MotelLogicC>().WakeUpInTown();
	}

	// Token: 0x04000B0A RID: 2826
	public GameObject motelLogic;
}
