using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class AssignDebug : MonoBehaviour
{
	// Token: 0x0600000F RID: 15 RVA: 0x000024C0 File Offset: 0x000008C0
	[ContextMenu("Do")]
	private void DebugDo()
	{
		base.transform.GetChild(0).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(16).gameObject;
		base.transform.GetChild(1).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(11).gameObject;
		base.transform.GetChild(2).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(17).gameObject;
		base.transform.GetChild(3).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(15).gameObject;
		base.transform.GetChild(4).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(12).gameObject;
		base.transform.GetChild(5).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(13).gameObject;
		base.transform.GetChild(6).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(19).gameObject;
		base.transform.GetChild(7).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(20).gameObject;
		base.transform.GetChild(8).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(18).gameObject;
		base.transform.GetChild(9).GetComponent<PageLogicC>().pageReturner = base.transform.GetChild(14).gameObject;
		base.transform.GetChild(0).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(1).gameObject;
		base.transform.GetChild(1).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(2).gameObject;
		base.transform.GetChild(2).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(3).gameObject;
		base.transform.GetChild(3).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(4).gameObject;
		base.transform.GetChild(4).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(5).gameObject;
		base.transform.GetChild(5).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(6).gameObject;
		base.transform.GetChild(6).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(7).gameObject;
		base.transform.GetChild(7).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(8).gameObject;
		base.transform.GetChild(8).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(9).gameObject;
		base.transform.GetChild(9).GetComponent<PageLogicC>().pageTurner.GetComponent<PageTurnerC>().nextPage = base.transform.GetChild(10).gameObject;
		base.transform.GetChild(16).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(1).gameObject;
		base.transform.GetChild(11).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(2).gameObject;
		base.transform.GetChild(17).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(3).gameObject;
		base.transform.GetChild(15).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(4).gameObject;
		base.transform.GetChild(12).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(5).gameObject;
		base.transform.GetChild(13).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(6).gameObject;
		base.transform.GetChild(19).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(7).gameObject;
		base.transform.GetChild(20).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(8).gameObject;
		base.transform.GetChild(18).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(9).gameObject;
		base.transform.GetChild(14).GetComponent<PageReturnerC>().parentPage = base.transform.GetChild(10).gameObject;
		base.transform.GetChild(16).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(0).gameObject;
		base.transform.GetChild(11).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(1).gameObject;
		base.transform.GetChild(17).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(2).gameObject;
		base.transform.GetChild(15).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(3).gameObject;
		base.transform.GetChild(12).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(4).gameObject;
		base.transform.GetChild(13).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(5).gameObject;
		base.transform.GetChild(19).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(6).gameObject;
		base.transform.GetChild(20).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(7).gameObject;
		base.transform.GetChild(18).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(8).gameObject;
		base.transform.GetChild(14).GetComponent<PageReturnerC>().returnPage = base.transform.GetChild(9).gameObject;
	}
}
