using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000082 RID: 130
public class CarPerformanceC : MonoBehaviour
{
	// Token: 0x17000028 RID: 40
	// (get) Token: 0x0600027B RID: 635 RVA: 0x00020FB7 File Offset: 0x0001F3B7
	// (set) Token: 0x0600027C RID: 636 RVA: 0x00020FBF File Offset: 0x0001F3BF
	public GameObject InstalledEngine
	{
		get
		{
			return this.installedEngine;
		}
		set
		{
			this.installedEngine = value;
		}
	}

	// Token: 0x0600027D RID: 637 RVA: 0x00020FC8 File Offset: 0x0001F3C8
	private void Awake()
	{
		this.myLogic = base.GetComponent<CarLogicC>();
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00020FD6 File Offset: 0x0001F3D6
	private void Start()
	{
		base.Invoke("LateStart", 2f);
	}

	// Token: 0x0600027F RID: 639 RVA: 0x00020FE8 File Offset: 0x0001F3E8
	private void LateStart()
	{
		this.TurnOffEngineGhostCollisions();
		this.GetCarCondition();
		this.myLogic.CarDamageUp();
	}

	// Token: 0x06000280 RID: 640 RVA: 0x00021004 File Offset: 0x0001F404
	private void TurnOffEngineGhostCollisions()
	{
		if (this.ghostMesh.Length <= 0)
		{
			return;
		}
		if (this.ghostMesh[0] != null)
		{
			BoxCollider[] components = this.ghostMesh[0].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider in components)
			{
				boxCollider.enabled = false;
			}
		}
		if (this.ghostMesh[1] != null)
		{
			BoxCollider[] components2 = this.ghostMesh[1].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider2 in components2)
			{
				boxCollider2.enabled = false;
			}
		}
		if (this.ghostMesh[2] != null)
		{
			BoxCollider[] components3 = this.ghostMesh[2].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider3 in components3)
			{
				boxCollider3.enabled = false;
			}
		}
		if (this.ghostMesh[3] != null)
		{
			BoxCollider[] components4 = this.ghostMesh[3].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider4 in components4)
			{
				boxCollider4.enabled = false;
			}
		}
		if (this.ghostMesh[4] != null)
		{
			BoxCollider[] components5 = this.ghostMesh[4].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider5 in components5)
			{
				boxCollider5.enabled = false;
			}
		}
		if (this.ghostMesh[5] != null)
		{
			BoxCollider[] components6 = this.ghostMesh[5].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider6 in components6)
			{
				boxCollider6.enabled = false;
			}
		}
		if (this.ghostMesh[6] != null)
		{
			BoxCollider[] components7 = this.ghostMesh[6].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider7 in components7)
			{
				boxCollider7.enabled = false;
			}
		}
	}

	// Token: 0x06000281 RID: 641 RVA: 0x0002127C File Offset: 0x0001F67C
	public void LoadEngineComponents()
	{
		if (this.myLogic.doorFitted)
		{
			UnityEngine.Object.Destroy(this.myLogic.rightDoor.transform.parent.GetComponent<Rigidbody>());
			UnityEngine.Object.Destroy(this.myLogic.rightDoor.transform.parent.GetComponent<Collider>());
			UnityEngine.Object.Destroy(this.myLogic.rightDoor.transform.parent.GetComponent<ObjectPickupC>());
			this.myLogic.rightDoor.transform.parent.transform.parent = this.myLogic.rightDoorHolder.transform;
			this.myLogic.rightDoor.transform.parent.localPosition = Vector3.zero;
			this.myLogic.rightDoor.transform.parent.localEulerAngles = Vector3.zero;
			this.myLogic.rightDoor.SetActive(true);
			this.myLogic.rightDoor.transform.parent.SendMessage("AllowFunctionality");
			UnityEngine.Object.Destroy(this.myLogic.rightDoor.transform.parent.GetComponent<FixDoorScriptC>());
		}
		if (this.engineLoadID != 0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.engineCatalogue[this.engineLoadID], base.transform.position, base.transform.rotation);
			gameObject.transform.parent = this.InstalledEngine.transform.parent;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.InstalledEngine);
			this.InstalledEngine = gameObject;
			this.InstalledEngine.GetComponent<ObjectPickupC>().isInEngine = true;
			this.InstalledEngine.GetComponent<ObjectPickupC>().placedAt = this.InstalledEngine.transform.parent.gameObject;
			this.InstalledEngine.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.InstalledEngine.transform.parent.GetComponent<Collider>().enabled = false;
			this.InstalledEngine.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.InstalledEngine.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.InstalledEngine.transform.parent.GetComponent<Collider>().enabled = true;
			UnityEngine.Object.Destroy(this.InstalledEngine);
			this.InstalledEngine = null;
		}
		if (this.ignitionCoilLoadID != 0)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.ignitionCoilCatalogue[this.ignitionCoilLoadID], base.transform.position, base.transform.rotation);
			gameObject2.transform.parent = this.installedIgnitionCoil.transform.parent;
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.installedIgnitionCoil);
			this.installedIgnitionCoil = gameObject2;
			this.installedIgnitionCoil.GetComponent<ObjectPickupC>().isInEngine = true;
			this.installedIgnitionCoil.GetComponent<ObjectPickupC>().placedAt = this.installedIgnitionCoil.transform.parent.gameObject;
			this.installedIgnitionCoil.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.installedIgnitionCoil.transform.parent.GetComponent<Collider>().enabled = false;
			this.installedIgnitionCoil.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.installedIgnitionCoil.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.installedIgnitionCoil.transform.parent.GetComponent<Collider>().enabled = true;
			UnityEngine.Object.Destroy(this.installedIgnitionCoil);
			this.installedIgnitionCoil = null;
		}
		if (this.fuelTankLoadID != 0)
		{
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.fuelTankCatalogue[this.fuelTankLoadID], base.transform.position, base.transform.rotation);
			gameObject3.transform.parent = this.installedFuelTank.transform.parent;
			gameObject3.transform.localPosition = Vector3.zero;
			gameObject3.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.installedFuelTank);
			this.installedFuelTank = gameObject3;
			this.installedFuelTank.GetComponent<ObjectPickupC>().isInEngine = true;
			this.installedFuelTank.GetComponent<ObjectPickupC>().placedAt = this.installedFuelTank.transform.parent.gameObject;
			this.installedFuelTank.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.installedFuelTank.transform.parent.GetComponent<Collider>().enabled = false;
			this.installedFuelTank.SendMessage("SendStatsToCarPerf");
			if (this.installedFuelTank != null)
			{
				this.UpdateFuelInTank();
			}
		}
		else
		{
			this.installedFuelTank.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.installedFuelTank.transform.parent.GetComponent<Collider>().enabled = true;
			UnityEngine.Object.Destroy(this.installedFuelTank);
			this.installedFuelTank = null;
		}
		if (this.carburettorLoadID != 0)
		{
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.carburettorCatalogue[this.carburettorLoadID], base.transform.position, base.transform.rotation);
			gameObject4.transform.parent = this.installedCarburettor.transform.parent;
			gameObject4.transform.localPosition = Vector3.zero;
			gameObject4.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.installedCarburettor);
			this.installedCarburettor = gameObject4;
			this.installedCarburettor.GetComponent<ObjectPickupC>().isInEngine = true;
			this.installedCarburettor.GetComponent<ObjectPickupC>().placedAt = this.installedCarburettor.transform.parent.gameObject;
			this.installedCarburettor.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.installedCarburettor.transform.parent.GetComponent<Collider>().enabled = false;
			this.installedCarburettor.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.installedCarburettor.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.installedCarburettor.transform.parent.GetComponent<Collider>().enabled = true;
			UnityEngine.Object.Destroy(this.installedCarburettor);
			this.installedCarburettor = null;
		}
		if (this.airFilterLoadID != 0)
		{
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.airFilterCatalogue[this.airFilterLoadID], base.transform.position, base.transform.rotation);
			gameObject5.transform.parent = this.installedAirFilter.transform.parent;
			gameObject5.transform.localPosition = Vector3.zero;
			gameObject5.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.installedAirFilter);
			this.installedAirFilter = gameObject5;
			this.installedAirFilter.GetComponent<ObjectPickupC>().isInEngine = true;
			this.installedAirFilter.GetComponent<ObjectPickupC>().placedAt = this.installedAirFilter.transform.parent.gameObject;
			this.installedAirFilter.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.installedAirFilter.transform.parent.GetComponent<Collider>().enabled = false;
			this.installedAirFilter.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.installedAirFilter.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.installedAirFilter.transform.parent.GetComponent<Collider>().enabled = true;
			UnityEngine.Object.Destroy(this.installedAirFilter);
			this.installedAirFilter = null;
		}
		if (this.waterTankLoadID != 0)
		{
			GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.waterTankCatalogue[this.waterTankLoadID], base.transform.position, base.transform.rotation);
			gameObject6.transform.parent = this.waterTankObj.transform.parent;
			gameObject6.transform.localPosition = Vector3.zero;
			gameObject6.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.waterTankObj);
			this.waterTankObj = gameObject6;
			this.waterTankObj.GetComponent<ObjectPickupC>().isInEngine = true;
			this.waterTankObj.GetComponent<ObjectPickupC>().placedAt = this.waterTankObj.transform.parent.gameObject;
			this.waterTankObj.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.waterTankObj.transform.parent.GetComponent<Collider>().enabled = false;
			this.waterTankObj.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.waterTankObj.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.waterTankObj.transform.parent.GetComponent<Collider>().enabled = true;
			UnityEngine.Object.Destroy(this.waterTankObj);
			this.waterTankObj = null;
		}
		if (this.batteryLoadID != 0)
		{
			GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.batteryCatalogue[this.batteryLoadID], base.transform.position, base.transform.rotation);
			gameObject7.transform.parent = this.installedBattery.transform.parent;
			gameObject7.transform.localPosition = Vector3.zero;
			gameObject7.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.installedBattery);
			this.installedBattery = gameObject7;
			this.installedBattery.GetComponent<ObjectPickupC>().isInEngine = true;
			this.installedBattery.GetComponent<ObjectPickupC>().placedAt = this.installedBattery.transform.parent.gameObject;
			this.installedBattery.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.installedBattery.transform.parent.GetComponent<Collider>().enabled = false;
			this.installedBattery.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.installedBattery.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.installedBattery.transform.parent.GetComponent<Collider>().enabled = true;
			UnityEngine.Object.Destroy(this.installedBattery);
			this.installedBattery = null;
		}
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00021CE0 File Offset: 0x000200E0
	public void RemoveTyreRefs()
	{
		if (this.frontLeftTyre != null && this.frontLeftTyre.transform.parent == null)
		{
			this.frontLeftTyre = null;
		}
		if (this.frontRightTyre != null && this.frontRightTyre.transform.parent == null)
		{
			this.frontRightTyre = null;
		}
		if (this.rearLeftTyre != null && this.rearLeftTyre.transform.parent == null)
		{
			this.rearLeftTyre = null;
		}
		if (this.rearRightTyre != null && this.rearRightTyre.transform.parent == null)
		{
			this.rearRightTyre = null;
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00021DBC File Offset: 0x000201BC
	public void LoadTyreComponents()
	{
		if (this.flTyreID != 0)
		{
			int num = this.flTyreID;
			if (this.flCompoundID == 2f)
			{
				num += 3;
			}
			else if (this.flCompoundID == 3f)
			{
				num += 6;
			}
			if (num >= this.tyreCatalogue.Length)
			{
				num = 1;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[num], base.transform.position, base.transform.rotation);
			gameObject.transform.localScale = gameObject.GetComponent<ObjectPickupC>().adjustScale;
			gameObject.transform.parent = this.frontLeftTyre.transform.parent;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.frontLeftTyre);
			this.frontLeftTyre = gameObject;
			this.frontLeftTyre.GetComponent<FrameDirtC>().leftFrontTyre = true;
			this.frontLeftTyre.GetComponent<FrameDirtC>().rightFrontTyre = false;
			this.frontLeftTyre.GetComponent<FrameDirtC>().leftRearTyre = false;
			this.frontLeftTyre.GetComponent<FrameDirtC>().rightRearTyre = false;
			this.frontLeftTyre.GetComponent<EngineComponentC>().wheelInstallID = 1;
			this.frontLeftTyre.GetComponent<ObjectPickupC>().isInEngine = true;
			this.frontLeftTyre.GetComponent<ObjectPickupC>().placedAt = this.frontLeftTyre.transform.parent.gameObject;
			this.frontLeftTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.frontLeftTyre.transform.parent.GetComponent<Collider>().enabled = false;
			this.myLogic.frontLeftWheelCollider.GetComponent<WheelScriptPCC>().wheelTransform = this.frontLeftTyre.transform;
			this.frontLeftTyre.GetComponent<ObjectPickupC>().enabled = false;
			this.frontLeftTyre.GetComponent<ObjectInteractionsC>().handInteractive = false;
			this.frontLeftTyre.tag = "Interactor";
			this.myLogic.frontLeftWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.myLogic.FlWheelDirt = this.frontLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget;
			this.frontLeftTyre.GetComponent<FrameDirtC>().director = GameObject.FindWithTag("Director");
			if (ES3.Exists("flWheelDirt"))
			{
				Material material = this.frontLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material.color = new Color(material.color.r, material.color.g, material.color.b, ES3.LoadFloat("flWheelDirt"));
				this.frontLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material.color;
			}
			else
			{
				Material material2 = this.frontLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material2.color = new Color(material2.color.r, material2.color.g, material2.color.b, 0f);
				this.frontLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material2.color;
			}
			this.frontLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isFitted = true;
			this.frontLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().boltStateLoose = false;
			this.frontLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().carBoltSide = 1;
			GameObject bolt = this.frontLeftTyre.GetComponent<EngineComponentC>().bolt;
			iTween.RotateBy(bolt, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, -3f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			iTween.MoveBy(bolt, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0.1f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			bolt.GetComponent<BoltLogicC>().isLoose = false;
			bolt.GetComponent<BoltLogicC>().boltStateLoose = false;
			this.frontLeftTyre.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.myLogic.frontLeftWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.frontLeftTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.frontLeftTyre.transform.parent.GetComponent<Collider>().enabled = true;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[0], base.transform.position, base.transform.rotation);
			gameObject2.transform.parent = this.frontLeftTyre.transform.parent;
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			gameObject2.transform.parent = null;
			UnityEngine.Object.Destroy(this.frontLeftTyre);
			this.frontLeftTyre = null;
			this.frontLeftBricks = gameObject2;
			if (base.transform.root.GetComponent<Rigidbody>())
			{
				base.StartCoroutine(this.TutorialNumerator());
			}
		}
		if (this.frTyreID != 0)
		{
			int num2 = this.frTyreID;
			if (this.frCompoundID == 2f)
			{
				num2 += 3;
			}
			else if (this.frCompoundID == 3f)
			{
				num2 += 6;
			}
			if (num2 >= this.tyreCatalogue.Length)
			{
				num2 = 1;
			}
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[num2], base.transform.position, base.transform.rotation);
			gameObject3.transform.localScale = gameObject3.GetComponent<ObjectPickupC>().adjustScale;
			gameObject3.transform.parent = this.frontRightTyre.transform.parent;
			gameObject3.transform.localPosition = Vector3.zero;
			gameObject3.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			UnityEngine.Object.Destroy(this.frontRightTyre);
			this.frontRightTyre = gameObject3;
			this.frontRightTyre.GetComponent<FrameDirtC>().leftFrontTyre = false;
			this.frontRightTyre.GetComponent<FrameDirtC>().rightFrontTyre = true;
			this.frontRightTyre.GetComponent<FrameDirtC>().leftRearTyre = false;
			this.frontRightTyre.GetComponent<FrameDirtC>().rightRearTyre = false;
			this.frontRightTyre.GetComponent<EngineComponentC>().wheelInstallID = 2;
			this.frontRightTyre.GetComponent<ObjectPickupC>().isInEngine = true;
			this.frontRightTyre.GetComponent<ObjectPickupC>().placedAt = this.frontRightTyre.transform.parent.gameObject;
			this.frontRightTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.frontRightTyre.transform.parent.GetComponent<Collider>().enabled = false;
			this.myLogic.frontRightWheelCollider.GetComponent<WheelScriptPCC>().wheelTransform = this.frontRightTyre.transform;
			this.frontRightTyre.GetComponent<ObjectPickupC>().enabled = false;
			this.frontRightTyre.GetComponent<ObjectInteractionsC>().handInteractive = false;
			this.frontRightTyre.tag = "Interactor";
			this.myLogic.frontRightWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.myLogic.FrWheelDirt = this.frontRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget;
			this.frontRightTyre.GetComponent<FrameDirtC>().director = GameObject.FindWithTag("Director");
			if (ES3.Exists("frWheelDirt"))
			{
				Material material3 = this.frontRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material3.color = new Color(material3.color.r, material3.color.g, material3.color.b, ES3.LoadFloat("frWheelDirt"));
				this.frontRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material3.color;
			}
			else
			{
				Material material4 = this.frontRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material4.color = new Color(material4.color.r, material4.color.g, material4.color.b, 0f);
				this.frontRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material4.color;
			}
			this.frontRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isFitted = true;
			this.frontRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().carBoltSide = 2;
			GameObject bolt2 = this.frontRightTyre.GetComponent<EngineComponentC>().bolt;
			iTween.RotateBy(bolt2, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, -3f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			iTween.MoveBy(bolt2, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0.1f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			bolt2.GetComponent<BoltLogicC>().isLoose = false;
			bolt2.GetComponent<BoltLogicC>().boltStateLoose = false;
			this.frontRightTyre.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.myLogic.frontRightWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.frontRightTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.frontRightTyre.transform.parent.GetComponent<Collider>().enabled = true;
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[0], base.transform.position, base.transform.rotation);
			gameObject4.transform.parent = this.frontRightTyre.transform.parent;
			gameObject4.transform.localPosition = Vector3.zero;
			gameObject4.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			gameObject4.transform.parent = null;
			UnityEngine.Object.Destroy(this.frontRightTyre);
			this.frontRightTyre = null;
			this.frontRightBricks = gameObject4;
		}
		if (this.rlTyreID != 0)
		{
			int num3 = this.rlTyreID;
			if (this.rlCompoundID == 2f)
			{
				num3 += 3;
			}
			else if (this.rlCompoundID == 3f)
			{
				num3 += 6;
			}
			if (num3 >= this.tyreCatalogue.Length)
			{
				num3 = 1;
			}
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[num3], base.transform.position, base.transform.rotation);
			gameObject5.transform.localScale = gameObject5.GetComponent<ObjectPickupC>().adjustScale;
			gameObject5.transform.parent = this.rearLeftTyre.transform.parent;
			gameObject5.transform.localPosition = Vector3.zero;
			gameObject5.transform.localEulerAngles = Vector3.zero;
			UnityEngine.Object.Destroy(this.rearLeftTyre);
			this.rearLeftTyre = gameObject5;
			this.rearLeftTyre.GetComponent<FrameDirtC>().leftFrontTyre = false;
			this.rearLeftTyre.GetComponent<FrameDirtC>().rightFrontTyre = false;
			this.rearLeftTyre.GetComponent<FrameDirtC>().leftRearTyre = true;
			this.rearLeftTyre.GetComponent<FrameDirtC>().rightRearTyre = false;
			this.rearLeftTyre.GetComponent<EngineComponentC>().wheelInstallID = 3;
			this.rearLeftTyre.GetComponent<ObjectPickupC>().isInEngine = true;
			this.rearLeftTyre.GetComponent<ObjectPickupC>().placedAt = this.rearLeftTyre.transform.parent.gameObject;
			this.rearLeftTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.rearLeftTyre.transform.parent.GetComponent<Collider>().enabled = false;
			this.myLogic.rearLeftWheelCollider.GetComponent<WheelScriptPCC>().wheelTransform = this.rearLeftTyre.transform;
			this.rearLeftTyre.GetComponent<ObjectPickupC>().enabled = false;
			this.rearLeftTyre.GetComponent<ObjectInteractionsC>().handInteractive = false;
			this.rearLeftTyre.tag = "Interactor";
			this.myLogic.rearLeftWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.myLogic.RlWheelDirt = this.rearLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget;
			this.rearLeftTyre.GetComponent<FrameDirtC>().director = GameObject.FindWithTag("Director");
			if (ES3.Exists("rrWheelDirt"))
			{
				Material material5 = this.rearLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material5.color = new Color(material5.color.r, material5.color.g, material5.color.b, ES3.LoadFloat("rrWheelDirt"));
				this.rearLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material5.color;
			}
			else
			{
				Material material6 = this.rearLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material6.color = new Color(material6.color.r, material6.color.g, material6.color.b, 0f);
				this.rearLeftTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material6.color;
			}
			this.rearLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isFitted = true;
			this.rearLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().carBoltSide = 1;
			GameObject bolt3 = this.rearLeftTyre.GetComponent<EngineComponentC>().bolt;
			iTween.RotateBy(bolt3, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, -3f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			iTween.MoveBy(bolt3, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0.1f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			bolt3.GetComponent<BoltLogicC>().isLoose = false;
			bolt3.GetComponent<BoltLogicC>().boltStateLoose = false;
			this.rearLeftTyre.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.myLogic.rearLeftWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.rearLeftTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.rearLeftTyre.transform.parent.GetComponent<Collider>().enabled = true;
			GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[0], base.transform.position, base.transform.rotation);
			gameObject6.transform.parent = this.rearLeftTyre.transform.parent;
			gameObject6.transform.localPosition = Vector3.zero;
			gameObject6.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			gameObject6.transform.parent = null;
			UnityEngine.Object.Destroy(this.rearLeftTyre);
			this.rearLeftTyre = null;
			this.rearLeftBricks = gameObject6;
		}
		if (this.rrTyreID != 0)
		{
			int num4 = this.rrTyreID;
			if (this.rrCompoundID == 2f)
			{
				num4 += 3;
			}
			else if (this.rrCompoundID == 3f)
			{
				num4 += 6;
			}
			if (num4 >= this.tyreCatalogue.Length)
			{
				num4 = 1;
			}
			GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[num4], base.transform.position, base.transform.rotation);
			gameObject7.transform.localScale = gameObject7.GetComponent<ObjectPickupC>().adjustScale;
			gameObject7.transform.parent = this.rearRightTyre.transform.parent;
			gameObject7.transform.localPosition = Vector3.zero;
			gameObject7.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			UnityEngine.Object.Destroy(this.rearRightTyre);
			this.rearRightTyre = gameObject7;
			this.rearRightTyre.GetComponent<FrameDirtC>().leftFrontTyre = false;
			this.rearRightTyre.GetComponent<FrameDirtC>().rightFrontTyre = false;
			this.rearRightTyre.GetComponent<FrameDirtC>().leftRearTyre = false;
			this.rearRightTyre.GetComponent<FrameDirtC>().rightRearTyre = true;
			this.rearRightTyre.GetComponent<EngineComponentC>().wheelInstallID = 4;
			this.rearRightTyre.GetComponent<ObjectPickupC>().isInEngine = true;
			this.rearRightTyre.GetComponent<ObjectPickupC>().placedAt = this.rearRightTyre.transform.parent.gameObject;
			this.rearRightTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = true;
			this.rearRightTyre.transform.parent.GetComponent<Collider>().enabled = false;
			this.myLogic.rearRightWheelCollider.GetComponent<WheelScriptPCC>().wheelTransform = this.rearRightTyre.transform;
			this.rearRightTyre.GetComponent<ObjectPickupC>().enabled = false;
			this.rearRightTyre.GetComponent<ObjectInteractionsC>().handInteractive = false;
			this.rearRightTyre.tag = "Interactor";
			this.myLogic.rearRightWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.myLogic.RrWheelDirt = this.rearRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget;
			this.rearRightTyre.GetComponent<FrameDirtC>().director = GameObject.FindWithTag("Director");
			if (ES3.Exists("rrWheeldirt"))
			{
				Material material7 = this.rearRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material7.color = new Color(material7.color.r, material7.color.g, material7.color.b, ES3.LoadFloat("rrWheelDirt"));
				this.rearRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material7.color;
			}
			else
			{
				Material material8 = this.rearRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material;
				material8.color = new Color(material8.color.r, material8.color.g, material8.color.b, 0f);
				this.rearRightTyre.GetComponent<EngineComponentC>().wheelDirtTarget.GetComponent<Renderer>().material.color = material8.color;
			}
			this.rearRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isFitted = true;
			this.rearRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().carBoltSide = 2;
			GameObject bolt4 = this.rearRightTyre.GetComponent<EngineComponentC>().bolt;
			iTween.RotateBy(bolt4, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, -3f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			iTween.MoveBy(bolt4, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0.1f, 0f),
				"islocal",
				true,
				"time",
				0.2
			}));
			bolt4.GetComponent<BoltLogicC>().isLoose = false;
			bolt4.GetComponent<BoltLogicC>().boltStateLoose = false;
			this.rearRightTyre.SendMessage("SendStatsToCarPerf");
		}
		else
		{
			this.myLogic.rearRightWheelCollider.GetComponent<WheelScriptPCC>().HandBrakeOn();
			this.rearRightTyre.transform.parent.GetComponent<HoldingLogicC>().isOccupied = false;
			this.rearRightTyre.transform.parent.GetComponent<Collider>().enabled = true;
			GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.tyreCatalogue[0], base.transform.position, base.transform.rotation);
			gameObject8.transform.parent = this.rearRightTyre.transform.parent;
			gameObject8.transform.localPosition = Vector3.zero;
			gameObject8.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
			gameObject8.transform.parent = null;
			UnityEngine.Object.Destroy(this.rearRightTyre);
			this.rearRightTyre = null;
			this.rearRightBricks = gameObject8;
		}
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00023404 File Offset: 0x00021804
	private IEnumerator TutorialNumerator()
	{
		Vector3 originalPos = base.transform.root.position;
		base.transform.root.GetComponent<Rigidbody>().isKinematic = true;
		yield return new WaitForSeconds(2f);
		base.transform.root.GetComponent<Rigidbody>().isKinematic = false;
		yield return new WaitForSeconds(Time.fixedDeltaTime * 2f);
		base.transform.root.GetComponent<Rigidbody>().isKinematic = true;
		base.transform.root.position = originalPos;
		yield break;
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00023420 File Offset: 0x00021820
	public void DestroyFLBricks()
	{
		GameObject obj = UnityEngine.Object.Instantiate<GameObject>(this.bricksDestroyParticles, this.frontLeftBricks.transform.position, this.frontLeftBricks.transform.rotation);
		UnityEngine.Object.Destroy(this.frontLeftBricks);
		UnityEngine.Object.Destroy(obj, 0.5f);
		this.frontLeftBricks = null;
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00023478 File Offset: 0x00021878
	public void DestroyFRBricks()
	{
		GameObject obj = UnityEngine.Object.Instantiate<GameObject>(this.bricksDestroyParticles, this.frontRightBricks.transform.position, this.frontRightBricks.transform.rotation);
		UnityEngine.Object.Destroy(this.frontRightBricks);
		UnityEngine.Object.Destroy(obj, 0.5f);
		this.frontRightBricks = null;
	}

	// Token: 0x06000287 RID: 647 RVA: 0x000234D0 File Offset: 0x000218D0
	public void DestroyRLBricks()
	{
		GameObject obj = UnityEngine.Object.Instantiate<GameObject>(this.bricksDestroyParticles, this.rearLeftBricks.transform.position, this.rearLeftBricks.transform.rotation);
		UnityEngine.Object.Destroy(this.rearLeftBricks);
		UnityEngine.Object.Destroy(obj, 0.5f);
		this.rearLeftBricks = null;
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00023528 File Offset: 0x00021928
	public void DestroyRRBricks()
	{
		GameObject obj = UnityEngine.Object.Instantiate<GameObject>(this.bricksDestroyParticles, this.rearRightBricks.transform.position, this.rearRightBricks.transform.rotation);
		UnityEngine.Object.Destroy(this.rearRightBricks);
		UnityEngine.Object.Destroy(obj, 0.5f);
		this.rearRightBricks = null;
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00023580 File Offset: 0x00021980
	private IEnumerator BootMove()
	{
		base.transform.parent.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		iTween.PunchRotation(base.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"x",
			-0.6f,
			"easetype",
			"easeInCirc",
			"islocal",
			true,
			"time",
			1.75f
		}));
		yield return new WaitForSeconds(1.75f);
		base.transform.parent.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		this.moveRoutine = null;
		yield break;
	}

	// Token: 0x0600028A RID: 650 RVA: 0x0002359C File Offset: 0x0002199C
	public void UpdateWeight()
	{
		iTween.Stop(base.gameObject, "PunchRotation");
		Vector3 localEulerAngles = base.transform.parent.gameObject.transform.localEulerAngles;
		base.transform.parent.gameObject.transform.localEulerAngles = new Vector3(0f, localEulerAngles.y, localEulerAngles.z);
		if (this.moveRoutine != null)
		{
			base.StopCoroutine(this.moveRoutine);
		}
		this.moveRoutine = base.StartCoroutine(this.BootMove());
		base.GetComponent<AudioSource>().PlayOneShot(this.shakeSFX, 0.7f);
		this.UpdatePerformanceAcceleration();
		this.UpdateFuelEconomy();
		if (this.myLogic.engineOn && base.GetComponent<ExtraUpgradesC>().dashUIInstalled)
		{
			if (this.carBootWeight >= 180f && base.GetComponent<ExtraUpgradesC>().weightUIState != 2)
			{
				base.GetComponent<ExtraUpgradesC>().WeightRedUI();
			}
			else if (this.carBootWeight >= 120f && this.carBootWeight < 180f && base.GetComponent<ExtraUpgradesC>().weightUIState != 1)
			{
				base.GetComponent<ExtraUpgradesC>().WeightOrangeUI();
			}
			else if (this.carBootWeight < 120f && base.GetComponent<ExtraUpgradesC>().weightUIState != 0)
			{
				base.GetComponent<ExtraUpgradesC>().WeightGreenUI();
			}
		}
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00023710 File Offset: 0x00021B10
	public void UpdateAllWheelGrip()
	{
		if (this.frontLeftTyre != null)
		{
			this.frontLeftTyre.GetComponent<EngineComponentC>().UpdateCondition();
		}
		if (this.frontRightTyre != null)
		{
			this.frontRightTyre.GetComponent<EngineComponentC>().UpdateCondition();
		}
		if (this.rearLeftTyre != null)
		{
			this.rearLeftTyre.GetComponent<EngineComponentC>().UpdateCondition();
		}
		if (this.rearRightTyre != null)
		{
			this.rearRightTyre.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x0600028C RID: 652 RVA: 0x000237A4 File Offset: 0x00021BA4
	public void UpdateGrip(int wheelID, float grip, float condition, float durability, GameObject wheel, float wetGrip, float offRoadGrip)
	{
		int num = wheelID - 1;
		if (wheelID < 0)
		{
			return;
		}
		if (this.myLogic)
		{
			GameObject gameObject = this.myLogic.wheelObjects[num];
			if (gameObject.GetComponent<WheelScriptPCC>().wheelTransform != wheel.transform)
			{
				gameObject.GetComponent<WheelScriptPCC>().wheelTransform = wheel.transform;
			}
			float num2 = durability * 0.34f;
			float num3 = durability * 0.67f;
			if ((double)condition <= 0.0)
			{
				float num4 = grip * 0.95f;
				float num5 = wetGrip * 0.95f;
				float num6 = offRoadGrip * 0.95f;
				if (base.GetComponent<ExtraUpgradesC>().dashUIInstalled)
				{
					base.GetComponent<ExtraUpgradesC>().TyreFlatUI(num);
				}
			}
			else if (condition < num2)
			{
				float num4 = grip * 0.4f;
				float num5 = wetGrip * 0.4f;
				float num6 = offRoadGrip * 0.4f;
				if (base.GetComponent<ExtraUpgradesC>().dashUIInstalled)
				{
					base.GetComponent<ExtraUpgradesC>().TyreLowUI(num);
				}
			}
			else if (condition > num2 && condition < num3)
			{
				float num4 = grip * 0.2f;
				float num5 = wetGrip * 0.2f;
				float num6 = offRoadGrip * 0.2f;
				if (base.GetComponent<ExtraUpgradesC>().dashUIInstalled)
				{
					base.GetComponent<ExtraUpgradesC>().TyreHighUI(num);
				}
			}
			else if (condition > num3 && base.GetComponent<ExtraUpgradesC>().dashUIInstalled)
			{
				base.GetComponent<ExtraUpgradesC>().TyreHighUI(num);
			}
			if ((num != 2 && num != 3) || this.carBootWeight > 0f)
			{
			}
			if (this.totalCarWeight > 0f)
			{
			}
			DirectorC directorC = null;
			if (GameObject.FindWithTag("Director"))
			{
				directorC = GameObject.FindWithTag("Director").GetComponent<DirectorC>();
			}
			WheelFrictionCurve sidewaysFriction = gameObject.GetComponent<WheelCollider>().sidewaysFriction;
			if (directorC != null)
			{
				if (directorC.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
				{
					sidewaysFriction.stiffness = wetGrip;
					if (num == 0 || num == 1)
					{
						sidewaysFriction.extremumValue = wetGrip;
					}
					else if (num == 2 || num == 3)
					{
						sidewaysFriction.extremumValue = wetGrip / 3f;
					}
				}
				else if (directorC.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					sidewaysFriction.stiffness = wetGrip * 0.75f;
					float num7 = wetGrip * 0.75f;
					if (num == 0 || num == 1)
					{
						sidewaysFriction.extremumValue = num7;
					}
					else if (num == 2 || num == 3)
					{
						sidewaysFriction.extremumValue = num7 / 3f;
					}
				}
				else
				{
					sidewaysFriction.stiffness = grip;
					if (num == 0 || num == 1)
					{
						sidewaysFriction.extremumValue = grip;
					}
					else if (num == 2 || num == 3)
					{
						sidewaysFriction.extremumValue = grip / 3f;
					}
				}
			}
			else
			{
				sidewaysFriction.stiffness = grip;
				if (num == 0 || num == 1)
				{
					sidewaysFriction.extremumValue = grip;
				}
				else if (num == 2 || num == 3)
				{
					sidewaysFriction.extremumValue = grip / 3f;
				}
			}
			sidewaysFriction.extremumValue = Mathf.Clamp(sidewaysFriction.extremumValue, 1.2f, 3f);
			gameObject.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction;
			gameObject.GetComponent<WheelScriptPCC>().extremumValue = gameObject.GetComponent<WheelCollider>().sidewaysFriction.extremumValue;
		}
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00023B36 File Offset: 0x00021F36
	public void UpdateFuelInTank()
	{
		if (this.installedFuelTank != null)
		{
		}
	}

	// Token: 0x0600028E RID: 654 RVA: 0x00023B4C File Offset: 0x00021F4C
	public void UpdateFuelEconomy()
	{
		this.actualFuelConsumptionRate = this.carFuelConsumptionRate;
		if (this.installedCarburettor != null)
		{
			float num = this.installedCarburettor.GetComponent<EngineComponentC>().durability * 0.34f;
			float num2 = this.installedCarburettor.GetComponent<EngineComponentC>().durability * 0.67f;
			if (this.installedCarburettor.GetComponent<EngineComponentC>().Condition <= 0.1f)
			{
				float num3 = this.actualFuelConsumptionRate * 0.8f;
				this.actualFuelConsumptionRate -= num3;
				if (base.GetComponent<ExtraUpgradesC>().carburettorConditionUIState != 2 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().CarburettorConditionRedUI();
				}
			}
			else if (this.installedCarburettor.GetComponent<EngineComponentC>().Condition <= num)
			{
				float num3 = this.actualFuelConsumptionRate * 0.2f;
				this.actualFuelConsumptionRate -= num3;
				if (base.GetComponent<ExtraUpgradesC>().carburettorConditionUIState != 1 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().CarburettorConditionOrangeUI();
				}
			}
			else if (this.installedCarburettor.GetComponent<EngineComponentC>().Condition > num && this.installedCarburettor.GetComponent<EngineComponentC>().Condition <= num2)
			{
				float num3 = this.actualFuelConsumptionRate * 0.1f;
				this.actualFuelConsumptionRate -= num3;
				if (base.GetComponent<ExtraUpgradesC>().carburettorConditionUIState != 0)
				{
					base.GetComponent<ExtraUpgradesC>().CarburettorConditionGreenUI();
				}
			}
			else if (this.installedCarburettor.GetComponent<EngineComponentC>().Condition > num2 && base.GetComponent<ExtraUpgradesC>().carburettorConditionUIState != 0 && this.myLogic.engineOn)
			{
				base.GetComponent<ExtraUpgradesC>().CarburettorConditionGreenUI();
			}
		}
		if (this.myLogic.engineOn && this.installedFuelTank)
		{
			if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
			{
				float num3 = this.actualFuelConsumptionRate * 0.2f;
				this.actualFuelConsumptionRate += num3;
				if (base.GetComponent<ExtraUpgradesC>().oilUIState != 2)
				{
					base.GetComponent<ExtraUpgradesC>().OutOfOilUI();
				}
			}
			else if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
			{
				float num3 = this.actualFuelConsumptionRate * 0.1f;
				this.actualFuelConsumptionRate += num3;
				if (base.GetComponent<ExtraUpgradesC>().oilUIState != 1)
				{
					base.GetComponent<ExtraUpgradesC>().BadOilUI();
				}
			}
			else if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
			{
				if (base.GetComponent<ExtraUpgradesC>().oilUIState != 0)
				{
					base.GetComponent<ExtraUpgradesC>().GoodOilUI();
				}
			}
			else if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
			{
				float num3 = this.actualFuelConsumptionRate * 0.1f;
				this.actualFuelConsumptionRate -= num3;
				if (base.GetComponent<ExtraUpgradesC>().oilUIState != 1)
				{
					base.GetComponent<ExtraUpgradesC>().BadOilUI();
				}
			}
		}
		float num4 = this.totalCarWeight * 0.0125f;
		this.actualFuelConsumptionRate += num4;
	}

	// Token: 0x0600028F RID: 655 RVA: 0x00023E7C File Offset: 0x0002227C
	public void UpdatePerformanceAcceleration()
	{
		this.actualAcceleration = this.carAcceleration;
		float num = 0f;
		float num2 = 0f;
		if (this.InstalledEngine != null)
		{
			float num3 = this.InstalledEngine.GetComponent<EngineComponentC>().durability * 0.34f;
			float num4 = this.InstalledEngine.GetComponent<EngineComponentC>().durability * 0.67f;
			if ((double)this.InstalledEngine.GetComponent<EngineComponentC>().Condition <= 0.1)
			{
				num = this.actualAcceleration * 0.4f;
				this.actualAcceleration += num;
			}
			else if (this.InstalledEngine.GetComponent<EngineComponentC>().Condition < num3 && this.InstalledEngine.GetComponent<EngineComponentC>().Condition > 0.1f)
			{
				num = this.actualAcceleration * 0.2f;
				this.actualAcceleration += num;
			}
			else if (this.InstalledEngine.GetComponent<EngineComponentC>().Condition > num3 && this.InstalledEngine.GetComponent<EngineComponentC>().Condition < num4)
			{
				num = this.actualAcceleration * 0.1f;
				this.actualAcceleration += num;
			}
			else if (this.InstalledEngine.GetComponent<EngineComponentC>().Condition > num4)
			{
			}
		}
		num2 += num * 0.1f;
		if (this.installedFuelTank && this.installedFuelTank.GetComponent<EngineComponentC>())
		{
			if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
			{
				num = this.actualAcceleration * 0.2f;
				this.actualAcceleration -= num;
				num2 += num * 0.1f;
			}
			else if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
			{
				num = this.actualAcceleration * 0.1f;
				this.actualAcceleration -= num;
				num2 += num * 0.1f;
			}
			else if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix != 2)
			{
				if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
				{
					num = this.actualAcceleration * 0.1f;
					this.actualAcceleration += num;
					num2 -= num * 0.1f;
				}
			}
		}
		float num5 = this.totalCarWeight * 0.12f;
		this.actualAcceleration += num5;
		if (!base.transform.parent.transform.parent.GetComponent<CarControleScriptC>())
		{
			return;
		}
		base.transform.parent.transform.parent.GetComponent<CarControleScriptC>().enginePitchAdj = num2;
		if (!this.myLogic.isPushingCar)
		{
			float num6 = 90f / this.actualAcceleration;
			num6 *= 0.75f;
			base.transform.parent.transform.parent.GetComponent<CarControleScriptC>().maxTorque = num6;
		}
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00024180 File Offset: 0x00022580
	public void UpdatePerformanceTopSpeed()
	{
		this.actualTopSpeed = this.carTopSpeed + 50f;
		if (this.InstalledEngine != null)
		{
			if (this.InstalledEngine.GetComponent<EngineComponentC>().TopSpeed > 0f)
			{
				this.actualTopSpeed = this.InstalledEngine.GetComponent<EngineComponentC>().TopSpeed;
			}
			float num = this.InstalledEngine.GetComponent<EngineComponentC>().durability * 0.34f;
			float num2 = this.InstalledEngine.GetComponent<EngineComponentC>().durability * 0.67f;
			if (this.InstalledEngine.GetComponent<EngineComponentC>().Condition <= 0.1f)
			{
				Debug.Log("Car Performance broken damage fired");
				float num3 = this.actualTopSpeed * 0.6f;
				this.actualTopSpeed -= num3;
				this.myLogic.EngineDamageHigh();
				if (base.GetComponent<ExtraUpgradesC>().engineBlockConditionUIState != 2 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().EngineBlockConditionRedUI();
				}
			}
			else if (this.InstalledEngine.GetComponent<EngineComponentC>().Condition < num && (double)this.InstalledEngine.GetComponent<EngineComponentC>().Condition > 0.1)
			{
				float num3 = this.actualTopSpeed * 0.2f;
				this.actualTopSpeed -= num3;
				this.myLogic.EngineDamageMed();
				if (base.GetComponent<ExtraUpgradesC>().engineBlockConditionUIState != 1 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().EngineBlockConditionOrangeUI();
				}
			}
			else if (this.InstalledEngine.GetComponent<EngineComponentC>().Condition > num && this.InstalledEngine.GetComponent<EngineComponentC>().Condition < num2)
			{
				float num3 = this.actualTopSpeed * 0.1f;
				this.actualTopSpeed -= num3;
				this.myLogic.EngineDamageLow();
				if (base.GetComponent<ExtraUpgradesC>().engineBlockConditionUIState != 0 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().EngineBlockConditionGreenUI();
				}
			}
			else if (this.InstalledEngine.GetComponent<EngineComponentC>().Condition > num2)
			{
				this.myLogic.EngineDamageNone();
				if (base.GetComponent<ExtraUpgradesC>().engineBlockConditionUIState != 0 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().EngineBlockConditionGreenUI();
				}
			}
		}
		if (this.installedFuelTank && this.installedFuelTank.GetComponent<EngineComponentC>())
		{
			if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
			{
				float num3 = this.actualTopSpeed * 0.05f;
				this.actualTopSpeed += num3;
			}
			else if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
			{
				float num3 = this.actualTopSpeed * 0.025f;
				this.actualTopSpeed += num3;
			}
			else if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix != 2)
			{
				if (this.installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 3)
				{
					float num3 = this.actualTopSpeed * 0.15f;
					this.actualTopSpeed -= num3;
				}
			}
		}
		if (!this.myLogic.isPushingCar)
		{
			float topSpeed = (this.actualTopSpeed + 42f) / 3.5f;
			base.transform.parent.transform.parent.GetComponent<CarControleScriptC>().TopSpeed = topSpeed;
		}
	}

	// Token: 0x06000291 RID: 657 RVA: 0x00024508 File Offset: 0x00022908
	public void UpdateAirFilter()
	{
		if (this.installedAirFilter == null)
		{
			return;
		}
		float num = this.installedAirFilter.GetComponent<EngineComponentC>().durability * 0.34f;
		float num2 = this.installedAirFilter.GetComponent<EngineComponentC>().durability * 0.67f;
		if (this.installedAirFilter.GetComponent<EngineComponentC>().Condition <= 0.1f)
		{
			this.carEngineWearRate = 0f;
			if (base.GetComponent<ExtraUpgradesC>().airFilterConditionUIState != 2 && this.myLogic.engineOn)
			{
				base.GetComponent<ExtraUpgradesC>().AirFilterConditionRedUI();
			}
		}
		else if (this.installedAirFilter.GetComponent<EngineComponentC>().Condition < num)
		{
			this.carEngineWearRate = this.installedAirFilter.GetComponent<EngineComponentC>().engineWearRate * 0.8f;
			if (base.GetComponent<ExtraUpgradesC>().airFilterConditionUIState != 1 && this.myLogic.engineOn)
			{
				base.GetComponent<ExtraUpgradesC>().AirFilterConditionOrangeUI();
			}
		}
		else if (this.installedAirFilter.GetComponent<EngineComponentC>().Condition > num && this.installedAirFilter.GetComponent<EngineComponentC>().Condition < num2)
		{
			this.carEngineWearRate = this.installedAirFilter.GetComponent<EngineComponentC>().engineWearRate * 0.9f;
			if (base.GetComponent<ExtraUpgradesC>().airFilterConditionUIState != 0 && this.myLogic.engineOn)
			{
				base.GetComponent<ExtraUpgradesC>().AirFilterConditionGreenUI();
			}
		}
		else if (this.installedAirFilter.GetComponent<EngineComponentC>().Condition > num2)
		{
			this.carEngineWearRate = this.installedAirFilter.GetComponent<EngineComponentC>().engineWearRate;
			if (base.GetComponent<ExtraUpgradesC>().airFilterConditionUIState != 0 && this.myLogic.engineOn)
			{
				base.GetComponent<ExtraUpgradesC>().AirFilterConditionGreenUI();
			}
		}
	}

	// Token: 0x06000292 RID: 658 RVA: 0x000246E0 File Offset: 0x00022AE0
	public void Minus1Water()
	{
		this.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges--;
		if (base.GetComponent<ExtraUpgradesC>().dashUIInstalled && this.myLogic.engineOn)
		{
			double num = (double)this.waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges * 0.34;
			double num2 = (double)this.waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges * 0.67;
			if ((double)this.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges > num)
			{
				base.GetComponent<ExtraUpgradesC>().HighWaterUI();
			}
			else if ((double)this.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges < num && (double)this.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges > 0.0)
			{
				base.GetComponent<ExtraUpgradesC>().LowWaterUI();
			}
			else if (this.waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges == 0)
			{
				base.GetComponent<ExtraUpgradesC>().OutOfWaterUI();
			}
		}
	}

	// Token: 0x06000293 RID: 659 RVA: 0x000247EA File Offset: 0x00022BEA
	public void FuelTankAdded()
	{
	}

	// Token: 0x06000294 RID: 660 RVA: 0x000247EC File Offset: 0x00022BEC
	public void EngineRemoved()
	{
		if (this.myLogic.engineOn)
		{
			base.StartCoroutine(this.myLogic.ignition.GetComponent<IgnitionLogicC>().TurnBack());
		}
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0002481A File Offset: 0x00022C1A
	public void CarburettorRemoved()
	{
		if (this.myLogic.engineOn)
		{
			base.StartCoroutine(this.myLogic.ignition.GetComponent<IgnitionLogicC>().TurnBack());
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x00024848 File Offset: 0x00022C48
	public void FuelTankRemoved()
	{
		if (this.myLogic.engineOn)
		{
			base.StartCoroutine(this.myLogic.ignition.GetComponent<IgnitionLogicC>().TurnBack());
		}
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00024878 File Offset: 0x00022C78
	public void UpdateIgnitionCoil()
	{
		if (this.installedIgnitionCoil == null)
		{
			return;
		}
		float num = this.installedIgnitionCoil.GetComponent<EngineComponentC>().durability * 0.34f;
		float num2 = this.installedIgnitionCoil.GetComponent<EngineComponentC>().durability * 0.67f;
		if ((double)this.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition <= 0.1)
		{
			if (this.carIgnitionTime != this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer * 10f)
			{
				this.carIgnitionTime = this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer * 10f;
				this.carInitialFuelConsumptionAmount = this.installedIgnitionCoil.GetComponent<EngineComponentC>().initialFuelConsumptionAmount * 2f;
				if (base.GetComponent<ExtraUpgradesC>().ignitionCoilConditionUIState != 2 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().IgnitionCoilConditionRedUI();
				}
			}
		}
		else if (this.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition < num)
		{
			if (this.carIgnitionTime != this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer * 5f)
			{
				this.carIgnitionTime = this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer * 5f;
				this.carInitialFuelConsumptionAmount = this.installedIgnitionCoil.GetComponent<EngineComponentC>().initialFuelConsumptionAmount * 0.8f;
				if (base.GetComponent<ExtraUpgradesC>().ignitionCoilConditionUIState != 1 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().IgnitionCoilConditionOrangeUI();
				}
			}
		}
		else if (this.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition > num && this.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition < num2)
		{
			if ((double)this.carIgnitionTime != (double)this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer * 2.5)
			{
				this.carIgnitionTime = this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer * 2.5f;
				this.carInitialFuelConsumptionAmount = this.installedIgnitionCoil.GetComponent<EngineComponentC>().initialFuelConsumptionAmount * 0.9f;
				if (base.GetComponent<ExtraUpgradesC>().ignitionCoilConditionUIState != 0 && this.myLogic.engineOn)
				{
					base.GetComponent<ExtraUpgradesC>().IgnitionCoilConditionGreenUI();
				}
			}
		}
		else if (this.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition > num2 && this.carIgnitionTime != this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer)
		{
			this.carIgnitionTime = this.installedIgnitionCoil.GetComponent<EngineComponentC>().ignitionTimer;
			this.carInitialFuelConsumptionAmount = this.installedIgnitionCoil.GetComponent<EngineComponentC>().initialFuelConsumptionAmount;
			if (base.GetComponent<ExtraUpgradesC>().ignitionCoilConditionUIState != 0 && this.myLogic.engineOn)
			{
				base.GetComponent<ExtraUpgradesC>().IgnitionCoilConditionGreenUI();
			}
		}
		this.myLogic.ignition.GetComponent<IgnitionLogicC>().holdTimeMin = this.carIgnitionTime * 2f;
	}

	// Token: 0x06000298 RID: 664 RVA: 0x00024B74 File Offset: 0x00022F74
	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "MainMenu")
		{
			return;
		}
		for (int i = 0; i < this.ghostMesh.Length; i++)
		{
			if (this.ghostMesh[i].activeInHierarchy)
			{
				float value = Mathf.PingPong(Time.time, 0.75f) + 1.24f;
				this.ghostMesh[i].GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
		if (this.myLogic.ignition.GetComponent<IgnitionLogicC>().currentPos == 1)
		{
			if (this.installedFuelTank != null)
			{
				float num = 135f / this.installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
				base.transform.root.GetComponent<CarControleScriptC>().fuelOMeterPointer.GetComponent<SpeedometerLogicC>().SetNeedle(this.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount * num);
			}
			else
			{
				base.transform.root.GetComponent<CarControleScriptC>().fuelOMeterPointer.GetComponent<SpeedometerLogicC>().SetNeedle(0f);
			}
		}
		else if (base.transform.root.GetComponent<CarControleScriptC>().fuelOMeterPointer != null)
		{
			base.transform.root.GetComponent<CarControleScriptC>().fuelOMeterPointer.GetComponent<SpeedometerLogicC>().SetNeedle(0f);
		}
	}

	// Token: 0x06000299 RID: 665 RVA: 0x00024CE4 File Offset: 0x000230E4
	private void TurnOnGhostMesh(int ID, Mesh meshInfo)
	{
		if (this.ghostMesh[ID].transform.parent.GetComponent<HoldingLogicC>().isOccupied)
		{
			return;
		}
		this.ghostMesh[ID].GetComponent<MeshFilter>().mesh = meshInfo;
		this.ghostMesh[ID].SetActive(true);
		BoxCollider[] components = this.ghostMesh[ID].transform.parent.GetComponents<BoxCollider>();
		foreach (BoxCollider boxCollider in components)
		{
			boxCollider.enabled = true;
		}
	}

	// Token: 0x0600029A RID: 666 RVA: 0x00024D6D File Offset: 0x0002316D
	public void GhostFuelTankGo(Mesh meshInfo)
	{
		this.TurnOnGhostMesh(0, meshInfo);
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00024D77 File Offset: 0x00023177
	public void GhostBatteryGo(Mesh meshInfo)
	{
		this.TurnOnGhostMesh(1, meshInfo);
	}

	// Token: 0x0600029C RID: 668 RVA: 0x00024D81 File Offset: 0x00023181
	public void GhostWaterTankGo(Mesh meshInfo)
	{
		this.TurnOnGhostMesh(2, meshInfo);
	}

	// Token: 0x0600029D RID: 669 RVA: 0x00024D8B File Offset: 0x0002318B
	public void GhostEngineBlockGo(Mesh meshInfo)
	{
		this.TurnOnGhostMesh(3, meshInfo);
	}

	// Token: 0x0600029E RID: 670 RVA: 0x00024D95 File Offset: 0x00023195
	public void GhostIgnitionCoilGo(Mesh meshInfo)
	{
		this.TurnOnGhostMesh(4, meshInfo);
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00024D9F File Offset: 0x0002319F
	public void GhostCarburettorGo(Mesh meshInfo)
	{
		this.TurnOnGhostMesh(5, meshInfo);
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x00024DA9 File Offset: 0x000231A9
	public void GhostAirFilterGo(Mesh meshInfo)
	{
		this.TurnOnGhostMesh(6, meshInfo);
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00024DB4 File Offset: 0x000231B4
	public void GhostStop()
	{
		for (int i = 0; i < this.ghostMesh.Length; i++)
		{
			this.ghostMesh[i].SetActive(false);
		}
		if (this.ghostMesh.Length > 0)
		{
			BoxCollider[] components = this.ghostMesh[0].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider in components)
			{
				boxCollider.enabled = false;
			}
			components = this.ghostMesh[1].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider2 in components)
			{
				boxCollider2.enabled = false;
			}
			components = this.ghostMesh[2].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider3 in components)
			{
				boxCollider3.enabled = false;
			}
			components = this.ghostMesh[3].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider4 in components)
			{
				boxCollider4.enabled = false;
			}
			components = this.ghostMesh[4].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider5 in components)
			{
				boxCollider5.enabled = false;
			}
			components = this.ghostMesh[5].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider6 in components)
			{
				boxCollider6.enabled = false;
			}
			components = this.ghostMesh[6].transform.parent.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider7 in components)
			{
				boxCollider7.enabled = false;
			}
		}
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x00024FC8 File Offset: 0x000233C8
	public void GetCarCondition()
	{
		this.carCondition = 0f;
		this.carDurability = 0f;
		if (this.installedIgnitionCoil != null)
		{
			this.carCondition += this.installedIgnitionCoil.GetComponent<EngineComponentC>().Condition;
			this.carDurability += this.installedIgnitionCoil.GetComponent<EngineComponentC>().durability;
		}
		if (this.InstalledEngine != null)
		{
			this.carCondition += this.InstalledEngine.GetComponent<EngineComponentC>().Condition;
			this.carDurability += this.InstalledEngine.GetComponent<EngineComponentC>().durability;
		}
		if (this.installedCarburettor != null)
		{
			this.carCondition += this.installedCarburettor.GetComponent<EngineComponentC>().Condition;
			this.carDurability += this.installedCarburettor.GetComponent<EngineComponentC>().durability;
		}
		if (this.installedFuelTank != null)
		{
			this.carCondition += this.installedFuelTank.GetComponent<EngineComponentC>().Condition;
			this.carDurability += this.installedFuelTank.GetComponent<EngineComponentC>().durability;
		}
		if (this.installedAirFilter != null)
		{
			this.carCondition += this.installedAirFilter.GetComponent<EngineComponentC>().Condition;
			this.carDurability += this.installedAirFilter.GetComponent<EngineComponentC>().durability;
		}
		if (this.installedBattery != null)
		{
			this.carCondition += this.installedBattery.GetComponent<EngineComponentC>().Condition;
			this.carDurability += this.installedBattery.GetComponent<EngineComponentC>().durability;
		}
		if (this.waterTankObj != null)
		{
			this.carCondition += this.waterTankObj.GetComponent<EngineComponentC>().Condition;
			this.carDurability += this.waterTankObj.GetComponent<EngineComponentC>().durability;
		}
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x000251F8 File Offset: 0x000235F8
	public void PotHoleHitFLWheel()
	{
		float currentSpeed = base.transform.root.GetComponent<CarControleScriptC>().currentSpeed;
		if (currentSpeed > 25f)
		{
			float num = UnityEngine.Random.Range(currentSpeed / 2f, currentSpeed);
			num /= 400f;
			this.frontLeftTyre.GetComponent<EngineComponentC>().Condition -= num;
			if ((double)this.frontLeftTyre.GetComponent<EngineComponentC>().Condition < 0.0)
			{
				this.frontLeftTyre.GetComponent<EngineComponentC>().Condition = 0f;
			}
		}
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x00025288 File Offset: 0x00023688
	public void PotHoleHitFRWheel()
	{
		float currentSpeed = base.transform.root.GetComponent<CarControleScriptC>().currentSpeed;
		if (currentSpeed > 25f)
		{
			float num = UnityEngine.Random.Range(currentSpeed / 2f, currentSpeed);
			num /= 400f;
			this.frontRightTyre.GetComponent<EngineComponentC>().Condition -= num;
			if ((double)this.frontRightTyre.GetComponent<EngineComponentC>().Condition < 0.0)
			{
				this.frontRightTyre.GetComponent<EngineComponentC>().Condition = 0f;
			}
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x00025318 File Offset: 0x00023718
	public void PotHoleHitRLWheel()
	{
		float currentSpeed = base.transform.root.GetComponent<CarControleScriptC>().currentSpeed;
		if (currentSpeed > 25f)
		{
			float num = UnityEngine.Random.Range(currentSpeed / 2f, currentSpeed);
			num /= 400f;
			this.rearLeftTyre.GetComponent<EngineComponentC>().Condition -= num;
			if ((double)this.rearLeftTyre.GetComponent<EngineComponentC>().Condition < 0.0)
			{
				this.rearLeftTyre.GetComponent<EngineComponentC>().Condition = 0f;
			}
		}
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x000253A8 File Offset: 0x000237A8
	public void PotHoleHitRRWheel()
	{
		float currentSpeed = base.transform.root.GetComponent<CarControleScriptC>().currentSpeed;
		if (currentSpeed > 25f)
		{
			float num = UnityEngine.Random.Range(currentSpeed / 2f, currentSpeed);
			num /= 400f;
			this.rearRightTyre.GetComponent<EngineComponentC>().Condition -= num;
			if ((double)this.rearRightTyre.GetComponent<EngineComponentC>().Condition < 0.0)
			{
				this.rearRightTyre.GetComponent<EngineComponentC>().Condition = 0f;
			}
		}
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x00025438 File Offset: 0x00023838
	public void RepairDoorLoad()
	{
		if (this.carDoorRepaired)
		{
			this.RepairDoor();
		}
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x0002544C File Offset: 0x0002384C
	public void RepairDoor()
	{
		this.carDoorMeshTransforms[0].GetComponent<MeshFilter>().mesh = this.carDoorMeshData[0];
		this.carDoorMeshTransforms[1].GetComponent<MeshFilter>().mesh = this.carDoorMeshData[1];
		this.carDoorMeshTransforms[2].GetComponent<MeshFilter>().mesh = this.carDoorMeshData[2];
		this.carDoorMeshTransforms[3].GetComponent<MeshFilter>().mesh = this.carDoorMeshData[3];
		this.carDoorMeshTransforms[4].GetComponent<MeshFilter>().mesh = this.carDoorMeshData[4];
		this.carDoorMeshTransforms[0].GetChild(6).GetComponent<DoorLogicC>().isBroken = false;
		this.carDoorMeshTransforms[0].GetChild(2).GetChild(0).GetComponent<WindowLogicC>().openChance = 100;
		this.carDoorRepaired = true;
		ES3.Save(this.carDoorRepaired, "carDoorRepaired");
	}

	// Token: 0x040003DB RID: 987
	public float carCharge;

	// Token: 0x040003DC RID: 988
	public float carIgnitionTime;

	// Token: 0x040003DD RID: 989
	public float carInitialFuelConsumptionAmount;

	// Token: 0x040003DE RID: 990
	public float installedIgnitionCoilWeight;

	// Token: 0x040003DF RID: 991
	public int ignitionCoilLoadID;

	// Token: 0x040003E0 RID: 992
	public GameObject[] ignitionCoilCatalogue;

	// Token: 0x040003E1 RID: 993
	public GameObject installedIgnitionCoil;

	// Token: 0x040003E2 RID: 994
	[Header("Engine")]
	public float carAcceleration;

	// Token: 0x040003E3 RID: 995
	public float actualAcceleration;

	// Token: 0x040003E4 RID: 996
	public float carTopSpeed;

	// Token: 0x040003E5 RID: 997
	public float actualTopSpeed;

	// Token: 0x040003E6 RID: 998
	public float installedEngineWeight;

	// Token: 0x040003E7 RID: 999
	public float carEngineWearRate;

	// Token: 0x040003E8 RID: 1000
	public int engineLoadID;

	// Token: 0x040003E9 RID: 1001
	public GameObject[] engineCatalogue;

	// Token: 0x040003EA RID: 1002
	public GameObject installedEngine;

	// Token: 0x040003EB RID: 1003
	[Header("Carburettor")]
	public float carFuelConsumptionRate;

	// Token: 0x040003EC RID: 1004
	public float actualFuelConsumptionRate;

	// Token: 0x040003ED RID: 1005
	public float installedCarburettorWeight;

	// Token: 0x040003EE RID: 1006
	public int carburettorLoadID;

	// Token: 0x040003EF RID: 1007
	public GameObject[] carburettorCatalogue;

	// Token: 0x040003F0 RID: 1008
	public GameObject installedCarburettor;

	// Token: 0x040003F1 RID: 1009
	[Header("Fuel Tank")]
	public float installedFuelTankWeight;

	// Token: 0x040003F2 RID: 1010
	public int fuelTankLoadID;

	// Token: 0x040003F3 RID: 1011
	public GameObject[] fuelTankCatalogue;

	// Token: 0x040003F4 RID: 1012
	public GameObject installedFuelTank;

	// Token: 0x040003F5 RID: 1013
	[Header("Air Filter")]
	public float installedAirFilterWeight;

	// Token: 0x040003F6 RID: 1014
	public int airFilterLoadID;

	// Token: 0x040003F7 RID: 1015
	public GameObject[] airFilterCatalogue;

	// Token: 0x040003F8 RID: 1016
	public GameObject installedAirFilter;

	// Token: 0x040003F9 RID: 1017
	[Header("Battery")]
	public float installedBatteryWeight;

	// Token: 0x040003FA RID: 1018
	public int batteryLoadID;

	// Token: 0x040003FB RID: 1019
	public GameObject[] batteryCatalogue;

	// Token: 0x040003FC RID: 1020
	public GameObject installedBattery;

	// Token: 0x040003FD RID: 1021
	[Header("Water Tank")]
	public float installedWaterTankWeight;

	// Token: 0x040003FE RID: 1022
	public int waterTankLoadID;

	// Token: 0x040003FF RID: 1023
	public GameObject[] waterTankCatalogue;

	// Token: 0x04000400 RID: 1024
	public GameObject waterTankObj;

	// Token: 0x04000401 RID: 1025
	[Header("Tyres")]
	public float carOnRoadGrip;

	// Token: 0x04000402 RID: 1026
	public float carWetGrip;

	// Token: 0x04000403 RID: 1027
	public float carOffRoadGrip;

	// Token: 0x04000404 RID: 1028
	public int flTyreID;

	// Token: 0x04000405 RID: 1029
	public float flCompoundID;

	// Token: 0x04000406 RID: 1030
	public int frTyreID;

	// Token: 0x04000407 RID: 1031
	public float frCompoundID;

	// Token: 0x04000408 RID: 1032
	public int rlTyreID;

	// Token: 0x04000409 RID: 1033
	public float rlCompoundID;

	// Token: 0x0400040A RID: 1034
	public int rrTyreID;

	// Token: 0x0400040B RID: 1035
	public float rrCompoundID;

	// Token: 0x0400040C RID: 1036
	public GameObject[] tyreCatalogue;

	// Token: 0x0400040D RID: 1037
	public GameObject frontLeftTyre;

	// Token: 0x0400040E RID: 1038
	public GameObject frontRightTyre;

	// Token: 0x0400040F RID: 1039
	public GameObject rearLeftTyre;

	// Token: 0x04000410 RID: 1040
	public GameObject rearRightTyre;

	// Token: 0x04000411 RID: 1041
	[HideInInspector]
	public GameObject frontLeftBricks;

	// Token: 0x04000412 RID: 1042
	[HideInInspector]
	public GameObject frontRightBricks;

	// Token: 0x04000413 RID: 1043
	[HideInInspector]
	public GameObject rearLeftBricks;

	// Token: 0x04000414 RID: 1044
	[HideInInspector]
	public GameObject rearRightBricks;

	// Token: 0x04000415 RID: 1045
	public GameObject bricksDestroyParticles;

	// Token: 0x04000416 RID: 1046
	[Header("Weights")]
	public float totalCarWeight;

	// Token: 0x04000417 RID: 1047
	public float carBootWeight;

	// Token: 0x04000418 RID: 1048
	public float carExtrasWeight;

	// Token: 0x04000419 RID: 1049
	public AudioClip shakeSFX;

	// Token: 0x0400041A RID: 1050
	[Header("Conditioning")]
	public float carCondition;

	// Token: 0x0400041B RID: 1051
	public float carDurability;

	// Token: 0x0400041C RID: 1052
	[Header("Upgrades")]
	public GameObject[] upgradeHolders;

	// Token: 0x0400041D RID: 1053
	public GameObject[] installedUpgrades;

	// Token: 0x0400041E RID: 1054
	public Transform[] carDoorMeshTransforms;

	// Token: 0x0400041F RID: 1055
	public Mesh[] carDoorMeshData;

	// Token: 0x04000420 RID: 1056
	public bool carDoorRepaired;

	// Token: 0x04000421 RID: 1057
	[Header("Ghost Mesh")]
	public GameObject[] ghostMesh;

	// Token: 0x04000422 RID: 1058
	public CarLogicC myLogic;

	// Token: 0x04000423 RID: 1059
	private Coroutine moveRoutine;
}
