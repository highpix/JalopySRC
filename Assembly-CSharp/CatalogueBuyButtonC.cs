using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class CatalogueBuyButtonC : MonoBehaviour
{
	// Token: 0x06000515 RID: 1301 RVA: 0x00057A98 File Offset: 0x00055E98
	public void Trigger()
	{
		base.transform.localScale = this.scale[2];
		base.StartCoroutine("Rescale");
		if (!this.cancelTransaction)
		{
			this.pageLogic.SendMessage("PurchaseGo");
		}
		else
		{
			this.pageLogic.SendMessage("ClearShoppingList");
		}
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00057B00 File Offset: 0x00055F00
	private IEnumerator Rescale()
	{
		yield return new WaitForSeconds(0.2f);
		if (this.isSelected)
		{
			base.transform.localScale = this.scale[1];
		}
		else
		{
			base.transform.localScale = this.scale[0];
		}
		yield break;
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x00057B1B File Offset: 0x00055F1B
	public void RaycastEnter()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[1];
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x00057B40 File Offset: 0x00055F40
	public void RaycastExit()
	{
		this.isSelected = false;
		base.StopCoroutine("Rescale");
		base.transform.localScale = this.scale[0];
	}

	// Token: 0x0400078E RID: 1934
	public GameObject pageLogic;

	// Token: 0x0400078F RID: 1935
	public Vector3[] scale = new Vector3[0];

	// Token: 0x04000790 RID: 1936
	public bool cancelTransaction;

	// Token: 0x04000791 RID: 1937
	private bool isSelected;
}
