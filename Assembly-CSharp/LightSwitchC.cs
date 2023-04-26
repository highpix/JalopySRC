using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000C0 RID: 192
public class LightSwitchC : MonoBehaviour
{
	// Token: 0x06000704 RID: 1796 RVA: 0x0008B42E File Offset: 0x0008982E
	public void Start()
	{
		this.startMaterial = base.GetComponent<Renderer>().material;
		if (this.isCarComponent)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x0008B45C File Offset: 0x0008985C
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x0008B4A0 File Offset: 0x000898A0
	public void ElectricsOff()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
		if (this.rotation.Length > 0)
		{
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotation[0],
				"islocal",
				true,
				"time",
				0.05,
				"onComplete",
				"LightOff",
				"onCompleteTarget",
				base.gameObject
			}));
		}
		else if (this.position.Length > 0)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[1],
				"islocal",
				true,
				"time",
				0.05,
				"onComplete",
				"LightOff",
				"onCompleteTarget",
				base.gameObject
			}));
		}
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x0008B5EC File Offset: 0x000899EC
	public IEnumerator Trigger()
	{
		if (this.isCarComponent)
		{
			if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
			{
				if (((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 && !this.carLogic.GetComponent<CarLogicC>().engineOn) || (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition <= 0.0)
				{
					base.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
					if (this.rotation.Length > 0)
					{
						iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
						{
							"rotation",
							this.rotation[1],
							"islocal",
							true,
							"time",
							0.05,
							"onComplete",
							"NoPowerBackOff",
							"onCompleteTarget",
							base.gameObject
						}));
					}
					else if (this.position.Length > 0)
					{
						iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
						{
							"rotation",
							this.position[1],
							"islocal",
							true,
							"time",
							0.05,
							"onComplete",
							"NoPowerBackOff",
							"onCompleteTarget",
							base.gameObject
						}));
					}
					yield break;
				}
				this.carLogic.GetComponent<CarLogicC>().ceilingLightOn = true;
			}
			else
			{
				if (this.errorActionIsPlaying)
				{
					yield break;
				}
				this.errorActionIsPlaying = true;
				iTween.Stop(base.gameObject, "RotateTo");
				iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.rotation[1],
					"islocal",
					true,
					"time",
					0.05
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 0.7f);
				yield return new WaitForSeconds(0.05f);
				iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.rotation[0],
					"islocal",
					true,
					"time",
					0.05
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 0.7f);
				yield return new WaitForSeconds(0.05f);
				this.errorActionIsPlaying = false;
				yield break;
			}
		}
		if (!this.isOn)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
			if (this.rotation.Length > 0)
			{
				iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.rotation[1],
					"islocal",
					true,
					"time",
					0.05,
					"onComplete",
					"LightOn",
					"onCompleteTarget",
					base.gameObject
				}));
			}
			else if (this.position.Length > 0)
			{
				iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.position[1],
					"islocal",
					true,
					"time",
					0.05,
					"onComplete",
					"LightOn",
					"onCompleteTarget",
					base.gameObject
				}));
			}
			yield break;
		}
		if (this.isOn)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
			if (this.rotation.Length > 0)
			{
				iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.rotation[0],
					"islocal",
					true,
					"time",
					0.05,
					"onComplete",
					"LightOff",
					"onCompleteTarget",
					base.gameObject
				}));
			}
			else if (this.position.Length > 0)
			{
				iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.position[1],
					"islocal",
					true,
					"time",
					0.05,
					"onComplete",
					"LightOff",
					"onCompleteTarget",
					base.gameObject
				}));
			}
			yield break;
		}
		yield break;
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x0008B608 File Offset: 0x00089A08
	public void NoPowerBackOff()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
		if (this.rotation.Length > 0)
		{
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotation[0],
				"islocal",
				true,
				"time",
				0.05
			}));
		}
		else if (this.position.Length > 0)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[0],
				"islocal",
				true,
				"time",
				0.05
			}));
		}
	}

	// Token: 0x06000709 RID: 1801 RVA: 0x0008B710 File Offset: 0x00089B10
	public void LightOn()
	{
		this.lightMesh.GetComponent<Renderer>().material = this.onMaterial;
		for (int i = 0; i < this.lightObj.Length; i++)
		{
			this.lightObj[i].active = true;
		}
		for (int j = 0; j < this.lightCone.Length; j++)
		{
			this.lightCone[j].active = true;
		}
		this.isOn = true;
		if (this.position.Length > 0)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[0],
				"islocal",
				true,
				"time",
				0.05
			}));
		}
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x0008B7F8 File Offset: 0x00089BF8
	public void LightOff()
	{
		this.lightMesh.GetComponent<Renderer>().material = this.offMaterial;
		for (int i = 0; i < this.lightObj.Length; i++)
		{
			this.lightObj[i].active = false;
		}
		for (int j = 0; j < this.lightCone.Length; j++)
		{
			this.lightCone[j].active = false;
		}
		this.isOn = false;
		if (this.position.Length > 0)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[0],
				"islocal",
				true,
				"time",
				0.05
			}));
		}
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x0008B8DF File Offset: 0x00089CDF
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x0008B8F9 File Offset: 0x00089CF9
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x0400097C RID: 2428
	public GameObject[] lightObj;

	// Token: 0x0400097D RID: 2429
	public GameObject[] lightCone;

	// Token: 0x0400097E RID: 2430
	public GameObject lightMesh;

	// Token: 0x0400097F RID: 2431
	public Material onMaterial;

	// Token: 0x04000980 RID: 2432
	public Material offMaterial;

	// Token: 0x04000981 RID: 2433
	public bool isOn;

	// Token: 0x04000982 RID: 2434
	public AudioClip audioClip;

	// Token: 0x04000983 RID: 2435
	public Vector3[] rotation;

	// Token: 0x04000984 RID: 2436
	public Vector3[] position;

	// Token: 0x04000985 RID: 2437
	private bool isGlowing;

	// Token: 0x04000986 RID: 2438
	public Material startMaterial;

	// Token: 0x04000987 RID: 2439
	public Material glowMaterial;

	// Token: 0x04000988 RID: 2440
	public bool isCarComponent;

	// Token: 0x04000989 RID: 2441
	private GameObject carLogic;

	// Token: 0x0400098A RID: 2442
	private bool errorActionIsPlaying;
}
