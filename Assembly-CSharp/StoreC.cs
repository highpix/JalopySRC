using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000106 RID: 262
public class StoreC : MonoBehaviour
{
	// Token: 0x06000A45 RID: 2629 RVA: 0x000EFF0C File Offset: 0x000EE30C
	private void Start()
	{
		this.director = GameObject.FindWithTag("Director");
		this.RandomizeBasePrices();
		this.SpawnTools();
		this.SpawnOffRoadTyres();
		this.SpawnOnRoadTyres();
		this.SpawnWetTyres();
		this.SpawnWater();
		this.SpawnOils();
		this.SpawnGasCans();
		this.SpawnRepairKits();
		this.SpawnTyreRepairKits();
		base.Invoke("LateStart", 3f);
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x000EFF75 File Offset: 0x000EE375
	private void LateStart()
	{
		if (this.pumpObject != null)
		{
			this.pumpObject.SetActive(true);
		}
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x000EFF94 File Offset: 0x000EE394
	public void RandomizeBasePrices()
	{
		this.supplyCatalogueBasePrices[this.supplyNumbers[3]] = UnityEngine.Random.Range(0.5f, 1.25f);
		this.supplyCatalogueBasePrices[this.supplyNumbers[4]] = UnityEngine.Random.Range(10f, 15f);
		this.supplyCatalogueBasePrices[this.supplyNumbers[0]] = UnityEngine.Random.Range(40f, 55f);
		this.supplyCatalogueBasePrices[this.supplyNumbers[1]] = UnityEngine.Random.Range(15f, 20f);
		this.supplyCatalogueBasePrices[this.supplyNumbers[2]] = UnityEngine.Random.Range(1.5f, 3f);
		this.supplyCatalogueBasePrices[this.supplyNumbers[5]] = UnityEngine.Random.Range(3f, 5.5f);
		this.SetValues(this.director.GetComponent<RouteGeneratorC>().routeLevel);
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x000F0084 File Offset: 0x000EE484
	public void SetValues(int routeLevel)
	{
		if (base.transform.root.GetComponent<Hub_CitySpawnC>())
		{
			this.countryCode = base.transform.root.GetComponent<Hub_CitySpawnC>().countryHUBCode - 1;
		}
		else if (this.wakeUpInTown || this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			this.countryCode = routeLevel - 1;
		}
		else if (!this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			this.countryCode = routeLevel;
		}
		if (this.wakeUpInTown || this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (routeLevel == 1)
			{
				this.SetGERValues();
			}
			else if (routeLevel == 2)
			{
				this.SetCSFRValues();
			}
			else if (routeLevel == 3)
			{
				this.SetHUNValues();
			}
			else if (routeLevel == 4)
			{
				this.SetYUGOValues();
			}
			else if (routeLevel == 5)
			{
				this.SetBULValues();
			}
			else if (routeLevel == 6)
			{
				this.SetTURKValues();
			}
		}
		else if (!this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (routeLevel == 0)
			{
				this.SetGERValues();
			}
			else if (routeLevel == 1)
			{
				this.SetCSFRValues();
			}
			else if (routeLevel == 2)
			{
				this.SetHUNValues();
			}
			else if (routeLevel == 3)
			{
				this.SetYUGOValues();
			}
			else if (routeLevel == 4)
			{
				this.SetBULValues();
			}
			else if (routeLevel == 5)
			{
				this.SetTURKValues();
			}
		}
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x000F0220 File Offset: 0x000EE620
	public void SetGERValues()
	{
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = 0f;
			this.supplyCatalogueState[3] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.5f;
			this.supplyCatalogueState[4] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]];
			this.supplyCatalogueState[0] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueState[5] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = 0f;
			this.supplyCatalogueState[5] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.5f;
			this.supplyCatalogueState[3] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]];
			this.supplyCatalogueState[1] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueState[2] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = 0f;
			this.supplyCatalogueState[2] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.5f;
			this.supplyCatalogueState[0] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]];
			this.supplyCatalogueState[5] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueState[3] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = 0f;
			this.supplyCatalogueState[1] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.5f;
			this.supplyCatalogueState[2] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]];
			this.supplyCatalogueState[4] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueState[0] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = 0f;
			this.supplyCatalogueState[0] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.5f;
			this.supplyCatalogueState[1] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]];
			this.supplyCatalogueState[3] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueState[4] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = 0f;
			this.supplyCatalogueState[4] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.5f;
			this.supplyCatalogueState[5] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]];
			this.supplyCatalogueState[2] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueState[1] = 5;
		}
		this.PriceRounding();
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x000F0FC0 File Offset: 0x000EF3C0
	public void SetCSFRValues()
	{
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = 0f;
			this.supplyCatalogueState[4] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.5f;
			this.supplyCatalogueState[0] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]];
			this.supplyCatalogueState[1] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueState[3] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = 0f;
			this.supplyCatalogueState[3] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.5f;
			this.supplyCatalogueState[1] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]];
			this.supplyCatalogueState[0] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueState[5] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = 0f;
			this.supplyCatalogueState[0] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.5f;
			this.supplyCatalogueState[5] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]];
			this.supplyCatalogueState[4] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueState[2] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = 0f;
			this.supplyCatalogueState[2] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.5f;
			this.supplyCatalogueState[4] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]];
			this.supplyCatalogueState[5] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueState[1] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = 0f;
			this.supplyCatalogueState[1] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.5f;
			this.supplyCatalogueState[3] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]];
			this.supplyCatalogueState[2] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueState[0] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = 0f;
			this.supplyCatalogueState[5] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.5f;
			this.supplyCatalogueState[2] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]];
			this.supplyCatalogueState[3] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueState[4] = 5;
		}
		this.PriceRounding();
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x000F1D60 File Offset: 0x000F0160
	public void SetHUNValues()
	{
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = 0f;
			this.supplyCatalogueState[0] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.5f;
			this.supplyCatalogueState[1] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]];
			this.supplyCatalogueState[2] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueState[4] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = 0f;
			this.supplyCatalogueState[1] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.5f;
			this.supplyCatalogueState[0] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]];
			this.supplyCatalogueState[4] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueState[3] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = 0f;
			this.supplyCatalogueState[5] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.5f;
			this.supplyCatalogueState[4] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]];
			this.supplyCatalogueState[1] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueState[0] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = 0f;
			this.supplyCatalogueState[4] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.5f;
			this.supplyCatalogueState[5] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]];
			this.supplyCatalogueState[3] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[0] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueState[2] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = 0f;
			this.supplyCatalogueState[3] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.5f;
			this.supplyCatalogueState[2] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]];
			this.supplyCatalogueState[5] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueState[1] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = 0f;
			this.supplyCatalogueState[2] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.5f;
			this.supplyCatalogueState[3] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]];
			this.supplyCatalogueState[0] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueState[5] = 5;
		}
		this.PriceRounding();
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x000F2B00 File Offset: 0x000F0F00
	public void SetYUGOValues()
	{
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = 0f;
			this.supplyCatalogueState[1] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.5f;
			this.supplyCatalogueState[2] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]];
			this.supplyCatalogueState[5] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueState[0] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = 0f;
			this.supplyCatalogueState[0] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.5f;
			this.supplyCatalogueState[4] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]];
			this.supplyCatalogueState[2] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueState[1] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = 0f;
			this.supplyCatalogueState[4] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.5f;
			this.supplyCatalogueState[1] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]];
			this.supplyCatalogueState[3] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueState[5] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = 0f;
			this.supplyCatalogueState[5] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.5f;
			this.supplyCatalogueState[3] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]];
			this.supplyCatalogueState[0] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueState[4] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = 0f;
			this.supplyCatalogueState[2] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.5f;
			this.supplyCatalogueState[5] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]];
			this.supplyCatalogueState[4] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueState[3] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = 0f;
			this.supplyCatalogueState[3] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.5f;
			this.supplyCatalogueState[0] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]];
			this.supplyCatalogueState[1] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueState[2] = 5;
		}
		this.PriceRounding();
	}

	// Token: 0x06000A4D RID: 2637 RVA: 0x000F38A0 File Offset: 0x000F1CA0
	public void SetBULValues()
	{
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = 0f;
			this.supplyCatalogueState[2] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.5f;
			this.supplyCatalogueState[5] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]];
			this.supplyCatalogueState[3] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueState[1] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = 0f;
			this.supplyCatalogueState[4] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.5f;
			this.supplyCatalogueState[2] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]];
			this.supplyCatalogueState[5] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueState[0] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = 0f;
			this.supplyCatalogueState[1] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.5f;
			this.supplyCatalogueState[3] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]];
			this.supplyCatalogueState[2] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueState[4] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = 0f;
			this.supplyCatalogueState[3] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.5f;
			this.supplyCatalogueState[0] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]];
			this.supplyCatalogueState[1] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueState[5] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = 0f;
			this.supplyCatalogueState[5] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.5f;
			this.supplyCatalogueState[4] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]];
			this.supplyCatalogueState[0] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueState[2] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = 0f;
			this.supplyCatalogueState[0] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.5f;
			this.supplyCatalogueState[1] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]];
			this.supplyCatalogueState[4] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueState[3] = 5;
		}
		this.PriceRounding();
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x000F4640 File Offset: 0x000F2A40
	public void SetTURKValues()
	{
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = 0f;
			this.supplyCatalogueState[5] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 1.5f;
			this.supplyCatalogueState[3] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]];
			this.supplyCatalogueState[4] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueState[2] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = 0f;
			this.supplyCatalogueState[2] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 1.5f;
			this.supplyCatalogueState[5] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]];
			this.supplyCatalogueState[3] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueState[1] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueState[0] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueState[4] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = 0f;
			this.supplyCatalogueState[3] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 1.5f;
			this.supplyCatalogueState[2] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]];
			this.supplyCatalogueState[0] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.5f;
			this.supplyCatalogueState[1] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = 0f;
			this.supplyCatalogueState[0] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 1.5f;
			this.supplyCatalogueState[1] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]];
			this.supplyCatalogueState[2] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 0.75f;
			this.supplyCatalogueState[4] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueState[5] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueState[3] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = 0f;
			this.supplyCatalogueState[4] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 1.5f;
			this.supplyCatalogueState[0] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]];
			this.supplyCatalogueState[1] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.5f;
			this.supplyCatalogueState[5] = 5;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
		{
			this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueBasePrices[this.supplyNumbers[1]] * 2f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = 0f;
			this.supplyCatalogueState[1] = 0;
			this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBasePrices[this.supplyNumbers[4]] * 1.5f;
			this.supplyCatalogueState[4] = 1;
			this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]] * 0.75f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBasePrices[this.supplyNumbers[5]];
			this.supplyCatalogueState[5] = 2;
			this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBasePrices[this.supplyNumbers[2]] * 0.75f;
			this.supplyCatalogueState[2] = 3;
			this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.5f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBasePrices[this.supplyNumbers[3]] * 0.75f;
			this.supplyCatalogueState[3] = 4;
			this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.25f;
			this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBasePrices[this.supplyNumbers[0]] * 0.5f;
			this.supplyCatalogueState[0] = 5;
		}
		this.PriceRounding();
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x000F53E0 File Offset: 0x000F37E0
	public void PriceRounding()
	{
		this.supplyCatalogueSellPrices[this.supplyNumbers[0]] = Mathf.Round(this.supplyCatalogueSellPrices[this.supplyNumbers[0]] * 10f) / 10f;
		this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] = Mathf.Round(this.supplyCatalogueBuyPrices[this.supplyNumbers[0]] * 10f) / 10f;
		this.supplyCatalogueSellPrices[this.supplyNumbers[1]] = Mathf.Round(this.supplyCatalogueSellPrices[this.supplyNumbers[1]] * 10f) / 10f;
		this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] = Mathf.Round(this.supplyCatalogueBuyPrices[this.supplyNumbers[1]] * 10f) / 10f;
		this.supplyCatalogueSellPrices[this.supplyNumbers[2]] = Mathf.Round(this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] * 10f) / 10f;
		this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] = Mathf.Round(this.supplyCatalogueBuyPrices[this.supplyNumbers[2]] * 10f) / 10f;
		this.supplyCatalogueSellPrices[this.supplyNumbers[3]] = Mathf.Round(this.supplyCatalogueSellPrices[this.supplyNumbers[3]] * 10f) / 10f;
		this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] = Mathf.Round(this.supplyCatalogueBuyPrices[this.supplyNumbers[3]] * 10f) / 10f;
		this.supplyCatalogueSellPrices[this.supplyNumbers[4]] = Mathf.Round(this.supplyCatalogueSellPrices[this.supplyNumbers[4]] * 10f) / 10f;
		this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] = Mathf.Round(this.supplyCatalogueBuyPrices[this.supplyNumbers[4]] * 10f) / 10f;
		this.supplyCatalogueSellPrices[this.supplyNumbers[5]] = Mathf.Round(this.supplyCatalogueSellPrices[this.supplyNumbers[5]] * 10f) / 10f;
		this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] = Mathf.Round(this.supplyCatalogueBuyPrices[this.supplyNumbers[5]] * 10f) / 10f;
		this.director.GetComponent<DirectorC>().supplyNumbers[0] = this.supplyNumbers[0];
		this.director.GetComponent<DirectorC>().supplyNumbers[1] = this.supplyNumbers[1];
		this.director.GetComponent<DirectorC>().supplyNumbers[2] = this.supplyNumbers[2];
		this.director.GetComponent<DirectorC>().supplyNumbers[3] = this.supplyNumbers[3];
		this.director.GetComponent<DirectorC>().supplyNumbers[4] = this.supplyNumbers[4];
		this.director.GetComponent<DirectorC>().supplyNumbers[5] = this.supplyNumbers[5];
		this.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[this.supplyNumbers[0]] = this.supplyCatalogueSellPrices[this.supplyNumbers[0]];
		this.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[this.supplyNumbers[1]] = this.supplyCatalogueSellPrices[this.supplyNumbers[1]];
		this.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[this.supplyNumbers[2]] = this.supplyCatalogueSellPrices[this.supplyNumbers[2]];
		this.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[this.supplyNumbers[3]] = this.supplyCatalogueSellPrices[this.supplyNumbers[3]];
		this.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[this.supplyNumbers[4]] = this.supplyCatalogueSellPrices[this.supplyNumbers[4]];
		this.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[this.supplyNumbers[5]] = this.supplyCatalogueSellPrices[this.supplyNumbers[5]];
		this.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[this.supplyNumbers[0]] = this.supplyCatalogueBuyPrices[this.supplyNumbers[0]];
		this.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[this.supplyNumbers[1]] = this.supplyCatalogueBuyPrices[this.supplyNumbers[1]];
		this.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[this.supplyNumbers[2]] = this.supplyCatalogueBuyPrices[this.supplyNumbers[2]];
		this.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[this.supplyNumbers[3]] = this.supplyCatalogueBuyPrices[this.supplyNumbers[3]];
		this.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[this.supplyNumbers[4]] = this.supplyCatalogueBuyPrices[this.supplyNumbers[4]];
		this.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[this.supplyNumbers[5]] = this.supplyCatalogueBuyPrices[this.supplyNumbers[5]];
		this.director.GetComponent<DirectorC>().economyReady = true;
		this.SpawnSupplies();
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		gameObject.GetComponent<CarLogicC>().UpdateBootPrices();
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x000F59A4 File Offset: 0x000F3DA4
	public void SpawnSupplies()
	{
		for (int i = 0; i < this.supplyNumbers.Count; i++)
		{
			int value = this.supplyNumbers[i];
			int index = UnityEngine.Random.Range(i, this.supplyNumbers.Count);
			this.supplyNumbers[i] = this.supplyNumbers[index];
			this.supplyNumbers[index] = value;
		}
		if (this.supplyCatalogueState[0] == 0)
		{
			this.saleSigns[0].transform.parent = this.supplySigns[0].transform;
			this.saleSigns[0].transform.localPosition = Vector3.zero;
			this.saleSigns[0].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
		}
		if (this.supplyCatalogueState[0] != 0)
		{
			for (int j = 0; j < this.supplySpawnLocs1.Count; j++)
			{
				Transform value2 = this.supplySpawnLocs1[j];
				int index2 = UnityEngine.Random.Range(j, this.supplySpawnLocs1.Count);
				this.supplySpawnLocs1[j] = this.supplySpawnLocs1[index2];
				this.supplySpawnLocs1[index2] = value2;
			}
			float num = 0f;
			if (this.supplyCatalogueState[0] == 1)
			{
				float max = (float)this.supplySpawnLocs1.Count * 0.25f;
				num = UnityEngine.Random.Range(0f, max);
			}
			else if (this.supplyCatalogueState[0] == 2)
			{
				float max = (float)this.supplySpawnLocs1.Count * 0.5f;
				num = UnityEngine.Random.Range(0f, max);
			}
			else if (this.supplyCatalogueState[0] == 3)
			{
				float max = (float)this.supplySpawnLocs1.Count * 0.75f;
				num = UnityEngine.Random.Range(0f, max);
				this.saleSigns[2].transform.parent = this.supplySigns[0].transform;
				this.saleSigns[2].transform.localPosition = Vector3.zero;
				this.saleSigns[2].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[0] == 4)
			{
				float max = (float)this.supplySpawnLocs1.Count * 0.75f;
				num = UnityEngine.Random.Range(0f, max);
				this.saleSigns[3].transform.parent = this.supplySigns[0].transform;
				this.saleSigns[3].transform.localPosition = Vector3.zero;
				this.saleSigns[3].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[0] == 5)
			{
				float max = (float)this.supplySpawnLocs1.Count;
				num = UnityEngine.Random.Range(0f, max);
				this.saleSigns[1].transform.parent = this.supplySigns[0].transform;
				this.saleSigns[1].transform.localPosition = Vector3.zero;
				this.saleSigns[1].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			int num2 = 0;
			while ((float)num2 < num)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.supplyCatalogue[0], this.supplySpawnLocs1[num2].position, this.supplySpawnLocs1[num2].rotation);
				if (this.wakeUpInTown)
				{
					gameObject.GetComponent<ObjectPickupC>().morningShop = true;
				}
				gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
				gameObject.transform.parent = this.supplySpawnLocs1[num2];
				gameObject.name = this.supplyCatalogue[0].name;
				gameObject.GetComponent<ObjectPickupC>().sellValue = this.supplyCatalogueSellPrices[0];
				gameObject.GetComponent<ObjectPickupC>().buyValue = this.supplyCatalogueBuyPrices[0];
				num2++;
			}
		}
		if (this.supplyCatalogueState[1] == 0)
		{
			this.saleSigns[0].transform.parent = this.supplySigns[1].transform;
			this.saleSigns[0].transform.localPosition = Vector3.zero;
			this.saleSigns[0].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
		}
		if (this.supplyCatalogueState[1] != 0)
		{
			for (int k = 0; k < this.supplySpawnLocs2.Count; k++)
			{
				Transform value3 = this.supplySpawnLocs2[k];
				int index3 = UnityEngine.Random.Range(k, this.supplySpawnLocs2.Count);
				this.supplySpawnLocs2[k] = this.supplySpawnLocs2[index3];
				this.supplySpawnLocs2[index3] = value3;
			}
			float num3 = 0f;
			if (this.supplyCatalogueState[1] == 1)
			{
				float max2 = (float)this.supplySpawnLocs2.Count * 0.25f;
				num3 = UnityEngine.Random.Range(0f, max2);
			}
			else if (this.supplyCatalogueState[1] == 2)
			{
				float max2 = (float)this.supplySpawnLocs2.Count * 0.5f;
				num3 = UnityEngine.Random.Range(0f, max2);
			}
			else if (this.supplyCatalogueState[1] == 3)
			{
				float max2 = (float)this.supplySpawnLocs2.Count * 0.75f;
				num3 = UnityEngine.Random.Range(0f, max2);
				this.saleSigns[2].transform.parent = this.supplySigns[1].transform;
				this.saleSigns[2].transform.localPosition = Vector3.zero;
				this.saleSigns[2].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[1] == 4)
			{
				float max2 = (float)this.supplySpawnLocs2.Count * 0.75f;
				num3 = UnityEngine.Random.Range(0f, max2);
				this.saleSigns[3].transform.parent = this.supplySigns[1].transform;
				this.saleSigns[3].transform.localPosition = Vector3.zero;
				this.saleSigns[3].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[1] == 5)
			{
				float max2 = (float)this.supplySpawnLocs2.Count;
				num3 = UnityEngine.Random.Range(0f, max2);
				this.saleSigns[1].transform.parent = this.supplySigns[1].transform;
				this.saleSigns[1].transform.localPosition = Vector3.zero;
				this.saleSigns[1].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			int num4 = 0;
			while ((float)num4 < num3)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.supplyCatalogue[1], this.supplySpawnLocs2[num4].position, this.supplySpawnLocs2[num4].rotation);
				if (this.wakeUpInTown)
				{
					gameObject2.GetComponent<ObjectPickupC>().morningShop = true;
				}
				gameObject2.GetComponent<ObjectPickupC>().isPurchased = false;
				gameObject2.transform.parent = this.supplySpawnLocs2[num4];
				gameObject2.name = this.supplyCatalogue[1].name;
				gameObject2.GetComponent<ObjectPickupC>().sellValue = this.supplyCatalogueSellPrices[1];
				gameObject2.GetComponent<ObjectPickupC>().buyValue = this.supplyCatalogueBuyPrices[1];
				num4++;
			}
		}
		if (this.supplyCatalogueState[2] == 0)
		{
			this.saleSigns[0].transform.parent = this.supplySigns[2].transform;
			this.saleSigns[0].transform.localPosition = Vector3.zero;
			this.saleSigns[0].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
		}
		if (this.supplyCatalogueState[2] != 0)
		{
			for (int l = 0; l < this.supplySpawnLocs3.Count; l++)
			{
				Transform value4 = this.supplySpawnLocs3[l];
				int index4 = UnityEngine.Random.Range(l, this.supplySpawnLocs3.Count);
				this.supplySpawnLocs3[l] = this.supplySpawnLocs3[index4];
				this.supplySpawnLocs3[index4] = value4;
			}
			float num5 = 0f;
			if (this.supplyCatalogueState[2] == 1)
			{
				float max3 = (float)this.supplySpawnLocs3.Count * 0.25f;
				num5 = UnityEngine.Random.Range(0f, max3);
			}
			else if (this.supplyCatalogueState[2] == 2)
			{
				float max3 = (float)this.supplySpawnLocs3.Count * 0.5f;
				num5 = UnityEngine.Random.Range(0f, max3);
			}
			else if (this.supplyCatalogueState[2] == 3)
			{
				float max3 = (float)this.supplySpawnLocs3.Count * 0.75f;
				num5 = UnityEngine.Random.Range(0f, max3);
				this.saleSigns[2].transform.parent = this.supplySigns[2].transform;
				this.saleSigns[2].transform.localPosition = Vector3.zero;
				this.saleSigns[2].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[2] == 4)
			{
				float max3 = (float)this.supplySpawnLocs3.Count * 0.75f;
				num5 = UnityEngine.Random.Range(0f, max3);
				this.saleSigns[3].transform.parent = this.supplySigns[2].transform;
				this.saleSigns[3].transform.localPosition = Vector3.zero;
				this.saleSigns[3].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[2] == 5)
			{
				float max3 = (float)this.supplySpawnLocs3.Count;
				num5 = UnityEngine.Random.Range(0f, max3);
				this.saleSigns[1].transform.parent = this.supplySigns[2].transform;
				this.saleSigns[1].transform.localPosition = Vector3.zero;
				this.saleSigns[1].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			int num6 = 0;
			while ((float)num6 < num5)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.supplyCatalogue[2], this.supplySpawnLocs3[num6].position, this.supplySpawnLocs3[num6].rotation);
				if (this.wakeUpInTown)
				{
					gameObject3.GetComponent<ObjectPickupC>().morningShop = true;
				}
				gameObject3.GetComponent<ObjectPickupC>().isPurchased = false;
				gameObject3.transform.parent = this.supplySpawnLocs3[num6];
				gameObject3.name = this.supplyCatalogue[2].name;
				gameObject3.GetComponent<ObjectPickupC>().sellValue = this.supplyCatalogueSellPrices[2];
				gameObject3.GetComponent<ObjectPickupC>().buyValue = this.supplyCatalogueBuyPrices[2];
				num6++;
			}
		}
		if (this.supplyCatalogueState[3] == 0)
		{
			this.saleSigns[0].transform.parent = this.supplySigns[3].transform;
			this.saleSigns[0].transform.localPosition = Vector3.zero;
			this.saleSigns[0].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
		}
		if (this.supplyCatalogueState[3] != 0)
		{
			for (int m = 0; m < this.supplySpawnLocs4.Count; m++)
			{
				Transform value5 = this.supplySpawnLocs4[m];
				int index5 = UnityEngine.Random.Range(m, this.supplySpawnLocs4.Count);
				this.supplySpawnLocs4[m] = this.supplySpawnLocs4[index5];
				this.supplySpawnLocs4[index5] = value5;
			}
			float num7 = 0f;
			if (this.supplyCatalogueState[3] == 1)
			{
				float max4 = (float)this.supplySpawnLocs4.Count * 0.25f;
				num7 = UnityEngine.Random.Range(0f, max4);
			}
			else if (this.supplyCatalogueState[3] == 2)
			{
				float max4 = (float)this.supplySpawnLocs4.Count * 0.5f;
				num7 = UnityEngine.Random.Range(0f, max4);
			}
			else if (this.supplyCatalogueState[3] == 3)
			{
				float max4 = (float)this.supplySpawnLocs4.Count * 0.75f;
				num7 = UnityEngine.Random.Range(0f, max4);
				this.saleSigns[2].transform.parent = this.supplySigns[3].transform;
				this.saleSigns[2].transform.localPosition = Vector3.zero;
				this.saleSigns[2].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[3] == 4)
			{
				float max4 = (float)this.supplySpawnLocs4.Count * 0.75f;
				num7 = UnityEngine.Random.Range(0f, max4);
				this.saleSigns[3].transform.parent = this.supplySigns[3].transform;
				this.saleSigns[3].transform.localPosition = Vector3.zero;
				this.saleSigns[3].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[3] == 5)
			{
				float max4 = (float)this.supplySpawnLocs4.Count;
				num7 = UnityEngine.Random.Range(0f, max4);
				this.saleSigns[1].transform.parent = this.supplySigns[3].transform;
				this.saleSigns[1].transform.localPosition = Vector3.zero;
				this.saleSigns[1].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			int num8 = 0;
			while ((float)num8 < num7)
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.supplyCatalogue[3], this.supplySpawnLocs4[num8].position, this.supplySpawnLocs4[num8].rotation);
				if (this.wakeUpInTown)
				{
					gameObject4.GetComponent<ObjectPickupC>().morningShop = true;
				}
				gameObject4.GetComponent<ObjectPickupC>().isPurchased = false;
				gameObject4.transform.parent = this.supplySpawnLocs4[num8];
				gameObject4.name = this.supplyCatalogue[3].name;
				gameObject4.GetComponent<ObjectPickupC>().sellValue = this.supplyCatalogueSellPrices[3];
				gameObject4.GetComponent<ObjectPickupC>().buyValue = this.supplyCatalogueBuyPrices[3];
				num8++;
			}
		}
		if (this.supplyCatalogueState[4] == 0)
		{
			this.saleSigns[0].transform.parent = this.supplySigns[4].transform;
			this.saleSigns[0].transform.localPosition = Vector3.zero;
			this.saleSigns[0].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
		}
		if (this.supplyCatalogueState[4] != 0)
		{
			for (int n = 0; n < this.supplySpawnLocs5.Count; n++)
			{
				Transform value6 = this.supplySpawnLocs5[n];
				int index6 = UnityEngine.Random.Range(n, this.supplySpawnLocs5.Count);
				this.supplySpawnLocs5[n] = this.supplySpawnLocs5[index6];
				this.supplySpawnLocs5[index6] = value6;
			}
			float num9 = 0f;
			if (this.supplyCatalogueState[4] == 1)
			{
				float max5 = (float)this.supplySpawnLocs5.Count * 0.25f;
				num9 = UnityEngine.Random.Range(0f, max5);
			}
			else if (this.supplyCatalogueState[4] == 2)
			{
				float max5 = (float)this.supplySpawnLocs5.Count * 0.5f;
				num9 = UnityEngine.Random.Range(0f, max5);
			}
			else if (this.supplyCatalogueState[4] == 3)
			{
				float max5 = (float)this.supplySpawnLocs5.Count * 0.75f;
				num9 = UnityEngine.Random.Range(0f, max5);
				this.saleSigns[2].transform.parent = this.supplySigns[4].transform;
				this.saleSigns[2].transform.localPosition = Vector3.zero;
				this.saleSigns[2].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[4] == 4)
			{
				float max5 = (float)this.supplySpawnLocs5.Count * 0.75f;
				num9 = UnityEngine.Random.Range(0f, max5);
				this.saleSigns[3].transform.parent = this.supplySigns[4].transform;
				this.saleSigns[3].transform.localPosition = Vector3.zero;
				this.saleSigns[3].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[4] == 5)
			{
				float max5 = (float)this.supplySpawnLocs5.Count;
				num9 = UnityEngine.Random.Range(0f, max5);
				this.saleSigns[1].transform.parent = this.supplySigns[4].transform;
				this.saleSigns[1].transform.localPosition = Vector3.zero;
				this.saleSigns[1].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			int num10 = 0;
			while ((float)num10 < num9)
			{
				GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.supplyCatalogue[4], this.supplySpawnLocs5[num10].position, this.supplySpawnLocs5[num10].rotation);
				if (this.wakeUpInTown)
				{
					gameObject5.GetComponent<ObjectPickupC>().morningShop = true;
				}
				gameObject5.GetComponent<ObjectPickupC>().isPurchased = false;
				gameObject5.transform.parent = this.supplySpawnLocs5[num10];
				gameObject5.name = this.supplyCatalogue[4].name;
				gameObject5.GetComponent<ObjectPickupC>().sellValue = this.supplyCatalogueSellPrices[4];
				gameObject5.GetComponent<ObjectPickupC>().buyValue = this.supplyCatalogueBuyPrices[4];
				num10++;
			}
		}
		if (this.supplyCatalogueState[5] == 0)
		{
			this.saleSigns[0].transform.parent = this.supplySigns[5].transform;
			this.saleSigns[0].transform.localPosition = Vector3.zero;
			this.saleSigns[0].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
		}
		if (this.supplyCatalogueState[5] != 0)
		{
			for (int num11 = 0; num11 < this.supplySpawnLocs6.Count; num11++)
			{
				Transform value7 = this.supplySpawnLocs6[num11];
				int index7 = UnityEngine.Random.Range(num11, this.supplySpawnLocs6.Count);
				this.supplySpawnLocs6[num11] = this.supplySpawnLocs6[index7];
				this.supplySpawnLocs6[index7] = value7;
			}
			float num12 = 0f;
			if (this.supplyCatalogueState[5] == 1)
			{
				float max6 = (float)this.supplySpawnLocs6.Count * 0.25f;
				num12 = UnityEngine.Random.Range(0f, max6);
			}
			else if (this.supplyCatalogueState[5] == 2)
			{
				float max6 = (float)this.supplySpawnLocs6.Count * 0.5f;
				num12 = UnityEngine.Random.Range(0f, max6);
			}
			else if (this.supplyCatalogueState[5] == 3)
			{
				float max6 = (float)this.supplySpawnLocs6.Count * 0.75f;
				num12 = UnityEngine.Random.Range(0f, max6);
				this.saleSigns[2].transform.parent = this.supplySigns[5].transform;
				this.saleSigns[2].transform.localPosition = Vector3.zero;
				this.saleSigns[2].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[5] == 4)
			{
				float max6 = (float)this.supplySpawnLocs6.Count * 0.75f;
				num12 = UnityEngine.Random.Range(0f, max6);
				this.saleSigns[3].transform.parent = this.supplySigns[5].transform;
				this.saleSigns[3].transform.localPosition = Vector3.zero;
				this.saleSigns[3].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			else if (this.supplyCatalogueState[5] == 5)
			{
				float max6 = (float)this.supplySpawnLocs6.Count;
				num12 = UnityEngine.Random.Range(0f, max6);
				this.saleSigns[1].transform.parent = this.supplySigns[5].transform;
				this.saleSigns[1].transform.localPosition = Vector3.zero;
				this.saleSigns[1].transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			}
			int num13 = 0;
			while ((float)num13 < num12)
			{
				GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.supplyCatalogue[5], this.supplySpawnLocs6[num13].position, this.supplySpawnLocs6[num13].rotation);
				if (this.wakeUpInTown)
				{
					gameObject6.GetComponent<ObjectPickupC>().morningShop = true;
				}
				gameObject6.GetComponent<ObjectPickupC>().isPurchased = false;
				gameObject6.transform.parent = this.supplySpawnLocs6[num13];
				gameObject6.name = this.supplyCatalogue[5].name;
				gameObject6.GetComponent<ObjectPickupC>().sellValue = this.supplyCatalogueSellPrices[5];
				gameObject6.GetComponent<ObjectPickupC>().buyValue = this.supplyCatalogueBuyPrices[5];
				num13++;
			}
		}
	}

	// Token: 0x06000A51 RID: 2641 RVA: 0x000F70B4 File Offset: 0x000F54B4
	public void SpawnTools()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.toolCatalogue.Length; i++)
		{
			list.Add(this.toolCatalogue[i]);
		}
		for (int j = 0; j < this.toolSpawnLocs.Length; j++)
		{
			list2.Add(this.toolSpawnLocs[j]);
		}
		int num = 2;
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list2.Count);
			int index2 = 0;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index2], list2[index].position, list2[index].rotation);
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.GetComponent<ObjectPickupC>().buyValue = 25f;
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.transform.parent = list2[index];
			gameObject.name = list[index2].name;
			IEnumerator enumerator = list2[index].GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					transform.gameObject.SetActive(true);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			list.RemoveAt(index2);
			list2.RemoveAt(index);
		}
	}

	// Token: 0x06000A52 RID: 2642 RVA: 0x000F7244 File Offset: 0x000F5644
	public void SpawnOffRoadTyres()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.offRoadTyre.Length; i++)
		{
			list.Add(this.offRoadTyre[i]);
		}
		for (int j = 0; j < this.offRoadTyreSpawnLocs.Length; j++)
		{
			list2.Add(this.offRoadTyreSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(0, list2.Count + 1);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x000F736C File Offset: 0x000F576C
	public void SpawnWetTyres()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.wetTyre.Length; i++)
		{
			list.Add(this.wetTyre[i]);
		}
		for (int j = 0; j < this.wetTyreSpawnLocs.Length; j++)
		{
			list2.Add(this.wetTyreSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(0, list2.Count + 1);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A54 RID: 2644 RVA: 0x000F7494 File Offset: 0x000F5894
	public void SpawnOnRoadTyres()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.onRoadTyre.Length; i++)
		{
			list.Add(this.onRoadTyre[i]);
		}
		for (int j = 0; j < this.onRoadTyreSpawnLocs.Length; j++)
		{
			list2.Add(this.onRoadTyreSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(2, list2.Count + 1);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A55 RID: 2645 RVA: 0x000F75BC File Offset: 0x000F59BC
	public void SpawnWater()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.waterCatalogue.Length; i++)
		{
			list.Add(this.waterCatalogue[i]);
		}
		for (int j = 0; j < this.waterSpawnLocs.Length; j++)
		{
			list2.Add(this.waterSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(this.waterMin, this.waterMax);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x000F76D0 File Offset: 0x000F5AD0
	public void SpawnOils()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.oilCatalogue.Length; i++)
		{
			list.Add(this.oilCatalogue[i]);
		}
		for (int j = 0; j < this.oilSpawnLocs.Length; j++)
		{
			list2.Add(this.oilSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(this.oilMin, this.oilMax);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x000F77FC File Offset: 0x000F5BFC
	public void SpawnRepairKits()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.repairKitCatalogue.Length; i++)
		{
			list.Add(this.repairKitCatalogue[i]);
		}
		for (int j = 0; j < this.repairKitSpawnLocs.Length; j++)
		{
			list2.Add(this.repairKitSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(0, list2.Count + 1);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x000F7924 File Offset: 0x000F5D24
	public void SpawnTyreRepairKits()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.tyreRepairKitCatalogue.Length; i++)
		{
			list.Add(this.tyreRepairKitCatalogue[i]);
		}
		for (int j = 0; j < this.tyreRepairKitSpawnLocs.Length; j++)
		{
			list2.Add(this.tyreRepairKitSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(0, list2.Count + 1);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x000F7A4C File Offset: 0x000F5E4C
	public void SpawnGasCans()
	{
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < this.gasCanCatalogue.Length; i++)
		{
			list.Add(this.gasCanCatalogue[i]);
		}
		for (int j = 0; j < this.gasCanSpawnLocs.Length; j++)
		{
			list2.Add(this.gasCanSpawnLocs[j]);
		}
		int num = UnityEngine.Random.Range(0, list2.Count + 1);
		for (int k = 0; k < num; k++)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			int index2 = UnityEngine.Random.Range(0, list2.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(list[index], list2[index2].position, list2[index2].rotation);
			gameObject.GetComponent<ObjectPickupC>().isPurchased = false;
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.transform.parent = list2[index2];
			gameObject.name = list[index].name;
			gameObject.GetComponent<PortableFuelC>().FuelToEmpty();
			list2.RemoveAt(index2);
		}
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x000F7B80 File Offset: 0x000F5F80
	public void GateClose()
	{
		if (!this.gateClosed)
		{
			iTween.Stop(base.gameObject);
			this.gateObj.GetComponent<AudioSource>().Stop();
			this.gateObj.GetComponent<AudioSource>().clip = this.gateAudio;
			this.gateObj.GetComponent<AudioSource>().Play();
			if (!this.marketGate)
			{
				iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
				{
					"z",
					-1.25,
					"time",
					8.0,
					"islocal",
					true,
					"easetype",
					"easeoutsine",
					"oncomplete",
					"StopGateAudio",
					"oncompletetarget",
					base.gameObject
				}));
			}
			else
			{
				iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
				{
					"z",
					0,
					"time",
					8.0,
					"islocal",
					true,
					"easetype",
					"easeoutsine",
					"oncomplete",
					"StopGateAudio",
					"oncompletetarget",
					base.gameObject
				}));
			}
			this.gateClosed = true;
		}
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x000F7D04 File Offset: 0x000F6104
	public void GateCheck()
	{
		if (this.gateClosed)
		{
			for (int i = 0; i < this.unPaidCatalogue.Count; i++)
			{
				if (!this.unPaidCatalogue[i].GetComponent<ObjectPickupC>().isPurchased)
				{
					return;
				}
				if (!this.unPaidCatalogue[i].GetComponent<ObjectPickupC>().isInShoppingKart)
				{
					return;
				}
			}
			if (this.shop.GetComponent<ShopC>().shoppingKart.Count > 0)
			{
				return;
			}
			if (this.shop.GetComponent<ShopC>().totalPrice > 0f)
			{
				return;
			}
			this.GateOpen();
		}
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x000F7DB0 File Offset: 0x000F61B0
	public void GateOpen()
	{
		if (this.gateClosed)
		{
			iTween.Stop(this.gateObj);
			this.gateObj.GetComponent<AudioSource>().Stop();
			this.gateObj.GetComponent<AudioSource>().clip = this.gateAudio;
			this.gateObj.GetComponent<AudioSource>().Play();
			if (!this.marketGate)
			{
				iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
				{
					"z",
					13.75,
					"time",
					8.0,
					"islocal",
					true,
					"easetype",
					"easeoutsine",
					"oncomplete",
					"StopGateAudio",
					"oncompletetarget",
					base.gameObject
				}));
			}
			else
			{
				iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
				{
					"z",
					9.5,
					"time",
					8.0,
					"islocal",
					true,
					"easetype",
					"easeoutsine",
					"oncomplete",
					"StopGateAudio",
					"oncompletetarget",
					base.gameObject
				}));
			}
			this.gateClosed = false;
		}
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x000F7F3C File Offset: 0x000F633C
	public void StopGateAudio()
	{
		this.gateObj.GetComponent<AudioSource>().Stop();
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x000F7F4E File Offset: 0x000F634E
	public void UpdateCatalogue()
	{
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x000F7F50 File Offset: 0x000F6350
	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "CarLogic")
		{
			col.GetComponent<CarLogicC>().uncle.GetComponent<UncleLogicC>().atPetrolStation = true;
		}
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x000F7F82 File Offset: 0x000F6382
	public void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "CarLogic")
		{
			col.GetComponent<CarLogicC>().uncle.GetComponent<UncleLogicC>().atPetrolStation = false;
		}
	}

	// Token: 0x04000E4B RID: 3659
	public int countryCode;

	// Token: 0x04000E4C RID: 3660
	public GameObject director;

	// Token: 0x04000E4D RID: 3661
	public GameObject shop;

	// Token: 0x04000E4E RID: 3662
	public List<Transform> crateSpawnLocs = new List<Transform>();

	// Token: 0x04000E4F RID: 3663
	public GameObject[] crateSpawnCatalogue = new GameObject[0];

	// Token: 0x04000E50 RID: 3664
	public Transform[] toolSpawnLocs = new Transform[0];

	// Token: 0x04000E51 RID: 3665
	public GameObject[] toolCatalogue = new GameObject[0];

	// Token: 0x04000E52 RID: 3666
	public Transform[] offRoadTyreSpawnLocs = new Transform[0];

	// Token: 0x04000E53 RID: 3667
	public GameObject[] offRoadTyre = new GameObject[0];

	// Token: 0x04000E54 RID: 3668
	public Transform[] onRoadTyreSpawnLocs = new Transform[0];

	// Token: 0x04000E55 RID: 3669
	public GameObject[] onRoadTyre = new GameObject[0];

	// Token: 0x04000E56 RID: 3670
	public Transform[] wetTyreSpawnLocs = new Transform[0];

	// Token: 0x04000E57 RID: 3671
	public GameObject[] wetTyre = new GameObject[0];

	// Token: 0x04000E58 RID: 3672
	public int waterMin;

	// Token: 0x04000E59 RID: 3673
	public int waterMax;

	// Token: 0x04000E5A RID: 3674
	public Transform[] waterSpawnLocs = new Transform[0];

	// Token: 0x04000E5B RID: 3675
	public GameObject[] waterCatalogue = new GameObject[0];

	// Token: 0x04000E5C RID: 3676
	public int oilMin;

	// Token: 0x04000E5D RID: 3677
	public int oilMax;

	// Token: 0x04000E5E RID: 3678
	public Transform[] oilSpawnLocs = new Transform[0];

	// Token: 0x04000E5F RID: 3679
	public GameObject[] oilCatalogue = new GameObject[0];

	// Token: 0x04000E60 RID: 3680
	public List<int> supplyNumbers = new List<int>();

	// Token: 0x04000E61 RID: 3681
	public List<Transform> supplySpawnLocs1 = new List<Transform>();

	// Token: 0x04000E62 RID: 3682
	public List<Transform> supplySpawnLocs2 = new List<Transform>();

	// Token: 0x04000E63 RID: 3683
	public List<Transform> supplySpawnLocs3 = new List<Transform>();

	// Token: 0x04000E64 RID: 3684
	public List<Transform> supplySpawnLocs4 = new List<Transform>();

	// Token: 0x04000E65 RID: 3685
	public List<Transform> supplySpawnLocs5 = new List<Transform>();

	// Token: 0x04000E66 RID: 3686
	public List<Transform> supplySpawnLocs6 = new List<Transform>();

	// Token: 0x04000E67 RID: 3687
	public GameObject[] supplyCatalogue = new GameObject[0];

	// Token: 0x04000E68 RID: 3688
	public GameObject[] supplySigns = new GameObject[0];

	// Token: 0x04000E69 RID: 3689
	public GameObject[] saleSigns = new GameObject[0];

	// Token: 0x04000E6A RID: 3690
	public float[] supplyCatalogueBasePrices = new float[0];

	// Token: 0x04000E6B RID: 3691
	public float[] supplyCatalogueSellPrices = new float[0];

	// Token: 0x04000E6C RID: 3692
	public float[] supplyCatalogueBuyPrices = new float[0];

	// Token: 0x04000E6D RID: 3693
	public int[] supplyCatalogueState = new int[0];

	// Token: 0x04000E6E RID: 3694
	public Transform[] gasCanSpawnLocs = new Transform[0];

	// Token: 0x04000E6F RID: 3695
	public GameObject[] gasCanCatalogue = new GameObject[0];

	// Token: 0x04000E70 RID: 3696
	public Transform[] repairKitSpawnLocs = new Transform[0];

	// Token: 0x04000E71 RID: 3697
	public GameObject[] repairKitCatalogue = new GameObject[0];

	// Token: 0x04000E72 RID: 3698
	public Transform[] tyreRepairKitSpawnLocs = new Transform[0];

	// Token: 0x04000E73 RID: 3699
	public GameObject[] tyreRepairKitCatalogue = new GameObject[0];

	// Token: 0x04000E74 RID: 3700
	public Mesh[] priceMesh = new Mesh[0];

	// Token: 0x04000E75 RID: 3701
	public List<GameObject> unPaidCatalogue = new List<GameObject>();

	// Token: 0x04000E76 RID: 3702
	public bool marketGate;

	// Token: 0x04000E77 RID: 3703
	public bool gateClosed;

	// Token: 0x04000E78 RID: 3704
	public GameObject gateObj;

	// Token: 0x04000E79 RID: 3705
	public AudioClip gateAudio;

	// Token: 0x04000E7A RID: 3706
	public bool wakeUpInTown;

	// Token: 0x04000E7B RID: 3707
	public GameObject pumpObject;
}
