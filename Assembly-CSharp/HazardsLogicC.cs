using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000114 RID: 276
public class HazardsLogicC : MonoBehaviour
{
	// Token: 0x06000AE1 RID: 2785 RVA: 0x000FD920 File Offset: 0x000FBD20
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x000FD948 File Offset: 0x000FBD48
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null && (((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn) || (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition <= 0.0) && (this.carLogic.GetComponent<CarLogicC>().headlightsOn || this.carLogic.GetComponent<CarLogicC>().hazardLightsOn))
		{
			this.currentPos = 0;
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.positionRotation[0],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType2
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
			this.carLogic.GetComponent<CarLogicC>().StopCoroutine("HazardLights");
			this.carLogic.GetComponent<CarLogicC>().LightsOff();
			this.carLogic.GetComponent<CarLogicC>().headlightsOn = false;
			this.carLogic.GetComponent<CarLogicC>().hazardLightsOn = false;
		}
	}

	// Token: 0x06000AE3 RID: 2787 RVA: 0x000FDB30 File Offset: 0x000FBF30
	public void ElectricsOff()
	{
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		this.currentPos = 0;
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.positionRotation[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
		if (!this.carLogic.GetComponent<CarLogicC>().headlightsOn)
		{
			this.carLogic.GetComponent<CarLogicC>().StopCoroutine("HazardLights");
			this.carLogic.GetComponent<CarLogicC>().lightFrontRHeadlight.GetComponent<Light>().enabled = false;
			this.carLogic.GetComponent<CarLogicC>().lightFrontLHeadlight.GetComponent<Light>().enabled = false;
			this.carLogic.GetComponent<CarLogicC>().lightRearRHeadlight.GetComponent<Light>().enabled = false;
			this.carLogic.GetComponent<CarLogicC>().lightRearLHeadlight.GetComponent<Light>().enabled = false;
			this.carLogic.GetComponent<AudioSource>().PlayOneShot(this.carLogic.GetComponent<CarLogicC>().flickAudioOff, 0.05f);
		}
		else if (this.carLogic.GetComponent<CarLogicC>().headlightsOn)
		{
			this.carLogic.GetComponent<CarLogicC>().StopCoroutine("HazardLights");
			this.carLogic.GetComponent<CarLogicC>().lightFrontRHeadlight.GetComponent<Light>().enabled = true;
			this.carLogic.GetComponent<CarLogicC>().lightFrontLHeadlight.GetComponent<Light>().enabled = true;
			this.carLogic.GetComponent<CarLogicC>().lightRearRHeadlight.GetComponent<Light>().enabled = true;
			this.carLogic.GetComponent<CarLogicC>().lightRearLHeadlight.GetComponent<Light>().enabled = true;
			this.carLogic.GetComponent<AudioSource>().PlayOneShot(this.carLogic.GetComponent<CarLogicC>().flickAudioOn, 0.05f);
		}
		this.carLogic.GetComponent<CarLogicC>().hazardLightsOn = false;
	}

	// Token: 0x06000AE4 RID: 2788 RVA: 0x000FDD80 File Offset: 0x000FC180
	public IEnumerator Trigger()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.5f);
				iTween.Stop(base.gameObject.transform.parent.gameObject, "RotateTo");
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.positionRotation[1],
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
					this.positionRotation[0],
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
					this.positionRotation[1],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
				this.carLogic.GetComponent<CarLogicC>().StartCoroutine("HazardLights");
				this.carLogic.GetComponent<CarLogicC>().hazardLightsOn = true;
				yield break;
			}
			if (this.currentPos == 1)
			{
				iTween.Stop(base.gameObject.transform.parent.gameObject);
				this.currentPos = 0;
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.positionRotation[0],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType2
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
				if (!this.carLogic.GetComponent<CarLogicC>().headlightsOn)
				{
					this.carLogic.GetComponent<CarLogicC>().StopCoroutine("HazardLights");
					this.carLogic.GetComponent<CarLogicC>().lightFrontRHeadlight.GetComponent<Light>().enabled = false;
					this.carLogic.GetComponent<CarLogicC>().lightFrontLHeadlight.GetComponent<Light>().enabled = false;
					this.carLogic.GetComponent<CarLogicC>().lightRearRHeadlight.GetComponent<Light>().enabled = false;
					this.carLogic.GetComponent<CarLogicC>().lightRearLHeadlight.GetComponent<Light>().enabled = false;
					this.carLogic.GetComponent<AudioSource>().PlayOneShot(this.carLogic.GetComponent<CarLogicC>().flickAudioOff, 0.05f);
				}
				else if (this.carLogic.GetComponent<CarLogicC>().headlightsOn)
				{
					this.carLogic.GetComponent<CarLogicC>().StopCoroutine("HazardLights");
					this.carLogic.GetComponent<CarLogicC>().lightFrontRHeadlight.GetComponent<Light>().enabled = true;
					this.carLogic.GetComponent<CarLogicC>().lightFrontLHeadlight.GetComponent<Light>().enabled = true;
					this.carLogic.GetComponent<CarLogicC>().lightRearRHeadlight.GetComponent<Light>().enabled = true;
					this.carLogic.GetComponent<CarLogicC>().lightRearLHeadlight.GetComponent<Light>().enabled = true;
					this.carLogic.GetComponent<AudioSource>().PlayOneShot(this.carLogic.GetComponent<CarLogicC>().flickAudioOn, 0.05f);
				}
				this.carLogic.GetComponent<CarLogicC>().hazardLightsOn = false;
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
			iTween.Stop(base.gameObject, "RotateTo");
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.positionRotation[1],
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
				this.positionRotation[0],
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

	// Token: 0x06000AE5 RID: 2789 RVA: 0x000FDD9B File Offset: 0x000FC19B
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000AE6 RID: 2790 RVA: 0x000FDDC4 File Offset: 0x000FC1C4
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F1C RID: 3868
	public GameObject carLogic;

	// Token: 0x04000F1D RID: 3869
	public float timeToComplete = 2.05f;

	// Token: 0x04000F1E RID: 3870
	public int currentPos;

	// Token: 0x04000F1F RID: 3871
	public Vector3[] positionRotation;

	// Token: 0x04000F20 RID: 3872
	public AudioClip audioSample;

	// Token: 0x04000F21 RID: 3873
	public Material glowMaterial;

	// Token: 0x04000F22 RID: 3874
	public Material startMaterial;

	// Token: 0x04000F23 RID: 3875
	public string easeType = "easeoutelastic";

	// Token: 0x04000F24 RID: 3876
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000F25 RID: 3877
	public AudioClip errorAudio;

	// Token: 0x04000F26 RID: 3878
	private bool isGlowing;

	// Token: 0x04000F27 RID: 3879
	private bool errorActionIsPlaying;
}
