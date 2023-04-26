using System;
using UnityEngine;

// Token: 0x0200008B RID: 139
public class AlarmClockC : MonoBehaviour
{
	// Token: 0x06000434 RID: 1076 RVA: 0x00046A04 File Offset: 0x00044E04
	private void Start()
	{
		if (ES3.Exists("alarmSilent"))
		{
			this.isSilent = ES3.LoadBool("alarmSilent");
		}
		if (!this.isSilent)
		{
			if (this.isHomeClock)
			{
				this.AlarmGo();
			}
		}
		else
		{
			this.alarmButton.transform.localPosition = new Vector3(0f, -0.001129985f, 0.006334074f);
		}
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x00046A75 File Offset: 0x00044E75
	public void AlarmGo()
	{
		base.GetComponent<AudioSource>().clip = this.alarmAudio;
		base.GetComponent<AudioSource>().loop = true;
		base.GetComponent<AudioSource>().Play();
		this.timerGo = true;
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x00046AA8 File Offset: 0x00044EA8
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.alarmButton.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if (this.timerGo)
		{
			this.timer += Time.deltaTime;
		}
		if ((double)this.timer > 7.0 && this.timerGo)
		{
			this.Trigger();
		}
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00046B34 File Offset: 0x00044F34
	public void Trigger()
	{
		this.timerGo = false;
		this.timer = 0f;
		if (!this.isSilent)
		{
			this.isSilent = true;
			iTween.MoveTo(this.alarmButton, iTween.Hash(new object[]
			{
				"position",
				new Vector3(0f, -0.001129985f, 0.006334074f),
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeoutquint",
				"oncomplete",
				"ButtonBack",
				"oncompletetarget",
				base.gameObject
			}));
		}
		else
		{
			this.isSilent = false;
			iTween.MoveTo(this.alarmButton, iTween.Hash(new object[]
			{
				"position",
				new Vector3(0f, 0.00242424f, 0.006334074f),
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeoutquint",
				"oncomplete",
				"ButtonBack",
				"oncompletetarget",
				base.gameObject
			}));
		}
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x00046CA3 File Offset: 0x000450A3
	public void ButtonBack()
	{
		base.GetComponent<AudioSource>().Stop();
		base.GetComponent<AudioSource>().PlayOneShot(this.clickAudio, 1f);
		ES2.Save<bool>(this.isSilent, "alarmSilent");
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x00046CD6 File Offset: 0x000450D6
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.alarmButton.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x00046CF5 File Offset: 0x000450F5
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.alarmButton.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000629 RID: 1577
	public AudioClip alarmAudio;

	// Token: 0x0400062A RID: 1578
	public GameObject alarmButton;

	// Token: 0x0400062B RID: 1579
	public AudioClip clickAudio;

	// Token: 0x0400062C RID: 1580
	public bool isHomeClock;

	// Token: 0x0400062D RID: 1581
	private bool isGlowing;

	// Token: 0x0400062E RID: 1582
	public Material startMaterial;

	// Token: 0x0400062F RID: 1583
	public Material glowMaterial;

	// Token: 0x04000630 RID: 1584
	public bool timerGo;

	// Token: 0x04000631 RID: 1585
	public float timer;

	// Token: 0x04000632 RID: 1586
	public bool isSilent;
}
