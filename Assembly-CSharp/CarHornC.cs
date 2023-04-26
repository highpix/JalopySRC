using System;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class CarHornC : MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x00002E65 File Offset: 0x00001265
	private void Start()
	{
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002E78 File Offset: 0x00001278
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if (this.isOn)
		{
			this.timeOn += Time.deltaTime;
			if ((double)this.timeOn >= 15.0)
			{
				this.BreakHorn();
			}
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0.0)
			{
				this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.01f * Time.deltaTime;
			}
			if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(this._camera.GetComponent<MainMenuC>().assignedInputStrings[16]) || Input.GetKeyUp(this._camera.GetComponent<MainMenuC>().assignedInputStrings[17]))
			{
				this.StopAction();
				return;
			}
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002FA0 File Offset: 0x000013A0
	public void BreakHorn()
	{
		this.isDead = true;
		this.audioSource.GetComponent<AudioSource>().clip = this.hornDeadAudio;
		this.audioSource.GetComponent<AudioSource>().loop = false;
		this.isOn = false;
		this.timeOn = 0f;
		if (this._steam == null)
		{
			this._steam = GameObject.FindWithTag("Steam");
		}
		if (this._steam != null)
		{
			this._steam.SendMessage("HornDead");
		}
	}

	// Token: 0x0600001C RID: 28 RVA: 0x0000302F File Offset: 0x0000142F
	public void StopAction()
	{
		this.timeOn = 0f;
		this.audioSource.GetComponent<AudioSource>().clip = this.hornEndAudio;
		this.audioSource.GetComponent<AudioSource>().loop = false;
		this.isOn = false;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000306C File Offset: 0x0000146C
	public void Trigger()
	{
		if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0.0 && !this.isDead)
		{
			this.audioSource.GetComponent<AudioSource>().clip = this.hornAudio;
			this.audioSource.GetComponent<AudioSource>().Play();
			this.audioSource.GetComponent<AudioSource>().loop = true;
			this.isOn = true;
		}
		else
		{
			this.audioSource.GetComponent<AudioSource>().clip = this.emptyAudio;
			this.audioSource.GetComponent<AudioSource>().Play();
			this.audioSource.GetComponent<AudioSource>().loop = false;
		}
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00003127 File Offset: 0x00001527
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00003146 File Offset: 0x00001546
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.GetComponent<Renderer>().material = this.startMaterial;
		if (this.isOn)
		{
			this.StopAction();
		}
	}

	// Token: 0x04000012 RID: 18
	private GameObject _camera;

	// Token: 0x04000013 RID: 19
	private float timeOn;

	// Token: 0x04000014 RID: 20
	private GameObject _steam;

	// Token: 0x04000015 RID: 21
	public bool isDead;

	// Token: 0x04000016 RID: 22
	public GameObject carLogic;

	// Token: 0x04000017 RID: 23
	public AudioClip hornAudio;

	// Token: 0x04000018 RID: 24
	public AudioClip hornEndAudio;

	// Token: 0x04000019 RID: 25
	public AudioClip emptyAudio;

	// Token: 0x0400001A RID: 26
	public AudioClip hornDeadAudio;

	// Token: 0x0400001B RID: 27
	public GameObject audioSource;

	// Token: 0x0400001C RID: 28
	public Material glowMaterial;

	// Token: 0x0400001D RID: 29
	public Material startMaterial;

	// Token: 0x0400001E RID: 30
	private bool isGlowing;

	// Token: 0x0400001F RID: 31
	private bool isOn;
}
