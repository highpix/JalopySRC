using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000116 RID: 278
public class IgnitionLogicC : MonoBehaviour
{
	// Token: 0x06000AEF RID: 2799 RVA: 0x000FF089 File Offset: 0x000FD489
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.nextAudioPitch = this.engineObject.GetComponent<AudioSource>().pitch;
		base.InvokeRepeating("NextAudioPitch", 0f, 1f);
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x000FF0C8 File Offset: 0x000FD4C8
	public void EngineShake()
	{
		this.engineObject.transform.localPosition = new Vector3(6.634415f, -2.966613f, 0.3476452f);
		iTween.PunchPosition(this.engineObject, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0.05f, 0.05f, 0.05f),
			"islocal",
			true,
			"time",
			0.125,
			"looptype",
			"loop"
		}));
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x000FF16D File Offset: 0x000FD56D
	public void NextAudioPitch()
	{
		if (!this.ignitionIsGo)
		{
			this.nextAudioPitch = UnityEngine.Random.Range(0.6f, 1f);
		}
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x000FF190 File Offset: 0x000FD590
	public void CarTweenShake()
	{
		iTween.PunchPosition(this.carLogic, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0.15f, 0.15f, 0.15f),
			"islocal",
			true,
			"time",
			0.1,
			"looptype",
			"loop",
			"oncomplete",
			"CarShakeSetRot",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x000FF236 File Offset: 0x000FD636
	public void CarShakeSetRot()
	{
		this.carLogic.transform.localEulerAngles = new Vector3(0f, -90f, 180f);
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x000FF25C File Offset: 0x000FD65C
	public void TurnBackKey()
	{
		this.currentPos = 0;
		this.keyObject.GetComponent<KeyJangleC>().IgnitionOff();
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
		this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.keyAudio, 0.7f);
		this.engineObject.GetComponent<AudioSource>().loop = false;
		iTween.Stop(this.engineObject);
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x000FF338 File Offset: 0x000FD738
	private void Update()
	{
		if (MainMenuC.Global == null)
		{
			return;
		}
		if (Input.GetButtonUp("Fire1") && this.isTriggered && this.currentPos == 1)
		{
			this.isTriggered = false;
			iTween.Stop(this.carLogic);
			this.carLogic.transform.localPosition = new Vector3(1.319854f, 0.9699586f, -2.523538f);
			if (!this.ignitionIsGo)
			{
				this.TurnBackKey();
			}
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) && this.isTriggered && this.currentPos == 1)
		{
			this.isTriggered = false;
			iTween.Stop(this.carLogic);
			this.carLogic.transform.localPosition = new Vector3(1.319854f, 0.9699586f, -2.523538f);
			if (!this.ignitionIsGo)
			{
				this.TurnBackKey();
			}
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) && this.isTriggered && this.currentPos == 1)
		{
			this.isTriggered = false;
			iTween.Stop(this.carLogic);
			this.carLogic.transform.localPosition = new Vector3(1.319854f, 0.9699586f, -2.523538f);
			if (!this.ignitionIsGo)
			{
				this.TurnBackKey();
			}
		}
		if (this.ignitionIsGo && !this.carLogic.GetComponent<CarLogicC>().isDriving && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank)
		{
			float num = 135f / this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount;
			this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().fuelOMeterPointer.GetComponent<SpeedometerLogicC>().SetNeedle(this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount * num);
		}
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
		if (!this.ignitionIsGo && this.isTriggered && this.isGlowing && !this.carLogic.GetComponent<CarLogicC>().engineOn && this.currentPos == 1)
		{
			if (Input.GetButton("Fire1") || Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[17]))
			{
				if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
				{
					if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0 || (double)this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime == 0.0 || (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition <= 0.0 || (double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition <= 0.0)
					{
						this.holdingTime = 0.1f;
						if (this.carLogic.GetComponent<ExtraUpgradesC>().ignitionCoilConditionUIState != 2 && this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil == null)
						{
							this.carLogic.GetComponent<ExtraUpgradesC>().IgnitionCoilMissingUI();
						}
						else if (this.carLogic.GetComponent<ExtraUpgradesC>().ignitionCoilConditionUIState != 2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition <= 0.0)
						{
							this.carLogic.GetComponent<ExtraUpgradesC>().IgnitionCoilConditionRedUI();
						}
						if (this.carLogic.GetComponent<ExtraUpgradesC>().chargeUIState != 2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0)
						{
							this.carLogic.GetComponent<ExtraUpgradesC>().OutOfChargeUI();
						}
						if (this.carLogic.GetComponent<ExtraUpgradesC>().batteryConditionUIState != 2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition <= 0.0)
						{
							this.carLogic.GetComponent<ExtraUpgradesC>().BatteryConditionRedUI();
						}
					}
					else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0.0 && (double)this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime > 0.0 && (double)this.carLogic.GetComponent<CarPerformanceC>().carAcceleration == 0.0 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > 0.0)
					{
						this.holdingTime = 0.1f;
						this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.1f * Time.deltaTime;
						this.CarTweenShake();
						if (this.carLogic.GetComponent<ExtraUpgradesC>().engineBlockConditionUIState != 2 && this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
						{
							this.carLogic.GetComponent<ExtraUpgradesC>().EngineBlockMissingUI();
						}
						if (this.nextAudioPitch > this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch += Time.deltaTime;
						}
						if (this.nextAudioPitch < this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch -= Time.deltaTime;
						}
					}
					else if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0f && (double)this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime > 0.0 && this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate == 0f)
					{
						this.holdingTime += Time.deltaTime;
						this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.1f * Time.deltaTime;
						this.CarTweenShake();
						if (this.nextAudioPitch > this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch += Time.deltaTime;
						}
						if (this.nextAudioPitch < this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch -= Time.deltaTime;
						}
						if (this.holdingTime > this.holdTime)
						{
							this.IgnitionGoAndFail();
						}
					}
					else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null && this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0f && (double)this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime > 0.0)
					{
						this.holdingTime += Time.deltaTime;
						this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.1f * Time.deltaTime;
						this.CarTweenShake();
						if (this.nextAudioPitch > this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch += Time.deltaTime;
						}
						if (this.nextAudioPitch < this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch -= Time.deltaTime;
						}
						if (this.holdingTime > this.holdTime)
						{
							this.IgnitionGoAndFail();
						}
					}
					else if (this.carLogic.GetComponent<CarPerformanceC>().flTyreID == 0 || this.carLogic.GetComponent<CarPerformanceC>().frTyreID == 0 || this.carLogic.GetComponent<CarPerformanceC>().rlTyreID == 0 || this.carLogic.GetComponent<CarPerformanceC>().rrTyreID == 0)
					{
						this.holdingTime += Time.deltaTime;
						this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.1f * Time.deltaTime;
						this.CarTweenShake();
						if (this.nextAudioPitch > this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch += Time.deltaTime;
						}
						if (this.nextAudioPitch < this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch -= Time.deltaTime;
						}
						if (this.holdingTime > this.holdTime)
						{
							this.IgnitionGoAndFail();
						}
					}
					else
					{
						this.holdingTime += Time.deltaTime;
						this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.1f * Time.deltaTime;
						this.CarTweenShake();
						if (this.nextAudioPitch > this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch += Time.deltaTime;
						}
						if (this.nextAudioPitch < this.engineObject.GetComponent<AudioSource>().pitch)
						{
							this.engineObject.GetComponent<AudioSource>().pitch -= Time.deltaTime;
						}
						if (this.holdingTime > this.holdTime)
						{
							base.StartCoroutine("IgnitionGo");
						}
					}
				}
				else if (this.carLogic.GetComponent<ExtraUpgradesC>().batteryConditionUIState != 2)
				{
					this.carLogic.GetComponent<ExtraUpgradesC>().BatteryMissingUI();
				}
			}
		}
		else if ((double)this.holdingTime != 0.0 && this.holdingTime < this.holdTime && !this.ignitionIsGo)
		{
			this.engineObject.GetComponent<AudioSource>().loop = false;
			this.holdingTime = 0f;
			base.StartCoroutine(this.TurnBack());
		}
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x000FFE84 File Offset: 0x000FE284
	private IEnumerator Trigger()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null)
		{
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1.transform.name != "CarKey")
			{
				yield break;
			}
		}
		else if (base.transform.parent.GetChild(1))
		{
			if (!this.seatObj.GetComponent<SeatLogicC>().isSat || this.preventIgnition)
			{
				this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.7f);
				yield break;
			}
			this.holdingTime = 0f;
			this.holdTime = UnityEngine.Random.Range(this.holdTimeMin, this.holdTimeMax);
			this.ignitionIsGo = false;
			this.isTriggered = true;
			if (this.currentPos == 0)
			{
				this.keyObject.GetComponent<KeyJangleC>().IgnitionOn();
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
				this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.keyAudio, 0.7f);
				yield return new WaitForSeconds(0.26f);
				if (Input.GetMouseButton(0) || Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[17]))
				{
					if (!(this.carLogic.GetComponent<CarPerformanceC>().installedBattery == null))
					{
						if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0f && (double)this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime != 0.0 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > 0.0)
						{
							if (!this.ignitionIsGo)
							{
								this.engineObject.GetComponent<AudioSource>().clip = this.audioSample;
								this.engineObject.GetComponent<AudioSource>().Play();
								this.engineObject.GetComponent<AudioSource>().loop = true;
							}
						}
					}
				}
				yield break;
			}
			if (this.currentPos == 1)
			{
				base.StartCoroutine(this.TurnBack());
				yield break;
			}
		}
		yield break;
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x000FFEA0 File Offset: 0x000FE2A0
	private IEnumerator IgnitionGo()
	{
		iTween.Stop(this.carLogic);
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount -= this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount <= 0.0)
			{
				this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount = 0f;
				this.currentPos = 1;
				this.holdingTime = 0f;
				this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.engineSplutterAudio);
				this.TurnBack();
				yield break;
			}
		}
		GameObject uncle = GameObject.FindWithTag("Uncle");
		uncle.GetComponent<Scene1_LogicC>().StartCoroutine("RemindPlayerOfMap");
		this.carLogic.transform.localPosition = new Vector3(1.319854f, 0.9699586f, -2.523538f);
		iTween.PunchRotation(this.carLogic, iTween.Hash(new object[]
		{
			"x",
			-3.6,
			"easetype",
			"easeInCirc",
			"islocal",
			true,
			"time",
			2.0
		}));
		this.ignitionIsGo = true;
		this.engineObject.GetComponent<AudioSource>().Stop();
		float mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.9f;
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.95f;
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 1.1f;
		}
		if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 1)
		{
			mixtureCalc /= 1.25f;
		}
		else if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 2)
		{
			mixtureCalc /= 1.5f;
		}
		else if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 3)
		{
			mixtureCalc /= 1.8f;
		}
		this.engineObject.GetComponent<AudioSource>().pitch = mixtureCalc;
		this.carLogic.GetComponent<ExtraUpgradesC>().IgnitionCheckAllUI();
		if (this.carLogic.GetComponent<CarLogicC>().radioOn)
		{
			yield return new WaitForSeconds(0.6f);
			if ((double)this.radioObject.GetComponent<AudioSource>().volume < 0.3)
			{
				base.StartCoroutine(this.radioObject.GetComponent<RadioFreqLogicC>().TurnRadioOn());
			}
		}
		base.StartCoroutine("EngineShake");
		if (!this.window1.GetComponent<WindowLogicC>().isOpen && !this.window2.GetComponent<WindowLogicC>().isOpen && !this.door1.GetComponent<DoorLogicC>().open && !this.door2.GetComponent<DoorLogicC>().open)
		{
			this.engineObject.GetComponent<AudioSource>().volume = 0.3f;
		}
		this.carLogic.GetComponent<CarLogicC>().engineOn = true;
		this.carLogic.GetComponent<CarLogicC>().EngineTurnedOn();
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			float num = 135f / this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
			this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().fuelOMeterPointer.GetComponent<SpeedometerLogicC>().SetNeedle(this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount * num);
		}
		yield break;
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x000FFEBC File Offset: 0x000FE2BC
	private IEnumerator IgnitionGoAndFail()
	{
		MonoBehaviour.print("ignition go and fail");
		iTween.Stop(this.carLogic);
		this.carLogic.transform.localPosition = new Vector3(1.319854f, 0.9699586f, -2.523538f);
		iTween.PunchRotation(this.carLogic, iTween.Hash(new object[]
		{
			"x",
			-3.6,
			"easetype",
			"easeInCirc",
			"islocal",
			true,
			"time",
			2.0
		}));
		this.ignitionIsGo = true;
		this.engineObject.GetComponent<AudioSource>().Stop();
		float mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.9f;
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.95f;
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
		}
		else if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
		{
			mixtureCalc = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 1.1f;
		}
		if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 1)
		{
			mixtureCalc /= 1.25f;
		}
		else if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 2)
		{
			mixtureCalc /= 1.5f;
		}
		else if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 3)
		{
			mixtureCalc /= 1.8f;
		}
		this.engineObject.GetComponent<AudioSource>().pitch = mixtureCalc;
		this.carLogic.GetComponent<ExtraUpgradesC>().IgnitionCheckAllUI();
		if (this.carLogic.GetComponent<CarLogicC>().radioOn)
		{
			yield return new WaitForSeconds(0.6f);
			if ((double)this.radioObject.GetComponent<AudioSource>().volume < 0.3)
			{
				base.StartCoroutine(this.radioObject.GetComponent<RadioFreqLogicC>().TurnRadioOn());
			}
		}
		if (!this.window1.GetComponent<WindowLogicC>().isOpen && !this.window2.GetComponent<WindowLogicC>().isOpen && !this.door1.GetComponent<DoorLogicC>().open && !this.door2.GetComponent<DoorLogicC>().open)
		{
			this.engineObject.GetComponent<AudioSource>().volume = 0.3f;
		}
		this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.audioEngineStartStop);
		yield return new WaitForSeconds(0.06f);
		this.TurnBack();
		yield break;
	}

	// Token: 0x06000AF9 RID: 2809 RVA: 0x000FFED8 File Offset: 0x000FE2D8
	public IEnumerator TurnBack()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			this.engineObject.GetComponent<AudioSource>().pitch = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
		}
		else
		{
			this.engineObject.GetComponent<AudioSource>().pitch = 1f;
		}
		this.engineObject.GetComponent<AudioSource>().loop = false;
		if (this.currentPos == 1)
		{
			base.StopCoroutine("IgnitionGo");
			this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().fuelOMeterPointer.GetComponent<SpeedometerLogicC>().SetNeedle(0f);
			this.ignitionIsGo = false;
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
			this.carLogic.GetComponent<CarLogicC>().engineOn = false;
			this.carLogic.GetComponent<CarLogicC>().EngineTurnedOff();
			this.carLogic.GetComponent<ExtraUpgradesC>().IgnitionAllUIOff();
			if (this.carLogic.GetComponent<CarLogicC>().radioOn)
			{
				base.StartCoroutine(this.radioObject.GetComponent<RadioFreqLogicC>().TurnRadioOff());
			}
			this.keyObject.GetComponent<KeyJangleC>().IgnitionOff();
			this.carLogic.GetComponent<CarLogicC>().DrivingStop(false);
			this.steeringWheel.GetComponent<WheelLogicC>().wheelTransforms.parent = null;
			base.StopCoroutine("EngineShake");
			base.StopCoroutine("CarTweenShake");
			iTween.Stop(this.engineObject);
			iTween.Stop(this.carLogic);
			this.engineObject.transform.localPosition = new Vector3(6.634415f, -2.966613f, 0.3476452f);
			GameObject.FindWithTag("Uncle").GetComponent<UncleLogicC>().HandBrakeCarStopped();
			this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.keyAudio, 0.7f);
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null && (double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount <= 0.0)
			{
				this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.engineSplutterAudio);
				this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount = 0f;
			}
			yield break;
		}
		yield break;
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x000FFEF4 File Offset: 0x000FE2F4
	public void RaycastEnter()
	{
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.glowMaterial;
		}
		this.isGlowing = true;
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x000FFF38 File Offset: 0x000FE338
	public void RaycastExit()
	{
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.startMaterial;
		}
		this.isGlowing = false;
	}

	// Token: 0x04000F35 RID: 3893
	private GameObject _camera;

	// Token: 0x04000F36 RID: 3894
	public bool preventIgnition;

	// Token: 0x04000F37 RID: 3895
	public GameObject carLogic;

	// Token: 0x04000F38 RID: 3896
	public GameObject engineObject;

	// Token: 0x04000F39 RID: 3897
	public GameObject seatObj;

	// Token: 0x04000F3A RID: 3898
	public float timeToComplete = 2.05f;

	// Token: 0x04000F3B RID: 3899
	public int currentPos;

	// Token: 0x04000F3C RID: 3900
	public Vector3[] positionRotation = new Vector3[0];

	// Token: 0x04000F3D RID: 3901
	public AudioClip keyAudio;

	// Token: 0x04000F3E RID: 3902
	public AudioClip audioSample;

	// Token: 0x04000F3F RID: 3903
	public AudioClip audioEngineStartStop;

	// Token: 0x04000F40 RID: 3904
	public AudioClip engineSplutterAudio;

	// Token: 0x04000F41 RID: 3905
	public Material glowMaterial;

	// Token: 0x04000F42 RID: 3906
	public Material startMaterial;

	// Token: 0x04000F43 RID: 3907
	public string easeType = "easeoutelastic";

	// Token: 0x04000F44 RID: 3908
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000F45 RID: 3909
	public float holdTime;

	// Token: 0x04000F46 RID: 3910
	public float holdingTime;

	// Token: 0x04000F47 RID: 3911
	public bool ignitionIsGo;

	// Token: 0x04000F48 RID: 3912
	public float nextAudioPitch = 1f;

	// Token: 0x04000F49 RID: 3913
	public GameObject radioObject;

	// Token: 0x04000F4A RID: 3914
	public GameObject steeringWheel;

	// Token: 0x04000F4B RID: 3915
	private bool timeForNextAudioPitch;

	// Token: 0x04000F4C RID: 3916
	private bool isGlowing;

	// Token: 0x04000F4D RID: 3917
	private bool isTriggered;

	// Token: 0x04000F4E RID: 3918
	public GameObject keyObject;

	// Token: 0x04000F4F RID: 3919
	public GameObject[] renderTargets = new GameObject[0];

	// Token: 0x04000F50 RID: 3920
	public AudioClip errorAudio;

	// Token: 0x04000F51 RID: 3921
	public GameObject door1;

	// Token: 0x04000F52 RID: 3922
	public GameObject door2;

	// Token: 0x04000F53 RID: 3923
	public GameObject window1;

	// Token: 0x04000F54 RID: 3924
	public GameObject window2;

	// Token: 0x04000F55 RID: 3925
	public float holdTimeMin = 0.5f;

	// Token: 0x04000F56 RID: 3926
	public float holdTimeMax = 1f;
}
