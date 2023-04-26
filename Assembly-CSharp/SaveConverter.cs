using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Token: 0x02000080 RID: 128
public class SaveConverter : MonoBehaviour
{
	// Token: 0x06000262 RID: 610 RVA: 0x0001E61E File Offset: 0x0001CA1E
	private void Awake()
	{
		this.DebugDo();
	}

	// Token: 0x06000263 RID: 611 RVA: 0x0001E626 File Offset: 0x0001CA26
	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}

	// Token: 0x06000264 RID: 612 RVA: 0x0001E634 File Offset: 0x0001CA34
	[ContextMenu("Do")]
	private void DebugDo()
	{
		if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
		}
		if (File.Exists(Application.persistentDataPath + "/Saves/Save.sfminsk"))
		{
			return;
		}
		SaveFile saveFile = new SaveFile();
		if (ES2.Exists("vSyncstate"))
		{
			saveFile.vSyncState = ES2.Load<int>("vSyncState");
		}
		if (ES2.Exists("uncleStoryCompleted"))
		{
			saveFile.uncleStoryCompleted = ES2.Load<bool>("uncleStoryCompleted");
		}
		if (ES2.Exists("stampSave0"))
		{
			saveFile.stampSave0 = ES2.Load<bool>("stampSave0");
		}
		if (ES2.Exists("stampSave1"))
		{
			saveFile.stampSave1 = ES2.Load<bool>("stampSave1");
		}
		if (ES2.Exists("stampSave2"))
		{
			saveFile.stampSave2 = ES2.Load<bool>("stampSave2");
		}
		if (ES2.Exists("stampSave3"))
		{
			saveFile.stampSave3 = ES2.Load<bool>("stampSave3");
		}
		if (ES2.Exists("stampSave4"))
		{
			saveFile.stampSave4 = ES2.Load<bool>("stampSave4");
		}
		if (ES2.Exists("stampSave5"))
		{
			saveFile.stampSave5 = ES2.Load<bool>("stampSave5");
		}
		if (ES2.Exists("ssaoSetting"))
		{
			saveFile.ssaoSetting = ES2.Load<bool>("ssaoSetting");
		}
		if (ES2.Exists("roofRackInstalled"))
		{
			saveFile.roofRackInstalled = ES2.Load<bool>("roofRackInstalled");
		}
		if (ES2.Exists("roofRackWeight"))
		{
			saveFile.roofRackWeight = ES2.Load<int>("roofRackWeight");
		}
		if (ES2.Exists("resolutionX"))
		{
			saveFile.resolutionX = ES2.Load<int>("resolutionX");
		}
		if (ES2.Exists("resolutionY"))
		{
			saveFile.resolutionY = ES2.Load<int>("resolutionY");
		}
		if (ES2.Exists("qualityState"))
		{
			saveFile.qualityState = ES2.Load<int>("qualityState");
		}
		if (ES2.Exists("bullBarInstalled"))
		{
			saveFile.bullBarInstalled = ES2.Load<bool>("bullBarInstalled");
		}
		if (ES2.Exists("bullBarWeight"))
		{
			saveFile.bullBarWeight = ES2.Load<int>("bullBarWeight");
		}
		if (ES2.Exists("dashUIInstalled"))
		{
			saveFile.dashUIInstalled = ES2.Load<bool>("dashUIInstalled");
		}
		if (ES2.Exists("dashUIWeight"))
		{
			saveFile.dashUIWeight = ES2.Load<int>("dashUIWeight");
		}
		if (ES2.Exists("effectsVolume"))
		{
			saveFile.effectsVolume = ES2.Load<float>("effectsVolume");
		}
		if (ES2.Exists("fov"))
		{
			saveFile.fov = ES2.Load<float>("fov");
		}
		if (ES2.Exists("fullScreenState"))
		{
			saveFile.fullScreenState = ES2.Load<bool>("fullScreenState");
		}
		if (ES2.Exists("lightRackInstalled"))
		{
			saveFile.lightRackInstalled = ES2.Load<bool>("lightRackInstalled");
		}
		if (ES2.Exists("lightRackWeight"))
		{
			saveFile.lightRackWeight = ES2.Load<int>("lightRackWeight");
		}
		if (ES2.Exists("masterVolume"))
		{
			saveFile.masterVolume = ES2.Load<float>("masterVolume");
		}
		if (ES2.Exists("mudGuardsInstalled"))
		{
			saveFile.mudGuardsInstalled = ES2.Load<bool>("mudGuardsInstalled");
		}
		if (ES2.Exists("mudGuardsWeight"))
		{
			saveFile.mudGuardsWeight = ES2.Load<int>("mudGuardsWeight");
		}
		if (ES2.Exists("preventFlickeringLights"))
		{
			saveFile.preventFlickeringLights = ES2.Load<bool>("preventFlickeringLights");
		}
		if (ES2.Exists("aaSetting"))
		{
			saveFile.aaSetting = ES2.Load<bool>("aaSetting");
		}
		if (ES2.Exists("aiCount"))
		{
			saveFile.aiCount = ES2.Load<int>("aiCount");
		}
		if (ES2.Exists("yugoGoodTracker"))
		{
			saveFile.yugoGoodTracker = (float)ES2.Load<int>("yugoGoodTracker");
		}
		if (ES2.Exists("waterTankWaterCharges"))
		{
			saveFile.waterTankWaterCharges = ES2.Load<int>("waterTankWaterCharges");
		}
		if (ES2.Exists("waterTankPurist"))
		{
			saveFile.waterTankPurist = ES2.Load<bool>("waterTankPurist");
		}
		if (ES2.Exists("waterTankID"))
		{
			saveFile.waterTankID = ES2.Load<int>("waterTankID");
		}
		if (ES2.Exists("waterTankCondition"))
		{
			saveFile.waterTankCondition = ES2.Load<float>("waterTankCondition");
		}
		if (ES2.Exists("uncleTutorialCompleted"))
		{
			saveFile.uncleTutorialCompleted = ES2.Load<bool>("uncleTutorialCompleted");
		}
		if (ES2.Exists("tyrePoppedStats"))
		{
			saveFile.tyrePoppedStats = ES2.Load<int>("tyrePoppedStats");
		}
		if (ES2.Exists("turkGoodTracker"))
		{
			saveFile.turkGoodTracker = (float)ES2.Load<int>("turkGoodTracker");
		}
		if (ES2.Exists("topSpeedStats"))
		{
			saveFile.topSpeedStats = ES2.Load<float>("topSpeedStats");
		}
		if (ES2.Exists("toolRackWeight"))
		{
			saveFile.toolRackWeight = ES2.Load<int>("toolRackWeight");
		}
		if (ES2.Exists("toolRackLevel"))
		{
			saveFile.toolRackLevel = ES2.Load<int>("toolRackLevel");
		}
		if (ES2.Exists("toolRackInstalled"))
		{
			saveFile.toolRackInstalled = ES2.Load<bool>("toolRackInstalled");
		}
		if (ES2.Exists("shopIsWelcomed"))
		{
			saveFile.shopIsWelcomed = ES2.Load<bool>("shopIsWelcomed");
		}
		if (ES2.Exists("rrWheelID"))
		{
			saveFile.rrWheelID = ES2.Load<int>("rrWheelID");
		}
		if (ES2.Exists("rrWheelDirt"))
		{
			saveFile.rrWheelDirt = ES2.Load<float>("rrWheelDirt");
		}
		if (ES2.Exists("rrWheelCondition"))
		{
			saveFile.rrWheelCondition = ES2.Load<float>("rrWheelCondition");
		}
		if (ES2.Exists("rrTyrePurist"))
		{
			saveFile.rrTyrePurist = ES2.Load<bool>("rrTyrePurist");
		}
		if (ES2.Exists("rrCompoundID"))
		{
			saveFile.rrCompoundID = (float)ES2.Load<int>("rrCompoundID");
		}
		if (ES2.Exists("routeLevel"))
		{
			saveFile.routeLevel = ES2.Load<int>("routeLevel");
		}
		if (ES2.Exists("rlWheelID"))
		{
			saveFile.rlWheelID = ES2.Load<int>("rlWheelID");
		}
		if (ES2.Exists("rlWheelDirt"))
		{
			saveFile.rlWheelDirt = ES2.Load<float>("rlWheelDirt");
		}
		if (ES2.Exists("rlWheelCondition"))
		{
			saveFile.rlWheelCondition = ES2.Load<float>("rlWheelCondition");
		}
		if (ES2.Exists("rlTyrePurist"))
		{
			saveFile.rlTyrePurist = ES2.Load<bool>("rlTyrePurist");
		}
		if (ES2.Exists("rlCompoundID"))
		{
			saveFile.rlCompoundID = (float)ES2.Load<int>("rlCompoundID");
		}
		if (ES2.Exists("repairKitsUsedStats"))
		{
			saveFile.repairKitsUsedStats = ES2.Load<int>("repairKitsUsedStats");
		}
		if (ES2.Exists("rearWindowDirt"))
		{
			saveFile.rearWindowDirt = ES2.Load<float>("rearWindowDirt");
		}
		if (ES2.Exists("rearrsideDirt"))
		{
			saveFile.rearrsideDirt = ES2.Load<float>("rearrsideDirt");
		}
		if (ES2.Exists("rearRightWindowDirt"))
		{
			saveFile.rearRightWindowDirt = ES2.Load<float>("rearRightWindowDirt");
		}
		if (ES2.Exists("rearlsideDirt"))
		{
			saveFile.rearlsideDirt = ES2.Load<float>("rearlsideDirt");
		}
		if (ES2.Exists("rearLeftWindowDirt"))
		{
			saveFile.rearLeftWindowDirt = ES2.Load<float>("rearLeftWindowDirt");
		}
		if (ES2.Exists("rearDirt"))
		{
			saveFile.rearDirt = ES2.Load<float>("rearDirt");
		}
		if (ES2.Exists("plateStringIDDate"))
		{
			saveFile.plateStringIDDate = ES2.Load<int>("plateStringIDDate");
		}
		if (ES2.Exists("plateStringID"))
		{
			saveFile.plateStringID = ES2.Load<int>("plateStringID");
		}
		if (ES2.Exists("padInput2"))
		{
			saveFile.padInput2 = ES2.Load<int>("padInput2");
		}
		if (ES2.Exists("odometerTotalDistance"))
		{
			saveFile.odometerTotalDistance = ES2.Load<float>("odometerTotalDistance");
		}
		if (ES2.Exists("mouseSmooth"))
		{
			saveFile.mouseSmooth = ES2.Load<bool>("mouseSmooth");
		}
		if (ES2.Exists("mouseSensitivity"))
		{
			saveFile.mouseSensitivity = ES2.Load<float>("mouseSensitivity");
		}
		if (ES2.Exists("moneyAmount"))
		{
			saveFile.moneyAmount = (float)ES2.Load<int>("moneyAmount");
		}
		if (ES2.Exists("mirrorEnabled"))
		{
			saveFile.mirrorEnabled = ES2.Load<bool>("mirrorEnabled");
			if (saveFile.mirrorEnabled)
			{
				saveFile.mirrorState = 3;
			}
		}
		if (ES2.Exists("lookInvert"))
		{
			saveFile.lookInvert = ES2.Load<bool>("lookInvert");
		}
		if (ES2.Exists("ignitionCoilPurist"))
		{
			saveFile.ignitionCoilPurist = ES2.Load<bool>("ignitionCoilPurist");
		}
		if (ES2.Exists("ignitionCoilID"))
		{
			saveFile.ignitionCoilID = ES2.Load<int>("ignitionCoilID");
		}
		if (ES2.Exists("ignitionCoilCondition"))
		{
			saveFile.ignitionCoilCondition = ES2.Load<float>("ignitionCoilCondition");
		}
		if (ES2.Exists("hunGoodTracker"))
		{
			saveFile.hunGoodTracker = (float)ES2.Load<int>("hunGoodTracker");
		}
		if (ES2.Exists("gerGoodTracker"))
		{
			saveFile.gerGoodTracker = (float)ES2.Load<int>("gerGoodTracker");
		}
		if (ES2.Exists("fuelUsedStats"))
		{
			saveFile.fuelUsedStats = ES2.Load<float>("fuelUsedStats");
		}
		if (ES2.Exists("fuelTankPurist"))
		{
			saveFile.fuelTankPurist = ES2.Load<bool>("fuelTankPurist");
		}
		if (ES2.Exists("fuelTankID"))
		{
			saveFile.fuelTankID = ES2.Load<int>("fuelTankID");
		}
		if (ES2.Exists("fuelTankFuelMix"))
		{
			saveFile.fuelTankFuelMix = ES2.Load<int>("fuelTankFuelMix");
		}
		if (ES2.Exists("fuelTankFuelAmount"))
		{
			saveFile.fuelTankFuelAmount = ES2.Load<float>("fuelTankFuelAmount");
		}
		if (ES2.Exists("fuelTankCondition"))
		{
			saveFile.fuelTankCondition = ES2.Load<float>("fuelTankCondition");
		}
		if (ES2.Exists("frWheelID"))
		{
			saveFile.frWheelID = ES2.Load<int>("frWheelID");
		}
		if (ES2.Exists("frWheelDirt"))
		{
			saveFile.frWheelDirt = ES2.Load<float>("frWheelDirt");
		}
		if (ES2.Exists("frWheelCondition"))
		{
			saveFile.frWheelCondition = ES2.Load<float>("frWheelCondition");
		}
		if (ES2.Exists("frTyrePurist"))
		{
			saveFile.frTyrePurist = ES2.Load<bool>("frTyrePurist");
		}
		if (ES2.Exists("frontWindowDirtWipers"))
		{
			saveFile.frontWindowDirtWipers = ES2.Load<float>("frontWindowDirtWipers");
		}
		if (ES2.Exists("frontWindowDirtSmudge"))
		{
			saveFile.frontWindowDirtSmudge = ES2.Load<float>("frontWindowDirtSmudge");
		}
		if (ES2.Exists("frontWindowDirtRim"))
		{
			saveFile.frontWindowDirtRim = ES2.Load<float>("frontWindowDirtRim");
		}
		if (ES2.Exists("frontRightWindowDirt"))
		{
			saveFile.frontRightWindowDirt = ES2.Load<float>("frontRightWindowDirt");
		}
		if (ES2.Exists("frontLeftWindowDirt"))
		{
			saveFile.frontLeftWindowDirt = ES2.Load<float>("frontLeftWindowDirt");
		}
		if (ES2.Exists("frntrsideDirt"))
		{
			saveFile.frntrsideDirt = ES2.Load<float>("frntrsideDirt");
		}
		if (ES2.Exists("frntlsideDirt"))
		{
			saveFile.frntlsideDirt = ES2.Load<float>("frntlsideDirt");
		}
		if (ES2.Exists("frntDirt"))
		{
			saveFile.frntDirt = ES2.Load<float>("frntDirt");
		}
		if (ES2.Exists("frCompoundID"))
		{
			saveFile.frCompoundID = (float)ES2.Load<int>("frCompoundID");
		}
		if (ES2.Exists("footStepsCounter"))
		{
			saveFile.footStepsCounter = ES2.Load<int>("footStepsCounter");
		}
		if (ES2.Exists("flWheelID"))
		{
			saveFile.flWheelID = ES2.Load<int>("flWheelID");
		}
		if (ES2.Exists("flWheelDirt"))
		{
			saveFile.flWheelDirt = ES2.Load<float>("flWheelDirt");
		}
		if (ES2.Exists("flWheelCondition"))
		{
			saveFile.flWheelCondition = ES2.Load<float>("flWheelCondition");
		}
		if (ES2.Exists("flTyrePurist"))
		{
			saveFile.flTyrePurist = ES2.Load<bool>("flTyrePurist");
		}
		if (ES2.Exists("flCompoundID"))
		{
			saveFile.flCompoundID = (float)ES2.Load<int>("flCompoundID");
		}
		if (ES2.Exists("economyState"))
		{
			saveFile.economyState = ES2.Load<int>("economyState");
		}
		if (ES2.Exists("doorrsideDirt2"))
		{
			saveFile.doorrsideDirt2 = ES2.Load<float>("doorrsideDirt2");
		}
		if (ES2.Exists("doorrsideDirt"))
		{
			saveFile.doorrsideDirt = ES2.Load<float>("doorrsideDirt");
		}
		if (ES2.Exists("doorlsideDirt2"))
		{
			saveFile.doorlsideDirt2 = ES2.Load<float>("doorlsideDirt2");
		}
		if (ES2.Exists("doorlsideDirt"))
		{
			saveFile.doorlsideDirt = ES2.Load<float>("doorlsideDirt");
		}
		if (ES2.Exists("doorFitted"))
		{
			saveFile.doorFitted = ES2.Load<bool>("doorFitted");
		}
		if (ES2.Exists("daysPassed"))
		{
			saveFile.daysPassed = ES2.Load<int>("daysPassed");
		}
		if (ES2.Exists("customDecal"))
		{
			saveFile.customDecal = ES2.Load<int>("customDecal");
		}
		if (ES2.Exists("csfrGoodTracker"))
		{
			saveFile.csfrGoodTracker = (float)ES2.Load<int>("csfrGoodTracker");
		}
		if (ES2.Exists("cleanedTimes"))
		{
			saveFile.cleanedTimes = ES2.Load<int>("cleanedTimes");
		}
		if (ES2.Exists("carEnginePurist"))
		{
			saveFile.carEnginePurist = ES2.Load<bool>("carEnginePurist");
		}
		if (ES2.Exists("carEngineID"))
		{
			saveFile.carEngineID = ES2.Load<int>("carEngineID");
		}
		if (ES2.Exists("carEngineCondition"))
		{
			saveFile.carEngineCondition = ES2.Load<float>("carEngineCondition");
		}
		if (ES2.Exists("carburettorPurist"))
		{
			saveFile.carburettorPurist = ES2.Load<bool>("carburettorPurist");
		}
		if (ES2.Exists("carburettorID"))
		{
			saveFile.carburettorID = ES2.Load<int>("carburettorID");
		}
		if (ES2.Exists("carburettorCondition"))
		{
			saveFile.carburettorCondition = ES2.Load<float>("carburettorCondition");
		}
		if (ES2.Exists("bulGoodTracker"))
		{
			saveFile.bulGoodTracker = (float)ES2.Load<int>("bulGoodTracker");
		}
		if (ES2.Exists("batteryPurist"))
		{
			saveFile.batteryPurist = ES2.Load<bool>("batteryPurist");
		}
		if (ES2.Exists("batteryID"))
		{
			saveFile.batteryID = ES2.Load<int>("batteryID");
		}
		if (ES2.Exists("batteryCondition"))
		{
			saveFile.batteryCondition = ES2.Load<float>("batteryCondition");
		}
		if (ES2.Exists("batteryCharges"))
		{
			saveFile.batteryCharges = ES2.Load<float>("batteryCharges");
		}
		if (ES2.Exists("alarmSilent"))
		{
			saveFile.alarmSilent = ES2.Load<bool>("alarmSilent");
		}
		if (ES2.Exists("airFilterPurist"))
		{
			saveFile.airFilterPurist = ES2.Load<bool>("airFilterPurist");
		}
		if (ES2.Exists("airFilterID"))
		{
			saveFile.airFilterID = ES2.Load<int>("airFilterID");
		}
		if (ES2.Exists("airFilterCondition"))
		{
			saveFile.airFilterCondition = ES2.Load<float>("airFilterCondition");
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintBonnet"))
		{
			saveFile.customPaintBonnet = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintBonnet"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintBonnet"))
		{
			saveFile.customMetallicPaintBonnet = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintBonnet"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintFrame"))
		{
			saveFile.customPaintFrame = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintFrame"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintFrame"))
		{
			saveFile.customMetallicPaintFrame = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintFrame"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintIntFloor"))
		{
			saveFile.customPaintIntFloor = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintIntFloor"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintIntFloor"))
		{
			saveFile.customMetallicPaintIntFloor = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintIntFloor"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintLDoor"))
		{
			saveFile.customPaintLDoor = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintLDoor"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintLDoor"))
		{
			saveFile.customMetallicPaintLDoor = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintLDoor"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintRDoor"))
		{
			saveFile.customPaintRDoor = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintRDoor"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintRDoor"))
		{
			saveFile.customMetallicPaintRDoor = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintRDoor"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintLHLight"))
		{
			saveFile.customPaintLHLight = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintLHLight"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintLHLight"))
		{
			saveFile.customMetallicPaintLHLight = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintLHLight"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintRHLight"))
		{
			saveFile.customPaintRHLight = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintRHLight"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintRHLight"))
		{
			saveFile.customMetallicPaintRHLight = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintRHLight"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintRoof"))
		{
			saveFile.customPaintRoof = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintRoof"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customMetallicPaintRoof"))
		{
			saveFile.customMetallicPaintRoof = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintRoof"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintTrunk"))
		{
			saveFile.customPaintTrunk = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customPaintTrunk"));
		}
		if (ES2.Exists("trabbiPaint.txt?tag=customPaintTrunk"))
		{
			saveFile.customPaintTrunk = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customMetallicPaintTrunk"));
		}
		if (ES2.Exists("customDecal"))
		{
			saveFile.customDecalColor = new ColorClass(ES2.Load<Color>("trabbiPaint.txt?tag=customDecalColor"));
			saveFile.customDecal = ES2.Load<int>("customDecal");
		}
		if (ES2.Exists("inventorySave.txt?tag=fuelCanLevels"))
		{
			saveFile.fuelCanLevels = ES2.LoadList<int>("inventorySave.txt?tag=fuelCanLevels");
		}
		if (ES2.Exists("inventorySave.txt?tag=fuelCanMixs"))
		{
			saveFile.fuelCanMixs = ES2.LoadList<int>("inventorySave.txt?tag=fuelCanMixs");
		}
		if (ES2.Exists("inventorySave.txt?tag=fuelCanMixs"))
		{
			saveFile.fuelCanMixs = ES2.LoadList<int>("inventorySave.txt?tag=fuelCanMixs");
		}
		if (ES2.Exists("inventorySave.txt?tag=oilBottleLevels"))
		{
			saveFile.oilBottleLevels = ES2.LoadList<int>("inventorySave.txt?tag=oilBottleLevels");
		}
		if (ES2.Exists("inventorySave.txt?tag=componentConditions"))
		{
			saveFile.componentConditions = ES2.LoadList<float>("inventorySave.txt?tag=componentConditions");
		}
		if (ES2.Exists("inventorySave.txt?tag=componentFuels"))
		{
			saveFile.componentFuels = ES2.LoadList<float>("inventorySave.txt?tag=componentFuels");
		}
		if (ES2.Exists("inventorySave.txt?tag=componentFuelMixs"))
		{
			saveFile.componentFuelMixs = ES2.LoadList<int>("inventorySave.txt?tag=componentFuelMixs");
		}
		if (ES2.Exists("inventorySave.txt?tag=componentCharges"))
		{
			saveFile.componentCharges = ES2.LoadList<float>("inventorySave.txt?tag=componentCharges");
		}
		if (ES2.Exists("inventorySave.txt?tag=componentWaters"))
		{
			saveFile.componentWaters = ES2.LoadList<int>("inventorySave.txt?tag=componentWaters");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveListsTyres"))
		{
			saveFile.bootInventorySaveListsTyres = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveListsTyres");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists3x2x1"))
		{
			saveFile.bootInventorySaveLists3x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists3x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs3x2x1"))
		{
			saveFile.bootInventorySaveLocs3x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs3x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists2x2x1"))
		{
			saveFile.bootInventorySaveLists2x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists2x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs2x2x1"))
		{
			saveFile.bootInventorySaveLocs2x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs2x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists3x2x3"))
		{
			saveFile.bootInventorySaveLists3x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists3x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs3x2x3"))
		{
			saveFile.bootInventorySaveLocs3x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs3x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists4x2x2"))
		{
			saveFile.bootInventorySaveLists4x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists4x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs4x2x2"))
		{
			saveFile.bootInventorySaveLocs4x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs4x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists4x2x1"))
		{
			saveFile.bootInventorySaveLists4x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists4x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs4x2x1"))
		{
			saveFile.bootInventorySaveLocs4x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs4x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveList"))
		{
			saveFile.roofInventorySaveList = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveList");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocsSingle"))
		{
			saveFile.roofInventorySaveLocsSingle = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocsSingle");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventoryTradeGoodsSmallIDSaveList"))
		{
			saveFile.roofInventoryTradeGoodsSmallIDSaveList = ES2.LoadList<int>("inventorySave.txt?tag=roofInventoryTradeGoodsSmallIDSaveList");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists3x2x1"))
		{
			saveFile.roofInventorySaveLists3x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists3x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs3x2x1"))
		{
			saveFile.roofInventorySaveLocs3x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs3x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists2x2x1"))
		{
			saveFile.roofInventorySaveLists2x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists2x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs2x2x1"))
		{
			saveFile.roofInventorySaveLocs2x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs2x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists2x2x3"))
		{
			saveFile.roofInventorySaveLists2x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists2x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs2x2x3"))
		{
			saveFile.roofInventorySaveLocs2x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs2x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists2x2x2"))
		{
			saveFile.roofInventorySaveLists2x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists2x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs2x2x2"))
		{
			saveFile.roofInventorySaveLocs2x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs2x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists3x2x3"))
		{
			saveFile.roofInventorySaveLists3x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists3x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs3x2x3"))
		{
			saveFile.roofInventorySaveLocs3x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs3x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists4x2x2"))
		{
			saveFile.roofInventorySaveLists4x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists4x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs4x2x2"))
		{
			saveFile.roofInventorySaveLocs4x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs4x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists4x2x3"))
		{
			saveFile.roofInventorySaveLists4x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists4x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs4x2x3"))
		{
			saveFile.roofInventorySaveLocs4x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs4x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists4x1x1"))
		{
			saveFile.roofInventorySaveLists4x1x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists4x1x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs4x1x1"))
		{
			saveFile.roofInventorySaveLocs4x1x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs4x1x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists4x2x1"))
		{
			saveFile.roofInventorySaveLists4x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists4x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs4x2x1"))
		{
			saveFile.roofInventorySaveLocs4x2x1 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs4x2x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLists2x1x3"))
		{
			saveFile.roofInventorySaveLists2x1x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLists2x1x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveLocs2x1x3"))
		{
			saveFile.roofInventorySaveLocs2x1x3 = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveLocs2x1x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=roofInventorySaveListsTyres"))
		{
			saveFile.roofInventorySaveListsTyres = ES2.LoadList<int>("inventorySave.txt?tag=roofInventorySaveListsTyres");
		}
		if (ES2.Exists("inventorySave.txt?tag=basketInventorySaveList"))
		{
			saveFile.basketInventorySaveList = ES2.LoadList<int>("inventorySave.txt?tag=basketInventorySaveList");
		}
		if (ES2.Exists("inventorySave.txt?tag=currentBasketsInInventory"))
		{
			saveFile.currentBasketsInInventory = ES2.LoadList<int>("inventorySave.txt?tag=currentBasketsInInventory");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists2x2x2"))
		{
			saveFile.bootInventorySaveLists2x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists2x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs2x2x2"))
		{
			saveFile.bootInventorySaveLocs2x2x2 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs2x2x2");
		}
		if (ES2.Exists("inventorySave.txt?tag=waterBottleLevels"))
		{
			saveFile.waterBottleLevels = ES2.LoadList<int>("inventorySave.txt?tag=waterBottleLevels");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists2x1x3"))
		{
			saveFile.bootInventorySaveLists2x1x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists2x1x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs2x1x3"))
		{
			saveFile.bootInventorySaveLocs2x1x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs2x1x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists2x2x3"))
		{
			saveFile.bootInventorySaveLists2x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists2x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs2x2x3"))
		{
			saveFile.bootInventorySaveLocs2x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs2x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists4x2x3"))
		{
			saveFile.bootInventorySaveLists4x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists4x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs4x2x3"))
		{
			saveFile.bootInventorySaveLocs4x2x3 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs4x2x3");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLists4x1x1"))
		{
			saveFile.bootInventorySaveLists4x1x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLists4x1x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocs4x1x1"))
		{
			saveFile.bootInventorySaveLocs4x1x1 = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocs4x1x1");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveList"))
		{
			saveFile.bootInventorySaveList = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveList");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventorySaveLocsSingle"))
		{
			saveFile.bootInventorySaveLocsSingle = ES2.LoadList<int>("inventorySave.txt?tag=bootInventorySaveLocsSingle");
		}
		if (ES2.Exists("inventorySave.txt?tag=bootInventoryTradegoodsSmallIDSaveList"))
		{
			saveFile.bootInventoryTradegoodsSmallIDSaveList = ES2.LoadList<int>("inventorySave.txt?tag=bootInventoryTradegoodsSmallIDSaveList");
		}
		if (ES2.Exists("keyboardInputs.txt?tag=assignedInputStrings"))
		{
			saveFile.assignedInputStrings = ES2.LoadList<string>("keyboardInputs.txt?tag=assignedInputStrings");
		}
		if (ES2.Exists("hubSpawn.txt?tag=motelRoomAssigned"))
		{
			saveFile.motelRoomAssigned = ES2.Load<int>("hubSpawn.txt?tag=motelRoomAssigned");
		}
		if (ES2.Exists("hubSpawn.txt?tag=primaryBuildingSaveList1"))
		{
			saveFile.primaryBuildingSaveList1 = ES2.LoadList<int>("hubSpawn.txt?tag=primaryBuildingSaveList1");
		}
		if (ES2.Exists("hubSpawn.txt?tag=primaryBuildingSaveList2"))
		{
			saveFile.primaryBuildingSaveList2 = ES2.LoadList<int>("hubSpawn.txt?tag=primaryBuildingSaveList2");
		}
		if (ES2.Exists("hubSpawn.txt?tag=primaryBuildingSaveList3"))
		{
			saveFile.primaryBuildingSaveList3 = ES2.LoadList<int>("hubSpawn.txt?tag=primaryBuildingSaveList3");
		}
		if (ES2.Exists("hubSpawn.txt?tag=primaryBuildingSaveList4"))
		{
			saveFile.primaryBuildingSaveList4 = ES2.LoadList<int>("hubSpawn.txt?tag=primaryBuildingSaveList4");
		}
		if (ES2.Exists("hubSpawn.txt?tag=primaryBuildingSaveList5"))
		{
			saveFile.primaryBuildingSaveList5 = ES2.LoadList<int>("hubSpawn.txt?tag=primaryBuildingSaveList5");
		}
		if (ES2.Exists("hubSpawn.txt?tag=primaryBuildingSaveList6"))
		{
			saveFile.primaryBuildingSaveList6 = ES2.LoadList<int>("hubSpawn.txt?tag=primaryBuildingSaveList6");
		}
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream fileStream = File.Create(Application.persistentDataPath + "/Saves/Save.sfminsk");
		binaryFormatter.Serialize(fileStream, saveFile);
		fileStream.Close();
	}
}
