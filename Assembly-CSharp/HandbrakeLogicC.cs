using System;
using UnityEngine;

// Token: 0x02000113 RID: 275
public class HandbrakeLogicC : MonoBehaviour
{
	// Token: 0x06000AD9 RID: 2777 RVA: 0x000FD4EE File Offset: 0x000FB8EE
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x000FD518 File Offset: 0x000FB918
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x000FD570 File Offset: 0x000FB970
	public void Trigger()
	{
		if (this.steeringWheel.GetComponent<WheelLogicC>().director == null)
		{
			this.steeringWheel.GetComponent<WheelLogicC>().director = GameObject.FindWithTag("Director");
		}
		if (this.steeringWheel.GetComponent<WheelLogicC>().director.GetComponent<DirectorC>().isSatAtBorder)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.7f);
			return;
		}
		if (!this.seatObj.GetComponent<SeatLogicC>().isSat)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.7f);
			return;
		}
		if (this.seatObj.GetComponent<SeatLogicC>().isSat && this.carLogic.GetComponent<CarLogicC>().preventHandBrake)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.7f);
			return;
		}
		if (!this.carLogic.GetComponent<CarLogicC>().engineOn)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.7f);
			return;
		}
		if (this.currentPos == 0)
		{
			this.carLogic.GetComponent<CarLogicC>().DrivingGo();
			this.wheelTransforms.parent = this.carLogic.transform;
			return;
		}
		if (this.currentPos == 1)
		{
			this.carLogic.GetComponent<CarLogicC>().DrivingStop(false);
			this.steeringWheel.GetComponent<WheelLogicC>().wheelTransforms.parent = null;
			GameObject.FindWithTag("Uncle").GetComponent<UncleLogicC>().HandBrakeCarStopped();
			return;
		}
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x000FD6FC File Offset: 0x000FBAFC
	public void ReleaseHandBrake()
	{
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 1;
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.positionRotation[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.handbrakeOnAudio, 0.7f);
			return;
		}
	}

	// Token: 0x06000ADD RID: 2781 RVA: 0x000FD7CC File Offset: 0x000FBBCC
	public void ApplyHandBrake()
	{
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 0;
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.positionRotation[0],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType2
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.handbrakeOnAudio, 0.7f);
			return;
		}
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x000FD89B File Offset: 0x000FBC9B
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x000FD8C9 File Offset: 0x000FBCC9
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F0D RID: 3853
	public GameObject carLogic;

	// Token: 0x04000F0E RID: 3854
	public Transform wheelTransforms;

	// Token: 0x04000F0F RID: 3855
	public GameObject steeringWheel;

	// Token: 0x04000F10 RID: 3856
	public GameObject seatObj;

	// Token: 0x04000F11 RID: 3857
	public float timeToComplete = 2.05f;

	// Token: 0x04000F12 RID: 3858
	public int currentPos;

	// Token: 0x04000F13 RID: 3859
	public Vector3[] positionRotation = new Vector3[0];

	// Token: 0x04000F14 RID: 3860
	public AudioClip handbrakeOffAudio;

	// Token: 0x04000F15 RID: 3861
	public AudioClip handbrakeOnAudio;

	// Token: 0x04000F16 RID: 3862
	public Material glowMaterial;

	// Token: 0x04000F17 RID: 3863
	public Material startMaterial;

	// Token: 0x04000F18 RID: 3864
	public string easeType = "easeoutelastic";

	// Token: 0x04000F19 RID: 3865
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000F1A RID: 3866
	public AudioClip errorAudio;

	// Token: 0x04000F1B RID: 3867
	private bool isGlowing;
}
