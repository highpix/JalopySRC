using System;
using System.Collections;
using Pathfinding;
using UnityEngine;

// Token: 0x02000126 RID: 294
public class Scene1_LogicC : MonoBehaviour
{
	// Token: 0x06000B5C RID: 2908 RVA: 0x001076F4 File Offset: 0x00105AF4
	public void StartNewGameSkipTutorial()
	{
		this.hasGivenTutorial = true;
		ES3.loadedSave = new SaveFile();
		ES3.Save(true, "uncleTutorialCompleted");
		ES3.Save(true, "doorFitted");
		ES3.Save(1, "carEngineID");
		ES3.Save(3f, "carEngineCondition");
		ES3.Save(1, "ignitionCoilID");
		ES3.Save(3f, "ignitionCoilCondition");
		ES3.Save(1, "fuelTankID");
		ES3.Save(3f, "fuelTankCondition");
		ES3.Save(10f, "fuelTankFuelAmount");
		ES3.Save(3, "fuelTankFuelMix");
		ES3.Save(1, "carburettorID");
		ES3.Save(3f, "carburettorCondition");
		ES3.Save(1, "airFilterID");
		ES3.Save(3f, "airFilterCondition");
		ES3.Save(1, "waterTankID");
		ES3.Save(3f, "waterTankCondition");
		ES3.Save(4, "waterTankWaterCharges");
		ES3.Save(1, "batteryID");
		ES3.Save(3f, "batteryCondition");
		ES3.Save(100f, "batteryCharges");
		ES3.Save(1, "flWheelID");
		ES3.Save(0f, "flCompoundID");
		ES3.Save(3f, "flWheelCondition");
		ES3.Save(1, "frWheelID");
		ES3.Save(0f, "frCompoundID");
		ES3.Save(3f, "frWheelCondition");
		ES3.Save(1, "rlWheelID");
		ES3.Save(0f, "rlCompoundID");
		ES3.Save(3f, "rlWheelCondition");
		ES3.Save(1, "rrWheelID");
		ES3.Save(0f, "rrCompoundID");
		ES3.Save(3f, "rrWheelCondition");
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x001078B8 File Offset: 0x00105CB8
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		if (base.GetComponent<UncleLogicC>().uncleGoneForever)
		{
			base.transform.parent = null;
			base.transform.position = new Vector3(0f, -1000f, -1000f);
		}
		if (this.hasGivenTutorial)
		{
			this.UncleAlreadyGivenTutorial();
			base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarLogicC>().leftDoor.GetComponent<DoorLogicC>().isLocked = false;
			this.hasGivenTutorialChecked = true;
			this.sparePartsCabinetTrigger.SetActive(true);
			this.sparePartsCabinetTrigger.GetComponent<HomeTriggersC>().ForceTrigger();
			this.fuelCabinetTrigger.SetActive(true);
			this.fuelCabinetTrigger.GetComponent<HomeTriggersC>().ForceTrigger();
			this.tyreTrigger.SetActive(true);
			this.tyreTrigger.GetComponent<HomeTriggersC>().ForceTrigger();
			return;
		}
		if (!this.debugEnter)
		{
			base.StartCoroutine(this.LogicStage1());
		}
		else
		{
			this.DebugCarEnter();
		}
	}

