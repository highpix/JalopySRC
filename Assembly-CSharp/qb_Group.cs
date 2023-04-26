using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
public class qb_Group : MonoBehaviour
{
	// Token: 0x060001CE RID: 462 RVA: 0x00018F85 File Offset: 0x00017385
	public void AddObject(GameObject newObject)
	{
		newObject.transform.parent = base.transform;
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00018F98 File Offset: 0x00017398
	public void Hide()
	{
		this.visible = false;
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00018FA1 File Offset: 0x000173A1
	public void Show()
	{
		this.visible = true;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00018FAA File Offset: 0x000173AA
	public void Freeze()
	{
		this.frozen = true;
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00018FB3 File Offset: 0x000173B3
	public void UnFreeze()
	{
		this.frozen = false;
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00018FBC File Offset: 0x000173BC
	public void CleanUp()
	{
		UnityEngine.Object.DestroyImmediate(base.gameObject);
	}

	// Token: 0x0400030B RID: 779
	public string groupName;

	// Token: 0x0400030C RID: 780
	private bool visible;

	// Token: 0x0400030D RID: 781
	private bool frozen;
}
