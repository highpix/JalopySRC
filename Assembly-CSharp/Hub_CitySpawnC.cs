using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class Hub_CitySpawnC : MonoBehaviour
{
	// Token: 0x060006B5 RID: 1717 RVA: 0x00086000 File Offset: 0x00084400
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		Hub_CitySpawn component = base.GetComponent<Hub_CitySpawn>();
		this.countryHUBCode = component.countryHUBCode;
		this.startSize = component.startSize;
		this.gateObj = component.gateObj;
		component.buildings.Copy(ref this.buildings);
		component.exteriorBuildings.Copy(ref this.exteriorBuildings);
		component.monumentLocs.Copy(ref this.monumentLocs);
		this.spawnedMotel = component.spawnedMotel;
		component.turkAIColFlickers.Copy(ref this.turkAIColFlickers);
		this.laikaFactory = component.laikaFactory;
		this.market = component.market;
		this.motel = component.motel;
		this.petrolStation = component.petrolStation;
		this.musicShop = component.musicShop;
		component.hitchHikers.Copy(ref this.hitchHikers);
		component.hollowBuildings.Copy(ref this.hollowBuildings);
		component.hollowBuildingsCorner.Copy(ref this.hollowBuildingsCorner);
		component.exteriorHollowBuildings.Copy(ref this.exteriorHollowBuildings);
		component.monuments.Copy(ref this.monuments);
		this.tJunction = component.tJunction;
		this.crossRoads = component.crossRoads;
		this.parkingRoad = component.parkingRoad;
		this.tJunctionPavement = component.tJunctionPavement;
		this.crossroadPavement = component.crossroadPavement;
		this.parkingPavement = component.parkingPavement;
		component.roadTargets.Copy(ref this.roadTargets);
		this.streetClutter = component.streetClutter;
		component.straightStreetClutter.Copy(ref this.straightStreetClutter);
		component.parkingStreetClutter.Copy(ref this.parkingStreetClutter);
		component.cornerStreetClutter.Copy(ref this.cornerStreetClutter);
		component.tjunctionStreetClutter.Copy(ref this.tjunctionStreetClutter);
		component.crossroadStreetClutter.Copy(ref this.crossroadStreetClutter);
		this.continueTarget = component.continueTarget;
		this.wakeUpInTown = component.wakeUpInTown;
		this.bulgarianMountainScenery = component.bulgarianMountainScenery;
		this.spawnedYugoScenery = component.spawnedYugoScenery;
		this.primaryBuildingsSaveList1 = new List<int>(component.primaryBuildingsSaveList1);
		this.primaryBuildingsSaveList2 = new List<int>(component.primaryBuildingsSaveList2);
		this.primaryBuildingsSaveList3 = new List<int>(component.primaryBuildingsSaveList3);
		this.primaryBuildingsSaveList4 = new List<int>(component.primaryBuildingsSaveList4);
		this.primaryBuildingsSaveList5 = new List<int>(component.primaryBuildingsSaveList5);
		this.primaryBuildingsSaveList6 = new List<int>(component.primaryBuildingsSaveList6);
		this.hollowBuildingIndexSaveList1 = new List<int>(component.hollowBuildingIndexSaveList1);
		this.hollowBuildingIndexSaveList2 = new List<int>(component.hollowBuildingIndexSaveList2);
		this.hollowBuildingIndexSaveList3 = new List<int>(component.hollowBuildingIndexSaveList3);
		this.hollowBuildingIndexSaveList4 = new List<int>(component.hollowBuildingIndexSaveList4);
		this.hollowBuildingIndexSaveList5 = new List<int>(component.hollowBuildingIndexSaveList5);
		this.hollowBuildingIndexSaveList6 = new List<int>(component.hollowBuildingIndexSaveList6);
		this.randomNumbers = new List<int>(component.randomNumbers);
		component.enabled = false;
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x000862F4 File Offset: 0x000846F4
	private void Start()
	{
		if (ES3.Exists("primaryBuildingsSaveList1"))
		{
			this.primaryBuildingsSaveList1 = ES3.LoadListInt("primaryBuildingsSaveList1");
		}
		if (ES3.Exists("primaryBuildingsSaveList2"))
		{
			this.primaryBuildingsSaveList2 = ES3.LoadListInt("primaryBuildingsSaveList2");
		}
		if (ES3.Exists("primaryBuildingsSaveList3"))
		{
			this.primaryBuildingsSaveList3 = ES3.LoadListInt("primaryBuildingsSaveList3");
		}
		if (ES3.Exists("primaryBuildingsSaveList4"))
		{
			this.primaryBuildingsSaveList4 = ES3.LoadListInt("primaryBuildingsSaveList4");
		}
		if (ES3.Exists("primaryBuildingsSaveList5"))
		{
			this.primaryBuildingsSaveList5 = ES3.LoadListInt("primaryBuildingsSaveList5");
		}
		if (ES3.Exists("primaryBuildingsSaveList6"))
		{
			this.primaryBuildingsSaveList6 = ES3.LoadListInt("primaryBuildingsSaveList6");
		}
		if (ES3.Exists("hollowBuildingIndexSaveList1"))
		{
			this.hollowBuildingIndexSaveList1 = ES3.LoadListInt("hollowBuildingIndexSaveList1");
		}
		if (ES3.Exists("hollowBuildingIndexSaveList2"))
		{
			this.hollowBuildingIndexSaveList2 = ES3.LoadListInt("hollowBuildingIndexSaveList2");
		}
		if (ES3.Exists("hollowBuildingIndexSaveList3"))
		{
			this.hollowBuildingIndexSaveList3 = ES3.LoadListInt("hollowBuildingIndexSaveList3");
		}
		if (ES3.Exists("hollowBuildingIndexSaveList4"))
		{
			this.hollowBuildingIndexSaveList4 = ES3.LoadListInt("hollowBuildingIndexSaveList4");
		}
		if (ES3.Exists("hollowBuildingIndexSaveList5"))
		{
			this.hollowBuildingIndexSaveList5 = ES3.LoadListInt("hollowBuildingIndexSaveList5");
		}
		if (ES3.Exists("hollowBuildingIndexSaveList6"))
		{
			this.hollowBuildingIndexSaveList6 = ES3.LoadListInt("hollowBuildingIndexSaveList6");
		}
		for (int i = 0; i < this.buildings.Length; i++)
		{
			this.randomNumbers.Add(i);
		}
		this.SpawnLaikaFactory();
		if (this.turkAIColFlickers.Length > 1)
		{
			base.StartCoroutine("TurkAIFlick1Go");
		}
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x000864BC File Offset: 0x000848BC
	private IEnumerator TurkAIFlick1Go()
	{
		this.turkAIColFlickers[0].GetComponent<Collider>().enabled = true;
		this.turkAIColFlickers[1].GetComponent<Collider>().enabled = false;
		this.turkAIColFlickers[2].GetComponent<Collider>().enabled = false;
		yield return new WaitForSeconds(5f);
		base.StartCoroutine("TurkAIFlick2Go");
		yield break;
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x000864D8 File Offset: 0x000848D8
	private IEnumerator TurkAIFlick2Go()
	{
		this.turkAIColFlickers[0].GetComponent<Collider>().enabled = false;
		this.turkAIColFlickers[1].GetComponent<Collider>().enabled = true;
		this.turkAIColFlickers[2].GetComponent<Collider>().enabled = false;
		yield return new WaitForSeconds(5f);
		base.StartCoroutine("TurkAIFlick3Go");
		yield break;
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x000864F4 File Offset: 0x000848F4
	private IEnumerator TurkAIFlick3Go()
	{
		this.turkAIColFlickers[0].GetComponent<Collider>().enabled = false;
		this.turkAIColFlickers[1].GetComponent<Collider>().enabled = false;
		this.turkAIColFlickers[2].GetComponent<Collider>().enabled = true;
		yield return new WaitForSeconds(5f);
		base.StartCoroutine("TurkAIFlick1Go");
		yield break;
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x00086510 File Offset: 0x00084910
	public int SpawnLaikaFactory()
	{
		if (this.randomNumbers.Count <= 0)
		{
			return -1;
		}
		int num = UnityEngine.Random.Range(0, this.randomNumbers.Count);
		int num2 = this.randomNumbers[num];
		if (this.countryHUBCode == 1)
		{
			if (this.hollowBuildingIndexSaveList1.Count > 0)
			{
				num = this.hollowBuildingIndexSaveList1[0];
			}
			else
			{
				this.hollowBuildingIndexSaveList1.Add(num);
			}
			if (this.primaryBuildingsSaveList1.Count > 0)
			{
				num2 = this.primaryBuildingsSaveList1[0];
			}
			else
			{
				this.primaryBuildingsSaveList1.Add(num2);
			}
		}
		else if (this.countryHUBCode == 2)
		{
			if (this.hollowBuildingIndexSaveList2.Count > 0)
			{
				num = this.hollowBuildingIndexSaveList2[0];
			}
			else
			{
				this.hollowBuildingIndexSaveList2.Add(num);
			}
			if (this.primaryBuildingsSaveList2.Count > 0)
			{
				num2 = this.primaryBuildingsSaveList2[0];
			}
			else
			{
				this.primaryBuildingsSaveList2.Add(num2);
			}
		}
		else if (this.countryHUBCode == 3)
		{
			if (this.hollowBuildingIndexSaveList3.Count > 0)
			{
				num = this.hollowBuildingIndexSaveList3[0];
			}
			else
			{
				this.hollowBuildingIndexSaveList3.Add(num);
			}
			if (this.primaryBuildingsSaveList3.Count > 0)
			{
				num2 = this.primaryBuildingsSaveList3[0];
			}
			else
			{
				this.primaryBuildingsSaveList3.Add(num2);
			}
		}
		else if (this.countryHUBCode == 4)
		{
			if (this.hollowBuildingIndexSaveList4.Count > 0)
			{
				num = this.hollowBuildingIndexSaveList4[0];
			}
			else
			{
				this.hollowBuildingIndexSaveList4.Add(num);
			}
			if (this.primaryBuildingsSaveList4.Count > 0)
			{
				num2 = this.primaryBuildingsSaveList4[0];
			}
			else
			{
				this.primaryBuildingsSaveList4.Add(num2);
			}
		}
		else if (this.countryHUBCode == 5)
		{
			if (this.hollowBuildingIndexSaveList5.Count > 0)
			{
				num = this.hollowBuildingIndexSaveList5[0];
			}
			else
			{
				this.hollowBuildingIndexSaveList5.Add(num);
			}
			if (this.primaryBuildingsSaveList5.Count > 0)
			{
				num2 = this.primaryBuildingsSaveList5[0];
			}
			else
			{
				this.primaryBuildingsSaveList5.Add(num2);
			}
		}
		else if (this.countryHUBCode == 6)
		{
			if (this.hollowBuildingIndexSaveList6.Count > 0)
			{
				num = this.hollowBuildingIndexSaveList6[0];
			}
			else
			{
				this.hollowBuildingIndexSaveList6.Add(num);
			}
			if (this.primaryBuildingsSaveList6.Count > 0)
			{
				num2 = this.primaryBuildingsSaveList6[0];
			}
			else
			{
				this.primaryBuildingsSaveList6.Add(num2);
			}
		}
		if (num >= this.randomNumbers.Count)
		{
			num = this.randomNumbers.Count - 1;
		}
		this.randomNumbers.RemoveAt(num);
		if (num2 >= this.buildings.Length)
		{
			num2 = this.buildings.Length - 1;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.laikaFactory, this.buildings[num2].transform.position, this.buildings[num2].transform.rotation);
		gameObject.transform.parent = this.buildings[num2].transform;
		gameObject.transform.localEulerAngles = new Vector3(0f, -90f, -90f);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		if (this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget != null)
		{
			this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget.GetComponent<Hub_RoadSpawnC>().canHaveParking = false;
		}
		if (!this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().doNotChangeRoad)
		{
			GameObject roadTarget = this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget;
			if (roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections == 0)
			{
				roadTarget.GetComponent<MeshFilter>().mesh = this.tJunction;
				if (roadTarget.GetComponent<Collider>())
				{
					UnityEngine.Object.Destroy(roadTarget.GetComponent<Collider>());
				}
				if (roadTarget.transform.GetChild(0))
				{
					if (roadTarget.transform.GetChild(0).GetComponent<MeshCollider>())
					{
						UnityEngine.Object.Destroy(roadTarget.transform.GetChild(0).GetComponent<MeshCollider>());
					}
					if (!roadTarget.transform.GetChild(0).GetComponent<BoxCollider>())
					{
						roadTarget.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
					}
					BoxCollider component = roadTarget.transform.GetChild(0).GetComponent<BoxCollider>();
					component.size = new Vector3(30f, 30f, 20f);
					component.center = new Vector3(component.center.x, component.center.y, -10f);
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().size = component.size;
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().center = component.center;
				}
				roadTarget.transform.localEulerAngles = this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().tJunctionRot;
				UnityEngine.Object.Destroy(roadTarget.GetComponent<Hub_RoadSpawnC>().pavement);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.tJunctionPavement, roadTarget.transform.position, roadTarget.transform.rotation);
				gameObject2.transform.parent = roadTarget.transform;
				gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
				roadTarget.GetComponent<Hub_RoadSpawnC>().pavement = gameObject2;
				roadTarget.GetComponent<Hub_RoadSpawnC>().roadType = 2;
			}
			if (roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections == 1)
			{
				roadTarget.GetComponent<MeshFilter>().mesh = this.crossRoads;
				roadTarget.GetComponent<Hub_RoadSpawnC>().roadType = 3;
				if (roadTarget.GetComponent<Collider>())
				{
					UnityEngine.Object.Destroy(roadTarget.GetComponent<Collider>());
				}
				if (roadTarget.transform.GetChild(0))
				{
					if (roadTarget.transform.GetChild(0).GetComponent<MeshCollider>())
					{
						UnityEngine.Object.Destroy(roadTarget.transform.GetChild(0).GetComponent<MeshCollider>());
					}
					if (!roadTarget.transform.GetChild(0).GetComponent<BoxCollider>())
					{
						roadTarget.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
					}
					BoxCollider component2 = roadTarget.transform.GetChild(0).GetComponent<BoxCollider>();
					component2.size = new Vector3(30f, 30f, 20f);
					component2.center = new Vector3(component2.center.x, component2.center.y, -10f);
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().size = component2.size;
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().center = component2.center;
				}
				UnityEngine.Object.Destroy(roadTarget.GetComponent<Hub_RoadSpawnC>().pavement);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.crossroadPavement, roadTarget.transform.position, roadTarget.transform.rotation);
				gameObject3.transform.parent = roadTarget.transform;
				gameObject3.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
				gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
				roadTarget.GetComponent<Hub_RoadSpawnC>().pavement = gameObject3;
				roadTarget.GetComponent<Hub_RoadSpawnC>().roadType = 3;
			}
			roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections++;
		}
		this.SpawnMarket();
		return num2;
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00086D30 File Offset: 0x00085130
	public int SpawnMarket()
	{
		if (this.randomNumbers.Count <= 0)
		{
			return -1;
		}
		int num = UnityEngine.Random.Range(0, this.randomNumbers.Count);
		int num2 = this.randomNumbers[num];
		if (this.countryHUBCode == 1)
		{
			if (this.hollowBuildingIndexSaveList1.Count > 1)
			{
				num = this.hollowBuildingIndexSaveList1[1];
			}
			else
			{
				this.hollowBuildingIndexSaveList1.Add(num);
			}
			if (this.primaryBuildingsSaveList1.Count > 1)
			{
				num2 = this.primaryBuildingsSaveList1[1];
			}
			else
			{
				this.primaryBuildingsSaveList1.Add(num2);
			}
		}
		else if (this.countryHUBCode == 2)
		{
			if (this.hollowBuildingIndexSaveList2.Count > 1)
			{
				num = this.hollowBuildingIndexSaveList2[1];
			}
			else
			{
				this.hollowBuildingIndexSaveList2.Add(num);
			}
			if (this.primaryBuildingsSaveList2.Count > 1)
			{
				num2 = this.primaryBuildingsSaveList2[1];
			}
			else
			{
				this.primaryBuildingsSaveList2.Add(num2);
			}
		}
		else if (this.countryHUBCode == 3)
		{
			if (this.hollowBuildingIndexSaveList3.Count > 1)
			{
				num = this.hollowBuildingIndexSaveList3[1];
			}
			else
			{
				this.hollowBuildingIndexSaveList3.Add(num);
			}
			if (this.primaryBuildingsSaveList3.Count > 1)
			{
				num2 = this.primaryBuildingsSaveList3[1];
			}
			else
			{
				this.primaryBuildingsSaveList3.Add(num2);
			}
		}
		else if (this.countryHUBCode == 4)
		{
			if (this.hollowBuildingIndexSaveList4.Count > 1)
			{
				num = this.hollowBuildingIndexSaveList4[1];
			}
			else
			{
				this.hollowBuildingIndexSaveList4.Add(num);
			}
			if (this.primaryBuildingsSaveList4.Count > 1)
			{
				num2 = this.primaryBuildingsSaveList4[1];
			}
			else
			{
				this.primaryBuildingsSaveList4.Add(num2);
			}
		}
		else if (this.countryHUBCode == 5)
		{
			if (this.hollowBuildingIndexSaveList5.Count > 1)
			{
				num = this.hollowBuildingIndexSaveList5[1];
			}
			else
			{
				this.hollowBuildingIndexSaveList5.Add(num);
			}
			if (this.primaryBuildingsSaveList5.Count > 1)
			{
				num2 = this.primaryBuildingsSaveList5[1];
			}
			else
			{
				this.primaryBuildingsSaveList5.Add(num2);
			}
		}
		else if (this.countryHUBCode == 6)
		{
			if (this.hollowBuildingIndexSaveList6.Count > 1)
			{
				num = this.hollowBuildingIndexSaveList6[1];
			}
			else
			{
				this.hollowBuildingIndexSaveList6.Add(num);
			}
			if (this.primaryBuildingsSaveList6.Count > 1)
			{
				num2 = this.primaryBuildingsSaveList6[1];
			}
			else
			{
				this.primaryBuildingsSaveList6.Add(num2);
			}
		}
		if (num >= this.randomNumbers.Count)
		{
			num = this.randomNumbers.Count - 1;
		}
		this.randomNumbers.RemoveAt(num);
		if (num2 >= this.buildings.Length)
		{
			num2 = this.buildings.Length - 2;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.market, this.buildings[num2].transform.position, this.buildings[num2].transform.rotation);
		if (this.wakeUpInTown)
		{
			gameObject.GetComponent<StoreC>().wakeUpInTown = true;
		}
		gameObject.transform.parent = this.buildings[num2].transform;
		gameObject.transform.localEulerAngles = new Vector3(0f, -90f, -90f);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		if (this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget != null)
		{
			this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget.GetComponent<Hub_RoadSpawnC>().canHaveParking = false;
		}
		if (!this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().doNotChangeRoad)
		{
			GameObject roadTarget = this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget;
			if (roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections == 0)
			{
				roadTarget.GetComponent<MeshFilter>().mesh = this.tJunction;
				roadTarget.transform.localEulerAngles = this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().tJunctionRot;
				if (roadTarget.GetComponent<Collider>())
				{
					UnityEngine.Object.Destroy(roadTarget.GetComponent<Collider>());
				}
				if (roadTarget.transform.GetChild(0))
				{
					if (roadTarget.transform.GetChild(0).GetComponent<MeshCollider>())
					{
						UnityEngine.Object.Destroy(roadTarget.transform.GetChild(0).GetComponent<MeshCollider>());
					}
					if (!roadTarget.transform.GetChild(0).GetComponent<BoxCollider>())
					{
						roadTarget.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
					}
					BoxCollider component = roadTarget.transform.GetChild(0).GetComponent<BoxCollider>();
					component.size = new Vector3(30f, 30f, 20f);
					component.center = new Vector3(component.center.x, component.center.y, -10f);
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().size = component.size;
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().center = component.center;
				}
				UnityEngine.Object.Destroy(roadTarget.GetComponent<Hub_RoadSpawnC>().pavement);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.tJunctionPavement, roadTarget.transform.position, roadTarget.transform.rotation);
				gameObject2.transform.parent = roadTarget.transform;
				gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
				roadTarget.GetComponent<Hub_RoadSpawnC>().pavement = gameObject2;
				roadTarget.GetComponent<Hub_RoadSpawnC>().roadType = 2;
			}
			if (roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections == 1)
			{
				roadTarget.GetComponent<MeshFilter>().mesh = this.crossRoads;
				if (roadTarget.GetComponent<Collider>())
				{
					UnityEngine.Object.Destroy(roadTarget.GetComponent<Collider>());
				}
				if (roadTarget.transform.GetChild(0))
				{
					if (roadTarget.transform.GetChild(0).GetComponent<MeshCollider>())
					{
						UnityEngine.Object.Destroy(roadTarget.transform.GetChild(0).GetComponent<MeshCollider>());
					}
					if (!roadTarget.transform.GetChild(0).GetComponent<BoxCollider>())
					{
						roadTarget.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
					}
					BoxCollider component2 = roadTarget.transform.GetChild(0).GetComponent<BoxCollider>();
					component2.size = new Vector3(30f, 30f, 20f);
					component2.center = new Vector3(component2.center.x, component2.center.y, -10f);
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().size = component2.size;
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().center = component2.center;
				}
				UnityEngine.Object.Destroy(roadTarget.GetComponent<Hub_RoadSpawnC>().pavement);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.crossroadPavement, roadTarget.transform.position, roadTarget.transform.rotation);
				gameObject3.transform.parent = roadTarget.transform;
				gameObject3.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
				gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
				roadTarget.GetComponent<Hub_RoadSpawnC>().pavement = gameObject3;
				roadTarget.GetComponent<Hub_RoadSpawnC>().roadType = 3;
			}
			roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections++;
		}
		this.SpawnMotel();
		return num2;
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0008755C File Offset: 0x0008595C
	public void GateOpen()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
			{
				"x",
				37.5,
				"time",
				8.0,
				"islocal",
				true,
				"easetype",
				"easeoutsine"
			}));
		}
		else
		{
			iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
			{
				"x",
				15,
				"time",
				8.0,
				"islocal",
				true,
				"easetype",
				"easeoutsine"
			}));
			if (this.bulgarianMountainScenery != null)
			{
				this.bulgarianMountainScenery.active = false;
			}
		}
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x00087674 File Offset: 0x00085A74
	public void GateClose()
	{
		iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
		{
			"x",
			0,
			"time",
			8.0,
			"islocal",
			true,
			"easetype",
			"easeoutsine"
		}));
		if (this.wakeUpInTown && this.bulgarianMountainScenery != null)
		{
			this.bulgarianMountainScenery.active = true;
		}
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x0008770C File Offset: 0x00085B0C
	public int SpawnMotel()
	{
		if (this.randomNumbers.Count <= 0)
		{
			return -1;
		}
		int num = UnityEngine.Random.Range(0, this.randomNumbers.Count);
		int num2 = this.randomNumbers[num];
		if (this.countryHUBCode == 1)
		{
			if (this.hollowBuildingIndexSaveList1.Count > 2)
			{
				num = this.hollowBuildingIndexSaveList1[2];
			}
			else
			{
				this.hollowBuildingIndexSaveList1.Add(num);
			}
			if (this.primaryBuildingsSaveList1.Count > 2)
			{
				num2 = this.primaryBuildingsSaveList1[2];
			}
			else
			{
				this.primaryBuildingsSaveList1.Add(num2);
			}
		}
		else if (this.countryHUBCode == 2)
		{
			if (this.hollowBuildingIndexSaveList2.Count > 2)
			{
				num = this.hollowBuildingIndexSaveList2[2];
			}
			else
			{
				this.hollowBuildingIndexSaveList2.Add(num);
			}
			if (this.primaryBuildingsSaveList2.Count > 2)
			{
				num2 = this.primaryBuildingsSaveList2[2];
			}
			else
			{
				this.primaryBuildingsSaveList2.Add(num2);
			}
		}
		else if (this.countryHUBCode == 3)
		{
			if (this.hollowBuildingIndexSaveList3.Count > 2)
			{
				num = this.hollowBuildingIndexSaveList3[2];
			}
			else
			{
				this.hollowBuildingIndexSaveList3.Add(num);
			}
			if (this.primaryBuildingsSaveList3.Count > 2)
			{
				num2 = this.primaryBuildingsSaveList3[2];
			}
			else
			{
				this.primaryBuildingsSaveList3.Add(num2);
			}
		}
		else if (this.countryHUBCode == 4)
		{
			if (this.hollowBuildingIndexSaveList4.Count > 2)
			{
				num = this.hollowBuildingIndexSaveList4[2];
			}
			else
			{
				this.hollowBuildingIndexSaveList4.Add(num);
			}
			if (this.primaryBuildingsSaveList4.Count > 2)
			{
				num2 = this.primaryBuildingsSaveList4[2];
			}
			else
			{
				this.primaryBuildingsSaveList4.Add(num2);
			}
		}
		else if (this.countryHUBCode == 5)
		{
			if (this.hollowBuildingIndexSaveList5.Count > 2)
			{
				num = this.hollowBuildingIndexSaveList5[2];
			}
			else
			{
				this.hollowBuildingIndexSaveList5.Add(num);
			}
			if (this.primaryBuildingsSaveList5.Count > 2)
			{
				num2 = this.primaryBuildingsSaveList5[2];
			}
			else
			{
				this.primaryBuildingsSaveList5.Add(num2);
			}
		}
		else if (this.countryHUBCode == 6)
		{
			if (this.hollowBuildingIndexSaveList6.Count > 2)
			{
				num = this.hollowBuildingIndexSaveList6[2];
			}
			else
			{
				this.hollowBuildingIndexSaveList6.Add(num);
			}
			if (this.primaryBuildingsSaveList6.Count > 2)
			{
				num2 = this.primaryBuildingsSaveList6[2];
			}
			else
			{
				this.primaryBuildingsSaveList6.Add(num2);
			}
		}
		if (num >= this.randomNumbers.Count)
		{
			num = this.randomNumbers.Count - 1;
		}
		this.randomNumbers.RemoveAt(num);
		if (num2 >= this.buildings.Length)
		{
			num2 = this.buildings.Length - 3;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.motel, this.buildings[num2].transform.position, this.buildings[num2].transform.rotation);
		this.spawnedMotel = gameObject;
		gameObject.transform.parent = this.buildings[num2].transform;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		if (this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget != null)
		{
			this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget.GetComponent<Hub_RoadSpawnC>().canHaveParking = false;
		}
		if (!this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().doNotChangeRoad)
		{
			GameObject roadTarget = this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().roadTarget;
			if (roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections == 0)
			{
				roadTarget.GetComponent<MeshFilter>().mesh = this.tJunction;
				roadTarget.transform.localEulerAngles = this.buildings[num2].GetComponent<Hub_BuildingSpawnC>().tJunctionRot;
				if (roadTarget.GetComponent<Collider>())
				{
					UnityEngine.Object.Destroy(roadTarget.GetComponent<Collider>());
				}
				if (roadTarget.transform.GetChild(0))
				{
					if (roadTarget.transform.GetChild(0).GetComponent<MeshCollider>())
					{
						UnityEngine.Object.Destroy(roadTarget.transform.GetChild(0).GetComponent<MeshCollider>());
					}
					if (!roadTarget.transform.GetChild(0).GetComponent<BoxCollider>())
					{
						roadTarget.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
					}
					BoxCollider component = roadTarget.transform.GetChild(0).GetComponent<BoxCollider>();
					component.size = new Vector3(30f, 30f, 20f);
					component.center = new Vector3(component.center.x, component.center.y, -10f);
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().size = component.size;
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().center = component.center;
				}
				UnityEngine.Object.Destroy(roadTarget.GetComponent<Hub_RoadSpawnC>().pavement);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.tJunctionPavement, roadTarget.transform.position, roadTarget.transform.rotation);
				gameObject2.transform.parent = roadTarget.transform;
				gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
				roadTarget.GetComponent<Hub_RoadSpawnC>().pavement = gameObject2;
				roadTarget.GetComponent<Hub_RoadSpawnC>().roadType = 2;
			}
			else if (roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections == 1)
			{
				roadTarget.GetComponent<MeshFilter>().mesh = this.crossRoads;
				if (roadTarget.GetComponent<Collider>())
				{
					UnityEngine.Object.Destroy(roadTarget.GetComponent<Collider>());
				}
				if (roadTarget.transform.GetChild(0))
				{
					if (roadTarget.transform.GetChild(0).GetComponent<MeshCollider>())
					{
						UnityEngine.Object.Destroy(roadTarget.transform.GetChild(0).GetComponent<MeshCollider>());
					}
					if (!roadTarget.transform.GetChild(0).GetComponent<BoxCollider>())
					{
						roadTarget.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
					}
					BoxCollider component2 = roadTarget.transform.GetChild(0).GetComponent<BoxCollider>();
					component2.size = new Vector3(30f, 30f, 20f);
					component2.center = new Vector3(component2.center.x, component2.center.y, -10f);
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().size = component2.size;
					roadTarget.transform.GetChild(0).GetComponent<BoxCollider>().center = component2.center;
				}
				UnityEngine.Object.Destroy(roadTarget.GetComponent<Hub_RoadSpawnC>().pavement);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.crossroadPavement, roadTarget.transform.position, roadTarget.transform.rotation);
				gameObject3.transform.parent = roadTarget.transform;
				gameObject3.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
				gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
				roadTarget.GetComponent<Hub_RoadSpawnC>().pavement = gameObject3;
				roadTarget.GetComponent<Hub_RoadSpawnC>().roadType = 3;
			}
			roadTarget.GetComponent<Hub_RoadSpawnC>().roadConnections++;
		}
		this.spawnedMotel.GetComponent<MotelParentC>().motelLogic.GetComponent<MotelLogicC>().SetMotelPrice();
		this.SpawnHollows();
		if (this.wakeUpInTown)
		{
			gameObject.GetComponent<MotelParentC>().WakeUpInTown();
			GameObject gameObject4 = GameObject.FindWithTag("Director");
			gameObject4.GetComponent<RouteGeneratorC>().firstSegmentTarget = this.continueTarget;
			gameObject4.GetComponent<RouteGeneratorC>().spawnedHub = base.gameObject;
		}
		return num2;
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x00087F6C File Offset: 0x0008636C
	public void SaveTownLayout()
	{
		if (this.countryHUBCode == 1)
		{
			if (this.primaryBuildingsSaveList1.Count > 0)
			{
				ES3.Save(this.primaryBuildingsSaveList1, "primaryBuildingsSaveList1");
			}
			if (this.hollowBuildingIndexSaveList1.Count > 0)
			{
				ES3.Save(this.hollowBuildingIndexSaveList1, "hollowBuildingIndexSaveList1");
			}
		}
		else if (this.countryHUBCode == 2)
		{
			if (this.primaryBuildingsSaveList2.Count > 0)
			{
				ES3.Save(this.primaryBuildingsSaveList2, "primaryBuildingsSaveList2");
			}
			if (this.hollowBuildingIndexSaveList2.Count > 0)
			{
				ES3.Save(this.hollowBuildingIndexSaveList2, "hollowBuildingIndexSaveList2");
			}
		}
		else if (this.countryHUBCode == 3)
		{
			if (this.primaryBuildingsSaveList3.Count > 0)
			{
				ES3.Save(this.primaryBuildingsSaveList3, "primaryBuildingsSaveList3");
			}
			if (this.hollowBuildingIndexSaveList3.Count > 0)
			{
				ES3.Save(this.hollowBuildingIndexSaveList3, "hollowBuildingIndexSaveList3");
			}
		}
		else if (this.countryHUBCode == 4)
		{
			if (this.primaryBuildingsSaveList4.Count > 0)
			{
				ES3.Save(this.primaryBuildingsSaveList4, "primaryBuildingsSaveList4");
			}
			if (this.hollowBuildingIndexSaveList4.Count > 0)
			{
				ES3.Save(this.hollowBuildingIndexSaveList4, "hollowBuildingIndexSaveList4");
			}
		}
		else if (this.countryHUBCode == 5)
		{
			if (this.primaryBuildingsSaveList5.Count > 0)
			{
				ES3.Save(this.primaryBuildingsSaveList5, "primaryBuildingsSaveList5");
			}
			if (this.hollowBuildingIndexSaveList5.Count > 0)
			{
				ES3.Save(this.hollowBuildingIndexSaveList5, "hollowBuildingIndexSaveList5");
			}
		}
		else if (this.countryHUBCode == 6)
		{
			if (this.primaryBuildingsSaveList6.Count > 0)
			{
				ES3.Save(this.primaryBuildingsSaveList6, "primaryBuildingsSaveList6");
			}
			if (this.hollowBuildingIndexSaveList6.Count > 0)
			{
				ES3.Save(this.hollowBuildingIndexSaveList6, "hollowBuildingIndexSaveList6");
			}
		}
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x00088168 File Offset: 0x00086568
	public void SpawnHollows()
	{
		for (int i = 0; i < this.randomNumbers.Count; i++)
		{
			int num = this.randomNumbers[i];
			GameObject gameObject = this.buildings[num];
			if (this.buildings[num].GetComponent<Hub_BuildingSpawnC>().roadTarget != null)
			{
				gameObject = this.buildings[num].GetComponent<Hub_BuildingSpawnC>().roadTarget;
			}
			if (this.buildings[num].GetComponent<Hub_BuildingSpawnC>().isCornerBuilding)
			{
				int num2 = UnityEngine.Random.Range(0, this.hollowBuildingsCorner.Length);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.hollowBuildingsCorner[num2], this.buildings[num].transform.position, this.buildings[num].transform.rotation);
				gameObject2.transform.parent = this.buildings[num].transform;
				gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			else
			{
				int num3 = UnityEngine.Random.Range(0, this.hollowBuildings.Length);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.hollowBuildings[num3], this.buildings[num].transform.position, this.buildings[num].transform.rotation);
				gameObject3.transform.parent = this.buildings[num].transform;
				gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject3.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			if (this.buildings[num].GetComponent<Hub_BuildingSpawnC>().roadTarget != null && this.buildings[num].GetComponent<Hub_BuildingSpawnC>().roadTarget.GetComponent<Hub_RoadSpawnC>().canHaveParking)
			{
				int num4 = UnityEngine.Random.Range(0, 2);
				if (num4 == 1)
				{
					gameObject.GetComponent<MeshFilter>().mesh = this.parkingRoad;
					if (gameObject.GetComponent<Collider>())
					{
						UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
					}
					if (gameObject.transform.GetChild(0))
					{
						if (gameObject.transform.GetChild(0).GetComponent<MeshCollider>())
						{
							UnityEngine.Object.Destroy(gameObject.transform.GetChild(0).GetComponent<MeshCollider>());
						}
						if (!gameObject.transform.GetChild(0).GetComponent<BoxCollider>())
						{
							gameObject.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
						}
						BoxCollider component = gameObject.transform.GetChild(0).GetComponent<BoxCollider>();
						component.size = new Vector3(30f, 30f, 20f);
						component.center = new Vector3(component.center.x, component.center.y, -10f);
					}
					UnityEngine.Object.Destroy(gameObject.GetComponent<Hub_RoadSpawnC>().pavement);
					GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.parkingPavement, gameObject.transform.position, gameObject.transform.rotation);
					gameObject4.transform.parent = gameObject.transform;
					gameObject4.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
					gameObject4.transform.localScale = new Vector3(1f, 1f, 1f);
					gameObject.GetComponent<Hub_RoadSpawnC>().pavement = gameObject4;
					gameObject.GetComponent<Hub_RoadSpawnC>().roadType = 1;
				}
				else
				{
					gameObject.GetComponent<Hub_RoadSpawnC>().roadType = 0;
				}
			}
		}
		this.SpawnExtHollows();
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x00088534 File Offset: 0x00086934
	public void SpawnExtHollows()
	{
		for (int i = 0; i < this.exteriorBuildings.Length; i++)
		{
			int num = UnityEngine.Random.Range(0, this.exteriorHollowBuildings.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.exteriorHollowBuildings[num], this.exteriorBuildings[i].transform.position, this.exteriorBuildings[i].transform.rotation);
			gameObject.transform.parent = this.exteriorBuildings[i].transform;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		}
		this.SpawnMonuments();
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x000885F8 File Offset: 0x000869F8
	public void SpawnMonuments()
	{
		for (int i = 0; i < this.monumentLocs.Length; i++)
		{
			int num = UnityEngine.Random.Range(0, this.monuments.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.monuments[num], this.monumentLocs[i].transform.position, this.monumentLocs[i].transform.rotation);
			gameObject.transform.parent = this.monumentLocs[i].transform;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		}
		this.SpawnStreetClutter();
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x000886BC File Offset: 0x00086ABC
	public void SpawnStreetClutter()
	{
		if (this.streetClutter)
		{
			for (int i = 0; i < this.roadTargets.Length; i++)
			{
				if (this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().roadType == 1)
				{
					int num = UnityEngine.Random.Range(0, this.parkingStreetClutter.Length);
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.parkingStreetClutter[num], this.roadTargets[i].transform.position, this.roadTargets[i].transform.rotation);
					gameObject.transform.parent = this.roadTargets[i].transform;
					gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
					gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().streetClutter = gameObject;
				}
				else if (this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().roadType == 0)
				{
					int num2 = UnityEngine.Random.Range(0, this.straightStreetClutter.Length);
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.straightStreetClutter[num2], this.roadTargets[i].transform.position, this.roadTargets[i].transform.rotation);
					gameObject2.transform.parent = this.roadTargets[i].transform;
					gameObject2.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
					gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
					this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().streetClutter = gameObject2;
				}
				else if (this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().roadType == 4)
				{
					int num3 = UnityEngine.Random.Range(0, this.cornerStreetClutter.Length);
					GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.cornerStreetClutter[num3], this.roadTargets[i].transform.position, this.roadTargets[i].transform.rotation);
					gameObject3.transform.parent = this.roadTargets[i].transform;
					gameObject3.transform.localEulerAngles = Vector3.zero;
					gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
					this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().streetClutter = gameObject3;
				}
				else if (this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().roadType == 2)
				{
					int num4 = UnityEngine.Random.Range(0, this.tjunctionStreetClutter.Length);
					GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.tjunctionStreetClutter[num4], this.roadTargets[i].transform.position, this.roadTargets[i].transform.rotation);
					gameObject4.transform.parent = this.roadTargets[i].transform;
					gameObject4.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
					gameObject4.transform.localScale = new Vector3(1f, 1f, 1f);
					this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().streetClutter = gameObject4;
				}
				else if (this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().roadType == 3)
				{
					int num5 = UnityEngine.Random.Range(0, this.crossroadStreetClutter.Length);
					GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.crossroadStreetClutter[num5], this.roadTargets[i].transform.position, this.roadTargets[i].transform.rotation);
					gameObject5.transform.parent = this.roadTargets[i].transform;
					gameObject5.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
					gameObject5.transform.localScale = new Vector3(1f, 1f, 1f);
					this.roadTargets[i].GetComponent<Hub_RoadSpawnC>().streetClutter = gameObject5;
				}
			}
		}
	}

	// Token: 0x04000904 RID: 2308
	public int countryHUBCode;

	// Token: 0x04000905 RID: 2309
	public int startSize;

	// Token: 0x04000906 RID: 2310
	public GameObject gateObj;

	// Token: 0x04000907 RID: 2311
	public GameObject[] buildings = new GameObject[0];

	// Token: 0x04000908 RID: 2312
	public GameObject[] exteriorBuildings = new GameObject[0];

	// Token: 0x04000909 RID: 2313
	public GameObject[] monumentLocs = new GameObject[0];

	// Token: 0x0400090A RID: 2314
	public List<int> randomNumbers = new List<int>();

	// Token: 0x0400090B RID: 2315
	public GameObject laikaFactory;

	// Token: 0x0400090C RID: 2316
	public GameObject market;

	// Token: 0x0400090D RID: 2317
	public GameObject motel;

	// Token: 0x0400090E RID: 2318
	public GameObject petrolStation;

	// Token: 0x0400090F RID: 2319
	public GameObject musicShop;

	// Token: 0x04000910 RID: 2320
	public GameObject[] hitchHikers = new GameObject[0];

	// Token: 0x04000911 RID: 2321
	public GameObject[] hollowBuildings = new GameObject[0];

	// Token: 0x04000912 RID: 2322
	public GameObject[] hollowBuildingsCorner = new GameObject[0];

	// Token: 0x04000913 RID: 2323
	public GameObject[] exteriorHollowBuildings = new GameObject[0];

	// Token: 0x04000914 RID: 2324
	public GameObject[] monuments = new GameObject[0];

	// Token: 0x04000915 RID: 2325
	public Mesh tJunction;

	// Token: 0x04000916 RID: 2326
	public Mesh crossRoads;

	// Token: 0x04000917 RID: 2327
	public Mesh parkingRoad;

	// Token: 0x04000918 RID: 2328
	public GameObject tJunctionPavement;

	// Token: 0x04000919 RID: 2329
	public GameObject crossroadPavement;

	// Token: 0x0400091A RID: 2330
	public GameObject parkingPavement;

	// Token: 0x0400091B RID: 2331
	public Transform[] roadTargets = new Transform[0];

	// Token: 0x0400091C RID: 2332
	public bool streetClutter = true;

	// Token: 0x0400091D RID: 2333
	public GameObject[] straightStreetClutter = new GameObject[0];

	// Token: 0x0400091E RID: 2334
	public GameObject[] parkingStreetClutter = new GameObject[0];

	// Token: 0x0400091F RID: 2335
	public GameObject[] cornerStreetClutter = new GameObject[0];

	// Token: 0x04000920 RID: 2336
	public GameObject[] tjunctionStreetClutter = new GameObject[0];

	// Token: 0x04000921 RID: 2337
	public GameObject[] crossroadStreetClutter = new GameObject[0];

	// Token: 0x04000922 RID: 2338
	public GameObject continueTarget;

	// Token: 0x04000923 RID: 2339
	public bool wakeUpInTown;

	// Token: 0x04000924 RID: 2340
	public GameObject bulgarianMountainScenery;

	// Token: 0x04000925 RID: 2341
	public GameObject spawnedYugoScenery;

	// Token: 0x04000926 RID: 2342
	private List<int> primaryBuildingsSaveList1 = new List<int>();

	// Token: 0x04000927 RID: 2343
	private List<int> primaryBuildingsSaveList2 = new List<int>();

	// Token: 0x04000928 RID: 2344
	private List<int> primaryBuildingsSaveList3 = new List<int>();

	// Token: 0x04000929 RID: 2345
	private List<int> primaryBuildingsSaveList4 = new List<int>();

	// Token: 0x0400092A RID: 2346
	private List<int> primaryBuildingsSaveList5 = new List<int>();

	// Token: 0x0400092B RID: 2347
	private List<int> primaryBuildingsSaveList6 = new List<int>();

	// Token: 0x0400092C RID: 2348
	private List<int> hollowBuildingIndexSaveList1 = new List<int>();

	// Token: 0x0400092D RID: 2349
	private List<int> hollowBuildingIndexSaveList2 = new List<int>();

	// Token: 0x0400092E RID: 2350
	private List<int> hollowBuildingIndexSaveList3 = new List<int>();

	// Token: 0x0400092F RID: 2351
	private List<int> hollowBuildingIndexSaveList4 = new List<int>();

	// Token: 0x04000930 RID: 2352
	private List<int> hollowBuildingIndexSaveList5 = new List<int>();

	// Token: 0x04000931 RID: 2353
	private List<int> hollowBuildingIndexSaveList6 = new List<int>();

	// Token: 0x04000932 RID: 2354
	public GameObject spawnedMotel;

	// Token: 0x04000933 RID: 2355
	public GameObject[] turkAIColFlickers = new GameObject[0];
}
