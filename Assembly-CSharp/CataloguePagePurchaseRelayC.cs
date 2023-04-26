using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x0200009D RID: 157
public class CataloguePagePurchaseRelayC : MonoBehaviour
{
	// Token: 0x0600051A RID: 1306 RVA: 0x00057C64 File Offset: 0x00056064
	private void Reset()
	{
		CataloguePagePurchaseRelay component = base.GetComponent<CataloguePagePurchaseRelay>();
		this.pageObject = component.pageObject;
		this.state = component.state;
		this.isSelected = component.isSelected;
		this.buttonID = component.buttonID;
		this.descObj = component.descObj;
		component.scale.Copy(ref this.scale);
		this.priceBackdrop = component.priceBackdrop;
		this.priceBackdropRotAmt = component.priceBackdropRotAmt;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00057CE4 File Offset: 0x000560E4
	public void Trigger()
	{
		base.transform.localScale = this.scale[2];
		base.StartCoroutine("Rescale");
		EngineComponentsCataloguePageC component = base.transform.parent.GetComponent<EngineComponentsCataloguePageC>();
		if (component.shoppingList.Count >= 6)
		{
			component.Error();
			return;
		}
		if (component.engNumHolder == 148)
		{
			component.AddToShoppingListExtras(this.buttonID);
		}
		else if (component.engNumHolder == 151)
		{
			component.AddToShoppingListPaintDecals(this.buttonID);
		}
		else
		{
			component.AddToShoppingList(component.prefabs[this.state]);
		}
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00057D9C File Offset: 0x0005619C
	public void UpdateState()
	{
		if (this.descObj != null)
		{
			this.descObj.GetComponent<TextMeshPro>().text = Language.Get(this.pageObject.GetComponent<EngineComponentsCataloguePageC>().prefabs[this.state].GetComponent<EngineComponentC>().flavourText, "Inspector_UI");
		}
		this.priceBackdrop.transform.parent.gameObject.GetComponent<TextMeshPro>().text = this.pageObject.GetComponent<EngineComponentsCataloguePageC>().prefabs[this.state].GetComponent<ObjectPickupC>().buyValue.ToString();
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00057E48 File Offset: 0x00056248
	private void Update()
	{
		if (this.isSelected)
		{
			this.priceBackdrop.Rotate(0f, 0f, this.priceBackdropRotAmt * Time.deltaTime, Space.Self);
		}
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00057E78 File Offset: 0x00056278
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

	// Token: 0x0600051F RID: 1311 RVA: 0x00057E94 File Offset: 0x00056294
	public void RaycastEnter()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[1];
		this.priceBackdrop.transform.parent.localScale = this.scale[4];
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x00057EEC File Offset: 0x000562EC
	public void RaycastExit()
	{
		base.StopCoroutine("Rescale");
		this.isSelected = false;
		base.transform.localScale = this.scale[0];
		this.priceBackdrop.transform.parent.localScale = this.scale[3];
	}

	// Token: 0x04000792 RID: 1938
	public GameObject pageObject;

	// Token: 0x04000793 RID: 1939
	public int state;

	// Token: 0x04000794 RID: 1940
	public bool isSelected;

	// Token: 0x04000795 RID: 1941
	public int buttonID;

	// Token: 0x04000796 RID: 1942
	public GameObject descObj;

	// Token: 0x04000797 RID: 1943
	public Vector3[] scale;

	// Token: 0x04000798 RID: 1944
	public Transform priceBackdrop;

	// Token: 0x04000799 RID: 1945
	public float priceBackdropRotAmt;
}
