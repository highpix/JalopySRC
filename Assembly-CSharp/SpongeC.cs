using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000100 RID: 256
public class SpongeC : MonoBehaviour
{
	// Token: 0x06000A0D RID: 2573 RVA: 0x000EDFFB File Offset: 0x000EC3FB
	private void Start()
	{
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x06000A0E RID: 2574 RVA: 0x000EE010 File Offset: 0x000EC410
	public void ReturnToBucket()
	{
		this.water.GetComponent<SphereCollider>().enabled = false;
		base.transform.parent = this.bucket.transform;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.bucketPosAdjust,
			"islocal",
			true,
			"time",
			1.0,
			"easetype",
			"easeoutquad"
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.bucketRotAdjust,
			"islocal",
			true,
			"time",
			0.75,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x06000A0F RID: 2575 RVA: 0x000EE110 File Offset: 0x000EC510
	public void PickUp()
	{
		this.water.GetComponent<SphereCollider>().enabled = true;
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x000EE124 File Offset: 0x000EC524
	public void Action()
	{
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		if (base.gameObject.GetComponent<ObjectInteractionsC>().target.transform.name == this.waterName)
		{
			if (this.cleanness < 3)
			{
				this.Clean();
			}
			else
			{
				this.Shake();
			}
		}
		if (base.gameObject.GetComponent<ObjectInteractionsC>().target.GetComponent<FrameDirtC>() != null)
		{
			double num = 0.0;
			GameObject target = base.gameObject.GetComponent<ObjectInteractionsC>().target;
			if (target.GetComponent<FrameDirtC>().frontWindow)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().frontWindowDirtRim.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().leftFrontWindow)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().frontLeftWindowObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().leftRearWindow)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().rearLeftWindowObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rightFrontWindow)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().frontRightWindowObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rightRearWindow)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().rearRightWindowObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rearWindow)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().rearWindowObject.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().frontFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().frntDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rearFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().rearDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().leftFrontFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().frntlsideDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().leftDoorFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().leftRearFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().rearlsideDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rightFrontFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().frntrsideDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rightDoorFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rightRearFrame)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().rearrsideDirtObj.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().leftFrontTyre)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().FlWheelDirt.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().leftRearTyre)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().RlWheelDirt.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rightFrontTyre)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().FrWheelDirt.GetComponent<Renderer>().material.color.a;
			}
			if (target.GetComponent<FrameDirtC>().rightRearTyre)
			{
				num = (double)this.carLogic.GetComponent<CarLogicC>().RrWheelDirt.GetComponent<Renderer>().material.color.a;
			}
			if (this.cleanness > 0 && num > 0.0)
			{
				this.Dirty();
			}
			else
			{
				this.Shake();
			}
		}
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x000EE618 File Offset: 0x000ECA18
	public void UnAction()
	{
		MonoBehaviour.print("UnAction");
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		float pitch = UnityEngine.Random.Range(0.8f, 1.2f);
		base.GetComponent<AudioSource>().pitch = pitch;
		int num = UnityEngine.Random.Range(0, this.airSwipe.Length - 1);
		base.GetComponent<AudioSource>().PlayOneShot(this.airSwipe[num], 1f);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"PunchPart2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x000EE730 File Offset: 0x000ECB30
	public void Shake()
	{
		iTween.PunchRotation(base.gameObject, iTween.Hash(new object[]
		{
			"z",
			60,
			"islocal",
			true,
			"time",
			0.3
		}));
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x000EE790 File Offset: 0x000ECB90
	public void Dirty()
	{
		base.gameObject.GetComponent<ObjectInteractionsC>().target.SendMessage("Clean");
		this.cleanness--;
		this.DirtTween();
		base.StartCoroutine(this.DirtyPunch());
		this.carLogic.GetComponent<CarLogicC>().cleanedTimes++;
		if (this.carLogic.GetComponent<CarLogicC>().cleanedTimes >= 50)
		{
			this.carLogic.GetComponent<CarLogicC>().CleanAchievement();
		}
	}

	// Token: 0x06000A14 RID: 2580 RVA: 0x000EE817 File Offset: 0x000ECC17
	public void Clean()
	{
		this.cleanness++;
		this.DirtTween();
		base.StartCoroutine(this.CleanPunch());
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x000EE83C File Offset: 0x000ECC3C
	private IEnumerator DirtyPunch()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"PunchPart2",
			"oncompletetarget",
			base.gameObject
		}));
		yield return new WaitForSeconds(this.timeToComplete / 2f);
		float randomPitch = UnityEngine.Random.Range(0.8f, 1.2f);
		base.GetComponent<AudioSource>().pitch = randomPitch;
		base.GetComponent<AudioSource>().PlayOneShot(this.splash, 1f);
		this.dirtyParticles.GetComponent<ParticleSystem>().Play();
		yield break;
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x000EE858 File Offset: 0x000ECC58
	public IEnumerator CleanPunch()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"PunchPart2",
			"oncompletetarget",
			base.gameObject
		}));
		float halfTime = this.timeToComplete / 2f;
		yield return new WaitForSeconds(halfTime);
		iTween.PunchPosition(base.gameObject, iTween.Hash(new object[]
		{
			"x",
			2.0,
			"islocal",
			true,
			"time",
			halfTime
		}));
		float randomPitch = UnityEngine.Random.Range(0.8f, 1.2f);
		base.GetComponent<AudioSource>().pitch = randomPitch;
		base.GetComponent<AudioSource>().PlayOneShot(this.splash, 1f);
		this.cleanParticles.GetComponent<ParticleSystem>().Play();
		yield break;
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x000EE874 File Offset: 0x000ECC74
	public void PunchPart2()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"delay",
			0.1,
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x000EE90C File Offset: 0x000ECD0C
	public void DirtTween()
	{
		float num = 0f;
		if (this.cleanness == 3)
		{
			num = 0f;
		}
		if (this.cleanness == 2)
		{
			num = 0.25f;
		}
		if (this.cleanness == 1)
		{
			num = 0.5f;
		}
		if (this.cleanness == 0)
		{
			num = 0.75f;
		}
		iTween.FadeTo(this.dirtObject, iTween.Hash(new object[]
		{
			"alpha",
			num,
			"time",
			0.4,
			"easetype",
			"easeInQuad"
		}));
	}

	// Token: 0x04000DEC RID: 3564
	public GameObject carLogic;

	// Token: 0x04000DED RID: 3565
	public GameObject dirtObject;

	// Token: 0x04000DEE RID: 3566
	public int cleanness;

	// Token: 0x04000DEF RID: 3567
	public string waterName = "Water";

	// Token: 0x04000DF0 RID: 3568
	public string dirtName = "Dirt";

	// Token: 0x04000DF1 RID: 3569
	public Vector3[] position = new Vector3[0];

	// Token: 0x04000DF2 RID: 3570
	public string easeType1 = string.Empty;

	// Token: 0x04000DF3 RID: 3571
	public string easeType2 = string.Empty;

	// Token: 0x04000DF4 RID: 3572
	public float timeToComplete;

	// Token: 0x04000DF5 RID: 3573
	public GameObject cleanParticles;

	// Token: 0x04000DF6 RID: 3574
	public GameObject dirtyParticles;

	// Token: 0x04000DF7 RID: 3575
	public AudioClip splash;

	// Token: 0x04000DF8 RID: 3576
	public AudioClip[] airSwipe = new AudioClip[0];

	// Token: 0x04000DF9 RID: 3577
	public GameObject water;

	// Token: 0x04000DFA RID: 3578
	public GameObject bucket;

	// Token: 0x04000DFB RID: 3579
	public Vector3 bucketPosAdjust;

	// Token: 0x04000DFC RID: 3580
	public Vector3 bucketRotAdjust;
}
