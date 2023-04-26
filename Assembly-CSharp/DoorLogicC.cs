using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000112 RID: 274
public class DoorLogicC : MonoBehaviour
{
	// Token: 0x06000ACE RID: 2766 RVA: 0x000FBA28 File Offset: 0x000F9E28
	private void Start()
	{
		if (this.handle != null)
		{
			this.startMaterial = this.handle.GetComponent<Renderer>().material;
			if (!this.isEnvironmentalDoor)
			{
			}
		}
		if (this.handle2 != null)
		{
			this.startMaterial2 = this.handle2.GetComponent<Renderer>().material;
		}
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x000FBA90 File Offset: 0x000F9E90
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.handle.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			if (this.handle2 != null)
			{
				this.handle2.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x000FBB08 File Offset: 0x000F9F08
	public IEnumerator Trigger()
	{
		if (this.windowScriptTrgt == null)
		{
			if (!this.open)
			{
				if (this.isBroken && UnityEngine.Random.value >= this.brokenDoorFailChance && this.handle != null)
				{
					if (this.isPushHandle)
					{
						iTween.MoveTo(this.handle, iTween.Hash(new object[]
						{
							"position",
							this.handleRotate,
							"islocal",
							true,
							"time",
							1.25,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
					}
					if (!this.isPushHandle)
					{
						iTween.RotateTo(this.handle, iTween.Hash(new object[]
						{
							"rotation",
							this.handleRotate,
							"islocal",
							true,
							"time",
							0.25,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
						if (this.handle2 != null && this.isEnvironmentalDoor)
						{
							iTween.RotateTo(this.handle2, iTween.Hash(new object[]
							{
								"rotation",
								this.handle2Rotate,
								"islocal",
								true,
								"time",
								0.25
							}));
						}
					}
					iTween.Stop(this.carFrame, "PunchRotation");
					this.carFrame.transform.localEulerAngles = new Vector3(this.carFrame.transform.localEulerAngles.x, this.carFrame.transform.localEulerAngles.y, 0f);
					iTween.PunchRotation(this.carFrame, iTween.Hash(new object[]
					{
						"z",
						-1.6,
						"easetype",
						"easeInCirc",
						"islocal",
						true,
						"time",
						1.75
					}));
					base.GetComponent<AudioSource>().PlayOneShot(this.shakeSFX, 0.7f);
					yield break;
				}
				base.GetComponent<AudioSource>().PlayOneShot(this.openSFX, 0.7f);
				if (!this.isLocked)
				{
					iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
					{
						"rotation",
						this.xyzOpen,
						"time",
						1.2,
						"islocal",
						true,
						"delay",
						0.2,
						"oncomplete",
						"UncleLogic",
						"oncompletetarget",
						base.gameObject
					}));
					this.open = true;
					if (!this.isEnvironmentalDoor && this.carSeat != null && this.driversDoor && !this.carLogic.GetComponent<CarLogicC>().isDriving && this.carSeat.GetComponent<SeatLogicC>().isSat)
					{
						this.doorExit.gameObject.SetActive(true);
						Debug.Log("Door Exit to true");
					}
					if (this.isBoot)
					{
						if (this.bootToolRack.activeInHierarchy)
						{
							this.bootToolRack.GetComponent<ToolRackC>().Wiggle();
						}
						if (ES3.Exists("savedStolenGoods"))
						{
							bool flag = ES3.LoadBool("savedStolenGoods");
							if (flag)
							{
								GameObject gameObject = GameObject.FindWithTag("Steam");
								if (gameObject != null)
								{
									gameObject.SendMessage("ThiefAchieve", SendMessageOptions.DontRequireReceiver);
								}
							}
						}
					}
				}
				if (this.isLocked)
				{
					base.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.lockedAudio, 1f);
				}
				if (this.handle != null)
				{
					if (this.isPushHandle)
					{
						iTween.MoveTo(this.handle, iTween.Hash(new object[]
						{
							"position",
							this.handleRotate,
							"islocal",
							true,
							"time",
							0.4,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
					}
					if (!this.isPushHandle)
					{
						iTween.RotateTo(this.handle, iTween.Hash(new object[]
						{
							"rotation",
							this.handleRotate,
							"islocal",
							true,
							"time",
							0.25,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
						if (this.handle2 != null && this.isEnvironmentalDoor)
						{
							iTween.RotateTo(this.handle2, iTween.Hash(new object[]
							{
								"rotation",
								this.handle2Rotate,
								"islocal",
								true,
								"time",
								0.25
							}));
						}
					}
				}
				yield break;
			}
			else if (this.open)
			{
				if (!this.isEnvironmentalDoor && this.carSeat != null && this.driversDoor && !this.carLogic.GetComponent<CarLogicC>().isDriving && this.carSeat.GetComponent<SeatLogicC>().isSat)
				{
					this.doorExit.gameObject.SetActive(false);
					Debug.Log("Door exit to false");
				}
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.xyzClosed,
					"time",
					0.3,
					"islocal",
					true,
					"easetype",
					"easeInCirc",
					"onComplete",
					"DoorClosed",
					"onCompleteTarget",
					base.gameObject
				}));
				if (this.isBoot && this.bootToolRack.activeInHierarchy)
				{
					this.bootToolRack.GetComponent<ToolRackC>().Close();
				}
				yield return new WaitForSeconds(0.28f);
				base.GetComponent<AudioSource>().PlayOneShot(this.closeSFX, 0.7f);
				yield break;
			}
		}
		else
		{
			if (this.isLocked)
			{
				iTween.RotateTo(this.handle, iTween.Hash(new object[]
				{
					"rotation",
					this.handleRotate,
					"islocal",
					true,
					"time",
					0.25,
					"onComplete",
					"HandleComplete",
					"onCompleteTarget",
					base.gameObject
				}));
				iTween.Stop(this.carFrame, "PunchRotation");
				this.carFrame.transform.localEulerAngles = new Vector3(this.carFrame.transform.localEulerAngles.x, this.carFrame.transform.localEulerAngles.y, 0f);
				iTween.PunchRotation(this.carFrame, iTween.Hash(new object[]
				{
					"z",
					-1.6,
					"easetype",
					"easeInCirc",
					"islocal",
					true,
					"time",
					1.75
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.shakeSFX, 0.7f);
				yield break;
			}
			if (!this.open)
			{
				base.StartCoroutine("DoorExitCheck");
				if (this.isBroken && UnityEngine.Random.value >= this.brokenDoorFailChance && this.handle != null)
				{
					if (this.isPushHandle)
					{
						iTween.MoveTo(this.handle, iTween.Hash(new object[]
						{
							"position",
							this.handleRotate,
							"islocal",
							true,
							"time",
							1.25,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
					}
					if (!this.isPushHandle)
					{
						iTween.RotateTo(this.handle, iTween.Hash(new object[]
						{
							"rotation",
							this.handleRotate,
							"islocal",
							true,
							"time",
							0.25,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
					}
					iTween.Stop(this.carFrame, "PunchRotation");
					this.carFrame.transform.localEulerAngles = new Vector3(this.carFrame.transform.localEulerAngles.x, this.carFrame.transform.localEulerAngles.y, 0f);
					iTween.PunchRotation(this.carFrame, iTween.Hash(new object[]
					{
						"z",
						-1.6,
						"easetype",
						"easeInCirc",
						"islocal",
						true,
						"time",
						1.75
					}));
					base.GetComponent<AudioSource>().PlayOneShot(this.shakeSFX, 0.7f);
					float distanceToCarEntrance = this.uncleObj.GetComponent<UncleLogicC>().distanceToCarEntrance;
					if ((double)distanceToCarEntrance <= 0.35)
					{
						this.uncleObj.GetComponent<UncleLogicC>().consecutiveDoorFails++;
						int num = UnityEngine.Random.Range(3, 5);
						if (this.spokenAboutDoorAmount == 0)
						{
							if (num == this.uncleObj.GetComponent<UncleLogicC>().consecutiveDoorFails)
							{
								base.StartCoroutine(this.uncleObj.GetComponent<UncleLogicC>().ComplainAboutBrokenDoor1());
								this.spokenAboutDoorAmount++;
							}
						}
						else if (num == this.uncleObj.GetComponent<UncleLogicC>().consecutiveDoorFails)
						{
							base.StartCoroutine(this.uncleObj.GetComponent<UncleLogicC>().ComplainAboutBrokenDoor2());
							this.spokenAboutDoorAmount++;
						}
					}
					yield break;
				}
				base.GetComponent<AudioSource>().PlayOneShot(this.openSFX, 0.7f);
				this.DoorOpen();
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.xyzOpen,
					"time",
					1.2,
					"islocal",
					true,
					"delay",
					0.2
				}));
				this.open = true;
				if (this.driversDoor && this.uncleObj != null)
				{
					this.uncleObj.SendMessage("PlayerOpensDriverDoor", SendMessageOptions.DontRequireReceiver);
				}
				if (this.handle != null)
				{
					if (this.isPushHandle)
					{
						iTween.MoveTo(this.handle, iTween.Hash(new object[]
						{
							"position",
							this.handleRotate,
							"islocal",
							true,
							"time",
							0.4,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
					}
					if (!this.isPushHandle)
					{
						iTween.RotateTo(this.handle, iTween.Hash(new object[]
						{
							"rotation",
							this.handleRotate,
							"islocal",
							true,
							"time",
							0.25,
							"onComplete",
							"HandleComplete",
							"onCompleteTarget",
							base.gameObject
						}));
					}
				}
				yield break;
			}
			else if (this.open)
			{
				if (!this.isEnvironmentalDoor && this.driversDoor && !this.carLogic.GetComponent<CarLogicC>().isDriving && this.carSeat.GetComponent<SeatLogicC>().isSat)
				{
					this.doorExit.gameObject.SetActive(false);
				}
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.xyzClosed,
					"time",
					0.3,
					"islocal",
					true,
					"easetype",
					"easeInCirc",
					"onComplete",
					"DoorClosed",
					"onCompleteTarget",
					base.gameObject
				}));
				if (this.isUncleDoor)
				{
					this.uncleObj.GetComponent<UncleLogicC>().CarDoorClosed();
				}
				yield return new WaitForSeconds(0.28f);
				base.GetComponent<AudioSource>().PlayOneShot(this.closeSFX, 0.7f);
				yield break;
			}
		}
		yield break;
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x000FBB24 File Offset: 0x000F9F24
	public void HandleComplete()
	{
		if (this.isPushHandle)
		{
			iTween.MoveTo(this.handle, iTween.Hash(new object[]
			{
				"position",
				this.handleOriginalRot,
				"time",
				0.4,
				"islocal",
				true
			}));
		}
		else
		{
			iTween.RotateTo(this.handle, iTween.Hash(new object[]
			{
				"rotation",
				this.handleOriginalRot,
				"time",
				0.4,
				"islocal",
				true
			}));
		}
		if (this.isEnvironmentalDoor && this.handle2 != null && this.isPushHandle)
		{
			iTween.MoveTo(this.handle2, iTween.Hash(new object[]
			{
				"position",
				this.handle2OriginalRot,
				"time",
				0.4,
				"islocal",
				true
			}));
		}
		if (this.isEnvironmentalDoor && this.handle2 != null && !this.isPushHandle)
		{
			iTween.RotateTo(this.handle2, iTween.Hash(new object[]
			{
				"rotation",
				this.handle2OriginalRot,
				"time",
				0.4,
				"islocal",
				true
			}));
		}
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x000FBCE8 File Offset: 0x000FA0E8
	public void DoorClosed()
	{
		this.open = false;
		if (this.carSeat != null && this.carSeat.GetComponent<SeatLogicC>().isSat && !this.windowScriptTrgt.GetComponent<WindowLogicC>().isOpen && !this.passengerWindowScriptTrgt.GetComponent<WindowLogicC>().isOpen && !this.passengerDoor.GetComponent<DoorLogicC>().open)
		{
			GameObject gameObject = GameObject.FindWithTag("Director");
			GameObject uDayCycle = gameObject.GetComponent<RouteGeneratorC>().uDayCycle;
			uDayCycle.GetComponent<DNC_soundEffect>().inCarVolume = true;
			this.carLogic.GetComponent<CarLogicC>().LowerEngineAudio();
			this.carLogic.GetComponent<CarLogicC>().frontLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = true;
			this.carLogic.GetComponent<CarLogicC>().frontRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = true;
			this.carLogic.GetComponent<CarLogicC>().rearLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = true;
			this.carLogic.GetComponent<CarLogicC>().rearRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = true;
			if (gameObject.GetComponent<RouteGeneratorC>().aiDrivers.Length > 0)
			{
				for (int i = 0; i < gameObject.GetComponent<RouteGeneratorC>().aiDrivers.Length; i++)
				{
					if (gameObject.GetComponent<RouteGeneratorC>().aiDrivers[i] != null)
					{
						gameObject.GetComponent<RouteGeneratorC>().aiDrivers[i].SendMessage("VolumeLower", SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x000FBE64 File Offset: 0x000FA264
	private IEnumerator DoorExitCheck()
	{
		yield return new WaitForSeconds(0.5f);
		if (!this.isEnvironmentalDoor && this.driversDoor && !this.carLogic.GetComponent<CarLogicC>().isDriving && this.carSeat.GetComponent<SeatLogicC>().isSat)
		{
			this.doorExit.gameObject.SetActive(true);
		}
		yield break;
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x000FBE80 File Offset: 0x000FA280
	public void DoorOpen()
	{
		if (this.isUncleDoor)
		{
			this.uncleObj.GetComponent<UncleLogicC>().consecutiveDoorFails = 0;
			this.uncleObj.GetComponent<UncleLogicC>().CarDoorOpen();
		}
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject uDayCycle = gameObject.GetComponent<RouteGeneratorC>().uDayCycle;
		uDayCycle.GetComponent<DNC_soundEffect>().inCarVolume = false;
		this.carLogic.GetComponent<CarLogicC>().HigherEngineAudio();
		this.carLogic.GetComponent<CarLogicC>().frontLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
		this.carLogic.GetComponent<CarLogicC>().frontRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
		this.carLogic.GetComponent<CarLogicC>().rearLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
		this.carLogic.GetComponent<CarLogicC>().rearRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
		if (gameObject.GetComponent<RouteGeneratorC>().aiDrivers.Length > 0)
		{
			for (int i = 0; i < gameObject.GetComponent<RouteGeneratorC>().aiDrivers.Length; i++)
			{
				if (gameObject.GetComponent<RouteGeneratorC>().aiDrivers[i] != null)
				{
					gameObject.GetComponent<RouteGeneratorC>().aiDrivers[i].SendMessage("VolumeHigher", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x000FBFBC File Offset: 0x000FA3BC
	public void CarShake()
	{
		iTween.Stop(this.carFrame, "PunchRotation");
		this.carFrame.transform.localEulerAngles = new Vector3(this.carFrame.transform.localEulerAngles.x, this.carFrame.transform.localEulerAngles.y, 0f);
		iTween.PunchRotation(this.carFrame, iTween.Hash(new object[]
		{
			"z",
			-1.6,
			"easetype",
			"easeInCirc",
			"islocal",
			true,
			"time",
			1.75
		}));
		base.GetComponent<AudioSource>().PlayOneShot(this.shakeSFX, 0.7f);
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x000FC0A4 File Offset: 0x000FA4A4
	public void RaycastEnter()
	{
		this.isGlowing = true;
		if (this.handle != null)
		{
			this.handle.GetComponent<Renderer>().material = this.glowMaterial;
		}
		if (this.handle2 != null)
		{
			this.handle2.GetComponent<Renderer>().material = this.glowMaterial;
		}
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x000FC108 File Offset: 0x000FA508
	public void RaycastExit()
	{
		this.isGlowing = false;
		if (this.handle != null)
		{
			this.handle.GetComponent<Renderer>().material = this.startMaterial;
		}
		if (this.handle2 != null)
		{
			this.handle2.GetComponent<Renderer>().material = this.startMaterial2;
		}
	}

	// Token: 0x04000EE9 RID: 3817
	public bool isEnvironmentalDoor;

	// Token: 0x04000EEA RID: 3818
	public bool isLocked;

	// Token: 0x04000EEB RID: 3819
	public AudioClip lockedAudio;

	// Token: 0x04000EEC RID: 3820
	[HideInInspector]
	public bool open;

	// Token: 0x04000EED RID: 3821
	public GameObject carSeat;

	// Token: 0x04000EEE RID: 3822
	public GameObject carLogic;

	// Token: 0x04000EEF RID: 3823
	public bool driversDoor;

	// Token: 0x04000EF0 RID: 3824
	public GameObject doorExit;

	// Token: 0x04000EF1 RID: 3825
	public Vector3 xyzOpen;

	// Token: 0x04000EF2 RID: 3826
	public Vector3 xyzClosed;

	// Token: 0x04000EF3 RID: 3827
	public Vector3 handleRotate;

	// Token: 0x04000EF4 RID: 3828
	public Vector3 handleOriginalRot;

	// Token: 0x04000EF5 RID: 3829
	public Vector3 handle2Rotate;

	// Token: 0x04000EF6 RID: 3830
	public Vector3 handle2OriginalRot;

	// Token: 0x04000EF7 RID: 3831
	public bool isPushHandle;

	// Token: 0x04000EF8 RID: 3832
	public GameObject handle;

	// Token: 0x04000EF9 RID: 3833
	public GameObject handle2;

	// Token: 0x04000EFA RID: 3834
	public GameObject passengerDoor;

	// Token: 0x04000EFB RID: 3835
	public AudioClip openSFX;

	// Token: 0x04000EFC RID: 3836
	public AudioClip closeSFX;

	// Token: 0x04000EFD RID: 3837
	public AudioClip shakeSFX;

	// Token: 0x04000EFE RID: 3838
	public bool isBroken;

	// Token: 0x04000EFF RID: 3839
	[Range(0f, 1f)]
	public float brokenDoorFailChance;

	// Token: 0x04000F00 RID: 3840
	public GameObject carFrame;

	// Token: 0x04000F01 RID: 3841
	public GameObject windowScriptTrgt;

	// Token: 0x04000F02 RID: 3842
	public GameObject passengerWindowScriptTrgt;

	// Token: 0x04000F03 RID: 3843
	public Material startMaterial;

	// Token: 0x04000F04 RID: 3844
	public Material startMaterial2;

	// Token: 0x04000F05 RID: 3845
	public Material glowMaterial;

	// Token: 0x04000F06 RID: 3846
	private bool isGlowing;

	// Token: 0x04000F07 RID: 3847
	private bool isConvex;

	// Token: 0x04000F08 RID: 3848
	public GameObject uncleObj;

	// Token: 0x04000F09 RID: 3849
	public bool isUncleDoor;

	// Token: 0x04000F0A RID: 3850
	private int spokenAboutDoorAmount;

	// Token: 0x04000F0B RID: 3851
	public bool isBoot;

	// Token: 0x04000F0C RID: 3852
	public GameObject bootToolRack;
}
