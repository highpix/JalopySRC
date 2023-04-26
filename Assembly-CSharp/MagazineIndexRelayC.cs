using System;
using UnityEngine;

// Token: 0x020000C4 RID: 196
public class MagazineIndexRelayC : MonoBehaviour
{
	// Token: 0x0600071D RID: 1821 RVA: 0x0008CC84 File Offset: 0x0008B084
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		MagazineIndexRelay component = base.GetComponent<MagazineIndexRelay>();
		this.magazine = (component.magazine as GameObject);
		this.pageNumber = component.pageNumber;
		component.scale.Copy(ref this.scale);
		component.enabled = false;
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x0008CCD8 File Offset: 0x0008B0D8
	public void RaycastEnter()
	{
		base.transform.localScale = this.scale[1];
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x0008CCF6 File Offset: 0x0008B0F6
	public void Trigger()
	{
		this.magazine.GetComponent<MagazineLogicC>().TurnToPage(this.pageNumber);
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x0008CD0E File Offset: 0x0008B10E
	public void RaycastExit()
	{
		base.transform.localScale = this.scale[0];
	}

	// Token: 0x0400099C RID: 2460
	public GameObject magazine;

	// Token: 0x0400099D RID: 2461
	public int pageNumber;

	// Token: 0x0400099E RID: 2462
	public Vector3[] scale;
}
