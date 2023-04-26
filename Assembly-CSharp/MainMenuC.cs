using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000086 RID: 134
public class MainMenuC : MonoBehaviour
{
	// Token: 0x06000360 RID: 864 RVA: 0x0002F700 File Offset: 0x0002DB00
	[ContextMenu("Read Variables")]
	private void ReadVariables()
	{
		mainMenu component = base.GetComponent<mainMenu>();
		this.objectIDCatalogue = new GameObject[component.objectIDCatalogue.Length];
		component.objectIDCatalogue.CopyTo(this.objectIDCatalogue, 0);
		this.decalMatCatalogue = new Material[component.decalMatCatalogue.Length];
		component.decalMatCatalogue.CopyTo(this.decalMatCatalogue, 0);
		this.keyboardInputTarget = new GameObject[component.keyboardInputTarget.Length];
		component.keyboardInputTarget.CopyTo(this.keyboardInputTarget, 0);
		this.keyboardInputUI = new Sprite[component.keyboardInputUI.Length];
		component.keyboardInputUI.CopyTo(this.keyboardInputUI, 0);
		this.keyboardInputAssigned = new int[component.keyboardInputAssigned.Length];
		component.keyboardInputAssigned.CopyTo(this.keyboardInputAssigned, 0);
		this.keyboardInputAssignedPrev = new int[component.keyboardInputAssignedPrev.Length];
		component.keyboardInputAssignedPrev.CopyTo(this.keyboardInputAssignedPrev, 0);
		this.inputStringLibrary = new string[component.inputStringLibrary.Length];
		component.inputStringLibrary.CopyTo(this.inputStringLibrary, 0);
		this.assignedInputStrings = new string[component.assignedInputStrings.Length];
		component.assignedInputStrings.CopyTo(this.assignedInputStrings, 0);
		this.localisationPickup = new GameObject[component.localisationPickup.Length];
		component.localisationPickup.CopyTo(this.localisationPickup, 0);
		component.enabled = false;
	}

