using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

// Token: 0x02000127 RID: 295
public class UncleLogicC : MonoBehaviour
{
	// Token: 0x06000BB7 RID: 2999 RVA: 0x0011D330 File Offset: 0x0011B730
	private void Reset()
	{
		UncleLogic component = base.GetComponent<UncleLogic>();
		this.debugStopUncleWorking = component.debugStopUncleWorking;
		this.passport = component.passport;
		this.suitcase = component.suitcase;
		this.uncleRightHand = component.uncleRightHand;
		this.restrictTalk = component.restrictTalk;
		this.uncleAtHome = component.uncleAtHome;
		this.uncleGoneForever = component.uncleGoneForever;
		this.moveSpeed = component.moveSpeed;
		this.curVel = component.curVel;
		this.lastVel = component.lastVel;
		this.myBounds = component.myBounds;
		this.director = component.director;
		this.carLogic = component.carLogic;
		this.player = component.player;
		this.motel = component.motel;
		this.uncleDoorTrigger = component.uncleDoorTrigger;
		this.uncleRayChecker = component.uncleRayChecker;
		this.mouth = component.mouth;
		this.distanceCheck = component.distanceCheck;
		this.dialogueHolder = component.dialogueHolder;
		this.conversationID = component.conversationID;
		this.uncleCarTransform = component.uncleCarTransform;
		this.relayNodeTransform = component.relayNodeTransform;
		this.bonnetNode = component.bonnetNode;
		this.bootNode = component.bootNode;
		this.stayAtHomeNode = component.stayAtHomeNode;
		this.readyToBoard = component.readyToBoard;
		this.firstTimeBoarding = component.firstTimeBoarding;
		this.distanceToCarEntrance = component.distanceToCarEntrance;
		this.distanceToRelayNode = component.distanceToRelayNode;
		this.distanceToBonnetNode = component.distanceToBonnetNode;
		this.walkingTowardsDoor = component.walkingTowardsDoor;
		this.carDoorOpen = component.carDoorOpen;
		this.enterCarDoorOnce = component.enterCarDoorOnce;
		this.isSat = component.isSat;
		this.carLookAt = component.carLookAt;
		this.radioVolume = component.radioVolume;
		this.consecutiveDoorFails = component.consecutiveDoorFails;
		this.hasComplainedAboutHazards = component.hasComplainedAboutHazards;
		this.hasComplainedAboutHeadlights = component.hasComplainedAboutHeadlights;
		this.hazardComplaintCounter = component.hazardComplaintCounter;
		this.headLightComplaintCounter = component.headLightComplaintCounter;
		this.headlightSpamStopper = component.headlightSpamStopper;
		this.wipersOffComplaintCounter = component.wipersOffComplaintCounter;
		this.hasComplainedAboutWipersOff = component.hasComplainedAboutWipersOff;
		this.hasComplainedAboutBonnet = component.hasComplainedAboutBonnet;
		this.hasComplainedAboutSpeed = component.hasComplainedAboutSpeed;
		this.speedingComplaintCounter = component.speedingComplaintCounter;
		this.sleepParticle = component.sleepParticle;
		component.speech.Copy(ref this.speech);
		this.routeDialogueLevel = component.routeDialogueLevel;
		this.isTalking = component.isTalking;
		this.textFinished = component.textFinished;
		this.textQueue = new List<string>(component.textQueue);
		this.currentConvoItem = component.currentConvoItem;
		this.interruptConvoItem = component.interruptConvoItem;
		this.dialogueConvoItem = component.dialogueConvoItem;
		this.speechStack = new List<string>(component.speechStack);
		this.inputRestrictDropItem = component.inputRestrictDropItem;
		this.interruptChecker = component.interruptChecker;
		this.dialogueChecker = component.dialogueChecker;
		this.canSpeak = component.canSpeak;
		this.interruptSpeechComplete = component.interruptSpeechComplete;
		this.dialogueSpeechComplete = component.dialogueSpeechComplete;
		this.uncleArrivedAtBonnet = component.uncleArrivedAtBonnet;
		this.hasGivenEngineRepairTutorial = component.hasGivenEngineRepairTutorial;
		this.engineRepairTutorialState = component.engineRepairTutorialState;
		this.itemsNeededToBeBought = new List<string>(component.itemsNeededToBeBought);
		this.itemsNeededToBeBoughtObjectNames = new List<string>(component.itemsNeededToBeBoughtObjectNames);
		this.gateClose = component.gateClose;
		this.atPetrolStation = component.atPetrolStation;
		this.isCloseToFuelPump = component.isCloseToFuelPump;
		this.fuelTutorialState = component.fuelTutorialState;
		this.gateObj = component.gateObj;
		this.gateAudio = component.gateAudio;
		this.withinRangeOfMotel = component.withinRangeOfMotel;
		this.motelDistanceCheck = component.motelDistanceCheck;
		this.hasSpokenWithinRangeOfMotel = component.hasSpokenWithinRangeOfMotel;
		this.hasSaidLetsCheckIn = component.hasSaidLetsCheckIn;
		this.isReadyToTalkAboutBorder = component.isReadyToTalkAboutBorder;
		component.sprites.Copy(ref this.sprites);
		this.spriteTarget = component.spriteTarget;
		this.spriteTimerCheck = component.spriteTimerCheck;
		this.tutorialBool = component.tutorialBool;
		this.characterName = component.characterName;
		component.shoeAudio.Copy(ref this.shoeAudio);
		this.dialogueSelected = component.dialogueSelected;
		this.carNavBlocker = component.carNavBlocker;
		component.startingHomeItems.Copy(ref this.startingHomeItems);
		component.enabled = false;
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0011D7A0 File Offset: 0x0011BBA0
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.player = GameObject.FindWithTag("Player");
		this.director = GameObject.FindWithTag("Director");
		if (ES3.Exists("uncleTutorialCompleted"))
		{
			this.tutorialBool = ES3.LoadBool("uncleTutorialCompleted");
		}
		if (!this.tutorialBool)
		{
			for (int i = 0; i < this.startingHomeItems.Length; i++)
			{
				this.startingHomeItems[i].SetActive(false);
			}
		}
		this.dialogueSelected = UnityEngine.Random.Range(0, 3);
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0011D83C File Offset: 0x0011BC3C
	private IEnumerator LoadDetails()
	{
		yield return new WaitForSeconds(3.5f);
		if (this.uncleGoneForever)
		{
			this.UncleGoneForeverLogic();
		}
		yield break;
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x0011D857 File Offset: 0x0011BC57
	public void HeadLookOn()
	{
		this.headLookOn = true;
		base.SendMessage("HeadLookControllerOn");
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x0011D86B File Offset: 0x0011BC6B
	public void HeadLookOff()
	{
		this.headLookOn = false;
		base.SendMessage("HeadLookControllerOff");
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x0011D880 File Offset: 0x0011BC80
	private void Update()
	{
		if (this.uncleAtHome && this.tutorialBool && !this.debugStopUncleWorking && !this.uncleGoneForever)
		{
			if (!this.spriteTarget.activeInHierarchy && base.GetComponent<Scene1_LogicC>().distanceFromCarDoor < 20f)
			{
				this.spriteTarget.SetActive(true);
			}
			this.spriteTarget.transform.LookAt(this._camera.transform.position, -Vector3.up);
			if (this.spriteTimer > this.spriteTimerCheck)
			{
				if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[0])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[1];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[1])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
				}
				this.spriteTimer = 0f;
			}
			this.spriteTimer += Time.deltaTime;
		}
		else if (this.spriteTarget.activeInHierarchy)
		{
			this.spriteTarget.SetActive(false);
		}
		if (this.isSat && this.headLookOn)
		{
			this.HeadLookOff();
		}
		float num = Vector3.Distance(base.transform.position, this.player.transform.position);
		if ((double)num < 15.0 && this.engineRepairTutorialState == 11 && this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1.transform.name == "EngineRepairKit")
		{
			base.StartCoroutine("EngineRepairTutorialPart6");
		}
		if (num / (float)((!this.isReadyToTalkAboutBorder) ? 1 : 3) < this.distanceCheck)
		{
			if (this.isReadyToTalkAboutBorder)
			{
				base.StartCoroutine("LetsGoBorderCross");
				this.isReadyToTalkAboutBorder = false;
			}
			if (!this.firstTimeBoarding || !this.isSat || this.player.GetComponent<RigidbodyControllerC>().isSat)
			{
			}
		}
		if (this.motel != null)
		{
			float num2 = Vector3.Distance(base.transform.position, this.motel.transform.position);
			if (!this.withinRangeOfMotel && num2 < this.motelDistanceCheck)
			{
				this.withinRangeOfMotel = true;
				base.StartCoroutine("WithinRangeOfMotel");
			}
			else if (this.withinRangeOfMotel && num2 > this.motelDistanceCheck)
			{
				this.withinRangeOfMotel = false;
			}
		}
		CharacterController component = base.GetComponent<CharacterController>();
		Vector3 vector = component.velocity;
		Vector3 a = base.transform.position - this.lastLocation;
		this.lastLocation = base.transform.position;
		vector = a * 8f;
		this.moveSpeed = vector.magnitude;
		base.GetComponent<Animator>().SetFloat("walkSpeed", vector.magnitude);
		if ((double)vector.magnitude > 0.1 && base.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Uncle_Walking"))
		{
			this.shoeAudioTimer += Time.deltaTime;
			if ((double)this.shoeAudioTimer > 0.4)
			{
				int num3 = UnityEngine.Random.Range(0, this.shoeAudio.Length);
				base.GetComponent<AudioSource>().PlayOneShot(this.shoeAudio[num3], 1f);
				this.shoeAudioTimer = 0f;
			}
		}
		this.distanceToCarEntrance = Vector3.Distance(base.transform.position, this.uncleCarTransform.position);
		this.distanceToRelayNode = Vector3.Distance(base.transform.position, this.relayNodeTransform.position);
		this.distanceToBonnetNode = Vector3.Distance(base.transform.position, this.bonnetNode.position);
		if (!this.isSat)
		{
			if (this.lastPosition != base.gameObject.transform.position && this.headLookOn)
			{
				this.HeadLookOff();
			}
			else if ((double)num < 10.0 && this.lastPosition == base.gameObject.transform.position && !this.headLookOn)
			{
				this.HeadLookOn();
			}
			if ((double)num > 10.0 && this.headLookOn)
			{
				this.HeadLookOff();
			}
			else if (this.lastPosition == base.gameObject.transform.position && (double)num <= 10.0 && !this.headLookOn)
			{
				this.HeadLookOn();
			}
			this.lastPosition = base.gameObject.transform.position;
		}
		if ((double)this.distanceToBonnetNode <= 0.45 && base.GetComponent<AIPath>().target == this.bonnetNode)
		{
			this.uncleArrivedAtBonnet = true;
			base.gameObject.GetComponent<AIPath>().target = null;
			base.gameObject.GetComponent<Animator>().SetFloat("walkSpeed", 0f);
		}
		if (this.readyToBoard)
		{
			if (this.walkingTowardsDoor && (double)this.distanceToRelayNode <= 0.5)
			{
				base.GetComponent<AIPath>().target = this.uncleCarTransform;
			}
			if ((double)this.distanceToCarEntrance >= 0.5 && !this.isSat)
			{
				if (!this.walkingTowardsDoor)
				{
					base.StartCoroutine("WalkTowardsCarDoor");
					this.walkingTowardsDoor = true;
				}
				return;
			}
			base.GetComponent<Animator>().SetFloat("walkSpeed", 0f);
			if (!this.uncleDoorTrigger.GetComponent<DoorLogicC>().open && this.uncleDoorTrigger.activeInHierarchy)
			{
				this.OpenCarDoor();
			}
			if (this.carDoorOpen && !this.isSat && !this.hasSaidLetsCheckIn)
			{
				base.StartCoroutine(this.UncleEnterCar());
			}
		}
		this.curVel = this.moveSpeed;
		if (this.curVel == this.lastVel)
		{
			base.gameObject.GetComponent<Animator>().SetFloat("walkSpeed", 0f);
		}
		this.lastVel = this.curVel;
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x0011DF5C File Offset: 0x0011C35C
	public void OpenCarDoor()
	{
		this.uncleDoorTrigger.GetComponent<DoorLogicC>().isBroken = false;
		this.uncleDoorTrigger.GetComponent<DoorLogicC>().open = false;
		this.uncleDoorTrigger.SendMessage("Trigger");
		this.uncleDoorTrigger.GetComponent<BoxCollider>().enabled = false;
		this.carDoorOpen = true;
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x0011DFB3 File Offset: 0x0011C3B3
	public void WalkTowardsCarDoor()
	{
		this.carNavBlocker.SetActive(true);
		AstarPath.active.Scan(null);
		this.carNavBlocker.SetActive(false);
		base.GetComponent<AIPath>().target = this.relayNodeTransform;
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0011DFEC File Offset: 0x0011C3EC
	public IEnumerator UncleEnterCar()
	{
		this.readyToBoard = false;
		this.suitcase.GetComponent<SuitcaseRelayC>()._lock.GetComponent<OpenBriefcaseLogicC>().StartCoroutine("CloseBreifcase");
		this.sleepParticle.GetComponent<ParticleSystem>().Stop();
		this.carLogic.GetComponent<CarLogicC>().preventHandBrake = false;
		base.GetComponent<AIPath>().target = null;
		base.GetComponent<AIPath>().canMove = false;
		base.gameObject.GetComponent<CharacterController>().enabled = false;
		base.transform.parent = this.uncleCarTransform;
		base.transform.localEulerAngles = Vector3.zero;
		base.transform.localPosition = Vector3.zero;
		base.GetComponent<Animator>().SetBool("enterCar", true);
		base.GetComponent<Animator>().SetBool("exitCar", false);
		this.isSat = true;
		this.uncleDoorTrigger.GetComponent<DoorLogicC>().isBroken = false;
		this.uncleDoorTrigger.GetComponent<DoorLogicC>().open = false;
		this.uncleDoorTrigger.SendMessage("Trigger");
		this.uncleDoorTrigger.GetComponent<BoxCollider>().enabled = false;
		if (this.firstTimeBoarding && this.player.GetComponent<RigidbodyControllerC>().isSat)
		{
			this.firstTimeBoarding = false;
			base.gameObject.GetComponent<Scene1_LogicC>().StartCoroutine("CarEnter");
		}
		yield return new WaitForSeconds(0.2f);
		this.suitcase.transform.parent = this.carLogic.GetComponent<CarLogicC>().suitcaseTransform;
		this.suitcase.transform.localPosition = Vector3.zero;
		this.suitcase.transform.localEulerAngles = Vector3.zero;
		yield return new WaitForSeconds(3.8f);
		this.uncleDoorTrigger.SendMessage("Trigger");
		if (this.uncleDoorTrigger.GetComponent<DoorLogicC>().open)
		{
			this.uncleDoorTrigger.GetComponent<DoorLogicC>().isBroken = false;
			this.uncleDoorTrigger.GetComponent<DoorLogicC>().open = true;
			this.uncleDoorTrigger.SendMessage("Trigger");
			this.carDoorOpen = false;
			yield return new WaitForEndOfFrame();
			this.uncleDoorTrigger.GetComponent<DoorLogicC>().isBroken = true;
			this.uncleDoorTrigger.GetComponent<BoxCollider>().enabled = true;
		}
		yield break;
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x0011E008 File Offset: 0x0011C408
	private IEnumerator UncleExitCar()
	{
		this.readyToBoard = false;
		this.enterCarDoorOnce = false;
		base.transform.parent = null;
		yield return new WaitForSeconds(1f);
		this.isSat = false;
		base.GetComponent<AIPath>().canMove = true;
		yield break;
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x0011E023 File Offset: 0x0011C423
	public void CarDoorOpen()
	{
		this.carDoorOpen = true;
		base.GetComponent<Animator>().SetBool("doorOpened", true);
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x0011E03D File Offset: 0x0011C43D
	public void CarDoorClosed()
	{
		this.carDoorOpen = false;
		base.GetComponent<Animator>().SetBool("doorOpened", false);
	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x0011E058 File Offset: 0x0011C458
	public void OpenHomeGate()
	{
		if (this.gateObj == null)
		{
			return;
		}
		iTween.Stop(this.gateObj);
		this.gateObj.GetComponent<AudioSource>().Stop();
		this.gateObj.GetComponent<AudioSource>().clip = this.gateAudio;
		this.gateObj.GetComponent<AudioSource>().Play();
		iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
		{
			"z",
			-9,
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

	// Token: 0x06000BC4 RID: 3012 RVA: 0x0011E140 File Offset: 0x0011C540
	public IEnumerator ResumeTalkingFromList()
	{
		if (this.textQueue.Count > 0)
		{
			for (int i = 0; i < this.textQueue.Count; i++)
			{
				base.StopCoroutine(this.textQueue[i]);
			}
			if (this.textQueue != null && this.textQueue[0] != null && this.textQueue[0] != string.Empty && this.textQueue[0][0] == '$')
			{
				int dialogueCount = 0;
				int.TryParse(this.textQueue[0][1].ToString(), out dialogueCount);
				base.StartCoroutine(this.Dialogues(this.textQueue[0].Remove(0, 2), dialogueCount));
			}
			else if (this.textQueue[0] != string.Empty)
			{
				base.StartCoroutine(this.textQueue[0]);
			}
		}
		yield break;
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0011E15C File Offset: 0x0011C55C
	public void RemoveCurrentItemFromList()
	{
		for (int i = 0; i < this.textQueue.Count; i++)
		{
			if (this.textQueue[i] == this.dialogueConvoItem)
			{
				this.textQueue.RemoveAt(i);
			}
		}
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x0011E1B0 File Offset: 0x0011C5B0
	public void AddItemToStartOfQueue()
	{
		for (int i = 0; i < this.textQueue.Count; i++)
		{
			if (this.textQueue[i] == this.dialogueConvoItem)
			{
				return;
			}
		}
		this.textQueue.Insert(0, this.dialogueConvoItem);
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x0011E208 File Offset: 0x0011C608
	public void InterruptCheck()
	{
		if (this.restrictTalk || this.uncleAtHome)
		{
			this.canSpeak = false;
			return;
		}
		if (this.interruptConvoItem != string.Empty && this.interruptConvoItem == this.interruptChecker)
		{
			this.canSpeak = false;
			return;
		}
		if (this.dialogueConvoItem != string.Empty)
		{
			base.StopCoroutine("DialogueCheck");
			base.StopCoroutine("DialogueSpeech");
			base.StopCoroutine(this.dialogueConvoItem);
			this.AddItemToStartOfQueue();
			this.isTalking = false;
			this.dialogueConvoItem = string.Empty;
		}
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StopCoroutine(this.InterruptSpeech());
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StopTypeText();
		this.isTalking = true;
		this.interruptConvoItem = this.interruptChecker;
		this.interruptChecker = string.Empty;
		this.textFinished = false;
		this.canSpeak = true;
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x0011E324 File Offset: 0x0011C724
	public IEnumerator DialogueCheck()
	{
		if (this.restrictTalk || this.uncleAtHome)
		{
			this.canSpeak = false;
			this.AddItemToStartOfQueue();
			yield break;
		}
		if (this.dialogueConvoItem != string.Empty)
		{
			this.canSpeak = false;
			this.AddItemToStartOfQueue();
			yield break;
		}
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StopCoroutine("DialogueSpeech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().StopTypeText();
		this.isTalking = true;
		this.dialogueConvoItem = this.dialogueChecker;
		this.dialogueChecker = string.Empty;
		this.textFinished = false;
		this.canSpeak = true;
		yield break;
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x0011E340 File Offset: 0x0011C740
	public IEnumerator InterruptSpeech()
	{
		base.StopCoroutine("StopInputRestrict");
		this.interruptSpeechComplete = false;
		this.canSpeak = false;
		for (int i = 0; i < this.speechStack.Count; i++)
		{
			this.director.GetComponent<DirectorC>().BubbleOn(this.mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = this.speechStack[i];
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			yield return new WaitUntil(() => this.textFinished);
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
		}
		this.isTalking = false;
		this.interruptConvoItem = string.Empty;
		this.interruptChecker = string.Empty;
		this.interruptSpeechComplete = true;
		base.StartCoroutine("ResumeTalkingFromList");
		yield break;
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x0011E35C File Offset: 0x0011C75C
	public IEnumerator DialogueSpeech()
	{
		base.StopCoroutine("StopInputRestrict");
		this.dialogueSpeechComplete = false;
		this.canSpeak = false;
		for (int i = 0; i < this.speechStack.Count; i++)
		{
			this.textFinished = false;
			yield return new WaitForSeconds(0.2f);
			this.director.GetComponent<DirectorC>().BubbleOn(this.mouth, this.characterName);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().word = this.speechStack[i];
			this.dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			base.GetComponent<UncleLogicC>().AudioSpeech();
			base.GetComponent<Animator>().SetBool("talking", true);
			yield return new WaitUntil(() => this.textFinished);
			base.GetComponent<Animator>().SetBool("talking", false);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForEndOfFrame();
		}
		this.isTalking = false;
		this.dialogueSpeechComplete = true;
		base.StartCoroutine("RemoveCurrentItemFromList");
		this.dialogueConvoItem = string.Empty;
		base.StartCoroutine("ResumeTalkingFromList");
		yield break;
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x0011E377 File Offset: 0x0011C777
	public void TextFinished()
	{
		this.textFinished = true;
	}

	// Token: 0x06000BCC RID: 3020 RVA: 0x0011E380 File Offset: 0x0011C780
	private IEnumerator ClearDialogue(float delay)
	{
		yield return new WaitForSeconds(delay);
		this.dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		this.dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().text = string.Empty;
		yield return new WaitForSeconds(delay);
		this.director.GetComponent<DirectorC>().BubbleOff();
		base.GetComponent<Animator>().SetBool("talking", false);
		yield break;
	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x0011E3A2 File Offset: 0x0011C7A2
	public void ClearDialogueInstant()
	{
		base.GetComponent<Animator>().SetBool("talking", false);
		this.dialogueHolder.GetComponent<UILabel>().text = string.Empty;
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x0011E3CC File Offset: 0x0011C7CC
	public void AudioSpeech()
	{
		int num = UnityEngine.Random.Range(0, this.speech.Length - 1);
		this.sleepParticle.GetComponent<AudioSource>().PlayOneShot(this.speech[num], 1f);
	}

	// Token: 0x06000BCF RID: 3023 RVA: 0x0011E407 File Offset: 0x0011C807
	public void CarSpeech()
	{
		base.GetComponent<Animator>().SetBool("talking", true);
	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x0011E41A File Offset: 0x0011C81A
	public void StopInputRestrictStopper()
	{
		base.StopCoroutine("StopInputRestrict");
	}

	// Token: 0x06000BD1 RID: 3025 RVA: 0x0011E428 File Offset: 0x0011C828
	public IEnumerator StopInputRestrict()
	{
		yield return new WaitForSeconds(0.5f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000BD2 RID: 3026 RVA: 0x0011E444 File Offset: 0x0011C844
	public IEnumerator CarCollisionLight()
	{
		if (!this.uncleAtHome || !this.uncleGoneForever || !this.restrictTalk || !this.sleepParticle.GetComponent<ParticleSystem>().isPlaying || this.interruptChecker != "CarCollisionLight")
		{
			this.interruptChecker = "CarCollisionLight";
			this.InterruptCheck();
			yield return new WaitForSeconds(0.2f);
			if (this.canSpeak)
			{
				int num = UnityEngine.Random.Range(0, 3);
				this.speechStack.Clear();
				if (num == 0)
				{
					this.speechStack.Add(Language.Get("un_lghtcoll_01", "Speech"));
				}
				else if (num == 1)
				{
					this.speechStack.Add(Language.Get("un_lghtcoll_01", "Speech"));
				}
				else if (num == 2)
				{
					this.speechStack.Add(Language.Get("un_lghtcoll_01", "Speech"));
				}
				base.StartCoroutine("InterruptSpeech");
			}
		}
		yield break;
	}

	// Token: 0x06000BD3 RID: 3027 RVA: 0x0011E460 File Offset: 0x0011C860
	public IEnumerator CarCollisionMed()
	{
		if (!this.uncleAtHome || !this.uncleGoneForever || !this.restrictTalk || !this.sleepParticle.GetComponent<ParticleSystem>().isPlaying || this.interruptChecker != "CarCollisionMed")
		{
			this.interruptChecker = "CarCollisionMed";
			this.InterruptCheck();
			base.GetComponent<Animator>().Play("Medium Collision");
			yield return new WaitForSeconds(0.2f);
			if (this.canSpeak)
			{
				int num = UnityEngine.Random.Range(0, 3);
				this.speechStack.Clear();
				if (num == 0)
				{
					this.speechStack.Add(Language.Get("un_medcoll_01", "Speech"));
				}
				else if (num == 1)
				{
					this.speechStack.Add(Language.Get("un_medcoll_02", "Speech"));
				}
				else if (num == 2)
				{
					this.speechStack.Add(Language.Get("un_medcoll_03", "Speech"));
				}
				base.StartCoroutine("InterruptSpeech");
			}
		}
		yield break;
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x0011E47C File Offset: 0x0011C87C
	private IEnumerator CarCollisionHeavy()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 5f)
		{
			yield break;
		}
		if (!this.uncleAtHome || !this.uncleGoneForever || !this.restrictTalk || !this.sleepParticle.GetComponent<ParticleSystem>().isPlaying || this.interruptChecker != "CarCollisionHeavy")
		{
			this.interruptChecker = "CarCollisionHeavy";
			this.InterruptCheck();
			base.GetComponent<Animator>().Play("Medium Collision");
			yield return new WaitForSeconds(0.2f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				int num = UnityEngine.Random.Range(0, 2);
				if (num == 0)
				{
					this.speechStack.Add(Language.Get("un_hvycoll_01", "Speech"));
				}
				else if (num == 1)
				{
					this.speechStack.Add(Language.Get("un_hvycoll_02", "Speech"));
				}
				int num2 = UnityEngine.Random.Range(0, 2);
				if (num2 == 0)
				{
					this.speechStack.Add(Language.Get("un_hvycoll_01b", "Speech"));
				}
				else if (num2 == 1)
				{
					this.speechStack.Add(Language.Get("un_hvycoll_01b", "Speech"));
				}
				int num3 = UnityEngine.Random.Range(0, 2);
				if (num3 == 0)
				{
					this.speechStack.Add(Language.Get("un_hvycoll_01c", "Speech"));
				}
				else if (num3 == 1)
				{
					this.speechStack.Add(Language.Get("un_hvycoll_01c", "Speech"));
				}
				base.StartCoroutine("InterruptSpeech");
			}
		}
		yield break;
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x0011E498 File Offset: 0x0011C898
	public IEnumerator ComplainAboutBrokenDoor1()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 5f)
		{
			yield break;
		}
		this.interruptChecker = "ComplainAboutBrokenDoor1";
		base.StartCoroutine("InterruptCheck");
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_brkndoor_02", "Speech"));
			base.StartCoroutine("InterruptSpeech");
		}
		yield break;
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x0011E4B4 File Offset: 0x0011C8B4
	public IEnumerator ComplainAboutBrokenDoor2()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 5f)
		{
			yield break;
		}
		this.interruptChecker = "ComplainAboutBrokenDoor2";
		base.StartCoroutine("InterruptCheck");
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_brkndoor_01", "Speech"));
			base.StartCoroutine("InterruptSpeech");
		}
		yield break;
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x0011E4D0 File Offset: 0x0011C8D0
	public IEnumerator RainingOpenUncleWindow()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 5f)
		{
			yield break;
		}
		this.interruptChecker = "RainingOpenUncleWindow";
		base.StartCoroutine("InterruptCheck");
		if (this.canSpeak)
		{
			int num = UnityEngine.Random.Range(0, 3);
			string text = string.Empty;
			if (num == 0)
			{
				text = Language.Get("un_window_01", "Speech");
			}
			else if (num == 1)
			{
				text = Language.Get("un_window_02", "Speech");
			}
			else if (num == 2)
			{
				text = Language.Get("un_window_03", "Speech");
			}
			base.StartCoroutine("InterruptSpeech");
		}
		yield break;
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x0011E4EC File Offset: 0x0011C8EC
	private IEnumerator RainingOpenPlayerWindow()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 5f)
		{
			yield break;
		}
		this.interruptChecker = "RainingOpenPlayerWindow";
		base.StartCoroutine("InterruptCheck");
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak)
		{
			int num = UnityEngine.Random.Range(0, 3);
			this.speechStack.Clear();
			if (num == 0)
			{
				this.speechStack.Add(Language.Get("un_window_04", "Speech"));
			}
			else if (num == 1)
			{
				this.speechStack.Add(Language.Get("un_window_05", "Speech"));
			}
			else if (num == 2)
			{
				this.speechStack.Add(Language.Get("un_window_06", "Speech"));
			}
			base.StartCoroutine("InterruptSpeech");
		}
		yield break;
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0011E508 File Offset: 0x0011C908
	public IEnumerator RadioTurnedLoud()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 5f)
		{
			yield break;
		}
		yield return new WaitForSeconds(1.5f);
		if (this.carLogic.GetComponent<CarLogicC>().radioOn)
		{
			base.StartCoroutine(this.RadioTurnedLoud2());
		}
		yield break;
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x0011E524 File Offset: 0x0011C924
	public IEnumerator RadioTurnedLoud2()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 5f)
		{
			yield break;
		}
		this.interruptChecker = "RadioTurnedLoud2";
		base.StartCoroutine("InterruptCheck");
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak && !this.debugStopUncleWorking && !this.uncleGoneForever)
		{
			int num = UnityEngine.Random.Range(0, 3);
			this.speechStack.Clear();
			if (num == 0)
			{
				this.speechStack.Add(Language.Get("un_radiovol_01", "Speech"));
			}
			else if (num == 1)
			{
				this.speechStack.Add(Language.Get("un_radiovol_02", "Speech"));
			}
			else if (num == 2)
			{
				this.speechStack.Add(Language.Get("un_radiovol_03", "Speech"));
			}
			base.StartCoroutine("InterruptSpeech");
			this.hasRadioBeenLoud = true;
		}
		yield break;
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x0011E540 File Offset: 0x0011C940
	public IEnumerator RadioTurnedDown()
	{
		this.interruptChecker = "RadioTurnedDown";
		base.StartCoroutine("InterruptCheck");
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak && !this.debugStopUncleWorking && !this.uncleGoneForever && this.hasRadioBeenLoud)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_radiovol_04", "Speech"));
			base.StartCoroutine("InterruptSpeech");
			this.hasRadioBeenLoud = false;
		}
		yield break;
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0011E55C File Offset: 0x0011C95C
	private IEnumerator ComplainDrivingHazards()
	{
		this.interruptChecker = "ComplainDrivingHazards";
		base.StartCoroutine("InterruptCheck");
		this.hasComplainedAboutHazards = true;
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak)
		{
			this.hazardComplaintCounter++;
			this.speechStack.Clear();
			if (this.hazardComplaintCounter == 1)
			{
				this.speechStack.Add(Language.Get("un_hazard_01", "Speech"));
			}
			else if (this.hazardComplaintCounter == 2)
			{
				this.speechStack.Add(Language.Get("un_hazard_02", "Speech"));
			}
			else if (this.hazardComplaintCounter > 2)
			{
				this.speechStack.Add(Language.Get("un_hazard_03", "Speech"));
			}
			base.StartCoroutine("InterruptSpeech");
		}
		yield return new WaitForSeconds(30f);
		this.hasComplainedAboutHazards = false;
		yield break;
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x0011E578 File Offset: 0x0011C978
	private IEnumerator DrivingInRainWithoutWipersOnSlow()
	{
		if (this.wipersOffComplaintCounter <= 3)
		{
			this.hasComplainedAboutWipersOff = true;
			this.wipersOffComplaintCounter++;
			this.interruptChecker = "DrivingInRainWithoutWipersOnSlow";
			base.StartCoroutine("InterruptCheck");
			yield return new WaitForSeconds(0.2f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				if (this.wipersOffComplaintCounter == 1)
				{
					this.speechStack.Add(Language.Get("un_windwiper_01", "Speech"));
				}
				else if (this.wipersOffComplaintCounter == 2)
				{
					this.speechStack.Add(Language.Get("un_windwiper_01b", "Speech"));
				}
				else if (this.wipersOffComplaintCounter > 2)
				{
					this.speechStack.Add(Language.Get("un_windwiper_01c", "Speech"));
				}
				base.StartCoroutine("InterruptSpeech");
			}
			yield return new WaitForSeconds(30f);
			this.hasComplainedAboutWipersOff = false;
		}
		yield break;
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x0011E594 File Offset: 0x0011C994
	private IEnumerator DrivingInRainWithoutWipersOnFast()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 12f)
		{
			yield break;
		}
		if (this.wipersOffComplaintCounter <= 4)
		{
			this.interruptChecker = "DrivingInRainWithoutWipersOnFast";
			base.StartCoroutine("InterruptCheck");
			yield return new WaitForSeconds(0.2f);
			if (this.canSpeak)
			{
				this.hasComplainedAboutWipersOff = true;
				this.wipersOffComplaintCounter++;
				this.speechStack.Clear();
				if (this.wipersOffComplaintCounter == 1)
				{
					this.speechStack.Add(Language.Get("un_windwiper_02", "Speech"));
				}
				else if (this.wipersOffComplaintCounter == 2)
				{
					this.speechStack.Add(Language.Get("un_windwiper_02b", "Speech"));
				}
				else if (this.wipersOffComplaintCounter > 2)
				{
					this.speechStack.Add(Language.Get("un_windwiper_02c", "Speech"));
				}
				base.StartCoroutine("InterruptSpeech");
			}
			yield return new WaitForSeconds(30f);
			this.hasComplainedAboutWipersOff = false;
		}
		yield break;
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x0011E5B0 File Offset: 0x0011C9B0
	private IEnumerator DrivingWithPoppedBonnet()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 12f)
		{
			yield break;
		}
		this.interruptChecker = "DrivingWithPoppedBonnet";
		base.StartCoroutine("InterruptCheck");
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak)
		{
			this.hasComplainedAboutBonnet = true;
			int num = UnityEngine.Random.Range(0, 3);
			this.speechStack.Clear();
			if (num == 0)
			{
				this.speechStack.Add(Language.Get("un_bonnet_01", "Speech"));
			}
			else if (num == 1)
			{
				this.speechStack.Add(Language.Get("un_bonnet_02", "Speech"));
			}
			else if (num == 2)
			{
				this.speechStack.Add(Language.Get("un_bonnet_03", "Speech"));
			}
			base.StartCoroutine("InterruptSpeech");
		}
		yield return new WaitForSeconds(30f);
		this.hasComplainedAboutBonnet = false;
		yield break;
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x0011E5CC File Offset: 0x0011C9CC
	private IEnumerator ComplainAboutSpeed()
	{
		if (Vector3.Distance(base.transform.position, MainMenuC.Global.transform.position) > 12f)
		{
			yield break;
		}
		if (this.speedingComplaintCounter <= 2)
		{
			this.interruptChecker = "ComplainAboutSpeed";
			base.StartCoroutine("InterruptCheck");
			yield return new WaitForSeconds(0.2f);
			if (this.canSpeak)
			{
				this.hasComplainedAboutSpeed = true;
				this.speedingComplaintCounter++;
				this.speechStack.Clear();
				if (this.speedingComplaintCounter == 0)
				{
					this.speechStack.Add(Language.Get("un_speed_01", "Speech"));
				}
				else if (this.speedingComplaintCounter == 1)
				{
					this.speechStack.Add(Language.Get("un_speed_02", "Speech"));
				}
				base.StartCoroutine("InterruptSpeech");
			}
			yield return new WaitForSeconds(30f);
			this.hasComplainedAboutSpeed = false;
		}
		yield break;
	}

	// Token: 0x06000BE1 RID: 3041 RVA: 0x0011E5E8 File Offset: 0x0011C9E8
	private IEnumerator DialogueExplainLever()
	{
		Transform mouthTemp = this.mouth;
		this.interruptChecker = "DialogueExplainLever";
		base.StartCoroutine("InterruptCheck");
		yield return new WaitForSeconds(0.2f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("sk_levertut_01", "Speech"));
			base.StartCoroutine("InterruptSpeech");
			yield return new WaitWhile(() => !this.interruptSpeechComplete);
			this.mouth = mouthTemp;
		}
		yield break;
	}

	// Token: 0x06000BE2 RID: 3042 RVA: 0x0011E604 File Offset: 0x0011CA04
	private IEnumerator EngineRepairTutorialPart2()
	{
		this.engineRepairTutorialState = 8;
		this.dialogueChecker = "EngineRepairTutorialPart2";
		this.carLogic.GetComponent<CarLogicC>().preventHandBrake = true;
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_enginerepair_06", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000BE3 RID: 3043 RVA: 0x0011E620 File Offset: 0x0011CA20
	private IEnumerator WaitingForPlayerToPullLatch()
	{
		this.dialogueChecker = "WaitingForPlayerToPullLatch";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_enginerepair_07", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000BE4 RID: 3044 RVA: 0x0011E63B File Offset: 0x0011CA3B
	public void BonnetLatchPulled()
	{
		if (this.engineRepairTutorialState == 8)
		{
			base.StartCoroutine("HeadTowardsBonnet");
		}
		if (this.engineRepairTutorialState == 3)
		{
			this.engineRepairTutorialState = 8;
		}
	}

	// Token: 0x06000BE5 RID: 3045 RVA: 0x0011E668 File Offset: 0x0011CA68
	private IEnumerator HeadTowardsBonnet()
	{
		if (this.isSat)
		{
			base.transform.parent = null;
			base.GetComponent<Animator>().SetBool("enterCar", false);
			base.GetComponent<Animator>().SetBool("exitCar", true);
			this.readyToBoard = false;
			this.isSat = false;
			this.uncleDoorTrigger.GetComponent<DoorLogicC>().isBroken = false;
			this.uncleDoorTrigger.GetComponent<DoorLogicC>().open = false;
			this.uncleDoorTrigger.SendMessage("Trigger");
			yield return new WaitForSeconds(4f);
			this.uncleDoorTrigger.SendMessage("Trigger");
			Ray downRay = new Ray(this.uncleDoorTrigger.transform.position, -Vector3.up);
			RaycastHit hit;
			if (Physics.Raycast(downRay, out hit) && hit.distance < 1f)
			{
				float y = 1f - hit.distance;
				base.gameObject.transform.localPosition += new Vector3(0f, y, 0f);
			}
			base.gameObject.transform.localPosition += new Vector3(0f, 0.5f, 0f);
			base.gameObject.GetComponent<CharacterController>().enabled = true;
			this.carNavBlocker.SetActive(true);
			AstarPath.active.Scan(null);
			this.carNavBlocker.SetActive(false);
			base.GetComponent<AIPath>().target = this.bonnetNode;
			base.GetComponent<AIPath>().canMove = true;
		}
		yield break;
	}

	// Token: 0x06000BE6 RID: 3046 RVA: 0x0011E683 File Offset: 0x0011CA83
	public void BonnetOpened()
	{
		if (this.engineRepairTutorialState == 8)
		{
			base.StartCoroutine("EngineRepairTutorialPart3");
		}
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x0011E6A0 File Offset: 0x0011CAA0
	private IEnumerator EngineRepairTutorialPart3()
	{
		this.dialogueChecker = "EngineRepairTutorialPart3";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_enginerepair_10", "Speech"));
			this.speechStack.Add(Language.Get("un_enginerepair_11", "Speech"));
			yield return new WaitForSeconds(0.4f);
			GameObject boot = this.carLogic.GetComponent<CarLogicC>().bootInventory;
			Transform[] inventorySlots = boot.GetComponent<InventoryLogicC>().slot2x2x3;
			int engineRepairKits = 0;
			for (int i = 0; i < inventorySlots.Length; i++)
			{
				IEnumerator enumerator = inventorySlots[i].transform.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Transform transform = (Transform)obj;
						if (transform.name == "EngineRepairKit")
						{
							engineRepairKits++;
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
			if (engineRepairKits == 0)
			{
				this.speechStack.Add(Language.Get("un_enginerepair_13", "Speech"));
				this.speechStack.Add(Language.Get("un_enginerepair_14", "Speech"));
				this.engineRepairTutorialState = 11;
				this.itemsNeededToBeBought.Add(Language.Get("un_shoplist_01", "Speech"));
				this.itemsNeededToBeBoughtObjectNames.Add(Language.Get("un_shoplistobj_01", "Speech"));
				this.readyToBoard = true;
				base.GetComponent<AIPath>().target = this.uncleCarTransform;
			}
			else
			{
				this.speechStack.Add(Language.Get("un_enginerepair_12", "Speech"));
				this.engineRepairTutorialState = 11;
			}
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
		}
		yield break;
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x0011E6BC File Offset: 0x0011CABC
	public IEnumerator EngineRepairTutorialPart5()
	{
		this.engineRepairTutorialState = 14;
		this.dialogueChecker = "EngineRepairTutorialPart5";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_enginerepair_16", "Speech"));
			this.speechStack.Add(Language.Get("un_enginerepair_17", "Speech"));
			this.speechStack.Add(Language.Get("un_enginerepair_19b", "Speech"));
			this.speechStack.Add(Language.Get("un_enginerepair_20", "Speech"));
			this.speechStack.Add(Language.Get("un_enginerepair_22", "Speech"));
			this.speechStack.Add(Language.Get("un_enginerepair_19", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.director.GetComponent<DirectorC>().UpdateEventLogLearntBasicRepair();
			this.engineRepairTutorialState = 14;
			this.hasGivenEngineRepairTutorial = true;
			this.itemsNeededToBeBought.Add(Language.Get("un_shoplist_01", "Speech"));
			this.itemsNeededToBeBoughtObjectNames.Add(Language.Get("un_shoplistobj_01", "Speech"));
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			this.readyToBoard = true;
			base.StartCoroutine("WalkTowardsCarDoor");
			this.carLogic.GetComponent<CarLogicC>().preventHandBrake = false;
		}
		yield break;
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x0011E6D8 File Offset: 0x0011CAD8
	public IEnumerator EngineRepairTutorialPart6()
	{
		if (this.engineRepairTutorialState == 13 || this.playerHoldingRepairKitBreaker)
		{
			if (this.textQueue[0] == "EngineRepairTutorialPart6")
			{
				this.textQueue.RemoveAt(0);
			}
			yield break;
		}
		this.playerHoldingRepairKitBreaker = true;
		this.dialogueChecker = "EngineRepairTutorialPart6";
		base.StartCoroutine("DialogueCheck");
		if (this.canSpeak)
		{
			this.engineRepairTutorialState = 13;
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_enginerepair_18", "Speech"));
			this.speechStack.Add(Language.Get("un_enginerepair_15", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.director.GetComponent<DirectorC>().BubbleOn(this.mouth, this.characterName);
			for (int i = 0; i < this.itemsNeededToBeBought.Count; i++)
			{
				if (this.itemsNeededToBeBought[i] == Language.Get("un_shoplist_01", "Speech"))
				{
					this.itemsNeededToBeBought.RemoveAt(i);
					this.itemsNeededToBeBoughtObjectNames.RemoveAt(i);
				}
			}
			base.StartCoroutine("HeadTowardsBonnet");
		}
		this.playerHoldingRepairKitBreaker = false;
		yield break;
	}

	// Token: 0x06000BEA RID: 3050 RVA: 0x0011E6F3 File Offset: 0x0011CAF3
	public void PlayerRepairedCar()
	{
		if (this.engineRepairTutorialState == 13 && !this.hasGivenEngineRepairTutorial)
		{
			base.StartCoroutine(this.EngineRepairTutorialPart5());
			return;
		}
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x0011E71B File Offset: 0x0011CB1B
	public void HandBrakeCarStart()
	{
		if (this.fuelTutorialState == 3 && this.gateClose)
		{
			base.StartCoroutine("ForgotToPay");
			return;
		}
		if (this.fuelTutorialState == 4)
		{
			base.StartCoroutine("FuelTutorialPart3");
			return;
		}
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x0011E75C File Offset: 0x0011CB5C
	public void HandBrakeCarStopped()
	{
		if (this.withinRangeOfMotel)
		{
			base.StartCoroutine("CarStoppedAtMotel");
			return;
		}
		if (this.engineRepairTutorialState == 3)
		{
			this.engineRepairTutorialState = 6;
			base.StartCoroutine("EngineRepairTutorialPart2");
			return;
		}
		if (this.engineRepairTutorialState == 8)
		{
			base.StartCoroutine("HeadTowardsBonnet");
		}
		else if (this.fuelTutorialState == 1)
		{
			if (!this.isCloseToFuelPump)
			{
				base.StartCoroutine("TooFarFromFuelPump");
				return;
			}
			base.StartCoroutine("FuelTutorialPart1");
			return;
		}
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x0011E7F0 File Offset: 0x0011CBF0
	public void ScrapyardSign()
	{
		this.dialogueChecker = "ScrapyardSign";
		base.StartCoroutine("DialogueCheck");
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_scrapyard_01", "Speech"));
			this.speechStack.Add(Language.Get("un_scrapyard_02", "Speech"));
			this.speechStack.Add(Language.Get("un_scrapyard_03", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x0011E884 File Offset: 0x0011CC84
	public void PetrolStationSign()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			return;
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeChosen == 1 && this.director.GetComponent<RouteGeneratorC>().route1StopOff == 1)
		{
			base.StartCoroutine("ScrapyardSign");
			return;
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeChosen == 2 && this.director.GetComponent<RouteGeneratorC>().route2StopOff == 1)
		{
			base.StartCoroutine("ScrapyardSign");
			return;
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeChosen == 3 && this.director.GetComponent<RouteGeneratorC>().route3StopOff == 1)
		{
			base.StartCoroutine("ScrapyardSign");
			return;
		}
		float num = this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount / this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
		if (this.fuelTutorialState == 0 || (double)num < 0.25)
		{
			this.fuelTutorialState = 1;
			this.dialogueChecker = "PetrolStationSign";
			base.StartCoroutine("DialogueCheck");
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_petrolstation_01", "Speech"));
				this.speechStack.Add(Language.Get("un_petrolstation_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
			}
		}
	}

	// Token: 0x06000BEF RID: 3055 RVA: 0x0011EA20 File Offset: 0x0011CE20
	private IEnumerator DebugExitCar()
	{
		base.transform.parent = null;
		base.GetComponent<Animator>().SetBool("enterCar", false);
		base.GetComponent<Animator>().SetBool("exitCar", true);
		this.readyToBoard = false;
		this.isSat = false;
		this.uncleDoorTrigger.GetComponent<DoorLogicC>().isBroken = false;
		this.uncleDoorTrigger.GetComponent<DoorLogicC>().open = false;
		this.uncleDoorTrigger.SendMessage("Trigger");
		yield return new WaitForSeconds(4f);
		this.uncleDoorTrigger.SendMessage("Trigger");
		base.GetComponent<Animator>().SetBool("exitCar", false);
		Ray downRay = new Ray(this.uncleDoorTrigger.transform.position, -Vector3.up);
		RaycastHit hit;
		if (Physics.Raycast(downRay, out hit) && hit.distance < 1f)
		{
			float y = 1f - hit.distance;
			base.gameObject.transform.localPosition += new Vector3(0f, y, 0f);
		}
		base.gameObject.transform.localPosition += new Vector3(0f, 0.5f, 0f);
		base.gameObject.GetComponent<CharacterController>().enabled = true;
		this.carNavBlocker.SetActive(true);
		AstarPath.active.Scan(null);
		this.carNavBlocker.SetActive(false);
		base.GetComponent<AIPath>().target = this.stayAtHomeNode;
		this.restrictTalk = true;
		this.uncleAtHome = true;
		base.GetComponent<AIPath>().canMove = true;
		yield break;
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x0011EA3C File Offset: 0x0011CE3C
	private IEnumerator ForgotToPay()
	{
		this.dialogueChecker = "ForgotToPay";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_petrolstation_16", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000BF1 RID: 3057 RVA: 0x0011EA58 File Offset: 0x0011CE58
	public void RouteDialogueChecks()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			this.GerDialogues();
			return;
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			this.CSFRDialogues();
			return;
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			base.StartCoroutine("HUNDialogues");
			return;
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			base.StartCoroutine("YUGODialogues");
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			base.StartCoroutine("BULDialogues");
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			base.StartCoroutine("TURKDialogues");
		}
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x0011EB34 File Offset: 0x0011CF34
	public void GerDialogues()
	{
		if (this.dialogueSelected == 0)
		{
			if (this.routeDialogueLevel == 0)
			{
				base.StartCoroutine(this.GerDialogueStart());
				return;
			}
			if (this.routeDialogueLevel == 1)
			{
				base.StartCoroutine(this.Dialogues("GerDialogueA1", 3));
				return;
			}
			if (this.routeDialogueLevel == 2)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength == 6)
				{
					base.StartCoroutine(this.Dialogues("GerDialogueA2", (this.dialogueSelected != 0) ? 3 : 1));
					return;
				}
				this.routeDialogueLevel = 3;
			}
			if (this.routeDialogueLevel == 3)
			{
				base.StartCoroutine(this.Dialogues("GerDialogueA3", (this.dialogueSelected != 2) ? 3 : 4));
				return;
			}
			if (this.routeDialogueLevel == 4)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
				{
					base.StartCoroutine(this.Dialogues("GerDialogueA4", (this.dialogueSelected != 0) ? 2 : 3));
					return;
				}
				this.routeDialogueLevel = 5;
			}
			if (this.routeDialogueLevel == 5)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3 && this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
				{
					base.StartCoroutine(this.Dialogues("GerDialogueA5", 3));
					return;
				}
				this.routeDialogueLevel++;
			}
			if (this.routeDialogueLevel == 6)
			{
				base.StartCoroutine(this.Dialogues("GerDialogueA6", (this.dialogueSelected != 0) ? 3 : 2));
				base.StartCoroutine("GerDialogueA6");
				return;
			}
			if (this.routeDialogueLevel == 7)
			{
				base.StartCoroutine(this.GerDialogueEnd());
				return;
			}
		}
		else
		{
			if (this.routeDialogueLevel == 0)
			{
				base.StartCoroutine("GerDialogueStart");
				return;
			}
			if (this.routeDialogueLevel == 1)
			{
				base.StartCoroutine(this.Dialogues("GerDialogueA1", 3));
				return;
			}
			if (this.routeDialogueLevel == 2)
			{
				base.StartCoroutine(this.Dialogues("GerDialogueA2", (this.dialogueSelected != 0) ? 3 : 1));
			}
			if (this.routeDialogueLevel == 3)
			{
				base.StartCoroutine(this.Dialogues("GerDialogueA3", (this.dialogueSelected != 2) ? 3 : 4));
			}
			if (this.routeDialogueLevel == 4)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
				{
					base.StartCoroutine(this.Dialogues("GerDialogueA4", (this.dialogueSelected != 0) ? 2 : 3));
					return;
				}
				this.routeDialogueLevel = 7;
			}
			if (this.routeDialogueLevel == 5)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
				{
					base.StartCoroutine(this.Dialogues("GerDialogueA5", 3));
					return;
				}
				this.routeDialogueLevel = 7;
			}
			if (this.routeDialogueLevel == 6)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 5)
				{
					base.StartCoroutine(this.Dialogues("GerDialogueA6", (this.dialogueSelected != 0) ? 3 : 2));
					return;
				}
				this.routeDialogueLevel = 7;
			}
			if (this.routeDialogueLevel == 7)
			{
				base.StartCoroutine("GerDialogueEnd");
				return;
			}
		}
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x0011EEB0 File Offset: 0x0011D2B0
	public void CSFRDialogues()
	{
		if (this.dialogueSelected == 0)
		{
			if (this.routeDialogueLevel == 0)
			{
				base.StartCoroutine("CSFRDialogueStart");
				return;
			}
			if (this.routeDialogueLevel == 1)
			{
				base.StartCoroutine(this.Dialogues("CSFRDialogueA1", (this.dialogueSelected != 2) ? 3 : 1));
				return;
			}
			if (this.routeDialogueLevel == 2)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength == 6)
				{
					base.StartCoroutine(this.Dialogues("CSFRDialogueA2", (this.dialogueSelected != 0) ? 3 : 1));
					return;
				}
				this.routeDialogueLevel = 3;
			}
			if (this.routeDialogueLevel == 3)
			{
				base.StartCoroutine(this.Dialogues("CSFRDialogueA3", (this.dialogueSelected != 2) ? 3 : 4));
				return;
			}
			if (this.routeDialogueLevel == 4)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
				{
					base.StartCoroutine(this.Dialogues("CSFRDialogueA4", (this.dialogueSelected != 0) ? ((this.dialogueSelected != 1) ? 2 : 4) : 3));
					return;
				}
				this.routeDialogueLevel = 5;
			}
			if (this.routeDialogueLevel == 5)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3 && this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
				{
					base.StartCoroutine(this.Dialogues("CSFRDialogueA5", (this.dialogueSelected != 0) ? ((this.dialogueSelected != 1) ? 2 : 4) : 3));
					return;
				}
				this.routeDialogueLevel++;
			}
			if (this.routeDialogueLevel == 6)
			{
				base.StartCoroutine(this.Dialogues("CSFRDialogueA6", 2));
				base.StartCoroutine("CSFRDialogueA6");
				return;
			}
			if (this.routeDialogueLevel == 7)
			{
				base.StartCoroutine("CSFRDialogueEnd");
				return;
			}
		}
		else
		{
			if (this.routeDialogueLevel == 0)
			{
				base.StartCoroutine("CSFRDialogueStart");
				return;
			}
			if (this.routeDialogueLevel == 1)
			{
				base.StartCoroutine(this.Dialogues("CSFRDialogueA1", (this.dialogueSelected != 2) ? 3 : 1));
				return;
			}
			if (this.routeDialogueLevel == 2)
			{
				base.StartCoroutine(this.Dialogues("CSFRDialogueA2", (this.dialogueSelected != 0) ? 3 : 1));
			}
			if (this.routeDialogueLevel == 3)
			{
				base.StartCoroutine(this.Dialogues("CSFRDialogueA3", (this.dialogueSelected != 2) ? 3 : 4));
			}
			if (this.routeDialogueLevel == 4)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
				{
					base.StartCoroutine(this.Dialogues("CSFRDialogueA4", (this.dialogueSelected != 0) ? ((this.dialogueSelected != 1) ? 2 : 4) : 3));
					return;
				}
				this.routeDialogueLevel = 7;
			}
			if (this.routeDialogueLevel == 5)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
				{
					base.StartCoroutine(this.Dialogues("CSFRDialogueA5", (this.dialogueSelected != 0) ? ((this.dialogueSelected != 1) ? 2 : 4) : 3));
					return;
				}
				this.routeDialogueLevel = 7;
			}
			if (this.routeDialogueLevel == 6)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 5)
				{
					base.StartCoroutine(this.Dialogues("CSFRDialogueA6", 2));
					return;
				}
				this.routeDialogueLevel = 7;
			}
			if (this.routeDialogueLevel == 7)
			{
				base.StartCoroutine("CSFRDialogueEnd");
				return;
			}
		}
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x0011F294 File Offset: 0x0011D694
	public IEnumerator HUNDialogues()
	{
		if (this.routeDialogueLevel == 0)
		{
			base.StartCoroutine("HUNDialogueStart");
			yield break;
		}
		if (this.routeDialogueLevel == 1)
		{
			base.StartCoroutine(this.Dialogues("HUNDialogueA1", 2));
			yield break;
		}
		if (this.routeDialogueLevel == 2)
		{
			base.StartCoroutine(this.Dialogues("HUNDialogueA2", (this.dialogueSelected != 0) ? ((this.dialogueSelected != 1) ? 3 : 1) : 2));
		}
		if (this.routeDialogueLevel == 3)
		{
			base.StartCoroutine(this.Dialogues("HUNDialogueA3", 3));
		}
		if (this.routeDialogueLevel == 4)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
			{
				base.StartCoroutine(this.Dialogues("HUNDialogueA4", (this.dialogueSelected != 1) ? 3 : 2));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 5)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
			{
				base.StartCoroutine(this.Dialogues("HUNDialogueA5", (this.dialogueSelected != 2) ? 2 : 3));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 6)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 5)
			{
				base.StartCoroutine(this.Dialogues("HUNDialogueA6", (this.dialogueSelected != 0) ? 2 : 1));
				base.StartCoroutine("HUNDialogueA6");
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 7)
		{
			base.StartCoroutine("HUNDialogueEnd");
			yield break;
		}
		yield break;
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0011F2B0 File Offset: 0x0011D6B0
	public IEnumerator YUGODialogues()
	{
		if (this.routeDialogueLevel == 0)
		{
			base.StartCoroutine("YUGODialogueStart");
			yield break;
		}
		if (this.routeDialogueLevel == 1)
		{
			base.StartCoroutine("YUGODialogueA1");
			yield break;
		}
		if (this.routeDialogueLevel == 2)
		{
			base.StartCoroutine(this.Dialogues("YUGODialogueA2", (this.dialogueSelected != 2) ? 3 : 2));
		}
		if (this.routeDialogueLevel == 3)
		{
			base.StartCoroutine(this.Dialogues("YUGODialogueA3", 2));
		}
		if (this.routeDialogueLevel == 4)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
			{
				base.StartCoroutine(this.Dialogues("YUGODialogueA4", 3));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 5)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
			{
				base.StartCoroutine(this.Dialogues("YUGODialogueA5", 3));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 6)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 5)
			{
				base.StartCoroutine(this.Dialogues("YUGODialogueA6", 1));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 7)
		{
			base.StartCoroutine("YUGODialogueEnd");
			yield break;
		}
		yield break;
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x0011F2CC File Offset: 0x0011D6CC
	public IEnumerator BULDialogues()
	{
		if (this.routeDialogueLevel == 0)
		{
			base.StartCoroutine("BULDialogueStart");
			yield break;
		}
		if (this.routeDialogueLevel == 1)
		{
			base.StartCoroutine(this.Dialogues("BULDialogueA1", (this.dialogueSelected != 0) ? ((this.dialogueSelected != 1) ? 1 : 2) : 3));
			yield break;
		}
		if (this.routeDialogueLevel == 2)
		{
			base.StartCoroutine(this.Dialogues("BULDialogueA2", (this.dialogueSelected != 2) ? 3 : 2));
		}
		if (this.routeDialogueLevel == 3)
		{
			base.StartCoroutine(this.Dialogues("BULDialogueA3", (this.dialogueSelected != 1) ? 3 : 2));
		}
		if (this.routeDialogueLevel == 4)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
			{
				base.StartCoroutine(this.Dialogues("BULDialogueA4", (this.dialogueSelected != 0) ? 4 : 1));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 5)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
			{
				base.StartCoroutine(this.Dialogues("BULDialogueA5", (this.dialogueSelected != 0) ? 2 : 3));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 6)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 5)
			{
				base.StartCoroutine(this.Dialogues("BULDialogueA6", (this.dialogueSelected != 2) ? 1 : 2));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 7)
		{
			base.StartCoroutine("BULDialogueEnd");
			yield break;
		}
		yield break;
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x0011F2E8 File Offset: 0x0011D6E8
	public IEnumerator TURKDialogues()
	{
		if (this.routeDialogueLevel == 0)
		{
			base.StartCoroutine("TURKDialogueStart");
			yield break;
		}
		if (this.routeDialogueLevel == 1)
		{
			base.StartCoroutine(this.Dialogues("TURKDialogueA1", (this.dialogueSelected != 2) ? 1 : 2));
			yield break;
		}
		if (this.routeDialogueLevel == 2)
		{
			base.StartCoroutine(this.Dialogues("TURKDialogueA2", (this.dialogueSelected != 1) ? 2 : 3));
		}
		if (this.routeDialogueLevel == 3)
		{
			base.StartCoroutine(this.Dialogues("TURKDialogueA3", (this.dialogueSelected != 1) ? 3 : 2));
		}
		if (this.routeDialogueLevel == 4)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 3)
			{
				base.StartCoroutine(this.Dialogues("TURKDialogueA4", (this.dialogueSelected != 0) ? 2 : 3));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 5)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 4)
			{
				base.StartCoroutine(this.Dialogues("TURKDialogueA5", (this.dialogueSelected != 2) ? 2 : 1));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 6)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeChosenLength != 5)
			{
				base.StartCoroutine(this.Dialogues("TURKDialogueA6", (this.dialogueSelected != 0) ? ((this.dialogueSelected != 1) ? 3 : 2) : 1));
				yield break;
			}
			this.routeDialogueLevel = 7;
		}
		if (this.routeDialogueLevel == 7)
		{
			base.StartCoroutine("TURKDialogueEnd");
			yield break;
		}
		yield break;
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x0011F304 File Offset: 0x0011D704
	private IEnumerator GerDialogueStart()
	{
		this.dialogueChecker = "GerDialogueStart";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_ger_01_01", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = 1;
			base.StartCoroutine(this.GerDialogueStart2());
		}
		yield break;
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x0011F320 File Offset: 0x0011D720
	private IEnumerator GerDialogueStart2()
	{
		this.dialogueChecker = "GerDialogueStart2";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_ger_01_02", "Speech"));
			this.speechStack.Add(Language.Get("un_ger_01_03", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000BFA RID: 3066 RVA: 0x0011F33C File Offset: 0x0011D73C
	private IEnumerator Dialogues(string name, int dialogueCount)
	{
		this.dialogueChecker = "$" + dialogueCount + name;
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			yield return new WaitForEndOfFrame();
			this.speechStack.Clear();
			string shortString = name.Remove(name.Length - 2);
			shortString = shortString.Replace("Dialogue", string.Empty);
			shortString = shortString.ToLower();
			int id;
			int.TryParse(name[name.Length - 1].ToString(), out id);
			for (int num = 1; num != dialogueCount + 1; num++)
			{
				this.speechStack.Add(Language.Get(string.Concat(new object[]
				{
					"un_",
					shortString,
					"_0",
					this.dialogueSelected + 1,
					"_0",
					id,
					"_0",
					num
				}), "Speech"));
			}
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = int.Parse(name.Substring(name.Length - 1)) + 1;
		}
		yield break;
	}

	// Token: 0x06000BFB RID: 3067 RVA: 0x0011F368 File Offset: 0x0011D768
	private IEnumerator GerDialogueEnd()
	{
		if (this.dialogueSelected == 0)
		{
			this.dialogueChecker = "GerDialogueEnd";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_ger_01_07_01", "Speech"));
				this.speechStack.Add(Language.Get("un_ger_01_07_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 8;
			}
		}
		else if (this.dialogueSelected == 1)
		{
			this.dialogueChecker = "GerDialogueEnd";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_ger_02_07_01", "Speech"));
				this.speechStack.Add(Language.Get("un_ger_02_07_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 8;
			}
		}
		else if (this.dialogueSelected == 2)
		{
			this.dialogueChecker = "GerDialogueEnd";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_ger_03_07_01", "Speech"));
				this.speechStack.Add(Language.Get("un_ger_03_07_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 8;
			}
		}
		yield break;
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x0011F384 File Offset: 0x0011D784
	private IEnumerator CSFRDialogueStart()
	{
		this.dialogueChecker = "CSFRDialogueStart";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_csfr_01_01", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = 1;
			base.StartCoroutine("CSFRDialogueStart2");
		}
		yield break;
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x0011F3A0 File Offset: 0x0011D7A0
	private IEnumerator CSFRDialogueStart2()
	{
		this.dialogueChecker = "CSFRDialogueStart2";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_csfr_01_02", "Speech"));
			this.speechStack.Add(Language.Get("un_csfr_01_03", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000BFE RID: 3070 RVA: 0x0011F3BC File Offset: 0x0011D7BC
	private IEnumerator CSFRDialogueEnd()
	{
		if (this.dialogueSelected == 0)
		{
			this.dialogueChecker = "CSFRDialogueEnd";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_csfr_01_07_01", "Speech"));
				this.speechStack.Add(Language.Get("un_csfr_01_07_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 8;
			}
		}
		else if (this.dialogueSelected == 1)
		{
			this.dialogueChecker = "CSFRDialogueEnd";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_csfr_02_07_01", "Speech"));
				this.speechStack.Add(Language.Get("un_csfr_02_07_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 8;
			}
		}
		else if (this.dialogueSelected == 2)
		{
			this.dialogueChecker = "CSFRDialogueEnd";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_csfr_03_07_01", "Speech"));
				this.speechStack.Add(Language.Get("un_csfr_03_07_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 8;
			}
		}
		yield break;
	}

	// Token: 0x06000BFF RID: 3071 RVA: 0x0011F3D8 File Offset: 0x0011D7D8
	private IEnumerator HUNDialogueStart()
	{
		this.dialogueChecker = "HUNDialogueStart";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_hun_01_01", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = 1;
			base.StartCoroutine("HUNDialogueStart2");
		}
		yield break;
	}

	// Token: 0x06000C00 RID: 3072 RVA: 0x0011F3F4 File Offset: 0x0011D7F4
	private IEnumerator HUNDialogueStart2()
	{
		this.dialogueChecker = "HUNDialogueStart2";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_hun_01_02", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000C01 RID: 3073 RVA: 0x0011F410 File Offset: 0x0011D810
	private IEnumerator HUNDialogueEnd()
	{
		this.dialogueChecker = "HUNDialogueEnd";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_hun_01_07_01", "Speech"));
			this.speechStack.Add(Language.Get("un_hun_01_07_02", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = 8;
		}
		yield break;
	}

	// Token: 0x06000C02 RID: 3074 RVA: 0x0011F42C File Offset: 0x0011D82C
	public IEnumerator YUGODialogueStart()
	{
		this.routeDialogueLevel = 1;
		yield break;
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x0011F448 File Offset: 0x0011D848
	private IEnumerator YUGODialogueA1()
	{
		if (this.dialogueSelected == 0)
		{
			this.dialogueChecker = "YUGODialogueA1";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_yugo_01_01_01", "Speech"));
				this.speechStack.Add(Language.Get("un_yugo_01_01_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition <= 1)
				{
					if (!this.carLogic.GetComponent<CarLogicC>().rightWindowHandle.GetComponent<WindowLogicC>().isOpen)
					{
						base.StartCoroutine(this.carLogic.GetComponent<CarLogicC>().rightWindowHandle.GetComponent<WindowLogicC>().Trigger());
						yield return new WaitForSeconds(2.5f);
					}
					this.speechStack.Clear();
					this.speechStack.Add(Language.Get("un_yugo_01_01_02b", "Speech"));
					base.StartCoroutine("DialogueSpeech");
				}
				else
				{
					this.speechStack.Clear();
					if (this.carLogic.GetComponent<CarLogicC>().rightWindowHandle.GetComponent<WindowLogicC>().isOpen)
					{
						base.StartCoroutine(this.carLogic.GetComponent<CarLogicC>().rightWindowHandle.GetComponent<WindowLogicC>().Trigger());
						yield return new WaitForSeconds(2.5f);
						this.speechStack.Add(Language.Get("un_yugo_01_01_03", "Speech"));
					}
					else
					{
						this.speechStack.Add(Language.Get("un_yugo_01_01_03b", "Speech"));
					}
					base.StartCoroutine("DialogueSpeech");
				}
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				this.routeDialogueLevel = 2;
			}
		}
		else if (this.dialogueSelected == 1)
		{
			this.dialogueChecker = "YUGODialogueA1";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_yugo_02_01_01", "Speech"));
				this.speechStack.Add(Language.Get("un_yugo_02_01_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 2;
			}
		}
		else if (this.dialogueSelected == 2)
		{
			this.dialogueChecker = "YUGODialogueA1";
			base.StartCoroutine("DialogueCheck");
			yield return new WaitForSeconds(0.1f);
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				this.speechStack.Add(Language.Get("un_yugo_03_01_01", "Speech"));
				this.speechStack.Add(Language.Get("un_yugo_03_01_02", "Speech"));
				base.StartCoroutine("DialogueSpeech");
				yield return new WaitWhile(() => !this.dialogueSpeechComplete);
				yield return new WaitForSeconds(0.5f);
				this.routeDialogueLevel = 2;
			}
		}
		yield break;
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x0011F464 File Offset: 0x0011D864
	private IEnumerator YUGODialogueEnd()
	{
		this.dialogueChecker = "YUGODialogueEnd";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_yugo_01_07_01", "Speech"));
			this.speechStack.Add(Language.Get("un_yugo_01_07_02", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = 8;
		}
		yield break;
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x0011F47F File Offset: 0x0011D87F
	public void BULDialogueStart()
	{
		this.routeDialogueLevel = 1;
	}

	// Token: 0x06000C06 RID: 3078 RVA: 0x0011F488 File Offset: 0x0011D888
	private IEnumerator BULDialogueEnd()
	{
		this.dialogueChecker = "BULDialogueEnd";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_bul_01_07_01", "Speech"));
			this.speechStack.Add(Language.Get("un_bul_01_07_02", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = 8;
		}
		yield break;
	}

	// Token: 0x06000C07 RID: 3079 RVA: 0x0011F4A4 File Offset: 0x0011D8A4
	private IEnumerator TURKDialogueStart()
	{
		this.dialogueChecker = "TURKDialogueStart";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_turk_01_01", "Speech"));
			this.speechStack.Add(Language.Get("un_turk_01_02", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		this.routeDialogueLevel = 1;
		yield break;
	}

	// Token: 0x06000C08 RID: 3080 RVA: 0x0011F4C0 File Offset: 0x0011D8C0
	private IEnumerator TURKDialogueEnd()
	{
		this.dialogueChecker = "TURKDialogueEnd";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_turk_01_07_01", "Speech"));
			this.speechStack.Add(Language.Get("un_turk_01_07_02", "Speech"));
			this.speechStack.Add(Language.Get("un_turk_01_07_03", "Speech"));
			this.speechStack.Add(Language.Get("un_turk_01_07_04", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			this.routeDialogueLevel = 8;
		}
		yield break;
	}

	// Token: 0x06000C09 RID: 3081 RVA: 0x0011F4DC File Offset: 0x0011D8DC
	private IEnumerator WithinRangeOfMotel()
	{
		if (this.motel.GetComponent<MotelLogicC>().parkingTrigger.GetComponent<MotelParkingTriggerC>().isMorning)
		{
			yield break;
		}
		if (this.hasSpokenWithinRangeOfMotel)
		{
			if (this.textQueue.Count > 0 && this.textQueue[0] == "WithinRangeOfMotel")
			{
				this.textQueue.RemoveAt(0);
			}
			yield break;
		}
		this.dialogueChecker = "WithinRangeOfMotel";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_motel_02", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield return new WaitWhile(() => !this.dialogueSpeechComplete);
		this.hasSpokenWithinRangeOfMotel = true;
		yield break;
	}

	// Token: 0x06000C0A RID: 3082 RVA: 0x0011F4F8 File Offset: 0x0011D8F8
	private IEnumerator WalletInCar()
	{
		this.dialogueChecker = "WalletInCar";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_motel_14", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000C0B RID: 3083 RVA: 0x0011F514 File Offset: 0x0011D914
	private IEnumerator CarStoppedAtMotel()
	{
		if (this.motel.GetComponent<MotelLogicC>().parkingTrigger.GetComponent<MotelParkingTriggerC>().isMorning)
		{
			yield break;
		}
		if (!this.motel.GetComponent<MotelLogicC>().carParked)
		{
			base.StartCoroutine("NotParkedAtMotel");
			yield break;
		}
		this.carNavBlocker.SetActive(true);
		AstarPath.active.Scan(null);
		this.carNavBlocker.SetActive(false);
		if (this.hasSaidLetsCheckIn)
		{
			yield break;
		}
		this.dialogueChecker = "CarStoppedAtMotel";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_motel_03", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			this.hasSaidLetsCheckIn = true;
			yield return new WaitForSeconds(0.5f);
			base.StartCoroutine("UncleToMotelLobby");
		}
		yield break;
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x0011F530 File Offset: 0x0011D930
	private IEnumerator NotParkedAtMotel()
	{
		this.dialogueChecker = "NotParkedAtMotel";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_motel_04", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x0011F54C File Offset: 0x0011D94C
	public bool UncleCheckCanExitCar()
	{
		Ray ray = new Ray(this.uncleRayChecker.position, Vector3.right);
		RaycastHit raycastHit;
		return !Physics.Raycast(ray, out raycastHit) || (double)raycastHit.distance >= 2.0;
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x0011F598 File Offset: 0x0011D998
	private IEnumerator UncleToMotelLobby()
	{
		if (this.isSat)
		{
			base.transform.parent = null;
			base.GetComponent<Animator>().SetBool("exitCar", true);
			base.GetComponent<Animator>().SetBool("enterCar", false);
			this.readyToBoard = false;
			this.isSat = false;
			this.uncleDoorTrigger.GetComponent<DoorLogicC>().isBroken = false;
			this.uncleDoorTrigger.GetComponent<DoorLogicC>().open = false;
			this.uncleDoorTrigger.SendMessage("Trigger");
			yield return new WaitForSeconds(0.6f);
			this.suitcase.transform.parent = this.uncleRightHand;
			this.suitcase.transform.localPosition = new Vector3(-0.334f, 0.006f, 0.08f);
			this.suitcase.transform.localEulerAngles = new Vector3(-14.05f, -137.48f, 86.08f);
			yield return new WaitForSeconds(3.4f);
			this.uncleDoorTrigger.SendMessage("Trigger");
			base.GetComponent<Animator>().SetBool("exitCar", false);
			if (this.carLogic.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>().Condition <= 0f || this.carLogic.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>().Condition <= 0f || this.carLogic.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>().Condition <= 0f || this.carLogic.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>().Condition <= 0f)
			{
				base.gameObject.transform.position += new Vector3(0f, 1f, 0f);
			}
			base.gameObject.GetComponent<CharacterController>().enabled = true;
			this.carNavBlocker.SetActive(true);
			AstarPath.active.Scan(null);
			this.carNavBlocker.SetActive(false);
			base.GetComponent<AIPath>().target = this.motel.GetComponent<MotelLogicC>().lobbyNode;
			base.GetComponent<AIPath>().canMove = true;
		}
		yield break;
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x0011F5B4 File Offset: 0x0011D9B4
	private IEnumerator DialogueCannotExitCar()
	{
		this.dialogueChecker = "DialogueCannotExitCar";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_cannotexit_01", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x0011F5D0 File Offset: 0x0011D9D0
	private IEnumerator UncleWalkingToRoom()
	{
		if (this.uncleAtHome || this.uncleGoneForever || this.restrictTalk || this.sleepParticle.GetComponent<ParticleSystem>().isPlaying)
		{
			yield break;
		}
		this.dialogueChecker = "UncleWalkingToRoom";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_motel_05", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x0011F5EC File Offset: 0x0011D9EC
	public IEnumerator MotelSatOnBed()
	{
		float distance = Vector3.Distance(base.transform.position, this.player.transform.position);
		float distanceBigger = this.distanceCheck * 2.5f;
		Camera camera = Camera.main;
		if (distance < distanceBigger && !MainMenuC.Global.restrictPause)
		{
			if (!this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				this.dialogueChecker = "MotelSatOnBed";
				base.StartCoroutine("DialogueCheck");
				yield return new WaitForSeconds(0.1f);
				if (this.canSpeak)
				{
					this.speechStack.Clear();
					this.speechStack.Add(Language.Get("un_motel_06", "Speech"));
					this.speechStack.Add(Language.Get("un_motel_07", "Speech"));
					this.speechStack.Add(Language.Get("un_motel_08", "Speech"));
					this.speechStack.Add(Language.Get("un_motel_15", "Speech"));
					base.StartCoroutine("DialogueSpeech");
					yield return new WaitWhile(() => !this.dialogueSpeechComplete);
					base.GetComponent<Animator>().SetTrigger("SleepMotel");
					base.StartCoroutine("SuitCaseOutOfBed");
				}
			}
			else
			{
				base.GetComponent<Animator>().SetTrigger("SleepMotel");
				base.StartCoroutine("SuitCaseOutOfBed");
			}
		}
		else
		{
			base.GetComponent<Animator>().SetTrigger("SleepMotel");
			base.StartCoroutine("SuitCaseOutOfBed");
		}
		this.isSat = true;
		yield break;
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0011F608 File Offset: 0x0011DA08
	public void UncleGoneForeverLogic()
	{
		this.suitcase.transform.parent = this.carLogic.GetComponent<CarLogicC>().suitcaseHolder;
		this.suitcase.transform.localPosition = Vector3.zero;
		this.suitcase.transform.localEulerAngles = Vector3.zero;
		this.suitcase.GetComponent<SuitcaseRelayC>()._lock.GetComponent<OpenBriefcaseLogicC>().CarTrigger();
		this.suitcase.GetComponent<SuitcaseRelayC>().ChangeToCarMesh();
		UnityEngine.Object.Destroy(this.passport.GetChild(1).transform.gameObject);
		UnityEngine.Object.Destroy(this.passport.GetChild(0).transform.gameObject);
		base.transform.GetComponent<Animator>().enabled = false;
		base.transform.GetComponent<CharacterController>().enabled = false;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			base.transform.GetChild(i).position = new Vector3(-2000f, -2000f, 0f);
		}
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x0011F724 File Offset: 0x0011DB24
	private IEnumerator SuitCaseOutOfBed()
	{
		yield return new WaitForSeconds(3.5f);
		this.sleepParticle.GetComponent<ParticleSystem>().Play();
		yield return new WaitForSeconds(1f);
		if (!this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome && this.director.GetComponent<RouteGeneratorC>().routeLevel != 5)
		{
			this.suitcase.GetComponent<SuitcaseRelayC>()._lock.GetComponent<OpenBriefcaseLogicC>().Trigger();
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5 && !this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			this.uncleGoneForever = true;
		}
		yield break;
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x0011F740 File Offset: 0x0011DB40
	private IEnumerator DemoOutro()
	{
		this.dialogueChecker = "DemoOutro";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_demoend_01", "Speech"));
			this.speechStack.Add(Language.Get("un_demoend_02", "Speech"));
			this.speechStack.Add(Language.Get("un_demoend_03", "Speech"));
			this.speechStack.Add(Language.Get("un_demoend_04", "Speech"));
			this.speechStack.Add(Language.Get("un_demoend_05", "Speech"));
			this.speechStack.Add(Language.Get("un_demoend_06", "Speech"));
			this.speechStack.Add(Language.Get("un_demoend_07", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitWhile(() => !this.dialogueSpeechComplete);
			yield return new WaitForSeconds(0.5f);
			MainMenuC.Global.StartCoroutine("SaveData");
			Application.LoadLevel(0);
		}
		yield break;
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x0011F75B File Offset: 0x0011DB5B
	private void DayGo()
	{
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x0011F75D File Offset: 0x0011DB5D
	public void ReadyToTalkAboutBorder()
	{
		this.isReadyToTalkAboutBorder = true;
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x0011F768 File Offset: 0x0011DB68
	private IEnumerator LetsGoBorderCross()
	{
		this.dialogueChecker = "DemoOutro";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("un_newday_01", "Speech"));
			this.speechStack.Add(Language.Get("un_newday_02", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x04001033 RID: 4147
	public bool debugStopUncleWorking;

	// Token: 0x04001034 RID: 4148
	private GameObject _camera;

	// Token: 0x04001035 RID: 4149
	private Vector3 lastPosition = Vector3.zero;

	// Token: 0x04001036 RID: 4150
	public Transform passport;

	// Token: 0x04001037 RID: 4151
	public GameObject suitcase;

	// Token: 0x04001038 RID: 4152
	public Transform uncleRightHand;

	// Token: 0x04001039 RID: 4153
	public bool restrictTalk;

	// Token: 0x0400103A RID: 4154
	public bool uncleAtHome = true;

	// Token: 0x0400103B RID: 4155
	public bool uncleGoneForever;

	// Token: 0x0400103C RID: 4156
	public float moveSpeed;

	// Token: 0x0400103D RID: 4157
	public float curVel;

	// Token: 0x0400103E RID: 4158
	public float lastVel;

	// Token: 0x0400103F RID: 4159
	public Collider myBounds;

	// Token: 0x04001040 RID: 4160
	public GameObject director;

	// Token: 0x04001041 RID: 4161
	public GameObject carLogic;

	// Token: 0x04001042 RID: 4162
	public GameObject player;

	// Token: 0x04001043 RID: 4163
	public GameObject motel;

	// Token: 0x04001044 RID: 4164
	public GameObject uncleDoorTrigger;

	// Token: 0x04001045 RID: 4165
	public Transform uncleRayChecker;

	// Token: 0x04001046 RID: 4166
	public Transform mouth;

	// Token: 0x04001047 RID: 4167
	public float distanceCheck;

	// Token: 0x04001048 RID: 4168
	public GameObject dialogueHolder;

	// Token: 0x04001049 RID: 4169
	[Header("Conversation IDs")]
	public int conversationID;

	// Token: 0x0400104A RID: 4170
	public Transform uncleCarTransform;

	// Token: 0x0400104B RID: 4171
	public Transform relayNodeTransform;

	// Token: 0x0400104C RID: 4172
	public Transform bonnetNode;

	// Token: 0x0400104D RID: 4173
	public Transform bootNode;

	// Token: 0x0400104E RID: 4174
	public Transform stayAtHomeNode;

	// Token: 0x0400104F RID: 4175
	public bool readyToBoard;

	// Token: 0x04001050 RID: 4176
	public bool firstTimeBoarding = true;

	// Token: 0x04001051 RID: 4177
	public float distanceToCarEntrance;

	// Token: 0x04001052 RID: 4178
	public float distanceToRelayNode;

	// Token: 0x04001053 RID: 4179
	public float distanceToBonnetNode;

	// Token: 0x04001054 RID: 4180
	public bool walkingTowardsDoor;

	// Token: 0x04001055 RID: 4181
	public bool carDoorOpen;

	// Token: 0x04001056 RID: 4182
	public bool enterCarDoorOnce;

	// Token: 0x04001057 RID: 4183
	public bool isSat;

	// Token: 0x04001058 RID: 4184
	public Transform carLookAt;

	// Token: 0x04001059 RID: 4185
	public GameObject radioVolume;

	// Token: 0x0400105A RID: 4186
	public int consecutiveDoorFails;

	// Token: 0x0400105B RID: 4187
	private bool hasRadioBeenLoud;

	// Token: 0x0400105C RID: 4188
	public bool hasComplainedAboutHazards;

	// Token: 0x0400105D RID: 4189
	public bool hasComplainedAboutHeadlights;

	// Token: 0x0400105E RID: 4190
	public int hazardComplaintCounter;

	// Token: 0x0400105F RID: 4191
	public int headLightComplaintCounter;

	// Token: 0x04001060 RID: 4192
	public bool headlightSpamStopper;

	// Token: 0x04001061 RID: 4193
	public int wipersOffComplaintCounter;

	// Token: 0x04001062 RID: 4194
	public bool hasComplainedAboutWipersOff;

	// Token: 0x04001063 RID: 4195
	public bool hasComplainedAboutBonnet;

	// Token: 0x04001064 RID: 4196
	public bool hasComplainedAboutSpeed;

	// Token: 0x04001065 RID: 4197
	public int speedingComplaintCounter;

	// Token: 0x04001066 RID: 4198
	public GameObject sleepParticle;

	// Token: 0x04001067 RID: 4199
	public AudioClip[] speech = new AudioClip[0];

	// Token: 0x04001068 RID: 4200
	[Header("Generic text")]
	public int routeDialogueLevel;

	// Token: 0x04001069 RID: 4201
	public bool isTalking;

	// Token: 0x0400106A RID: 4202
	public bool textFinished;

	// Token: 0x0400106B RID: 4203
	public List<string> textQueue = new List<string>();

	// Token: 0x0400106C RID: 4204
	public string currentConvoItem;

	// Token: 0x0400106D RID: 4205
	public string interruptConvoItem;

	// Token: 0x0400106E RID: 4206
	public string dialogueConvoItem;

	// Token: 0x0400106F RID: 4207
	public List<string> speechStack = new List<string>();

	// Token: 0x04001070 RID: 4208
	public bool inputRestrictDropItem;

	// Token: 0x04001071 RID: 4209
	public string interruptChecker = string.Empty;

	// Token: 0x04001072 RID: 4210
	public string dialogueChecker = string.Empty;

	// Token: 0x04001073 RID: 4211
	public bool canSpeak;

	// Token: 0x04001074 RID: 4212
	public bool interruptSpeechComplete;

	// Token: 0x04001075 RID: 4213
	public bool dialogueSpeechComplete;

	// Token: 0x04001076 RID: 4214
	public bool uncleArrivedAtBonnet;

	// Token: 0x04001077 RID: 4215
	public bool hasGivenEngineRepairTutorial;

	// Token: 0x04001078 RID: 4216
	public int engineRepairTutorialState;

	// Token: 0x04001079 RID: 4217
	private bool playerHoldingRepairKitBreaker;

	// Token: 0x0400107A RID: 4218
	public List<string> itemsNeededToBeBought = new List<string>();

	// Token: 0x0400107B RID: 4219
	public List<string> itemsNeededToBeBoughtObjectNames = new List<string>();

	// Token: 0x0400107C RID: 4220
	public bool gateClose;

	// Token: 0x0400107D RID: 4221
	public bool atPetrolStation;

	// Token: 0x0400107E RID: 4222
	public bool isCloseToFuelPump;

	// Token: 0x0400107F RID: 4223
	public int fuelTutorialState;

	// Token: 0x04001080 RID: 4224
	public GameObject gateObj;

	// Token: 0x04001081 RID: 4225
	public AudioClip gateAudio;

	// Token: 0x04001082 RID: 4226
	public bool withinRangeOfMotel;

	// Token: 0x04001083 RID: 4227
	public float motelDistanceCheck;

	// Token: 0x04001084 RID: 4228
	public bool hasSpokenWithinRangeOfMotel;

	// Token: 0x04001085 RID: 4229
	public bool hasSaidLetsCheckIn;

	// Token: 0x04001086 RID: 4230
	public bool isReadyToTalkAboutBorder;

	// Token: 0x04001087 RID: 4231
	private bool headLookOn = true;

	// Token: 0x04001088 RID: 4232
	public Sprite[] sprites = new Sprite[0];

	// Token: 0x04001089 RID: 4233
	public GameObject spriteTarget;

	// Token: 0x0400108A RID: 4234
	private float spriteTimer;

	// Token: 0x0400108B RID: 4235
	public float spriteTimerCheck = 0.15f;

	// Token: 0x0400108C RID: 4236
	public bool tutorialBool;

	// Token: 0x0400108D RID: 4237
	public string characterName = "ui_name_01";

	// Token: 0x0400108E RID: 4238
	public AudioClip[] shoeAudio = new AudioClip[0];

	// Token: 0x0400108F RID: 4239
	private float shoeAudioTimer;

	// Token: 0x04001090 RID: 4240
	public int dialogueSelected;

	// Token: 0x04001091 RID: 4241
	public GameObject carNavBlocker;

	// Token: 0x04001092 RID: 4242
	public GameObject[] startingHomeItems = new GameObject[0];

	// Token: 0x04001093 RID: 4243
	private Vector3 lastLocation;
}
