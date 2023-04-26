using System;
using UnityEngine;

// Token: 0x02000125 RID: 293
public class RouteConvoRelayC : MonoBehaviour
{
	// Token: 0x06000B5A RID: 2906 RVA: 0x0010764C File Offset: 0x00105A4C
	private void OnTriggerEnter(Collider car)
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (gameObject.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			return;
		}
		if (car.tag == "CarInteractor" && !this.hasFired)
		{
			GameObject gameObject2 = GameObject.FindWithTag("Uncle");
			gameObject2.GetComponent<UncleLogicC>().RouteDialogueChecks();
			this.hasFired = true;
		}
	}

	// Token: 0x04000FD6 RID: 4054
	private bool hasFired;
}
