using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A3 RID: 163
public class DoorKnockingC : MonoBehaviour
{
	// Token: 0x0600054A RID: 1354 RVA: 0x00059726 File Offset: 0x00057B26
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.GetComponent<Renderer>().material;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x00059749 File Offset: 0x00057B49
	public void SetDoorToShady()
	{
		this.personalityType = 1;
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x00059752 File Offset: 0x00057B52
	public void SetDoorToAngry()
	{
		this.personalityType = 2;
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x0005975C File Offset: 0x00057B5C
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x000597A0 File Offset: 0x00057BA0
	public void Trigger()
	{
		if (this.doorHandle != null)
		{
			if (!this.doorHandle.GetComponent<EnvironmentDoorsC>().isLocked)
			{
				base.StartCoroutine(this.doorHandle.GetComponent<EnvironmentDoorsC>().Trigger());
				return;
			}
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().open)
			{
				base.StartCoroutine(this.doorHandle.GetComponent<EnvironmentDoorsC>().Trigger());
				return;
			}
		}
		if (this.knockTimerRestrict)
		{
			return;
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.knockAudio, 1f);
		base.StartCoroutine(this.KnockTimeRestrictGo());
		if (this.personalityType == 1)
		{
			base.StartCoroutine(this.SketchResponse());
		}
		else if (this.personalityType == 2)
		{
			base.StartCoroutine(this.AngryResponse());
		}
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x00059880 File Offset: 0x00057C80
	public IEnumerator KnockTimeRestrictGo()
	{
		this.knockTimerRestrict = true;
		this.knockCount++;
		yield return new WaitForSeconds(this.timerRestrict);
		this.knockTimerRestrict = false;
		yield break;
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x0005989C File Offset: 0x00057C9C
	public void RaycastEnter()
	{
		if (this.doorHandle != null && (this.doorHandle.GetComponent<EnvironmentDoorsC>().open || !this.doorHandle.GetComponent<EnvironmentDoorsC>().isLocked))
		{
			if (!this._camera.GetComponent<DragRigidbodyC>().cursors[2].gameObject.active)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing = true;
				if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle != null)
				{
					this.doorHandle.GetComponent<EnvironmentDoorsC>().handle.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().glowMaterial;
				}
				if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2 != null)
				{
					this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().glowMaterial;
				}
				return;
			}
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing = false;
				if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle != null)
				{
					this.doorHandle.GetComponent<EnvironmentDoorsC>().handle.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial;
				}
				if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2 != null)
				{
					this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial2;
				}
				return;
			}
		}
		this.isGlowing = true;
		base.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x00059A6C File Offset: 0x00057E6C
	public void RaycastExit()
	{
		if (this.doorHandle != null && (this.doorHandle.GetComponent<EnvironmentDoorsC>().open || !this.doorHandle.GetComponent<EnvironmentDoorsC>().isLocked))
		{
			this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing = false;
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle != null)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().handle.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial;
			}
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2 != null)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial2;
			}
		}
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x00059B68 File Offset: 0x00057F68
	public IEnumerator ClearDialogue(float delay)
	{
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().text = string.Empty;
		yield return new WaitForSeconds(delay);
		this.director.GetComponent<DirectorC>().BubbleOff();
		yield break;
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00059B8C File Offset: 0x00057F8C
	public void ClearDialogueInstant()
	{
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		this.director.GetComponent<DirectorC>().BubbleOff();
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x00059BEC File Offset: 0x00057FEC
	public IEnumerator DialogueCheck()
	{
		if (this.dialogueConvoItem != string.Empty && this.dialogueConvoItem != this.dialogueChecker)
		{
			this.canSpeak = false;
			this.AddItemToStartOfQueue();
			yield break;
		}
		yield return new WaitForEndOfFrame();
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StopCoroutine("DialogueSpeech");
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StopTypeText();
		this.isTalking = true;
		this.dialogueConvoItem = this.dialogueChecker;
		this.dialogueChecker = string.Empty;
		this.textFinished = false;
		this.canSpeak = true;
		yield break;
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x00059C08 File Offset: 0x00058008
	public IEnumerator DialogueSpeech()
	{
		base.StopCoroutine("StopInputRestrict");
		this.dialogueSpeechComplete = false;
		this.canSpeak = false;
		for (int i = 0; i < this.speechStack.Count; i++)
		{
			this.textFinished = false;
			yield return new WaitForSeconds(0.2f);
			if (this.director == null)
			{
				this.director = GameObject.FindWithTag("Director");
			}
			this.director.GetComponent<DirectorC>().BubbleOn(base.transform, this.characterName);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().word = this.speechStack[i];
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
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

	// Token: 0x06000556 RID: 1366 RVA: 0x00059C24 File Offset: 0x00058024
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

	// Token: 0x06000557 RID: 1367 RVA: 0x00059C7C File Offset: 0x0005807C
	public void StopInputRestrictStopper()
	{
		base.StopCoroutine("StopInputRestrict");
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x00059C8C File Offset: 0x0005808C
	public IEnumerator StopInputRestrict()
	{
		yield return new WaitForSeconds(0.5f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x00059CA7 File Offset: 0x000580A7
	public void TextFinished()
	{
		this.textFinished = true;
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x00059CB0 File Offset: 0x000580B0
	public IEnumerator AngryResponse()
	{
		this.dialogueChecker = "AngryResponse";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			int rndSpeech = UnityEngine.Random.Range(0, 3);
			if (rndSpeech == 0)
			{
				this.speechStack.Add(Language.Get("motel_door_angry_01", "Speech"));
			}
			else if (rndSpeech == 1)
			{
				this.speechStack.Add(Language.Get("motel_door_angry_02", "Speech"));
			}
			else if (rndSpeech == 2)
			{
				this.speechStack.Add(Language.Get("motel_door_angry_03", "Speech"));
			}
			yield return new WaitForEndOfFrame();
			base.StartCoroutine("DialogueSpeech");
			this.director.GetComponent<DirectorC>().AnnoyedGuest();
		}
		yield break;
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x00059CCC File Offset: 0x000580CC
	public IEnumerator SketchResponse()
	{
		this.dialogueChecker = "SketchResponse";
		base.StartCoroutine(this.DialogueCheck());
		yield return new WaitForSeconds(0.1f);
		if (!this.hasGivenMoney)
		{
			if (this.canSpeak)
			{
				this.speechStack.Clear();
				int rndSpeech = UnityEngine.Random.Range(0, 3);
				if (rndSpeech == 0)
				{
					this.speechStack.Add(Language.Get("motel_door_sketch_01", "Speech"));
				}
				else if (rndSpeech == 1)
				{
					this.speechStack.Add(Language.Get("motel_door_sketch_02", "Speech"));
				}
				else if (rndSpeech == 2)
				{
					this.speechStack.Add(Language.Get("motel_door_sketch_03", "Speech"));
				}
				yield return new WaitForEndOfFrame();
				base.StartCoroutine(this.DialogueSpeech());
				this.SlideCashUnderDoor();
				this.hasGivenMoney = true;
			}
		}
		else if (this.canSpeak)
		{
			this.speechStack.Clear();
			int rndSpeech2 = UnityEngine.Random.Range(0, 3);
			if (rndSpeech2 == 0)
			{
				this.speechStack.Add(Language.Get("motel_door_sketch_04", "Speech"));
			}
			else if (rndSpeech2 == 1)
			{
				this.speechStack.Add(Language.Get("motel_door_sketch_05", "Speech"));
			}
			else if (rndSpeech2 == 2)
			{
				this.speechStack.Add(Language.Get("motel_door_sketch_06", "Speech"));
			}
			yield return new WaitForEndOfFrame();
			base.StartCoroutine(this.DialogueSpeech());
			this.director.GetComponent<DirectorC>().AnnoyedGuest();
		}
		yield break;
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x00059CE8 File Offset: 0x000580E8
	public void SlideCashUnderDoor()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.cashPrefab, this.cashSpawnLoc.position, this.cashSpawnLoc.rotation);
		gameObject.transform.parent = this.cashSpawnLoc;
		gameObject.transform.localScale = Vector3.one;
		if (this.director.GetComponent<RouteGeneratorC>().borderOpen)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
			{
				gameObject.GetComponent<LooseCashC>().cashValue = 20;
				gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				gameObject.GetComponent<LooseCashC>().cashValue = 20;
				gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				gameObject.GetComponent<LooseCashC>().cashValue = 25;
				gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				gameObject.GetComponent<LooseCashC>().cashValue = 30;
				gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
			{
				gameObject.GetComponent<LooseCashC>().cashValue = 35;
				gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
			{
				gameObject.GetComponent<LooseCashC>().cashValue = 40;
				gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
			{
				gameObject.GetComponent<LooseCashC>().cashValue = 45;
				gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			gameObject.GetComponent<LooseCashC>().cashValue = 20;
			gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			gameObject.GetComponent<LooseCashC>().cashValue = 25;
			gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			gameObject.GetComponent<LooseCashC>().cashValue = 30;
			gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			gameObject.GetComponent<LooseCashC>().cashValue = 35;
			gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			gameObject.GetComponent<LooseCashC>().cashValue = 40;
			gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			gameObject.GetComponent<LooseCashC>().cashValue = 45;
			gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			gameObject.GetComponent<LooseCashC>().cashValue = 45;
			gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = gameObject.GetComponent<LooseCashC>().cashValue.ToString();
		}
		iTween.MoveTo(gameObject, iTween.Hash(new object[]
		{
			"position",
			this.cashTarget,
			"time",
			1.0,
			"easetype",
			"easeoutexpo"
		}));
	}

	// Token: 0x040007C7 RID: 1991
	private GameObject _camera;

	// Token: 0x040007C8 RID: 1992
	public Material startMaterial;

	// Token: 0x040007C9 RID: 1993
	public Material glowMaterial;

	// Token: 0x040007CA RID: 1994
	public GameObject doorHandle;

	// Token: 0x040007CB RID: 1995
	private bool isGlowing;

	// Token: 0x040007CC RID: 1996
	private bool knockTimerRestrict;

	// Token: 0x040007CD RID: 1997
	public float timerRestrict;

	// Token: 0x040007CE RID: 1998
	public int knockCount;

	// Token: 0x040007CF RID: 1999
	public AudioClip knockAudio;

	// Token: 0x040007D0 RID: 2000
	public Transform cashSpawnLoc;

	// Token: 0x040007D1 RID: 2001
	public Transform cashTarget;

	// Token: 0x040007D2 RID: 2002
	public GameObject cashPrefab;

	// Token: 0x040007D3 RID: 2003
	public int personalityType;

	// Token: 0x040007D4 RID: 2004
	private GameObject director;

	// Token: 0x040007D5 RID: 2005
	public bool isTalking;

	// Token: 0x040007D6 RID: 2006
	public bool textFinished;

	// Token: 0x040007D7 RID: 2007
	public List<string> textQueue = new List<string>();

	// Token: 0x040007D8 RID: 2008
	public string currentConvoItem;

	// Token: 0x040007D9 RID: 2009
	public string interruptConvoItem;

	// Token: 0x040007DA RID: 2010
	public string dialogueConvoItem;

	// Token: 0x040007DB RID: 2011
	public List<string> speechStack = new List<string>();

	// Token: 0x040007DC RID: 2012
	public bool inputRestrictDropItem;

	// Token: 0x040007DD RID: 2013
	public string interruptChecker = string.Empty;

	// Token: 0x040007DE RID: 2014
	public string dialogueChecker = string.Empty;

	// Token: 0x040007DF RID: 2015
	public bool canSpeak;

	// Token: 0x040007E0 RID: 2016
	public bool interruptSpeechComplete;

	// Token: 0x040007E1 RID: 2017
	public bool dialogueSpeechComplete;

	// Token: 0x040007E2 RID: 2018
	private bool hasGivenMoney;

	// Token: 0x040007E3 RID: 2019
	public string characterName = "ui_name_07";
}
