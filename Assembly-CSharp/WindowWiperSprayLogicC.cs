using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000130 RID: 304
public class WindowWiperSprayLogicC : MonoBehaviour
{
	// Token: 0x06000C58 RID: 3160 RVA: 0x0012B0AF File Offset: 0x001294AF
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000C59 RID: 3161 RVA: 0x0012B0D8 File Offset: 0x001294D8
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000C5A RID: 3162 RVA: 0x0012B130 File Offset: 0x00129530
	public IEnumerator Trigger()
	{
		GameObject uncleObj = base.transform.root.gameObject.GetComponent<CarControleScriptC>().uncleObj;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null && (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.5f);
			iTween.Stop(base.gameObject.transform.parent.gameObject, "RotateTo");
			iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.position[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType
			}));
			yield return new WaitForSeconds(this.timeToComplete);
			iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.position[0],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType2
			}));
			yield break;
		}
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 1;
			iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.position[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType,
				"oncomplete",
				"ReturnAction",
				"oncompletetarget",
				base.gameObject
			}));
			this.carLogic.GetComponent<CarLogicC>().StartCoroutine("WaterSpray");
			if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null && !this.carLogic.GetComponent<CarLogicC>().windowWipersOn)
			{
				base.StartCoroutine(this.windowWiperTarget1.GetComponent<WiperLogicC>().WaterWipe());
				base.StartCoroutine(this.windowWiperTarget2.GetComponent<WiperLogicC>().WaterWipe());
			}
			yield break;
		}
		if (this.currentPos == 1)
		{
			yield break;
		}
		yield break;
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x0012B14C File Offset: 0x0012954C
	public IEnumerator ReturnAction()
	{
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		yield return new WaitForSeconds(1.3f);
		this.currentPos = 0;
		yield break;
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x0012B167 File Offset: 0x00129567
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x0012B195 File Offset: 0x00129595
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04001106 RID: 4358
	public GameObject carLogic;

	// Token: 0x04001107 RID: 4359
	public GameObject windowWiperTarget1;

	// Token: 0x04001108 RID: 4360
	public GameObject windowWiperTarget2;

	// Token: 0x04001109 RID: 4361
	public float timeToComplete = 2.05f;

	// Token: 0x0400110A RID: 4362
	public int currentPos;

	// Token: 0x0400110B RID: 4363
	public Vector3[] position;

	// Token: 0x0400110C RID: 4364
	public AudioClip audioSample;

	// Token: 0x0400110D RID: 4365
	public Material glowMaterial;

	// Token: 0x0400110E RID: 4366
	public Material startMaterial;

	// Token: 0x0400110F RID: 4367
	public string easeType = "easeoutelastic";

	// Token: 0x04001110 RID: 4368
	public string easeType2 = "easeoutelastic";

	// Token: 0x04001111 RID: 4369
	public AudioClip errorAudio;

	// Token: 0x04001112 RID: 4370
	private bool isGlowing;
}
