using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000083 RID: 131
public class DirectorC : MonoBehaviour
{
	// Token: 0x060002AA RID: 682 RVA: 0x0002581D File Offset: 0x00023C1D
	private void Start()
	{
		this.UpdateDayUIText();
		Time.timeScale = 1f;
		base.Invoke("LateStart", 2.5f);
	}

	// Token: 0x060002AB RID: 683 RVA: 0x0002583F File Offset: 0x00023C3F
	private void LateStart()
	{
		base.GetComponent<RouteGeneratorC>().mapDayText.GetComponent<TextMesh>().text = this.dayUI1.GetComponent<UILabel>().text;
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00025868 File Offset: 0x00023C68
	public void CheckForThereAndBackAchievement()
	{
		if (this.gerStartBedGo && this.turkBedGo && this.gerEndBedGo)
		{
			GameObject gameObject = GameObject.FindWithTag("Steam");
			if (gameObject != null)
			{
				gameObject.SendMessage("ThereAndBack");
			}
		}
	}

	// Token: 0x060002AD RID: 685 RVA: 0x000258B8 File Offset: 0x00023CB8
	public void ResetThereAndBackAchievementProgress()
	{
		this.gerStartBedGo = false;
		this.turkBedGo = false;
		this.gerEndBedGo = false;
	}

	// Token: 0x060002AE RID: 686 RVA: 0x000258D0 File Offset: 0x00023CD0
	public void UpdateDayUIText()
	{
		this.dayUI1.GetComponent<UILabel>().text = Language.Get("ui_daydate_00", "Inspector_UI") + " " + this.daysPassed.ToString();
		base.GetComponent<RouteGeneratorC>().mapDayText.GetComponent<TextMesh>().text = this.dayUI1.GetComponent<UILabel>().text;
		if (!base.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (base.GetComponent<RouteGeneratorC>().routeLevel == 0)
			{
				this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_01", "Inspector_UI");
			}
			else if (base.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_02", "Inspector_UI");
			}
			else if (base.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_03", "Inspector_UI");
			}
			else if (base.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_04", "Inspector_UI");
			}
			else if (base.GetComponent<RouteGeneratorC>().routeLevel == 4)
			{
				this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_05", "Inspector_UI");
			}
			else if (base.GetComponent<RouteGeneratorC>().routeLevel == 5)
			{
				this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_06", "Inspector_UI");
			}
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_01", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_00", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_01", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_02", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_03", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_04", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_05", "Inspector_UI");
		}
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00025BF8 File Offset: 0x00023FF8
	public void StartingDayUIText()
	{
		this.dayUI1.GetComponent<UILabel>().text = Language.Get("ui_daydate_00", "Inspector_UI") + " " + this.daysPassed.ToString();
		if (base.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_00", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_01", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_02", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_03", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_04", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_05", "Inspector_UI");
		}
		else if (base.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			this.dayUI2.GetComponent<UILabel>().text = Language.Get("ui_daydetail_06", "Inspector_UI");
		}
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00025DAC File Offset: 0x000241AC
	public void EventLogPurchasedFuel(float fuelUnits, float totalFuelPrice)
	{
		float num = Mathf.Round(this.dayNightCycle.GetComponent<DNC_DayNight>().timeInHours);
		string str = string.Empty;
		if (num <= 12f)
		{
			str = num.ToString() + " AM\n\t";
		}
		else
		{
			str = num.ToString() + " PM\n\t";
		}
		str += Language.Get("log_fuelup_01", "Inspector_UI");
		str += fuelUnits.ToString();
		str += Language.Get("log_fuelup_02", "Inspector_UI");
		str += totalFuelPrice.ToString();
		this.eventLogString = str + "\n" + this.eventLogString;
		this.eventLogString.Replace("\\n", "\n");
		this.eventLogString.Replace("\\t", "\t");
		int length = 0;
		if (this.eventLogString.Length > this.eventCharacterLimit)
		{
			int startIndex = this.eventLogString.Length - this.eventCharacterTracking[this.eventCharacterTracking.Count - 1];
			this.eventLogString.Substring(startIndex, length);
			this.eventCharacterTracking.RemoveAt(this.eventCharacterTracking.Count - 1);
		}
		this.eventCharacterTracking.Add(this.eventLogString.Length);
		this.eventLogTarget.GetComponent<TextMesh>().text = this.eventLogString;
		this.eventLogTarget.SetActive(false);
		this.eventLogPurchasedObj.Clear();
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00025F54 File Offset: 0x00024354
	public void UpdateEventLogLearntBasicRepair()
	{
		float num = Mathf.Round(this.dayNightCycle.GetComponent<DNC_DayNight>().timeInHours);
		string str = string.Empty;
		if (num <= 12f)
		{
			str = num.ToString() + " AM\n\t";
		}
		else
		{
			str = num.ToString() + " PM\n\t";
		}
		str += Language.Get("log_repairtut_01", "Inspector_UI");
		this.eventLogString = str + "\n" + this.eventLogString;
		this.eventLogString.Replace("\\n", "\n");
		this.eventLogString.Replace("\\t", "\t");
		int length = 0;
		if (this.eventLogString.Length > this.eventCharacterLimit)
		{
			int startIndex = this.eventLogString.Length - this.eventCharacterTracking[this.eventCharacterTracking.Count - 1];
			this.eventLogString.Substring(startIndex, length);
			this.eventCharacterTracking.RemoveAt(this.eventCharacterTracking.Count - 1);
		}
		this.eventCharacterTracking.Add(this.eventLogString.Length);
		this.eventLogTarget.GetComponent<TextMesh>().text = this.eventLogString;
		this.eventLogTarget.SetActive(false);
		this.eventLogPurchasedObj.Clear();
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x000260BC File Offset: 0x000244BC
	public void UpdateEventLogPurchased()
	{
		float num = Mathf.Round(this.dayNightCycle.GetComponent<DNC_DayNight>().timeInHours);
		string str = string.Empty;
		if (num <= 12f)
		{
			str = num.ToString() + " AM\n\tPurchased ";
		}
		else
		{
			str = num.ToString() + " PM\n\tPurchased ";
		}
		float num2 = 0f;
		bool flag = false;
		for (int i = 0; i < this.eventLogPurchasedObj.Count; i++)
		{
			num2 += this.eventLogPurchasedObj[i].GetComponent<ObjectPickupC>().buyValue;
		}
		if (flag)
		{
			str += "...";
		}
		str += this.eventLogPurchasedObj.Count.ToString();
		str += " items for a total of ";
		str += num2.ToString();
		this.eventLogString = str + "\n" + this.eventLogString;
		this.eventLogString.Replace("\\n", "\n");
		this.eventLogString.Replace("\\t", "\t");
		if (this.eventLogString.Length > this.eventCharacterLimit && this.eventCharacterTracking[0] != 0)
		{
			int startIndex = this.eventLogString.Length - this.eventCharacterTracking[this.eventCharacterTracking.Count - 1];
			this.eventLogString.Substring(startIndex, Mathf.RoundToInt(num2));
			this.eventCharacterTracking.RemoveAt(this.eventCharacterTracking.Count - 1);
		}
		this.eventCharacterTracking.Add(this.eventLogString.Length);
		this.eventLogTarget.GetComponent<TextMesh>().text = this.eventLogString;
		this.eventLogTarget.SetActive(false);
		this.eventLogPurchasedObj.Clear();
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x000262C0 File Offset: 0x000246C0
	public void UpdateEventLogSold()
	{
		float num = Mathf.Round(this.dayNightCycle.GetComponent<DNC_DayNight>().timeInHours);
		string str = string.Empty;
		if (num <= 12f)
		{
			str = num.ToString() + " AM\n\tSold ";
		}
		else
		{
			str = num.ToString() + " PM\n\tSold ";
		}
		float num2 = 0f;
		bool flag = false;
		for (int i = 0; i < this.eventLogSoldObj.Count; i++)
		{
			num2 += this.eventLogSoldObj[i].GetComponent<ObjectPickupC>().sellValue;
		}
		if (flag)
		{
			str += "...";
		}
		str += this.eventLogSoldObj.Count.ToString();
		str += " items for a total of ";
		str += num2.ToString();
		this.eventLogString = str + "\n" + this.eventLogString;
		this.eventLogString.Replace("\\n", "\n");
		this.eventLogString.Replace("\\t", "\t");
		if (this.eventLogString.Length > this.eventCharacterLimit && this.eventCharacterTracking[0] != 0)
		{
			int startIndex = this.eventLogString.Length - this.eventCharacterTracking[this.eventCharacterTracking.Count - 1];
			this.eventLogString = this.eventLogString.Substring(startIndex);
			this.eventCharacterTracking.RemoveAt(this.eventCharacterTracking.Count - 1);
		}
		this.eventCharacterTracking.Add(this.eventLogString.Length);
		this.eventLogTarget.GetComponent<TextMesh>().text = this.eventLogString;
		this.eventLogTarget.SetActive(false);
		this.eventLogPurchasedObj.Clear();
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x000264C0 File Offset: 0x000248C0
	private float DirtDencity(float dirtIncrease)
	{
		float result = 0f;
		if ((double)dirtIncrease >= 0.97)
		{
			result = 1f;
		}
		else if ((double)dirtIncrease >= 0.94)
		{
			result = 0.97f;
		}
		else if ((double)dirtIncrease >= 0.91)
		{
			result = 0.94f;
		}
		else if ((double)dirtIncrease >= 0.88)
		{
			result = 0.91f;
		}
		else if ((double)dirtIncrease >= 0.85)
		{
			result = 0.88f;
		}
		else if ((double)dirtIncrease >= 0.82)
		{
			result = 0.85f;
		}
		else if ((double)dirtIncrease >= 0.79)
		{
			result = 0.82f;
		}
		else if ((double)dirtIncrease >= 0.76)
		{
			result = 0.79f;
		}
		else if ((double)dirtIncrease >= 0.73)
		{
			result = 0.76f;
		}
		else if ((double)dirtIncrease >= 0.7)
		{
			result = 0.73f;
		}
		else if ((double)dirtIncrease >= 0.67)
		{
			result = 0.7f;
		}
		else if ((double)dirtIncrease >= 0.64)
		{
			result = 0.67f;
		}
		else if ((double)dirtIncrease >= 0.61)
		{
			result = 0.64f;
		}
		else if ((double)dirtIncrease >= 0.58)
		{
			result = 0.61f;
		}
		else if ((double)dirtIncrease >= 0.55)
		{
			result = 0.58f;
		}
		else if ((double)dirtIncrease >= 0.52)
		{
			result = 0.55f;
		}
		else if ((double)dirtIncrease >= 0.49)
		{
			result = 0.52f;
		}
		else if ((double)dirtIncrease >= 0.46)
		{
			result = 0.49f;
		}
		else if ((double)dirtIncrease >= 0.43)
		{
			result = 0.46f;
		}
		else if ((double)dirtIncrease >= 0.0)
		{
			result = 0.43f;
		}
		return result;
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x000266EC File Offset: 0x00024AEC
	private void DirtUp(GameObject whichObject, float changeD)
	{
		float num = 1f - changeD;
		float num2 = 0f * num;
		float dirtIncrease = whichObject.GetComponent<Renderer>().material.color.a + num2;
		if (this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsInstalled)
		{
			num2 /= 2f;
			dirtIncrease = whichObject.GetComponent<Renderer>().material.color.a + num2;
		}
		float num3 = this.DirtDencity(dirtIncrease);
		iTween.FadeTo(whichObject, iTween.Hash(new object[]
		{
			"alpha",
			num3,
			"time",
			0.75,
			"easetype",
			"easeOutQuart"
		}));
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x000267B7 File Offset: 0x00024BB7
	private void WindScreenRimDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().frontWindowDirtRim, 0.43f);
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x000267D4 File Offset: 0x00024BD4
	private void WindScreenWipersDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().frontWindowDirtWipers, 0.43f);
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x000267F1 File Offset: 0x00024BF1
	private void RearWindowDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().rearWindowObject, 0.55f);
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x0002680E File Offset: 0x00024C0E
	private void FrontLeftWindowDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().frontLeftWindowObj, 0.55f);
	}

	// Token: 0x060002BA RID: 698 RVA: 0x0002682B File Offset: 0x00024C2B
	private void FrontRightWindowDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().frontRightWindowObj, 0.55f);
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00026848 File Offset: 0x00024C48
	private void RearLeftWindowDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().rearLeftWindowObj, 0.55f);
	}

