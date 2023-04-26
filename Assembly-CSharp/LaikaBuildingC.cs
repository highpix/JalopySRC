using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class LaikaBuildingC : MonoBehaviour
{
	// Token: 0x060006DC RID: 1756 RVA: 0x000895EC File Offset: 0x000879EC
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.director = GameObject.FindWithTag("Director");
		this.shopTeller.GetComponent<Animator>().SetBool("driving", false);
		this.timeBetweenSounds = UnityEngine.Random.Range(0, 15);
		this.MusicPlay();
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x00089644 File Offset: 0x00087A44
	private IEnumerator MusicPlay()
	{
		for (;;)
		{
			yield return new WaitForSeconds((float)this.timeBetweenSounds);
			this.speakers.GetComponent<AudioSource>().Play();
			this.timeBetweenSounds = UnityEngine.Random.Range(70, 100);
		}
		yield break;
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x00089660 File Offset: 0x00087A60
	public void PlayerTriggerEnter()
	{
		if (!this.isWelcomed && !this.hasGreeted && !this.isTalking)
		{
			this.isWelcomed = true;
			base.StartCoroutine("Welcome");
		}
		if (!this.isWelcomed && this.hasGreeted && !this.isTalking)
		{
			this.isWelcomed = true;
			base.StartCoroutine("WelcomeAgain");
		}
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x000896D5 File Offset: 0x00087AD5
	public void PlayerTriggerExit()
	{
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x000896D8 File Offset: 0x00087AD8
	private IEnumerator ClearDialogue(float delay)
	{
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().text = string.Empty;
		yield return new WaitForSeconds(delay);
		this.director.GetComponent<DirectorC>().BubbleOff();
		yield break;
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x000896FC File Offset: 0x00087AFC
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

	// Token: 0x060006E2 RID: 1762 RVA: 0x000897B8 File Offset: 0x00087BB8
	private IEnumerator DialogueSpeech()
	{
		base.StopCoroutine("StopInputRestrict");
		this.dialogueSpeechComplete = false;
		this.canSpeak = false;
		for (int i = 0; i < this.speechStack.Count; i++)
		{
			this.textFinished = false;
			yield return new WaitForSeconds(0.2f);
			this.director.GetComponent<DirectorC>().BubbleOn(this.shopTellerMouth.transform, this.characterName);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().word = this.speechStack[i];
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			int rnd = UnityEngine.Random.Range(0, this.audioTalking.Length);
			this.shopTeller.GetComponent<AudioSource>().clip = this.audioTalking[rnd];
			this.shopTeller.GetComponent<AudioSource>().Play();
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			while (this.inputRestrictDropItem)
			{
				yield return new WaitForEndOfFrame();
			}
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForEndOfFrame();
		}
		this.isTalking = false;
		this.dialogueSpeechComplete = true;
		base.StartCoroutine("RemoveCurrentItemFromList");
		this.dialogueConvoItem = string.Empty;
		base.StartCoroutine("ResumeTalkingFromList");
		yield break;
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x000897D4 File Offset: 0x00087BD4
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

	// Token: 0x060006E4 RID: 1764 RVA: 0x00089828 File Offset: 0x00087C28
	public void ResumeTalkingFromList()
	{
		if (this.textQueue.Count > 0)
		{
			for (int i = 0; i < this.textQueue.Count; i++)
			{
				base.StopCoroutine(this.textQueue[i]);
			}
			base.StartCoroutine(this.textQueue[0]);
		}
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x00089888 File Offset: 0x00087C88
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

	// Token: 0x060006E6 RID: 1766 RVA: 0x000898E0 File Offset: 0x00087CE0
	public void StopInputRestrictStopper()
	{
		base.StopCoroutine("StopInputRestrict");
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x000898F0 File Offset: 0x00087CF0
	private IEnumerator StopInputRestrict()
	{
		yield return new WaitForSeconds(0.5f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x0008990B File Offset: 0x00087D0B
	public void TextFinished()
	{
		this.textFinished = true;
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x00089914 File Offset: 0x00087D14
	private IEnumerator Welcome()
	{
		this.dialogueChecker = "Welcome";
		this.DialogueCheck();
		this.hasEntered = true;
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.hasGreeted = true;
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("laika_wel_01", "Speech"));
			if (UnityEngine.Random.Range(0, 1) == 0)
			{
				this.speechStack.Add(Language.Get("laika_wel_02", "Speech"));
			}
			else
			{
				this.speechStack.Add(Language.Get("laika_wel_02b", "Speech"));
			}
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x00089930 File Offset: 0x00087D30
	private IEnumerator WelcomeAgain()
	{
		this.dialogueChecker = "WelcomeAgain";
		this.DialogueCheck();
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			if (this.hasEntered)
			{
				this.speechStack.Clear();
				int num = UnityEngine.Random.Range(0, 2);
				if (num == 0)
				{
					this.speechStack.Add(Language.Get("laika_wel_05", "Speech"));
				}
				else if (num == 1)
				{
					this.speechStack.Add(Language.Get("laika_wel_06", "Speech"));
				}
				else if (num == 2)
				{
					this.speechStack.Add(Language.Get("laika_wel_07", "Speech"));
				}
				base.StartCoroutine("DialogueSpeech");
				yield break;
			}
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("laika_wel_04", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.hasEntered = true;
		}
		yield break;
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x0008994B File Offset: 0x00087D4B
	public void PurchasedDoor()
	{
		base.StartCoroutine(this.BoughtDoor());
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x0008995C File Offset: 0x00087D5C
	private IEnumerator BoughtDoor()
	{
		this.canSpeak = true;
		this.dialogueChecker = "Door Info";
		this.DialogueCheck();
		this.hasEntered = true;
		yield return new WaitForSeconds(0.1f);
		this.hasGreeted = true;
		this.speechStack.Clear();
		this.speechStack.Add("We have replaced your door, and took the broken one to keep, thank you!");
		base.StartCoroutine("DialogueSpeech");
		yield break;
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x00089978 File Offset: 0x00087D78
	private IEnumerator PartsOrdered()
	{
		this.dialogueChecker = "PartsOrdered";
		this.DialogueCheck();
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak && this.hasEntered)
		{
			this.speechStack.Clear();
			int num = UnityEngine.Random.Range(0, 2);
			if (num == 0)
			{
				this.speechStack.Add(Language.Get("laika_order_01", "Speech"));
			}
			else if (num == 1)
			{
				this.speechStack.Add(Language.Get("laika_order_02", "Speech"));
			}
			else if (num == 2)
			{
				this.speechStack.Add(Language.Get("laika_order_03", "Speech"));
			}
			base.StartCoroutine("DialogueSpeech");
			yield break;
		}
		yield break;
	}

	// Token: 0x04000950 RID: 2384
	private GameObject _camera;

	// Token: 0x04000951 RID: 2385
	public GameObject director;

	// Token: 0x04000952 RID: 2386
	public GameObject shopTeller;

	// Token: 0x04000953 RID: 2387
	public GameObject shopTellerMouth;

	// Token: 0x04000954 RID: 2388
	public bool isWelcomed;

	// Token: 0x04000955 RID: 2389
	public bool hasGreeted;

	// Token: 0x04000956 RID: 2390
	public bool hasEntered;

	// Token: 0x04000957 RID: 2391
	public int timeBetweenSounds;

	// Token: 0x04000958 RID: 2392
	public GameObject speakers;

	// Token: 0x04000959 RID: 2393
	public AudioClip[] audioTalking = new AudioClip[0];

	// Token: 0x0400095A RID: 2394
	public bool isTalking;

	// Token: 0x0400095B RID: 2395
	public bool textFinished;

	// Token: 0x0400095C RID: 2396
	public List<string> textQueue = new List<string>();

	// Token: 0x0400095D RID: 2397
	public string currentConvoItem;

	// Token: 0x0400095E RID: 2398
	public string interruptConvoItem;

	// Token: 0x0400095F RID: 2399
	public string dialogueConvoItem;

	// Token: 0x04000960 RID: 2400
	public List<string> speechStack = new List<string>();

	// Token: 0x04000961 RID: 2401
	public bool inputRestrictDropItem;

	// Token: 0x04000962 RID: 2402
	public string interruptChecker = string.Empty;

	// Token: 0x04000963 RID: 2403
	public string dialogueChecker = string.Empty;

	// Token: 0x04000964 RID: 2404
	public bool canSpeak;

	// Token: 0x04000965 RID: 2405
	public bool interruptSpeechComplete;

	// Token: 0x04000966 RID: 2406
	public bool dialogueSpeechComplete;

	// Token: 0x04000967 RID: 2407
	public string characterName = "ui_name_06";
}
