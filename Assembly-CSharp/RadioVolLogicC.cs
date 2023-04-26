using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011A RID: 282
public class RadioVolLogicC : MonoBehaviour
{
	// Token: 0x06000B0F RID: 2831 RVA: 0x0010276D File Offset: 0x00100B6D
	private void Start()
	{
		if (this.handle != null)
		{
			this.startMaterial = this.handle.GetComponent<Renderer>().material;
		}
		this.uncleObj = GameObject.FindWithTag("Uncle");
	}

	// Token: 0x06000B10 RID: 2832 RVA: 0x001027A8 File Offset: 0x00100BA8
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.handle.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if (!this.carLogic.GetComponent<CarLogicC>().radioOn)
		{
			if (this.radioFreqObject != null)
			{
				this.radioFreqObject.GetComponent<AudioSource>().volume -= Time.deltaTime;
				this.radioFreqObject.GetComponent<RadioFreqLogicC>().radioStatic.GetComponent<AudioSource>().volume -= Time.deltaTime;
			}
		}
		else if (this.volumeSetting == 0 && (double)this.radioFreqObject.GetComponent<AudioSource>().volume < 1.0)
		{
			this.radioFreqObject.GetComponent<AudioSource>().volume += Time.deltaTime;
			this.radioFreqObject.GetComponent<RadioFreqLogicC>().radioStatic.GetComponent<AudioSource>().volume += Time.deltaTime;
		}
		else if (this.volumeSetting == 1 && (double)this.radioFreqObject.GetComponent<AudioSource>().volume > 0.5)
		{
			this.radioFreqObject.GetComponent<AudioSource>().volume -= Time.deltaTime;
			this.radioFreqObject.GetComponent<RadioFreqLogicC>().radioStatic.GetComponent<AudioSource>().volume -= Time.deltaTime;
		}
		else if (this.volumeSetting == 1 && (double)this.radioFreqObject.GetComponent<AudioSource>().volume < 0.49)
		{
			this.radioFreqObject.GetComponent<AudioSource>().volume += Time.deltaTime;
			this.radioFreqObject.GetComponent<RadioFreqLogicC>().radioStatic.GetComponent<AudioSource>().volume += Time.deltaTime;
		}
	}

	// Token: 0x06000B11 RID: 2833 RVA: 0x001029B0 File Offset: 0x00100DB0
	public IEnumerator Trigger()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery == null)
		{
			if (this.errorActionIsPlaying)
			{
				yield break;
			}
			this.errorActionIsPlaying = true;
			float quickTweenTime = this.tweenTime / 6f;
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.5f);
			iTween.Stop(base.gameObject, "RotateBy");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.volumeRotAmount,
				"time",
				quickTweenTime,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			yield return new WaitForSeconds(quickTweenTime);
			iTween.Stop(base.gameObject, "RotateBy");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.volumeRotAmount2,
				"time",
				quickTweenTime,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			yield return new WaitForSeconds(quickTweenTime);
			this.errorActionIsPlaying = false;
			yield break;
		}
		else if (((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn) || (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition <= 0.0)
		{
			if (this.errorActionIsPlaying)
			{
				yield break;
			}
			this.errorActionIsPlaying = true;
			float quickTweenTime2 = this.tweenTime / 6f;
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.5f);
			iTween.Stop(base.gameObject, "RotateBy");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.volumeRotAmount,
				"time",
				quickTweenTime2,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			yield return new WaitForSeconds(quickTweenTime2);
			iTween.Stop(base.gameObject, "RotateBy");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.volumeRotAmount2,
				"time",
				quickTweenTime2,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			yield return new WaitForSeconds(quickTweenTime2);
			this.errorActionIsPlaying = false;
			yield break;
		}
		else
		{
			if (this.volumeSetting == 0)
			{
				this.volumeSetting = 1;
				iTween.RotateBy(this.handle, iTween.Hash(new object[]
				{
					"amount",
					this.volumeRotAmount,
					"time",
					this.tweenTime,
					"islocal",
					true,
					"easetype",
					this.dialEaseType,
					"oncomplete",
					"RadioTurnedDown",
					"oncompletetarget",
					this.uncleObj
				}));
				yield break;
			}
			if (this.volumeSetting == 1)
			{
				this.volumeSetting = 0;
				iTween.RotateBy(this.handle, iTween.Hash(new object[]
				{
					"amount",
					this.volumeRotAmount2,
					"time",
					this.tweenTime,
					"islocal",
					true,
					"easetype",
					this.dialEaseType,
					"oncomplete",
					"RadioTurnedLoud",
					"oncompletetarget",
					this.uncleObj
				}));
				yield break;
			}
			yield break;
		}
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x001029CB File Offset: 0x00100DCB
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.handle.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000B13 RID: 2835 RVA: 0x001029EA File Offset: 0x00100DEA
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.handle.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F7B RID: 3963
	public int volumeSetting;

	// Token: 0x04000F7C RID: 3964
	public GameObject carLogic;

	// Token: 0x04000F7D RID: 3965
	public Vector3 volumeRotAmount;

	// Token: 0x04000F7E RID: 3966
	public Vector3 volumeRotAmount2;

	// Token: 0x04000F7F RID: 3967
	public float tweenTime;

	// Token: 0x04000F80 RID: 3968
	public GameObject radioFreqObject;

	// Token: 0x04000F81 RID: 3969
	public GameObject handle;

	// Token: 0x04000F82 RID: 3970
	public Material startMaterial;

	// Token: 0x04000F83 RID: 3971
	public Material glowMaterial;

	// Token: 0x04000F84 RID: 3972
	public string dialEaseType = string.Empty;

	// Token: 0x04000F85 RID: 3973
	public AudioClip errorAudio;

	// Token: 0x04000F86 RID: 3974
	private bool isGlowing;

	// Token: 0x04000F87 RID: 3975
	private bool errorActionIsPlaying;

	// Token: 0x04000F88 RID: 3976
	public GameObject uncleObj;
}
