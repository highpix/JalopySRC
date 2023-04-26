using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200012E RID: 302
public class WheelScriptPCC : MonoBehaviour
{
	// Token: 0x06000C45 RID: 3141 RVA: 0x001292F4 File Offset: 0x001276F4
	private void Start()
	{
		this.wheelCollider = base.gameObject.GetComponent<WheelCollider>();
		this.carScript = base.transform.root.gameObject.GetComponent<CarControleScriptC>();
		this.SetValues();
		this.director = GameObject.FindGameObjectWithTag("Director");
		this.savedLowSpeed = this.carScript.lowSpeedTorqueChangeOver;
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x00129354 File Offset: 0x00127754
	public void SetValues()
	{
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x00129358 File Offset: 0x00127758
	private void Update()
	{
		this.WheelPosition();
		this.UpdateWetness();
		this.UpdateSpeedBasedGrip();
		if (this.wheelTransform != null)
		{
			this.wheelTransform.Rotate(this.wheelCollider.rpm / 60f * 360f * Time.deltaTime, 0f, 0f);
			if (this.typeOfWheel == WheelScriptPCC.wheelType.Steer || this.typeOfWheel == WheelScriptPCC.wheelType.SteerAndMotor)
			{
				if (this.wheelTransform.transform.parent.GetComponent<HoldingLogicC>().wheelID == 2)
				{
					this.wheelTransform.localEulerAngles = new Vector3(this.wheelTransform.localEulerAngles.x, this.wheelCollider.steerAngle + this.wheelTransform.localEulerAngles.z - 180f, this.wheelTransform.localEulerAngles.z);
				}
				else
				{
					this.wheelTransform.localEulerAngles = new Vector3(this.wheelTransform.localEulerAngles.x, this.wheelCollider.steerAngle + this.wheelTransform.localEulerAngles.z, this.wheelTransform.localEulerAngles.z);
				}
			}
		}
		if (this.steeringwheelTransform != null)
		{
			this.steeringwheelTransform.localEulerAngles = new Vector3(this.steeringwheelTransform.localEulerAngles.x, this.steeringwheelTransform.localEulerAngles.y, this.wheelCollider.steerAngle * 6f);
		}
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x00129504 File Offset: 0x00127904
	public void UpdateSpeedBasedGrip()
	{
		float num = this.extremumSlip;
		float num2 = this.asymptoteSlip;
		if (this.director != null && base.transform.root.GetComponent<CarControleScriptC>().currentSpeed < 40f)
		{
			float num3 = 40f - base.transform.root.GetComponent<CarControleScriptC>().currentSpeed;
			num3 *= 0.1f;
			float num4 = this.extremumSlip + num3;
			float num5 = this.asymptoteSlip + num3 * 2f;
			if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip < num4)
			{
			}
		}
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x001295B8 File Offset: 0x001279B8
	public void UpdateWetness()
	{
		this.wetAmount = Mathf.Clamp(this.wetAmount - Time.deltaTime * this.dryRate, 0f, float.MaxValue);
		if (this.director != null)
		{
			if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 0)
			{
				float num = this.extremumSlip;
				float num2 = this.asymptoteSlip;
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip > num)
				{
					WheelFrictionCurve sidewaysFriction = default(WheelFrictionCurve);
					sidewaysFriction = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction.extremumSlip -= 200f * Time.deltaTime;
					sidewaysFriction.asymptoteSlip -= 400f * Time.deltaTime;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction;
				}
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip < num)
				{
					WheelFrictionCurve sidewaysFriction2 = default(WheelFrictionCurve);
					sidewaysFriction2 = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction2.extremumSlip = num;
					sidewaysFriction2.asymptoteSlip = num2;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction2;
				}
			}
			if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 1)
			{
				float num = this.extremumSlip * 1.1f;
				float num2 = this.asymptoteSlip * 1.1f;
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip > num)
				{
					WheelFrictionCurve sidewaysFriction3 = default(WheelFrictionCurve);
					sidewaysFriction3 = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction3.extremumSlip -= 200f * Time.deltaTime;
					sidewaysFriction3.asymptoteSlip -= 400f * Time.deltaTime;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction3;
				}
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip < num)
				{
					WheelFrictionCurve sidewaysFriction4 = default(WheelFrictionCurve);
					sidewaysFriction4 = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction4.extremumSlip = num;
					sidewaysFriction4.asymptoteSlip = num2;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction4;
				}
			}
			if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
			{
				float num = this.extremumSlip * 1.2f;
				float num2 = this.asymptoteSlip * 1.2f;
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip > num)
				{
					WheelFrictionCurve sidewaysFriction5 = default(WheelFrictionCurve);
					sidewaysFriction5 = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction5.extremumSlip -= 200f * Time.deltaTime;
					sidewaysFriction5.asymptoteSlip -= 400f * Time.deltaTime;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction5;
				}
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip < num)
				{
					WheelFrictionCurve sidewaysFriction6 = default(WheelFrictionCurve);
					sidewaysFriction6 = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction6.extremumSlip = num;
					sidewaysFriction6.asymptoteSlip = num2;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction6;
				}
			}
			if (this.director.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
			{
				float num = this.extremumSlip * 1.4f;
				float num2 = this.asymptoteSlip * 1.4f;
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip > num)
				{
					WheelFrictionCurve sidewaysFriction7 = default(WheelFrictionCurve);
					sidewaysFriction7 = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction7.extremumSlip -= 200f * Time.deltaTime;
					sidewaysFriction7.asymptoteSlip -= 400f * Time.deltaTime;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction7;
				}
				if (base.GetComponent<WheelCollider>().sidewaysFriction.extremumSlip < num)
				{
					WheelFrictionCurve sidewaysFriction8 = default(WheelFrictionCurve);
					sidewaysFriction8 = base.GetComponent<WheelCollider>().sidewaysFriction;
					sidewaysFriction8.extremumSlip = num;
					sidewaysFriction8.asymptoteSlip = num2;
					base.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction8;
				}
			}
		}
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x001299A4 File Offset: 0x00127DA4
	private void FixedUpdate()
	{
		if (SceneManager.GetActiveScene().name == "MainMenu")
		{
			return;
		}
		this.StiffnessCode();
		if (this.typeOfWheel == WheelScriptPCC.wheelType.Motor || this.typeOfWheel == WheelScriptPCC.wheelType.SteerAndMotor)
		{
			this.TorqueControle();
		}
		if (this.typeOfWheel == WheelScriptPCC.wheelType.Steer || this.typeOfWheel == WheelScriptPCC.wheelType.SteerAndMotor)
		{
			this.CalcSteerValue();
			this.SteerControle();
		}
		if (this.handBreakable)
		{
			this.HandBrake();
		}
		if (!this.carScript.braked)
		{
			this.Decellaration();
		}
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x00129A3C File Offset: 0x00127E3C
	public void WheelPosition()
	{
		if (this.wheelTransform != null)
		{
			if (base.transform.root.GetComponent<CarControleScriptC>().currentSpeed >= 1f)
			{
				if ((double)this.wheelTransform.GetComponent<EngineComponentC>().Condition <= 0.0 && !this.isFlatPlaying)
				{
					base.StartCoroutine(this.PlayFlatRubber());
				}
			}
			else if (base.transform.root.GetComponent<CarControleScriptC>().currentSpeed <= -1f && (double)this.wheelTransform.GetComponent<EngineComponentC>().Condition <= 0.0 && !this.isFlatPlaying)
			{
				base.StartCoroutine(this.PlayFlatRubber());
			}
		}
		else
		{
			if (this.wheelNumber == 1 && this.carScript.carLogic.GetComponent<CarPerformanceC>().frontLeftTyre != null)
			{
				this.wheelTransform = this.carScript.carLogic.GetComponent<CarPerformanceC>().frontLeftTyre.transform;
			}
			if (this.wheelNumber == 2 && this.carScript.carLogic.GetComponent<CarPerformanceC>().frontRightTyre != null)
			{
				this.wheelTransform = this.carScript.carLogic.GetComponent<CarPerformanceC>().frontRightTyre.transform;
			}
			if (this.wheelNumber == 3 && this.carScript.carLogic.GetComponent<CarPerformanceC>().rearLeftTyre != null)
			{
				this.wheelTransform = this.carScript.carLogic.GetComponent<CarPerformanceC>().rearLeftTyre.transform;
			}
			if (this.wheelNumber == 4 && this.carScript.carLogic.GetComponent<CarPerformanceC>().rearRightTyre != null)
			{
				this.wheelTransform = this.carScript.carLogic.GetComponent<CarPerformanceC>().rearRightTyre.transform;
			}
		}
		WheelHit wheelHit;
		Vector3 position;
		if (this.wheelCollider.GetGroundHit(out wheelHit))
		{
			position = wheelHit.point + Vector3.up * 1.4f * this.wheelCollider.radius;
		}
		else
		{
			position = base.transform.position - Vector3.up * this.wheelCollider.suspensionDistance;
		}
		if (this.wheelTransform != null)
		{
			this.wheelTransform.localPosition = new Vector3(this.wheelTransform.localPosition.x, this.wheelTransform.parent.InverseTransformPoint(position).y, this.wheelTransform.localPosition.z);
		}
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x00129D0C File Offset: 0x0012810C
	private IEnumerator PlayFlatRubber()
	{
		this.isFlatPlaying = true;
		int i = UnityEngine.Random.Range(0, this.flatTyreAudio.Length);
		GameObject sound = UnityEngine.Object.Instantiate<GameObject>(this.flatTyreAudio[i], base.transform.position, Quaternion.identity);
		double flatVolume = (double)base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.01;
		if (flatVolume > 1.0)
		{
			flatVolume = 1.0;
		}
		if (this.volumeLower)
		{
			flatVolume *= 0.4;
		}
		sound.GetComponent<AudioSource>().volume = base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.025f;
		float waitTime = 0.4f;
		waitTime -= base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.0085f;
		if (waitTime < 0.02f)
		{
			waitTime = 0.02f;
		}
		yield return new WaitForSeconds(waitTime);
		this.isFlatPlaying = false;
		yield break;
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x00129D27 File Offset: 0x00128127
	public void Decellaration()
	{
		if (!this.isBeingDriven)
		{
			return;
		}
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x00129D38 File Offset: 0x00128138
	public void CalcSteerValue()
	{
		if (!this.playerCam)
		{
			return;
		}
		if (!MainMenuC.Global)
		{
			return;
		}
		if ((MainMenuC.Global.padInput == 1 && (double)Input.GetAxis("JoypadX") > 0.1) || (double)Input.GetAxis("JoypadX") < -0.1)
		{
			if ((double)Input.GetAxis("JoypadX") > 0.1)
			{
				this.currentSteerSensitivity += Input.GetAxis("JoypadX") * this.padTurningSensitivity * Time.deltaTime;
			}
			else if ((double)Input.GetAxis("JoypadX") < 0.1)
			{
				this.currentSteerSensitivity += Input.GetAxis("JoypadX") * this.padTurningSensitivity * Time.deltaTime;
			}
		}
		else if ((MainMenuC.Global.padInput != 2 || (double)Input.GetAxis("JoypadX") <= 0.1) && (double)Input.GetAxis("JoypadX") >= -0.1)
		{
			if ((MainMenuC.Global.padInput != 3 || (double)Input.GetAxis("JoypadX") <= 0.1) && (double)Input.GetAxis("JoypadX") >= -0.1)
			{
				if ((MainMenuC.Global.padInput == 0 && Input.GetKey(MainMenuC.Global.assignedInputStrings[12])) || Input.GetKey(MainMenuC.Global.assignedInputStrings[13]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[14]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[15]))
				{
					if (Input.GetKey(MainMenuC.Global.assignedInputStrings[12]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[13]))
					{
						this.currentSteerSensitivity -= this.steerSensitivityValue * Time.deltaTime;
					}
					else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[14]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[15]))
					{
						this.currentSteerSensitivity += this.steerSensitivityValue * Time.deltaTime;
					}
				}
				else if ((double)this.currentSteerSensitivity > 0.0)
				{
					this.currentSteerSensitivity -= this.steerSensitivityValue * Time.deltaTime / 2f;
				}
				else if ((double)this.currentSteerSensitivity < 0.0)
				{
					this.currentSteerSensitivity += this.steerSensitivityValue * Time.deltaTime / 2f;
				}
			}
		}
		if ((double)this.currentSteerSensitivity > 1.0)
		{
			this.currentSteerSensitivity = 1f;
		}
		if ((double)this.currentSteerSensitivity < -1.0)
		{
			this.currentSteerSensitivity = -1f;
		}
		if ((double)this.prevSteerAngel > 0.0)
		{
			this.prevSteerAngel -= this.steerSensitivityValue * Time.deltaTime / 2f;
		}
		if ((double)this.prevSteerAngel < 0.0)
		{
			this.prevSteerAngel += this.steerSensitivityValue * Time.deltaTime / 2f;
		}
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x0012A0D4 File Offset: 0x001284D4
	public void SteerControle()
	{
		if (this.isBeingDriven)
		{
			this.speedFactor = base.transform.parent.root.GetComponent<Rigidbody>().velocity.magnitude / this.carScript.lowestSteerAtSpeed;
			float num = Mathf.Lerp(this.carScript.lowSpeedSteerAngel, this.carScript.highSpeedSteerAngel, this.speedFactor);
			if (this.invertSteer)
			{
				if (Input.GetKey(MainMenuC.Global.assignedInputStrings[12]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[13]))
				{
					this.prevSteerAngel = this.currentSteerSensitivity;
					num *= this.currentSteerSensitivity;
				}
				else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[14]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[15]))
				{
					this.prevSteerAngel = this.currentSteerSensitivity;
					num *= this.currentSteerSensitivity;
				}
				else if (!this.noClip && MainMenuC.Global.padInput == 1)
				{
					if ((double)Input.GetAxis("JoypadX") > 0.1 || (double)Input.GetAxis("JoypadX") < -0.1)
					{
						this.prevSteerAngel = this.currentSteerSensitivity;
						num *= -Input.GetAxis("JoypadX");
					}
				}
				else if (!this.noClip && MainMenuC.Global.padInput == 2)
				{
					if ((double)Input.GetAxis("JoypadX") > 0.1 || (double)Input.GetAxis("JoypadX") < -0.1)
					{
						this.prevSteerAngel = this.currentSteerSensitivity;
						num *= -Input.GetAxis("JoypadX");
					}
				}
				else if (!this.noClip && MainMenuC.Global.padInput == 3 && ((double)Input.GetAxis("JoypadX") > 0.1 || (double)Input.GetAxis("JoypadX") < -0.1))
				{
					this.prevSteerAngel = this.currentSteerSensitivity;
					num *= -Input.GetAxis("JoypadX");
				}
			}
			else if (!this.noClip && MainMenuC.Global.padInput == 0)
			{
				if (Input.GetKey(MainMenuC.Global.assignedInputStrings[12]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[13]))
				{
					this.prevSteerAngel = this.currentSteerSensitivity;
					num *= this.currentSteerSensitivity;
				}
				else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[14]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[15]))
				{
					this.prevSteerAngel = this.currentSteerSensitivity;
					num *= this.currentSteerSensitivity;
				}
				else if ((double)this.prevSteerAngel > 0.1)
				{
					num *= this.currentSteerSensitivity;
					this.prevSteerAngel = this.currentSteerSensitivity;
				}
				else if ((double)this.prevSteerAngel < -0.1)
				{
					num *= this.currentSteerSensitivity;
					this.prevSteerAngel = this.currentSteerSensitivity;
				}
				else
				{
					num = 0f;
					this.prevSteerAngel = 0f;
				}
			}
			else if (!this.noClip && MainMenuC.Global.padInput == 1)
			{
				if ((double)Input.GetAxis("JoypadX") > 0.1 || (double)Input.GetAxis("JoypadX") < -0.1)
				{
					this.prevSteerAngel = this.currentSteerSensitivity;
					num *= this.currentSteerSensitivity;
				}
				else if ((double)this.prevSteerAngel > 0.01)
				{
					num *= this.currentSteerSensitivity;
					this.prevSteerAngel = this.currentSteerSensitivity;
				}
				else if ((double)this.prevSteerAngel < -0.01)
				{
					num *= this.currentSteerSensitivity;
					this.prevSteerAngel = this.currentSteerSensitivity;
				}
				else
				{
					num = 0f;
					this.prevSteerAngel = 0f;
				}
			}
			else if (!this.noClip && MainMenuC.Global.padInput == 2)
			{
				if ((double)Input.GetAxis("JoypadX") > 0.1 || (double)Input.GetAxis("JoypadX") < -0.1)
				{
					num *= Input.GetAxis("JoypadX");
				}
				else
				{
					num = 0f;
					this.prevSteerAngel = 0f;
				}
			}
			else if (!this.noClip && MainMenuC.Global.padInput == 3)
			{
				if ((double)Input.GetAxis("JoypadX") > 0.1 || (double)Input.GetAxis("JoypadX") < -0.1)
				{
					num *= Input.GetAxis("JoypadX");
				}
				else
				{
					num = 0f;
					this.prevSteerAngel = 0f;
				}
			}
			if ((double)num < 0.1 && (double)num > -0.1)
			{
				num = 0f;
				this.prevSteerAngel = 0f;
				this.wheelCollider.steerAngle = 0f;
			}
			if (this.wheelNumber == 1)
			{
				float num2 = Mathf.Clamp(this.wetAmount * 0.3f, 0f, 25f);
			}
			if (this.wheelNumber == 2)
			{
				float num2 = Mathf.Clamp(this.wetAmount * -0.3f, -25f, 0f);
			}
			this.wheelCollider.steerAngle = Mathf.Lerp(this.wheelCollider.steerAngle, num, Time.deltaTime * 5f);
			WheelFrictionCurve sidewaysFriction = this.wheelCollider.sidewaysFriction;
			sidewaysFriction.extremumValue = 2f - Mathf.Clamp(this.wetAmount * 0.099f, 0f, 0.99f);
			this.wheelCollider.sidewaysFriction = sidewaysFriction;
			WheelFrictionCurve forwardFriction = this.wheelCollider.forwardFriction;
		}
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x0012A70C File Offset: 0x00128B0C
	public void TorqueControle()
	{
		if (!this.isBeingDriven)
		{
			return;
		}
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			MainMenuC.Global.padInput = 1;
		}
		float currentSpeed = this.carScript.currentSpeed;
		bool flag = Input.GetKey(MainMenuC.Global.assignedInputStrings[8]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[9]) || Input.GetAxis("JoypadAccelerate") > 0.1f;
		bool flag2 = Input.GetKey(MainMenuC.Global.assignedInputStrings[10]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[11]) || Input.GetAxis("JoypadReverse") > 0.1f;
		float num = 1f;
		float num2 = -1f;
		if (Mathf.Abs(Input.GetAxis("JoypadAccelerate")) > 0.1f || Mathf.Abs(Input.GetAxis("JoypadReverse")) > 0.1f)
		{
			num = Input.GetAxis("JoypadAccelerate");
			num2 = -Input.GetAxis("JoypadReverse");
		}
		if (!this.carScript.braked)
		{
			if (flag && currentSpeed < this.carScript.TopSpeed)
			{
				this.wheelCollider.brakeTorque = 0f;
				if (currentSpeed < this.carScript.lowSpeedTorqueChangeOver)
				{
					this.wheelCollider.motorTorque = this.carScript.maxTorque * this.carScript.lowSpeedTorqueMultiplier * DebugController.Global.torqueMultiplier * num;
				}
				if (currentSpeed > this.carScript.lowSpeedTorqueChangeOver)
				{
					this.wheelCollider.motorTorque = this.carScript.maxTorque * DebugController.Global.torqueMultiplier * num;
				}
				this.wheelCollider.wheelDampingRate = Mathf.Lerp(this.wheelCollider.wheelDampingRate, 0f, Time.fixedDeltaTime * 5f);
				return;
			}
			if (currentSpeed > 0f)
			{
				this.wheelCollider.wheelDampingRate = Mathf.Lerp(this.wheelCollider.wheelDampingRate, 80f, Time.fixedDeltaTime * 30f);
				this.wheelCollider.motorTorque = 0f;
				if (flag)
				{
					this.wheelCollider.brakeTorque = 0f;
				}
				else
				{
					this.wheelCollider.brakeTorque = ((!flag2) ? this.brakeForce : (this.brakeForce * 4f));
				}
				return;
			}
			if (flag2 && currentSpeed <= 0f && currentSpeed > -this.carScript.maxReverseSpeed)
			{
				this.wheelCollider.brakeTorque = 0f;
				this.wheelCollider.motorTorque = this.carScript.maxTorque * DebugController.Global.torqueMultiplier * this.carScript.lowSpeedTorqueMultiplier * num2;
				this.wheelCollider.wheelDampingRate = Mathf.Lerp(this.wheelCollider.wheelDampingRate, 0f, Time.fixedDeltaTime * 5f);
				return;
			}
			this.wheelCollider.wheelDampingRate = Mathf.Lerp(this.wheelCollider.wheelDampingRate, 80f, Time.fixedDeltaTime * 30f);
			this.wheelCollider.motorTorque = 0f;
			if (flag2)
			{
				this.wheelCollider.brakeTorque = 0f;
			}
			else
			{
				this.wheelCollider.brakeTorque = ((!flag) ? this.brakeForce : (this.brakeForce * 4f));
			}
		}
		else
		{
			this.wheelCollider.wheelDampingRate = Mathf.Lerp(this.wheelCollider.wheelDampingRate, 80f, Time.fixedDeltaTime * 30f);
			this.wheelCollider.motorTorque = 0f;
			this.wheelCollider.brakeTorque = this.brakeForce;
		}
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x0012AAE4 File Offset: 0x00128EE4
	public void HandBrake()
	{
		if (!this.isBeingDriven)
		{
			return;
		}
		if (this.carScript.braked)
		{
			if (this.carScript.currentSpeed <= 1f)
			{
				if (this.carScript.currentSpeed < 0f)
				{
				}
			}
			this.wheelCollider.motorTorque = 0f;
			WheelFrictionCurve forwardFriction = this.wheelCollider.forwardFriction;
			forwardFriction.stiffness = 1f;
			this.wheelCollider.forwardFriction = forwardFriction;
			if (this.carScript.currentSpeed >= 1f || this.carScript.currentSpeed > -1f)
			{
			}
		}
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x0012ABA4 File Offset: 0x00128FA4
	public void HandBrakeOn()
	{
		if (!this.wheelCollider)
		{
			return;
		}
		base.gameObject.GetComponent<WheelCollider>().brakeTorque = float.PositiveInfinity;
		WheelFrictionCurve sidewaysFriction = this.wheelCollider.sidewaysFriction;
		sidewaysFriction.stiffness = 10f;
		this.wheelCollider.sidewaysFriction = sidewaysFriction;
		WheelFrictionCurve forwardFriction = this.wheelCollider.forwardFriction;
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x0012AC08 File Offset: 0x00129008
	public void HandBrakeOff()
	{
		base.gameObject.GetComponent<WheelCollider>().brakeTorque = 0f;
		WheelFrictionCurve sidewaysFriction = this.wheelCollider.sidewaysFriction;
		sidewaysFriction.stiffness = 10f;
		this.wheelCollider.sidewaysFriction = sidewaysFriction;
		WheelFrictionCurve forwardFriction = this.wheelCollider.forwardFriction;
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x0012AC5A File Offset: 0x0012905A
	public void NoClipFalse()
	{
		this.noClip = false;
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x0012AC63 File Offset: 0x00129063
	public void NoClipTrue()
	{
		this.noClip = true;
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x0012AC6C File Offset: 0x0012906C
	private void StiffnessCode()
	{
		if (this.carScript.carLogic.GetComponent<CarPerformanceC>().frontLeftTyre == null)
		{
			return;
		}
		WheelFrictionCurve sidewaysFriction = this.wheelCollider.sidewaysFriction;
		sidewaysFriction.stiffness = ((this.carScript.currentSpeed >= (float)this.stiffSpeed) ? this.sidewaysStiffness : (this.sidewaysStiffness / 2f));
		WheelFrictionCurve forwardFriction = this.wheelCollider.forwardFriction;
		float num = 0f;
		if (this.wheelNumber == 1 && this.carScript.carLogic.GetComponent<CarPerformanceC>().frontLeftTyre)
		{
			num = this.carScript.carLogic.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>().Condition;
		}
		if (this.wheelNumber == 2 && this.carScript.carLogic.GetComponent<CarPerformanceC>().frontRightTyre)
		{
			num = this.carScript.carLogic.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>().Condition;
		}
		if (this.wheelNumber == 3 && this.carScript.carLogic.GetComponent<CarPerformanceC>().rearLeftTyre)
		{
			num = this.carScript.carLogic.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>().Condition;
		}
		if (this.wheelNumber == 4 && this.carScript.carLogic.GetComponent<CarPerformanceC>().rearRightTyre)
		{
			num = this.carScript.carLogic.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>().Condition;
		}
		if (num <= 0f)
		{
			forwardFriction.stiffness = 0.3f;
			sidewaysFriction.stiffness = 0.1f;
			this.wheelCollider.radius = 0.4f;
		}
		else
		{
			forwardFriction.stiffness = ((!this.carScript.braked) ? this.forwardStiffness : 1f);
			this.wheelCollider.radius = 0.55f;
		}
		this.wheelCollider.forwardFriction = forwardFriction;
		this.wheelCollider.sidewaysFriction = sidewaysFriction;
	}

	// Token: 0x040010DA RID: 4314
	public WheelCollider[] frontWheels;

	// Token: 0x040010DB RID: 4315
	public GameObject playerCam;

	// Token: 0x040010DC RID: 4316
	public float padTurningSensitivity = 1f;

	// Token: 0x040010DD RID: 4317
	public WheelScriptPCC.wheelType typeOfWheel;

	// Token: 0x040010DE RID: 4318
	public bool handBreakable;

	// Token: 0x040010DF RID: 4319
	public bool invertSteer;

	// Token: 0x040010E0 RID: 4320
	public Transform wheelTransform;

	// Token: 0x040010E1 RID: 4321
	public bool isBeingDriven;

	// Token: 0x040010E2 RID: 4322
	public bool isBeingPushed;

	// Token: 0x040010E3 RID: 4323
	public Transform steeringwheelTransform;

	// Token: 0x040010E4 RID: 4324
	private float speedFactor;

	// Token: 0x040010E5 RID: 4325
	public WheelCollider wheelCollider;

	// Token: 0x040010E6 RID: 4326
	private CarControleScriptC carScript;

	// Token: 0x040010E7 RID: 4327
	public float mySidewayFriction;

	// Token: 0x040010E8 RID: 4328
	public float myForwardFriction;

	// Token: 0x040010E9 RID: 4329
	public float slipSidewayFriction;

	// Token: 0x040010EA RID: 4330
	public float slipForwardFriction;

	// Token: 0x040010EB RID: 4331
	public float extremumValue;

	// Token: 0x040010EC RID: 4332
	public float extremumSlip;

	// Token: 0x040010ED RID: 4333
	public float asymptoteSlip;

	// Token: 0x040010EE RID: 4334
	[HideInInspector]
	public GameObject director;

	// Token: 0x040010EF RID: 4335
	public bool noClip;

	// Token: 0x040010F0 RID: 4336
	public bool keyboardInput;

	// Token: 0x040010F1 RID: 4337
	public float currentSteerSensitivity;

	// Token: 0x040010F2 RID: 4338
	public float steerSensitivityValue;

	// Token: 0x040010F3 RID: 4339
	public int wheelNumber;

	// Token: 0x040010F4 RID: 4340
	public GameObject[] flatTyreAudio = new GameObject[0];

	// Token: 0x040010F5 RID: 4341
	private bool isFlatPlaying;

	// Token: 0x040010F6 RID: 4342
	public bool volumeLower;

	// Token: 0x040010F7 RID: 4343
	public float prevSteerAngel;

	// Token: 0x040010F8 RID: 4344
	private float dryRate = 1500f;

	// Token: 0x040010F9 RID: 4345
	public float savedLowSpeed;

	// Token: 0x040010FA RID: 4346
	public float newBrake;

	// Token: 0x040010FB RID: 4347
	public float brakeForce = 100f;

	// Token: 0x040010FC RID: 4348
	public float carSpeed;

	// Token: 0x040010FD RID: 4349
	public int stiffSpeed = 25;

	// Token: 0x040010FE RID: 4350
	public float forwardStiffness = 1f;

	// Token: 0x040010FF RID: 4351
	public float sidewaysStiffness;

	// Token: 0x04001100 RID: 4352
	public float wetAmount;

	// Token: 0x0200012F RID: 303
	[AddComponentMenu("CarPhys/Scripts/Wheel Script")]
	public enum wheelType
	{
		// Token: 0x04001102 RID: 4354
		Steer,
		// Token: 0x04001103 RID: 4355
		SteerAndMotor,
		// Token: 0x04001104 RID: 4356
		Motor,
		// Token: 0x04001105 RID: 4357
		JustAWheel
	}
}
