using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class FootstepsC : MonoBehaviour
{
	// Token: 0x06000668 RID: 1640 RVA: 0x00081730 File Offset: 0x0007FB30
	private void Update()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, -Vector3.up, out raycastHit))
		{
			float distance = raycastHit.distance;
			if (raycastHit.collider.tag == "Carpet" || raycastHit.collider.tag == "Dirt")
			{
				this.groundType = 1;
			}
			else if (raycastHit.collider.tag == "Wood")
			{
				this.groundType = 2;
			}
			else if (raycastHit.collider.tag == "Concrete")
			{
				this.groundType = 3;
			}
			else if (raycastHit.collider.tag == "Metal")
			{
				this.groundType = 4;
			}
		}
		if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
		{
			this.isPlayerWalking += Time.deltaTime;
		}
		else
		{
			this.isPlayerWalking = 0f;
		}
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x00081858 File Offset: 0x0007FC58
	private void Start()
	{
		base.StartCoroutine(this.LateStart());
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x00081868 File Offset: 0x0007FC68
	private IEnumerator LateStart()
	{
		this.director = GameObject.FindWithTag("Director");
		for (;;)
		{
			if ((double)this.isPlayerWalking >= 0.2 && this.groundType == 1)
			{
				yield return new WaitForSeconds(this.delayBeforeSteps);
				base.GetComponent<AudioSource>().clip = this.stepCarpet[UnityEngine.Random.Range(0, this.stepCarpet.Length)];
				base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.25f - this.footAudioRandomness, 0.25f + this.footAudioRandomness);
				base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
				base.GetComponent<AudioSource>().Play();
				this.director.GetComponent<DirectorC>().footSteps++;
				if (this.isPlayerWalking == 0f)
				{
					yield return new WaitForEndOfFrame();
				}
				else
				{
					yield return new WaitForSeconds(this.delayBetweenSteps);
					base.GetComponent<AudioSource>().clip = this.stepCarpet[UnityEngine.Random.Range(0, this.stepCarpet.Length)];
					base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.25f - this.footAudioRandomness, 0.25f + this.footAudioRandomness);
					base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
					base.GetComponent<AudioSource>().Play();
					this.director.GetComponent<DirectorC>().footSteps++;
					yield return new WaitForSeconds(this.audioStepLength);
					if (this.isPlayerWalking == 0f)
					{
						yield return new WaitForEndOfFrame();
					}
				}
			}
			else if ((double)this.isPlayerWalking >= 0.2 && this.groundType == 2)
			{
				yield return new WaitForSeconds(this.delayBeforeSteps);
				base.GetComponent<AudioSource>().clip = this.stepWood[UnityEngine.Random.Range(0, this.stepWood.Length)];
				base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.6f - this.footAudioRandomness, 0.6f + this.footAudioRandomness);
				base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
				base.GetComponent<AudioSource>().Play();
				this.director.GetComponent<DirectorC>().footSteps++;
				if (this.isPlayerWalking == 0f)
				{
					yield return new WaitForEndOfFrame();
				}
				else
				{
					yield return new WaitForSeconds(this.delayBetweenSteps);
					base.GetComponent<AudioSource>().clip = this.stepWood[UnityEngine.Random.Range(0, this.stepWood.Length)];
					base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.6f - this.footAudioRandomness, 0.6f + this.footAudioRandomness);
					base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
					base.GetComponent<AudioSource>().Play();
					this.director.GetComponent<DirectorC>().footSteps++;
					yield return new WaitForSeconds(this.audioStepLength);
					if (this.isPlayerWalking == 0f)
					{
						yield return new WaitForEndOfFrame();
					}
				}
			}
			else if ((double)this.isPlayerWalking >= 0.2 && this.groundType == 3)
			{
				yield return new WaitForSeconds(this.delayBeforeSteps);
				base.GetComponent<AudioSource>().clip = this.stepConcrete[UnityEngine.Random.Range(0, this.stepConcrete.Length)];
				base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.45f - this.footAudioRandomness, 0.45f + this.footAudioRandomness);
				base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
				base.GetComponent<AudioSource>().Play();
				this.director.GetComponent<DirectorC>().footSteps++;
				if (this.isPlayerWalking == 0f)
				{
					yield return new WaitForEndOfFrame();
				}
				else
				{
					yield return new WaitForSeconds(this.delayBetweenSteps);
					base.GetComponent<AudioSource>().clip = this.stepConcrete[UnityEngine.Random.Range(0, this.stepConcrete.Length)];
					base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.45f - this.footAudioRandomness, 0.45f + this.footAudioRandomness);
					base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
					base.GetComponent<AudioSource>().Play();
					this.director.GetComponent<DirectorC>().footSteps++;
					yield return new WaitForSeconds(this.audioStepLength);
					if (this.isPlayerWalking == 0f)
					{
						yield return new WaitForEndOfFrame();
					}
				}
			}
			else if ((double)this.isPlayerWalking >= 0.2 && this.groundType == 4)
			{
				yield return new WaitForSeconds(this.delayBeforeSteps);
				base.GetComponent<AudioSource>().clip = this.stepMetal[UnityEngine.Random.Range(0, this.stepMetal.Length)];
				base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.45f - this.footAudioRandomness, 0.45f + this.footAudioRandomness);
				base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
				base.GetComponent<AudioSource>().Play();
				this.director.GetComponent<DirectorC>().footSteps++;
				if (this.isPlayerWalking == 0f)
				{
					yield return new WaitForEndOfFrame();
				}
				else
				{
					yield return new WaitForSeconds(this.delayBetweenSteps);
					base.GetComponent<AudioSource>().clip = this.stepMetal[UnityEngine.Random.Range(0, this.stepMetal.Length)];
					base.GetComponent<AudioSource>().volume = UnityEngine.Random.Range(0.45f - this.footAudioRandomness, 0.45f + this.footAudioRandomness);
					base.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f - this.soundEffectPitchRandomness, 1f + this.soundEffectPitchRandomness);
					base.GetComponent<AudioSource>().Play();
					this.director.GetComponent<DirectorC>().footSteps++;
					yield return new WaitForSeconds(this.audioStepLength);
					if (this.isPlayerWalking == 0f)
					{
						yield return new WaitForEndOfFrame();
					}
				}
			}
			else
			{
				yield return new WaitForEndOfFrame();
			}
		}
		yield break;
	}

	// Token: 0x04000895 RID: 2197
	public AudioClip[] stepWood = new AudioClip[0];

	// Token: 0x04000896 RID: 2198
	public AudioClip[] stepCarpet = new AudioClip[0];

	// Token: 0x04000897 RID: 2199
	public AudioClip[] stepConcrete = new AudioClip[0];

	// Token: 0x04000898 RID: 2200
	public AudioClip[] stepMetal = new AudioClip[0];

	// Token: 0x04000899 RID: 2201
	public float delayBeforeSteps = 0.2f;

	// Token: 0x0400089A RID: 2202
	public float delayBetweenSteps = 0.45f;

	// Token: 0x0400089B RID: 2203
	public float audioStepLength = 0.6f;

	// Token: 0x0400089C RID: 2204
	public int groundType;

	// Token: 0x0400089D RID: 2205
	public float isPlayerWalking;

	// Token: 0x0400089E RID: 2206
	public float footAudioRandomness = 0.1f;

	// Token: 0x0400089F RID: 2207
	public float soundEffectPitchRandomness = 0.05f;

	// Token: 0x040008A0 RID: 2208
	private GameObject director;
}
