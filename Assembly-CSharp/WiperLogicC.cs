using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011D RID: 285
public class WiperLogicC : MonoBehaviour
{
	// Token: 0x06000B26 RID: 2854 RVA: 0x00103C0C File Offset: 0x0010200C
	public void StopWiper()
	{
		this.wiperOn = false;
		base.StopCoroutine("WiperUp");
		base.StopCoroutine("WiperDown");
		if (this.wiperBoss)
		{
			this.ReturnRain();
		}
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
	}

	// Token: 0x06000B27 RID: 2855 RVA: 0x00103CDF File Offset: 0x001020DF
	public void StartWiper()
	{
		this.wiperOn = true;
		this.WiperUp();
	}

	// Token: 0x06000B28 RID: 2856 RVA: 0x00103CF0 File Offset: 0x001020F0
	public void WiperUp()
	{
		if (this.isBroken && UnityEngine.Random.value >= this.brokenDoorFailChance)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotations[2],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.brokenEaseType1,
				"oncomplete",
				"BrokenWiperDown",
				"oncompletetarget",
				base.gameObject
			}));
			return;
		}
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"WiperDown",
			"oncompletetarget",
			base.gameObject
		}));
		if (this.wiperBoss)
		{
			this.Smudge();
			this.Clean();
		}
		if (this.audio1 != null)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audio1, 1f);
		}
	}

	// Token: 0x06000B29 RID: 2857 RVA: 0x00103ED4 File Offset: 0x001022D4
	public void WiperDown()
	{
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2,
			"oncomplete",
			"WiperUp",
			"oncompletetarget",
			base.gameObject
		}));
		if (this.wiperBoss)
		{
			this.ScreenWaterUp();
		}
		if (this.audio2 != null)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audio2, 1f);
		}
	}

	// Token: 0x06000B2A RID: 2858 RVA: 0x00103FD8 File Offset: 0x001023D8
	public void BrokenWiperDown()
	{
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.brokenEaseType2,
			"oncomplete",
			"WiperUp",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000B2B RID: 2859 RVA: 0x001040A4 File Offset: 0x001024A4
	public void Smudge()
	{
		float a = this.carLogic.GetComponent<CarLogicC>().frontWindowDirtWipers.GetComponent<Renderer>().material.color.a;
		iTween.FadeTo(this.carLogic.GetComponent<CarLogicC>().frontWindowDirtSmudge, iTween.Hash(new object[]
		{
			"alpha",
			a,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
	}

	// Token: 0x06000B2C RID: 2860 RVA: 0x00104134 File Offset: 0x00102534
	public void Clean()
	{
		if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
		{
			return;
		}
		iTween.FadeTo(this.screenWater, iTween.Hash(new object[]
		{
			"alpha",
			0.065,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
	}

	// Token: 0x06000B2D RID: 2861 RVA: 0x001041B0 File Offset: 0x001025B0
	public void ScreenWaterUp()
	{
		if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
		{
			return;
		}
		if (this.carLogic.GetComponent<CarLogicC>().isUnderShelter)
		{
			return;
		}
		if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 1)
		{
			iTween.FadeTo(this.screenWater, iTween.Hash(new object[]
			{
				"alpha",
				0.08,
				"time",
				this.timeToComplete / 2f,
				"easetype",
				this.easeType1
			}));
		}
		else if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 2)
		{
			iTween.FadeTo(this.screenWater, iTween.Hash(new object[]
			{
				"alpha",
				0.125,
				"time",
				this.timeToComplete / 2f,
				"easetype",
				this.easeType1
			}));
		}
	}

	// Token: 0x06000B2E RID: 2862 RVA: 0x001042D4 File Offset: 0x001026D4
	public void ReturnRain()
	{
		if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
		{
			return;
		}
		if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 1)
		{
			iTween.FadeTo(this.screenWater, iTween.Hash(new object[]
			{
				"alpha",
				0.1,
				"time",
				this.timeToComplete / 2f,
				"easetype",
				this.easeType1
			}));
		}
		else if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 2)
		{
			iTween.FadeTo(this.screenWater, iTween.Hash(new object[]
			{
				"alpha",
				0.235,
				"time",
				this.timeToComplete / 2f,
				"easetype",
				this.easeType1
			}));
		}
	}

	// Token: 0x06000B2F RID: 2863 RVA: 0x001043E0 File Offset: 0x001027E0
	public IEnumerator WaterWipe()
	{
		if (this.isBroken && UnityEngine.Random.value >= this.brokenDoorFailChance)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotations[2],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.brokenEaseType1
			}));
			yield break;
		}
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
		if (this.wiperBoss)
		{
			this.Smudge();
		}
		yield return new WaitForSeconds(this.timeToComplete);
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		yield return new WaitForSeconds(this.timeToComplete);
		if (this.isBroken && UnityEngine.Random.value >= this.brokenDoorFailChance)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotations[2],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.brokenEaseType1
			}));
			yield break;
		}
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
		if (this.wiperBoss)
		{
			this.Smudge();
		}
		yield return new WaitForSeconds(this.timeToComplete);
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		yield return new WaitForSeconds(this.timeToComplete);
		if (this.isBroken && UnityEngine.Random.value >= this.brokenDoorFailChance)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotations[2],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.brokenEaseType1
			}));
			yield break;
		}
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
		if (this.wiperBoss)
		{
			this.Smudge();
		}
		yield return new WaitForSeconds(this.timeToComplete);
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		yield break;
	}

	// Token: 0x04000FA1 RID: 4001
	public GameObject carLogic;

	// Token: 0x04000FA2 RID: 4002
	public GameObject screenWater;

	// Token: 0x04000FA3 RID: 4003
	public bool wiperOn;

	// Token: 0x04000FA4 RID: 4004
	public float timeToComplete;

	// Token: 0x04000FA5 RID: 4005
	public bool isBroken;

	// Token: 0x04000FA6 RID: 4006
	[Range(0f, 1f)]
	public float brokenDoorFailChance;

	// Token: 0x04000FA7 RID: 4007
	public Vector3[] rotations;

	// Token: 0x04000FA8 RID: 4008
	public string easeType1 = string.Empty;

	// Token: 0x04000FA9 RID: 4009
	public string easeType2 = string.Empty;

	// Token: 0x04000FAA RID: 4010
	public string brokenEaseType1 = string.Empty;

	// Token: 0x04000FAB RID: 4011
	public string brokenEaseType2 = string.Empty;

	// Token: 0x04000FAC RID: 4012
	public bool wiperBoss;

	// Token: 0x04000FAD RID: 4013
	public AudioClip audio1;

	// Token: 0x04000FAE RID: 4014
	public AudioClip audio2;
}