	// Token: 0x06000361 RID: 865 RVA: 0x0002F868 File Offset: 0x0002DC68
	private void OnDestroy()
	{
		MainMenuC.Global = null;
		ES3.SaveFiles();
		if (Application.isEditor)
		{
			this.SaveData(0);
		}
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0002F886 File Offset: 0x0002DC86
	private void Awake()
	{
		MainMenuC.Global = this;
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0002F890 File Offset: 0x0002DC90
	private void LocalisationPickup()
	{
		this.localisationPickup[0].GetComponent<UILabel>().text = Language.Get("ui_pickup_13", "Inspector_UI");
		this.localisationPickup[1].GetComponent<UILabel>().text = Language.Get("ui_pickup_12", "Inspector_UI");
		this.localisationPickup[2].GetComponent<UILabel>().text = Language.Get("ui_pickup_11", "Inspector_UI");
		this.pauseUI[7].GetComponent<UILabel>().text = Language.Get("ui_pickup_16", "Inspector_UI");
		this.pauseUI[9].GetComponent<UILabel>().text = Language.Get("ui_pickup_06", "Inspector_UI");
		this.localisationPickup[3].GetComponent<UILabel>().text = Language.Get("ui_pickup_16", "Inspector_UI");
		this.localisationPickup[4].GetComponent<UILabel>().text = Language.Get("ui_pickup_06", "Inspector_UI");
		this.localisationPickup[5].GetComponent<UILabel>().text = Language.Get("ui_pickup_18", "Inspector_UI");
		this.localisationPickup[6].GetComponent<UILabel>().text = Language.Get("ui_pickup_19", "Inspector_UI");
		this.localisationPickup[7].GetComponent<UILabel>().text = Language.Get("ui_pickup_06", "Inspector_UI");
		this.localisationPickup[8].GetComponent<UILabel>().text = Language.Get("ui_pickup_16", "Inspector_UI");
		this.localisationPickup[9].GetComponent<UILabel>().text = Language.Get("ui_pickup_20", "Inspector_UI");
		this.localisationPickup[10].GetComponent<UILabel>().text = Language.Get("ui_pickup_06", "Inspector_UI");
		this.localisationPickup[11].GetComponent<UILabel>().text = Language.Get("ui_pickup_16", "Inspector_UI");
		this.localisationPickup[12].GetComponent<UILabel>().text = Language.Get("input_keys_01", "Inspector_UI");
		this.localisationPickup[13].GetComponent<UILabel>().text = Language.Get("input_keys_02", "Inspector_UI");
		this.localisationPickup[14].GetComponent<UILabel>().text = Language.Get("input_keys_03", "Inspector_UI");
		this.localisationPickup[15].GetComponent<UILabel>().text = Language.Get("input_keys_04", "Inspector_UI");
		this.localisationPickup[16].GetComponent<UILabel>().text = Language.Get("input_keys_05", "Inspector_UI");
		this.localisationPickup[17].GetComponent<UILabel>().text = Language.Get("input_keys_06", "Inspector_UI");
		this.localisationPickup[18].GetComponent<UILabel>().text = Language.Get("input_keys_07", "Inspector_UI");
		this.localisationPickup[19].GetComponent<UILabel>().text = Language.Get("input_keys_08", "Inspector_UI");
		this.localisationPickup[20].GetComponent<UILabel>().text = Language.Get("input_keys_09", "Inspector_UI");
		this.localisationPickup[21].GetComponent<UILabel>().text = Language.Get("input_keys_10", "Inspector_UI");
		this.localisationPickup[22].GetComponent<UILabel>().text = Language.Get("input_keys_11", "Inspector_UI");
		this.localisationPickup[23].GetComponent<UILabel>().text = Language.Get("input_keys_12", "Inspector_UI");
		this.localisationPickup[24].GetComponent<UILabel>().text = Language.Get("input_keys_13", "Inspector_UI");
		this.localisationPickup[25].GetComponent<UILabel>().text = Language.Get("input_keys_14", "Inspector_UI");
		this.localisationPickup[26].GetComponent<UILabel>().text = Language.Get("input_keys_15", "Inspector_UI");
		this.localisationPickup[27].GetComponent<UILabel>().text = Language.Get("input_keys_16", "Inspector_UI");
		this.localisationPickup[28].GetComponent<UILabel>().text = Language.Get("input_keys_17", "Inspector_UI");
		this.localisationPickup[29].GetComponent<UILabel>().text = Language.Get("opt_gen_12", "Inspector_UI");
		this.localisationPickup[30].GetComponent<UILabel>().text = Language.Get("ui_pickup_16", "Inspector_UI");
		this.localisationPickup[31].GetComponent<UILabel>().text = Language.Get("ui_pickup_06", "Inspector_UI");
		this.localisationPickup[32].GetComponent<UILabel>().text = Language.Get("ui_pickup_97", "Inspector_UI");
		this.localisationPickup[33].GetComponent<UILabel>().text = Language.Get("ui_pickup_98", "Inspector_UI");
	}

	// Token: 0x06000364 RID: 868 RVA: 0x0002FD5C File Offset: 0x0002E15C
	private void LateStart()
	{
		this.LoadPlayerDetails();
		this.LoadLevelGeneration();
		this.LoadPauseVariables();
		this.LoadEngineComponents();
		this.LoadExtraUpgrades();
		this.LoadCarPaintJob();
		this.LoadWheelComponents();
		base.StartCoroutine(this.LoadBootInventory());
		this.LocalisationPickup();
		this.pauseUI[0].GetComponent<UILabel>().text = Language.Get("opt_pause_01", "Inspector_UI");
		this.pauseUI[1].GetComponent<UILabel>().text = Language.Get("opt_pause_02", "Inspector_UI");
		this.pauseUI[2].GetComponent<UILabel>().text = Language.Get("opt_pause_07", "Inspector_UI");
		this.pauseUI[3].GetComponent<UILabel>().text = Language.Get("opt_pause_05", "Inspector_UI");
		this.pauseUI[10].GetComponent<UILabel>().text = Language.Get("opt_pause_04", "Inspector_UI");
		this.pauseUI[8].GetComponent<UILabel>().text = Language.Get("opt_pause_03", "Inspector_UI");
		this.pauseUI[16].GetComponent<UILabel>().text = "Exit to Desktop";
		this.pauseUI[1].GetComponent<Collider>().enabled = false;
		this.pauseUI[2].GetComponent<Collider>().enabled = false;
		this.pauseUI[3].GetComponent<Collider>().enabled = false;
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[8].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[10].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		this.pauseUI[16].GetComponent<Collider>().enabled = false;
		NGUITools.SetActive(this.pauseUI[16], false);
		NGUITools.SetActive(this.pauseUI[0], false);
		NGUITools.SetActive(this.pauseUI[1], false);
		NGUITools.SetActive(this.pauseUI[2], false);
		NGUITools.SetActive(this.pauseUI[3], false);
		NGUITools.SetActive(this.pauseUI[4], false);
		NGUITools.SetActive(this.pauseUI[5], false);
		NGUITools.SetActive(this.pauseUI[6], false);
		NGUITools.SetActive(this.pauseUI[7], false);
		NGUITools.SetActive(this.pauseUI[8], false);
		NGUITools.SetActive(this.pauseUI[9], false);
		NGUITools.SetActive(this.pauseUI[10], false);
		NGUITools.SetActive(this.pauseUI[12], false);
		NGUITools.SetActive(this.pauseUI[13], false);
		NGUITools.SetActive(this.pauseUI[14], false);
		if (this.isAsleep)
		{
			base.GetComponent<MouseLook>().enabled = false;
			base.transform.parent.GetComponent<MouseLook>().enabled = false;
			base.transform.parent.GetComponent<RigidbodyControllerC>().enabled = false;
			base.transform.parent = null;
			base.transform.position = this.pathPos[0];
			base.transform.eulerAngles = this.pathRot[0];
			this.topEyeLid.transform.localPosition = new Vector3(this.topEyeLid.transform.localPosition.x, 0.5f, this.topEyeLid.transform.localPosition.z);
			this.bottomEyeLid.transform.localPosition = new Vector3(this.bottomEyeLid.transform.localPosition.x, -0.5f, this.bottomEyeLid.transform.localPosition.z);
		}
		if (this.isAsleep)
		{
			this.wakeUpAtHome = true;
		}
	}

	// Token: 0x06000365 RID: 869 RVA: 0x00030188 File Offset: 0x0002E588
	private void Start()
	{
		DOTween.KillAll(false);
		this.reticuleOff = ES3.LoadBool("reticule");
		if (this.reticuleOff)
		{
			base.GetComponent<DragRigidbodyC>().cursors[2].gameObject.SetActive(false);
			base.GetComponent<DragRigidbodyC>().cursors[3].gameObject.SetActive(true);
		}
		else
		{
			base.GetComponent<DragRigidbodyC>().cursors[3].gameObject.SetActive(false);
			base.GetComponent<DragRigidbodyC>().cursors[2].gameObject.SetActive(true);
		}
		this.hasWokenUp = false;
		TweenAlpha.Begin(this.loadingText, 0f, 0f);
		this.loadingText.SetActive(false);
		Cursor.lockState = CursorLockMode.Confined;
		this.LoadUncleDetails();
		base.Invoke("LateStart", Time.deltaTime * 2f);
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00030267 File Offset: 0x0002E667
	public void PreventWakeUp()
	{
		this.preventWakeUp = true;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x00030270 File Offset: 0x0002E670
	private void LoadWakeUpAtMotel()
	{
		this.WakeUpGeneric();
	}

	// Token: 0x06000368 RID: 872 RVA: 0x00030278 File Offset: 0x0002E678
	private void LoadLevelGeneration()
	{
		if (ES3.Exists("routeLevel"))
		{
			this.director.GetComponent<RouteGeneratorC>().routeLevel = ES3.LoadInt("routeLevel");
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			this.director.GetComponent<RouteGeneratorC>().DresdenStart();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			this.director.GetComponent<RouteGeneratorC>().SturovoStart();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			this.director.GetComponent<RouteGeneratorC>().LetenyeStart();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			this.director.GetComponent<RouteGeneratorC>().DubrovnikStart();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			this.director.GetComponent<RouteGeneratorC>().MalkoTarnovoStart();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			this.director.GetComponent<RouteGeneratorC>().IstanbulStart();
		}
	}

	// Token: 0x06000369 RID: 873 RVA: 0x000303AC File Offset: 0x0002E7AC
	private void LoadWheelComponents()
	{
		if (ES3.Exists("flWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().flTyreID = ES3.LoadInt("flWheelID");
		}
		if (ES3.Exists("flCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().flCompoundID = ES3.LoadFloat("flCompoundID");
		}
		if (ES3.Exists("frWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().frTyreID = ES3.LoadInt("frWheelID");
		}
		if (ES3.Exists("frCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().frCompoundID = ES3.LoadFloat("frCompoundID");
		}
		if (ES3.Exists("rlWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().rlTyreID = ES3.LoadInt("rlWheelID");
		}
		if (ES3.Exists("rlCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().rlCompoundID = ES3.LoadFloat("rlCompoundID");
		}
		if (ES3.Exists("rrWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().rrTyreID = ES3.LoadInt("rrWheelID");
		}
		if (ES3.Exists("rrCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().rrCompoundID = ES3.LoadFloat("rrCompoundID");
		}
		this.carLogic.GetComponent<CarPerformanceC>().LoadTyreComponents();
	}

	// Token: 0x0600036A RID: 874 RVA: 0x00030514 File Offset: 0x0002E914
	private void LoadEngineComponents()
	{
		if (ES3.Exists("gerGoodTracker"))
		{
			this.director.GetComponent<DirectorC>().gerGoodTracker = ES3.LoadFloat("gerGoodTracker");
		}
		if (ES3.Exists("csfrGoodTracker"))
		{
			this.director.GetComponent<DirectorC>().csfrGoodTracker = ES3.LoadFloat("csfrGoodTracker");
		}
		if (ES3.Exists("hunGoodTracker"))
		{
			this.director.GetComponent<DirectorC>().hunGoodTracker = ES3.LoadFloat("hunGoodTracker");
		}
		if (ES3.Exists("yugoGoodTracker"))
		{
			this.director.GetComponent<DirectorC>().yugoGoodTracker = ES3.LoadFloat("yugoGoodTracker");
		}
		if (ES3.Exists("bulGoodTracker"))
		{
			this.director.GetComponent<DirectorC>().bulGoodTracker = ES3.LoadFloat("bulGoodTracker");
		}
		if (ES3.Exists("turkGoodTracker"))
		{
			this.director.GetComponent<DirectorC>().turkGoodTracker = ES3.LoadFloat("turkGoodTracker");
		}
		if (ES3.Exists("doorFitted"))
		{
			this.carLogic.GetComponent<CarLogicC>().doorFitted = ES3.LoadBool("doorFitted");
		}
		if (ES3.Exists("carDoorRepaired"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().carDoorRepaired = ES3.LoadBool("carDoorRepaired");
			this.carLogic.GetComponent<CarPerformanceC>().RepairDoorLoad();
		}
		if (ES3.Exists("carEngineID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().engineLoadID = ES3.LoadInt("carEngineID");
		}
		if (ES3.Exists("ignitionCoilID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().ignitionCoilLoadID = ES3.LoadInt("ignitionCoilID");
		}
		if (ES3.Exists("fuelTankID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().fuelTankLoadID = ES3.LoadInt("fuelTankID");
		}
		if (ES3.Exists("carburettorID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().carburettorLoadID = ES3.LoadInt("carburettorID");
		}
		if (ES3.Exists("airFilterID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().airFilterLoadID = ES3.LoadInt("airFilterID");
		}
		if (ES3.Exists("waterTankID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().waterTankLoadID = ES3.LoadInt("waterTankID");
		}
		if (ES3.Exists("batteryID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().batteryLoadID = ES3.LoadInt("batteryID");
		}
		if (ES3.Exists("odometerTotalDistance"))
		{
			this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().totalDistance = ES3.LoadFloat("odometerTotalDistance");
		}
		base.Invoke("LoadEngineComponentsDelayed", Time.deltaTime * 2f);
	}

	// Token: 0x0600036B RID: 875 RVA: 0x000307EB File Offset: 0x0002EBEB
	private void LoadEngineComponentsDelayed()
	{
		this.carLogic.GetComponent<CarPerformanceC>().LoadEngineComponents();
	}

	// Token: 0x0600036C RID: 876 RVA: 0x00030800 File Offset: 0x0002EC00
	private void LoadExtraUpgrades()
	{
		if (ES3.Exists("roofRackInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled = ES3.LoadBool("roofRackInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().roofRackWeight = ES3.LoadInt("roofRackWeight");
		}
		if (ES3.Exists("bullBarInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().bullBarInstalled = ES3.LoadBool("bullBarInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().bullBarWeight = ES3.LoadInt("bullBarWeight");
		}
		if (ES3.Exists("mudGuardsInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsInstalled = ES3.LoadBool("mudGuardsInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsWeight = ES3.LoadInt("mudGuardsWeight");
		}
		if (ES3.Exists("dashUIInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled = ES3.LoadBool("dashUIInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().dashUIWeight = ES3.LoadInt("dashUIWeight");
		}
		if (ES3.Exists("lightRackInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().lightRackInstalled = ES3.LoadBool("lightRackInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().lightRackWeight = ES3.LoadInt("lightRackWeight");
		}
		if (ES3.Exists("toolRackInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().toolRackInstalled = ES3.LoadBool("toolRackInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().toolRackWeight = ES3.LoadInt("toolRackWeight");
			this.carLogic.GetComponent<ExtraUpgradesC>().toolRackLevel = ES3.LoadInt("toolRackLevel");
		}
		this.carLogic.GetComponent<ExtraUpgradesC>().LoadExtras();
	}

	// Token: 0x0600036D RID: 877 RVA: 0x000309CC File Offset: 0x0002EDCC
	private void LoadCarPaintJob()
	{
		if (ES3.LoadColor("customPaintBonnet") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().bonnetObj.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintBonnet");
		}
		if (ES3.LoadColor("customMetallicPaintBonnet") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().bonnetObj.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintBonnet"));
		}
		if (ES3.LoadColor("customPaintFrame") != Color.white)
		{
			for (int i = 0; i < this.carLogic.GetComponent<PaintCanRelayC>().targets.Length; i++)
			{
				this.carLogic.GetComponent<PaintCanRelayC>().targets[i].GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintFrame");
			}
		}
		if (ES3.LoadColor("customMetallicPaintFrame") != Color.white)
		{
			for (int j = 0; j < this.carLogic.GetComponent<PaintCanRelayC>().targets.Length; j++)
			{
				this.carLogic.GetComponent<PaintCanRelayC>().targets[j].GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintFrame"));
			}
		}
		if (ES3.LoadColor("customPaintIntFloor") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().carInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
			this.carLogic.GetComponent<CarLogicC>().lDoorInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
			this.carLogic.GetComponent<CarLogicC>().rDoorInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
			this.carLogic.GetComponent<CarLogicC>().trunkInterior.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintIntFloor");
		}
		if (ES3.LoadColor("customMetallicPaintIntFloor") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().carInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
			this.carLogic.GetComponent<CarLogicC>().lDoorInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
			this.carLogic.GetComponent<CarLogicC>().rDoorInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
			this.carLogic.GetComponent<CarLogicC>().trunkInterior.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintIntFloor"));
		}
		if (ES3.LoadColor("customPaintLDoor") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().leftDoor.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintLDoor");
		}
		if (ES3.LoadColor("customMetallicPaintLDoor") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().leftDoor.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintLDoor"));
		}
		if (ES3.LoadColor("customPaintRDoor") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().rightDoor.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintRDoor");
		}
		if (ES3.LoadColor("customMetallicPaintRDoor") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().rightDoor.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintRDoor"));
		}
		if (ES3.LoadColor("customPaintLHLight") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().lHLight.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintLHLight");
		}
		if (ES3.LoadColor("customMetallicPaintLHLight") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().lHLight.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintLHLight"));
		}
		if (ES3.LoadColor("customPaintRHLight") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().rHLight.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintRHLight");
		}
		if (ES3.LoadColor("customMetallicPaintRHLight") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().rHLight.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintRHLight"));
		}
		if (ES3.LoadColor("customPaintRoof") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().roof.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintRoof");
		}
		if (ES3.LoadColor("customMetallicPaintRoof") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().roof.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintRoof"));
		}
		if (ES3.LoadColor("customPaintTrunk") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().bootLid.transform.parent.GetComponent<Renderer>().material.color = ES3.LoadColor("customPaintTrunk");
		}
		if (ES3.LoadColor("customPaintTrunk") != Color.white)
		{
			this.carLogic.GetComponent<CarLogicC>().bootLid.transform.parent.GetComponent<Renderer>().material.SetColor("_SpecColor", ES3.LoadColor("customMetallicPaintTrunk"));
		}
		if (ES3.Exists("customDecal"))
		{
			Color decalColour = ES3.LoadColor("customDecalColor");
			int num = ES3.LoadInt("customDecal");
			if (num == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().decalColour = new Color(0f, 0f, 0f, 0f);
			}
			else
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().decalColour = decalColour;
			}
			this.carLogic.GetComponent<ExtraUpgradesC>().installedDecalID = num;
			this.carLogic.GetComponent<ExtraUpgradesC>().NewDecal(this.decalMatCatalogue[num]);
		}
	}

	// Token: 0x0600036E RID: 878 RVA: 0x000310DC File Offset: 0x0002F4DC
	private void LoadUncleDetails()
	{
		if (ES3.LoadBool("stampSave0"))
		{
			this._diaryStamp[0].GetComponent<IconRelayC>().UnlockStamp();
		}
		if (ES3.LoadBool("stampSave1"))
		{
			this._diaryStamp[1].GetComponent<IconRelayC>().UnlockStamp();
		}
		if (ES3.LoadBool("stampSave2"))
		{
			this._diaryStamp[2].GetComponent<IconRelayC>().UnlockStamp();
		}
		if (ES3.LoadBool("stampSave3"))
		{
			this._diaryStamp[3].GetComponent<IconRelayC>().UnlockStamp();
		}
		if (ES3.LoadBool("stampSave4"))
		{
			this._diaryStamp[4].GetComponent<IconRelayC>().UnlockStamp();
		}
		if (ES3.LoadBool("stampSave5"))
		{
			this._diaryStamp[5].GetComponent<IconRelayC>().UnlockStamp();
		}
		if (ES3.Exists("uncleStoryCompleted"))
		{
			this.uncle.GetComponent<UncleLogicC>().uncleGoneForever = ES3.LoadBool("uncleStoryCompleted");
		}
		if (ES3.Exists("uncleTutorialCompleted"))
		{
			this.uncle.GetComponent<Scene1_LogicC>().hasGivenTutorial = ES3.LoadBool("uncleTutorialCompleted");
		}
		this.uncle.GetComponent<UncleLogicC>().StartCoroutine("LoadDetails");
	}

	// Token: 0x0600036F RID: 879 RVA: 0x00031218 File Offset: 0x0002F618
	private void LoadPlayerDetails()
	{
		if (ES3.Exists("footStepsCounter"))
		{
			this.director.GetComponent<DirectorC>().footSteps = ES3.LoadInt("footStepsCounter");
		}
		if (ES3.Exists("fuelUsedStats"))
		{
			this.director.GetComponent<DirectorC>().fuelUsedStats = ES3.LoadFloat("fuelUsedStats");
		}
		if (ES3.Exists("tyrePoppedStats"))
		{
			this.director.GetComponent<DirectorC>().tyrePoppedStats = ES3.LoadInt("tyrePoppedStats");
		}
		if (ES3.Exists("topSpeedStats"))
		{
			this.director.GetComponent<DirectorC>().topSpeedStats = ES3.LoadFloat("topSpeedStats");
		}
		if (ES3.Exists("repairKitsUsedStats"))
		{
			this.director.GetComponent<DirectorC>().repairKitsUsedStats = ES3.LoadInt("repairKitsUsedStats");
		}
		if (ES3.Exists("daysPassed"))
		{
			this.director.GetComponent<DirectorC>().daysPassed = ES3.LoadInt("daysPassed");
		}
		if (ES3.Exists("moneyAmount"))
		{
			this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth = ES3.LoadFloat("moneyAmount");
			this.director.GetComponent<DirectorC>().totalWealth = ES3.LoadFloat("moneyAmount");
		}
		this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().UpdateWealth();
	}

	// Token: 0x06000370 RID: 880 RVA: 0x00031384 File Offset: 0x0002F784
	private void ClearInventoryLoadDetails()
	{
		this.componentConditions.Clear();
		this.waterBottleLevels.Clear();
		this.fuelCanLevels.Clear();
		this.fuelCanMixs.Clear();
		this.oilBottleLevels.Clear();
		this.componentFuels.Clear();
		this.componentFuelMixs.Clear();
		this.componentCharges.Clear();
		this.componentWaters.Clear();
	}

	// Token: 0x06000371 RID: 881 RVA: 0x000313F4 File Offset: 0x0002F7F4
	private void LoadPauseVariables()
	{
		if (ES3.Exists("lookInvert"))
		{
			this.invertMouse = ES3.LoadBool("lookInvert");
		}
		if (ES3.Exists("mirrorEnabled"))
		{
			this.mirrorEnabled = ES3.LoadBool("mirrorEnabled");
			if (this.mirrorEnabled)
			{
				this.carLogic.GetComponent<CarLogicC>().EnableMirrors();
			}
		}
		this.mouseSmooth = false;
		if (ES3.Exists("mouseSensitivity"))
		{
			this.mouseSensitivity = ES3.LoadFloat("mouseSensitivity");
			this.pauseUI[6].GetComponent<UIScrollBar>().value = this.mouseSensitivity;
		}
		if (ES3.Exists("ssaoSetting"))
		{
			bool flag = ES3.LoadBool("ssaoSetting");
			if (flag)
			{
				base.GetComponent<SSAOPro>().enabled = true;
			}
			else
			{
				base.GetComponent<SSAOPro>().enabled = false;
			}
		}
		else
		{
			base.GetComponent<SSAOPro>().enabled = true;
		}
		if (ES3.Exists("aaSetting"))
		{
			bool flag2 = ES3.LoadBool("aaSetting");
		}
		base.Invoke("LoadMouseSettings", Time.deltaTime * 2f);
	}

	// Token: 0x06000372 RID: 882 RVA: 0x00031518 File Offset: 0x0002F918
	private void LoadMouseSettings()
	{
		this.pauseUI[6].GetComponent<UIScrollBar>().value = this.mouseSensitivity;
		if (!this.invertMouse)
		{
			this.pauseUI[4].GetComponent<UILabel>().text = Language.Get("opt_game_01", "Inspector_UI");
			base.gameObject.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
			base.gameObject.GetComponent<MouseLook>().sensitivityY = this.mouseSensitivity * 10f;
			this.player.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
			this.player.GetComponent<MouseLook>().sensitivityY = this.mouseSensitivity * 10f;
		}
		else
		{
			Debug.Log("invert mouse == false (else)");
			this.pauseUI[4].GetComponent<UILabel>().text = Language.Get("opt_game_01_b", "Inspector_UI");
			float num = this.mouseSensitivity * 10f;
			float sensitivityY = num * -1f;
			base.gameObject.GetComponent<MouseLook>().sensitivityY = sensitivityY;
			base.gameObject.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
			this.player.GetComponent<MouseLook>().sensitivityY = sensitivityY;
			this.player.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
		}
		if (!this.reticuleOff)
		{
			this.pauseUI[12].GetComponent<UILabel>().text = Language.Get("opt_game_05", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
		}
		else
		{
			this.pauseUI[12].GetComponent<UILabel>().text = Language.Get("opt_game_05", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
		}
		if (this.mouseSmooth)
		{
			base.gameObject.GetComponent<MouseLook>().smoothingBool = true;
			this.player.GetComponent<MouseLook>().smoothingBool = true;
			this.mouseSmooth = true;
		}
		else
		{
			base.gameObject.GetComponent<MouseLook>().smoothingBool = false;
			this.player.GetComponent<MouseLook>().smoothingBool = false;
			this.mouseSmooth = false;
		}
		if (ES3.Exists("padInput2"))
		{
			this.padInput = ES3.LoadInt("padInput2");
		}
		if (this.padInput == 0)
		{
			base.transform.GetComponent<MouseLook>().padInput = 0;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_07", "Inspector_UI");
		}
		else if (this.padInput == 1)
		{
			this.padInput = 1;
			base.GetComponent<MouseLook>().padInput = 1;
			this.player.GetComponent<MouseLook>().padInput = 1;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_08", "Inspector_UI");
		}
		else if (this.padInput == 2)
		{
			this.padInput = 2;
			base.GetComponent<MouseLook>().padInput = 2;
			this.player.GetComponent<MouseLook>().padInput = 2;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_09", "Inspector_UI");
		}
		else if (this.padInput == 3)
		{
			this.padInput = 3;
			base.GetComponent<MouseLook>().padInput = 3;
			this.player.GetComponent<MouseLook>().padInput = 3;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_10", "Inspector_UI");
		}
	}

	// Token: 0x06000373 RID: 883 RVA: 0x00031908 File Offset: 0x0002FD08
	private void Update()
	{
		if (this.changeInputID != 0)
		{
			this.CheckForKeyboardInputChange();
		}
		if (this.lockCursor && this.isPaused == 0 && Input.anyKey)
		{
			Screen.lockCursor = true;
		}
		if ((double)base.transform.localEulerAngles.y != 0.0 && !base.GetComponent<MouseLook>().noClip)
		{
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, 0f, base.transform.localEulerAngles.z);
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		float num = realtimeSinceStartup - this.optionsPart2PauseTime;
		float num2 = realtimeSinceStartup - this.optionsPart3PauseTime;
		if (this.optionsPart2Bool)
		{
			this.optionsPart2Delay += num;
		}
		if (this.optionsPart3Bool)
		{
			this.optionsPart3Delay += num2;
		}
		if ((double)this.optionsPart2Delay >= 0.6 && this.optionsPart2Bool)
		{
			base.StartCoroutine("OpenOptionsPart2");
			this.optionsPart2Bool = false;
		}
		if ((double)this.optionsPart3Delay >= 0.6 && this.optionsPart3Bool)
		{
			base.StartCoroutine("OpenOptionsPart3");
			this.optionsPart3Bool = false;
		}
		if ((double)this.optionsPart4Delay >= 0.6 && this.optionsPart4Bool)
		{
			base.StartCoroutine("OpenOptionsSetKeyBindings");
			this.optionsPart4Bool = false;
		}
		float num3 = realtimeSinceStartup - this.closeOptionsPart2PauseTime;
		float num4 = realtimeSinceStartup - this.closeOptionsPart3PauseTime;
		float num5 = realtimeSinceStartup - this.closeOptionsPart4PauseTime;
		if (this.closeOptionsPart2Bool)
		{
			this.closeOptionsPart2Delay += num3;
		}
		if (this.closeOptionsPart3Bool)
		{
			this.closeOptionsPart3Delay += num4;
		}
		if ((double)this.closeOptionsPart2Delay >= 0.6 && this.closeOptionsPart2Bool)
		{
			base.StartCoroutine("CloseOptionsPart2");
			this.closeOptionsPart2Bool = false;
		}
		if ((double)this.closeOptionsPart3Delay >= 0.6 && this.closeOptionsPart3Bool)
		{
			base.StartCoroutine("CloseOptionsPart3");
			this.closeOptionsPart3Bool = false;
		}
		if ((double)this.closeOptionsPart4Delay >= 0.6 && this.closeOptionsPart4Bool)
		{
			base.StartCoroutine("CloseOptionsSetKeyBindingsCancel");
			this.closeOptionsPart4Bool = false;
		}
		if (Input.GetButtonDown("Pause") && this.isPaused == 0 && !this.map.GetComponent<MapLogicC>().isBookOpen && !this.restrictPause)
		{
			this.Pause();
		}
		else if (Input.GetButtonDown("Pause") && this.isPaused == 1 && !this.map.GetComponent<MapLogicC>().isBookOpen)
		{
			this.UnPause();
		}
		else if (Input.GetButtonDown("Pause") && this.isPaused == 3 && !this.map.GetComponent<MapLogicC>().isBookOpen)
		{
			base.StartCoroutine("CloseOptionsCancelChanges");
		}
		else if (Input.GetButtonDown("Pause") && this.isPaused == 4 && !this.map.GetComponent<MapLogicC>().isBookOpen)
		{
			base.StartCoroutine("CloseOptionsSetKeyBindingsCancel");
		}
		else if (Input.GetButtonDown("Pause") && this.isPaused == 5 && !this.map.GetComponent<MapLogicC>().isBookOpen)
		{
			base.StartCoroutine("CloseRestartOptions");
		}
		else if (Input.GetButtonDown("Pause") && this.isPaused == 6 && !this.map.GetComponent<MapLogicC>().isBookOpen)
		{
			base.StartCoroutine("CloseReturnHomeOptions");
		}
		else if (Input.GetButtonDown("Pause") && this.isPaused == 7 && !this.map.GetComponent<MapLogicC>().isBookOpen)
		{
			base.StartCoroutine("CloseSaveQuitOptions");
		}
	}

	// Token: 0x06000374 RID: 884 RVA: 0x00031D4C File Offset: 0x0003014C
	public void Pause()
	{
		if (!this.hasWokenUp)
		{
			return;
		}
		XboxPause.Global.PauseStart();
		this.dialogObject.SetActive(false);
		this.dialogObject.transform.parent.GetComponent<UILabel>().color = Color.clear;
		this.isPaused = 1;
		this.carController.GetComponent<CarControleScriptC>().IsPaused = true;
		this.myPosition = Vector3.zero;
		this.myRotation = Quaternion.identity;
		iTween.ValueTo(base.gameObject, iTween.Hash(new object[]
		{
			"from",
			1.0,
			"to",
			0.1f,
			"time",
			0.5,
			"onupdatetarget",
			base.gameObject,
			"onupdate",
			"UpdateTime",
			"oncomplete",
			"SavePause",
			"easetype",
			iTween.EaseType.easeInQuad
		}));
		this.Squint();
		base.GetComponent<DragRigidbodyC>().cursors[3].gameObject.SetActive(false);
		base.GetComponent<DragRigidbodyC>().cursors[2].gameObject.SetActive(true);
		NGUITools.SetActive(this.pauseUI[0], true);
		NGUITools.SetActive(this.pauseUI[1], true);
		NGUITools.SetActive(this.pauseUI[2], true);
		NGUITools.SetActive(this.pauseUI[3], true);
		NGUITools.SetActive(this.pauseUI[8], true);
		NGUITools.SetActive(this.pauseUI[10], true);
		NGUITools.SetActive(this.pauseUI[16], true);
		TweenAlpha.Begin(this.pauseUI[16], 0.8f, 1f);
		TweenAlpha.Begin(this.pauseUI[0], 0.8f, 1f);
		TweenAlpha.Begin(this.pauseUI[1], 0.8f, 1f);
		TweenAlpha.Begin(this.pauseUI[2], 0.8f, 1f);
		TweenAlpha.Begin(this.pauseUI[3], 0.8f, 1f);
		TweenAlpha.Begin(this.pauseUI[8], 0.8f, 1f);
		TweenAlpha.Begin(this.pauseUI[10], 0.8f, 1f);
		this.pauseUI[1].GetComponent<Collider>().enabled = true;
		this.pauseUI[2].GetComponent<Collider>().enabled = true;
		this.pauseUI[3].GetComponent<Collider>().enabled = true;
		this.pauseUI[8].GetComponent<Collider>().enabled = true;
		this.pauseUI[10].GetComponent<Collider>().enabled = true;
		this.pauseUI[16].GetComponent<Collider>().enabled = true;
		if (base.transform.parent != null && base.transform.parent.transform.parent == null)
		{
			base.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
			base.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
		base.gameObject.GetComponent<MouseLook>().enabled = false;
		base.gameObject.GetComponent<DragRigidbodyC>().enabled = false;
		if (base.transform.parent != null)
		{
			base.transform.parent.gameObject.GetComponent<MouseLook>().enabled = false;
			base.transform.parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = false;
		}
		this.lockCursor = false;
		Cursor.lockState = CursorLockMode.None;
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0003210A File Offset: 0x0003050A
	private void SavePause()
	{
		this.myRotation = CarControleScriptC.Global.GetComponent<Rigidbody>().rotation;
		this.myPosition = CarControleScriptC.Global.GetComponent<Rigidbody>().position;
		this.UpdateTime(0f);
	}

	// Token: 0x06000376 RID: 886 RVA: 0x00032144 File Offset: 0x00030544
	private void UpdateTime(float actualTime)
	{
		this.ambientAudio.GetComponent<AudioSource>().pitch = actualTime;
		this.ambientAudioNight.GetComponent<AudioSource>().pitch = actualTime;
		this.engineAudio.GetComponent<AudioSource>().pitch = actualTime;
		this.radioAudio.GetComponent<AudioSource>().pitch = actualTime;
		this.radioStaticAudio.GetComponent<AudioSource>().pitch = actualTime;
		if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
		{
			this.carLogic.GetComponent<CarLogicC>().dirtTrackAudioTarget.GetComponent<AudioSource>().pitch = actualTime;
		}
		Time.timeScale = actualTime;
	}

	// Token: 0x06000377 RID: 887 RVA: 0x000321F4 File Offset: 0x000305F4
	public void UnPause()
	{
		CarControleScriptC.Global.GetComponent<Rigidbody>().freezeRotation = false;
		if (this.isPaused == 1)
		{
			this.isPaused = 2;
			this.dialogObject.SetActive(true);
			this.dialogObject.transform.parent.GetComponent<UILabel>().color = Color.black;
			iTween.ValueTo(base.gameObject, iTween.Hash(new object[]
			{
				"from",
				0.1f,
				"to",
				1f,
				"time",
				0.5f,
				"onupdatetarget",
				base.gameObject,
				"onupdate",
				"UpdateTime",
				"easetype",
				iTween.EaseType.easeOutQuad
			}));
			this.BlinkOpen();
			if (this.myPosition != Vector3.zero)
			{
				CarControleScriptC.Global.transform.rotation = this.myRotation;
				CarControleScriptC.Global.transform.position = this.myPosition;
			}
			this.carController.GetComponent<CarControleScriptC>().IsPaused = false;
			Screen.lockCursor = true;
			TweenAlpha.Begin(this.pauseUI[0], 0.8f, 0f);
			TweenAlpha.Begin(this.pauseUI[1], 0.8f, 0f);
			TweenAlpha.Begin(this.pauseUI[16], 0.8f, 0f);
			TweenAlpha.Begin(this.pauseUI[2], 0.8f, 0f);
			TweenAlpha.Begin(this.pauseUI[3], 0.8f, 0f);
			TweenAlpha.Begin(this.pauseUI[8], 0.8f, 0f);
			TweenAlpha.Begin(this.pauseUI[10], 0.8f, 0f);
			this.pauseUI[1].GetComponent<Collider>().enabled = false;
			this.pauseUI[2].GetComponent<Collider>().enabled = false;
			this.pauseUI[3].GetComponent<Collider>().enabled = false;
			this.pauseUI[8].GetComponent<Collider>().enabled = false;
			this.pauseUI[10].GetComponent<Collider>().enabled = false;
			base.gameObject.GetComponent<MouseLook>().enabled = true;
			base.gameObject.GetComponent<DragRigidbodyC>().enabled = true;
			base.transform.parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = true;
			if (!base.transform.parent.gameObject.GetComponent<RigidbodyControllerC>().isSat)
			{
			}
			base.transform.parent.gameObject.GetComponent<MouseLook>().enabled = true;
			base.GetComponent<DragRigidbodyC>().inputRestrict = false;
			base.StartCoroutine(this.NguiOff());
			Screen.lockCursor = true;
			if (this.reticuleOff)
			{
				base.GetComponent<DragRigidbodyC>().cursors[2].gameObject.SetActive(false);
				base.GetComponent<DragRigidbodyC>().cursors[3].gameObject.SetActive(true);
			}
			else
			{
				base.GetComponent<DragRigidbodyC>().cursors[2].gameObject.SetActive(true);
				base.GetComponent<DragRigidbodyC>().cursors[3].gameObject.SetActive(false);
			}
		}
		XboxPause.Global.PauseStop();
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00032550 File Offset: 0x00030950
	private IEnumerator NguiOff()
	{
		yield return new WaitForSeconds(0.8f);
		this.isPaused = 0;
		NGUITools.SetActive(this.pauseUI[0], false);
		NGUITools.SetActive(this.pauseUI[1], false);
		NGUITools.SetActive(this.pauseUI[2], false);
		NGUITools.SetActive(this.pauseUI[3], false);
		NGUITools.SetActive(this.pauseUI[8], false);
		NGUITools.SetActive(this.pauseUI[10], false);
		NGUITools.SetActive(this.pauseUI[16], false);
		yield break;
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0003256C File Offset: 0x0003096C
	private void Squint()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.65,
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.65,
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x0600037A RID: 890 RVA: 0x0003264B File Offset: 0x00030A4B
	private void FadeTitleIn()
	{
	}

	// Token: 0x0600037B RID: 891 RVA: 0x00032650 File Offset: 0x00030A50
	private void WakeUpPre1()
	{
		Screen.lockCursor = true;
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.525,
			"time",
			2.5,
			"islocal",
			true,
			"easetype",
			"easeinquint",
			"oncomplete",
			"WakeClosePre1",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.525,
			"time",
			2.5,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.pathRot[0],
			"time",
			5,
			"easetype",
			"easeinoutquint",
			"oncomplete",
			"TurnHead2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x0600037C RID: 892 RVA: 0x000327D8 File Offset: 0x00030BD8
	private void TurnHead2()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.pathRot[0],
			"time",
			1.0,
			"easetype",
			"easeinoutquint"
		}));
	}

	// Token: 0x0600037D RID: 893 RVA: 0x00032848 File Offset: 0x00030C48
	private void WakeClosePre1()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.5,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"WakeUp",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.5,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0003293C File Offset: 0x00030D3C
	private void WakeUp()
	{
		Screen.lockCursor = true;
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.6,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeinquint",
			"oncomplete",
			"WakeClose",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.6,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00032A38 File Offset: 0x00030E38
	private void WakeClose()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.5,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"WakeUp2",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.5,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00032B2C File Offset: 0x00030F2C
	private void WakeUp2()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.675,
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.675,
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		Screen.lockCursor = true;
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00032C14 File Offset: 0x00031014
	private void GetUpOutOfBerlinBed()
	{
		if (this.preventWakeUp)
		{
			return;
		}
		if (this.wakeUpAtHome)
		{
			base.gameObject.transform.position = iTweenPath.GetPath("BerlinWakeUpHome")[0];
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"path",
				iTweenPath.GetPath("BerlinWakeUpHome"),
				"time",
				3.0,
				"easetype",
				"easeinoutquint",
				"oncomplete",
				"EnabledLookAndWalk",
				"oncompletetarget",
				base.gameObject
			}));
			this.wakeUpAtHome = false;
		}
		else
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"path",
				iTweenPath.GetPath("BerlinWakeUp"),
				"delay",
				2,
				"time",
				7,
				"easetype",
				"easeinoutquint",
				"oncomplete",
				"EnabledLookAndWalk",
				"oncompletetarget",
				base.gameObject
			}));
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.climbOutOfBedAudio, 1f);
		base.Invoke("Blink", 1f);
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00032D88 File Offset: 0x00031188
	public void WakeUpGeneric()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.6,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeinquint",
			"oncomplete",
			"WakeCloseMotel",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.6,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x06000383 RID: 899 RVA: 0x00032E7C File Offset: 0x0003127C
	private void WakeCloseMotel()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.5,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"WakeUp2Motel",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.5,
			"time",
			1,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00032F70 File Offset: 0x00031370
	private void WakeUp2Motel()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.675,
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeinquint",
			"oncomplete",
			"Blink",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.675,
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x06000385 RID: 901 RVA: 0x00033074 File Offset: 0x00031474
	private IEnumerator EnabledLookAndWalk()
	{
		base.transform.parent = this.player.transform;
		this.player.transform.localEulerAngles = this.pathRot[0];
		yield return new WaitForEndOfFrame();
		base.transform.localPosition = new Vector3(0f, 0.8f, 0f);
		base.transform.localEulerAngles = Vector3.zero;
		this.hasWokenUp = true;
		this.isAsleep = false;
		Cursor.lockState = CursorLockMode.Locked;
		this.ReticuleToggle(false);
		base.GetComponent<MouseLook>().enabled = true;
		this.player.GetComponent<MouseLook>().enabled = true;
		base.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
		base.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		this.MouseLookToolTip();
		this.player.GetComponent<RigidbodyControllerC>().enabled = true;
		yield return new WaitForEndOfFrame();
		base.transform.localPosition = new Vector3(0f, 0.8f, 0f);
		base.transform.localEulerAngles = Vector3.zero;
		yield return new WaitForSeconds(0.1f);
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, 0f, base.transform.localEulerAngles.z);
		this.LoadKeyBindings();
		yield break;
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00033090 File Offset: 0x00031490
	private IEnumerator DelayedEnabledLookAndWalk()
	{
		yield return new WaitForSeconds(3f);
		base.transform.parent = this.player.transform;
		this.player.transform.localEulerAngles = this.pathRot[0];
		yield return new WaitForEndOfFrame();
		base.transform.localPosition = new Vector3(0f, 0.8f, 0f);
		base.transform.localEulerAngles = Vector3.zero;
		this.hasWokenUp = true;
		this.isAsleep = false;
		Screen.lockCursor = true;
		base.GetComponent<MouseLook>().enabled = true;
		this.player.GetComponent<MouseLook>().enabled = true;
		base.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
		base.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		this.MouseLookToolTip();
		this.player.GetComponent<RigidbodyControllerC>().enabled = true;
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		base.transform.localPosition = new Vector3(0f, 0.8f, 0f);
		base.transform.localEulerAngles = Vector3.zero;
		yield return new WaitForSeconds(0.1f);
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, 0f, base.transform.localEulerAngles.z);
		this.LoadKeyBindings();
		yield break;
	}

	// Token: 0x06000387 RID: 903 RVA: 0x000330AC File Offset: 0x000314AC
	public void DisableLookAndWalk()
	{
		base.GetComponent<MouseLook>().enabled = false;
		this.player.GetComponent<MouseLook>().enabled = false;
		this.player.GetComponent<RigidbodyControllerC>().enabled = false;
		base.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
		base.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}

	// Token: 0x06000388 RID: 904 RVA: 0x0003311C File Offset: 0x0003151C
	public void EnableLookAndWalk()
	{
		base.GetComponent<MouseLook>().enabled = true;
		Camera.main.transform.localPosition = new Vector3(0f, Camera.main.transform.localPosition.y, 0f);
		this.player.GetComponent<MouseLook>().enabled = true;
		this.player.GetComponent<RigidbodyControllerC>().enabled = true;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x0003318C File Offset: 0x0003158C
	private void MouseLookToolTip()
	{
	}

	// Token: 0x0600038A RID: 906 RVA: 0x0003318E File Offset: 0x0003158E
	private void MouseLookText()
	{
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00033190 File Offset: 0x00031590
	private void StopLookToolTip()
	{
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00033194 File Offset: 0x00031594
	private void Blink()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.5,
			"time",
			this.blinkTime,
			"islocal",
			true,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"BlinkOpen",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.5,
			"time",
			this.blinkTime,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00033294 File Offset: 0x00031694
	private void BlinkOpen()
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.75,
			"time",
			this.blinkTime,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.75,
			"time",
			this.blinkTime,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00033370 File Offset: 0x00031770
	public void CloseEyes(int delay)
	{
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.5,
			"time",
			3.5,
			"delay",
			delay,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.5,
			"time",
			3.5,
			"delay",
			delay,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00033478 File Offset: 0x00031878
	private void CameraShake()
	{
		iTween.ShakeRotation(base.gameObject, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(10f, 10f, 10f),
			"time",
			5,
			"islocal",
			true
		}));
	}

	// Token: 0x06000390 RID: 912 RVA: 0x000334E1 File Offset: 0x000318E1
	public void ExitGame()
	{
		if (this.isPaused == 7)
		{
			Time.timeScale = 1f;
			this.SaveData(2);
		}
	}

	// Token: 0x06000391 RID: 913 RVA: 0x00033500 File Offset: 0x00031900
	public void ExitGameDesktop()
	{
		if (this.isPaused == 7)
		{
			Time.timeScale = 1f;
			this.SaveData(2);
			Application.Quit();
		}
	}

	// Token: 0x06000392 RID: 914 RVA: 0x00033524 File Offset: 0x00031924
	[ContextMenu("Save Game")]
	private void DebugSave()
	{
		this.SaveData(0);
	}

	// Token: 0x06000393 RID: 915 RVA: 0x00033530 File Offset: 0x00031930
	public void SaveData(int state)
	{
		this.bootInventorySaveList.Clear();
		this.bootInventorySaveLocsSingle.Clear();
		this.bootInventorySaveLists3x2x1.Clear();
		this.bootInventorySaveLocs3x2x1.Clear();
		this.bootInventorySaveLists2x2x1.Clear();
		this.bootInventorySaveLocs2x2x1.Clear();
		this.bootInventorySaveLists2x1x2.Clear();
		this.bootInventorySaveLocs2x1x2.Clear();
		this.bootInventorySaveLists2x2x2.Clear();
		this.bootInventorySaveLocs2x2x2.Clear();
		this.bootInventorySaveLists2x2x3.Clear();
		this.bootInventorySaveLocs2x2x3.Clear();
		this.bootInventorySaveLists3x2x3.Clear();
		this.bootInventorySaveLocs3x2x3.Clear();
		this.bootInventorySaveLists4x2x2.Clear();
		this.bootInventorySaveLocs4x2x2.Clear();
		this.bootInventorySaveLists4x2x3.Clear();
		this.bootInventorySaveLocs4x2x3.Clear();
		this.bootInventorySaveLists4x1x1.Clear();
		this.bootInventorySaveLocs4x1x1.Clear();
		this.bootInventorySaveLists4x2x1.Clear();
		this.bootInventorySaveLocs4x2x1.Clear();
		this.bootInventorySaveLists2x1x3.Clear();
		this.bootInventorySaveLocs2x1x3.Clear();
		this.bootInventorySaveListsTyres.Clear();
		this.bootInventoryTradeGoodsSmallIDSaveList.Clear();
		this.basketInventorySaveList.Clear();
		this.currentBasketsInInventory.Clear();
		this.roofInventorySaveList.Clear();
		this.roofInventorySaveLocsSingle.Clear();
		this.roofInventorySaveLists3x2x1.Clear();
		this.roofInventorySaveLocs3x2x1.Clear();
		this.roofInventorySaveLists2x2x1.Clear();
		this.roofInventorySaveLocs2x2x1.Clear();
		this.roofInventorySaveLists2x1x2.Clear();
		this.roofInventorySaveLocs2x1x2.Clear();
		this.roofInventorySaveLists2x2x2.Clear();
		this.roofInventorySaveLocs2x2x2.Clear();
		this.roofInventorySaveLists2x2x3.Clear();
		this.roofInventorySaveLocs2x2x3.Clear();
		this.roofInventorySaveLists3x2x3.Clear();
		this.roofInventorySaveLocs3x2x3.Clear();
		this.roofInventorySaveLists4x2x2.Clear();
		this.roofInventorySaveLocs4x2x2.Clear();
		this.roofInventorySaveLists4x2x3.Clear();
		this.roofInventorySaveLocs4x2x3.Clear();
		this.roofInventorySaveLists4x1x1.Clear();
		this.roofInventorySaveLocs4x1x1.Clear();
		this.roofInventorySaveLists4x2x1.Clear();
		this.roofInventorySaveLocs4x2x1.Clear();
		this.roofInventorySaveLists2x1x3.Clear();
		this.roofInventorySaveLocs2x1x3.Clear();
		this.roofInventorySaveListsTyres.Clear();
		this.roofInventoryTradeGoodsSmallIDSaveList.Clear();
		if (this.storageInventory[0].transform.childCount > 0)
		{
			this.ClearHome1Inventory();
		}
		if (this.storageInventory[1].transform.childCount > 0)
		{
			this.ClearHome2Inventory();
		}
		if (this.storageInventory[2].transform.childCount > 0)
		{
			this.ClearHome3Inventory();
		}
		if (this.storageInventory[3].transform.childCount > 0)
		{
			this.ClearHome4Inventory();
		}
		if (this.storageInventory[4].transform.childCount > 0)
		{
			this.ClearHome5Inventory();
		}
		if (this.uncle.GetComponent<Scene1_LogicC>().hasGivenTutorial)
		{
			DirectorC component = this.director.GetComponent<DirectorC>();
			ES3.Save(component.gerGoodTracker, "gerGoodTracker");
			ES3.Save(component.csfrGoodTracker, "csfrGoodTracker");
			ES3.Save(component.hunGoodTracker, "hunGoodTracker");
			ES3.Save(component.yugoGoodTracker, "yugoGoodTracker");
			ES3.Save(component.bulGoodTracker, "bulGoodTracker");
			ES3.Save(component.turkGoodTracker, "turkGoodTracker");
			CarPerformanceC component2 = this.carLogic.GetComponent<CarPerformanceC>();
			CarLogicC component3 = this.carLogic.GetComponent<CarLogicC>();
			ES3.Save(component3.doorFitted, "doorFitted");
			ES3.Save(component3.frntDirtObj.GetComponent<Renderer>().material.color.a, "frntDirt");
			ES3.Save(component3.rearDirtObj.GetComponent<Renderer>().material.color.a, "rearDirt");
			ES3.Save(component3.frntlsideDirtObj.GetComponent<Renderer>().material.color.a, "frntlsideDirt");
			ES3.Save(component3.doorlsideDirtObj.GetComponent<Renderer>().material.color.a, "doorlsideDirt");
			ES3.Save(component3.doorlsideDirtObj2.GetComponent<Renderer>().material.color.a, "doorlsideDirt2");
			ES3.Save(component3.rearlsideDirtObj.GetComponent<Renderer>().material.color.a, "rearlsideDirt");
			ES3.Save(component3.frntrsideDirtObj.GetComponent<Renderer>().material.color.a, "frntrsideDirt");
			ES3.Save(component3.doorrsideDirtObj.GetComponent<Renderer>().material.color.a, "doorrsideDirt");
			ES3.Save(component3.doorrsideDirtObj2.GetComponent<Renderer>().material.color.a, "doorrsideDirt2");
			ES3.Save(component3.rearrsideDirtObj.GetComponent<Renderer>().material.color.a, "rearrsideDirt");
			if (component2.frontLeftTyre != null)
			{
				ES3.Save(component3.FlWheelDirt.GetComponent<Renderer>().material.color.a, "flWheelDirt");
			}
			if (component2.frontRightTyre != null)
			{
				ES3.Save(component3.FrWheelDirt.GetComponent<Renderer>().material.color.a, "frWheelDirt");
			}
			if (component2.rearLeftTyre != null)
			{
				ES3.Save(component3.RlWheelDirt.GetComponent<Renderer>().material.color.a, "rlWheelDirt");
			}
			if (component2.rearRightTyre != null)
			{
				ES3.Save(component3.RrWheelDirt.GetComponent<Renderer>().material.color.a, "rrWheelDirt");
			}
			ES3.Save(component3.frontWindowDirtRim.GetComponent<Renderer>().material.color.a, "frontWindowDirtRim");
			ES3.Save(component3.frontWindowDirtWipers.GetComponent<Renderer>().material.color.a, "frontWindowDirtWipers");
			ES3.Save(component3.frontWindowDirtSmudge.GetComponent<Renderer>().material.color.a, "frontWindowDirtSmudge");
			ES3.Save(component3.frontLeftWindowObj.GetComponent<Renderer>().material.color.a, "frontLeftWindowDirt");
			ES3.Save(component3.frontRightWindowObj.GetComponent<Renderer>().material.color.a, "frontRightWindowDirt");
			ES3.Save(component3.rearLeftWindowObj.GetComponent<Renderer>().material.color.a, "rearLeftWindowDirt");
			ES3.Save(component3.rearRightWindowObj.GetComponent<Renderer>().material.color.a, "rearRightWindowDirt");
			ES3.Save(component3.rearWindowObject.GetComponent<Renderer>().material.color.a, "rearWindowDirt");
			ES3.Save(component3.cleanedTimes, "cleanedTimes");
			ES3.Save(component2.engineLoadID, "carEngineID");
			if (component2.InstalledEngine != null)
			{
				ES3.Save(component2.InstalledEngine.GetComponent<EngineComponentC>().Condition, "carEngineCondition");
				ES3.Save(component2.InstalledEngine.GetComponent<EngineComponentC>().puristCheck, "carEnginePurist");
			}
			ES3.Save(component2.ignitionCoilLoadID, "ignitionCoilID");
			if (component2.installedIgnitionCoil != null)
			{
				ES3.Save(component2.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition, "ignitionCoilCondition");
				ES3.Save(component2.installedIgnitionCoil.GetComponent<EngineComponentC>().puristCheck, "ignitionCoilPurist");
			}
			ES3.Save(component2.fuelTankLoadID, "fuelTankID");
			if (component2.installedFuelTank != null)
			{
				ES3.Save(component2.installedFuelTank.GetComponent<EngineComponentC>().Condition, "fuelTankCondition");
				ES3.Save(component2.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount, "fuelTankFuelAmount");
				ES3.Save(component2.installedFuelTank.GetComponent<EngineComponentC>().fuelMix, "fuelTankFuelMix");
				ES3.Save(component2.installedFuelTank.GetComponent<EngineComponentC>().puristCheck, "fuelTankPurist");
			}
			ES3.Save(component2.carburettorLoadID, "carburettorID");
			if (component2.installedCarburettor != null)
			{
				ES3.Save(component2.installedCarburettor.GetComponent<EngineComponentC>().Condition, "carburettorCondition");
				ES3.Save(component2.installedCarburettor.GetComponent<EngineComponentC>().puristCheck, "carburettorPurist");
			}
			ES3.Save(component2.airFilterLoadID, "airFilterID");
			if (component2.installedAirFilter != null)
			{
				ES3.Save(component2.installedAirFilter.GetComponent<EngineComponentC>().Condition, "airFilterCondition");
				ES3.Save(component2.installedAirFilter.GetComponent<EngineComponentC>().puristCheck, "airFilterPurist");
			}
			ES3.Save(component2.waterTankLoadID, "waterTankID");
			if (component2.waterTankObj != null)
			{
				ES3.Save(component2.waterTankObj.GetComponent<EngineComponentC>().Condition, "waterTankCondition");
				ES3.Save(component2.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges, "waterTankWaterCharges");
				ES3.Save(component2.waterTankObj.GetComponent<EngineComponentC>().puristCheck, "waterTankPurist");
			}
			ES3.Save(component2.batteryLoadID, "batteryID");
			if (component2.installedBattery != null)
			{
				ES3.Save(component2.installedBattery.GetComponent<EngineComponentC>().Condition, "batteryCondition");
				ES3.Save(component2.installedBattery.GetComponent<EngineComponentC>().charge, "batteryCharges");
				ES3.Save(component2.installedBattery.GetComponent<EngineComponentC>().puristCheck, "batteryPurist");
			}
			if (component2.frontLeftTyre != null)
			{
				ES3.Save(component2.flTyreID, "flWheelID");
				ES3.Save(component2.flCompoundID, "flCompoundID");
				ES3.Save(component2.frontLeftTyre.GetComponent<EngineComponentC>().Condition, "flWheelCondition");
				ES3.Save(component2.frontLeftTyre.GetComponent<EngineComponentC>().puristCheck, "flTyrePurist");
			}
			else
			{
				ES3.Save(222, "flWheelID");
			}
			if (component2.frontRightTyre != null)
			{
				ES3.Save(component2.frTyreID, "frWheelID");
				ES3.Save(component2.frCompoundID, "frCompoundID");
				ES3.Save(component2.frontRightTyre.GetComponent<EngineComponentC>().Condition, "frWheelCondition");
				ES3.Save(component2.frontRightTyre.GetComponent<EngineComponentC>().puristCheck, "frTyrePurist");
			}
			else
			{
				ES3.Save(222, "frWheelID");
			}
			if (component2.rearLeftTyre != null)
			{
				ES3.Save(component2.rlTyreID, "rlWheelID");
				ES3.Save(component2.rlCompoundID, "rlCompoundID");
				ES3.Save(component2.rearLeftTyre.GetComponent<EngineComponentC>().Condition, "rlWheelCondition");
				ES3.Save(component2.rearLeftTyre.GetComponent<EngineComponentC>().puristCheck, "rlTyrePurist");
			}
			else
			{
				ES3.Save(222, "rlWheelCondition");
			}
			if (component2.rearRightTyre != null)
			{
				ES3.Save(component2.rrTyreID, "rrWheelID");
				ES3.Save(component2.rrCompoundID, "rrCompoundID");
				ES3.Save(component2.rearRightTyre.GetComponent<EngineComponentC>().Condition, "rrWheelCondition");
				ES3.Save(component2.rearRightTyre.GetComponent<EngineComponentC>().puristCheck, "rrTyrePurist");
			}
			else
			{
				ES3.Save(222, "rrWheelCondition");
			}
			if (this.carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled)
			{
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled, "roofRackInstalled");
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().roofRackWeight, "roofRackWeight");
			}
			if (this.carLogic.GetComponent<ExtraUpgradesC>().bullBarInstalled)
			{
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().bullBarInstalled, "bullBarInstalled");
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().bullBarWeight, "bullBarWeight");
			}
			if (this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsInstalled)
			{
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsInstalled, "mudGuardsInstalled");
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsWeight, "mudGuardsWeight");
			}
			if (this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled)
			{
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled, "dashUIInstalled");
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().dashUIWeight, "dashUIWeight");
			}
			if (this.carLogic.GetComponent<ExtraUpgradesC>().lightRackInstalled)
			{
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().lightRackInstalled, "lightRackInstalled");
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().lightRackWeight, "lightRackWeight");
			}
			if (this.carLogic.GetComponent<ExtraUpgradesC>().toolRackInstalled)
			{
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().toolRackInstalled, "toolRackInstalled");
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().toolRackWeight, "toolRackWeight");
				ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().toolRackLevel, "toolRackLevel");
			}
			ES3.Save(this.uncle.GetComponent<Scene1_LogicC>().hasGivenTutorial, "uncleTutorialCompleted");
			ES3.Save(this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth, "moneyAmount");
			ES3.Save(this.director.GetComponent<DirectorC>().daysPassed, "daysPassed");
			ES3.Save(this.director.GetComponent<DirectorC>().footSteps, "footStepsCounter");
			ES3.Save(this.director.GetComponent<DirectorC>().fuelUsedStats, "fuelUsedStats");
			ES3.Save(this.director.GetComponent<DirectorC>().tyrePoppedStats, "tyrePoppedStats");
			ES3.Save(this.director.GetComponent<DirectorC>().topSpeedStats, "topSpeedStats");
			ES3.Save(this.director.GetComponent<DirectorC>().repairKitsUsedStats, "repairKitsUsedStats");
			ES3.Save(component3.bonnetObj.transform.parent.GetComponent<Renderer>().material.color, "customPaintBonnet");
			ES3.Save(component3.bonnetObj.transform.parent.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintBonnet");
			ES3.Save(this.carLogic.GetComponent<Renderer>().material.color, "customPaintFrame");
			ES3.Save(this.carLogic.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintFrame");
			ES3.Save(component3.carInterior.GetComponent<Renderer>().material.color, "customPaintIntFloor");
			ES3.Save(component3.carInterior.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintIntFloor");
			ES3.Save(component3.leftDoor.transform.parent.GetComponent<Renderer>().material.color, "customPaintLDoor");
			ES3.Save(component3.leftDoor.transform.parent.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintLDoor");
			ES3.Save(component3.rightDoor.transform.parent.GetComponent<Renderer>().material.color, "customPaintRDoor");
			ES3.Save(component3.rightDoor.transform.parent.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintRDoor");
			ES3.Save(component3.lHLight.GetComponent<Renderer>().material.color, "customPaintLHLight");
			ES3.Save(component3.lHLight.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintLHLight");
			ES3.Save(component3.rHLight.GetComponent<Renderer>().material.color, "customPaintRHLight");
			ES3.Save(component3.rHLight.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintRHLight");
			ES3.Save(component3.roof.GetComponent<Renderer>().material.color, "customPaintRoof");
			ES3.Save(component3.roof.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintRoof");
			ES3.Save(component3.bootLid.transform.parent.GetComponent<Renderer>().material.color, "customPaintTrunk");
			ES3.Save(component3.bootLid.transform.parent.GetComponent<Renderer>().material.GetColor("_SpecColor"), "customMetallicPaintTrunk");
			ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().installedDecalID, "customDecal");
			ES3.Save(this.carLogic.GetComponent<ExtraUpgradesC>().installedDecalColor, "customDecalColor");
			ES3.Save(this.director.GetComponent<RouteGeneratorC>().economyState, "economyState");
		}
		this.SaveInventory();
		if (state == 1)
		{
			ES3.Save(this.director.GetComponent<RouteGeneratorC>().routeLevel, "routeLevel");
			if (this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>())
			{
				this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>().SaveTownLayout();
				this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>().spawnedMotel.GetComponent<MotelParentC>().motelLogic.GetComponent<MotelLogicC>().SaveRoomLayout();
			}
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (state == 2)
		{
			ES3.Save(this.director.GetComponent<RouteGeneratorC>().routeLevel, "routeLevel");
			if (this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>())
			{
				this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>().SaveTownLayout();
				this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>().spawnedMotel.GetComponent<MotelParentC>().motelLogic.GetComponent<MotelLogicC>().SaveRoomLayout();
			}
			Application.LoadLevel(0);
		}
		else if (state == 3)
		{
			ES3.Save(0, "routeLevel");
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (state == 0)
		{
			if (this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>())
			{
				this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>().SaveTownLayout();
				this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<Hub_CitySpawnC>().spawnedMotel.GetComponent<MotelParentC>().motelLogic.GetComponent<MotelLogicC>().SaveRoomLayout();
				ES3.Save(this.director.GetComponent<RouteGeneratorC>().routeLevel, "routeLevel");
			}
			else if (this.director.GetComponent<RouteGeneratorC>().startingEnvironment.GetComponent<HomeLogicC>())
			{
				ES3.Save(0, "routeLevel");
			}
		}
		MonoBehaviour.print("Saved");
	}

	// Token: 0x06000394 RID: 916 RVA: 0x000348F8 File Offset: 0x00032CF8
	private void ClearStolenGoodsValue()
	{
		this.stolenGoodsValue = 0f;
	}

	// Token: 0x06000395 RID: 917 RVA: 0x00034905 File Offset: 0x00032D05
	private void AddToStolenGoodsValue(float val)
	{
		this.stolenGoodsValue += val;
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00034918 File Offset: 0x00032D18
	private void ClearBootInventory()
	{
		this.ClearInventoryLoadDetails();
		this.bootInventorySaveList.Clear();
		this.bootInventoryTradeGoodsSmallIDSaveList.Clear();
		this.bootInventorySaveLocsSingle.Clear();
		this.bootInventorySaveLists3x2x1.Clear();
		this.bootInventorySaveLocs3x2x1.Clear();
		this.bootInventorySaveLists2x2x1.Clear();
		this.bootInventorySaveLocs2x2x1.Clear();
		this.bootInventorySaveLists2x1x2.Clear();
		this.bootInventorySaveLocs2x1x2.Clear();
		this.bootInventorySaveLists2x2x2.Clear();
		this.bootInventorySaveLocs2x2x2.Clear();
		this.bootInventorySaveLists2x2x3.Clear();
		this.bootInventorySaveLocs2x2x3.Clear();
		this.bootInventorySaveLists3x2x3.Clear();
		this.bootInventorySaveLocs3x2x3.Clear();
		this.currentBasketsInInventory.Clear();
		this.basketInventorySaveList.Clear();
		this.bootInventorySaveLists4x2x2.Clear();
		this.bootInventorySaveLocs4x2x2.Clear();
		this.bootInventorySaveLists4x2x3.Clear();
		this.bootInventorySaveLocs4x2x3.Clear();
		this.bootInventorySaveLists4x1x1.Clear();
		this.bootInventorySaveLocs4x1x1.Clear();
		this.bootInventorySaveLists4x2x1.Clear();
		this.bootInventorySaveLocs4x2x1.Clear();
		this.bootInventorySaveLists2x1x3.Clear();
		this.bootInventorySaveLocs2x1x3.Clear();
		this.bootInventorySaveListsTyres.Clear();
		InventoryLogicC component = this.carLogic.GetComponent<CarLogicC>().bootInventory.GetComponent<InventoryLogicC>();
		this.ClearAllSlots(component);
		if (component.wheelHolder1.transform.childCount > 0)
		{
			UnityEngine.Object.Destroy(component.wheelHolder1.transform.GetChild(0).gameObject);
		}
		if (component.wheelHolder2.transform.childCount > 0)
		{
			UnityEngine.Object.Destroy(component.wheelHolder2.transform.GetChild(0).gameObject);
		}
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00034AE0 File Offset: 0x00032EE0
	private void ClearRoofInventory()
	{
		this.ClearInventoryLoadDetails();
		this.roofInventorySaveList.Clear();
		this.roofInventoryTradeGoodsSmallIDSaveList.Clear();
		this.roofInventorySaveLocsSingle.Clear();
		this.roofInventorySaveLists3x2x1.Clear();
		this.roofInventorySaveLocs3x2x1.Clear();
		this.roofInventorySaveLists2x2x1.Clear();
		this.roofInventorySaveLocs2x2x1.Clear();
		this.roofInventorySaveLists2x1x2.Clear();
		this.roofInventorySaveLocs2x1x2.Clear();
		this.roofInventorySaveLists2x2x2.Clear();
		this.roofInventorySaveLocs2x2x2.Clear();
		this.roofInventorySaveLists2x2x3.Clear();
		this.roofInventorySaveLocs2x2x3.Clear();
		this.roofInventorySaveLists3x2x3.Clear();
		this.roofInventorySaveLocs3x2x3.Clear();
		this.currentBasketsInInventory.Clear();
		this.basketInventorySaveList.Clear();
		this.roofInventorySaveLists4x2x2.Clear();
		this.roofInventorySaveLocs4x2x2.Clear();
		this.roofInventorySaveLists4x2x3.Clear();
		this.roofInventorySaveLocs4x2x3.Clear();
		this.roofInventorySaveLists4x1x1.Clear();
		this.roofInventorySaveLocs4x1x1.Clear();
		this.roofInventorySaveLists4x2x1.Clear();
		this.roofInventorySaveLocs4x2x1.Clear();
		this.roofInventorySaveLists2x1x3.Clear();
		this.roofInventorySaveLocs2x1x3.Clear();
		this.roofInventorySaveListsTyres.Clear();
		InventoryLogicC component = this.carLogic.GetComponent<CarLogicC>().roofInventory.GetComponent<InventoryLogicC>();
		this.ClearAllSlots(component);
		if (component.wheelHolder1.transform.childCount > 0)
		{
			UnityEngine.Object.Destroy(component.wheelHolder1.transform.GetChild(0).gameObject);
		}
		if (component.wheelHolder2.transform.childCount > 0)
		{
			UnityEngine.Object.Destroy(component.wheelHolder2.transform.GetChild(0).gameObject);
		}
	}

	// Token: 0x06000398 RID: 920 RVA: 0x00034CA8 File Offset: 0x000330A8
	private void ClearAllSlots(InventoryLogicC inventory)
	{
		this.ClearSlots(inventory.inventorySlots);
		this.ClearSlots(inventory.slot3x2x1);
		this.ClearSlots(inventory.slot2x2x1);
		this.ClearSlots(inventory.slot2x1x2);
		this.ClearSlots(inventory.slot2x2x2);
		this.ClearSlots(inventory.slot2x2x3);
		this.ClearSlots(inventory.slot3x2x3);
		this.ClearSlots(inventory.slot4x2x2);
		this.ClearSlots(inventory.slot4x2x3);
		this.ClearSlots(inventory.slot4x1x1);
		this.ClearSlots(inventory.slot4x2x1);
		this.ClearSlots(inventory.slot2x1x3);
	}

	// Token: 0x06000399 RID: 921 RVA: 0x00034D48 File Offset: 0x00033148
	private void ClearSlots(Transform[] slots)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].childCount > 0)
			{
				UnityEngine.Object.Destroy(slots[i].transform.GetChild(0).gameObject);
				slots[i].GetComponent<InventoryRelayC>().isOccupied = false;
			}
		}
	}

	// Token: 0x0600039A RID: 922 RVA: 0x00034DA0 File Offset: 0x000331A0
	private void ClearSlots(GameObject[] slots)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].transform.childCount > 0)
			{
				UnityEngine.Object.Destroy(slots[i].transform.GetChild(0).gameObject);
				slots[i].GetComponent<InventoryRelayC>().isOccupied = false;
			}
		}
	}

	// Token: 0x0600039B RID: 923 RVA: 0x00034DFC File Offset: 0x000331FC
	private void SavingStolenGoods()
	{
		double num;
		if ((double)this.stolenGoodsValue == 0.0)
		{
			num = -1.0;
		}
		else if ((double)this.stolenGoodsValue <= 10.0)
		{
			num = 10.0;
		}
		else if ((double)this.stolenGoodsValue <= 25.0)
		{
			num = 40.0;
		}
		else if ((double)this.stolenGoodsValue <= 50.0)
		{
			num = 80.0;
		}
		else
		{
			num = 100.0;
		}
		float num2 = UnityEngine.Random.Range(0f, 100f);
		if ((double)num2 < num)
		{
			ES3.Save(true, "savedStolenGoods");
			this.ClearBootInventory();
			this.ClearRoofInventory();
			InventoryLogicC component = this.carLogic.GetComponent<CarLogicC>().bootInventory.GetComponent<InventoryLogicC>();
			GameObject junkObject = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[171]);
			this.UpdateJunk(junkObject, component.slot4x2x3[0].transform, false);
			GameObject junkObject2 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[171]);
			this.UpdateJunk(junkObject2, component.slot4x2x3[1].transform, false);
			GameObject junkObject3 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[172]);
			this.UpdateJunk(junkObject3, component.wheelHolder1.transform, true);
			component.AvailableSlotCount();
			component.UpdateInventory();
		}
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00034F75 File Offset: 0x00033375
	private void SaveDirtLevels()
	{
	}

	// Token: 0x0600039D RID: 925 RVA: 0x00034F78 File Offset: 0x00033378
	private void ClearHome1Inventory()
	{
		this.home1InventorySaveList.Clear();
		this.home1InventorySaveLocsSingle.Clear();
		this.home1InventorySaveLists3x2x1.Clear();
		this.home1InventorySaveLocs3x2x1.Clear();
		this.home1InventorySaveLists2x2x1.Clear();
		this.home1InventorySaveLocs2x2x1.Clear();
		this.home1InventorySaveLists2x1x2.Clear();
		this.home1InventorySaveLocs2x1x2.Clear();
		this.home1InventorySaveLists2x2x2.Clear();
		this.home1InventorySaveLocs2x2x2.Clear();
		this.home1InventorySaveLists2x2x3.Clear();
		this.home1InventorySaveLocs2x2x3.Clear();
		this.home1InventorySaveLists3x2x3.Clear();
		this.home1InventorySaveLocs3x2x3.Clear();
		this.home1InventorySaveLists4x2x2.Clear();
		this.home1InventorySaveLocs4x2x2.Clear();
		this.home1InventorySaveLists4x2x3.Clear();
		this.home1InventorySaveLocs4x2x3.Clear();
		this.home1InventorySaveLists4x1x1.Clear();
		this.home1InventorySaveLocs4x1x1.Clear();
		this.home1InventorySaveLists4x2x1.Clear();
		this.home1InventorySaveLocs4x2x1.Clear();
		this.home1InventorySaveLists2x1x3.Clear();
		this.home1InventorySaveLocs2x1x3.Clear();
		if (this.home1InventorySaveListsTyres != null)
		{
			this.home1InventorySaveListsTyres.Clear();
		}
		else
		{
			this.home1InventorySaveListsTyres = new List<int>();
		}
		this.home1InventoryTradeGoodsSmallIDSaveList.Clear();
	}

	// Token: 0x0600039E RID: 926 RVA: 0x000350C0 File Offset: 0x000334C0
	private void ClearHome2Inventory()
	{
		this.home2InventorySaveList.Clear();
		this.home2InventorySaveLocsSingle.Clear();
		this.home2InventorySaveLists3x2x1.Clear();
		this.home2InventorySaveLocs3x2x1.Clear();
		this.home2InventorySaveLists2x2x1.Clear();
		this.home2InventorySaveLocs2x2x1.Clear();
		this.home2InventorySaveLists2x1x2.Clear();
		this.home2InventorySaveLocs2x1x2.Clear();
		this.home2InventorySaveLists2x2x2.Clear();
		this.home2InventorySaveLocs2x2x2.Clear();
		this.home2InventorySaveLists2x2x3.Clear();
		this.home2InventorySaveLocs2x2x3.Clear();
		this.home2InventorySaveLists3x2x3.Clear();
		this.home2InventorySaveLocs3x2x3.Clear();
		this.home2InventorySaveLists4x2x2.Clear();
		this.home2InventorySaveLocs4x2x2.Clear();
		this.home2InventorySaveLists4x2x3.Clear();
		this.home2InventorySaveLocs4x2x3.Clear();
		this.home2InventorySaveLists4x1x1.Clear();
		this.home2InventorySaveLocs4x1x1.Clear();
		this.home2InventorySaveLists4x2x1.Clear();
		this.home2InventorySaveLocs4x2x1.Clear();
		this.home2InventorySaveLists2x1x3.Clear();
		this.home2InventorySaveLocs2x1x3.Clear();
		if (this.home2InventorySaveListsTyres != null)
		{
			this.home2InventorySaveListsTyres.Clear();
		}
		else
		{
			this.home2InventorySaveListsTyres = new List<int>();
		}
		this.home2InventoryTradeGoodsSmallIDSaveList.Clear();
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00035208 File Offset: 0x00033608
	private void ClearHome3Inventory()
	{
		this.home3InventorySaveList.Clear();
		this.home3InventorySaveLocsSingle.Clear();
		this.home3InventorySaveLists3x2x1.Clear();
		this.home3InventorySaveLocs3x2x1.Clear();
		this.home3InventorySaveLists2x2x1.Clear();
		this.home3InventorySaveLocs2x2x1.Clear();
		this.home3InventorySaveLists2x1x2.Clear();
		this.home3InventorySaveLocs2x1x2.Clear();
		this.home3InventorySaveLists2x2x2.Clear();
		this.home3InventorySaveLocs2x2x2.Clear();
		this.home3InventorySaveLists2x2x3.Clear();
		this.home3InventorySaveLocs2x2x3.Clear();
		this.home3InventorySaveLists3x2x3.Clear();
		this.home3InventorySaveLocs3x2x3.Clear();
		this.home3InventorySaveLists4x2x2.Clear();
		this.home3InventorySaveLocs4x2x2.Clear();
		this.home3InventorySaveLists4x2x3.Clear();
		this.home3InventorySaveLocs4x2x3.Clear();
		this.home3InventorySaveLists4x1x1.Clear();
		this.home3InventorySaveLocs4x1x1.Clear();
		this.home3InventorySaveLists4x2x1.Clear();
		this.home3InventorySaveLocs4x2x1.Clear();
		this.home3InventorySaveLists2x1x3.Clear();
		this.home3InventorySaveLocs2x1x3.Clear();
		if (this.home3InventorySaveListsTyres != null)
		{
			this.home3InventorySaveListsTyres.Clear();
		}
		else
		{
			this.home3InventorySaveListsTyres = new List<int>();
		}
		this.home3InventoryTradeGoodsSmallIDSaveList.Clear();
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x00035350 File Offset: 0x00033750
	private void ClearHome4Inventory()
	{
		this.home4InventorySaveList.Clear();
		this.home4InventorySaveLocsSingle.Clear();
		this.home4InventorySaveLists3x2x1.Clear();
		this.home4InventorySaveLocs3x2x1.Clear();
		this.home4InventorySaveLists2x2x1.Clear();
		this.home4InventorySaveLocs2x2x1.Clear();
		this.home4InventorySaveLists2x1x2.Clear();
		this.home4InventorySaveLocs2x1x2.Clear();
		this.home4InventorySaveLists2x2x2.Clear();
		this.home4InventorySaveLocs2x2x2.Clear();
		this.home4InventorySaveLists2x2x3.Clear();
		this.home4InventorySaveLocs2x2x3.Clear();
		this.home4InventorySaveLists3x2x3.Clear();
		this.home4InventorySaveLocs3x2x3.Clear();
		this.home4InventorySaveLists4x2x2.Clear();
		this.home4InventorySaveLocs4x2x2.Clear();
		this.home4InventorySaveLists4x2x3.Clear();
		this.home4InventorySaveLocs4x2x3.Clear();
		this.home4InventorySaveLists4x1x1.Clear();
		this.home4InventorySaveLocs4x1x1.Clear();
		this.home4InventorySaveLists4x2x1.Clear();
		this.home4InventorySaveLocs4x2x1.Clear();
		this.home4InventorySaveLists2x1x3.Clear();
		this.home4InventorySaveLocs2x1x3.Clear();
		if (this.home4InventorySaveListsTyres != null)
		{
			this.home4InventorySaveListsTyres.Clear();
		}
		else
		{
			this.home4InventorySaveListsTyres = new List<int>();
		}
		this.home4InventoryTradeGoodsSmallIDSaveList.Clear();
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00035498 File Offset: 0x00033898
	private void ClearHome5Inventory()
	{
		this.home5InventorySaveList.Clear();
		this.home5InventorySaveLocsSingle.Clear();
		this.home5InventorySaveLists3x2x1.Clear();
		this.home5InventorySaveLocs3x2x1.Clear();
		this.home5InventorySaveLists2x2x1.Clear();
		this.home5InventorySaveLocs2x2x1.Clear();
		this.home5InventorySaveLists2x1x2.Clear();
		this.home5InventorySaveLocs2x1x2.Clear();
		this.home5InventorySaveLists2x2x2.Clear();
		this.home5InventorySaveLocs2x2x2.Clear();
		this.home5InventorySaveLists2x2x3.Clear();
		this.home5InventorySaveLocs2x2x3.Clear();
		this.home5InventorySaveLists3x2x3.Clear();
		this.home5InventorySaveLocs3x2x3.Clear();
		this.home5InventorySaveLists4x2x2.Clear();
		this.home5InventorySaveLocs4x2x2.Clear();
		this.home5InventorySaveLists4x2x3.Clear();
		this.home5InventorySaveLocs4x2x3.Clear();
		this.home5InventorySaveLists4x1x1.Clear();
		this.home5InventorySaveLocs4x1x1.Clear();
		this.home5InventorySaveLists4x2x1.Clear();
		this.home5InventorySaveLocs4x2x1.Clear();
		this.home5InventorySaveLists2x1x3.Clear();
		this.home5InventorySaveLocs2x1x3.Clear();
		if (this.home5InventorySaveListsTyres != null)
		{
			this.home5InventorySaveListsTyres.Clear();
		}
		else
		{
			this.home5InventorySaveListsTyres = new List<int>();
		}
		this.home5InventoryTradeGoodsSmallIDSaveList.Clear();
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x000355E0 File Offset: 0x000339E0
	public void OpenOptions()
	{
		this.isPaused = 3;
		this.optionsPart2Delay = 0f;
		this.optionsPart2Bool = true;
		this.optionsPart2PauseTime = Time.realtimeSinceStartup;
		TweenAlpha.Begin(this.pauseUI[1], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[16], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[2], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[3], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[8], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[10], 0.8f, 0f);
		this.pauseUI[1].GetComponent<Collider>().enabled = false;
		this.pauseUI[2].GetComponent<Collider>().enabled = false;
		this.pauseUI[3].GetComponent<Collider>().enabled = false;
		this.pauseUI[8].GetComponent<Collider>().enabled = false;
		this.pauseUI[10].GetComponent<Collider>().enabled = false;
		this.pauseUI[16].GetComponent<Collider>().enabled = false;
		TweenAlpha.Begin(this.pauseUI[1], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[16], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[2], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[3], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[8], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[10], 0.6f, 0f);
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x000357AC File Offset: 0x00033BAC
	private void OpenOptionsPart2()
	{
		NGUITools.SetActive(this.pauseUI[1], false);
		NGUITools.SetActive(this.pauseUI[2], false);
		NGUITools.SetActive(this.pauseUI[3], false);
		NGUITools.SetActive(this.pauseUI[8], false);
		NGUITools.SetActive(this.pauseUI[10], false);
		NGUITools.SetActive(this.pauseUI[4], true);
		NGUITools.SetActive(this.pauseUI[5], true);
		NGUITools.SetActive(this.pauseUI[6], true);
		NGUITools.SetActive(this.pauseUI[7], true);
		NGUITools.SetActive(this.pauseUI[9], true);
		NGUITools.SetActive(this.pauseUI[12], true);
		NGUITools.SetActive(this.pauseUI[13], true);
		NGUITools.SetActive(this.pauseUI[14], true);
		NGUITools.SetActive(this.pauseUI[16], true);
		TweenAlpha.Begin(this.pauseUI[4], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[5], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[6], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[7], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[9], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[12], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[13], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[14], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[4], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[5], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[6], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[7], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[9], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[12], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[13], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[14], 0.6f, 1f);
		this.optionsPart3Delay = 0f;
		this.optionsPart3Bool = true;
		this.optionsPart3PauseTime = Time.realtimeSinceStartup;
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00035A28 File Offset: 0x00033E28
	private void OpenOptionsPart3()
	{
		this.pauseUI[4].GetComponent<Collider>().enabled = true;
		this.pauseUI[6].GetComponent<Collider>().enabled = true;
		this.pauseUI[7].GetComponent<Collider>().enabled = true;
		this.pauseUI[9].GetComponent<Collider>().enabled = true;
		this.pauseUI[12].GetComponent<Collider>().enabled = true;
		this.pauseUI[13].GetComponent<Collider>().enabled = true;
		this.pauseUI[14].GetComponent<Collider>().enabled = true;
		this.optionsPart4Delay = 0f;
		this.optionsPart4Bool = true;
		this.optionsPart4PauseTime = Time.realtimeSinceStartup;
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x00035ADC File Offset: 0x00033EDC
	public void CloseOptions()
	{
		ES3.Save(this.invertMouse, "lookInvert");
		ES3.Save(this.mouseSmooth, "mouseSmooth");
		ES3.Save(this.padInput, "padInput2");
		ES3.Save(this.mirrorEnabled, "mirrorEnabled");
		ES3.Save(this.reticuleOff, "reticule");
		this.mouseSensitivity = this.pauseUI[6].GetComponent<UIScrollBar>().value;
		ES3.Save(this.mouseSensitivity, "mouseSensitivity");
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		this.isPaused = 1;
		this.closeOptionsPart2Delay = 0f;
		this.closeOptionsPart2Bool = true;
		this.closeOptionsPart2PauseTime = Time.realtimeSinceStartup;
		TweenAlpha.Begin(this.pauseUI[4], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[5], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[6], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[7], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[9], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[12], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[13], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[14], 0.6f, 0f);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00035CD4 File Offset: 0x000340D4
	public void CloseOptionsCancelChanges()
	{
		XboxPause.Global.PauseStart();
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		this.pauseUI[16].GetComponent<Collider>().enabled = true;
		this.isPaused = 1;
		this.closeOptionsPart2Delay = 0f;
		this.closeOptionsPart2Bool = true;
		this.closeOptionsPart2PauseTime = Time.realtimeSinceStartup;
		TweenAlpha.Begin(this.pauseUI[4], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[5], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[6], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[7], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[9], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[12], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[13], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[14], 0.6f, 0f);
		if (ES3.Exists("lookInvert"))
		{
			this.invertMouse = ES3.LoadBool("lookInvert");
		}
		else
		{
			this.invertMouse = false;
		}
		if (!this.invertMouse)
		{
			this.pauseUI[4].GetComponent<UILabel>().text = Language.Get("opt_game_01", "Inspector_UI");
		}
		else
		{
			this.pauseUI[4].GetComponent<UILabel>().text = Language.Get("opt_game_01_b", "Inspector_UI");
		}
		if (!this.reticuleOff)
		{
			this.pauseUI[12].GetComponent<UILabel>().text = Language.Get("opt_game_05", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
		}
		else
		{
			this.pauseUI[12].GetComponent<UILabel>().text = Language.Get("opt_game_05", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
		}
		if (ES3.Exists("padInput2"))
		{
			this.padInput = ES3.LoadInt("padInput2");
		}
		if (this.padInput == 0)
		{
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_07", "Inspector_UI");
		}
		else if (this.padInput == 1)
		{
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_08", "Inspector_UI");
		}
		else if (this.padInput == 2)
		{
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_09", "Inspector_UI");
		}
		else if (this.padInput == 3)
		{
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_10", "Inspector_UI");
		}
		if (ES3.Exists("mirrorEnabled"))
		{
			this.mirrorEnabled = ES3.LoadBool("mirrorEnabled");
		}
		else
		{
			this.mirrorEnabled = false;
		}
		this.mouseSmooth = false;
		if (ES3.Exists("mouseSensitivity"))
		{
			this.mouseSensitivity = ES3.LoadFloat("mouseSensitivity");
			this.pauseUI[6].GetComponent<UIScrollBar>().value = ES3.LoadFloat("mouseSensitivity");
		}
		else
		{
			this.pauseUI[6].GetComponent<UIScrollBar>().value = this.mouseSensitivity;
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00036128 File Offset: 0x00034528
	private void CloseOptionsPart2()
	{
		NGUITools.SetActive(this.pauseUI[4], false);
		NGUITools.SetActive(this.pauseUI[5], false);
		NGUITools.SetActive(this.pauseUI[6], false);
		NGUITools.SetActive(this.pauseUI[7], false);
		NGUITools.SetActive(this.pauseUI[9], false);
		NGUITools.SetActive(this.pauseUI[12], false);
		NGUITools.SetActive(this.pauseUI[13], false);
		NGUITools.SetActive(this.pauseUI[14], false);
		NGUITools.SetActive(this.pauseUI[1], true);
		NGUITools.SetActive(this.pauseUI[2], true);
		NGUITools.SetActive(this.pauseUI[3], true);
		NGUITools.SetActive(this.pauseUI[8], true);
		NGUITools.SetActive(this.pauseUI[10], true);
		this.pauseUI[1].GetComponent<Collider>().enabled = true;
		this.pauseUI[2].GetComponent<Collider>().enabled = true;
		this.pauseUI[3].GetComponent<Collider>().enabled = true;
		this.pauseUI[10].GetComponent<Collider>().enabled = true;
		TweenAlpha.Begin(this.pauseUI[1], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[16], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[2], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[3], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[8], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[10], 0f, 0f);
		TweenAlpha.Begin(this.pauseUI[1], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[16], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[2], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[3], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[8], 0.6f, 1f);
		TweenAlpha.Begin(this.pauseUI[10], 0.6f, 1f);
		this.closeOptionsPart3Delay = 0f;
		this.closeOptionsPart3Bool = true;
		this.closeOptionsPart3PauseTime = Time.realtimeSinceStartup;
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00036380 File Offset: 0x00034780
	private void CloseOptionsPart3()
	{
		this.pauseUI[1].GetComponent<Collider>().enabled = true;
		this.pauseUI[2].GetComponent<Collider>().enabled = true;
		this.pauseUI[3].GetComponent<Collider>().enabled = true;
		this.pauseUI[8].GetComponent<Collider>().enabled = true;
		this.pauseUI[10].GetComponent<Collider>().enabled = true;
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x000363F0 File Offset: 0x000347F0
	public void ChangeMouseSensitivity()
	{
		this.mouseSensitivity = Mathf.Lerp(0.05f, 1f, UIProgressBar.current.value);
		if (!this.invertMouse)
		{
			base.gameObject.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
			base.gameObject.GetComponent<MouseLook>().sensitivityY = this.mouseSensitivity * 10f;
			this.player.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
			this.player.GetComponent<MouseLook>().sensitivityY = this.mouseSensitivity * 10f;
		}
		else
		{
			float num = this.mouseSensitivity * 10f;
			float sensitivityY = num * -1f;
			base.gameObject.GetComponent<MouseLook>().sensitivityY = sensitivityY;
			base.gameObject.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
			this.player.GetComponent<MouseLook>().sensitivityY = sensitivityY;
			this.player.GetComponent<MouseLook>().sensitivityX = this.mouseSensitivity * 10f;
		}
	}

	// Token: 0x060003AA RID: 938 RVA: 0x0003650B File Offset: 0x0003490B
	public void EnableReticule()
	{
		base.GetComponent<DragRigidbodyC>().cursors[2].gameObject.SetActive(true);
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00036528 File Offset: 0x00034928
	public void ReticuleToggle(bool overrideTrigger = false)
	{
		if (this.isPaused != 3)
		{
			return;
		}
		if (!this.reticuleOff)
		{
			this.reticuleOff = true;
			if (Application.platform == RuntimePlatform.XboxOne)
			{
				base.GetComponent<DragRigidbodyC>().cursors[2].GetComponent<VfAnimCursor>().xboxCursor.gameObject.SetActive(false);
			}
			this.pauseUI[12].GetComponent<UILabel>().text = Language.Get("opt_game_05", "Inspector_UI") + Language.Get("opt_video_07", "Inspector_UI");
			return;
		}
		if (this.reticuleOff)
		{
			this.reticuleOff = false;
			if (Application.platform == RuntimePlatform.XboxOne)
			{
				base.GetComponent<DragRigidbodyC>().cursors[2].GetComponent<VfAnimCursor>().xboxCursor.gameObject.SetActive(true);
			}
			this.pauseUI[12].GetComponent<UILabel>().text = Language.Get("opt_game_05", "Inspector_UI") + Language.Get("opt_video_06", "Inspector_UI");
			return;
		}
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00036630 File Offset: 0x00034A30
	public void InvertMouse()
	{
		if (this.isPaused != 3)
		{
			return;
		}
		Debug.Log(this.player.GetComponent<MouseLook>().sensitivityY);
		if (this.player.GetComponent<MouseLook>().sensitivityY > 0f)
		{
			this.invertMouse = true;
			float sensitivityY = base.gameObject.GetComponent<MouseLook>().sensitivityY * -1f;
			base.gameObject.GetComponent<MouseLook>().sensitivityY = sensitivityY;
			this.player.GetComponent<MouseLook>().sensitivityY = sensitivityY;
			this.pauseUI[4].GetComponent<UILabel>().text = Language.Get("opt_game_01_b", "Inspector_UI");
			return;
		}
		if (this.player.GetComponent<MouseLook>().sensitivityY < 0f)
		{
			this.invertMouse = false;
			float sensitivityY2 = base.gameObject.GetComponent<MouseLook>().sensitivityY * -1f;
			base.gameObject.GetComponent<MouseLook>().sensitivityY = sensitivityY2;
			this.player.GetComponent<MouseLook>().sensitivityY = sensitivityY2;
			this.pauseUI[4].GetComponent<UILabel>().text = Language.Get("opt_game_01", "Inspector_UI");
			return;
		}
	}

	// Token: 0x060003AD RID: 941 RVA: 0x0003675C File Offset: 0x00034B5C
	public void PadInputToggle()
	{
		if (this.isPaused != 3)
		{
			return;
		}
		if (this.padInput == 0)
		{
			this.padInput = 1;
			base.GetComponent<MouseLook>().padInput = 1;
			base.transform.parent.GetComponent<MouseLook>().padInput = 1;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_08", "Inspector_UI");
			return;
		}
		if (this.padInput == 1)
		{
			this.padInput = 2;
			base.GetComponent<MouseLook>().padInput = 2;
			base.transform.parent.GetComponent<MouseLook>().padInput = 2;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_09", "Inspector_UI");
			return;
		}
		if (this.padInput == 2)
		{
			this.padInput = 3;
			base.GetComponent<MouseLook>().padInput = 3;
			base.transform.parent.GetComponent<MouseLook>().padInput = 3;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_10", "Inspector_UI");
			return;
		}
		if (this.padInput == 3)
		{
			this.padInput = 0;
			base.GetComponent<MouseLook>().padInput = 0;
			base.transform.parent.GetComponent<MouseLook>().padInput = 0;
			this.pauseUI[13].GetComponent<UILabel>().text = Language.Get("opt_game_06", "Inspector_UI") + Language.Get("opt_game_07", "Inspector_UI");
			return;
		}
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00036928 File Offset: 0x00034D28
	public void MirrorEnabledDisabled()
	{
		if (this.isPaused != 3)
		{
			return;
		}
		if (!this.mirrorEnabled)
		{
			this.mirrorEnabled = true;
			this.carLogic.GetComponent<CarLogicC>().EnableMirrors();
		}
		else
		{
			this.mirrorEnabled = false;
			this.carLogic.GetComponent<CarLogicC>().DisableMirrors();
		}
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00036980 File Offset: 0x00034D80
	public void MouseSmooth()
	{
		if (this.isPaused != 3)
		{
			return;
		}
		if (this.mouseSmooth)
		{
			base.gameObject.GetComponent<MouseLook>().smoothingBool = false;
			this.player.GetComponent<MouseLook>().smoothingBool = false;
			this.mouseSmooth = false;
		}
		else
		{
			base.gameObject.GetComponent<MouseLook>().smoothingBool = true;
			this.player.GetComponent<MouseLook>().smoothingBool = true;
			this.mouseSmooth = true;
		}
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x000369FC File Offset: 0x00034DFC
	public void RestartDemo()
	{
		Time.timeScale = 1f;
		iTween.MoveTo(this.topEyeLid, iTween.Hash(new object[]
		{
			"y",
			0.5,
			"time",
			1.5,
			"islocal",
			true,
			"easetype",
			"easeoutbounce",
			"oncomplete",
			"ReloadLevel1",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveTo(this.bottomEyeLid, iTween.Hash(new object[]
		{
			"y",
			-0.5,
			"time",
			1.5,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x00036B0C File Offset: 0x00034F0C
	private IEnumerator ReloadLevel1()
	{
		this.director.GetComponent<DirectorC>().daysPassed++;
		this.loadingText.SetActive(true);
		TweenAlpha.Begin(this.loadingText, 0.5f, 1f);
		yield return new WaitForSeconds(0.55f);
		base.StartCoroutine("SaveAndReturnHome");
		yield break;
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00036B27 File Offset: 0x00034F27
	public void SaveAndReload()
	{
		this.SaveData(1);
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00036B30 File Offset: 0x00034F30
	public void SaveAndReturnHome()
	{
		this.SaveData(3);
		this.director.GetComponent<DirectorC>().ResetThereAndBackAchievementProgress();
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x00036B4C File Offset: 0x00034F4C
	private IEnumerator ReloadLevel()
	{
		yield return new WaitForSeconds(0.2f);
		Application.LoadLevel(Application.loadedLevel);
		this.director.GetComponent<DirectorC>().ResetThereAndBackAchievementProgress();
		yield break;
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x00036B67 File Offset: 0x00034F67
	private void EnableDriver()
	{
		this.carCharacterDriver.SetActive(true);
		this.carCharacterDriver.GetComponent<Animator>().SetBool("driving", true);
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x00036B8B File Offset: 0x00034F8B
	private void DisableDriver()
	{
		this.carCharacterDriver.GetComponent<Animator>().SetBool("driving", false);
		this.carCharacterDriver.SetActive(false);
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x00036BAF File Offset: 0x00034FAF
	private void ParentDebugToCar()
	{
		base.transform.parent = this.carController.transform;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00036BC7 File Offset: 0x00034FC7
	private void UnParentDebugToCar()
	{
		base.transform.parent = null;
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x00036BD8 File Offset: 0x00034FD8
	private void DebugAdd100Cash()
	{
		this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth += 100f;
		this.director.GetComponent<DirectorC>().totalWealth += 100f;
		this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().UpdateWealth();
		base.GetComponent<AudioSource>().PlayOneShot(this.debugAudioCash, 1f);
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00036C58 File Offset: 0x00035058
	private void HideUncleSpeech()
	{
		this.debugBubbleTail.GetComponent<LineRenderer>().enabled = false;
		this.debugBubble.GetComponent<UILabel>().enabled = false;
		this.debugBubbleTexture.GetComponent<UITexture>().enabled = false;
		this.debugUncle.SetActive(false);
	}

	// Token: 0x060003BB RID: 955 RVA: 0x00036CA4 File Offset: 0x000350A4
	public void ShowUncleSpeech()
	{
		this.debugBubbleTail.GetComponent<LineRenderer>().enabled = true;
		this.debugBubble.GetComponent<UILabel>().enabled = true;
		this.debugBubbleTexture.GetComponent<UITexture>().enabled = true;
		this.debugUncle.SetActive(true);
	}

	// Token: 0x060003BC RID: 956 RVA: 0x00036CF0 File Offset: 0x000350F0
	public void OpenOptionsSetKeyBindingsTrigger()
	{
		this.isPaused = 4;
		this.optionsPart3Delay = 0f;
		this.optionsPart3Bool = true;
		this.optionsPart3PauseTime = Time.realtimeSinceStartup;
		TweenAlpha.Begin(this.controllerOptions, 0.8f, 0f);
		TweenAlpha.Begin(this.controllerOptions, 0.6f, 0f);
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		this.closeOptionsPart2Delay = 0f;
		this.closeOptionsPart2Bool = true;
		this.closeOptionsPart2PauseTime = Time.realtimeSinceStartup;
		TweenAlpha.Begin(this.pauseUI[4], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[5], 0.6f, 0f);
		TweenAlpha.Begin(this.pauseUI[6], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[7], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[9], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[12], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[13], 0.8f, 0f);
		TweenAlpha.Begin(this.pauseUI[14], 0.6f, 0f);
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00036EB8 File Offset: 0x000352B8
	public void OpenOptionsSetKeyBindings()
	{
		this.isPaused = 4;
		for (int i = 0; i < this.keyboardInputAssigned.Length; i++)
		{
			this.keyboardInputAssignedPrev[i] = this.keyboardInputAssigned[i];
		}
		NGUITools.SetActive(this.controllerOptions, true);
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		NGUITools.SetActive(this.pauseUI[4], false);
		NGUITools.SetActive(this.pauseUI[5], false);
		NGUITools.SetActive(this.pauseUI[6], false);
		NGUITools.SetActive(this.pauseUI[7], false);
		NGUITools.SetActive(this.pauseUI[9], false);
		NGUITools.SetActive(this.pauseUI[12], false);
		NGUITools.SetActive(this.pauseUI[13], false);
		NGUITools.SetActive(this.pauseUI[14], false);
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00036FFE File Offset: 0x000353FE
	public void CloseOptionsSetKeyBindingsCancel()
	{
		this.isPaused = 3;
		NGUITools.SetActive(this.controllerOptions, false);
		this.ResetKeyBindingsToPrevSetting();
		this.OpenOptionsPart2();
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0003701F File Offset: 0x0003541F
	public void CloseOptionsSetKeyBindingsAccept()
	{
		this.isPaused = 3;
		NGUITools.SetActive(this.controllerOptions, false);
		this.SaveKeyBindings();
		this.OpenOptionsPart2();
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00037040 File Offset: 0x00035440
	public void OpenRestart()
	{
		this.isPaused = 5;
		NGUITools.SetActive(this.restartOptions, true);
		this.pauseUI[1].GetComponent<Collider>().enabled = false;
		this.pauseUI[2].GetComponent<Collider>().enabled = false;
		this.pauseUI[3].GetComponent<Collider>().enabled = false;
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[8].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[10].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		NGUITools.SetActive(this.pauseUI[0], false);
		NGUITools.SetActive(this.pauseUI[1], false);
		NGUITools.SetActive(this.pauseUI[2], false);
		NGUITools.SetActive(this.pauseUI[3], false);
		NGUITools.SetActive(this.pauseUI[4], false);
		NGUITools.SetActive(this.pauseUI[5], false);
		NGUITools.SetActive(this.pauseUI[6], false);
		NGUITools.SetActive(this.pauseUI[7], false);
		NGUITools.SetActive(this.pauseUI[8], false);
		NGUITools.SetActive(this.pauseUI[9], false);
		NGUITools.SetActive(this.pauseUI[10], false);
		NGUITools.SetActive(this.pauseUI[12], false);
		NGUITools.SetActive(this.pauseUI[13], false);
		NGUITools.SetActive(this.pauseUI[14], false);
		NGUITools.SetActive(this.pauseUI[16], false);
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00037224 File Offset: 0x00035624
	public void CloseRestartOptions()
	{
		NGUITools.SetActive(this.restartOptions, false);
		this.isPaused = 1;
		this.pauseUI[1].GetComponent<Collider>().enabled = true;
		this.pauseUI[2].GetComponent<Collider>().enabled = true;
		this.pauseUI[3].GetComponent<Collider>().enabled = true;
		NGUITools.SetActive(this.pauseUI[0], true);
		NGUITools.SetActive(this.pauseUI[1], true);
		NGUITools.SetActive(this.pauseUI[2], true);
		NGUITools.SetActive(this.pauseUI[3], true);
		this.pauseUI[8].GetComponent<Collider>().enabled = true;
		this.pauseUI[10].GetComponent<Collider>().enabled = true;
		NGUITools.SetActive(this.pauseUI[8], true);
		NGUITools.SetActive(this.pauseUI[10], true);
		NGUITools.SetActive(this.pauseUI[16], true);
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00037308 File Offset: 0x00035708
	public void OpenReturnHome()
	{
		this.isPaused = 6;
		NGUITools.SetActive(this.returnHomeOptions, true);
		this.pauseUI[1].GetComponent<Collider>().enabled = false;
		this.pauseUI[2].GetComponent<Collider>().enabled = false;
		this.pauseUI[3].GetComponent<Collider>().enabled = false;
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[8].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[10].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		NGUITools.SetActive(this.pauseUI[0], false);
		NGUITools.SetActive(this.pauseUI[1], false);
		NGUITools.SetActive(this.pauseUI[2], false);
		NGUITools.SetActive(this.pauseUI[3], false);
		NGUITools.SetActive(this.pauseUI[4], false);
		NGUITools.SetActive(this.pauseUI[5], false);
		NGUITools.SetActive(this.pauseUI[6], false);
		NGUITools.SetActive(this.pauseUI[7], false);
		NGUITools.SetActive(this.pauseUI[8], false);
		NGUITools.SetActive(this.pauseUI[9], false);
		NGUITools.SetActive(this.pauseUI[10], false);
		NGUITools.SetActive(this.pauseUI[12], false);
		NGUITools.SetActive(this.pauseUI[13], false);
		NGUITools.SetActive(this.pauseUI[14], false);
		NGUITools.SetActive(this.pauseUI[16], false);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x000374EC File Offset: 0x000358EC
	public void CloseReturnHomeOptions()
	{
		NGUITools.SetActive(this.returnHomeOptions, false);
		this.pauseUI[1].GetComponent<Collider>().enabled = true;
		this.pauseUI[2].GetComponent<Collider>().enabled = true;
		this.pauseUI[3].GetComponent<Collider>().enabled = true;
		NGUITools.SetActive(this.pauseUI[0], true);
		NGUITools.SetActive(this.pauseUI[1], true);
		NGUITools.SetActive(this.pauseUI[2], true);
		NGUITools.SetActive(this.pauseUI[3], true);
		this.pauseUI[8].GetComponent<Collider>().enabled = true;
		this.pauseUI[10].GetComponent<Collider>().enabled = true;
		NGUITools.SetActive(this.pauseUI[8], true);
		NGUITools.SetActive(this.pauseUI[10], true);
		NGUITools.SetActive(this.pauseUI[16], true);
		this.isPaused = 1;
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x000375D0 File Offset: 0x000359D0
	public void OpenSaveQuit()
	{
		this.isPaused = 7;
		for (int i = 0; i < this.keyboardInputAssigned.Length; i++)
		{
			this.keyboardInputAssignedPrev[i] = this.keyboardInputAssigned[i];
		}
		NGUITools.SetActive(this.saveQuitOptions, true);
		this.pauseUI[1].GetComponent<Collider>().enabled = false;
		this.pauseUI[2].GetComponent<Collider>().enabled = false;
		this.pauseUI[3].GetComponent<Collider>().enabled = false;
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[8].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[10].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		NGUITools.SetActive(this.pauseUI[0], false);
		NGUITools.SetActive(this.pauseUI[1], false);
		NGUITools.SetActive(this.pauseUI[2], false);
		NGUITools.SetActive(this.pauseUI[3], false);
		NGUITools.SetActive(this.pauseUI[4], false);
		NGUITools.SetActive(this.pauseUI[5], false);
		NGUITools.SetActive(this.pauseUI[6], false);
		NGUITools.SetActive(this.pauseUI[7], false);
		NGUITools.SetActive(this.pauseUI[8], false);
		NGUITools.SetActive(this.pauseUI[9], false);
		NGUITools.SetActive(this.pauseUI[10], false);
		NGUITools.SetActive(this.pauseUI[12], false);
		NGUITools.SetActive(this.pauseUI[13], false);
		NGUITools.SetActive(this.pauseUI[14], false);
		NGUITools.SetActive(this.pauseUI[16], false);
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x000377DC File Offset: 0x00035BDC
	public void OpenSaveQuitDesktop()
	{
		this.isPaused = 7;
		for (int i = 0; i < this.keyboardInputAssigned.Length; i++)
		{
			this.keyboardInputAssignedPrev[i] = this.keyboardInputAssigned[i];
		}
		NGUITools.SetActive(this.quitDesktop, true);
		this.pauseUI[16].GetComponent<Collider>().enabled = false;
		NGUITools.SetActive(this.pauseUI[16], false);
		this.pauseUI[1].GetComponent<Collider>().enabled = false;
		this.pauseUI[2].GetComponent<Collider>().enabled = false;
		this.pauseUI[3].GetComponent<Collider>().enabled = false;
		this.pauseUI[4].GetComponent<Collider>().enabled = false;
		this.pauseUI[6].GetComponent<Collider>().enabled = false;
		this.pauseUI[7].GetComponent<Collider>().enabled = false;
		this.pauseUI[8].GetComponent<Collider>().enabled = false;
		this.pauseUI[9].GetComponent<Collider>().enabled = false;
		this.pauseUI[10].GetComponent<Collider>().enabled = false;
		this.pauseUI[12].GetComponent<Collider>().enabled = false;
		this.pauseUI[13].GetComponent<Collider>().enabled = false;
		this.pauseUI[14].GetComponent<Collider>().enabled = false;
		NGUITools.SetActive(this.pauseUI[0], false);
		NGUITools.SetActive(this.pauseUI[1], false);
		NGUITools.SetActive(this.pauseUI[2], false);
		NGUITools.SetActive(this.pauseUI[3], false);
		NGUITools.SetActive(this.pauseUI[4], false);
		NGUITools.SetActive(this.pauseUI[5], false);
		NGUITools.SetActive(this.pauseUI[6], false);
		NGUITools.SetActive(this.pauseUI[7], false);
		NGUITools.SetActive(this.pauseUI[8], false);
		NGUITools.SetActive(this.pauseUI[9], false);
		NGUITools.SetActive(this.pauseUI[10], false);
		NGUITools.SetActive(this.pauseUI[12], false);
		NGUITools.SetActive(this.pauseUI[13], false);
		NGUITools.SetActive(this.pauseUI[14], false);
		NGUITools.SetActive(this.pauseUI[16], false);
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x00037A0C File Offset: 0x00035E0C
	public void CloseSaveQuitOptions()
	{
		NGUITools.SetActive(this.saveQuitOptions, false);
		NGUITools.SetActive(this.quitDesktop, false);
		this.isPaused = 1;
		this.pauseUI[1].GetComponent<Collider>().enabled = true;
		this.pauseUI[2].GetComponent<Collider>().enabled = true;
		this.pauseUI[3].GetComponent<Collider>().enabled = true;
		this.pauseUI[8].GetComponent<Collider>().enabled = true;
		this.pauseUI[10].GetComponent<Collider>().enabled = true;
		NGUITools.SetActive(this.pauseUI[8], true);
		NGUITools.SetActive(this.pauseUI[10], true);
		NGUITools.SetActive(this.pauseUI[0], true);
		NGUITools.SetActive(this.pauseUI[1], true);
		NGUITools.SetActive(this.pauseUI[2], true);
		NGUITools.SetActive(this.pauseUI[3], true);
		NGUITools.SetActive(this.pauseUI[16], true);
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x00037AFC File Offset: 0x00035EFC
	public void SaveKeyBindings()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < this.assignedInputStrings.Length; i++)
		{
			list.Add(this.assignedInputStrings[i]);
		}
		ES3.Save(list, "assignedInputStrings");
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x00037B44 File Offset: 0x00035F44
	private void LoadKeyBindings()
	{
		if (ES3.Exists("assignedInputStrings"))
		{
			List<string> list = new List<string>();
			list = ES3.LoadListString("assignedInputStrings");
			for (int i = 0; i < list.Count; i++)
			{
				this.assignedInputStrings[i] = list[i];
				this.UpdateKeyboardInputChange(this.assignedInputStrings[i], i);
			}
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x00037BA8 File Offset: 0x00035FA8
	public void ResetKeyInputToDefault()
	{
		this.UpdateKeyboardInputChange("w", 0);
		this.UpdateKeyboardInputChange("w", 1);
		this.UpdateKeyboardInputChange("s", 2);
		this.UpdateKeyboardInputChange("s", 3);
		this.UpdateKeyboardInputChange("a", 4);
		this.UpdateKeyboardInputChange("a", 5);
		this.UpdateKeyboardInputChange("d", 6);
		this.UpdateKeyboardInputChange("d", 7);
		this.UpdateKeyboardInputChange("w", 8);
		this.UpdateKeyboardInputChange("w", 9);
		this.UpdateKeyboardInputChange("s", 10);
		this.UpdateKeyboardInputChange("s", 11);
		this.UpdateKeyboardInputChange("a", 12);
		this.UpdateKeyboardInputChange("a", 13);
		this.UpdateKeyboardInputChange("d", 14);
		this.UpdateKeyboardInputChange("d", 15);
		this.UpdateKeyboardInputChange("mouse 0", 16);
		this.UpdateKeyboardInputChange("mouse 0", 17);
		this.UpdateKeyboardInputChange("mouse 2", 18);
		this.UpdateKeyboardInputChange("q", 19);
		this.UpdateKeyboardInputChange("mouse 1", 20);
		this.UpdateKeyboardInputChange("mouse 1", 21);
		this.UpdateKeyboardInputChange("1", 22);
		this.UpdateKeyboardInputChange("1", 23);
		this.UpdateKeyboardInputChange("2", 24);
		this.UpdateKeyboardInputChange("2", 25);
		this.UpdateKeyboardInputChange("3", 26);
		this.UpdateKeyboardInputChange("3", 27);
		this.UpdateKeyboardInputChange("left ctrl", 28);
		this.UpdateKeyboardInputChange("left ctrl", 29);
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00037D34 File Offset: 0x00036134
	private void UpdateKeyboardInputChange(string inputString, int i)
	{
		int num;
		if (inputString == "backspace")
		{
			num = 1;
		}
		else if (inputString == "delete")
		{
			num = 3;
		}
		else if (inputString == "tab")
		{
			num = 5;
		}
		else if (inputString == "clear")
		{
			num = 7;
		}
		else if (inputString == "return")
		{
			num = 9;
		}
		else if (inputString == "pause")
		{
			num = 11;
		}
		else if (inputString == "escape")
		{
			num = 13;
		}
		else if (inputString == "space")
		{
			num = 15;
		}
		else if (inputString == "up")
		{
			num = 17;
		}
		else if (inputString == "down")
		{
			num = 19;
		}
		else if (inputString == "right")
		{
			num = 21;
		}
		else if (inputString == "left")
		{
			num = 23;
		}
		else if (inputString == "insert")
		{
			num = 25;
		}
		else if (inputString == "home")
		{
			num = 27;
		}
		else if (inputString == "end")
		{
			num = 29;
		}
		else if (inputString == "page up")
		{
			num = 31;
		}
		else if (inputString == "page down")
		{
			num = 33;
		}
		else if (inputString == "f1")
		{
			num = 35;
		}
		else if (inputString == "f2")
		{
			num = 37;
		}
		else if (inputString == "f3")
		{
			num = 39;
		}
		else if (inputString == "f4")
		{
			num = 41;
		}
		else if (inputString == "f5")
		{
			num = 43;
		}
		else if (inputString == "f6")
		{
			num = 45;
		}
		else if (inputString == "f7")
		{
			num = 47;
		}
		else if (inputString == "f8")
		{
			num = 49;
		}
		else if (inputString == "f9")
		{
			num = 51;
		}
		else if (inputString == "f10")
		{
			num = 53;
		}
		else if (inputString == "f11")
		{
			num = 55;
		}
		else if (inputString == "f12")
		{
			num = 57;
		}
		else if (inputString == "0")
		{
			num = 59;
		}
		else if (inputString == "1")
		{
			num = 61;
		}
		else if (inputString == "2")
		{
			num = 63;
		}
		else if (inputString == "3")
		{
			num = 65;
		}
		else if (inputString == "4")
		{
			num = 67;
		}
		else if (inputString == "5")
		{
			num = 69;
		}
		else if (inputString == "6")
		{
			num = 71;
		}
		else if (inputString == "7")
		{
			num = 73;
		}
		else if (inputString == "8")
		{
			num = 75;
		}
		else if (inputString == "9")
		{
			num = 77;
		}
		else if (inputString == "!")
		{
			num = 79;
		}
		else if (inputString == "\"")
		{
			num = 81;
		}
		else if (inputString == "#")
		{
			num = 83;
		}
		else if (inputString == "$")
		{
			num = 85;
		}
		else if (inputString == "&")
		{
			num = 87;
		}
		else if (inputString == "'")
		{
			num = 89;
		}
		else if (inputString == "(")
		{
			num = 91;
		}
		else if (inputString == ")")
		{
			num = 93;
		}
		else if (inputString == "*")
		{
			num = 95;
		}
		else if (inputString == "+")
		{
			num = 97;
		}
		else if (inputString == ",")
		{
			num = 99;
		}
		else if (inputString == "-")
		{
			num = 101;
		}
		else if (inputString == ".")
		{
			num = 103;
		}
		else if (inputString == "/")
		{
			num = 105;
		}
		else if (inputString == ":")
		{
			num = 107;
		}
		else if (inputString == ";")
		{
			num = 109;
		}
		else if (inputString == "<")
		{
			num = 111;
		}
		else if (inputString == "=")
		{
			num = 113;
		}
		else if (inputString == ">")
		{
			num = 115;
		}
		else if (inputString == "?")
		{
			num = 117;
		}
		else if (inputString == "@")
		{
			num = 119;
		}
		else if (inputString == "[")
		{
			num = 121;
		}
		else if (inputString == "\\")
		{
			num = 123;
		}
		else if (inputString == "]")
		{
			num = 125;
		}
		else if (inputString == "^")
		{
			num = 127;
		}
		else if (inputString == "_")
		{
			num = 129;
		}
		else if (inputString == "`")
		{
			num = 131;
		}
		else if (inputString == "a")
		{
			num = 133;
		}
		else if (inputString == "b")
		{
			num = 135;
		}
		else if (inputString == "c")
		{
			num = 137;
		}
		else if (inputString == "d")
		{
			num = 139;
		}
		else if (inputString == "e")
		{
			num = 141;
		}
		else if (inputString == "f")
		{
			num = 143;
		}
		else if (inputString == "g")
		{
			num = 145;
		}
		else if (inputString == "h")
		{
			num = 147;
		}
		else if (inputString == "i")
		{
			num = 149;
		}
		else if (inputString == "j")
		{
			num = 151;
		}
		else if (inputString == "k")
		{
			num = 153;
		}
		else if (inputString == "l")
		{
			num = 155;
		}
		else if (inputString == "m")
		{
			num = 157;
		}
		else if (inputString == "n")
		{
			num = 159;
		}
		else if (inputString == "o")
		{
			num = 161;
		}
		else if (inputString == "p")
		{
			num = 163;
		}
		else if (inputString == "q")
		{
			num = 165;
		}
		else if (inputString == "r")
		{
			num = 167;
		}
		else if (inputString == "s")
		{
			num = 169;
		}
		else if (inputString == "t")
		{
			num = 171;
		}
		else if (inputString == "u")
		{
			num = 173;
		}
		else if (inputString == "v")
		{
			num = 175;
		}
		else if (inputString == "w")
		{
			num = 177;
		}
		else if (inputString == "x")
		{
			num = 179;
		}
		else if (inputString == "y")
		{
			num = 181;
		}
		else if (inputString == "z")
		{
			num = 183;
		}
		else if (inputString == "numlock")
		{
			num = 185;
		}
		else if (inputString == "caps lock")
		{
			num = 187;
		}
		else if (inputString == "scroll lock")
		{
			num = 189;
		}
		else if (inputString == "right shift")
		{
			num = 191;
		}
		else if (inputString == "left shift")
		{
			num = 193;
		}
		else if (inputString == "right ctrl")
		{
			num = 195;
		}
		else if (inputString == "left ctrl")
		{
			num = 197;
		}
		else if (inputString == "right alt")
		{
			num = 199;
		}
		else if (inputString == "left alt")
		{
			num = 201;
		}
		else if (inputString == "mouse 0")
		{
			num = 203;
		}
		else if (inputString == "mouse 1")
		{
			num = 205;
		}
		else
		{
			if (!(inputString == "mouse 2"))
			{
				return;
			}
			num = 207;
		}
		this.keyboardInputTarget[i].GetComponent<UI2DSprite>().sprite2D = this.keyboardInputUI[num - 1];
		this.keyboardInputTarget[i].GetComponent<UIButton>().normalSprite2D = this.keyboardInputUI[num - 1];
		this.keyboardInputTarget[i].GetComponent<UIButton>().hoverSprite2D = this.keyboardInputUI[num - 1];
		this.keyboardInputAssigned[i] = num - 1;
		this.assignedInputStrings[i] = this.inputStringLibrary[num - 1];
		base.GetComponent<MouseLook>().assignedInputStrings[i] = this.inputStringLibrary[num - 1];
		base.transform.parent.GetComponent<MouseLook>().assignedInputStrings[i] = this.inputStringLibrary[num - 1];
		if (i == 8)
		{
			this.steeringUI[0].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 10)
		{
			this.steeringUI[1].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 12)
		{
			this.steeringUI[2].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 14)
		{
			this.steeringUI[3].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 16)
		{
			this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[0] = this.keyboardInputUI[num - 1];
			this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[1] = this.keyboardInputUI[num];
		}
		if (i == 20)
		{
			this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[2] = this.keyboardInputUI[num - 1];
			this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[3] = this.keyboardInputUI[num];
		}
		if (i == 18)
		{
			this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[4] = this.keyboardInputUI[num - 1];
			this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[5] = this.keyboardInputUI[num];
		}
		if (i == 8)
		{
			this.userManualUI[0].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 10)
		{
			this.userManualUI[1].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 12)
		{
			this.userManualUI[2].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 14)
		{
			this.userManualUI[3].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 18 && this.environmentalPosterUI[0] != null)
		{
			this.environmentalPosterUI[0].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 22 && this.environmentalPosterUI[1] != null)
		{
			this.environmentalPosterUI[1].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 24 && this.environmentalPosterUI[2] != null)
		{
			this.environmentalPosterUI[2].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		if (i == 20 && this.environmentalPosterUI[3] != null)
		{
			this.environmentalPosterUI[3].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
		}
		this.changeInputID = 0;
	}

	// Token: 0x060003CB RID: 971 RVA: 0x00038ADC File Offset: 0x00036EDC
	private void ResetKeyBindingsToPrevSetting()
	{
		for (int i = 0; i < this.keyboardInputAssigned.Length; i++)
		{
			this.keyboardInputAssigned[i] = this.keyboardInputAssignedPrev[i];
			this.keyboardInputTarget[i].GetComponent<UI2DSprite>().sprite2D = this.keyboardInputUI[this.keyboardInputAssignedPrev[i]];
			this.keyboardInputTarget[i].GetComponent<UIButton>().normalSprite2D = this.keyboardInputUI[this.keyboardInputAssignedPrev[i]];
			this.keyboardInputTarget[i].GetComponent<UIButton>().hoverSprite2D = this.keyboardInputUI[this.keyboardInputAssignedPrev[i]];
			this.keyboardInputAssigned[i] = this.keyboardInputAssignedPrev[i];
			this.assignedInputStrings[i] = this.inputStringLibrary[this.keyboardInputAssignedPrev[i]];
			base.GetComponent<MouseLook>().assignedInputStrings[i] = this.inputStringLibrary[this.keyboardInputAssignedPrev[i]];
			base.transform.parent.GetComponent<MouseLook>().assignedInputStrings[i] = this.inputStringLibrary[this.keyboardInputAssignedPrev[i]];
		}
	}

	// Token: 0x060003CC RID: 972 RVA: 0x00038BE0 File Offset: 0x00036FE0
	private void CheckForKeyboardInputChange()
	{
		if (Input.anyKey)
		{
			int num;
			if (Input.GetKey("backspace"))
			{
				num = 1;
			}
			else if (Input.GetKey("delete"))
			{
				num = 3;
			}
			else if (Input.GetKey("tab"))
			{
				num = 5;
			}
			else if (Input.GetKey("clear"))
			{
				num = 7;
			}
			else if (Input.GetKey("return"))
			{
				num = 9;
			}
			else if (Input.GetKey("pause"))
			{
				num = 11;
			}
			else if (Input.GetKey("escape"))
			{
				num = 13;
			}
			else if (Input.GetKey("space"))
			{
				num = 15;
			}
			else if (Input.GetKey("up"))
			{
				num = 17;
			}
			else if (Input.GetKey("down"))
			{
				num = 19;
			}
			else if (Input.GetKey("right"))
			{
				num = 21;
			}
			else if (Input.GetKey("left"))
			{
				num = 23;
			}
			else if (Input.GetKey("insert"))
			{
				num = 25;
			}
			else if (Input.GetKey("home"))
			{
				num = 27;
			}
			else if (Input.GetKey("end"))
			{
				num = 29;
			}
			else if (Input.GetKey("page up"))
			{
				num = 31;
			}
			else if (Input.GetKey("page down"))
			{
				num = 33;
			}
			else if (Input.GetKey("f1"))
			{
				num = 35;
			}
			else if (Input.GetKey("f2"))
			{
				num = 37;
			}
			else if (Input.GetKey("f3"))
			{
				num = 39;
			}
			else if (Input.GetKey("f4"))
			{
				num = 41;
			}
			else if (Input.GetKey("f5"))
			{
				num = 43;
			}
			else if (Input.GetKey("f6"))
			{
				num = 45;
			}
			else if (Input.GetKey("f7"))
			{
				num = 47;
			}
			else if (Input.GetKey("f8"))
			{
				num = 49;
			}
			else if (Input.GetKey("f9"))
			{
				num = 51;
			}
			else if (Input.GetKey("f10"))
			{
				num = 53;
			}
			else if (Input.GetKey("f11"))
			{
				num = 55;
			}
			else if (Input.GetKey("f12"))
			{
				num = 57;
			}
			else if (Input.GetKey("0"))
			{
				num = 59;
			}
			else if (Input.GetKey("1"))
			{
				num = 61;
			}
			else if (Input.GetKey("2"))
			{
				num = 63;
			}
			else if (Input.GetKey("3"))
			{
				num = 65;
			}
			else if (Input.GetKey("4"))
			{
				num = 67;
			}
			else if (Input.GetKey("5"))
			{
				num = 69;
			}
			else if (Input.GetKey("6"))
			{
				num = 71;
			}
			else if (Input.GetKey("7"))
			{
				num = 73;
			}
			else if (Input.GetKey("8"))
			{
				num = 75;
			}
			else if (Input.GetKey("9"))
			{
				num = 77;
			}
			else if (Input.GetKey("!"))
			{
				num = 79;
			}
			else if (Input.GetKey("\""))
			{
				num = 81;
			}
			else if (Input.GetKey("#"))
			{
				num = 83;
			}
			else if (Input.GetKey("$"))
			{
				num = 84;
			}
			else if (Input.GetKey("&"))
			{
				num = 87;
			}
			else if (Input.GetKey("'"))
			{
				num = 89;
			}
			else if (Input.GetKey("("))
			{
				num = 91;
			}
			else if (Input.GetKey(")"))
			{
				num = 93;
			}
			else if (Input.GetKey("*"))
			{
				num = 95;
			}
			else if (Input.GetKey("+"))
			{
				num = 97;
			}
			else if (Input.GetKey(","))
			{
				num = 99;
			}
			else if (Input.GetKey("-"))
			{
				num = 101;
			}
			else if (Input.GetKey("."))
			{
				num = 103;
			}
			else if (Input.GetKey("/"))
			{
				num = 105;
			}
			else if (Input.GetKey(":"))
			{
				num = 107;
			}
			else if (Input.GetKey(";"))
			{
				num = 109;
			}
			else if (Input.GetKey("<"))
			{
				num = 111;
			}
			else if (Input.GetKey("="))
			{
				num = 113;
			}
			else if (Input.GetKey(">"))
			{
				num = 115;
			}
			else if (Input.GetKey("?"))
			{
				num = 117;
			}
			else if (Input.GetKey("@"))
			{
				num = 119;
			}
			else if (Input.GetKey("["))
			{
				num = 121;
			}
			else if (Input.GetKey("\\"))
			{
				num = 123;
			}
			else if (Input.GetKey("]"))
			{
				num = 125;
			}
			else if (Input.GetKey("^"))
			{
				num = 127;
			}
			else if (Input.GetKey("_"))
			{
				num = 129;
			}
			else if (Input.GetKey("`"))
			{
				num = 131;
			}
			else if (Input.GetKey("a"))
			{
				num = 133;
			}
			else if (Input.GetKey("b"))
			{
				num = 135;
			}
			else if (Input.GetKey("c"))
			{
				num = 137;
			}
			else if (Input.GetKey("d"))
			{
				num = 139;
			}
			else if (Input.GetKey("e"))
			{
				num = 141;
			}
			else if (Input.GetKey("f"))
			{
				num = 143;
			}
			else if (Input.GetKey("g"))
			{
				num = 145;
			}
			else if (Input.GetKey("h"))
			{
				num = 147;
			}
			else if (Input.GetKey("i"))
			{
				num = 149;
			}
			else if (Input.GetKey("j"))
			{
				num = 151;
			}
			else if (Input.GetKey("k"))
			{
				num = 153;
			}
			else if (Input.GetKey("l"))
			{
				num = 155;
			}
			else if (Input.GetKey("m"))
			{
				num = 157;
			}
			else if (Input.GetKey("n"))
			{
				num = 159;
			}
			else if (Input.GetKey("o"))
			{
				num = 161;
			}
			else if (Input.GetKey("p"))
			{
				num = 163;
			}
			else if (Input.GetKey("q"))
			{
				num = 165;
			}
			else if (Input.GetKey("r"))
			{
				num = 167;
			}
			else if (Input.GetKey("s"))
			{
				num = 169;
			}
			else if (Input.GetKey("t"))
			{
				num = 171;
			}
			else if (Input.GetKey("u"))
			{
				num = 173;
			}
			else if (Input.GetKey("v"))
			{
				num = 175;
			}
			else if (Input.GetKey("w"))
			{
				num = 177;
			}
			else if (Input.GetKey("x"))
			{
				num = 179;
			}
			else if (Input.GetKey("y"))
			{
				num = 181;
			}
			else if (Input.GetKey("z"))
			{
				num = 183;
			}
			else if (Input.GetKey("numlock"))
			{
				num = 185;
			}
			else if (Input.GetKey("caps lock"))
			{
				num = 187;
			}
			else if (Input.GetKey("scroll lock"))
			{
				num = 189;
			}
			else if (Input.GetKey("right shift"))
			{
				num = 191;
			}
			else if (Input.GetKey("left shift"))
			{
				num = 193;
			}
			else if (Input.GetKey("right ctrl"))
			{
				num = 195;
			}
			else if (Input.GetKey("left ctrl"))
			{
				num = 197;
			}
			else if (Input.GetKey("right alt"))
			{
				num = 199;
			}
			else if (Input.GetKey("left alt"))
			{
				num = 201;
			}
			else if (Input.GetKey("mouse 0"))
			{
				num = 203;
			}
			else if (Input.GetKey("mouse 1"))
			{
				num = 205;
			}
			else
			{
				if (!Input.GetKey("mouse 2"))
				{
					return;
				}
				num = 207;
			}
			this.keyboardInputTarget[this.changeInputID - 1].GetComponent<UI2DSprite>().sprite2D = this.keyboardInputUI[num - 1];
			this.keyboardInputTarget[this.changeInputID - 1].GetComponent<UIButton>().normalSprite2D = this.keyboardInputUI[num - 1];
			this.keyboardInputTarget[this.changeInputID - 1].GetComponent<UIButton>().hoverSprite2D = this.keyboardInputUI[num - 1];
			this.keyboardInputAssigned[this.changeInputID - 1] = num - 1;
			this.assignedInputStrings[this.changeInputID - 1] = this.inputStringLibrary[num - 1];
			base.GetComponent<MouseLook>().assignedInputStrings[this.changeInputID - 1] = this.inputStringLibrary[num - 1];
			base.transform.parent.GetComponent<MouseLook>().assignedInputStrings[this.changeInputID - 1] = this.inputStringLibrary[num - 1];
			if (this.changeInputID - 1 == 8)
			{
				this.steeringUI[0].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 10)
			{
				this.steeringUI[1].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 12)
			{
				this.steeringUI[2].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 14)
			{
				this.steeringUI[3].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 16)
			{
				this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[0] = this.keyboardInputUI[num - 1];
				this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[1] = this.keyboardInputUI[num];
			}
			if (this.changeInputID - 1 == 20)
			{
				this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[2] = this.keyboardInputUI[num - 1];
				this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[3] = this.keyboardInputUI[num];
			}
			if (this.changeInputID - 1 == 18)
			{
				this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[4] = this.keyboardInputUI[num - 1];
				this.dialogueUI.GetComponent<DialogueStuffsC>().sprites[5] = this.keyboardInputUI[num];
			}
			if (this.changeInputID - 1 == 8)
			{
				this.userManualUI[0].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 10)
			{
				this.userManualUI[1].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 12)
			{
				this.userManualUI[2].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 14)
			{
				this.userManualUI[3].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 18)
			{
				this.environmentalPosterUI[0].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 22)
			{
				this.environmentalPosterUI[1].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 24)
			{
				this.environmentalPosterUI[2].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			if (this.changeInputID - 1 == 20)
			{
				this.environmentalPosterUI[3].GetComponent<SpriteRenderer>().sprite = this.keyboardInputUI[num - 1];
			}
			this.changeInputID = 0;
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x00039978 File Offset: 0x00037D78
	public void ChangeKeyboardInputWalkingForward1()
	{
		this.changeInputID = 1;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x00039981 File Offset: 0x00037D81
	public void ChangeKeyboardInputWalkingForward2()
	{
		this.changeInputID = 2;
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0003998A File Offset: 0x00037D8A
	public void ChangeKeyboardInputWalkingBackward1()
	{
		this.changeInputID = 3;
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x00039993 File Offset: 0x00037D93
	public void ChangeKeyboardInputWalkingBackward2()
	{
		this.changeInputID = 4;
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x0003999C File Offset: 0x00037D9C
	public void ChangeKeyboardInputStrafeLeft1()
	{
		this.changeInputID = 5;
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x000399A5 File Offset: 0x00037DA5
	public void ChnageKeyboardInputStrafeLeft2()
	{
		this.changeInputID = 6;
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x000399AE File Offset: 0x00037DAE
	public void ChangeKeyboardInputStrafeRight1()
	{
		this.changeInputID = 7;
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x000399B7 File Offset: 0x00037DB7
	public void ChangeKeyboardInputStrafeRight2()
	{
		this.changeInputID = 8;
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x000399C0 File Offset: 0x00037DC0
	public void ChangeKeyboardInputAccelerate1()
	{
		this.changeInputID = 9;
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x000399CA File Offset: 0x00037DCA
	public void ChangeKeyboardInputAccelerate2()
	{
		this.changeInputID = 10;
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x000399D4 File Offset: 0x00037DD4
	public void ChangeKeyboardInputBrakeRev1()
	{
		this.changeInputID = 11;
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x000399DE File Offset: 0x00037DDE
	public void ChangeKeyboardInputBrakeRev2()
	{
		this.changeInputID = 12;
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x000399E8 File Offset: 0x00037DE8
	public void ChangeKeyboardInputSteerLeft1()
	{
		this.changeInputID = 13;
	}

	// Token: 0x060003DA RID: 986 RVA: 0x000399F2 File Offset: 0x00037DF2
	public void ChangeKeyboardInputSteerLeft2()
	{
		this.changeInputID = 14;
	}

	// Token: 0x060003DB RID: 987 RVA: 0x000399FC File Offset: 0x00037DFC
	public void ChangeKeyboardInputSteerRight1()
	{
		this.changeInputID = 15;
	}

	// Token: 0x060003DC RID: 988 RVA: 0x00039A06 File Offset: 0x00037E06
	public void ChangeKeyboardInputSteerRight2()
	{
		this.changeInputID = 16;
	}

	// Token: 0x060003DD RID: 989 RVA: 0x00039A10 File Offset: 0x00037E10
	public void ChangeKeyboardPickup1()
	{
		this.changeInputID = 17;
	}

	// Token: 0x060003DE RID: 990 RVA: 0x00039A1A File Offset: 0x00037E1A
	public void ChangeKeyboardPickup2()
	{
		this.changeInputID = 18;
	}

	// Token: 0x060003DF RID: 991 RVA: 0x00039A24 File Offset: 0x00037E24
	public void ChangeKeyboardDrop1()
	{
		this.changeInputID = 19;
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x00039A2E File Offset: 0x00037E2E
	public void ChangeKeyboardDrop2()
	{
		this.changeInputID = 20;
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x00039A38 File Offset: 0x00037E38
	public void ChangeKeyboardZoom1()
	{
		this.changeInputID = 21;
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x00039A42 File Offset: 0x00037E42
	public void ChangeKeyboardZoom2()
	{
		this.changeInputID = 22;
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00039A4C File Offset: 0x00037E4C
	public void ChangeKeyboardItem11()
	{
		this.changeInputID = 23;
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x00039A56 File Offset: 0x00037E56
	public void ChangeKeyboardItem12()
	{
		this.changeInputID = 24;
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x00039A60 File Offset: 0x00037E60
	public void ChangeKeyboardItem21()
	{
		this.changeInputID = 25;
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00039A6A File Offset: 0x00037E6A
	public void ChangeKeyboardItem22()
	{
		this.changeInputID = 26;
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x00039A74 File Offset: 0x00037E74
	public void ChangeKeyboardItem31()
	{
		this.changeInputID = 27;
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x00039A7E File Offset: 0x00037E7E
	public void ChangeKeyboardItem32()
	{
		this.changeInputID = 28;
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x00039A88 File Offset: 0x00037E88
	public void ChangeKeyboardCrouch1()
	{
		this.changeInputID = 29;
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x00039A92 File Offset: 0x00037E92
	public void ChangeKeyboardCrouch2()
	{
		this.changeInputID = 30;
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00039A9C File Offset: 0x00037E9C
	public void changeKeyboardInputStop()
	{
		this.changeInputID = 0;
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x00039AA8 File Offset: 0x00037EA8
	public void UnlockLetter(int id)
	{
		this._diaryStamp[id].GetComponent<IconRelayC>().UnlockStamp();
		GameObject gameObject = GameObject.FindWithTag("Steam");
		ES3.Save(true, "stampSave" + id);
		if (gameObject != null)
		{
			gameObject.SendMessage("UnlockAchievement" + (id + 1));
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x00039B0C File Offset: 0x00037F0C
	private void CheckStolen(Transform checkTransform, bool roof = false)
	{
		if (checkTransform.childCount > 0)
		{
			if (!checkTransform.GetChild(0).GetComponent<ObjectPickupC>().isPurchased)
			{
				this.AddToStolenGoodsValue(checkTransform.GetChild(0).GetComponent<ObjectPickupC>().buyValue);
			}
			if (!roof)
			{
				this.bootInventorySaveListsTyres.Add(checkTransform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
			}
			else
			{
				this.roofInventorySaveListsTyres.Add(checkTransform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
			}
			this.componentConditions.Add(checkTransform.GetChild(0).GetComponent<EngineComponentC>().Condition);
			ES3.Save(this.componentConditions, "componentConditions");
		}
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x00039BC4 File Offset: 0x00037FC4
	private void SaveInventory()
	{
		this.ClearStolenGoodsValue();
		InventoryLogicC component = this.carLogic.GetComponent<CarLogicC>().bootInventory.GetComponent<InventoryLogicC>();
		this.SaveInventoryNo1(component);
		this.CheckStolen(component.wheelHolder1.transform, false);
		this.CheckStolen(component.wheelHolder2.transform, false);
		if (this.bootInventorySaveListsTyres.Count > 0)
		{
			ES3.Save(this.bootInventorySaveListsTyres, "bootInventorySaveListsTyres");
		}
		InventoryLogicC component2 = this.carLogic.GetComponent<CarLogicC>().roofInventory.GetComponent<InventoryLogicC>();
		this.SaveInventoryNo2(component2);
		this.CheckStolen(component2.wheelHolder1.transform, true);
		this.CheckStolen(component2.wheelHolder2.transform, true);
		if (this.roofInventorySaveListsTyres.Count > 0)
		{
			ES3.Save(this.roofInventorySaveListsTyres, "roofInventorySaveListsTyres");
		}
		ES3.Save(this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().totalDistance, "odometerTotalDistance");
		if (this.storageInventory[0] != null)
		{
			if (this.storageInventory[0].transform.childCount > 0)
			{
				this.SaveHome1Inventory();
			}
			if (this.storageInventory[1].transform.childCount > 0)
			{
				this.SaveHome2Inventory();
			}
			if (this.storageInventory[2].transform.childCount > 0)
			{
				this.SaveHome3Inventory();
			}
			if (this.storageInventory[3].transform.childCount > 0)
			{
				this.SaveHome4Inventory();
			}
			if (this.storageInventory[4].transform.childCount > 0)
			{
				this.SaveHome5Inventory();
			}
		}
		this.SavingStolenGoods();
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00039D90 File Offset: 0x00038190
	private void LoadHome1Inventory()
	{
		this.LoadHomeInventory(1);
		if (!ES3.LoadBool("home1InventoryInstalled"))
		{
			this.ThiefCheck();
		}
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x00039DAE File Offset: 0x000381AE
	private void LoadHome2Inventory()
	{
		this.LoadHomeInventory(2);
		if (!ES3.LoadBool("home2InventoryInstalled"))
		{
			this.ThiefCheck();
		}
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x00039DCC File Offset: 0x000381CC
	private void LoadHome3Inventory()
	{
		this.LoadHomeInventory(3);
		if (!ES3.LoadBool("home3InventoryInstalled"))
		{
			this.ThiefCheck();
		}
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x00039DEA File Offset: 0x000381EA
	private void LoadHome4Inventory()
	{
		this.LoadHomeInventory(4);
		if (!ES3.LoadBool("home4InventoryInstalled"))
		{
			this.ThiefCheck();
		}
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x00039E08 File Offset: 0x00038208
	private void LoadHome5Inventory()
	{
		this.LoadHomeInventory(5);
		if (!ES3.LoadBool("home5InventoryInstalled"))
		{
			this.ThiefCheck();
		}
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x00039E28 File Offset: 0x00038228
	private void ThiefCheck()
	{
		this.ClearInventoryLoadDetails();
		if (ES3.Exists("savedStolenGoods"))
		{
			bool flag = ES3.LoadBool("savedStolenGoods");
		}
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x00039E58 File Offset: 0x00038258
	private void LoadHomeInventory(int index)
	{
		HomeStorageClipboardC.Global.LoadShelf(index - 1);
		if (this.storageInventory[index - 1].transform.childCount < 1)
		{
			return;
		}
		InventoryLogicC component = this.storageInventory[index - 1].transform.GetChild(0).GetComponent<InventoryLogicC>();
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		List<int> list4 = new List<int>();
		List<int> list5 = new List<int>();
		List<int> list6 = new List<int>();
		List<int> list7 = new List<int>();
		List<int> list8 = new List<int>();
		List<int> list9 = new List<int>();
		List<int> list10 = new List<int>();
		List<int> list11 = new List<int>();
		List<int> list12 = new List<int>();
		List<int> list13 = new List<int>();
		List<int> list14 = new List<int>();
		List<int> list15 = new List<int>();
		List<int> list16 = new List<int>();
		List<int> list17 = new List<int>();
		List<int> list18 = new List<int>();
		List<int> list19 = new List<int>();
		List<int> list20 = new List<int>();
		List<int> list21 = new List<int>();
		List<int> list22 = new List<int>();
		List<int> list23 = new List<int>();
		if (ES3.Exists("home" + index + "InventorySaveList"))
		{
			list = ES3.LoadListInt("home" + index + "InventorySaveList");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocsSingle"))
		{
			list2 = ES3.LoadListInt("home" + index + "InventorySaveLocsSingle");
		}
		if (ES3.Exists("home" + index + "InventoryTradeGoodsSmallIDSaveList"))
		{
			list3 = ES3.LoadListInt("home" + index + "InventoryTradeGoodsSmallIDSaveList");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists3x2x1"))
		{
			list4 = ES3.LoadListInt("home" + index + "InventorySaveLists3x2x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs3x2x1"))
		{
			list5 = ES3.LoadListInt("home" + index + "InventorySaveLocs3x2x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists2x2x1"))
		{
			list6 = ES3.LoadListInt("home" + index + "InventorySaveLists2x2x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs2x2x1"))
		{
			list7 = ES3.LoadListInt("home" + index + "InventorySaveLocs2x2x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists2x2x2"))
		{
			list8 = ES3.LoadListInt("home" + index + "InventorySaveLists2x2x2");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs2x2x2"))
		{
			list9 = ES3.LoadListInt("home" + index + "InventorySaveLocs2x2x2");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists2x2x3"))
		{
			list10 = ES3.LoadListInt("home" + index + "InventorySaveLists2x2x3");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs2x2x3"))
		{
			list11 = ES3.LoadListInt("home" + index + "InventorySaveLocs2x2x3");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists3x2x3"))
		{
			list12 = ES3.LoadListInt("home" + index + "InventorySaveLists3x2x3");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs3x2x3"))
		{
			list13 = ES3.LoadListInt("home" + index + "InventorySaveLocs3x2x3");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists4x2x2"))
		{
			list14 = ES3.LoadListInt("home" + index + "InventorySaveLists4x2x2");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs4x2x2"))
		{
			list15 = ES3.LoadListInt("home" + index + "InventorySaveLocs4x2x2");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists4x2x3"))
		{
			list16 = ES3.LoadListInt("home" + index + "InventorySaveLists4x2x3");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs4x2x3"))
		{
			list17 = ES3.LoadListInt("home" + index + "InventorySaveLocs4x2x3");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists4x1x1"))
		{
			list18 = ES3.LoadListInt("home" + index + "InventorySaveLists4x1x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs4x1x1"))
		{
			list19 = ES3.LoadListInt("home" + index + "InventorySaveLocs4x1x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists4x2x1"))
		{
			list20 = ES3.LoadListInt("home" + index + "InventorySaveLists4x2x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs4x2x1"))
		{
			list21 = ES3.LoadListInt("home" + index + "InventorySaveLocs4x2x1");
		}
		if (ES3.Exists("home" + index + "InventorySaveLists2x1x3"))
		{
			list22 = ES3.LoadListInt("home" + index + "InventorySaveLists2x1x3");
		}
		if (ES3.Exists("home" + index + "InventorySaveLocs2x1x3"))
		{
			list23 = ES3.LoadListInt("home" + index + "InventorySaveLocs2x1x3");
		}
		if (index == 5)
		{
			this.home5InventorySaveList = list;
			this.home5InventorySaveLocsSingle = list2;
			this.home5InventoryTradeGoodsSmallIDSaveList = list3;
			this.home5InventorySaveLists3x2x1 = list4;
			this.home5InventorySaveLocs3x2x1 = list5;
			this.home5InventorySaveLists2x2x1 = list6;
			this.home5InventorySaveLocs2x2x1 = list7;
			this.home5InventorySaveLists2x2x2 = list8;
			this.home5InventorySaveLocs2x2x2 = list9;
			this.home5InventorySaveLists2x2x3 = list10;
			this.home5InventorySaveLocs2x2x3 = list11;
			this.home5InventorySaveLists3x2x3 = list12;
			this.home5InventorySaveLocs3x2x3 = list13;
			this.home5InventorySaveLists4x2x2 = list14;
			this.home5InventorySaveLocs4x2x2 = list15;
			this.home5InventorySaveLists4x2x3 = list16;
			this.home5InventorySaveLocs4x2x3 = list17;
			this.home5InventorySaveLists4x1x1 = list18;
			this.home5InventorySaveLocs4x1x1 = list19;
			this.home5InventorySaveLists4x2x1 = list20;
			this.home5InventorySaveLocs4x2x1 = list21;
			this.home5InventorySaveLists2x1x3 = list22;
			this.home5InventorySaveLocs2x1x3 = list23;
		}
		if (index == 4)
		{
			this.home4InventorySaveList = list;
			this.home4InventorySaveLocsSingle = list2;
			this.home4InventoryTradeGoodsSmallIDSaveList = list3;
			this.home4InventorySaveLists3x2x1 = list4;
			this.home4InventorySaveLocs3x2x1 = list5;
			this.home4InventorySaveLists2x2x1 = list6;
			this.home4InventorySaveLocs2x2x1 = list7;
			this.home4InventorySaveLists2x2x2 = list8;
			this.home4InventorySaveLocs2x2x2 = list9;
			this.home4InventorySaveLists2x2x3 = list10;
			this.home4InventorySaveLocs2x2x3 = list11;
			this.home4InventorySaveLists3x2x3 = list12;
			this.home4InventorySaveLocs3x2x3 = list13;
			this.home4InventorySaveLists4x2x2 = list14;
			this.home4InventorySaveLocs4x2x2 = list15;
			this.home4InventorySaveLists4x2x3 = list16;
			this.home4InventorySaveLocs4x2x3 = list17;
			this.home4InventorySaveLists4x1x1 = list18;
			this.home4InventorySaveLocs4x1x1 = list19;
			this.home4InventorySaveLists4x2x1 = list20;
			this.home4InventorySaveLocs4x2x1 = list21;
			this.home4InventorySaveLists2x1x3 = list22;
			this.home4InventorySaveLocs2x1x3 = list23;
		}
		if (index == 3)
		{
			this.home3InventorySaveList = list;
			this.home3InventorySaveLocsSingle = list2;
			this.home3InventoryTradeGoodsSmallIDSaveList = list3;
			this.home3InventorySaveLists3x2x1 = list4;
			this.home3InventorySaveLocs3x2x1 = list5;
			this.home3InventorySaveLists2x2x1 = list6;
			this.home3InventorySaveLocs2x2x1 = list7;
			this.home3InventorySaveLists2x2x2 = list8;
			this.home3InventorySaveLocs2x2x2 = list9;
			this.home3InventorySaveLists2x2x3 = list10;
			this.home3InventorySaveLocs2x2x3 = list11;
			this.home3InventorySaveLists3x2x3 = list12;
			this.home3InventorySaveLocs3x2x3 = list13;
			this.home3InventorySaveLists4x2x2 = list14;
			this.home3InventorySaveLocs4x2x2 = list15;
			this.home3InventorySaveLists4x2x3 = list16;
			this.home3InventorySaveLocs4x2x3 = list17;
			this.home3InventorySaveLists4x1x1 = list18;
			this.home3InventorySaveLocs4x1x1 = list19;
			this.home3InventorySaveLists4x2x1 = list20;
			this.home3InventorySaveLocs4x2x1 = list21;
			this.home3InventorySaveLists2x1x3 = list22;
			this.home3InventorySaveLocs2x1x3 = list23;
		}
		if (index == 2)
		{
			this.home2InventorySaveList = list;
			this.home2InventorySaveLocsSingle = list2;
			this.home2InventoryTradeGoodsSmallIDSaveList = list3;
			this.home2InventorySaveLists3x2x1 = list4;
			this.home2InventorySaveLocs3x2x1 = list5;
			this.home2InventorySaveLists2x2x1 = list6;
			this.home2InventorySaveLocs2x2x1 = list7;
			this.home2InventorySaveLists2x2x2 = list8;
			this.home2InventorySaveLocs2x2x2 = list9;
			this.home2InventorySaveLists2x2x3 = list10;
			this.home2InventorySaveLocs2x2x3 = list11;
			this.home2InventorySaveLists3x2x3 = list12;
			this.home2InventorySaveLocs3x2x3 = list13;
			this.home2InventorySaveLists4x2x2 = list14;
			this.home2InventorySaveLocs4x2x2 = list15;
			this.home2InventorySaveLists4x2x3 = list16;
			this.home2InventorySaveLocs4x2x3 = list17;
			this.home2InventorySaveLists4x1x1 = list18;
			this.home2InventorySaveLocs4x1x1 = list19;
			this.home2InventorySaveLists4x2x1 = list20;
			this.home2InventorySaveLocs4x2x1 = list21;
			this.home2InventorySaveLists2x1x3 = list22;
			this.home2InventorySaveLocs2x1x3 = list23;
		}
		if (index == 1)
		{
			this.home1InventorySaveList = list;
			this.home1InventorySaveLocsSingle = list2;
			this.home1InventoryTradeGoodsSmallIDSaveList = list3;
			this.home1InventorySaveLists3x2x1 = list4;
			this.home1InventorySaveLocs3x2x1 = list5;
			this.home1InventorySaveLists2x2x1 = list6;
			this.home1InventorySaveLocs2x2x1 = list7;
			this.home1InventorySaveLists2x2x2 = list8;
			this.home1InventorySaveLocs2x2x2 = list9;
			this.home1InventorySaveLists2x2x3 = list10;
			this.home1InventorySaveLocs2x2x3 = list11;
			this.home1InventorySaveLists3x2x3 = list12;
			this.home1InventorySaveLocs3x2x3 = list13;
			this.home1InventorySaveLists4x2x2 = list14;
			this.home1InventorySaveLocs4x2x2 = list15;
			this.home1InventorySaveLists4x2x3 = list16;
			this.home1InventorySaveLocs4x2x3 = list17;
			this.home1InventorySaveLists4x1x1 = list18;
			this.home1InventorySaveLocs4x1x1 = list19;
			this.home1InventorySaveLists4x2x1 = list20;
			this.home1InventorySaveLocs4x2x1 = list21;
			this.home1InventorySaveLists2x1x3 = list22;
			this.home1InventorySaveLocs2x1x3 = list23;
		}
		this.SpawnSingleInventoryItem(component, index - 1);
		this.SpawnSingleInventoryItems2(index, "3x2x1", component.slot3x2x1, component, false);
		this.SpawnSingleInventoryItems2(index, "2x2x1", component.slot2x2x1, component, false);
		this.SpawnSingleInventoryItems2(index, "2x2x2", component.slot2x2x2, component, false);
		this.SpawnSingleInventoryItems2(index, "2x2x3", component.slot2x2x3, component, true);
		this.SpawnSingleInventoryItems2(index, "3x2x3", component.slot3x2x3, component, true);
		this.SpawnSingleInventoryItems2(index, "4x2x2", component.slot4x2x2, component, false);
		this.SpawnSingleInventoryItems2(index, "4x2x3", component.slot4x2x3, component, false);
		this.SpawnSingleInventoryItems2(index, "4x1x1", component.slot4x1x1, component, false);
		this.SpawnSingleInventoryItems2(index, "4x2x1", component.slot4x2x1, component, false);
		this.SpawnSingleInventoryItems2(index, "2x1x3", component.slot2x1x3, component, false);
		if (index == 5 && ES3.Exists("home5InventorySaveListsTyres"))
		{
			this.home5InventorySaveListsTyres = ES3.LoadListInt("home5InventorySaveListsTyres");
		}
		if (index == 4 && ES3.Exists("home4InventorySaveListsTyres"))
		{
			this.home4InventorySaveListsTyres = ES3.LoadListInt("home4InventorySaveListsTyres");
		}
		if (index == 3 && ES3.Exists("home3InventorySaveListsTyres"))
		{
			this.home3InventorySaveListsTyres = ES3.LoadListInt("home3InventorySaveListsTyres");
		}
		if (index == 2 && ES3.Exists("home2InventorySaveListsTyres"))
		{
			this.home2InventorySaveListsTyres = ES3.LoadListInt("home2InventorySaveListsTyres");
		}
		if (index == 1 && ES3.Exists("home1InventorySaveListsTyres"))
		{
			this.home1InventorySaveListsTyres = ES3.LoadListInt("home1InventorySaveListsTyres");
		}
		this.SpawnSingleInventoryTire(component, index);
		this.ClearInventoryLoadDetails();
		bool flag = false;
		if (ES3.Exists("savedStolenGoods"))
		{
			flag = ES3.LoadBool("savedStolenGoods");
		}
		if (flag)
		{
		}
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0003AA08 File Offset: 0x00038E08
	private void CheckInventoryTire(List<int> tireList, int index, InventoryLogicC inventory)
	{
		if (tireList.Count > index)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[tireList[index]]);
			if (gameObject.GetComponent<Rigidbody>())
			{
				UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
			}
			if (gameObject.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
			{
				gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			}
			if (index == 0)
			{
				gameObject.transform.parent = inventory.wheelHolder1.transform;
			}
			if (index == 1)
			{
				gameObject.transform.parent = inventory.wheelHolder2.transform;
			}
			if (index == 2)
			{
				gameObject.transform.parent = inventory.wheelHolder3.transform;
			}
			if (index == 3)
			{
				gameObject.transform.parent = inventory.wheelHolder4.transform;
			}
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			inventory.wheelHolder1Available = false;
			gameObject.GetComponent<Collider>().isTrigger = true;
			gameObject.GetComponent<Collider>().enabled = true;
			gameObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = inventory.wheelHolder1.transform;
			if (gameObject.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
			{
				gameObject.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
				gameObject.GetComponent<EngineComponentC>().LoadPoppedTyre();
				this.componentConditions.RemoveAt(0);
			}
			inventory.AvailableSlotCount();
			inventory.UpdateInventory();
		}
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0003ABA4 File Offset: 0x00038FA4
	private void SpawnSingleInventoryTire(InventoryLogicC inventory, int index)
	{
		List<int> tireList = null;
		if (index == 1)
		{
			tireList = this.home1InventorySaveListsTyres;
		}
		if (index == 2)
		{
			tireList = this.home2InventorySaveListsTyres;
		}
		if (index == 3)
		{
			tireList = this.home3InventorySaveListsTyres;
		}
		if (index == 4)
		{
			tireList = this.home4InventorySaveListsTyres;
		}
		if (index == 5)
		{
			tireList = this.home5InventorySaveListsTyres;
		}
		this.CheckInventoryTire(tireList, 0, inventory);
		this.CheckInventoryTire(tireList, 1, inventory);
		this.CheckInventoryTire(tireList, 2, inventory);
		this.CheckInventoryTire(tireList, 3, inventory);
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0003AC20 File Offset: 0x00039020
	private void SpawnSingleInventoryItems2(int index, string stringVariable, Transform[] slots, InventoryLogicC inventory, bool checkColliders = false)
	{
		List<int> list = this.ReturnHomeInventorySaveList(stringVariable, index);
		List<int> list2 = this.ReturnHomeInventorySaveLocs(stringVariable, index);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[list[i]]);
				if (gameObject.GetComponent<Rigidbody>())
				{
					UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
				}
				if (gameObject.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
				{
					gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
				}
				gameObject.transform.parent = slots[list2[i]].transform;
				gameObject.transform.localPosition = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
				gameObject.transform.localEulerAngles = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
				slots[list2[i]].GetComponent<InventoryRelayC>().isOccupied = true;
				slots[list2[i]].GetComponent<InventoryRelayC>().StartCoroutine("Occupy");
				if (gameObject.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
				{
					gameObject.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
					gameObject.GetComponent<EngineComponentC>().UpdateCondition();
					this.componentConditions.RemoveAt(0);
				}
				gameObject.GetComponent<Collider>().isTrigger = true;
				gameObject.GetComponent<Collider>().enabled = true;
				if (checkColliders)
				{
					Collider[] components = gameObject.GetComponents<Collider>();
					foreach (Collider collider in components)
					{
						collider.isTrigger = true;
						collider.enabled = true;
					}
				}
				gameObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = slots[list2[i]];
				if (gameObject.GetComponent<ObjectPickupC>().objectID == 210)
				{
					if (this.currentBasketsInInventory.Count > 0)
					{
						for (int k = 0; k < this.currentBasketsInInventory[0]; k++)
						{
							GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.basketInventorySaveList[0]]);
							this.basketInventorySaveList.RemoveAt(0);
							if (gameObject2.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
							{
								gameObject2.transform.localScale = gameObject2.GetComponent<ObjectPickupC>().adjustScale;
							}
							gameObject.transform.GetChild(0).GetComponent<InventoryLogicC>().InstantTrigger(gameObject2);
							if (gameObject2.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
							{
								gameObject2.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
								gameObject2.GetComponent<EngineComponentC>().UpdateCondition();
								this.componentConditions.RemoveAt(0);
							}
							else if (gameObject2.GetComponent<WaterBottleLogicC>() && this.waterBottleLevels.Count > 0)
							{
								gameObject2.GetComponent<WaterBottleLogicC>().waterLevel = this.waterBottleLevels[0];
								gameObject2.GetComponent<WaterBottleLogicC>().WaterUpdate();
								this.waterBottleLevels.RemoveAt(0);
							}
							else if (gameObject2.GetComponent<OilBottleC>() && this.oilBottleLevels.Count > 0)
							{
								gameObject2.GetComponent<OilBottleC>().oilLevel = this.oilBottleLevels[0];
								gameObject2.GetComponent<OilBottleC>().OilUpdate();
								this.oilBottleLevels.RemoveAt(0);
							}
							else if (gameObject2.GetComponent<PortableFuelC>() && this.fuelCanLevels.Count > 0)
							{
								gameObject2.GetComponent<PortableFuelC>().fuelLevel = this.fuelCanLevels[0];
								gameObject2.GetComponent<PortableFuelC>().fuelMix = this.fuelCanMixs[0];
								gameObject2.GetComponent<PortableFuelC>().FuelUpdate();
								this.fuelCanLevels.RemoveAt(0);
								this.fuelCanMixs.RemoveAt(0);
							}
							if (gameObject2.GetComponent<EngineComponentC>() && this.componentCharges.Count > 0 && gameObject2.GetComponent<EngineComponentC>().isBattery)
							{
								gameObject2.GetComponent<EngineComponentC>().charge = this.componentCharges[0];
								this.componentCharges.RemoveAt(0);
							}
							if (gameObject2.GetComponent<EngineComponentC>() && this.componentWaters.Count > 0 && gameObject2.GetComponent<EngineComponentC>().totalWaterCharges > 0)
							{
								gameObject2.GetComponent<EngineComponentC>().currentWaterCharges = this.componentWaters[0];
								gameObject2.transform.GetChild(0).GetComponent<WaterSupplyRelayC>().WaterUpdate();
								this.componentWaters.RemoveAt(0);
							}
						}
					}
					if (this.currentBasketsInInventory.Count > 0)
					{
						this.currentBasketsInInventory.RemoveAt(0);
					}
				}
				inventory.AvailableSlotCount();
				inventory.UpdateInventory();
				if (gameObject.GetComponent<PortableFuelC>() && this.fuelCanLevels.Count > 0)
				{
					gameObject.GetComponent<PortableFuelC>().fuelLevel = this.fuelCanLevels[0];
					gameObject.GetComponent<PortableFuelC>().fuelMix = this.fuelCanMixs[0];
					gameObject.GetComponent<PortableFuelC>().FuelUpdate();
					this.fuelCanLevels.RemoveAt(0);
					this.fuelCanMixs.RemoveAt(0);
				}
			}
		}
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0003B184 File Offset: 0x00039584
	private void SpawnSingleInventoryItem(InventoryLogicC inventory, int index)
	{
		List<int> list = this.ReturnHomeInventorySaveList(index + 1);
		List<int> list2 = this.ReturnHomeInventorySaveLocsSingle(index + 1);
		List<int> list3 = this.ReturnHomeTradeGoodsSmall(index + 1);
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[list[i]]);
			if (gameObject.GetComponent<Rigidbody>())
			{
				UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
			}
			if (gameObject.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
			{
				gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			}
			gameObject.transform.parent = inventory.inventorySlots[list2[i]].transform;
			gameObject.transform.localPosition = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
			gameObject.transform.localEulerAngles = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
			inventory.inventorySlots[list2[i]].GetComponent<InventoryRelayC>().isOccupied = true;
			if (gameObject.GetComponent<ObjectPickupC>().dimensionY == 2)
			{
				if (inventory.inventorySlots[list2[i]].GetComponent<InventoryRelayC>().spaceAbove != null)
				{
					inventory.inventorySlots[list2[i]].GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = true;
				}
				if (gameObject.GetComponent<WaterBottleLogicC>() && this.waterBottleLevels.Count > 0)
				{
					gameObject.GetComponent<WaterBottleLogicC>().waterLevel = this.waterBottleLevels[0];
					gameObject.GetComponent<WaterBottleLogicC>().WaterUpdate();
					this.waterBottleLevels.RemoveAt(0);
				}
				else if (gameObject.GetComponent<OilBottleC>() && this.oilBottleLevels.Count > 0)
				{
					gameObject.GetComponent<OilBottleC>().oilLevel = this.oilBottleLevels[0];
					gameObject.GetComponent<OilBottleC>().OilUpdate();
					this.oilBottleLevels.RemoveAt(0);
				}
			}
			if (gameObject.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
			{
				gameObject.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
				gameObject.GetComponent<EngineComponentC>().UpdateCondition();
				this.componentConditions.RemoveAt(0);
			}
			if (gameObject.GetComponent<EngineComponentC>() && this.componentWaters.Count > 0 && gameObject.GetComponent<EngineComponentC>().totalWaterCharges > 0)
			{
				gameObject.GetComponent<EngineComponentC>().currentWaterCharges = this.componentWaters[0];
				gameObject.transform.GetChild(0).GetComponent<WaterSupplyRelayC>().WaterUpdate();
				this.componentWaters.RemoveAt(0);
			}
			gameObject.GetComponent<Collider>().isTrigger = true;
			gameObject.GetComponent<Collider>().enabled = true;
			gameObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = inventory.inventorySlots[list2[i]];
			gameObject.GetComponent<ObjectPickupC>().hasBeenTradeUpdated = true;
			if (list3.Count > 0 && list3[i] > 0 && gameObject.GetComponent<ObjectPickupC>().countryMat.Length > 0)
			{
				gameObject.GetComponent<ObjectPickupC>().startMaterial = gameObject.GetComponent<ObjectPickupC>().countryMat[list3[i]];
				gameObject.GetComponent<ObjectPickupC>().tradeGoodCountryCode = list3[i];
				gameObject.GetComponent<ObjectPickupC>().LoadRendersFromSave();
			}
			inventory.AvailableSlotCount();
			inventory.UpdateInventory();
		}
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0003B510 File Offset: 0x00039910
	private List<int> ReturnHomeInventorySaveList(int index)
	{
		if (index == 1)
		{
			return this.home1InventorySaveList;
		}
		if (index == 2)
		{
			return this.home2InventorySaveList;
		}
		if (index == 3)
		{
			return this.home3InventorySaveList;
		}
		if (index == 4)
		{
			return this.home4InventorySaveList;
		}
		if (index == 5)
		{
			return this.home5InventorySaveList;
		}
		return null;
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0003B564 File Offset: 0x00039964
	private List<int> ReturnHomeInventorySaveList(string indexString, int index)
	{
		if (index == 5)
		{
			if (indexString == "3x2x1")
			{
				return this.home5InventorySaveLists3x2x1;
			}
			if (indexString == "2x2x1")
			{
				return this.home5InventorySaveLists2x2x1;
			}
			if (indexString == "2x2x2")
			{
				return this.home5InventorySaveLists2x2x2;
			}
			if (indexString == "2x2x3")
			{
				return this.home5InventorySaveLists2x2x3;
			}
			if (indexString == "3x2x3")
			{
				return this.home5InventorySaveLists3x2x3;
			}
			if (indexString == "4x2x2")
			{
				return this.home5InventorySaveLists4x2x2;
			}
			if (indexString == "4x1x1")
			{
				return this.home5InventorySaveLists4x1x1;
			}
			if (indexString == "4x2x1")
			{
				return this.home5InventorySaveLists4x2x1;
			}
			if (indexString == "2x1x3")
			{
				return this.home5InventorySaveLists2x1x3;
			}
			if (indexString == "4x2x3")
			{
				return this.home5InventorySaveLists4x2x3;
			}
		}
		if (index == 4)
		{
			if (indexString == "3x2x1")
			{
				return this.home4InventorySaveLists3x2x1;
			}
			if (indexString == "2x2x1")
			{
				return this.home4InventorySaveLists2x2x1;
			}
			if (indexString == "2x2x2")
			{
				return this.home4InventorySaveLists2x2x2;
			}
			if (indexString == "2x2x3")
			{
				return this.home4InventorySaveLists2x2x3;
			}
			if (indexString == "3x2x3")
			{
				return this.home4InventorySaveLists3x2x3;
			}
			if (indexString == "4x2x2")
			{
				return this.home4InventorySaveLists4x2x2;
			}
			if (indexString == "4x1x1")
			{
				return this.home4InventorySaveLists4x1x1;
			}
			if (indexString == "4x2x1")
			{
				return this.home4InventorySaveLists4x2x1;
			}
			if (indexString == "2x1x3")
			{
				return this.home4InventorySaveLists2x1x3;
			}
			if (indexString == "4x2x3")
			{
				return this.home4InventorySaveLists4x2x3;
			}
		}
		if (index == 3)
		{
			if (indexString == "3x2x1")
			{
				return this.home3InventorySaveLists3x2x1;
			}
			if (indexString == "2x2x1")
			{
				return this.home3InventorySaveLists2x2x1;
			}
			if (indexString == "2x2x2")
			{
				return this.home3InventorySaveLists2x2x2;
			}
			if (indexString == "2x2x3")
			{
				return this.home3InventorySaveLists2x2x3;
			}
			if (indexString == "3x2x3")
			{
				return this.home3InventorySaveLists3x2x3;
			}
			if (indexString == "4x2x2")
			{
				return this.home3InventorySaveLists4x2x2;
			}
			if (indexString == "4x1x1")
			{
				return this.home3InventorySaveLists4x1x1;
			}
			if (indexString == "4x2x1")
			{
				return this.home3InventorySaveLists4x2x1;
			}
			if (indexString == "2x1x3")
			{
				return this.home3InventorySaveLists2x1x3;
			}
			if (indexString == "4x2x3")
			{
				return this.home3InventorySaveLists4x2x3;
			}
		}
		if (index == 2)
		{
			if (indexString == "3x2x1")
			{
				return this.home2InventorySaveLists3x2x1;
			}
			if (indexString == "2x2x1")
			{
				return this.home2InventorySaveLists2x2x1;
			}
			if (indexString == "2x2x2")
			{
				return this.home2InventorySaveLists2x2x2;
			}
			if (indexString == "2x2x3")
			{
				return this.home2InventorySaveLists2x2x3;
			}
			if (indexString == "3x2x3")
			{
				return this.home2InventorySaveLists3x2x3;
			}
			if (indexString == "4x2x2")
			{
				return this.home2InventorySaveLists4x2x2;
			}
			if (indexString == "4x1x1")
			{
				return this.home2InventorySaveLists4x1x1;
			}
			if (indexString == "4x2x1")
			{
				return this.home2InventorySaveLists4x2x1;
			}
			if (indexString == "2x1x3")
			{
				return this.home2InventorySaveLists2x1x3;
			}
			if (indexString == "4x2x3")
			{
				return this.home2InventorySaveLists4x2x3;
			}
		}
		if (index == 1)
		{
			if (indexString == "3x2x1")
			{
				return this.home1InventorySaveLists3x2x1;
			}
			if (indexString == "2x2x1")
			{
				return this.home1InventorySaveLists2x2x1;
			}
			if (indexString == "2x2x2")
			{
				return this.home1InventorySaveLists2x2x2;
			}
			if (indexString == "2x2x3")
			{
				return this.home1InventorySaveLists2x2x3;
			}
			if (indexString == "3x2x3")
			{
				return this.home1InventorySaveLists3x2x3;
			}
			if (indexString == "4x2x2")
			{
				return this.home1InventorySaveLists4x2x2;
			}
			if (indexString == "4x1x1")
			{
				return this.home1InventorySaveLists4x1x1;
			}
			if (indexString == "4x2x1")
			{
				return this.home1InventorySaveLists4x2x1;
			}
			if (indexString == "2x1x3")
			{
				return this.home1InventorySaveLists2x1x3;
			}
			if (indexString == "4x2x3")
			{
				return this.home1InventorySaveLists4x2x3;
			}
		}
		return null;
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0003BA14 File Offset: 0x00039E14
	private List<int> ReturnHomeInventorySaveLocs(string locString, int index)
	{
		if (index == 5)
		{
			if (locString == "3x2x1")
			{
				return this.home5InventorySaveLocs3x2x1;
			}
			if (locString == "2x2x1")
			{
				return this.home5InventorySaveLocs2x2x1;
			}
			if (locString == "2x2x2")
			{
				return this.home5InventorySaveLocs2x2x2;
			}
			if (locString == "2x2x3")
			{
				return this.home5InventorySaveLocs2x2x3;
			}
			if (locString == "3x2x3")
			{
				return this.home5InventorySaveLocs3x2x3;
			}
			if (locString == "4x2x2")
			{
				return this.home5InventorySaveLocs4x2x2;
			}
			if (locString == "4x1x1")
			{
				return this.home5InventorySaveLocs4x1x1;
			}
			if (locString == "4x2x1")
			{
				return this.home5InventorySaveLocs4x2x1;
			}
			if (locString == "2x1x3")
			{
				return this.home5InventorySaveLocs2x1x3;
			}
			if (locString == "4x2x3")
			{
				return this.home5InventorySaveLocs4x2x3;
			}
		}
		if (index == 4)
		{
			if (locString == "3x2x1")
			{
				return this.home4InventorySaveLocs3x2x1;
			}
			if (locString == "2x2x1")
			{
				return this.home4InventorySaveLocs2x2x1;
			}
			if (locString == "2x2x2")
			{
				return this.home4InventorySaveLocs2x2x2;
			}
			if (locString == "2x2x3")
			{
				return this.home4InventorySaveLocs2x2x3;
			}
			if (locString == "3x2x3")
			{
				return this.home4InventorySaveLocs3x2x3;
			}
			if (locString == "4x2x2")
			{
				return this.home4InventorySaveLocs4x2x2;
			}
			if (locString == "4x1x1")
			{
				return this.home4InventorySaveLocs4x1x1;
			}
			if (locString == "4x2x1")
			{
				return this.home4InventorySaveLocs4x2x1;
			}
			if (locString == "2x1x3")
			{
				return this.home4InventorySaveLocs2x1x3;
			}
			if (locString == "4x2x3")
			{
				return this.home4InventorySaveLocs4x2x3;
			}
		}
		if (index == 3)
		{
			if (locString == "3x2x1")
			{
				return this.home3InventorySaveLocs3x2x1;
			}
			if (locString == "2x2x1")
			{
				return this.home3InventorySaveLocs2x2x1;
			}
			if (locString == "2x2x2")
			{
				return this.home3InventorySaveLocs2x2x2;
			}
			if (locString == "2x2x3")
			{
				return this.home3InventorySaveLocs2x2x3;
			}
			if (locString == "3x2x3")
			{
				return this.home3InventorySaveLocs3x2x3;
			}
			if (locString == "4x2x2")
			{
				return this.home3InventorySaveLocs4x2x2;
			}
			if (locString == "4x1x1")
			{
				return this.home3InventorySaveLocs4x1x1;
			}
			if (locString == "4x2x1")
			{
				return this.home3InventorySaveLocs4x2x1;
			}
			if (locString == "2x1x3")
			{
				return this.home3InventorySaveLocs2x1x3;
			}
			if (locString == "4x2x3")
			{
				return this.home3InventorySaveLocs4x2x3;
			}
		}
		if (index == 2)
		{
			if (locString == "3x2x1")
			{
				return this.home2InventorySaveLocs3x2x1;
			}
			if (locString == "2x2x1")
			{
				return this.home2InventorySaveLocs2x2x1;
			}
			if (locString == "2x2x2")
			{
				return this.home2InventorySaveLocs2x2x2;
			}
			if (locString == "2x2x3")
			{
				return this.home2InventorySaveLocs2x2x3;
			}
			if (locString == "3x2x3")
			{
				return this.home2InventorySaveLocs3x2x3;
			}
			if (locString == "4x2x2")
			{
				return this.home2InventorySaveLocs4x2x2;
			}
			if (locString == "4x1x1")
			{
				return this.home2InventorySaveLocs4x1x1;
			}
			if (locString == "4x2x1")
			{
				return this.home2InventorySaveLocs4x2x1;
			}
			if (locString == "2x1x3")
			{
				return this.home2InventorySaveLocs2x1x3;
			}
			if (locString == "4x2x3")
			{
				return this.home2InventorySaveLocs4x2x3;
			}
		}
		if (index == 1)
		{
			if (locString == "3x2x1")
			{
				return this.home1InventorySaveLocs3x2x1;
			}
			if (locString == "2x2x1")
			{
				return this.home1InventorySaveLocs2x2x1;
			}
			if (locString == "2x2x2")
			{
				return this.home1InventorySaveLocs2x2x2;
			}
			if (locString == "2x2x3")
			{
				return this.home1InventorySaveLocs2x2x3;
			}
			if (locString == "3x2x3")
			{
				return this.home1InventorySaveLocs3x2x3;
			}
			if (locString == "4x2x2")
			{
				return this.home1InventorySaveLocs4x2x2;
			}
			if (locString == "4x1x1")
			{
				return this.home1InventorySaveLocs4x1x1;
			}
			if (locString == "4x2x1")
			{
				return this.home1InventorySaveLocs4x2x1;
			}
			if (locString == "2x1x3")
			{
				return this.home1InventorySaveLocs2x1x3;
			}
			if (locString == "4x2x3")
			{
				return this.home1InventorySaveLocs4x2x3;
			}
		}
		return null;
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0003BEC4 File Offset: 0x0003A2C4
	private List<int> ReturnHomeInventorySaveLocsSingle(int index)
	{
		if (index == 1)
		{
			return this.home1InventorySaveLocsSingle;
		}
		if (index == 2)
		{
			return this.home2InventorySaveLocsSingle;
		}
		if (index == 3)
		{
			return this.home3InventorySaveLocsSingle;
		}
		if (index == 4)
		{
			return this.home4InventorySaveLocsSingle;
		}
		if (index == 5)
		{
			return this.home5InventorySaveLocsSingle;
		}
		return null;
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0003BF18 File Offset: 0x0003A318
	private List<int> ReturnHomeTradeGoodsSmall(int index)
	{
		if (index == 1)
		{
			return this.home1InventoryTradeGoodsSmallIDSaveList;
		}
		if (index == 2)
		{
			return this.home2InventoryTradeGoodsSmallIDSaveList;
		}
		if (index == 3)
		{
			return this.home3InventoryTradeGoodsSmallIDSaveList;
		}
		if (index == 4)
		{
			return this.home4InventoryTradeGoodsSmallIDSaveList;
		}
		if (index == 5)
		{
			return this.home5InventoryTradeGoodsSmallIDSaveList;
		}
		return null;
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0003BF6C File Offset: 0x0003A36C
	private void SaveInventoryNo2(InventoryLogicC roofInventory)
	{
		this.MainSaveInventory(roofInventory, true);
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0003BF78 File Offset: 0x0003A378
	private void MainSaveInventory(InventoryLogicC inventory, bool roof)
	{
		for (int i = 0; i < inventory.inventorySlots.Length; i++)
		{
			if (inventory.inventorySlots[i].transform.childCount > 0)
			{
				if (!inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().isPurchased)
				{
					this.AddToStolenGoodsValue(inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().buyValue);
				}
				if (!roof)
				{
					this.bootInventorySaveList.Add(inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
					if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().isTradeGood)
					{
						if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 0)
						{
							this.bootInventoryTradeGoodsSmallIDSaveList.Add(0);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 1)
						{
							this.bootInventoryTradeGoodsSmallIDSaveList.Add(1);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 2)
						{
							this.bootInventoryTradeGoodsSmallIDSaveList.Add(2);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 3)
						{
							this.bootInventoryTradeGoodsSmallIDSaveList.Add(3);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 4)
						{
							this.bootInventoryTradeGoodsSmallIDSaveList.Add(4);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 5)
						{
							this.bootInventoryTradeGoodsSmallIDSaveList.Add(5);
						}
					}
					else
					{
						this.bootInventoryTradeGoodsSmallIDSaveList.Add(0);
					}
					this.DoCheckSlot(inventory.inventorySlots[i].transform);
					this.bootInventorySaveLocsSingle.Add(i);
				}
				else
				{
					this.roofInventorySaveList.Add(inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
					if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().isTradeGood)
					{
						if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 0)
						{
							this.roofInventoryTradeGoodsSmallIDSaveList.Add(0);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 1)
						{
							this.roofInventoryTradeGoodsSmallIDSaveList.Add(1);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 2)
						{
							this.roofInventoryTradeGoodsSmallIDSaveList.Add(2);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 3)
						{
							this.roofInventoryTradeGoodsSmallIDSaveList.Add(3);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 4)
						{
							this.roofInventoryTradeGoodsSmallIDSaveList.Add(4);
						}
						else if (inventory.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode == 5)
						{
							this.roofInventoryTradeGoodsSmallIDSaveList.Add(5);
						}
					}
					else
					{
						this.roofInventoryTradeGoodsSmallIDSaveList.Add(0);
					}
					this.DoCheckSlot(inventory.inventorySlots[i].transform);
					this.roofInventorySaveLocsSingle.Add(i);
				}
			}
		}
		if (!roof)
		{
			if (this.bootInventorySaveList.Count > 0)
			{
				ES3.Save(this.bootInventorySaveList, "bootInventorySaveList");
			}
			if (this.bootInventorySaveLocsSingle.Count > 0)
			{
				ES3.Save(this.bootInventorySaveLocsSingle, "bootInventorySaveLocsSingle");
			}
			if (this.bootInventoryTradeGoodsSmallIDSaveList.Count > 0)
			{
				ES3.Save(this.bootInventoryTradeGoodsSmallIDSaveList, "bootInventoryTradeGoodsSmallIDSaveList");
			}
		}
		else
		{
			if (this.roofInventorySaveList.Count > 0)
			{
				ES3.Save(this.roofInventorySaveList, "roofInventorySaveList");
			}
			if (this.roofInventorySaveLocsSingle.Count > 0)
			{
				ES3.Save(this.roofInventorySaveLocsSingle, "roofInventorySaveLocsSingle");
			}
			if (this.roofInventoryTradeGoodsSmallIDSaveList.Count > 0)
			{
				ES3.Save(this.roofInventoryTradeGoodsSmallIDSaveList, "roofInventoryTradeGoodsSmallIDSaveList");
			}
		}
		this.SaveSlots2(inventory.slot3x2x1, "3x2x1", roof);
		this.SaveSlots2(inventory.slot2x2x1, "2x2x1", roof);
		this.SaveSlots(inventory.slot2x1x2, "2x1x2", roof);
		this.SaveSlots2(inventory.slot2x2x2, "2x2x2", roof);
		this.SaveSlots2(inventory.slot2x2x3, "2x2x3", roof);
		if (!roof)
		{
			for (int j = 0; j < inventory.slot3x2x3.Length; j++)
			{
				if (inventory.slot3x2x3[j].childCount > 0)
				{
					this.SlotStringAction("3x2x3", j, inventory.slot3x2x3, false);
					if (inventory.slot3x2x3[j].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 210)
					{
						this.WoodenBasketLoop(inventory.slot3x2x3[j].transform);
					}
				}
			}
			this.SaveES2Slots("3x2x3");
		}
		else
		{
			for (int k = 0; k < inventory.slot3x2x3.Length; k++)
			{
				if (inventory.slot3x2x3[k].childCount > 0)
				{
					this.SlotStringAction("3x2x3", k, inventory.slot3x2x3, true);
					if (inventory.slot3x2x3[k].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 210)
					{
						this.WoodenBasketLoop(inventory.slot3x2x3[k].transform);
					}
				}
			}
			this.SaveES2SlotsRoof("3x2x3");
		}
		this.SaveSlots(inventory.slot4x2x2, "4x2x2", roof);
		this.SaveSlots2(inventory.slot4x2x3, "4x2x3", roof);
		this.SaveSlots(inventory.slot4x1x1, "4x1x1", roof);
		this.SaveSlots(inventory.slot4x2x1, "4x2x1", roof);
		this.SaveSlots(inventory.slot2x1x3, "2x1x3", roof);
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0003C5F8 File Offset: 0x0003A9F8
	private void WoodenBasketLoop(Transform target)
	{
		Transform child = target.transform.GetChild(0).transform.GetChild(0);
		this.currentBasketsInInventory.Add(0);
		InventoryLogicC componentInChildren = child.GetComponentInChildren<InventoryLogicC>();
		this.MainBasketLoop(componentInChildren.inventorySlots.Length, componentInChildren.inventorySlots);
		this.MainBasketLoop(componentInChildren.slot2x2x1.Length, componentInChildren.slot2x2x1);
		this.MainBasketLoop(componentInChildren.slot2x2x2.Length, componentInChildren.slot2x2x2);
		this.MainBasketLoop(componentInChildren.slot2x2x3.Length, componentInChildren.slot2x2x3);
		for (int i = 0; i < componentInChildren.slot2x1x2.Length; i++)
		{
			IEnumerator enumerator = componentInChildren.slot2x1x2[i].transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					this.basketInventorySaveList.Add(transform.GetComponent<ObjectPickupC>().objectID);
					List<int> list;
					int index;
					(list = this.currentBasketsInInventory)[index = this.currentBasketsInInventory.Count - 1] = list[index] + 1;
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
		}
		ES3.Save(this.basketInventorySaveList, "basketInventorySaveList");
		ES3.Save(this.currentBasketsInInventory, "currentBasketsInInventory");
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0003C758 File Offset: 0x0003AB58
	private void SaveES2SlotsRoof(string slotString)
	{
		if (this.ReturnBootSaveList(slotString, true) != null && this.ReturnBootSaveList(slotString, true).Count > 0)
		{
			ES3.Save(this.ReturnBootSaveList(slotString, true), "roofInventorySaveLists" + slotString);
		}
		if (this.ReturnBootSaveLocs(slotString, true) != null && this.ReturnBootSaveLocs(slotString, true).Count > 0)
		{
			ES3.Save(this.ReturnBootSaveLocs(slotString, true), "roofInventorySaveLocs" + slotString);
		}
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0003C7D5 File Offset: 0x0003ABD5
	private void SaveInventoryNo1(InventoryLogicC inventory)
	{
		this.MainSaveInventory(inventory, false);
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0003C7E0 File Offset: 0x0003ABE0
	private void DoCheckSlot(Transform slot)
	{
		if (slot.transform.childCount < 1)
		{
			return;
		}
		if (slot.transform.GetChild(0).GetComponent<EngineComponentC>())
		{
			this.componentConditions.Add(slot.transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
			ES3.Save(this.componentConditions, "componentConditions");
		}
		if (slot.transform.GetChild(0).GetComponent<EngineComponentC>() && slot.transform.GetChild(0).GetComponent<EngineComponentC>().totalFuelAmount > 0f)
		{
			this.componentFuels.Add(slot.transform.GetChild(0).GetComponent<EngineComponentC>().currentFuelAmount);
			this.componentFuelMixs.Add(slot.transform.GetChild(0).GetComponent<EngineComponentC>().fuelMix);
			ES3.Save(this.componentFuels, "componentFuels");
			ES3.Save(this.componentFuelMixs, "componentFuelMixs");
		}
		if (slot.transform.GetChild(0).GetComponent<EngineComponentC>() && slot.transform.GetChild(0).GetComponent<EngineComponentC>().totalWaterCharges > 0)
		{
			this.componentWaters.Add(slot.transform.GetChild(0).GetComponent<EngineComponentC>().currentWaterCharges);
			ES3.Save(this.componentWaters, "componentWaters");
		}
		if (slot.transform.GetChild(0).GetComponent<ObjectPickupC>() && slot.transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 158)
		{
			this.fuelCanLevels.Add(slot.transform.GetChild(0).GetComponent<PortableFuelC>().fuelLevel);
			this.fuelCanMixs.Add(slot.transform.GetChild(0).GetComponent<PortableFuelC>().fuelMix);
			ES3.Save(this.fuelCanLevels, "fuelCanLevels");
			ES3.Save(this.fuelCanMixs, "fuelCanMixs");
		}
		if (slot.transform.GetChild(0).GetComponent<EngineComponentC>() && slot.transform.GetChild(0).GetComponent<EngineComponentC>().isBattery)
		{
			this.componentCharges.Add(slot.transform.GetChild(0).GetComponent<EngineComponentC>().charge);
			ES3.Save(this.componentCharges, "componentCharges");
		}
		if (slot.transform.GetChild(0).GetComponent<ObjectPickupC>() && slot.transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 159)
		{
			this.waterBottleLevels.Add(slot.transform.GetChild(0).GetComponent<WaterBottleLogicC>().waterLevel);
			ES3.Save(this.waterBottleLevels, "waterBottleLevels");
		}
		if (slot.transform.GetChild(0).GetComponent<ObjectPickupC>() && slot.transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 157)
		{
			this.oilBottleLevels.Add(slot.transform.GetChild(0).GetComponent<OilBottleC>().oilLevel);
			ES3.Save(this.oilBottleLevels, "oilBottleLevels");
		}
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0003CB2C File Offset: 0x0003AF2C
	private void MainBasketLoop(int length, GameObject[] parents)
	{
		for (int i = 0; i < length; i++)
		{
			IEnumerator enumerator = parents[i].transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform child = (Transform)obj;
					this.BasketLoop1(child);
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
		}
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0003CBA8 File Offset: 0x0003AFA8
	private void MainBasketLoop(int length, Transform[] parents)
	{
		for (int i = 0; i < length; i++)
		{
			IEnumerator enumerator = parents[i].GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform child = (Transform)obj;
					this.BasketLoop1(child);
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
		}
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0003CC1C File Offset: 0x0003B01C
	private void BasketLoop1(Transform child)
	{
		this.basketInventorySaveList.Add(child.GetComponent<ObjectPickupC>().objectID);
		List<int> list;
		int index;
		(list = this.currentBasketsInInventory)[index = this.currentBasketsInInventory.Count - 1] = list[index] + 1;
		if (child.GetComponent<EngineComponentC>())
		{
			this.componentConditions.Add(child.GetComponent<EngineComponentC>().Condition);
			ES3.Save(this.componentConditions, "componentConditions");
		}
		if (child.GetComponent<ObjectPickupC>().objectID == 159)
		{
			this.waterBottleLevels.Add(child.GetComponent<WaterBottleLogicC>().waterLevel);
			ES3.Save(this.waterBottleLevels, "waterBottleLevels");
		}
		if (child.GetComponent<ObjectPickupC>().objectID == 157)
		{
			this.oilBottleLevels.Add(child.GetComponent<OilBottleC>().oilLevel);
			ES3.Save(this.oilBottleLevels, "oilBottleLevels");
		}
		if (child.GetComponent<ObjectPickupC>().objectID == 158)
		{
			this.fuelCanLevels.Add(child.GetComponent<PortableFuelC>().fuelLevel);
			this.fuelCanMixs.Add(child.GetComponent<PortableFuelC>().fuelMix);
			ES3.Save(this.fuelCanLevels, "fuelCanLevels");
			ES3.Save(this.fuelCanMixs, "fuelCanMixs");
		}
		if (child.GetComponent<EngineComponentC>() && child.GetComponent<EngineComponentC>().totalWaterCharges > 0)
		{
			this.componentWaters.Add(child.GetComponent<EngineComponentC>().currentWaterCharges);
			ES3.Save(this.componentWaters, "componentWaters");
		}
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0003CDB8 File Offset: 0x0003B1B8
	private void SaveES2Slots(string slotString)
	{
		if (this.ReturnBootSaveList(slotString, false).Count > 0)
		{
			ES3.Save(this.ReturnBootSaveList(slotString, false), "bootInventorySaveLists" + slotString);
		}
		if (this.ReturnBootSaveLocs(slotString, false).Count > 0)
		{
			ES3.Save(this.ReturnBootSaveLocs(slotString, false), "bootInventorySaveLocs" + slotString);
		}
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x0003CE1C File Offset: 0x0003B21C
	private void SaveSlots(Transform[] slots, string slotString, bool roof = false)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].childCount > 0)
			{
				this.SlotStringAction(slotString, i, slots, roof);
			}
		}
		if (roof)
		{
			this.SaveES2SlotsRoof(slotString);
		}
		else
		{
			this.SaveES2Slots(slotString);
		}
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0003CE70 File Offset: 0x0003B270
	private void SaveSlots2(Transform[] slots, string slotString, bool roof = false)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].childCount > 0)
			{
				this.SlotStringAction(slotString, i, slots, roof);
				this.DoCheckSlot(slots[i].transform.GetChild(0));
			}
		}
		if (roof)
		{
			this.SaveES2SlotsRoof(slotString);
		}
		else
		{
			this.SaveES2Slots(slotString);
		}
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x0003CED8 File Offset: 0x0003B2D8
	private List<int> ReturnBootSaveLocs(string slotString, bool roof = false)
	{
		if (roof)
		{
			if (slotString == "2x1x3")
			{
				return this.roofInventorySaveLocs2x1x3;
			}
			if (slotString == "4x2x1")
			{
				return this.roofInventorySaveLocs4x2x1;
			}
			if (slotString == "4x1x1")
			{
				return this.roofInventorySaveLocs4x1x1;
			}
			if (slotString == "4x2x3")
			{
				return this.roofInventorySaveLocs4x2x3;
			}
			if (slotString == "3x2x3")
			{
				return this.roofInventorySaveLocs3x2x3;
			}
			if (slotString == "2x2x3")
			{
				return this.roofInventorySaveLocs2x2x3;
			}
			if (slotString == "2x2x2")
			{
				return this.roofInventorySaveLocs2x2x2;
			}
			if (slotString == "2x1x2")
			{
				return this.roofInventorySaveLocs2x1x2;
			}
			if (slotString == "2x2x1")
			{
				return this.roofInventorySaveLocs2x2x1;
			}
			if (slotString == "3x2x1")
			{
				return this.roofInventorySaveLocs3x2x1;
			}
		}
		else
		{
			if (slotString == "2x1x3")
			{
				return this.bootInventorySaveLocs2x1x3;
			}
			if (slotString == "4x2x1")
			{
				return this.bootInventorySaveLocs4x2x1;
			}
			if (slotString == "4x2x2")
			{
				return this.bootInventorySaveLocs4x2x2;
			}
			if (slotString == "4x1x1")
			{
				return this.bootInventorySaveLocs4x1x1;
			}
			if (slotString == "4x2x3")
			{
				return this.bootInventorySaveLocs4x2x3;
			}
			if (slotString == "3x2x3")
			{
				return this.bootInventorySaveLocs3x2x3;
			}
			if (slotString == "2x2x3")
			{
				return this.bootInventorySaveLocs2x2x3;
			}
			if (slotString == "2x2x2")
			{
				return this.bootInventorySaveLocs2x2x2;
			}
			if (slotString == "2x1x2")
			{
				return this.bootInventorySaveLocs2x1x2;
			}
			if (slotString == "2x2x1")
			{
				return this.bootInventorySaveLocs2x2x1;
			}
			if (slotString == "3x2x1")
			{
				return this.bootInventorySaveLocs3x2x1;
			}
		}
		return null;
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x0003D0D4 File Offset: 0x0003B4D4
	private List<int> ReturnBootSaveList(string slotString, bool roof = false)
	{
		if (roof)
		{
			if (slotString == "2x1x3")
			{
				return this.roofInventorySaveLists2x1x3;
			}
			if (slotString == "4x2x1")
			{
				return this.roofInventorySaveLists4x2x1;
			}
			if (slotString == "4x2x2")
			{
				return this.roofInventorySaveLists4x2x2;
			}
			if (slotString == "4x1x1")
			{
				return this.roofInventorySaveLists4x1x1;
			}
			if (slotString == "4x2x3")
			{
				return this.roofInventorySaveLists4x2x3;
			}
			if (slotString == "3x2x3")
			{
				return this.roofInventorySaveLists3x2x3;
			}
			if (slotString == "2x2x3")
			{
				return this.roofInventorySaveLists2x2x3;
			}
			if (slotString == "2x2x2")
			{
				return this.roofInventorySaveLists2x2x2;
			}
			if (slotString == "2x1x2")
			{
				return this.roofInventorySaveLists2x1x2;
			}
			if (slotString == "2x2x1")
			{
				return this.roofInventorySaveLists2x2x1;
			}
			if (slotString == "3x2x1")
			{
				return this.roofInventorySaveLists3x2x1;
			}
		}
		else
		{
			if (slotString == "2x1x3")
			{
				return this.bootInventorySaveLists2x1x3;
			}
			if (slotString == "4x2x1")
			{
				return this.bootInventorySaveLists4x2x1;
			}
			if (slotString == "4x2x2")
			{
				return this.bootInventorySaveLists4x2x2;
			}
			if (slotString == "4x1x1")
			{
				return this.bootInventorySaveLists4x1x1;
			}
			if (slotString == "4x2x3")
			{
				return this.bootInventorySaveLists4x2x3;
			}
			if (slotString == "3x2x3")
			{
				return this.bootInventorySaveLists3x2x3;
			}
			if (slotString == "2x2x3")
			{
				return this.bootInventorySaveLists2x2x3;
			}
			if (slotString == "2x2x2")
			{
				return this.bootInventorySaveLists2x2x2;
			}
			if (slotString == "2x1x2")
			{
				return this.bootInventorySaveLists2x1x2;
			}
			if (slotString == "2x2x1")
			{
				return this.bootInventorySaveLists2x2x1;
			}
			if (slotString == "3x2x1")
			{
				return this.bootInventorySaveLists3x2x1;
			}
		}
		return null;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0003D2E8 File Offset: 0x0003B6E8
	private void SlotStringAction(string slotString, int index, Transform[] slots, bool roof = false)
	{
		if (!slots[index].transform.GetChild(0).GetComponent<ObjectPickupC>().isPurchased)
		{
			this.AddToStolenGoodsValue(slots[index].transform.GetChild(0).GetComponent<ObjectPickupC>().buyValue);
		}
		this.ReturnBootSaveList(slotString, roof).Add(slots[index].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
		this.ReturnBootSaveLocs(slotString, roof).Add(index);
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0003D368 File Offset: 0x0003B768
	private void UpdateJunk(GameObject junkObject, Transform parentTransform, bool last = false)
	{
		InventoryLogicC component = this.carLogic.GetComponent<CarLogicC>().bootInventory.GetComponent<InventoryLogicC>();
		if (junkObject.GetComponent<Rigidbody>())
		{
			UnityEngine.Object.Destroy(junkObject.GetComponent<Rigidbody>());
		}
		junkObject.transform.parent = parentTransform;
		if (!last)
		{
			junkObject.transform.localPosition = junkObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
			junkObject.transform.localEulerAngles = junkObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
			parentTransform.GetComponent<InventoryRelayC>().isOccupied = true;
			parentTransform.GetComponent<InventoryRelayC>().StartCoroutine("Occupy");
		}
		else
		{
			if (junkObject.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
			{
				junkObject.transform.localScale = junkObject.GetComponent<ObjectPickupC>().adjustScale;
			}
			junkObject.transform.localPosition = new Vector3(-1.594501f, -1.673794f, -0.2081873f);
			junkObject.transform.localEulerAngles = new Vector3(40.99137f, -88.95309f, -91.36813f);
		}
		this.carLogic.GetComponent<CarPerformanceC>().carBootWeight += junkObject.GetComponent<ObjectPickupC>().rigidMass;
		this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += junkObject.GetComponent<ObjectPickupC>().rigidMass;
		junkObject.GetComponent<Collider>().isTrigger = true;
		junkObject.GetComponent<Collider>().enabled = true;
		junkObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = parentTransform.transform;
		component.GetComponent<InventoryLogicC>().wheelHolder1Available = false;
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0003D4F0 File Offset: 0x0003B8F0
	private void LoadLogic(GameObject spawned, InventoryLogicC inventory, Transform targetTransform, int id)
	{
		if (spawned.GetComponent<Rigidbody>())
		{
			UnityEngine.Object.Destroy(spawned.GetComponent<Rigidbody>());
		}
		if (spawned.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
		{
			spawned.transform.localScale = spawned.GetComponent<ObjectPickupC>().adjustScale;
		}
		spawned.transform.parent = targetTransform;
		spawned.transform.localPosition = spawned.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		spawned.transform.localEulerAngles = spawned.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
		this.carLogic.GetComponent<CarPerformanceC>().carBootWeight += spawned.GetComponent<ObjectPickupC>().rigidMass;
		this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += spawned.GetComponent<ObjectPickupC>().rigidMass;
		targetTransform.GetComponent<InventoryRelayC>().isOccupied = true;
		this.SpawnedObjectCheck(spawned, inventory, id);
		spawned.GetComponent<Collider>().isTrigger = true;
		spawned.GetComponent<Collider>().enabled = true;
		spawned.GetComponent<ObjectPickupC>().inventoryPlacedAt = targetTransform.transform;
		inventory.AvailableSlotCount();
		inventory.UpdateInventory();
		targetTransform.GetComponent<InventoryRelayC>().StartCoroutine("Occupy");
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x0003D620 File Offset: 0x0003BA20
	private void LoadLogic2(GameObject spawned11, InventoryLogicC inventory, bool first = true)
	{
		if (spawned11.GetComponent<Rigidbody>())
		{
			UnityEngine.Object.Destroy(spawned11.GetComponent<Rigidbody>());
		}
		if (spawned11.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
		{
			spawned11.transform.localScale = spawned11.GetComponent<ObjectPickupC>().adjustScale;
		}
		if (first)
		{
			spawned11.transform.parent = inventory.wheelHolder1.transform;
		}
		else
		{
			spawned11.transform.parent = inventory.wheelHolder2.transform;
		}
		spawned11.transform.localPosition = Vector3.zero;
		spawned11.transform.localEulerAngles = Vector3.zero;
		spawned11.transform.localScale = Vector3.one;
		this.carLogic.GetComponent<CarPerformanceC>().carBootWeight += spawned11.GetComponent<ObjectPickupC>().rigidMass;
		this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += spawned11.GetComponent<ObjectPickupC>().rigidMass;
		if (first)
		{
			inventory.GetComponent<InventoryLogicC>().wheelHolder1Available = false;
		}
		else
		{
			inventory.GetComponent<InventoryLogicC>().wheelHolder2Available = false;
		}
		spawned11.GetComponent<Collider>().isTrigger = true;
		spawned11.GetComponent<Collider>().enabled = true;
		if (first)
		{
			spawned11.GetComponent<ObjectPickupC>().inventoryPlacedAt = inventory.wheelHolder1.transform;
		}
		else
		{
			spawned11.GetComponent<ObjectPickupC>().inventoryPlacedAt = inventory.wheelHolder2.transform;
		}
		if (spawned11.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
		{
			spawned11.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
			spawned11.GetComponent<EngineComponentC>().LoadPoppedTyre();
			this.componentConditions.RemoveAt(0);
		}
		inventory.AvailableSlotCount();
		inventory.UpdateInventory();
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x0003D7F0 File Offset: 0x0003BBF0
	private void SpawnedObjectCheck(GameObject spawned1, InventoryLogicC inventory, int id)
	{
		if (this.componentWaters == null)
		{
			this.componentWaters = new List<int>();
		}
		if (this.componentCharges == null)
		{
			this.componentCharges = new List<float>();
		}
		if (this.componentFuels == null)
		{
			this.componentFuels = new List<float>();
		}
		if (spawned1.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
		{
			spawned1.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
			spawned1.GetComponent<EngineComponentC>().UpdateCondition();
			this.componentConditions.RemoveAt(0);
		}
		if (spawned1.GetComponent<EngineComponentC>() && this.componentWaters.Count > 0 && spawned1.GetComponent<EngineComponentC>().totalWaterCharges > 0)
		{
			spawned1.GetComponent<EngineComponentC>().currentWaterCharges = this.componentWaters[0];
			spawned1.transform.GetChild(0).GetComponent<WaterSupplyRelayC>().WaterUpdate();
			this.componentWaters.RemoveAt(0);
		}
		if (spawned1.GetComponent<EngineComponentC>() && this.componentCharges.Count > 0 && spawned1.GetComponent<EngineComponentC>().isBattery)
		{
			spawned1.GetComponent<EngineComponentC>().charge = this.componentCharges[0];
			this.componentCharges.RemoveAt(0);
		}
		if (spawned1.GetComponent<EngineComponentC>() && this.componentFuels.Count > 0 && spawned1.GetComponent<EngineComponentC>().totalFuelAmount > 0f)
		{
			spawned1.GetComponent<EngineComponentC>().currentFuelAmount = this.componentFuels[0];
			spawned1.GetComponent<EngineComponentC>().fuelMix = this.componentFuelMixs[0];
			this.componentFuels.RemoveAt(0);
			this.componentFuelMixs.RemoveAt(0);
		}
		if (this.roofInventorySaveLocsSingle == null)
		{
			this.roofInventorySaveLocsSingle = new List<int>();
		}
		if (spawned1.GetComponent<ObjectPickupC>().dimensionY == 2)
		{
			if (inventory.inventorySlots.Length <= this.roofInventorySaveLocsSingle.Count && inventory.inventorySlots[this.roofInventorySaveLocsSingle[id]].GetComponent<InventoryRelayC>().spaceAbove != null)
			{
				inventory.inventorySlots[this.roofInventorySaveLocsSingle[id]].GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = true;
			}
			if (spawned1.GetComponent<WaterBottleLogicC>() && this.waterBottleLevels.Count > 0)
			{
				spawned1.GetComponent<WaterBottleLogicC>().waterLevel = this.waterBottleLevels[0];
				spawned1.GetComponent<WaterBottleLogicC>().WaterUpdate();
				this.waterBottleLevels.RemoveAt(0);
			}
			else if (spawned1.GetComponent<OilBottleC>() && this.oilBottleLevels.Count > 0)
			{
				spawned1.GetComponent<OilBottleC>().oilLevel = this.oilBottleLevels[0];
				spawned1.GetComponent<OilBottleC>().OilUpdate();
				this.oilBottleLevels.RemoveAt(0);
			}
		}
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x0003DAFC File Offset: 0x0003BEFC
	private void UpdateColliders(GameObject colliderHolder)
	{
		Collider[] components = colliderHolder.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0003DB38 File Offset: 0x0003BF38
	private IEnumerator LoadBootInventory()
	{
		InventoryLogicC inventory = this.carLogic.GetComponent<CarLogicC>().bootInventory.GetComponent<InventoryLogicC>();
		bool theif = false;
		if (ES3.Exists("savedStolenGoods"))
		{
			theif = ES3.LoadBool("savedStolenGoods");
		}
		if (theif)
		{
			GameObject junkObject = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[171]);
			this.UpdateJunk(junkObject, inventory.slot4x2x3[0].transform, false);
			GameObject junkObject2 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[171]);
			this.UpdateJunk(junkObject2, inventory.slot4x2x3[1].transform, false);
			GameObject junkObject3 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[172]);
			this.UpdateJunk(junkObject3, inventory.wheelHolder1.transform, true);
			inventory.AvailableSlotCount();
			inventory.UpdateInventory();
		}
		else
		{
			if (ES3.Exists("basketInventorySaveList"))
			{
				this.basketInventorySaveList = ES3.LoadListInt("basketInventorySaveList");
			}
			if (ES3.Exists("currentBasketsInInventory"))
			{
				this.currentBasketsInInventory = ES3.LoadListInt("currentBasketsInInventory");
			}
			if (ES3.Exists("waterBottleLevels"))
			{
				this.waterBottleLevels = ES3.LoadListInt("waterBottleLevels");
			}
			if (ES3.Exists("fuelCanLevels"))
			{
				this.fuelCanLevels = ES3.LoadListInt("fuelCanLevels");
			}
			if (ES3.Exists("fuelCanMixs"))
			{
				this.fuelCanMixs = ES3.LoadListInt("fuelCanMixs");
			}
			if (ES3.Exists("oilBottleLevels"))
			{
				this.oilBottleLevels = ES3.LoadListInt("oilBottleLevels");
			}
			if (ES3.Exists("componentConditions"))
			{
				this.componentConditions = ES3.LoadListFloat("componentConditions");
			}
			if (ES3.Exists("componentFuels"))
			{
				this.componentFuels = ES3.LoadListFloat("componentFuels");
			}
			if (ES3.Exists("componentFuelMixs"))
			{
				this.componentFuelMixs = ES3.LoadListInt("componentFuelMixs");
			}
			if (ES3.Exists("componentCharges"))
			{
				this.componentCharges = ES3.LoadListFloat("componentCharges");
			}
			if (ES3.Exists("componentWaters"))
			{
				this.componentWaters = ES3.LoadListInt("componentWaters");
			}
			if (ES3.Exists("bootInventorySaveList"))
			{
				this.bootInventorySaveList = ES3.LoadListInt("bootInventorySaveList");
			}
			if (ES3.Exists("bootInventorySaveLocsSingle"))
			{
				this.bootInventorySaveLocsSingle = ES3.LoadListInt("bootInventorySaveLocsSingle");
			}
			if (ES3.Exists("bootInventoryTradeGoodsSmallIDSaveList"))
			{
				this.bootInventoryTradeGoodsSmallIDSaveList = ES3.LoadListInt("bootInventoryTradeGoodsSmallIDSaveList");
			}
			for (int j = 0; j < this.bootInventorySaveList.Count; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveList[j]]);
				this.LoadLogic(gameObject, inventory, inventory.inventorySlots[this.bootInventorySaveLocsSingle[j]].transform, j);
				if (gameObject.GetComponent<ObjectPickupC>().dimensionY == 2)
				{
					if (inventory.inventorySlots[this.bootInventorySaveLocsSingle[j]].GetComponent<InventoryRelayC>().spaceAbove != null)
					{
						inventory.inventorySlots[this.bootInventorySaveLocsSingle[j]].GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = true;
					}
					if (gameObject.GetComponent<WaterBottleLogicC>() && this.waterBottleLevels.Count > 0)
					{
						gameObject.GetComponent<WaterBottleLogicC>().waterLevel = this.waterBottleLevels[0];
						gameObject.GetComponent<WaterBottleLogicC>().WaterUpdate();
						this.waterBottleLevels.RemoveAt(0);
					}
					else if (gameObject.GetComponent<OilBottleC>() && this.oilBottleLevels.Count > 0)
					{
						gameObject.GetComponent<OilBottleC>().oilLevel = this.oilBottleLevels[0];
						gameObject.GetComponent<OilBottleC>().OilUpdate();
						this.oilBottleLevels.RemoveAt(0);
					}
				}
				if (gameObject.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
				{
					gameObject.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
					gameObject.GetComponent<EngineComponentC>().UpdateCondition();
					this.componentConditions.RemoveAt(0);
				}
				if (gameObject.GetComponent<EngineComponentC>() && this.componentWaters.Count > 0 && gameObject.GetComponent<EngineComponentC>().totalWaterCharges > 0)
				{
					gameObject.GetComponent<EngineComponentC>().currentWaterCharges = this.componentWaters[0];
					gameObject.transform.GetChild(0).GetComponent<WaterSupplyRelayC>().WaterUpdate();
					this.componentWaters.RemoveAt(0);
				}
				gameObject.GetComponent<Collider>().isTrigger = true;
				gameObject.GetComponent<Collider>().enabled = true;
				gameObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = inventory.inventorySlots[this.bootInventorySaveLocsSingle[j]];
				gameObject.GetComponent<ObjectPickupC>().hasBeenTradeUpdated = true;
				if (this.bootInventoryTradeGoodsSmallIDSaveList.Count > 0 && this.bootInventoryTradeGoodsSmallIDSaveList[j] > 0 && gameObject.GetComponent<ObjectPickupC>().countryMat.Length > 0)
				{
					gameObject.GetComponent<ObjectPickupC>().startMaterial = gameObject.GetComponent<ObjectPickupC>().countryMat[this.bootInventoryTradeGoodsSmallIDSaveList[j]];
					gameObject.GetComponent<ObjectPickupC>().tradeGoodCountryCode = this.bootInventoryTradeGoodsSmallIDSaveList[j];
					gameObject.GetComponent<ObjectPickupC>().LoadRendersFromSave();
				}
				inventory.AvailableSlotCount();
				inventory.UpdateInventory();
			}
			if (ES3.Exists("bootInventorySaveLists3x2x1"))
			{
				this.bootInventorySaveLists3x2x1 = ES3.LoadListInt("bootInventorySaveLists3x2x1");
			}
			if (ES3.Exists("bootInventorySaveLocs3x2x1"))
			{
				this.bootInventorySaveLocs3x2x1 = ES3.LoadListInt("bootInventorySaveLocs3x2x1");
			}
			if (ES3.Exists("bootInventorySaveLists2x2x1"))
			{
				this.bootInventorySaveLists2x2x1 = ES3.LoadListInt("bootInventorySaveLists2x2x1");
			}
			if (ES3.Exists("bootInventorySaveLocs2x2x1"))
			{
				this.bootInventorySaveLocs2x2x1 = ES3.LoadListInt("bootInventorySaveLocs2x2x1");
			}
			if (ES3.Exists("bootInventorySaveLists2x2x2"))
			{
				this.bootInventorySaveLists2x2x2 = ES3.LoadListInt("bootInventorySaveLists2x2x2");
			}
			if (ES3.Exists("bootInventorySaveLocs2x2x2"))
			{
				this.bootInventorySaveLocs2x2x2 = ES3.LoadListInt("bootInventorySaveLocs2x2x2");
			}
			if (ES3.Exists("bootInventorySaveLists2x2x3"))
			{
				this.bootInventorySaveLists2x2x3 = ES3.LoadListInt("bootInventorySaveLists2x2x3");
			}
			if (ES3.Exists("bootInventorySaveLocs2x2x3"))
			{
				this.bootInventorySaveLocs2x2x3 = ES3.LoadListInt("bootInventorySaveLocs2x2x3");
			}
			if (ES3.Exists("bootInventorySaveLists3x2x3"))
			{
				this.bootInventorySaveLists3x2x3 = ES3.LoadListInt("bootInventorySaveLists3x2x3");
			}
			if (ES3.Exists("bootInventorySaveLocs3x2x3"))
			{
				this.bootInventorySaveLocs3x2x3 = ES3.LoadListInt("bootInventorySaveLocs3x2x3");
			}
			if (ES3.Exists("bootInventorySaveLists4x2x2"))
			{
				this.bootInventorySaveLists4x2x2 = ES3.LoadListInt("bootInventorySaveLists4x2x2");
			}
			if (ES3.Exists("bootInventorySaveLocs4x2x2"))
			{
				this.bootInventorySaveLocs4x2x2 = ES3.LoadListInt("bootInventorySaveLocs4x2x2");
			}
			if (ES3.Exists("bootInventorySaveLists4x2x3"))
			{
				this.bootInventorySaveLists4x2x3 = ES3.LoadListInt("bootInventorySaveLists4x2x3");
			}
			if (ES3.Exists("bootInventorySaveLocs4x2x3"))
			{
				this.bootInventorySaveLocs4x2x3 = ES3.LoadListInt("bootInventorySaveLocs4x2x3");
			}
			if (ES3.Exists("bootInventorySaveLists4x1x1"))
			{
				this.bootInventorySaveLists4x1x1 = ES3.LoadListInt("bootInventorySaveLists4x1x1");
			}
			if (ES3.Exists("bootInventorySaveLocs4x1x1"))
			{
				this.bootInventorySaveLocs4x1x1 = ES3.LoadListInt("bootInventorySaveLocs4x1x1");
			}
			if (ES3.Exists("bootInventorySaveLists4x2x1"))
			{
				this.bootInventorySaveLists4x2x1 = ES3.LoadListInt("bootInventorySaveLists4x2x1");
			}
			if (ES3.Exists("bootInventorySaveLocs4x2x1"))
			{
				this.bootInventorySaveLocs4x2x1 = ES3.LoadListInt("bootInventorySaveLocs4x2x1");
			}
			if (ES3.Exists("bootInventorySaveLists2x1x3"))
			{
				this.bootInventorySaveLists2x1x3 = ES3.LoadListInt("bootInventorySaveLists2x1x3");
			}
			if (ES3.Exists("bootInventorySaveLocs2x1x3"))
			{
				this.bootInventorySaveLocs2x1x3 = ES3.LoadListInt("bootInventorySaveLocs2x1x3");
			}
			if (ES3.Exists("bootInventorySaveListsTyres"))
			{
				this.bootInventorySaveListsTyres = ES3.LoadListInt("bootInventorySaveListsTyres");
			}
			if (ES3.Exists("roofInventorySaveList"))
			{
				this.roofInventorySaveList = ES3.LoadListInt("roofInventorySaveList");
			}
			if (ES3.Exists("roofInventorySaveLocsSingle"))
			{
				this.roofInventorySaveLocsSingle = ES3.LoadListInt("roofInventorySaveLocsSingle");
			}
			if (ES3.Exists("roofInventoryTradeGoodsSmallIDSaveList"))
			{
				this.roofInventoryTradeGoodsSmallIDSaveList = ES3.LoadListInt("roofInventoryTradeGoodsSmallIDSaveList");
			}
			if (ES3.Exists("roofInventorySaveLists3x2x1"))
			{
				this.roofInventorySaveLists3x2x1 = ES3.LoadListInt("roofInventorySaveLists3x2x1");
			}
			if (ES3.Exists("roofInventorySaveLocs3x2x1"))
			{
				this.roofInventorySaveLocs3x2x1 = ES3.LoadListInt("roofInventorySaveLocs3x2x1");
			}
			if (ES3.Exists("roofInventorySaveLists2x2x1"))
			{
				this.roofInventorySaveLists2x2x1 = ES3.LoadListInt("roofInventorySaveLists2x2x1");
			}
			if (ES3.Exists("roofInventorySaveLocs2x2x1"))
			{
				this.roofInventorySaveLocs2x2x1 = ES3.LoadListInt("roofInventorySaveLocs2x2x1");
			}
			if (ES3.Exists("roofInventorySaveLists2x2x3"))
			{
				this.roofInventorySaveLists2x2x3 = ES3.LoadListInt("roofInventorySaveLists2x2x3");
			}
			if (ES3.Exists("roofInventorySaveLocs2x2x3"))
			{
				this.roofInventorySaveLocs2x2x3 = ES3.LoadListInt("roofInventorySaveLocs2x2x3");
			}
			if (ES3.Exists("roofInventorySaveLists2x2x2"))
			{
				this.roofInventorySaveLists2x2x2 = ES3.LoadListInt("roofInventorySaveLists2x2x2");
			}
			if (ES3.Exists("roofInventorySaveLocs2x2x2"))
			{
				this.roofInventorySaveLocs2x2x2 = ES3.LoadListInt("roofInventorySaveLocs2x2x2");
			}
			if (ES3.Exists("roofInventorySaveLists3x2x3"))
			{
				this.roofInventorySaveLists3x2x3 = ES3.LoadListInt("roofInventorySaveLists3x2x3");
			}
			if (ES3.Exists("roofInventorySaveLocs3x2x3"))
			{
				this.roofInventorySaveLocs3x2x3 = ES3.LoadListInt("roofInventorySaveLocs3x2x3");
			}
			if (ES3.Exists("roofInventorySaveLists4x2x2"))
			{
				this.roofInventorySaveLists4x2x2 = ES3.LoadListInt("roofInventorySaveLists4x2x2");
			}
			if (ES3.Exists("roofInventorySaveLocs4x2x2"))
			{
				this.roofInventorySaveLocs4x2x2 = ES3.LoadListInt("roofInventorySaveLocs4x2x2");
			}
			if (ES3.Exists("roofInventorySaveLists4x2x3"))
			{
				this.roofInventorySaveLists4x2x3 = ES3.LoadListInt("roofInventorySaveLists4x2x3");
			}
			if (ES3.Exists("roofInventorySaveLocs4x2x3"))
			{
				this.roofInventorySaveLocs4x2x3 = ES3.LoadListInt("roofInventorySaveLocs4x2x3");
			}
			if (ES3.Exists("roofInventorySaveLists4x1x1"))
			{
				this.roofInventorySaveLists4x1x1 = ES3.LoadListInt("roofInventorySaveLists4x1x1");
			}
			if (ES3.Exists("roofInventorySaveLocs4x1x1"))
			{
				this.roofInventorySaveLocs4x1x1 = ES3.LoadListInt("roofInventorySaveLocs4x1x1");
			}
			if (ES3.Exists("roofInventorySaveLists4x2x1"))
			{
				this.roofInventorySaveLists4x2x1 = ES3.LoadListInt("roofInventorySaveLists4x2x1");
			}
			if (ES3.Exists("roofInventorySaveLocs4x2x1"))
			{
				this.roofInventorySaveLocs4x2x1 = ES3.LoadListInt("roofInventorySaveLocs4x2x1");
			}
			if (ES3.Exists("roofInventorySaveLists2x1x3"))
			{
				this.roofInventorySaveLists2x1x3 = ES3.LoadListInt("roofInventorySaveLists2x1x3");
			}
			if (ES3.Exists("roofInventorySaveLocs2x1x3"))
			{
				this.roofInventorySaveLocs2x1x3 = ES3.LoadListInt("roofInventorySaveLocs2x1x3");
			}
			if (ES3.Exists("roofInventorySaveListsTyres"))
			{
				this.roofInventorySaveListsTyres = ES3.LoadListInt("roofInventorySaveListsTyres");
			}
			GameObject bspawn = null;
			if (this.basketInventorySaveList != null && this.basketInventorySaveList.Count > 0)
			{
				bspawn = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.basketInventorySaveList[0]]);
			}
			if (this.bootInventorySaveLists3x2x1 == null)
			{
				this.bootInventorySaveLists3x2x1 = new List<int>();
			}
			if (this.bootInventorySaveLists2x2x1 == null)
			{
				this.bootInventorySaveLists2x2x1 = new List<int>();
			}
			if (this.bootInventorySaveLists2x2x2 == null)
			{
				this.bootInventorySaveLists2x2x2 = new List<int>();
			}
			if (this.bootInventorySaveLists2x2x3 == null)
			{
				this.bootInventorySaveLists2x2x3 = new List<int>();
			}
			if (this.bootInventorySaveLists3x2x3 == null)
			{
				this.bootInventorySaveLists3x2x3 = new List<int>();
			}
			for (int k = 0; k < this.bootInventorySaveLists3x2x1.Count; k++)
			{
				GameObject spawned19 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists3x2x1[k]]);
				this.LoadLogic(spawned19, inventory, inventory.slot3x2x1[this.bootInventorySaveLocs3x2x1[k]].transform, k);
			}
			for (int l = 0; l < this.bootInventorySaveLists2x2x1.Count; l++)
			{
				GameObject spawned20 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists2x2x1[l]]);
				this.LoadLogic(spawned20, inventory, inventory.slot2x2x1[this.bootInventorySaveLocs2x2x1[l]].transform, l);
			}
			for (int m = 0; m < this.bootInventorySaveLists2x2x2.Count; m++)
			{
				GameObject spawned21 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists2x2x2[m]]);
				this.LoadLogic(spawned21, inventory, inventory.slot2x2x2[this.bootInventorySaveLocs2x2x2[m]].transform, m);
			}
			for (int n = 0; n < this.bootInventorySaveLists2x2x3.Count; n++)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists2x2x3[n]]);
				this.LoadLogic(gameObject2, inventory, inventory.slot2x2x3[this.bootInventorySaveLocs2x2x3[n]].transform, n);
				if (gameObject2.GetComponent<PortableFuelC>() && this.fuelCanLevels.Count > 0)
				{
					gameObject2.GetComponent<PortableFuelC>().fuelLevel = this.fuelCanLevels[0];
					gameObject2.GetComponent<PortableFuelC>().fuelMix = this.fuelCanMixs[0];
					gameObject2.GetComponent<PortableFuelC>().FuelUpdate();
					this.fuelCanLevels.RemoveAt(0);
					this.fuelCanMixs.RemoveAt(0);
				}
			}
			for (int num = 0; num < this.bootInventorySaveLists3x2x3.Count; num++)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists3x2x3[num]]);
				this.LoadLogic(gameObject3, inventory, inventory.slot3x2x3[this.bootInventorySaveLocs3x2x3[num]].transform, num);
				if (gameObject3.GetComponent<ObjectPickupC>().objectID == 210)
				{
					if (this.currentBasketsInInventory.Count > 0)
					{
						for (int num2 = 0; num2 < this.currentBasketsInInventory[0]; num2++)
						{
							bspawn = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.basketInventorySaveList[0]]);
							this.basketInventorySaveList.RemoveAt(0);
							if (bspawn.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
							{
								bspawn.transform.localScale = bspawn.GetComponent<ObjectPickupC>().adjustScale;
							}
							gameObject3.transform.GetChild(0).GetComponent<InventoryLogicC>().InstantTrigger(bspawn);
							this.carLogic.GetComponent<CarPerformanceC>().carBootWeight += bspawn.GetComponent<ObjectPickupC>().rigidMass;
							this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += bspawn.GetComponent<ObjectPickupC>().rigidMass;
							if (bspawn.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
							{
								bspawn.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
								bspawn.GetComponent<EngineComponentC>().UpdateCondition();
								this.componentConditions.RemoveAt(0);
							}
							else if (bspawn.GetComponent<WaterBottleLogicC>() && this.waterBottleLevels.Count > 0)
							{
								bspawn.GetComponent<WaterBottleLogicC>().waterLevel = this.waterBottleLevels[0];
								bspawn.GetComponent<WaterBottleLogicC>().WaterUpdate();
								this.waterBottleLevels.RemoveAt(0);
							}
							else if (bspawn.GetComponent<OilBottleC>() && this.oilBottleLevels.Count > 0)
							{
								bspawn.GetComponent<OilBottleC>().oilLevel = this.oilBottleLevels[0];
								bspawn.GetComponent<OilBottleC>().OilUpdate();
								this.oilBottleLevels.RemoveAt(0);
							}
							else if (bspawn.GetComponent<PortableFuelC>() && this.fuelCanLevels.Count > 0)
							{
								bspawn.GetComponent<PortableFuelC>().fuelLevel = this.fuelCanLevels[0];
								bspawn.GetComponent<PortableFuelC>().fuelMix = this.fuelCanMixs[0];
								bspawn.GetComponent<PortableFuelC>().FuelUpdate();
								this.fuelCanLevels.RemoveAt(0);
								this.fuelCanMixs.RemoveAt(0);
							}
							if (bspawn.GetComponent<EngineComponentC>() && this.componentCharges.Count > 0 && bspawn.GetComponent<EngineComponentC>().isBattery)
							{
								bspawn.GetComponent<EngineComponentC>().charge = this.componentCharges[0];
								this.componentCharges.RemoveAt(0);
							}
							if (bspawn.GetComponent<EngineComponentC>() && this.componentWaters.Count > 0 && bspawn.GetComponent<EngineComponentC>().totalWaterCharges > 0)
							{
								bspawn.GetComponent<EngineComponentC>().currentWaterCharges = this.componentWaters[0];
								bspawn.transform.GetChild(0).GetComponent<WaterSupplyRelayC>().WaterUpdate();
								this.componentWaters.RemoveAt(0);
							}
						}
					}
					if (this.currentBasketsInInventory.Count > 0)
					{
						this.currentBasketsInInventory.RemoveAt(0);
					}
				}
				this.UpdateColliders(gameObject3);
			}
			if (this.bootInventorySaveLists4x2x2 == null)
			{
				this.bootInventorySaveLists4x2x2 = new List<int>();
			}
			if (this.bootInventorySaveLists4x2x3 == null)
			{
				this.bootInventorySaveLists4x2x3 = new List<int>();
			}
			if (this.bootInventorySaveLists4x1x1 == null)
			{
				this.bootInventorySaveLists4x1x1 = new List<int>();
			}
			if (this.bootInventorySaveLists4x2x1 == null)
			{
				this.bootInventorySaveLists4x2x1 = new List<int>();
			}
			if (this.bootInventorySaveLists2x1x3 == null)
			{
				this.bootInventorySaveLists2x1x3 = new List<int>();
			}
			if (this.bootInventorySaveListsTyres == null)
			{
				this.bootInventorySaveListsTyres = new List<int>();
			}
			for (int num3 = 0; num3 < this.bootInventorySaveLists4x2x2.Count; num3++)
			{
				GameObject spawned22 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists4x2x2[num3]]);
				this.LoadLogic(spawned22, inventory, inventory.slot4x2x2[this.bootInventorySaveLocs4x2x2[num3]].transform, num3);
			}
			for (int num4 = 0; num4 < this.bootInventorySaveLists4x2x3.Count; num4++)
			{
				GameObject spawned23 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists4x2x3[num4]]);
				this.LoadLogic(spawned23, inventory, inventory.slot4x2x3[this.bootInventorySaveLocs4x2x3[num4]].transform, num4);
			}
			for (int num5 = 0; num5 < this.bootInventorySaveLists4x1x1.Count; num5++)
			{
				GameObject spawned24 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists4x1x1[num5]]);
				this.LoadLogic(spawned24, inventory, inventory.slot4x1x1[this.bootInventorySaveLocs4x1x1[num5]].transform, num5);
			}
			for (int num6 = 0; num6 < this.bootInventorySaveLists4x2x1.Count; num6++)
			{
				GameObject spawned25 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists4x2x1[num6]]);
				this.LoadLogic(spawned25, inventory, inventory.slot4x2x1[this.bootInventorySaveLocs4x2x1[num6]].transform, num6);
			}
			for (int num7 = 0; num7 < this.bootInventorySaveLists2x1x3.Count; num7++)
			{
				GameObject spawned26 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveLists2x1x3[num7]]);
				this.LoadLogic(spawned26, inventory, inventory.slot2x1x3[this.bootInventorySaveLocs2x1x3[num7]].transform, num7);
			}
			if (this.bootInventorySaveListsTyres.Count > 0)
			{
				GameObject spawned27 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveListsTyres[0]]);
				this.LoadLogic2(spawned27, inventory, true);
			}
			if (this.bootInventorySaveListsTyres.Count > 1)
			{
				GameObject spawned28 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.bootInventorySaveListsTyres[1]]);
				this.LoadLogic2(spawned28, inventory, false);
			}
			InventoryLogicC inventoryRoof = this.carLogic.GetComponent<CarLogicC>().roofInventory.GetComponent<InventoryLogicC>();
			if (this.roofInventorySaveList == null)
			{
				this.roofInventorySaveList = new List<int>();
			}
			for (int num8 = 0; num8 < this.roofInventorySaveList.Count; num8++)
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveList[num8]]);
				this.LoadLogic(gameObject4, inventoryRoof, inventoryRoof.inventorySlots[this.roofInventorySaveLocsSingle[num8]].transform, num8);
				gameObject4.GetComponent<ObjectPickupC>().hasBeenTradeUpdated = true;
				if (this.roofInventoryTradeGoodsSmallIDSaveList.Count > 0 && this.roofInventoryTradeGoodsSmallIDSaveList[num8] > 0 && gameObject4.GetComponent<ObjectPickupC>().countryMat.Length > 0)
				{
					gameObject4.GetComponent<ObjectPickupC>().startMaterial = gameObject4.GetComponent<ObjectPickupC>().countryMat[this.roofInventoryTradeGoodsSmallIDSaveList[num8]];
					gameObject4.GetComponent<ObjectPickupC>().tradeGoodCountryCode = this.roofInventoryTradeGoodsSmallIDSaveList[num8];
					gameObject4.GetComponent<ObjectPickupC>().LoadRendersFromSave();
				}
			}
			if (this.roofInventorySaveLists3x2x1 == null)
			{
				this.roofInventorySaveLists3x2x1 = new List<int>();
			}
			for (int num9 = 0; num9 < this.roofInventorySaveLists3x2x1.Count; num9++)
			{
				GameObject spawned29 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists3x2x1[num9]]);
				this.LoadLogic(spawned29, inventoryRoof, inventoryRoof.slot3x2x1[this.roofInventorySaveLocs3x2x1[num9]].transform, num9);
			}
			if (this.roofInventorySaveLists2x2x1 == null)
			{
				this.roofInventorySaveLists2x2x1 = new List<int>();
			}
			for (int num10 = 0; num10 < this.roofInventorySaveLists2x2x1.Count; num10++)
			{
				GameObject spawned30 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists2x2x1[num10]]);
				this.LoadLogic(spawned30, inventoryRoof, inventoryRoof.slot2x2x1[this.roofInventorySaveLocs2x2x1[num10]].transform, num10);
			}
			if (this.roofInventorySaveLists2x2x2 == null)
			{
				this.roofInventorySaveLists2x2x2 = new List<int>();
			}
			for (int num11 = 0; num11 < this.roofInventorySaveLists2x2x2.Count; num11++)
			{
				GameObject spawned31 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists2x2x2[num11]]);
				this.LoadLogic(spawned31, inventoryRoof, inventoryRoof.slot2x2x2[this.roofInventorySaveLocs2x2x2[num11]].transform, num11);
			}
			if (this.roofInventorySaveLists2x2x3 == null)
			{
				this.roofInventorySaveLists2x2x3 = new List<int>();
			}
			for (int num12 = 0; num12 < this.roofInventorySaveLists2x2x3.Count; num12++)
			{
				GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists2x2x3[num12]]);
				this.LoadLogic(gameObject5, inventoryRoof, inventoryRoof.slot2x2x3[this.roofInventorySaveLocs2x2x3[num12]].transform, num12);
				if (gameObject5.GetComponent<PortableFuelC>() && this.fuelCanLevels.Count > 0)
				{
					gameObject5.GetComponent<PortableFuelC>().fuelLevel = this.fuelCanLevels[0];
					gameObject5.GetComponent<PortableFuelC>().fuelMix = this.fuelCanMixs[0];
					gameObject5.GetComponent<PortableFuelC>().FuelUpdate();
					this.fuelCanLevels.RemoveAt(0);
					this.fuelCanMixs.RemoveAt(0);
				}
			}
			if (this.roofInventorySaveLists3x2x3 == null)
			{
				this.roofInventorySaveLists3x2x3 = new List<int>();
			}
			for (int i16 = 0; i16 < this.roofInventorySaveLists3x2x3.Count; i16++)
			{
				GameObject spawned18 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists3x2x3[i16]]);
				this.LoadLogic(spawned18, inventoryRoof, inventoryRoof.slot3x2x3[this.roofInventorySaveLocs3x2x3[i16]].transform, i16);
				this.UpdateColliders(spawned18);
				if (spawned18.GetComponent<ObjectPickupC>().objectID == 210)
				{
					if (this.currentBasketsInInventory.Count > 0)
					{
						for (int cbasket2 = 0; cbasket2 < this.currentBasketsInInventory[0]; cbasket2++)
						{
							GameObject bspawn2 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.basketInventorySaveList[0]]);
							this.basketInventorySaveList.RemoveAt(0);
							if (bspawn2.GetComponent<ObjectPickupC>().adjustScale != Vector3.zero)
							{
								bspawn2.transform.localScale = bspawn2.GetComponent<ObjectPickupC>().adjustScale;
							}
							spawned18.transform.GetChild(0).GetComponent<InventoryLogicC>().InstantTrigger(bspawn2);
							this.carLogic.GetComponent<CarPerformanceC>().carBootWeight += bspawn2.GetComponent<ObjectPickupC>().rigidMass;
							this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += bspawn2.GetComponent<ObjectPickupC>().rigidMass;
							if (bspawn2.GetComponent<EngineComponentC>() && this.componentConditions.Count > 0)
							{
								bspawn2.GetComponent<EngineComponentC>().Condition = this.componentConditions[0];
								bspawn2.GetComponent<EngineComponentC>().UpdateCondition();
								this.componentConditions.RemoveAt(0);
							}
							if (bspawn2.GetComponent<WaterBottleLogicC>() && this.waterBottleLevels.Count > 0)
							{
								bspawn2.GetComponent<WaterBottleLogicC>().waterLevel = this.waterBottleLevels[0];
								bspawn2.GetComponent<WaterBottleLogicC>().WaterUpdate();
								this.waterBottleLevels.RemoveAt(0);
							}
							else if (bspawn2.GetComponent<OilBottleC>() && this.oilBottleLevels.Count > 0)
							{
								bspawn2.GetComponent<OilBottleC>().oilLevel = this.oilBottleLevels[0];
								bspawn2.GetComponent<OilBottleC>().OilUpdate();
								this.oilBottleLevels.RemoveAt(0);
							}
							else if (bspawn2.GetComponent<PortableFuelC>() && this.fuelCanLevels.Count > 0)
							{
								bspawn2.GetComponent<PortableFuelC>().fuelLevel = this.fuelCanLevels[0];
								bspawn2.GetComponent<PortableFuelC>().fuelMix = this.fuelCanMixs[0];
								bspawn2.GetComponent<PortableFuelC>().FuelUpdate();
								this.fuelCanLevels.RemoveAt(0);
								this.fuelCanMixs.RemoveAt(0);
							}
							if (bspawn.GetComponent<EngineComponentC>() && this.componentCharges.Count > 0 && bspawn.GetComponent<EngineComponentC>().isBattery)
							{
								bspawn.GetComponent<EngineComponentC>().charge = this.componentCharges[0];
								this.componentCharges.RemoveAt(0);
							}
							if (bspawn.GetComponent<EngineComponentC>() && this.componentWaters.Count > 0 && bspawn.GetComponent<EngineComponentC>().totalWaterCharges > 0)
							{
								bspawn.GetComponent<EngineComponentC>().currentWaterCharges = this.componentWaters[0];
								bspawn.transform.GetChild(0).GetComponent<WaterSupplyRelayC>().WaterUpdate();
								this.componentWaters.RemoveAt(0);
							}
							yield return new WaitForEndOfFrame();
						}
					}
					if (this.currentBasketsInInventory.Count > 0)
					{
						this.currentBasketsInInventory.RemoveAt(0);
					}
				}
			}
			if (this.roofInventorySaveLists4x2x2 == null)
			{
				this.roofInventorySaveLists4x2x2 = new List<int>();
			}
			for (int num13 = 0; num13 < this.roofInventorySaveLists4x2x2.Count; num13++)
			{
				GameObject spawned32 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists4x2x2[num13]]);
				this.LoadLogic(spawned32, inventoryRoof, inventoryRoof.slot4x2x2[this.roofInventorySaveLocs4x2x2[num13]].transform, num13);
			}
			if (this.roofInventorySaveLists4x2x3 == null)
			{
				this.roofInventorySaveLists4x2x3 = new List<int>();
			}
			for (int num14 = 0; num14 < this.roofInventorySaveLists4x2x3.Count; num14++)
			{
				GameObject spawned33 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists4x2x3[num14]]);
				this.LoadLogic(spawned33, inventoryRoof, inventoryRoof.slot4x2x3[this.roofInventorySaveLocs4x2x3[num14]].transform, num14);
			}
			if (this.roofInventorySaveLists4x1x1 == null)
			{
				this.roofInventorySaveLists4x1x1 = new List<int>();
			}
			for (int num15 = 0; num15 < this.roofInventorySaveLists4x1x1.Count; num15++)
			{
				GameObject spawned34 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists4x1x1[num15]]);
				this.LoadLogic(spawned34, inventoryRoof, inventoryRoof.slot4x1x1[this.roofInventorySaveLocs4x1x1[num15]].transform, num15);
			}
			if (this.roofInventorySaveLists4x2x1 == null)
			{
				this.roofInventorySaveLists4x2x1 = new List<int>();
			}
			for (int num16 = 0; num16 < this.roofInventorySaveLists4x2x1.Count; num16++)
			{
				GameObject spawned35 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists4x2x1[num16]]);
				this.LoadLogic(spawned35, inventoryRoof, inventoryRoof.slot4x2x1[this.roofInventorySaveLocs4x2x1[num16]].transform, num16);
			}
			if (this.roofInventorySaveLists2x1x3 == null)
			{
				this.roofInventorySaveLists2x1x3 = new List<int>();
			}
			for (int num17 = 0; num17 < this.roofInventorySaveLists2x1x3.Count; num17++)
			{
				GameObject spawned36 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveLists2x1x3[num17]]);
				this.LoadLogic(spawned36, inventoryRoof, inventoryRoof.slot2x1x3[this.roofInventorySaveLocs2x1x3[num17]].transform, num17);
			}
			if (this.roofInventorySaveListsTyres == null)
			{
				this.roofInventorySaveListsTyres = new List<int>();
			}
			if (this.roofInventorySaveListsTyres.Count > 0)
			{
				GameObject spawned37 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveListsTyres[0]]);
				this.LoadLogic2(spawned37, inventoryRoof, true);
			}
			if (this.roofInventorySaveListsTyres.Count > 1)
			{
				GameObject spawned38 = UnityEngine.Object.Instantiate<GameObject>(this.objectIDCatalogue[this.roofInventorySaveListsTyres[1]]);
				this.LoadLogic2(spawned38, inventoryRoof, false);
			}
		}
		this.carLogic.GetComponent<CarPerformanceC>().UpdateWeight();
		if (ES3.LoadBool("home1InventoryInstalled"))
		{
			this.LoadHome1Inventory();
		}
		if (ES3.LoadBool("home2InventoryInstalled"))
		{
			this.LoadHome2Inventory();
		}
		if (ES3.LoadBool("home3InventoryInstalled"))
		{
			this.LoadHome3Inventory();
		}
		if (ES3.LoadBool("home4InventoryInstalled"))
		{
			this.LoadHome4Inventory();
		}
		if (ES3.LoadBool("home5InventoryInstalled"))
		{
			this.LoadHome5Inventory();
		}
		else
		{
			this.ClearInventoryLoadDetails();
		}
		yield break;
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0003DB54 File Offset: 0x0003BF54
	private void SaveHomeInventory(int index)
	{
		if (this.storageInventory[index - 1].transform.childCount <= 0)
		{
			return;
		}
		List<int> list = this.home1InventorySaveList;
		List<int> list2 = this.home1InventorySaveLocsSingle;
		List<int> list3 = this.home1InventoryTradeGoodsSmallIDSaveList;
		List<int> list4 = this.home1InventorySaveLists3x2x1;
		List<int> list5 = this.home1InventorySaveLocs3x2x1;
		List<int> list6 = this.home1InventorySaveLists2x2x1;
		List<int> list7 = this.home1InventorySaveLocs2x2x1;
		List<int> list8 = this.home1InventorySaveLists2x1x2;
		List<int> list9 = this.home1InventorySaveLocs2x1x2;
		List<int> list10 = this.home1InventorySaveLists2x2x2;
		List<int> list11 = this.home1InventorySaveLocs2x2x2;
		List<int> list12 = this.home1InventorySaveLists2x2x3;
		List<int> list13 = this.home1InventorySaveLocs2x2x3;
		List<int> list14 = this.home1InventorySaveLists3x2x3;
		List<int> list15 = this.home1InventorySaveLocs3x2x3;
		List<int> list16 = this.home1InventorySaveLists4x2x2;
		List<int> list17 = this.home1InventorySaveLocs4x2x2;
		List<int> list18 = this.home1InventorySaveLists4x2x3;
		List<int> list19 = this.home1InventorySaveLocs4x2x3;
		List<int> list20 = this.home1InventorySaveLists4x1x1;
		List<int> list21 = this.home1InventorySaveLocs4x1x1;
		List<int> list22 = this.home1InventorySaveLists4x2x1;
		List<int> list23 = this.home1InventorySaveLocs4x2x1;
		List<int> list24 = this.home1InventorySaveLists2x1x3;
		List<int> list25 = this.home1InventorySaveLocs2x1x3;
		List<int> list26 = this.home1InventorySaveListsTyres;
		if (index == 2)
		{
			list = this.home2InventorySaveList;
			list2 = this.home2InventorySaveLocsSingle;
			list3 = this.home2InventoryTradeGoodsSmallIDSaveList;
			list4 = this.home2InventorySaveLists3x2x1;
			list5 = this.home2InventorySaveLocs3x2x1;
			list6 = this.home2InventorySaveLists2x2x1;
			list7 = this.home2InventorySaveLocs2x2x1;
			list8 = this.home2InventorySaveLists2x1x2;
			list9 = this.home2InventorySaveLocs2x1x2;
			list10 = this.home2InventorySaveLists2x2x2;
			list11 = this.home2InventorySaveLocs2x2x2;
			list12 = this.home2InventorySaveLists2x2x3;
			list13 = this.home2InventorySaveLocs2x2x3;
			list14 = this.home2InventorySaveLists3x2x3;
			list15 = this.home2InventorySaveLocs3x2x3;
			list16 = this.home2InventorySaveLists4x2x2;
			list17 = this.home2InventorySaveLocs4x2x2;
			list18 = this.home2InventorySaveLists4x2x3;
			list19 = this.home2InventorySaveLocs4x2x3;
			list20 = this.home2InventorySaveLists4x1x1;
			list21 = this.home2InventorySaveLocs4x1x1;
			list22 = this.home2InventorySaveLists4x2x1;
			list23 = this.home2InventorySaveLocs4x2x1;
			list24 = this.home2InventorySaveLists2x1x3;
			list25 = this.home2InventorySaveLocs2x1x3;
			list26 = this.home2InventorySaveListsTyres;
		}
		if (index == 3)
		{
			list = this.home3InventorySaveList;
			list2 = this.home3InventorySaveLocsSingle;
			list3 = this.home3InventoryTradeGoodsSmallIDSaveList;
			list4 = this.home3InventorySaveLists3x2x1;
			list5 = this.home3InventorySaveLocs3x2x1;
			list6 = this.home3InventorySaveLists2x2x1;
			list7 = this.home3InventorySaveLocs2x2x1;
			list8 = this.home3InventorySaveLists2x1x2;
			list9 = this.home3InventorySaveLocs2x1x2;
			list10 = this.home3InventorySaveLists2x2x2;
			list11 = this.home3InventorySaveLocs2x2x2;
			list12 = this.home3InventorySaveLists2x2x3;
			list13 = this.home3InventorySaveLocs2x2x3;
			list14 = this.home3InventorySaveLists3x2x3;
			list15 = this.home3InventorySaveLocs3x2x3;
			list16 = this.home3InventorySaveLists4x2x2;
			list17 = this.home3InventorySaveLocs4x2x2;
			list18 = this.home3InventorySaveLists4x2x3;
			list19 = this.home3InventorySaveLocs4x2x3;
			list20 = this.home3InventorySaveLists4x1x1;
			list21 = this.home3InventorySaveLocs4x1x1;
			list22 = this.home3InventorySaveLists4x2x1;
			list23 = this.home3InventorySaveLocs4x2x1;
			list24 = this.home3InventorySaveLists2x1x3;
			list25 = this.home3InventorySaveLocs2x1x3;
			list26 = this.home3InventorySaveListsTyres;
		}
		if (index == 4)
		{
			list = this.home4InventorySaveList;
			list2 = this.home4InventorySaveLocsSingle;
			list3 = this.home4InventoryTradeGoodsSmallIDSaveList;
			list4 = this.home4InventorySaveLists3x2x1;
			list5 = this.home4InventorySaveLocs3x2x1;
			list6 = this.home4InventorySaveLists2x2x1;
			list7 = this.home4InventorySaveLocs2x2x1;
			list8 = this.home4InventorySaveLists2x1x2;
			list9 = this.home4InventorySaveLocs2x1x2;
			list10 = this.home4InventorySaveLists2x2x2;
			list11 = this.home4InventorySaveLocs2x2x2;
			list12 = this.home4InventorySaveLists2x2x3;
			list13 = this.home4InventorySaveLocs2x2x3;
			list14 = this.home4InventorySaveLists3x2x3;
			list15 = this.home4InventorySaveLocs3x2x3;
			list16 = this.home4InventorySaveLists4x2x2;
			list17 = this.home4InventorySaveLocs4x2x2;
			list18 = this.home4InventorySaveLists4x2x3;
			list19 = this.home4InventorySaveLocs4x2x3;
			list20 = this.home4InventorySaveLists4x1x1;
			list21 = this.home4InventorySaveLocs4x1x1;
			list22 = this.home4InventorySaveLists4x2x1;
			list23 = this.home4InventorySaveLocs4x2x1;
			list24 = this.home4InventorySaveLists2x1x3;
			list25 = this.home4InventorySaveLocs2x1x3;
			list26 = this.home4InventorySaveListsTyres;
		}
		if (index == 5)
		{
			list = this.home5InventorySaveList;
			list2 = this.home5InventorySaveLocsSingle;
			list3 = this.home5InventoryTradeGoodsSmallIDSaveList;
			list4 = this.home5InventorySaveLists3x2x1;
			list5 = this.home5InventorySaveLocs3x2x1;
			list6 = this.home5InventorySaveLists2x2x1;
			list7 = this.home5InventorySaveLocs2x2x1;
			list8 = this.home5InventorySaveLists2x1x2;
			list9 = this.home5InventorySaveLocs2x1x2;
			list10 = this.home5InventorySaveLists2x2x2;
			list11 = this.home5InventorySaveLocs2x2x2;
			list12 = this.home5InventorySaveLists2x2x3;
			list13 = this.home5InventorySaveLocs2x2x3;
			list14 = this.home5InventorySaveLists3x2x3;
			list15 = this.home5InventorySaveLocs3x2x3;
			list16 = this.home5InventorySaveLists4x2x2;
			list17 = this.home5InventorySaveLocs4x2x2;
			list18 = this.home5InventorySaveLists4x2x3;
			list19 = this.home5InventorySaveLocs4x2x3;
			list20 = this.home5InventorySaveLists4x1x1;
			list21 = this.home5InventorySaveLocs4x1x1;
			list22 = this.home5InventorySaveLists4x2x1;
			list23 = this.home5InventorySaveLocs4x2x1;
			list24 = this.home5InventorySaveLists2x1x3;
			list25 = this.home5InventorySaveLocs2x1x3;
			list26 = this.home5InventorySaveListsTyres;
		}
		InventoryLogicC component = this.storageInventory[index - 1].transform.GetChild(0).GetComponent<InventoryLogicC>();
		ES3.Save(true, "home" + index + "InventoryInstalled");
		for (int i = 0; i < component.inventorySlots.Length; i++)
		{
			if (component.inventorySlots[i].transform.childCount > 0)
			{
				this.AddToHomeInventoryList(index, component.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				if (component.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().isTradeGood)
				{
					if (component.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().isTradeGood)
					{
						this.AddToHomeTradeGoods(index, component.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().tradeGoodCountryCode);
					}
					else
					{
						this.AddToHomeTradeGoods(index, 0);
					}
				}
				if (component.inventorySlots[i].transform.GetChild(0).GetComponent<EngineComponentC>())
				{
					this.componentConditions.Add(component.inventorySlots[i].transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
					ES3.Save(this.componentConditions, "componentConditions");
					if (component.inventorySlots[i].transform.GetChild(0).GetComponent<EngineComponentC>().totalWaterCharges > 0)
					{
						this.componentWaters.Add(component.inventorySlots[i].transform.GetChild(0).GetComponent<EngineComponentC>().currentWaterCharges);
						ES3.Save(this.componentWaters, "componentWaters");
					}
				}
				if (component.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 159)
				{
					this.waterBottleLevels.Add(component.inventorySlots[i].transform.GetChild(0).GetComponent<WaterBottleLogicC>().waterLevel);
					ES3.Save(this.waterBottleLevels, "waterBottleLevels");
				}
				if (component.inventorySlots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 157)
				{
					this.oilBottleLevels.Add(component.inventorySlots[i].transform.GetChild(0).GetComponent<OilBottleC>().oilLevel);
					ES3.Save(this.oilBottleLevels, "oilBottleLevels");
				}
				this.AddToHomeInventorySaveLocs(index, i);
			}
		}
		for (int j = 0; j < component.slot3x2x1.Length; j++)
		{
			if (component.slot3x2x1[j].childCount > 0)
			{
				list4.Add(component.slot3x2x1[j].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list5.Add(j);
				if (component.slot3x2x1[j].transform.GetChild(0).GetComponent<EngineComponentC>())
				{
					this.componentConditions.Add(component.slot3x2x1[j].transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
					ES3.Save(this.componentConditions, "componentConditions");
				}
			}
		}
		for (int k = 0; k < component.slot2x2x1.Length; k++)
		{
			if (component.slot2x2x1[k].childCount > 0)
			{
				MonoBehaviour.print("Inventory 1 slot 2x2x1 ID[" + k + "]");
				list6.Add(component.slot2x2x1[k].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list7.Add(k);
				if (component.slot2x2x1[k].transform.GetChild(0).GetComponent<EngineComponentC>())
				{
					this.componentConditions.Add(component.slot2x2x1[k].transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
					ES3.Save(this.componentConditions, "componentConditions");
					if (component.slot2x2x1[k].transform.GetChild(0).GetComponent<EngineComponentC>().totalWaterCharges > 0)
					{
						this.componentWaters.Add(component.slot2x2x1[k].transform.GetChild(0).GetComponent<EngineComponentC>().currentWaterCharges);
						ES3.Save(this.componentWaters, "componentWaters");
					}
				}
			}
		}
		for (int l = 0; l < component.slot2x1x2.Length; l++)
		{
			if (component.slot2x1x2[l].childCount > 0)
			{
				list8.Add(component.slot2x1x2[l].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list9.Add(l);
			}
		}
		for (int m = 0; m < component.slot2x2x2.Length; m++)
		{
			if (component.slot2x2x2[m].childCount > 0)
			{
				list10.Add(component.slot2x2x2[m].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list11.Add(m);
				if (component.slot2x2x2[m].transform.GetChild(0).GetComponent<EngineComponentC>())
				{
					this.componentConditions.Add(component.slot2x2x2[m].transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
					ES3.Save(this.componentConditions, "componentConditions");
					if (component.slot2x2x2[m].transform.GetChild(0).GetComponent<EngineComponentC>().totalWaterCharges > 0)
					{
						this.componentWaters.Add(component.slot2x2x2[m].transform.GetChild(0).GetComponent<EngineComponentC>().currentWaterCharges);
						ES3.Save(this.componentWaters, "componentWaters");
					}
				}
			}
		}
		for (int n = 0; n < component.slot2x2x3.Length; n++)
		{
			if (component.slot2x2x3[n].childCount > 0)
			{
				list12.Add(component.slot2x2x3[n].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list13.Add(n);
				if (component.slot2x2x3[n].transform.GetChild(0).GetComponent<EngineComponentC>())
				{
					this.componentConditions.Add(component.slot2x2x3[n].transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
					ES3.Save(this.componentConditions, "componentConditions");
					if (component.slot2x2x3[n].transform.GetChild(0).GetComponent<EngineComponentC>().isBattery)
					{
						this.componentCharges.Add(component.slot2x2x3[n].transform.GetChild(0).GetComponent<EngineComponentC>().charge);
						ES3.Save(this.componentCharges, "componentCharges");
					}
				}
				if (component.slot2x2x3[n].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 158)
				{
					this.fuelCanLevels.Add(component.slot2x2x3[n].transform.GetChild(0).GetComponent<PortableFuelC>().fuelLevel);
					this.fuelCanMixs.Add(component.slot2x2x3[n].transform.GetChild(0).GetComponent<PortableFuelC>().fuelMix);
					ES3.Save(this.fuelCanLevels, "fuelCanLevels");
					ES3.Save(this.fuelCanMixs, "fuelCanMixs");
				}
			}
		}
		for (int num = 0; num < component.slot3x2x3.Length; num++)
		{
			if (component.slot3x2x3[num].childCount > 0)
			{
				list14.Add(component.slot3x2x3[num].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list15.Add(num);
				if (component.slot3x2x3[num].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID == 210)
				{
					Transform child = component.slot3x2x3[num].transform.GetChild(0).transform.GetChild(0);
					this.currentBasketsInInventory.Add(0);
					for (int num2 = 0; num2 < child.GetComponent<InventoryLogicC>().inventorySlots.Length; num2++)
					{
						IEnumerator enumerator = child.GetComponent<InventoryLogicC>().inventorySlots[num2].transform.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								Transform transform = (Transform)obj;
								this.basketInventorySaveList.Add(transform.GetComponent<ObjectPickupC>().objectID);
								List<int> list27;
								int index2;
								(list27 = this.currentBasketsInInventory)[index2 = this.currentBasketsInInventory.Count - 1] = list27[index2] + 1;
								if (transform.GetComponent<EngineComponentC>())
								{
									this.componentConditions.Add(transform.GetComponent<EngineComponentC>().Condition);
									ES3.Save(this.componentConditions, "componentConditions");
								}
								if (transform.GetComponent<ObjectPickupC>().objectID == 159)
								{
									this.waterBottleLevels.Add(transform.GetComponent<WaterBottleLogicC>().waterLevel);
									ES3.Save(this.waterBottleLevels, "waterBottleLevels");
								}
								if (transform.GetComponent<ObjectPickupC>().objectID == 157)
								{
									this.oilBottleLevels.Add(transform.GetComponent<OilBottleC>().oilLevel);
									ES3.Save(this.oilBottleLevels, "oilBottleLevels");
								}
								if (transform.GetComponent<EngineComponentC>() && transform.GetComponent<EngineComponentC>().totalWaterCharges > 0)
								{
									this.componentWaters.Add(transform.GetComponent<EngineComponentC>().currentWaterCharges);
									ES3.Save(this.componentWaters, "componentWaters");
								}
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
					}
					for (int num3 = 0; num3 < child.GetComponent<InventoryLogicC>().slot2x2x1.Length; num3++)
					{
						IEnumerator enumerator2 = child.GetComponent<InventoryLogicC>().slot2x2x1[num3].transform.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								object obj2 = enumerator2.Current;
								Transform transform2 = (Transform)obj2;
								this.basketInventorySaveList.Add(transform2.GetComponent<ObjectPickupC>().objectID);
								List<int> list27;
								int index3;
								(list27 = this.currentBasketsInInventory)[index3 = this.currentBasketsInInventory.Count - 1] = list27[index3] + 1;
								if (transform2.GetComponent<EngineComponentC>())
								{
									this.componentConditions.Add(transform2.GetComponent<EngineComponentC>().Condition);
									ES3.Save(this.componentConditions, "componentConditions");
								}
								if (transform2.GetComponent<EngineComponentC>() && transform2.GetComponent<EngineComponentC>().totalWaterCharges > 0)
								{
									this.componentWaters.Add(transform2.GetComponent<EngineComponentC>().currentWaterCharges);
									ES3.Save(this.componentWaters, "componentWaters");
								}
							}
						}
						finally
						{
							IDisposable disposable2;
							if ((disposable2 = (enumerator2 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					for (int num4 = 0; num4 < child.GetComponent<InventoryLogicC>().slot2x2x2.Length; num4++)
					{
						IEnumerator enumerator3 = child.GetComponent<InventoryLogicC>().slot2x2x2[num4].transform.GetEnumerator();
						try
						{
							while (enumerator3.MoveNext())
							{
								object obj3 = enumerator3.Current;
								Transform transform3 = (Transform)obj3;
								this.basketInventorySaveList.Add(transform3.GetComponent<ObjectPickupC>().objectID);
								List<int> list27;
								int index4;
								(list27 = this.currentBasketsInInventory)[index4 = this.currentBasketsInInventory.Count - 1] = list27[index4] + 1;
								if (transform3.GetComponent<EngineComponentC>())
								{
									this.componentConditions.Add(transform3.GetComponent<EngineComponentC>().Condition);
									ES3.Save(this.componentConditions, "componentConditions");
								}
								if (transform3.GetComponent<EngineComponentC>() && transform3.GetComponent<EngineComponentC>().totalWaterCharges > 0)
								{
									this.componentWaters.Add(transform3.GetComponent<EngineComponentC>().currentWaterCharges);
									ES3.Save(this.componentWaters, "componentWaters");
								}
							}
						}
						finally
						{
							IDisposable disposable3;
							if ((disposable3 = (enumerator3 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					for (int num5 = 0; num5 < child.GetComponent<InventoryLogicC>().slot2x2x3.Length; num5++)
					{
						IEnumerator enumerator4 = child.GetComponent<InventoryLogicC>().slot2x2x3[num5].transform.GetEnumerator();
						try
						{
							while (enumerator4.MoveNext())
							{
								object obj4 = enumerator4.Current;
								Transform transform4 = (Transform)obj4;
								this.basketInventorySaveList.Add(transform4.GetComponent<ObjectPickupC>().objectID);
								List<int> list27;
								int index5;
								(list27 = this.currentBasketsInInventory)[index5 = this.currentBasketsInInventory.Count - 1] = list27[index5] + 1;
								if (transform4.GetComponent<EngineComponentC>())
								{
									this.componentConditions.Add(transform4.GetComponent<EngineComponentC>().Condition);
									ES3.Save(this.componentConditions, "componentConditions");
								}
								if (transform4.GetComponent<ObjectPickupC>().objectID == 158)
								{
									this.fuelCanLevels.Add(transform4.GetComponent<PortableFuelC>().fuelLevel);
									this.fuelCanMixs.Add(transform4.GetComponent<PortableFuelC>().fuelMix);
									ES3.Save(this.fuelCanLevels, "fuelCanLevels");
									ES3.Save(this.fuelCanMixs, "fuelCanMixs");
								}
								if (transform4.GetComponent<EngineComponentC>() && transform4.GetComponent<EngineComponentC>().isBattery)
								{
									this.componentCharges.Add(transform4.GetComponent<EngineComponentC>().charge);
									ES3.Save(this.componentCharges, "componentCharges");
								}
							}
						}
						finally
						{
							IDisposable disposable4;
							if ((disposable4 = (enumerator4 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					for (int num6 = 0; num6 < child.GetComponent<InventoryLogicC>().slot2x1x2.Length; num6++)
					{
						IEnumerator enumerator5 = child.GetComponent<InventoryLogicC>().slot2x1x2[num6].transform.GetEnumerator();
						try
						{
							while (enumerator5.MoveNext())
							{
								object obj5 = enumerator5.Current;
								Transform transform5 = (Transform)obj5;
								this.basketInventorySaveList.Add(transform5.GetComponent<ObjectPickupC>().objectID);
								List<int> list27;
								int index6;
								(list27 = this.currentBasketsInInventory)[index6 = this.currentBasketsInInventory.Count - 1] = list27[index6] + 1;
							}
						}
						finally
						{
							IDisposable disposable5;
							if ((disposable5 = (enumerator5 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
					ES3.Save(this.basketInventorySaveList, "basketInventorySaveList");
					ES3.Save(this.currentBasketsInInventory, "currentBasketsInInventory");
				}
			}
		}
		for (int num7 = 0; num7 < component.slot4x2x2.Length; num7++)
		{
			if (component.slot4x2x2[num7].childCount > 0)
			{
				list16.Add(component.slot4x2x2[num7].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list17.Add(num7);
			}
		}
		for (int num8 = 0; num8 < component.slot4x2x3.Length; num8++)
		{
			if (component.slot4x2x3[num8].childCount > 0)
			{
				list18.Add(component.slot4x2x3[num8].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list19.Add(num8);
				if (component.slot4x2x3[num8].transform.GetChild(0).GetComponent<EngineComponentC>())
				{
					this.componentConditions.Add(component.slot4x2x3[num8].transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
					ES3.Save(this.componentConditions, "componentConditions");
					if (component.slot4x2x3[num8].transform.GetChild(0).GetComponent<EngineComponentC>().totalFuelAmount > 0f)
					{
						this.componentFuels.Add(component.slot4x2x3[num8].transform.GetChild(0).GetComponent<EngineComponentC>().currentFuelAmount);
						this.componentFuelMixs.Add(component.slot4x2x3[num8].transform.GetChild(0).GetComponent<EngineComponentC>().fuelMix);
						ES3.Save(this.componentFuels, "componentFuels");
						ES3.Save(this.componentFuelMixs, "componentFuelMixs");
					}
				}
			}
		}
		for (int num9 = 0; num9 < component.slot4x1x1.Length; num9++)
		{
			if (component.slot4x1x1[num9].childCount > 0)
			{
				list20.Add(component.slot4x1x1[num9].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list21.Add(num9);
			}
		}
		for (int num10 = 0; num10 < component.slot4x2x1.Length; num10++)
		{
			if (component.slot4x2x1[num10].childCount > 0)
			{
				list22.Add(component.slot4x2x1[num10].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list23.Add(num10);
			}
		}
		for (int num11 = 0; num11 < component.slot2x1x3.Length; num11++)
		{
			if (component.slot2x1x3[num11].childCount > 0)
			{
				list24.Add(component.slot2x1x3[num11].transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
				list25.Add(num11);
			}
		}
		if (component.wheelHolder1.transform.childCount > 0)
		{
			list26.Add(component.wheelHolder1.transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
			this.componentConditions.Add(component.wheelHolder1.transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
			ES3.Save(this.componentConditions, "componentConditions");
		}
		if (component.wheelHolder2.transform.childCount > 0)
		{
			list26.Add(component.wheelHolder2.transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
			this.componentConditions.Add(component.wheelHolder2.transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
			ES3.Save(this.componentConditions, "componentConditions");
		}
		if (component.wheelHolder3.transform.childCount > 0)
		{
			list26.Add(component.wheelHolder3.transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
			this.componentConditions.Add(component.wheelHolder3.transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
			ES3.Save(this.componentConditions, "componentConditions");
		}
		if (component.wheelHolder4.transform.childCount > 0)
		{
			list26.Add(component.wheelHolder4.transform.GetChild(0).GetComponent<ObjectPickupC>().objectID);
			this.componentConditions.Add(component.wheelHolder4.transform.GetChild(0).GetComponent<EngineComponentC>().Condition);
			ES3.Save(this.componentConditions, "componentConditions");
		}
		if (list.Count > 0)
		{
			ES3.Save(list, "home" + index + "InventorySaveList");
		}
		if (list2.Count > 0)
		{
			ES3.Save(list2, "home" + index + "InventorySaveLocsSingle");
		}
		if (list3.Count > 0)
		{
			ES3.Save(list3, "home" + index + "InventoryTradeGoodsSmallIDSaveList");
		}
		if (list4.Count > 0)
		{
			ES3.Save(list4, "home" + index + "InventorySaveLists3x2x1");
		}
		if (list5.Count > 0)
		{
			ES3.Save(list5, "home" + index + "InventorySaveLocs3x2x1");
		}
		if (list6.Count > 0)
		{
			ES3.Save(list6, "home" + index + "InventorySaveLists2x2x1");
		}
		if (list7.Count > 0)
		{
			ES3.Save(list7, "home" + index + "InventorySaveLocs2x2x1");
		}
		if (list8.Count > 0)
		{
			ES3.Save(list8, "home" + index + "InventorySaveLists2x1x2");
		}
		if (list7.Count > 0)
		{
			ES3.Save(list9, "home" + index + "InventorySaveLocs2x1x2");
		}
		if (list10.Count > 0)
		{
			ES3.Save(list10, "home" + index + "InventorySaveLists2x2x2");
		}
		if (list11.Count > 0)
		{
			ES3.Save(list11, "home" + index + "InventorySaveLocs2x2x2");
		}
		if (list12.Count > 0)
		{
			ES3.Save(list12, "home" + index + "InventorySaveLists2x2x3");
		}
		if (list13.Count > 0)
		{
			ES3.Save(list13, "home" + index + "InventorySaveLocs2x2x3");
		}
		if (list14.Count > 0)
		{
			ES3.Save(list14, "home" + index + "InventorySaveLists3x2x3");
		}
		if (list15.Count > 0)
		{
			ES3.Save(list15, "home" + index + "InventorySaveLocs3x2x3");
		}
		if (list16.Count > 0)
		{
			ES3.Save(list16, "home" + index + "InventorySaveLists4x2x2");
		}
		if (list17.Count > 0)
		{
			ES3.Save(list17, "home" + index + "InventorySaveLocs4x2x2");
		}
		if (list18.Count > 0)
		{
			ES3.Save(list18, "home" + index + "InventorySaveLists4x2x3");
		}
		if (list19.Count > 0)
		{
			ES3.Save(list19, "home" + index + "InventorySaveLocs4x2x3");
		}
		if (list20.Count > 0)
		{
			ES3.Save(list20, "home" + index + "InventorySaveLists4x1x1");
		}
		if (list21.Count > 0)
		{
			ES3.Save(list21, "home" + index + "InventorySaveLocs4x1x1");
		}
		if (list22.Count > 0)
		{
			ES3.Save(list22, "home" + index + "InventorySaveLists4x2x1");
		}
		if (list23.Count > 0)
		{
			ES3.Save(list23, "home" + index + "InventorySaveLocs4x2x1");
		}
		if (list24.Count > 0)
		{
			ES3.Save(list24, "home" + index + "InventorySaveLists2x1x3");
		}
		if (list25.Count > 0)
		{
			ES3.Save(list25, "home" + index + "InventorySaveLocs2x1x3");
		}
		if (list26.Count > 0)
		{
			ES3.Save(list26, "home" + index + "InventorySaveListsTyres");
		}
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0003F810 File Offset: 0x0003DC10
	private void AddToHomeInventoryList(int index, int value)
	{
		if (index == 1)
		{
			this.home1InventorySaveList.Add(value);
		}
		if (index == 2)
		{
			this.home2InventorySaveList.Add(value);
		}
		if (index == 3)
		{
			this.home3InventorySaveList.Add(value);
		}
		if (index == 4)
		{
			this.home4InventorySaveList.Add(value);
		}
		if (index == 5)
		{
			this.home5InventorySaveList.Add(value);
		}
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0003F87C File Offset: 0x0003DC7C
	private void AddToHomeTradeGoods(int index, int value)
	{
		if (index == 1)
		{
			this.home1InventoryTradeGoodsSmallIDSaveList.Add(value);
		}
		if (index == 2)
		{
			this.home2InventoryTradeGoodsSmallIDSaveList.Add(value);
		}
		if (index == 3)
		{
			this.home3InventoryTradeGoodsSmallIDSaveList.Add(value);
		}
		if (index == 4)
		{
			this.home4InventoryTradeGoodsSmallIDSaveList.Add(value);
		}
		if (index == 5)
		{
			this.home5InventoryTradeGoodsSmallIDSaveList.Add(value);
		}
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0003F8E8 File Offset: 0x0003DCE8
	private void AddToHomeInventorySaveLocs(int index, int value)
	{
		if (index == 1)
		{
			this.home1InventorySaveLocsSingle.Add(value);
		}
		if (index == 2)
		{
			this.home2InventorySaveLocsSingle.Add(value);
		}
		if (index == 3)
		{
			this.home3InventorySaveLocsSingle.Add(value);
		}
		if (index == 4)
		{
			this.home4InventorySaveLocsSingle.Add(value);
		}
		if (index == 5)
		{
			this.home5InventorySaveLocsSingle.Add(value);
		}
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0003F954 File Offset: 0x0003DD54
	private void SaveHome1Inventory()
	{
		this.SaveHomeInventory(1);
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x0003F95D File Offset: 0x0003DD5D
	private void SaveHome2Inventory()
	{
		this.SaveHomeInventory(2);
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x0003F966 File Offset: 0x0003DD66
	private void SaveHome3Inventory()
	{
		this.SaveHomeInventory(3);
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0003F96F File Offset: 0x0003DD6F
	private void SaveHome4Inventory()
	{
		this.SaveHomeInventory(4);
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0003F978 File Offset: 0x0003DD78
	private void SaveHome5Inventory()
	{
		this.SaveHomeInventory(5);
	}

	// Token: 0x040004CD RID: 1229
	[HideInInspector]
	public bool lockCursor = true;

	// Token: 0x040004CE RID: 1230
	public static MainMenuC Global;

	// Token: 0x040004CF RID: 1231
	public GameObject[] _diaryStamp;

	// Token: 0x040004D0 RID: 1232
	public GameObject uncle;

	// Token: 0x040004D1 RID: 1233
	public GameObject carLogic;

	// Token: 0x040004D2 RID: 1234
	public GameObject player;

	// Token: 0x040004D3 RID: 1235
	public GameObject carController;

	// Token: 0x040004D4 RID: 1236
	public GameObject carCharacterDriver;

	// Token: 0x040004D5 RID: 1237
	public GameObject map;

	// Token: 0x040004D6 RID: 1238
	public GameObject director;

	// Token: 0x040004D7 RID: 1239
	public GameObject loadingText;

	// Token: 0x040004D8 RID: 1240
	public bool restrictPause;

	// Token: 0x040004D9 RID: 1241
	public int isPaused;

	// Token: 0x040004DA RID: 1242
	public GameObject ambientAudio;

	// Token: 0x040004DB RID: 1243
	public GameObject ambientAudioNight;

	// Token: 0x040004DC RID: 1244
	public GameObject engineAudio;

	// Token: 0x040004DD RID: 1245
	public GameObject radioAudio;

	// Token: 0x040004DE RID: 1246
	public GameObject radioStaticAudio;

	// Token: 0x040004DF RID: 1247
	public AudioClip debugAudioCash;

	// Token: 0x040004E0 RID: 1248
	public GameObject debugBubbleTail;

	// Token: 0x040004E1 RID: 1249
	public GameObject debugBubble;

	// Token: 0x040004E2 RID: 1250
	public GameObject debugBubbleTexture;

	// Token: 0x040004E3 RID: 1251
	public GameObject debugUncle;

	// Token: 0x040004E4 RID: 1252
	public GameObject[] pauseUI;

	// Token: 0x040004E5 RID: 1253
	public Vector3[] pathPos;

	// Token: 0x040004E6 RID: 1254
	public Vector3[] pathRot;

	// Token: 0x040004E7 RID: 1255
	public GameObject topEyeLid;

	// Token: 0x040004E8 RID: 1256
	public GameObject bottomEyeLid;

	// Token: 0x040004E9 RID: 1257
	private Transform topEyeLidPos;

	// Token: 0x040004EA RID: 1258
	private Transform bottomEyeLidPos;

	// Token: 0x040004EB RID: 1259
	public float blinkTime = 0.1f;

	// Token: 0x040004EC RID: 1260
	[HideInInspector]
	public bool wakeUpAtHome;

	// Token: 0x040004ED RID: 1261
	public bool isAsleep;

	// Token: 0x040004EE RID: 1262
	[Header("Options")]
	public bool invertMouse;

	// Token: 0x040004EF RID: 1263
	public bool mouseSmooth;

	// Token: 0x040004F0 RID: 1264
	public int padInput;

	// Token: 0x040004F1 RID: 1265
	public float mouseSensitivity = 0.2f;

	// Token: 0x040004F2 RID: 1266
	public bool reticuleOff = true;

	// Token: 0x040004F3 RID: 1267
	public float optionsPart2Delay;

	// Token: 0x040004F4 RID: 1268
	private bool optionsPart2Bool;

	// Token: 0x040004F5 RID: 1269
	public float optionsPart2PauseTime;

	// Token: 0x040004F6 RID: 1270
	public float optionsPart3Delay;

	// Token: 0x040004F7 RID: 1271
	private bool optionsPart3Bool;

	// Token: 0x040004F8 RID: 1272
	public float optionsPart3PauseTime;

	// Token: 0x040004F9 RID: 1273
	public float optionsPart4Delay;

	// Token: 0x040004FA RID: 1274
	private bool optionsPart4Bool;

	// Token: 0x040004FB RID: 1275
	public float optionsPart4PauseTime;

	// Token: 0x040004FC RID: 1276
	public float closeOptionsPart2Delay;

	// Token: 0x040004FD RID: 1277
	private bool closeOptionsPart2Bool;

	// Token: 0x040004FE RID: 1278
	public float closeOptionsPart2PauseTime;

	// Token: 0x040004FF RID: 1279
	public float closeOptionsPart3Delay;

	// Token: 0x04000500 RID: 1280
	private bool closeOptionsPart3Bool;

	// Token: 0x04000501 RID: 1281
	public float closeOptionsPart3PauseTime;

	// Token: 0x04000502 RID: 1282
	public float closeOptionsPart4Delay;

	// Token: 0x04000503 RID: 1283
	private bool closeOptionsPart4Bool;

	// Token: 0x04000504 RID: 1284
	public float closeOptionsPart4PauseTime;

	// Token: 0x04000505 RID: 1285
	public AudioClip climbOutOfBedAudio;

	// Token: 0x04000506 RID: 1286
	public GameObject[] objectIDCatalogue;

	// Token: 0x04000507 RID: 1287
	public Material[] decalMatCatalogue;

	// Token: 0x04000508 RID: 1288
	public List<GameObject> storageInventory = new List<GameObject>();

	// Token: 0x04000509 RID: 1289
	public GameObject storageClipboard;

	// Token: 0x0400050A RID: 1290
	public List<int> bootInventorySaveList = new List<int>();

	// Token: 0x0400050B RID: 1291
	public List<int> bootInventorySaveLocsSingle = new List<int>();

	// Token: 0x0400050C RID: 1292
	public List<int> bootInventorySaveLists3x2x1 = new List<int>();

	// Token: 0x0400050D RID: 1293
	public List<int> bootInventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x0400050E RID: 1294
	public List<int> bootInventorySaveLists2x2x1 = new List<int>();

	// Token: 0x0400050F RID: 1295
	public List<int> bootInventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x04000510 RID: 1296
	public List<int> bootInventorySaveLists2x1x2 = new List<int>();

	// Token: 0x04000511 RID: 1297
	public List<int> bootInventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x04000512 RID: 1298
	public List<int> bootInventorySaveLists2x2x2 = new List<int>();

	// Token: 0x04000513 RID: 1299
	public List<int> bootInventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x04000514 RID: 1300
	public List<int> bootInventorySaveLists2x2x3 = new List<int>();

	// Token: 0x04000515 RID: 1301
	public List<int> bootInventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x04000516 RID: 1302
	public List<int> bootInventorySaveLists3x2x3 = new List<int>();

	// Token: 0x04000517 RID: 1303
	public List<int> bootInventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x04000518 RID: 1304
	public List<int> bootInventorySaveLists4x2x2 = new List<int>();

	// Token: 0x04000519 RID: 1305
	public List<int> bootInventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x0400051A RID: 1306
	public List<int> bootInventorySaveLists4x2x3 = new List<int>();

	// Token: 0x0400051B RID: 1307
	public List<int> bootInventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x0400051C RID: 1308
	public List<int> bootInventorySaveLists4x1x1 = new List<int>();

	// Token: 0x0400051D RID: 1309
	public List<int> bootInventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x0400051E RID: 1310
	public List<int> bootInventorySaveLists4x2x1 = new List<int>();

	// Token: 0x0400051F RID: 1311
	public List<int> bootInventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x04000520 RID: 1312
	public List<int> bootInventorySaveLists2x1x3 = new List<int>();

	// Token: 0x04000521 RID: 1313
	public List<int> bootInventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x04000522 RID: 1314
	public List<int> bootInventorySaveListsTyres = new List<int>();

	// Token: 0x04000523 RID: 1315
	public List<int> bootInventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x04000524 RID: 1316
	public List<int> waterBottleLevels = new List<int>();

	// Token: 0x04000525 RID: 1317
	public List<int> fuelCanLevels = new List<int>();

	// Token: 0x04000526 RID: 1318
	public List<int> fuelCanMixs = new List<int>();

	// Token: 0x04000527 RID: 1319
	public List<int> oilBottleLevels = new List<int>();

	// Token: 0x04000528 RID: 1320
	public List<float> componentConditions = new List<float>();

	// Token: 0x04000529 RID: 1321
	public List<float> componentFuels = new List<float>();

	// Token: 0x0400052A RID: 1322
	public List<int> componentFuelMixs = new List<int>();

	// Token: 0x0400052B RID: 1323
	public List<float> componentCharges = new List<float>();

	// Token: 0x0400052C RID: 1324
	public List<int> componentWaters = new List<int>();

	// Token: 0x0400052D RID: 1325
	public List<int> basketInventorySaveList = new List<int>();

	// Token: 0x0400052E RID: 1326
	public List<int> currentBasketsInInventory = new List<int>();

	// Token: 0x0400052F RID: 1327
	public List<int> roofInventorySaveList = new List<int>();

	// Token: 0x04000530 RID: 1328
	public List<int> roofInventorySaveLocsSingle = new List<int>();

	// Token: 0x04000531 RID: 1329
	public List<int> roofInventorySaveLists3x2x1 = new List<int>();

	// Token: 0x04000532 RID: 1330
	public List<int> roofInventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x04000533 RID: 1331
	public List<int> roofInventorySaveLists2x2x1 = new List<int>();

	// Token: 0x04000534 RID: 1332
	public List<int> roofInventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x04000535 RID: 1333
	public List<int> roofInventorySaveLists2x1x2 = new List<int>();

	// Token: 0x04000536 RID: 1334
	public List<int> roofInventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x04000537 RID: 1335
	public List<int> roofInventorySaveLists2x2x2 = new List<int>();

	// Token: 0x04000538 RID: 1336
	public List<int> roofInventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x04000539 RID: 1337
	public List<int> roofInventorySaveLists2x2x3 = new List<int>();

	// Token: 0x0400053A RID: 1338
	public List<int> roofInventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x0400053B RID: 1339
	public List<int> roofInventorySaveLists3x2x3 = new List<int>();

	// Token: 0x0400053C RID: 1340
	public List<int> roofInventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x0400053D RID: 1341
	public List<int> roofInventorySaveLists4x2x2 = new List<int>();

	// Token: 0x0400053E RID: 1342
	public List<int> roofInventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x0400053F RID: 1343
	public List<int> roofInventorySaveLists4x2x3 = new List<int>();

	// Token: 0x04000540 RID: 1344
	public List<int> roofInventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x04000541 RID: 1345
	public List<int> roofInventorySaveLists4x1x1 = new List<int>();

	// Token: 0x04000542 RID: 1346
	public List<int> roofInventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x04000543 RID: 1347
	public List<int> roofInventorySaveLists4x2x1 = new List<int>();

	// Token: 0x04000544 RID: 1348
	public List<int> roofInventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x04000545 RID: 1349
	public List<int> roofInventorySaveLists2x1x3 = new List<int>();

	// Token: 0x04000546 RID: 1350
	public List<int> roofInventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x04000547 RID: 1351
	public List<int> roofInventorySaveListsTyres = new List<int>();

	// Token: 0x04000548 RID: 1352
	public List<int> roofInventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x04000549 RID: 1353
	public List<int> home1InventorySaveList = new List<int>();

	// Token: 0x0400054A RID: 1354
	private List<int> home1InventorySaveLocsSingle = new List<int>();

	// Token: 0x0400054B RID: 1355
	private List<int> home1InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x0400054C RID: 1356
	private List<int> home1InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x0400054D RID: 1357
	private List<int> home1InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x0400054E RID: 1358
	public List<int> home1InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x0400054F RID: 1359
	private List<int> home1InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x04000550 RID: 1360
	private List<int> home1InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x04000551 RID: 1361
	private List<int> home1InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x04000552 RID: 1362
	private List<int> home1InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x04000553 RID: 1363
	private List<int> home1InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x04000554 RID: 1364
	private List<int> home1InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x04000555 RID: 1365
	private List<int> home1InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x04000556 RID: 1366
	private List<int> home1InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x04000557 RID: 1367
	private List<int> home1InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x04000558 RID: 1368
	private List<int> home1InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x04000559 RID: 1369
	private List<int> home1InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x0400055A RID: 1370
	private List<int> home1InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x0400055B RID: 1371
	private List<int> home1InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x0400055C RID: 1372
	private List<int> home1InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x0400055D RID: 1373
	private List<int> home1InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x0400055E RID: 1374
	private List<int> home1InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x0400055F RID: 1375
	private List<int> home1InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x04000560 RID: 1376
	private List<int> home1InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x04000561 RID: 1377
	private List<int> home1InventorySaveListsTyres = new List<int>();

	// Token: 0x04000562 RID: 1378
	private List<int> home1InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x04000563 RID: 1379
	private List<int> home2InventorySaveList = new List<int>();

	// Token: 0x04000564 RID: 1380
	private List<int> home2InventorySaveLocsSingle = new List<int>();

	// Token: 0x04000565 RID: 1381
	private List<int> home2InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x04000566 RID: 1382
	private List<int> home2InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x04000567 RID: 1383
	private List<int> home2InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x04000568 RID: 1384
	private List<int> home2InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x04000569 RID: 1385
	private List<int> home2InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x0400056A RID: 1386
	private List<int> home2InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x0400056B RID: 1387
	private List<int> home2InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x0400056C RID: 1388
	private List<int> home2InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x0400056D RID: 1389
	private List<int> home2InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x0400056E RID: 1390
	private List<int> home2InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x0400056F RID: 1391
	private List<int> home2InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x04000570 RID: 1392
	private List<int> home2InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x04000571 RID: 1393
	private List<int> home2InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x04000572 RID: 1394
	private List<int> home2InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x04000573 RID: 1395
	private List<int> home2InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x04000574 RID: 1396
	private List<int> home2InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x04000575 RID: 1397
	private List<int> home2InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x04000576 RID: 1398
	private List<int> home2InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x04000577 RID: 1399
	private List<int> home2InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x04000578 RID: 1400
	private List<int> home2InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x04000579 RID: 1401
	private List<int> home2InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x0400057A RID: 1402
	private List<int> home2InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x0400057B RID: 1403
	private List<int> home2InventorySaveListsTyres = new List<int>();

	// Token: 0x0400057C RID: 1404
	private List<int> home2InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x0400057D RID: 1405
	private List<int> home3InventorySaveList = new List<int>();

	// Token: 0x0400057E RID: 1406
	private List<int> home3InventorySaveLocsSingle = new List<int>();

	// Token: 0x0400057F RID: 1407
	private List<int> home3InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x04000580 RID: 1408
	private List<int> home3InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x04000581 RID: 1409
	private List<int> home3InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x04000582 RID: 1410
	private List<int> home3InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x04000583 RID: 1411
	private List<int> home3InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x04000584 RID: 1412
	private List<int> home3InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x04000585 RID: 1413
	private List<int> home3InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x04000586 RID: 1414
	private List<int> home3InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x04000587 RID: 1415
	private List<int> home3InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x04000588 RID: 1416
	private List<int> home3InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x04000589 RID: 1417
	private List<int> home3InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x0400058A RID: 1418
	private List<int> home3InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x0400058B RID: 1419
	private List<int> home3InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x0400058C RID: 1420
	private List<int> home3InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x0400058D RID: 1421
	private List<int> home3InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x0400058E RID: 1422
	private List<int> home3InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x0400058F RID: 1423
	private List<int> home3InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x04000590 RID: 1424
	private List<int> home3InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x04000591 RID: 1425
	private List<int> home3InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x04000592 RID: 1426
	private List<int> home3InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x04000593 RID: 1427
	private List<int> home3InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x04000594 RID: 1428
	private List<int> home3InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x04000595 RID: 1429
	private List<int> home3InventorySaveListsTyres = new List<int>();

	// Token: 0x04000596 RID: 1430
	private List<int> home3InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x04000597 RID: 1431
	private List<int> home4InventorySaveList = new List<int>();

	// Token: 0x04000598 RID: 1432
	private List<int> home4InventorySaveLocsSingle = new List<int>();

	// Token: 0x04000599 RID: 1433
	private List<int> home4InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x0400059A RID: 1434
	private List<int> home4InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x0400059B RID: 1435
	private List<int> home4InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x0400059C RID: 1436
	private List<int> home4InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x0400059D RID: 1437
	private List<int> home4InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x0400059E RID: 1438
	private List<int> home4InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x0400059F RID: 1439
	private List<int> home4InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x040005A0 RID: 1440
	private List<int> home4InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x040005A1 RID: 1441
	private List<int> home4InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x040005A2 RID: 1442
	private List<int> home4InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x040005A3 RID: 1443
	private List<int> home4InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x040005A4 RID: 1444
	private List<int> home4InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x040005A5 RID: 1445
	private List<int> home4InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x040005A6 RID: 1446
	private List<int> home4InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x040005A7 RID: 1447
	private List<int> home4InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x040005A8 RID: 1448
	private List<int> home4InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x040005A9 RID: 1449
	private List<int> home4InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x040005AA RID: 1450
	private List<int> home4InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x040005AB RID: 1451
	private List<int> home4InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x040005AC RID: 1452
	private List<int> home4InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x040005AD RID: 1453
	private List<int> home4InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x040005AE RID: 1454
	private List<int> home4InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x040005AF RID: 1455
	private List<int> home4InventorySaveListsTyres = new List<int>();

	// Token: 0x040005B0 RID: 1456
	private List<int> home4InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x040005B1 RID: 1457
	private List<int> home5InventorySaveList = new List<int>();

	// Token: 0x040005B2 RID: 1458
	private List<int> home5InventorySaveLocsSingle = new List<int>();

	// Token: 0x040005B3 RID: 1459
	private List<int> home5InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x040005B4 RID: 1460
	private List<int> home5InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x040005B5 RID: 1461
	private List<int> home5InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x040005B6 RID: 1462
	private List<int> home5InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x040005B7 RID: 1463
	private List<int> home5InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x040005B8 RID: 1464
	private List<int> home5InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x040005B9 RID: 1465
	private List<int> home5InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x040005BA RID: 1466
	private List<int> home5InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x040005BB RID: 1467
	private List<int> home5InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x040005BC RID: 1468
	private List<int> home5InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x040005BD RID: 1469
	private List<int> home5InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x040005BE RID: 1470
	private List<int> home5InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x040005BF RID: 1471
	private List<int> home5InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x040005C0 RID: 1472
	private List<int> home5InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x040005C1 RID: 1473
	private List<int> home5InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x040005C2 RID: 1474
	private List<int> home5InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x040005C3 RID: 1475
	private List<int> home5InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x040005C4 RID: 1476
	private List<int> home5InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x040005C5 RID: 1477
	private List<int> home5InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x040005C6 RID: 1478
	private List<int> home5InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x040005C7 RID: 1479
	private List<int> home5InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x040005C8 RID: 1480
	private List<int> home5InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x040005C9 RID: 1481
	private List<int> home5InventorySaveListsTyres = new List<int>();

	// Token: 0x040005CA RID: 1482
	private List<int> home5InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x040005CB RID: 1483
	private bool mirrorEnabled;

	// Token: 0x040005CC RID: 1484
	private bool preventWakeUp;

	// Token: 0x040005CD RID: 1485
	public bool hasWokenUp;

	// Token: 0x040005CE RID: 1486
	[HideInInspector]
	public float inventoryShelfDelay;

	// Token: 0x040005CF RID: 1487
	public GameObject controllerOptions;

	// Token: 0x040005D0 RID: 1488
	public GameObject restartOptions;

	// Token: 0x040005D1 RID: 1489
	public GameObject returnHomeOptions;

	// Token: 0x040005D2 RID: 1490
	public GameObject saveQuitOptions;

	// Token: 0x040005D3 RID: 1491
	public GameObject quitDesktop;

	// Token: 0x040005D4 RID: 1492
	public int changeInputID;

	// Token: 0x040005D5 RID: 1493
	public GameObject[] keyboardInputTarget;

	// Token: 0x040005D6 RID: 1494
	public Sprite[] keyboardInputUI;

	// Token: 0x040005D7 RID: 1495
	public int[] keyboardInputAssigned;

	// Token: 0x040005D8 RID: 1496
	public int[] keyboardInputAssignedPrev;

	// Token: 0x040005D9 RID: 1497
	public string[] inputStringLibrary;

	// Token: 0x040005DA RID: 1498
	public string[] assignedInputStrings;

	// Token: 0x040005DB RID: 1499
	public GameObject[] steeringUI;

	// Token: 0x040005DC RID: 1500
	public GameObject dialogueUI;

	// Token: 0x040005DD RID: 1501
	public GameObject[] userManualUI;

	// Token: 0x040005DE RID: 1502
	public GameObject[] environmentalPosterUI;

	// Token: 0x040005DF RID: 1503
	public GameObject[] localisationPickup;

	// Token: 0x040005E0 RID: 1504
	private float stolenGoodsValue;

	// Token: 0x040005E1 RID: 1505
	public GameObject dialogObject;

	// Token: 0x040005E2 RID: 1506
	private Vector3 myPosition;

	// Token: 0x040005E3 RID: 1507
	private Quaternion myRotation;
}
