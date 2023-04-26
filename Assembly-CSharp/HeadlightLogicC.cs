using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000115 RID: 277
public class HeadlightLogicC : MonoBehaviour
{
	// Token: 0x06000AE8 RID: 2792 RVA: 0x000FE682 File Offset: 0x000FCA82
	private void Start()
	{
		this.director = GameObject.FindWithTag("Director");
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000AE9 RID: 2793 RVA: 0x000FE6BC File Offset: 0x000FCABC
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000AEA RID: 2794 RVA: 0x000FE714 File Offset: 0x000FCB14
	public void ElectricsOff()
	{
		GameObject uncleObj = base.transform.root.gameObject.GetComponent<CarControleScriptC>().uncleObj;
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		this.currentPos = 0;
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
		this.carLogic.GetComponent<CarLogicC>().StopCoroutine("HeadLightOn");
		this.carLogic.GetComponent<CarLogicC>().StopCoroutine("FlickerLight");
		this.carLogic.GetComponent<CarLogicC>().LightsOff();
		if (this.director.GetComponent<DirectorC>().isDay)
		{
		}
	}

	// Token: 0x06000AEB RID: 2795 RVA: 0x000FE848 File Offset: 0x000FCC48
	public IEnumerator Trigger()
	{
		GameObject uncleObj = base.transform.root.gameObject.GetComponent<CarControleScriptC>().uncleObj;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			if (((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn) || ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn))
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.5f);
				iTween.Stop(base.gameObject.transform.parent.gameObject, "RotateTo");
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.position[1],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType
				}));
				yield return new WaitForSeconds(this.timeToComplete);
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
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
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.position[1],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
				this.carLogic.GetComponent<CarLogicC>().HeadLightOn();
				if (this.director.GetComponent<DirectorC>().isDay)
				{
				}
				yield break;
			}
			if (this.currentPos == 1)
			{
				iTween.Stop(base.gameObject.transform.parent.gameObject);
				this.currentPos = 0;
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.position[0],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType2
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
				this.carLogic.GetComponent<CarLogicC>().StopCoroutine("HeadLightOn");
				this.carLogic.GetComponent<CarLogicC>().StopCoroutine("FlickerLight");
				this.carLogic.GetComponent<CarLogicC>().LightsOff();
				if (this.director.GetComponent<DirectorC>().isDay)
				{
				}
				yield break;
			}
			yield break;
		}
		else
		{
			if (this.errorActionIsPlaying)
			{
				yield break;
			}
			this.errorActionIsPlaying = true;
			iTween.Stop(base.gameObject, "RotateBy");
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
			yield return new WaitForSeconds(this.timeToComplete);
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[0],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType2
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
			yield return new WaitForSeconds(this.timeToComplete);
			this.errorActionIsPlaying = false;
			yield break;
		}
	}

	// Token: 0x06000AEC RID: 2796 RVA: 0x000FE863 File Offset: 0x000FCC63
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000AED RID: 2797 RVA: 0x000FE891 File Offset: 0x000FCC91
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F28 RID: 3880
	public GameObject carLogic;

	// Token: 0x04000F29 RID: 3881
	public GameObject director;

	// Token: 0x04000F2A RID: 3882
	public float timeToComplete = 2.05f;

	// Token: 0x04000F2B RID: 3883
	public int currentPos;

	// Token: 0x04000F2C RID: 3884
	public Vector3[] position;

	// Token: 0x04000F2D RID: 3885
	public AudioClip audioSample;

	// Token: 0x04000F2E RID: 3886
	public Material glowMaterial;

	// Token: 0x04000F2F RID: 3887
	public Material startMaterial;

	// Token: 0x04000F30 RID: 3888
	public string easeType = "easeoutelastic";

	// Token: 0x04000F31 RID: 3889
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000F32 RID: 3890
	public AudioClip errorAudio;

	// Token: 0x04000F33 RID: 3891
	private bool isGlowing;

	// Token: 0x04000F34 RID: 3892
	private bool errorActionIsPlaying;
}
