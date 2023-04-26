using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000123 RID: 291
public class MaintManUncleLogicC : MonoBehaviour
{
	// Token: 0x06000B56 RID: 2902 RVA: 0x0010746C File Offset: 0x0010586C
	public IEnumerator PickUp()
	{
		this.uncle.GetComponent<Animator>().SetBool("giveItem", false);
		this.uncle.GetComponent<Scene1_LogicC>().StartCoroutine("ManualPickedUp");
		yield return new WaitForSeconds(2f);
		UnityEngine.Object.Destroy(this);
		yield break;
	}

	// Token: 0x04000FD4 RID: 4052
	public GameObject uncle;
}
