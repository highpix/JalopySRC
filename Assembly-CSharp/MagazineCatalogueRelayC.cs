using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000C3 RID: 195
public class MagazineCatalogueRelayC : MonoBehaviour
{
	// Token: 0x06000717 RID: 1815 RVA: 0x0008CA50 File Offset: 0x0008AE50
	private void Reset()
	{
		MagazineCatalogueRelay component = base.GetComponent<MagazineCatalogueRelay>();
		this.pageMama = component.pageMama;
		this.componentNumber = component.componentNumber;
		component.scale.Copy(ref this.scale);
		component.otherShits.Copy(ref this.otherShits);
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x0008CAA4 File Offset: 0x0008AEA4
	public void Trigger()
	{
		for (int i = 0; i < this.otherShits.Length; i++)
		{
			if (this.otherShits[i] != base.gameObject)
			{
				this.otherShits[i].GetComponent<MagazineCatalogueRelayC>().isSelected = false;
				this.otherShits[i].GetComponent<MagazineCatalogueRelayC>().RaycastExit();
			}
		}
		this.pageMama.GetComponent<EngineComponentsCataloguePageC>().ComponentGo(this.componentNumber);
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x0008CB20 File Offset: 0x0008AF20
	private IEnumerator ScaleDown()
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

	// Token: 0x0600071A RID: 1818 RVA: 0x0008CB3B File Offset: 0x0008AF3B
	public void RaycastEnter()
	{
		if (!this.isSelected)
		{
			base.transform.localScale = this.scale[1];
		}
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x0008CB64 File Offset: 0x0008AF64
	public void RaycastExit()
	{
		if (!this.isSelected)
		{
			base.transform.localScale = this.scale[0];
		}
	}

	// Token: 0x04000997 RID: 2455
	public GameObject pageMama;

	// Token: 0x04000998 RID: 2456
	public int componentNumber;

	// Token: 0x04000999 RID: 2457
	public Vector3[] scale;

	// Token: 0x0400099A RID: 2458
	public GameObject[] otherShits;

	// Token: 0x0400099B RID: 2459
	private bool isSelected;
}
