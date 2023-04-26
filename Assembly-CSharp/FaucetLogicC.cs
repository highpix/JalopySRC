using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000030 RID: 48
public class FaucetLogicC : MonoBehaviour
{
	// Token: 0x06000112 RID: 274 RVA: 0x00012560 File Offset: 0x00010960
	private void Reset()
	{
		FaucetLogic component = base.GetComponent<FaucetLogic>();
		this.audioDelay = component.audioDelay;
		this.coldWater = component.coldWater;
		this.hotWater = component.hotWater;
		this.steam = component.steam;
		this.waterAudio = component.waterAudio;
		this.hotValve = component.hotValve;
		this.coldValve = component.coldValve;
		this.bottleHolder = component.bottleHolder;
		this.faucetOffAudio = component.faucetOffAudio;
		component.enabled = false;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x000125E8 File Offset: 0x000109E8
	public IEnumerator TriggerOn()
	{
		this.coldWater.GetComponent<ParticleSystem>().Play();
		this.coldTapRunning = true;
		if (!this.hotTapRunning)
		{
			if (this.audioDelay > 0f)
			{
				yield return new WaitForSeconds(this.audioDelay);
			}
			base.GetComponent<AudioSource>().clip = this.waterAudio;
			base.GetComponent<AudioSource>().Play();
			base.GetComponent<AudioSource>().loop = true;
		}
		if (this.hotTapRunning)
		{
		}
		yield break;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00012604 File Offset: 0x00010A04
	public void TriggerOff()
	{
		this.coldTapRunning = false;
		this.coldWater.GetComponent<ParticleSystem>().Stop();
		if (!this.hotTapRunning)
		{
			base.GetComponent<AudioSource>().Stop();
			base.GetComponent<AudioSource>().loop = false;
			if (this.audioDelay == 0f)
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.faucetOffAudio, 0.1f);
			}
		}
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00012670 File Offset: 0x00010A70
	public void FunctionalLogicGo()
	{
		this.coldWater.active = false;
		this.hotWater.active = false;
		if (this.coldTapRunning && !this.hotTapRunning && this.bottleHolder.GetComponent<HoldingLogicC>().targetObject != null)
		{
			this.bottleHolder.GetComponent<HoldingLogicC>().targetObject.SendMessage("FillBottleColdWater");
		}
		if (this.hotTapRunning && this.bottleHolder.GetComponent<HoldingLogicC>().targetObject != null)
		{
			this.bottleHolder.GetComponent<HoldingLogicC>().targetObject.SendMessage("FillBottleHotWater");
		}
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00012720 File Offset: 0x00010B20
	public void FunctionalLogicStop()
	{
		this.coldWater.active = true;
		this.hotWater.active = true;
		if (this.hotValve.GetComponent<OvenDialC>().currentPos == 1)
		{
			this.hotValve.SendMessage("Trigger");
		}
		if (this.coldValve.GetComponent<OvenDialC>().currentPos == 1)
		{
			this.coldValve.SendMessage("Trigger");
		}
	}

	// Token: 0x06000117 RID: 279 RVA: 0x00012794 File Offset: 0x00010B94
	public void HotTapOn()
	{
		this.hotTapRunning = true;
		this.hotWater.GetComponent<ParticleSystem>().Play();
		if (!this.coldTapRunning)
		{
			base.GetComponent<AudioSource>().clip = this.waterAudio;
			base.GetComponent<AudioSource>().Play();
			base.GetComponent<AudioSource>().loop = true;
		}
		if (this.bottleHolder != null && this.bottleHolder.GetComponent<HoldingLogicC>().targetObject != null)
		{
			this.bottleHolder.GetComponent<HoldingLogicC>().targetObject.SendMessage("FillBottleHotWater");
		}
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00012834 File Offset: 0x00010C34
	public void HotTapOff()
	{
		this.hotWater.GetComponent<ParticleSystem>().Stop();
		this.hotTapRunning = false;
		if (!this.coldTapRunning)
		{
			base.GetComponent<AudioSource>().Stop();
			base.GetComponent<AudioSource>().loop = false;
			base.GetComponent<AudioSource>().PlayOneShot(this.faucetOffAudio, 0.1f);
		}
	}

	// Token: 0x0400021F RID: 543
	public float audioDelay;

	// Token: 0x04000220 RID: 544
	public GameObject coldWater;

	// Token: 0x04000221 RID: 545
	public GameObject hotWater;

	// Token: 0x04000222 RID: 546
	public GameObject steam;

	// Token: 0x04000223 RID: 547
	public AudioClip waterAudio;

	// Token: 0x04000224 RID: 548
	private bool hotTapRunning;

	// Token: 0x04000225 RID: 549
	private bool coldTapRunning;

	// Token: 0x04000226 RID: 550
	public GameObject hotValve;

	// Token: 0x04000227 RID: 551
	public GameObject coldValve;

	// Token: 0x04000228 RID: 552
	public GameObject bottleHolder;

	// Token: 0x04000229 RID: 553
	public AudioClip faucetOffAudio;
}