	// Token: 0x060002BC RID: 700 RVA: 0x00026865 File Offset: 0x00024C65
	private void RearRightWindowDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().rearRightWindowObj, 0.55f);
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00026882 File Offset: 0x00024C82
	private void FrontLeftWheelDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().FlWheelDirt, 0.55f);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x0002689F File Offset: 0x00024C9F
	private void RearLeftWheelDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().RlWheelDirt, 0.55f);
	}

	// Token: 0x060002BF RID: 703 RVA: 0x000268BC File Offset: 0x00024CBC
	private void RearRightWheelDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().RrWheelDirt, 0.55f);
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x000268D9 File Offset: 0x00024CD9
	private void FrontRightWheelDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().FrWheelDirt, 0.55f);
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x000268F6 File Offset: 0x00024CF6
	private void FrontFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().frntDirtObj, 0.15f);
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x00026913 File Offset: 0x00024D13
	private void FrontLeftFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().frntlsideDirtObj, 0.078f);
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x00026930 File Offset: 0x00024D30
	private void FrontRightFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().frntrsideDirtObj, 0.078f);
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0002694D File Offset: 0x00024D4D
	private void DoorLeftFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj, 0.078f);
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0002696A File Offset: 0x00024D6A
	private void DoorRightFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj, 0.078f);
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x00026987 File Offset: 0x00024D87
	private void RearLeftFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().rearlsideDirtObj, 0.078f);
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x000269A4 File Offset: 0x00024DA4
	private void RearRightFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().rearrsideDirtObj, 0.078f);
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x000269C1 File Offset: 0x00024DC1
	private void RearFrameDirtUp()
	{
		this.DirtUp(this.carLogic.GetComponent<CarLogicC>().rearDirtObj, 0.15f);
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x000269E0 File Offset: 0x00024DE0
	private void DirtDown(GameObject theObject)
	{
		float num = theObject.GetComponent<Renderer>().material.color.a - 0.33f;
		iTween.FadeTo(theObject, iTween.Hash(new object[]
		{
			"alpha",
			num,
			"time",
			0.75,
			"easetype",
			"easeOutQuart"
		}));
	}

	// Token: 0x060002CA RID: 714 RVA: 0x00026A60 File Offset: 0x00024E60
	public void FrontWindowDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frontWindowDirtWipers);
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frontWindowDirtRim);
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frontWindowDirtSmudge);
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00026AAF File Offset: 0x00024EAF
	public void RearWindowDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().rearWindowObject);
	}

	// Token: 0x060002CC RID: 716 RVA: 0x00026AC7 File Offset: 0x00024EC7
	public void LeftFrontWindowDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frontLeftWindowObj);
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00026ADF File Offset: 0x00024EDF
	public void RightFrontWindowDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frontRightWindowObj);
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00026AF7 File Offset: 0x00024EF7
	public void LeftRearWindowDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().rearLeftWindowObj);
	}

	// Token: 0x060002CF RID: 719 RVA: 0x00026B0F File Offset: 0x00024F0F
	public void RightRearWindowDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().rearRightWindowObj);
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x00026B27 File Offset: 0x00024F27
	public void LeftFrontTyreDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().FlWheelDirt);
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x00026B3F File Offset: 0x00024F3F
	public void LeftRearTyreDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().RlWheelDirt);
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x00026B57 File Offset: 0x00024F57
	public void RightRearTyreDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().RrWheelDirt);
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x00026B6F File Offset: 0x00024F6F
	public void RightFrontTyreDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().FrWheelDirt);
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x00026B87 File Offset: 0x00024F87
	public void FrontFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frntDirtObj);
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x00026B9F File Offset: 0x00024F9F
	public void LeftFrontFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frntlsideDirtObj);
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00026BB7 File Offset: 0x00024FB7
	public void RightFrontFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().frntrsideDirtObj);
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00026BD0 File Offset: 0x00024FD0
	public void LeftDoorFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj);
		iTween.FadeTo(this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj2, iTween.Hash(new object[]
		{
			"alpha",
			0f,
			"time",
			0.75,
			"easetype",
			"easeOutQuart"
		}));
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x00026C54 File Offset: 0x00025054
	public void RightDoorFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj);
		iTween.FadeTo(this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj2, iTween.Hash(new object[]
		{
			"alpha",
			0f,
			"time",
			0.75,
			"easetype",
			"easeOutQuart"
		}));
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00026CD5 File Offset: 0x000250D5
	public void LeftRearFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().rearlsideDirtObj);
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00026CED File Offset: 0x000250ED
	public void RightRearFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().rearrsideDirtObj);
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00026D05 File Offset: 0x00025105
	public void RearFrameDirtDown()
	{
		this.DirtDown(this.carLogic.GetComponent<CarLogicC>().rearDirtObj);
	}

	// Token: 0x060002DC RID: 732 RVA: 0x00026D20 File Offset: 0x00025120
	public void FLPuddleSplash()
	{
		this.WindScreenRimDirtUp();
		this.WindScreenWipersDirtUp();
		this.FrontLeftWindowDirtUp();
		this.RearLeftWindowDirtUp();
		this.FrontLeftWheelDirtUp();
		this.FrontFrameDirtUp();
		this.FrontLeftFrameDirtUp();
		this.DoorLeftFrameDirtUp();
		if ((double)this.carLogic.GetComponent<CarLogicC>().rearlsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
		{
			this.RearLeftFrameDirtUp();
		}
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00026D9C File Offset: 0x0002519C
	public void FRPuddleSplash()
	{
		this.WindScreenRimDirtUp();
		this.WindScreenWipersDirtUp();
		this.FrontRightWindowDirtUp();
		this.RearRightWindowDirtUp();
		this.FrontRightWheelDirtUp();
		this.FrontFrameDirtUp();
		this.FrontRightFrameDirtUp();
		this.DoorRightFrameDirtUp();
		if ((double)this.carLogic.GetComponent<CarLogicC>().rearrsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
		{
			this.RearRightFrameDirtUp();
		}
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00026E15 File Offset: 0x00025215
	public void RLPuddleSplash()
	{
		this.RearLeftWheelDirtUp();
		this.RearLeftFrameDirtUp();
		this.RearFrameDirtUp();
		this.RearWindowDirtUp();
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00026E2F File Offset: 0x0002522F
	public void RRPuddleSplash()
	{
		this.RearRightWheelDirtUp();
		this.RearRightFrameDirtUp();
		this.RearFrameDirtUp();
		this.RearWindowDirtUp();
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00026E4C File Offset: 0x0002524C
	public void FLPuddleGlide()
	{
		if ((double)this.carLogic.GetComponent<CarLogicC>().FlWheelDirt.GetComponent<Renderer>().material.color.a < 0.64)
		{
			this.FrontLeftWheelDirtUp();
		}
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00026E98 File Offset: 0x00025298
	public void FRPuddleGlide()
	{
		if ((double)this.carLogic.GetComponent<CarLogicC>().FrWheelDirt.GetComponent<Renderer>().material.color.a < 0.64)
		{
			this.FrontRightWheelDirtUp();
		}
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x00026EE4 File Offset: 0x000252E4
	public void RLPuddleGlide()
	{
		if ((double)this.carLogic.GetComponent<CarLogicC>().RlWheelDirt.GetComponent<Renderer>().material.color.a < 0.64)
		{
			this.RearLeftWheelDirtUp();
		}
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x00026F30 File Offset: 0x00025330
	public void RRPuddleGlide()
	{
		if ((double)this.carLogic.GetComponent<CarLogicC>().RrWheelDirt.GetComponent<Renderer>().material.color.a < 0.64)
		{
			this.RearRightWheelDirtUp();
		}
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x00026F79 File Offset: 0x00025379
	private void DayGo()
	{
		this.isDay = true;
		this.uncle.SendMessage("DayGo");
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00026F92 File Offset: 0x00025392
	private void NightGo()
	{
		this.isDay = false;
		this.uncle.SendMessage("NightGo");
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x00026FAB File Offset: 0x000253AB
	private void LateNightGo()
	{
		this.uncle.SendMessage("LateNightGo");
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x00026FC0 File Offset: 0x000253C0
	private AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.volume = 1f;
		audioSource.spatialBlend = 0f;
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		return audioSource;
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0002701C File Offset: 0x0002541C
	public void BubbleOn(Transform target, string _name)
	{
		this.dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().enabled = false;
		this.dialogueHolder.GetComponent<UILabel>().enabled = false;
		this.dialogueHolder.GetComponent<DialogueStuffsC>()._name = Language.Get(_name, "Speech");
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[0] = this.dialogueHolder.GetComponent<DialogueStuffsC>().talkSound[0];
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[1] = this.dialogueHolder.GetComponent<DialogueStuffsC>().talkSound[1];
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[2] = this.dialogueHolder.GetComponent<DialogueStuffsC>().talkSound[2];
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[3] = this.dialogueHolder.GetComponent<DialogueStuffsC>().talkSound[3];
		this.dialogueHolder.transform.localScale = Vector3.zero;
		this.dialogueBubble.SetActive(true);
		this.PlayClipAt(this.bubbleGrowAudio, base.transform.position);
		iTween.ScaleTo(this.dialogueHolder, iTween.Hash(new object[]
		{
			"scale",
			new Vector3(1f, 1f, 1f),
			"time",
			0.1,
			"easetype",
			"easeOutBounce",
			"oncomplete",
			"BubbleOnFollowUp",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x000271BF File Offset: 0x000255BF
	private void BubbleOnFollowUp()
	{
		this.dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().enabled = true;
		this.dialogueHolder.GetComponent<UILabel>().enabled = true;
	}

	// Token: 0x060002EA RID: 746 RVA: 0x000271F0 File Offset: 0x000255F0
	public void YellBubbleOn(Transform target, string _name)
	{
		this.dialogueBubbleTail.GetComponent<SpeechBubbleTailC>().uncleMouth = target;
		this.dialogueHolder.GetComponent<DialogueStuffsC>()._name = Language.Get(_name, "Speech");
		this.dialogueBubble.SetActive(true);
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[0] = this.dialogueHolder.GetComponent<DialogueStuffsC>().yellSound[0];
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[1] = this.dialogueHolder.GetComponent<DialogueStuffsC>().yellSound[1];
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[2] = this.dialogueHolder.GetComponent<DialogueStuffsC>().yellSound[2];
		this.dialogueHolder.GetComponent<DialogueStuffsC>().sound[3] = this.dialogueHolder.GetComponent<DialogueStuffsC>().yellSound[3];
		this.dialogueHolder.transform.localScale = Vector3.zero;
		this.dialogueHolder.GetComponent<UILabel>().fontSize = 100;
		iTween.ScaleTo(this.dialogueHolder, iTween.Hash(new object[]
		{
			"scale",
			new Vector3(1f, 1f, 1f),
			"time",
			0.2,
			"easetype",
			"easeOutBounce"
		}));
		this.dialogueHolder.GetComponent<AudioSource>().PlayOneShot(this.bubbleGrowAudio, 1f);
		this.BubbleShake();
	}

	// Token: 0x060002EB RID: 747 RVA: 0x00027370 File Offset: 0x00025770
	public void CancelYell()
	{
		iTween.Stop(this.dialogueHolder);
		this.dialogueHolder.GetComponent<UILabel>().fontSize = 46;
		this.dialogueHolder.transform.localEulerAngles = new Vector3(this.dialogueHolder.transform.localEulerAngles.x, this.dialogueHolder.transform.localEulerAngles.y, 0f);
	}

	// Token: 0x060002EC RID: 748 RVA: 0x000273E4 File Offset: 0x000257E4
	private void BubbleShake()
	{
		iTween.ShakeRotation(this.dialogueHolder, iTween.Hash(new object[]
		{
			"z",
			1.0,
			"time",
			0.05,
			"easetype",
			"easeOutQuart",
			"looptype",
			"loop"
		}));
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0002745C File Offset: 0x0002585C
	public void BubbleOff()
	{
		iTween.ScaleTo(this.dialogueHolder, iTween.Hash(new object[]
		{
			"scale",
			Vector3.zero,
			"time",
			0.2,
			"easetype",
			"easeOutQuart",
			"oncomplete",
			"BubbleOff2",
			"oncompletetarget",
			base.gameObject
		}));
		this.dialogueBubbleTail.SetActive(false);
	}

	// Token: 0x060002EE RID: 750 RVA: 0x000274EC File Offset: 0x000258EC
	private void BubbleOff2()
	{
		this.dialogueBubble.SetActive(false);
	}

	// Token: 0x060002EF RID: 751 RVA: 0x000274FA File Offset: 0x000258FA
	public void AnnoyedGuest()
	{
		this.guestAnnoyance++;
	}

	// Token: 0x04000424 RID: 1060
	public bool isDemo;

	// Token: 0x04000425 RID: 1061
	public bool gerStartBedGo;

	// Token: 0x04000426 RID: 1062
	public bool turkBedGo;

	// Token: 0x04000427 RID: 1063
	public bool gerEndBedGo;

	// Token: 0x04000428 RID: 1064
	public float gerGoodTracker;

	// Token: 0x04000429 RID: 1065
	public float csfrGoodTracker;

	// Token: 0x0400042A RID: 1066
	public float hunGoodTracker;

	// Token: 0x0400042B RID: 1067
	public float yugoGoodTracker;

	// Token: 0x0400042C RID: 1068
	public float bulGoodTracker;

	// Token: 0x0400042D RID: 1069
	public float turkGoodTracker;

	// Token: 0x0400042E RID: 1070
	public bool isSatAtBorder;

	// Token: 0x0400042F RID: 1071
	public GameObject dayNightCycle;

	// Token: 0x04000430 RID: 1072
	public GameObject dialogueHolder;

	// Token: 0x04000431 RID: 1073
	public GameObject dialogueBubble;

	// Token: 0x04000432 RID: 1074
	public GameObject dialogueBubbleTail;

	// Token: 0x04000433 RID: 1075
	public AudioClip bubbleGrowAudio;

	// Token: 0x04000434 RID: 1076
	public GameObject carLogic;

	// Token: 0x04000435 RID: 1077
	public GameObject wallet;

	// Token: 0x04000436 RID: 1078
	public GameObject uncle;

	// Token: 0x04000437 RID: 1079
	public GameObject Astar;

	// Token: 0x04000438 RID: 1080
	public bool isDay = true;

	// Token: 0x04000439 RID: 1081
	public float puddleWetness;

	// Token: 0x0400043A RID: 1082
	public int puddleCount;

	// Token: 0x0400043B RID: 1083
	public int potHoleCount;

	// Token: 0x0400043C RID: 1084
	public int oilSpillCount;

	// Token: 0x0400043D RID: 1085
	private GameObject[] puddles;

	// Token: 0x0400043E RID: 1086
	public int aiCarCount;

	// Token: 0x0400043F RID: 1087
	public float totalWealth;

	// Token: 0x04000440 RID: 1088
	public int daysPassed;

	// Token: 0x04000441 RID: 1089
	public GameObject dayUI1;

	// Token: 0x04000442 RID: 1090
	public GameObject dayUI2;

	// Token: 0x04000443 RID: 1091
	[Header("Supply Values")]
	public int[] supplyNumbers;

	// Token: 0x04000444 RID: 1092
	public float[] supplyCatalogueSellPrices;

	// Token: 0x04000445 RID: 1093
	public float[] supplyCatalogueBuyPrices;

	// Token: 0x04000446 RID: 1094
	[Header("Event Logs")]
	public GameObject eventLogTarget;

	// Token: 0x04000447 RID: 1095
	public string eventLogString;

	// Token: 0x04000448 RID: 1096
	public List<int> eventCharacterTracking = new List<int>();

	// Token: 0x04000449 RID: 1097
	public int eventCharacterLimit = 760;

	// Token: 0x0400044A RID: 1098
	public List<GameObject> eventLogPurchasedObj = new List<GameObject>();

	// Token: 0x0400044B RID: 1099
	public List<GameObject> eventLogSoldObj = new List<GameObject>();

	// Token: 0x0400044C RID: 1100
	[Header("Unlocks")]
	public bool[] diaryUnlockStates = new bool[7];

	// Token: 0x0400044D RID: 1101
	[Header("Niblets")]
	public Transform laikaCatalogueHolder;

	// Token: 0x0400044E RID: 1102
	public bool wakeUpInTown;

	// Token: 0x0400044F RID: 1103
	public bool economyReady;

	// Token: 0x04000450 RID: 1104
	public bool economyGenerating;

	// Token: 0x04000451 RID: 1105
	public int guestAnnoyance;

	// Token: 0x04000452 RID: 1106
	public int footSteps;

	// Token: 0x04000453 RID: 1107
	public float fuelUsedStats;

	// Token: 0x04000454 RID: 1108
	public int tyrePoppedStats;

	// Token: 0x04000455 RID: 1109
	public float topSpeedStats;

	// Token: 0x04000456 RID: 1110
	public int repairKitsUsedStats;

	// Token: 0x04000457 RID: 1111
	public List<GameObject> soldItems = new List<GameObject>();
}
