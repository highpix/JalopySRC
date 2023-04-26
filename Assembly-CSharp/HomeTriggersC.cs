using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class HomeTriggersC : MonoBehaviour
{
	// Token: 0x060006AF RID: 1711 RVA: 0x00085C1A File Offset: 0x0008401A
	private void OnEnable()
	{
		base.gameObject.layer = 0;
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x00085C28 File Offset: 0x00084028
	public void OnTriggerEnter()
	{
		if (this.sparePartsCabinet)
		{
			this.target.GetComponent<Animator>().SetTrigger("Open");
			this.target.GetComponent<BoxCollider>().enabled = false;
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (this.fuelCabinet)
		{
			this.target.GetComponent<BreadBinDoorC>().isLocked = false;
			this.target.GetComponent<BreadBinDoorC>().StartCoroutine("Trigger");
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (this.tyreCabinet)
		{
			this.target.GetComponent<BreadBinDoorC>().isLocked = false;
			this.target.GetComponent<BreadBinDoorC>().StartCoroutine("Trigger");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x00085CF8 File Offset: 0x000840F8
	public void ForceTrigger()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (gameObject.GetComponent<RouteGeneratorC>().routeLevel != 0)
		{
			return;
		}
		if (this.sparePartsCabinet)
		{
			this.target.GetComponent<Animator>().SetTrigger("Open");
			this.target.GetComponent<BoxCollider>().enabled = false;
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (this.fuelCabinet)
		{
			this.target.GetComponent<BreadBinDoorC>().isLocked = false;
			this.target.GetComponent<BreadBinDoorC>().StartCoroutine("Trigger");
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (this.tyreCabinet)
		{
			this.target.GetComponent<BreadBinDoorC>().isLocked = false;
			this.target.GetComponent<BreadBinDoorC>().StartCoroutine("Trigger");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040008F6 RID: 2294
	public bool sparePartsCabinet;

	// Token: 0x040008F7 RID: 2295
	public bool fuelCabinet;

	// Token: 0x040008F8 RID: 2296
	public bool tyreCabinet;

	// Token: 0x040008F9 RID: 2297
	public GameObject target;
}
