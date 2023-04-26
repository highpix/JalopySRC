using System;
using UnityEngine;

// Token: 0x0200009E RID: 158
public class CloseBorderC : MonoBehaviour
{
	// Token: 0x06000522 RID: 1314 RVA: 0x00058044 File Offset: 0x00056444
	public void OnTriggerEnter(Collider col)
	{
		if (base.transform.parent.GetComponent<BorderLogicC>().borderCrossed && col.gameObject.tag == "CarLogic")
		{
			base.transform.parent.GetComponent<BorderLogicC>().CloseGate();
		}
	}
}
