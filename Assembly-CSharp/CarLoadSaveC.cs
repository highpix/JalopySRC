using System;
using UnityEngine;

// Token: 0x020000C6 RID: 198
public class CarLoadSaveC : MonoBehaviour
{
	// Token: 0x06000752 RID: 1874 RVA: 0x00098142 File Offset: 0x00096542
	public void Start()
	{
		this.LoadEngineComponents();
		this.LoadExtraComponents();
		this.LoadWheelComponents();
		this.LoadDirtLevels();
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x0009815C File Offset: 0x0009655C
	public void LoadWheelComponents()
	{
		if (ES3.Exists("flWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().flTyreID = ES3.LoadInt("flWheelID");
		}
		if (ES3.Exists("flCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().flCompoundID = ES3.LoadFloat("flCompoundID");
		}
		if (ES3.Exists("frWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().frTyreID = ES3.LoadInt("frWheelID");
		}
		if (ES3.Exists("frCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().frCompoundID = ES3.LoadFloat("frCompoundID");
		}
		if (ES3.Exists("rlWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().rlTyreID = ES3.LoadInt("rlWheelID");
		}
		if (ES3.Exists("frCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().frCompoundID = ES3.LoadFloat("frCompoundID");
		}
		if (ES3.Exists("rrWheelID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().rrTyreID = ES3.LoadInt("rrWheelID");
		}
		if (ES3.Exists("frCompoundID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().frCompoundID = ES3.LoadFloat("frCompoundID");
		}
		this.carLogic.GetComponent<CarPerformanceC>().LoadTyreComponents();
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x000982C4 File Offset: 0x000966C4
	public void LoadEngineComponents()
	{
		if (ES3.Exists("carEngineID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().engineLoadID = ES3.LoadInt("carEngineID");
		}
		if (ES3.Exists("ignitionCoilID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().ignitionCoilLoadID = ES3.LoadInt("ignitionCoilID");
		}
		if (ES3.Exists("fuelTankID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().fuelTankLoadID = ES3.LoadInt("fuelTankID");
		}
		if (ES3.Exists("carburettorID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().carburettorLoadID = ES3.LoadInt("carburettorID");
		}
		if (ES3.Exists("airFilterID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().airFilterLoadID = ES3.LoadInt("airFilterID");
		}
		if (ES3.Exists("waterTankID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().waterTankLoadID = ES3.LoadInt("waterTankID");
		}
		if (ES3.Exists("batteryID"))
		{
			this.carLogic.GetComponent<CarPerformanceC>().batteryLoadID = ES3.LoadInt("batteryID");
		}
		this.carLogic.GetComponent<CarPerformanceC>().LoadEngineComponents();
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x00098400 File Offset: 0x00096800
	public void LoadExtraComponents()
	{
		if (ES3.Exists("roofRackInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled = ES3.LoadBool("roofRackInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().roofRackWeight = ES3.LoadInt("roofRackWeight");
		}
		if (ES3.Exists("bullBarInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().bullBarInstalled = ES3.LoadBool("bullBarInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().bullBarWeight = ES3.LoadInt("bullBarWeight");
		}
		if (ES3.Exists("mudGuardsInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsInstalled = ES3.LoadBool("mudGuardsInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().mudGuardsWeight = ES3.LoadInt("mudGuardsWeight");
		}
		if (ES3.Exists("lightRackInstalled"))
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().lightRackInstalled = ES3.LoadBool("lightRackInstalled");
			this.carLogic.GetComponent<ExtraUpgradesC>().lightRackWeight = ES3.LoadInt("lightRackWeight");
		}
		this.carLogic.GetComponent<ExtraUpgradesC>().LoadExtras();
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x0009852C File Offset: 0x0009692C
	public void LoadDirtLevels()
	{
		if (ES3.Exists("frntDirt"))
		{
			this.frntDirt = ES3.LoadFloat("frntDirt");
			this.carLogic.GetComponent<CarLogicC>().frntDirtObj.GetComponent<Renderer>().material.SetAlpha(this.frntDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frntDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearDirt"))
		{
			this.rearDirt = ES3.LoadFloat("rearDirt");
			this.carLogic.GetComponent<CarLogicC>().rearDirtObj.GetComponent<Renderer>().material.SetAlpha(this.rearDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().rearDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frntlsideDirt"))
		{
			this.frntlsideDirt = ES3.LoadFloat("frntlsideDirt");
			this.carLogic.GetComponent<CarLogicC>().frntlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(this.frntlsideDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frntlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorlsideDirt"))
		{
			this.doorlsideDirt = ES3.LoadFloat("doorlsideDirt");
			this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(this.doorlsideDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorlsideDirt2"))
		{
			this.doorlsideDirt2 = ES3.LoadFloat("doorlsideDirt2");
			this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(this.doorlsideDirt2);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().doorlsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearlsideDirt"))
		{
			this.rearlsideDirt = ES3.LoadFloat("rearlsideDirt");
			this.carLogic.GetComponent<CarLogicC>().rearlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(this.rearlsideDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().rearlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frntrsideDirt"))
		{
			this.frntrsideDirt = ES3.LoadFloat("frntrsideDirt");
			this.carLogic.GetComponent<CarLogicC>().frntrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(this.frntrsideDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frntrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorrsideDirt"))
		{
			this.doorrsideDirt = ES3.LoadFloat("doorrsideDirt");
			this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(this.doorrsideDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorrsideDirt2"))
		{
			this.doorrsideDirt2 = ES3.LoadFloat("doorrsideDirt2");
			this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(this.doorrsideDirt2);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().doorrsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearrsideDirt"))
		{
			this.rearrsideDirt = ES3.LoadFloat("rearrsideDirt");
			this.carLogic.GetComponent<CarLogicC>().rearrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(this.rearrsideDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().rearrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("flWheelDirt"))
		{
			this.flWheelDirt = ES3.LoadFloat("flWheelDirt");
			this.carLogic.GetComponent<CarLogicC>().FlWheelDirt.GetComponent<Renderer>().material.SetAlpha(this.flWheelDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().FlWheelDirt.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frWheelDirt"))
		{
			this.frWheelDirt = ES3.LoadFloat("frWheelDirt");
			this.carLogic.GetComponent<CarLogicC>().FrWheelDirt.GetComponent<Renderer>().material.SetAlpha(this.frWheelDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().FrWheelDirt.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rrWheelDirt"))
		{
			this.rrWheelDirt = ES3.LoadFloat("rrWheelDirt");
			this.carLogic.GetComponent<CarLogicC>().RrWheelDirt.GetComponent<Renderer>().material.SetAlpha(this.rrWheelDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().RrWheelDirt.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rlWheelDirt"))
		{
			this.rlWheelDirt = ES3.LoadFloat("rlWheelDirt");
			this.carLogic.GetComponent<CarLogicC>().RlWheelDirt.GetComponent<Renderer>().material.SetAlpha(this.rlWheelDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().RlWheelDirt.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontWindowDirtRim"))
		{
			this.frontWindowDirtRim = ES3.LoadFloat("frontWindowDirtRim");
			this.carLogic.GetComponent<CarLogicC>().frontWindowDirtRim.GetComponent<Renderer>().material.SetAlpha(this.frontWindowDirtRim);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frontWindowDirtRim.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontWindowDirtWipers"))
		{
			this.frontWindowDirtWipers = ES3.LoadFloat("frontWindowDirtWipers");
			this.carLogic.GetComponent<CarLogicC>().frontWindowDirtWipers.GetComponent<Renderer>().material.SetAlpha(this.frontWindowDirtWipers);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frontWindowDirtWipers.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontWindowDirtSmudge"))
		{
			this.frontWindowDirtSmudge = ES3.LoadFloat("frontWindowDirtSmudge");
			this.carLogic.GetComponent<CarLogicC>().frontWindowDirtSmudge.GetComponent<Renderer>().material.SetAlpha(this.frontWindowDirtSmudge);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frontWindowDirtSmudge.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontLeftWindowDirt"))
		{
			this.frontLeftWindowDirt = ES3.LoadFloat("frontLeftWindowDirt");
			this.carLogic.GetComponent<CarLogicC>().frontLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(this.frontLeftWindowDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frontLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontRightWindowDirt"))
		{
			this.frontRightWindowDirt = ES3.LoadFloat("frontRightWindowDirt");
			this.carLogic.GetComponent<CarLogicC>().frontRightWindowObj.GetComponent<Renderer>().material.SetAlpha(this.frontRightWindowDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().frontRightWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearLeftWindowDirt"))
		{
			this.rearLeftWindowDirt = ES3.LoadFloat("rearLeftWindowDirt");
			this.carLogic.GetComponent<CarLogicC>().rearLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(this.rearLeftWindowDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().rearLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearRightWindowDirt"))
		{
			this.rearRightWindowDirt = ES3.LoadFloat("rearRightWindowDirt");
			this.carLogic.GetComponent<CarLogicC>().rearRightWindowObj.GetComponent<Renderer>().material.SetAlpha(this.rearRightWindowDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().rearRightWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearWindowDirt"))
		{
			this.rearWindowDirt = ES3.LoadFloat("rearWindowDirt");
			this.carLogic.GetComponent<CarLogicC>().rearWindowObject.GetComponent<Renderer>().material.SetAlpha(this.rearWindowDirt);
		}
		else
		{
			this.carLogic.GetComponent<CarLogicC>().rearWindowObject.GetComponent<Renderer>().material.SetAlpha(0f);
		}
	}

	// Token: 0x040009BD RID: 2493
	public GameObject carLogic;

	// Token: 0x040009BE RID: 2494
	public float frntDirt;

	// Token: 0x040009BF RID: 2495
	public float rearDirt;

	// Token: 0x040009C0 RID: 2496
	public float frntlsideDirt;

	// Token: 0x040009C1 RID: 2497
	public float doorlsideDirt;

	// Token: 0x040009C2 RID: 2498
	public float doorlsideDirt2;

	// Token: 0x040009C3 RID: 2499
	public float rearlsideDirt;

	// Token: 0x040009C4 RID: 2500
	public float frntrsideDirt;

	// Token: 0x040009C5 RID: 2501
	public float doorrsideDirt;

	// Token: 0x040009C6 RID: 2502
	public float doorrsideDirt2;

	// Token: 0x040009C7 RID: 2503
	public float rearrsideDirt;

	// Token: 0x040009C8 RID: 2504
	public float flWheelDirt;

	// Token: 0x040009C9 RID: 2505
	public float frWheelDirt;

	// Token: 0x040009CA RID: 2506
	public float rrWheelDirt;

	// Token: 0x040009CB RID: 2507
	public float rlWheelDirt;

	// Token: 0x040009CC RID: 2508
	public float frontWindowDirtRim;

	// Token: 0x040009CD RID: 2509
	public float frontWindowDirtWipers;

	// Token: 0x040009CE RID: 2510
	public float frontWindowDirtSmudge;

	// Token: 0x040009CF RID: 2511
	public float frontLeftWindowDirt;

	// Token: 0x040009D0 RID: 2512
	public float frontRightWindowDirt;

	// Token: 0x040009D1 RID: 2513
	public float rearLeftWindowDirt;

	// Token: 0x040009D2 RID: 2514
	public float rearRightWindowDirt;

	// Token: 0x040009D3 RID: 2515
	public float rearWindowDirt;
}
