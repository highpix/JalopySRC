using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000124 RID: 292
public class MapUncleLogicC : MonoBehaviour
{
	// Token: 0x06000B58 RID: 2904 RVA: 0x0010755C File Offset: 0x0010595C
	public IEnumerator PickUp()
	{
		this.uncle.GetComponent<Scene1_LogicC>().StartCoroutine("MapPickedUpTutorial");
		this.uncle.GetComponent<Animator>().SetBool("giveItem", false);
		yield return new WaitForSeconds(2f);
		UnityEngine.Object.Destroy(this);
		yield break;
	}

	// Token: 0x04000FD5 RID: 4053
	public GameObject uncle;
}
