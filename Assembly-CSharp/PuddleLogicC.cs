using System;
using UnityEngine;

// Token: 0x020000EC RID: 236
public class PuddleLogicC : MonoBehaviour
{
	// Token: 0x0600095C RID: 2396 RVA: 0x000DF900 File Offset: 0x000DDD00
	private void Start()
	{
		this.director = GameObject.FindGameObjectWithTag("Director");
		float value = UnityEngine.Random.Range(-3.5f, 3.5f);
		base.transform.SetLocalX(value);
		base.transform.SetLocalY(0.001f);
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x000DF94C File Offset: 0x000DDD4C
	private void Reset()
	{
		PuddleLogic component = base.GetComponent<PuddleLogic>();
		component.splash.Copy(ref this.splash);
		this._particles = (component._particles as GameObject);
		this.splashMaterial = component.splashMaterial;
		this.wetness = component.wetness;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x000DF9A0 File Offset: 0x000DDDA0
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wheel")
		{
			if (this.wetness > 0)
			{
				other.gameObject.GetComponent<WheelScriptPCC>().wetAmount += (float)this.wetness;
				float currentSpeed = other.transform.root.GetComponent<CarCollisionsC>().carLogic.transform.root.GetComponent<CarControleScriptC>().currentSpeed;
				other.transform.root.GetComponent<Rigidbody>().AddForce(other.transform.right * (((currentSpeed <= 18f) ? 1f : 3f) * (float)this.wetness), ForceMode.Impulse);
			}
			if (this.wetness == 50)
			{
				other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarLogicC>().LightRainPuddleSplash();
			}
			if (this.wetness == 100)
			{
				other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarLogicC>().HeavyRainPuddleSplash();
			}
			if (other.transform.root.GetComponent<CarCollisionsC>().carLogic.transform.root.GetComponent<CarControleScriptC>().currentSpeed > 20f)
			{
				int num = UnityEngine.Random.Range(0, this.splash.Length - 1);
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 1)
				{
					this.director.GetComponent<DirectorC>().FLPuddleSplash();
					if (this.splashMaterial != null)
					{
						other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarLogicC>().puddleSplashL.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = this.splashMaterial;
						other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarLogicC>().puddleSplashL.GetComponent<ParticleSystem>().Play();
						base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.75f, 1.25f);
						base.GetComponent<AudioSource>().PlayOneShot(this.splash[num], 1f);
					}
				}
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 2)
				{
					this.director.GetComponent<DirectorC>().FRPuddleSplash();
					if (this.splashMaterial != null)
					{
						other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarLogicC>().puddleSplashR.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = this.splashMaterial;
						other.transform.root.GetComponent<CarCollisionsC>().carLogic.GetComponent<CarLogicC>().puddleSplashR.GetComponent<ParticleSystem>().Play();
						base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.75f, 1.25f);
						base.GetComponent<AudioSource>().PlayOneShot(this.splash[num], 1f);
					}
				}
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 3)
				{
					this.director.GetComponent<DirectorC>().RLPuddleSplash();
					base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.75f, 1.25f);
					base.GetComponent<AudioSource>().PlayOneShot(this.splash[num], 1f);
				}
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 4)
				{
					this.director.GetComponent<DirectorC>().RRPuddleSplash();
					base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.75f, 1.25f);
					base.GetComponent<AudioSource>().PlayOneShot(this.splash[num], 1f);
				}
			}
			else
			{
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 1)
				{
					this.director.GetComponent<DirectorC>().FLPuddleGlide();
				}
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 2)
				{
					this.director.GetComponent<DirectorC>().FRPuddleGlide();
				}
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 3)
				{
					this.director.GetComponent<DirectorC>().RLPuddleGlide();
				}
				if (other.gameObject.GetComponent<WheelScriptPCC>().wheelNumber == 4)
				{
					this.director.GetComponent<DirectorC>().RRPuddleGlide();
				}
			}
		}
	}

	// Token: 0x04000CC6 RID: 3270
	private GameObject director;

	// Token: 0x04000CC7 RID: 3271
	public AudioClip[] splash = new AudioClip[0];

	// Token: 0x04000CC8 RID: 3272
	public GameObject _particles;

	// Token: 0x04000CC9 RID: 3273
	public Material splashMaterial;

	// Token: 0x04000CCA RID: 3274
	public int wetness;
}
