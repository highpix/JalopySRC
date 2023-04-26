using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000095 RID: 149
public class BuyHomeStorageC : MonoBehaviour
{
	// Token: 0x060004AB RID: 1195 RVA: 0x0004ED88 File Offset: 0x0004D188
	public void Trigger()
	{
		this.priceBackdrop.transform.parent.localScale = this.scale[2];
		base.StartCoroutine(this.Rescale());
		HomeStorageClipboardC component = base.transform.parent.GetComponent<HomeStorageClipboardC>();
		int num = component.currentStorage + component.storageOrder;
		if (num >= component.storageMax)
		{
			component.Error();
			return;
		}
		component.AddStorageOrder();
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0004EE00 File Offset: 0x0004D200
	private void Update()
	{
		if (this.isSelected)
		{
			this.priceBackdrop.Rotate(0f, 0f, this.priceBackdropRotAmt * Time.deltaTime, Space.Self);
		}
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x0004EE30 File Offset: 0x0004D230
	public IEnumerator Rescale()
	{
		yield return new WaitForSeconds(0.2f);
		if (this.isSelected)
		{
			this.priceBackdrop.transform.parent.localScale = this.scale[1];
		}
		else
		{
			this.priceBackdrop.transform.parent.localScale = this.scale[0];
		}
		yield break;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x0004EE4B File Offset: 0x0004D24B
	public void RaycastEnter()
	{
		this.isSelected = true;
		this.priceBackdrop.transform.parent.localScale = this.scale[1];
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0004EE7A File Offset: 0x0004D27A
	public void RaycastExit()
	{
		base.StopCoroutine("Rescale");
		this.isSelected = false;
		this.priceBackdrop.transform.parent.localScale = this.scale[0];
	}

	// Token: 0x040006CB RID: 1739
	public bool isSelected;

	// Token: 0x040006CC RID: 1740
	public Vector3[] scale;

	// Token: 0x040006CD RID: 1741
	public Transform priceBackdrop;

	// Token: 0x040006CE RID: 1742
	public float priceBackdropRotAmt;
}
