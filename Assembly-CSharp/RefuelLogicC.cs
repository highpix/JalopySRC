using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class RefuelLogicC : MonoBehaviour
{
	// Token: 0x0600096F RID: 2415 RVA: 0x000E035C File Offset: 0x000DE75C
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.director = GameObject.FindWithTag("Director");
		this.uncle = this.director.GetComponent<DirectorC>().uncle;
		if (this.ropeEnd == null)
		{
			IEnumerator enumerator = base.transform.parent.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (transform.name == "Line_Rope_End")
					{
						this.ropeEnd = transform.gameObject;
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		base.Invoke("PlaceAtPump", Time.deltaTime * 3f);
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x000E0450 File Offset: 0x000DE850
	public void DropNoRigidbody()
	{
		this.PlaceAtPump();
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x000E0458 File Offset: 0x000DE858
	public void PlaceAtPump()
	{
		this.shop.GetComponent<ShopC>().fuelUsed = Mathf.Floor(this.fuelUsed);
		base.transform.parent = this.holderObj.transform;
		base.transform.localPosition = this.holderObj.GetComponent<HoldingLogicC>().posAdjust;
		base.transform.localEulerAngles = this.holderObj.GetComponent<HoldingLogicC>().rotAdjust;
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		if (this.fuelTarget != null)
		{
			this.fuelTarget.GetComponent<PortableFuelC>().animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", false);
		}
		Collider[] array = new Collider[0];
		array = base.GetComponents<Collider>();
		foreach (Collider collider in array)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x000E0554 File Offset: 0x000DE954
	private void Update()
	{
		if (this.carLogic == null || this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
		{
			return;
		}
		if (!this.fuelLid && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>())
		{
			this.fuelLid = this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelLid;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>() && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelLid)
		{
			if (this.fuelLid != this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelLid)
			{
				this.fuelLid = this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelLid;
			}
			float num = Vector3.Distance(base.transform.position, this.fuelLid.transform.position);
			if (this.uncle.GetComponent<UncleLogicC>().atPetrolStation && num < 50f)
			{
				if (num < this.distanceCheck && !this.uncle.GetComponent<UncleLogicC>().isCloseToFuelPump)
				{
					this.uncle.GetComponent<UncleLogicC>().isCloseToFuelPump = true;
				}
				else if (num > this.distanceCheck && this.uncle.GetComponent<UncleLogicC>().isCloseToFuelPump)
				{
					this.uncle.GetComponent<UncleLogicC>().isCloseToFuelPump = false;
				}
			}
			if (this.isTriggered && (Input.GetButtonUp("Fire1") || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17])))
			{
				this.ActionPart2();
				this.isTriggered = false;
				Transform root = this._camera.transform.root;
				root.GetComponent<RigidbodyControllerC>().enabled = true;
				if (this.fuelTarget && this.fuelTarget.GetComponent<PortableFuelC>())
				{
					this.fuelTarget.GetComponent<PortableFuelC>().LidClose();
				}
			}
			if (this.isTriggered && (Input.GetButton("Fire1") || Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[17])))
			{
				if (this.fuelTarget != null && (this.fuelTarget.transform.name == "GasCan" || this.fuelTarget.transform.name == "GasCan(Clone)"))
				{
					if (this.fuelTarget.GetComponent<PortableFuelC>().fuelLevel >= 9 || this.fuelWatcher == this.director.GetComponent<DirectorC>().totalWealth)
					{
						this.fuelTarget.GetComponent<PortableFuelC>().LidClose();
						this.ActionPart2();
						this.isTriggered = false;
						Transform root2 = this._camera.transform.root;
						root2.GetComponent<RigidbodyControllerC>().enabled = true;
						return;
					}
					this.fuelUsed += Time.deltaTime;
					if (!this.fuelTarget.GetComponent<PortableFuelC>().addedToShopTracking)
					{
						this.fuelTarget.GetComponent<PortableFuelC>().shop = this.shop;
						this.shop.GetComponent<ShopC>().portableFuelRefilledList.Add(this.fuelTarget);
						this.shop.GetComponent<ShopC>().portableFuelRefilledNumbers.Add(0);
						this.fuelTarget.GetComponent<PortableFuelC>().shopTrackingReff = this.shop.GetComponent<ShopC>().portableFuelRefilledList.Count - 1;
						this.fuelTarget.GetComponent<PortableFuelC>().addedToShopTracking = true;
					}
					if (this.fuelUsed > this.fuelWatcher)
					{
						this.fuelWatcher += 1f;
						this.fuelTarget.GetComponent<PortableFuelC>().fuelLevel++;
						this.fuelTarget.GetComponent<PortableFuelC>().fuelTillOilDown--;
						if (this.fuelTarget.GetComponent<PortableFuelC>().fuelTillOilDown <= 0)
						{
							this.fuelTarget.GetComponent<PortableFuelC>().FuelOilDown();
						}
						List<int> portableFuelRefilledNumbers;
						int shopTrackingReff;
						(portableFuelRefilledNumbers = this.shop.GetComponent<ShopC>().portableFuelRefilledNumbers)[shopTrackingReff = this.fuelTarget.GetComponent<PortableFuelC>().shopTrackingReff] = portableFuelRefilledNumbers[shopTrackingReff] + 1;
						this.fuelTarget.GetComponent<PortableFuelC>().FillWithFuel();
						base.StartCoroutine("FuelLitreUpdate");
						base.StartCoroutine("FuelPriceUpdate");
						this.shop.GetComponent<ShopC>().totalPrice += 1f;
						this.shop.GetComponent<ShopC>().visualPrice.GetComponent<TextMesh>().text = this.shop.GetComponent<ShopC>().totalPrice.ToString() + ".00";
						this._camera.GetComponent<DragRigidbodyC>().SetEngineCompUI1();
					}
					return;
				}
				else if (this.fuelTarget == null)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount >= this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount || this.fuelWatcher == this.director.GetComponent<DirectorC>().totalWealth)
					{
						this.ActionPart2();
						this.isTriggered = false;
						Transform root3 = this._camera.transform.root;
						root3.GetComponent<RigidbodyControllerC>().enabled = true;
						return;
					}
					this.fuelUsed += Time.deltaTime;
					this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().currentFuelAmount += Time.deltaTime;
					if (this.fuelUsed > this.fuelWatcher)
					{
						this.fuelWatcher += 1f;
						if (this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().fuelTillOilDown > 0)
						{
							this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().fuelTillOilDown--;
						}
						if (this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().fuelTillOilDown <= 0 && this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().fuelMix > 0)
						{
							this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().fuelMix--;
							this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
							if (this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<ObjectPickupC>().isInEngine)
							{
								this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
								this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
								this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
							}
						}
						base.StartCoroutine("FuelLitreUpdate");
						base.StartCoroutine("FuelPriceUpdate");
						this.shop.GetComponent<ShopC>().totalPrice += 1f;
						this.shop.GetComponent<ShopC>().visualPrice.GetComponent<TextMesh>().text = this.shop.GetComponent<ShopC>().totalPrice.ToString() + ".00";
						this._camera.GetComponent<DragRigidbodyC>().SetEngineCompUI1();
					}
				}
			}
			return;
		}
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x000E0DD8 File Offset: 0x000DF1D8
	public void DistanceTooLarge()
	{
		this.isTriggered = false;
		this.droneAudioObj.GetComponent<AudioSource>().Stop();
		Transform root = this._camera.transform.root;
		root.GetComponent<RigidbodyControllerC>().enabled = true;
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x000E0E1C File Offset: 0x000DF21C
	public void Action()
	{
		if (this.fuelTarget == null)
		{
			base.GetComponent<ObjectInteractionsC>().target.SendMessage("LidOpen");
		}
		Debug.Log("Fueling");
		this.droneAudioObj.GetComponent<AudioSource>().Play();
		this.fuelLid.transform.parent.transform.parent.gameObject.GetComponent<EngineComponentC>().FuelTankDurabilityCalc();
		CarLogicC component = this.carLogic.GetComponent<CarLogicC>();
		if (this.fuelTarget != null && (this.fuelTarget.transform.name == "GasCan" || this.fuelTarget.transform.name == "GasCan(Clone)") && this.fuelTarget.GetComponent<PortableFuelC>().fuelLevel == 9)
		{
			this.UnAction();
			this.droneAudioObj.GetComponent<AudioSource>().Stop();
			return;
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount && this.fuelTarget == null)
		{
			this.UnAction();
			return;
		}
		Transform root = this._camera.transform.root;
		root.GetComponent<Rigidbody>().velocity = Vector3.zero;
		root.GetComponent<RigidbodyControllerC>().enabled = false;
		this.isTriggered = true;
		if (this.fuelTarget == null)
		{
			GameObject target = base.gameObject.GetComponent<ObjectInteractionsC>().target;
			base.transform.parent = target.transform;
		}
		else
		{
			base.transform.parent = this.fuelTarget.transform;
		}
		base.gameObject.layer = LayerMask.NameToLayer("Default");
		if (this.fuelTarget == null)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.position[2],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType1
			}));
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotation[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType1
			}));
			iTween.ScaleTo(base.gameObject, iTween.Hash(new object[]
			{
				"scale",
				new Vector3(1f, 1f, 1f),
				"islocal",
				false,
				"time",
				0.01
			}));
		}
		else
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.fuelTarget.GetComponent<PortableFuelC>().fuelHandlePosition.position,
				"islocal",
				false,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType1
			}));
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.fuelTarget.GetComponent<PortableFuelC>().fuelHandlePosition.eulerAngles,
				"islocal",
				false,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType1
			}));
			iTween.ScaleTo(base.gameObject, iTween.Hash(new object[]
			{
				"scale",
				new Vector3(2f, 2f, 2f),
				"islocal",
				false,
				"time",
				0.01
			}));
			this.fuelTarget.GetComponent<PortableFuelC>().animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", true);
		}
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x000E12C5 File Offset: 0x000DF6C5
	public void CheckGateClosed()
	{
		if (!this.store.GetComponent<StoreC>().gateClosed)
		{
			this.store.GetComponent<StoreC>().GateClose();
		}
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x000E12EC File Offset: 0x000DF6EC
	public void FuelLitreUpdate()
	{
		iTween.RotateBy(this.litreObjs[1], iTween.Hash(new object[]
		{
			"z",
			0.1,
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"CheckGateClosed",
			"oncompletetarget",
			base.gameObject
		}));
		AudioSource.PlayClipAtPoint(this.dingAudio, this.litreObjs[1].transform.position);
		if (this.fuelUsed > 10f && this.fuelDigitTracker < 1)
		{
			this.fuelDigitTracker++;
			iTween.RotateBy(this.litreObjs[0], iTween.Hash(new object[]
			{
				"z",
				0.1,
				"islocal",
				true,
				"time",
				0.5,
				"easetype",
				"easeoutquad"
			}));
		}
		if (this.fuelUsed > 20f && this.fuelDigitTracker < 2)
		{
			this.fuelDigitTracker++;
			iTween.RotateBy(this.litreObjs[0], iTween.Hash(new object[]
			{
				"z",
				0.1,
				"islocal",
				true,
				"time",
				0.5,
				"easetype",
				"easeoutquad"
			}));
		}
		if (this.fuelUsed > 30f && this.fuelDigitTracker < 3)
		{
			this.fuelDigitTracker++;
			iTween.RotateBy(this.litreObjs[0], iTween.Hash(new object[]
			{
				"z",
				0.1,
				"islocal",
				true,
				"time",
				0.5,
				"easetype",
				"easeoutquad"
			}));
		}
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x000E1568 File Offset: 0x000DF968
	public void FuelPriceUpdate()
	{
		iTween.RotateBy(this.priceObjs[1], iTween.Hash(new object[]
		{
			"z",
			0.1,
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			"easeoutquad"
		}));
		if (this.fuelUsed > 10f && this.fuelDigitTracker2 < 1)
		{
			this.fuelDigitTracker2++;
			iTween.RotateBy(this.priceObjs[0], iTween.Hash(new object[]
			{
				"z",
				0.1,
				"islocal",
				true,
				"time",
				0.5,
				"easetype",
				"easeoutquad"
			}));
		}
		if (this.fuelUsed > 20f && this.fuelDigitTracker2 < 2)
		{
			this.fuelDigitTracker2++;
			iTween.RotateBy(this.priceObjs[0], iTween.Hash(new object[]
			{
				"z",
				0.1,
				"islocal",
				true,
				"time",
				0.5,
				"easetype",
				"easeoutquad"
			}));
		}
		if (this.fuelUsed > 30f && this.fuelDigitTracker2 < 3)
		{
			this.fuelDigitTracker2++;
			iTween.RotateBy(this.priceObjs[0], iTween.Hash(new object[]
			{
				"z",
				0.1,
				"islocal",
				true,
				"time",
				0.5,
				"easetype",
				"easeoutquad"
			}));
		}
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x000E17A0 File Offset: 0x000DFBA0
	public void UnAction()
	{
		float pitch = UnityEngine.Random.Range(0.8f, 1.2f);
		base.GetComponent<AudioSource>().pitch = pitch;
		int num = UnityEngine.Random.Range(0, this.airSwipe.Length - 1);
		base.GetComponent<AudioSource>().PlayOneShot(this.airSwipe[num], 1f);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"PunchPart2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x000E1888 File Offset: 0x000DFC88
	public void PunchPart2()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"delay",
			0.1,
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x000E1920 File Offset: 0x000DFD20
	public void ActionPart2()
	{
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1;
		base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		this.droneAudioObj.GetComponent<AudioSource>().Stop();
		iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
		{
			"x",
			0.0,
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutexpo"
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"FuelTargetNull",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.ScaleTo(base.gameObject, iTween.Hash(new object[]
		{
			"scale",
			new Vector3(1f, 1f, 1f),
			"islocal",
			true,
			"time",
			0.01
		}));
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x000E1B3D File Offset: 0x000DFF3D
	public void FuelTargetNull()
	{
		this.fuelTarget = null;
	}

	// Token: 0x04000CDF RID: 3295
	private GameObject _camera;

	// Token: 0x04000CE0 RID: 3296
	public GameObject fuelTarget;

	// Token: 0x04000CE1 RID: 3297
	public GameObject director;

	// Token: 0x04000CE2 RID: 3298
	public GameObject uncle;

	// Token: 0x04000CE3 RID: 3299
	private bool isTriggered;

	// Token: 0x04000CE4 RID: 3300
	public GameObject carLogic;

	// Token: 0x04000CE5 RID: 3301
	public GameObject holderObj;

	// Token: 0x04000CE6 RID: 3302
	public GameObject fuelLid;

	// Token: 0x04000CE7 RID: 3303
	public GameObject[] priceObjs = new GameObject[0];

	// Token: 0x04000CE8 RID: 3304
	public GameObject[] litreObjs = new GameObject[0];

	// Token: 0x04000CE9 RID: 3305
	public Vector3[] rotation = new Vector3[0];

	// Token: 0x04000CEA RID: 3306
	public Vector3[] position = new Vector3[0];

	// Token: 0x04000CEB RID: 3307
	public string easeType1 = string.Empty;

	// Token: 0x04000CEC RID: 3308
	public string easeType2 = string.Empty;

	// Token: 0x04000CED RID: 3309
	public float timeToComplete;

	// Token: 0x04000CEE RID: 3310
	public GameObject fuelParticles;

	// Token: 0x04000CEF RID: 3311
	public float fuelUsed;

	// Token: 0x04000CF0 RID: 3312
	public float fuelWatcher = 1f;

	// Token: 0x04000CF1 RID: 3313
	public AudioClip pourAudio;

	// Token: 0x04000CF2 RID: 3314
	public AudioClip[] airSwipe;

	// Token: 0x04000CF3 RID: 3315
	public AudioClip dingAudio;

	// Token: 0x04000CF4 RID: 3316
	public GameObject droneAudioObj;

	// Token: 0x04000CF5 RID: 3317
	private int fuelDigitTracker;

	// Token: 0x04000CF6 RID: 3318
	private int fuelDigitTracker2;

	// Token: 0x04000CF7 RID: 3319
	private float carFuelAlreadyInTank;

	// Token: 0x04000CF8 RID: 3320
	private bool calculatedFuel;

	// Token: 0x04000CF9 RID: 3321
	public GameObject ropeEnd;

	// Token: 0x04000CFA RID: 3322
	public float distanceCheck = 16f;

	// Token: 0x04000CFB RID: 3323
	public GameObject shop;

	// Token: 0x04000CFC RID: 3324
	public GameObject store;

	// Token: 0x04000CFD RID: 3325
	private bool isGlowing;

	// Token: 0x04000CFE RID: 3326
	public Material glowMaterial;

	// Token: 0x04000CFF RID: 3327
	public Material startMaterial;
}
