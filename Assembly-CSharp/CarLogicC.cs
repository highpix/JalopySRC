using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200009B RID: 155
public class CarLogicC : MonoBehaviour
{
	// Token: 0x1700002B RID: 43
	// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00051459 File Offset: 0x0004F859
	// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00051461 File Offset: 0x0004F861
	public GameObject RlWheelDirt
	{
		get
		{
			return this.rlWheelDirt;
		}
		set
		{
			this.rlWheelDirt = value;
		}
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0005146A File Offset: 0x0004F86A
	// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00051472 File Offset: 0x0004F872
	public GameObject RrWheelDirt
	{
		get
		{
			return this.rrWheelDirt;
		}
		set
		{
			this.rrWheelDirt = value;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0005147B File Offset: 0x0004F87B
	// (set) Token: 0x060004D5 RID: 1237 RVA: 0x00051483 File Offset: 0x0004F883
	public GameObject FrWheelDirt
	{
		get
		{
			return this.frWheelDirt;
		}
		set
		{
			this.frWheelDirt = value;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0005148C File Offset: 0x0004F88C
	// (set) Token: 0x060004D7 RID: 1239 RVA: 0x00051494 File Offset: 0x0004F894
	public GameObject FlWheelDirt
	{
		get
		{
			return this.flWheelDirt;
		}
		set
		{
			this.flWheelDirt = value;
		}
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x000514A0 File Offset: 0x0004F8A0
	private void Start()
	{
		this.myLogic = base.GetComponent<CarLogicC>();
		this.StopDirtAudio();
		if (ES3.Exists("frntDirt"))
		{
			this.myLogic.frntDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frntDirt"));
		}
		else
		{
			this.myLogic.frntDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearDirt"))
		{
			this.myLogic.rearDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("rearDirt"));
		}
		else
		{
			this.myLogic.rearDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frntlsideDirt"))
		{
			this.myLogic.frntlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frntlsideDirt"));
		}
		else
		{
			this.myLogic.frntlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorlsideDirt"))
		{
			this.myLogic.doorlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("doorlsideDirt"));
		}
		else
		{
			this.myLogic.doorlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorlsideDirt2"))
		{
			this.myLogic.doorlsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("doorlsideDirt2"));
		}
		else
		{
			this.myLogic.doorlsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearlsideDirt"))
		{
			this.myLogic.rearlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("rearlsideDirt"));
		}
		else
		{
			this.myLogic.rearlsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frntrsideDirt"))
		{
			this.myLogic.frntrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frntrsideDirt"));
		}
		else
		{
			this.myLogic.frntrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorrsideDirt"))
		{
			this.myLogic.doorrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("doorrsideDirt"));
		}
		else
		{
			this.myLogic.doorrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("doorrsideDirt2"))
		{
			this.myLogic.doorrsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("doorrsideDirt2"));
		}
		else
		{
			this.myLogic.doorrsideDirtObj2.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearrsideDirt"))
		{
			this.myLogic.rearrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("rearrsideDirt"));
		}
		else
		{
			this.myLogic.rearrsideDirtObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontWindowDirtRim"))
		{
			this.myLogic.frontWindowDirtRim.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frontWindowDirtRim"));
		}
		else
		{
			this.myLogic.frontWindowDirtRim.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontWindowDirtWipers"))
		{
			this.myLogic.frontWindowDirtWipers.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frontWindowDirtWipers"));
		}
		else
		{
			this.myLogic.frontWindowDirtWipers.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontWindowDirtSmudge"))
		{
			this.myLogic.frontWindowDirtSmudge.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frontWindowDirtSmudge"));
		}
		else
		{
			this.myLogic.frontWindowDirtSmudge.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("frontLeftWindowDirt"))
		{
			this.myLogic.frontLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frontLeftWindowDirt"));
		}
		else
		{
			this.myLogic.frontLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (this.frontRightWindowObj != null)
		{
			if (ES3.Exists("frontRightWindowDirt"))
			{
				this.myLogic.frontRightWindowObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("frontRightWindowDirt"));
			}
			else
			{
				this.myLogic.frontRightWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
			}
		}
		if (ES3.Exists("rearLeftWindowDirt"))
		{
			this.myLogic.rearLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("rearLeftWindowDirt"));
		}
		else
		{
			this.myLogic.rearLeftWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearRightWindowDirt"))
		{
			this.myLogic.rearRightWindowObj.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("rearRightWindowDirt"));
		}
		else
		{
			this.myLogic.rearRightWindowObj.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("rearWindowDirt"))
		{
			this.myLogic.rearWindowObject.GetComponent<Renderer>().material.SetAlpha(ES3.LoadFloat("rearWindowDirt"));
		}
		else
		{
			this.myLogic.rearWindowObject.GetComponent<Renderer>().material.SetAlpha(0f);
		}
		if (ES3.Exists("cleanedTimes"))
		{
			this.cleanedTimes = ES3.LoadInt("cleanedTimes");
		}
		if (this.axleObjs.Length > 0)
		{
			if (this.axleObjs[0] != null)
			{
				this.axleObjs[0].GetComponent<Collider>().enabled = false;
			}
			if (this.axleObjs[1] != null)
			{
				this.axleObjs[1].GetComponent<Collider>().enabled = false;
			}
			if (this.axleObjs[2] != null)
			{
				this.axleObjs[2].GetComponent<Collider>().enabled = false;
			}
			if (this.axleObjs[3] != null)
			{
				this.axleObjs[3].GetComponent<Collider>().enabled = false;
			}
		}
		if (ES3.Exists("uncleTutorialCompleted"))
		{
			this.rightDoorHolder.GetComponent<Collider>().enabled = false;
		}
		else
		{
			this.rightDoorHolder.GetComponent<Collider>().enabled = true;
		}
		this.SetDryWindows();
		this.SetOdometer();
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x00051BF8 File Offset: 0x0004FFF8
	public void CleanAchievement()
	{
		GameObject gameObject = GameObject.FindWithTag("Steam");
		if (gameObject != null)
		{
			gameObject.SendMessage("UpdateProudOwner");
		}
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x00051C28 File Offset: 0x00050028
	private void SetOdometer()
	{
		if (SceneManager.GetActiveScene().name == "MainMenu")
		{
			return;
		}
		for (int i = 0; i < this.odometerDials.Length; i++)
		{
			this.odometerDials[i].transform.localEulerAngles = new Vector3(this.odometerDials[i].transform.localEulerAngles.x, this.odometerDials[i].transform.localEulerAngles.y, 0f);
		}
		if (ES3.Exists("odometerTotalDistance"))
		{
			base.transform.parent.transform.parent.GetComponent<CarControleScriptC>().totalDistance = ES3.LoadFloat("odometerTotalDistance");
		}
		this.actualOdometer = Mathf.RoundToInt(base.transform.parent.transform.parent.GetComponent<CarControleScriptC>().totalDistance / 32f);
		this.SetOdometerUp((float)this.actualOdometer);
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x00051D30 File Offset: 0x00050130
	private void SetOdometerUp(float amount)
	{
		if (this.odometerDials.Length <= 0)
		{
			return;
		}
		this.OdometerConversion();
		if (this.actualOdometer > 999999)
		{
			this.odometerRotations[0] = 9;
			this.odometerRotations[1] = 9;
			this.odometerRotations[2] = 9;
			this.odometerRotations[3] = 9;
			this.odometerRotations[4] = 9;
			this.odometerRotations[5] = 9;
		}
		else
		{
			this.odometerDials[0].transform.localEulerAngles = new Vector3(0f, 0f, (float)this.odometerRotations[0]);
			this.odometerDials[1].transform.localEulerAngles = new Vector3(0f, 0f, (float)this.odometerRotations[1]);
			this.odometerDials[2].transform.localEulerAngles = new Vector3(0f, 0f, (float)this.odometerRotations[2]);
			this.odometerDials[3].transform.localEulerAngles = new Vector3(0f, 0f, (float)this.odometerRotations[3]);
			this.odometerDials[4].transform.localEulerAngles = new Vector3(0f, 0f, (float)this.odometerRotations[4]);
			this.odometerDials[5].transform.localEulerAngles = new Vector3(0f, 0f, (float)this.odometerRotations[5]);
		}
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x00051EA0 File Offset: 0x000502A0
	private void OdometerConversion()
	{
		if (this.odometerRotations.Length <= 0)
		{
			return;
		}
		if (this.actualOdometer < 10)
		{
			this.odometerRotations[0] = int.Parse(this.actualOdometer.ToString()[0].ToString());
			this.odometerRotations[1] = 0;
			this.odometerRotations[2] = 0;
			this.odometerRotations[3] = 0;
			this.odometerRotations[4] = 0;
			this.odometerRotations[5] = 0;
		}
		else if (this.actualOdometer < 100)
		{
			this.odometerRotations[0] = int.Parse(this.actualOdometer.ToString()[1].ToString());
			this.odometerRotations[1] = int.Parse(this.actualOdometer.ToString()[0].ToString());
			this.odometerRotations[2] = 0;
			this.odometerRotations[3] = 0;
			this.odometerRotations[4] = 0;
			this.odometerRotations[5] = 0;
		}
		else if (this.actualOdometer < 1000)
		{
			this.odometerRotations[0] = int.Parse(this.actualOdometer.ToString()[2].ToString());
			this.odometerRotations[1] = int.Parse(this.actualOdometer.ToString()[1].ToString());
			this.odometerRotations[2] = int.Parse(this.actualOdometer.ToString()[0].ToString());
			this.odometerRotations[3] = 0;
			this.odometerRotations[4] = 0;
			this.odometerRotations[5] = 0;
		}
		else if (this.actualOdometer < 10000)
		{
			this.odometerRotations[0] = int.Parse(this.actualOdometer.ToString()[3].ToString());
			this.odometerRotations[1] = int.Parse(this.actualOdometer.ToString()[2].ToString());
			this.odometerRotations[2] = int.Parse(this.actualOdometer.ToString()[1].ToString());
			this.odometerRotations[3] = int.Parse(this.actualOdometer.ToString()[0].ToString());
			this.odometerRotations[4] = 0;
			this.odometerRotations[5] = 0;
		}
		else if (this.actualOdometer < 100000)
		{
			this.odometerRotations[0] = int.Parse(this.actualOdometer.ToString()[4].ToString());
			this.odometerRotations[1] = int.Parse(this.actualOdometer.ToString()[3].ToString());
			this.odometerRotations[2] = int.Parse(this.actualOdometer.ToString()[2].ToString());
			this.odometerRotations[3] = int.Parse(this.actualOdometer.ToString()[1].ToString());
			this.odometerRotations[4] = int.Parse(this.actualOdometer.ToString()[0].ToString());
			this.odometerRotations[5] = 0;
		}
		else if (this.actualOdometer > 999999)
		{
			this.odometerRotations[0] = 9;
			this.odometerRotations[1] = 9;
			this.odometerRotations[2] = 9;
			this.odometerRotations[3] = 9;
			this.odometerRotations[4] = 9;
			this.odometerRotations[5] = 9;
		}
		else
		{
			this.odometerRotations[0] = int.Parse(this.actualOdometer.ToString()[5].ToString());
			this.odometerRotations[1] = int.Parse(this.actualOdometer.ToString()[4].ToString());
			this.odometerRotations[2] = int.Parse(this.actualOdometer.ToString()[3].ToString());
			this.odometerRotations[3] = int.Parse(this.actualOdometer.ToString()[2].ToString());
			this.odometerRotations[4] = int.Parse(this.actualOdometer.ToString()[1].ToString());
			this.odometerRotations[5] = int.Parse(this.actualOdometer.ToString()[0].ToString());
		}
		this.odometerRotations[0] = this.ConvertOdometerNumbersToRots(this.odometerRotations[0]);
		this.odometerRotations[1] = this.ConvertOdometerNumbersToRots(this.odometerRotations[1]);
		this.odometerRotations[2] = this.ConvertOdometerNumbersToRots(this.odometerRotations[2]);
		this.odometerRotations[3] = this.ConvertOdometerNumbersToRots(this.odometerRotations[3]);
		this.odometerRotations[4] = this.ConvertOdometerNumbersToRots(this.odometerRotations[4]);
		this.odometerRotations[5] = this.ConvertOdometerNumbersToRots(this.odometerRotations[5]);
	}

	// Token: 0x060004DD RID: 1245 RVA: 0x000524A8 File Offset: 0x000508A8
	public int ConvertOdometerNumbersToRots(int num)
	{
		if (num == 0)
		{
			num = 0;
		}
		else if (num == 1)
		{
			num = 36;
		}
		else if (num == 2)
		{
			num = 72;
		}
		else if (num == 3)
		{
			num = 108;
		}
		else if (num == 4)
		{
			num = 144;
		}
		else if (num == 5)
		{
			num = 180;
		}
		else if (num == 6)
		{
			num = 216;
		}
		else if (num == 7)
		{
			num = 252;
		}
		else if (num == 8)
		{
			num = 288;
		}
		else if (num == 9)
		{
			num = 324;
		}
		return num;
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x00052564 File Offset: 0x00050964
	public void UpdateOdometer(float num)
	{
		int num2 = Mathf.RoundToInt(num / 32f);
		if (num2 > this.actualOdometer)
		{
			this.actualOdometer = num2;
			this.OdometerConversion();
			this.OdometerUp();
			if (this._steam == null)
			{
				this._steam = GameObject.FindWithTag("Steam");
			}
			if (this._steam != null)
			{
				this._steam.SendMessage("OdometerUp", this.actualOdometer);
			}
		}
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x000525EC File Offset: 0x000509EC
	private void OdometerUp()
	{
		if (this.odometerDials[0].transform.localEulerAngles.z != (float)this.odometerRotations[0])
		{
			if (this.actualOdometer >= 999999)
			{
				iTween.RotateTo(this.odometerDials[0], iTween.Hash(new object[]
				{
					"z",
					330,
					"islocal",
					true,
					"time",
					0.5,
					"easetype",
					"easeOutQuad"
				}));
			}
			else
			{
				iTween.RotateTo(this.odometerDials[0], iTween.Hash(new object[]
				{
					"z",
					this.odometerRotations[0],
					"islocal",
					true,
					"time",
					0.5,
					"easetype",
					"easeOutQuad"
				}));
			}
		}
		if (this.odometerDials[1].transform.localEulerAngles.z != (float)this.odometerRotations[1])
		{
			iTween.RotateTo(this.odometerDials[1], iTween.Hash(new object[]
			{
				"z",
				this.odometerRotations[1],
				"islocal",
				true,
				"delay",
				0.05,
				"time",
				0.5,
				"easetype",
				"easeOutQuad"
			}));
		}
		if (this.odometerDials[2].transform.localEulerAngles.z != (float)this.odometerRotations[2])
		{
			iTween.RotateTo(this.odometerDials[2], iTween.Hash(new object[]
			{
				"z",
				this.odometerRotations[2],
				"islocal",
				true,
				"time",
				0.5,
				"delay",
				0.1,
				"easetype",
				"easeOutQuad"
			}));
		}
		if (this.odometerDials[3].transform.localEulerAngles.z != (float)this.odometerRotations[3])
		{
			iTween.RotateTo(this.odometerDials[3], iTween.Hash(new object[]
			{
				"z",
				this.odometerRotations[3],
				"islocal",
				true,
				"time",
				0.5,
				"delay",
				0.15,
				"easetype",
				"easeOutQuad"
			}));
		}
		if (this.odometerDials[4].transform.localEulerAngles.z != (float)this.odometerRotations[4])
		{
			iTween.RotateTo(this.odometerDials[4], iTween.Hash(new object[]
			{
				"z",
				this.odometerRotations[4],
				"islocal",
				true,
				"time",
				0.5,
				"delay",
				0.2,
				"easetype",
				"easeOutQuad"
			}));
		}
		if (this.odometerDials[5].transform.localEulerAngles.z != (float)this.odometerRotations[5])
		{
			iTween.RotateTo(this.odometerDials[5], iTween.Hash(new object[]
			{
				"z",
				this.odometerRotations[5],
				"islocal",
				true,
				"time",
				0.5,
				"delay",
				0.25,
				"easetype",
				"easeOutQuad"
			}));
		}
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x00052A6A File Offset: 0x00050E6A
	public void UpdateBootPrices()
	{
		this.bootInventory.GetComponent<InventoryLogicC>().UpdateBootPrices();
		this.roofInventory.GetComponent<InventoryLogicC>().UpdateBootPrices();
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x00052A8C File Offset: 0x00050E8C
	public void LeftTyresReadyForRemoval()
	{
		if (base.GetComponent<CarPerformanceC>().frontLeftTyre != null)
		{
			Transform child = base.GetComponent<CarPerformanceC>().frontLeftTyre.transform.GetChild(0);
			child.GetComponent<BoxCollider>().enabled = true;
			this.frontLeftWheelCollider.GetComponent<SphereCollider>().enabled = false;
		}
		if (base.GetComponent<CarPerformanceC>().rearLeftTyre != null)
		{
			Transform child2 = base.GetComponent<CarPerformanceC>().rearLeftTyre.transform.GetChild(0);
			child2.GetComponent<BoxCollider>().enabled = true;
			this.rearLeftWheelCollider.GetComponent<SphereCollider>().enabled = false;
		}
		this.axleObjs[0].GetComponent<Collider>().enabled = true;
		this.axleObjs[1].GetComponent<Collider>().enabled = true;
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x00052B54 File Offset: 0x00050F54
	public void RightTyresReadyForRemoval()
	{
		if (base.GetComponent<CarPerformanceC>().frontRightTyre != null)
		{
			Transform child = base.GetComponent<CarPerformanceC>().frontRightTyre.transform.GetChild(0);
			child.GetComponent<BoxCollider>().enabled = true;
			this.frontRightWheelCollider.GetComponent<SphereCollider>().enabled = false;
		}
		if (base.GetComponent<CarPerformanceC>().rearRightTyre != null)
		{
			Transform child2 = base.GetComponent<CarPerformanceC>().rearRightTyre.transform.GetChild(0);
			child2.GetComponent<BoxCollider>().enabled = true;
			this.rearRightWheelCollider.GetComponent<SphereCollider>().enabled = false;
		}
		this.axleObjs[2].GetComponent<Collider>().enabled = true;
		this.axleObjs[3].GetComponent<Collider>().enabled = true;
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x00052C1C File Offset: 0x0005101C
	public void LeftTyresRestricted()
	{
		Transform child = base.GetComponent<CarPerformanceC>().frontLeftTyre.transform.GetChild(0);
		Transform child2 = base.GetComponent<CarPerformanceC>().rearLeftTyre.transform.GetChild(0);
		child.GetComponent<BoxCollider>().enabled = false;
		child2.GetComponent<BoxCollider>().enabled = false;
		this.frontLeftWheelCollider.GetComponent<SphereCollider>().enabled = true;
		this.rearLeftWheelCollider.GetComponent<SphereCollider>().enabled = true;
		this.axleObjs[0].GetComponent<Collider>().enabled = false;
		this.axleObjs[1].GetComponent<Collider>().enabled = false;
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00052CB8 File Offset: 0x000510B8
	public void RightTyresRestricted()
	{
		Transform child = base.GetComponent<CarPerformanceC>().frontRightTyre.transform.GetChild(0);
		Transform child2 = base.GetComponent<CarPerformanceC>().rearRightTyre.transform.GetChild(0);
		child.GetComponent<BoxCollider>().enabled = false;
		child2.GetComponent<BoxCollider>().enabled = false;
		this.frontRightWheelCollider.GetComponent<SphereCollider>().enabled = true;
		this.rearRightWheelCollider.GetComponent<SphereCollider>().enabled = true;
		this.axleObjs[2].GetComponent<Collider>().enabled = false;
		this.axleObjs[3].GetComponent<Collider>().enabled = false;
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x00052D53 File Offset: 0x00051153
	private void StartDirtAudio()
	{
		this.dirtTrackAudioTarget.GetComponent<AudioSource>().Play();
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00052D65 File Offset: 0x00051165
	private void StopDirtAudio()
	{
		if (!this.ridingThroughGrass && !this.ridingThroughDirt && this.dirtTrackAudioTarget != null)
		{
			this.dirtTrackAudioTarget.GetComponent<AudioSource>().Stop();
		}
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00052DA0 File Offset: 0x000511A0
	private void Update()
	{
		if (this.isPushingCar)
		{
			this.carDriver.GetComponent<CarControleScriptC>().maxTorque = 0.5f;
			this.carDriver.GetComponent<CarControleScriptC>().TopSpeed = 5f;
		}
		if (this.wheelUIIsGo)
		{
			if (this.spriteTimer > this.spriteTimerCheck)
			{
				if (this.wheelUI[0].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[0])
				{
					this.wheelUI[0].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[1];
				}
				else if (this.wheelUI[0].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[1])
				{
					this.wheelUI[0].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[0];
				}
				if (this.wheelUI[1].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[2])
				{
					this.wheelUI[1].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[3];
				}
				else if (this.wheelUI[1].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[3])
				{
					this.wheelUI[1].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[2];
				}
				if (this.wheelUI[2].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[4])
				{
					this.wheelUI[2].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[5];
				}
				else if (this.wheelUI[2].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[5])
				{
					this.wheelUI[2].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[4];
				}
				if (this.wheelUI[3].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[6])
				{
					this.wheelUI[3].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[7];
				}
				else if (this.wheelUI[3].GetComponent<SpriteRenderer>().sprite == this.wheelUISprites[7])
				{
					this.wheelUI[3].GetComponent<SpriteRenderer>().sprite = this.wheelUISprites[6];
				}
				this.spriteTimer = 0f;
			}
			this.spriteTimer += Time.deltaTime;
			this.spriteTimer2 += Time.deltaTime;
			if ((double)this.spriteTimer2 >= 5.0)
			{
				this.wheelUIIsGo = false;
				this.wheelUI[0].SetActive(false);
				this.wheelUI[1].SetActive(false);
				this.wheelUI[2].SetActive(false);
				this.wheelUI[3].SetActive(false);
			}
		}
		if (this.radioOn && !this.engineOn && base.GetComponent<CarPerformanceC>().installedBattery != null && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0.0 && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > 0.0)
		{
			base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.025f * Time.deltaTime;
		}
		if (this.windowWipersOn && !this.engineOn && base.GetComponent<CarPerformanceC>().installedBattery != null && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0.0 && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > 0.0)
		{
			base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.025f * Time.deltaTime;
		}
		if (((this.hazardLightsOn && !this.engineOn) || (this.headlightsOn && !this.engineOn)) && base.GetComponent<CarPerformanceC>().installedBattery != null && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0.0 && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > 0.0)
		{
			base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.025f * Time.deltaTime;
		}
		this.lightFrontRHeadlight.GetComponent<Light>().enabled = this.headlightsOn;
		if (this.ceilingLightOn && !this.engineOn && base.GetComponent<CarPerformanceC>().installedBattery != null && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge > 0.0 && (double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > 0.0)
		{
			base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge -= 0.025f * Time.deltaTime;
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(this.rayOrigin2.position, Vector3.down, out raycastHit, 4f, 16384))
		{
			if (raycastHit.collider.tag == "Dirt")
			{
				if (!this.ridingThroughDirt)
				{
					this.ridingThroughDirt = true;
					this.StartDirtAudio();
				}
				if (this.rainLvl == 0 && (double)this.carDriver.GetComponent<CarControleScriptC>().currentSpeed > 5.0)
				{
					float value = 0.01f * Time.deltaTime;
					float value2 = 0.02f * Time.deltaTime;
					if (base.GetComponent<ExtraUpgradesC>().mudGuardsInstalled)
					{
						value = 0.005f * Time.deltaTime;
						value2 = 0.01f * Time.deltaTime;
					}
					if ((double)this.FlWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
					{
						this.FlWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value2);
					}
					if ((double)this.FrWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
					{
						this.FrWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value2);
					}
					if ((double)this.RrWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
					{
						this.RrWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value2);
					}
					if ((double)this.RlWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
					{
						this.RlWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value2);
					}
					if ((double)this.frntDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.frntDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
					if ((double)this.rearDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.rearDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
					if ((double)this.frntlsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.frntlsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
					if ((double)this.doorlsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.doorlsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
						this.doorlsideDirtObj2.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
					if ((double)this.rearlsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.rearlsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
					if ((double)this.frntrsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.frntrsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
					if ((double)this.doorrsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.doorrsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
						this.doorrsideDirtObj2.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
					if ((double)this.rearrsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
					{
						this.rearrsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value);
					}
				}
			}
			else
			{
				this.ridingThroughDirt = false;
				this.StopDirtAudio();
			}
		}
		else
		{
			this.ridingThroughDirt = false;
			this.StopDirtAudio();
		}
		if (Physics.Raycast(this.rayOrigin2.position, Vector3.down, out raycastHit, 4f, 131072))
		{
			if (!this.ridingThroughGrass)
			{
				this.ridingThroughGrass = true;
				this.StartDirtAudio();
			}
			if (this.rainLvl == 0 && (double)this.carDriver.GetComponent<CarControleScriptC>().currentSpeed > 5.0)
			{
				float value3 = 0.02f * Time.deltaTime;
				float value4 = 0.04f * Time.deltaTime;
				if (base.GetComponent<ExtraUpgradesC>().mudGuardsInstalled)
				{
					value3 = 0.01f * Time.deltaTime;
					value4 = 0.02f * Time.deltaTime;
				}
				if ((double)this.FlWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
				{
					this.FlWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value4);
				}
				if ((double)this.FrWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
				{
					this.FrWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value4);
				}
				if ((double)this.RrWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
				{
					this.RrWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value4);
				}
				if ((double)this.RlWheelDirt.GetComponent<Renderer>().material.color.a < 1.0)
				{
					this.RlWheelDirt.GetComponent<Renderer>().material.color.IncreaseAlpha(value4);
				}
				if ((double)this.frntDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.frntDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
				if ((double)this.rearDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.rearDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
				if ((double)this.frntlsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.frntlsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
				if ((double)this.doorlsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.doorlsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
					this.doorlsideDirtObj2.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
				if ((double)this.rearlsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.rearlsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
				if ((double)this.frntrsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.frntrsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
				if ((double)this.doorrsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.doorrsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
					this.doorrsideDirtObj2.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
				if ((double)this.rearrsideDirtObj.GetComponent<Renderer>().material.color.a < 0.5)
				{
					this.rearrsideDirtObj.GetComponent<Renderer>().material.color.IncreaseAlpha(value3);
				}
			}
		}
		else
		{
			this.ridingThroughGrass = false;
			this.StopDirtAudio();
		}
		if (this.rainLvl > 0)
		{
			Vector3 origin = new Vector3(base.transform.position.x, base.transform.position.y + 1f, base.transform.position.z);
			float value5 = 0.1f * Time.deltaTime;
			if (Physics.Raycast(origin, Vector3.up, 100f))
			{
				this.isUnderShelter = true;
				this.playerSeat.GetComponent<SeatLogicC>().rainAudioPlay = false;
				if ((double)this.windscreenRainExt.GetComponent<Renderer>().material.color.a > 0.0)
				{
					this.windscreenRainExt.GetComponent<Renderer>().material.color.ReduceAlpha(value5);
				}
				if ((double)this.windscreenRainInt.GetComponent<Renderer>().material.color.a > 0.0)
				{
					this.windscreenRainInt.GetComponent<Renderer>().material.color.ReduceAlpha(value5);
				}
				if ((double)this.flRain.GetComponent<Renderer>().material.color.a > 0.0)
				{
					this.flRain.GetComponent<Renderer>().material.color.ReduceAlpha(value5);
				}
				if ((double)this.frRain.GetComponent<Renderer>().material.color.a > 0.0)
				{
					this.frRain.GetComponent<Renderer>().material.color.ReduceAlpha(value5);
				}
				if ((double)this.rlRain.GetComponent<Renderer>().material.color.a > 0.0)
				{
					this.rlRain.GetComponent<Renderer>().material.color.ReduceAlpha(value5);
				}
				if ((double)this.rrRain.GetComponent<Renderer>().material.color.a > 0.0)
				{
					this.rrRain.GetComponent<Renderer>().material.color.ReduceAlpha(value5);
				}
				if ((double)this.rearRain.GetComponent<Renderer>().material.color.a > 0.0)
				{
					this.rearRain.GetComponent<Renderer>().material.color.ReduceAlpha(value5);
				}
			}
			else
			{
				this.isUnderShelter = false;
				if (this.rainLvl == 1)
				{
					this.playerSeat.GetComponent<SeatLogicC>().rainAudioPlay = true;
					if ((double)this.windscreenRainExt.GetComponent<Renderer>().material.color.a < 0.1)
					{
						this.windscreenRainExt.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.windscreenRainInt.GetComponent<Renderer>().material.color.a < 0.1)
					{
						this.windscreenRainInt.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.flRain.GetComponent<Renderer>().material.color.a < 0.1)
					{
						this.flRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.frRain.GetComponent<Renderer>().material.color.a < 0.1)
					{
						this.frRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.rlRain.GetComponent<Renderer>().material.color.a < 0.1)
					{
						this.rlRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.rrRain.GetComponent<Renderer>().material.color.a < 0.1)
					{
						this.rrRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.rearRain.GetComponent<Renderer>().material.color.a < 0.1)
					{
						this.rearRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
				}
				if (this.rainLvl == 2)
				{
					this.playerSeat.GetComponent<SeatLogicC>().rainAudioPlay = true;
					if ((double)this.windscreenRainExt.GetComponent<Renderer>().material.color.a < 0.235)
					{
						this.windscreenRainExt.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.windscreenRainInt.GetComponent<Renderer>().material.color.a < 0.235)
					{
						this.windscreenRainInt.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.flRain.GetComponent<Renderer>().material.color.a < 0.235)
					{
						this.flRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.frRain.GetComponent<Renderer>().material.color.a < 0.235)
					{
						this.frRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.rlRain.GetComponent<Renderer>().material.color.a < 0.235)
					{
						this.rlRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.rrRain.GetComponent<Renderer>().material.color.a < 0.235)
					{
						this.rrRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
					if ((double)this.rearRain.GetComponent<Renderer>().material.color.a < 0.235)
					{
						this.rearRain.GetComponent<Renderer>().material.color.IncreaseAlpha(value5);
					}
				}
			}
		}
		if (this.rainLvl == 1)
		{
			float value6 = 0.002f * Time.deltaTime;
			if ((double)this.frontWindowDirtRim.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontWindowDirtRim.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.frontWindowDirtWipers.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontWindowDirtWipers.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.frontWindowDirtSmudge.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontWindowDirtSmudge.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.frontLeftWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontLeftWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.frontRightWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontRightWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.rearLeftWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearLeftWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.rearRightWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearRightWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.rearWindowObject.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearWindowObject.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.FlWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.FlWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.FrWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.FrWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.RlWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.RlWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.RrWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.RrWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.frntDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frntDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.rearDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.frntlsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frntlsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.doorlsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.doorlsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
				this.doorlsideDirtObj2.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.rearlsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearlsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.frntrsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frntrsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
			if ((double)this.doorrsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.doorrsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
				this.doorrsideDirtObj2.GetComponent<Renderer>().material.color.SetAlpha(value6);
			}
			if ((double)this.rearrsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearrsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value6);
			}
		}
		if (this.rainLvl == 2)
		{
			float value7 = 0.005f * Time.deltaTime;
			if ((double)this.frontWindowDirtRim.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontWindowDirtRim.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.frontWindowDirtWipers.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontWindowDirtWipers.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.frontWindowDirtSmudge.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontWindowDirtSmudge.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.frontLeftWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontLeftWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.frontRightWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frontRightWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.rearLeftWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearLeftWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.rearRightWindowObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearRightWindowObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.rearWindowObject.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearWindowObject.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.FlWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.FlWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.FrWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.FrWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.RrWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.RrWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.RlWheelDirt.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.RlWheelDirt.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.frntDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frntDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.rearDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.frntlsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frntlsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.doorlsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.doorlsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
				this.doorlsideDirtObj2.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.rearlsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearlsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.frntrsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.frntrsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
			if ((double)this.doorrsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.doorrsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
				this.doorrsideDirtObj2.GetComponent<Renderer>().material.color.SetAlpha(value7);
			}
			if ((double)this.rearrsideDirtObj.GetComponent<Renderer>().material.color.a > 0.0)
			{
				this.rearrsideDirtObj.GetComponent<Renderer>().material.color.ReduceAlpha(value7);
			}
		}
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x00054ED8 File Offset: 0x000532D8
	public void PushCarGo()
	{
		if (this.wheelObjects[0] == null || this.wheelObjects[1] == null || this.wheelObjects[2] == null || this.wheelObjects[3] == null)
		{
			return;
		}
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.handBrakeObj.SendMessage("ReleaseHandBrake");
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.storedPushAcc = this.carDriver.GetComponent<CarControleScriptC>().maxTorque;
		this.storedTopSpeed = this.carDriver.GetComponent<CarControleScriptC>().TopSpeed;
		this.isPushingCar = true;
		this.carDriver.GetComponent<CarControleScriptC>().enabled = true;
		this.carDriver.GetComponent<CarControleScriptC>().PushCarGo();
		this.carDriver.GetComponent<CarControleScriptC>().maxTorque = 0.5f;
		this.carDriver.GetComponent<CarControleScriptC>().TopSpeed = 1f;
		if (this.jackInUse != null && !this.jackInUse.GetComponent<CarJackC>().isJackedUp)
		{
			if (this.jackInUse.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
				this.jackInUse.GetComponent<ObjectPickupC>().ThrowLogic();
			}
			else
			{
				this.jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
				this.jackInUse.GetComponent<ObjectPickupC>().ReturnToShelf();
			}
			this.jackInUse = null;
		}
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x000550DC File Offset: 0x000534DC
	public void PushCarStop()
	{
		if (this.wheelObjects[0] == null || this.wheelObjects[1] == null || this.wheelObjects[2] == null || this.wheelObjects[3] == null)
		{
			return;
		}
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.handBrakeObj.SendMessage("ApplyHandBrake");
		float num = 1f;
		if (base.GetComponent<CarPerformanceC>().InstalledEngine != null && base.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
			if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.9f;
			}
			else if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.95f;
			}
			else if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
			}
			else if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 1.1f;
			}
		}
		if (this.damageLvl == 1)
		{
			num /= 1.25f;
		}
		else if (this.damageLvl == 2)
		{
			num /= 1.5f;
		}
		else if (this.damageLvl == 3)
		{
			num /= 1.8f;
		}
		this.engineObject.GetComponent<AudioSource>().pitch = num;
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		this.isPushingCar = false;
		this.carDriver.GetComponent<CarControleScriptC>().maxTorque = this.storedPushAcc;
		this.carDriver.GetComponent<CarControleScriptC>().TopSpeed = this.storedTopSpeed;
		this.carDriver.GetComponent<CarControleScriptC>().PushCarStop();
		this.carDriver.GetComponent<CarControleScriptC>().enabled = false;
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x000553B4 File Offset: 0x000537B4
	public void DrivingGo()
	{
		if (this.firstTimeDrivingToday)
		{
			for (int i = 0; i < this.wheelUI.Length; i++)
			{
				this.wheelUI[i].SetActive(true);
			}
			this.wheelUIIsGo = true;
			this.firstTimeDrivingToday = false;
		}
		this.isDriving = true;
		if (this.wheelObjects[0].GetComponent<WheelCollider>().sidewaysFriction.extremumValue > 10000f)
		{
			this.wheelObjects[0].GetComponent<WheelCollider>().sidewaysFriction.DecreaseExtrenum(10000f);
			this.wheelObjects[1].GetComponent<WheelCollider>().sidewaysFriction.DecreaseExtrenum(10000f);
			this.wheelObjects[2].GetComponent<WheelCollider>().sidewaysFriction.DecreaseExtrenum(10000f);
			this.wheelObjects[3].GetComponent<WheelCollider>().sidewaysFriction.DecreaseExtrenum(10000f);
		}
		this.cameraFollowCar = true;
		this.doorExit.gameObject.SetActive(false);
		this.player.GetComponent<RigidbodyControllerC>().driving = true;
		if (this.wheelObjects[0] == null || this.wheelObjects[1] == null || this.wheelObjects[2] == null || this.wheelObjects[3] == null)
		{
			return;
		}
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().HandBrakeOff();
		this.handBrakeObj.SendMessage("ReleaseHandBrake");
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().isBeingDriven = true;
		this.carDriver.GetComponent<CarControleScriptC>().enabled = true;
		this.uncle.GetComponent<UncleLogicC>().HandBrakeCarStart();
		if (this.jackInUse != null)
		{
			if (this.jackInUse.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
				this.jackInUse.GetComponent<ObjectPickupC>().ThrowLogic();
			}
			else
			{
				this.jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
				this.jackInUse.GetComponent<ObjectPickupC>().ReturnToShelf();
			}
			this.jackInUse = null;
		}
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00055649 File Offset: 0x00053A49
	private void StopStop()
	{
		this.carDriver.GetComponent<CarControleScriptC>().GetComponent<Rigidbody>().isKinematic = false;
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x00055664 File Offset: 0x00053A64
	public void DrivingStop(bool kinematic = false)
	{
		if (kinematic)
		{
			base.Invoke("StopStop", 0.1f);
			this.carDriver.GetComponent<CarControleScriptC>().GetComponent<Rigidbody>().isKinematic = true;
		}
		this.isDriving = false;
		this.cameraFollowCar = false;
		if (this.playerSeat.GetComponent<SeatLogicC>().isSat && this.leftDoor.GetComponent<DoorLogicC>().open)
		{
			this.doorExit.gameObject.SetActive(true);
		}
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().HandBrakeOn();
		this.handBrakeObj.SendMessage("ApplyHandBrake");
		this.playerCamera.GetComponent<DragRigidbodyC>().isDriving = false;
		this.player.GetComponent<RigidbodyControllerC>().driving = false;
		this.wheelObjects[0].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		this.wheelObjects[1].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		this.wheelObjects[2].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		this.wheelObjects[3].GetComponent<WheelScriptPCC>().isBeingDriven = false;
		float num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
		if (base.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 0)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.9f;
			}
			else if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 1)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 0.95f;
			}
			else if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch;
			}
			else if (base.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().fuelMix == 2)
			{
				num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudioPitch / 1.1f;
			}
		}
		if (this.damageLvl == 1)
		{
			num /= 1.25f;
		}
		else if (this.damageLvl == 2)
		{
			num /= 1.5f;
		}
		else if (this.damageLvl == 3)
		{
			num /= 1.8f;
		}
		this.engineObject.GetComponent<AudioSource>().pitch = num;
		this.carDriver.GetComponent<CarControleScriptC>().speedOMeterPointer.GetComponent<SpeedometerLogicC>().SetNeedle(0f);
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x00055932 File Offset: 0x00053D32
	private void RestoreCameraLook()
	{
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x00055934 File Offset: 0x00053D34
	public void EngineTurnedOn()
	{
		this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.engineStartAudio, 1f);
		this.engineObject.GetComponent<AudioSource>().loop = true;
		this.engineObject.GetComponent<AudioSource>().clip = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().engineAudio;
		this.engineObject.GetComponent<AudioSource>().Play();
		this.exhaust.SetActive(true);
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x000559B0 File Offset: 0x00053DB0
	public void EngineTurnedOff()
	{
		this.engineObject.GetComponent<AudioSource>().loop = false;
		this.engineObject.GetComponent<AudioSource>().Stop();
		this.engineObject.GetComponent<AudioSource>().PlayOneShot(this.engineStopAudio, 1f);
		this.exhaust.SetActive(false);
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x00055A08 File Offset: 0x00053E08
	public void HeadLightOn()
	{
		this.frontRHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOn;
		this.frontLHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOn;
		this.lightFrontLHeadlight.GetComponent<Light>().enabled = true;
		this.lightFrontRHeadlight.GetComponent<Light>().color.SetAlpha(0f);
		this.lightFrontRHeadlight.GetComponent<Light>().enabled = true;
		this.rearRHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOn;
		this.rearLHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOn;
		this.lightRearLHeadlight.GetComponent<Light>().enabled = true;
		this.lightRearRHeadlight.GetComponent<Light>().color.SetAlpha(0f);
		this.lightRearRHeadlight.GetComponent<Light>().enabled = true;
		if (base.GetComponent<ExtraUpgradesC>().lightRackInstalled)
		{
			base.GetComponent<ExtraUpgradesC>().lightRackMatTarget[0].GetComponent<Renderer>().material = this.frontHeadlightMatOn;
			base.GetComponent<ExtraUpgradesC>().lightRackMatTarget[1].GetComponent<Renderer>().material = this.frontHeadlightMatOn;
			base.GetComponent<ExtraUpgradesC>().lightRackMatTarget[2].GetComponent<Renderer>().material = this.frontHeadlightMatOn;
			base.GetComponent<ExtraUpgradesC>().lightRackLight.GetComponent<Light>().enabled = true;
			base.GetComponent<ExtraUpgradesC>().lightRackLight.GetComponent<Light>().color.SetAlpha(0f);
		}
		this.bsRoutine = base.StartCoroutine(this.FlickerHead());
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x00055B94 File Offset: 0x00053F94
	private IEnumerator FlickerHead()
	{
		base.StartCoroutine(this.FlickerLight());
		float randomLightWait = UnityEngine.Random.Range(0f, 4.1f);
		yield return new WaitForSeconds(randomLightWait);
		base.StopCoroutine(this.FlickerLight());
		this.lightFrontRHeadlight.GetComponent<Light>().enabled = true;
		this.headlightsOn = true;
		this.bsRoutine = null;
		yield break;
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x00055BB0 File Offset: 0x00053FB0
	public void LightsOff()
	{
		if (this.bsRoutine != null)
		{
			base.StopCoroutine(this.bsRoutine);
		}
		this.frontRHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOff2;
		this.frontLHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOff;
		this.lightFrontRHeadlight.GetComponent<Light>().enabled = false;
		this.lightFrontLHeadlight.GetComponent<Light>().enabled = false;
		this.rearRHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOff;
		this.rearLHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOff;
		this.lightRearRHeadlight.GetComponent<Light>().enabled = false;
		this.lightRearLHeadlight.GetComponent<Light>().enabled = false;
		if (base.GetComponent<ExtraUpgradesC>().lightRackInstalled)
		{
			base.GetComponent<ExtraUpgradesC>().lightRackMatTarget[0].GetComponent<Renderer>().material = this.frontHeadlightMatOff;
			base.GetComponent<ExtraUpgradesC>().lightRackMatTarget[1].GetComponent<Renderer>().material = this.frontHeadlightMatOff;
			base.GetComponent<ExtraUpgradesC>().lightRackMatTarget[2].GetComponent<Renderer>().material = this.frontHeadlightMatOff;
			base.GetComponent<ExtraUpgradesC>().lightRackLight.GetComponent<Light>().enabled = false;
		}
		this.headlightsOn = false;
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00055CF4 File Offset: 0x000540F4
	private IEnumerator FlickerLight()
	{
		bool allow = true;
		if (ES3.Exists("preventFlickerLight"))
		{
			bool flag = ES3.LoadBool("preventFlickerLight");
			if (flag)
			{
				this.lightFrontRHeadlight.GetComponent<Light>().enabled = true;
				allow = false;
			}
		}
		if (allow)
		{
			while (true && this.headlightsOn)
			{
				if (this.randomizer == 0f)
				{
					this.lightFrontRHeadlight.GetComponent<Light>().enabled = false;
				}
				else
				{
					this.lightFrontRHeadlight.GetComponent<Light>().enabled = true;
				}
				this.randomizer = (float)UnityEngine.Random.Range(0, 3);
				yield return new WaitForSeconds(this.flickerSpeed);
			}
		}
		yield break;
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x00055D10 File Offset: 0x00054110
	private IEnumerator HazardLights()
	{
		for (;;)
		{
			this.frontRHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOn;
			this.frontLHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOn;
			this.lightFrontRHeadlight.GetComponent<Light>().enabled = true;
			this.lightFrontLHeadlight.GetComponent<Light>().enabled = true;
			this.rearRHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOn;
			this.rearLHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOn;
			this.lightRearRHeadlight.GetComponent<Light>().enabled = true;
			this.lightRearLHeadlight.GetComponent<Light>().enabled = true;
			base.GetComponent<AudioSource>().PlayOneShot(this.flickAudioOn, 0.05f);
			yield return new WaitForSeconds(0.5f);
			this.frontRHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOff2;
			this.frontLHeadlight.GetComponent<Renderer>().material = this.frontHeadlightMatOff;
			this.lightFrontRHeadlight.GetComponent<Light>().enabled = false;
			this.lightFrontLHeadlight.GetComponent<Light>().enabled = false;
			this.rearRHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOff;
			this.rearLHeadlight.GetComponent<Renderer>().material = this.rearHeadlightMatOff;
			this.lightRearRHeadlight.GetComponent<Light>().enabled = false;
			this.lightRearLHeadlight.GetComponent<Light>().enabled = false;
			base.GetComponent<AudioSource>().PlayOneShot(this.flickAudioOff, 0.05f);
			yield return new WaitForSeconds(0.5f);
		}
		yield break;
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00055D2B File Offset: 0x0005412B
	private void HeadLightFullBeam()
	{
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x00055D2D File Offset: 0x0005412D
	private void RemoveMeshCollider()
	{
		UnityEngine.Object.Destroy(base.GetComponent<MeshCollider>());
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00055D3A File Offset: 0x0005413A
	private void AddMeshCollider()
	{
		if (base.gameObject.GetComponent<MeshCollider>() == null)
		{
			base.gameObject.AddComponent<MeshCollider>();
		}
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x00055D60 File Offset: 0x00054160
	private void WaterSpray()
	{
		if (base.GetComponent<CarPerformanceC>().waterTankObj == null)
		{
			base.GetComponent<ExtraUpgradesC>().WaterTankMissingUI();
			return;
		}
		if (base.GetComponent<CarPerformanceC>().installedBattery == null)
		{
			base.GetComponent<ExtraUpgradesC>().BatteryMissingUI();
			return;
		}
		if ((double)base.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge <= 0.0)
		{
			base.GetComponent<ExtraUpgradesC>().OutOfChargeUI();
			return;
		}
		if (base.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges > 0)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.waterSprayAudio, 1f);
			this.waterSpray[0].GetComponent<ParticleSystem>().Play();
			this.waterSpray[1].GetComponent<ParticleSystem>().Play();
			float num = this.myLogic.frontWindowDirtWipers.GetComponent<Renderer>().material.color.a - 0.4f;
			iTween.FadeTo(this.frontWindowDirtWipers, iTween.Hash(new object[]
			{
				"alpha",
				num,
				"time",
				3.2,
				"easetype",
				"easeInQuad"
			}));
			float num2 = this.myLogic.frontWindowDirtSmudge.GetComponent<Renderer>().material.color.a - 0.4f;
			iTween.FadeTo(this.frontWindowDirtSmudge, iTween.Hash(new object[]
			{
				"alpha",
				num2,
				"time",
				3.2,
				"easetype",
				"easeInQuad"
			}));
			base.GetComponent<CarPerformanceC>().Minus1Water();
			GameObject gameObject = base.GetComponent<CarPerformanceC>().waterTankObj.transform.GetChild(0).gameObject;
			gameObject.GetComponent<WaterSupplyRelayC>().WaterUpdate();
		}
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x00055F5C File Offset: 0x0005435C
	public void SetDryWindows()
	{
		this.rainLvl = 0;
		this.windscreenRainExt.SetActive(false);
		this.windscreenRainInt.SetActive(false);
		this.flRain.SetActive(false);
		this.frRain.SetActive(false);
		this.rlRain.SetActive(false);
		this.rrRain.SetActive(false);
		this.rearRain.SetActive(false);
		this.windscreenRainExt.GetComponent<Renderer>().material.color.SetAlpha(0f);
		this.windscreenRainInt.GetComponent<Renderer>().material.color.SetAlpha(0f);
		this.flRain.GetComponent<Renderer>().material.color.SetAlpha(0f);
		this.frRain.GetComponent<Renderer>().material.color.SetAlpha(0f);
		this.rlRain.GetComponent<Renderer>().material.color.SetAlpha(0f);
		this.rrRain.GetComponent<Renderer>().material.color.SetAlpha(0f);
		this.rearRain.GetComponent<Renderer>().material.color.SetAlpha(0f);
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x000560A0 File Offset: 0x000544A0
	[ContextMenu("Rain Light")]
	public void SetLightRainWindows()
	{
		this.rainLvl = 1;
		this.windscreenRainExt.SetActive(true);
		this.windscreenRainInt.SetActive(true);
		this.flRain.SetActive(true);
		this.frRain.SetActive(true);
		this.rlRain.SetActive(true);
		this.rrRain.SetActive(true);
		this.rearRain.SetActive(true);
		Color value = new Color(1f, 1f, 1f, 0.1f);
		this.windscreenRainExt.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.windscreenRainInt.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.flRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.frRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.rlRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.rrRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.rearRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x000561F0 File Offset: 0x000545F0
	[ContextMenu("Rain Heavy")]
	public void SetHeavyRainWindows()
	{
		Color value = new Color(1f, 1f, 1f, 0.235f);
		this.rainLvl = 2;
		this.windscreenRainExt.SetActive(true);
		this.windscreenRainInt.SetActive(true);
		this.flRain.SetActive(true);
		this.frRain.SetActive(true);
		this.rlRain.SetActive(true);
		this.rrRain.SetActive(true);
		this.rearRain.SetActive(true);
		this.windscreenRainExt.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.windscreenRainInt.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.flRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.frRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.rlRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.rrRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
		this.rearRain.GetComponent<Renderer>().materials[0].SetColor("_Color", value);
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00056340 File Offset: 0x00054740
	public void LightRainPuddleSplash()
	{
		iTween.Stop(base.gameObject);
		this.windscreenRainExt.SetActive(true);
		this.windscreenRainInt.SetActive(true);
		this.flRain.SetActive(true);
		this.frRain.SetActive(true);
		this.rlRain.SetActive(true);
		this.rrRain.SetActive(true);
		this.rearRain.SetActive(true);
		this.windscreenRainExt.GetComponent<Renderer>().material.color.SetAlpha(0.176f);
		this.windscreenRainInt.GetComponent<Renderer>().material.color.SetAlpha(0.176f);
		this.flRain.GetComponent<Renderer>().material.color.SetAlpha(0.176f);
		this.frRain.GetComponent<Renderer>().material.color.SetAlpha(0.176f);
		this.rlRain.GetComponent<Renderer>().material.color.SetAlpha(0.176f);
		this.rrRain.GetComponent<Renderer>().material.color.SetAlpha(0.176f);
		this.rearRain.GetComponent<Renderer>().material.color.SetAlpha(0.176f);
		iTween.FadeTo(this.windscreenRainExt, iTween.Hash(new object[]
		{
			"alpha",
			0.1,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.windscreenRainInt, iTween.Hash(new object[]
		{
			"alpha",
			0.1,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.flRain, iTween.Hash(new object[]
		{
			"alpha",
			0.1,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.frRain, iTween.Hash(new object[]
		{
			"alpha",
			0.1,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.rlRain, iTween.Hash(new object[]
		{
			"alpha",
			0.1,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.rrRain, iTween.Hash(new object[]
		{
			"alpha",
			0.1,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.rearRain, iTween.Hash(new object[]
		{
			"alpha",
			0.1,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x000566F0 File Offset: 0x00054AF0
	public void HeavyRainPuddleSplash()
	{
		iTween.Stop(base.gameObject);
		this.windscreenRainExt.SetActive(true);
		this.windscreenRainInt.SetActive(true);
		this.flRain.SetActive(true);
		this.frRain.SetActive(true);
		this.rlRain.SetActive(true);
		this.rrRain.SetActive(true);
		this.rearRain.SetActive(true);
		this.windscreenRainExt.GetComponent<Renderer>().material.color.SetAlpha(1f);
		this.windscreenRainInt.GetComponent<Renderer>().material.color.SetAlpha(1f);
		this.flRain.GetComponent<Renderer>().material.color.SetAlpha(1f);
		this.frRain.GetComponent<Renderer>().material.color.SetAlpha(1f);
		this.rlRain.GetComponent<Renderer>().material.color.SetAlpha(1f);
		this.rrRain.GetComponent<Renderer>().material.color.SetAlpha(1f);
		this.rearRain.GetComponent<Renderer>().material.color.SetAlpha(1f);
		iTween.FadeTo(this.windscreenRainExt, iTween.Hash(new object[]
		{
			"alpha",
			0.235,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.windscreenRainInt, iTween.Hash(new object[]
		{
			"alpha",
			0.235,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.flRain, iTween.Hash(new object[]
		{
			"alpha",
			0.235,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.frRain, iTween.Hash(new object[]
		{
			"alpha",
			0.235,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.rlRain, iTween.Hash(new object[]
		{
			"alpha",
			0.235,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.rrRain, iTween.Hash(new object[]
		{
			"alpha",
			0.235,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
		iTween.FadeTo(this.rearRain, iTween.Hash(new object[]
		{
			"alpha",
			0.235,
			"time",
			3.2,
			"easetype",
			"easeInQuad"
		}));
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x00056A9D File Offset: 0x00054E9D
	public void LowerEngineAudio()
	{
		this.engineObject.GetComponent<AudioSource>().volume = 0.3f;
		this.isQuietAudio = true;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x00056ABB File Offset: 0x00054EBB
	public void HigherEngineAudio()
	{
		this.engineObject.GetComponent<AudioSource>().volume = 1f;
		this.isQuietAudio = false;
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x00056AD9 File Offset: 0x00054ED9
	public void TrafficLightPenalty()
	{
		this.penaltyFare += 10;
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x00056AEC File Offset: 0x00054EEC
	private void PenaltyUp()
	{
		iTween.MoveTo(this.spawnedPenaltyTicket, iTween.Hash(new object[]
		{
			"position",
			Vector3.zero,
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
		this.penaltyFare += 10;
		GameObject amountTarget = this.spawnedPenaltyTicket.GetComponent<PenaltyTicketsC>().amountTarget;
		amountTarget.GetComponent<TextMesh>().text = this.penaltyFare.ToString();
		base.GetComponent<AudioSource>().PlayOneShot(this.penaltyAudio, 1f);
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00056BB0 File Offset: 0x00054FB0
	public void CarDamageUp()
	{
		for (int i = 0; i < this.damageTarget.Length; i++)
		{
			float num;
			if (base.GetComponent<CarPerformanceC>().carCondition != 0f && base.GetComponent<CarPerformanceC>().carDurability != 0f)
			{
				num = base.GetComponent<CarPerformanceC>().carCondition / base.GetComponent<CarPerformanceC>().carDurability;
			}
			else
			{
				num = 1f;
			}
			num = 1f - num;
			if (this.damageTarget[i] != null)
			{
				Color color = this.damageTarget[i].GetComponent<Renderer>().material.color;
				this.damageTarget[i].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, num);
			}
		}
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x00056C90 File Offset: 0x00055090
	public void LowerEngineDamage()
	{
		for (int i = 0; i < this.damageTarget.Length; i++)
		{
			float num;
			if (base.GetComponent<CarPerformanceC>().carCondition != 0f && base.GetComponent<CarPerformanceC>().carDurability != 0f)
			{
				num = base.GetComponent<CarPerformanceC>().carCondition / base.GetComponent<CarPerformanceC>().carDurability;
			}
			else
			{
				num = 1f;
			}
			num = 1f - num;
			Color color = this.damageTarget[i].GetComponent<Renderer>().material.color;
			this.damageTarget[i].GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, num);
		}
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x00056D5B File Offset: 0x0005515B
	private void CarDamageNone()
	{
		this.leftWindowHandle.GetComponent<WindowLogicC>().openChance = 100;
		this.rightWindowHandle.GetComponent<WindowLogicC>().openChance = 100;
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x00056D81 File Offset: 0x00055181
	private void UpdateEngineDamage()
	{
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x00056D84 File Offset: 0x00055184
	public void EngineDamageNone()
	{
		if (this.bonnetOpen)
		{
			this.engineDamageParticles[0].SetActive(false);
			this.engineDamageParticles[1].SetActive(false);
			this.engineDamageParticles[2].SetActive(false);
		}
		else
		{
			this.engineDamageParticles[0].SetActive(false);
			this.engineDamageParticles[1].SetActive(false);
			this.engineDamageParticles[2].SetActive(false);
		}
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x00056DF8 File Offset: 0x000551F8
	public void EngineDamageLow()
	{
		if (this.bonnetOpen)
		{
			this.engineDamageParticles[0].SetActive(false);
			this.engineDamageParticles[1].SetActive(false);
			this.engineDamageParticles[2].SetActive(true);
		}
		else
		{
			this.engineDamageParticles[0].SetActive(true);
			this.engineDamageParticles[1].SetActive(true);
			this.engineDamageParticles[2].SetActive(false);
		}
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startSize = 0.25f;
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startSize = 0.25f;
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startSize = 0.25f;
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f);
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f);
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f);
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startSpeed = 0.25f;
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startSpeed = 0.25f;
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startSpeed = 0.25f;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00056F68 File Offset: 0x00055368
	public void EngineDamageMed()
	{
		if (this.bonnetOpen)
		{
			this.engineDamageParticles[0].SetActive(false);
			this.engineDamageParticles[1].SetActive(false);
			this.engineDamageParticles[2].SetActive(true);
		}
		else
		{
			this.engineDamageParticles[0].SetActive(true);
			this.engineDamageParticles[1].SetActive(true);
			this.engineDamageParticles[2].SetActive(false);
		}
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startSize = 0.5f;
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startSize = 0.5f;
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startSize = 0.5f;
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startColor = new Color(0.6f, 0.6f, 0.6f);
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startColor = new Color(0.6f, 0.6f, 0.6f);
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startColor = new Color(0.6f, 0.6f, 0.6f);
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startSpeed = 0.5f;
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startSpeed = 0.5f;
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startSpeed = 0.5f;
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x000570D8 File Offset: 0x000554D8
	public void EngineDamageHigh()
	{
		if (this.bonnetOpen)
		{
			this.engineDamageParticles[0].SetActive(false);
			this.engineDamageParticles[1].SetActive(false);
			this.engineDamageParticles[2].SetActive(true);
		}
		else
		{
			this.engineDamageParticles[0].SetActive(true);
			this.engineDamageParticles[1].SetActive(true);
			this.engineDamageParticles[2].SetActive(false);
		}
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startSize = 1f;
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startSize = 1f;
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startSize = 1f;
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startColor = new Color(0.3f, 0.3f, 0.3f);
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startColor = new Color(0.3f, 0.3f, 0.3f);
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startColor = new Color(0.3f, 0.3f, 0.3f);
		this.engineDamageParticles[0].GetComponent<ParticleSystem>().startSpeed = 1f;
		this.engineDamageParticles[1].GetComponent<ParticleSystem>().startSpeed = 1f;
		this.engineDamageParticles[2].GetComponent<ParticleSystem>().startSpeed = 1f;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00057248 File Offset: 0x00055648
	public void BonnetOpen()
	{
		if (base.GetComponent<CarPerformanceC>().InstalledEngine == null)
		{
			return;
		}
		float condition = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		if ((double)condition <= 2.0)
		{
			this.engineDamageParticles[0].SetActive(false);
			this.engineDamageParticles[1].SetActive(false);
			this.engineDamageParticles[2].SetActive(true);
		}
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x000572BC File Offset: 0x000556BC
	public void BonnetClosed()
	{
		float num = 0f;
		if (base.GetComponent<CarPerformanceC>().InstalledEngine)
		{
			num = base.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition;
		}
		if ((double)num <= 2.0)
		{
			this.engineDamageParticles[0].SetActive(true);
			this.engineDamageParticles[1].SetActive(true);
			this.engineDamageParticles[2].SetActive(false);
		}
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00057334 File Offset: 0x00055734
	public void BorderControlState()
	{
		this.DrivingStop(true);
		this.leftDoor.GetComponent<DoorLogicC>().isLocked = true;
		this.leftDoor.GetComponent<DoorLogicC>().doorExit.SetActive(false);
		this.ignition.GetComponent<IgnitionLogicC>().preventIgnition = true;
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00057380 File Offset: 0x00055780
	public void BorderControlStateOff()
	{
		this.leftDoor.GetComponent<DoorLogicC>().isLocked = false;
		this.ignition.GetComponent<IgnitionLogicC>().preventIgnition = false;
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x000573A4 File Offset: 0x000557A4
	public void ElectricsOff()
	{
		if (this.ceilingLight == null)
		{
			return;
		}
		if (this.ceilingLight && this.ceilingLight.GetComponent<LightSwitchC>().isOn)
		{
			this.ceilingLight.GetComponent<LightSwitchC>().ElectricsOff();
		}
		if (this.radioOn)
		{
			base.StartCoroutine(this.radioFreq.GetComponent<RadioFreqLogicC>().TurnRadioOff());
		}
		if (this.windowWipersOn)
		{
			this.wipersHandle.GetComponent<WindowWipersLogicC>().ElectricsOff();
		}
		if (this.hazardLightsOn)
		{
			this.hazardLightButton.GetComponent<HazardsLogicC>().ElectricsOff();
		}
		if (this.headlightsOn)
		{
			this.headLightButton.GetComponent<HeadlightLogicC>().ElectricsOff();
		}
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x0005746B File Offset: 0x0005586B
	public void EnableMirrors()
	{
		this.mirrors[0].SetActive(true);
		this.mirrors[1].SetActive(true);
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00057489 File Offset: 0x00055889
	public void DisableMirrors()
	{
		this.mirrors[0].SetActive(false);
		this.mirrors[1].SetActive(false);
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x000574A8 File Offset: 0x000558A8
	private void NoClipTrue()
	{
		this.frontLeftWheelCollider.GetComponent<WheelScriptPCC>().NoClipTrue();
		this.frontRightWheelCollider.GetComponent<WheelScriptPCC>().NoClipTrue();
		this.rearLeftWheelCollider.GetComponent<WheelScriptPCC>().NoClipTrue();
		this.rearRightWheelCollider.GetComponent<WheelScriptPCC>().NoClipTrue();
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x000574F8 File Offset: 0x000558F8
	private void NoClipFalse()
	{
		this.frontLeftWheelCollider.GetComponent<WheelScriptPCC>().NoClipFalse();
		this.frontRightWheelCollider.GetComponent<WheelScriptPCC>().NoClipFalse();
		this.rearLeftWheelCollider.GetComponent<WheelScriptPCC>().NoClipFalse();
		this.rearRightWheelCollider.GetComponent<WheelScriptPCC>().NoClipFalse();
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x00057548 File Offset: 0x00055948
	public void OutOfFuel()
	{
		if (!this.ranOutOfFuel)
		{
			this.ranOutOfFuel = true;
			GameObject gameObject = GameObject.FindWithTag("Steam");
			if (gameObject != null)
			{
				gameObject.SendMessage("RanOutOfFuel");
			}
		}
	}

	// Token: 0x040006F6 RID: 1782
	private GameObject _steam;

	// Token: 0x040006F7 RID: 1783
	public GameObject player;

	// Token: 0x040006F8 RID: 1784
	public GameObject playerCamera;

	// Token: 0x040006F9 RID: 1785
	public GameObject uncle;

	// Token: 0x040006FA RID: 1786
	[Header("Lighting")]
	public Transform suitcaseTransform;

	// Token: 0x040006FB RID: 1787
	public GameObject frontRHeadlight;

	// Token: 0x040006FC RID: 1788
	public GameObject frontLHeadlight;

	// Token: 0x040006FD RID: 1789
	public GameObject rearRHeadlight;

	// Token: 0x040006FE RID: 1790
	public GameObject rearLHeadlight;

	// Token: 0x040006FF RID: 1791
	public GameObject lightFrontRHeadlight;

	// Token: 0x04000700 RID: 1792
	public GameObject lightFrontLHeadlight;

	// Token: 0x04000701 RID: 1793
	public GameObject lightRearRHeadlight;

	// Token: 0x04000702 RID: 1794
	public GameObject lightRearLHeadlight;

	// Token: 0x04000703 RID: 1795
	public Material frontHeadlightMatOn;

	// Token: 0x04000704 RID: 1796
	public Material frontHeadlightMatOff;

	// Token: 0x04000705 RID: 1797
	public Material frontHeadlightMatOff2;

	// Token: 0x04000706 RID: 1798
	public Material rearHeadlightMatOn;

	// Token: 0x04000707 RID: 1799
	public Material rearHeadlightMatOff;

	// Token: 0x04000708 RID: 1800
	[HideInInspector]
	public bool headlightsOn;

	// Token: 0x04000709 RID: 1801
	public GameObject headLightButton;

	// Token: 0x0400070A RID: 1802
	public float flickerSpeed = 0.07f;

	// Token: 0x0400070B RID: 1803
	private float randomizer;

	// Token: 0x0400070C RID: 1804
	public AudioClip flickAudioOn;

	// Token: 0x0400070D RID: 1805
	public AudioClip flickAudioOff;

	// Token: 0x0400070E RID: 1806
	[HideInInspector]
	public bool ceilingLightOn;

	// Token: 0x0400070F RID: 1807
	public GameObject ceilingLight;

	// Token: 0x04000710 RID: 1808
	[HideInInspector]
	public bool hazardLightsOn;

	// Token: 0x04000711 RID: 1809
	public GameObject hazardLightButton;

	// Token: 0x04000712 RID: 1810
	[Header("Engine")]
	public bool engineOn;

	// Token: 0x04000713 RID: 1811
	public bool isDriving;

	// Token: 0x04000714 RID: 1812
	public GameObject[] wheelObjects;

	// Token: 0x04000715 RID: 1813
	public GameObject carDriver;

	// Token: 0x04000716 RID: 1814
	public AudioClip engineAudio;

	// Token: 0x04000717 RID: 1815
	public GameObject handBrakeObj;

	// Token: 0x04000718 RID: 1816
	public GameObject engineObject;

	// Token: 0x04000719 RID: 1817
	public AudioClip engineStartAudio;

	// Token: 0x0400071A RID: 1818
	public AudioClip engineStopAudio;

	// Token: 0x0400071B RID: 1819
	public GameObject exhaust;

	// Token: 0x0400071C RID: 1820
	public bool preventHandBrake;

	// Token: 0x0400071D RID: 1821
	[Header("Car Parts")]
	public GameObject leftDoor;

	// Token: 0x0400071E RID: 1822
	public GameObject rightDoor;

	// Token: 0x0400071F RID: 1823
	public GameObject rightDoorHolder;

	// Token: 0x04000720 RID: 1824
	public GameObject leftWindowHandle;

	// Token: 0x04000721 RID: 1825
	public GameObject rightWindowHandle;

	// Token: 0x04000722 RID: 1826
	public GameObject ignition;

	// Token: 0x04000723 RID: 1827
	public GameObject engineBolt;

	// Token: 0x04000724 RID: 1828
	public Transform repairKitLoc;

	// Token: 0x04000725 RID: 1829
	public bool doorFitted;

	// Token: 0x04000726 RID: 1830
	[Header("Other")]
	public Transform steeringWheel;

	// Token: 0x04000727 RID: 1831
	public bool wheelUIIsGo;

	// Token: 0x04000728 RID: 1832
	public bool firstTimeDrivingToday = true;

	// Token: 0x04000729 RID: 1833
	public GameObject[] wheelUI;

	// Token: 0x0400072A RID: 1834
	public Sprite[] wheelUISprites;

	// Token: 0x0400072B RID: 1835
	private float spriteTimer;

	// Token: 0x0400072C RID: 1836
	private float spriteTimer2;

	// Token: 0x0400072D RID: 1837
	private float spriteTimerCheck = 0.15f;

	// Token: 0x0400072E RID: 1838
	public Transform cameraTarget;

	// Token: 0x0400072F RID: 1839
	public GameObject doorExit;

	// Token: 0x04000730 RID: 1840
	public bool windowWipersOn;

	// Token: 0x04000731 RID: 1841
	public GameObject bonnetObj;

	// Token: 0x04000732 RID: 1842
	public bool bonnetPopped;

	// Token: 0x04000733 RID: 1843
	public bool bonnetOpen;

	// Token: 0x04000734 RID: 1844
	public GameObject radioFreq;

	// Token: 0x04000735 RID: 1845
	[Header("Window Wipers & Dirt")]
	public GameObject wipersHandle;

	// Token: 0x04000736 RID: 1846
	[Header("Front Window")]
	public GameObject frontWindowDirtRim;

	// Token: 0x04000737 RID: 1847
	public GameObject frontWindowDirtWipers;

	// Token: 0x04000738 RID: 1848
	public GameObject frontWindowDirtSmudge;

	// Token: 0x04000739 RID: 1849
	[Header("Dirt")]
	public Transform rayOrigin2;

	// Token: 0x0400073A RID: 1850
	public bool ridingThroughDirt;

	// Token: 0x0400073B RID: 1851
	public bool ridingThroughGrass;

	// Token: 0x0400073C RID: 1852
	public GameObject dirtTrackAudioTarget;

	// Token: 0x0400073D RID: 1853
	public GameObject puddleSplashL;

	// Token: 0x0400073E RID: 1854
	public GameObject puddleSplashR;

	// Token: 0x0400073F RID: 1855
	[Header("Other Windows")]
	public GameObject frontLeftWindowObj;

	// Token: 0x04000740 RID: 1856
	public GameObject frontRightWindowObj;

	// Token: 0x04000741 RID: 1857
	public GameObject rearLeftWindowObj;

	// Token: 0x04000742 RID: 1858
	public GameObject rearRightWindowObj;

	// Token: 0x04000743 RID: 1859
	public GameObject rearWindowObject;

	// Token: 0x04000744 RID: 1860
	[Header("Car Frame")]
	public GameObject frntDirtObj;

	// Token: 0x04000745 RID: 1861
	public GameObject rearDirtObj;

	// Token: 0x04000746 RID: 1862
	public GameObject frntlsideDirtObj;

	// Token: 0x04000747 RID: 1863
	public GameObject doorlsideDirtObj;

	// Token: 0x04000748 RID: 1864
	public GameObject doorlsideDirtObj2;

	// Token: 0x04000749 RID: 1865
	public GameObject rearlsideDirtObj;

	// Token: 0x0400074A RID: 1866
	public GameObject frntrsideDirtObj;

	// Token: 0x0400074B RID: 1867
	public GameObject doorrsideDirtObj;

	// Token: 0x0400074C RID: 1868
	public GameObject doorrsideDirtObj2;

	// Token: 0x0400074D RID: 1869
	public GameObject rearrsideDirtObj;

	// Token: 0x0400074E RID: 1870
	[Header("Dirt Tyres")]
	public GameObject flWheelDirt;

	// Token: 0x0400074F RID: 1871
	public GameObject frWheelDirt;

	// Token: 0x04000750 RID: 1872
	public GameObject rrWheelDirt;

	// Token: 0x04000751 RID: 1873
	public GameObject rlWheelDirt;

	// Token: 0x04000752 RID: 1874
	[Header("Water")]
	public AudioClip waterSprayAudio;

	// Token: 0x04000753 RID: 1875
	public GameObject[] waterSpray;

	// Token: 0x04000754 RID: 1876
	public GameObject waterHolder;

	// Token: 0x04000755 RID: 1877
	[Header("Rainfall")]
	public GameObject windscreenRainExt;

	// Token: 0x04000756 RID: 1878
	public GameObject windscreenRainInt;

	// Token: 0x04000757 RID: 1879
	public int rainLvl;

	// Token: 0x04000758 RID: 1880
	public int windowWipersRainLvl;

	// Token: 0x04000759 RID: 1881
	public GameObject flRain;

	// Token: 0x0400075A RID: 1882
	public GameObject frRain;

	// Token: 0x0400075B RID: 1883
	public GameObject rlRain;

	// Token: 0x0400075C RID: 1884
	public GameObject rrRain;

	// Token: 0x0400075D RID: 1885
	public GameObject rearRain;

	// Token: 0x0400075E RID: 1886
	public bool isUnderShelter;

	// Token: 0x0400075F RID: 1887
	[HideInInspector]
	public bool isPushingCar;

	// Token: 0x04000760 RID: 1888
	[Header("Camera")]
	public Transform drivingLookAt;

	// Token: 0x04000761 RID: 1889
	public float drivingRotTweenTime;

	// Token: 0x04000762 RID: 1890
	public string drivingEaseType = string.Empty;

	// Token: 0x04000763 RID: 1891
	public bool cameraFollowCar;

	// Token: 0x04000764 RID: 1892
	public bool radioOn;

	// Token: 0x04000765 RID: 1893
	public GameObject playerSeat;

	// Token: 0x04000766 RID: 1894
	[HideInInspector]
	public bool isQuietAudio;

	// Token: 0x04000767 RID: 1895
	[Header("Penalties")]
	public GameObject penaltyTicket;

	// Token: 0x04000768 RID: 1896
	public Transform penaltyTicketTarget;

	// Token: 0x04000769 RID: 1897
	private GameObject spawnedPenaltyTicket;

	// Token: 0x0400076A RID: 1898
	public int penaltyFare;

	// Token: 0x0400076B RID: 1899
	public AudioClip penaltyAudio;

	// Token: 0x0400076C RID: 1900
	[Header("Damage")]
	public int damageLvl;

	// Token: 0x0400076D RID: 1901
	public GameObject[] damageTarget;

	// Token: 0x0400076E RID: 1902
	public GameObject[] engineDamageParticles;

	// Token: 0x0400076F RID: 1903
	[Header("Repairs")]
	public Transform engineToolBoxLoc;

	// Token: 0x04000770 RID: 1904
	public Transform spannerLoc;

	// Token: 0x04000771 RID: 1905
	[Header("Tyres")]
	public int sideJackedUp;

	// Token: 0x04000772 RID: 1906
	public GameObject frontLeftWheelCollider;

	// Token: 0x04000773 RID: 1907
	public GameObject frontRightWheelCollider;

	// Token: 0x04000774 RID: 1908
	public GameObject rearLeftWheelCollider;

	// Token: 0x04000775 RID: 1909
	public GameObject rearRightWheelCollider;

	// Token: 0x04000776 RID: 1910
	public GameObject jackInUse;

	// Token: 0x04000777 RID: 1911
	public GameObject[] axleObjs;

	// Token: 0x04000778 RID: 1912
	public GameObject bootInventory;

	// Token: 0x04000779 RID: 1913
	public Transform bootStandingLoc;

	// Token: 0x0400077A RID: 1914
	public GameObject bootLid;

	// Token: 0x0400077B RID: 1915
	public GameObject roofInventory;

	// Token: 0x0400077C RID: 1916
	[Header("Additional Paint Targets")]
	public GameObject carInterior;

	// Token: 0x0400077D RID: 1917
	public GameObject lDoorInterior;

	// Token: 0x0400077E RID: 1918
	public GameObject rDoorInterior;

	// Token: 0x0400077F RID: 1919
	public GameObject lHLight;

	// Token: 0x04000780 RID: 1920
	public GameObject rHLight;

	// Token: 0x04000781 RID: 1921
	public GameObject roof;

	// Token: 0x04000782 RID: 1922
	public GameObject trunkInterior;

	// Token: 0x04000783 RID: 1923
	public GameObject[] odometerDials;

	// Token: 0x04000784 RID: 1924
	public int[] odometerRotations;

	// Token: 0x04000785 RID: 1925
	public int actualOdometer;

	// Token: 0x04000786 RID: 1926
	public GameObject[] mirrors;

	// Token: 0x04000787 RID: 1927
	private float storedTopSpeed;

	// Token: 0x04000788 RID: 1928
	private float storedPushAcc;

	// Token: 0x04000789 RID: 1929
	private bool ranOutOfFuel;

	// Token: 0x0400078A RID: 1930
	public Transform suitcaseHolder;

	// Token: 0x0400078B RID: 1931
	public int cleanedTimes;

	// Token: 0x0400078C RID: 1932
	private CarLogicC myLogic;

	// Token: 0x0400078D RID: 1933
	private Coroutine bsRoutine;
}
