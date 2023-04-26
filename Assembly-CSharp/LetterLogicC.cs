using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000BF RID: 191
public class LetterLogicC : MonoBehaviour
{
	// Token: 0x060006F2 RID: 1778 RVA: 0x0008A594 File Offset: 0x00088994
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		LetterLogic component = base.GetComponent<LetterLogic>();
		component.textObjs.Copy(ref this.textObjs);
		component.textStrings.Copy(ref this.textStrings);
		this.carLogic = (component.carLogic as GameObject);
		this.letter = (component.letter as GameObject);
		component.localisedLetters.Copy(ref this.localisedLetters);
		this.letterID = component.letterID;
		this.holdingPosition = component.holdingPosition;
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		component.glowTargets.Copy(ref this.glowTargets);
		this.isBookOpen = component.isBookOpen;
		this.isLetterZoomed = component.isLetterZoomed;
		component.envelopePos.Copy(ref this.envelopePos);
		this.dropOffPoint = component.dropOffPoint;
		this.envelope = (component.envelope as GameObject);
		this.audioLetterOpen = component.audioLetterOpen;
		this.mousePosSens = component.mousePosSens;
		this.wantedPosSens = component.wantedPosSens;
		component.enabled = false;
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x0008A6BC File Offset: 0x00088ABC
	private void Start()
	{
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this._camera = Camera.main.gameObject;
		this.startMaterial = this.glowTargets[0].GetComponent<Renderer>().material;
		base.transform.parent = this.dropOffPoint;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
	}

