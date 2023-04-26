using System;
using UnityEngine;

// Token: 0x0200010E RID: 270
public class SeatLogicC : MonoBehaviour
{
	// Token: 0x06000AA5 RID: 2725 RVA: 0x000F9E31 File Offset: 0x000F8231
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.GetComponent<Renderer>().material;
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x000F9E54 File Offset: 0x000F8254
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if (base.GetComponent<AudioSource>().volume < 1f && this.rainAudioPlay)
		{
			base.GetComponent<AudioSource>().volume += 0.1f * Time.deltaTime;
		}
		if (base.GetComponent<AudioSource>().volume > 0f && !this.rainAudioPlay)
		{
			base.GetComponent<AudioSource>().volume -= 0.1f * Time.deltaTime;
		}
		if (base.GetComponent<AudioSource>().volume < 0.05f && !this.rainAudioPlay)
		{
			base.GetComponent<AudioSource>().Stop();
		}
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x000F9F40 File Offset: 0x000F8340
	public void Trigger()
	{
		if (this.driverDoor.GetComponent<DoorLogicC>().open)
		{
			this.doorExit.SetActive(true);
		}
		this._camera.GetComponent<DragRigidbodyC>().StartCoroutine("DropAllItems");
		this.isSat = true;
		this.player.GetComponent<RigidbodyControllerC>().isSat = true;
		this.player.GetComponent<MouseLook>().isSat = true;
		this._camera.GetComponent<MouseLook>().isSat = true;
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		if (gameObject.GetComponent<UncleLogicC>().firstTimeBoarding)
		{
			gameObject.GetComponent<Scene1_LogicC>().StartCoroutine("CarEnter");
			gameObject.GetComponent<UncleLogicC>().firstTimeBoarding = false;
		}
		this.RainInteriorAudio();
		RigidbodyControllerC component = this._camera.transform.parent.GetComponent<RigidbodyControllerC>();
		component.speed = 8f;
		FootstepsC component2 = this._camera.transform.parent.GetComponent<FootstepsC>();
		component2.audioStepLength = 0.3f;
		this._camera.transform.localPosition = Vector3.up * 0.8f;
		this._camera.GetComponent<DragRigidbodyC>().enabled = false;
		base.gameObject.tag = "Untagged";
		this.player = this._camera.transform.parent.gameObject;
		this.player.GetComponent<FootstepsC>().isPlayerWalking = 0f;
		this.player.GetComponent<FootstepsC>().enabled = false;
		this.player.GetComponent<AudioSource>().Stop();
		if (this.player.GetComponent<CharacterController>())
		{
			this.player.GetComponent<CharacterController>().enabled = false;
		}
		if (this.player.GetComponent<Rigidbody>())
		{
			this.player.GetComponent<Rigidbody>().isKinematic = true;
			this.player.GetComponent<Rigidbody>().detectCollisions = false;
			this.player.GetComponent<CapsuleCollider>().enabled = false;
		}
		this._camera.GetComponent<MouseLook>().enabled = false;
		this.player.GetComponent<MouseLook>().enabled = false;
		this.player.transform.MoveRotateTo(this.seatLoc.position, base.transform.eulerAngles, this.tweenTime, 0f, this, delegate()
		{
			this.RestoreControl();
		});
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x000FA1A0 File Offset: 0x000F85A0
	public void RainInteriorAudio()
	{
		if (base.transform.parent.gameObject.GetComponent<CarLogicC>().rainLvl > 0)
		{
			base.GetComponent<AudioSource>().Play();
			this.rainAudioPlay = true;
			base.GetComponent<AudioSource>().volume = 1f;
		}
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x000FA1EF File Offset: 0x000F85EF
	public void ForceRainAudio()
	{
		base.GetComponent<AudioSource>().Play();
		this.rainAudioPlay = true;
		base.GetComponent<AudioSource>().volume = 1f;
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x000FA213 File Offset: 0x000F8613
	public void StopInteriorRainAudio()
	{
		if (base.transform.parent.gameObject.GetComponent<CarLogicC>().rainLvl > 0)
		{
			this.rainAudioPlay = false;
		}
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x000FA23C File Offset: 0x000F863C
	public void ForceStopInterirorRainAudio()
	{
		base.GetComponent<AudioSource>().Stop();
		this.rainAudioPlay = false;
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x000FA250 File Offset: 0x000F8650
	public void PushStateGo()
	{
		this.player.transform.parent = this.seatLoc.transform;
		this.player.GetComponent<RigidbodyControllerC>().isSat = true;
		this.player.GetComponent<Rigidbody>().isKinematic = true;
		this.player.GetComponent<Rigidbody>().detectCollisions = false;
		this.player.GetComponent<CapsuleCollider>().enabled = false;
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x000FA2BC File Offset: 0x000F86BC
	public void PushStateStop()
	{
		this.player.transform.parent = null;
		this.player.GetComponent<RigidbodyControllerC>().isSat = false;
		this.player.GetComponent<CapsuleCollider>().enabled = true;
		this.player.GetComponent<Rigidbody>().isKinematic = false;
		this.player.GetComponent<Rigidbody>().detectCollisions = true;
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x000FA320 File Offset: 0x000F8720
	public void RestoreControl()
	{
		if (MainMenuC.Global.mouseSmooth)
		{
			this._camera.GetComponent<MouseLook>().yTargetRotation = this._camera.transform.localRotation.y;
			this.player.GetComponent<MouseLook>().xTargetRotation = this.player.transform.localRotation.x;
		}
		this.player.transform.parent = this.seatLoc.transform;
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		this._camera.GetComponent<MouseLook>().enabled = true;
		this.player.GetComponent<MouseLook>().enabled = true;
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x000FA3DA File Offset: 0x000F87DA
	public void RaycastEnter()
	{
		if (base.gameObject.tag != "Interactor")
		{
			return;
		}
		this.isGlowing = true;
		base.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x000FA40F File Offset: 0x000F880F
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000EB7 RID: 3767
	private GameObject _camera;

	// Token: 0x04000EB8 RID: 3768
	public Transform seatLoc;

	// Token: 0x04000EB9 RID: 3769
	public GameObject player;

	// Token: 0x04000EBA RID: 3770
	public GameObject driverDoor;

	// Token: 0x04000EBB RID: 3771
	public GameObject doorExit;

	// Token: 0x04000EBC RID: 3772
	public float tweenTime;

	// Token: 0x04000EBD RID: 3773
	public string easeType = string.Empty;

	// Token: 0x04000EBE RID: 3774
	public string rotEaseType = string.Empty;

	// Token: 0x04000EBF RID: 3775
	public Material startMaterial;

	// Token: 0x04000EC0 RID: 3776
	public Material glowMaterial;

	// Token: 0x04000EC1 RID: 3777
	public bool isGlowing;

	// Token: 0x04000EC2 RID: 3778
	public bool isSat;

	// Token: 0x04000EC3 RID: 3779
	[HideInInspector]
	public bool rainAudioPlay;
}
