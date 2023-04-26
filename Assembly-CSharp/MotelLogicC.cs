using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TMPro;
using UnityEngine;

// Token: 0x020000D1 RID: 209
public class MotelLogicC : MonoBehaviour
{
	// Token: 0x06000838 RID: 2104 RVA: 0x000AB9B8 File Offset: 0x000A9DB8
	private void LateStart()
	{
		this.wallet = this.director.GetComponent<DirectorC>().wallet;
		this.startMaterial = this.glowTarget.GetComponent<Renderer>().material;
		if (!this.hasPaid)
		{
			this.roomNumber = UnityEngine.Random.Range(0, this.roomKey.Length);
			if (this.roomNumber == 2)
			{
				this.roomNumber = 0;
			}
			this.SetGuests();
		}
		if (this.musicBox != null)
		{
			iTween.PunchScale(this.musicBox, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0.1f, 0f, 0.1f),
				"easetype",
				"easeOutBounce",
				"looptype",
				"loop",
				"time",
				0.35
			}));
		}
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		gameObject.GetComponent<UncleLogicC>().motel = base.gameObject;
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x000ABACC File Offset: 0x000A9ECC
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.player = GameObject.FindWithTag("Player");
		this.director = GameObject.FindWithTag("Director");
		base.Invoke("LateStart", 0.2f);
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x000ABB19 File Offset: 0x000A9F19
	public void SaveRoomLayout()
	{
		ES3.Save(this.roomNumber, "motelRoomAssigned");
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x000ABB2C File Offset: 0x000A9F2C
	public void WakeUpInTown()
	{
		iTween.Stop(Camera.main.gameObject);
		this.isWelcomed = false;
		this.hasSlept = true;
		this.hasPaid = true;
		this.hasSaidBye = false;
		this.hasGreeted = true;
		this.parkingTrigger.GetComponent<MotelParkingTriggerC>().isMorning = true;
		int num = UnityEngine.Random.Range(0, this.roomBeds.Length);
		if (ES3.Exists("motelRoomAssigned"))
		{
			num = ES3.LoadInt("motelRoomAssigned");
		}
		Camera.main.transform.localPosition = new Vector3(0f, 0.8f, 0f);
		this.roomNumber = num;
		this.SetGuests();
		GameObject gameObject = this.roomBeds[num];
		base.StartCoroutine(gameObject.GetComponent<BedLogicC>().WakeUpFromLoad());
		this.roomDoors[num].GetComponent<EnvironmentDoorsC>().isLocked = false;
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x000ABC04 File Offset: 0x000AA004
	public void SetGuests()
	{
		for (int i = 0; i < this.roomDoors.Length; i++)
		{
			if (i != this.roomNumber)
			{
				int num = UnityEngine.Random.Range(0, 100);
				if (num <= 20)
				{
					this.roomDoors[i].transform.parent.transform.parent.GetComponent<DoorKnockingC>().SetDoorToShady();
				}
				else if (num > 20 && num <= 75)
				{
					this.roomDoors[i].transform.parent.transform.parent.GetComponent<DoorKnockingC>().SetDoorToAngry();
				}
			}
		}
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x000ABCA8 File Offset: 0x000AA0A8
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.glowTarget.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x000ABCF4 File Offset: 0x000AA0F4
	public void PlayerTriggerEnter()
	{
		if (!this.isWelcomed && !this.hasPaid && !this.hasGreeted)
		{
			this.isWelcomed = true;
			base.StartCoroutine("Welcome");
		}
		if (!this.isWelcomed && this.hasGreeted)
		{
			this.isWelcomed = true;
			base.StartCoroutine("WelcomeAgain");
		}
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x000ABD5E File Offset: 0x000AA15E
	public void PlayerTriggerExit()
	{
		if (this.isWelcomed)
		{
			base.StopCoroutine("Welcome");
			base.StopCoroutine("WelcomeAgain");
			this.isWelcomed = false;
		}
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x000ABD88 File Offset: 0x000AA188
	public void CarEnter()
	{
		this.carParked = true;
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x000ABD94 File Offset: 0x000AA194
	public void CarEnterMorning()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		gameObject.GetComponent<UncleLogicC>().debugStopUncleWorking = false;
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x000ABDB8 File Offset: 0x000AA1B8
	public void CarExit()
	{
		this.carParked = false;
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x000ABDC4 File Offset: 0x000AA1C4
	public void CarExitMorning()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x000ABDDC File Offset: 0x000AA1DC
	private IEnumerator ClearDialogue(float delay)
	{
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().text = string.Empty;
		yield return new WaitForSeconds(delay);
		this.director.GetComponent<DirectorC>().BubbleOff();
		yield break;
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x000ABE00 File Offset: 0x000AA200
	public void GateClose()
	{
		base.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Hub_CitySpawnC>().GateClose();
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x000ABE54 File Offset: 0x000AA254
	public void ClearDialogueInstant()
	{
		this.director.GetComponent<DirectorC>().BubbleOff();
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x000ABE88 File Offset: 0x000AA288
	public void DialogueCheck()
	{
		if (this.dialogueConvoItem != string.Empty && this.dialogueConvoItem != this.dialogueChecker)
		{
			this.canSpeak = false;
			this.AddItemToStartOfQueue();
			return;
		}
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StopCoroutine("DialogueSpeech");
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StopTypeText();
		this.isTalking = true;
		this.dialogueConvoItem = this.dialogueChecker;
		this.dialogueChecker = string.Empty;
		this.textFinished = false;
		this.canSpeak = true;
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x000ABF44 File Offset: 0x000AA344
	private IEnumerator DialogueSpeech()
	{
		base.StopCoroutine("StopInputRestrict");
		this.dialogueSpeechComplete = false;
		this.canSpeak = false;
		for (int i = 0; i < this.speechStack.Count; i++)
		{
			this.textFinished = false;
			yield return new WaitForSeconds(0.2f);
			this.director.GetComponent<DirectorC>().BubbleOn(this.shopKeeperMouth.transform, this.characterName);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().word = this.speechStack[i];
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			int rnd = UnityEngine.Random.Range(0, this.audioTalking.Length);
			this.shopKeeper.GetComponent<AudioSource>().clip = this.audioTalking[rnd];
			this.shopKeeper.GetComponent<AudioSource>().Play();
			this.shopKeeper.GetComponent<Animator>().SetBool("talking", true);
			yield return new WaitWhile(() => !this.textFinished);
			this.shopKeeper.GetComponent<Animator>().SetBool("talking", false);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			yield return new WaitWhile(() => this.inputRestrictDropItem);
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForEndOfFrame();
		}
		this.isTalking = false;
		this.dialogueSpeechComplete = true;
		this.dialogueConvoItem = string.Empty;
		yield break;
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x000ABF60 File Offset: 0x000AA360
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

	// Token: 0x0600084A RID: 2122 RVA: 0x000ABFB8 File Offset: 0x000AA3B8
	private void StopInputRestrictStopper()
	{
		base.StopCoroutine("StopInputRestrict");
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x000ABFC8 File Offset: 0x000AA3C8
	private IEnumerator StopInputRestrict()
	{
		yield return new WaitForSeconds(0.5f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x000ABFE3 File Offset: 0x000AA3E3
	public void TextFinished()
	{
		this.textFinished = true;
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000ABFEC File Offset: 0x000AA3EC
	private IEnumerator Welcome()
	{
		this.dialogueChecker = "Welcome";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.shopKeeper.GetComponent<Animator>().SetTrigger("PlayerEnters");
			this.hasGreeted = true;
			yield return new WaitForEndOfFrame();
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("motel_wel_01", "Speech"));
			this.speechStack.Add(string.Concat(new string[]
			{
				Language.Get("motel_price_01", "Speech"),
				" ",
				this.roomPrice.ToString(),
				" ",
				Language.Get("motel_price_02", "Speech")
			}));
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("DialogueSpeech");
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null)
			{
				while (!this.dialogueSpeechComplete)
				{
					yield return new WaitForEndOfFrame();
				}
				yield return new WaitForSeconds(0.5f);
				GameObject uncle = GameObject.FindWithTag("Uncle");
				uncle.GetComponent<UncleLogicC>().StartCoroutine("WalletInCar");
			}
		}
		yield break;
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x000AC008 File Offset: 0x000AA408
	private IEnumerator WelcomeAgain()
	{
		this.dialogueChecker = "WelcomeAgain";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.shopKeeper.GetComponent<Animator>().SetTrigger("PlayerEnters");
			if (this.hasSlept)
			{
				if (!this.hasSaidBye)
				{
					this.hasSaidBye = true;
					int rnd4 = UnityEngine.Random.Range(0, 2);
					yield return new WaitForEndOfFrame();
					this.speechStack.Clear();
					if (rnd4 == 0)
					{
						this.speechStack.Add(Language.Get("motel_wel_10", "Speech"));
					}
					else if (rnd4 == 1)
					{
						this.speechStack.Add(Language.Get("motel_wel_10b", "Speech"));
					}
					else if (rnd4 == 2)
					{
						this.speechStack.Add(Language.Get("motel_wel_10c", "Speech"));
					}
					yield return new WaitForEndOfFrame();
					base.StartCoroutine("DialogueSpeech");
				}
				yield break;
			}
			int rnd5 = UnityEngine.Random.Range(0, 2);
			this.speechStack.Clear();
			if (rnd5 == 0)
			{
				this.speechStack.Add(Language.Get("motel_wel_09", "Speech"));
			}
			else if (rnd5 == 1)
			{
				this.speechStack.Add(Language.Get("motel_wel_09b", "Speech"));
			}
			else if (rnd5 == 2)
			{
				this.speechStack.Add(Language.Get("motel_wel_09c", "Speech"));
			}
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("DialogueSpeech");
			while (!this.dialogueSpeechComplete)
			{
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForSeconds(0.5f);
			if (!this.hasPaid)
			{
				this.speechStack.Clear();
				this.speechStack.Add(string.Concat(new string[]
				{
					Language.Get("motel_price_01", "Speech"),
					" ",
					this.roomPrice.ToString(),
					" ",
					Language.Get("motel_price_02", "Speech")
				}));
				yield return new WaitForEndOfFrame();
				base.StartCoroutine("DialogueSpeech");
			}
		}
		yield break;
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x000AC024 File Offset: 0x000AA424
	private void Reset()
	{
		MotelLogic component = base.GetComponent<MotelLogic>();
		this._camera = component._camera;
		this.director = component.director;
		this.roomKeySpawnLoc = component.roomKeySpawnLoc;
		this.player = component.player;
		this.shopKeeper = component.shopKeeper;
		this.shopKeeperMouth = component.shopKeeperMouth;
		this.motelPrice = component.motelPrice;
		component.motelPriceText.Copy(ref this.motelPriceText);
		this.parkingTrigger = component.parkingTrigger;
		component.audioTalking.Copy(ref this.audioTalking);
		this.isWelcomed = component.isWelcomed;
		this.roomNumber = component.roomNumber;
		component.roomKey.Copy(ref this.roomKey);
		component.roomDoors.Copy(ref this.roomDoors);
		component.roomBeds.Copy(ref this.roomBeds);
		this.hasPaid = component.hasPaid;
		this.hasGreeted = component.hasGreeted;
		this.roomPrice = component.roomPrice;
		this.hasSlept = component.hasSlept;
		this.spawnedRoomKey = component.spawnedRoomKey;
		component.roomDoor.Copy(ref this.roomDoor);
		this.musicBox = component.musicBox;
		this.wallet = component.wallet;
		this.isGlowing = component.isGlowing;
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.glowTarget = component.glowTarget;
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
		this.lobbyNode = component.lobbyNode;
		component.doorNodes.Copy(ref this.doorNodes);
		component.roomNodes.Copy(ref this.roomNodes);
		this.carParked = component.carParked;
		this.characterName = component.characterName;
		this.hasSaidBye = component.hasSaidBye;
		component.enabled = false;
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x000AC29C File Offset: 0x000AA69C
	public void Trigger()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null)
		{
			return;
		}
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		if (isHolding.name == this.wallet.name && !this.hasPaid)
		{
			if (this.wallet.GetComponent<WalletC>().TotalWealth >= (float)this.roomPrice)
			{
				this.Payed();
				base.StartCoroutine(this.PaidDialogue());
				isHolding.SendMessage("ChangeMoney");
				return;
			}
		}
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x000AC33C File Offset: 0x000AA73C
	private IEnumerator PaidDialogue()
	{
		this.dialogueChecker = "PaidDialogue";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			if (this.roomNumber == 0)
			{
				this.speechStack.Add(Language.Get("motel_wel_03", "Speech"));
			}
			else if (this.roomNumber == 1)
			{
				this.speechStack.Add(Language.Get("motel_wel_04", "Speech"));
			}
			else if (this.roomNumber == 2)
			{
				this.speechStack.Add(Language.Get("motel_wel_05", "Speech"));
			}
			else if (this.roomNumber == 3)
			{
				this.speechStack.Add(Language.Get("motel_wel_06", "Speech"));
			}
			else if (this.roomNumber == 4)
			{
				this.speechStack.Add(Language.Get("motel_wel_07", "Speech"));
			}
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("DialogueSpeech");
			while (!this.dialogueSpeechComplete)
			{
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForSeconds(0.5f);
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("motel_wel_08", "Speech"));
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("DialogueSpeech");
			yield return new WaitForSeconds(0.5f);
			while (!this.dialogueSpeechComplete)
			{
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForSeconds(0.5f);
			GameObject uncle = GameObject.FindWithTag("Uncle");
			uncle.GetComponent<AIPath>().target = this.doorNodes[this.roomNumber];
			uncle.GetComponent<UncleLogicC>().StartCoroutine("UncleWalkingToRoom");
		}
		yield break;
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x000AC358 File Offset: 0x000AA758
	public void Payed()
	{
		this.hasPaid = true;
		base.GetComponent<BoxCollider>().enabled = false;
		this.shopKeeper.GetComponent<Animator>().SetTrigger("GiveKey");
		this.wallet.GetComponent<WalletC>().incomingFunds -= (float)this.roomPrice;
		this.wallet.GetComponent<WalletC>().UpdateWealth();
		base.StartCoroutine(this.GiveRoomKey());
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x000AC3C8 File Offset: 0x000AA7C8
	private IEnumerator GiveRoomKey()
	{
		yield return new WaitForSeconds(0.2f);
		this.spawnedRoomKey = UnityEngine.Object.Instantiate<GameObject>(this.roomKey[this.roomNumber], this.roomKeySpawnLoc.transform.position, this.roomKeySpawnLoc.transform.rotation);
		this.spawnedRoomKey.GetComponent<MotelRelayC>().shopKeeper = this.shopKeeper;
		this.spawnedRoomKey.name = this.roomKey[this.roomNumber].name;
		this.spawnedRoomKey.transform.parent = this.roomKeySpawnLoc;
		this.spawnedRoomKey.transform.localPosition = Vector3.zero;
		yield break;
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x000AC3E4 File Offset: 0x000AA7E4
	public void SetMotelPrice()
	{
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			this.motelPriceText[0].GetComponent<TextMeshPro>().text = Language.Get("motel_price_ger_01", "Inspector_UI");
			this.motelPriceText[1].GetComponent<TextMeshPro>().text = Language.Get("motel_price_ger_02", "Inspector_UI");
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			this.roomPrice += 5;
			this.motelPrice.GetComponent<TextMeshPro>().text = this.roomPrice.ToString();
			this.motelPriceText[0].GetComponent<TextMeshPro>().text = Language.Get("motel_price_csfr_01", "Inspector_UI");
			this.motelPriceText[1].GetComponent<TextMeshPro>().text = Language.Get("motel_price_csfr_02", "Inspector_UI");
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			this.roomPrice += 10;
			this.motelPrice.GetComponent<TextMeshPro>().text = this.roomPrice.ToString();
			this.motelPriceText[0].GetComponent<TextMeshPro>().text = Language.Get("motel_price_hun_01", "Inspector_UI");
			this.motelPriceText[1].GetComponent<TextMeshPro>().text = Language.Get("motel_price_hun_02", "Inspector_UI");
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			this.roomPrice += 15;
			this.motelPrice.GetComponent<TextMeshPro>().text = this.roomPrice.ToString();
			this.motelPriceText[0].GetComponent<TextMeshPro>().text = Language.Get("motel_price_yugo_01", "Inspector_UI");
			this.motelPriceText[1].GetComponent<TextMeshPro>().text = Language.Get("motel_price_yugo_02", "Inspector_UI");
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			this.roomPrice += 20;
			this.motelPrice.GetComponent<TextMeshPro>().text = this.roomPrice.ToString();
			this.motelPriceText[0].GetComponent<TextMeshPro>().text = Language.Get("motel_price_bul_01", "Inspector_UI");
			this.motelPriceText[1].GetComponent<TextMeshPro>().text = Language.Get("motel_price_bul_02", "Inspector_UI");
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			this.roomPrice += 25;
			this.motelPrice.GetComponent<TextMeshPro>().text = this.roomPrice.ToString();
			this.motelPriceText[0].GetComponent<TextMeshPro>().text = Language.Get("motel_price_turk_01", "Inspector_UI");
			this.motelPriceText[1].GetComponent<TextMeshPro>().text = Language.Get("motel_price_turk_02", "Inspector_UI");
		}
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x000AC72A File Offset: 0x000AAB2A
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.glowTarget.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x000AC749 File Offset: 0x000AAB49
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.glowTarget.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000ADC RID: 2780
	private GameObject _camera;

	// Token: 0x04000ADD RID: 2781
	public Transform roomKeySpawnLoc;

	// Token: 0x04000ADE RID: 2782
	public GameObject director;

	// Token: 0x04000ADF RID: 2783
	public GameObject player;

	// Token: 0x04000AE0 RID: 2784
	public GameObject shopKeeper;

	// Token: 0x04000AE1 RID: 2785
	public GameObject shopKeeperMouth;

	// Token: 0x04000AE2 RID: 2786
	public GameObject motelPrice;

	// Token: 0x04000AE3 RID: 2787
	public GameObject[] motelPriceText;

	// Token: 0x04000AE4 RID: 2788
	public GameObject parkingTrigger;

	// Token: 0x04000AE5 RID: 2789
	public AudioClip[] audioTalking;

	// Token: 0x04000AE6 RID: 2790
	public bool isWelcomed;

	// Token: 0x04000AE7 RID: 2791
	public int roomNumber;

	// Token: 0x04000AE8 RID: 2792
	public GameObject[] roomKey;

	// Token: 0x04000AE9 RID: 2793
	public GameObject[] roomDoors;

	// Token: 0x04000AEA RID: 2794
	public GameObject[] roomBeds;

	// Token: 0x04000AEB RID: 2795
	public bool hasPaid;

	// Token: 0x04000AEC RID: 2796
	public bool hasGreeted;

	// Token: 0x04000AED RID: 2797
	public int roomPrice;

	// Token: 0x04000AEE RID: 2798
	public bool hasSlept;

	// Token: 0x04000AEF RID: 2799
	private GameObject spawnedRoomKey;

	// Token: 0x04000AF0 RID: 2800
	public GameObject[] roomDoor;

	// Token: 0x04000AF1 RID: 2801
	public GameObject musicBox;

	// Token: 0x04000AF2 RID: 2802
	private GameObject wallet;

	// Token: 0x04000AF3 RID: 2803
	private bool isGlowing;

	// Token: 0x04000AF4 RID: 2804
	public Material startMaterial;

	// Token: 0x04000AF5 RID: 2805
	public Material glowMaterial;

	// Token: 0x04000AF6 RID: 2806
	public GameObject glowTarget;

	// Token: 0x04000AF7 RID: 2807
	public bool isTalking;

	// Token: 0x04000AF8 RID: 2808
	public bool textFinished;

	// Token: 0x04000AF9 RID: 2809
	public List<string> textQueue = new List<string>();

	// Token: 0x04000AFA RID: 2810
	public string currentConvoItem;

	// Token: 0x04000AFB RID: 2811
	public string interruptConvoItem;

	// Token: 0x04000AFC RID: 2812
	public string dialogueConvoItem;

	// Token: 0x04000AFD RID: 2813
	public List<string> speechStack = new List<string>();

	// Token: 0x04000AFE RID: 2814
	public bool inputRestrictDropItem;

	// Token: 0x04000AFF RID: 2815
	public string interruptChecker = string.Empty;

	// Token: 0x04000B00 RID: 2816
	public string dialogueChecker = string.Empty;

	// Token: 0x04000B01 RID: 2817
	public bool canSpeak;

	// Token: 0x04000B02 RID: 2818
	public bool interruptSpeechComplete;

	// Token: 0x04000B03 RID: 2819
	public bool dialogueSpeechComplete;

	// Token: 0x04000B04 RID: 2820
	public Transform lobbyNode;

	// Token: 0x04000B05 RID: 2821
	public Transform[] doorNodes;

	// Token: 0x04000B06 RID: 2822
	public Transform[] roomNodes;

	// Token: 0x04000B07 RID: 2823
	public bool carParked;

	// Token: 0x04000B08 RID: 2824
	public string characterName = "ui_name_04";

	// Token: 0x04000B09 RID: 2825
	public bool hasSaidBye;
}
