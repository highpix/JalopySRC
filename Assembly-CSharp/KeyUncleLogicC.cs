using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000122 RID: 290
public class KeyUncleLogicC : MonoBehaviour
{
	// Token: 0x06000B54 RID: 2900 RVA: 0x0010731C File Offset: 0x0010571C
	public IEnumerator PickUp()
	{
		this.uncle.GetComponent<Animator>().SetBool("giveItem", false);
		yield return new WaitForSeconds(2f);
		if (this.uncle.GetComponent<Scene1_LogicC>().forceUncleLeave && this.uncle.GetComponent<UncleLogicC>().isSat)
		{
			this.uncle.GetComponent<UncleLogicC>().restrictTalk = true;
			this.uncle.GetComponent<UncleLogicC>().uncleAtHome = true;
			this.uncle.GetComponent<UncleLogicC>().StartCoroutine("DebugExitCar");
		}
		UnityEngine.Object.Destroy(this);
		yield break;
	}

	// Token: 0x04000FD2 RID: 4050
	public GameObject uncle;

	// Token: 0x04000FD3 RID: 4051
	public Transform holdingPosition;
}
