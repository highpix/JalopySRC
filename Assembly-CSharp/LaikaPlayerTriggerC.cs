using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class LaikaPlayerTriggerC : MonoBehaviour
{
	// Token: 0x060006EF RID: 1775 RVA: 0x0008A533 File Offset: 0x00088933
	public void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			base.transform.parent.GetComponent<LaikaBuildingC>().PlayerTriggerEnter();
		}
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x0008A55F File Offset: 0x0008895F
	public void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player")
		{
			base.transform.parent.GetComponent<LaikaBuildingC>().PlayerTriggerExit();
		}
	}
}
