using System;
using UnityEngine;

// Token: 0x02000084 RID: 132
public class EngineComponentC : MonoBehaviour
{
	// Token: 0x17000029 RID: 41
	// (get) Token: 0x060002F1 RID: 753 RVA: 0x00027568 File Offset: 0x00025968
	// (set) Token: 0x060002F2 RID: 754 RVA: 0x00027570 File Offset: 0x00025970
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

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x060002F3 RID: 755 RVA: 0x00027579 File Offset: 0x00025979
	// (set) Token: 0x060002F4 RID: 756 RVA: 0x00027581 File Offset: 0x00025981
	public float Condition
	{
		get
		{
			return this.condition;
		}
		set
		{
			value = Mathf.Clamp(value, 0f, this.durability);
			this.condition = value;
		}
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0002759D File Offset: 0x0002599D
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		base.Invoke("LateStart", Time.deltaTime);
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x000275C0 File Offset: 0x000259C0
	private void LateStart()
	{
		this.LoadConditionValues();
		if (this.totalWaterCharges > 0)
		{
			this.waterTankLid.GetComponent<WaterLidC>().waterSupply.SetActive(true);
			this.waterTankLid.GetComponent<WaterLidC>().waterSupply.SetActive(false);
		}
		if (this.isTutorialObj)
		{
			if (ES3.Exists("uncleTutorialCompleted"))
			{
				if (!ES3.LoadBool("uncleTutorialCompleted") && this.componentHeader == "CMP_cmpt_decal_00_0")
				{
					UnityEngine.Object.Destroy(base.gameObject);
					return;
				}
			}
			else if (this.componentHeader == "CMP_cmpt_decal_00_0")
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
		}
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x00027680 File Offset: 0x00025A80
	private void LoadConditionValues()
	{
		if (base.GetComponent<ObjectPickupC>().isInEngine)
		{
			if (this.acceleration > 0f)
			{
				this.Condition = ES3.LoadFloat("carEngineCondition");
				this.puristCheck = ES3.LoadBool("carEnginePurist");
			}
			if (this.ignitionTimer != 0f)
			{
				this.Condition = ES3.LoadFloat("ignitionCoilCondition");
				this.puristCheck = ES3.LoadBool("ignitionCoilPurist");
			}
			if (this.totalFuelAmount != 0f)
			{
				this.Condition = ES3.LoadFloat("fuelTankCondition");
				this.puristCheck = ES3.LoadBool("fuelTankPurist");
				this.currentFuelAmount = ES3.LoadFloat("fuelTankFuelAmount");
				this.fuelMix = ES3.LoadInt("fuelTankFuelMix");
			}
			if (this.fuelConsumptionRate != 0f)
			{
				this.Condition = ES3.LoadFloat("carburettorCondition");
				this.puristCheck = ES3.LoadBool("carburettorPurist");
			}
			if (this.engineWearRate != 0f)
			{
				this.Condition = ES3.LoadFloat("airFilterCondition");
				this.puristCheck = ES3.LoadBool("airFilterPurist");
			}
			if ((float)this.totalWaterCharges != 0f)
			{
				this.Condition = ES3.LoadFloat("waterTankCondition");
				this.puristCheck = ES3.LoadBool("waterTankPurist");
				this.currentWaterCharges = ES3.LoadInt("waterTankWaterCharges");
				this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges = this.currentWaterCharges;
			}
			if (this.charge != 0f)
			{
				this.Condition = ES3.LoadFloat("batteryCondition");
				this.charge = ES3.LoadFloat("batteryCharges");
				this.puristCheck = ES3.LoadBool("batteryPurist");
			}
			if (this.wheelInstallID == 1)
			{
				this.Condition = ES3.LoadFloat("flWheelCondition");
				this.puristCheck = ES3.LoadBool("flTyrePurist");
			}
			if (this.wheelInstallID == 2)
			{
				this.Condition = ES3.LoadFloat("frWheelCondition");
				this.puristCheck = ES3.LoadBool("frTyrePurist");
			}
			if (this.wheelInstallID == 3)
			{
				this.Condition = ES3.LoadFloat("rlWheelCondition");
				this.puristCheck = ES3.LoadBool("rlTyrePurist");
			}
			if (this.wheelInstallID == 4)
			{
				this.Condition = ES3.LoadFloat("rrWheelCondition");
				this.puristCheck = ES3.LoadBool("rrTyrePurist");
			}
		}
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x00027900 File Offset: 0x00025D00
	private void Action()
	{
		if (this.totalWaterCharges > 0)
		{
			if (this.waterTankLid.GetComponent<WaterLidC>().currentPos == 0)
			{
				this.waterTankLid.GetComponent<WaterLidC>().StartCoroutine("Trigger");
			}
			base.transform.GetChild(0).SendMessage("Action");
		}
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0002795C File Offset: 0x00025D5C
	private void Update()
	{
		if (this.Condition < 0f)
		{
			this.Condition = 0f;
		}
		if (this.lowCondition == 0f && this.durability != 0f)
		{
			this.lowCondition = this.durability * 0.34f;
		}
		if (this.medCondition == 0f && this.durability != 0f)
		{
			this.medCondition = this.durability * 0.67f;
		}
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		if (base.GetComponent<ObjectPickupC>().isInEngine && this.ignitionTimer > 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().UpdateIgnitionCoil();
		}
		if (base.GetComponent<ObjectPickupC>().isInEngine && this.carLogic.GetComponent<CarLogicC>().bonnetOpen && this.Condition < this.medCondition)
		{
			if (this.Condition > this.lowCondition)
			{
				this.spriteTarget.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, 247, 133, byte.MaxValue);
			}
			else if (this.Condition < this.lowCondition && (double)this.Condition > 0.0)
			{
				this.spriteTarget.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, 201, 133, byte.MaxValue);
			}
			else if (this.Condition == 0f)
			{
				this.spriteTarget.GetComponent<SpriteRenderer>().color = new Color32(byte.MaxValue, 146, 146, byte.MaxValue);
			}
			if (!this.spriteTarget.activeInHierarchy)
			{
				this.spriteTarget.SetActive(true);
			}
			this.spriteTarget.transform.LookAt(this._camera.transform.position, -Vector3.up);
			if (this.spriteTimer > this.spriteTimerCheck)
			{
				if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[0])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[1];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[1])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[2];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[2])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[3];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[3])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
				}
				this.spriteTimer = 0f;
			}
			this.spriteTimer += Time.deltaTime;
		}
		else if (this.spriteTarget != null && this.spriteTarget.activeInHierarchy)
		{
			this.spriteTarget.SetActive(false);
		}
		if (this.fuelSpriteTarget != null)
		{
			double num = (double)this.totalFuelAmount * 0.34;
			if (base.GetComponent<ObjectPickupC>().isInEngine && this.carLogic.GetComponent<CarLogicC>().bonnetOpen && (double)this.currentFuelAmount < num)
			{
				if (!this.fuelSpriteTarget.active)
				{
					this.fuelSpriteTarget.SetActive(true);
				}
				this.fuelSpriteTarget.transform.LookAt(this._camera.transform.position, -Vector3.up);
				if (this.fuelSpriteTimer > this.spriteTimerCheck)
				{
					if (this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite == this.fuelSprites[0])
					{
						this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite = this.fuelSprites[1];
					}
					else if (this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite == this.fuelSprites[1])
					{
						this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite = this.fuelSprites[2];
					}
					else if (this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite == this.fuelSprites[2])
					{
						this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite = this.fuelSprites[3];
					}
					else if (this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite == this.fuelSprites[3])
					{
						this.fuelSpriteTarget.GetComponent<SpriteRenderer>().sprite = this.fuelSprites[0];
					}
					this.fuelSpriteTimer = 0f;
				}
			}
			else if (this.fuelSpriteTarget.active)
			{
				this.fuelSpriteTarget.SetActive(false);
			}
			this.fuelSpriteTimer += Time.deltaTime;
		}
		else if (this.fuelSpriteTarget != null && this.fuelSpriteTarget.active)
		{
			this.fuelSpriteTarget.SetActive(false);
		}
		if (base.GetComponent<ObjectPickupC>() && base.GetComponent<ObjectPickupC>().isInEngine)
		{
			if (this.carLogic == null)
			{
				this.carLogic = GameObject.FindWithTag("CarLogic");
			}
			if (this.carLogic.GetComponent<CarLogicC>().engineOn && this.fuelConsumptionRate != 0f)
			{
				this.CarburettorDurabilityLossCalc(this.carLogic);
			}
			if (this.carLogic.GetComponent<CarLogicC>().engineOn && this.engineWearRate != 0f)
			{
				this.AirFilterDurabilityLossCalc(this.carLogic);
			}
			if (this.carLogic.GetComponent<CarLogicC>().engineOn && this.TopSpeed != 0f)
			{
				this.EngineDurabilityLossCalc(this.carLogic);
			}
			if (this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>() && this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed > 5f && this.wheelInstallID > 0)
			{
				this.TyreDurabilityLossCalc(this.carLogic);
			}
		}
		if (base.GetComponent<ObjectPickupC>().isInEngine && (double)this.Condition <= 0.0 && this.isBattery && !this.batteryDepleted)
		{
			this.carLogic.GetComponent<CarLogicC>().ElectricsOff();
			this.batteryDepleted = true;
		}
		if (base.GetComponent<ObjectPickupC>().isInEngine && this.isBattery && (double)this.charge <= 0.0 && !this.batteryDepleted)
		{
			this.carLogic.GetComponent<CarLogicC>().ElectricsOff();
			this.batteryDepleted = true;
		}
	}

	// Token: 0x060002FA RID: 762 RVA: 0x000280E4 File Offset: 0x000264E4
	public void ReEnableFunctionality()
	{
		if (this.isBattery && base.GetComponent<ObjectPickupC>().isInEngine && (double)this.charge > 0.0 && this.batteryDepleted)
		{
			this.batteryDepleted = false;
		}
	}

	// Token: 0x060002FB RID: 763 RVA: 0x00028134 File Offset: 0x00026534
	public void WaterTankDurabilityCalc()
	{
		float num = this.Condition * 0.34f;
		float num2 = this.Condition * 0.67f;
		if ((double)this.Condition <= 0.0)
		{
			this.Condition = 0f;
			this.waterLeakParticles.SetActive(true);
			if (!this.isLeakingWater)
			{
				base.InvokeRepeating("LeakWater", 0f, 1f);
			}
			if (this.carLogic.GetComponent<ExtraUpgradesC>().waterTankConditionUIState != 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().WaterTankConditionRedUI();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition <= num)
		{
			if (this.carLogic.GetComponent<ExtraUpgradesC>().waterTankConditionUIState != 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().WaterTankConditionOrangeUI();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > num && this.Condition < num2)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else
		{
			this.waterLeakParticles.SetActive(false);
			base.CancelInvoke("LeakWater");
			this.isLeakingWater = false;
			if (this.carLogic != null && this.carLogic.GetComponent<ExtraUpgradesC>().waterTankConditionUIState != 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().WaterTankConditionGreenUI();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		double num3 = (double)this.totalWaterCharges * 0.34;
		if ((double)this.currentWaterCharges <= 0.0)
		{
			if (this.carLogic != null && this.carLogic.GetComponent<ExtraUpgradesC>().waterUIState != 2 && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().OutOfWaterUI();
			}
		}
		else if ((double)this.currentWaterCharges <= num3)
		{
			if (this.carLogic.GetComponent<ExtraUpgradesC>().waterUIState != 1 && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LowWaterUI();
			}
		}
		else if (this.carLogic != null && this.carLogic.GetComponent<ExtraUpgradesC>().waterUIState != 0)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().HighWaterUI();
		}
	}

	// Token: 0x060002FC RID: 764 RVA: 0x000283E4 File Offset: 0x000267E4
	private void LeakWater()
	{
		if (this.currentWaterCharges == 0)
		{
			this.isLeakingWater = false;
			this.waterLeakParticles.SetActive(false);
			base.CancelInvoke("LeakWater");
			return;
		}
		this.isLeakingWater = true;
		base.GetComponent<AudioSource>().PlayOneShot(this.fuelLeakAudio, 0.05f);
		this.waterLeakCount += 0.01f;
		if ((double)this.waterLeakCount >= 1.0)
		{
			this.waterLeakCount = 0f;
			this.currentWaterCharges--;
			base.transform.GetChild(0).gameObject.GetComponent<WaterSupplyRelayC>().WaterUpdate();
		}
	}

	// Token: 0x060002FD RID: 765 RVA: 0x00028494 File Offset: 0x00026894
	private void AirFilterDurabilityCalc()
	{
		float num = this.durability * 0.34f;
		float num2 = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0)
		{
			this.Condition = 0f;
		}
		else if (this.Condition <= num)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > num && this.Condition < num2)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (base.GetComponent<ObjectPickupC>())
		{
			base.GetComponent<ObjectPickupC>().SetPriceTag();
		}
	}

	// Token: 0x060002FE RID: 766 RVA: 0x00028560 File Offset: 0x00026960
	private void CarburettorDurabilityCalc()
	{
		float num = this.durability * 0.34f;
		float num2 = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0)
		{
			this.Condition = 0f;
		}
		else if (this.Condition <= num)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > num && this.Condition < num2)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (base.GetComponent<ObjectPickupC>())
		{
			base.GetComponent<ObjectPickupC>().SetPriceTag();
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0002862C File Offset: 0x00026A2C
	private void EngineBlockDurabilityCalc()
	{
		float num = this.durability * 0.34f;
		float num2 = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0)
		{
			this.Condition = 0f;
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition <= num)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > num && this.Condition < num2)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (base.GetComponent<ObjectPickupC>())
		{
			base.GetComponent<ObjectPickupC>().SetPriceTag();
		}
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00028714 File Offset: 0x00026B14
	private void IgnitionCoilDurabilityCalc()
	{
		float num = this.durability * 0.34f;
		float num2 = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime = this.ignitionTimer * 10f;
			this.Condition = 0f;
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition <= num)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime = this.ignitionTimer * 5f;
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > num && this.Condition < num2)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime = this.ignitionTimer * 2.5f;
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else
		{
			this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime = this.ignitionTimer;
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00028864 File Offset: 0x00026C64
	public void BatteryDurabilityCalc()
	{
		float num = this.durability * 0.34f;
		float num2 = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0)
		{
			this.Condition = 0f;
			if (this.carLogic.GetComponent<ExtraUpgradesC>().batteryConditionUIState != 2 && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BatteryConditionRedUI2();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition <= num)
		{
			if (this.carLogic.GetComponent<ExtraUpgradesC>().batteryConditionUIState != 1 && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BatteryConditionOrangeUI();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > num && this.Condition < num2)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else
		{
			if (this.carLogic.GetComponent<ExtraUpgradesC>().batteryConditionUIState != 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BatteryConditionGreenUI();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		float num3 = this.charge * 0.34f;
		if ((double)this.charge <= 0.0)
		{
			this.charge = 0f;
			if (this.carLogic.GetComponent<ExtraUpgradesC>().chargeUIState != 2 && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().OutOfChargeUI2();
			}
			else if (base.GetComponent<ExtraUpgradesC>().chargeUIState != 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().OutOfChargeUI();
			}
		}
		else if (this.charge <= num3)
		{
			if (this.carLogic.GetComponent<ExtraUpgradesC>().chargeUIState != 1 && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BatteryConditionOrangeUI();
			}
		}
		else if (this.carLogic.GetComponent<ExtraUpgradesC>().chargeUIState != 0)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().BatteryConditionGreenUI();
		}
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00028AEC File Offset: 0x00026EEC
	public void FuelTankDurabilityCalc()
	{
		float num = this.durability * 0.34f;
		float num2 = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0)
		{
			this.Condition = 0f;
			this.fuelLeakParticles.SetActive(true);
			if (!this.isLeakingFuel)
			{
				base.InvokeRepeating("LeakFuel", 0f, 1f);
			}
			if (base.GetComponent<ObjectPickupC>().isInEngine && this.carLogic.GetComponent<ExtraUpgradesC>().fuelTankConditionUIState != 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().FuelTankConditionRedUI();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition <= num)
		{
			if (base.GetComponent<ObjectPickupC>().isInEngine && this.carLogic.GetComponent<ExtraUpgradesC>().fuelTankConditionUIState != 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().FuelTankConditionOrangeUI();
			}
			this.fuelLeakParticles.SetActive(false);
			base.CancelInvoke("LeakFuel");
			this.isLeakingFuel = false;
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > num && this.Condition < num2)
		{
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else
		{
			this.fuelLeakParticles.SetActive(false);
			base.CancelInvoke("LeakFuel");
			this.isLeakingFuel = false;
			if (base.GetComponent<ObjectPickupC>().isInEngine && this.carLogic.GetComponent<ExtraUpgradesC>().fuelTankConditionUIState != 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().FuelTankConditionGreenUI();
			}
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00028CDC File Offset: 0x000270DC
	private void LeakFuel()
	{
		if (this.currentFuelAmount <= 0f)
		{
			this.isLeakingFuel = false;
			this.fuelLeakParticles.SetActive(false);
			base.CancelInvoke("LeakFuel");
			return;
		}
		this.isLeakingFuel = true;
		base.GetComponent<AudioSource>().PlayOneShot(this.fuelLeakAudio, 0.05f);
		this.currentFuelAmount -= 0.001f * Time.deltaTime;
	}

	// Token: 0x06000304 RID: 772 RVA: 0x00028D50 File Offset: 0x00027150
	public void CarburettorDurabilityLossCalc(GameObject carLogic)
	{
		float num = 0.0001f;
		float num2 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * num;
		if ((double)this.Condition < 0.0)
		{
			this.Condition = 0f;
		}
		if ((double)this.Condition > 0.0)
		{
			if (num2 > 0f)
			{
				this.Condition -= num2 * Time.deltaTime;
			}
			else if (num2 < 0f)
			{
				this.Condition += num2 * Time.deltaTime;
			}
		}
		this.lowCondition = this.durability * 0.34f;
		this.medCondition = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0 && !this.hasHitBrokenCondition)
		{
			this.hasHitBrokenCondition = true;
			this.hasHitLowCondition = false;
			this.hasHitMedCondition = false;
			this.Condition = 0f;
			carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition <= this.lowCondition && !this.hasHitLowCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitLowCondition = true;
			this.hasHitMedCondition = false;
			carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > this.lowCondition && this.Condition < this.medCondition && !this.hasHitMedCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitLowCondition = false;
			this.hasHitMedCondition = true;
			carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > this.medCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitLowCondition = false;
			this.hasHitMedCondition = false;
			carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00028FA4 File Offset: 0x000273A4
	public void AirFilterDurabilityLossCalc(GameObject carLogic)
	{
		float num = 0.0001f;
		float num2 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * num;
		if ((double)this.Condition < 0.0)
		{
			this.Condition = 0f;
		}
		if ((double)this.Condition > 0.0)
		{
			if (num2 > 0f)
			{
				this.Condition -= num2 * Time.deltaTime;
			}
			else if (num2 < 0f)
			{
				this.Condition += num2 * Time.deltaTime;
			}
		}
		this.lowCondition = this.durability * 0.34f;
		this.medCondition = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0 && !this.hasHitBrokenCondition)
		{
			this.hasHitBrokenCondition = true;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = false;
			this.Condition = 0f;
			carLogic.GetComponent<CarPerformanceC>().UpdateAirFilter();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition < this.lowCondition && !this.hasHitLowCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitLowCondition = true;
			this.hasHitMedCondition = false;
			carLogic.GetComponent<CarPerformanceC>().UpdateAirFilter();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > this.lowCondition && this.Condition < this.medCondition && !this.hasHitMedCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = true;
			this.hasHitLowCondition = false;
			carLogic.GetComponent<CarPerformanceC>().UpdateAirFilter();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > this.medCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = false;
			carLogic.GetComponent<CarPerformanceC>().UpdateAirFilter();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x000291F8 File Offset: 0x000275F8
	public void EngineDurabilityLossCalc(GameObject carLogic)
	{
		float num = 0.0001f;
		if (this.engineWearRate != 0f)
		{
			float num2 = num * this.engineWearRate;
			num -= num2;
		}
		float num3 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * num;
		if ((double)this.Condition < 0.0)
		{
			this.Condition = 0f;
		}
		if ((double)this.Condition > 0.0)
		{
			if (num3 > 0f)
			{
				this.Condition -= num3 * Time.deltaTime;
			}
			else if (num3 < 0f)
			{
				this.Condition += num3 * Time.deltaTime;
			}
		}
		this.lowCondition = this.durability * 0.34f;
		this.medCondition = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0 && !this.hasHitBrokenCondition)
		{
			Debug.Log("Engine Component Has hit broken conditions");
			this.hasHitBrokenCondition = true;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = false;
			this.Condition = 0f;
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition < this.lowCondition && (double)this.Condition > 0.0 && !this.hasHitLowCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = true;
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > this.lowCondition && this.Condition < this.medCondition && !this.hasHitMedCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = true;
			this.hasHitLowCondition = false;
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > this.medCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = false;
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
			carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x000294B4 File Offset: 0x000278B4
	public void TyreRepairKitActions()
	{
		this.hasHitBrokenCondition = false;
		this.hasHitMedCondition = false;
		this.hasHitLowCondition = true;
		this.Condition = 1f;
		this.UpdateCondition();
		this.rubberMesh.GetComponent<MeshFilter>().mesh = this.rubberLibrary[0];
		this.dirtTarget.GetComponent<MeshFilter>().mesh = this.dirtLibrary[0];
		base.GetComponent<ObjectPickupC>().SetPriceTag();
		this.tyrePopCondition = UnityEngine.Random.Range(0f, 0.5f);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x00029538 File Offset: 0x00027938
	private void TyreDurabilityLossCalc(GameObject carLogic)
	{
		float num = Time.deltaTime / 2.5f;
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		int num2 = this.wheelInstallID - 1;
		if (this.compoundType == 1)
		{
			num *= 1.25f;
		}
		else if (this.compoundType == 2)
		{
			num *= 0.75f;
		}
		else if (this.compoundType == 3)
		{
			num *= 0.5f;
		}
		if (!carLogic.GetComponent<CarLogicC>().ridingThroughDirt && !carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
		{
			if (this.tyreType == 0)
			{
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2 || this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					if (num2 == 0 || num2 == 1)
					{
						carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.wetGrip;
					}
					else if (num2 == 2 || num2 == 3)
					{
						carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.wetGrip / 3f;
					}
				}
				else if (num2 == 0 || num2 == 1)
				{
					carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.roadGrip;
				}
				else if (num2 == 2 || num2 == 3)
				{
					carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.roadGrip / 3f;
				}
				float num3 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * 0.0001f;
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
				{
					num *= 0.75f;
					this.Condition -= num3 * num;
				}
				else if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					num *= 0.5f;
					this.Condition -= num3 * num;
				}
				else
				{
					this.Condition -= num3 * num;
				}
			}
			else if (this.tyreType == 1)
			{
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2 || this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					if (num2 == 0 || num2 == 1)
					{
						carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.wetGrip;
					}
					else if (num2 == 2 || num2 == 3)
					{
						carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.wetGrip / 3f;
					}
				}
				else if (num2 == 0 || num2 == 1)
				{
					carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.roadGrip;
				}
				else if (num2 == 2 || num2 == 3)
				{
					carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.roadGrip / 3f;
				}
				float num4 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * 0.0002f;
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
				{
					num *= 0.75f;
					this.Condition -= num4 * num;
				}
				else if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					num *= 0.5f;
					this.Condition -= num4 * num;
				}
				else
				{
					this.Condition -= num4 * num;
				}
			}
			else if (this.tyreType == 2)
			{
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2 || this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					if (num2 == 0 || num2 == 1)
					{
						carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.wetGrip;
					}
					else if (num2 == 2 || num2 == 3)
					{
						carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.wetGrip / 3f;
					}
				}
				else if (num2 == 0 || num2 == 1)
				{
					carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.roadGrip;
				}
				else if (num2 == 2 || num2 == 3)
				{
					carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.roadGrip / 3f;
				}
				float num5 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * 0.0001f;
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
				{
					this.Condition -= num5 * num;
				}
				else if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					this.Condition -= num5 * num;
				}
				else
				{
					num *= 1.5f;
					this.Condition -= num5 * num;
				}
			}
		}
		else if (carLogic.GetComponent<CarLogicC>().ridingThroughDirt || carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
		{
			if (num2 == 0 || num2 == 1)
			{
				carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.offRoadGrip;
			}
			else if (num2 == 2 || num2 == 3)
			{
				carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = this.offRoadGrip / 3f;
			}
			if (this.tyreType == 0)
			{
				float num6 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * 0.0002f;
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
				{
					this.Condition -= num6 * num;
				}
				else if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					this.Condition -= num6 * num;
				}
				else
				{
					num *= 1.25f;
					this.Condition -= num6 * num;
				}
			}
			else if (this.tyreType == 1)
			{
				float num7 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * 0.0001f;
				this.Condition -= num7 * num;
			}
			else if (this.tyreType == 2)
			{
				float num8 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * 0.0001f;
				if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
				{
					this.Condition -= num8 * num;
				}
				else if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
				{
					this.Condition -= num8 * num;
				}
				else
				{
					num *= 1.25f;
					float num9 = carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().currentSpeed * 0.0001f;
					this.Condition -= num9 * num;
				}
			}
		}
		this.lowCondition = this.durability * 0.34f;
		this.medCondition = this.durability * 0.67f;
		if ((double)this.Condition <= 0.0 && !this.hasHitBrokenCondition)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.blowOutAudio, 1f);
			this.rubberMesh.GetComponent<MeshFilter>().mesh = this.rubberLibrary[1];
			this.dirtTarget.GetComponent<MeshFilter>().mesh = this.dirtLibrary[1];
			this.hasHitBrokenCondition = true;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = false;
			this.Condition = 0f;
			this.UpdateCondition();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
			this.tyrePopCondition = 0f;
		}
		else if (this.Condition <= this.tyrePopCondition && !this.hasHitBrokenCondition)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.blowOutAudio, 1f);
			this.rubberMesh.GetComponent<MeshFilter>().mesh = this.rubberLibrary[1];
			this.dirtTarget.GetComponent<MeshFilter>().mesh = this.dirtLibrary[1];
			this.director.GetComponent<DirectorC>().tyrePoppedStats++;
			this.hasHitBrokenCondition = true;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = false;
			this.Condition = 0f;
			this.UpdateCondition();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
			this.tyrePopCondition = 0f;
		}
		else if (this.Condition < this.lowCondition && !this.hasHitLowCondition && (double)this.Condition > 0.0)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = true;
			this.UpdateCondition();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
			this.tyrePopCondition = UnityEngine.Random.Range(0f, 0.5f);
		}
		else if (this.Condition > this.lowCondition && this.Condition < this.medCondition && !this.hasHitMedCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = true;
			this.hasHitLowCondition = false;
			this.UpdateCondition();
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		else if (this.Condition > this.medCondition)
		{
			this.hasHitBrokenCondition = false;
			this.hasHitMedCondition = false;
			this.hasHitLowCondition = false;
			if (base.GetComponent<ObjectPickupC>())
			{
				base.GetComponent<ObjectPickupC>().SetPriceTag();
			}
		}
		if ((double)carLogic.transform.root.GetComponent<CarControleScriptC>().currentSpeed < 30.0 && (double)carLogic.transform.root.GetComponent<CarControleScriptC>().currentSpeed >= 0.0)
		{
			float num10 = carLogic.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 10f;
			num10 = 300f - num10;
			WheelFrictionCurve wheelFrictionCurve;
			carLogic.GetComponent<CarLogicC>().wheelObjects[num2].GetComponent<WheelCollider>().sidewaysFriction.extremumValue = wheelFrictionCurve.extremumValue + num10;
		}
		if (this.wheelInstallID == 3 || this.wheelInstallID == 4)
		{
			float num11 = carLogic.GetComponent<CarPerformanceC>().carBootWeight * 1E-06f;
			this.Condition -= num11 * num;
		}
		if ((double)this.Condition < 0.0)
		{
			this.Condition = 0f;
		}
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0002A13C File Offset: 0x0002853C
	public void UpdateCondition()
	{
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		this.lowCondition = this.durability * 0.34f;
		this.medCondition = this.durability * 0.67f;
		if (this.roadGrip != 0f && this.bolt != null && this.bolt.GetComponent<BoltLogicC>().isFitted)
		{
			this.carLogic.GetComponent<CarPerformanceC>().UpdateGrip(this.wheelInstallID, this.roadGrip, this.Condition, this.durability, base.gameObject, this.wetGrip, this.offRoadGrip);
		}
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0002A200 File Offset: 0x00028600
	public void LoadPoppedTyre()
	{
		if ((double)this.Condition <= 0.0 && this.rubberMesh != null)
		{
			this.rubberMesh.GetComponent<MeshFilter>().mesh = this.rubberLibrary[1];
			this.dirtTarget.GetComponent<MeshFilter>().mesh = this.dirtLibrary[1];
		}
	}

	// Token: 0x0600030B RID: 779 RVA: 0x0002A263 File Offset: 0x00028663
	private void PickUp()
	{
		if (this.bolt != null)
		{
			this.bolt.GetComponent<BoltLogicC>().isFitted = false;
		}
	}

	// Token: 0x0600030C RID: 780 RVA: 0x0002A288 File Offset: 0x00028688
	private void ThrowLogic()
	{
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		this.carLogic.GetComponent<CarPerformanceC>().GhostStop();
		if (base.GetComponent<ObjectPickupC>().previousParent != null)
		{
			base.GetComponent<ObjectPickupC>().previousParent.GetComponent<HoldingLogicC>().ScrapyardGhostStop();
		}
	}

	// Token: 0x0600030D RID: 781 RVA: 0x0002A2F4 File Offset: 0x000286F4
	public void UnsecuredWheel()
	{
		iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, 0f, 0.03f),
			"islocal",
			true,
			"time",
			0.3f,
			"easetype",
			"easeinquint"
		}));
		this.bolt.GetComponent<BoltLogicC>().isFitted = true;
	}

	// Token: 0x0600030E RID: 782 RVA: 0x0002A384 File Offset: 0x00028784
	private void UpdateHands()
	{
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		if (base.GetComponent<EngineComponentC>())
		{
			if (this.carLogic == null)
			{
				this.carLogic = GameObject.FindWithTag("CarLogic");
			}
			this.carLogic.GetComponent<CarPerformanceC>().GhostStop();
			if (DragRigidbodyC.Global.isHolding1 != null)
			{
				if (this.totalFuelAmount > 0f && DragRigidbodyC.Global.isHolding1.name == "FuelTank")
				{
					this.carLogic.GetComponent<CarPerformanceC>().GhostFuelTankGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (this.isBattery && DragRigidbodyC.Global.isHolding1.name == "Battery")
				{
					this.carLogic.GetComponent<CarPerformanceC>().GhostBatteryGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (this.totalWaterCharges != 0 && DragRigidbodyC.Global.isHolding1.name == "WaterContainer")
				{
					this.carLogic.GetComponent<CarPerformanceC>().GhostWaterTankGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (this.acceleration != 0f && DragRigidbodyC.Global.isHolding1.name == "EngineBlock")
				{
					this.carLogic.GetComponent<CarPerformanceC>().GhostEngineBlockGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (this.ignitionTimer != 0f && DragRigidbodyC.Global.isHolding1.name == "IgnitionCoil")
				{
					this.carLogic.GetComponent<CarPerformanceC>().GhostIgnitionCoilGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (this.fuelConsumptionRate != 0f && DragRigidbodyC.Global.isHolding1.name == "Carburettor")
				{
					this.carLogic.GetComponent<CarPerformanceC>().GhostCarburettorGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (this.engineWearRate != 0f && DragRigidbodyC.Global.isHolding1.name == "AirFilter")
				{
					this.carLogic.GetComponent<CarPerformanceC>().GhostAirFilterGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
			}
		}
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0002A654 File Offset: 0x00028A54
	public void SendStatsToCarPerf()
	{
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		this.carLogic.GetComponent<CarPerformanceC>().GhostStop();
		if (DragRigidbodyC.Global != null)
		{
			DragRigidbodyC.Global.GhostEngineHolding1();
		}
		if (this.isTutorialObj)
		{
			if (this.ignitionTimer != 0f)
			{
				this.uncle.SendMessage("IgnitionCoilTutorialFitted");
			}
			if (this.acceleration != 0f)
			{
				this.uncle.SendMessage("EngineBlockTutorialFitted");
			}
			if (this.fuelConsumptionRate != 0f)
			{
				this.uncle.SendMessage("CarburettorTutorialFitted");
			}
			if (this.totalFuelAmount != 0f)
			{
				this.uncle.SendMessage("FuelTankTutorialFitted");
			}
			if (this.engineWearRate != 0f)
			{
				this.uncle.SendMessage("AirFilterTutorialFitted");
			}
			if (this.isBattery)
			{
				this.uncle.SendMessage("BatteryTutorialFitted");
			}
			if (this.totalWaterCharges != 0)
			{
				this.uncle.SendMessage("WaterTankTutorialFitted");
			}
		}
		if (this.ignitionTimer != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime += this.ignitionTimer;
		}
		if (this.initialFuelConsumptionAmount != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().ignitionCoilLoadID = this.loadID;
			this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount += this.initialFuelConsumptionAmount;
			this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition += this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability += this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil = base.gameObject;
			this.carLogic.GetComponent<CarPerformanceC>().UpdateIgnitionCoil();
		}
		if (this.acceleration != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carAcceleration = this.acceleration;
			this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
			this.carLogic.GetComponent<CarPerformanceC>().engineLoadID = this.loadID;
			this.carLogic.GetComponent<CarLogicC>().engineObject.GetComponent<AudioSource>().clip = this.engineAudio;
			base.transform.root.GetComponent<CarControleScriptC>().enginePitchDmg0 = this.engineAudioPitch;
		}
		if (this.TopSpeed != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed += this.TopSpeed;
			this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition += this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability += this.durability;
			float num = this.TopSpeed / 2f;
			this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine = base.gameObject;
			this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
			this.EngineBlockDurabilityCalc();
		}
		if (this.fuelConsumptionRate != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carburettorLoadID = this.loadID;
			this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate += this.fuelConsumptionRate;
			this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition += this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability += this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor = base.gameObject;
			this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
			this.CarburettorDurabilityCalc();
		}
		if (this.totalFuelAmount != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().fuelTankLoadID = this.loadID;
			this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank = base.gameObject;
			this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition += this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability += this.durability;
			this.FuelTankDurabilityCalc();
			this.carLogic.GetComponent<CarPerformanceC>().FuelTankAdded();
		}
		if (this.engineWearRate != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().airFilterLoadID = this.loadID;
			this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate += this.engineWearRate;
			this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition += this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability += this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter = base.gameObject;
			this.AirFilterDurabilityCalc();
		}
		if (this.isBattery)
		{
			this.carLogic.GetComponent<CarPerformanceC>().batteryLoadID = this.loadID;
			this.carLogic.GetComponent<CarPerformanceC>().installedBattery = base.gameObject;
			this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition += this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability += this.durability;
			this.BatteryDurabilityCalc();
		}
		if (this.totalWaterCharges != 0)
		{
			this.carLogic.GetComponent<CarPerformanceC>().waterTankLoadID = this.loadID;
			this.carLogic.GetComponent<CarPerformanceC>().waterTankObj = base.gameObject;
			this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight += this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition += this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability += this.durability;
			this.carLogic.GetComponent<CarLogicC>().bonnetObj.GetComponent<BonnetLogicC>().waterLid = this.waterTankLid;
			this.WaterTankDurabilityCalc();
			if (this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.lowCondition = this.durability * 0.34f;
				this.medCondition = this.durability * 0.67f;
				if (this.Condition > this.lowCondition)
				{
					this.carLogic.GetComponent<ExtraUpgradesC>().WaterTankConditionGreenUI();
				}
				else if (this.Condition < this.lowCondition && (double)this.Condition > 0.0)
				{
					this.carLogic.GetComponent<ExtraUpgradesC>().WaterTankConditionOrangeUI();
				}
				else if ((double)this.Condition == 0.0)
				{
					this.carLogic.GetComponent<ExtraUpgradesC>().WaterTankConditionRedUI();
				}
			}
		}
		if (this.roadGrip != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carOnRoadGrip += this.roadGrip;
			this.carLogic.GetComponent<CarPerformanceC>().carWetGrip += this.wetGrip;
			this.carLogic.GetComponent<CarPerformanceC>().carOffRoadGrip += this.offRoadGrip;
			this.carLogic.GetComponent<CarPerformanceC>().UpdateGrip(this.wheelInstallID, this.roadGrip, this.Condition, this.durability, base.gameObject, this.wetGrip, this.offRoadGrip);
			if (this.isTutorialObj)
			{
				if (this.uncle != null)
				{
					this.uncle.SendMessage("TyreFittedTutorial", SendMessageOptions.RequireReceiver);
				}
				this.isTutorialObj = false;
			}
		}
		this.carLogic.GetComponent<CarLogicC>().CarDamageUp();
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0002AFB0 File Offset: 0x000293B0
	public void RemoveStatsFromCarPerf()
	{
		if (this.ignitionTimer != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime = 0f;
			this.carLogic.GetComponent<CarPerformanceC>().ignitionCoilLoadID = 0;
		}
		if (this.initialFuelConsumptionAmount != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount = 0f;
			this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability -= this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil = null;
			if (this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().IgnitionCoilConditionRemovedUI();
			}
		}
		if (this.acceleration != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carAcceleration = 0f;
			this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().maxTorque = 0f;
			this.carLogic.GetComponent<CarPerformanceC>().engineLoadID = 0;
		}
		if (this.TopSpeed != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed -= this.TopSpeed;
			this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability -= this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().EngineRemoved();
			this.carLogic.transform.parent.transform.parent.GetComponent<CarControleScriptC>().TopSpeed = 0f;
			this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine = null;
		}
		if (this.fuelConsumptionRate != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate = 0f;
			this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability -= this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor = null;
			this.carLogic.GetComponent<CarPerformanceC>().CarburettorRemoved();
			this.carLogic.GetComponent<CarPerformanceC>().carburettorLoadID = 0;
		}
		if (this.totalFuelAmount != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank = null;
			this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability -= this.durability;
			this.FuelTankDurabilityCalc();
			this.carLogic.GetComponent<CarPerformanceC>().FuelTankRemoved();
			this.carLogic.GetComponent<CarPerformanceC>().fuelTankLoadID = 0;
		}
		if (this.engineWearRate != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate -= this.engineWearRate;
			this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability -= this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter = null;
			this.carLogic.GetComponent<CarPerformanceC>().airFilterLoadID = 0;
			if (this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().AirFilterMissingUI();
			}
		}
		if (this.isBattery)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedBattery = null;
			this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability -= this.durability;
			this.carLogic.GetComponent<CarPerformanceC>().batteryLoadID = 0;
			this.carLogic.GetComponent<CarLogicC>().ElectricsOff();
		}
		if (this.totalWaterCharges != 0)
		{
			this.carLogic.GetComponent<CarPerformanceC>().waterTankObj = null;
			this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().totalCarWeight -= this.weight;
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= this.Condition;
			this.carLogic.GetComponent<CarPerformanceC>().carDurability -= this.durability;
			this.WaterTankDurabilityCalc();
			this.carLogic.GetComponent<CarPerformanceC>().waterTankLoadID = 0;
			if (this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled && this.carLogic.GetComponent<CarLogicC>().engineOn)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().WaterTankMissingUI();
			}
		}
		if (this.roadGrip != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().carOnRoadGrip -= this.roadGrip;
			this.carLogic.GetComponent<CarPerformanceC>().carWetGrip -= this.wetGrip;
			this.carLogic.GetComponent<CarPerformanceC>().carOffRoadGrip -= this.offRoadGrip;
		}
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0002B69E File Offset: 0x00029A9E
	private void RaycastEnter()
	{
		if (this.bolt != null)
		{
		}
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0002B6B1 File Offset: 0x00029AB1
	private void RaycastExit()
	{
		if (this.bolt != null)
		{
		}
	}

	// Token: 0x04000458 RID: 1112
	public GameObject director;

	// Token: 0x04000459 RID: 1113
	public bool puristCheck;

	// Token: 0x0400045A RID: 1114
	public GameObject _camera;

	// Token: 0x0400045B RID: 1115
	public string componentHeader = string.Empty;

	// Token: 0x0400045C RID: 1116
	public int sellValue;

	// Token: 0x0400045D RID: 1117
	public string flavourText = string.Empty;

	// Token: 0x0400045E RID: 1118
	public string flavourTextDetailed = string.Empty;

	// Token: 0x0400045F RID: 1119
	public string uniqueProperty = string.Empty;

	// Token: 0x04000460 RID: 1120
	public int loadID;

	// Token: 0x04000461 RID: 1121
	public GameObject uncle;

	// Token: 0x04000462 RID: 1122
	public float weight;

	// Token: 0x04000463 RID: 1123
	public float durability;

	// Token: 0x04000464 RID: 1124
	public float condition;

	// Token: 0x04000465 RID: 1125
	public float totalFuelAmount;

	// Token: 0x04000466 RID: 1126
	public float currentFuelAmount;

	// Token: 0x04000467 RID: 1127
	public int fuelMix;

	// Token: 0x04000468 RID: 1128
	public int fuelTillOilDown = 3;

	// Token: 0x04000469 RID: 1129
	public float fuelConsumptionRate;

	// Token: 0x0400046A RID: 1130
	public float initialFuelConsumptionAmount;

	// Token: 0x0400046B RID: 1131
	public GameObject fuelLid;

	// Token: 0x0400046C RID: 1132
	public GameObject fuelLeakParticles;

	// Token: 0x0400046D RID: 1133
	public AudioClip fuelLeakAudio;

	// Token: 0x0400046E RID: 1134
	public Sprite[] fuelSprites;

	// Token: 0x0400046F RID: 1135
	public GameObject fuelSpriteTarget;

	// Token: 0x04000470 RID: 1136
	public float fuelSpriteTimer;

	// Token: 0x04000471 RID: 1137
	private bool isLeakingFuel;

	// Token: 0x04000472 RID: 1138
	public float ignitionTimer;

	// Token: 0x04000473 RID: 1139
	public float charge;

	// Token: 0x04000474 RID: 1140
	public bool isBattery;

	// Token: 0x04000475 RID: 1141
	public bool batteryDepleted;

	// Token: 0x04000476 RID: 1142
	public float acceleration;

	// Token: 0x04000477 RID: 1143
	public float topSpeed;

	// Token: 0x04000478 RID: 1144
	public float turnRate;

	// Token: 0x04000479 RID: 1145
	public AudioClip engineAudio;

	// Token: 0x0400047A RID: 1146
	public float engineAudioPitch = 1f;

	// Token: 0x0400047B RID: 1147
	public float dirtAccumilation;

	// Token: 0x0400047C RID: 1148
	public int totalWaterCharges;

	// Token: 0x0400047D RID: 1149
	public int currentWaterCharges;

	// Token: 0x0400047E RID: 1150
	public GameObject waterLeakParticles;

	// Token: 0x0400047F RID: 1151
	public GameObject waterTankLid;

	// Token: 0x04000480 RID: 1152
	private bool isLeakingWater;

	// Token: 0x04000481 RID: 1153
	public float waterLeakCount;

	// Token: 0x04000482 RID: 1154
	public float storage;

	// Token: 0x04000483 RID: 1155
	public float damageResistance;

	// Token: 0x04000484 RID: 1156
	public float engineWearRate;

	// Token: 0x04000485 RID: 1157
	private float lowCondition;

	// Token: 0x04000486 RID: 1158
	private float medCondition;

	// Token: 0x04000487 RID: 1159
	private float tyrePopCondition;

	// Token: 0x04000488 RID: 1160
	public GameObject bolt;

	// Token: 0x04000489 RID: 1161
	public int wheelInstallID;

	// Token: 0x0400048A RID: 1162
	public float roadGrip;

	// Token: 0x0400048B RID: 1163
	public float wetGrip;

	// Token: 0x0400048C RID: 1164
	public float offRoadGrip;

	// Token: 0x0400048D RID: 1165
	public int tyreType;

	// Token: 0x0400048E RID: 1166
	public int compoundType;

	// Token: 0x0400048F RID: 1167
	public AudioClip blowOutAudio;

	// Token: 0x04000490 RID: 1168
	public GameObject wheelDirtTarget;

	// Token: 0x04000491 RID: 1169
	public GameObject rubberMesh;

	// Token: 0x04000492 RID: 1170
	public Mesh[] rubberLibrary;

	// Token: 0x04000493 RID: 1171
	public GameObject compoundTarget;

	// Token: 0x04000494 RID: 1172
	public GameObject dirtTarget;

	// Token: 0x04000495 RID: 1173
	public Mesh[] dirtLibrary;

	// Token: 0x04000496 RID: 1174
	public GameObject carLogic;

	// Token: 0x04000497 RID: 1175
	private bool hasHitMedCondition;

	// Token: 0x04000498 RID: 1176
	private bool hasHitLowCondition;

	// Token: 0x04000499 RID: 1177
	public bool hasHitBrokenCondition;

	// Token: 0x0400049A RID: 1178
	public Sprite[] sprites;

	// Token: 0x0400049B RID: 1179
	public GameObject spriteTarget;

	// Token: 0x0400049C RID: 1180
	private float spriteTimer;

	// Token: 0x0400049D RID: 1181
	public float spriteTimerCheck = 0.15f;

	// Token: 0x0400049E RID: 1182
	public bool isTutorialObj;
}
