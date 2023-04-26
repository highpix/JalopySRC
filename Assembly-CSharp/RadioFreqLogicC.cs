using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000119 RID: 281
public class RadioFreqLogicC : MonoBehaviour
{
	// Token: 0x06000B04 RID: 2820 RVA: 0x0010159C File Offset: 0x000FF99C
	private void Start()
	{
		if (this.handle != null)
		{
			this.startMaterial = this.handle.GetComponent<Renderer>().material;
		}
		this.uncleObj = GameObject.FindWithTag("Uncle");
		base.StartCoroutine("ArrangeShuffle");
	}

	// Token: 0x06000B05 RID: 2821 RVA: 0x001015EC File Offset: 0x000FF9EC
	public void ArrangeShuffle()
	{
		for (int i = 0; i < this.songListings.Length; i++)
		{
			this.songShuffle.Add(this.songListings[i]);
		}
		for (int j = 0; j < this.songShuffle.Count; j++)
		{
			AudioClip value = this.songShuffle[j];
			int index = UnityEngine.Random.Range(j, this.songShuffle.Count);
			this.songShuffle[j] = this.songShuffle[index];
			this.songShuffle[index] = value;
		}
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (gameObject != null && !gameObject.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 0)
			{
				this.songShuffle.Insert(0, this.countrySpecificIndents[0]);
				this.songShuffle.Insert(3, this.countrySpecificIndents[0]);
				this.songShuffle.Insert(6, this.countrySpecificIndents[0]);
				this.songShuffle.Insert(9, this.countrySpecificIndents[0]);
				this.songShuffle.Insert(12, this.countrySpecificIndents[0]);
				this.songShuffle.Insert(15, this.countrySpecificIndents[0]);
			}
			else if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				this.songShuffle.Insert(0, this.countrySpecificIndents[1]);
				this.songShuffle.Insert(3, this.countrySpecificIndents[1]);
				this.songShuffle.Insert(6, this.countrySpecificIndents[1]);
				this.songShuffle.Insert(9, this.countrySpecificIndents[1]);
				this.songShuffle.Insert(12, this.countrySpecificIndents[1]);
				this.songShuffle.Insert(15, this.countrySpecificIndents[1]);
			}
			else if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				this.songShuffle.Insert(0, this.countrySpecificIndents[2]);
				this.songShuffle.Insert(3, this.countrySpecificIndents[2]);
				this.songShuffle.Insert(6, this.countrySpecificIndents[2]);
				this.songShuffle.Insert(9, this.countrySpecificIndents[2]);
				this.songShuffle.Insert(12, this.countrySpecificIndents[2]);
				this.songShuffle.Insert(15, this.countrySpecificIndents[2]);
			}
			else if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				this.songShuffle.Insert(0, this.countrySpecificIndents[3]);
				this.songShuffle.Insert(3, this.countrySpecificIndents[3]);
				this.songShuffle.Insert(6, this.countrySpecificIndents[3]);
				this.songShuffle.Insert(9, this.countrySpecificIndents[3]);
				this.songShuffle.Insert(12, this.countrySpecificIndents[3]);
				this.songShuffle.Insert(15, this.countrySpecificIndents[3]);
			}
			else if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 4)
			{
				this.songShuffle.Insert(0, this.countrySpecificIndents[4]);
				this.songShuffle.Insert(3, this.countrySpecificIndents[4]);
				this.songShuffle.Insert(6, this.countrySpecificIndents[4]);
				this.songShuffle.Insert(9, this.countrySpecificIndents[4]);
				this.songShuffle.Insert(12, this.countrySpecificIndents[4]);
				this.songShuffle.Insert(15, this.countrySpecificIndents[4]);
			}
			else if (gameObject.GetComponent<RouteGeneratorC>().routeLevel == 5)
			{
				this.songShuffle.Insert(0, this.countrySpecificIndents[5]);
				this.songShuffle.Insert(3, this.countrySpecificIndents[5]);
				this.songShuffle.Insert(6, this.countrySpecificIndents[5]);
				this.songShuffle.Insert(9, this.countrySpecificIndents[5]);
				this.songShuffle.Insert(12, this.countrySpecificIndents[5]);
				this.songShuffle.Insert(15, this.countrySpecificIndents[5]);
			}
		}
		base.GetComponent<AudioSource>().clip = this.songShuffle[0];
		base.GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x00101A38 File Offset: 0x000FFE38
	public void NextSong()
	{
		this.songShuffle.RemoveAt(0);
		if (this.songShuffle.Count == 0)
		{
			base.StartCoroutine("ArrangeShuffle");
			return;
		}
		base.GetComponent<AudioSource>().clip = this.songShuffle[0];
		base.GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x00101A90 File Offset: 0x000FFE90
	private void Update()
	{
		if (!base.GetComponent<AudioSource>().isPlaying)
		{
			this.NextSong();
		}
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.handle.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x00101AF0 File Offset: 0x000FFEF0
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
			iTween.Stop(base.gameObject, "MoveTo");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.onAmount,
				"time",
				quickTweenTime,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			iTween.MoveTo(this.needle, iTween.Hash(new object[]
			{
				"position",
				this.needleMoveTo,
				"time",
				quickTweenTime,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			yield return new WaitForSeconds(quickTweenTime);
			iTween.Stop(base.gameObject, "RotateBy");
			iTween.Stop(base.gameObject, "MoveTo");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.offAmount,
				"time",
				quickTweenTime,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			iTween.MoveTo(this.needle, iTween.Hash(new object[]
			{
				"position",
				this.needleMoveFrom,
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
			iTween.Stop(base.gameObject, "MoveTo");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.onAmount,
				"time",
				quickTweenTime2,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			iTween.MoveTo(this.needle, iTween.Hash(new object[]
			{
				"position",
				this.needleMoveTo,
				"time",
				quickTweenTime2,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			yield return new WaitForSeconds(quickTweenTime2);
			iTween.Stop(base.gameObject, "RotateBy");
			iTween.Stop(base.gameObject, "MoveTo");
			iTween.RotateBy(this.handle, iTween.Hash(new object[]
			{
				"amount",
				this.offAmount,
				"time",
				quickTweenTime2,
				"islocal",
				true,
				"easetype",
				this.dialEaseType
			}));
			iTween.MoveTo(this.needle, iTween.Hash(new object[]
			{
				"position",
				this.needleMoveFrom,
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
			if (!this.carLogic.GetComponent<CarLogicC>().radioOn)
			{
				base.StartCoroutine(this.TurnRadioOn());
				yield break;
			}
			if (this.carLogic.GetComponent<CarLogicC>().radioOn)
			{
				base.StartCoroutine(this.TurnRadioOff());
				yield break;
			}
			yield break;
		}
	}

	// Token: 0x06000B09 RID: 2825 RVA: 0x00101B0C File Offset: 0x000FFF0C
	public IEnumerator TurnRadioOn()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery == null)
		{
			yield break;
		}
		if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn)
		{
			yield break;
		}
		this.carLogic.GetComponent<CarLogicC>().radioOn = true;
		iTween.Stop(this.handle, "RotateBy");
		iTween.Stop(this.needle, "MoveTo");
		base.GetComponent<AudioSource>().PlayOneShot(this.onSFX, 0.7f);
		iTween.RotateBy(this.handle, iTween.Hash(new object[]
		{
			"amount",
			this.onAmount,
			"time",
			this.tweenTime,
			"islocal",
			true,
			"easetype",
			this.dialEaseType,
			"oncomplete",
			"PlayMusic",
			"onCompleteTarget",
			base.gameObject
		}));
		iTween.MoveTo(this.needle, iTween.Hash(new object[]
		{
			"position",
			this.needleMoveTo,
			"time",
			this.tweenTime,
			"islocal",
			true,
			"easetype",
			this.dialEaseType
		}));
		yield return new WaitForSeconds(this.tweenTime);
		if (this.radioVolume.GetComponent<RadioVolLogicC>().volumeSetting == 0)
		{
			base.StartCoroutine(this.uncleObj.GetComponent<UncleLogicC>().RadioTurnedLoud());
		}
		yield break;
	}

	// Token: 0x06000B0A RID: 2826 RVA: 0x00101B28 File Offset: 0x000FFF28
	public IEnumerator TurnRadioOff()
	{
		iTween.Stop(this.handle, "RotateBy");
		iTween.Stop(this.needle, "MoveTo");
		base.GetComponent<AudioSource>().PlayOneShot(this.offSFX, 0.7f);
		this.carLogic.GetComponent<CarLogicC>().radioOn = false;
		iTween.RotateBy(this.handle, iTween.Hash(new object[]
		{
			"amount",
			this.offAmount,
			"time",
			this.tweenTime,
			"islocal",
			true,
			"easetype",
			this.dialEaseType
		}));
		iTween.MoveTo(this.needle, iTween.Hash(new object[]
		{
			"position",
			this.needleMoveFrom,
			"time",
			this.tweenTime,
			"islocal",
			true,
			"easetype",
			this.dialEaseType
		}));
		yield return new WaitForSeconds(this.tweenTime);
		base.StartCoroutine(this.uncleObj.GetComponent<UncleLogicC>().RadioTurnedDown());
		yield break;
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x00101B43 File Offset: 0x000FFF43
	public void PlayMusic()
	{
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x00101B45 File Offset: 0x000FFF45
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.handle.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x00101B64 File Offset: 0x000FFF64
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.handle.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F62 RID: 3938
	public GameObject carLogic;

	// Token: 0x04000F63 RID: 3939
	public GameObject radioVolume;

	// Token: 0x04000F64 RID: 3940
	public Vector3 onAmount;

	// Token: 0x04000F65 RID: 3941
	public Vector3 offAmount;

	// Token: 0x04000F66 RID: 3942
	public Vector3 needleMoveTo;

	// Token: 0x04000F67 RID: 3943
	public Vector3 needleMoveFrom;

	// Token: 0x04000F68 RID: 3944
	public float tweenTime;

	// Token: 0x04000F69 RID: 3945
	public GameObject handle;

	// Token: 0x04000F6A RID: 3946
	public GameObject needle;

	// Token: 0x04000F6B RID: 3947
	public AudioClip onSFX;

	// Token: 0x04000F6C RID: 3948
	public AudioClip offSFX;

	// Token: 0x04000F6D RID: 3949
	public Material startMaterial;

	// Token: 0x04000F6E RID: 3950
	public Material glowMaterial;

	// Token: 0x04000F6F RID: 3951
	public string dialEaseType = string.Empty;

	// Token: 0x04000F70 RID: 3952
	public AudioClip errorAudio;

	// Token: 0x04000F71 RID: 3953
	private bool isGlowing;

	// Token: 0x04000F72 RID: 3954
	private bool errorActionIsPlaying;

	// Token: 0x04000F73 RID: 3955
	public GameObject uncleObj;

	// Token: 0x04000F74 RID: 3956
	public AudioClip[] songListings;

	// Token: 0x04000F75 RID: 3957
	public AudioClip[] countrySpecificIndents;

	// Token: 0x04000F76 RID: 3958
	public List<AudioClip> songShuffle = new List<AudioClip>();

	// Token: 0x04000F77 RID: 3959
	public AudioClip[] intermissionListings;

	// Token: 0x04000F78 RID: 3960
	public GameObject radioStatic;

	// Token: 0x04000F79 RID: 3961
	public int songNumber;

	// Token: 0x04000F7A RID: 3962
	public float currentTrackLength;
}
