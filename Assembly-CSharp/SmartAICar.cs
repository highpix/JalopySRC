using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000FA RID: 250
[RequireComponent(typeof(Rigidbody))]
public class SmartAICar : MonoBehaviour
{
	// Token: 0x060009E7 RID: 2535 RVA: 0x000EA6BC File Offset: 0x000E8ABC
	private void Start()
	{
		this.SetChasis();
		this.SetWheelFrictions();
		this.SoundsInitialize();
		this.WheelTypeInit();
		this.GearInit();
		if (this.WheelSlipPrefab)
		{
			this.SmokeInit();
		}
		this.dynamicCOM = new GameObject("Dynamic Com").transform;
		this.dynamicCOM.parent = base.transform;
		this.myRigidbody = base.GetComponent<Rigidbody>();
		Renderer[] componentsInChildren = base.GetComponentsInChildren<Renderer>();
		if (componentsInChildren.Length > 0)
		{
			Array.Sort<Renderer>(componentsInChildren, (Renderer r1, Renderer r2) => r2.bounds.size.magnitude.CompareTo(r1.bounds.size.magnitude));
			this.vehicleSizeX = componentsInChildren[0].bounds.size.x;
			this.vehicleSizeY = componentsInChildren[0].bounds.size.y;
			this.vehicleSizeZ = componentsInChildren[0].bounds.size.z;
		}
		base.GetComponent<Rigidbody>().centerOfMass = new Vector3(this.COM.localPosition.x * base.transform.localScale.x, this.COM.localPosition.y * base.transform.localScale.y, this.COM.localPosition.z * base.transform.localScale.z);
		base.GetComponent<Rigidbody>().maxAngularVelocity = 3f;
	}

