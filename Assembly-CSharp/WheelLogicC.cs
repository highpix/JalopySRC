using System;
using UnityEngine;

// Token: 0x0200011B RID: 283
public class WheelLogicC : MonoBehaviour
{
	// Token: 0x06000B15 RID: 2837 RVA: 0x0010302A File Offset: 0x0010142A
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.GetComponent<Renderer>().material;
	}

	// Token: 0x06000B16 RID: 2838 RVA: 0x00103050 File Offset: 0x00101450
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if (this.isPushingCar && (Input.GetButtonUp("Fire1") || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17])))
		{
			this.ExitPushState();
		}
	}

	// Token: 0x06000B17 RID: 2839 RVA: 0x001030E8 File Offset: 0x001014E8
	public void Trigger()
	{
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		if (this.director.GetComponent<DirectorC>().isSatAtBorder)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.7f);
			return;
		}
		if (!this.seatObj.GetComponent<SeatLogicC>().isSat)
		{
			this.EnterPushState();
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
		if (this.handBrake.GetComponent<HandbrakeLogicC>().currentPos == 0)
		{
			this.carLogic.GetComponent<CarLogicC>().DrivingGo();
			this.wheelTransforms.parent = this.carLogic.transform;
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().DrivingStop(false);
			GameObject.FindWithTag("Uncle").GetComponent<UncleLogicC>().HandBrakeCarStopped();
			this.wheelTransforms.parent = null;
		}
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x0010323C File Offset: 0x0010163C
	public void EnterPushState()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(this._camera.transform.position, -Vector3.up, out raycastHit) && raycastHit.transform.tag != "CarLogic")
		{
			this.isPushingCar = true;
			this.carLogic.GetComponent<CarLogicC>().PushCarGo();
			this.seatObj.SendMessage("PushStateGo");
		}
	}

	// Token: 0x06000B19 RID: 2841 RVA: 0x001032B1 File Offset: 0x001016B1
	public void ExitPushState()
	{
		this.isPushingCar = false;
		this.carLogic.GetComponent<CarLogicC>().PushCarStop();
		this.seatObj.SendMessage("PushStateStop");
		GameObject.FindWithTag("Uncle").GetComponent<UncleLogicC>().HandBrakeCarStopped();
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x001032EE File Offset: 0x001016EE
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000B1B RID: 2843 RVA: 0x0010330D File Offset: 0x0010170D
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F89 RID: 3977
	private GameObject _camera;

	// Token: 0x04000F8A RID: 3978
	public GameObject director;

	// Token: 0x04000F8B RID: 3979
	public GameObject carLogic;

	// Token: 0x04000F8C RID: 3980
	public GameObject handBrake;

	// Token: 0x04000F8D RID: 3981
	public GameObject seatObj;

	// Token: 0x04000F8E RID: 3982
	public Material glowMaterial;

	// Token: 0x04000F8F RID: 3983
	public Material startMaterial;

	// Token: 0x04000F90 RID: 3984
	private bool isGlowing;

	// Token: 0x04000F91 RID: 3985
	public Transform wheelTransforms;

	// Token: 0x04000F92 RID: 3986
	public AudioClip errorAudio;

	// Token: 0x04000F93 RID: 3987
	public bool isPushingCar;
}
