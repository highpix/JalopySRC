using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000EA RID: 234
public class RouteGeneratorC : MonoBehaviour
{
	// Token: 0x0600090A RID: 2314 RVA: 0x000C2948 File Offset: 0x000C0D48
	private void Awake()
	{
		RouteGeneratorC.Global = this;
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x000C2950 File Offset: 0x000C0D50
	private void OnDestroy()
	{
		RouteGeneratorC.Global = null;
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x000C2958 File Offset: 0x000C0D58
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		RouteGenerator component = base.GetComponent<RouteGenerator>();
		this.routeLevel = component.routeLevel;
		this.drivingTowardsHome = component.drivingTowardsHome;
		this.spawnedHub = component.spawnedHub;
		this.startingEnvironment = component.startingEnvironment;
		this.borderOpen = component.borderOpen;
		this.routeGenerated = component.routeGenerated;
		this.firstSegmentTarget = component.firstSegmentTarget;
		component.segmentLibraryGerStart.Copy(ref this.segmentLibraryGerStart);
		component.segmentLibraryGer3.Copy(ref this.segmentLibraryGer3);
		component.stopOffLibraryGer3.Copy(ref this.stopOffLibraryGer3);
		component.segmentLibraryGer2.Copy(ref this.segmentLibraryGer2);
		component.stopOffLibraryGer2.Copy(ref this.stopOffLibraryGer2);
		this.roundaboutGer2_2 = component.roundaboutGer2_2;
		this.roundaboutGer2_3 = component.roundaboutGer2_3;
		this.roundaboutGer3_1 = component.roundaboutGer3_1;
		this.roundaboutGer2_1 = component.roundaboutGer2_1;
		component.destinationObjectsGer.Copy(ref this.destinationObjectsGer);
		component.destinationObjectsHome.Copy(ref this.destinationObjectsHome);
		component.segmentLibraryCSFRStart.Copy(ref this.segmentLibraryCSFRStart);
		component.segmentLibraryCSFR1.Copy(ref this.segmentLibraryCSFR1);
		component.stopOffLibraryCSFR1.Copy(ref this.stopOffLibraryCSFR1);
		component.segmentLibraryCSFR0.Copy(ref this.segmentLibraryCSFR0);
		component.stopOffLibraryCSFR0.Copy(ref this.stopOffLibraryCSFR0);
		this.roundaboutCSFR1_0 = component.roundaboutCSFR1_0;
		this.roundaboutCSFR1_1 = component.roundaboutCSFR1_1;
		this.roundaboutCSFR0_1 = component.roundaboutCSFR0_1;
		component.destinationObjectsCSFR.Copy(ref this.destinationObjectsCSFR);
		component.segmentLibraryHUNStart.Copy(ref this.segmentLibraryHUNStart);
		component.segmentLibraryHUN2.Copy(ref this.segmentLibraryHUN2);
		component.stopOffLibraryHUN2.Copy(ref this.stopOffLibraryHUN2);
		component.segmentLibraryHUN0.Copy(ref this.segmentLibraryHUN0);
		component.stopOffLibraryHUN0.Copy(ref this.stopOffLibraryHUN0);
		this.roundAboutHUN2_0 = component.roundAboutHUN2_0;
		this.roundAboutHUN2_2 = component.roundAboutHUN2_2;
		this.roundaboutHUN0_0 = component.roundaboutHUN0_0;
		this.roundaboutHUN2_0 = component.roundaboutHUN2_0;
		component.destinationObjectsHUN.Copy(ref this.destinationObjectsHUN);
		component.segmentLibraryYUGOStart.Copy(ref this.segmentLibraryYUGOStart);
		component.segmentLibraryYUGO1.Copy(ref this.segmentLibraryYUGO1);
		component.stopOffLibraryYUGO1.Copy(ref this.stopOffLibraryYUGO1);
		component.segmentLibraryYUGO0.Copy(ref this.segmentLibraryYUGO0);
		component.stopOffLibraryYUGO0.Copy(ref this.stopOffLibraryYUGO0);
		this.roundaboutYUGO1_0 = component.roundaboutYUGO1_0;
		this.roundaboutYUGO1_1 = component.roundaboutYUGO1_1;
		this.roundaboutYUGO0_1 = component.roundaboutYUGO0_1;
		this.roundaboutYUGO0_0 = component.roundaboutYUGO0_0;
		component.destinationObjectsYUGO.Copy(ref this.destinationObjectsYUGO);
		this.yugoSea = component.yugoSea;
		this.yugoBackdrop = component.yugoBackdrop;
		component.segmentLibraryBULStart.Copy(ref this.segmentLibraryBULStart);
		component.segmentLibraryBUL0.Copy(ref this.segmentLibraryBUL0);
		component.stopOffLibraryBUL0.Copy(ref this.stopOffLibraryBUL0);
		component.destinationObjectsBUL.Copy(ref this.destinationObjectsBUL);
		component.segmentLibraryTURKStart.Copy(ref this.segmentLibraryTURKStart);
		component.segmentLibraryTURK1.Copy(ref this.segmentLibraryTURK1);
		component.stopOffLibraryTURK1.Copy(ref this.stopOffLibraryTURK1);
		component.segmentLibraryTURK2.Copy(ref this.segmentLibraryTURK2);
		component.stopOffLibraryTURK2.Copy(ref this.stopOffLibraryTURK2);
		component.destinationObjectsTURK.Copy(ref this.destinationObjectsTURK);
		component.segmentLibrary1.Copy(ref this.segmentLibrary1);
		component.stopOffLibrary1.Copy(ref this.stopOffLibrary1);
		component.segmentLibrary0.Copy(ref this.segmentLibrary0);
		component.stopOffLibrary0.Copy(ref this.stopOffLibrary0);
		component.sceneryIndustrial.Copy(ref this.sceneryIndustrial);
		component.sceneryResidentialGER.Copy(ref this.sceneryResidentialGER);
		component.sceneryMountainsBUL.Copy(ref this.sceneryMountainsBUL);
		component.stopOffObjects.Copy(ref this.stopOffObjects);
		component.stopOffObjects2.Copy(ref this.stopOffObjects2);
		component.stopOffObjects3.Copy(ref this.stopOffObjects3);
		component.stopOffObjects4.Copy(ref this.stopOffObjects4);
		component.stopOffObjects5.Copy(ref this.stopOffObjects5);
		component.stopOffObjects6.Copy(ref this.stopOffObjects6);
		component.blockerObjects.Copy(ref this.blockerObjects);
		component.puddlePrefabs.Copy(ref this.puddlePrefabs);
		component.lrpuddlePrefabs.Copy(ref this.lrpuddlePrefabs);
		component.hrpuddlePrefabs.Copy(ref this.hrpuddlePrefabs);
		component.route1Segments.Copy(ref this.route1Segments);
		component.route2Segments.Copy(ref this.route2Segments);
		component.route3Segments.Copy(ref this.route3Segments);
		component.route4Segments.Copy(ref this.route4Segments);
		component.cratePrefabs.Copy(ref this.cratePrefabs);
		component.abandonCarPrefabs.Copy(ref this.abandonCarPrefabs);
		component.potHolePrefabs.Copy(ref this.potHolePrefabs);
		component.oilSpillPrefabs.Copy(ref this.oilSpillPrefabs);
		component.aiCarPrefabs.Copy(ref this.aiCarPrefabs);
		component.aiDrivers.Copy(ref this.aiDrivers);
		this.roundaboutBUL0_0 = component.roundaboutBUL0_0;
		this.roundaboutTURK1_2 = component.roundaboutTURK1_2;
		this.roundaboutTURK1_1 = component.roundaboutTURK1_1;
		this.roundaboutTURK2_3 = component.roundaboutTURK2_3;
		this.roundaboutTURK1_3 = component.roundaboutTURK1_3;
		this.mapObject = component.mapObject;
		this.mapText1 = component.mapText1;
		this.mapText2 = component.mapText2;
		this.mapText3 = component.mapText3;
		this.mapText4 = component.mapText4;
		this.mapDayText = component.mapDayText;
		this.route1RoundaboutSegment = component.route1RoundaboutSegment;
		this.route2RoundaboutSegment = component.route2RoundaboutSegment;
		this.route3RoundaboutSegment = component.route3RoundaboutSegment;
		this.carLogic = component.carLogic;
		this.seatLogic = component.seatLogic;
		this.uDayCycle = component.uDayCycle;
		this.lightRain = component.lightRain;
		this.heavyRain = component.heavyRain;
		this.rainTarget = component.rainTarget;
		this.economyState = component.economyState;
		this.gerEconomyNumbers = new List<int>(component.gerEconomyNumbers);
		this.csfrEconomyNumbers = new List<int>(component.csfrEconomyNumbers);
		this.hunEconomyNumbers = new List<int>(component.hunEconomyNumbers);
		this.yugoEconomyNumbers = new List<int>(component.yugoEconomyNumbers);
		this.bulEconomyNumbers = new List<int>(component.bulEconomyNumbers);
		this.turkEconomyNumbers = new List<int>(component.turkEconomyNumbers);
		this.route1StopOffPoint = component.route1StopOffPoint;
		this.route2StopOffPoint = component.route2StopOffPoint;
		this.route3StopOffPoint = component.route3StopOffPoint;
		component.segment.Copy(ref this.segment);
		component.route1Segment.Copy(ref this.route1Segment);
		component.route2Segment.Copy(ref this.route2Segment);
		component.route3Segment.Copy(ref this.route3Segment);
		component.route4Segment.Copy(ref this.route4Segment);
		this.lightObjects = new List<GameObject>(component.lightObjects);
		component.weatherIcons.Copy(ref this.weatherIcons);
		component.roadConditionIcons.Copy(ref this.roadConditionIcons);
		this.spawnedRouteSegments = new List<GameObject>(component.spawnedRouteSegments);
		this.cratesToBeCleanedUp = new List<GameObject>(component.cratesToBeCleanedUp);
		this.routeAmmo = component.routeAmmo;
		this.routeChosen = component.routeChosen;
		this.routeChosenLength = component.routeChosenLength;
		this.destinationNumber = component.destinationNumber;
		this.forceLightsOff = component.forceLightsOff;
		this.aiDestination1 = component.aiDestination1;
		this.aiDestination2 = component.aiDestination2;
		this.route1Distance = component.route1Distance;
		this.route2Distance = component.route2Distance;
		this.route3Distance = component.route3Distance;
		this.route4Distance = component.route4Distance;
		this.route1Weather = component.route1Weather;
		this.route1StopOff = component.route1StopOff;
		this.route1RoadCondition = component.route1RoadCondition;
		this.route2Weather = component.route2Weather;
		this.route2StopOff = component.route2StopOff;
		this.route2RoadCondition = component.route2RoadCondition;
		this.route3Weather = component.route3Weather;
		this.route3StopOff = component.route3StopOff;
		this.route3RoadCondition = component.route3RoadCondition;
		this.route4Weather = component.route4Weather;
		this.route4StopOff = component.route4StopOff;
		this.route4RoadCondition = component.route4RoadCondition;
		this.currentWeatherCondition = component.currentWeatherCondition;
		this.currentRoadCondition = component.currentRoadCondition;
		this.sunChance = component.sunChance;
		this.fogChance = component.fogChance;
		this.lightRainChance = component.lightRainChance;
		this.heavyRainChance = component.heavyRainChance;
		this.goodRoadConditionChance = component.goodRoadConditionChance;
		this.poorRoadConditionChance = component.poorRoadConditionChance;
		this.abandonCarSpawnAmmo = component.abandonCarSpawnAmmo;
		this.abandonCarSpawnAmmoReference = component.abandonCarSpawnAmmoReference;
		this.abandonCarSpawnChance = component.abandonCarSpawnChance;
		component.enabled = false;
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x000C3284 File Offset: 0x000C1684
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.RouteDistances();
		this.PickDestination();
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.seatLogic = this.carLogic.GetComponent<CarLogicC>().playerSeat;
		if (ES3.Exists("economyState") && this.routeLevel != 0)
		{
			this.economyState = ES3.LoadInt("economyState");
		}
		else
		{
			this.GenerateMarketEconomies();
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x000C3308 File Offset: 0x000C1708
	public void DresdenStart()
	{
		MainMenuC.Global.PreventWakeUp();
		int num = UnityEngine.Random.Range(0, this.destinationObjectsGer.Length);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.destinationObjectsGer[num]);
		gameObject.transform.position = Vector3.zero;
		gameObject.GetComponent<Hub_CitySpawnC>().wakeUpInTown = true;
		base.GetComponent<DirectorC>().wakeUpInTown = true;
		MainMenuC.Global.StartCoroutine("DelayedEnabledLookAndWalk");
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x000C3374 File Offset: 0x000C1774
	public void SturovoStart()
	{
		MainMenuC.Global.PreventWakeUp();
		int num = UnityEngine.Random.Range(0, this.destinationObjectsCSFR.Length);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.destinationObjectsCSFR[num]);
		gameObject.transform.position = Vector3.zero;
		gameObject.GetComponent<Hub_CitySpawnC>().wakeUpInTown = true;
		base.GetComponent<DirectorC>().wakeUpInTown = true;
		MainMenuC.Global.StartCoroutine("DelayedEnabledLookAndWalk");
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x000C33E0 File Offset: 0x000C17E0
	public void LetenyeStart()
	{
		MainMenuC.Global.PreventWakeUp();
		int num = UnityEngine.Random.Range(0, this.destinationObjectsHUN.Length);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.destinationObjectsHUN[num]);
		gameObject.transform.position = Vector3.zero;
		gameObject.GetComponent<Hub_CitySpawnC>().wakeUpInTown = true;
		base.GetComponent<DirectorC>().wakeUpInTown = true;
		MainMenuC.Global.StartCoroutine("DelayedEnabledLookAndWalk");
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x000C344C File Offset: 0x000C184C
	public void DubrovnikStart()
	{
		MainMenuC.Global.PreventWakeUp();
		int num = UnityEngine.Random.Range(0, this.destinationObjectsYUGO.Length);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.destinationObjectsYUGO[num]);
		gameObject.transform.position = Vector3.zero;
		gameObject.GetComponent<Hub_CitySpawnC>().wakeUpInTown = true;
		base.GetComponent<DirectorC>().wakeUpInTown = true;
		MainMenuC.Global.StartCoroutine("DelayedEnabledLookAndWalk");
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
		Vector3 zero = Vector3.zero;
		gameObject2.transform.position = zero;
		this.spawnedRouteSegments.Add(gameObject2);
		GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
		gameObject3.transform.position = new Vector3(0f, 0f, 1000f);
		this.spawnedRouteSegments.Add(gameObject3);
		GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
		gameObject4.transform.position = new Vector3(0f, 0f, -1000f);
		this.spawnedRouteSegments.Add(gameObject4);
		GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutYUGO1_1);
		gameObject5.transform.position = new Vector3(0f, 0f, 200f);
		this.spawnedRouteSegments.Add(gameObject5);
		this.backdrop = UnityEngine.Object.Instantiate<GameObject>(this.yugoBackdrop);
		this.backdrop.transform.parent = gameObject.transform;
		this.backdrop.transform.localPosition = new Vector3(-130f, 90f, 80f);
		this.backdrop.transform.localEulerAngles = new Vector3(90f, -180f, 0f);
		this.backdrop.transform.localScale = new Vector3(50f, 50f, 23f);
		base.Invoke("LateShoot", 4f);
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x000C3633 File Offset: 0x000C1A33
	private void LateShoot()
	{
		this.startingEnvironment.GetComponent<Hub_CitySpawnC>().spawnedYugoScenery = this.backdrop;
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x000C364C File Offset: 0x000C1A4C
	public void MalkoTarnovoStart()
	{
		MainMenuC.Global.PreventWakeUp();
		int num = UnityEngine.Random.Range(0, this.destinationObjectsBUL.Length);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.destinationObjectsBUL[num]);
		gameObject.transform.position = Vector3.zero;
		gameObject.GetComponent<Hub_CitySpawnC>().wakeUpInTown = true;
		base.GetComponent<DirectorC>().wakeUpInTown = true;
		MainMenuC.Global.StartCoroutine("DelayedEnabledLookAndWalk");
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x000C36B8 File Offset: 0x000C1AB8
	public void IstanbulStart()
	{
		MainMenuC.Global.PreventWakeUp();
		int num = UnityEngine.Random.Range(0, this.destinationObjectsTURK.Length);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.destinationObjectsTURK[num]);
		gameObject.transform.position = Vector3.zero;
		gameObject.GetComponent<Hub_CitySpawnC>().wakeUpInTown = true;
		base.GetComponent<DirectorC>().wakeUpInTown = true;
		MainMenuC.Global.StartCoroutine("DelayedEnabledLookAndWalk");
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x000C3724 File Offset: 0x000C1B24
	public void GenerateMarketEconomies()
	{
		this.economyState = UnityEngine.Random.Range(1, 6);
		if (this.economyState == 1)
		{
			this.EconomyState1();
			return;
		}
		if (this.economyState == 2)
		{
			this.EconomyState2();
			return;
		}
		if (this.economyState == 3)
		{
			this.EconomyState3();
			return;
		}
		if (this.economyState == 4)
		{
			this.EconomyState4();
			return;
		}
		if (this.economyState == 5)
		{
			this.EconomyState5();
			return;
		}
		if (this.economyState == 6)
		{
			this.EconomyState6();
			return;
		}
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x000C37B0 File Offset: 0x000C1BB0
	public void EconomyState1()
	{
		this.gerEconomyNumbers[0] = 0;
		this.gerEconomyNumbers[1] = 1;
		this.gerEconomyNumbers[2] = 2;
		this.gerEconomyNumbers[3] = 3;
		this.gerEconomyNumbers[4] = 4;
		this.gerEconomyNumbers[5] = 5;
		this.csfrEconomyNumbers[0] = 1;
		this.csfrEconomyNumbers[1] = 2;
		this.csfrEconomyNumbers[2] = 3;
		this.csfrEconomyNumbers[3] = 4;
		this.csfrEconomyNumbers[4] = 5;
		this.csfrEconomyNumbers[5] = 0;
		this.hunEconomyNumbers[0] = 2;
		this.hunEconomyNumbers[1] = 3;
		this.hunEconomyNumbers[2] = 4;
		this.hunEconomyNumbers[3] = 5;
		this.hunEconomyNumbers[4] = 0;
		this.hunEconomyNumbers[5] = 1;
		this.yugoEconomyNumbers[0] = 3;
		this.yugoEconomyNumbers[1] = 4;
		this.yugoEconomyNumbers[2] = 5;
		this.yugoEconomyNumbers[3] = 0;
		this.yugoEconomyNumbers[4] = 1;
		this.yugoEconomyNumbers[5] = 2;
		this.bulEconomyNumbers[0] = 4;
		this.bulEconomyNumbers[1] = 5;
		this.bulEconomyNumbers[2] = 0;
		this.bulEconomyNumbers[3] = 1;
		this.bulEconomyNumbers[4] = 2;
		this.bulEconomyNumbers[5] = 3;
		this.turkEconomyNumbers[0] = 5;
		this.turkEconomyNumbers[1] = 0;
		this.turkEconomyNumbers[2] = 1;
		this.turkEconomyNumbers[3] = 2;
		this.turkEconomyNumbers[4] = 3;
		this.turkEconomyNumbers[5] = 4;
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x000C3994 File Offset: 0x000C1D94
	public void EconomyState2()
	{
		this.gerEconomyNumbers[0] = 5;
		this.gerEconomyNumbers[1] = 0;
		this.gerEconomyNumbers[2] = 3;
		this.gerEconomyNumbers[3] = 2;
		this.gerEconomyNumbers[4] = 1;
		this.gerEconomyNumbers[5] = 4;
		this.csfrEconomyNumbers[0] = 0;
		this.csfrEconomyNumbers[1] = 3;
		this.csfrEconomyNumbers[2] = 2;
		this.csfrEconomyNumbers[3] = 1;
		this.csfrEconomyNumbers[4] = 4;
		this.csfrEconomyNumbers[5] = 5;
		this.hunEconomyNumbers[0] = 3;
		this.hunEconomyNumbers[1] = 2;
		this.hunEconomyNumbers[2] = 1;
		this.hunEconomyNumbers[3] = 4;
		this.hunEconomyNumbers[4] = 5;
		this.hunEconomyNumbers[5] = 0;
		this.yugoEconomyNumbers[0] = 2;
		this.yugoEconomyNumbers[1] = 1;
		this.yugoEconomyNumbers[2] = 4;
		this.yugoEconomyNumbers[3] = 5;
		this.yugoEconomyNumbers[4] = 0;
		this.yugoEconomyNumbers[5] = 3;
		this.bulEconomyNumbers[0] = 1;
		this.bulEconomyNumbers[1] = 4;
		this.bulEconomyNumbers[2] = 5;
		this.bulEconomyNumbers[3] = 0;
		this.bulEconomyNumbers[4] = 3;
		this.bulEconomyNumbers[5] = 2;
		this.turkEconomyNumbers[0] = 4;
		this.turkEconomyNumbers[1] = 5;
		this.turkEconomyNumbers[2] = 0;
		this.turkEconomyNumbers[3] = 3;
		this.turkEconomyNumbers[4] = 2;
		this.turkEconomyNumbers[5] = 1;
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x000C3B78 File Offset: 0x000C1F78
	public void EconomyState3()
	{
		this.gerEconomyNumbers[0] = 4;
		this.gerEconomyNumbers[1] = 2;
		this.gerEconomyNumbers[2] = 5;
		this.gerEconomyNumbers[3] = 1;
		this.gerEconomyNumbers[4] = 3;
		this.gerEconomyNumbers[5] = 0;
		this.csfrEconomyNumbers[0] = 2;
		this.csfrEconomyNumbers[1] = 5;
		this.csfrEconomyNumbers[2] = 1;
		this.csfrEconomyNumbers[3] = 3;
		this.csfrEconomyNumbers[4] = 0;
		this.csfrEconomyNumbers[5] = 4;
		this.hunEconomyNumbers[0] = 5;
		this.hunEconomyNumbers[1] = 1;
		this.hunEconomyNumbers[2] = 3;
		this.hunEconomyNumbers[3] = 0;
		this.hunEconomyNumbers[4] = 4;
		this.hunEconomyNumbers[5] = 2;
		this.yugoEconomyNumbers[0] = 1;
		this.yugoEconomyNumbers[1] = 3;
		this.yugoEconomyNumbers[2] = 0;
		this.yugoEconomyNumbers[3] = 4;
		this.yugoEconomyNumbers[4] = 2;
		this.yugoEconomyNumbers[5] = 5;
		this.bulEconomyNumbers[0] = 3;
		this.bulEconomyNumbers[1] = 0;
		this.bulEconomyNumbers[2] = 4;
		this.bulEconomyNumbers[3] = 2;
		this.bulEconomyNumbers[4] = 5;
		this.bulEconomyNumbers[5] = 1;
		this.turkEconomyNumbers[0] = 0;
		this.turkEconomyNumbers[1] = 4;
		this.turkEconomyNumbers[2] = 2;
		this.turkEconomyNumbers[3] = 5;
		this.turkEconomyNumbers[4] = 1;
		this.turkEconomyNumbers[5] = 3;
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x000C3D5C File Offset: 0x000C215C
	public void EconomyState4()
	{
		this.gerEconomyNumbers[0] = 3;
		this.gerEconomyNumbers[1] = 4;
		this.gerEconomyNumbers[2] = 1;
		this.gerEconomyNumbers[3] = 5;
		this.gerEconomyNumbers[4] = 0;
		this.gerEconomyNumbers[5] = 2;
		this.csfrEconomyNumbers[0] = 4;
		this.csfrEconomyNumbers[1] = 1;
		this.csfrEconomyNumbers[2] = 5;
		this.csfrEconomyNumbers[3] = 0;
		this.csfrEconomyNumbers[4] = 2;
		this.csfrEconomyNumbers[5] = 3;
		this.hunEconomyNumbers[0] = 1;
		this.hunEconomyNumbers[1] = 5;
		this.hunEconomyNumbers[2] = 0;
		this.hunEconomyNumbers[3] = 2;
		this.hunEconomyNumbers[4] = 3;
		this.hunEconomyNumbers[5] = 4;
		this.yugoEconomyNumbers[0] = 5;
		this.yugoEconomyNumbers[1] = 0;
		this.yugoEconomyNumbers[2] = 2;
		this.yugoEconomyNumbers[3] = 3;
		this.yugoEconomyNumbers[4] = 4;
		this.yugoEconomyNumbers[5] = 1;
		this.bulEconomyNumbers[0] = 0;
		this.bulEconomyNumbers[1] = 2;
		this.bulEconomyNumbers[2] = 3;
		this.bulEconomyNumbers[3] = 4;
		this.bulEconomyNumbers[4] = 1;
		this.bulEconomyNumbers[5] = 5;
		this.turkEconomyNumbers[0] = 2;
		this.turkEconomyNumbers[1] = 3;
		this.turkEconomyNumbers[2] = 4;
		this.turkEconomyNumbers[3] = 1;
		this.turkEconomyNumbers[4] = 5;
		this.turkEconomyNumbers[5] = 0;
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x000C3F40 File Offset: 0x000C2340
	public void EconomyState5()
	{
		this.gerEconomyNumbers[0] = 2;
		this.gerEconomyNumbers[1] = 3;
		this.gerEconomyNumbers[2] = 0;
		this.gerEconomyNumbers[3] = 4;
		this.gerEconomyNumbers[4] = 5;
		this.gerEconomyNumbers[5] = 1;
		this.csfrEconomyNumbers[0] = 3;
		this.csfrEconomyNumbers[1] = 0;
		this.csfrEconomyNumbers[2] = 4;
		this.csfrEconomyNumbers[3] = 5;
		this.csfrEconomyNumbers[4] = 1;
		this.csfrEconomyNumbers[5] = 2;
		this.hunEconomyNumbers[0] = 0;
		this.hunEconomyNumbers[1] = 4;
		this.hunEconomyNumbers[2] = 5;
		this.hunEconomyNumbers[3] = 1;
		this.hunEconomyNumbers[4] = 2;
		this.hunEconomyNumbers[5] = 3;
		this.yugoEconomyNumbers[0] = 4;
		this.yugoEconomyNumbers[1] = 5;
		this.yugoEconomyNumbers[2] = 1;
		this.yugoEconomyNumbers[3] = 2;
		this.yugoEconomyNumbers[4] = 3;
		this.yugoEconomyNumbers[5] = 0;
		this.bulEconomyNumbers[0] = 5;
		this.bulEconomyNumbers[1] = 1;
		this.bulEconomyNumbers[2] = 2;
		this.bulEconomyNumbers[3] = 3;
		this.bulEconomyNumbers[4] = 0;
		this.bulEconomyNumbers[5] = 4;
		this.turkEconomyNumbers[0] = 1;
		this.turkEconomyNumbers[1] = 2;
		this.turkEconomyNumbers[2] = 3;
		this.turkEconomyNumbers[3] = 0;
		this.turkEconomyNumbers[4] = 4;
		this.turkEconomyNumbers[5] = 5;
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x000C4124 File Offset: 0x000C2524
	public void EconomyState6()
	{
		this.gerEconomyNumbers[0] = 1;
		this.gerEconomyNumbers[1] = 5;
		this.gerEconomyNumbers[2] = 4;
		this.gerEconomyNumbers[3] = 0;
		this.gerEconomyNumbers[4] = 2;
		this.gerEconomyNumbers[5] = 3;
		this.csfrEconomyNumbers[0] = 5;
		this.csfrEconomyNumbers[1] = 4;
		this.csfrEconomyNumbers[2] = 0;
		this.csfrEconomyNumbers[3] = 2;
		this.csfrEconomyNumbers[4] = 3;
		this.csfrEconomyNumbers[5] = 1;
		this.hunEconomyNumbers[0] = 4;
		this.hunEconomyNumbers[1] = 0;
		this.hunEconomyNumbers[2] = 2;
		this.hunEconomyNumbers[3] = 3;
		this.hunEconomyNumbers[4] = 1;
		this.hunEconomyNumbers[5] = 5;
		this.yugoEconomyNumbers[0] = 0;
		this.yugoEconomyNumbers[1] = 2;
		this.yugoEconomyNumbers[2] = 3;
		this.yugoEconomyNumbers[3] = 1;
		this.yugoEconomyNumbers[4] = 5;
		this.yugoEconomyNumbers[5] = 4;
		this.bulEconomyNumbers[0] = 2;
		this.bulEconomyNumbers[1] = 3;
		this.bulEconomyNumbers[2] = 1;
		this.bulEconomyNumbers[3] = 5;
		this.bulEconomyNumbers[4] = 4;
		this.bulEconomyNumbers[5] = 0;
		this.turkEconomyNumbers[0] = 3;
		this.turkEconomyNumbers[1] = 1;
		this.turkEconomyNumbers[2] = 5;
		this.turkEconomyNumbers[3] = 4;
		this.turkEconomyNumbers[4] = 0;
		this.turkEconomyNumbers[5] = 2;
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x000C4308 File Offset: 0x000C2708
	public void PickDestination()
	{
		if (!this.drivingTowardsHome)
		{
			if (this.routeLevel == 0)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsGer.Length);
			}
			else if (this.routeLevel == 1)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsCSFR.Length);
			}
			else if (this.routeLevel == 2)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsHUN.Length);
			}
			else if (this.routeLevel == 3)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsYUGO.Length);
			}
			else if (this.routeLevel == 4)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsBUL.Length);
			}
			else if (this.routeLevel == 5)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsTURK.Length);
			}
		}
		else
		{
			if (this.routeLevel == 0)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsHome.Length);
			}
			if (this.routeLevel == 1)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsHome.Length);
			}
			if (this.routeLevel == 2)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsGer.Length);
			}
			else if (this.routeLevel == 3)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsCSFR.Length);
			}
			else if (this.routeLevel == 4)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsHUN.Length);
			}
			else if (this.routeLevel == 5)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsYUGO.Length);
			}
			else if (this.routeLevel == 6)
			{
				this.destinationNumber = UnityEngine.Random.Range(0, this.destinationObjectsBUL.Length);
			}
		}
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x000C44F0 File Offset: 0x000C28F0
	public void RouteDistances()
	{
		int min = 3;
		int max = 7;
		this.route1Distance = UnityEngine.Random.Range(min, max);
		this.route2Distance = UnityEngine.Random.Range(min, max);
		this.route3Distance = UnityEngine.Random.Range(min, max);
		this.route4Distance = UnityEngine.Random.Range(min, max);
		this.GetRoadCondition();
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x000C453C File Offset: 0x000C293C
	public void GetRoadCondition()
	{
		if (!this.drivingTowardsHome)
		{
			if (this.routeLevel == 0)
			{
				this.goodRoadConditionChance = 70;
				this.poorRoadConditionChance = 90;
			}
			else if (this.routeLevel == 1)
			{
				this.goodRoadConditionChance = 50;
				this.poorRoadConditionChance = 80;
			}
			else if (this.routeLevel == 2)
			{
				this.goodRoadConditionChance = 45;
				this.poorRoadConditionChance = 75;
			}
			else if (this.routeLevel == 3)
			{
				this.goodRoadConditionChance = 40;
				this.poorRoadConditionChance = 60;
			}
			else if (this.routeLevel == 4)
			{
				this.goodRoadConditionChance = 30;
				this.poorRoadConditionChance = 50;
			}
			else if (this.routeLevel == 5)
			{
				this.goodRoadConditionChance = 20;
				this.poorRoadConditionChance = 40;
			}
		}
		else
		{
			if (this.routeLevel == 0)
			{
				this.goodRoadConditionChance = 70;
				this.poorRoadConditionChance = 90;
			}
			if (this.routeLevel == 1)
			{
				this.goodRoadConditionChance = 70;
				this.poorRoadConditionChance = 90;
			}
			else if (this.routeLevel == 2)
			{
				this.goodRoadConditionChance = 50;
				this.poorRoadConditionChance = 80;
			}
			else if (this.routeLevel == 3)
			{
				this.goodRoadConditionChance = 45;
				this.poorRoadConditionChance = 75;
			}
			else if (this.routeLevel == 4)
			{
				this.goodRoadConditionChance = 40;
				this.poorRoadConditionChance = 60;
			}
			else if (this.routeLevel == 5)
			{
				this.goodRoadConditionChance = 30;
				this.poorRoadConditionChance = 50;
			}
			else if (this.routeLevel == 6)
			{
				this.goodRoadConditionChance = 20;
				this.poorRoadConditionChance = 40;
			}
		}
		this.GetPrecipitation();
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x000C46FC File Offset: 0x000C2AFC
	public void GetPrecipitation()
	{
		if (!this.drivingTowardsHome)
		{
			if (this.routeLevel == 0)
			{
				this.sunChance = 60;
				this.fogChance = 85;
				this.lightRainChance = 100;
				this.heavyRainChance = 101;
			}
			else if (this.routeLevel == 1)
			{
				this.sunChance = 30;
				this.fogChance = 40;
				this.lightRainChance = 80;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 2)
			{
				this.sunChance = 15;
				this.fogChance = 80;
				this.lightRainChance = 90;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 3)
			{
				this.sunChance = 45;
				this.fogChance = 55;
				this.lightRainChance = 80;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 4)
			{
				this.sunChance = 25;
				this.fogChance = 30;
				this.lightRainChance = 60;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 5)
			{
				this.sunChance = 80;
				this.fogChance = 85;
				this.lightRainChance = 95;
				this.heavyRainChance = 10;
			}
		}
		else
		{
			if (this.routeLevel == 0)
			{
				this.sunChance = 60;
				this.fogChance = 85;
				this.lightRainChance = 100;
				this.heavyRainChance = 101;
			}
			if (this.routeLevel == 1)
			{
				this.sunChance = 60;
				this.fogChance = 85;
				this.lightRainChance = 100;
				this.heavyRainChance = 101;
			}
			else if (this.routeLevel == 2)
			{
				this.sunChance = 30;
				this.fogChance = 40;
				this.lightRainChance = 80;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 3)
			{
				this.sunChance = 15;
				this.fogChance = 80;
				this.lightRainChance = 90;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 4)
			{
				this.sunChance = 45;
				this.fogChance = 55;
				this.lightRainChance = 80;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 5)
			{
				this.sunChance = 25;
				this.fogChance = 30;
				this.lightRainChance = 60;
				this.heavyRainChance = 100;
			}
			else if (this.routeLevel == 6)
			{
				this.sunChance = 80;
				this.fogChance = 85;
				this.lightRainChance = 95;
				this.heavyRainChance = 10;
			}
		}
		this.GetRoute1();
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x000C498C File Offset: 0x000C2D8C
	public void GetRoute1()
	{
		this.route1Weather = UnityEngine.Random.Range(0, 101);
		if (this.route1Weather <= this.sunChance)
		{
			this.mapText1.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[0];
			this.route1WeatherCode = 0;
		}
		if (this.route1Weather <= this.fogChance && this.route1Weather > this.sunChance)
		{
			this.mapText1.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[1];
			this.route1WeatherCode = 1;
		}
		if (this.route1Weather <= this.lightRainChance && this.route1Weather > this.fogChance)
		{
			this.mapText1.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[2];
			this.route1WeatherCode = 2;
		}
		if (this.route1Weather <= this.heavyRainChance && this.route1Weather > this.lightRainChance)
		{
			this.mapText1.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[3];
			this.route1WeatherCode = 3;
		}
		this.route1RoadCondition = UnityEngine.Random.Range(0, 101);
		if (this.route1RoadCondition <= this.goodRoadConditionChance)
		{
			this.mapText1.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[0];
			this.route1RoadCode = 0;
		}
		else if (this.route1RoadCondition <= this.poorRoadConditionChance && this.route1RoadCondition > this.goodRoadConditionChance)
		{
			this.mapText1.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[1];
			this.route1RoadCode = 1;
		}
		else
		{
			this.mapText1.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[2];
			this.route1RoadCode = 2;
		}
		if (this.route1Distance > 3)
		{
			this.route1StopOffPoint = UnityEngine.Random.Range(1, this.route1Distance);
			int num = UnityEngine.Random.Range(0, 100);
			if (num > 75)
			{
				this.route1StopOff = 1;
			}
			else
			{
				this.route1StopOff = 0;
			}
		}
		else
		{
			this.route1StopOffPoint = 0;
			this.route1StopOff = 0;
		}
		if (!this.drivingTowardsHome)
		{
			if (this.routeLevel == 0)
			{
				this.GatherGermanRoute1();
			}
			else if (this.routeLevel == 1)
			{
				this.GatherCSFRRoute1();
			}
			else if (this.routeLevel == 2)
			{
				this.GatherHUNRoute1();
			}
			else if (this.routeLevel == 3)
			{
				this.GatherYUGORoute1();
			}
			else if (this.routeLevel == 4)
			{
				this.GatherBULRoute1();
			}
			else if (this.routeLevel == 5)
			{
				this.GatherTURKRoute1();
			}
		}
		else
		{
			if (this.routeLevel == 0)
			{
				this.GatherGermanRoute1();
			}
			if (this.routeLevel == 1)
			{
				this.GatherGermanRoute1();
			}
			else if (this.routeLevel == 2)
			{
				this.GatherCSFRRoute1();
			}
			else if (this.routeLevel == 3)
			{
				this.GatherHUNRoute1();
			}
			else if (this.routeLevel == 4)
			{
				this.GatherYUGORoute1();
			}
			else if (this.routeLevel == 5)
			{
				this.GatherBULRoute1();
			}
			else if (this.routeLevel == 6)
			{
				this.GatherTURKRoute1();
			}
		}
		this.GetRoute2();
		this.SetRoute1Text();
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x000C4D14 File Offset: 0x000C3114
	public void GatherGermanRoute1()
	{
		this.route1Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryGerStart.Length);
		this.route1Segments[0] = this.segmentLibraryGerStart[this.route1Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route1RoundaboutSegment = this.roundaboutGer2_1;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
			{
				this.route1RoundaboutSegment = this.roundaboutGer3_1;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route1Segments[1] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryGer3[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryGer3[1];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryGer3[2];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.stopOffLibraryGer2[0];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryGer3[2];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryGer2[0];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route1Segments[2] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryGer3[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryGer3[1];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryGer3[2];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.stopOffLibraryGer2[0];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryGer3[2];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryGer2[0];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route1Segments[3] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryGer3[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryGer3[1];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryGer3[2];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.stopOffLibraryGer2[0];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryGer3[2];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryGer2[0];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route1Segments[4] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryGer3[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryGer3[1];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryGer3[2];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.stopOffLibraryGer2[0];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryGer3[2];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryGer2[0];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route1Segments[5] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryGer3[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryGer3[1];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryGer3[2];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.stopOffLibraryGer2[0];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryGer3[2];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryGer2[0];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route1RoundaboutSegment = this.roundaboutGer2_2;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 3)
			{
				this.route1RoundaboutSegment = this.roundaboutGer2_3;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route1Segments[1] = this.stopOffLibraryGer3[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route1Segments[1] = this.segmentLibraryGer3[this.route1Segment[1]];
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route1Segments[1] = this.stopOffLibraryGer2[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route1Segments[1] = this.segmentLibraryGer2[this.route1Segment[1]];
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route1Segments[2] = this.stopOffLibraryGer3[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route1Segments[2] = this.segmentLibraryGer3[this.route1Segment[2]];
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route1Segments[2] = this.stopOffLibraryGer2[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route1Segments[2] = this.segmentLibraryGer2[this.route1Segment[2]];
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route1Segments[3] = this.stopOffLibraryGer3[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route1Segments[3] = this.segmentLibraryGer3[this.route1Segment[3]];
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route1Segments[3] = this.stopOffLibraryGer2[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route1Segments[3] = this.segmentLibraryGer2[this.route1Segment[3]];
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route1Segments[4] = this.stopOffLibraryGer3[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route1Segments[4] = this.segmentLibraryGer3[this.route1Segment[4]];
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route1Segments[4] = this.stopOffLibraryGer2[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route1Segments[4] = this.segmentLibraryGer2[this.route1Segment[4]];
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route1Segments[5] = this.stopOffLibraryGer3[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route1Segments[5] = this.segmentLibraryGer3[this.route1Segment[5]];
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route1Segments[5] = this.stopOffLibraryGer2[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route1Segments[5] = this.segmentLibraryGer2[this.route1Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x000C5D1C File Offset: 0x000C411C
	public void GatherGermanRoute2()
	{
		this.route2Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryGerStart.Length);
		this.route2Segments[0] = this.segmentLibraryGerStart[this.route2Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route2RoundaboutSegment = this.roundaboutGer2_1;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
			{
				this.route2RoundaboutSegment = this.roundaboutGer3_1;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route2Segments[1] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryGer3[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryGer3[1];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryGer3[2];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.stopOffLibraryGer2[0];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryGer3[2];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryGer2[0];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route2Segments[2] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryGer3[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryGer3[1];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryGer3[2];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.stopOffLibraryGer2[0];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryGer3[2];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryGer2[0];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route2Segments[3] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryGer3[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryGer3[1];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryGer3[2];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.stopOffLibraryGer2[0];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryGer3[2];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryGer2[0];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route2Segments[4] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryGer3[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryGer3[1];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryGer3[2];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.stopOffLibraryGer2[0];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryGer3[2];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryGer2[0];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route2Segments[5] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryGer3[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryGer3[1];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryGer3[2];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.stopOffLibraryGer2[0];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryGer3[2];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryGer2[0];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route2RoundaboutSegment = this.roundaboutGer2_2;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 3)
			{
				this.route2RoundaboutSegment = this.roundaboutGer2_3;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route2Segments[1] = this.stopOffLibraryGer3[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route2Segments[1] = this.segmentLibraryGer3[this.route2Segment[1]];
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route2Segments[1] = this.stopOffLibraryGer2[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route2Segments[1] = this.segmentLibraryGer2[this.route2Segment[1]];
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route2Segments[2] = this.stopOffLibraryGer3[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route2Segments[2] = this.segmentLibraryGer3[this.route2Segment[2]];
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route2Segments[2] = this.stopOffLibraryGer2[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route2Segments[2] = this.segmentLibraryGer2[this.route2Segment[2]];
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route2Segments[3] = this.stopOffLibraryGer3[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route2Segments[3] = this.segmentLibraryGer3[this.route2Segment[3]];
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route2Segments[3] = this.stopOffLibraryGer2[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route2Segments[3] = this.segmentLibraryGer2[this.route2Segment[3]];
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route2Segments[4] = this.stopOffLibraryGer3[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route2Segments[4] = this.segmentLibraryGer3[this.route2Segment[4]];
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route2Segments[4] = this.stopOffLibraryGer2[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route2Segments[4] = this.segmentLibraryGer2[this.route2Segment[4]];
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route2Segments[5] = this.stopOffLibraryGer3[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route2Segments[5] = this.segmentLibraryGer3[this.route2Segment[5]];
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route2Segments[5] = this.stopOffLibraryGer2[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route2Segments[5] = this.segmentLibraryGer2[this.route2Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x000C6D24 File Offset: 0x000C5124
	public void GatherGermanRoute3()
	{
		this.route3Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryGerStart.Length);
		this.route3Segments[0] = this.segmentLibraryGerStart[this.route3Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route3RoundaboutSegment = this.roundaboutGer2_1;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
			{
				this.route3RoundaboutSegment = this.roundaboutGer3_1;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route3Segments[1] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryGer3[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryGer3[1];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryGer3[2];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.stopOffLibraryGer2[0];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryGer3[2];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryGer2[0];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route3Segments[2] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryGer3[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryGer3[1];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryGer3[2];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.stopOffLibraryGer2[0];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryGer3[2];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryGer2[0];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route3Segments[3] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryGer3[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryGer3[1];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryGer3[2];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.stopOffLibraryGer2[0];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryGer3[2];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryGer2[0];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route3Segments[4] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryGer3[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryGer3[1];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryGer3[2];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.stopOffLibraryGer2[0];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryGer3[2];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryGer2[0];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 3)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryGer3[0];
						}
						else
						{
							this.route3Segments[5] = this.stopOffLibraryGer3[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryGer3[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryGer3[1];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.segmentLibraryGer2[2];
						}
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryGer3[2];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.stopOffLibraryGer2[0];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.stopOffLibraryGer2[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryGer3[2];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryGer2[0];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.segmentLibraryGer2[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route3RoundaboutSegment = this.roundaboutGer2_2;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 3)
			{
				this.route3RoundaboutSegment = this.roundaboutGer2_3;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route3Segments[1] = this.stopOffLibraryGer3[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route3Segments[1] = this.segmentLibraryGer3[this.route3Segment[1]];
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route3Segments[1] = this.stopOffLibraryGer2[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route3Segments[1] = this.segmentLibraryGer2[this.route3Segment[1]];
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route3Segments[2] = this.stopOffLibraryGer3[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route3Segments[2] = this.segmentLibraryGer3[this.route3Segment[2]];
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route3Segments[2] = this.stopOffLibraryGer2[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route3Segments[2] = this.segmentLibraryGer2[this.route3Segment[2]];
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route3Segments[3] = this.stopOffLibraryGer3[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route3Segments[3] = this.segmentLibraryGer3[this.route3Segment[3]];
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route3Segments[3] = this.stopOffLibraryGer2[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route3Segments[3] = this.segmentLibraryGer2[this.route3Segment[3]];
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route3Segments[4] = this.stopOffLibraryGer3[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route3Segments[4] = this.segmentLibraryGer3[this.route3Segment[4]];
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route3Segments[4] = this.stopOffLibraryGer2[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route3Segments[4] = this.segmentLibraryGer2[this.route3Segment[4]];
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryGer3.Length);
						this.route3Segments[5] = this.stopOffLibraryGer3[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryGer3.Length);
						this.route3Segments[5] = this.segmentLibraryGer3[this.route3Segment[5]];
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryGer2.Length);
						this.route3Segments[5] = this.stopOffLibraryGer2[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryGer2.Length);
						this.route3Segments[5] = this.segmentLibraryGer2[this.route3Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x000C7D2C File Offset: 0x000C612C
	public void GatherCSFRRoute1()
	{
		this.PickDestination();
		this.route1Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryCSFRStart.Length);
		this.route1Segments[0] = this.segmentLibraryCSFRStart[this.route1Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route1RoundaboutSegment = this.roundaboutCSFR1_1;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route1RoundaboutSegment = this.roundaboutCSFR1_0;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route1Segments[1] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 4);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route1Segment[1] == 3)
						{
							this.route1Segments[1] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route1Segments[2] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 4);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route1Segment[2] == 3)
						{
							this.route1Segments[2] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route1Segments[3] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 4);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route1Segment[3] == 3)
						{
							this.route1Segments[3] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route1Segments[4] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 4);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route1Segment[4] == 3)
						{
							this.route1Segments[4] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route1Segments[5] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 4);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route1Segment[5] == 3)
						{
							this.route1Segments[5] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
		}
		else
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route1RoundaboutSegment = this.roundaboutCSFR1_1;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route1RoundaboutSegment = this.roundaboutCSFR1_0;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route1Segments[1] = this.stopOffLibraryCSFR1[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route1Segments[1] = this.segmentLibraryCSFR1[this.route1Segment[1]];
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route1Segments[1] = this.stopOffLibraryCSFR0[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route1Segments[1] = this.segmentLibraryCSFR0[this.route1Segment[1]];
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route1Segments[2] = this.stopOffLibraryCSFR1[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route1Segments[2] = this.segmentLibraryCSFR1[this.route1Segment[2]];
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route1Segments[2] = this.stopOffLibraryCSFR0[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route1Segments[2] = this.segmentLibraryCSFR0[this.route1Segment[2]];
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route1Segments[3] = this.stopOffLibraryCSFR1[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route1Segments[3] = this.segmentLibraryCSFR1[this.route1Segment[3]];
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route1Segments[3] = this.stopOffLibraryCSFR0[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route1Segments[3] = this.segmentLibraryCSFR0[this.route1Segment[3]];
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route1Segments[4] = this.stopOffLibraryCSFR1[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route1Segments[4] = this.segmentLibraryCSFR1[this.route1Segment[4]];
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route1Segments[4] = this.stopOffLibraryCSFR0[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route1Segments[4] = this.segmentLibraryCSFR0[this.route1Segment[4]];
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route1Segments[5] = this.stopOffLibraryCSFR1[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route1Segments[5] = this.segmentLibraryCSFR1[this.route1Segment[5]];
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route1Segments[5] = this.stopOffLibraryCSFR0[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route1Segments[5] = this.segmentLibraryCSFR0[this.route1Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x000C8C80 File Offset: 0x000C7080
	public void GatherCSFRRoute2()
	{
		this.PickDestination();
		this.route2Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryCSFRStart.Length);
		this.route2Segments[0] = this.segmentLibraryCSFRStart[this.route2Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route2RoundaboutSegment = this.roundaboutCSFR1_1;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route2RoundaboutSegment = this.roundaboutCSFR1_0;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route2Segments[1] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 4);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route2Segment[1] == 3)
						{
							this.route2Segments[1] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route2Segments[2] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 4);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route2Segment[2] == 3)
						{
							this.route2Segments[2] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route2Segments[3] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 4);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route2Segment[3] == 3)
						{
							this.route2Segments[3] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route2Segments[4] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 4);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route2Segment[4] == 3)
						{
							this.route2Segments[4] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route2Segments[5] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 4);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route2Segment[5] == 3)
						{
							this.route2Segments[5] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
		}
		else
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route2RoundaboutSegment = this.roundaboutCSFR1_1;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route2RoundaboutSegment = this.roundaboutCSFR1_0;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route2Segments[1] = this.stopOffLibraryCSFR1[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route2Segments[1] = this.segmentLibraryCSFR1[this.route2Segment[1]];
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route2Segments[1] = this.stopOffLibraryCSFR0[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route2Segments[1] = this.segmentLibraryCSFR0[this.route2Segment[1]];
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route2Segments[2] = this.stopOffLibraryCSFR1[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route2Segments[2] = this.segmentLibraryCSFR1[this.route2Segment[2]];
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route2Segments[2] = this.stopOffLibraryCSFR0[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route2Segments[2] = this.segmentLibraryCSFR0[this.route2Segment[2]];
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route2Segments[3] = this.stopOffLibraryCSFR1[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route2Segments[3] = this.segmentLibraryCSFR1[this.route2Segment[3]];
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route2Segments[3] = this.stopOffLibraryCSFR0[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route2Segments[3] = this.segmentLibraryCSFR0[this.route2Segment[3]];
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route2Segments[4] = this.stopOffLibraryCSFR1[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route2Segments[4] = this.segmentLibraryCSFR1[this.route2Segment[4]];
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route2Segments[4] = this.stopOffLibraryCSFR0[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route2Segments[4] = this.segmentLibraryCSFR0[this.route2Segment[4]];
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route2Segments[5] = this.stopOffLibraryCSFR1[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route2Segments[5] = this.segmentLibraryCSFR1[this.route2Segment[5]];
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route2Segments[5] = this.stopOffLibraryCSFR0[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route2Segments[5] = this.segmentLibraryCSFR0[this.route2Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x000C9BD4 File Offset: 0x000C7FD4
	public void GatherCSFRRoute3()
	{
		this.PickDestination();
		this.route3Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryCSFRStart.Length);
		this.route3Segments[0] = this.segmentLibraryCSFRStart[this.route3Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route3RoundaboutSegment = this.roundaboutCSFR1_1;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route3RoundaboutSegment = this.roundaboutCSFR1_0;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route3Segments[1] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 4);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route3Segment[1] == 3)
						{
							this.route3Segments[1] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route3Segments[2] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 4);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route3Segment[2] == 3)
						{
							this.route3Segments[2] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route3Segments[3] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 4);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route3Segment[3] == 3)
						{
							this.route3Segments[3] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route3Segments[4] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 4);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route3Segment[4] == 3)
						{
							this.route3Segments[4] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryCSFR1[0];
						}
						else
						{
							this.route3Segments[5] = this.stopOffLibraryCSFR1[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryCSFR1[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryCSFR1[1];
						}
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryCSFR0[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.stopOffLibraryCSFR0[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 4);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryCSFR1[2];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryCSFR0[0];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.segmentLibraryCSFR0[1];
						}
						else if (this.route3Segment[5] == 3)
						{
							this.route3Segments[5] = this.segmentLibraryCSFR0[2];
						}
					}
				}
			}
		}
		else
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route3RoundaboutSegment = this.roundaboutCSFR1_1;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route3RoundaboutSegment = this.roundaboutCSFR1_0;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route3Segments[1] = this.stopOffLibraryCSFR1[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route3Segments[1] = this.segmentLibraryCSFR1[this.route3Segment[1]];
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route3Segments[1] = this.stopOffLibraryCSFR0[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route3Segments[1] = this.segmentLibraryCSFR0[this.route3Segment[1]];
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route3Segments[2] = this.stopOffLibraryCSFR1[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route3Segments[2] = this.segmentLibraryCSFR1[this.route3Segment[2]];
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route3Segments[2] = this.stopOffLibraryCSFR0[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route3Segments[2] = this.segmentLibraryCSFR0[this.route3Segment[2]];
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route3Segments[3] = this.stopOffLibraryCSFR1[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route3Segments[3] = this.segmentLibraryCSFR1[this.route3Segment[3]];
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route3Segments[3] = this.stopOffLibraryCSFR0[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route3Segments[3] = this.segmentLibraryCSFR0[this.route3Segment[3]];
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route3Segments[4] = this.stopOffLibraryCSFR1[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route3Segments[4] = this.segmentLibraryCSFR1[this.route3Segment[4]];
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route3Segments[4] = this.stopOffLibraryCSFR0[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route3Segments[4] = this.segmentLibraryCSFR0[this.route3Segment[4]];
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR1.Length);
						this.route3Segments[5] = this.stopOffLibraryCSFR1[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR1.Length);
						this.route3Segments[5] = this.segmentLibraryCSFR1[this.route3Segment[5]];
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryCSFR0.Length);
						this.route3Segments[5] = this.stopOffLibraryCSFR0[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryCSFR0.Length);
						this.route3Segments[5] = this.segmentLibraryCSFR0[this.route3Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x000CAB28 File Offset: 0x000C8F28
	public void GatherHUNRoute1()
	{
		this.PickDestination();
		this.route1Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryHUNStart.Length);
		this.route1Segments[0] = this.segmentLibraryHUNStart[this.route1Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route1RoundaboutSegment = this.roundaboutHUN2_0;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route1RoundaboutSegment = this.roundaboutHUN0_0;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route1Segments[1] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryHUN2[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryHUN2[1];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryHUN2[2];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryHUN0[0];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route1Segments[2] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryHUN2[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryHUN2[1];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryHUN2[2];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryHUN0[0];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route1Segments[3] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryHUN2[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryHUN2[1];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryHUN2[2];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryHUN0[0];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route1Segments[4] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryHUN2[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryHUN2[1];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryHUN2[2];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryHUN0[0];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route1Segments[5] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryHUN2[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryHUN2[1];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 4);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryHUN0[2];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryHUN0[0];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.segmentLibraryHUN0[1];
						}
						else if (this.route1Segment[5] == 3)
						{
							this.route1Segments[5] = this.segmentLibraryHUN0[2];
						}
					}
				}
			}
		}
		else
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route1RoundaboutSegment = this.roundAboutHUN2_2;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route1RoundaboutSegment = this.roundAboutHUN2_0;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route1Segments[1] = this.stopOffLibraryHUN2[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route1Segments[1] = this.segmentLibraryHUN2[this.route1Segment[1]];
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route1Segments[1] = this.stopOffLibraryHUN0[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route1Segments[1] = this.segmentLibraryHUN0[this.route1Segment[1]];
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route1Segments[2] = this.stopOffLibraryHUN2[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route1Segments[2] = this.segmentLibraryHUN2[this.route1Segment[2]];
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route1Segments[2] = this.stopOffLibraryHUN0[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route1Segments[2] = this.segmentLibraryHUN0[this.route1Segment[2]];
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route1Segments[3] = this.stopOffLibraryHUN2[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route1Segments[3] = this.segmentLibraryHUN2[this.route1Segment[3]];
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route1Segments[3] = this.stopOffLibraryHUN0[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route1Segments[3] = this.segmentLibraryHUN0[this.route1Segment[3]];
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route1Segments[4] = this.stopOffLibraryHUN2[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route1Segments[4] = this.segmentLibraryHUN2[this.route1Segment[4]];
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route1Segments[4] = this.stopOffLibraryHUN0[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route1Segments[4] = this.segmentLibraryHUN0[this.route1Segment[4]];
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route1Segments[5] = this.stopOffLibraryHUN2[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route1Segments[5] = this.segmentLibraryHUN2[this.route1Segment[5]];
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route1Segments[5] = this.stopOffLibraryHUN0[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route1Segments[5] = this.segmentLibraryHUN0[this.route1Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x000CBAA0 File Offset: 0x000C9EA0
	public void GatherHUNRoute2()
	{
		this.PickDestination();
		this.route2Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryHUNStart.Length);
		this.route2Segments[0] = this.segmentLibraryHUNStart[this.route2Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route2RoundaboutSegment = this.roundaboutHUN2_0;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route2RoundaboutSegment = this.roundaboutHUN0_0;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route2Segments[1] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryHUN2[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryHUN2[1];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryHUN2[2];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryHUN0[0];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route2Segments[2] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryHUN2[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryHUN2[1];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryHUN2[2];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryHUN0[0];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route2Segments[3] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryHUN2[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryHUN2[1];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryHUN2[2];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryHUN0[0];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route2Segments[4] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryHUN2[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryHUN2[1];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryHUN2[2];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryHUN0[0];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route2Segments[5] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryHUN2[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryHUN2[1];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryHUN2[2];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryHUN0[0];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route2RoundaboutSegment = this.roundAboutHUN2_2;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route2RoundaboutSegment = this.roundAboutHUN2_0;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route2Segments[1] = this.stopOffLibraryHUN2[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route2Segments[1] = this.segmentLibraryHUN2[this.route2Segment[1]];
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route2Segments[1] = this.stopOffLibraryHUN0[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route2Segments[1] = this.segmentLibraryHUN0[this.route2Segment[1]];
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route2Segments[2] = this.stopOffLibraryHUN2[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route2Segments[2] = this.segmentLibraryHUN2[this.route2Segment[2]];
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route2Segments[2] = this.stopOffLibraryHUN0[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route2Segments[2] = this.segmentLibraryHUN0[this.route2Segment[2]];
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route2Segments[3] = this.stopOffLibraryHUN2[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route2Segments[3] = this.segmentLibraryHUN2[this.route2Segment[3]];
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route2Segments[3] = this.stopOffLibraryHUN0[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route2Segments[3] = this.segmentLibraryHUN0[this.route2Segment[3]];
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route2Segments[4] = this.stopOffLibraryHUN2[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route2Segments[4] = this.segmentLibraryHUN2[this.route2Segment[4]];
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route2Segments[4] = this.stopOffLibraryHUN0[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route2Segments[4] = this.segmentLibraryHUN0[this.route2Segment[4]];
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route2Segments[5] = this.stopOffLibraryHUN2[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route2Segments[5] = this.segmentLibraryHUN2[this.route2Segment[5]];
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route2Segments[5] = this.stopOffLibraryHUN0[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route2Segments[5] = this.segmentLibraryHUN0[this.route2Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x000CC9F4 File Offset: 0x000CADF4
	public void GatherHUNRoute3()
	{
		this.PickDestination();
		this.route3Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryHUNStart.Length);
		this.route3Segments[0] = this.segmentLibraryHUNStart[this.route3Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route3RoundaboutSegment = this.roundaboutHUN2_0;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route3RoundaboutSegment = this.roundaboutHUN0_0;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route3Segments[1] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryHUN2[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryHUN2[1];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryHUN2[2];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryHUN0[0];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route3Segments[2] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryHUN2[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryHUN2[1];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryHUN2[2];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryHUN0[0];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route3Segments[3] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryHUN2[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryHUN2[1];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryHUN2[2];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryHUN0[0];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route3Segments[4] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryHUN2[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryHUN2[1];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryHUN2[2];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryHUN0[0];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryHUN2[0];
						}
						else
						{
							this.route3Segments[5] = this.stopOffLibraryHUN2[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryHUN2[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryHUN2[1];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.segmentLibraryHUN0[2];
						}
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryHUN0[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.stopOffLibraryHUN0[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryHUN2[2];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryHUN0[0];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.segmentLibraryHUN0[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route3RoundaboutSegment = this.roundAboutHUN2_2;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route3RoundaboutSegment = this.roundAboutHUN2_0;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route3Segments[1] = this.stopOffLibraryHUN2[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route3Segments[1] = this.segmentLibraryHUN2[this.route3Segment[1]];
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route3Segments[1] = this.stopOffLibraryHUN0[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route3Segments[1] = this.segmentLibraryHUN0[this.route3Segment[1]];
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route3Segments[2] = this.stopOffLibraryHUN2[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route3Segments[2] = this.segmentLibraryHUN2[this.route3Segment[2]];
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route3Segments[2] = this.stopOffLibraryHUN0[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route3Segments[2] = this.segmentLibraryHUN0[this.route3Segment[2]];
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route3Segments[3] = this.stopOffLibraryHUN2[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route3Segments[3] = this.segmentLibraryHUN2[this.route3Segment[3]];
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route3Segments[3] = this.stopOffLibraryHUN0[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route3Segments[3] = this.segmentLibraryHUN0[this.route3Segment[3]];
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route3Segments[4] = this.stopOffLibraryHUN2[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route3Segments[4] = this.segmentLibraryHUN2[this.route3Segment[4]];
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route3Segments[4] = this.stopOffLibraryHUN0[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route3Segments[4] = this.segmentLibraryHUN0[this.route3Segment[4]];
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN2.Length);
						this.route3Segments[5] = this.stopOffLibraryHUN2[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryHUN2.Length);
						this.route3Segments[5] = this.segmentLibraryHUN2[this.route3Segment[5]];
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryHUN0.Length);
						this.route3Segments[5] = this.stopOffLibraryHUN0[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryHUN0.Length);
						this.route3Segments[5] = this.segmentLibraryHUN0[this.route3Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x000CD948 File Offset: 0x000CBD48
	public void GatherYUGORoute1()
	{
		this.PickDestination();
		this.route1Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryYUGOStart.Length);
		this.route1Segments[0] = this.segmentLibraryYUGOStart[this.route1Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route1RoundaboutSegment = this.roundaboutYUGO1_0;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route1RoundaboutSegment = this.roundaboutYUGO0_0;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route1Segments[1] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route1Segment[1] == 2)
						{
							this.route1Segments[1] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route1Segments[2] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route1Segment[2] == 2)
						{
							this.route1Segments[2] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route1Segments[3] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route1Segment[3] == 2)
						{
							this.route1Segments[3] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route1Segments[4] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route1Segment[4] == 2)
						{
							this.route1Segments[4] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route1Segments[5] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route1Segment[5] == 2)
						{
							this.route1Segments[5] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route1RoundaboutSegment = this.roundaboutYUGO1_1;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route1RoundaboutSegment = this.roundaboutYUGO1_0;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route1Segments[1] = this.stopOffLibraryYUGO1[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route1Segments[1] = this.segmentLibraryYUGO1[this.route1Segment[1]];
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route1Segments[1] = this.stopOffLibraryYUGO0[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route1Segments[1] = this.segmentLibraryYUGO0[this.route1Segment[1]];
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route1Segments[2] = this.stopOffLibraryYUGO1[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route1Segments[2] = this.segmentLibraryYUGO1[this.route1Segment[2]];
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route1Segments[2] = this.stopOffLibraryYUGO0[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route1Segments[2] = this.segmentLibraryYUGO0[this.route1Segment[2]];
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route1Segments[3] = this.stopOffLibraryYUGO1[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route1Segments[3] = this.segmentLibraryYUGO1[this.route1Segment[3]];
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route1Segments[3] = this.stopOffLibraryYUGO0[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route1Segments[3] = this.segmentLibraryYUGO0[this.route1Segment[3]];
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route1Segments[4] = this.stopOffLibraryYUGO1[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route1Segments[4] = this.segmentLibraryYUGO1[this.route1Segment[4]];
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route1Segments[4] = this.stopOffLibraryYUGO0[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route1Segments[4] = this.segmentLibraryYUGO0[this.route1Segment[4]];
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route1Segments[5] = this.stopOffLibraryYUGO1[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route1Segments[5] = this.segmentLibraryYUGO1[this.route1Segment[5]];
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route1Segments[5] = this.stopOffLibraryYUGO0[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route1Segments[5] = this.segmentLibraryYUGO0[this.route1Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x000CE89C File Offset: 0x000CCC9C
	public void GatherYUGORoute2()
	{
		this.PickDestination();
		this.route2Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryYUGOStart.Length);
		this.route2Segments[0] = this.segmentLibraryYUGOStart[this.route2Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route2RoundaboutSegment = this.roundaboutYUGO1_0;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route2RoundaboutSegment = this.roundaboutYUGO0_0;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route2Segments[1] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route2Segment[1] == 2)
						{
							this.route2Segments[1] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route2Segments[2] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route2Segment[2] == 2)
						{
							this.route2Segments[2] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route2Segments[3] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route2Segment[3] == 2)
						{
							this.route2Segments[3] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route2Segments[4] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route2Segment[4] == 2)
						{
							this.route2Segments[4] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route2Segments[5] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route2Segment[5] == 2)
						{
							this.route2Segments[5] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route2RoundaboutSegment = this.roundaboutYUGO1_1;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route2RoundaboutSegment = this.roundaboutYUGO1_0;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route2Segments[1] = this.stopOffLibraryYUGO1[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route2Segments[1] = this.segmentLibraryYUGO1[this.route2Segment[1]];
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route2Segments[1] = this.stopOffLibraryYUGO0[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route2Segments[1] = this.segmentLibraryYUGO0[this.route2Segment[1]];
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route2Segments[2] = this.stopOffLibraryYUGO1[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route2Segments[2] = this.segmentLibraryYUGO1[this.route2Segment[2]];
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route2Segments[2] = this.stopOffLibraryYUGO0[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route2Segments[2] = this.segmentLibraryYUGO0[this.route2Segment[2]];
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route2Segments[3] = this.stopOffLibraryYUGO1[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route2Segments[3] = this.segmentLibraryYUGO1[this.route2Segment[3]];
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route2Segments[3] = this.stopOffLibraryYUGO0[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route2Segments[3] = this.segmentLibraryYUGO0[this.route2Segment[3]];
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route2Segments[4] = this.stopOffLibraryYUGO1[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route2Segments[4] = this.segmentLibraryYUGO1[this.route2Segment[4]];
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route2Segments[4] = this.stopOffLibraryYUGO0[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route2Segments[4] = this.segmentLibraryYUGO0[this.route2Segment[4]];
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route2Segments[5] = this.stopOffLibraryYUGO1[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route2Segments[5] = this.segmentLibraryYUGO1[this.route2Segment[5]];
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route2Segments[5] = this.stopOffLibraryYUGO0[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route2Segments[5] = this.segmentLibraryYUGO0[this.route2Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x0600092C RID: 2348 RVA: 0x000CF7F0 File Offset: 0x000CDBF0
	public void GatherYUGORoute3()
	{
		this.PickDestination();
		this.route3Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryYUGOStart.Length);
		this.route3Segments[0] = this.segmentLibraryYUGOStart[this.route3Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route3RoundaboutSegment = this.roundaboutYUGO1_0;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
			{
				this.route3RoundaboutSegment = this.roundaboutYUGO0_0;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route3Segments[1] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route3Segment[1] == 2)
						{
							this.route3Segments[1] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route3Segments[2] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route3Segment[2] == 2)
						{
							this.route3Segments[2] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route3Segments[3] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route3Segment[3] == 2)
						{
							this.route3Segments[3] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route3Segments[4] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route3Segment[4] == 2)
						{
							this.route3Segments[4] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryYUGO1[0];
						}
						else
						{
							this.route3Segments[5] = this.stopOffLibraryYUGO1[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryYUGO1[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryYUGO1[1];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.segmentLibraryYUGO0[2];
						}
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 0)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.stopOffLibraryYUGO0[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.stopOffLibraryYUGO0[1];
						}
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 3);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryYUGO1[2];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryYUGO0[0];
						}
						else if (this.route3Segment[5] == 2)
						{
							this.route3Segments[5] = this.segmentLibraryYUGO0[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route3RoundaboutSegment = this.roundaboutYUGO1_1;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 0)
			{
				this.route3RoundaboutSegment = this.roundaboutYUGO1_0;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route3Segments[1] = this.stopOffLibraryYUGO1[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route3Segments[1] = this.segmentLibraryYUGO1[this.route3Segment[1]];
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route3Segments[1] = this.stopOffLibraryYUGO0[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route3Segments[1] = this.segmentLibraryYUGO0[this.route3Segment[1]];
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route3Segments[2] = this.stopOffLibraryYUGO1[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route3Segments[2] = this.segmentLibraryYUGO1[this.route3Segment[2]];
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route3Segments[2] = this.stopOffLibraryYUGO0[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route3Segments[2] = this.segmentLibraryYUGO0[this.route3Segment[2]];
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route3Segments[3] = this.stopOffLibraryYUGO1[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route3Segments[3] = this.segmentLibraryYUGO1[this.route3Segment[3]];
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route3Segments[3] = this.stopOffLibraryYUGO0[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route3Segments[3] = this.segmentLibraryYUGO0[this.route3Segment[3]];
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route3Segments[4] = this.stopOffLibraryYUGO1[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route3Segments[4] = this.segmentLibraryYUGO1[this.route3Segment[4]];
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route3Segments[4] = this.stopOffLibraryYUGO0[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route3Segments[4] = this.segmentLibraryYUGO0[this.route3Segment[4]];
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO1.Length);
						this.route3Segments[5] = this.stopOffLibraryYUGO1[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO1.Length);
						this.route3Segments[5] = this.segmentLibraryYUGO1[this.route3Segment[5]];
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryYUGO0.Length);
						this.route3Segments[5] = this.stopOffLibraryYUGO0[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryYUGO0.Length);
						this.route3Segments[5] = this.segmentLibraryYUGO0[this.route3Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x000D0744 File Offset: 0x000CEB44
	public void GatherBULRoute1()
	{
		this.PickDestination();
		this.route1Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryBULStart.Length);
		this.route1Segments[0] = this.segmentLibraryBULStart[this.route1Segment[0]];
		if (this.drivingTowardsHome)
		{
			this.route1RoundaboutSegment = this.roundaboutBUL0_0;
			if (this.route1Distance > 1)
			{
				if (this.route1StopOffPoint == 1)
				{
					this.route1Segment[1] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[1] == 0)
					{
						this.route1Segments[1] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route1Segment[1] == 1)
					{
						this.route1Segments[1] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route1Segment[1] == 2)
					{
						this.route1Segments[1] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route1Segment[1] == 3)
					{
						this.route1Segments[1] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route1Segment[1] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[1] == 0)
					{
						this.route1Segments[1] = this.segmentLibraryBUL0[0];
					}
					else if (this.route1Segment[1] == 1)
					{
						this.route1Segments[1] = this.segmentLibraryBUL0[1];
					}
					else if (this.route1Segment[1] == 2)
					{
						this.route1Segments[1] = this.segmentLibraryBUL0[2];
					}
					else if (this.route1Segment[1] == 3)
					{
						this.route1Segments[1] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1StopOffPoint == 2)
				{
					this.route1Segment[2] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[2] == 0)
					{
						this.route1Segments[2] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route1Segment[2] == 1)
					{
						this.route1Segments[2] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route1Segment[2] == 2)
					{
						this.route1Segments[2] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route1Segment[2] == 3)
					{
						this.route1Segments[2] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route1Segment[2] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[2] == 0)
					{
						this.route1Segments[2] = this.segmentLibraryBUL0[0];
					}
					else if (this.route1Segment[2] == 1)
					{
						this.route1Segments[2] = this.segmentLibraryBUL0[1];
					}
					else if (this.route1Segment[2] == 2)
					{
						this.route1Segments[2] = this.segmentLibraryBUL0[2];
					}
					else if (this.route1Segment[2] == 3)
					{
						this.route1Segments[2] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1StopOffPoint == 3)
				{
					this.route1Segment[3] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[3] == 0)
					{
						this.route1Segments[3] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route1Segment[3] == 1)
					{
						this.route1Segments[3] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route1Segment[3] == 2)
					{
						this.route1Segments[3] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route1Segment[3] == 3)
					{
						this.route1Segments[3] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route1Segment[3] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[3] == 0)
					{
						this.route1Segments[3] = this.segmentLibraryBUL0[0];
					}
					else if (this.route1Segment[3] == 1)
					{
						this.route1Segments[3] = this.segmentLibraryBUL0[1];
					}
					else if (this.route1Segment[3] == 2)
					{
						this.route1Segments[3] = this.segmentLibraryBUL0[2];
					}
					else if (this.route1Segment[3] == 3)
					{
						this.route1Segments[3] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1StopOffPoint == 4)
				{
					this.route1Segment[4] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[4] == 0)
					{
						this.route1Segments[4] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route1Segment[4] == 1)
					{
						this.route1Segments[4] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route1Segment[4] == 2)
					{
						this.route1Segments[4] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route1Segment[4] == 3)
					{
						this.route1Segments[4] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route1Segment[4] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[4] == 0)
					{
						this.route1Segments[4] = this.segmentLibraryBUL0[0];
					}
					else if (this.route1Segment[4] == 1)
					{
						this.route1Segments[4] = this.segmentLibraryBUL0[1];
					}
					else if (this.route1Segment[4] == 2)
					{
						this.route1Segments[4] = this.segmentLibraryBUL0[2];
					}
					else if (this.route1Segment[4] == 3)
					{
						this.route1Segments[4] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1StopOffPoint == 5)
				{
					this.route1Segment[5] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[5] == 0)
					{
						this.route1Segments[5] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route1Segment[5] == 1)
					{
						this.route1Segments[5] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route1Segment[5] == 2)
					{
						this.route1Segments[5] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route1Segment[5] == 3)
					{
						this.route1Segments[5] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route1Segment[5] = UnityEngine.Random.Range(0, 4);
					if (this.route1Segment[5] == 0)
					{
						this.route1Segments[5] = this.segmentLibraryBUL0[0];
					}
					else if (this.route1Segment[5] == 1)
					{
						this.route1Segments[5] = this.segmentLibraryBUL0[1];
					}
					else if (this.route1Segment[5] == 2)
					{
						this.route1Segments[5] = this.segmentLibraryBUL0[2];
					}
					else if (this.route1Segment[5] == 3)
					{
						this.route1Segments[5] = this.segmentLibraryBUL0[3];
					}
				}
			}
		}
		else
		{
			this.route1RoundaboutSegment = this.roundaboutBUL0_0;
			if (this.route1Distance > 1)
			{
				if (this.route1StopOffPoint == 1)
				{
					this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route1Segments[1] = this.stopOffLibraryBUL0[this.route1Segment[1]];
				}
				else
				{
					this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route1Segments[1] = this.segmentLibraryBUL0[this.route1Segment[1]];
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1StopOffPoint == 2)
				{
					this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route1Segments[2] = this.stopOffLibraryBUL0[this.route1Segment[2]];
				}
				else
				{
					this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route1Segments[2] = this.segmentLibraryBUL0[this.route1Segment[2]];
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1StopOffPoint == 3)
				{
					this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route1Segments[3] = this.stopOffLibraryBUL0[this.route1Segment[3]];
				}
				else
				{
					this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route1Segments[3] = this.segmentLibraryBUL0[this.route1Segment[3]];
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1StopOffPoint == 4)
				{
					this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route1Segments[4] = this.stopOffLibraryBUL0[this.route1Segment[4]];
				}
				else
				{
					this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route1Segments[4] = this.segmentLibraryBUL0[this.route1Segment[4]];
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1StopOffPoint == 5)
				{
					this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route1Segments[5] = this.stopOffLibraryBUL0[this.route1Segment[5]];
				}
				else
				{
					this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route1Segments[5] = this.segmentLibraryBUL0[this.route1Segment[5]];
				}
			}
		}
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x000D1064 File Offset: 0x000CF464
	public void GatherBULRoute2()
	{
		this.PickDestination();
		this.route2Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryBULStart.Length);
		this.route2Segments[0] = this.segmentLibraryBULStart[this.route2Segment[0]];
		if (this.drivingTowardsHome)
		{
			this.route2RoundaboutSegment = this.roundaboutBUL0_0;
			if (this.route2Distance > 1)
			{
				if (this.route2StopOffPoint == 1)
				{
					this.route2Segment[1] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[1] == 0)
					{
						this.route2Segments[1] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route2Segment[1] == 1)
					{
						this.route2Segments[1] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route2Segment[1] == 2)
					{
						this.route2Segments[1] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route2Segment[1] == 3)
					{
						this.route2Segments[1] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route2Segment[1] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[1] == 0)
					{
						this.route2Segments[1] = this.segmentLibraryBUL0[0];
					}
					else if (this.route2Segment[1] == 1)
					{
						this.route2Segments[1] = this.segmentLibraryBUL0[1];
					}
					else if (this.route2Segment[1] == 2)
					{
						this.route2Segments[1] = this.segmentLibraryBUL0[2];
					}
					else if (this.route2Segment[1] == 3)
					{
						this.route2Segments[1] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2StopOffPoint == 2)
				{
					this.route2Segment[2] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[2] == 0)
					{
						this.route2Segments[2] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route2Segment[2] == 1)
					{
						this.route2Segments[2] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route2Segment[2] == 2)
					{
						this.route2Segments[2] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route2Segment[2] == 3)
					{
						this.route2Segments[2] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route2Segment[2] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[2] == 0)
					{
						this.route2Segments[2] = this.segmentLibraryBUL0[0];
					}
					else if (this.route2Segment[2] == 1)
					{
						this.route2Segments[2] = this.segmentLibraryBUL0[1];
					}
					else if (this.route2Segment[2] == 2)
					{
						this.route2Segments[2] = this.segmentLibraryBUL0[2];
					}
					else if (this.route2Segment[2] == 3)
					{
						this.route2Segments[2] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2StopOffPoint == 3)
				{
					this.route2Segment[3] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[3] == 0)
					{
						this.route2Segments[3] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route2Segment[3] == 1)
					{
						this.route2Segments[3] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route2Segment[3] == 2)
					{
						this.route2Segments[3] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route2Segment[3] == 3)
					{
						this.route2Segments[3] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route2Segment[3] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[3] == 0)
					{
						this.route2Segments[3] = this.segmentLibraryBUL0[0];
					}
					else if (this.route2Segment[3] == 1)
					{
						this.route2Segments[3] = this.segmentLibraryBUL0[1];
					}
					else if (this.route2Segment[3] == 2)
					{
						this.route2Segments[3] = this.segmentLibraryBUL0[2];
					}
					else if (this.route2Segment[3] == 3)
					{
						this.route2Segments[3] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2StopOffPoint == 4)
				{
					this.route2Segment[4] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[4] == 0)
					{
						this.route2Segments[4] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route2Segment[4] == 1)
					{
						this.route2Segments[4] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route2Segment[4] == 2)
					{
						this.route2Segments[4] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route2Segment[4] == 3)
					{
						this.route2Segments[4] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route2Segment[4] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[4] == 0)
					{
						this.route2Segments[4] = this.segmentLibraryBUL0[0];
					}
					else if (this.route2Segment[4] == 1)
					{
						this.route2Segments[4] = this.segmentLibraryBUL0[1];
					}
					else if (this.route2Segment[4] == 2)
					{
						this.route2Segments[4] = this.segmentLibraryBUL0[2];
					}
					else if (this.route2Segment[4] == 3)
					{
						this.route2Segments[4] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2StopOffPoint == 5)
				{
					this.route2Segment[5] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[5] == 0)
					{
						this.route2Segments[5] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route2Segment[5] == 1)
					{
						this.route2Segments[5] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route2Segment[5] == 2)
					{
						this.route2Segments[5] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route2Segment[5] == 3)
					{
						this.route2Segments[5] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route2Segment[5] = UnityEngine.Random.Range(0, 4);
					if (this.route2Segment[5] == 0)
					{
						this.route2Segments[5] = this.segmentLibraryBUL0[0];
					}
					else if (this.route2Segment[5] == 1)
					{
						this.route2Segments[5] = this.segmentLibraryBUL0[1];
					}
					else if (this.route2Segment[5] == 2)
					{
						this.route2Segments[5] = this.segmentLibraryBUL0[2];
					}
					else if (this.route2Segment[5] == 3)
					{
						this.route2Segments[5] = this.segmentLibraryBUL0[3];
					}
				}
			}
		}
		else
		{
			this.route2RoundaboutSegment = this.roundaboutBUL0_0;
			if (this.route2Distance > 1)
			{
				if (this.route2StopOffPoint == 1)
				{
					this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route2Segments[1] = this.stopOffLibraryBUL0[this.route2Segment[1]];
				}
				else
				{
					this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route2Segments[1] = this.segmentLibraryBUL0[this.route2Segment[1]];
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2StopOffPoint == 2)
				{
					this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route2Segments[2] = this.stopOffLibraryBUL0[this.route2Segment[2]];
				}
				else
				{
					this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route2Segments[2] = this.segmentLibraryBUL0[this.route2Segment[2]];
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2StopOffPoint == 3)
				{
					this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route2Segments[3] = this.stopOffLibraryBUL0[this.route2Segment[3]];
				}
				else
				{
					this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route2Segments[3] = this.segmentLibraryBUL0[this.route2Segment[3]];
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2StopOffPoint == 4)
				{
					this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route2Segments[4] = this.stopOffLibraryBUL0[this.route2Segment[4]];
				}
				else
				{
					this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route2Segments[4] = this.segmentLibraryBUL0[this.route2Segment[4]];
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2StopOffPoint == 5)
				{
					this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route2Segments[5] = this.stopOffLibraryBUL0[this.route2Segment[5]];
				}
				else
				{
					this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route2Segments[5] = this.segmentLibraryBUL0[this.route2Segment[5]];
				}
			}
		}
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x000D1984 File Offset: 0x000CFD84
	public void GatherBULRoute3()
	{
		this.PickDestination();
		this.route3Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryBULStart.Length);
		this.route3Segments[0] = this.segmentLibraryBULStart[this.route3Segment[0]];
		if (this.drivingTowardsHome)
		{
			this.route3RoundaboutSegment = this.roundaboutBUL0_0;
			if (this.route3Distance > 1)
			{
				if (this.route3StopOffPoint == 1)
				{
					this.route3Segment[1] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[1] == 0)
					{
						this.route3Segments[1] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route3Segment[1] == 1)
					{
						this.route3Segments[1] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route3Segment[1] == 2)
					{
						this.route3Segments[1] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route3Segment[1] == 3)
					{
						this.route3Segments[1] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route3Segment[1] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[1] == 0)
					{
						this.route3Segments[1] = this.segmentLibraryBUL0[0];
					}
					else if (this.route3Segment[1] == 1)
					{
						this.route3Segments[1] = this.segmentLibraryBUL0[1];
					}
					else if (this.route3Segment[1] == 2)
					{
						this.route3Segments[1] = this.segmentLibraryBUL0[2];
					}
					else if (this.route3Segment[1] == 3)
					{
						this.route3Segments[1] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3StopOffPoint == 2)
				{
					this.route3Segment[2] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[2] == 0)
					{
						this.route3Segments[2] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route3Segment[2] == 1)
					{
						this.route3Segments[2] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route3Segment[2] == 2)
					{
						this.route3Segments[2] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route3Segment[2] == 3)
					{
						this.route3Segments[2] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route3Segment[2] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[2] == 0)
					{
						this.route3Segments[2] = this.segmentLibraryBUL0[0];
					}
					else if (this.route3Segment[2] == 1)
					{
						this.route3Segments[2] = this.segmentLibraryBUL0[1];
					}
					else if (this.route3Segment[2] == 2)
					{
						this.route3Segments[2] = this.segmentLibraryBUL0[2];
					}
					else if (this.route3Segment[2] == 3)
					{
						this.route3Segments[2] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3StopOffPoint == 3)
				{
					this.route3Segment[3] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[3] == 0)
					{
						this.route3Segments[3] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route3Segment[3] == 1)
					{
						this.route3Segments[3] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route3Segment[3] == 2)
					{
						this.route3Segments[3] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route3Segment[3] == 3)
					{
						this.route3Segments[3] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route3Segment[3] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[3] == 0)
					{
						this.route3Segments[3] = this.segmentLibraryBUL0[0];
					}
					else if (this.route3Segment[3] == 1)
					{
						this.route3Segments[3] = this.segmentLibraryBUL0[1];
					}
					else if (this.route3Segment[3] == 2)
					{
						this.route3Segments[3] = this.segmentLibraryBUL0[2];
					}
					else if (this.route3Segment[3] == 3)
					{
						this.route3Segments[3] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3StopOffPoint == 4)
				{
					this.route3Segment[4] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[4] == 0)
					{
						this.route3Segments[4] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route3Segment[4] == 1)
					{
						this.route3Segments[4] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route3Segment[4] == 2)
					{
						this.route3Segments[4] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route3Segment[4] == 3)
					{
						this.route3Segments[4] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route3Segment[4] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[4] == 0)
					{
						this.route3Segments[4] = this.segmentLibraryBUL0[0];
					}
					else if (this.route3Segment[4] == 1)
					{
						this.route3Segments[4] = this.segmentLibraryBUL0[1];
					}
					else if (this.route3Segment[4] == 2)
					{
						this.route3Segments[4] = this.segmentLibraryBUL0[2];
					}
					else if (this.route3Segment[4] == 3)
					{
						this.route3Segments[4] = this.segmentLibraryBUL0[3];
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3StopOffPoint == 5)
				{
					this.route3Segment[5] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[5] == 0)
					{
						this.route3Segments[5] = this.stopOffLibraryBUL0[0];
					}
					else if (this.route3Segment[5] == 1)
					{
						this.route3Segments[5] = this.stopOffLibraryBUL0[1];
					}
					else if (this.route3Segment[5] == 2)
					{
						this.route3Segments[5] = this.stopOffLibraryBUL0[2];
					}
					else if (this.route3Segment[5] == 3)
					{
						this.route3Segments[5] = this.stopOffLibraryBUL0[3];
					}
				}
				else
				{
					this.route3Segment[5] = UnityEngine.Random.Range(0, 4);
					if (this.route3Segment[5] == 0)
					{
						this.route3Segments[5] = this.segmentLibraryBUL0[0];
					}
					else if (this.route3Segment[5] == 1)
					{
						this.route3Segments[5] = this.segmentLibraryBUL0[1];
					}
					else if (this.route3Segment[5] == 2)
					{
						this.route3Segments[5] = this.segmentLibraryBUL0[2];
					}
					else if (this.route3Segment[5] == 3)
					{
						this.route3Segments[5] = this.segmentLibraryBUL0[3];
					}
				}
			}
		}
		else
		{
			this.route3RoundaboutSegment = this.roundaboutBUL0_0;
			if (this.route3Distance > 1)
			{
				if (this.route3StopOffPoint == 1)
				{
					this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route3Segments[1] = this.stopOffLibraryBUL0[this.route3Segment[1]];
				}
				else
				{
					this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route3Segments[1] = this.segmentLibraryBUL0[this.route3Segment[1]];
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3StopOffPoint == 2)
				{
					this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route3Segments[2] = this.stopOffLibraryBUL0[this.route3Segment[2]];
				}
				else
				{
					this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route3Segments[2] = this.segmentLibraryBUL0[this.route3Segment[2]];
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3StopOffPoint == 3)
				{
					this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route3Segments[3] = this.stopOffLibraryBUL0[this.route3Segment[3]];
				}
				else
				{
					this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route3Segments[3] = this.segmentLibraryBUL0[this.route3Segment[3]];
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3StopOffPoint == 4)
				{
					this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route3Segments[4] = this.stopOffLibraryBUL0[this.route3Segment[4]];
				}
				else
				{
					this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route3Segments[4] = this.segmentLibraryBUL0[this.route3Segment[4]];
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3StopOffPoint == 5)
				{
					this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryBUL0.Length);
					this.route3Segments[5] = this.stopOffLibraryBUL0[this.route3Segment[5]];
				}
				else
				{
					this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryBUL0.Length);
					this.route3Segments[5] = this.segmentLibraryBUL0[this.route3Segment[5]];
				}
			}
		}
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x000D22A4 File Offset: 0x000D06A4
	public void GatherTURKRoute1()
	{
		this.PickDestination();
		this.route1Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryTURKStart.Length);
		this.route1Segments[0] = this.segmentLibraryTURKStart[this.route1Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route1RoundaboutSegment = this.roundaboutTURK2_3;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route1RoundaboutSegment = this.roundaboutTURK1_3;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segments[1] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryTURK2[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segments[1] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[1] == 0)
						{
							this.route1Segments[1] = this.segmentLibraryTURK1[0];
						}
						else if (this.route1Segment[1] == 1)
						{
							this.route1Segments[1] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segments[2] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryTURK2[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segments[2] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[2] == 0)
						{
							this.route1Segments[2] = this.segmentLibraryTURK1[0];
						}
						else if (this.route1Segment[2] == 1)
						{
							this.route1Segments[2] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segments[3] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryTURK2[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segments[3] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[3] == 0)
						{
							this.route1Segments[3] = this.segmentLibraryTURK1[0];
						}
						else if (this.route1Segment[3] == 1)
						{
							this.route1Segments[3] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segments[4] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryTURK2[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segments[4] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[4] == 0)
						{
							this.route1Segments[4] = this.segmentLibraryTURK1[0];
						}
						else if (this.route1Segment[4] == 1)
						{
							this.route1Segments[4] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segments[5] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryTURK2[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segments[5] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route1Segment[5] == 0)
						{
							this.route1Segments[5] = this.segmentLibraryTURK1[0];
						}
						else if (this.route1Segment[5] == 1)
						{
							this.route1Segments[5] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route1RoundaboutSegment = this.roundaboutTURK1_1;
			}
			else if (this.route1Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route1RoundaboutSegment = this.roundaboutTURK1_2;
			}
			if (this.route1Distance > 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route1Segments[1] = this.stopOffLibraryTURK1[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route1Segments[1] = this.segmentLibraryTURK1[this.route1Segment[1]];
					}
				}
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 1)
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route1Segments[1] = this.stopOffLibraryTURK2[this.route1Segment[1]];
					}
					else
					{
						this.route1Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route1Segments[1] = this.segmentLibraryTURK2[this.route1Segment[1]];
					}
				}
			}
			if (this.route1Distance > 2)
			{
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route1Segments[2] = this.stopOffLibraryTURK1[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route1Segments[2] = this.segmentLibraryTURK1[this.route1Segment[2]];
					}
				}
				if (this.route1Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 2)
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route1Segments[2] = this.stopOffLibraryTURK2[this.route1Segment[2]];
					}
					else
					{
						this.route1Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route1Segments[2] = this.segmentLibraryTURK2[this.route1Segment[2]];
					}
				}
			}
			if (this.route1Distance > 3)
			{
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route1Segments[3] = this.stopOffLibraryTURK1[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route1Segments[3] = this.segmentLibraryTURK1[this.route1Segment[3]];
					}
				}
				if (this.route1Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 3)
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route1Segments[3] = this.stopOffLibraryTURK2[this.route1Segment[3]];
					}
					else
					{
						this.route1Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route1Segments[3] = this.segmentLibraryTURK2[this.route1Segment[3]];
					}
				}
			}
			if (this.route1Distance > 4)
			{
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route1Segments[4] = this.stopOffLibraryTURK1[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route1Segments[4] = this.segmentLibraryTURK1[this.route1Segment[4]];
					}
				}
				if (this.route1Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 4)
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route1Segments[4] = this.stopOffLibraryTURK2[this.route1Segment[4]];
					}
					else
					{
						this.route1Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route1Segments[4] = this.segmentLibraryTURK2[this.route1Segment[4]];
					}
				}
			}
			if (this.route1Distance > 5)
			{
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route1Segments[5] = this.stopOffLibraryTURK1[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route1Segments[5] = this.segmentLibraryTURK1[this.route1Segment[5]];
					}
				}
				if (this.route1Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route1StopOffPoint == 5)
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route1Segments[5] = this.stopOffLibraryTURK2[this.route1Segment[5]];
					}
					else
					{
						this.route1Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route1Segments[5] = this.segmentLibraryTURK2[this.route1Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x000D2E74 File Offset: 0x000D1274
	public void GatherTURKRoute2()
	{
		this.PickDestination();
		this.route2Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryTURKStart.Length);
		this.route2Segments[0] = this.segmentLibraryTURKStart[this.route2Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route2RoundaboutSegment = this.roundaboutTURK2_3;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route2RoundaboutSegment = this.roundaboutTURK1_3;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segments[1] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryTURK2[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segments[1] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[1] == 0)
						{
							this.route2Segments[1] = this.segmentLibraryTURK1[0];
						}
						else if (this.route2Segment[1] == 1)
						{
							this.route2Segments[1] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segments[2] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryTURK2[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segments[2] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[2] == 0)
						{
							this.route2Segments[2] = this.segmentLibraryTURK1[0];
						}
						else if (this.route2Segment[2] == 1)
						{
							this.route2Segments[2] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segments[3] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryTURK2[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segments[3] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[3] == 0)
						{
							this.route2Segments[3] = this.segmentLibraryTURK1[0];
						}
						else if (this.route2Segment[3] == 1)
						{
							this.route2Segments[3] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segments[4] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryTURK2[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segments[4] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[4] == 0)
						{
							this.route2Segments[4] = this.segmentLibraryTURK1[0];
						}
						else if (this.route2Segment[4] == 1)
						{
							this.route2Segments[4] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segments[5] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryTURK2[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segments[5] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route2Segment[5] == 0)
						{
							this.route2Segments[5] = this.segmentLibraryTURK1[0];
						}
						else if (this.route2Segment[5] == 1)
						{
							this.route2Segments[5] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route2RoundaboutSegment = this.roundaboutTURK1_1;
			}
			else if (this.route2Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route2RoundaboutSegment = this.roundaboutTURK1_2;
			}
			if (this.route2Distance > 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route2Segments[1] = this.stopOffLibraryTURK1[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route2Segments[1] = this.segmentLibraryTURK1[this.route2Segment[1]];
					}
				}
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 1)
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route2Segments[1] = this.stopOffLibraryTURK2[this.route2Segment[1]];
					}
					else
					{
						this.route2Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route2Segments[1] = this.segmentLibraryTURK2[this.route2Segment[1]];
					}
				}
			}
			if (this.route2Distance > 2)
			{
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route2Segments[2] = this.stopOffLibraryTURK1[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route2Segments[2] = this.segmentLibraryTURK1[this.route2Segment[2]];
					}
				}
				if (this.route2Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 2)
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route2Segments[2] = this.stopOffLibraryTURK2[this.route2Segment[2]];
					}
					else
					{
						this.route2Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route2Segments[2] = this.segmentLibraryTURK2[this.route2Segment[2]];
					}
				}
			}
			if (this.route2Distance > 3)
			{
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route2Segments[3] = this.stopOffLibraryTURK1[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route2Segments[3] = this.segmentLibraryTURK1[this.route2Segment[3]];
					}
				}
				if (this.route2Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 3)
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route2Segments[3] = this.stopOffLibraryTURK2[this.route2Segment[3]];
					}
					else
					{
						this.route2Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route2Segments[3] = this.segmentLibraryTURK2[this.route2Segment[3]];
					}
				}
			}
			if (this.route2Distance > 4)
			{
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route2Segments[4] = this.stopOffLibraryTURK1[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route2Segments[4] = this.segmentLibraryTURK1[this.route2Segment[4]];
					}
				}
				if (this.route2Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 4)
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route2Segments[4] = this.stopOffLibraryTURK2[this.route2Segment[4]];
					}
					else
					{
						this.route2Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route2Segments[4] = this.segmentLibraryTURK2[this.route2Segment[4]];
					}
				}
			}
			if (this.route2Distance > 5)
			{
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route2Segments[5] = this.stopOffLibraryTURK1[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route2Segments[5] = this.segmentLibraryTURK1[this.route2Segment[5]];
					}
				}
				if (this.route2Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route2StopOffPoint == 5)
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route2Segments[5] = this.stopOffLibraryTURK2[this.route2Segment[5]];
					}
					else
					{
						this.route2Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route2Segments[5] = this.segmentLibraryTURK2[this.route2Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x000D3A44 File Offset: 0x000D1E44
	public void GatherTURKRoute3()
	{
		this.PickDestination();
		this.route3Segment[0] = UnityEngine.Random.Range(0, this.segmentLibraryTURKStart.Length);
		this.route3Segments[0] = this.segmentLibraryTURKStart[this.route3Segment[0]];
		if (this.drivingTowardsHome)
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
			{
				this.route3RoundaboutSegment = this.roundaboutTURK2_3;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
			{
				this.route3RoundaboutSegment = this.roundaboutTURK1_3;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segments[1] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryTURK2[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segments[1] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[1] == 0)
						{
							this.route3Segments[1] = this.segmentLibraryTURK1[0];
						}
						else if (this.route3Segment[1] == 1)
						{
							this.route3Segments[1] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segments[2] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryTURK2[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segments[2] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[2] == 0)
						{
							this.route3Segments[2] = this.segmentLibraryTURK1[0];
						}
						else if (this.route3Segment[2] == 1)
						{
							this.route3Segments[2] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segments[3] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryTURK2[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segments[3] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[3] == 0)
						{
							this.route3Segments[3] = this.segmentLibraryTURK1[0];
						}
						else if (this.route3Segment[3] == 1)
						{
							this.route3Segments[3] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segments[4] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryTURK2[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segments[4] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[4] == 0)
						{
							this.route3Segments[4] = this.segmentLibraryTURK1[0];
						}
						else if (this.route3Segment[4] == 1)
						{
							this.route3Segments[4] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 2)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segments[5] = this.stopOffLibraryTURK2[0];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryTURK2[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryTURK1[1];
						}
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().startSize == 1)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segments[5] = this.stopOffLibraryTURK1[0];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, 2);
						if (this.route3Segment[5] == 0)
						{
							this.route3Segments[5] = this.segmentLibraryTURK1[0];
						}
						else if (this.route3Segment[5] == 1)
						{
							this.route3Segments[5] = this.segmentLibraryTURK2[1];
						}
					}
				}
			}
		}
		else
		{
			if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 1)
			{
				this.route3RoundaboutSegment = this.roundaboutTURK1_1;
			}
			else if (this.route3Segments[0].GetComponent<SpawnContinueC>().startSize == 2)
			{
				this.route3RoundaboutSegment = this.roundaboutTURK1_2;
			}
			if (this.route3Distance > 1)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route3Segments[1] = this.stopOffLibraryTURK1[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route3Segments[1] = this.segmentLibraryTURK1[this.route3Segment[1]];
					}
				}
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 1)
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route3Segments[1] = this.stopOffLibraryTURK2[this.route3Segment[1]];
					}
					else
					{
						this.route3Segment[1] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route3Segments[1] = this.segmentLibraryTURK2[this.route3Segment[1]];
					}
				}
			}
			if (this.route3Distance > 2)
			{
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route3Segments[2] = this.stopOffLibraryTURK1[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route3Segments[2] = this.segmentLibraryTURK1[this.route3Segment[2]];
					}
				}
				if (this.route3Segments[1].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 2)
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route3Segments[2] = this.stopOffLibraryTURK2[this.route3Segment[2]];
					}
					else
					{
						this.route3Segment[2] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route3Segments[2] = this.segmentLibraryTURK2[this.route3Segment[2]];
					}
				}
			}
			if (this.route3Distance > 3)
			{
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route3Segments[3] = this.stopOffLibraryTURK1[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route3Segments[3] = this.segmentLibraryTURK1[this.route3Segment[3]];
					}
				}
				if (this.route3Segments[2].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 3)
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route3Segments[3] = this.stopOffLibraryTURK2[this.route3Segment[3]];
					}
					else
					{
						this.route3Segment[3] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route3Segments[3] = this.segmentLibraryTURK2[this.route3Segment[3]];
					}
				}
			}
			if (this.route3Distance > 4)
			{
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route3Segments[4] = this.stopOffLibraryTURK1[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route3Segments[4] = this.segmentLibraryTURK1[this.route3Segment[4]];
					}
				}
				if (this.route3Segments[3].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 4)
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route3Segments[4] = this.stopOffLibraryTURK2[this.route3Segment[4]];
					}
					else
					{
						this.route3Segment[4] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route3Segments[4] = this.segmentLibraryTURK2[this.route3Segment[4]];
					}
				}
			}
			if (this.route3Distance > 5)
			{
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK1.Length);
						this.route3Segments[5] = this.stopOffLibraryTURK1[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryTURK1.Length);
						this.route3Segments[5] = this.segmentLibraryTURK1[this.route3Segment[5]];
					}
				}
				if (this.route3Segments[4].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					if (this.route3StopOffPoint == 5)
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.stopOffLibraryTURK2.Length);
						this.route3Segments[5] = this.stopOffLibraryTURK2[this.route3Segment[5]];
					}
					else
					{
						this.route3Segment[5] = UnityEngine.Random.Range(0, this.segmentLibraryTURK2.Length);
						this.route3Segments[5] = this.segmentLibraryTURK2[this.route3Segment[5]];
					}
				}
			}
		}
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x000D4614 File Offset: 0x000D2A14
	public void GetRoute2()
	{
		this.route2Weather = UnityEngine.Random.Range(0, 101);
		if (this.route2Weather <= this.sunChance)
		{
			this.mapText2.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[0];
			this.route2WeatherCode = 0;
		}
		if (this.route2Weather <= this.fogChance && this.route2Weather > this.sunChance)
		{
			this.mapText2.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[1];
			this.route2WeatherCode = 1;
		}
		if (this.route2Weather <= this.lightRainChance && this.route2Weather > this.fogChance)
		{
			this.mapText2.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[2];
			this.route2WeatherCode = 2;
		}
		if (this.route2Weather <= this.heavyRainChance && this.route2Weather > this.lightRainChance)
		{
			this.mapText2.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[3];
			this.route3WeatherCode = 3;
		}
		this.route2RoadCondition = UnityEngine.Random.Range(0, 101);
		if (this.route2RoadCondition <= this.goodRoadConditionChance)
		{
			this.mapText2.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[0];
			this.route2RoadCode = 0;
		}
		else if (this.route2RoadCondition <= this.poorRoadConditionChance && this.route2RoadCondition > this.goodRoadConditionChance)
		{
			this.mapText2.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[1];
			this.route2RoadCode = 1;
		}
		else
		{
			this.mapText2.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[2];
			this.route2RoadCode = 2;
		}
		if (this.route2Distance > 3)
		{
			this.route2StopOffPoint = UnityEngine.Random.Range(1, this.route2Distance);
			int num = UnityEngine.Random.Range(0, 100);
			if (num > 75)
			{
				this.route2StopOff = 1;
			}
			else
			{
				this.route2StopOff = 0;
			}
		}
		else
		{
			this.route2StopOffPoint = 0;
			this.route2StopOff = 0;
		}
		if (!this.drivingTowardsHome)
		{
			if (this.routeLevel == 0)
			{
				this.GatherGermanRoute2();
			}
			else if (this.routeLevel == 1)
			{
				this.GatherCSFRRoute2();
			}
			else if (this.routeLevel == 2)
			{
				this.GatherHUNRoute2();
			}
			else if (this.routeLevel == 3)
			{
				this.GatherYUGORoute2();
			}
			else if (this.routeLevel == 4)
			{
				this.GatherBULRoute2();
			}
			else if (this.routeLevel == 5)
			{
				this.GatherTURKRoute2();
			}
		}
		else
		{
			if (this.routeLevel == 0)
			{
				this.GatherGermanRoute2();
			}
			if (this.routeLevel == 1)
			{
				this.GatherGermanRoute2();
			}
			else if (this.routeLevel == 2)
			{
				this.GatherCSFRRoute2();
			}
			else if (this.routeLevel == 3)
			{
				this.GatherHUNRoute2();
			}
			else if (this.routeLevel == 4)
			{
				this.GatherYUGORoute2();
			}
			else if (this.routeLevel == 5)
			{
				this.GatherBULRoute2();
			}
			else if (this.routeLevel == 6)
			{
				this.GatherTURKRoute2();
			}
		}
		this.GetRoute3();
		this.SetRoute2Text();
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x000D499C File Offset: 0x000D2D9C
	public void GetRoute3()
	{
		this.route3Weather = UnityEngine.Random.Range(0, 101);
		if (this.route3Weather <= this.sunChance)
		{
			this.mapText3.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[0];
			this.route3WeatherCode = 0;
		}
		if (this.route3Weather <= this.fogChance && this.route3Weather > this.sunChance)
		{
			this.mapText3.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[1];
			this.route3WeatherCode = 1;
		}
		if (this.route3Weather <= this.lightRainChance && this.route3Weather > this.fogChance)
		{
			this.mapText3.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[2];
			this.route3WeatherCode = 2;
		}
		if (this.route3Weather <= this.heavyRainChance && this.route3Weather > this.lightRainChance)
		{
			this.mapText3.GetComponent<MapRelayC>().weatherIcon.GetComponent<SpriteRenderer>().sprite = this.weatherIcons[3];
			this.route3WeatherCode = 3;
		}
		this.route3RoadCondition = UnityEngine.Random.Range(0, 101);
		if (this.route3RoadCondition <= this.goodRoadConditionChance)
		{
			this.mapText3.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[0];
			this.route3RoadCode = 0;
		}
		else if (this.route3RoadCondition <= this.poorRoadConditionChance && this.route3RoadCondition > this.goodRoadConditionChance)
		{
			this.mapText3.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[1];
			this.route3RoadCode = 1;
		}
		else
		{
			this.mapText3.GetComponent<MapRelayC>().roadConditionIcon.GetComponent<SpriteRenderer>().sprite = this.roadConditionIcons[2];
			this.route3RoadCode = 2;
		}
		if (this.route3Distance > 3)
		{
			this.route3StopOffPoint = UnityEngine.Random.Range(1, this.route3Distance);
			int num = UnityEngine.Random.Range(0, 100);
			if (num > 75)
			{
				this.route3StopOff = 1;
			}
			else
			{
				this.route3StopOff = 0;
			}
		}
		else
		{
			this.route3StopOffPoint = 0;
			this.route3StopOff = 0;
		}
		if (!this.drivingTowardsHome)
		{
			if (this.routeLevel == 0)
			{
				this.GatherGermanRoute3();
			}
			else if (this.routeLevel == 1)
			{
				this.GatherCSFRRoute3();
			}
			else if (this.routeLevel == 2)
			{
				this.GatherHUNRoute3();
			}
			else if (this.routeLevel == 3)
			{
				this.GatherYUGORoute3();
			}
			else if (this.routeLevel == 4)
			{
				this.GatherBULRoute3();
			}
			else if (this.routeLevel == 5)
			{
				this.GatherTURKRoute3();
			}
		}
		else
		{
			if (this.routeLevel == 0)
			{
				this.GatherGermanRoute3();
			}
			if (this.routeLevel == 1)
			{
				this.GatherGermanRoute3();
			}
			else if (this.routeLevel == 2)
			{
				this.GatherCSFRRoute3();
			}
			else if (this.routeLevel == 3)
			{
				this.GatherHUNRoute3();
			}
			else if (this.routeLevel == 4)
			{
				this.GatherYUGORoute3();
			}
			else if (this.routeLevel == 5)
			{
				this.GatherBULRoute3();
			}
			else if (this.routeLevel == 6)
			{
				this.GatherTURKRoute3();
			}
		}
		this.SetRoute3Text();
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x000D4D20 File Offset: 0x000D3120
	public void DeleteRoute()
	{
		for (int i = 0; i < this.spawnedRouteSegments.Count; i++)
		{
			if (this.spawnedRouteSegments[i] != null)
			{
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[i].gameObject);
			}
		}
		for (int j = 0; j < this.spawnedRouteSegments.Count; j++)
		{
			this.spawnedRouteSegments.RemoveAt(j);
		}
		for (int k = 0; k < this.cratesToBeCleanedUp.Count; k++)
		{
			if (this.cratesToBeCleanedUp[k] == null)
			{
				this.cratesToBeCleanedUp.RemoveAt(k);
			}
			else
			{
				float num = Vector3.Distance(this.cratesToBeCleanedUp[k].transform.position, this._camera.transform.position);
				if (num > 150f)
				{
					UnityEngine.Object.Destroy(this.cratesToBeCleanedUp[k]);
					this.cratesToBeCleanedUp.RemoveAt(k);
				}
			}
		}
		this.routeGenerated = false;
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x000D4E40 File Offset: 0x000D3240
	public void UpdateGarbageCollection(int num)
	{
		for (int i = 0; i < this.cratesToBeCleanedUp.Count; i++)
		{
			if (this.cratesToBeCleanedUp[i] != null && this.cratesToBeCleanedUp[i].GetComponent<ObjectPickupC>().isInGarbageCollection >= num)
			{
				this.cratesToBeCleanedUp[i].GetComponent<ObjectPickupC>().isInGarbageCollection--;
			}
		}
	}

	// Token: 0x06000937 RID: 2359 RVA: 0x000D4EBA File Offset: 0x000D32BA
	public void SetRoute1Text()
	{
		this.mapText1.GetComponent<MapRelayC>().distance = this.route1Distance;
		this.mapText1.GetComponent<MapRelayC>().SetText();
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x000D4EE4 File Offset: 0x000D32E4
	public void SpawnRoute1()
	{
		this.routeChosen = 1;
		this.SetRoadConditions();
		this.SetWeather();
		if (!this.drivingTowardsHome)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.route1RoundaboutSegment);
			gameObject.transform.position = this.firstSegmentTarget.transform.position;
			this.spawnedRouteSegments.Add(this.startingEnvironment);
			this.spawnedRouteSegments.Add(gameObject);
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
			gameObject2.transform.position = gameObject.GetComponent<RoundaboutC>().continueNode.transform.position;
			this.spawnedRouteSegments.Add(gameObject2);
			this.routeAmmo++;
		}
		else
		{
			if (this.spawnedHub != null)
			{
				if (this.spawnedHub.GetComponent<Hub_CitySpawnC>())
				{
					this.spawnedHub.GetComponent<Hub_CitySpawnC>().GateOpen();
					this.borderOpen = false;
				}
			}
			else if (this.startingEnvironment != null && this.startingEnvironment.GetComponent<Hub_CitySpawnC>())
			{
				this.startingEnvironment.GetComponent<Hub_CitySpawnC>().GateOpen();
				this.borderOpen = false;
			}
			if (this.routeLevel == 1)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutGer3_1);
					gameObject3.transform.position = base.transform.position;
					gameObject3.transform.position += new Vector3(0f, 0f, 800f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject3);
					GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject4.transform.position = gameObject3.GetComponent<RoundaboutC>().transform.position;
					gameObject4.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject4);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutGer2_1);
					gameObject5.transform.position = base.transform.position;
					gameObject5.transform.position += new Vector3(0f, 0f, 600f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject5);
					GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject6.transform.position = gameObject5.GetComponent<RoundaboutC>().transform.position;
					gameObject6.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject6);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 2)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutCSFR1_1);
					gameObject7.transform.position = base.transform.position;
					gameObject7.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject7);
					GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject8.transform.position = gameObject7.GetComponent<RoundaboutC>().transform.position;
					gameObject8.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject8);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutCSFR0_1);
					gameObject9.transform.position = base.transform.position;
					gameObject9.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject9);
					GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject10.transform.position = gameObject9.GetComponent<RoundaboutC>().transform.position;
					gameObject10.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject10);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 3)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					GameObject gameObject11 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutHUN0_0);
					gameObject11.transform.position = base.transform.position;
					gameObject11.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject11);
					GameObject gameObject12 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject12.transform.position = gameObject11.GetComponent<RoundaboutC>().transform.position;
					gameObject12.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject12);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject13 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutHUN2_0);
					gameObject13.transform.position = base.transform.position;
					gameObject13.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject13);
					GameObject gameObject14 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject14.transform.position = gameObject13.GetComponent<RoundaboutC>().transform.position;
					gameObject14.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject14);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 4)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					GameObject gameObject15 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutYUGO0_1);
					gameObject15.transform.position = base.transform.position;
					gameObject15.transform.position += new Vector3(0f, 0f, 400f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject15);
					GameObject gameObject16 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject16.transform.position = gameObject15.GetComponent<RoundaboutC>().transform.position;
					gameObject16.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject16);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject17 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutYUGO0_0);
					gameObject17.transform.position = base.transform.position;
					gameObject17.transform.position += new Vector3(0f, 0f, 400f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject17);
					GameObject gameObject18 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject18.transform.position = gameObject17.GetComponent<RoundaboutC>().transform.position;
					gameObject18.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject18);
					this.routeAmmo++;
				}
				UnityEngine.Object.Destroy(this.startingEnvironment.GetComponent<Hub_CitySpawnC>().spawnedYugoScenery);
			}
			if (this.routeLevel == 5)
			{
				GameObject gameObject19 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutBUL0_0);
				gameObject19.transform.position = base.transform.position;
				this.spawnedRouteSegments.Add(this.startingEnvironment);
				this.spawnedRouteSegments.Add(gameObject19);
				GameObject gameObject20 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
				gameObject20.transform.position = gameObject19.GetComponent<RoundaboutC>().transform.position;
				gameObject20.transform.position += new Vector3(0f, 0f, 1000f);
				this.spawnedRouteSegments.Add(gameObject20);
				this.routeAmmo++;
			}
			if (this.routeLevel == 6)
			{
				if (this.route1Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					GameObject gameObject21 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutTURK2_3);
					gameObject21.transform.position = base.transform.position;
					gameObject21.transform.position += new Vector3(0f, 0f, 200f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject21);
					GameObject gameObject22 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject22.transform.position = gameObject21.GetComponent<RoundaboutC>().transform.position;
					gameObject22.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject22);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject23 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutTURK1_3);
					gameObject23.transform.position = base.transform.position;
					gameObject23.transform.position += new Vector3(0f, 0f, 200f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject23);
					GameObject gameObject24 = UnityEngine.Object.Instantiate<GameObject>(this.route1Segments[0]);
					gameObject24.transform.position = gameObject23.GetComponent<RoundaboutC>().transform.position;
					gameObject24.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject24);
					this.routeAmmo++;
				}
			}
		}
		if (this.drivingTowardsHome)
		{
			if (this.routeLevel == 4)
			{
				int num = 8;
				int num2 = 0;
				for (int i = 0; i <= num; i++)
				{
					GameObject gameObject25 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
					Vector3 position = this.firstSegmentTarget.transform.position + new Vector3(0f, 0f, (float)num2);
					gameObject25.transform.position = position;
					this.spawnedRouteSegments.Add(gameObject25);
					Debug.Log(" i rate of sea spawn : " + i);
					Debug.Log("Sea Pos Adjust : " + num2);
					num2 += 1000;
				}
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
			}
		}
		else if (this.routeLevel == 3)
		{
			int num3 = 8;
			int num4 = 0;
			for (int j = 0; j <= num3 + 1; j++)
			{
				GameObject gameObject26 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
				if (j == num3 + 1)
				{
					num4 = 1000;
				}
				Vector3 position2 = this.firstSegmentTarget.transform.position + new Vector3(0f, 0f, (float)num4);
				gameObject26.transform.position = position2;
				this.spawnedRouteSegments.Add(gameObject26);
				num4 -= 1000;
			}
		}
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x000D5C2C File Offset: 0x000D402C
	public void SpawnRoute2()
	{
		this.routeChosen = 2;
		this.SetRoadConditions();
		this.SetWeather();
		if (!this.drivingTowardsHome)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.route2RoundaboutSegment);
			gameObject.transform.position = this.firstSegmentTarget.transform.position;
			this.spawnedRouteSegments.Add(this.startingEnvironment);
			this.spawnedRouteSegments.Add(gameObject);
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
			gameObject2.transform.position = gameObject.GetComponent<RoundaboutC>().continueNode.transform.position;
			this.spawnedRouteSegments.Add(gameObject2);
			this.routeAmmo++;
		}
		else
		{
			if (this.spawnedHub != null)
			{
				if (this.spawnedHub.GetComponent<Hub_CitySpawnC>())
				{
					this.spawnedHub.GetComponent<Hub_CitySpawnC>().GateOpen();
					this.borderOpen = false;
				}
			}
			else if (this.startingEnvironment != null && this.startingEnvironment.GetComponent<Hub_CitySpawnC>())
			{
				this.startingEnvironment.GetComponent<Hub_CitySpawnC>().GateOpen();
				this.borderOpen = false;
			}
			if (this.routeLevel == 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 3)
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutGer3_1);
					gameObject3.transform.position = base.transform.position;
					gameObject3.transform.position += new Vector3(0f, 0f, 800f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject3);
					GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject4.transform.position = gameObject3.GetComponent<RoundaboutC>().transform.position;
					gameObject4.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject4);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutGer2_1);
					gameObject5.transform.position = base.transform.position;
					gameObject5.transform.position += new Vector3(0f, 0f, 600f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject5);
					GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject6.transform.position = gameObject5.GetComponent<RoundaboutC>().transform.position;
					gameObject6.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject6);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 2)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutCSFR1_1);
					gameObject7.transform.position = base.transform.position;
					gameObject7.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject7);
					GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject8.transform.position = gameObject7.GetComponent<RoundaboutC>().transform.position;
					gameObject8.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject8);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutCSFR0_1);
					gameObject9.transform.position = base.transform.position;
					gameObject9.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject9);
					GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject10.transform.position = gameObject9.GetComponent<RoundaboutC>().transform.position;
					gameObject10.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject10);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 3)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					GameObject gameObject11 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutHUN0_0);
					gameObject11.transform.position = base.transform.position;
					gameObject11.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject11);
					GameObject gameObject12 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject12.transform.position = gameObject11.GetComponent<RoundaboutC>().transform.position;
					gameObject12.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject12);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject13 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutHUN2_0);
					gameObject13.transform.position = base.transform.position;
					gameObject13.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject13);
					GameObject gameObject14 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject14.transform.position = gameObject13.GetComponent<RoundaboutC>().transform.position;
					gameObject14.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject14);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 4)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					GameObject gameObject15 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutYUGO0_1);
					gameObject15.transform.position = base.transform.position;
					gameObject15.transform.position += new Vector3(0f, 0f, 400f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject15);
					GameObject gameObject16 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject16.transform.position = gameObject15.GetComponent<RoundaboutC>().transform.position;
					gameObject16.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject16);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject17 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutYUGO0_0);
					gameObject17.transform.position = base.transform.position;
					gameObject17.transform.position += new Vector3(0f, 0f, 400f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject17);
					GameObject gameObject18 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject18.transform.position = gameObject17.GetComponent<RoundaboutC>().transform.position;
					gameObject18.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject18);
					this.routeAmmo++;
				}
				UnityEngine.Object.Destroy(this.startingEnvironment.GetComponent<Hub_CitySpawnC>().spawnedYugoScenery);
			}
			if (this.routeLevel == 5)
			{
				GameObject gameObject19 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutBUL0_0);
				gameObject19.transform.position = base.transform.position;
				this.spawnedRouteSegments.Add(this.startingEnvironment);
				this.spawnedRouteSegments.Add(gameObject19);
				GameObject gameObject20 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
				gameObject20.transform.position = gameObject19.GetComponent<RoundaboutC>().transform.position;
				gameObject20.transform.position += new Vector3(0f, 0f, 1000f);
				this.spawnedRouteSegments.Add(gameObject20);
				this.routeAmmo++;
			}
			if (this.routeLevel == 6)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					GameObject gameObject21 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutTURK2_3);
					gameObject21.transform.position = base.transform.position;
					gameObject21.transform.position += new Vector3(0f, 0f, 200f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject21);
					GameObject gameObject22 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject22.transform.position = gameObject21.GetComponent<RoundaboutC>().transform.position;
					gameObject22.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject22);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject23 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutTURK1_3);
					gameObject23.transform.position = base.transform.position;
					gameObject23.transform.position += new Vector3(0f, 0f, 200f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject23);
					GameObject gameObject24 = UnityEngine.Object.Instantiate<GameObject>(this.route2Segments[0]);
					gameObject24.transform.position = gameObject23.GetComponent<RoundaboutC>().transform.position;
					gameObject24.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject24);
					this.routeAmmo++;
				}
			}
		}
		if (this.drivingTowardsHome)
		{
			if (this.routeLevel == 4)
			{
				int num = 8;
				int num2 = 0;
				for (int i = 0; i <= num; i++)
				{
					GameObject gameObject25 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
					Vector3 position = this.firstSegmentTarget.transform.position + new Vector3(0f, 0f, (float)num2);
					gameObject25.transform.position = position;
					this.spawnedRouteSegments.Add(gameObject25);
					Debug.Log(" i rate of sea spawn : " + i);
					Debug.Log("Sea Pos Adjust : " + num2);
					num2 += 1000;
				}
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
			}
		}
		else if (this.routeLevel == 3)
		{
			int num3 = 8;
			int num4 = 0;
			for (int j = 0; j <= num3 + 1; j++)
			{
				GameObject gameObject26 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
				if (j == num3 + 1)
				{
					num4 = 1000;
				}
				Vector3 position2 = this.firstSegmentTarget.transform.position + new Vector3(0f, 0f, (float)num4);
				gameObject26.transform.position = position2;
				this.spawnedRouteSegments.Add(gameObject26);
				num4 -= 1000;
			}
		}
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x000D6974 File Offset: 0x000D4D74
	public void SpawnRoute3()
	{
		this.routeChosen = 3;
		this.SetRoadConditions();
		this.SetWeather();
		if (!this.drivingTowardsHome)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.route3RoundaboutSegment);
			gameObject.transform.position = this.firstSegmentTarget.transform.position;
			this.spawnedRouteSegments.Add(this.startingEnvironment);
			this.spawnedRouteSegments.Add(gameObject);
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
			gameObject2.transform.position = gameObject.GetComponent<RoundaboutC>().continueNode.transform.position;
			this.spawnedRouteSegments.Add(gameObject2);
			this.routeAmmo++;
		}
		else
		{
			if (this.spawnedHub != null)
			{
				if (this.spawnedHub.GetComponent<Hub_CitySpawnC>())
				{
					this.spawnedHub.GetComponent<Hub_CitySpawnC>().GateOpen();
					this.borderOpen = false;
				}
			}
			else if (this.startingEnvironment != null && this.startingEnvironment.GetComponent<Hub_CitySpawnC>())
			{
				this.startingEnvironment.GetComponent<Hub_CitySpawnC>().GateOpen();
				this.borderOpen = false;
			}
			if (this.routeLevel == 1)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutGer3_1);
					gameObject3.transform.position = base.transform.position;
					gameObject3.transform.position += new Vector3(0f, 0f, 800f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject3);
					GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject4.transform.position = gameObject3.GetComponent<RoundaboutC>().transform.position;
					gameObject4.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject4);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutGer2_1);
					gameObject5.transform.position = base.transform.position;
					gameObject5.transform.position += new Vector3(0f, 0f, 600f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject5);
					GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject6.transform.position = gameObject5.GetComponent<RoundaboutC>().transform.position;
					gameObject6.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject6);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 2)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutCSFR1_1);
					gameObject7.transform.position = base.transform.position;
					gameObject7.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject7);
					GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject8.transform.position = gameObject7.GetComponent<RoundaboutC>().transform.position;
					gameObject8.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject8);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutCSFR0_1);
					gameObject9.transform.position = base.transform.position;
					gameObject9.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject9);
					GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject10.transform.position = gameObject9.GetComponent<RoundaboutC>().transform.position;
					gameObject10.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject10);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 3)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 0)
				{
					GameObject gameObject11 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutHUN0_0);
					gameObject11.transform.position = base.transform.position;
					gameObject11.transform.position += new Vector3(0f, 0f, 500f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject11);
					GameObject gameObject12 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject12.transform.position = gameObject11.GetComponent<RoundaboutC>().transform.position;
					gameObject12.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject12);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject13 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutHUN2_0);
					gameObject13.transform.position = base.transform.position;
					gameObject13.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject13);
					GameObject gameObject14 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject14.transform.position = gameObject13.GetComponent<RoundaboutC>().transform.position;
					Vector3 vector = gameObject14.transform.position;
					vector += new Vector3(gameObject14.transform.position.x, gameObject14.transform.position.y, -1000f);
					gameObject14.transform.position += vector;
					this.spawnedRouteSegments.Add(gameObject14);
					this.routeAmmo++;
				}
			}
			if (this.routeLevel == 4)
			{
				if (this.route2Segments[0].GetComponent<SpawnContinueC>().continueSize == 1)
				{
					GameObject gameObject15 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutYUGO0_1);
					gameObject15.transform.position = base.transform.position;
					gameObject15.transform.position += new Vector3(0f, 0f, 400f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject15);
					GameObject gameObject16 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject16.transform.position = gameObject15.GetComponent<RoundaboutC>().transform.position;
					gameObject16.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject16);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject17 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutYUGO0_0);
					gameObject17.transform.position = base.transform.position;
					gameObject17.transform.position += new Vector3(0f, 0f, 400f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject17);
					GameObject gameObject18 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject18.transform.position = gameObject17.GetComponent<RoundaboutC>().transform.position;
					gameObject18.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject18);
					this.routeAmmo++;
				}
				UnityEngine.Object.Destroy(this.startingEnvironment.GetComponent<Hub_CitySpawnC>().spawnedYugoScenery);
			}
			if (this.routeLevel == 5)
			{
				GameObject gameObject19 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutBUL0_0);
				gameObject19.transform.position = base.transform.position;
				this.spawnedRouteSegments.Add(this.startingEnvironment);
				this.spawnedRouteSegments.Add(gameObject19);
				GameObject gameObject20 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
				gameObject20.transform.position = gameObject19.GetComponent<RoundaboutC>().transform.position;
				gameObject20.transform.position += new Vector3(0f, 0f, 1000f);
				this.spawnedRouteSegments.Add(gameObject20);
				this.routeAmmo++;
			}
			if (this.routeLevel == 6)
			{
				if (this.route3Segments[0].GetComponent<SpawnContinueC>().continueSize == 2)
				{
					GameObject gameObject21 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutTURK2_3);
					gameObject21.transform.position = base.transform.position;
					gameObject21.transform.position += new Vector3(0f, 0f, 200f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject21);
					GameObject gameObject22 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject22.transform.position = gameObject21.GetComponent<RoundaboutC>().transform.position;
					gameObject22.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject22);
					this.routeAmmo++;
				}
				else
				{
					GameObject gameObject23 = UnityEngine.Object.Instantiate<GameObject>(this.roundaboutTURK1_3);
					gameObject23.transform.position = base.transform.position;
					gameObject23.transform.position += new Vector3(0f, 0f, 200f);
					this.spawnedRouteSegments.Add(this.startingEnvironment);
					this.spawnedRouteSegments.Add(gameObject23);
					GameObject gameObject24 = UnityEngine.Object.Instantiate<GameObject>(this.route3Segments[0]);
					gameObject24.transform.position = gameObject23.GetComponent<RoundaboutC>().transform.position;
					gameObject24.transform.position += new Vector3(0f, 0f, 1000f);
					this.spawnedRouteSegments.Add(gameObject24);
					this.routeAmmo++;
				}
			}
		}
		if (this.drivingTowardsHome)
		{
			if (this.routeLevel == 4)
			{
				int num = 8;
				int num2 = 0;
				for (int i = 0; i <= num; i++)
				{
					GameObject gameObject25 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
					Vector3 position = this.firstSegmentTarget.transform.position + new Vector3(0f, 0f, (float)num2);
					gameObject25.transform.position = position;
					this.spawnedRouteSegments.Add(gameObject25);
					Debug.Log(" i rate of sea spawn : " + i);
					Debug.Log("Sea Pos Adjust : " + num2);
					num2 += 1000;
				}
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
				UnityEngine.Object.Destroy(this.spawnedRouteSegments[0].gameObject);
				this.spawnedRouteSegments.RemoveAt(0);
			}
		}
		else if (this.routeLevel == 3)
		{
			int num3 = 8;
			int num4 = 0;
			for (int j = 0; j <= num3 + 1; j++)
			{
				GameObject gameObject26 = UnityEngine.Object.Instantiate<GameObject>(this.yugoSea);
				if (j == num3 + 1)
				{
					num4 = 1000;
				}
				Vector3 position2 = this.firstSegmentTarget.transform.position + new Vector3(0f, 0f, (float)num4);
				gameObject26.transform.position = position2;
				this.spawnedRouteSegments.Add(gameObject26);
				num4 -= 1000;
			}
		}
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x000D76F3 File Offset: 0x000D5AF3
	public void SpawnRoute4()
	{
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x000D76F5 File Offset: 0x000D5AF5
	public void SetRoute2Text()
	{
		this.mapText2.GetComponent<MapRelayC>().distance = this.route2Distance;
		this.mapText2.GetComponent<MapRelayC>().SetText();
	}

	// Token: 0x0600093D RID: 2365 RVA: 0x000D7720 File Offset: 0x000D5B20
	public void StopRain()
	{
		this.uDayCycle.GetComponent<DNC_soundEffect>().SetSunnyAudio();
		base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
		if (this.rainTarget != null)
		{
			UnityEngine.Object.Destroy(this.rainTarget);
		}
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x000D7774 File Offset: 0x000D5B74
	public void SetRoadConditions()
	{
		if (this.routeChosen == 1)
		{
			this.currentRoadCondition = this.route1RoadCode;
		}
		else if (this.routeChosen == 2)
		{
			this.currentRoadCondition = this.route2RoadCode;
		}
		else if (this.routeChosen == 3)
		{
			this.currentRoadCondition = this.route3RoadCode;
		}
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x000D77D4 File Offset: 0x000D5BD4
	public void SetWeather()
	{
		this.rainType = 0;
		this.uDayCycle.GetComponent<DNC_DayNight>().isPaused = false;
		if (this.routeChosen == -1)
		{
			this.uDayCycle.GetComponent<DNC_soundEffect>().SetFogAudio();
			base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
			base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = true;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = true;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = true;
			this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = true;
			if (this.rainTarget != null)
			{
				UnityEngine.Object.Destroy(this.rainTarget);
			}
			return;
		}
		if (this.routeChosen == 1)
		{
			this.currentWeatherCondition = this.route1WeatherCode;
			if (this.route1Weather <= this.sunChance)
			{
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetSunnyAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				DNC_DayNight component = this.uDayCycle.GetComponent<DNC_DayNight>();
				component.timeOfDayTransitions[0].enabled = true;
				component.timeOfDayTransitions[1].enabled = true;
				component.timeOfDayTransitions[2].enabled = true;
				component.timeOfDayTransitions[3].enabled = true;
				component.timeOfDayTransitions[4].enabled = false;
				component.timeOfDayTransitions[5].enabled = false;
				component.timeOfDayTransitions[6].enabled = false;
				component.timeOfDayTransitions[7].enabled = false;
				component.timeOfDayTransitions[8].enabled = false;
				component.timeOfDayTransitions[9].enabled = false;
				component.timeOfDayTransitions[10].enabled = false;
				component.timeOfDayTransitions[11].enabled = false;
				if (this.rainTarget != null)
				{
					UnityEngine.Object.Destroy(this.rainTarget);
				}
				return;
			}
			if (this.route1Weather <= this.fogChance && this.route1Weather > this.sunChance)
			{
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetFogAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = true;
				if (this.rainTarget != null)
				{
					UnityEngine.Object.Destroy(this.rainTarget);
				}
				return;
			}
			if (this.route1Weather <= this.lightRainChance && this.route1Weather > this.fogChance)
			{
				this.rainType = 1;
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetLightRainAudio();
				if (this.seatLogic.GetComponent<SeatLogicC>().isSat)
				{
					this.seatLogic.GetComponent<SeatLogicC>().ForceRainAudio();
				}
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = true;
				this.rainTarget = UnityEngine.Object.Instantiate<GameObject>(this.lightRain, this.firstSegmentTarget.transform.position, Quaternion.identity);
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetLightRainWindows();
				return;
			}
			if (this.route1Weather <= this.heavyRainChance && this.route1Weather > this.lightRainChance)
			{
				this.rainType = 2;
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetHeavyRainAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				if (this.seatLogic.GetComponent<SeatLogicC>().isSat)
				{
					this.seatLogic.GetComponent<SeatLogicC>().ForceRainAudio();
				}
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = false;
				this.rainTarget = UnityEngine.Object.Instantiate<GameObject>(this.heavyRain, this.firstSegmentTarget.transform.position, Quaternion.identity);
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetHeavyRainWindows();
				return;
			}
		}
		if (this.routeChosen == 2)
		{
			this.currentWeatherCondition = this.route2WeatherCode;
			if (this.route2Weather <= this.sunChance)
			{
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetSunnyAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = false;
				if (this.rainTarget != null)
				{
					UnityEngine.Object.Destroy(this.rainTarget);
				}
				return;
			}
			if (this.route2Weather <= this.fogChance && this.route2Weather > this.sunChance)
			{
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetFogAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = true;
				if (this.rainTarget != null)
				{
					UnityEngine.Object.Destroy(this.rainTarget);
				}
				return;
			}
			if (this.route2Weather <= this.lightRainChance && this.route2Weather > this.fogChance)
			{
				this.rainType = 1;
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetLightRainAudio();
				if (this.seatLogic.GetComponent<SeatLogicC>().isSat)
				{
					this.seatLogic.GetComponent<SeatLogicC>().ForceRainAudio();
				}
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = true;
				this.rainTarget = UnityEngine.Object.Instantiate<GameObject>(this.lightRain, this.firstSegmentTarget.transform.position, Quaternion.identity);
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetLightRainWindows();
				return;
			}
			if (this.route2Weather <= this.heavyRainChance && this.route2Weather > this.lightRainChance)
			{
				this.rainType = 2;
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetHeavyRainAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				if (this.seatLogic.GetComponent<SeatLogicC>().isSat)
				{
					this.seatLogic.GetComponent<SeatLogicC>().ForceRainAudio();
				}
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = false;
				this.rainTarget = UnityEngine.Object.Instantiate<GameObject>(this.heavyRain, this.firstSegmentTarget.transform.position, Quaternion.identity);
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetHeavyRainWindows();
				return;
			}
		}
		if (this.routeChosen == 3)
		{
			this.currentWeatherCondition = this.route3WeatherCode;
			if (this.route3Weather <= this.sunChance)
			{
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetSunnyAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = false;
				if (this.rainTarget != null)
				{
					UnityEngine.Object.Destroy(this.rainTarget);
				}
				return;
			}
			if (this.route3Weather <= this.fogChance && this.route3Weather > this.sunChance)
			{
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetFogAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = true;
				if (this.rainTarget != null)
				{
					UnityEngine.Object.Destroy(this.rainTarget);
				}
				return;
			}
			if (this.route3Weather <= this.lightRainChance && this.route3Weather > this.fogChance)
			{
				this.rainType = 1;
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetLightRainAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				if (this.seatLogic.GetComponent<SeatLogicC>().isSat)
				{
					this.seatLogic.GetComponent<SeatLogicC>().ForceRainAudio();
				}
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = true;
				this.rainTarget = UnityEngine.Object.Instantiate<GameObject>(this.lightRain, this.firstSegmentTarget.transform.position, Quaternion.identity);
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetLightRainWindows();
				return;
			}
			if (this.route3Weather <= this.heavyRainChance && this.route3Weather > this.lightRainChance)
			{
				this.rainType = 2;
				this.uDayCycle.GetComponent<DNC_soundEffect>().SetHeavyRainAudio();
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
				if (this.seatLogic.GetComponent<SeatLogicC>().isSat)
				{
					this.seatLogic.GetComponent<SeatLogicC>().ForceRainAudio();
				}
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[0].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[1].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[2].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[3].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[4].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[5].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[6].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[7].enabled = true;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[8].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[9].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[10].enabled = false;
				this.uDayCycle.GetComponent<DNC_DayNight>().timeOfDayTransitions[11].enabled = false;
				this.rainTarget = UnityEngine.Object.Instantiate<GameObject>(this.heavyRain, this.firstSegmentTarget.transform.position, Quaternion.identity);
				base.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetHeavyRainWindows();
				return;
			}
		}
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x000D8E3E File Offset: 0x000D723E
	public void SetRoute3Text()
	{
		this.mapText3.GetComponent<MapRelayC>().distance = this.route3Distance;
		this.mapText3.GetComponent<MapRelayC>().SetText();
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x000D8E68 File Offset: 0x000D7268
	public void SpawnGerman()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.segmentLibraryGerStart[this.segment[0]]);
		gameObject.transform.position = Vector3.zero;
		this.routeAmmo++;
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x000D8EA8 File Offset: 0x000D72A8
	public void GatherAI()
	{
		base.Invoke("GatherAIDelayed", 2f);
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x000D8EBA File Offset: 0x000D72BA
	public void GatherAIDelayed()
	{
		this.aiDrivers = GameObject.FindGameObjectsWithTag("AICar");
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x000D8ECC File Offset: 0x000D72CC
	public void RemoveLights()
	{
		this.lightObjects.Clear();
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x000D8ED9 File Offset: 0x000D72D9
	public void StoreLights()
	{
		base.Invoke("StoreLightsDelayed", 5f);
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x000D8EEB File Offset: 0x000D72EB
	public void StoreLightsDelayed()
	{
		this.lightObjects.AddRange(GameObject.FindGameObjectsWithTag("StreetLight"));
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x000D8F04 File Offset: 0x000D7304
	public void Illuminate()
	{
		if (this.forceLightsOff)
		{
			for (int i = 0; i < this.lightObjects.Count; i++)
			{
				this.lightObjects[i].GetComponent<StreetLightC>().FakeIlluminate();
			}
			return;
		}
		for (int j = 0; j < this.lightObjects.Count; j++)
		{
			if (this.lightObjects[j].GetComponent<StreetLightC>() == null)
			{
				MonoBehaviour.print(this.lightObjects[j].name + " Does not have StreetLightC");
			}
			else
			{
				this.lightObjects[j].GetComponent<StreetLightC>().Illuminate();
			}
		}
	}

	// Token: 0x06000948 RID: 2376 RVA: 0x000D8FC4 File Offset: 0x000D73C4
	public void IlluminateStop()
	{
		if (this.forceLightsOff)
		{
			for (int i = 0; i < this.lightObjects.Count; i++)
			{
				if (this.lightObjects[i].GetComponent<StreetLightC>() == null)
				{
					MonoBehaviour.print(this.lightObjects[i].name + " Does not have StreetLightC");
				}
				else
				{
					this.lightObjects[i].GetComponent<StreetLightC>().FakeIlluminateStop();
				}
			}
			return;
		}
		for (int j = 0; j < this.lightObjects.Count; j++)
		{
			if (this.lightObjects[j].GetComponent<StreetLightC>() == null)
			{
				MonoBehaviour.print(this.lightObjects[j].name + " Does not have StreetLightC");
			}
			else
			{
				this.lightObjects[j].GetComponent<StreetLightC>().IlluminateStop();
			}
		}
	}

	// Token: 0x04000C09 RID: 3081
	public static RouteGeneratorC Global;

	// Token: 0x04000C0A RID: 3082
	private GameObject _camera;

	// Token: 0x04000C0B RID: 3083
	public int routeLevel;

	// Token: 0x04000C0C RID: 3084
	public bool drivingTowardsHome;

	// Token: 0x04000C0D RID: 3085
	public GameObject spawnedHub;

	// Token: 0x04000C0E RID: 3086
	public GameObject startingEnvironment;

	// Token: 0x04000C0F RID: 3087
	public bool borderOpen;

	// Token: 0x04000C10 RID: 3088
	public bool routeGenerated;

	// Token: 0x04000C11 RID: 3089
	public GameObject firstSegmentTarget;

	// Token: 0x04000C12 RID: 3090
	public GameObject[] segmentLibraryGerStart = new GameObject[0];

	// Token: 0x04000C13 RID: 3091
	public GameObject[] segmentLibraryGer3 = new GameObject[3];

	// Token: 0x04000C14 RID: 3092
	public GameObject[] stopOffLibraryGer3 = new GameObject[0];

	// Token: 0x04000C15 RID: 3093
	public GameObject[] segmentLibraryGer2 = new GameObject[3];

	// Token: 0x04000C16 RID: 3094
	public GameObject[] stopOffLibraryGer2 = new GameObject[0];

	// Token: 0x04000C17 RID: 3095
	public GameObject roundaboutGer2_2;

	// Token: 0x04000C18 RID: 3096
	public GameObject roundaboutGer2_3;

	// Token: 0x04000C19 RID: 3097
	public GameObject roundaboutGer3_1;

	// Token: 0x04000C1A RID: 3098
	public GameObject roundaboutGer2_1;

	// Token: 0x04000C1B RID: 3099
	public GameObject[] destinationObjectsGer = new GameObject[0];

	// Token: 0x04000C1C RID: 3100
	public GameObject[] destinationObjectsHome = new GameObject[0];

	// Token: 0x04000C1D RID: 3101
	public GameObject[] segmentLibraryCSFRStart = new GameObject[0];

	// Token: 0x04000C1E RID: 3102
	public GameObject[] segmentLibraryCSFR1 = new GameObject[3];

	// Token: 0x04000C1F RID: 3103
	public GameObject[] stopOffLibraryCSFR1 = new GameObject[0];

	// Token: 0x04000C20 RID: 3104
	public GameObject[] segmentLibraryCSFR0 = new GameObject[3];

	// Token: 0x04000C21 RID: 3105
	public GameObject[] stopOffLibraryCSFR0 = new GameObject[0];

	// Token: 0x04000C22 RID: 3106
	public GameObject roundaboutCSFR1_0;

	// Token: 0x04000C23 RID: 3107
	public GameObject roundaboutCSFR1_1;

	// Token: 0x04000C24 RID: 3108
	public GameObject roundaboutCSFR0_1;

	// Token: 0x04000C25 RID: 3109
	public GameObject[] destinationObjectsCSFR = new GameObject[0];

	// Token: 0x04000C26 RID: 3110
	public GameObject[] segmentLibraryHUNStart = new GameObject[0];

	// Token: 0x04000C27 RID: 3111
	public GameObject[] segmentLibraryHUN2 = new GameObject[3];

	// Token: 0x04000C28 RID: 3112
	public GameObject[] stopOffLibraryHUN2 = new GameObject[0];

	// Token: 0x04000C29 RID: 3113
	public GameObject[] segmentLibraryHUN0 = new GameObject[3];

	// Token: 0x04000C2A RID: 3114
	public GameObject[] stopOffLibraryHUN0 = new GameObject[0];

	// Token: 0x04000C2B RID: 3115
	public GameObject roundAboutHUN2_0;

	// Token: 0x04000C2C RID: 3116
	public GameObject roundAboutHUN2_2;

	// Token: 0x04000C2D RID: 3117
	public GameObject roundaboutHUN0_0;

	// Token: 0x04000C2E RID: 3118
	public GameObject roundaboutHUN2_0;

	// Token: 0x04000C2F RID: 3119
	public GameObject[] destinationObjectsHUN = new GameObject[0];

	// Token: 0x04000C30 RID: 3120
	public GameObject[] segmentLibraryYUGOStart = new GameObject[0];

	// Token: 0x04000C31 RID: 3121
	public GameObject[] segmentLibraryYUGO1 = new GameObject[3];

	// Token: 0x04000C32 RID: 3122
	public GameObject[] stopOffLibraryYUGO1 = new GameObject[0];

	// Token: 0x04000C33 RID: 3123
	public GameObject[] segmentLibraryYUGO0 = new GameObject[3];

	// Token: 0x04000C34 RID: 3124
	public GameObject[] stopOffLibraryYUGO0 = new GameObject[0];

	// Token: 0x04000C35 RID: 3125
	public GameObject roundaboutYUGO1_0;

	// Token: 0x04000C36 RID: 3126
	public GameObject roundaboutYUGO1_1;

	// Token: 0x04000C37 RID: 3127
	public GameObject roundaboutYUGO0_1;

	// Token: 0x04000C38 RID: 3128
	public GameObject roundaboutYUGO0_0;

	// Token: 0x04000C39 RID: 3129
	public GameObject[] destinationObjectsYUGO = new GameObject[0];

	// Token: 0x04000C3A RID: 3130
	public GameObject yugoSea;

	// Token: 0x04000C3B RID: 3131
	public GameObject yugoBackdrop;

	// Token: 0x04000C3C RID: 3132
	public GameObject[] segmentLibraryBULStart = new GameObject[0];

	// Token: 0x04000C3D RID: 3133
	public GameObject[] segmentLibraryBUL0 = new GameObject[3];

	// Token: 0x04000C3E RID: 3134
	public GameObject[] stopOffLibraryBUL0 = new GameObject[0];

	// Token: 0x04000C3F RID: 3135
	public GameObject roundaboutBUL0_0;

	// Token: 0x04000C40 RID: 3136
	public GameObject[] destinationObjectsBUL = new GameObject[0];

	// Token: 0x04000C41 RID: 3137
	public GameObject[] segmentLibraryTURKStart = new GameObject[0];

	// Token: 0x04000C42 RID: 3138
	public GameObject[] segmentLibraryTURK1 = new GameObject[3];

	// Token: 0x04000C43 RID: 3139
	public GameObject[] stopOffLibraryTURK1 = new GameObject[0];

	// Token: 0x04000C44 RID: 3140
	public GameObject[] segmentLibraryTURK2 = new GameObject[3];

	// Token: 0x04000C45 RID: 3141
	public GameObject[] stopOffLibraryTURK2 = new GameObject[0];

	// Token: 0x04000C46 RID: 3142
	public GameObject roundaboutTURK1_2;

	// Token: 0x04000C47 RID: 3143
	public GameObject roundaboutTURK1_1;

	// Token: 0x04000C48 RID: 3144
	public GameObject roundaboutTURK2_3;

	// Token: 0x04000C49 RID: 3145
	public GameObject roundaboutTURK1_3;

	// Token: 0x04000C4A RID: 3146
	public GameObject[] destinationObjectsTURK = new GameObject[0];

	// Token: 0x04000C4B RID: 3147
	public int economyState;

	// Token: 0x04000C4C RID: 3148
	public List<int> gerEconomyNumbers = new List<int>();

	// Token: 0x04000C4D RID: 3149
	public List<int> csfrEconomyNumbers = new List<int>();

	// Token: 0x04000C4E RID: 3150
	public List<int> hunEconomyNumbers = new List<int>();

	// Token: 0x04000C4F RID: 3151
	public List<int> yugoEconomyNumbers = new List<int>();

	// Token: 0x04000C50 RID: 3152
	public List<int> bulEconomyNumbers = new List<int>();

	// Token: 0x04000C51 RID: 3153
	public List<int> turkEconomyNumbers = new List<int>();

	// Token: 0x04000C52 RID: 3154
	public int route1StopOffPoint;

	// Token: 0x04000C53 RID: 3155
	public int route2StopOffPoint;

	// Token: 0x04000C54 RID: 3156
	public int route3StopOffPoint;

	// Token: 0x04000C55 RID: 3157
	private int route4StopOffPoint;

	// Token: 0x04000C56 RID: 3158
	public GameObject[] segmentLibrary1 = new GameObject[3];

	// Token: 0x04000C57 RID: 3159
	public GameObject[] stopOffLibrary1 = new GameObject[0];

	// Token: 0x04000C58 RID: 3160
	public GameObject[] segmentLibrary0 = new GameObject[3];

	// Token: 0x04000C59 RID: 3161
	public GameObject[] stopOffLibrary0 = new GameObject[0];

	// Token: 0x04000C5A RID: 3162
	public GameObject[] sceneryIndustrial = new GameObject[0];

	// Token: 0x04000C5B RID: 3163
	public GameObject[] sceneryResidentialGER = new GameObject[0];

	// Token: 0x04000C5C RID: 3164
	public GameObject[] sceneryMountainsBUL = new GameObject[0];

	// Token: 0x04000C5D RID: 3165
	public int routeAmmo;

	// Token: 0x04000C5E RID: 3166
	public int routeChosen;

	// Token: 0x04000C5F RID: 3167
	public int routeChosenLength;

	// Token: 0x04000C60 RID: 3168
	public int[] segment = new int[5];

	// Token: 0x04000C61 RID: 3169
	public int destinationNumber;

	// Token: 0x04000C62 RID: 3170
	public GameObject[] stopOffObjects = new GameObject[0];

	// Token: 0x04000C63 RID: 3171
	public GameObject[] stopOffObjects2 = new GameObject[0];

	// Token: 0x04000C64 RID: 3172
	public GameObject[] stopOffObjects3 = new GameObject[0];

	// Token: 0x04000C65 RID: 3173
	public GameObject[] stopOffObjects4 = new GameObject[0];

	// Token: 0x04000C66 RID: 3174
	public GameObject[] stopOffObjects5 = new GameObject[0];

	// Token: 0x04000C67 RID: 3175
	public GameObject[] stopOffObjects6 = new GameObject[0];

	// Token: 0x04000C68 RID: 3176
	public GameObject[] blockerObjects = new GameObject[0];

	// Token: 0x04000C69 RID: 3177
	public List<GameObject> lightObjects = new List<GameObject>();

	// Token: 0x04000C6A RID: 3178
	public bool forceLightsOff;

	// Token: 0x04000C6B RID: 3179
	public GameObject[] puddlePrefabs = new GameObject[0];

	// Token: 0x04000C6C RID: 3180
	public GameObject[] lrpuddlePrefabs = new GameObject[0];

	// Token: 0x04000C6D RID: 3181
	public GameObject[] hrpuddlePrefabs = new GameObject[0];

	// Token: 0x04000C6E RID: 3182
	public GameObject[] potHolePrefabs = new GameObject[0];

	// Token: 0x04000C6F RID: 3183
	public GameObject[] oilSpillPrefabs = new GameObject[0];

	// Token: 0x04000C70 RID: 3184
	public GameObject[] aiCarPrefabs = new GameObject[0];

	// Token: 0x04000C71 RID: 3185
	public GameObject[] aiDrivers = new GameObject[0];

	// Token: 0x04000C72 RID: 3186
	public Transform aiDestination1;

	// Token: 0x04000C73 RID: 3187
	public Transform aiDestination2;

	// Token: 0x04000C74 RID: 3188
	public GameObject mapObject;

	// Token: 0x04000C75 RID: 3189
	public GameObject mapText1;

	// Token: 0x04000C76 RID: 3190
	public GameObject mapText2;

	// Token: 0x04000C77 RID: 3191
	public GameObject mapText3;

	// Token: 0x04000C78 RID: 3192
	public GameObject mapText4;

	// Token: 0x04000C79 RID: 3193
	public GameObject mapDayText;

	// Token: 0x04000C7A RID: 3194
	public GameObject route1RoundaboutSegment;

	// Token: 0x04000C7B RID: 3195
	public GameObject route2RoundaboutSegment;

	// Token: 0x04000C7C RID: 3196
	public GameObject route3RoundaboutSegment;

	// Token: 0x04000C7D RID: 3197
	public int route1Distance;

	// Token: 0x04000C7E RID: 3198
	public GameObject[] route1Segments = new GameObject[5];

	// Token: 0x04000C7F RID: 3199
	private int[] route1Segment = new int[6];

	// Token: 0x04000C80 RID: 3200
	public int route2Distance;

	// Token: 0x04000C81 RID: 3201
	public GameObject[] route2Segments = new GameObject[5];

	// Token: 0x04000C82 RID: 3202
	private int[] route2Segment = new int[6];

	// Token: 0x04000C83 RID: 3203
	public int route3Distance;

	// Token: 0x04000C84 RID: 3204
	public GameObject[] route3Segments = new GameObject[6];

	// Token: 0x04000C85 RID: 3205
	private int[] route3Segment = new int[6];

	// Token: 0x04000C86 RID: 3206
	public int route4Distance;

	// Token: 0x04000C87 RID: 3207
	public GameObject[] route4Segments = new GameObject[5];

	// Token: 0x04000C88 RID: 3208
	private int[] route4Segment = new int[6];

	// Token: 0x04000C89 RID: 3209
	public int route1Weather;

	// Token: 0x04000C8A RID: 3210
	private int route1WeatherCode;

	// Token: 0x04000C8B RID: 3211
	public int route1StopOff;

	// Token: 0x04000C8C RID: 3212
	public int route1RoadCondition;

	// Token: 0x04000C8D RID: 3213
	private int route1RoadCode;

	// Token: 0x04000C8E RID: 3214
	public int route2Weather;

	// Token: 0x04000C8F RID: 3215
	private int route2WeatherCode;

	// Token: 0x04000C90 RID: 3216
	public int route2StopOff;

	// Token: 0x04000C91 RID: 3217
	public int route2RoadCondition;

	// Token: 0x04000C92 RID: 3218
	private int route2RoadCode;

	// Token: 0x04000C93 RID: 3219
	public int route3Weather;

	// Token: 0x04000C94 RID: 3220
	private int route3WeatherCode;

	// Token: 0x04000C95 RID: 3221
	public int route3StopOff;

	// Token: 0x04000C96 RID: 3222
	public int route3RoadCondition;

	// Token: 0x04000C97 RID: 3223
	private int route3RoadCode;

	// Token: 0x04000C98 RID: 3224
	public int route4Weather;

	// Token: 0x04000C99 RID: 3225
	private int route4WeatherCode;

	// Token: 0x04000C9A RID: 3226
	public int route4StopOff;

	// Token: 0x04000C9B RID: 3227
	public int route4RoadCondition;

	// Token: 0x04000C9C RID: 3228
	private int route4RoadCode;

	// Token: 0x04000C9D RID: 3229
	public int currentWeatherCondition;

	// Token: 0x04000C9E RID: 3230
	public int currentRoadCondition;

	// Token: 0x04000C9F RID: 3231
	public GameObject carLogic;

	// Token: 0x04000CA0 RID: 3232
	public GameObject seatLogic;

	// Token: 0x04000CA1 RID: 3233
	public GameObject uDayCycle;

	// Token: 0x04000CA2 RID: 3234
	public GameObject lightRain;

	// Token: 0x04000CA3 RID: 3235
	public GameObject heavyRain;

	// Token: 0x04000CA4 RID: 3236
	private int sunChance = 60;

	// Token: 0x04000CA5 RID: 3237
	private int fogChance = 65;

	// Token: 0x04000CA6 RID: 3238
	private int lightRainChance = 80;

	// Token: 0x04000CA7 RID: 3239
	private int heavyRainChance = 100;

	// Token: 0x04000CA8 RID: 3240
	private int goodRoadConditionChance;

	// Token: 0x04000CA9 RID: 3241
	private int poorRoadConditionChance;

	// Token: 0x04000CAA RID: 3242
	[HideInInspector]
	public GameObject rainTarget;

	// Token: 0x04000CAB RID: 3243
	public Sprite[] weatherIcons = new Sprite[0];

	// Token: 0x04000CAC RID: 3244
	public Sprite[] roadConditionIcons = new Sprite[0];

	// Token: 0x04000CAD RID: 3245
	public List<GameObject> spawnedRouteSegments = new List<GameObject>();

	// Token: 0x04000CAE RID: 3246
	public List<GameObject> cratesToBeCleanedUp = new List<GameObject>();

	// Token: 0x04000CAF RID: 3247
	public GameObject[] cratePrefabs = new GameObject[0];

	// Token: 0x04000CB0 RID: 3248
	public GameObject[] abandonCarPrefabs = new GameObject[0];

	// Token: 0x04000CB1 RID: 3249
	public int abandonCarSpawnAmmo = 2;

	// Token: 0x04000CB2 RID: 3250
	public int abandonCarSpawnAmmoReference = 2;

	// Token: 0x04000CB3 RID: 3251
	public int abandonCarSpawnChance = 10;

	// Token: 0x04000CB4 RID: 3252
	private GameObject backdrop;

	// Token: 0x04000CB5 RID: 3253
	public int rainType;
}
