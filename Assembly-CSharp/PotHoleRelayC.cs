using System;
using UnityEngine;

// Token: 0x020000E8 RID: 232
public class PotHoleRelayC : MonoBehaviour
{
	// Token: 0x06000905 RID: 2309 RVA: 0x000C23B4 File Offset: 0x000C07B4
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wheel")
		{
			if (other.gameObject.name == "FL_Wheel")
			{
				other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarPerformanceC>().PotHoleHitFLWheel();
			}
			else if (other.gameObject.name == "FR_Wheel")
			{
				other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarPerformanceC>().PotHoleHitFRWheel();
			}
			else if (other.gameObject.name == "RL_Wheel")
			{
				other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarPerformanceC>().PotHoleHitRLWheel();
			}
			else if (other.gameObject.name == "RR_Wheel")
			{
				other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarPerformanceC>().PotHoleHitRRWheel();
			}
		}
	}
}
