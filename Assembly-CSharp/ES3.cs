using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Token: 0x0200002B RID: 43
public class ES3 : MonoBehaviour
{
	// Token: 0x060000F2 RID: 242 RVA: 0x0000C76C File Offset: 0x0000AB6C
	private void Awake()
	{
		if (ES3.Global != null && ES3.Global != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		ES3.Global = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.LoadSaveFile();
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0000C7BC File Offset: 0x0000ABBC
	private void OnDestroy()
	{
		if (ES3.Global == this)
		{
		}
		ES3.Global = null;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000C7D4 File Offset: 0x0000ABD4
	private void LoadSaveFile()
	{
		if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
		}
		if (File.Exists(Application.persistentDataPath + "/Saves/Save.sfminsk"))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = File.Open(Application.persistentDataPath + "/Saves/Save.sfminsk", FileMode.Open);
			ES3.loadedSave = (SaveFile)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		else
		{
			ES3.loadedSave = new SaveFile();
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000C86C File Offset: 0x0000AC6C
	public static void SaveFiles()
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		if (File.Exists(Application.persistentDataPath + "/Saves/Save.sfminsk"))
		{
			if (!Directory.Exists(Application.persistentDataPath + "/Saves/Backups"))
			{
				Directory.CreateDirectory(Application.persistentDataPath + "/Saves/Backups");
			}
			File.Copy(Application.persistentDataPath + "/Saves/Save.sfminsk", Application.persistentDataPath + string.Format("/Saves/Backups/Backup Save {0}.sfminsk", DateTime.Now.ToString().Replace('/', '_').Replace(':', '_')));
		}
		File.Delete(Application.persistentDataPath + "/Saves/Save.sfminsk");
		FileStream fileStream = File.Create(Application.persistentDataPath + "/Saves/Save.sfminsk");
		binaryFormatter.Serialize(fileStream, ES3.loadedSave);
		fileStream.Close();
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x0000C94E File Offset: 0x0000AD4E
	[ContextMenu("Save")]
	private void SaveS()
	{
		ES3.SaveFiles();
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x0000C958 File Offset: 0x0000AD58
	public static void Save(float value, string identifier)
	{
		if (identifier == "fov")
		{
			ES3.loadedSave.fov = value;
			return;
		}
		if (identifier == "masterVolume")
		{
			ES3.loadedSave.masterVolume = value;
			MonoBehaviour.print(value);
			return;
		}
		if (identifier == "effectsVolume")
		{
			ES3.loadedSave.effectsVolume = value;
			return;
		}
		if (identifier == "musicVolume")
		{
			ES3.loadedSave.musicVolume = value;
			return;
		}
		if (identifier == "odometerTotalDistance")
		{
			ES3.loadedSave.odometerTotalDistance = value;
			return;
		}
		if (identifier == "mouseSensitivity")
		{
			ES3.loadedSave.mouseSensitivity = value;
			return;
		}
		if (identifier == "gerGoodTracker")
		{
			ES3.loadedSave.gerGoodTracker = value;
			return;
		}
		if (identifier == "csfrGoodTracker")
		{
			ES3.loadedSave.csfrGoodTracker = value;
			return;
		}
		if (identifier == "hunGoodTracker")
		{
			ES3.loadedSave.hunGoodTracker = value;
			return;
		}
		if (identifier == "yugoGoodTracker")
		{
			ES3.loadedSave.yugoGoodTracker = value;
			return;
		}
		if (identifier == "bulGoodTracker")
		{
			ES3.loadedSave.bulGoodTracker = value;
			return;
		}
		if (identifier == "turkGoodTracker")
		{
			ES3.loadedSave.turkGoodTracker = value;
			return;
		}
		if (identifier == "frntDirt")
		{
			ES3.loadedSave.frntDirt = value;
			return;
		}
		if (identifier == "rearDirt")
		{
			ES3.loadedSave.rearDirt = value;
			return;
		}
		if (identifier == "frntlsideDirt")
		{
			ES3.loadedSave.frntlsideDirt = value;
			return;
		}
		if (identifier == "doorlsideDirt")
		{
			ES3.loadedSave.doorlsideDirt = value;
			return;
		}
		if (identifier == "doorlsideDirt2")
		{
			ES3.loadedSave.doorlsideDirt2 = value;
			return;
		}
		if (identifier == "rearlsideDirt")
		{
			ES3.loadedSave.rearlsideDirt = value;
			return;
		}
		if (identifier == "frntrsideDirt")
		{
			ES3.loadedSave.frntrsideDirt = value;
			return;
		}
		if (identifier == "doorrsideDirt")
		{
			ES3.loadedSave.doorrsideDirt = value;
			return;
		}
		if (identifier == "doorrsideDirt2")
		{
			ES3.loadedSave.doorrsideDirt2 = value;
			return;
		}
		if (identifier == "rearrsideDirt")
		{
			ES3.loadedSave.rearrsideDirt = value;
			return;
		}
		if (identifier == "flWheelDirt")
		{
			ES3.loadedSave.flWheelDirt = value;
			return;
		}
		if (identifier == "frWheelDirt")
		{
			ES3.loadedSave.frWheelDirt = value;
			return;
		}
		if (identifier == "rrWheelDirt")
		{
			ES3.loadedSave.rrWheelDirt = value;
			return;
		}
		if (identifier == "rlWheelDirt")
		{
			ES3.loadedSave.rlWheelDirt = value;
			return;
		}
		if (identifier == "frontWindowDirtRim")
		{
			ES3.loadedSave.frontWindowDirtRim = value;
			return;
		}
		if (identifier == "frontWindowDirtWipers")
		{
			ES3.loadedSave.frontWindowDirtWipers = value;
			return;
		}
		if (identifier == "frontWindowDirtSmudge")
		{
			ES3.loadedSave.frontWindowDirtSmudge = value;
			return;
		}
		if (identifier == "frontLeftWindowDirt")
		{
			ES3.loadedSave.frontLeftWindowDirt = value;
			return;
		}
		if (identifier == "frontRightWindowDirt")
		{
			ES3.loadedSave.frontRightWindowDirt = value;
			return;
		}
		if (identifier == "rearLeftWindowDirt")
		{
			ES3.loadedSave.rearLeftWindowDirt = value;
			return;
		}
		if (identifier == "rearRightWindowDirt")
		{
			ES3.loadedSave.rearRightWindowDirt = value;
			return;
		}
		if (identifier == "rearWindowDirt")
		{
			ES3.loadedSave.rearWindowDirt = value;
			return;
		}
		if (identifier == "airFilterCondition")
		{
			ES3.loadedSave.airFilterCondition = value;
			return;
		}
		if (identifier == "carEngineCondition")
		{
			ES3.loadedSave.carEngineCondition = value;
			return;
		}
		if (identifier == "ignitionCoilCondition")
		{
			ES3.loadedSave.ignitionCoilCondition = value;
			return;
		}
		if (identifier == "fuelTankCondition")
		{
			ES3.loadedSave.fuelTankCondition = value;
			return;
		}
		if (identifier == "fuelTankFuelAmount")
		{
			ES3.loadedSave.fuelTankFuelAmount = value;
			return;
		}
		if (identifier == "carburettorCondition")
		{
			ES3.loadedSave.carburettorCondition = value;
			return;
		}
		if (identifier == "waterTankCondition")
		{
			ES3.loadedSave.waterTankCondition = value;
			return;
		}
		if (identifier == "batteryCondition")
		{
			ES3.loadedSave.batteryCondition = value;
			return;
		}
		if (identifier == "batteryCharges")
		{
			ES3.loadedSave.batteryCharges = value;
			return;
		}
		if (identifier == "flWheelCondition")
		{
			ES3.loadedSave.flWheelCondition = value;
			return;
		}
		if (identifier == "rlWheelCondition")
		{
			ES3.loadedSave.rlWheelCondition = value;
			return;
		}
		if (identifier == "rrWheelCondition")
		{
			ES3.loadedSave.rrWheelCondition = value;
			return;
		}
		if (identifier == "frWheelCondition")
		{
			ES3.loadedSave.frWheelCondition = value;
			return;
		}
		if (identifier == "flCompoundID")
		{
			ES3.loadedSave.flCompoundID = value;
			return;
		}
		if (identifier == "frCompoundID")
		{
			ES3.loadedSave.frCompoundID = value;
			return;
		}
		if (identifier == "rlCompoundID")
		{
			ES3.loadedSave.rlCompoundID = value;
			return;
		}
		if (identifier == "rrCompoundID")
		{
			ES3.loadedSave.rrCompoundID = value;
			return;
		}
		if (identifier == "fuelUsedStats")
		{
			ES3.loadedSave.fuelUsedStats = value;
			return;
		}
		if (identifier == "moneyAmount")
		{
			ES3.loadedSave.moneyAmount = value;
			return;
		}
		if (identifier == "topSpeedStats")
		{
			ES3.loadedSave.topSpeedStats = value;
			return;
		}
		Debug.Log("NOT FOUND SAVING FLOAT - " + identifier);
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0000CF68 File Offset: 0x0000B368
	[ContextMenu("Reset Save")]
	public void Reset()
	{
		ES3.loadedSave = new SaveFile();
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000CF74 File Offset: 0x0000B374
	public static float LoadFloat(string identifier)
	{
		if (identifier == "fov")
		{
			return ES3.loadedSave.fov;
		}
		if (identifier == "masterVolume")
		{
			return ES3.loadedSave.masterVolume;
		}
		if (identifier == "effectsVolume")
		{
			return ES3.loadedSave.effectsVolume;
		}
		if (identifier == "musicVolume")
		{
			return ES3.loadedSave.musicVolume;
		}
		if (identifier == "mouseSensitivity")
		{
			return ES3.loadedSave.mouseSensitivity;
		}
		if (identifier == "airFilterCondition")
		{
			return ES3.loadedSave.airFilterCondition;
		}
		if (identifier == "carEngineCondition")
		{
			return ES3.loadedSave.carEngineCondition;
		}
		if (identifier == "ignitionCoilCondition")
		{
			return ES3.loadedSave.ignitionCoilCondition;
		}
		if (identifier == "fuelTankCondition")
		{
			return ES3.loadedSave.fuelTankCondition;
		}
		if (identifier == "fuelTankFuelAmount")
		{
			return ES3.loadedSave.fuelTankFuelAmount;
		}
		if (identifier == "carburettorCondition")
		{
			return ES3.loadedSave.carburettorCondition;
		}
		if (identifier == "waterTankCondition")
		{
			return ES3.loadedSave.waterTankCondition;
		}
		if (identifier == "batteryCondition")
		{
			return ES3.loadedSave.batteryCondition;
		}
		if (identifier == "batteryCharges")
		{
			return ES3.loadedSave.batteryCharges;
		}
		if (identifier == "flWheelCondition")
		{
			return ES3.loadedSave.flWheelCondition;
		}
		if (identifier == "rlWheelCondition")
		{
			return ES3.loadedSave.rlWheelCondition;
		}
		if (identifier == "rrWheelCondition")
		{
			return ES3.loadedSave.rrWheelCondition;
		}
		if (identifier == "frWheelCondition")
		{
			return ES3.loadedSave.frWheelCondition;
		}
		if (identifier == "gerGoodTracker")
		{
			return ES3.loadedSave.gerGoodTracker;
		}
		if (identifier == "csfrGoodTracker")
		{
			return ES3.loadedSave.csfrGoodTracker;
		}
		if (identifier == "hunGoodTracker")
		{
			return ES3.loadedSave.hunGoodTracker;
		}
		if (identifier == "yugoGoodTracker")
		{
			return ES3.loadedSave.yugoGoodTracker;
		}
		if (identifier == "bulGoodTracker")
		{
			return ES3.loadedSave.bulGoodTracker;
		}
		if (identifier == "turkGoodTracker")
		{
			return ES3.loadedSave.turkGoodTracker;
		}
		if (identifier == "frntDirt")
		{
			return ES3.loadedSave.frntDirt;
		}
		if (identifier == "rearDirt")
		{
			return ES3.loadedSave.rearDirt;
		}
		if (identifier == "frntlsideDirt")
		{
			return ES3.loadedSave.frntlsideDirt;
		}
		if (identifier == "doorlsideDirt")
		{
			return ES3.loadedSave.doorlsideDirt;
		}
		if (identifier == "doorlsideDirt2")
		{
			return ES3.loadedSave.doorlsideDirt2;
		}
		if (identifier == "rearlsideDirt")
		{
			return ES3.loadedSave.rearlsideDirt;
		}
		if (identifier == "frntrsideDirt")
		{
			return ES3.loadedSave.frntrsideDirt;
		}
		if (identifier == "doorrsideDirt")
		{
			return ES3.loadedSave.doorrsideDirt;
		}
		if (identifier == "doorrsideDirt2")
		{
			return ES3.loadedSave.doorrsideDirt2;
		}
		if (identifier == "rearrsideDirt")
		{
			return ES3.loadedSave.rearrsideDirt;
		}
		if (identifier == "flWheelDirt")
		{
			return ES3.loadedSave.flWheelDirt;
		}
		if (identifier == "frWheelDirt")
		{
			return ES3.loadedSave.frWheelDirt;
		}
		if (identifier == "rrWheelDirt")
		{
			return ES3.loadedSave.rrWheelDirt;
		}
		if (identifier == "rlWheelDirt")
		{
			return ES3.loadedSave.rlWheelDirt;
		}
		if (identifier == "frontWindowDirtRim")
		{
			return ES3.loadedSave.frontWindowDirtRim;
		}
		if (identifier == "frontWindowDirtWipers")
		{
			return ES3.loadedSave.frontWindowDirtWipers;
		}
		if (identifier == "frontWindowDirtSmudge")
		{
			return ES3.loadedSave.frontWindowDirtSmudge;
		}
		if (identifier == "frontLeftWindowDirt")
		{
			return ES3.loadedSave.frontLeftWindowDirt;
		}
		if (identifier == "frontRightWindowDirt")
		{
			return ES3.loadedSave.frontRightWindowDirt;
		}
		if (identifier == "rearLeftWindowDirt")
		{
			return ES3.loadedSave.rearLeftWindowDirt;
		}
		if (identifier == "rearRightWindowDirt")
		{
			return ES3.loadedSave.rearRightWindowDirt;
		}
		if (identifier == "rearWindowDirt")
		{
			return ES3.loadedSave.rearWindowDirt;
		}
		if (identifier == "flCompoundID")
		{
			return ES3.loadedSave.flCompoundID;
		}
		if (identifier == "frCompoundID")
		{
			return ES3.loadedSave.frCompoundID;
		}
		if (identifier == "rlCompoundID")
		{
			return ES3.loadedSave.rlCompoundID;
		}
		if (identifier == "rrCompoundID")
		{
			return ES3.loadedSave.rrCompoundID;
		}
		if (identifier == "fuelUsedStats")
		{
			return ES3.loadedSave.fuelUsedStats;
		}
		if (identifier == "moneyAmount")
		{
			return ES3.loadedSave.moneyAmount;
		}
		if (identifier == "topSpeedStats")
		{
			return ES3.loadedSave.topSpeedStats;
		}
		if (identifier == "odometerTotalDistance")
		{
			return ES3.loadedSave.odometerTotalDistance;
		}
		Debug.Log("NOT FOUND LOADING FLOAT - " + identifier);
		return 0f;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000D548 File Offset: 0x0000B948
	public static void Save(bool value, string identifier)
	{
		if (identifier == "stampSave0")
		{
			ES3.loadedSave.stampSave0 = value;
			return;
		}
		if (identifier == "stampSave1")
		{
			ES3.loadedSave.stampSave1 = value;
			return;
		}
		if (identifier == "stampSave2")
		{
			ES3.loadedSave.stampSave2 = value;
			return;
		}
		if (identifier == "stampSave3")
		{
			ES3.loadedSave.stampSave3 = value;
			return;
		}
		if (identifier == "stampSave4")
		{
			ES3.loadedSave.stampSave4 = value;
			return;
		}
		if (identifier == "stampSave5")
		{
			ES3.loadedSave.stampSave5 = value;
			return;
		}
		if (identifier == "shopIsWelcomed")
		{
			ES3.loadedSave.shopIsWelcomed = value;
			return;
		}
		if (identifier == "preventFlickerLight")
		{
			ES3.loadedSave.preventFlickerLight = value;
			return;
		}
		if (identifier == "savedStolenGoods")
		{
			ES3.loadedSave.savedStolenGoods = value;
			return;
		}
		if (identifier == "alarmSilent")
		{
			ES3.loadedSave.alarmSilent = value;
			return;
		}
		if (identifier == "preventFlickeringLights")
		{
			ES3.loadedSave.preventFlickeringLights = value;
			return;
		}
		if (identifier == "lookInvert")
		{
			ES3.loadedSave.lookInvert = value;
			return;
		}
		if (identifier == "carDoorRepaired")
		{
			ES3.loadedSave.carDoorRepaired = value;
			return;
		}
		if (identifier == "aaSetting")
		{
			ES3.loadedSave.aaSetting = value;
			return;
		}
		if (identifier == "ssaoSetting")
		{
			ES3.loadedSave.ssaoSetting = value;
			return;
		}
		if (identifier == "doorFitted")
		{
			ES3.loadedSave.doorFitted = value;
			return;
		}
		if (identifier == "frTyrePurist")
		{
			ES3.loadedSave.frTyrePurist = value;
			return;
		}
		if (identifier == "flTyrePurist")
		{
			ES3.loadedSave.flTyrePurist = value;
			return;
		}
		if (identifier == "batteryPurist")
		{
			ES3.loadedSave.batteryPurist = value;
			return;
		}
		if (identifier == "waterTankPurist")
		{
			ES3.loadedSave.waterTankPurist = value;
			return;
		}
		if (identifier == "carburettorPurist")
		{
			ES3.loadedSave.carburettorPurist = value;
			return;
		}
		if (identifier == "airFilterPurist")
		{
			ES3.loadedSave.airFilterPurist = value;
			return;
		}
		if (identifier == "fuelTankPurist")
		{
			ES3.loadedSave.fuelTankPurist = value;
			return;
		}
		if (identifier == "ignitionCoilPurist")
		{
			ES3.loadedSave.ignitionCoilPurist = value;
			return;
		}
		if (identifier == "carEnginePurist")
		{
			ES3.loadedSave.carEnginePurist = value;
			return;
		}
		if (identifier == "rlTyrePurist")
		{
			ES3.loadedSave.rlTyrePurist = value;
			return;
		}
		if (identifier == "rrTyrePurist")
		{
			ES3.loadedSave.rrTyrePurist = value;
			return;
		}
		if (identifier == "roofRackInstalled")
		{
			ES3.loadedSave.roofRackInstalled = value;
			return;
		}
		if (identifier == "bullBarInstalled")
		{
			ES3.loadedSave.bullBarInstalled = value;
			return;
		}
		if (identifier == "mudGuardsInstalled")
		{
			ES3.loadedSave.mudGuardsInstalled = value;
			return;
		}
		if (identifier == "dashUIInstalled")
		{
			ES3.loadedSave.dashUIInstalled = value;
			return;
		}
		if (identifier == "lightRackInstalled")
		{
			ES3.loadedSave.lightRackInstalled = value;
			return;
		}
		if (identifier == "toolRackInstalled")
		{
			ES3.loadedSave.toolRackInstalled = value;
			return;
		}
		if (identifier == "uncleTutorialCompleted")
		{
			ES3.loadedSave.uncleTutorialCompleted = value;
			return;
		}
		if (identifier == "uncleStoryCompleted")
		{
			ES3.loadedSave.uncleStoryCompleted = value;
			return;
		}
		if (identifier == "mirrorEnabled")
		{
			ES3.loadedSave.mirrorEnabled = value;
			return;
		}
		if (identifier == "mouseSmooth")
		{
			ES3.loadedSave.mouseSmooth = value;
			return;
		}
		if (identifier == "fullScreenState")
		{
			ES3.loadedSave.fullScreenState = value;
			return;
		}
		if (identifier == "carDoorRepaired")
		{
			ES3.loadedSave.carDoorRepaired = value;
			return;
		}
		if (identifier == "home1InventoryInstalled")
		{
			ES3.loadedSave.home1inventoryInstalled = value;
			return;
		}
		if (identifier == "home2InventoryInstalled")
		{
			ES3.loadedSave.home2inventoryInstalled = value;
			return;
		}
		if (identifier == "home3InventoryInstalled")
		{
			ES3.loadedSave.home3inventoryInstalled = value;
			return;
		}
		if (identifier == "home4InventoryInstalled")
		{
			ES3.loadedSave.home4inventoryInstalled = value;
			return;
		}
		if (identifier == "home5InventoryInstalled")
		{
			ES3.loadedSave.home5inventoryInstalled = value;
			return;
		}
		if (identifier == "reticule")
		{
			ES3.loadedSave.reticule = value;
			return;
		}
		Debug.Log("NOT FOUND SAVING BOOL - " + identifier);
	}

	// Token: 0x060000FB RID: 251 RVA: 0x0000DA54 File Offset: 0x0000BE54
	public static bool LoadBool(string identifier)
	{
		if (identifier == "reticule")
		{
			return ES3.loadedSave.reticule;
		}
		if (identifier == "carDoorRepaired")
		{
			return ES3.loadedSave.carDoorRepaired;
		}
		if (identifier == "fullScreenState")
		{
			return ES3.loadedSave.fullScreenState;
		}
		if (identifier == "stampSave0")
		{
			return ES3.loadedSave.stampSave0;
		}
		if (identifier == "stampSave1")
		{
			return ES3.loadedSave.stampSave1;
		}
		if (identifier == "stampSave2")
		{
			return ES3.loadedSave.stampSave2;
		}
		if (identifier == "stampSave3")
		{
			return ES3.loadedSave.stampSave3;
		}
		if (identifier == "stampSave4")
		{
			return ES3.loadedSave.stampSave4;
		}
		if (identifier == "stampSave5")
		{
			return ES3.loadedSave.stampSave5;
		}
		if (identifier == "shopIsWelcomed")
		{
			return ES3.loadedSave.shopIsWelcomed;
		}
		if (identifier == "preventFlickerLight")
		{
			return ES3.loadedSave.preventFlickerLight;
		}
		if (identifier == "savedStolenGoods")
		{
			return ES3.loadedSave.savedStolenGoods;
		}
		if (identifier == "alarmSilent")
		{
			return ES3.loadedSave.alarmSilent;
		}
		if (identifier == "preventFlickeringLights")
		{
			return ES3.loadedSave.preventFlickeringLights;
		}
		if (identifier == "mouseSmooth")
		{
			return ES3.loadedSave.mouseSmooth;
		}
		if (identifier == "carDoorRepaired")
		{
			return ES3.loadedSave.carDoorRepaired;
		}
		if (identifier == "aaSetting")
		{
			return ES3.loadedSave.aaSetting;
		}
		if (identifier == "ssaoSetting")
		{
			return Application.platform == RuntimePlatform.WindowsPlayer && ES3.loadedSave.ssaoSetting;
		}
		if (identifier == "frTyrePurist")
		{
			return ES3.loadedSave.frTyrePurist;
		}
		if (identifier == "flTyrePurist")
		{
			return ES3.loadedSave.flTyrePurist;
		}
		if (identifier == "batteryPurist")
		{
			return ES3.loadedSave.batteryPurist;
		}
		if (identifier == "waterTankPurist")
		{
			return ES3.loadedSave.waterTankPurist;
		}
		if (identifier == "carburettorPurist")
		{
			return ES3.loadedSave.carburettorPurist;
		}
		if (identifier == "airFilterPurist")
		{
			return ES3.loadedSave.airFilterPurist;
		}
		if (identifier == "fuelTankPurist")
		{
			return ES3.loadedSave.fuelTankPurist;
		}
		if (identifier == "ignitionCoilPurist")
		{
			return ES3.loadedSave.ignitionCoilPurist;
		}
		if (identifier == "carEnginePurist")
		{
			return ES3.loadedSave.carEnginePurist;
		}
		if (identifier == "rlTyrePurist")
		{
			return ES3.loadedSave.rlTyrePurist;
		}
		if (identifier == "rrTyrePurist")
		{
			return ES3.loadedSave.rrTyrePurist;
		}
		if (identifier == "doorFitted")
		{
			return ES3.loadedSave.doorFitted;
		}
		if (identifier == "roofRackInstalled")
		{
			return ES3.loadedSave.roofRackInstalled;
		}
		if (identifier == "bullBarInstalled")
		{
			return ES3.loadedSave.bullBarInstalled;
		}
		if (identifier == "mudGuardsInstalled")
		{
			return ES3.loadedSave.mudGuardsInstalled;
		}
		if (identifier == "dashUIInstalled")
		{
			return ES3.loadedSave.dashUIInstalled;
		}
		if (identifier == "lightRackInstalled")
		{
			return ES3.loadedSave.lightRackInstalled;
		}
		if (identifier == "toolRackInstalled")
		{
			return ES3.loadedSave.toolRackInstalled;
		}
		if (identifier == "uncleTutorialCompleted")
		{
			return ES3.loadedSave.uncleTutorialCompleted;
		}
		if (identifier == "uncleStoryCompleted")
		{
			return ES3.loadedSave.uncleStoryCompleted;
		}
		if (identifier == "lookInvert")
		{
			return ES3.loadedSave.lookInvert;
		}
		if (identifier == "mirrorEnabled")
		{
			return ES3.loadedSave.mirrorEnabled;
		}
		if (identifier == "home1InventoryInstalled")
		{
			return ES3.loadedSave.home1inventoryInstalled;
		}
		if (identifier == "home2InventoryInstalled")
		{
			return ES3.loadedSave.home2inventoryInstalled;
		}
		if (identifier == "home3InventoryInstalled")
		{
			return ES3.loadedSave.home3inventoryInstalled;
		}
		if (identifier == "home4InventoryInstalled")
		{
			return ES3.loadedSave.home4inventoryInstalled;
		}
		if (identifier == "home5InventoryInstalled")
		{
			return ES3.loadedSave.home5inventoryInstalled;
		}
		Debug.Log("NOT FOUND LOADING BOOL - " + identifier);
		return false;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0000DF40 File Offset: 0x0000C340
	public static void Save(int value, string identifier)
	{
		if (identifier == "mirrorState")
		{
			ES3.loadedSave.mirrorState = value;
			return;
		}
		if (identifier == "plateStringIDDate")
		{
			ES3.loadedSave.plateStringIDDate = value;
			return;
		}
		if (identifier == "newMonitorIndex")
		{
			ES3.loadedSave.newMonitorIndex = value;
			return;
		}
		if (identifier == "motelRoomAssigned")
		{
			ES3.loadedSave.motelRoomAssigned = value;
			return;
		}
		if (identifier == "routeLevel")
		{
			ES3.loadedSave.routeLevel = value;
			return;
		}
		if (identifier == "plateStringID")
		{
			ES3.loadedSave.plateStringID = value;
			return;
		}
		if (identifier == "resolutionX")
		{
			ES3.loadedSave.resolutionX = value;
			return;
		}
		if (identifier == "resolutionY")
		{
			ES3.loadedSave.resolutionY = value;
			return;
		}
		if (identifier == "vSyncState")
		{
			ES3.loadedSave.vSyncState = value;
			return;
		}
		if (identifier == "aiCount")
		{
			ES3.loadedSave.aiCount = value;
			return;
		}
		if (identifier == "qualityState")
		{
			ES3.loadedSave.qualityState = value;
			return;
		}
		if (identifier == "padInput2")
		{
			ES3.loadedSave.padInput2 = value;
			return;
		}
		if (identifier == "cleanedTimes")
		{
			ES3.loadedSave.cleanedTimes = value;
			return;
		}
		if (identifier == "carEngineID")
		{
			ES3.loadedSave.carEngineID = value;
			return;
		}
		if (identifier == "ignitionCoilID")
		{
			ES3.loadedSave.ignitionCoilID = value;
			return;
		}
		if (identifier == "fuelTankID")
		{
			ES3.loadedSave.fuelTankID = value;
			return;
		}
		if (identifier == "carburettorID")
		{
			ES3.loadedSave.carburettorID = value;
			return;
		}
		if (identifier == "airFilterID")
		{
			ES3.loadedSave.airFilterID = value;
			return;
		}
		if (identifier == "waterTankID")
		{
			ES3.loadedSave.waterTankID = value;
			return;
		}
		if (identifier == "batteryID")
		{
			ES3.loadedSave.batteryID = value;
			return;
		}
		if (identifier == "frWheelID")
		{
			ES3.loadedSave.frWheelID = value;
			return;
		}
		if (identifier == "flWheelID")
		{
			ES3.loadedSave.flWheelID = value;
			return;
		}
		if (identifier == "rrWheelID")
		{
			ES3.loadedSave.rrWheelID = value;
			return;
		}
		if (identifier == "rlWheelID")
		{
			ES3.loadedSave.rlWheelID = value;
			return;
		}
		if (identifier == "toolRackWeight")
		{
			ES3.loadedSave.toolRackWeight = value;
			return;
		}
		if (identifier == "toolRackLevel")
		{
			ES3.loadedSave.toolRackLevel = value;
			return;
		}
		if (identifier == "roofRackWeight")
		{
			ES3.loadedSave.roofRackWeight = value;
			return;
		}
		if (identifier == "lightRackWeight")
		{
			ES3.loadedSave.lightRackWeight = value;
			return;
		}
		if (identifier == "dashUIWeight")
		{
			ES3.loadedSave.dashUIWeight = value;
			return;
		}
		if (identifier == "mudGuardsWeight")
		{
			ES3.loadedSave.mudGuardsWeight = value;
			return;
		}
		if (identifier == "bullBarWeight")
		{
			ES3.loadedSave.bullBarWeight = value;
			return;
		}
		if (identifier == "tyrePoppedStats")
		{
			ES3.loadedSave.tyrePoppedStats = value;
			return;
		}
		if (identifier == "repairKitsUsedStats")
		{
			ES3.loadedSave.repairKitsUsedStats = value;
			return;
		}
		if (identifier == "daysPassed")
		{
			ES3.loadedSave.daysPassed = value;
			return;
		}
		if (identifier == "footStepsCounter")
		{
			ES3.loadedSave.footStepsCounter = value;
			return;
		}
		if (identifier == "customDecal")
		{
			ES3.loadedSave.customDecal = value;
			return;
		}
		if (identifier == "economyState")
		{
			ES3.loadedSave.economyState = value;
			return;
		}
		if (identifier == "fuelTankFuelMix")
		{
			ES3.loadedSave.fuelTankFuelMix = value;
			return;
		}
		if (identifier == "waterTankWaterCharges")
		{
			ES3.loadedSave.waterTankWaterCharges = value;
			return;
		}
		if (identifier == "padInput")
		{
			ES3.loadedSave.padInput2 = value;
			return;
		}
		Debug.Log("NOT FOUND SAVING INT - " + identifier);
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0000E3C0 File Offset: 0x0000C7C0
	public static int LoadInt(string identifier)
	{
		if (identifier == "mirrorState")
		{
			return ES3.loadedSave.mirrorState;
		}
		if (identifier == "plateStringIDDate")
		{
			return ES3.loadedSave.plateStringIDDate;
		}
		if (identifier == "newMonitorIndex")
		{
			return ES3.loadedSave.newMonitorIndex;
		}
		if (identifier == "motelRoomAssigned")
		{
			return ES3.loadedSave.motelRoomAssigned;
		}
		if (identifier == "routeLevel")
		{
			return ES3.loadedSave.routeLevel;
		}
		if (identifier == "plateStringID")
		{
			return ES3.loadedSave.plateStringID;
		}
		if (identifier == "resolutionX")
		{
			return ES3.loadedSave.resolutionX;
		}
		if (identifier == "resolutionY")
		{
			return ES3.loadedSave.resolutionY;
		}
		if (identifier == "vSyncState")
		{
			return ES3.loadedSave.vSyncState;
		}
		if (identifier == "aiCount")
		{
			return ES3.loadedSave.aiCount;
		}
		if (identifier == "qualityState")
		{
			return ES3.loadedSave.qualityState;
		}
		if (identifier == "padInput2")
		{
			return ES3.loadedSave.padInput2;
		}
		if (identifier == "fuelTankFuelMix")
		{
			return ES3.loadedSave.fuelTankFuelMix;
		}
		if (identifier == "waterTankWaterCharges")
		{
			return ES3.loadedSave.waterTankWaterCharges;
		}
		if (identifier == "cleanedTimes")
		{
			return ES3.loadedSave.cleanedTimes;
		}
		if (identifier == "carEngineID")
		{
			return ES3.loadedSave.carEngineID;
		}
		if (identifier == "ignitionCoilID")
		{
			return ES3.loadedSave.ignitionCoilID;
		}
		if (identifier == "fuelTankID")
		{
			return ES3.loadedSave.fuelTankID;
		}
		if (identifier == "carburettorID")
		{
			return ES3.loadedSave.carburettorID;
		}
		if (identifier == "airFilterID")
		{
			return ES3.loadedSave.airFilterID;
		}
		if (identifier == "waterTankID")
		{
			return ES3.loadedSave.waterTankID;
		}
		if (identifier == "batteryID")
		{
			return ES3.loadedSave.batteryID;
		}
		if (identifier == "frWheelID")
		{
			return ES3.loadedSave.frWheelID;
		}
		if (identifier == "flWheelID")
		{
			return ES3.loadedSave.flWheelID;
		}
		if (identifier == "rrWheelID")
		{
			return ES3.loadedSave.rrWheelID;
		}
		if (identifier == "rlWheelID")
		{
			return ES3.loadedSave.rlWheelID;
		}
		if (identifier == "toolRackWeight")
		{
			return ES3.loadedSave.toolRackWeight;
		}
		if (identifier == "toolRackLevel")
		{
			return ES3.loadedSave.toolRackLevel;
		}
		if (identifier == "roofRackWeight")
		{
			return ES3.loadedSave.roofRackWeight;
		}
		if (identifier == "lightRackWeight")
		{
			return ES3.loadedSave.lightRackWeight;
		}
		if (identifier == "dashUIWeight")
		{
			return ES3.loadedSave.dashUIWeight;
		}
		if (identifier == "mudGuardsWeight")
		{
			return ES3.loadedSave.mudGuardsWeight;
		}
		if (identifier == "bullBarWeight")
		{
			return ES3.loadedSave.bullBarWeight;
		}
		if (identifier == "tyrePoppedStats")
		{
			return ES3.loadedSave.tyrePoppedStats;
		}
		if (identifier == "repairKitsUsedStats")
		{
			return ES3.loadedSave.repairKitsUsedStats;
		}
		if (identifier == "daysPassed")
		{
			return ES3.loadedSave.daysPassed;
		}
		if (identifier == "footStepsCounter")
		{
			return ES3.loadedSave.footStepsCounter;
		}
		if (identifier == "customDecal")
		{
			return ES3.loadedSave.customDecal;
		}
		if (identifier == "economyState")
		{
			return ES3.loadedSave.economyState;
		}
		if (identifier == "routeLevel")
		{
			return ES3.loadedSave.routeLevel;
		}
		Debug.Log("NOT FOUND LOADING INT - " + identifier);
		return 0;
	}

	// Token: 0x060000FE RID: 254 RVA: 0x0000E818 File Offset: 0x0000CC18
	public static void Save(Color value, string identifier)
	{
		if (identifier == "customPaintBonnet")
		{
			ES3.loadedSave.customPaintBonnet.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintBonnet")
		{
			ES3.loadedSave.customMetallicPaintBonnet.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintFrame")
		{
			ES3.loadedSave.customPaintFrame.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintFrame")
		{
			ES3.loadedSave.customMetallicPaintFrame.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintIntFloor")
		{
			ES3.loadedSave.customPaintIntFloor.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintIntFloor")
		{
			ES3.loadedSave.customMetallicPaintIntFloor.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintLDoor")
		{
			ES3.loadedSave.customPaintLDoor.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintLDoor")
		{
			ES3.loadedSave.customMetallicPaintLDoor.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintRDoor")
		{
			ES3.loadedSave.customPaintRDoor.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintRDoor")
		{
			ES3.loadedSave.customMetallicPaintRDoor.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintLHLight")
		{
			ES3.loadedSave.customPaintLHLight.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintLHLight")
		{
			ES3.loadedSave.customMetallicPaintLHLight.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintRHLight")
		{
			ES3.loadedSave.customPaintRHLight.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintRHLight")
		{
			ES3.loadedSave.customMetallicPaintRHLight.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintRoof")
		{
			ES3.loadedSave.customPaintRoof.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintRoof")
		{
			ES3.loadedSave.customMetallicPaintRoof.ConvertColor(value);
			return;
		}
		if (identifier == "customPaintTrunk")
		{
			ES3.loadedSave.customPaintTrunk.ConvertColor(value);
			return;
		}
		if (identifier == "customMetallicPaintTrunk")
		{
			ES3.loadedSave.customMetallicPaintTrunk.ConvertColor(value);
			return;
		}
		if (identifier == "customDecalColor")
		{
			ES3.loadedSave.customDecalColor.ConvertColor(value);
			return;
		}
		Debug.Log("NOT FOUND SAVING COLOR - " + identifier);
	}

	// Token: 0x060000FF RID: 255 RVA: 0x0000EAA8 File Offset: 0x0000CEA8
	public static Color LoadColor(string identifier)
	{
		if (identifier == "customPaintBonnet")
		{
			return ES3.loadedSave.customPaintBonnet.ConvertToColor();
		}
		if (identifier == "customMetallicPaintBonnet")
		{
			return ES3.loadedSave.customMetallicPaintBonnet.ConvertToColor();
		}
		if (identifier == "customPaintFrame")
		{
			return ES3.loadedSave.customPaintFrame.ConvertToColor();
		}
		if (identifier == "customMetallicPaintFrame")
		{
			return ES3.loadedSave.customMetallicPaintFrame.ConvertToColor();
		}
		if (identifier == "customPaintIntFloor")
		{
			return ES3.loadedSave.customPaintIntFloor.ConvertToColor();
		}
		if (identifier == "customMetallicPaintIntFloor")
		{
			return ES3.loadedSave.customMetallicPaintIntFloor.ConvertToColor();
		}
		if (identifier == "customPaintLDoor")
		{
			return ES3.loadedSave.customPaintLDoor.ConvertToColor();
		}
		if (identifier == "customMetallicPaintLDoor")
		{
			return ES3.loadedSave.customMetallicPaintLDoor.ConvertToColor();
		}
		if (identifier == "customPaintRDoor")
		{
			return ES3.loadedSave.customPaintRDoor.ConvertToColor();
		}
		if (identifier == "customMetallicPaintRDoor")
		{
			return ES3.loadedSave.customMetallicPaintRDoor.ConvertToColor();
		}
		if (identifier == "customPaintLHLight")
		{
			return ES3.loadedSave.customPaintLHLight.ConvertToColor();
		}
		if (identifier == "customMetallicPaintLHLight")
		{
			return ES3.loadedSave.customMetallicPaintLHLight.ConvertToColor();
		}
		if (identifier == "customPaintRHLight")
		{
			return ES3.loadedSave.customPaintRHLight.ConvertToColor();
		}
		if (identifier == "customMetallicPaintRHLight")
		{
			return ES3.loadedSave.customMetallicPaintRHLight.ConvertToColor();
		}
		if (identifier == "customPaintRoof")
		{
			return ES3.loadedSave.customPaintRoof.ConvertToColor();
		}
		if (identifier == "customMetallicPaintRoof")
		{
			return ES3.loadedSave.customMetallicPaintRoof.ConvertToColor();
		}
		if (identifier == "customPaintTrunk")
		{
			return ES3.loadedSave.customPaintTrunk.ConvertToColor();
		}
		if (identifier == "customMetallicPaintTrunk")
		{
			return ES3.loadedSave.customMetallicPaintTrunk.ConvertToColor();
		}
		if (identifier == "customDecalColor")
		{
			return ES3.loadedSave.customDecalColor.ConvertToColor();
		}
		Debug.Log("NOT FOUND LOADING COLOR - " + identifier);
		return Color.white;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0000ED2C File Offset: 0x0000D12C
	public static void Save(List<string> value, string identifier)
	{
		if (identifier == "assignedInputstrings")
		{
			ES3.loadedSave.assignedInputStrings = value;
			return;
		}
		if (identifier == "assignedInputStrings")
		{
			ES3.loadedSave.assignedInputStrings = value;
			return;
		}
		Debug.Log("NOT FOUND SAVING LIST - " + identifier);
	}

	// Token: 0x06000101 RID: 257 RVA: 0x0000ED84 File Offset: 0x0000D184
	public static List<string> LoadListString(string identifier)
	{
		if (identifier == "assignedInputstrings")
		{
			return ES3.loadedSave.assignedInputStrings;
		}
		if (identifier == "assignedInputStrings")
		{
			return ES3.loadedSave.assignedInputStrings;
		}
		Debug.Log("NOT FOUND LOADING LIST - " + identifier);
		return new List<string>();
	}

	// Token: 0x06000102 RID: 258 RVA: 0x0000EDDC File Offset: 0x0000D1DC
	public static void Save(List<float> value, string identifier)
	{
		if (identifier == "componentFuels")
		{
			ES3.loadedSave.componentFuels = value;
			return;
		}
		if (identifier == "componentConditions")
		{
			ES3.loadedSave.componentConditions = value;
			return;
		}
		if (identifier == "componentCharges")
		{
			ES3.loadedSave.componentCharges = value;
			return;
		}
		Debug.Log("NOT FOUND SAVING LIST - " + identifier);
	}

	// Token: 0x06000103 RID: 259 RVA: 0x0000EE50 File Offset: 0x0000D250
	public static List<float> LoadListFloat(string identifier)
	{
		if (identifier == "componentFuels")
		{
			return ES3.loadedSave.componentFuels;
		}
		if (identifier == "componentCharges")
		{
			return ES3.loadedSave.componentCharges;
		}
		if (identifier == "componentConditions")
		{
			return ES3.loadedSave.componentConditions;
		}
		Debug.Log("NOT FOUND LOADING LIST - " + identifier);
		return new List<float>();
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000EEC4 File Offset: 0x0000D2C4
	public static void Save(List<int> value, string identifier)
	{
		if (identifier == "basketInventorySaveList")
		{
			ES3.loadedSave.basketInventorySaveList = value;
			return;
		}
		if (identifier == "currentBasketsInInventory")
		{
			ES3.loadedSave.currentBasketsInInventory = value;
			return;
		}
		if (identifier == "fuelCanLevels")
		{
			ES3.loadedSave.fuelCanLevels = value;
			return;
		}
		if (identifier == "fuelCanMixs")
		{
			ES3.loadedSave.fuelCanMixs = value;
			return;
		}
		if (identifier == "componentFuelMixs")
		{
			ES3.loadedSave.componentFuelMixs = value;
			return;
		}
		if (identifier == "componentWaters")
		{
			ES3.loadedSave.componentWaters = value;
			return;
		}
		if (identifier == "bootInventorySaveLists2x2x2")
		{
			ES3.loadedSave.bootInventorySaveLists2x2x2 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs2x2x2")
		{
			ES3.loadedSave.bootInventorySaveLocs2x2x2 = value;
			return;
		}
		if (identifier == "waterBottleLevels")
		{
			ES3.loadedSave.waterBottleLevels = value;
			return;
		}
		if (identifier == "bootInventorySaveLists2x1x3")
		{
			ES3.loadedSave.bootInventorySaveLists2x1x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs2x1x3")
		{
			ES3.loadedSave.bootInventorySaveLocs2x1x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveLists2x2x3")
		{
			ES3.loadedSave.bootInventorySaveLists2x2x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs2x2x3")
		{
			ES3.loadedSave.bootInventorySaveLocs2x2x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveLists4x2x3")
		{
			ES3.loadedSave.bootInventorySaveLists4x2x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs4x2x3")
		{
			ES3.loadedSave.bootInventorySaveLocs4x2x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveListsTyres")
		{
			ES3.loadedSave.bootInventorySaveListsTyres = value;
			return;
		}
		if (identifier == "primaryBuildingsSaveList1")
		{
			ES3.loadedSave.primaryBuildingSaveList1 = value;
			return;
		}
		if (identifier == "primaryBuildingsSaveList2")
		{
			ES3.loadedSave.primaryBuildingSaveList2 = value;
			return;
		}
		if (identifier == "primaryBuildingsSaveList3")
		{
			ES3.loadedSave.primaryBuildingSaveList3 = value;
			return;
		}
		if (identifier == "primaryBuildingsSaveList4")
		{
			ES3.loadedSave.primaryBuildingSaveList4 = value;
			return;
		}
		if (identifier == "primaryBuildingsSaveList5")
		{
			ES3.loadedSave.primaryBuildingSaveList5 = value;
			return;
		}
		if (identifier == "primaryBuildingsSaveList6")
		{
			ES3.loadedSave.primaryBuildingSaveList6 = value;
			return;
		}
		if (identifier == "hollowBuildingIndexSaveList1")
		{
			ES3.loadedSave.hollowBuildingIndexSaveList1 = value;
			return;
		}
		if (identifier == "hollowBuildingIndexSaveList2")
		{
			ES3.loadedSave.hollowBuildingIndexSaveList2 = value;
			return;
		}
		if (identifier == "hollowBuildingIndexSaveList3")
		{
			ES3.loadedSave.hollowBuildingIndexSaveList3 = value;
			return;
		}
		if (identifier == "hollowBuildingIndexSaveList4")
		{
			ES3.loadedSave.hollowBuildingIndexSaveList4 = value;
			return;
		}
		if (identifier == "hollowBuildingIndexSaveList5")
		{
			ES3.loadedSave.hollowBuildingIndexSaveList5 = value;
			return;
		}
		if (identifier == "hollowBuildingIndexSaveList6")
		{
			ES3.loadedSave.hollowBuildingIndexSaveList6 = value;
			return;
		}
		if (identifier == "oilBottleLevels")
		{
			ES3.loadedSave.oilBottleLevels = value;
			return;
		}
		if (identifier == "bootInventorySaveList")
		{
			ES3.loadedSave.bootInventorySaveList = value;
			return;
		}
		if (identifier == "bootInventorySaveLocsSingle")
		{
			ES3.loadedSave.bootInventorySaveLocsSingle = value;
			return;
		}
		if (identifier == "bootInventoryTradeGoodsSmallIDSaveList")
		{
			ES3.loadedSave.bootInventoryTradegoodsSmallIDSaveList = value;
			return;
		}
		if (identifier == "bootInventorySaveLists4x1x1")
		{
			ES3.loadedSave.bootInventorySaveLists4x1x1 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs4x1x1")
		{
			ES3.loadedSave.bootInventorySaveLocs4x1x1 = value;
			return;
		}
		if (identifier == "bootInventorySaveLists3x2x1")
		{
			ES3.loadedSave.bootInventorySaveLists3x2x1 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs3x2x1")
		{
			ES3.loadedSave.bootInventorySaveLocs3x2x1 = value;
			return;
		}
		if (identifier == "bootInventorySaveLists2x2x1")
		{
			ES3.loadedSave.bootInventorySaveLists2x2x1 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs2x2x1")
		{
			ES3.loadedSave.bootInventorySaveLocs2x2x1 = value;
			return;
		}
		if (identifier == "bootInventorySaveLists3x2x3")
		{
			ES3.loadedSave.bootInventorySaveLists3x2x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs3x2x3")
		{
			ES3.loadedSave.bootInventorySaveLocs3x2x3 = value;
			return;
		}
		if (identifier == "bootInventorySaveLists4x2x2")
		{
			ES3.loadedSave.bootInventorySaveLists4x2x2 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs4x2x2")
		{
			ES3.loadedSave.bootInventorySaveLocs4x2x2 = value;
			return;
		}
		if (identifier == "bootInventorySaveLists4x2x1")
		{
			ES3.loadedSave.bootInventorySaveLists4x2x1 = value;
			return;
		}
		if (identifier == "bootInventorySaveLocs4x2x1")
		{
			ES3.loadedSave.bootInventorySaveLocs4x2x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveList")
		{
			ES3.loadedSave.roofInventorySaveList = value;
			return;
		}
		if (identifier == "roofInventorySaveLocsSingle")
		{
			ES3.loadedSave.roofInventorySaveLocsSingle = value;
			return;
		}
		if (identifier == "roofInventoryTradeGoodsSmallIDSaveList")
		{
			ES3.loadedSave.roofInventoryTradeGoodsSmallIDSaveList = value;
			return;
		}
		if (identifier == "roofInventorySaveLists3x2x1")
		{
			ES3.loadedSave.roofInventorySaveLists3x2x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs3x2x1")
		{
			ES3.loadedSave.roofInventorySaveLocs3x2x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists2x2x1")
		{
			ES3.loadedSave.roofInventorySaveLists2x2x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs2x2x1")
		{
			ES3.loadedSave.roofInventorySaveLocs2x2x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists2x2x3")
		{
			ES3.loadedSave.roofInventorySaveLists2x2x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs2x2x3")
		{
			ES3.loadedSave.roofInventorySaveLocs2x2x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists2x2x2")
		{
			ES3.loadedSave.roofInventorySaveLists2x2x2 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs2x2x2")
		{
			ES3.loadedSave.roofInventorySaveLocs2x2x2 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists3x2x3")
		{
			ES3.loadedSave.roofInventorySaveLists3x2x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs3x2x3")
		{
			ES3.loadedSave.roofInventorySaveLocs3x2x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists4x2x2")
		{
			ES3.loadedSave.roofInventorySaveLists4x2x2 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs4x2x2")
		{
			ES3.loadedSave.roofInventorySaveLocs4x2x2 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists4x2x3")
		{
			ES3.loadedSave.roofInventorySaveLists4x2x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs4x2x3")
		{
			ES3.loadedSave.roofInventorySaveLocs4x2x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists4x1x1")
		{
			ES3.loadedSave.roofInventorySaveLists4x1x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs4x1x1")
		{
			ES3.loadedSave.roofInventorySaveLocs4x1x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists4x2x1")
		{
			ES3.loadedSave.roofInventorySaveLists4x2x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs4x2x1")
		{
			ES3.loadedSave.roofInventorySaveLocs4x2x1 = value;
			return;
		}
		if (identifier == "roofInventorySaveLists2x1x3")
		{
			ES3.loadedSave.roofInventorySaveLists2x1x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveLocs2x1x3")
		{
			ES3.loadedSave.roofInventorySaveLocs2x1x3 = value;
			return;
		}
		if (identifier == "roofInventorySaveListsTyres")
		{
			ES3.loadedSave.roofInventorySaveListsTyres = value;
			return;
		}
		if (identifier == "home1InventorySaveList")
		{
			ES3.loadedSave.home1inventorySaveList = value;
			return;
		}
		if (identifier == "home2InventorySaveList")
		{
			ES3.loadedSave.home2inventorySaveList = value;
			return;
		}
		if (identifier == "home3InventorySaveList")
		{
			ES3.loadedSave.home3inventorySaveList = value;
			return;
		}
		if (identifier == "home4InventorySaveList")
		{
			ES3.loadedSave.home4inventorySaveList = value;
			return;
		}
		if (identifier == "home5InventorySaveList")
		{
			ES3.loadedSave.home5inventorySaveList = value;
			return;
		}
		if (identifier == "home1InventorySaveLists4x1x1")
		{
			ES3.loadedSave.home1InventorySaveLists4x1x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs4x1x1")
		{
			ES3.loadedSave.home1InventorySaveLocs4x1x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists3x2x1")
		{
			ES3.loadedSave.home1InventorySaveLists3x2x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs3x2x1")
		{
			ES3.loadedSave.home1InventorySaveLocs3x2x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists2x2x1")
		{
			ES3.loadedSave.home1InventorySaveLists2x2x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs2x2x1")
		{
			ES3.loadedSave.home1InventorySaveLocs2x2x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists3x2x3")
		{
			ES3.loadedSave.home1InventorySaveLists3x2x3 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs3x2x3")
		{
			ES3.loadedSave.home1InventorySaveLocs3x2x3 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists4x2x2")
		{
			ES3.loadedSave.home1InventorySaveLists4x2x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs4x2x2")
		{
			ES3.loadedSave.home1InventorySaveLocs4x2x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists4x2x1")
		{
			ES3.loadedSave.home1InventorySaveLists4x2x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs4x2x1")
		{
			ES3.loadedSave.home1InventorySaveLocs4x2x1 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocsSingle")
		{
			ES3.loadedSave.home1InventorySaveLocsSingle = value;
			return;
		}
		if (identifier == "home1InventoryTradeGoodsSmallIDSaveList")
		{
			ES3.loadedSave.home1InventoryTradeGoodsSmallIDSaveList = value;
			return;
		}
		if (identifier == "home1InventorySaveLists2x1x3")
		{
			ES3.loadedSave.home1InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs2x1x3")
		{
			ES3.loadedSave.home1InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists2x1x2")
		{
			ES3.loadedSave.home1InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs2x1x2")
		{
			ES3.loadedSave.home1InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists2x2x2")
		{
			ES3.loadedSave.home1InventorySaveLists2x2x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs2x2x2")
		{
			ES3.loadedSave.home1InventorySaveLocs2x2x2 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists2x2x3")
		{
			ES3.loadedSave.home1InventorySaveLists2x2x3 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs2x2x3")
		{
			ES3.loadedSave.home1InventorySaveLocs2x2x3 = value;
			return;
		}
		if (identifier == "home1InventorySaveLists4x2x3")
		{
			ES3.loadedSave.home1InventorySaveLists4x2x4 = value;
			return;
		}
		if (identifier == "home1InventorySaveLocs4x2x3")
		{
			ES3.loadedSave.home1InventorySaveLocs4x2x4 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists4x1x1")
		{
			ES3.loadedSave.home2InventorySaveLists4x1x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs4x1x1")
		{
			ES3.loadedSave.home2InventorySaveLocs4x1x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists3x2x1")
		{
			ES3.loadedSave.home2InventorySaveLists3x2x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs3x2x1")
		{
			ES3.loadedSave.home2InventorySaveLocs3x2x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists2x2x1")
		{
			ES3.loadedSave.home2InventorySaveLists2x2x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs2x2x1")
		{
			ES3.loadedSave.home2InventorySaveLocs2x2x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists3x2x3")
		{
			ES3.loadedSave.home2InventorySaveLists3x2x3 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs3x2x3")
		{
			ES3.loadedSave.home2InventorySaveLocs3x2x3 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists4x2x2")
		{
			ES3.loadedSave.home2InventorySaveLists4x2x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs4x2x2")
		{
			ES3.loadedSave.home2InventorySaveLocs4x2x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists4x2x1")
		{
			ES3.loadedSave.home2InventorySaveLists4x2x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs4x2x1")
		{
			ES3.loadedSave.home2InventorySaveLocs4x2x1 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists2x1x3")
		{
			ES3.loadedSave.home2InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs2x1x3")
		{
			ES3.loadedSave.home2InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists2x1x2")
		{
			ES3.loadedSave.home2InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs2x1x2")
		{
			ES3.loadedSave.home2InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists2x2x2")
		{
			ES3.loadedSave.home2InventorySaveLists2x2x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs2x2x2")
		{
			ES3.loadedSave.home2InventorySaveLocs2x2x2 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists2x2x3")
		{
			ES3.loadedSave.home2InventorySaveLists2x2x3 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs2x2x3")
		{
			ES3.loadedSave.home2InventorySaveLocs2x2x3 = value;
			return;
		}
		if (identifier == "home2InventorySaveLists4x2x3")
		{
			ES3.loadedSave.home2InventorySaveLists4x2x4 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocs4x2x3")
		{
			ES3.loadedSave.home2InventorySaveLocs4x2x4 = value;
			return;
		}
		if (identifier == "home2InventorySaveLocsSingle")
		{
			ES3.loadedSave.home2InventorySaveLocsSingle = value;
			return;
		}
		if (identifier == "home2InventoryTradeGoodsSmallIDSaveList")
		{
			ES3.loadedSave.home2InventoryTradeGoodsSmallIDSaveList = value;
			return;
		}
		if (identifier == "home3InventorySaveLists4x1x1")
		{
			ES3.loadedSave.home3InventorySaveLists4x1x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs4x1x1")
		{
			ES3.loadedSave.home3InventorySaveLocs4x1x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists3x2x1")
		{
			ES3.loadedSave.home3InventorySaveLists3x2x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs3x2x1")
		{
			ES3.loadedSave.home3InventorySaveLocs3x2x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists2x2x1")
		{
			ES3.loadedSave.home3InventorySaveLists2x2x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs2x2x1")
		{
			ES3.loadedSave.home3InventorySaveLocs2x2x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists3x2x3")
		{
			ES3.loadedSave.home3InventorySaveLists3x2x3 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs3x2x3")
		{
			ES3.loadedSave.home3InventorySaveLocs3x2x3 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists4x2x2")
		{
			ES3.loadedSave.home3InventorySaveLists4x2x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs4x2x2")
		{
			ES3.loadedSave.home3InventorySaveLocs4x2x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists4x2x1")
		{
			ES3.loadedSave.home3InventorySaveLists4x2x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs4x2x1")
		{
			ES3.loadedSave.home3InventorySaveLocs4x2x1 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists2x1x3")
		{
			ES3.loadedSave.home3InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs2x1x3")
		{
			ES3.loadedSave.home3InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists2x1x2")
		{
			ES3.loadedSave.home3InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs2x1x2")
		{
			ES3.loadedSave.home3InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists2x2x2")
		{
			ES3.loadedSave.home3InventorySaveLists2x2x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs2x2x2")
		{
			ES3.loadedSave.home3InventorySaveLocs2x2x2 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists2x2x3")
		{
			ES3.loadedSave.home3InventorySaveLists2x2x3 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs2x2x3")
		{
			ES3.loadedSave.home3InventorySaveLocs2x2x3 = value;
			return;
		}
		if (identifier == "home3InventorySaveLists4x2x3")
		{
			ES3.loadedSave.home3InventorySaveLists4x2x4 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocs4x2x3")
		{
			ES3.loadedSave.home3InventorySaveLocs4x2x4 = value;
			return;
		}
		if (identifier == "home3InventorySaveLocsSingle")
		{
			ES3.loadedSave.home3InventorySaveLocsSingle = value;
			return;
		}
		if (identifier == "home3InventoryTradeGoodsSmallIDSaveList")
		{
			ES3.loadedSave.home3InventoryTradeGoodsSmallIDSaveList = value;
			return;
		}
		if (identifier == "home4InventorySaveLists4x1x1")
		{
			ES3.loadedSave.home4InventorySaveLists4x1x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs4x1x1")
		{
			ES3.loadedSave.home4InventorySaveLocs4x1x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists3x2x1")
		{
			ES3.loadedSave.home4InventorySaveLists3x2x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs3x2x1")
		{
			ES3.loadedSave.home4InventorySaveLocs3x2x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists2x2x1")
		{
			ES3.loadedSave.home4InventorySaveLists2x2x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs2x2x1")
		{
			ES3.loadedSave.home4InventorySaveLocs2x2x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists3x2x3")
		{
			ES3.loadedSave.home4InventorySaveLists3x2x3 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs3x2x3")
		{
			ES3.loadedSave.home4InventorySaveLocs3x2x3 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists4x2x2")
		{
			ES3.loadedSave.home4InventorySaveLists4x2x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs4x2x2")
		{
			ES3.loadedSave.home4InventorySaveLocs4x2x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists4x2x1")
		{
			ES3.loadedSave.home4InventorySaveLists4x2x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs4x2x1")
		{
			ES3.loadedSave.home4InventorySaveLocs4x2x1 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists2x1x3")
		{
			ES3.loadedSave.home4InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs2x1x3")
		{
			ES3.loadedSave.home4InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists2x1x2")
		{
			ES3.loadedSave.home4InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs2x1x2")
		{
			ES3.loadedSave.home4InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists2x2x2")
		{
			ES3.loadedSave.home4InventorySaveLists2x2x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs2x2x2")
		{
			ES3.loadedSave.home4InventorySaveLocs2x2x2 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists2x2x3")
		{
			ES3.loadedSave.home4InventorySaveLists2x2x3 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs2x2x3")
		{
			ES3.loadedSave.home4InventorySaveLocs2x2x3 = value;
			return;
		}
		if (identifier == "home4InventorySaveLists4x2x3")
		{
			ES3.loadedSave.home4InventorySaveLists4x2x4 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocs4x2x3")
		{
			ES3.loadedSave.home4InventorySaveLocs4x2x4 = value;
			return;
		}
		if (identifier == "home4InventorySaveLocsSingle")
		{
			ES3.loadedSave.home4InventorySaveLocsSingle = value;
			return;
		}
		if (identifier == "home4InventoryTradeGoodsSmallIDSaveList")
		{
			ES3.loadedSave.home4InventoryTradeGoodsSmallIDSaveList = value;
			return;
		}
		if (identifier == "home5InventorySaveLists4x1x1")
		{
			ES3.loadedSave.home5InventorySaveLists4x1x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs4x1x1")
		{
			ES3.loadedSave.home5InventorySaveLocs4x1x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists3x2x1")
		{
			ES3.loadedSave.home5InventorySaveLists3x2x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs3x2x1")
		{
			ES3.loadedSave.home5InventorySaveLocs3x2x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists2x2x1")
		{
			ES3.loadedSave.home5InventorySaveLists2x2x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs2x2x1")
		{
			ES3.loadedSave.home5InventorySaveLocs2x2x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists3x2x3")
		{
			ES3.loadedSave.home5InventorySaveLists3x2x3 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs3x2x3")
		{
			ES3.loadedSave.home5InventorySaveLocs3x2x3 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists4x2x2")
		{
			ES3.loadedSave.home5InventorySaveLists4x2x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs4x2x2")
		{
			ES3.loadedSave.home5InventorySaveLocs4x2x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists4x2x1")
		{
			ES3.loadedSave.home5InventorySaveLists4x2x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs4x2x1")
		{
			ES3.loadedSave.home5InventorySaveLocs4x2x1 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists2x1x3")
		{
			ES3.loadedSave.home5InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs2x1x3")
		{
			ES3.loadedSave.home5InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists2x1x2")
		{
			ES3.loadedSave.home5InventorySaveLists2x1x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs2x1x2")
		{
			ES3.loadedSave.home5InventorySaveLocs2x1x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists2x2x2")
		{
			ES3.loadedSave.home5InventorySaveLists2x2x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs2x2x2")
		{
			ES3.loadedSave.home5InventorySaveLocs2x2x2 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists2x2x3")
		{
			ES3.loadedSave.home5InventorySaveLists2x2x3 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs2x2x3")
		{
			ES3.loadedSave.home5InventorySaveLocs2x2x3 = value;
			return;
		}
		if (identifier == "home5InventorySaveLists4x2x3")
		{
			ES3.loadedSave.home5InventorySaveLists4x2x4 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocs4x2x3")
		{
			ES3.loadedSave.home5InventorySaveLocs4x2x4 = value;
			return;
		}
		if (identifier == "home5InventorySaveLocsSingle")
		{
			ES3.loadedSave.home5InventorySaveLocsSingle = value;
			return;
		}
		if (identifier == "home5InventoryTradeGoodsSmallIDSaveList")
		{
			ES3.loadedSave.home5InventoryTradeGoodsSmallIDSaveList = value;
			return;
		}
		if (identifier == "home1InventorySaveListsTyres")
		{
			ES3.loadedSave.home1InventorySaveListsTyres = value;
			return;
		}
		if (identifier == "home2InventorySaveListsTyres")
		{
			ES3.loadedSave.home2InventorySaveListsTyres = value;
			return;
		}
		if (identifier == "home3InventorySaveListsTyres")
		{
			ES3.loadedSave.home3InventorySaveListsTyres = value;
			return;
		}
		if (identifier == "home4InventorySaveListsTyres")
		{
			ES3.loadedSave.home4InventorySaveListsTyres = value;
			return;
		}
		if (identifier == "home5InventorySaveListsTyres")
		{
			ES3.loadedSave.home5InventorySaveListsTyres = value;
			return;
		}
		Debug.Log("NOT FOUND SAVING LIST INT - " + identifier);
	}

	// Token: 0x06000105 RID: 261 RVA: 0x0001048C File Offset: 0x0000E88C
	public static List<int> LoadListInt(string identifier)
	{
		if (identifier == "basketInventorySaveList")
		{
			return ES3.loadedSave.basketInventorySaveList;
		}
		if (identifier == "currentBasketsInInventory")
		{
			return ES3.loadedSave.currentBasketsInInventory;
		}
		if (identifier == "fuelCanLevels")
		{
			return ES3.loadedSave.fuelCanLevels;
		}
		if (identifier == "fuelCanMixs")
		{
			return ES3.loadedSave.fuelCanMixs;
		}
		if (identifier == "componentFuelMixs")
		{
			return ES3.loadedSave.componentFuelMixs;
		}
		if (identifier == "componentWaters")
		{
			return ES3.loadedSave.componentWaters;
		}
		if (identifier == "bootInventorySaveLists2x2x2")
		{
			return ES3.loadedSave.bootInventorySaveLists2x2x2;
		}
		if (identifier == "bootInventorySaveLocs2x2x2")
		{
			return ES3.loadedSave.bootInventorySaveLocs2x2x2;
		}
		if (identifier == "waterBottleLevels")
		{
			return ES3.loadedSave.waterBottleLevels;
		}
		if (identifier == "bootInventorySaveLists2x1x3")
		{
			return ES3.loadedSave.bootInventorySaveLists2x1x3;
		}
		if (identifier == "bootInventorySaveLocs2x1x3")
		{
			return ES3.loadedSave.bootInventorySaveLocs2x1x3;
		}
		if (identifier == "bootInventorySaveLists2x2x3")
		{
			return ES3.loadedSave.bootInventorySaveLists2x2x3;
		}
		if (identifier == "bootInventorySaveLocs2x2x3")
		{
			return ES3.loadedSave.bootInventorySaveLocs2x2x3;
		}
		if (identifier == "bootInventorySaveLists4x2x3")
		{
			return ES3.loadedSave.bootInventorySaveLists4x2x3;
		}
		if (identifier == "bootInventorySaveLocs4x2x3")
		{
			return ES3.loadedSave.bootInventorySaveLocs4x2x3;
		}
		if (identifier == "bootInventorySaveListsTyres")
		{
			return ES3.loadedSave.bootInventorySaveListsTyres;
		}
		if (identifier == "primaryBuildingsSaveList1")
		{
			return ES3.loadedSave.primaryBuildingSaveList1;
		}
		if (identifier == "primaryBuildingsSaveList2")
		{
			return ES3.loadedSave.primaryBuildingSaveList2;
		}
		if (identifier == "primaryBuildingsSaveList3")
		{
			return ES3.loadedSave.primaryBuildingSaveList3;
		}
		if (identifier == "primaryBuildingsSaveList4")
		{
			return ES3.loadedSave.primaryBuildingSaveList4;
		}
		if (identifier == "primaryBuildingsSaveList5")
		{
			return ES3.loadedSave.primaryBuildingSaveList5;
		}
		if (identifier == "primaryBuildingsSaveList6")
		{
			return ES3.loadedSave.primaryBuildingSaveList6;
		}
		if (identifier == "hollowBuildingIndexSaveList1")
		{
			return ES3.loadedSave.hollowBuildingIndexSaveList1;
		}
		if (identifier == "hollowBuildingIndexSaveList2")
		{
			return ES3.loadedSave.hollowBuildingIndexSaveList2;
		}
		if (identifier == "hollowBuildingIndexSaveList3")
		{
			return ES3.loadedSave.hollowBuildingIndexSaveList3;
		}
		if (identifier == "hollowBuildingIndexSaveList4")
		{
			return ES3.loadedSave.hollowBuildingIndexSaveList4;
		}
		if (identifier == "hollowBuildingIndexSaveList5")
		{
			return ES3.loadedSave.hollowBuildingIndexSaveList5;
		}
		if (identifier == "hollowBuildingIndexSaveList6")
		{
			return ES3.loadedSave.hollowBuildingIndexSaveList6;
		}
		if (identifier == "oilBottleLevels")
		{
			return ES3.loadedSave.oilBottleLevels;
		}
		if (identifier == "bootInventorySaveList")
		{
			return ES3.loadedSave.bootInventorySaveList;
		}
		if (identifier == "bootInventorySaveLocsSingle")
		{
			return ES3.loadedSave.bootInventorySaveLocsSingle;
		}
		if (identifier == "bootInventoryTradeGoodsSmallIDSaveList")
		{
			return ES3.loadedSave.bootInventoryTradegoodsSmallIDSaveList;
		}
		if (identifier == "bootInventorySaveLists4x1x1")
		{
			return ES3.loadedSave.bootInventorySaveLists4x1x1;
		}
		if (identifier == "bootInventorySaveLocs4x1x1")
		{
			return ES3.loadedSave.bootInventorySaveLocs4x1x1;
		}
		if (identifier == "bootInventorySaveLists3x2x1")
		{
			return ES3.loadedSave.bootInventorySaveLists3x2x1;
		}
		if (identifier == "bootInventorySaveLocs3x2x1")
		{
			return ES3.loadedSave.bootInventorySaveLocs3x2x1;
		}
		if (identifier == "bootInventorySaveLists2x2x1")
		{
			return ES3.loadedSave.bootInventorySaveLists2x2x1;
		}
		if (identifier == "bootInventorySaveLocs2x2x1")
		{
			return ES3.loadedSave.bootInventorySaveLocs2x2x1;
		}
		if (identifier == "bootInventorySaveLists3x2x3")
		{
			return ES3.loadedSave.bootInventorySaveLists3x2x3;
		}
		if (identifier == "bootInventorySaveLocs3x2x3")
		{
			return ES3.loadedSave.bootInventorySaveLocs3x2x3;
		}
		if (identifier == "bootInventorySaveLists4x2x2")
		{
			return ES3.loadedSave.bootInventorySaveLists4x2x2;
		}
		if (identifier == "bootInventorySaveLocs4x2x2")
		{
			return ES3.loadedSave.bootInventorySaveLocs4x2x2;
		}
		if (identifier == "bootInventorySaveLists4x2x1")
		{
			return ES3.loadedSave.bootInventorySaveLists4x2x1;
		}
		if (identifier == "bootInventorySaveLocs4x2x1")
		{
			return ES3.loadedSave.bootInventorySaveLocs4x2x1;
		}
		if (identifier == "roofInventorySaveList")
		{
			return ES3.loadedSave.roofInventorySaveList;
		}
		if (identifier == "roofInventorySaveLocsSingle")
		{
			return ES3.loadedSave.roofInventorySaveLocsSingle;
		}
		if (identifier == "roofInventoryTradeGoodsSmallIDSaveList")
		{
			return ES3.loadedSave.roofInventoryTradeGoodsSmallIDSaveList;
		}
		if (identifier == "roofInventorySaveLists3x2x1")
		{
			return ES3.loadedSave.roofInventorySaveLists3x2x1;
		}
		if (identifier == "roofInventorySaveLocs3x2x1")
		{
			return ES3.loadedSave.roofInventorySaveLocs3x2x1;
		}
		if (identifier == "roofInventorySaveLists2x2x1")
		{
			return ES3.loadedSave.roofInventorySaveLists2x2x1;
		}
		if (identifier == "roofInventorySaveLocs2x2x1")
		{
			return ES3.loadedSave.roofInventorySaveLocs2x2x1;
		}
		if (identifier == "roofInventorySaveLists2x2x3")
		{
			return ES3.loadedSave.roofInventorySaveLists2x2x3;
		}
		if (identifier == "roofInventorySaveLocs2x2x3")
		{
			return ES3.loadedSave.roofInventorySaveLocs2x2x3;
		}
		if (identifier == "roofInventorySaveLists2x2x2")
		{
			return ES3.loadedSave.roofInventorySaveLists2x2x2;
		}
		if (identifier == "roofInventorySaveLocs2x2x2")
		{
			return ES3.loadedSave.roofInventorySaveLocs2x2x2;
		}
		if (identifier == "roofInventorySaveLists3x2x3")
		{
			return ES3.loadedSave.roofInventorySaveLists3x2x3;
		}
		if (identifier == "roofInventorySaveLocs3x2x3")
		{
			return ES3.loadedSave.roofInventorySaveLocs3x2x3;
		}
		if (identifier == "roofInventorySaveLists4x2x2")
		{
			return ES3.loadedSave.roofInventorySaveLists4x2x2;
		}
		if (identifier == "roofInventorySaveLocs4x2x2")
		{
			return ES3.loadedSave.roofInventorySaveLocs4x2x2;
		}
		if (identifier == "roofInventorySaveLists4x2x3")
		{
			return ES3.loadedSave.roofInventorySaveLists4x2x3;
		}
		if (identifier == "roofInventorySaveLocs4x2x3")
		{
			return ES3.loadedSave.roofInventorySaveLocs4x2x3;
		}
		if (identifier == "roofInventorySaveLists4x1x1")
		{
			return ES3.loadedSave.roofInventorySaveLists4x1x1;
		}
		if (identifier == "roofInventorySaveLocs4x1x1")
		{
			return ES3.loadedSave.roofInventorySaveLocs4x1x1;
		}
		if (identifier == "roofInventorySaveLists4x2x1")
		{
			return ES3.loadedSave.roofInventorySaveLists4x2x1;
		}
		if (identifier == "roofInventorySaveLocs4x2x1")
		{
			return ES3.loadedSave.roofInventorySaveLocs4x2x1;
		}
		if (identifier == "roofInventorySaveLists2x1x3")
		{
			return ES3.loadedSave.roofInventorySaveLists2x1x3;
		}
		if (identifier == "roofInventorySaveLocs2x1x3")
		{
			return ES3.loadedSave.roofInventorySaveLocs2x1x3;
		}
		if (identifier == "roofInventorySaveListsTyres")
		{
			return ES3.loadedSave.roofInventorySaveListsTyres;
		}
		if (identifier == "home1InventorySaveList")
		{
			return ES3.loadedSave.home1inventorySaveList;
		}
		if (identifier == "home1InventorySaveLocsSingle")
		{
			return ES3.loadedSave.home1InventorySaveLocsSingle;
		}
		if (identifier == "home1InventoryTradeGoodsSmallIDSaveList")
		{
			return ES3.loadedSave.home1InventoryTradeGoodsSmallIDSaveList;
		}
		if (identifier == "home1InventorySaveLists3x2x1")
		{
			return ES3.loadedSave.home1InventorySaveLists3x2x1;
		}
		if (identifier == "home1InventorySaveLists2x2x1")
		{
			return ES3.loadedSave.home1InventorySaveLists2x2x1;
		}
		if (identifier == "home1InventorySaveLists2x2x2")
		{
			return ES3.loadedSave.home1InventorySaveLists2x2x2;
		}
		if (identifier == "home1InventorySaveLists2x2x3")
		{
			return ES3.loadedSave.home1InventorySaveLists2x2x3;
		}
		if (identifier == "home1InventorySaveLists3x2x3")
		{
			return ES3.loadedSave.home1InventorySaveLists3x2x3;
		}
		if (identifier == "home1InventorySaveLists4x2x2")
		{
			return ES3.loadedSave.home1InventorySaveLists4x2x2;
		}
		if (identifier == "home1InventorySaveLists4x2x3")
		{
			return ES3.loadedSave.home1InventorySaveLists4x2x3;
		}
		if (identifier == "home1InventorySaveLists4x1x1")
		{
			return ES3.loadedSave.home1InventorySaveLists4x1x1;
		}
		if (identifier == "home1InventorySaveLists4x2x1")
		{
			return ES3.loadedSave.home1InventorySaveLists4x2x1;
		}
		if (identifier == "home1InventorySaveLists2x1x3")
		{
			return ES3.loadedSave.home1InventorySaveLists2x1x3;
		}
		if (identifier == "home1InventorySaveLocs3x2x1")
		{
			return ES3.loadedSave.home1InventorySaveLocs3x2x1;
		}
		if (identifier == "home1InventorySaveLocs2x2x1")
		{
			return ES3.loadedSave.home1InventorySaveLocs2x2x1;
		}
		if (identifier == "home1InventorySaveLocs2x2x2")
		{
			return ES3.loadedSave.home1InventorySaveLocs2x2x2;
		}
		if (identifier == "home1InventorySaveLocs2x2x3")
		{
			return ES3.loadedSave.home1InventorySaveLocs2x2x3;
		}
		if (identifier == "home1InventorySaveLocs3x2x3")
		{
			return ES3.loadedSave.home1InventorySaveLocs3x2x3;
		}
		if (identifier == "home1InventorySaveLocs4x2x2")
		{
			return ES3.loadedSave.home1InventorySaveLocs4x2x2;
		}
		if (identifier == "home1InventorySaveLocs4x2x3")
		{
			return ES3.loadedSave.home1InventorySaveLocs4x2x3;
		}
		if (identifier == "home1InventorySaveLocs4x1x1")
		{
			return ES3.loadedSave.home1InventorySaveLocs4x1x1;
		}
		if (identifier == "home1InventorySaveLocs4x2x1")
		{
			return ES3.loadedSave.home1InventorySaveLocs4x2x1;
		}
		if (identifier == "home1InventorySaveLocs2x1x3")
		{
			return ES3.loadedSave.home1InventorySaveLocs2x1x3;
		}
		if (identifier == "home2InventorySaveList")
		{
			return ES3.loadedSave.home2inventorySaveList;
		}
		if (identifier == "home2InventorySaveLocsSingle")
		{
			return ES3.loadedSave.home2InventorySaveLocsSingle;
		}
		if (identifier == "home2InventoryTradeGoodsSmallIDSaveList")
		{
			return ES3.loadedSave.home2InventoryTradeGoodsSmallIDSaveList;
		}
		if (identifier == "home2InventorySaveLists3x2x1")
		{
			return ES3.loadedSave.home2InventorySaveLists3x2x1;
		}
		if (identifier == "home2InventorySaveLists2x2x1")
		{
			return ES3.loadedSave.home2InventorySaveLists2x2x1;
		}
		if (identifier == "home2InventorySaveLists2x2x2")
		{
			return ES3.loadedSave.home2InventorySaveLists2x2x2;
		}
		if (identifier == "home2InventorySaveLists2x2x3")
		{
			return ES3.loadedSave.home2InventorySaveLists2x2x3;
		}
		if (identifier == "home2InventorySaveLists3x2x3")
		{
			return ES3.loadedSave.home2InventorySaveLists3x2x3;
		}
		if (identifier == "home2InventorySaveLists4x2x2")
		{
			return ES3.loadedSave.home2InventorySaveLists4x2x2;
		}
		if (identifier == "home2InventorySaveLists4x2x3")
		{
			return ES3.loadedSave.home2InventorySaveLists4x2x3;
		}
		if (identifier == "home2InventorySaveLists4x1x1")
		{
			return ES3.loadedSave.home2InventorySaveLists4x1x1;
		}
		if (identifier == "home2InventorySaveLists4x2x1")
		{
			return ES3.loadedSave.home2InventorySaveLists4x2x1;
		}
		if (identifier == "home2InventorySaveLists2x1x3")
		{
			return ES3.loadedSave.home2InventorySaveLists2x1x3;
		}
		if (identifier == "home2InventorySaveLocs3x2x1")
		{
			return ES3.loadedSave.home2InventorySaveLocs3x2x1;
		}
		if (identifier == "home2InventorySaveLocs2x2x1")
		{
			return ES3.loadedSave.home2InventorySaveLocs2x2x1;
		}
		if (identifier == "home2InventorySaveLocs2x2x2")
		{
			return ES3.loadedSave.home2InventorySaveLocs2x2x2;
		}
		if (identifier == "home2InventorySaveLocs2x2x3")
		{
			return ES3.loadedSave.home2InventorySaveLocs2x2x3;
		}
		if (identifier == "home2InventorySaveLocs3x2x3")
		{
			return ES3.loadedSave.home2InventorySaveLocs3x2x3;
		}
		if (identifier == "home2InventorySaveLocs4x2x2")
		{
			return ES3.loadedSave.home2InventorySaveLocs4x2x2;
		}
		if (identifier == "home2InventorySaveLocs4x2x3")
		{
			return ES3.loadedSave.home2InventorySaveLocs4x2x3;
		}
		if (identifier == "home2InventorySaveLocs4x1x1")
		{
			return ES3.loadedSave.home2InventorySaveLocs4x1x1;
		}
		if (identifier == "home2InventorySaveLocs4x2x1")
		{
			return ES3.loadedSave.home2InventorySaveLocs4x2x1;
		}
		if (identifier == "home2InventorySaveLocs2x1x3")
		{
			return ES3.loadedSave.home2InventorySaveLocs2x1x3;
		}
		if (identifier == "home3InventorySaveList")
		{
			return ES3.loadedSave.home3inventorySaveList;
		}
		if (identifier == "home3InventorySaveLocsSingle")
		{
			return ES3.loadedSave.home3InventorySaveLocsSingle;
		}
		if (identifier == "home3InventoryTradeGoodsSmallIDSaveList")
		{
			return ES3.loadedSave.home3InventoryTradeGoodsSmallIDSaveList;
		}
		if (identifier == "home3InventorySaveLists3x2x1")
		{
			return ES3.loadedSave.home3InventorySaveLists3x2x1;
		}
		if (identifier == "home3InventorySaveLists2x2x1")
		{
			return ES3.loadedSave.home3InventorySaveLists2x2x1;
		}
		if (identifier == "home3InventorySaveLists2x2x2")
		{
			return ES3.loadedSave.home3InventorySaveLists2x2x2;
		}
		if (identifier == "home3InventorySaveLists2x2x3")
		{
			return ES3.loadedSave.home3InventorySaveLists2x2x3;
		}
		if (identifier == "home3InventorySaveLists3x2x3")
		{
			return ES3.loadedSave.home3InventorySaveLists3x2x3;
		}
		if (identifier == "home3InventorySaveLists4x2x2")
		{
			return ES3.loadedSave.home3InventorySaveLists4x2x2;
		}
		if (identifier == "home3InventorySaveLists4x2x3")
		{
			return ES3.loadedSave.home3InventorySaveLists4x2x3;
		}
		if (identifier == "home3InventorySaveLists4x1x1")
		{
			return ES3.loadedSave.home3InventorySaveLists4x1x1;
		}
		if (identifier == "home3InventorySaveLists4x2x1")
		{
			return ES3.loadedSave.home3InventorySaveLists4x2x1;
		}
		if (identifier == "home3InventorySaveLists2x1x3")
		{
			return ES3.loadedSave.home3InventorySaveLists2x1x3;
		}
		if (identifier == "home3InventorySaveLocs3x2x1")
		{
			return ES3.loadedSave.home3InventorySaveLocs3x2x1;
		}
		if (identifier == "home3InventorySaveLocs2x2x1")
		{
			return ES3.loadedSave.home3InventorySaveLocs2x2x1;
		}
		if (identifier == "home3InventorySaveLocs2x2x2")
		{
			return ES3.loadedSave.home3InventorySaveLocs2x2x2;
		}
		if (identifier == "home3InventorySaveLocs2x2x3")
		{
			return ES3.loadedSave.home3InventorySaveLocs2x2x3;
		}
		if (identifier == "home3InventorySaveLocs3x2x3")
		{
			return ES3.loadedSave.home3InventorySaveLocs3x2x3;
		}
		if (identifier == "home3InventorySaveLocs4x2x2")
		{
			return ES3.loadedSave.home3InventorySaveLocs4x2x2;
		}
		if (identifier == "home3InventorySaveLocs4x2x3")
		{
			return ES3.loadedSave.home3InventorySaveLocs4x2x3;
		}
		if (identifier == "home3InventorySaveLocs4x1x1")
		{
			return ES3.loadedSave.home3InventorySaveLocs4x1x1;
		}
		if (identifier == "home3InventorySaveLocs4x2x1")
		{
			return ES3.loadedSave.home3InventorySaveLocs4x2x1;
		}
		if (identifier == "home3InventorySaveLocs2x1x3")
		{
			return ES3.loadedSave.home3InventorySaveLocs2x1x3;
		}
		if (identifier == "home4InventorySaveList")
		{
			return ES3.loadedSave.home4inventorySaveList;
		}
		if (identifier == "home4InventorySaveLocsSingle")
		{
			return ES3.loadedSave.home4InventorySaveLocsSingle;
		}
		if (identifier == "home4InventoryTradeGoodsSmallIDSaveList")
		{
			return ES3.loadedSave.home4InventoryTradeGoodsSmallIDSaveList;
		}
		if (identifier == "home4InventorySaveLists3x2x1")
		{
			return ES3.loadedSave.home4InventorySaveLists3x2x1;
		}
		if (identifier == "home4InventorySaveLists2x2x1")
		{
			return ES3.loadedSave.home4InventorySaveLists2x2x1;
		}
		if (identifier == "home4InventorySaveLists2x2x2")
		{
			return ES3.loadedSave.home4InventorySaveLists2x2x2;
		}
		if (identifier == "home4InventorySaveLists2x2x3")
		{
			return ES3.loadedSave.home4InventorySaveLists2x2x3;
		}
		if (identifier == "home4InventorySaveLists3x2x3")
		{
			return ES3.loadedSave.home4InventorySaveLists3x2x3;
		}
		if (identifier == "home4InventorySaveLists4x2x2")
		{
			return ES3.loadedSave.home4InventorySaveLists4x2x2;
		}
		if (identifier == "home4InventorySaveLists4x2x3")
		{
			return ES3.loadedSave.home4InventorySaveLists4x2x3;
		}
		if (identifier == "home4InventorySaveLists4x1x1")
		{
			return ES3.loadedSave.home4InventorySaveLists4x1x1;
		}
		if (identifier == "home4InventorySaveLists4x2x1")
		{
			return ES3.loadedSave.home4InventorySaveLists4x2x1;
		}
		if (identifier == "home4InventorySaveLists2x1x3")
		{
			return ES3.loadedSave.home4InventorySaveLists2x1x3;
		}
		if (identifier == "home4InventorySaveLocs3x2x1")
		{
			return ES3.loadedSave.home4InventorySaveLocs3x2x1;
		}
		if (identifier == "home4InventorySaveLocs2x2x1")
		{
			return ES3.loadedSave.home4InventorySaveLocs2x2x1;
		}
		if (identifier == "home4InventorySaveLocs2x2x2")
		{
			return ES3.loadedSave.home4InventorySaveLocs2x2x2;
		}
		if (identifier == "home4InventorySaveLocs2x2x3")
		{
			return ES3.loadedSave.home4InventorySaveLocs2x2x3;
		}
		if (identifier == "home4InventorySaveLocs3x2x3")
		{
			return ES3.loadedSave.home4InventorySaveLocs3x2x3;
		}
		if (identifier == "home4InventorySaveLocs4x2x2")
		{
			return ES3.loadedSave.home4InventorySaveLocs4x2x2;
		}
		if (identifier == "home4InventorySaveLocs4x2x3")
		{
			return ES3.loadedSave.home4InventorySaveLocs4x2x3;
		}
		if (identifier == "home4InventorySaveLocs4x1x1")
		{
			return ES3.loadedSave.home4InventorySaveLocs4x1x1;
		}
		if (identifier == "home4InventorySaveLocs4x2x1")
		{
			return ES3.loadedSave.home4InventorySaveLocs4x2x1;
		}
		if (identifier == "home4InventorySaveLocs2x1x3")
		{
			return ES3.loadedSave.home4InventorySaveLocs2x1x3;
		}
		if (identifier == "home5InventorySaveList")
		{
			return ES3.loadedSave.home5inventorySaveList;
		}
		if (identifier == "home5InventorySaveLocsSingle")
		{
			return ES3.loadedSave.home5InventorySaveLocsSingle;
		}
		if (identifier == "home5InventoryTradeGoodsSmallIDSaveList")
		{
			return ES3.loadedSave.home5InventoryTradeGoodsSmallIDSaveList;
		}
		if (identifier == "home5InventorySaveLists3x2x1")
		{
			return ES3.loadedSave.home5InventorySaveLists3x2x1;
		}
		if (identifier == "home5InventorySaveLists2x2x1")
		{
			return ES3.loadedSave.home5InventorySaveLists2x2x1;
		}
		if (identifier == "home5InventorySaveLists2x2x2")
		{
			return ES3.loadedSave.home5InventorySaveLists2x2x2;
		}
		if (identifier == "home5InventorySaveLists2x2x3")
		{
			return ES3.loadedSave.home5InventorySaveLists2x2x3;
		}
		if (identifier == "home5InventorySaveLists3x2x3")
		{
			return ES3.loadedSave.home5InventorySaveLists3x2x3;
		}
		if (identifier == "home5InventorySaveLists4x2x2")
		{
			return ES3.loadedSave.home5InventorySaveLists4x2x2;
		}
		if (identifier == "home5InventorySaveLists4x2x3")
		{
			return ES3.loadedSave.home5InventorySaveLists4x2x3;
		}
		if (identifier == "home5InventorySaveLists4x1x1")
		{
			return ES3.loadedSave.home5InventorySaveLists4x1x1;
		}
		if (identifier == "home5InventorySaveLists4x2x1")
		{
			return ES3.loadedSave.home5InventorySaveLists4x2x1;
		}
		if (identifier == "home5InventorySaveLists2x1x3")
		{
			return ES3.loadedSave.home5InventorySaveLists2x1x3;
		}
		if (identifier == "home5InventorySaveLocs3x2x1")
		{
			return ES3.loadedSave.home5InventorySaveLocs3x2x1;
		}
		if (identifier == "home5InventorySaveLocs2x2x1")
		{
			return ES3.loadedSave.home5InventorySaveLocs2x2x1;
		}
		if (identifier == "home5InventorySaveLocs2x2x2")
		{
			return ES3.loadedSave.home5InventorySaveLocs2x2x2;
		}
		if (identifier == "home5InventorySaveLocs2x2x3")
		{
			return ES3.loadedSave.home5InventorySaveLocs2x2x3;
		}
		if (identifier == "home5InventorySaveLocs3x2x3")
		{
			return ES3.loadedSave.home5InventorySaveLocs3x2x3;
		}
		if (identifier == "home5InventorySaveLocs4x2x2")
		{
			return ES3.loadedSave.home5InventorySaveLocs4x2x2;
		}
		if (identifier == "home5InventorySaveLocs4x2x3")
		{
			return ES3.loadedSave.home5InventorySaveLocs4x2x3;
		}
		if (identifier == "home5InventorySaveLocs4x1x1")
		{
			return ES3.loadedSave.home5InventorySaveLocs4x1x1;
		}
		if (identifier == "home5InventorySaveLocs4x2x1")
		{
			return ES3.loadedSave.home5InventorySaveLocs4x2x1;
		}
		if (identifier == "home5InventorySaveLocs2x1x3")
		{
			return ES3.loadedSave.home5InventorySaveLocs2x1x3;
		}
		if (identifier == "home1InventorySaveListsTyres")
		{
			return ES3.loadedSave.home1InventorySaveListsTyres;
		}
		if (identifier == "home2InventorySaveListsTyres")
		{
			return ES3.loadedSave.home2InventorySaveListsTyres;
		}
		if (identifier == "home3InventorySaveListsTyres")
		{
			return ES3.loadedSave.home3InventorySaveListsTyres;
		}
		if (identifier == "home4InventorySaveListsTyres")
		{
			return ES3.loadedSave.home4InventorySaveListsTyres;
		}
		if (identifier == "home5InventorySaveListsTyres")
		{
			return ES3.loadedSave.home5InventorySaveListsTyres;
		}
		Debug.Log("NOT FOUND LOADING LIST INT - " + identifier);
		return new List<int>();
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00011882 File Offset: 0x0000FC82
	public static bool Exists(string identifier)
	{
		return true;
	}

	// Token: 0x040000A4 RID: 164
	public static ES3 Global;

	// Token: 0x040000A5 RID: 165
	public static SaveFile loadedSave;
}
