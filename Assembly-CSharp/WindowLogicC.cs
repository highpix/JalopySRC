using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200010F RID: 271
public class WindowLogicC : MonoBehaviour
{
	// Token: 0x06000AB3 RID: 2739 RVA: 0x000FA439 File Offset: 0x000F8839
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.GetComponent<Renderer>().material;
		this.uncleObj = GameObject.FindGameObjectWithTag("Uncle");
	}

	// Token: 0x06000AB4 RID: 2740 RVA: 0x000FA46C File Offset: 0x000F886C
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000AB5 RID: 2741 RVA: 0x000FA4C0 File Offset: 0x000F88C0
	public IEnumerator Trigger()
	{
		int num = UnityEngine.Random.Range(0, 100);
		if (this.isAnimating)
		{
			yield break;
		}
		this.isAnimating = true;
		if (!this.isOpen)
		{
			if (num < this.openChance)
			{
				this.isOpen = true;
				base.GetComponent<AudioSource>().PlayOneShot(this.audioWidow, 0.7f);
				this.WindowOpen();
				iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"z",
					-4.6,
					"islocal",
					true,
					"time",
					this.windowAnimTimer,
					"easetype",
					"linear"
				}));
				iTween.MoveTo(this.window, iTween.Hash(new object[]
				{
					"position",
					this.windowDownLoc,
					"time",
					this.windowAnimTimer,
					"easetype",
					"linear",
					"islocal",
					true,
					"onComplete",
					"ReturnDoorFunctionality",
					"onCompleteTarget",
					base.gameObject
				}));
				if (this.uncleObj.GetComponent<UncleLogicC>().director.GetComponent<RouteGeneratorC>().currentWeatherCondition > 1)
				{
					if (this.isUncleWindow)
					{
						this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("RainingOpenUncleWindow");
					}
					else
					{
						this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("RainingOpenPlayerWindow");
					}
				}
				yield break;
			}
			this.BrokenShake();
			yield break;
		}
		else
		{
			if (!this.isOpen)
			{
				yield break;
			}
			if (num < this.openChance)
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.audioWidow, 0.7f);
				this.isOpen = false;
				iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"z",
					4.6,
					"islocal",
					true,
					"time",
					this.windowAnimTimer,
					"easetype",
					"linear",
					"oncomplete",
					"WindowClosed",
					"oncompletetarget",
					base.gameObject
				}));
				iTween.MoveTo(this.window, iTween.Hash(new object[]
				{
					"position",
					this.windowUpLoc,
					"time",
					this.windowAnimTimer,
					"islocal",
					true,
					"easetype",
					"linear",
					"onComplete",
					"ReturnDoorFunctionality",
					"onCompleteTarget",
					base.gameObject
				}));
				yield break;
			}
			this.BrokenShake();
			yield break;
		}
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x000FA4DB File Offset: 0x000F88DB
	public void ReturnDoorFunctionality()
	{
		this.isAnimating = false;
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x000FA4E4 File Offset: 0x000F88E4
	public void WindowOpen()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject uDayCycle = gameObject.GetComponent<RouteGeneratorC>().uDayCycle;
		uDayCycle.GetComponent<DNC_soundEffect>().inCarVolume = false;
		this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().HigherEngineAudio();
		this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().frontLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
		this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().frontRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
		this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().rearLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
		this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().rearRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
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

	// Token: 0x06000AB8 RID: 2744 RVA: 0x000FA624 File Offset: 0x000F8A24
	public void WindowClosed()
	{
		if (this.seatLogic.GetComponent<SeatLogicC>().isSat && !this.doorScriptTrgt.GetComponent<DoorLogicC>().open && !this.passengerWindowScriptTrgt.GetComponent<WindowLogicC>().isOpen && !this.passengerDoor.GetComponent<DoorLogicC>().open)
		{
			GameObject gameObject = GameObject.FindWithTag("Director");
			GameObject uDayCycle = gameObject.GetComponent<RouteGeneratorC>().uDayCycle;
			uDayCycle.GetComponent<DNC_soundEffect>().inCarVolume = true;
			this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().LowerEngineAudio();
			this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().frontLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
			this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().frontRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
			this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().rearLeftWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
			this.doorScriptTrgt.GetComponent<DoorLogicC>().carLogic.GetComponent<CarLogicC>().rearRightWheelCollider.GetComponent<WheelScriptPCC>().volumeLower = false;
			if (gameObject.GetComponent<RouteGeneratorC>().aiDrivers.Length > 0)
			{
				for (int i = 0; i < gameObject.GetComponent<RouteGeneratorC>().aiDrivers.Length; i++)
				{
					gameObject.GetComponent<RouteGeneratorC>().aiDrivers[i].SendMessage("VolumeHigher", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	// Token: 0x06000AB9 RID: 2745 RVA: 0x000FA79F File Offset: 0x000F8B9F
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x000FA7C8 File Offset: 0x000F8BC8
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x000FA7F4 File Offset: 0x000F8BF4
	public void BrokenShake()
	{
		this.isAnimating = true;
		iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"z",
			-0.05,
			"islocal",
			true,
			"time",
			0.1,
			"easetype",
			"easeinquint",
			"oncomplete",
			"BrokenShake2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x000FA8A8 File Offset: 0x000F8CA8
	public void BrokenShake2()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.handleStuckAudio, 0.8f);
		iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"z",
			0.05,
			"islocal",
			true,
			"time",
			0.2,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"BrokenShake3",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x000FA968 File Offset: 0x000F8D68
	public void BrokenShake3()
	{
		iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"z",
			-0.05,
			"islocal",
			true,
			"time",
			0.1,
			"easetype",
			"easeinquint",
			"oncomplete",
			"BrokenShake4",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x000FAA14 File Offset: 0x000F8E14
	public void BrokenShake4()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.handleStuckAudio, 0.8f);
		iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"z",
			0.05,
			"islocal",
			true,
			"time",
			0.4,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"BrokenShakeEnd",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000ABF RID: 2751 RVA: 0x000FAAD4 File Offset: 0x000F8ED4
	public void BrokenShakeEnd()
	{
		this.isAnimating = false;
	}

	// Token: 0x04000EC4 RID: 3780
	public GameObject window;

	// Token: 0x04000EC5 RID: 3781
	public Vector3 windowDownLoc;

	// Token: 0x04000EC6 RID: 3782
	public Vector3 windowUpLoc;

	// Token: 0x04000EC7 RID: 3783
	private Color startcolor;

	// Token: 0x04000EC8 RID: 3784
	public bool isAnimating;

	// Token: 0x04000EC9 RID: 3785
	public float windowAnimTimer;

	// Token: 0x04000ECA RID: 3786
	public bool isOpen;

	// Token: 0x04000ECB RID: 3787
	public AudioClip audioWidow;

	// Token: 0x04000ECC RID: 3788
	public AudioClip handleStuckAudio;

	// Token: 0x04000ECD RID: 3789
	public Material startMaterial;

	// Token: 0x04000ECE RID: 3790
	public Material glowMaterial;

	// Token: 0x04000ECF RID: 3791
	private bool isGlowing;

	// Token: 0x04000ED0 RID: 3792
	public GameObject uncleObj;

	// Token: 0x04000ED1 RID: 3793
	public bool isUncleWindow;

	// Token: 0x04000ED2 RID: 3794
	public GameObject doorScriptTrgt;

	// Token: 0x04000ED3 RID: 3795
	public GameObject passengerWindowScriptTrgt;

	// Token: 0x04000ED4 RID: 3796
	public GameObject passengerDoor;

	// Token: 0x04000ED5 RID: 3797
	public GameObject seatLogic;

	// Token: 0x04000ED6 RID: 3798
	public int openChance;
}
