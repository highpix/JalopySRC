using System;
using UnityEngine;

// Token: 0x020000F3 RID: 243
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class RigidbodyControllerC : MonoBehaviour
{
	// Token: 0x0600098F RID: 2447
	private void Awake()
	{
		this._camera = Camera.main.gameObject;
		base.GetComponent<Rigidbody>().freezeRotation = true;
		base.GetComponent<Rigidbody>().useGravity = false;
		GameObject.Find("First Person Controller").AddComponent<DegubFly>();
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x000E2BF0 File Offset: 0x000E0FF0
	private void FixedUpdate()
	{
		if (this.driving)
		{
			base.transform.position = this.carSeat.position;
			return;
		}
		if (Input.GetKey(MainMenuC.Global.assignedInputStrings[28]) && !this.seatObj.GetComponent<SeatLogicC>().isSat)
		{
			this._camera.transform.localPosition = new Vector3(this._camera.transform.localPosition.x, 0.15f, this._camera.transform.localPosition.z);
			this._camera.transform.parent.GetComponent<RigidbodyControllerC>().speed = 3f;
			this._camera.transform.parent.GetComponent<FootstepsC>().audioStepLength = 0.65f;
		}
		else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[29]) && !this.seatObj.GetComponent<SeatLogicC>().isSat)
		{
			this._camera.transform.localPosition = new Vector3(this._camera.transform.localPosition.x, 0.15f, this._camera.transform.localPosition.z);
			this._camera.transform.parent.GetComponent<RigidbodyControllerC>().speed = 3f;
			this._camera.transform.parent.GetComponent<FootstepsC>().audioStepLength = 0.65f;
		}
		else
		{
			this._camera.transform.localPosition = new Vector3(this._camera.transform.localPosition.x, 0.8f, this._camera.transform.localPosition.z);
			HeadBobberC component = this._camera.GetComponent<HeadBobberC>();
			component.midpoint = 0.8f;
			component.bobbingSpeed = 18f;
			component.bobbingAmount = 0.05f;
			this._camera.transform.parent.GetComponent<RigidbodyControllerC>().speed = 8f;
			this._camera.transform.parent.GetComponent<FootstepsC>().audioStepLength = 0.3f;
		}
		if (this.grounded)
		{
			this.targetVelocity = Vector3.zero;
			if (Input.GetKey(MainMenuC.Global.assignedInputStrings[0]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[1]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[2]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[3]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[4]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[5]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[6]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[7]))
			{
				if (Input.GetKey(MainMenuC.Global.assignedInputStrings[0]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[1]))
				{
					if (Input.GetKey(MainMenuC.Global.assignedInputStrings[4]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[5]))
					{
						this.targetVelocity = new Vector3(-1f, 0f, 1f);
					}
					else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[6]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[7]))
					{
						this.targetVelocity = new Vector3(1f, 0f, 1f);
					}
					else
					{
						this.targetVelocity = new Vector3(0f, 0f, 1f);
					}
				}
				if (Input.GetKey(MainMenuC.Global.assignedInputStrings[2]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[3]))
				{
					if (Input.GetKey(MainMenuC.Global.assignedInputStrings[4]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[5]))
					{
						this.targetVelocity = new Vector3(-1f, 0f, -1f);
					}
					else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[6]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[7]))
					{
						this.targetVelocity = new Vector3(1f, 0f, -1f);
					}
					else
					{
						this.targetVelocity = new Vector3(0f, 0f, -1f);
					}
				}
				if (Input.GetKey(MainMenuC.Global.assignedInputStrings[4]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[5]))
				{
					if (Input.GetKey(MainMenuC.Global.assignedInputStrings[0]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[1]))
					{
						this.targetVelocity = new Vector3(-1f, 0f, 1f);
					}
					else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[2]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[3]))
					{
						this.targetVelocity = new Vector3(-1f, 0f, -1f);
					}
					else
					{
						this.targetVelocity = new Vector3(-1f, 0f, 0f);
					}
				}
				if (Input.GetKey(MainMenuC.Global.assignedInputStrings[6]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[7]))
				{
					if (Input.GetKey(MainMenuC.Global.assignedInputStrings[0]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[1]))
					{
						this.targetVelocity = new Vector3(1f, 0f, 1f);
					}
					else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[2]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[3]))
					{
						this.targetVelocity = new Vector3(1f, 0f, -1f);
					}
					else
					{
						this.targetVelocity = new Vector3(1f, 0f, 0f);
					}
				}
				this.targetVelocity = base.transform.TransformDirection(this.targetVelocity);
				this.targetVelocity *= this.speed;
				base.GetComponent<Rigidbody>().velocity = this.targetVelocity;
			}
			else if ((base.GetComponent<MouseLook>().padInput == 1 || base.GetComponent<MouseLook>().padInput == 3) && (Mathf.Abs(Input.GetAxis("JoypadX")) > 0.1f || Mathf.Abs(Input.GetAxis("JoypadY")) > 0.1f))
			{
				Vector3 vector = new Vector3(Input.GetAxis("JoypadX"), 0f, Input.GetAxis("JoypadY"));
				vector = base.transform.TransformDirection(vector);
				vector *= this.speed;
				Vector3 velocity = base.GetComponent<Rigidbody>().velocity;
				Vector3 force = vector - velocity;
				force.x = Mathf.Clamp(force.x, -this.maxVelocityChange, this.maxVelocityChange);
				force.z = Mathf.Clamp(force.z, -this.maxVelocityChange, this.maxVelocityChange);
				force.y = 0f;
				base.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
			}
			if (this.canJump && Input.GetButton("Jump"))
			{
				base.GetComponent<Rigidbody>().velocity = new Vector3(base.GetComponent<Rigidbody>().velocity.x, this.CalculateJumpVerticalSpeed(), base.GetComponent<Rigidbody>().velocity.z);
			}
		}
		base.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -this.gravity * base.GetComponent<Rigidbody>().mass, 0f));
		this.grounded = false;
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x000E3456 File Offset: 0x000E1856
	private void OnCollisionStay()
	{
		this.grounded = true;
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x000E345F File Offset: 0x000E185F
	private float CalculateJumpVerticalSpeed()
	{
		return Mathf.Sqrt(2f * this.jumpHeight * this.gravity);
	}

	// Token: 0x04000D0F RID: 3343
	private GameObject _camera;

	// Token: 0x04000D10 RID: 3344
	public float speed = 10f;

	// Token: 0x04000D11 RID: 3345
	public float gravity = 10f;

	// Token: 0x04000D12 RID: 3346
	public float maxVelocityChange = 10f;

	// Token: 0x04000D13 RID: 3347
	public bool canJump = true;

	// Token: 0x04000D14 RID: 3348
	public float jumpHeight = 2f;

	// Token: 0x04000D15 RID: 3349
	public Transform carSeat;

	// Token: 0x04000D16 RID: 3350
	public bool driving;

	// Token: 0x04000D17 RID: 3351
	public bool isSat;

	// Token: 0x04000D18 RID: 3352
	private bool grounded;

	// Token: 0x04000D19 RID: 3353
	public GameObject seatObj;

	// Token: 0x04000D1A RID: 3354
	public Vector3 targetVelocity;
}
