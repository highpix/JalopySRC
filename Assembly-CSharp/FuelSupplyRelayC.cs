using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class FuelSupplyRelayC : MonoBehaviour
{
	// Token: 0x0600066C RID: 1644 RVA: 0x00082448 File Offset: 0x00080848
	private void LateStart()
	{
		if (base.GetComponent<SphereCollider>())
		{
			UnityEngine.Object.Destroy(base.GetComponent<SphereCollider>());
		}
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.startMaterial = this.fuelLid.GetComponent<Renderer>().material;
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x00082496 File Offset: 0x00080896
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		base.Invoke("LateStart", 0.1f);
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x000824B8 File Offset: 0x000808B8
	private void Reset()
	{
		FuelSupplyRelay component = base.GetComponent<FuelSupplyRelay>();
		this.fuelLid = component.fuelLid;
		this.glowMaterial = component.glowMaterial;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x000824EC File Offset: 0x000808EC
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.fuelLid.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x00082538 File Offset: 0x00080938
	public void PortableFuelActionNoOil()
	{
		base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount += 1f;
		if (base.transform.parent.GetComponent<EngineComponentC>().fuelMix > 0)
		{
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown > 0)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown--;
			}
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown <= 0 && base.transform.parent.GetComponent<EngineComponentC>().fuelMix > 0)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelMix--;
				this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
				if (base.transform.parent.GetComponent<ObjectPickupC>().isInEngine)
				{
					this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
				}
			}
		}
		if (base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount > base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount)
		{
			base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount = base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount;
		}
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x000826D8 File Offset: 0x00080AD8
	public void PortableFuelActionLeanOil()
	{
		base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount += 1f;
		if (base.transform.parent.GetComponent<EngineComponentC>().fuelMix > 1)
		{
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown > 0)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown--;
			}
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown <= 0 && base.transform.parent.GetComponent<EngineComponentC>().fuelMix > 1)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelMix--;
				this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
				if (base.transform.parent.GetComponent<ObjectPickupC>().isInEngine)
				{
					this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
				}
			}
		}
		else if (base.transform.parent.GetComponent<EngineComponentC>().fuelMix < 1)
		{
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown <= 3)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown++;
			}
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown >= 3 && base.transform.parent.GetComponent<EngineComponentC>().fuelMix < 1)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelMix++;
				this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
				if (base.transform.parent.GetComponent<ObjectPickupC>().isInEngine)
				{
					this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
				}
			}
		}
		if (base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount > base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount)
		{
			base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount = base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount;
		}
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x00082990 File Offset: 0x00080D90
	public void PortableFuelActionOptimalOil()
	{
		base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount += 1f;
		if (base.transform.parent.GetComponent<EngineComponentC>().fuelMix > 2)
		{
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown > 0)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown--;
			}
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown <= 0 && base.transform.parent.GetComponent<EngineComponentC>().fuelMix > 2)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelMix--;
				this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
				if (base.transform.parent.GetComponent<ObjectPickupC>().isInEngine)
				{
					this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
				}
			}
		}
		else if (base.transform.parent.GetComponent<EngineComponentC>().fuelMix < 2)
		{
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown <= 3)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown++;
			}
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown >= 3 && base.transform.parent.GetComponent<EngineComponentC>().fuelMix < 2)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelMix++;
				this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
				if (base.transform.parent.GetComponent<ObjectPickupC>().isInEngine)
				{
					this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
				}
			}
		}
		if (base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount > base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount)
		{
			base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount = base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount;
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x00082C48 File Offset: 0x00081048
	public void PortableFuelActionRichOil()
	{
		base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount += 1f;
		if (base.transform.parent.GetComponent<EngineComponentC>().fuelMix < 3)
		{
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown <= 3)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown++;
			}
			if (base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown >= 3 && base.transform.parent.GetComponent<EngineComponentC>().fuelMix < 3)
			{
				base.transform.parent.GetComponent<EngineComponentC>().fuelMix++;
				this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
				base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
				if (base.transform.parent.GetComponent<ObjectPickupC>().isInEngine)
				{
					this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
					this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
				}
			}
		}
		if (base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount > base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount)
		{
			base.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount = base.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount;
		}
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x00082DE8 File Offset: 0x000811E8
	public void LidOpen()
	{
		iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
		{
			"x",
			0.1,
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutexpo"
		}));
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x00082E60 File Offset: 0x00081260
	public void LidClose()
	{
		iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
		{
			"x",
			0,
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeinexpo"
		}));
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00082ED0 File Offset: 0x000812D0
	public void OilAction()
	{
		base.transform.parent.GetComponent<EngineComponentC>().fuelMix++;
		base.transform.parent.GetComponent<EngineComponentC>().fuelTillOilDown = 5;
		this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceAcceleration();
		if (base.transform.parent.GetComponent<ObjectPickupC>().isInEngine)
		{
			this.carLogic.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
		}
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x00082F4C File Offset: 0x0008134C
	public void RaycastEnter()
	{
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		if (isHolding != null && (isHolding.transform.name == "FuelHandle" || isHolding.transform.name == "GasCan" || isHolding.transform.name == "GasCanEmpty"))
		{
			this.isGlowing = true;
			this.fuelLid.GetComponent<Renderer>().material = this.glowMaterial;
		}
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x00082FE4 File Offset: 0x000813E4
	public void RaycastExit()
	{
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		if (isHolding != null && (isHolding.transform.name == "FuelHandle" || isHolding.transform.name == "GasCan" || isHolding.transform.name == "GasCanEmpty"))
		{
			this.isGlowing = false;
			this.fuelLid.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x040008A1 RID: 2209
	private GameObject _camera;

	// Token: 0x040008A2 RID: 2210
	public GameObject carLogic;

	// Token: 0x040008A3 RID: 2211
	public GameObject fuelLid;

	// Token: 0x040008A4 RID: 2212
	private bool isGlowing;

	// Token: 0x040008A5 RID: 2213
	public Material glowMaterial;

	// Token: 0x040008A6 RID: 2214
	public Material startMaterial;
}