	// Token: 0x060009E8 RID: 2536 RVA: 0x000EA85C File Offset: 0x000E8C5C
	private void SetChasis()
	{
		int num = UnityEngine.Random.Range(0, this.chasisMesh.Length);
		this.initialMesh.GetComponent<MeshFilter>().mesh = this.chasisMesh[num];
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x000EA890 File Offset: 0x000E8C90
	private void SetWheelFrictions()
	{
		this.RearLeftFriction = this.RearLeftWheelCollider.sidewaysFriction;
		this.RearRightFriction = this.RearRightWheelCollider.sidewaysFriction;
		this.FrontLeftFriction = this.FrontLeftWheelCollider.sidewaysFriction;
		this.FrontRightFriction = this.FrontRightWheelCollider.sidewaysFriction;
		this.StiffnessRear = this.RearLeftWheelCollider.sidewaysFriction.stiffness;
		this.StiffnessFront = this.FrontLeftWheelCollider.sidewaysFriction.stiffness;
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x000EA914 File Offset: 0x000E8D14
	public void VolumeLower()
	{
		this.volumeLower = true;
		this.engineAudio.GetComponent<AudioSource>().volume = 0.4f;
		this.skidAudio.GetComponent<AudioSource>().volume = 0.4f;
		this.crashAudio.GetComponent<AudioSource>().volume = 0.4f;
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x000EA968 File Offset: 0x000E8D68
	public void VolumeHigher()
	{
		this.volumeLower = false;
		this.engineAudio.GetComponent<AudioSource>().volume = 1f;
		this.skidAudio.GetComponent<AudioSource>().volume = 1f;
		this.crashAudio.GetComponent<AudioSource>().volume = 1f;
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x000EA9BC File Offset: 0x000E8DBC
	private void SoundsInitialize()
	{
		this.engineAudio = new GameObject("EngineSound");
		this.engineAudio.transform.position = base.transform.position;
		this.engineAudio.transform.rotation = base.transform.rotation;
		this.engineAudio.transform.parent = base.transform;
		this.engineAudio.AddComponent<AudioSource>();
		this.engineAudio.GetComponent<AudioSource>().spatialBlend = 1f;
		this.engineAudio.GetComponent<AudioSource>().minDistance = 5f;
		this.engineAudio.GetComponent<AudioSource>().maxDistance = 50f;
		this.engineAudio.GetComponent<AudioSource>().clip = this.engineClip;
		this.engineAudio.GetComponent<AudioSource>().loop = true;
		this.engineAudio.GetComponent<AudioSource>().Play();
		this.skidAudio = new GameObject("SkidSound");
		this.skidAudio.transform.position = base.transform.position;
		this.skidAudio.transform.rotation = base.transform.rotation;
		this.skidAudio.transform.parent = base.transform;
		this.skidAudio.AddComponent<AudioSource>();
		this.skidAudio.GetComponent<AudioSource>().spatialBlend = 1f;
		this.skidAudio.GetComponent<AudioSource>().minDistance = 10f;
		this.skidAudio.GetComponent<AudioSource>().maxDistance = 50f;
		this.skidAudio.GetComponent<AudioSource>().volume = 0f;
		this.skidAudio.GetComponent<AudioSource>().clip = this.skidClip;
		this.skidAudio.GetComponent<AudioSource>().loop = true;
		this.skidAudio.GetComponent<AudioSource>().Play();
		this.crashAudio = new GameObject("CrashSound");
		this.crashAudio.transform.position = base.transform.position;
		this.crashAudio.transform.rotation = base.transform.rotation;
		this.crashAudio.transform.parent = base.transform;
		this.crashAudio.AddComponent<AudioSource>();
		this.crashAudio.GetComponent<AudioSource>().spatialBlend = 1f;
		this.crashAudio.GetComponent<AudioSource>().minDistance = 10f;
		this.crashAudio.GetComponent<AudioSource>().maxDistance = 50f;
	}

	// Token: 0x060009ED RID: 2541 RVA: 0x000EAC44 File Offset: 0x000E9044
	private void WheelTypeInit()
	{
		SmartAICar.WheelType wheelTypeChoise = this._wheelTypeChoise;
		if (wheelTypeChoise != SmartAICar.WheelType.FWD)
		{
			if (wheelTypeChoise == SmartAICar.WheelType.RWD)
			{
				this.fwd = false;
				this.rwd = true;
			}
		}
		else
		{
			this.fwd = true;
			this.rwd = false;
		}
	}

	// Token: 0x060009EE RID: 2542 RVA: 0x000EAC90 File Offset: 0x000E9090
	private void GearInit()
	{
		this.GearRatio = new float[this.EngineTorqueCurve.length];
		for (int i = 0; i < this.EngineTorqueCurve.length; i++)
		{
			this.GearRatio[i] = this.EngineTorqueCurve.keys[i].value;
		}
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x000EACF0 File Offset: 0x000E90F0
	private void SmokeInit()
	{
		UnityEngine.Object.Instantiate<GameObject>(this.WheelSlipPrefab, this.FrontRightWheelCollider.transform.position, base.transform.rotation);
		UnityEngine.Object.Instantiate<GameObject>(this.WheelSlipPrefab, this.FrontLeftWheelCollider.transform.position, base.transform.rotation);
		UnityEngine.Object.Instantiate<GameObject>(this.WheelSlipPrefab, this.RearRightWheelCollider.transform.position, base.transform.rotation);
		UnityEngine.Object.Instantiate<GameObject>(this.WheelSlipPrefab, this.RearLeftWheelCollider.transform.position, base.transform.rotation);
		foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
		{
			if (gameObject.name == "WheelSlip(Clone)")
			{
				this.WheelParticles.Add(gameObject);
			}
		}
		this.WheelParticles[0].transform.position = this.FrontRightWheelCollider.transform.position;
		this.WheelParticles[1].transform.position = this.FrontLeftWheelCollider.transform.position;
		this.WheelParticles[2].transform.position = this.RearRightWheelCollider.transform.position;
		this.WheelParticles[3].transform.position = this.RearLeftWheelCollider.transform.position;
		this.WheelParticles[0].transform.parent = this.FrontRightWheelCollider.transform;
		this.WheelParticles[1].transform.parent = this.FrontLeftWheelCollider.transform;
		this.WheelParticles[2].transform.parent = this.RearRightWheelCollider.transform;
		this.WheelParticles[3].transform.parent = this.RearLeftWheelCollider.transform;
	}

	// Token: 0x060009F0 RID: 2544 RVA: 0x000EAF04 File Offset: 0x000E9304
	private void OnGUI()
	{
		if (this.GUIenabled)
		{
			GUI.color = Color.blue;
			GUI.Button(new Rect(48f, 48f, Mathf.Lerp(0f, 500f, this.Speed / this.maxSpeed), 30f), string.Empty);
			GUI.Box(new Rect(48f, 48f, 500f, 30f), Mathf.Round(this.Speed) + string.Empty);
			GUI.Box(new Rect(270f, 10f, 50f, 30f), "Speed");
			GUI.color = Color.red;
			GUI.Button(new Rect(48f, 125f, Mathf.Lerp(0f, 500f, this.BrakePower / 1000f), 30f), string.Empty);
			GUI.Box(new Rect(48f, 125f, 500f, 30f), Mathf.Round(this.BrakePower) + string.Empty);
			GUI.Box(new Rect(255f, 85f, 90f, 30f), "BrakePower");
			GUI.Box(new Rect(48f, 200f, 300f, 100f), "InputSteer");
			GUI.HorizontalSlider(new Rect(48f, 250f, 300f, 100f), this.inputSteer, -2f, 2f);
		}
	}

	// Token: 0x060009F1 RID: 2545 RVA: 0x000EB0B0 File Offset: 0x000E94B0
	private void OnDrawGizmos()
	{
		if (this.waypoints.Count > 0 && this.waypoints[0])
		{
			Gizmos.DrawIcon(this.waypoints[0].transform.position, "FinishIcon.png", false);
		}
		for (int i = 0; i < this.waypoints.Count; i++)
		{
			if (i < this.waypoints.Count - 1 && this.waypoints[i] && this.waypoints[i + 1])
			{
				Gizmos.color = new Color(0f, 1f, 1f, 0.3f);
				Gizmos.DrawSphere(this.waypoints[i + 1].transform.position, 2f);
				Gizmos.DrawWireSphere(this.waypoints[i + 1].transform.position, (float)this.nextWaypointPassRadius);
				if (this.waypoints.Count > 0)
				{
					Gizmos.color = Color.green;
					if (i < this.waypoints.Count - 1)
					{
						Gizmos.DrawLine(this.waypoints[i].position, this.waypoints[i + 1].position);
					}
					else
					{
						Gizmos.DrawLine(this.waypoints[i].position, this.waypoints[0].position);
					}
				}
			}
		}
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x000EB24C File Offset: 0x000E964C
	private void Update()
	{
		this.myRigidbody.isKinematic = false;
		this.myRigidbody.useGravity = true;
		this.myRigidbody.constraints = RigidbodyConstraints.None;
		this.WheelAlign();
		this.SkidAudio();
		if (this.hornTimer > 0f)
		{
			this.hornTimer -= Time.deltaTime;
		}
		if (this.chassis && this.WheelSlipPrefab)
		{
			this.SmokeInstantiateRate();
		}
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x000EB2D1 File Offset: 0x000E96D1
	private void FixedUpdate()
	{
		this.Engine();
		this.Navigation();
		this.FixedRaycasts();
	}

	// Token: 0x060009F4 RID: 2548 RVA: 0x000EB2E8 File Offset: 0x000E96E8
	private void Engine()
	{
		if (this.Speed == 0f)
		{
			this.removalTimer += Time.deltaTime;
			if (this.removalTimer > 10f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		else if (this.removalTimer > 0f)
		{
			this.removalTimer = 0f;
		}
		if (this.EngineTorqueCurve.keys.Length >= 2)
		{
			if (this.CurrentGear == this.EngineTorqueCurve.length - 2)
			{
				this.gearTimeMultiplier = -this.EngineTorqueCurve[this.CurrentGear].time / this.gearShiftRate / (this.maxSpeed * 3f) + 1f;
			}
			else
			{
				this.gearTimeMultiplier = -this.EngineTorqueCurve[this.CurrentGear].time / (this.maxSpeed * 3f) + 1f;
			}
		}
		else
		{
			this.gearTimeMultiplier = 1f;
			Debug.Log("You DID NOT CREATE any engine torque curve keys!, Please create 1 key at least...");
		}
		this.Speed = base.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
		this.acceleration = (base.GetComponent<Rigidbody>().velocity - this.lastVelocity) / Time.fixedDeltaTime;
		this.lastVelocity = base.GetComponent<Rigidbody>().velocity * 2f;
		if (this.carAhead || this.carAhead2 || this.carAhead3)
		{
			this.myRigidbody.drag = Mathf.Clamp01(base.transform.InverseTransformDirection(this.acceleration).z / 2f);
		}
		else
		{
			this.myRigidbody.drag = Mathf.Clamp01(base.transform.InverseTransformDirection(this.acceleration).z / 50f);
		}
		if (this.EngineTorqueCurve.keys.Length >= 2)
		{
			this.EngineRPM = Mathf.Abs(this.FrontRightWheelCollider.rpm * this.gearShiftRate * Mathf.Clamp01(this.inputTorque) + this.FrontLeftWheelCollider.rpm * this.gearShiftRate * Mathf.Clamp01(this.inputTorque)) / 2f * this.GearRatio[this.CurrentGear] * this.gearTimeMultiplier + this.MinEngineRPM;
		}
		else
		{
			this.EngineRPM = Mathf.Abs(this.FrontRightWheelCollider.rpm * this.gearShiftRate * Mathf.Clamp01(this.inputTorque) + this.FrontLeftWheelCollider.rpm * this.gearShiftRate * Mathf.Clamp01(this.inputTorque)) / 2f * this.gearTimeMultiplier + this.MinEngineRPM;
		}
		if (this.Speed < this.HighSpeedSteerAngleAtSpeed)
		{
			this.FrontLeftWheelCollider.steerAngle = this.SteerAngle * this.inputSteer;
			this.FrontRightWheelCollider.steerAngle = this.SteerAngle * this.inputSteer;
		}
		else
		{
			this.FrontLeftWheelCollider.steerAngle = this.HighSpeedSteerAngle * this.inputSteer;
			this.FrontRightWheelCollider.steerAngle = this.HighSpeedSteerAngle * this.inputSteer;
		}
		this.engineAudio.GetComponent<AudioSource>().volume = Mathf.Lerp(this.engineAudio.GetComponent<AudioSource>().volume, Mathf.Clamp(this.inputTorque, 0.25f, 1f), Time.deltaTime * 5f);
		this.engineAudio.GetComponent<AudioSource>().pitch = Mathf.Lerp(1f, 2f, (this.EngineRPM - this.MinEngineRPM / 1.5f) / (this.MaxEngineRPM + this.MinEngineRPM));
		float t = 1f;
		if (this.Speed < 40f)
		{
			t = this.Speed / this.maxSpeed;
		}
		this.torqueMultiplier = Mathf.Lerp(6f, 1f, t);
		if (this.rwd)
		{
			if (this.Speed > this.maxSpeed)
			{
				this.RearLeftWheelCollider.motorTorque = 0f;
				this.RearRightWheelCollider.motorTorque = 0f;
			}
			else if (!this.reversing)
			{
				if (this.carAhead || this.carAhead2 || this.carAhead3)
				{
					this.RearLeftWheelCollider.motorTorque = 0f;
					this.RearRightWheelCollider.motorTorque = 0f;
					this.FrontLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
					this.FrontRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
					this.RearLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
					this.RearRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				}
				else
				{
					this.FrontLeftWheelCollider.brakeTorque = 0f;
					this.FrontRightWheelCollider.brakeTorque = 0f;
					this.RearLeftWheelCollider.brakeTorque = 0f;
					this.RearRightWheelCollider.brakeTorque = 0f;
					this.RearLeftWheelCollider.motorTorque = this.EngineTorque * Mathf.Clamp(this.inputTorque, 0f, 1f) * this.EngineTorqueCurve.Evaluate(this.Speed) * this.torqueMultiplier;
					this.RearRightWheelCollider.motorTorque = this.EngineTorque * Mathf.Clamp(this.inputTorque, 0f, 1f) * this.EngineTorqueCurve.Evaluate(this.Speed) * this.torqueMultiplier;
				}
			}
			else if (this.carAhead || this.carAhead2 || this.carAhead3)
			{
				this.RearLeftWheelCollider.motorTorque = 0f;
				this.RearRightWheelCollider.motorTorque = 0f;
			}
			else
			{
				this.RearLeftWheelCollider.motorTorque = this.EngineTorque * -this.EngineTorqueCurve.Evaluate(this.Speed) / 4f;
				this.RearRightWheelCollider.motorTorque = this.EngineTorque * -this.EngineTorqueCurve.Evaluate(this.Speed) / 4f;
			}
		}
		if (this.fwd)
		{
			if (this.Speed > this.maxSpeed)
			{
				this.FrontLeftWheelCollider.motorTorque = 0f;
				this.FrontRightWheelCollider.motorTorque = 0f;
				this.FrontLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				this.FrontRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				this.RearLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				this.RearRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
			}
			else if (!this.reversing)
			{
				if (this.carAhead || this.carAhead2 || this.carAhead3)
				{
					this.FrontLeftWheelCollider.motorTorque = 0f;
					this.FrontRightWheelCollider.motorTorque = 0f;
					this.FrontLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
					this.FrontRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
					this.RearLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
					this.RearRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				}
				else
				{
					this.FrontLeftWheelCollider.brakeTorque = 0f;
					this.FrontRightWheelCollider.brakeTorque = 0f;
					this.RearLeftWheelCollider.brakeTorque = 0f;
					this.RearRightWheelCollider.brakeTorque = 0f;
					this.FrontLeftWheelCollider.motorTorque = this.EngineTorque * Mathf.Clamp(this.inputTorque, 0f, 1f) * this.EngineTorqueCurve.Evaluate(this.Speed) * this.torqueMultiplier;
					this.FrontRightWheelCollider.motorTorque = this.EngineTorque * Mathf.Clamp(this.inputTorque, 0f, 1f) * this.EngineTorqueCurve.Evaluate(this.Speed) * this.torqueMultiplier;
				}
			}
			else if (this.carAhead || this.carAhead2 || this.carAhead3)
			{
				this.FrontLeftWheelCollider.motorTorque = 0f;
				this.FrontRightWheelCollider.motorTorque = 0f;
				this.FrontLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				this.FrontRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				this.RearLeftWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
				this.RearRightWheelCollider.brakeTorque = (float)this.carAheadStopSpeed;
			}
			else
			{
				this.FrontLeftWheelCollider.brakeTorque = 0f;
				this.FrontRightWheelCollider.brakeTorque = 0f;
				this.RearLeftWheelCollider.brakeTorque = 0f;
				this.RearRightWheelCollider.brakeTorque = 0f;
				this.FrontLeftWheelCollider.motorTorque = this.EngineTorque * (-this.EngineTorqueCurve.Evaluate(this.Speed) / 4f);
				this.FrontRightWheelCollider.motorTorque = this.EngineTorque * (-this.EngineTorqueCurve.Evaluate(this.Speed) / 4f);
			}
		}
		this.RearLeftWheelCollider.brakeTorque = this.BrakePower;
		this.RearRightWheelCollider.brakeTorque = this.BrakePower;
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x000EBC68 File Offset: 0x000EA068
	private void ShiftGears()
	{
		for (int i = 0; i < this.EngineTorqueCurve.length; i++)
		{
			if (this.EngineTorqueCurve.Evaluate(this.Speed) < this.EngineTorqueCurve.keys[i].value)
			{
				this.CurrentGear = i;
			}
		}
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x000EBCC4 File Offset: 0x000EA0C4
	private void Navigation()
	{
		if (!this.reversing)
		{
			this.inputSteer = Mathf.Clamp(this.newInputSteer, -2f, 2f);
		}
		else
		{
			this.inputSteer = Mathf.Clamp(-this.newInputSteer, -2f, 2f);
		}
		if (this.hardBrake)
		{
			this.BrakePower = 10000f;
			this.inputTorque = 0f;
		}
		else
		{
			if (this.carAhead || this.carAhead2 || this.carAhead3)
			{
				this.inputTorque = 0f;
				this.BrakePower = 10000f;
				this.inputSteer = 0f;
				return;
			}
			if (this.Speed >= 25f)
			{
				this.BrakePower = Mathf.Abs(this.inputSteer * this.brakeRaycast) + this.longRayBraking;
			}
			else
			{
				if (this.BrakePower < 0.1f)
				{
					this.BrakePower = 0f;
				}
				this.BrakePower = Mathf.Lerp(this.BrakePower, 0f, Time.deltaTime * 10f);
				this.inputTorque = Mathf.Clamp(500f, 0.5f, 1f);
			}
		}
	}

	// Token: 0x060009F7 RID: 2551 RVA: 0x000EBE0B File Offset: 0x000EA20B
	private void Resetting()
	{
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x000EBE10 File Offset: 0x000EA210
	private void WheelAlign()
	{
		this.FrontLeftWheelTransform.transform.rotation = this.FrontLeftWheelCollider.transform.rotation * Quaternion.Euler(this.RotationValueFL, this.FrontLeftWheelCollider.steerAngle, this.FrontLeftWheelCollider.transform.rotation.z);
		this.RotationValueFL += this.FrontLeftWheelCollider.rpm * 6f * Time.deltaTime;
		this.FrontRightWheelTransform.transform.rotation = this.FrontRightWheelCollider.transform.rotation * Quaternion.Euler(this.RotationValueFR, this.FrontRightWheelCollider.steerAngle, this.FrontRightWheelCollider.transform.rotation.z);
		this.RotationValueFR += this.FrontRightWheelCollider.rpm * 6f * Time.deltaTime;
		this.RearLeftWheelTransform.transform.rotation = this.RearLeftWheelCollider.transform.rotation * Quaternion.Euler(this.RotationValueRL, 0f, this.RearLeftWheelCollider.transform.rotation.z);
		this.RotationValueRL += this.RearLeftWheelCollider.rpm * 6f * Time.deltaTime;
		this.RearRightWheelTransform.transform.rotation = this.RearRightWheelCollider.transform.rotation * Quaternion.Euler(this.RotationValueRR, 0f, this.RearRightWheelCollider.transform.rotation.z);
		this.RotationValueRR += this.RearRightWheelCollider.rpm * 6f * Time.deltaTime;
		Vector3 vector = this.FrontLeftWheelCollider.transform.TransformPoint(this.FrontLeftWheelCollider.center);
		WheelHit wheelHit;
		this.FrontLeftWheelCollider.GetGroundHit(out wheelHit);
		RaycastHit raycastHit;
		if (Physics.Raycast(vector, -this.FrontLeftWheelCollider.transform.up, out raycastHit, (this.FrontLeftWheelCollider.suspensionDistance + this.FrontLeftWheelCollider.radius) * base.transform.localScale.y))
		{
			this.FrontLeftWheelTransform.transform.position = raycastHit.point + this.FrontLeftWheelCollider.transform.up * this.FrontLeftWheelCollider.radius * base.transform.localScale.y;
			float num = (-this.FrontLeftWheelCollider.transform.InverseTransformPoint(wheelHit.point).y - this.FrontLeftWheelCollider.radius) / this.FrontLeftWheelCollider.suspensionDistance;
			Debug.DrawLine(wheelHit.point, wheelHit.point + this.FrontLeftWheelCollider.transform.up * (wheelHit.force / 8000f), ((double)num > 0.0) ? Color.white : Color.magenta);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.FrontLeftWheelCollider.transform.forward * wheelHit.forwardSlip, Color.green);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.FrontLeftWheelCollider.transform.right * wheelHit.sidewaysSlip, Color.red);
		}
		else
		{
			this.FrontLeftWheelTransform.transform.position = vector - this.FrontLeftWheelCollider.transform.up * this.FrontLeftWheelCollider.suspensionDistance * base.transform.localScale.y;
			this.FrontLeftFriction.stiffness = 0f;
		}
		Vector3 vector2 = this.FrontRightWheelCollider.transform.TransformPoint(this.FrontRightWheelCollider.center);
		this.FrontRightWheelCollider.GetGroundHit(out wheelHit);
		if (Physics.Raycast(vector2, -this.FrontRightWheelCollider.transform.up, out raycastHit, (this.FrontRightWheelCollider.suspensionDistance + this.FrontRightWheelCollider.radius) * base.transform.localScale.y))
		{
			this.FrontRightWheelTransform.transform.position = raycastHit.point + this.FrontRightWheelCollider.transform.up * this.FrontRightWheelCollider.radius * base.transform.localScale.y;
			float num2 = (-this.FrontRightWheelCollider.transform.InverseTransformPoint(wheelHit.point).y - this.FrontRightWheelCollider.radius) / this.FrontRightWheelCollider.suspensionDistance;
			Debug.DrawLine(wheelHit.point, wheelHit.point + this.FrontRightWheelCollider.transform.up * (wheelHit.force / 8000f), ((double)num2 > 0.0) ? Color.white : Color.magenta);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.FrontRightWheelCollider.transform.forward * wheelHit.forwardSlip, Color.green);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.FrontRightWheelCollider.transform.right * wheelHit.sidewaysSlip, Color.red);
		}
		else
		{
			this.FrontRightWheelTransform.transform.position = vector2 - this.FrontRightWheelCollider.transform.up * this.FrontRightWheelCollider.suspensionDistance * base.transform.localScale.y;
			this.FrontRightFriction.stiffness = 0f;
		}
		this.RotationValueFR += this.FrontRightWheelCollider.rpm * 6f * Time.deltaTime;
		this.FrontRightWheelTransform.transform.rotation = this.FrontRightWheelCollider.transform.rotation * Quaternion.Euler(this.RotationValueFR, this.FrontRightWheelCollider.steerAngle, this.FrontRightWheelCollider.transform.rotation.z);
		Vector3 vector3 = this.RearLeftWheelCollider.transform.TransformPoint(this.RearLeftWheelCollider.center);
		this.RearLeftWheelCollider.GetGroundHit(out wheelHit);
		if (Physics.Raycast(vector3, -this.RearLeftWheelCollider.transform.up, out raycastHit, (this.RearLeftWheelCollider.suspensionDistance + this.RearLeftWheelCollider.radius) * base.transform.localScale.y))
		{
			this.RearLeftWheelTransform.transform.position = raycastHit.point + this.RearLeftWheelCollider.transform.up * this.RearLeftWheelCollider.radius * base.transform.localScale.y;
			float num3 = (-this.RearLeftWheelCollider.transform.InverseTransformPoint(wheelHit.point).y - this.RearLeftWheelCollider.radius) / this.RearLeftWheelCollider.suspensionDistance;
			Debug.DrawLine(wheelHit.point, wheelHit.point + this.RearLeftWheelCollider.transform.up * (wheelHit.force / 8000f), ((double)num3 > 0.0) ? Color.white : Color.magenta);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.RearLeftWheelCollider.transform.forward * wheelHit.forwardSlip, Color.green);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.RearLeftWheelCollider.transform.right * wheelHit.sidewaysSlip, Color.red);
		}
		else
		{
			this.RearLeftWheelTransform.transform.position = vector3 - this.RearLeftWheelCollider.transform.up * this.RearLeftWheelCollider.suspensionDistance * base.transform.localScale.y;
			this.RearLeftFriction.stiffness = 0f;
		}
		this.RearLeftWheelCollider.GetGroundHit(out wheelHit);
		Vector3 vector4 = this.RearRightWheelCollider.transform.TransformPoint(this.RearRightWheelCollider.center);
		this.RearRightWheelCollider.GetGroundHit(out wheelHit);
		if (Physics.Raycast(vector4, -this.RearRightWheelCollider.transform.up, out raycastHit, (this.RearRightWheelCollider.suspensionDistance + this.RearRightWheelCollider.radius) * base.transform.localScale.y))
		{
			this.RearRightWheelTransform.transform.position = raycastHit.point + this.RearRightWheelCollider.transform.up * this.RearRightWheelCollider.radius * base.transform.localScale.y;
			float num4 = (-this.RearRightWheelCollider.transform.InverseTransformPoint(wheelHit.point).y - this.RearRightWheelCollider.radius) / this.RearRightWheelCollider.suspensionDistance;
			Debug.DrawLine(wheelHit.point, wheelHit.point + this.RearRightWheelCollider.transform.up * (wheelHit.force / 8000f), ((double)num4 > 0.0) ? Color.white : Color.magenta);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.RearRightWheelCollider.transform.forward * wheelHit.forwardSlip, Color.green);
			Debug.DrawLine(wheelHit.point, wheelHit.point - this.RearRightWheelCollider.transform.right * wheelHit.sidewaysSlip, Color.red);
		}
		else
		{
			this.RearRightWheelTransform.transform.position = vector4 - this.RearRightWheelCollider.transform.up * this.RearRightWheelCollider.suspensionDistance * base.transform.localScale.y;
			this.RearRightFriction.stiffness = 0f;
		}
		this.RearRightWheelCollider.GetGroundHit(out wheelHit);
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x000EC96D File Offset: 0x000EAD6D
	private void WheelStiffness()
	{
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x000EC970 File Offset: 0x000EAD70
	private void FixedRaycasts()
	{
		bool flag = false;
		Vector3 point = base.transform.TransformDirection(new Vector3(0f, 0f, 1f));
		Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(25f, base.transform.up) * point * (float)this.wideRayDistance, Color.white);
		Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(-25f, base.transform.up) * point * (float)this.wideRayDistance, Color.white);
		Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(7f, base.transform.up) * point * (float)this.tightRayDistance, Color.white);
		Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(-7f, base.transform.up) * point * (float)this.tightRayDistance, Color.white);
		Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(0f, base.transform.up) * point * (float)this.longRayDistance, Color.white);
		Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(90f, base.transform.up) * point * (float)this.sideRayDistance, Color.white);
		Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(-90f, base.transform.up) * point * (float)this.sideRayDistance, Color.white);
		RaycastHit raycastHit;
		float num;
		bool flag2;
		if (Physics.Raycast(base.transform.position, Quaternion.AngleAxis(25f, base.transform.up) * point, out raycastHit, (float)this.wideRayDistance, this.raycastLayers))
		{
			if (raycastHit.transform.tag == "AICar" || raycastHit.transform.tag == "Player" || raycastHit.transform.tag == "CarLogic")
			{
				this.longRayBraking = 1000f;
				this.carAhead = true;
			}
			else
			{
				this.carAhead = false;
			}
			Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(25f, base.transform.up) * point * (float)this.wideRayDistance, Color.red);
			num = Mathf.Lerp(-0.5f, 0f, raycastHit.distance / (float)this.wideRayDistance);
			flag2 = true;
			this.wdRRayRed = true;
		}
		else
		{
			num = 0f;
			flag2 = false;
			this.wdRRayRed = false;
		}
		float num2;
		bool flag3;
		if (Physics.Raycast(base.transform.position, Quaternion.AngleAxis(-25f, base.transform.up) * point, out raycastHit, (float)this.wideRayDistance, this.raycastLayers))
		{
			if (raycastHit.transform.tag == "AICar" || raycastHit.transform.tag == "Player" || raycastHit.transform.tag == "CarLogic")
			{
				this.longRayBraking = 1000f;
				this.carAhead = true;
			}
			else
			{
				this.carAhead = false;
			}
			Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(-25f, base.transform.up) * point * (float)this.wideRayDistance, Color.red);
			num2 = Mathf.Lerp(0.5f, 0f, raycastHit.distance / (float)this.wideRayDistance);
			flag3 = true;
			this.wdLRayRed = true;
		}
		else
		{
			num2 = 0f;
			flag3 = false;
			this.wdLRayRed = false;
		}
		float num3;
		bool flag4;
		if (Physics.Raycast(base.transform.position, Quaternion.AngleAxis(7f, base.transform.up) * point, out raycastHit, (float)this.tightRayDistance, this.raycastLayers))
		{
			Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(7f, base.transform.up) * point * (float)this.tightRayDistance, Color.red);
			num3 = Mathf.Lerp(-1f, 0f, raycastHit.distance / (float)this.tightRayDistance);
			flag4 = true;
			this.tghtRRayRed = true;
			if (raycastHit.transform.tag == "AICar" || raycastHit.transform.tag == "Player" || raycastHit.transform.tag == "CarLogic")
			{
				Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(7f, base.transform.up) * point * (float)this.tightRayDistance, Color.magenta);
				this.longRayBraking = 1000f;
				this.carAhead2 = true;
			}
			else
			{
				this.carAhead2 = false;
			}
		}
		else
		{
			num3 = 0f;
			flag4 = false;
			this.tghtRRayRed = false;
			this.carAhead2 = false;
		}
		float num4;
		bool flag5;
		if (Physics.Raycast(base.transform.position, Quaternion.AngleAxis(-7f, base.transform.up) * point, out raycastHit, (float)this.tightRayDistance, this.raycastLayers))
		{
			Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(-7f, base.transform.up) * point * (float)this.tightRayDistance, Color.red);
			num4 = Mathf.Lerp(1f, 0f, raycastHit.distance / (float)this.tightRayDistance);
			flag5 = true;
			this.tghtLRayRed = true;
			if (raycastHit.transform.tag == "AICar" || raycastHit.transform.tag == "Player" || raycastHit.transform.tag == "CarLogic")
			{
				Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(-7f, base.transform.up) * point * (float)this.tightRayDistance, Color.magenta);
				this.longRayBraking = 1000f;
				this.carAhead3 = true;
			}
			else
			{
				this.carAhead3 = false;
			}
		}
		else
		{
			num4 = 0f;
			flag5 = false;
			this.tghtLRayRed = false;
			this.carAhead3 = false;
		}
		float num5;
		bool flag6;
		if (Physics.Raycast(base.transform.position, Quaternion.AngleAxis(90f, base.transform.up) * point, out raycastHit, (float)this.sideRayDistance, this.raycastLayers))
		{
			Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(90f, base.transform.up) * point * (float)this.sideRayDistance, Color.red);
			num5 = Mathf.Lerp(-0.5f, 0f, raycastHit.distance / (float)this.sideRayDistance);
			flag6 = true;
			this.rightRayRed = true;
		}
		else
		{
			num5 = 0f;
			flag6 = false;
			this.rightRayRed = false;
		}
		float num6;
		bool flag7;
		if (Physics.Raycast(base.transform.position, Quaternion.AngleAxis(-90f, base.transform.up) * point, out raycastHit, (float)this.sideRayDistance, this.raycastLayers))
		{
			Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(-90f, base.transform.up) * point * (float)this.sideRayDistance, Color.red);
			num6 = Mathf.Lerp(0.5f, 0f, raycastHit.distance / (float)this.sideRayDistance);
			flag7 = true;
			this.leftRayRed = true;
		}
		else
		{
			num6 = 0f;
			flag7 = false;
			this.leftRayRed = false;
		}
		if (Physics.Raycast(base.transform.position, Quaternion.AngleAxis(0f, base.transform.up) * point, out raycastHit, (float)this.longRayDistance, this.raycastLayers))
		{
			this.fwdRayRed = true;
			if (raycastHit.transform.tag == "AICar" || raycastHit.transform.tag == "Player" || raycastHit.transform.tag == "CarLogic")
			{
				Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(0f, base.transform.up) * point * (float)this.longRayDistance, Color.magenta);
				this.longRayBraking = 1000000f;
				this.carAhead = true;
				if (this.hornTimer <= 0.1f)
				{
					int num7 = UnityEngine.Random.Range(0, this.horns.Length - 1);
					if (!this.volumeLower)
					{
						base.GetComponent<AudioSource>().PlayOneShot(this.horns[num7], 1f);
					}
					else
					{
						base.GetComponent<AudioSource>().PlayOneShot(this.horns[num7], 0.4f);
					}
					float num8 = UnityEngine.Random.Range(3f, 8f);
					this.hornTimer = num8;
				}
			}
			else
			{
				Debug.DrawRay(base.transform.position, Quaternion.AngleAxis(0f, base.transform.up) * point * (float)this.longRayDistance, Color.red);
				this.longRayBraking = Mathf.Lerp(this.brakeRaycast, 0f, raycastHit.distance / (float)this.longRayDistance);
				this.carAhead = false;
			}
		}
		else
		{
			this.fwdRayRed = false;
			this.longRayBraking = 0f;
			this.reversing = false;
			this.carAhead = false;
		}
		if (flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag)
		{
			this.raycasting = true;
		}
		else
		{
			this.raycasting = false;
		}
		if (this.raycasting)
		{
			this.newInputSteer = num + num4 + num3 + num2 + num5 + num6;
		}
		else
		{
			this.newInputSteer = 0f;
		}
		if (!flag4 || !flag5)
		{
			this.resetTime = 0f;
		}
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x000ED4D4 File Offset: 0x000EB8D4
	private void SkidAudio()
	{
		WheelHit wheelHit;
		this.FrontRightWheelCollider.GetGroundHit(out wheelHit);
		if (Mathf.Abs(wheelHit.sidewaysSlip) > 5f || Mathf.Abs(wheelHit.forwardSlip) > 2.5f)
		{
			this.skidAudio.GetComponent<AudioSource>().volume = Mathf.Abs(wheelHit.sidewaysSlip) / 20f + Mathf.Abs(wheelHit.forwardSlip) / 20f;
		}
		else
		{
			this.skidAudio.GetComponent<AudioSource>().volume -= Time.deltaTime;
		}
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x000ED574 File Offset: 0x000EB974
	private void SmokeInstantiateRate()
	{
		if (this.WheelParticles.Count > 0)
		{
			WheelHit wheelHit;
			this.FrontRightWheelCollider.GetGroundHit(out wheelHit);
			if (Mathf.Abs(wheelHit.sidewaysSlip) > 5f || Mathf.Abs(wheelHit.forwardSlip) > 2.5f)
			{
				this.WheelParticles[0].GetComponent<ParticleEmitter>().emit = true;
			}
			else
			{
				this.WheelParticles[0].GetComponent<ParticleEmitter>().emit = false;
			}
			this.FrontLeftWheelCollider.GetGroundHit(out wheelHit);
			if (Mathf.Abs(wheelHit.sidewaysSlip) > 5f || Mathf.Abs(wheelHit.forwardSlip) > 2.5f)
			{
				this.WheelParticles[1].GetComponent<ParticleEmitter>().emit = true;
			}
			else
			{
				this.WheelParticles[1].GetComponent<ParticleEmitter>().emit = false;
			}
			this.RearRightWheelCollider.GetGroundHit(out wheelHit);
			if (Mathf.Abs(wheelHit.sidewaysSlip) > 5f || Mathf.Abs(wheelHit.forwardSlip) > 2.5f)
			{
				this.WheelParticles[2].GetComponent<ParticleEmitter>().emit = true;
			}
			else
			{
				this.WheelParticles[2].GetComponent<ParticleEmitter>().emit = false;
			}
			this.RearLeftWheelCollider.GetGroundHit(out wheelHit);
			if (Mathf.Abs(wheelHit.sidewaysSlip) > 5f || Mathf.Abs(wheelHit.forwardSlip) > 2.5f)
			{
				this.WheelParticles[3].GetComponent<ParticleEmitter>().emit = true;
			}
			else
			{
				this.WheelParticles[3].GetComponent<ParticleEmitter>().emit = false;
			}
		}
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x000ED748 File Offset: 0x000EBB48
	private void Chassis()
	{
		this.verticalLean = Mathf.Clamp(Mathf.Lerp(this.verticalLean, base.GetComponent<Rigidbody>().angularVelocity.x * this.chassisVerticalLean, Time.deltaTime * 5f), -3f, 3f);
		this.horizontalLean = Mathf.Clamp(Mathf.Lerp(this.horizontalLean, base.GetComponent<Rigidbody>().angularVelocity.y * this.chassisHorizontalLean, Time.deltaTime * 5f), -5f, 5f);
		Quaternion localRotation = Quaternion.Euler(this.verticalLean, this.chassis.transform.localRotation.y, this.horizontalLean);
		this.chassis.transform.localRotation = localRotation;
		this.dynamicCOM.localPosition = new Vector3(Mathf.Clamp(base.transform.InverseTransformDirection(base.GetComponent<Rigidbody>().angularVelocity).y * 1f, -this.vehicleSizeX / 15f, this.vehicleSizeX / 15f) + this.COM.localPosition.x, -Mathf.Abs(Mathf.Clamp(base.transform.InverseTransformDirection(base.GetComponent<Rigidbody>().angularVelocity).z * 10f, -this.vehicleSizeY / 5f, this.vehicleSizeY / 5f)) + this.COM.localPosition.y, Mathf.Clamp(base.transform.InverseTransformDirection(base.GetComponent<Rigidbody>().angularVelocity).x, -this.vehicleSizeZ / 15f, this.vehicleSizeZ / 15f) + this.COM.localPosition.z);
		this.dynamicCOM.rotation = base.transform.rotation;
		base.GetComponent<Rigidbody>().centerOfMass = new Vector3(this.dynamicCOM.localPosition.x * base.transform.localScale.x, this.dynamicCOM.localPosition.y * base.transform.localScale.y, this.dynamicCOM.localPosition.z * base.transform.localScale.z);
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x000ED9D4 File Offset: 0x000EBDD4
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "BrakeZone" && other.GetComponent<BrakeLogic>().roundaboutWait)
		{
			this.BrakePower = this.brakeZone;
			this.hardBrake = true;
		}
		else if (other.gameObject.tag == "BrakeZone" && this.Speed >= 25f)
		{
			this.BrakePower = this.brakeZone;
		}
		if (other.gameObject.tag == "BrakeZone" && !other.GetComponent<BrakeLogic>().roundaboutWait)
		{
			this.hardBrake = false;
		}
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x000EDA8C File Offset: 0x000EBE8C
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.contacts.Length > 0 && collision.relativeVelocity.magnitude > (float)this.crashSoundLimit && this.crashClips.Length > 0 && collision.contacts[0].thisCollider.gameObject.layer != LayerMask.NameToLayer("Wheel"))
		{
			this.crashAudio.GetComponent<AudioSource>().clip = this.crashClips[UnityEngine.Random.Range(0, this.crashClips.Length)];
			this.crashAudio.GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(1f, 1.2f);
			this.crashAudio.GetComponent<AudioSource>().Play();
		}
		if (collision.gameObject.layer == 12)
		{
			this.BrakePower = 10000f;
		}
	}

	// Token: 0x06000A00 RID: 2560 RVA: 0x000EDB6A File Offset: 0x000EBF6A
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "BrakeZone")
		{
			this.BrakePower = 0f;
		}
	}

	// Token: 0x04000D76 RID: 3446
	public int carAheadStopSpeed = -10;

	// Token: 0x04000D77 RID: 3447
	public int wideRayDistance = 20;

	// Token: 0x04000D78 RID: 3448
	public int tightRayDistance = 20;

	// Token: 0x04000D79 RID: 3449
	public int longRayDistance = 20;

	// Token: 0x04000D7A RID: 3450
	public int sideRayDistance = 4;

	// Token: 0x04000D7B RID: 3451
	private float newInputSteer;

	// Token: 0x04000D7C RID: 3452
	public bool GUIenabled;

	// Token: 0x04000D7D RID: 3453
	private bool raycasting;

	// Token: 0x04000D7E RID: 3454
	private float resetTime;

	// Token: 0x04000D7F RID: 3455
	public LayerMask raycastLayers;

	// Token: 0x04000D80 RID: 3456
	public WheelCollider FrontLeftWheelCollider;

	// Token: 0x04000D81 RID: 3457
	public WheelCollider FrontRightWheelCollider;

	// Token: 0x04000D82 RID: 3458
	public WheelCollider RearLeftWheelCollider;

	// Token: 0x04000D83 RID: 3459
	public WheelCollider RearRightWheelCollider;

	// Token: 0x04000D84 RID: 3460
	public Transform FrontLeftWheelTransform;

	// Token: 0x04000D85 RID: 3461
	public Transform FrontRightWheelTransform;

	// Token: 0x04000D86 RID: 3462
	public Transform RearLeftWheelTransform;

	// Token: 0x04000D87 RID: 3463
	public Transform RearRightWheelTransform;

	// Token: 0x04000D88 RID: 3464
	public Transform COM;

	// Token: 0x04000D89 RID: 3465
	private Transform dynamicCOM;

	// Token: 0x04000D8A RID: 3466
	private float vehicleSizeX;

	// Token: 0x04000D8B RID: 3467
	private float vehicleSizeY;

	// Token: 0x04000D8C RID: 3468
	private float vehicleSizeZ;

	// Token: 0x04000D8D RID: 3469
	public float BrakePower;

	// Token: 0x04000D8E RID: 3470
	public bool reversing;

	// Token: 0x04000D8F RID: 3471
	public float longRayBraking;

	// Token: 0x04000D90 RID: 3472
	public float brakeZone = 1000f;

	// Token: 0x04000D91 RID: 3473
	public float brakeRaycast = 500f;

	// Token: 0x04000D92 RID: 3474
	public List<Transform> waypoints = new List<Transform>();

	// Token: 0x04000D93 RID: 3475
	private int currentWaypoint;

	// Token: 0x04000D94 RID: 3476
	public float inputSteer;

	// Token: 0x04000D95 RID: 3477
	public float inputTorque;

	// Token: 0x04000D96 RID: 3478
	public int lap;

	// Token: 0x04000D97 RID: 3479
	public int totalWaypointPassed;

	// Token: 0x04000D98 RID: 3480
	public int nextWaypointPassRadius = 20;

	// Token: 0x04000D99 RID: 3481
	public SmartAICar.WheelType _wheelTypeChoise;

	// Token: 0x04000D9A RID: 3482
	private bool rwd;

	// Token: 0x04000D9B RID: 3483
	private bool fwd = true;

	// Token: 0x04000D9C RID: 3484
	public float gearShiftRate = 10f;

	// Token: 0x04000D9D RID: 3485
	public int CurrentGear;

	// Token: 0x04000D9E RID: 3486
	public AnimationCurve EngineTorqueCurve;

	// Token: 0x04000D9F RID: 3487
	private float[] GearRatio;

	// Token: 0x04000DA0 RID: 3488
	public float EngineTorque = 750f;

	// Token: 0x04000DA1 RID: 3489
	public float MaxEngineRPM = 6000f;

	// Token: 0x04000DA2 RID: 3490
	public float MinEngineRPM = 1000f;

	// Token: 0x04000DA3 RID: 3491
	public float EngineRPM;

	// Token: 0x04000DA4 RID: 3492
	public float SteerAngle = 20f;

	// Token: 0x04000DA5 RID: 3493
	public float HighSpeedSteerAngle = 10f;

	// Token: 0x04000DA6 RID: 3494
	public float HighSpeedSteerAngleAtSpeed = 80f;

	// Token: 0x04000DA7 RID: 3495
	public float Speed;

	// Token: 0x04000DA8 RID: 3496
	public float maxSpeed = 180f;

	// Token: 0x04000DA9 RID: 3497
	public float StiffnessRear;

	// Token: 0x04000DAA RID: 3498
	public float StiffnessFront;

	// Token: 0x04000DAB RID: 3499
	public Vector3 acceleration;

	// Token: 0x04000DAC RID: 3500
	public Vector3 lastVelocity;

	// Token: 0x04000DAD RID: 3501
	private GameObject skidAudio;

	// Token: 0x04000DAE RID: 3502
	public AudioClip skidClip;

	// Token: 0x04000DAF RID: 3503
	private GameObject crashAudio;

	// Token: 0x04000DB0 RID: 3504
	public AudioClip[] crashClips;

	// Token: 0x04000DB1 RID: 3505
	private GameObject engineAudio;

	// Token: 0x04000DB2 RID: 3506
	public AudioClip engineClip;

	// Token: 0x04000DB3 RID: 3507
	private int crashSoundLimit = 5;

	// Token: 0x04000DB4 RID: 3508
	private bool volumeLower;

	// Token: 0x04000DB5 RID: 3509
	private float RotationValueFL;

	// Token: 0x04000DB6 RID: 3510
	private float RotationValueFR;

	// Token: 0x04000DB7 RID: 3511
	private float RotationValueRL;

	// Token: 0x04000DB8 RID: 3512
	private float RotationValueRR;

	// Token: 0x04000DB9 RID: 3513
	private float[] RotationValueExtra;

	// Token: 0x04000DBA RID: 3514
	public GameObject WheelSlipPrefab;

	// Token: 0x04000DBB RID: 3515
	private List<GameObject> WheelParticles = new List<GameObject>();

	// Token: 0x04000DBC RID: 3516
	public WheelFrictionCurve RearLeftFriction;

	// Token: 0x04000DBD RID: 3517
	public WheelFrictionCurve RearRightFriction;

	// Token: 0x04000DBE RID: 3518
	public WheelFrictionCurve FrontLeftFriction;

	// Token: 0x04000DBF RID: 3519
	public WheelFrictionCurve FrontRightFriction;

	// Token: 0x04000DC0 RID: 3520
	public WheelFrictionCurve[] ExtraRearWheelsFriction;

	// Token: 0x04000DC1 RID: 3521
	public GameObject chassis;

	// Token: 0x04000DC2 RID: 3522
	public float chassisVerticalLean = 3f;

	// Token: 0x04000DC3 RID: 3523
	public float chassisHorizontalLean = 3f;

	// Token: 0x04000DC4 RID: 3524
	private float horizontalLean;

	// Token: 0x04000DC5 RID: 3525
	private float verticalLean;

	// Token: 0x04000DC6 RID: 3526
	private float gearTimeMultiplier;

	// Token: 0x04000DC7 RID: 3527
	public bool hardBrake;

	// Token: 0x04000DC8 RID: 3528
	public bool carAhead;

	// Token: 0x04000DC9 RID: 3529
	public bool carAhead2;

	// Token: 0x04000DCA RID: 3530
	public bool carAhead3;

	// Token: 0x04000DCB RID: 3531
	private bool fwdRayRed;

	// Token: 0x04000DCC RID: 3532
	private bool tghtRRayRed;

	// Token: 0x04000DCD RID: 3533
	private bool tghtLRayRed;

	// Token: 0x04000DCE RID: 3534
	private bool wdRRayRed;

	// Token: 0x04000DCF RID: 3535
	private bool wdLRayRed;

	// Token: 0x04000DD0 RID: 3536
	private bool leftRayRed;

	// Token: 0x04000DD1 RID: 3537
	private bool rightRayRed;

	// Token: 0x04000DD2 RID: 3538
	public AudioClip[] horns;

	// Token: 0x04000DD3 RID: 3539
	private float hornTimer;

	// Token: 0x04000DD4 RID: 3540
	public GameObject initialMesh;

	// Token: 0x04000DD5 RID: 3541
	public Mesh[] chasisMesh;

	// Token: 0x04000DD6 RID: 3542
	public float removalTimer;

	// Token: 0x04000DD7 RID: 3543
	private Rigidbody myRigidbody;

	// Token: 0x04000DD8 RID: 3544
	public int distanceThreshold = 750;

	// Token: 0x04000DD9 RID: 3545
	[SerializeField]
	private float torqueMultiplier;

	// Token: 0x020000FB RID: 251
	public enum WheelType
	{
		// Token: 0x04000DDC RID: 3548
		FWD,
		// Token: 0x04000DDD RID: 3549
		RWD
	}
}
