using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011C RID: 284
public class WindowWipersLogicC : MonoBehaviour
{
	// Token: 0x06000B1D RID: 2845 RVA: 0x00103355 File Offset: 0x00101755
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000B1E RID: 2846 RVA: 0x0010337C File Offset: 0x0010177C
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000B1F RID: 2847 RVA: 0x001033D0 File Offset: 0x001017D0
	public void ElectricsOff()
	{
		this.carLogic.GetComponent<CarLogicC>().windowWipersOn = false;
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		this.currentPos = 0;
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"x",
			this.handleRotations[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2,
			"oncomplete",
			"StopWipers",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x001034AC File Offset: 0x001018AC
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
					"x",
					this.handleRotations[1],
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
					"x",
					this.handleRotations[0],
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
				this.carLogic.GetComponent<CarLogicC>().windowWipersOn = true;
				iTween.Stop(base.gameObject.transform.parent.gameObject);
				this.currentPos = 1;
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"x",
					this.handleRotations[1],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType,
					"oncomplete",
					"StartWipers",
					"oncompletetarget",
					base.gameObject
				}));
				yield break;
			}
			if (this.currentPos == 1)
			{
				this.carLogic.GetComponent<CarLogicC>().windowWipersOn = false;
				iTween.Stop(base.gameObject.transform.parent.gameObject);
				this.currentPos = 0;
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"x",
					this.handleRotations[0],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType2,
					"oncomplete",
					"StopWipers",
					"oncompletetarget",
					base.gameObject
				}));
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
				"x",
				this.handleRotations[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType,
				"oncomplete",
				"StartWipers",
				"oncompletetarget",
				base.gameObject
			}));
			yield return new WaitForSeconds(this.timeToComplete);
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"x",
				this.handleRotations[0],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType2,
				"oncomplete",
				"StopWipers",
				"oncompletetarget",
				base.gameObject
			}));
			yield return new WaitForSeconds(this.timeToComplete);
			this.errorActionIsPlaying = false;
			yield break;
		}
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x001034C7 File Offset: 0x001018C7
	public void StartWipers()
	{
		this.windowWiperTarget1.GetComponent<WiperLogicC>().StartWiper();
		this.windowWiperTarget2.GetComponent<WiperLogicC>().StartWiper();
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x001034E9 File Offset: 0x001018E9
	public void StopWipers()
	{
		this.windowWiperTarget1.GetComponent<WiperLogicC>().StopWiper();
		this.windowWiperTarget2.GetComponent<WiperLogicC>().StopWiper();
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x0010350B File Offset: 0x0010190B
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x00103534 File Offset: 0x00101934
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F94 RID: 3988
	public GameObject carLogic;

	// Token: 0x04000F95 RID: 3989
	public float timeToComplete = 2.05f;

	// Token: 0x04000F96 RID: 3990
	public GameObject windowWiperTarget1;

	// Token: 0x04000F97 RID: 3991
	public GameObject windowWiperTarget2;

	// Token: 0x04000F98 RID: 3992
	public float[] handleRotations;

	// Token: 0x04000F99 RID: 3993
	public Material glowMaterial;

	// Token: 0x04000F9A RID: 3994
	public Material startMaterial;

	// Token: 0x04000F9B RID: 3995
	public string easeType = "easeoutelastic";

	// Token: 0x04000F9C RID: 3996
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000F9D RID: 3997
	public AudioClip errorAudio;

	// Token: 0x04000F9E RID: 3998
	private bool isGlowing;

	// Token: 0x04000F9F RID: 3999
	private bool errorActionIsPlaying;

	// Token: 0x04000FA0 RID: 4000
	public int currentPos;
}
