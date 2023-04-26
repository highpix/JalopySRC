using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000081 RID: 129
public class CarControleScriptC : MonoBehaviour
{
	// Token: 0x06000266 RID: 614 RVA: 0x00020173 File Offset: 0x0001E573
	private void Awake()
	{
		CarControleScriptC.Global = this;
	}

	// Token: 0x06000267 RID: 615 RVA: 0x0002017B File Offset: 0x0001E57B
	private void OnDestroy()
	{
		CarControleScriptC.Global = null;
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000268 RID: 616 RVA: 0x00020183 File Offset: 0x0001E583
	// (set) Token: 0x06000269 RID: 617 RVA: 0x0002018B File Offset: 0x0001E58B
	public bool Braked
	{
		get
		{
			return this.braked;
		}
		set
		{
			this.braked = value;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x0600026A RID: 618 RVA: 0x00020194 File Offset: 0x0001E594
	// (set) Token: 0x0600026B RID: 619 RVA: 0x0002019C File Offset: 0x0001E59C
	public float TopSpeed
	{
		get
		{
			return this.topSpeed;
		}
		set
		{
			this.topSpeed = value;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x0600026C RID: 620 RVA: 0x000201A5 File Offset: 0x0001E5A5
	// (set) Token: 0x0600026D RID: 621 RVA: 0x000201AD File Offset: 0x0001E5AD
	public bool IsPaused
	{
		get
		{
			return this.isPaused;
		}
		set
		{
			this.isPaused = value;
			base.GetComponent<Rigidbody>().freezeRotation = value;
		}
	}

	// Token: 0x0600026E RID: 622 RVA: 0x000201C2 File Offset: 0x0001E5C2
	private void Start()
	{
		this.myBody = base.GetComponent<Rigidbody>();
		base.Invoke("LateStart", 3f);
	}

	// Token: 0x0600026F RID: 623 RVA: 0x000201E0 File Offset: 0x0001E5E0
	private void LateStart()
	{
		this.mySpeedometerLogic = this.speedOMeterPointer.GetComponent<SpeedometerLogicC>();
		this.carPerformance = this.carLogic.GetComponent<CarPerformanceC>();
		this.exhaustSystem = this.exhaust.GetComponentInChildren<ParticleSystem>();
		this.myDirector = this.director.GetComponent<DirectorC>();
		this.myCarLogic = this.carLogic.GetComponent<CarLogicC>();
		this._camera = Camera.main.gameObject;
		this.myBody.centerOfMass = this.centerOfMass;
		this.lastPosition = base.transform.position;
		this.uncleObj = GameObject.Find("Uncle");
		base.StartCoroutine("OdometerGo");
	}

	// Token: 0x06000270 RID: 624 RVA: 0x00020290 File Offset: 0x0001E690
	private IEnumerator OdometerGo()
	{
		yield return new WaitForSeconds(1f);
		this.odometerDistanceCheckValue = this.totalDistance + 32f;
		yield break;
	}

	// Token: 0x06000271 RID: 625 RVA: 0x000202AB File Offset: 0x0001E6AB
	private void FixedUpdate()
	{
		this.HandBrake();
	}

	// Token: 0x06000272 RID: 626 RVA: 0x000202B4 File Offset: 0x0001E6B4
	private void Update()
	{
		this.myBody.centerOfMass = this.centerOfMass;
		if (this.exhaustSystem == null)
		{
			this.exhaustSystem = this.exhaust.GetComponentInChildren<ParticleSystem>();
		}
		this.CalculateSpeed();
		if (this.exhaustSystem == null)
		{
			return;
		}
		this.EngineSound();
		this.CalculateOdometer();
		if (this.currentSpeed < 5f)
		{
			this.exhaustSystem.startSpeed = 1f;
			this.exhaustSystem.emissionRate = 4f;
			this.exhaustSystem.startLifetime = 2f;
		}
		else if (this.currentSpeed <= 20f)
		{
			this.exhaustSystem.startSpeed = 1f;
			this.exhaustSystem.emissionRate = 4f;
			this.exhaustSystem.startLifetime = 0.5f;
		}
		else
		{
			float startSpeed = this.currentSpeed / 160f;
			this.exhaustSystem.startSpeed = startSpeed;
			float emissionRate = this.currentSpeed / 4f;
			this.exhaustSystem.emissionRate = emissionRate;
			this.exhaustSystem.startLifetime = 0.25f;
		}
		if ((Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[8]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[9])) && this.carPerformance.installedFuelTank != null && this.currentSpeed < 15f && (double)this.currentSpeed >= 0.0)
		{
			this.currentSpeed += 5f;
			if (this.carLogic.GetComponent<CarLogicC>().ignition.GetComponent<IgnitionLogicC>().ignitionIsGo)
			{
				this.carPerformance.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount -= ((!this.carLogic.GetComponent<CarLogicC>().isPushingCar) ? 0.1f : 0f);
			}
			this.myDirector.fuelUsedStats += 0.1f;
			if ((double)this.carPerformance.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount < 0.0)
			{
				this.carPerformance.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount = 0f;
			}
		}
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00020512 File Offset: 0x0001E912
	public void PushCarGo()
	{
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00020514 File Offset: 0x0001E914
	public void PushCarStop()
	{
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00020518 File Offset: 0x0001E918
	private void CalculateOdometer()
	{
		if ((double)this.fuelLoss != 0.0)
		{
			float num = Vector3.Distance(this.lastPosition, base.transform.position);
			this.totalDistance += num;
			this.lastPosition = base.transform.position;
			if (this.totalDistance > this.odometerDistanceCheckValue)
			{
				this.myCarLogic.UpdateOdometer(this.totalDistance);
				this.odometerDistanceCheckValue = this.totalDistance + 32f;
			}
		}
	}

	// Token: 0x06000276 RID: 630 RVA: 0x000205A4 File Offset: 0x0001E9A4
	private void CalculateSpeed()
	{
		if (this.mySpeedometerLogic == null)
		{
			return;
		}
		float num = Mathf.Lerp(this.lastRPM, this.dataWheel.rpm, Time.fixedDeltaTime);
		this.lastRPM = num;
		this.currentSpeed = 6f * this.dataWheel.radius * this.dataWheel.rpm * 60f / 1000f;
		float num2 = 6f * this.dataWheel.radius * num * 60f / 1000f;
		this.currentSpeed = Mathf.Round(this.currentSpeed);
		if (this.currentSpeed >= 0f)
		{
			this.mySpeedometerLogic.SetNeedle(num2 * 3f);
		}
		if (this.currentSpeed < 0f)
		{
			float num3 = num2 * -1f;
			this.mySpeedometerLogic.SetNeedle(num3 * 3f);
		}
		CarPerformanceC carPerformanceC = this.carPerformance;
		float num4 = this.carPerformance.actualFuelConsumptionRate * 100f;
		this.fuelLoss = this.currentSpeed / num4;
		if (this.currentSpeed > this.myDirector.topSpeedStats)
		{
			this.myDirector.topSpeedStats = this.currentSpeed;
		}
		if (carPerformanceC.installedFuelTank != null)
		{
			if (this.currentSpeed > 0f && this._camera.transform.parent.GetComponent<RigidbodyControllerC>().driving)
			{
				carPerformanceC.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount -= ((!this.carLogic.GetComponent<CarLogicC>().isPushingCar) ? (this.fuelLoss * Time.deltaTime) : 0f);
				this.myDirector.fuelUsedStats += this.fuelLoss * Time.deltaTime;
			}
			else if (this.currentSpeed < 0f && this._camera.transform.parent.GetComponent<RigidbodyControllerC>().driving)
			{
				carPerformanceC.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount += ((!this.carLogic.GetComponent<CarLogicC>().isPushingCar) ? (this.fuelLoss * Time.deltaTime) : 0f);
			}
			if ((double)carPerformanceC.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount <= 0.0 && this._camera.transform.parent.GetComponent<RigidbodyControllerC>().driving)
			{
				this.myCarLogic.ignition.SendMessage("Trigger");
				this.myCarLogic.OutOfFuel();
				if (this.carLogic.GetComponent<ExtraUpgradesC>().fuelUIState != 2)
				{
					this.carLogic.GetComponent<ExtraUpgradesC>().OutOfFuelUI();
				}
			}
			else if (this._camera.transform.parent != null && this._camera.transform.parent.GetComponent<RigidbodyControllerC>().driving)
			{
				double num5 = (double)carPerformanceC.installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount * 0.34;
				if ((double)carPerformanceC.installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount <= num5)
				{
					if (this.carLogic.GetComponent<ExtraUpgradesC>().fuelUIState != 1)
					{
						this.carLogic.GetComponent<ExtraUpgradesC>().LowFuelUI();
					}
				}
				else if (this.carLogic.GetComponent<ExtraUpgradesC>().fuelUIState != 0)
				{
					this.carLogic.GetComponent<ExtraUpgradesC>().HighFuelUI();
				}
			}
		}
		else
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().HighFuelUI();
		}
		if (!this.uncleObj.GetComponent<UncleLogicC>().debugStopUncleWorking || !this.uncleObj.GetComponent<UncleLogicC>().uncleGoneForever)
		{
			this.uncleObj.GetComponent<Animator>().SetFloat("carSpeed", this.currentSpeed);
		}
		if (this.uncleObj == null)
		{
			return;
		}
		if (this.currentSpeed >= 10f)
		{
			if (this.myCarLogic.hazardLightsOn && !this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutHazards)
			{
				this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutHazards = true;
				this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("ComplainDrivingHazards");
			}
			if (!this.myCarLogic.hazardLightsOn && this.myCarLogic.headlightsOn && this.myDirector.isDay && !this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutHeadlights)
			{
				this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutHeadlights = true;
			}
			if (!this.myCarLogic.windowWipersOn && this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition > 1 && !this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutWipersOff)
			{
				this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutWipersOff = true;
				this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("DrivingInRainWithoutWipersOnSlow");
			}
			if (this.myCarLogic.bonnetPopped && !this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutBonnet)
			{
				this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutBonnet = true;
				this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("DrivingWithPoppedBonnet");
			}
		}
		if (this.currentSpeed >= 40f && !this.myCarLogic.windowWipersOn && this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition > 1 && !this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutWipersOff)
		{
			this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutWipersOff = true;
			this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("DrivingInRainWithoutWipersOnFast");
		}
		if (this.currentSpeed >= 60f && !this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutSpeed)
		{
			this.uncleObj.GetComponent<UncleLogicC>().hasComplainedAboutSpeed = true;
			this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("ComplainAboutSpeed");
		}
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00020BCA File Offset: 0x0001EFCA
	private void HandBrake()
	{
		if (MainMenuC.Global == null)
		{
			return;
		}
		this.braked = false;
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00020BE4 File Offset: 0x0001EFE4
	private void EngineSound()
	{
		int num = 0;
		for (int i = 0; i < this.gearRatio.Length; i++)
		{
			if ((float)this.gearRatio[i] > this.currentSpeed)
			{
				num = i;
				break;
			}
		}
		float num2;
		if (num == 0)
		{
			num2 = 0f;
		}
		else
		{
			num2 = (float)this.gearRatio[num - 1];
		}
		float num3 = (float)this.gearRatio[num];
		int damageLvl = this.carLogic.GetComponent<CarLogicC>().damageLvl;
		float num4 = Mathf.Clamp((this.currentSpeed - num2) / (num3 - num2), 0f, 1f);
		this.enginePitch = num4 + 1.15f;
		if (damageLvl == 0)
		{
			this.enginePitch = num4 + this.enginePitch;
		}
		if (damageLvl == 1)
		{
			this.enginePitch = num4 + this.enginePitch / 1.15f;
		}
		if (damageLvl == 2)
		{
			this.enginePitch = num4 + this.enginePitch / 1.3f;
		}
		if (damageLvl == 3)
		{
			this.enginePitch = num4 + this.enginePitch / 1.45f;
		}
		if (this.IsPaused)
		{
			return;
		}
		if (this.currentSpeed == 0f && this.engineObject != null)
		{
			this.engineObject.GetComponent<AudioSource>().pitch = this.enginePitch;
		}
		else if (this.currentSpeed > 0f)
		{
			if (this.enginePitchAdj > 0f)
			{
				this.enginePitch += this.enginePitchAdj;
			}
			this.engineObject.GetComponent<AudioSource>().pitch = this.enginePitch;
		}
		else if (this.currentSpeed < 0f)
		{
			float num5 = this.enginePitch * -1f;
			if (num5 < 0.8f)
			{
				num5 = 0.8f;
			}
			else if (num5 > 1.4f)
			{
				num5 = 1.4f;
			}
			this.engineObject.GetComponent<AudioSource>().pitch = num5;
		}
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00020DF8 File Offset: 0x0001F1F8
	private void OnCollisionEnter(Collision other)
	{
		if (this.currentSpeed == 0f)
		{
			return;
		}
		if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
		{
			if (this.currentSpeed < 30f && this.currentSpeed >= 10f)
			{
				this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("CarCollisionLight");
			}
			if (this.currentSpeed >= 30f && this.currentSpeed < 60f)
			{
				this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("CarCollisionMed");
				GameObject gameObject = GameObject.FindWithTag("Steam");
				if (gameObject != null)
				{
					gameObject.SendMessage("BigCollision");
				}
			}
			if (this.currentSpeed >= 100f)
			{
				this.uncleObj.GetComponent<UncleLogicC>().StartCoroutine("CarCollisionHeavy");
				GameObject gameObject2 = GameObject.FindWithTag("Steam");
				if (gameObject2 != null)
				{
					gameObject2.SendMessage("BigCollision");
				}
			}
		}
	}

	// Token: 0x040003B1 RID: 945
	public static CarControleScriptC Global;

	// Token: 0x040003B2 RID: 946
	public GameObject _camera;

	// Token: 0x040003B3 RID: 947
	public GameObject exhaust;

	// Token: 0x040003B4 RID: 948
	private ParticleSystem exhaustSystem;

	// Token: 0x040003B5 RID: 949
	public Vector3 centerOfMass;

	// Token: 0x040003B6 RID: 950
	public WheelCollider dataWheel;

	// Token: 0x040003B7 RID: 951
	public float lowestSteerAtSpeed = 50f;

	// Token: 0x040003B8 RID: 952
	public float lowSpeedSteerAngel = 10f;

	// Token: 0x040003B9 RID: 953
	public float highSpeedSteerAngel = 1f;

	// Token: 0x040003BA RID: 954
	public float decellarationSpeed = 30f;

	// Token: 0x040003BB RID: 955
	public float maxTorque = 50f;

	// Token: 0x040003BC RID: 956
	public float lowSpeedTorqueChangeOver = 7.5f;

	// Token: 0x040003BD RID: 957
	public float lowSpeedTorqueMultiplier = 5f;

	// Token: 0x040003BE RID: 958
	public float currentSpeed;

	// Token: 0x040003BF RID: 959
	public float topSpeed = 150f;

	// Token: 0x040003C0 RID: 960
	public float maxReverseSpeed = 50f;

	// Token: 0x040003C1 RID: 961
	public bool braked;

	// Token: 0x040003C2 RID: 962
	public float maxBrakeTorque = 100f;

	// Token: 0x040003C3 RID: 963
	public GameObject speedOMeterPointer;

	// Token: 0x040003C4 RID: 964
	private SpeedometerLogicC mySpeedometerLogic;

	// Token: 0x040003C5 RID: 965
	public GameObject fuelOMeterPointer;

	// Token: 0x040003C6 RID: 966
	public int[] gearRatio;

	// Token: 0x040003C7 RID: 967
	public int minAnglePointer = -90;

	// Token: 0x040003C8 RID: 968
	public int maxAnglePointer = 180;

	// Token: 0x040003C9 RID: 969
	public GameObject engineObject;

	// Token: 0x040003CA RID: 970
	public GameObject revsObject;

	// Token: 0x040003CB RID: 971
	private bool isPaused;

	// Token: 0x040003CC RID: 972
	public GameObject uncleObj;

	// Token: 0x040003CD RID: 973
	public GameObject carLogic;

	// Token: 0x040003CE RID: 974
	private CarPerformanceC carPerformance;

	// Token: 0x040003CF RID: 975
	private CarLogicC myCarLogic;

	// Token: 0x040003D0 RID: 976
	public GameObject director;

	// Token: 0x040003D1 RID: 977
	private DirectorC myDirector;

	// Token: 0x040003D2 RID: 978
	public float enginePitchDmg0;

	// Token: 0x040003D3 RID: 979
	public float fuelLoss;

	// Token: 0x040003D4 RID: 980
	public float totalDistance;

	// Token: 0x040003D5 RID: 981
	public float odometerDistanceCheckValue;

	// Token: 0x040003D6 RID: 982
	public Vector3 lastPosition;

	// Token: 0x040003D7 RID: 983
	public float enginePitch = 1f;

	// Token: 0x040003D8 RID: 984
	public float enginePitchAdj;

	// Token: 0x040003D9 RID: 985
	private Rigidbody myBody;

	// Token: 0x040003DA RID: 986
	private float lastRPM;
}
