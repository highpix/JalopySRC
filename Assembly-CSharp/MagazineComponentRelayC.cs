using System;
using TMPro;
using UnityEngine;

// Token: 0x0200003D RID: 61
public class MagazineComponentRelayC : MonoBehaviour
{
	// Token: 0x0600013E RID: 318 RVA: 0x00013BD0 File Offset: 0x00011FD0
	private void Reset()
	{
		MagazineComponentRelay component = base.GetComponent<MagazineComponentRelay>();
		this.componentNumber = component.componentNumber;
		this.sfx = component.sfx;
		component.scale.Copy(ref this.scale);
		this.textHeader = component.textHeader;
		this.textDescription = component.textDescription;
		this.textBullet1 = component.textBullet1;
		this.textBullet2 = component.textBullet2;
		this.textBullet3 = component.textBullet3;
		this.textBullet4 = component.textBullet4;
		this.textBullet5 = component.textBullet5;
		component.otherShits.Copy(ref this.otherShits);
		this.disableTextLocalisationReasons = component.disableTextLocalisationReasons;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00013C84 File Offset: 0x00012084
	private void Start()
	{
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00013C98 File Offset: 0x00012098
	public void Trigger()
	{
		for (int i = 0; i < this.otherShits.Length; i++)
		{
			if (this.otherShits[i] != base.gameObject)
			{
				this.otherShits[i].GetComponent<MagazineComponentRelayC>().isSelected = false;
				this.otherShits[i].GetComponent<MagazineComponentRelayC>().RaycastExit();
			}
		}
		this.textHeader.active = false;
		this.textDescription.active = false;
		this.textBullet1.active = false;
		this.textBullet2.active = false;
		this.textBullet3.active = false;
		this.textBullet4.active = false;
		this.textBullet5.active = false;
		if (this.componentNumber == 1)
		{
			this.IgnitionCoilSelected();
		}
		else if (this.componentNumber == 2)
		{
			this.FuelTankSelected();
		}
		else if (this.componentNumber == 3)
		{
			this.BatterySelected();
		}
		else if (this.componentNumber == 4)
		{
			this.WaterTankSelected();
		}
		else if (this.componentNumber == 5)
		{
			this.EngineSelected();
		}
		else if (this.componentNumber == 6)
		{
			this.CarburettorSelected();
		}
		else if (this.componentNumber == 7)
		{
			this.AirFilterSelected();
		}
		else
		{
			this.isSelected = false;
			this.RaycastExit();
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00013E00 File Offset: 0x00012200
	public void IgnitionCoilSelected()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[2];
		GameObject gameObject = base.transform.parent.transform.parent.gameObject;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			gameObject = base.transform.parent.transform.parent.transform.parent.gameObject;
		}
		gameObject.GetComponent<AudioSource>().PlayOneShot(this.sfx, 0.8f);
		EngineComponentC component = this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>();
		if (this.textHeader.GetComponent<TextMeshPro>())
		{
			this.textHeader.GetComponent<TextMeshPro>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		else if (this.textHeader.GetComponent<TextMesh>())
		{
			this.textHeader.GetComponent<TextMesh>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		if (this.textDescription.GetComponent<TextMeshPro>())
		{
			this.textDescription.GetComponent<TextMeshPro>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMeshPro>().text = this.textDescription.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
		}
		else if (this.textDescription.GetComponent<TextMesh>())
		{
			this.textDescription.GetComponent<TextMesh>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMesh>().text = this.textDescription.GetComponent<TextMesh>().text.Replace("\\n", "\n");
		}
		if (this.textBullet1.GetComponent<TextMeshPro>())
		{
			this.textBullet1.GetComponent<TextMeshPro>().text = component.initialFuelConsumptionAmount.ToString() + Language.Get("ui_pickup_31", "Inspector_UI");
		}
		else if (this.textBullet1.GetComponent<TextMesh>())
		{
			this.textBullet1.GetComponent<TextMesh>().text = component.initialFuelConsumptionAmount.ToString() + Language.Get("ui_pickup_31", "Inspector_UI");
		}
		if (this.textBullet2.GetComponent<TextMeshPro>())
		{
			this.textBullet2.GetComponent<TextMeshPro>().text = component.ignitionTimer.ToString() + Language.Get("ui_pickup_32", "Inspector_UI");
			this.textBullet2.GetComponent<TextMeshPro>().color = Color.black;
		}
		else if (this.textBullet2.GetComponent<TextMesh>())
		{
			this.textBullet2.GetComponent<TextMesh>().text = component.ignitionTimer.ToString() + Language.Get("ui_pickup_32", "Inspector_UI");
			this.textBullet2.GetComponent<TextMesh>().color = Color.black;
		}
		if (this.textBullet3.GetComponent<TextMeshPro>())
		{
			this.textBullet3.GetComponent<TextMeshPro>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
		}
		else if (this.textBullet3.GetComponent<TextMesh>())
		{
			this.textBullet3.GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
		}
		if (this.textBullet4.GetComponent<TextMeshPro>())
		{
			this.textBullet4.GetComponent<TextMeshPro>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		else if (this.textBullet4.GetComponent<TextMesh>())
		{
			this.textBullet4.GetComponent<TextMesh>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		this.textHeader.active = true;
		if (!this.disableTextLocalisationReasons)
		{
			this.textDescription.active = true;
		}
		this.textBullet1.active = true;
		this.textBullet2.active = true;
		this.textBullet3.active = true;
		this.textBullet4.active = true;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00014354 File Offset: 0x00012754
	public void FuelTankSelected()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[2];
		GameObject gameObject = base.transform.parent.transform.parent.gameObject;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			gameObject = base.transform.parent.transform.parent.transform.parent.gameObject;
		}
		gameObject.GetComponent<AudioSource>().PlayOneShot(this.sfx, 0.8f);
		EngineComponentC component = this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>();
		if (this.textHeader.GetComponent<TextMeshPro>())
		{
			this.textHeader.GetComponent<TextMeshPro>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		else if (this.textHeader.GetComponent<TextMesh>())
		{
			this.textHeader.GetComponent<TextMesh>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		if (this.textDescription.GetComponent<TextMeshPro>())
		{
			this.textDescription.GetComponent<TextMeshPro>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMeshPro>().text = this.textDescription.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
		}
		else if (this.textDescription.GetComponent<TextMesh>())
		{
			this.textDescription.GetComponent<TextMesh>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMesh>().text = this.textDescription.GetComponent<TextMesh>().text.Replace("\\n", "\n");
		}
		if (this.textBullet1.GetComponent<TextMeshPro>())
		{
			this.textBullet1.GetComponent<TextMeshPro>().text = Mathf.Round(component.currentFuelAmount).ToString() + " / " + component.totalFuelAmount.ToString() + Language.Get("ui_pickup_22", "Inspector_UI");
		}
		else if (this.textBullet1.GetComponent<TextMesh>())
		{
			this.textBullet1.GetComponent<TextMesh>().text = Mathf.Round(component.currentFuelAmount).ToString() + " / " + component.totalFuelAmount.ToString() + Language.Get("ui_pickup_22", "Inspector_UI");
		}
		if (component.fuelMix == 0)
		{
			if (this.textBullet2.GetComponent<TextMeshPro>())
			{
				this.textBullet2.GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_25", "Inspector_UI");
				this.textBullet2.GetComponent<TextMeshPro>().color = Color.red;
			}
			else if (this.textBullet2.GetComponent<TextMesh>())
			{
				this.textBullet2.GetComponent<TextMesh>().text = Language.Get("ui_pickup_25", "Inspector_UI");
				this.textBullet2.GetComponent<TextMesh>().color = Color.red;
			}
		}
		if (component.fuelMix == 1)
		{
			if (this.textBullet2.GetComponent<TextMeshPro>())
			{
				this.textBullet2.GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_26", "Inspector_UI");
				this.textBullet2.GetComponent<TextMeshPro>().color = Color.yellow;
			}
			else if (this.textBullet2.GetComponent<TextMesh>())
			{
				this.textBullet2.GetComponent<TextMesh>().text = Language.Get("ui_pickup_26", "Inspector_UI");
				this.textBullet2.GetComponent<TextMesh>().color = Color.yellow;
			}
		}
		if (component.fuelMix == 2)
		{
			if (this.textBullet2.GetComponent<TextMeshPro>())
			{
				this.textBullet2.GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_27", "Inspector_UI");
				this.textBullet2.GetComponent<TextMeshPro>().color = Color.green;
			}
			else if (this.textBullet2.GetComponent<TextMesh>())
			{
				this.textBullet2.GetComponent<TextMesh>().text = Language.Get("ui_pickup_27", "Inspector_UI");
				this.textBullet2.GetComponent<TextMesh>().color = Color.green;
			}
		}
		if (component.fuelMix == 3)
		{
			if (this.textBullet2.GetComponent<TextMeshPro>())
			{
				this.textBullet2.GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_28", "Inspector_UI");
				this.textBullet2.GetComponent<TextMeshPro>().color = Color.yellow;
			}
			else if (this.textBullet2.GetComponent<TextMesh>())
			{
				this.textBullet2.GetComponent<TextMesh>().text = Language.Get("ui_pickup_28", "Inspector_UI");
				this.textBullet2.GetComponent<TextMesh>().color = Color.yellow;
			}
		}
		if (this.textBullet3.GetComponent<TextMeshPro>())
		{
			this.textBullet3.GetComponent<TextMeshPro>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
		}
		else if (this.textBullet3.GetComponent<TextMesh>())
		{
			this.textBullet3.GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
		}
		if (this.textBullet4.GetComponent<TextMeshPro>())
		{
			this.textBullet4.GetComponent<TextMeshPro>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		else if (this.textBullet4.GetComponent<TextMesh>())
		{
			this.textBullet4.GetComponent<TextMesh>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		this.textHeader.active = true;
		if (!this.disableTextLocalisationReasons)
		{
			this.textDescription.active = true;
		}
		this.textBullet1.active = true;
		this.textBullet2.active = true;
		this.textBullet3.active = true;
		this.textBullet4.active = true;
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00014ABC File Offset: 0x00012EBC
	public void BatterySelected()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[2];
		GameObject gameObject = base.transform.parent.transform.parent.gameObject;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			gameObject = base.transform.parent.transform.parent.transform.parent.gameObject;
		}
		gameObject.GetComponent<AudioSource>().PlayOneShot(this.sfx, 0.8f);
		EngineComponentC component = this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>();
		if (this.textHeader.GetComponent<TextMeshPro>())
		{
			this.textHeader.GetComponent<TextMeshPro>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		else if (this.textHeader.GetComponent<TextMesh>())
		{
			this.textHeader.GetComponent<TextMesh>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		if (this.textDescription.GetComponent<TextMeshPro>())
		{
			this.textDescription.GetComponent<TextMeshPro>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMeshPro>().text = this.textDescription.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
		}
		else if (this.textDescription.GetComponent<TextMesh>())
		{
			this.textDescription.GetComponent<TextMesh>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMesh>().text = this.textDescription.GetComponent<TextMesh>().text.Replace("\\n", "\n");
		}
		if (this.textBullet1.GetComponent<TextMeshPro>())
		{
			this.textBullet1.GetComponent<TextMeshPro>().text = Mathf.Round(component.charge).ToString() + Language.Get("ui_pickup_48", "Inspector_UI");
		}
		else if (this.textBullet1.GetComponent<TextMesh>())
		{
			this.textBullet1.GetComponent<TextMesh>().text = Mathf.Round(component.charge).ToString() + Language.Get("ui_pickup_48", "Inspector_UI");
		}
		if (this.textBullet2.GetComponent<TextMeshPro>())
		{
			this.textBullet2.GetComponent<TextMeshPro>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMeshPro>().color = Color.black;
		}
		else if (this.textBullet2.GetComponent<TextMesh>())
		{
			this.textBullet2.GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMesh>().color = Color.black;
		}
		if (this.textBullet3.GetComponent<TextMeshPro>())
		{
			this.textBullet3.GetComponent<TextMeshPro>().text = component.weight.ToString() + Language.Get("ui_pickup_21", "Inspector_UI");
		}
		else if (this.textBullet3.GetComponent<TextMesh>())
		{
			this.textBullet3.GetComponent<TextMesh>().text = component.weight.ToString() + Language.Get("ui_pickup_21", "Inspector_UI");
		}
		this.textHeader.active = true;
		if (!this.disableTextLocalisationReasons)
		{
			this.textDescription.active = true;
		}
		this.textBullet1.active = true;
		this.textBullet2.active = true;
		this.textBullet3.active = true;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x00014F7C File Offset: 0x0001337C
	public void WaterTankSelected()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[2];
		GameObject gameObject = base.transform.parent.transform.parent.gameObject;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			gameObject = base.transform.parent.transform.parent.transform.parent.gameObject;
		}
		gameObject.GetComponent<AudioSource>().PlayOneShot(this.sfx, 0.8f);
		EngineComponentC component = this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>();
		if (this.textHeader.GetComponent<TextMeshPro>())
		{
			this.textHeader.GetComponent<TextMeshPro>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		else if (this.textHeader.GetComponent<TextMesh>())
		{
			this.textHeader.GetComponent<TextMesh>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		if (this.textDescription.GetComponent<TextMeshPro>())
		{
			this.textDescription.GetComponent<TextMeshPro>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMeshPro>().text = this.textDescription.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
		}
		else if (this.textDescription.GetComponent<TextMesh>())
		{
			this.textDescription.GetComponent<TextMesh>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMesh>().text = this.textDescription.GetComponent<TextMesh>().text.Replace("\\n", "\n");
		}
		float num = 0.083f * (float)component.currentWaterCharges;
		float num2 = 0.083f * (float)component.totalWaterCharges;
		if (this.textBullet1.GetComponent<TextMeshPro>())
		{
			this.textBullet1.GetComponent<TextMeshPro>().text = Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString() + " / " + Mathf.Abs(Mathf.Round(num2 * 10f) / 10f).ToString() + Language.Get("ui_pickup_42", "Inspector_UI");
		}
		else if (this.textBullet1.GetComponent<TextMesh>())
		{
			this.textBullet1.GetComponent<TextMesh>().text = Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString() + " / " + Mathf.Abs(Mathf.Round(num2 * 10f) / 10f).ToString() + Language.Get("ui_pickup_42", "Inspector_UI");
		}
		if (this.textBullet2.GetComponent<TextMeshPro>())
		{
			this.textBullet2.GetComponent<TextMeshPro>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMeshPro>().color = Color.black;
		}
		else if (this.textBullet2.GetComponent<TextMesh>())
		{
			this.textBullet2.GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMesh>().color = Color.black;
		}
		if (this.textBullet3.GetComponent<TextMeshPro>())
		{
			this.textBullet3.GetComponent<TextMeshPro>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		else if (this.textBullet3.GetComponent<TextMesh>())
		{
			this.textBullet3.GetComponent<TextMesh>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		this.textHeader.active = true;
		if (!this.disableTextLocalisationReasons)
		{
			this.textDescription.active = true;
		}
		this.textBullet1.active = true;
		this.textBullet2.active = true;
		this.textBullet3.active = true;
	}

	// Token: 0x06000145 RID: 325 RVA: 0x000154C8 File Offset: 0x000138C8
	public void EngineSelected()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[2];
		GameObject gameObject = base.transform.parent.transform.parent.gameObject;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			gameObject = base.transform.parent.transform.parent.transform.parent.gameObject;
		}
		gameObject.GetComponent<AudioSource>().PlayOneShot(this.sfx, 0.8f);
		EngineComponentC component = this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>();
		if (this.textHeader.GetComponent<TextMeshPro>())
		{
			this.textHeader.GetComponent<TextMeshPro>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		else if (this.textHeader.GetComponent<TextMesh>())
		{
			this.textHeader.GetComponent<TextMesh>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		if (this.textDescription.GetComponent<TextMeshPro>())
		{
			this.textDescription.GetComponent<TextMeshPro>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMeshPro>().text = this.textDescription.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
		}
		else if (this.textDescription.GetComponent<TextMesh>())
		{
			this.textDescription.GetComponent<TextMesh>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMesh>().text = this.textDescription.GetComponent<TextMesh>().text.Replace("\\n", "\n");
		}
		if (this.textBullet1.GetComponent<TextMeshPro>())
		{
			this.textBullet1.GetComponent<TextMeshPro>().text = component.acceleration.ToString() + Language.Get("ui_pickup_33", "Inspector_UI");
		}
		else if (this.textBullet1.GetComponent<TextMesh>())
		{
			this.textBullet1.GetComponent<TextMesh>().text = component.acceleration.ToString() + Language.Get("ui_pickup_33", "Inspector_UI");
		}
		if (this.textBullet2.GetComponent<TextMeshPro>())
		{
			this.textBullet2.GetComponent<TextMeshPro>().text = component.TopSpeed.ToString() + Language.Get("ui_pickup_34", "Inspector_UI");
			this.textBullet2.GetComponent<TextMeshPro>().color = Color.black;
		}
		else if (this.textBullet2.GetComponent<TextMesh>())
		{
			this.textBullet2.GetComponent<TextMesh>().text = component.TopSpeed.ToString() + Language.Get("ui_pickup_34", "Inspector_UI");
			this.textBullet2.GetComponent<TextMesh>().color = Color.black;
		}
		if (this.textBullet3.GetComponent<TextMeshPro>())
		{
			this.textBullet3.GetComponent<TextMeshPro>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
		}
		else if (this.textBullet3.GetComponent<TextMesh>())
		{
			this.textBullet3.GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
		}
		if (this.textBullet4.GetComponent<TextMeshPro>())
		{
			this.textBullet4.GetComponent<TextMeshPro>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		else if (this.textBullet4.GetComponent<TextMesh>())
		{
			this.textBullet4.GetComponent<TextMesh>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		this.textHeader.active = true;
		if (!this.disableTextLocalisationReasons)
		{
			this.textDescription.active = true;
		}
		this.textBullet1.active = true;
		this.textBullet2.active = true;
		this.textBullet3.active = true;
		this.textBullet4.active = true;
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00015A24 File Offset: 0x00013E24
	public void CarburettorSelected()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[2];
		GameObject gameObject = base.transform.parent.transform.parent.gameObject;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			gameObject = base.transform.parent.transform.parent.transform.parent.gameObject;
		}
		gameObject.GetComponent<AudioSource>().PlayOneShot(this.sfx, 0.8f);
		EngineComponentC component = this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>();
		if (this.textHeader.GetComponent<TextMeshPro>())
		{
			this.textHeader.GetComponent<TextMeshPro>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		else if (this.textHeader.GetComponent<TextMesh>())
		{
			this.textHeader.GetComponent<TextMesh>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		if (this.textDescription.GetComponent<TextMeshPro>())
		{
			this.textDescription.GetComponent<TextMeshPro>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMeshPro>().text = this.textDescription.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
		}
		else if (this.textDescription.GetComponent<TextMesh>())
		{
			this.textDescription.GetComponent<TextMesh>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMesh>().text = this.textDescription.GetComponent<TextMesh>().text.Replace("\\n", "\n");
		}
		if (this.textBullet1.GetComponent<TextMeshPro>())
		{
			this.textBullet1.GetComponent<TextMeshPro>().text = component.fuelConsumptionRate.ToString();
		}
		else if (this.textBullet1.GetComponent<TextMesh>())
		{
			this.textBullet1.GetComponent<TextMesh>().text = component.fuelConsumptionRate.ToString();
		}
		if (this.textBullet2.GetComponent<TextMeshPro>())
		{
			this.textBullet2.GetComponent<TextMeshPro>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMeshPro>().color = Color.black;
		}
		else if (this.textBullet2.GetComponent<TextMesh>())
		{
			this.textBullet2.GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMesh>().color = Color.black;
		}
		if (this.textBullet3.GetComponent<TextMeshPro>())
		{
			this.textBullet3.GetComponent<TextMeshPro>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		else if (this.textBullet3.GetComponent<TextMesh>())
		{
			this.textBullet3.GetComponent<TextMesh>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		this.textHeader.active = true;
		if (!this.disableTextLocalisationReasons)
		{
			this.textDescription.active = true;
		}
		this.textBullet1.active = true;
		this.textBullet2.active = true;
		this.textBullet3.active = true;
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00015EA8 File Offset: 0x000142A8
	public void AirFilterSelected()
	{
		this.isSelected = true;
		base.transform.localScale = this.scale[2];
		GameObject gameObject = base.transform.parent.transform.parent.gameObject;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			gameObject = base.transform.parent.transform.parent.transform.parent.gameObject;
		}
		gameObject.GetComponent<AudioSource>().PlayOneShot(this.sfx, 0.8f);
		EngineComponentC component = this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>();
		if (this.textHeader.GetComponent<TextMeshPro>())
		{
			this.textHeader.GetComponent<TextMeshPro>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		else if (this.textHeader.GetComponent<TextMesh>())
		{
			this.textHeader.GetComponent<TextMesh>().text = Language.Get(component.componentHeader, "Inspector_UI") + ".";
		}
		if (this.textDescription.GetComponent<TextMeshPro>())
		{
			this.textDescription.GetComponent<TextMeshPro>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMeshPro>().text = this.textDescription.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
		}
		else if (this.textDescription.GetComponent<TextMesh>())
		{
			this.textDescription.GetComponent<TextMesh>().text = Language.Get(component.flavourTextDetailed, "Inspector_UI");
			this.textDescription.GetComponent<TextMesh>().text = this.textDescription.GetComponent<TextMesh>().text.Replace("\\n", "\n");
		}
		if (this.textBullet1.GetComponent<TextMeshPro>())
		{
			this.textBullet1.GetComponent<TextMeshPro>().text = Mathf.Abs(component.engineWearRate * 100f).ToString() + Language.Get("ui_pickup_46", "Inspector_UI");
		}
		else if (this.textBullet1.GetComponent<TextMesh>())
		{
			this.textBullet1.GetComponent<TextMesh>().text = Mathf.Abs(component.engineWearRate * 100f).ToString() + Language.Get("ui_pickup_46", "Inspector_UI");
		}
		if (this.textBullet2.GetComponent<TextMeshPro>())
		{
			this.textBullet2.GetComponent<TextMeshPro>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMeshPro>().color = Color.black;
		}
		else if (this.textBullet2.GetComponent<TextMesh>())
		{
			this.textBullet2.GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				Language.Get("ui_pickup_21", "Inspector_UI"),
				" : ",
				Mathf.Round(component.Condition).ToString(),
				"/",
				component.durability.ToString()
			});
			this.textBullet2.GetComponent<TextMesh>().color = Color.black;
		}
		if (this.textBullet3.GetComponent<TextMeshPro>())
		{
			this.textBullet3.GetComponent<TextMeshPro>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		else if (this.textBullet3.GetComponent<TextMesh>())
		{
			this.textBullet3.GetComponent<TextMesh>().text = component.weight.ToString() + Language.Get("ui_pickup_49", "Inspector_UI");
		}
		this.textHeader.active = true;
		if (!this.disableTextLocalisationReasons)
		{
			this.textDescription.active = true;
		}
		this.textBullet1.active = true;
		this.textBullet2.active = true;
		this.textBullet3.active = true;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00016372 File Offset: 0x00014772
	public void RaycastEnter()
	{
		if (!this.isSelected)
		{
			base.transform.localScale = this.scale[1];
		}
	}

	// Token: 0x06000149 RID: 329 RVA: 0x0001639B File Offset: 0x0001479B
	public void RaycastExit()
	{
		if (!this.isSelected)
		{
			base.transform.localScale = this.scale[0];
		}
	}

	// Token: 0x0400025D RID: 605
	private GameObject carLogic;

	// Token: 0x0400025E RID: 606
	public int componentNumber;

	// Token: 0x0400025F RID: 607
	public AudioClip sfx;

	// Token: 0x04000260 RID: 608
	public Vector3[] scale = new Vector3[0];

	// Token: 0x04000261 RID: 609
	public GameObject textHeader;

	// Token: 0x04000262 RID: 610
	public GameObject textDescription;

	// Token: 0x04000263 RID: 611
	public GameObject textBullet1;

	// Token: 0x04000264 RID: 612
	public GameObject textBullet2;

	// Token: 0x04000265 RID: 613
	public GameObject textBullet3;

	// Token: 0x04000266 RID: 614
	public GameObject textBullet4;

	// Token: 0x04000267 RID: 615
	public GameObject textBullet5;

	// Token: 0x04000268 RID: 616
	public GameObject[] otherShits = new GameObject[0];

	// Token: 0x04000269 RID: 617
	public bool disableTextLocalisationReasons;

	// Token: 0x0400026A RID: 618
	private bool isSelected;
}
