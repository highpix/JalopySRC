using System;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class MotelParkingTriggerC : MonoBehaviour
{
	// Token: 0x0600085A RID: 2138 RVA: 0x000AD868 File Offset: 0x000ABC68
	public void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "CarLogic" || collider.tag == "CarInteractor")
		{
			if (this.isMorning)
			{
				base.transform.parent.GetComponent<MotelLogicC>().CarEnterMorning();
			}
			else
			{
				base.transform.parent.GetComponent<MotelLogicC>().CarEnter();
			}
		}
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x000AD8DC File Offset: 0x000ABCDC
	public void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "CarLogic" || collider.tag == "CarInteractor")
		{
			if (this.isMorning)
			{
				base.transform.parent.GetComponent<MotelLogicC>().CarExitMorning();
			}
			else
			{
				base.transform.parent.GetComponent<MotelLogicC>().CarExit();
			}
		}
	}

	// Token: 0x04000B0B RID: 2827
	public bool isMorning;
}
