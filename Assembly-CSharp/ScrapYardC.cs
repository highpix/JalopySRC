using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000F6 RID: 246
public class ScrapYardC : MonoBehaviour
{
	// Token: 0x060009A0 RID: 2464 RVA: 0x000E3865 File Offset: 0x000E1C65
	private void Start()
	{
		this.SetParents();
		this.DefineLockSystem();
		this.SpawnJunk();
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x000E387C File Offset: 0x000E1C7C
	public void SpawnJunk()
	{
		int num = UnityEngine.Random.Range(2, 4);
		for (int i = 0; i < num; i++)
		{
			int index = UnityEngine.Random.Range(0, this.spawnLocs.Count);
			int index2 = UnityEngine.Random.Range(0, this.spawnCatalogue.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnCatalogue[index2], this.spawnLocs[index].position, this.spawnLocs[index].rotation);
			gameObject.GetComponent<ObjectPickupC>().isPurchased = true;
			gameObject.name = this.spawnCatalogue[index2].name;
			float condition = UnityEngine.Random.Range(0f, 1f);
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			if ((double)gameObject.GetComponent<EngineComponentC>().currentFuelAmount > 0.0)
			{
				gameObject.GetComponent<EngineComponentC>().currentFuelAmount = 0f;
			}
			if (gameObject.GetComponent<EngineComponentC>().totalWaterCharges > 0)
			{
				gameObject.GetComponent<EngineComponentC>().totalWaterCharges = 0;
			}
			if ((double)gameObject.GetComponent<EngineComponentC>().charge > 0.0)
			{
				float charge = UnityEngine.Random.Range(0f, 20f);
				gameObject.GetComponent<EngineComponentC>().charge = charge;
			}
			gameObject.gameObject.GetComponent<Collider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			this.spawnCatalogue.RemoveAt(index2);
			this.spawnLocs.RemoveAt(index);
		}
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x000E3A04 File Offset: 0x000E1E04
	public void SetParents()
	{
		this.gateGasTankParent = this.gateGasTank.transform.parent.gameObject;
		this.gateBatteryParent = this.gateBattery.transform.parent.gameObject;
		this.gateEngineParent = this.gateEngine.transform.parent.gameObject;
		this.gateCarburettorParent = this.gateCarburettor.transform.parent.gameObject;
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x000E3A80 File Offset: 0x000E1E80
	public void DefineLockSystem()
	{
		int num = UnityEngine.Random.Range(0, 8);
		if (num == 0)
		{
			this.LockGateNoFuel();
		}
		else if (num == 1)
		{
			this.LockGateNoCharge();
		}
		else if (num == 2)
		{
			this.LockGateNoFuelTank();
		}
		else if (num == 3)
		{
			this.LockGateNoBattery();
		}
		else if (num == 4)
		{
			this.LockGateNoCarburettor();
		}
		else if (num == 5)
		{
			this.LockGateNoEngine();
		}
		else if (num == 6)
		{
			this.LockGateBrokenEngine();
		}
		else if (num == 7)
		{
			this.LockGateBrokenCarburettor();
		}
		else if (num == 8)
		{
			this.LockGateBrokenFuelTank();
		}
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x000E3B31 File Offset: 0x000E1F31
	public void LockGateNoFuel()
	{
		this.gateGasTank.GetComponent<EngineComponentC>().currentFuelAmount = 0f;
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x000E3B48 File Offset: 0x000E1F48
	public void LockGateNoCharge()
	{
		this.gateBattery.GetComponent<EngineComponentC>().charge = 0f;
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x000E3B60 File Offset: 0x000E1F60
	public void LockGateNoFuelTank()
	{
		this.gateGasTankParent.GetComponent<HoldingLogicC>().isOccupied = false;
		this.gateGasTankParent.GetComponent<BoxCollider>().enabled = true;
		this.gateGasTankParent.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
		UnityEngine.Object.Destroy(this.gateGasTank);
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x000E3BB0 File Offset: 0x000E1FB0
	public void LockGateNoBattery()
	{
		this.gateBatteryParent.GetComponent<HoldingLogicC>().isOccupied = false;
		this.gateBatteryParent.GetComponent<BoxCollider>().enabled = true;
		this.gateBatteryParent.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
		UnityEngine.Object.Destroy(this.gateBattery);
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x000E3C00 File Offset: 0x000E2000
	public void LockGateNoCarburettor()
	{
		this.gateCarburettorParent.GetComponent<HoldingLogicC>().isOccupied = false;
		this.gateCarburettorParent.GetComponent<BoxCollider>().enabled = true;
		this.gateCarburettorParent.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
		UnityEngine.Object.Destroy(this.gateCarburettor);
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x000E3C50 File Offset: 0x000E2050
	public void LockGateNoEngine()
	{
		this.gateEngineParent.GetComponent<HoldingLogicC>().isOccupied = false;
		this.gateEngineParent.GetComponent<BoxCollider>().enabled = true;
		this.gateEngineParent.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
		UnityEngine.Object.Destroy(this.gateEngine);
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x000E3CA0 File Offset: 0x000E20A0
	public void LockGateBrokenEngine()
	{
		this.gateEngine.GetComponent<EngineComponentC>().Condition = 0f;
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x000E3CB7 File Offset: 0x000E20B7
	public void LockGateBrokenCarburettor()
	{
		this.gateCarburettor.GetComponent<EngineComponentC>().Condition = 0f;
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x000E3CCE File Offset: 0x000E20CE
	public void LockGateBrokenFuelTank()
	{
		this.gateGasTank.GetComponent<EngineComponentC>().Condition = 0f;
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x000E3CE8 File Offset: 0x000E20E8
	public void CancelTransaction()
	{
		if (this.gateGasTank == null)
		{
			return;
		}
		if ((double)this.gateGasTank.GetComponent<EngineComponentC>().currentFuelAmount < 1.0)
		{
			return;
		}
		if ((double)this.gateGasTank.GetComponent<EngineComponentC>().Condition <= 0.0)
		{
			return;
		}
		if (this.gateBattery == null)
		{
			return;
		}
		if ((double)this.gateBattery.GetComponent<EngineComponentC>().charge < 1.0)
		{
			return;
		}
		if ((double)this.gateBattery.GetComponent<EngineComponentC>().Condition <= 0.0)
		{
			return;
		}
		if (this.gateEngine == null)
		{
			return;
		}
		if ((double)this.gateEngine.GetComponent<EngineComponentC>().Condition <= 0.0)
		{
			return;
		}
		if (this.gateCarburettor == null)
		{
			return;
		}
		if ((double)this.gateCarburettor.GetComponent<EngineComponentC>().Condition <= 0.0)
		{
			return;
		}
		this.GateOpen();
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x000E3E04 File Offset: 0x000E2204
	public void GateOpen()
	{
		iTween.PunchPosition(this.gateEngine, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0.05f, 0.05f, 0.05f),
			"islocal",
			true,
			"time",
			2.35,
			"oncomplete",
			"EngineSmoke",
			"oncompletetarget",
			base.gameObject
		}));
		this.gateEngine.GetComponent<AudioSource>().PlayOneShot(this.engineAudio);
		this.gateBattery.GetComponent<EngineComponentC>().charge -= 10f;
		if (this.gateBattery.GetComponent<EngineComponentC>().charge < 0f)
		{
			this.gateBattery.GetComponent<EngineComponentC>().charge = 0f;
		}
		this.gateGasTank.GetComponent<EngineComponentC>().currentFuelAmount -= 1f;
		if ((double)this.gateGasTank.GetComponent<EngineComponentC>().currentFuelAmount < 0.0)
		{
			this.gateGasTank.GetComponent<EngineComponentC>().currentFuelAmount = 0f;
		}
		iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
		{
			"position",
			new Vector3(54.11253f, 4.159318f, 23.11248f),
			"time",
			8.0,
			"islocal",
			true,
			"easetype",
			"easeoutsine"
		}));
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x000E3FBD File Offset: 0x000E23BD
	public void EngineSmoke()
	{
		this.engineSmoke.SetActive(true);
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x000E3FCB File Offset: 0x000E23CB
	public void StopGateAudio()
	{
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x000E3FCD File Offset: 0x000E23CD
	public void DialogueExplainLever()
	{
	}

	// Token: 0x04000D29 RID: 3369
	public GameObject gateGasTank;

	// Token: 0x04000D2A RID: 3370
	private GameObject gateGasTankParent;

	// Token: 0x04000D2B RID: 3371
	public GameObject gateBattery;

	// Token: 0x04000D2C RID: 3372
	private GameObject gateBatteryParent;

	// Token: 0x04000D2D RID: 3373
	public GameObject gateEngine;

	// Token: 0x04000D2E RID: 3374
	private GameObject gateEngineParent;

	// Token: 0x04000D2F RID: 3375
	public GameObject gateCarburettor;

	// Token: 0x04000D30 RID: 3376
	private GameObject gateCarburettorParent;

	// Token: 0x04000D31 RID: 3377
	public GameObject gateObj;

	// Token: 0x04000D32 RID: 3378
	public AudioClip engineAudio;

	// Token: 0x04000D33 RID: 3379
	public GameObject engineSmoke;

	// Token: 0x04000D34 RID: 3380
	public List<Transform> spawnLocs = new List<Transform>();

	// Token: 0x04000D35 RID: 3381
	public List<GameObject> spawnCatalogue = new List<GameObject>();
}
