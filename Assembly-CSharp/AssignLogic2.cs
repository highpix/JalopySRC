using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class AssignLogic2 : MonoBehaviour
{
	// Token: 0x06000011 RID: 17 RVA: 0x00002B78 File Offset: 0x00000F78
	[ContextMenu("Do")]
	private void DebugDo()
	{
		base.transform.GetChild(0).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(0).GetComponent<PageLogicC>().DebugDo();
		base.transform.GetChild(1).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(2).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(2).GetComponent<PageLogicC>().DebugDo();
		base.transform.GetChild(3).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(3).GetComponent<PageLogicC>().DebugDo();
		base.transform.GetChild(5).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(5).GetComponent<PageLogicC>().DebugDo();
		base.transform.GetChild(7).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(7).GetComponent<PageLogicC>().DebugDo();
		base.transform.GetChild(9).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(9).GetComponent<PageLogicC>().DebugDo();
		base.transform.GetChild(11).GetComponent<PageLogicC>().magazine = base.transform.parent.gameObject;
		base.transform.GetChild(11).GetComponent<PageLogicC>().DebugDo();
	}
}
