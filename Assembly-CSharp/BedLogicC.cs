using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200008D RID: 141
public class BedLogicC : MonoBehaviour
{
	// Token: 0x0600043F RID: 1087 RVA: 0x00046EC8 File Offset: 0x000452C8
	private void Reset()
	{
		BedLogic component = base.GetComponent<BedLogic>();
		this.homeBed = component.homeBed;
		component.renderTargets.Copy(ref this.renderTargets);
		this.glowTarget = (component.glowTarget as GameObject);
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.motelLogic = (component.motelLogic as GameObject);
		this.messyBed = component.messyBed;
		component.path.Copy(ref this.path);
		this.carLoadTransform = component.carLoadTransform;
		this.uncleLoadTransform = component.uncleLoadTransform;
		component.enabled = false;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x00046F70 File Offset: 0x00045370
	private void Start()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 0 && this.homeBed)
		{
			UnityEngine.Object.Destroy(base.gameObject.GetComponent<BoxCollider>());
			base.GetComponent<MeshFilter>().mesh = this.messyBed;
		}
		if (!gameObject.GetComponent<RouteGeneratorC>().drivingTowardsHome && gameObject.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			gameObject.GetComponent<DirectorC>().gerStartBedGo = true;
		}
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x00046FF0 File Offset: 0x000453F0
	private void Update()
	{
		if (this.isGlowing)
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
				gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x00047054 File Offset: 0x00045454
	public void SpawnYugoBlocker()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject.GetComponent<RouteGeneratorC>().roundaboutYUGO1_1);
		gameObject2.transform.parent = base.transform.root;
		gameObject2.transform.localPosition = new Vector3(0f, 0f, 100f);
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x000470B4 File Offset: 0x000454B4
	private IEnumerator Trigger()
	{
		if (this.block)
		{
			yield break;
		}
		MainMenuC.Global.ReticuleToggle(false);
		this.block = true;
		Camera camera = Camera.main;
		GameObject player = camera.transform.parent.gameObject;
		GameObject director = GameObject.FindWithTag("Director");
		GameObject carLogic = GameObject.FindWithTag("CarLogic");
		VfAnimCursor.TurnOffXbox = true;
		MainMenuC.Global.restrictPause = true;
		MainMenuC.Global.DisableLookAndWalk();
		camera.GetComponent<DragRigidbodyC>().StartCoroutine("DropAllItems");
		GameObject _camera = Camera.main.gameObject;
		iTween.MoveTo(_camera, iTween.Hash(new object[]
		{
			"position",
			this.path[1].position,
			"time",
			1.5,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
		iTween.RotateTo(_camera, iTween.Hash(new object[]
		{
			"rotation",
			this.path[1].eulerAngles,
			"delay",
			0.25f,
			"time",
			2f,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
		yield return new WaitForSeconds(2f);
		MainMenuC.Global.CloseEyes(2);
		yield return new WaitForSeconds(6f);
		director.GetComponent<RouteGeneratorC>().StopRain();
		director.GetComponent<RouteGeneratorC>().RemoveLights();
		director.GetComponent<RouteGeneratorC>().DeleteRoute();
		director.GetComponent<RouteGeneratorC>().StoreLights();
		director.GetComponent<RouteGeneratorC>().abandonCarSpawnAmmo = director.GetComponent<RouteGeneratorC>().abandonCarSpawnAmmoReference;
		if (base.transform.root.GetComponent<Hub_CitySpawnC>())
		{
			if (base.transform.root.GetComponent<Hub_CitySpawnC>().countryHUBCode == 4)
			{
				this.SpawnYugoBlocker();
			}
			if (base.transform.root.GetComponent<Hub_CitySpawnC>().countryHUBCode == 6)
			{
				director.GetComponent<DirectorC>().turkBedGo = true;
				if (carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>().puristCheck && carLogic.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>().puristCheck && !carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled && !carLogic.GetComponent<ExtraUpgradesC>().bullBarInstalled && !carLogic.GetComponent<ExtraUpgradesC>().mudGuardsInstalled && !carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled && !carLogic.GetComponent<ExtraUpgradesC>().lightRackInstalled && !carLogic.GetComponent<ExtraUpgradesC>().toolRackInstalled)
				{
					GameObject gameObject = GameObject.FindWithTag("Steam");
					if (gameObject != null)
					{
						gameObject.SendMessage("Purist");
					}
				}
			}
		}
		if (director.GetComponent<RouteGeneratorC>().routeLevel == 1 && director.GetComponent<RouteGeneratorC>().drivingTowardsHome && this.homeBed)
		{
			director.GetComponent<DirectorC>().gerEndBedGo = true;
			director.GetComponent<DirectorC>().CheckForThereAndBackAchievement();
		}
		if (director.GetComponent<DirectorC>().isDemo)
		{
			base.StartCoroutine("DemoOutro");
			yield break;
		}
		base.StartCoroutine(this.UncleReadyForNextDay());
		director.GetComponent<DirectorC>().economyReady = false;
		director.GetComponent<DirectorC>().daysPassed++;
		GameObject dayUI = director.GetComponent<DirectorC>().dayUI1;
		GameObject dayUI2 = director.GetComponent<DirectorC>().dayUI2;
		director.GetComponent<DirectorC>().UpdateDayUIText();
		TweenAlpha.Begin(dayUI, 0f, 0f);
		TweenAlpha.Begin(dayUI2, 0f, 0f);
		NGUITools.SetActive(dayUI, true);
		NGUITools.SetActive(dayUI2, true);
		TweenAlpha.Begin(dayUI, 1.2f, 1f);
		yield return new WaitForSeconds(1.5f);
		TweenAlpha.Begin(dayUI2, 1.2f, 1f);
		GameObject dayNight = director.GetComponent<DirectorC>().dayNightCycle;
		dayNight.GetComponent<DNC_DayNight>().isPaused = true;
		dayNight.GetComponent<DNC_DayNight>().timeInHours = 5f;
		dayNight.GetComponent<DNC_DayNight>()._timeInSeconds = 17000f;
		dayNight.GetComponent<DNC_DayNight>().isPaused = false;
		dayNight.GetComponent<DNC_DayNight>().isMorning = true;
		UnityEngine.Object.Destroy(base.gameObject.GetComponent<BoxCollider>());
		base.GetComponent<MeshFilter>().mesh = this.messyBed;
		GameObject map = director.GetComponent<RouteGeneratorC>().mapText1;
		GameObject map2 = director.GetComponent<RouteGeneratorC>().mapText2;
		GameObject map3 = director.GetComponent<RouteGeneratorC>().mapText3;
		map.GetComponent<MapRelayC>().mapIsLocked = false;
		map.GetComponent<MapRelayC>().highlighted = false;
		map.GetComponent<TextMesh>().color = Color.black;
		map2.GetComponent<MapRelayC>().mapIsLocked = false;
		map2.GetComponent<MapRelayC>().highlighted = false;
		map2.GetComponent<TextMesh>().color = Color.black;
		map3.GetComponent<MapRelayC>().mapIsLocked = false;
		map3.GetComponent<MapRelayC>().highlighted = false;
		map3.GetComponent<TextMesh>().color = Color.black;
		map.GetComponent<MapRelayC>().selectedRoute = false;
		map2.GetComponent<MapRelayC>().selectedRoute = false;
		map3.GetComponent<MapRelayC>().selectedRoute = false;
		map.GetComponent<MapRelayC>().loadRouteGo = false;
		map2.GetComponent<MapRelayC>().loadRouteGo = false;
		map3.GetComponent<MapRelayC>().loadRouteGo = false;
		map.GetComponent<MapRelayC>().cutOffValue = 1f;
		map2.GetComponent<MapRelayC>().cutOffValue = 1f;
		map3.GetComponent<MapRelayC>().cutOffValue = 1f;
		map.GetComponent<MapRelayC>().redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map.GetComponent<MapRelayC>().redCirc.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map2.GetComponent<MapRelayC>().redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map2.GetComponent<MapRelayC>().redCirc.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map3.GetComponent<MapRelayC>().redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map3.GetComponent<MapRelayC>().redCirc.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		if (director.GetComponent<RouteGeneratorC>().routeLevel < 6 && !director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			director.GetComponent<RouteGeneratorC>().routeLevel++;
		}
		else
		{
			director.GetComponent<RouteGeneratorC>().routeLevel--;
		}
		if (director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			director.GetComponent<RouteGeneratorC>().mapObject.GetComponent<MapLogicC>().changeDirectionText.GetComponent<TextMesh>().text = Language.Get("ui_headback_02", "Inspector_UI");
		}
		else
		{
			director.GetComponent<RouteGeneratorC>().mapObject.GetComponent<MapLogicC>().changeDirectionText.GetComponent<TextMesh>().text = Language.Get("ui_headback_01", "Inspector_UI");
		}
		director.GetComponent<RouteGeneratorC>().drivingTowardsHome = false;
		director.GetComponent<RouteGeneratorC>().mapObject.GetComponent<MapLogicC>().ChangeMap2();
		GameObject uncle = GameObject.FindWithTag("Uncle");
		if (this.homeBed)
		{
			director.GetComponent<RouteGeneratorC>().borderOpen = false;
			uncle.GetComponent<UncleLogicC>().gateObj = this.motelLogic.GetComponent<HomeLogicC>().gateObj;
		}
		else if (this.motelLogic != null)
		{
			this.motelLogic.GetComponent<MotelLogicC>().parkingTrigger.GetComponent<MotelParkingTriggerC>().isMorning = true;
		}
		if (uncle.GetComponent<UncleLogicC>().uncleGoneForever)
		{
			Debug.Log("Uncle here 1");
			uncle.transform.parent = null;
			uncle.transform.position = new Vector3(0f, -1000f, -1000f);
			uncle.GetComponent<CharacterController>().enabled = false;
			uncle.GetComponent<UncleLogicC>().restrictTalk = true;
			ES3.Save(uncle.GetComponent<UncleLogicC>().uncleGoneForever, "uncleStoryCompleted");
		}
		else
		{
			uncle.GetComponent<UncleLogicC>().hasSaidLetsCheckIn = false;
		}
		director.GetComponent<RouteGeneratorC>().currentWeatherCondition = 0;
		director.GetComponent<RouteGeneratorC>().RouteDistances();
		Transform car = GameObject.FindWithTag("CarLogic").transform.parent.transform.parent;
		GameObject carLocation = new GameObject("Car Location");
		car.GetComponent<Rigidbody>().isKinematic = true;
		carLocation.transform.position = car.transform.position;
		carLocation.transform.parent = base.transform.root;
		player.transform.parent = base.transform.root;
		base.transform.root.transform.position = Vector3.zero;
		car.transform.position = carLocation.transform.position;
		carLogic.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().ForceStopInterirorRainAudio();
		director.GetComponent<RouteGeneratorC>().rainType = 0;
		director.GetComponent<RouteGeneratorC>().routeChosen = -1;
		director.GetComponent<RouteGeneratorC>().SetWeather();
		if (director.GetComponent<RouteGeneratorC>().startingEnvironment != null)
		{
			UnityEngine.Object.Destroy(director.GetComponent<RouteGeneratorC>().startingEnvironment);
		}
		UnityEngine.Object.Destroy(carLocation);
		player.transform.parent = null;
		director.GetComponent<RouteGeneratorC>().startingEnvironment = base.transform.root.gameObject;
		map.GetComponent<MapRelayC>().SetRouteToMap();
		map2.GetComponent<MapRelayC>().SetRouteToMap();
		map3.GetComponent<MapRelayC>().SetRouteToMap();
		director.GetComponent<RouteGeneratorC>().mapObject.GetComponent<MapLogicC>().NewLevelUpdate();
		director.GetComponent<RouteGeneratorC>().borderOpen = true;
		director.GetComponent<RouteGeneratorC>().routeAmmo = 0;
		yield return new WaitForSeconds(3f);
		TweenAlpha.Begin(dayUI, 0.8f, 0f);
		TweenAlpha.Begin(dayUI2, 0.8f, 0f);
		yield return new WaitForSeconds(1f);
		NGUITools.SetActive(dayUI, false);
		NGUITools.SetActive(dayUI2, false);
		MainMenuC.Global.WakeUpGeneric();
		yield return new WaitForSeconds(0.5f);
		iTween.MoveTo(player, iTween.Hash(new object[]
		{
			"position",
			this.path[2],
			"time",
			1.5,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
		iTween.RotateTo(player, iTween.Hash(new object[]
		{
			"rotation",
			this.path[2].eulerAngles,
			"delay",
			0.25,
			"time",
			2.0,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
		yield return new WaitForSeconds(2f);
		MainMenuC.Global.EnableLookAndWalk();
		carLogic.GetComponent<CarPerformanceC>().UpdateAllWheelGrip();
		if (!this.homeBed)
		{
			this.motelLogic.GetComponent<MotelLogicC>().hasSlept = true;
			this.motelLogic.GetComponent<MotelLogicC>().GateClose();
		}
		else
		{
			this.motelLogic.GetComponent<HomeLogicC>().GateClose();
		}
		MainMenuC.Global.restrictPause = false;
		map.GetComponent<MapRelayC>().SetReturnRouteToMap();
		map2.GetComponent<MapRelayC>().SetReturnRouteToMap();
		map3.GetComponent<MapRelayC>().SetReturnRouteToMap();
		MainMenuC.Global.SaveData(0);
		base.Invoke("Later", 3f);
		Transform car2 = GameObject.FindWithTag("CarLogic").transform.parent.transform.parent;
		car2.GetComponent<Rigidbody>().isKinematic = true;
		car2.transform.position = this.carLoadTransform.position;
		car2.transform.eulerAngles = this.carLoadTransform.eulerAngles;
		car2.GetComponent<Rigidbody>().isKinematic = false;
		MainMenuC.Global.ReticuleToggle(false);
		director.GetComponent<RouteGeneratorC>().StopRain();
		VfAnimCursor.TurnOffXbox = false;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			XboxController.SaveData();
		}
		yield break;
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x000470CF File Offset: 0x000454CF
	private void Later()
	{
		GameObject.FindWithTag("CarLogic").transform.parent.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x000470FC File Offset: 0x000454FC
	public IEnumerator WakeUpFromLoad()
	{
		MainMenuC.Global.WakeUpGeneric();
		iTween.Stop(Camera.main.gameObject);
		Camera camera = Camera.main;
		GameObject player = GameObject.FindWithTag("Player");
		GameObject director = GameObject.FindWithTag("Director");
		camera.transform.parent = player.transform;
		player.transform.position = this.path[1].transform.position;
		camera.transform.position = this.path[1].position;
		camera.transform.rotation = this.path[1].rotation;
		iTween.MoveTo(Camera.main.gameObject, iTween.Hash(new object[]
		{
			"position",
			new Vector3(0f, 0.8000002f, 0f),
			"time",
			4f,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo"
		}));
		iTween.RotateTo(Camera.main.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			Vector3.zero,
			"delay",
			0.25,
			"time",
			2.0,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo"
		}));
		yield return new WaitForSeconds(2f);
		camera.transform.localEulerAngles = Vector3.zero;
		GameObject dayUI = director.GetComponent<DirectorC>().dayUI1;
		GameObject dayUI2 = director.GetComponent<DirectorC>().dayUI2;
		director.GetComponent<DirectorC>().StartingDayUIText();
		MainMenuC.Global.restrictPause = true;
		UnityEngine.Object.Destroy(base.gameObject.GetComponent<BoxCollider>());
		base.GetComponent<MeshFilter>().mesh = this.messyBed;
		GameObject map = director.GetComponent<RouteGeneratorC>().mapText1;
		GameObject map2 = director.GetComponent<RouteGeneratorC>().mapText2;
		GameObject map3 = director.GetComponent<RouteGeneratorC>().mapText3;
		map.GetComponent<MapRelayC>().mapIsLocked = false;
		map.GetComponent<MapRelayC>().highlighted = false;
		map.GetComponent<TextMesh>().color = Color.black;
		map2.GetComponent<MapRelayC>().mapIsLocked = false;
		map2.GetComponent<MapRelayC>().highlighted = false;
		map2.GetComponent<TextMesh>().color = Color.black;
		map3.GetComponent<MapRelayC>().mapIsLocked = false;
		map3.GetComponent<MapRelayC>().highlighted = false;
		map3.GetComponent<TextMesh>().color = Color.black;
		map.GetComponent<MapRelayC>().selectedRoute = false;
		map2.GetComponent<MapRelayC>().selectedRoute = false;
		map3.GetComponent<MapRelayC>().selectedRoute = false;
		map.GetComponent<MapRelayC>().loadRouteGo = false;
		map2.GetComponent<MapRelayC>().loadRouteGo = false;
		map3.GetComponent<MapRelayC>().loadRouteGo = false;
		map.GetComponent<MapRelayC>().cutOffValue = 1f;
		map2.GetComponent<MapRelayC>().cutOffValue = 1f;
		map3.GetComponent<MapRelayC>().cutOffValue = 1f;
		map.GetComponent<MapRelayC>().redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map.GetComponent<MapRelayC>().redCirc.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map2.GetComponent<MapRelayC>().redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map2.GetComponent<MapRelayC>().redCirc.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map3.GetComponent<MapRelayC>().redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		map3.GetComponent<MapRelayC>().redCirc.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		director.GetComponent<RouteGeneratorC>().RouteDistances();
		Transform car = GameObject.FindWithTag("CarLogic").transform.parent.transform.parent;
		car.GetComponent<Rigidbody>().isKinematic = true;
		car.transform.position = this.carLoadTransform.position;
		car.transform.eulerAngles = this.carLoadTransform.eulerAngles;
		car.GetComponent<Rigidbody>().isKinematic = false;
		GameObject uncle = GameObject.FindWithTag("Uncle");
		if (!uncle.GetComponent<UncleLogicC>().debugStopUncleWorking && !uncle.GetComponent<UncleLogicC>().uncleGoneForever)
		{
			uncle.transform.parent = null;
			uncle.GetComponent<CharacterController>().enabled = false;
			uncle.transform.position = this.uncleLoadTransform.position;
			uncle.transform.eulerAngles = this.uncleLoadTransform.eulerAngles;
			uncle.GetComponent<CharacterController>().enabled = true;
		}
		if (director.GetComponent<RouteGeneratorC>().startingEnvironment != null)
		{
			UnityEngine.Object.Destroy(director.GetComponent<RouteGeneratorC>().startingEnvironment);
		}
		player.transform.parent = null;
		director.GetComponent<RouteGeneratorC>().startingEnvironment = base.transform.root.gameObject;
		map.GetComponent<MapRelayC>().SetRouteToMap();
		map2.GetComponent<MapRelayC>().SetRouteToMap();
		map3.GetComponent<MapRelayC>().SetRouteToMap();
		director.GetComponent<RouteGeneratorC>().mapObject.GetComponent<MapLogicC>().NewLevelUpdate();
		director.GetComponent<RouteGeneratorC>().borderOpen = true;
		director.GetComponent<RouteGeneratorC>().routeAmmo = 0;
		yield return new WaitForSeconds(3f);
		TweenAlpha.Begin(dayUI, 0.8f, 0f);
		TweenAlpha.Begin(dayUI2, 0.8f, 0f);
		yield return new WaitForSeconds(1f);
		NGUITools.SetActive(dayUI, false);
		NGUITools.SetActive(dayUI2, false);
		yield return new WaitForSeconds(0.5f);
		MainMenuC.Global.EnableLookAndWalk();
		this.motelLogic.GetComponent<MotelLogicC>().hasSlept = true;
		this.motelLogic.GetComponent<MotelLogicC>().GateClose();
		MainMenuC.Global.restrictPause = false;
		yield break;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x00047118 File Offset: 0x00045518
	public IEnumerator UncleReadyForNextDay()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		if (gameObject.GetComponent<UncleLogicC>().uncleAtHome || gameObject.GetComponent<UncleLogicC>().debugStopUncleWorking)
		{
			yield break;
		}
		if (gameObject.GetComponent<UncleLogicC>().uncleGoneForever)
		{
			gameObject.GetComponent<UncleLogicC>().UncleGoneForeverLogic();
			yield break;
		}
		gameObject.GetComponent<UncleLogicC>().routeDialogueLevel = 0;
		gameObject.GetComponent<Animator>().SetBool("bedTime", false);
		base.StartCoroutine(gameObject.GetComponent<UncleLogicC>().UncleEnterCar());
		gameObject.GetComponent<UncleLogicC>().ReadyToTalkAboutBorder();
		yield break;
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x00047134 File Offset: 0x00045534
	public void DemoOutro()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		gameObject.GetComponent<UncleLogicC>().StartCoroutine("DemoOutro");
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x00047160 File Offset: 0x00045560
	public void RaycastEnter()
	{
		this.isGlowing = true;
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.glowMaterial;
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x000471A4 File Offset: 0x000455A4
	public void RaycastExit()
	{
		this.isGlowing = false;
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x0400063D RID: 1597
	public bool homeBed;

	// Token: 0x0400063E RID: 1598
	public GameObject[] renderTargets = new GameObject[0];

	// Token: 0x0400063F RID: 1599
	private bool isGlowing;

	// Token: 0x04000640 RID: 1600
	public GameObject glowTarget;

	// Token: 0x04000641 RID: 1601
	public Material startMaterial;

	// Token: 0x04000642 RID: 1602
	public Material glowMaterial;

	// Token: 0x04000643 RID: 1603
	public GameObject motelLogic;

	// Token: 0x04000644 RID: 1604
	public Mesh messyBed;

	// Token: 0x04000645 RID: 1605
	public Transform[] path = new Transform[0];

	// Token: 0x04000646 RID: 1606
	public Transform carLoadTransform;

	// Token: 0x04000647 RID: 1607
	public Transform uncleLoadTransform;

	// Token: 0x04000648 RID: 1608
	private bool block;
}
