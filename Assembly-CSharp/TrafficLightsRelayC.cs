using System;
using UnityEngine;

// Token: 0x02000120 RID: 288
public class TrafficLightsRelayC : MonoBehaviour
{
	// Token: 0x06000B3F RID: 2879 RVA: 0x00105DD8 File Offset: 0x001041D8
	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "CarInteractor")
		{
			if (this.isResetTrigg && this.isRed)
			{
				this.trafficBoss.GetComponent<TrafficLightManagerC>().StartCoroutine("LightChange");
				return;
			}
			if (!this.isResetTrigg)
			{
				this.trafficBoss.GetComponent<TrafficLightManagerC>().StartCoroutine("PenaltyCheck");
			}
		}
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x00105E4D File Offset: 0x0010424D
	public void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "CarInteractor" && this.isRed)
		{
			this.trafficBoss.GetComponent<TrafficLightManagerC>().StartCoroutine("ExitedRed");
		}
	}

	// Token: 0x04000FC0 RID: 4032
	public GameObject trafficBoss;

	// Token: 0x04000FC1 RID: 4033
	public GameObject[] allLights = new GameObject[0];

	// Token: 0x04000FC2 RID: 4034
	public bool isResetTrigg;

	// Token: 0x04000FC3 RID: 4035
	public bool isRed;
}