	// Token: 0x06000B5E RID: 2910 RVA: 0x001079E5 File Offset: 0x00105DE5
	public void NightGo()
	{
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x001079E7 File Offset: 0x00105DE7
	public void LateNightGo()
	{
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x001079E9 File Offset: 0x00105DE9
	public void DayGo()
	{
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x001079EC File Offset: 0x00105DEC
	public void UncleAlreadyGivenTutorial()
	{
		this.holdingItems[0].transform.parent = this.holdingItems[0].GetComponent<MagazineLogicC>().dropOffPoint;
		this.holdingItems[0].transform.localPosition = Vector3.zero;
		this.holdingItems[0].transform.localEulerAngles = Vector3.zero;
		this.holdingItems[0].SetActive(true);
		UnityEngine.Object.Destroy(this.holdingItems[1].GetComponent<MapUncleLogicC>());
		this.holdingItems[1].transform.parent = this.holdingItems[1].GetComponent<MapLogicC>().doorLoc;
		this.holdingItems[1].transform.localPosition = Vector3.zero;
		this.holdingItems[1].transform.localEulerAngles = Vector3.zero;
		this.holdingItems[1].SetActive(true);
		this.holdingItems[2].transform.parent = this.holdingItems[2].GetComponent<KeyUncleLogicC>().holdingPosition;
		this.holdingItems[2].transform.localPosition = Vector3.zero;
		this.holdingItems[2].transform.localEulerAngles = Vector3.zero;
		this.holdingItems[2].SetActive(true);
		base.StopCoroutine("DoorFitted");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.gameObject.transform.position = this.uncleStartPosition.position;
		MainMenuC.Global.wakeUpAtHome = true;
		MainMenuC.Global.SendMessage("GetUpOutOfBerlinBed");
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x00107B90 File Offset: 0x00105F90
	private void Update()
	{
		if (this.notDropped && (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) || Input.GetButtonDown("Drop")))
		{
			this.notDropped = false;
		}
		this.distanceFromCarDoor = Vector3.Distance(base.transform.position, this.nodeTargets[1].transform.position);
		float num = Vector3.Distance(base.transform.position, base.GetComponent<UncleLogicC>().player.transform.position);
		if (this.hasGivenTutorialChecked && !base.GetComponent<UncleLogicC>().debugStopUncleWorking && !base.GetComponent<UncleLogicC>().uncleGoneForever)
		{
			if ((double)num < 5.0 && !this.standardUncleIntroductionFinished && !this.uncleJourneyDeclined && !this.bringCarCloserRunning)
			{
				if ((double)this.distanceFromCarDoor <= 20.0)
				{
					base.StartCoroutine(this.StandardUncleIntroduction());
				}
			}
			if ((double)num > 6.5 && this.uncleJourneyDeclined)
			{
				this.uncleJourneyDeclined = false;
			}
			return;
		}
		if (!this.hasGivenTutorial)
		{
			if ((double)this.distanceFromCarDoor < 0.5 && (double)num < 8.0 && !this.doorTutorialStarted && !this.doorTutorialCompleted)
			{
				base.StartCoroutine(this.DoorTutorial());
			}
			if ((double)this.distanceFromCarDoor < 0.5 && (double)num < 8.0 && this.doorTutorialStarted && !this.doorTutorialCompleted && this.allowDoorTutorialDropItem && !this.runningDropItemDoorTutorial)
			{
				base.StartCoroutine("DropItemDoorTutorial");
			}
			if (this.startBonnetLatchRepeat && !this.bonnetLatchRepeatRunning)
			{
				this.bonnetLatchRepeatTime += Time.deltaTime;
				if ((double)this.bonnetLatchRepeatTime > 10.0)
				{
					base.StartCoroutine("BonnetLatchRepeat");
				}
			}
			if (this.startEngineTutorialRepeat && !this.engineTutorialRepeatRunning)
			{
				this.engineTutorialRepeatTime += Time.deltaTime;
				if ((double)this.engineTutorialRepeatTime > 10.0)
				{
					base.StartCoroutine("EngineTutorialRepeat");
				}
			}
			if ((double)num < 10.0 && this.engineTutorialFinished && this.ignitionCoilFitted && this.engineBlockFitted && this.carburettorFitted && this.airFilterFitted && this.fuelTankFitted && this.waterTankFitted && this.batteryFitted && !this.fuelAndOilTutorialStart)
			{
				this.engineTutorialFinished = true;
				base.StartCoroutine("FinishEngineTutorial");
			}
			if ((double)num < 10.0 && this.engineTutorialStart && !this.engineTutorialFinished)
			{
				if (this.engineTutorialRepeatRunning && !this.reminderToFitOtherComponents && this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null && !this.reminderToFitOtherComponentsRepeatRunning)
				{
					this.reminderToFitOtherComponentsTime += Time.deltaTime;
					if ((double)this.reminderToFitOtherComponentsTime > 10.0)
					{
						base.StartCoroutine("StillNeedToInstall");
					}
				}
				if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null)
				{
					if (!this.engineTutorialCarburettorFinished && !this.engineTutorialCarburettorStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "Carburettor")
					{
						this.engineTutorialCarburettorStarted = true;
						base.StartCoroutine("EngineTutorialCarburettorHeld");
					}
					if (!this.engineTutorialEngineBlockFinished && !this.engineTutorialEngineBlockStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "EngineBlock")
					{
						this.engineTutorialEngineBlockStarted = true;
						base.StartCoroutine("EngineTutorialEngineBlockHeld");
					}
					if (!this.engineTutorialIgnitionCoilFinished && !this.engineTutorialIgnitionCoilStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "IgnitionCoil")
					{
						this.engineTutorialIgnitionCoilStarted = true;
						base.StartCoroutine("EngineTutorialIgnitionCoilHeld");
					}
					if (!this.engineTutorialAirFilterFinished && !this.engineTutorialAirFilterStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "AirFilter")
					{
						this.engineTutorialAirFilterStarted = true;
						base.StartCoroutine("EngineTutorialAirFilterHeld");
					}
					if (!this.engineTutorialFuelTankFinished && !this.engineTutorialFuelTankStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "FuelTank")
					{
						this.engineTutorialFuelTankStarted = true;
						base.StartCoroutine("EngineTutorialFuelTankHeld");
					}
					if (!this.engineTutorialWaterTankFinished && !this.engineTutorialWaterTankStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "WaterContainer")
					{
						this.engineTutorialWaterTankStarted = true;
						base.StartCoroutine("EngineTutorialWaterTankHeld");
					}
					if (!this.engineTutorialBatteryFinished && !this.engineTutorialBatteryStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "Battery")
					{
						this.engineTutorialBatteryStarted = true;
						base.StartCoroutine("EngineTutorialBatteryHeld");
					}
				}
			}
			if ((double)num < 10.0 && this.fuelAndOilTutorialStart && !this.fuelAndOilTutorialFinished)
			{
				if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null)
				{
					if (!this.fuelAndOilTutorialFuelFinished && !this.fuelAndOilTutorialFuelStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "GasCan")
					{
						this.fuelAndOilTutorialFuelStarted = true;
						base.StartCoroutine("FuelAndOilTutorialFuelHeld");
					}
					if (!this.fuelAndOilTutorialOilFinished && !this.fuelAndOilTutorialOilStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "2-Stroke")
					{
						this.fuelAndOilTutorialOilStarted = true;
						base.StartCoroutine("FuelAndOilTutorialOilHeld");
					}
					if (!this.fuelAndOilTutorialWaterFinished && !this.fuelAndOilTutorialWaterStarted && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "WaterBottle")
					{
						this.fuelAndOilTutorialWaterStarted = true;
						base.StartCoroutine("FuelAndOilTutorialWaterHeld");
					}
				}
				else if ((double)num < 10.0 && !this.reminderToRefuelRunning)
				{
					if (!this.fuelAndOilTutorialWaterFinished || !this.fuelAndOilTutorialFuelFinished || !this.fuelAndOilTutorialOilFinished)
					{
						this.reminderToRefuelTime += Time.deltaTime;
						if ((double)this.reminderToRefuelTime > 10.0)
						{
							base.StartCoroutine("StillNeedToRefuel");
						}
					}
					if (this.fuelAndOilTutorialWaterFinished && this.fuelAndOilTutorialFuelFinished && this.fuelAndOilTutorialOilFinished && !this.fuelAndOilTutorialFinished)
					{
						this.fuelAndOilTutorialFinished = true;
						base.StartCoroutine("StopInputRestrict");
						base.StartCoroutine("StopInputRestrictDropOnly");
						base.StopCoroutine("DropHolding");
						base.StartCoroutine("ClearDialogue", 0.0);
						base.StopCoroutine("FuelTutorialComplete");
						base.StartCoroutine("FuelTutorialComplete");
					}
				}
			}
			if (this.waitingForPlayerToGetCarJack && (double)num < 10.0 && !this.reminderToGetCarJackRunning)
			{
				this.reminderToGetCarJackTimer += Time.deltaTime;
				if ((double)this.reminderToGetCarJackTimer > 10.0)
				{
					base.StartCoroutine("StillNeedToGetCarJack");
				}
			}
			if (this.waitingForPlayerToGetCarJack && (double)num < 10.0 && this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "CarJack")
			{
				base.StartCoroutine("PlaceJackUnderCar");
			}
			if (this.waitingForPlayerToGetTyres && (double)num < 10.0 && !this.reminderToGetTyresRunning)
			{
				this.reminderToGetTyresTimer += Time.deltaTime;
				if ((double)this.reminderToGetTyresTimer > 10.0)
				{
					base.StartCoroutine("StillNeedToGetTyres");
				}
			}
			if (this.waitingForPlayerToGetTyres && (double)num < 10.0 && this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "Wheel")
			{
				base.StartCoroutine("PlaceTyreOntoAxle");
			}
			if (!this.nowFitTheOtherTyrePlayed)
			{
				if (base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontLeftTyre != null && base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearLeftTyre != null)
				{
					if (!base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose && !base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose)
					{
						base.StartCoroutine("NowFitTheOtherTyres");
					}
				}
				else if (base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontRightTyre != null && base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearRightTyre != null && !base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose && !base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose)
				{
					base.StartCoroutine("NowFitTheOtherTyres");
				}
			}
			else if (!this.washCarSuggestionStarted && base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontLeftTyre != null && base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontRightTyre != null && base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearLeftTyre != null && base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearRightTyre != null && !base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose && !base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose && !base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose && !base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose)
			{
				base.StartCoroutine("WashCarSuggestion");
			}
		}
	}

	// Token: 0x06000B63 RID: 2915 RVA: 0x001087C8 File Offset: 0x00106BC8
	public void StopInputRestrictStopper()
	{
		base.StopCoroutine("StopInputRestrict");
	}

	// Token: 0x06000B64 RID: 2916 RVA: 0x001087D8 File Offset: 0x00106BD8
	private IEnumerator StopInputRestrict()
	{
		yield return new WaitForSeconds(0.5f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000B65 RID: 2917 RVA: 0x001087F4 File Offset: 0x00106BF4
	private IEnumerator StopInputRestrictDropOnly()
	{
		yield return new WaitForSeconds(0.5f);
		this.inputRestrictDropItem = false;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropOnly = false;
		yield break;
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x0010880F File Offset: 0x00106C0F
	public void TextFinished()
	{
		this.textFinished = true;
	}

	// Token: 0x06000B67 RID: 2919 RVA: 0x00108818 File Offset: 0x00106C18
	private IEnumerator StandardUncleIntroduction()
	{
		base.StopCoroutine("StopInputRestrict");
		this.standardUncleIntroductionFinished = true;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0f);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia8_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia8_02", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		base.StartCoroutine("StopInputRestrict");
		MainMenuC.Global.EnableReticule();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		MainMenuC.Global.restrictPause = true;
		yield return new WaitForSeconds(0.4f);
		MainMenuC.Global.pauseUI[15].SetActive(true);
		Time.timeScale = 0f;
		this._camera.GetComponent<MouseLook>().enabled = false;
		this._camera.transform.parent.gameObject.GetComponent<MouseLook>().enabled = false;
		MainMenuC.Global.lockCursor = false;
		Screen.lockCursor = false;
		yield break;
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x00108834 File Offset: 0x00106C34
	public void UncleDontJoinJourney()
	{
		this.standardUncleIntroductionFinished = false;
		this.uncleJourneyDeclined = true;
		MainMenuC.Global.pauseUI[15].SetActive(false);
		Time.timeScale = 1f;
		this._camera.GetComponent<MouseLook>().enabled = true;
		this._camera.transform.parent.gameObject.GetComponent<MouseLook>().enabled = true;
		MainMenuC.Global.lockCursor = true;
		Screen.lockCursor = true;
		MainMenuC.Global.restrictPause = false;
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x001088BC File Offset: 0x00106CBC
	public void UncleJoinJourney()
	{
		MainMenuC.Global.pauseUI[15].SetActive(false);
		Time.timeScale = 1f;
		this._camera.GetComponent<MouseLook>().enabled = true;
		this._camera.transform.parent.gameObject.GetComponent<MouseLook>().enabled = true;
		MainMenuC.Global.lockCursor = true;
		Screen.lockCursor = true;
		base.gameObject.GetComponent<AIPath>().destination = this.nodeTargets[1].position;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
		base.StartCoroutine("DebugCarEnter");
		base.GetComponent<UncleLogicC>().uncleAtHome = false;
		MainMenuC.Global.restrictPause = false;
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x00108988 File Offset: 0x00106D88
	private IEnumerator LogicStage1()
	{
		MainMenuC.Global.ReticuleToggle(true);
		base.GetComponent<UncleLogicC>().uncleAtHome = false;
		base.StopCoroutine("StopInputRestrict");
		MainMenuC.Global.restrictPause = true;
		yield return new WaitForSeconds(2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().YellBubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia_02", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().CancelYell();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		MainMenuC.Global.SendMessage("WakeUpPre1");
		yield return new WaitForSeconds(1.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia_03", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia_04", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		MainMenuC.Global.SendMessage("GetUpOutOfBerlinBed");
		yield return new WaitForSeconds(1.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia_05", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.gameObject.GetComponent<AIPath>().destination = this.nodeTargets[1].position;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia_06", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.6f);
		MainMenuC.Global.restrictPause = false;
		MainMenuC.Global.ReticuleToggle(true);
		yield break;
	}

	// Token: 0x06000B6B RID: 2923 RVA: 0x001089A4 File Offset: 0x00106DA4
	private IEnumerator DropItemDoorTutorial()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null)
		{
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "R_Door")
			{
				yield break;
			}
			if (this.hasGivenTutorial)
			{
				yield break;
			}
			base.StopCoroutine("StopInputRestrict");
			base.StopCoroutine("DoorTutorial");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.runningDropItemDoorTutorial = true;
			yield return new WaitForSeconds(0.2f);
			this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropOnly = true;
			this.inputRestrictDropItem = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dropthat_03", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnim();
			this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
			bool notDropped = true;
			while (notDropped)
			{
				if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) || Input.GetButtonDown("Drop"))
				{
					notDropped = false;
				}
				yield return new WaitForEndOfFrame();
			}
			base.StartCoroutine("StopInputRestrict");
			base.StartCoroutine("StopInputRestrictDropOnly");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
			yield return new WaitForSeconds(0.4f);
			this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropOnly = false;
			this.inputRestrictDropItem = false;
			this.runningDropItemDoorTutorial = false;
		}
		yield break;
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x001089C0 File Offset: 0x00106DC0
	private IEnumerator DoorTutorial()
	{
		base.StopCoroutine("StopInputRestrict");
		this.doorTutorialStarted = true;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia2_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia2_02", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia2_03", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia2_04", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia2_05", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia2_06", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia2_07", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().RightClickAnim();
		yield return new WaitWhile(() => !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[20]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[21]) && !Input.GetButton("JoypadZoom"));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.allowDoorTutorialDropItem = true;
		yield break;
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x001089DC File Offset: 0x00106DDC
	private IEnumerator DoorFitted()
	{
		if (this.hasGivenTutorial)
		{
			yield break;
		}
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("DoorTutorial");
		this.doorTutorialCompleted = true;
		this.allowDoorTutorialDropItem = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarLogicC>().leftDoor.GetComponent<DoorLogicC>().isLocked = false;
		yield return new WaitForSeconds(0.2f);
		Debug.Log("Door Fitted");
		this.bonnetTutorialStart = true;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia3_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia3_02", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.gameObject.GetComponent<AIPath>().target = this.nodeTargets[2];
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia3_03", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.startBonnetLatchRepeat = true;
		this.textFinished = false;
		yield break;
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x001089F8 File Offset: 0x00106DF8
	private IEnumerator BonnetLatchRepeat()
	{
		base.StopCoroutine("StopInputRestrict");
		this.bonnetLatchRepeatTime = 0f;
		if (!this.bonnetLatchRepeatRunning)
		{
			this.bonnetLatchRepeatRunning = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia3_03b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			this.bonnetLatchRepeatRunning = false;
		}
		yield break;
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x00108A13 File Offset: 0x00106E13
	public void PlayerOpensDriverDoor()
	{
		if (this.bonnetTutorialStart && !this.bonnetTutorialFinished && !this.hasGivenCarDoorText)
		{
			this.hasGivenCarDoorText = true;
			base.StartCoroutine("InCarDuringBonnetTutorial");
		}
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x00108A4C File Offset: 0x00106E4C
	private IEnumerator InCarDuringBonnetTutorial()
	{
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("DoorFitted");
		base.StopCoroutine("BonnetLatchRepeat");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.gameObject.GetComponent<AIPath>().target = this.nodeTargets[2];
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia3_03c", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x00108A67 File Offset: 0x00106E67
	public void PlayerOpensTheBonnetLatch()
	{
		if (this.bonnetTutorialStart && !this.bonnetTutorialFinished)
		{
			base.StartCoroutine("BonnetTutorialContinue");
		}
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x00108A8C File Offset: 0x00106E8C
	private IEnumerator BonnetTutorialContinue()
	{
		if (this.bonnetLatchTutorialFinished)
		{
			yield break;
		}
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("BonnetLatchRepeat");
		base.StopCoroutine("DoorFitted");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia3_04", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia3_05", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		this.bonnetLatchTutorialFinished = true;
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x00108AA8 File Offset: 0x00106EA8
	public void BonnetOpened()
	{
		if (!this.hasGivenTutorial)
		{
			if (!this.bonnetTutorialStart && !this.doorTutorialStarted && !this.doorTutorialCompleted)
			{
				base.StartCoroutine("DoorBeforeBonnet2");
				return;
			}
			if (!this.bonnetTutorialStart && this.doorTutorialStarted && !this.doorTutorialCompleted)
			{
				base.StartCoroutine("DoorBeforeBonnet");
				return;
			}
			if (!this.engineTutorialStart && !this.engineTutorialFinished)
			{
				base.StartCoroutine("EngineTutorialStart");
			}
		}
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x00108B40 File Offset: 0x00106F40
	private IEnumerator DoorBeforeBonnet()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("DoorTutorial");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.engineTutorialStart = true;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia6_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x00108B5C File Offset: 0x00106F5C
	private IEnumerator DoorBeforeBonnet2()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("DoorTutorial");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.engineTutorialStart = true;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia6_01b", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x00108B78 File Offset: 0x00106F78
	private IEnumerator EngineTutorialStart()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("InCarDuringBonnetTutorial");
		base.StopCoroutine("BonnetLatchRepeat");
		base.StopCoroutine("BonnetTutorialContinue");
		base.StopCoroutine("DoorFitted");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.engineTutorialStart = true;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_02", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.sparePartsCabinetTrigger.SetActive(true);
		this.startEngineTutorialRepeat = true;
		yield break;
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x00108B94 File Offset: 0x00106F94
	private IEnumerator PlaceIntoEngine()
	{
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_10", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x00108BB0 File Offset: 0x00106FB0
	private IEnumerator EngineTutorialCarburettorHeld()
	{
		if (!this.engineTutorialStart)
		{
			base.StartCoroutine("DropHolding");
			yield break;
		}
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("EngineTutorialEngineBlockHeld");
		this.engineTutorialEngineBlockStarted = false;
		base.StopCoroutine("EngineTutorialIgnitionCoilHeld");
		this.engineTutorialIgnitionCoilStarted = false;
		base.StopCoroutine("EngineTutorialAirFilterHeld");
		this.engineTutorialAirFilterStarted = false;
		base.StopCoroutine("EngineTutorialFuelTankHeld");
		this.engineTutorialFuelTankStarted = false;
		base.StopCoroutine("EngineTutorialWaterTankHeld");
		this.engineTutorialWaterTankStarted = false;
		base.StopCoroutine("EngineTutorialBatteryHeld");
		this.engineTutorialBatteryStarted = false;
		yield return new WaitForSeconds(0.4f);
		if (!this.engineTutorialCarburettorFinished)
		{
			base.StopCoroutine("EngineTutorialRepeat");
			this.startEngineTutorialRepeat = false;
			this.engineTutorialRepeatRunning = true;
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_03", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_03b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.engineTutorialCarburettorFinished = true;
			base.StartCoroutine("PlaceIntoEngine");
		}
		yield break;
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x00108BCC File Offset: 0x00106FCC
	private IEnumerator EngineTutorialEngineBlockHeld()
	{
		if (!this.engineTutorialStart)
		{
			base.StartCoroutine("DropHolding");
			yield break;
		}
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("EngineTutorialCarburettorHeld");
		this.engineTutorialCarburettorStarted = false;
		base.StopCoroutine("EngineTutorialIgnitionCoilHeld");
		this.engineTutorialIgnitionCoilStarted = false;
		base.StopCoroutine("EngineTutorialAirFilterHeld");
		this.engineTutorialAirFilterStarted = false;
		base.StopCoroutine("EngineTutorialFuelTankHeld");
		this.engineTutorialFuelTankStarted = false;
		base.StopCoroutine("EngineTutorialWaterTankHeld");
		this.engineTutorialWaterTankStarted = false;
		base.StopCoroutine("EngineTutorialBatteryHeld");
		this.engineTutorialBatteryStarted = false;
		yield return new WaitForSeconds(0.4f);
		if (!this.engineTutorialEngineBlockFinished)
		{
			base.StopCoroutine("EngineTutorialRepeat");
			this.startEngineTutorialRepeat = false;
			this.engineTutorialRepeatRunning = true;
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_04", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_04b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_04c", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.engineTutorialEngineBlockFinished = true;
			base.StartCoroutine("PlaceIntoEngine");
		}
		yield break;
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x00108BE8 File Offset: 0x00106FE8
	private IEnumerator EngineTutorialIgnitionCoilHeld()
	{
		if (!this.engineTutorialStart)
		{
			base.StartCoroutine("DropHolding");
			yield break;
		}
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("EngineTutorialEngineBlockHeld");
		this.engineTutorialEngineBlockStarted = false;
		base.StopCoroutine("EngineTutorialCarburettorHeld");
		this.engineTutorialCarburettorStarted = false;
		base.StopCoroutine("EngineTutorialAirFilterHeld");
		this.engineTutorialAirFilterStarted = false;
		base.StopCoroutine("EngineTutorialFuelTankHeld");
		this.engineTutorialFuelTankStarted = false;
		base.StopCoroutine("EngineTutorialWaterTankHeld");
		this.engineTutorialWaterTankStarted = false;
		base.StopCoroutine("EngineTutorialBatteryHeld");
		this.engineTutorialBatteryStarted = false;
		yield return new WaitForSeconds(0.4f);
		if (!this.engineTutorialIgnitionCoilFinished)
		{
			base.StopCoroutine("EngineTutorialRepeat");
			this.startEngineTutorialRepeat = false;
			this.engineTutorialRepeatRunning = true;
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_05", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_05b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_05c", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.engineTutorialIgnitionCoilFinished = true;
			base.StartCoroutine("PlaceIntoEngine");
		}
		yield break;
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x00108C04 File Offset: 0x00107004
	private IEnumerator EngineTutorialFuelTankHeld()
	{
		if (!this.engineTutorialStart)
		{
			base.StartCoroutine("DropHolding");
			yield break;
		}
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("EngineTutorialEngineBlockHeld");
		this.engineTutorialEngineBlockStarted = false;
		base.StopCoroutine("EngineTutorialIgnitionCoilHeld");
		this.engineTutorialIgnitionCoilStarted = false;
		base.StopCoroutine("EngineTutorialAirFilterHeld");
		this.engineTutorialAirFilterStarted = false;
		base.StopCoroutine("EngineTutorialCarburettorHeld");
		this.engineTutorialCarburettorStarted = false;
		base.StopCoroutine("EngineTutorialWaterTankHeld");
		this.engineTutorialWaterTankStarted = false;
		base.StopCoroutine("EngineTutorialBatteryHeld");
		this.engineTutorialBatteryStarted = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.4f);
		if (!this.engineTutorialFuelTankFinished)
		{
			base.StopCoroutine("EngineTutorialRepeat");
			this.startEngineTutorialRepeat = false;
			this.engineTutorialRepeatRunning = true;
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_07", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_07b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_07c", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_07d", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_07e", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.engineTutorialFuelTankFinished = true;
			base.StartCoroutine("PlaceIntoEngine");
		}
		yield break;
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x00108C20 File Offset: 0x00107020
	private IEnumerator EngineTutorialWaterTankHeld()
	{
		if (!this.engineTutorialStart)
		{
			base.StartCoroutine("DropHolding");
			yield break;
		}
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("EngineTutorialEngineBlockHeld");
		this.engineTutorialEngineBlockStarted = false;
		base.StopCoroutine("EngineTutorialIgnitionCoilHeld");
		this.engineTutorialIgnitionCoilStarted = false;
		base.StopCoroutine("EngineTutorialAirFilterHeld");
		this.engineTutorialAirFilterStarted = false;
		base.StopCoroutine("EngineTutorialFuelTankHeld");
		this.engineTutorialFuelTankStarted = false;
		base.StopCoroutine("EngineTutorialCarburettorHeld");
		this.engineTutorialCarburettorStarted = false;
		base.StopCoroutine("EngineTutorialBatteryHeld");
		this.engineTutorialBatteryStarted = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.4f);
		if (!this.engineTutorialWaterTankFinished)
		{
			base.StopCoroutine("EngineTutorialRepeat");
			this.startEngineTutorialRepeat = false;
			this.engineTutorialRepeatRunning = true;
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_08", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_08b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.engineTutorialWaterTankFinished = true;
			base.StartCoroutine("PlaceIntoEngine");
		}
		yield break;
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x00108C3C File Offset: 0x0010703C
	private IEnumerator EngineTutorialAirFilterHeld()
	{
		if (!this.engineTutorialStart)
		{
			base.StartCoroutine("DropHolding");
			yield break;
		}
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("EngineTutorialEngineBlockHeld");
		this.engineTutorialEngineBlockStarted = false;
		base.StopCoroutine("EngineTutorialIgnitionCoilHeld");
		this.engineTutorialIgnitionCoilStarted = false;
		base.StopCoroutine("EngineTutorialWaterTankHeld");
		this.engineTutorialWaterTankStarted = false;
		base.StopCoroutine("EngineTutorialFuelTankHeld");
		this.engineTutorialFuelTankStarted = false;
		base.StopCoroutine("EngineTutorialCarburettorHeld");
		this.engineTutorialCarburettorStarted = false;
		base.StopCoroutine("EngineTutorialBatteryHeld");
		this.engineTutorialBatteryStarted = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.4f);
		if (!this.engineTutorialAirFilterFinished)
		{
			base.StopCoroutine("EngineTutorialRepeat");
			this.startEngineTutorialRepeat = false;
			this.engineTutorialRepeatRunning = true;
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_06", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_06b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.engineTutorialAirFilterFinished = true;
			base.StartCoroutine("PlaceIntoEngine");
		}
		yield break;
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x00108C58 File Offset: 0x00107058
	private IEnumerator EngineTutorialBatteryHeld()
	{
		if (!this.engineTutorialStart)
		{
			base.StartCoroutine("DropHolding");
			yield break;
		}
		base.StopCoroutine("EngineTutorialStart");
		base.StopCoroutine("StopInputRestrict");
		this.startBonnetLatchRepeat = false;
		base.StopCoroutine("EngineTutorialEngineBlockHeld");
		this.engineTutorialEngineBlockStarted = false;
		base.StopCoroutine("EngineTutorialIgnitionCoilHeld");
		this.engineTutorialIgnitionCoilStarted = false;
		base.StopCoroutine("EngineTutorialAirFilterHeld");
		this.engineTutorialAirFilterStarted = false;
		base.StopCoroutine("EngineTutorialFuelTankHeld");
		this.engineTutorialFuelTankStarted = false;
		base.StopCoroutine("EngineTutorialCarburettorHeld");
		this.engineTutorialCarburettorStarted = false;
		base.StopCoroutine("EngineTutorialWaterTankHeld");
		this.engineTutorialWaterTankStarted = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.4f);
		if (!this.engineTutorialBatteryFinished)
		{
			base.StopCoroutine("EngineTutorialRepeat");
			this.startEngineTutorialRepeat = false;
			this.engineTutorialRepeatRunning = true;
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_09", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_09b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_09c", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.engineTutorialBatteryFinished = true;
			base.StartCoroutine("PlaceIntoEngine");
		}
		yield break;
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x00108C74 File Offset: 0x00107074
	private IEnumerator FinishEngineTutorial()
	{
		this.fuelCabinetTrigger.SetActive(true);
		Debug.Log("Finished Engine Tutorial");
		base.StopCoroutine("StopInputRestrict");
		this.fuelAndOilTutorialStart = true;
		base.StopCoroutine("EngineTutorialRepeat");
		this.startEngineTutorialRepeat = false;
		this.reminderToFitOtherComponents = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_11", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_12", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.StartCoroutine("FuelAndOilTutorialStart");
		yield break;
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x00108C90 File Offset: 0x00107090
	private IEnumerator PutThatEngineComponentBack()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("FinishEngineTutorial");
		this.startEngineTutorialRepeat = false;
		this.engineTutorialFinished = false;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_14", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x00108CAC File Offset: 0x001070AC
	public void CheckAllComponents()
	{
		if (!this.ignitionCoilFitted)
		{
			return;
		}
		if (!this.engineBlockFitted)
		{
			return;
		}
		if (!this.carburettorFitted)
		{
			return;
		}
		if (!this.fuelTankFitted)
		{
			return;
		}
		if (!this.airFilterFitted)
		{
			return;
		}
		if (!this.batteryFitted)
		{
			return;
		}
		if (!this.waterTankFitted)
		{
			return;
		}
		this.engineTutorialFinished = true;
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x00108D14 File Offset: 0x00107114
	public void IgnitionCoilTutorialFitted()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		this.ignitionCoilFitted = true;
		this.CheckAllComponents();
		base.StopCoroutine("EngineTutorialIgnitionCoilHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StartCoroutine("StopInputRestrict");
		this.engineTutorialIgnitionCoilFinished = true;
	}

	// Token: 0x06000B83 RID: 2947 RVA: 0x00108D7C File Offset: 0x0010717C
	public void IgnitionCoilTutorialRemoved()
	{
		this.ignitionCoilFitted = false;
	}

	// Token: 0x06000B84 RID: 2948 RVA: 0x00108D88 File Offset: 0x00107188
	public void EngineBlockTutorialFitted()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		this.engineBlockFitted = true;
		this.CheckAllComponents();
		base.StopCoroutine("EngineTutorialEngineBlockHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StartCoroutine("StopInputRestrict");
		this.engineTutorialEngineBlockFinished = true;
	}

	// Token: 0x06000B85 RID: 2949 RVA: 0x00108DF0 File Offset: 0x001071F0
	public void EngineBlockTutorialRemoved()
	{
		this.engineBlockFitted = false;
	}

	// Token: 0x06000B86 RID: 2950 RVA: 0x00108DFC File Offset: 0x001071FC
	public void CarburettorTutorialFitted()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		this.carburettorFitted = true;
		this.CheckAllComponents();
		base.StopCoroutine("EngineTutorialCarburettorHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StartCoroutine("StopInputRestrict");
		this.engineTutorialCarburettorFinished = true;
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x00108E64 File Offset: 0x00107264
	public void CarburettorTutorialRemoved()
	{
		this.carburettorFitted = false;
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x00108E70 File Offset: 0x00107270
	public void FuelTankTutorialFitted()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		this.fuelTankFitted = true;
		this.CheckAllComponents();
		base.StopCoroutine("EngineTutorialFuelTankHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StartCoroutine("StopInputRestrict");
		this.engineTutorialFuelTankFinished = true;
	}

	// Token: 0x06000B89 RID: 2953 RVA: 0x00108ED8 File Offset: 0x001072D8
	public void FuelTankTutorialRemoved()
	{
		this.fuelTankFitted = false;
	}

	// Token: 0x06000B8A RID: 2954 RVA: 0x00108EE4 File Offset: 0x001072E4
	public void AirFilterTutorialFitted()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		this.airFilterFitted = true;
		this.CheckAllComponents();
		base.StopCoroutine("EngineTutorialAirFilterHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StartCoroutine("StopInputRestrict");
		this.engineTutorialAirFilterFinished = true;
	}

	// Token: 0x06000B8B RID: 2955 RVA: 0x00108F4C File Offset: 0x0010734C
	public void AirFilterTutorialRemoved()
	{
		this.airFilterFitted = false;
	}

	// Token: 0x06000B8C RID: 2956 RVA: 0x00108F58 File Offset: 0x00107358
	public void BatteryTutorialFitted()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		this.batteryFitted = true;
		this.CheckAllComponents();
		base.StopCoroutine("EngineTutorialBatteryHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StartCoroutine("StopInputRestrict");
		this.engineTutorialBatteryFinished = true;
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x00108FC0 File Offset: 0x001073C0
	public void BatteryTutorialRemoved()
	{
		this.batteryFitted = false;
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x00108FCC File Offset: 0x001073CC
	public void WaterTankTutorialFitted()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		this.waterTankFitted = true;
		this.CheckAllComponents();
		base.StopCoroutine("EngineTutorialWaterTankHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StartCoroutine("StopInputRestrict");
		this.engineTutorialWaterTankFinished = true;
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x00109034 File Offset: 0x00107434
	public void WaterTankTutorialRemoved()
	{
		this.waterTankFitted = false;
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x00109040 File Offset: 0x00107440
	private IEnumerator StillNeedToInstall()
	{
		this.reminderToFitOtherComponentsTime = 0f;
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("EngineTutorialRepeat");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		if (!this.reminderToFitOtherComponentsRepeatRunning)
		{
			yield return new WaitForSeconds(0.2f);
			this.reminderToFitOtherComponentsRepeatRunning = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_15", "Speech");
			bool needsComma = false;
			if (!this.ignitionCoilFitted)
			{
				DialogueStuffsC component = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component.word += " ";
				DialogueStuffsC component2 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component2.word += Language.Get("un_sc1_dia4_15g", "Speech");
				needsComma = true;
			}
			if (!this.engineBlockFitted)
			{
				DialogueStuffsC component3 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component3.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component4 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component4.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component5 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component5.word += Language.Get("un_sc1_dia4_15a", "Speech");
			}
			if (!this.airFilterFitted)
			{
				DialogueStuffsC component6 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component6.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component7 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component7.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component8 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component8.word += Language.Get("un_sc1_dia4_15c", "Speech");
			}
			if (!this.carburettorFitted)
			{
				DialogueStuffsC component9 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component9.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component10 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component10.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component11 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component11.word += Language.Get("un_sc1_dia4_15b", "Speech");
			}
			if (!this.fuelTankFitted)
			{
				DialogueStuffsC component12 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component12.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component13 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component13.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component14 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component14.word += Language.Get("un_sc1_dia4_15d", "Speech");
			}
			if (!this.waterTankFitted)
			{
				DialogueStuffsC component15 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component15.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component16 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component16.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component17 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component17.word += Language.Get("un_sc1_dia4_15e", "Speech");
			}
			if (!this.batteryFitted)
			{
				DialogueStuffsC component18 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component18.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component19 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component19.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component20 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component20.word += Language.Get("un_sc1_dia4_15f", "Speech");
			}
			DialogueStuffsC component21 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
			component21.word += ".";
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			this.reminderToFitOtherComponentsRepeatRunning = false;
		}
		yield break;
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x0010905C File Offset: 0x0010745C
	private IEnumerator FuelAndOilTutorialStart()
	{
		if (base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			if (base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount == base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
			{
				this.fuelAndOilTutorialFuelFinished = true;
			}
			if (base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix > 0)
			{
				this.fuelAndOilTutorialOilFinished = true;
			}
			if (base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges == base.GetComponent<UncleLogicC>().carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges)
			{
				this.fuelAndOilTutorialWaterFinished = true;
			}
			if (this.fuelAndOilTutorialWaterFinished && this.fuelAndOilTutorialOilFinished && this.fuelAndOilTutorialFuelFinished)
			{
				yield break;
			}
		}
		this.textFinished = false;
		base.StopCoroutine("StopInputRestrict");
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_16", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_16b", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.fuelAndOilTutorialStart = true;
		yield break;
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x00109078 File Offset: 0x00107478
	private IEnumerator DropHolding()
	{
		if (this.hasGivenTutorial)
		{
			yield break;
		}
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("FuelAndOilTutorialOilHeld");
		base.StopCoroutine("FuelAndOilTutorialFuelHeld");
		base.StopCoroutine("FuelAndOilTutorialWaterHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropOnly = true;
		this.inputRestrictDropItem = true;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_24", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnim();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		this.notDropped = true;
		while (this.notDropped)
		{
			yield return new WaitForEndOfFrame();
		}
		base.StartCoroutine("StopInputRestrict");
		base.StartCoroutine("StopInputRestrictDropOnly");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
		yield return new WaitForSeconds(0.4f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropOnly = false;
		this.inputRestrictDropItem = false;
		MonoBehaviour.print("no more restrict drop");
		this.dropDialogue++;
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x00109094 File Offset: 0x00107494
	private IEnumerator StillNeedToRefuel()
	{
		this.reminderToRefuelTime = 0f;
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		if (!this.reminderToRefuelRunning)
		{
			yield return new WaitForSeconds(0.2f);
			this.reminderToRefuelRunning = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_23", "Speech");
			bool needsComma = false;
			if (!this.fuelAndOilTutorialFuelFinished)
			{
				DialogueStuffsC component = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component.word += " ";
				DialogueStuffsC component2 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component2.word += Language.Get("un_sc1_dia4_23a", "Speech");
				needsComma = true;
			}
			if (!this.fuelAndOilTutorialOilFinished)
			{
				DialogueStuffsC component3 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component3.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component4 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component4.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component5 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component5.word += Language.Get("un_sc1_dia4_23b", "Speech");
			}
			if (!this.fuelAndOilTutorialWaterFinished)
			{
				DialogueStuffsC component6 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component6.word += " ";
				if (needsComma)
				{
					DialogueStuffsC component7 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
					component7.word += ",";
				}
				needsComma = true;
				DialogueStuffsC component8 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
				component8.word += Language.Get("un_sc1_dia4_23c", "Speech");
			}
			DialogueStuffsC component9 = this.dialogueHolder.GetComponent<DialogueStuffsC>();
			component9.word += ".";
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			this.reminderToRefuelRunning = false;
		}
		yield break;
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x001090B0 File Offset: 0x001074B0
	private IEnumerator FuelAndOilTutorialWaterHeld()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_22", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		yield return new WaitWhile(() => !this.textFinished);
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_22b", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.fuelAndOilTutorialWaterFinished = true;
		yield break;
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x001090CC File Offset: 0x001074CC
	private IEnumerator FuelAndOilTutorialFuelHeld()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_17", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_17b", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.fuelAndOilTutorialFuelFinished = true;
		yield break;
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x001090E8 File Offset: 0x001074E8
	private IEnumerator TryHoldingDownFuel()
	{
		if (base.GetComponent<UncleLogicC>().tutorialBool)
		{
			yield break;
		}
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 3.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_18", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x00109104 File Offset: 0x00107504
	private IEnumerator FuelAndOilTutorialOilHeld()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_19", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		MonoBehaviour.print("pries pirma yield");
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_19b", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_19c", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_19d", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.fuelAndOilTutorialOilFinished = true;
		yield break;
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x00109120 File Offset: 0x00107520
	private IEnumerator FuelTutorialComplete()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("FuelAndOilTutorialOilHeld");
		base.StopCoroutine("FuelAndOilTutorialWaterHeld");
		base.StopCoroutine("FuelAndOilTutorialStart");
		base.StopCoroutine("FuelAndOilTutorialFuelHeld");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 3.0);
		this.tyreTrigger.SetActive(true);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_20", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.StartCoroutine("TyreTutorialStart");
		yield break;
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x0010913C File Offset: 0x0010753C
	private IEnumerator TyreTutorialStart()
	{
		this.rightJack.active = false;
		this.textFinished = false;
		this.rightTyre.transform.localPosition -= Vector3.up * 10f;
		base.StopCoroutine("StopInputRestrict");
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_21", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.gameObject.GetComponent<AIPath>().target = this.nodeTargets[1];
		this.tyreTutorialStart = true;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_01b", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.waitingForPlayerToGetCarJack = true;
		yield break;
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x00109158 File Offset: 0x00107558
	private IEnumerator StillNeedToGetCarJack()
	{
		this.reminderToGetCarJackTimer = 0f;
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		if (!this.reminderToGetCarJackRunning)
		{
			yield return new WaitForSeconds(0.2f);
			this.reminderToGetCarJackRunning = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_02", "Speech");
			DialogueStuffsC component = this.dialogueHolder.GetComponent<DialogueStuffsC>();
			component.word += ".";
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			this.reminderToGetCarJackRunning = false;
		}
		yield break;
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x00109174 File Offset: 0x00107574
	private IEnumerator PlaceJackUnderCar()
	{
		base.StopCoroutine("StopInputRestrict");
		this.waitingForPlayerToGetCarJack = false;
		base.StopCoroutine("StillNeedToGetCarJack");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_03", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		yield break;
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x00109190 File Offset: 0x00107590
	private IEnumerator JackPlacedUnderCar()
	{
		if (this.tyreTutorialStart)
		{
			base.StopCoroutine("StopInputRestrict");
			this.waitingForPlayerToGetCarJack = false;
			base.StopCoroutine("StillNeedToGetCarJack");
			base.StopCoroutine("PlaceJackUnderCar");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_04", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
		}
		yield break;
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x001091AC File Offset: 0x001075AC
	private IEnumerator TurnJackHandleUp()
	{
		if (this.tyreTutorialStart)
		{
			base.StopCoroutine("StopInputRestrict");
			base.StopCoroutine("StillNeedToGetCarJack");
			base.StopCoroutine("JackPlacedUnderCar");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropOnly = true;
			this.inputRestrictDropItem = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_05", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnim();
			this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
			while (this.notDropped)
			{
				if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) || Input.GetButtonDown("Drop"))
				{
					this.notDropped = false;
				}
				yield return new WaitForEndOfFrame();
			}
			base.StartCoroutine("StopInputRestrict");
			base.StartCoroutine("StopInputRestrictDropOnly");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.waitingForPlayerToGetTyres = true;
		}
		yield break;
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x001091C8 File Offset: 0x001075C8
	private IEnumerator StillNeedToGetTyres()
	{
		this.reminderToGetTyresTimer = 0f;
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		if (!this.reminderToGetTyresRunning)
		{
			yield return new WaitForSeconds(0.2f);
			this.reminderToGetTyresRunning = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_06", "Speech");
			DialogueStuffsC component = this.dialogueHolder.GetComponent<DialogueStuffsC>();
			component.word += ".";
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			this.reminderToGetTyresRunning = false;
		}
		yield break;
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x001091E4 File Offset: 0x001075E4
	private IEnumerator PlaceTyreOntoAxle()
	{
		if (this.tyreTutorialStart)
		{
			this.waitingForPlayerToGetTyres = false;
			base.StopCoroutine("StopInputRestrict");
			base.StopCoroutine("StillNeedToGetTyres");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_07", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
		}
		yield break;
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x00109200 File Offset: 0x00107600
	private IEnumerator TyreFittedTutorial()
	{
		if (this.tyreTutorialStart && !this.hasTyreFittedOnceBefore)
		{
			base.StopCoroutine("StopInputRestrict");
			base.StopCoroutine("PlaceTyreOntoAxle");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_08", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
			this.hasTyreFittedOnceBefore = true;
		}
		yield break;
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x0010921C File Offset: 0x0010761C
	private IEnumerator WheelTightened()
	{
		if (this.tyreTutorialStart)
		{
			base.StopCoroutine("StopInputRestrict");
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_09", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
		}
		yield break;
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x00109238 File Offset: 0x00107638
	private IEnumerator NowFitTheOtherTyres()
	{
		if (this.tyreTutorialStart)
		{
			base.StopCoroutine("StopInputRestrict");
			this.textFinished = false;
			this.nowFitTheOtherTyrePlayed = true;
			this.tyreTutorialFinished = true;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia5_10", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.4f);
		}
		this.rightJack.active = true;
		this.rightJack.transform.localPosition = new Vector3(1.020173f, -5.360926f, 2.848676f);
		this.rightJack.transform.localEulerAngles = new Vector3(-5.006742E-06f, 88.29626f, 180f);
		yield break;
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x00109254 File Offset: 0x00107654
	private IEnumerator WashCarSuggestion()
	{
		this.washCarSuggestionStarted = true;
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia6_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia6_02", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.gameObject.GetComponent<AIPath>().destination = this.nodeTargets[1].position;
		base.StartCoroutine("DebugCarEnter");
		yield break;
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x00109270 File Offset: 0x00107670
	private IEnumerator EngineTutorialRepeat()
	{
		this.engineTutorialRepeatTime = 0f;
		if (!this.engineTutorialRepeatRunning)
		{
			base.StopCoroutine("StopInputRestrict");
			this.engineTutorialRepeatRunning = true;
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia4_02b", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		}
		yield break;
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x0010928C File Offset: 0x0010768C
	private IEnumerator GiveItem1()
	{
		yield return new WaitForSeconds(1.2f);
		this.holdingItems[0].SetActive(true);
		yield break;
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x001092A8 File Offset: 0x001076A8
	private IEnumerator GivePlayerMoney()
	{
		yield return new WaitForSeconds(1.2f);
		GameObject moneyX = UnityEngine.Object.Instantiate<GameObject>(this.money, this.holdingItems[3].transform.position, Quaternion.identity);
		moneyX.GetComponent<LooseCashC>().particles.GetComponent<ParticleSystem>().Stop();
		moneyX.GetComponent<AudioSource>().Stop();
		moneyX.GetComponent<LooseCashC>().uncle = base.gameObject;
		moneyX.transform.parent = this.holdingItems[3].transform;
		moneyX.transform.localPosition = Vector3.zero;
		moneyX.transform.localEulerAngles = Vector3.zero;
		moneyX.GetComponent<LooseCashC>().cashValue = 60;
		yield return new WaitForSeconds(0.3f);
		base.StartCoroutine(moneyX.GetComponent<LooseCashC>().PickUp());
		yield break;
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x001092C4 File Offset: 0x001076C4
	private IEnumerator CarEnter()
	{
		yield return new WaitForSeconds(1f);
		if (this.hasGivenTutorial)
		{
			if (!base.GetComponent<UncleLogicC>().uncleAtHome)
			{
				base.StartCoroutine("CarEnter2");
			}
			yield break;
		}
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_01", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_02", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		base.GetComponent<Animator>().SetBool("giveItem", true);
		base.StartCoroutine("GiveItem1");
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000BA8 RID: 2984 RVA: 0x001092E0 File Offset: 0x001076E0
	private IEnumerator ManualPickedUp()
	{
		if (this.hasGivenTutorial)
		{
			yield break;
		}
		if (this.hasGivenManualTutorial)
		{
			yield break;
		}
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_03", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_04", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		this.hasGivenManualTutorial = true;
		yield break;
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x001092FC File Offset: 0x001076FC
	private IEnumerator ManualPageTurned()
	{
		if (this.hasGivenTutorial)
		{
			yield break;
		}
		this.mainManualPageTurnTutFinished = true;
		yield return new WaitForSeconds(0.2f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_05", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnim();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		yield return new WaitWhile(() => !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) && !Input.GetButtonDown("Drop"));
		base.StartCoroutine("StopInputRestrict");
		base.StartCoroutine("StopInputRestrictDropOnly");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.StartCoroutine("GiveMap");
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x00109318 File Offset: 0x00107718
	private IEnumerator CarEnter2()
	{
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		if (this.keyHolder.transform.childCount > 0)
		{
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia8_03", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
		}
		if (base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth <= 60f)
		{
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_moneygive_01", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<Animator>().SetBool("talking", true);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForSeconds(0.2f);
			this.textFinished = false;
			base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_moneygive_02", "Speech");
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<Animator>().SetBool("talking", true);
			base.GetComponent<Animator>().SetBool("giveItem", true);
			base.StartCoroutine(this.GivePlayerMoney());
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitForEndOfFrame();
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			yield return new WaitForEndOfFrame();
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		}
		yield break;
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x00109333 File Offset: 0x00107733
	public void StopRemindingPlayerOfMap()
	{
		base.StopCoroutine("RemindPlayerOfMap");
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x00109340 File Offset: 0x00107740
	private IEnumerator RemindPlayerOfMap()
	{
		if (base.GetComponent<UncleLogicC>().uncleAtHome)
		{
			yield break;
		}
		if (base.GetComponent<UncleLogicC>().director.GetComponent<RouteGeneratorC>().routeChosen != 0)
		{
			yield break;
		}
		if (base.GetComponent<UncleLogicC>().director.GetComponent<RouteGeneratorC>().routeLevel > 0 && base.GetComponent<UncleLogicC>().debugStopUncleWorking)
		{
			yield break;
		}
		base.StopCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		yield return new WaitForSeconds(0.2f);
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "Map")
		{
			yield break;
		}
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1_dia8_04", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		yield break;
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x0010935C File Offset: 0x0010775C
	private IEnumerator GiveItem2()
	{
		yield return new WaitForSeconds(1.2f);
		this.holdingItems[1].SetActive(true);
		yield break;
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x00109378 File Offset: 0x00107778
	private IEnumerator GiveMap()
	{
		base.StopCoroutine("StopInputRestrict");
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_06", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.GetComponent<Animator>().SetBool("giveItem", true);
		base.StartCoroutine("GiveItem2");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x00109394 File Offset: 0x00107794
	private IEnumerator MapPickedUpTutorial()
	{
		base.GetComponent<Animator>().SetBool("giveItem", false);
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_07", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_08", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_09", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield break;
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x001093B0 File Offset: 0x001077B0
	private IEnumerator RouteSelectedTutorial()
	{
		if (this.hasGivenRouteSelectedTutorial || this.hasGivenTutorial)
		{
			yield break;
		}
		base.StopCoroutine("MapPickedUpTutorial");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.hasGivenRouteSelectedTutorial = true;
		yield return new WaitForSeconds(1f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_14", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_10", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x001093CC File Offset: 0x001077CC
	private IEnumerator MapPageTurnTutorial()
	{
		this.hasGivenMapPageTurnTutorial = true;
		if (this.hasGivenTutorial)
		{
			yield break;
		}
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_13", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnim();
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		yield return new WaitWhile(() => !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) && !Input.GetButtonDown("Drop"));
		base.StartCoroutine("StopInputRestrict");
		base.StartCoroutine("StopInputRestrictDropOnly");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().DropAnimStop();
		yield return new WaitForSeconds(0.4f);
		base.StartCoroutine("GiveItem3");
		base.StartCoroutine("GiveKey");
		base.GetComponent<Animator>().SetBool("giveItem", true);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x001093E8 File Offset: 0x001077E8
	private IEnumerator GiveItem3()
	{
		yield return new WaitForSeconds(1.2f);
		this.holdingItems[2].SetActive(true);
		yield break;
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x00109404 File Offset: 0x00107804
	private IEnumerator GiveKey()
	{
		base.StopCoroutine("StopInputRestrict");
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_11", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		base.StartCoroutine("GiveItem3");
		base.GetComponent<Animator>().SetBool("giveItem", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.textFinished = false;
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOn(base.GetComponent<UncleLogicC>().mouth, this.characterName);
		base.GetComponent<UncleLogicC>().AudioSpeech();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = Language.Get("un_sc1carintr_dia_12", "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
		base.GetComponent<Animator>().SetBool("talking", true);
		while (!this.textFinished)
		{
			yield return new WaitForEndOfFrame();
		}
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
		yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
		yield return new WaitForEndOfFrame();
		yield return new WaitWhile(() => this.inputRestrictDropItem);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine("StopInputRestrict");
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		yield return new WaitForSeconds(0.2f);
		this.hasGivenTutorial = true;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x00109420 File Offset: 0x00107820
	public void DebugCarEnter()
	{
		base.gameObject.GetComponent<AIPath>().destination = this.nodeTargets[1].position;
		this.dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		base.gameObject.GetComponent<UncleLogicC>().readyToBoard = true;
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x00109470 File Offset: 0x00107870
	public IEnumerator ClearDialogue(float delay)
	{
		this.dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		this.dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().text = string.Empty;
		yield return new WaitForSeconds(delay);
		this.textFinished = false;
		this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		base.GetComponent<UncleLogicC>().director.GetComponent<DirectorC>().BubbleOff();
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StopTypeText();
		this.dialogueHolder.GetComponent<DialogueStuffsC>().word = string.Empty;
		yield break;
	}

	// Token: 0x04000FD7 RID: 4055
	public GameObject rightJack;

	// Token: 0x04000FD8 RID: 4056
	private GameObject _camera;

	// Token: 0x04000FD9 RID: 4057
	public bool forceUncleLeave = true;

	// Token: 0x04000FDA RID: 4058
	public Transform uncleStartPosition;

	// Token: 0x04000FDB RID: 4059
	public GameObject money;

	// Token: 0x04000FDC RID: 4060
	public GameObject keyHolder;

	// Token: 0x04000FDD RID: 4061
	public int currentState;

	// Token: 0x04000FDE RID: 4062
	public GameObject dialogueHolder;

	// Token: 0x04000FDF RID: 4063
	public bool hasGivenTutorial = true;

	// Token: 0x04000FE0 RID: 4064
	public bool debugEnter;

	// Token: 0x04000FE1 RID: 4065
	public Transform[] nodeTargets = new Transform[0];

	// Token: 0x04000FE2 RID: 4066
	public GameObject[] holdingItems = new GameObject[0];

	// Token: 0x04000FE3 RID: 4067
	public GameObject sparePartsCabinetTrigger;

	// Token: 0x04000FE4 RID: 4068
	public GameObject fuelCabinetTrigger;

	// Token: 0x04000FE5 RID: 4069
	public GameObject tyreTrigger;

	// Token: 0x04000FE6 RID: 4070
	public bool textFinished;

	// Token: 0x04000FE7 RID: 4071
	public bool doorTutorialStarted;

	// Token: 0x04000FE8 RID: 4072
	public bool doorTutorialCompleted;

	// Token: 0x04000FE9 RID: 4073
	public bool bonnetTutorialStart;

	// Token: 0x04000FEA RID: 4074
	public bool hasGivenCarDoorText;

	// Token: 0x04000FEB RID: 4075
	public bool bonnetTutorialFinished;

	// Token: 0x04000FEC RID: 4076
	public bool bonnetLatchRepeatRunning;

	// Token: 0x04000FED RID: 4077
	public bool startBonnetLatchRepeat;

	// Token: 0x04000FEE RID: 4078
	public float bonnetLatchRepeatTime;

	// Token: 0x04000FEF RID: 4079
	public bool engineTutorialStart;

	// Token: 0x04000FF0 RID: 4080
	public bool engineTutorialFinished;

	// Token: 0x04000FF1 RID: 4081
	public bool engineTutorialRepeatRunning;

	// Token: 0x04000FF2 RID: 4082
	public bool startEngineTutorialRepeat;

	// Token: 0x04000FF3 RID: 4083
	public float engineTutorialRepeatTime;

	// Token: 0x04000FF4 RID: 4084
	public bool reminderToFitOtherComponents;

	// Token: 0x04000FF5 RID: 4085
	public bool reminderToFitOtherComponentsRepeatRunning;

	// Token: 0x04000FF6 RID: 4086
	public float reminderToFitOtherComponentsTime;

	// Token: 0x04000FF7 RID: 4087
	public bool bonnetLatchTutorialFinished;

	// Token: 0x04000FF8 RID: 4088
	public bool engineTutorialCarburettorStarted;

	// Token: 0x04000FF9 RID: 4089
	public bool engineTutorialCarburettorFinished;

	// Token: 0x04000FFA RID: 4090
	public bool carburettorFitted;

	// Token: 0x04000FFB RID: 4091
	public bool engineTutorialEngineBlockStarted;

	// Token: 0x04000FFC RID: 4092
	public bool engineTutorialEngineBlockFinished;

	// Token: 0x04000FFD RID: 4093
	public bool engineBlockFitted;

	// Token: 0x04000FFE RID: 4094
	public bool engineTutorialIgnitionCoilStarted;

	// Token: 0x04000FFF RID: 4095
	public bool engineTutorialIgnitionCoilFinished;

	// Token: 0x04001000 RID: 4096
	public bool ignitionCoilFitted;

	// Token: 0x04001001 RID: 4097
	public bool engineTutorialAirFilterStarted;

	// Token: 0x04001002 RID: 4098
	public bool engineTutorialAirFilterFinished;

	// Token: 0x04001003 RID: 4099
	public bool airFilterFitted;

	// Token: 0x04001004 RID: 4100
	public bool engineTutorialFuelTankStarted;

	// Token: 0x04001005 RID: 4101
	public bool engineTutorialFuelTankFinished;

	// Token: 0x04001006 RID: 4102
	public bool fuelTankFitted;

	// Token: 0x04001007 RID: 4103
	public bool engineTutorialWaterTankStarted;

	// Token: 0x04001008 RID: 4104
	public bool engineTutorialWaterTankFinished;

	// Token: 0x04001009 RID: 4105
	public bool waterTankFitted;

	// Token: 0x0400100A RID: 4106
	public bool engineTutorialBatteryStarted;

	// Token: 0x0400100B RID: 4107
	public bool engineTutorialBatteryFinished;

	// Token: 0x0400100C RID: 4108
	public bool batteryFitted;

	// Token: 0x0400100D RID: 4109
	public bool fuelAndOilTutorialStart;

	// Token: 0x0400100E RID: 4110
	public bool fuelAndOilTutorialFinished;

	// Token: 0x0400100F RID: 4111
	public bool fuelAndOilTutorialFuelStarted;

	// Token: 0x04001010 RID: 4112
	public bool fuelAndOilTutorialFuelFinished;

	// Token: 0x04001011 RID: 4113
	public bool fuelAndOilTutorialOilStarted;

	// Token: 0x04001012 RID: 4114
	public bool fuelAndOilTutorialOilFinished;

	// Token: 0x04001013 RID: 4115
	public bool fuelAndOilTutorialWaterStarted;

	// Token: 0x04001014 RID: 4116
	public bool fuelAndOilTutorialWaterFinished;

	// Token: 0x04001015 RID: 4117
	public bool reminderToRefuelRunning;

	// Token: 0x04001016 RID: 4118
	public float reminderToRefuelTime;

	// Token: 0x04001017 RID: 4119
	public int dropDialogue;

	// Token: 0x04001018 RID: 4120
	public bool tyreTutorialStart;

	// Token: 0x04001019 RID: 4121
	public bool tyreTutorialFinished;

	// Token: 0x0400101A RID: 4122
	public bool waitingForPlayerToGetCarJack;

	// Token: 0x0400101B RID: 4123
	public float reminderToGetCarJackTimer;

	// Token: 0x0400101C RID: 4124
	public bool reminderToGetCarJackRunning;

	// Token: 0x0400101D RID: 4125
	public bool waitingForPlayerToGetTyres;

	// Token: 0x0400101E RID: 4126
	public float reminderToGetTyresTimer;

	// Token: 0x0400101F RID: 4127
	public bool reminderToGetTyresRunning;

	// Token: 0x04001020 RID: 4128
	public bool nowFitTheOtherTyrePlayed;

	// Token: 0x04001021 RID: 4129
	public bool hasTyreFittedOnceBefore;

	// Token: 0x04001022 RID: 4130
	public bool washCarSuggestionStarted;

	// Token: 0x04001023 RID: 4131
	public bool inputRestrictDropItem;

	// Token: 0x04001024 RID: 4132
	public bool mainManualPageTurnTutFinished;

	// Token: 0x04001025 RID: 4133
	public bool hasGivenRouteSelectedTutorial;

	// Token: 0x04001026 RID: 4134
	public bool hasGivenMapPageTurnTutorial;

	// Token: 0x04001027 RID: 4135
	private bool hasGivenManualTutorial;

	// Token: 0x04001028 RID: 4136
	private bool standardUncleIntroductionFinished;

	// Token: 0x04001029 RID: 4137
	private bool hasGivenTutorialChecked;

	// Token: 0x0400102A RID: 4138
	private bool runningDropItemDoorTutorial;

	// Token: 0x0400102B RID: 4139
	private bool allowDoorTutorialDropItem;

	// Token: 0x0400102C RID: 4140
	private bool uncleJourneyDeclined;

	// Token: 0x0400102D RID: 4141
	private bool bringCarCloserRunning;

	// Token: 0x0400102E RID: 4142
	public string characterName = "ui_name_01";

	// Token: 0x0400102F RID: 4143
	public float distanceFromCarDoor;

	// Token: 0x04001030 RID: 4144
	public bool notDropped = true;

	// Token: 0x04001031 RID: 4145
	public GameObject leftTyre;

	// Token: 0x04001032 RID: 4146
	public GameObject rightTyre;
}