	// Token: 0x060006F4 RID: 1780 RVA: 0x0008A734 File Offset: 0x00088B34
	public void LocaliseTexts()
	{
		LanguageCode languageCode = Language.CurrentLanguage();
		this.letter.active = false;
		if (languageCode == LanguageCode.EN)
		{
			this.letter = this.localisedLetters[0];
		}
		else if (languageCode == LanguageCode.FR)
		{
			this.letter = this.localisedLetters[1];
		}
		else if (languageCode == LanguageCode.IT)
		{
			this.letter = this.localisedLetters[2];
		}
		else if (languageCode == LanguageCode.DE)
		{
			this.letter = this.localisedLetters[3];
		}
		else if (languageCode == LanguageCode.ES)
		{
			this.letter = this.localisedLetters[4];
		}
		else if (languageCode == LanguageCode.PT_BR)
		{
			this.letter = this.localisedLetters[5];
		}
		else if (languageCode == LanguageCode.TR)
		{
			this.letter = this.localisedLetters[6];
		}
		else if (languageCode == LanguageCode.HU)
		{
			this.letter = this.localisedLetters[7];
		}
		else if (languageCode == LanguageCode.ZH)
		{
			this.letter = this.localisedLetters[8];
		}
		else if (languageCode == LanguageCode.NL)
		{
			this.letter = this.localisedLetters[9];
		}
		else if (languageCode == LanguageCode.FI)
		{
			this.letter = this.localisedLetters[10];
		}
		else if (languageCode == LanguageCode.JA)
		{
			this.letter = this.localisedLetters[11];
		}
		else if (languageCode == LanguageCode.PL)
		{
			this.letter = this.localisedLetters[12];
		}
		else if (languageCode == LanguageCode.RU)
		{
			this.letter = this.localisedLetters[13];
		}
		else if (languageCode == LanguageCode.SK)
		{
			this.letter = this.localisedLetters[14];
		}
		else if (languageCode == LanguageCode.HR)
		{
			this.letter = this.localisedLetters[15];
		}
		else if (languageCode == LanguageCode.RO)
		{
			this.letter = this.localisedLetters[16];
		}
		else if (languageCode == LanguageCode.KO)
		{
			this.letter = this.localisedLetters[17];
		}
		else if (languageCode == LanguageCode.NO)
		{
			this.letter = this.localisedLetters[18];
		}
		this.letter.active = true;
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x0008A980 File Offset: 0x00088D80
	[ContextMenu("Read Letter")]
	public void PickUp()
	{
		if (!this.isGlowing)
		{
			return;
		}
		this.StopGlow();
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		MainMenuC.Global.UnlockLetter(this.letterID);
		this.LocaliseTexts();
		this._camera.SendMessage("ForceZoomOut");
		this.TweenBookPos();
		Transform parent = this._camera.transform.parent;
		parent.GetComponent<Rigidbody>().useGravity = false;
		parent.GetComponent<Rigidbody>().isKinematic = false;
		parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
		parent.GetComponent<Rigidbody>().isKinematic = true;
		this._camera.GetComponent<MouseLook>().enabled = false;
		this._camera.GetComponent<DragRigidbodyC>().enabled = false;
		parent.gameObject.GetComponent<MouseLook>().enabled = false;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = false;
		base.gameObject.GetComponent<Collider>().enabled = false;
		MainMenuC.Global.lockCursor = false;
		Screen.lockCursor = false;
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x0008AA88 File Offset: 0x00088E88
	public void TweenBookPos()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.holdingPosition,
			"time",
			1.0,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"FlipBook",
			"oncompletetarget",
			base.gameObject
		}));
		Vector3 vector = new Vector3(this.holdingPosition.eulerAngles.x - 180f, this.holdingPosition.eulerAngles.y, this.holdingPosition.eulerAngles.z - 180f);
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			vector,
			"time",
			1.0,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x0008ABA4 File Offset: 0x00088FA4
	public void FlipBook()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.holdingPosition,
			"delay",
			1.0,
			"time",
			1.0,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"OpenBook",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x0008AC40 File Offset: 0x00089040
	public IEnumerator OpenBook()
	{
		base.transform.position = this.holdingPosition.position;
		this.isBookOpen = true;
		base.gameObject.GetComponent<Animator>().SetBool("open", true);
		base.GetComponent<AudioSource>().PlayOneShot(this.audioLetterOpen, 1f);
		yield return new WaitForSeconds(1f);
		if (!this.isBookOpen)
		{
			yield break;
		}
		this.RevealLetter();
		yield break;
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x0008AC5C File Offset: 0x0008905C
	public void RevealLetter()
	{
		iTween.MoveTo(this.envelope, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[1],
			"delay",
			0.5,
			"time",
			1.0,
			"islocal",
			true,
			"easetype",
			"easeinquad",
			"oncomplete",
			"LetterZoom",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x0008AD1C File Offset: 0x0008911C
	public void LetterZoom()
	{
		iTween.MoveTo(this.letter, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[2],
			"delay",
			0.0,
			"time",
			0.4,
			"islocal",
			true,
			"easetype",
			"easeinquad"
		}));
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x0008ADB8 File Offset: 0x000891B8
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			for (int i = 0; i < this.glowTargets.Length; i++)
			{
				this.glowTargets[i].GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
		if ((Input.GetMouseButtonDown(1) && this.isBookOpen) || (Input.GetButtonDown("Cancel") && this.isBookOpen))
		{
			this.isBookOpen = false;
			iTween.Stop(base.gameObject);
			this.CloseLetter1();
			base.gameObject.GetComponent<Collider>().enabled = true;
		}
		if (this.isLetterZoomed)
		{
			Vector3 mousePosition = Input.mousePosition;
			float y = mousePosition.y / (float)this.mousePosSens;
			Vector3 vector = this._camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mousePosition.x, y, 10f));
			this.letter.transform.localPosition.SetY(Mathf.Clamp(vector.y / (float)this.wantedPosSens, -0.22f, 0.18f));
		}
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x0008AEF0 File Offset: 0x000892F0
	public void CloseLetter1()
	{
		this.isLetterZoomed = false;
		iTween.MoveTo(this.letter, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[0],
			"delay",
			0.0,
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeinquad",
			"oncomplete",
			"CloseLetter2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0008AFB8 File Offset: 0x000893B8
	public void CloseLetter2()
	{
		iTween.MoveTo(this.envelope, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[0],
			"delay",
			0.0,
			"time",
			1.0,
			"islocal",
			true,
			"easetype",
			"easeinquad",
			"oncomplete",
			"CloseEnvelope",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0008B078 File Offset: 0x00089478
	public void CloseEnvelope()
	{
		base.gameObject.GetComponent<Animator>().SetBool("open", false);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.dropOffPoint,
			"delay",
			0.5,
			"time",
			1.0,
			"easetype",
			"easeinquad",
			"oncomplete",
			"ResumeCamera",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.dropOffPoint,
			"delay",
			0.5,
			"time",
			1.0,
			"easetype",
			"easeinquad"
		}));
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0008B194 File Offset: 0x00089594
	public void ResumeCamera()
	{
		MainMenuC.Global.lockCursor = true;
		Screen.lockCursor = true;
		Transform parent = this._camera.transform.parent;
		this._camera.GetComponent<MouseLook>().enabled = true;
		if (!parent.GetComponent<RigidbodyControllerC>().isSat)
		{
			parent.GetComponent<Rigidbody>().isKinematic = false;
		}
		else
		{
			parent.GetComponent<Rigidbody>().isKinematic = true;
		}
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		parent.gameObject.GetComponent<MouseLook>().enabled = true;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = true;
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0008B234 File Offset: 0x00089634
	public void RaycastEnter()
	{
		if (!OpenBriefcaseLogicC.isOpen)
		{
			return;
		}
		this.isGlowing = true;
		for (int i = 0; i < this.glowTargets.Length; i++)
		{
			this.glowTargets[i].GetComponent<Renderer>().material = this.glowMaterial;
		}
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0008B284 File Offset: 0x00089684
	public void RaycastExit()
	{
		this.isGlowing = false;
		for (int i = 0; i < this.glowTargets.Length; i++)
		{
			this.glowTargets[i].GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0008B2CC File Offset: 0x000896CC
	public void StopGlow()
	{
		this.isGlowing = false;
		for (int i = 0; i < this.glowTargets.Length; i++)
		{
			this.glowTargets[i].GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x04000968 RID: 2408
	public GameObject[] textObjs;

	// Token: 0x04000969 RID: 2409
	public string[] textStrings;

	// Token: 0x0400096A RID: 2410
	public GameObject carLogic;

	// Token: 0x0400096B RID: 2411
	public GameObject letter;

	// Token: 0x0400096C RID: 2412
	public GameObject[] localisedLetters;

	// Token: 0x0400096D RID: 2413
	public int letterID;

	// Token: 0x0400096E RID: 2414
	private GameObject _camera;

	// Token: 0x0400096F RID: 2415
	public Transform holdingPosition;

	// Token: 0x04000970 RID: 2416
	public Material startMaterial;

	// Token: 0x04000971 RID: 2417
	public Material glowMaterial;

	// Token: 0x04000972 RID: 2418
	public GameObject[] glowTargets;

	// Token: 0x04000973 RID: 2419
	public bool isGlowing;

	// Token: 0x04000974 RID: 2420
	public bool isBookOpen;

	// Token: 0x04000975 RID: 2421
	public bool isLetterZoomed;

	// Token: 0x04000976 RID: 2422
	public Vector3[] envelopePos;

	// Token: 0x04000977 RID: 2423
	public Transform dropOffPoint;

	// Token: 0x04000978 RID: 2424
	public GameObject envelope;

	// Token: 0x04000979 RID: 2425
	public AudioClip audioLetterOpen;

	// Token: 0x0400097A RID: 2426
	public int mousePosSens;

	// Token: 0x0400097B RID: 2427
	public int wantedPosSens;
}
