using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000097 RID: 151
public class CarCollisionsC : MonoBehaviour
{
	// Token: 0x060004B5 RID: 1205 RVA: 0x0004F0FD File Offset: 0x0004D4FD
	private void Start()
	{
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x0004F110 File Offset: 0x0004D510
	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Ground") || col.gameObject.layer == LayerMask.NameToLayer("Grass") || col.gameObject.layer == LayerMask.NameToLayer("CarMesh") || col.gameObject.layer == LayerMask.NameToLayer("Untagged") || col.gameObject.layer == LayerMask.NameToLayer("Player") || col.gameObject.layer == LayerMask.NameToLayer("Uncle") || col.gameObject.layer == LayerMask.NameToLayer("TrueObstacle") || col.gameObject.layer == LayerMask.NameToLayer("AIObstacles") || col.gameObject.layer == LayerMask.NameToLayer("AICollider"))
		{
			return;
		}
		if (col.gameObject.tag == "AICar" && col.relativeVelocity.magnitude > (float)this.fineVelocity)
		{
			this.carLogic.GetComponent<CarLogicC>().TrafficLightPenalty();
		}
		if (col.relativeVelocity.magnitude > 20f)
		{
			float num = col.relativeVelocity.magnitude / 25f;
			if (this.carLogic.GetComponent<ExtraUpgradesC>().bullBarInstalled)
			{
				num = col.relativeVelocity.magnitude / 50f;
			}
			this.carLogic.GetComponent<CarPerformanceC>().carCondition -= num;
			this.carLogic.GetComponent<CarLogicC>().CarDamageUp();
			float num2 = UnityEngine.Random.Range(0f, num);
			this.damageShuffle[0] = num2;
			num -= num2;
			float num3 = UnityEngine.Random.Range(0f, num);
			this.damageShuffle[1] = num3;
			num -= num3;
			float num4 = UnityEngine.Random.Range(0f, num);
			this.damageShuffle[2] = num4;
			num -= num4;
			float num5 = UnityEngine.Random.Range(0f, num);
			this.damageShuffle[3] = num5;
			num -= num5;
			float num6 = UnityEngine.Random.Range(0f, num);
			this.damageShuffle[4] = num6;
			num -= num6;
			float num7 = UnityEngine.Random.Range(0f, num);
			this.damageShuffle[5] = num7;
			num -= num7;
			float num8 = UnityEngine.Random.Range(0f, num);
			this.damageShuffle[6] = num8;
			num -= num8;
			for (int i = 0; i < this.damageShuffle.Count; i++)
			{
				float value = this.damageShuffle[i];
				int index = UnityEngine.Random.Range(i, this.damageShuffle.Count);
				this.damageShuffle[i] = this.damageShuffle[index];
				this.damageShuffle[index] = value;
			}
			this.ApplyDamage();
		}
		if (col.gameObject.tag != "Player" && col.contacts.Length > 0)
		{
			ContactPoint contactPoint = col.contacts[0];
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
			Vector3 point = contactPoint.point;
			GameObject obj = UnityEngine.Object.Instantiate<GameObject>(this.crashAudio, point, rotation);
			UnityEngine.Object.Destroy(obj, 2f);
		}
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x0004F494 File Offset: 0x0004D894
	public void ApplyDamage()
	{
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition -= this.damageShuffle[0];
			this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().EngineDurabilityLossCalc(this.carLogic);
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition -= this.damageShuffle[1];
			this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().AirFilterDurabilityLossCalc(this.carLogic);
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition -= this.damageShuffle[2];
			this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().CarburettorDurabilityLossCalc(this.carLogic);
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition -= this.damageShuffle[3];
			this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().FuelTankDurabilityCalc();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition -= this.damageShuffle[4];
			this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().WaterTankDurabilityCalc();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition -= this.damageShuffle[5];
			this.carLogic.GetComponent<CarPerformanceC>().UpdateIgnitionCoil();
		}
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition -= this.damageShuffle[6];
			this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().BatteryDurabilityCalc();
		}
		for (int i = 0; i < this.damageShuffle.Count; i++)
		{
			this.damageShuffle[i] = 0f;
		}
	}

	// Token: 0x040006D3 RID: 1747
	public GameObject carLogic;

	// Token: 0x040006D4 RID: 1748
	public int fineVelocity = 5;

	// Token: 0x040006D5 RID: 1749
	public GameObject crashAudio;

	// Token: 0x040006D6 RID: 1750
	public List<float> damageShuffle = new List<float>();
}
