using System;
using UnityEngine;

// Token: 0x020000D4 RID: 212
public class MotelRelayC : MonoBehaviour
{
	// Token: 0x0600085D RID: 2141 RVA: 0x000AD958 File Offset: 0x000ABD58
	public void PickUp()
	{
		this.shopKeeper.GetComponent<Animator>().SetBool("KeyWasTaken", true);
		this.shopKeeper.transform.parent.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x04000B0C RID: 2828
	public GameObject shopKeeper;
}
