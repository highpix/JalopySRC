using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class PetrolStationDistanceCheckC : MonoBehaviour
{
	// Token: 0x060008EB RID: 2283 RVA: 0x000BFA80 File Offset: 0x000BDE80
	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "CarLogic")
		{
			col.GetComponent<CarLogicC>().uncle.GetComponent<UncleLogicC>().PetrolStationSign();
		}
	}
}
