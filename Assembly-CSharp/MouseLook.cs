using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000087 RID: 135
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	// Token: 0x0600041E RID: 1054 RVA: 0x00042A8B File Offset: 0x00040E8B
	private void OnEnable()
	{
		if (this.axes == MouseLook.RotationAxes.MouseY)
		{
			this.debugStart = base.transform.localEulerAngles;
		}
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x00042AAC File Offset: 0x00040EAC
	private void FixedUpdate()
	{
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			this.padInput = 1;
		}
		if (this.axes == MouseLook.RotationAxes.MouseXAndY)
		{
			float y = base.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.sensitivityX;
			if ((this.padInput == 1 || this.padInput == 3) && (Input.GetAxis("RJoystick X") > 0.1f || Input.GetAxis("RJoystick X") < 0.1f))
			{
				y = base.transform.localEulerAngles.y + Input.GetAxis("RJoystick X") * this.sensitivityX;
			}
			this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
			if ((this.padInput == 1 || this.padInput == 3) && (Input.GetAxis("RJoystick Y") > 0.1f || Input.GetAxis("RJoystick Y") < 0.1f))
			{
				this.rotationY += Input.GetAxis("RJoystick Y") * this.sensitivityY;
			}
			this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
			base.transform.localEulerAngles = new Vector3(-this.rotationY, y, 0f);
		}
		else if (this.axes == MouseLook.RotationAxes.MouseX)
		{
			if (!this.smoothingBool)
			{
				base.transform.Rotate(0f, Input.GetAxis("Mouse X") * this.sensitivityX, 0f);
				if ((this.padInput == 1 || this.padInput == 3) && (Input.GetAxis("RJoystick X") > 0.1f || Input.GetAxis("RJoystick X") < 0.1f))
				{
					base.transform.Rotate(0f, Input.GetAxis("RJoystick X") * this.sensitivityX, 0f);
				}
			}
			else if (this.isSat)
			{
				base.transform.Rotate(0f, Input.GetAxis("Mouse X") * this.sensitivityX, 0f);
				if ((this.padInput == 1 || this.padInput == 3) && (Input.GetAxis("RJoystick X") > 0.1f || Input.GetAxis("RJoystick X") < 0.1f))
				{
					base.transform.Rotate(0f, Input.GetAxis("RJoystick X") * this.sensitivityX, 0f);
				}
			}
			else
			{
				float num = Input.GetAxis("Mouse X") * this.sensitivityX;
				this.xTargetRotation += num;
				this.xTargetRotation %= 360f;
			}
		}
		else if (!this.smoothingBool)
		{
			this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
			if ((this.padInput == 1 || this.padInput == 3) && (Input.GetAxis("RJoystick Y") > 0.1f || Input.GetAxis("RJoystick Y") < 0.1f))
			{
				this.rotationY += Input.GetAxis("RJoystick Y") * this.sensitivityY;
			}
			this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
			base.transform.localEulerAngles = new Vector3(-this.rotationY, 0f, 0f);
		}
		else if (this.isSat)
		{
			this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
			if ((this.padInput == 1 || this.padInput == 3) && (Input.GetAxis("RJoystick Y") > 0.1f || Input.GetAxis("RJoystick Y") < 0.1f))
			{
				this.rotationY += Input.GetAxis("RJoystick Y") * this.sensitivityY;
			}
			this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
			base.transform.localEulerAngles = new Vector3(-this.rotationY, 0f, 0f);
		}
		else
		{
			float num2 = Input.GetAxis("Mouse Y") * this.sensitivityY;
			this.yTargetRotation += -num2;
			this.yTargetRotation %= 360f;
			this.yTargetRotation = Mathf.Clamp(this.yTargetRotation, this.minimumY, this.maximumY);
		}
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x00042F7F File Offset: 0x0004137F
	public void ForceNormalFOV()
	{
		base.GetComponent<Camera>().fieldOfView = this.normalFOV;
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00042F94 File Offset: 0x00041394
	private void Update()
	{
		if (this.axes == MouseLook.RotationAxes.MouseX)
		{
			if (this.smoothingBool && !this.isSat)
			{
				base.transform.localRotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(0f, this.xTargetRotation, 0f), Time.deltaTime * 10f / this.smoothing);
			}
		}
		else if (this.axes == MouseLook.RotationAxes.MouseY && this.smoothingBool && !this.isSat)
		{
			base.transform.localRotation = Quaternion.Lerp(base.transform.localRotation, Quaternion.Euler(this.yTargetRotation, 0f, 0f), Time.deltaTime * 10f / this.smoothing);
		}
		if (!Screen.lockCursor)
		{
			Screen.lockCursor = true;
		}
		if (Input.GetButtonDown("Drop") && this.noClip && !this.parentedToCar && this.noClipBreaker <= 0f && this.debugEnabled)
		{
			base.transform.SendMessage("ParentDebugToCar");
			this.parentedToCar = true;
			this.noClipBreaker = 1f;
		}
		if (Input.GetButtonDown("Drop") && this.noClip && this.parentedToCar && this.noClipBreaker <= 0f && this.debugEnabled)
		{
			base.transform.SendMessage("UnParentDebugToCar");
			this.parentedToCar = false;
			this.noClipBreaker = 1f;
		}
		if (Input.GetButtonDown("JoypadX") && this.noClipBreaker <= 0f && !this.debugUncleDisabled && this.debugEnabled)
		{
			base.transform.SendMessage("HideUncleSpeech");
			this.noClipBreaker = 1f;
			this.debugUncleDisabled = true;
		}
		if (Input.GetButtonDown("JoypadX") && this.noClipBreaker <= 0f && this.debugUncleDisabled && this.debugEnabled)
		{
			base.transform.SendMessage("ShowUncleSpeech");
			this.noClipBreaker = 1f;
			this.debugUncleDisabled = false;
		}
		if (Input.GetButtonDown("JoypadY") && this.debugEnabled)
		{
			base.transform.SendMessage("DebugAdd100Cash");
		}
		if (Input.GetButtonDown("NoClip") && this.noClip && this.noClipBreaker <= 0f && this.debugEnabled)
		{
			this.cursor.SetActive(false);
			this.axes = MouseLook.RotationAxes.MouseY;
			this.myBody.SetActive(true);
			base.transform.parent = this.myBody.transform;
			base.transform.localPosition = new Vector3(0f, 0.8f, 0f);
			base.transform.localRotation = Quaternion.identity;
			this.noClip = false;
			GameObject.FindWithTag("CarLogic").SendMessage("NoClipFalse", SendMessageOptions.DontRequireReceiver);
			this.noClipBreaker = 1f;
			base.transform.SendMessage("DisableDriver");
		}
		if (Input.GetButtonDown("NoClip") && !this.noClip && this.noClipBreaker <= 0f && this.debugEnabled)
		{
			this.myBody = base.transform.parent.gameObject;
			GameObject.FindWithTag("CarLogic").SendMessage("NoClipTrue", SendMessageOptions.DontRequireReceiver);
			base.gameObject.transform.parent = null;
			this.myBody.SetActive(false);
			this.axes = MouseLook.RotationAxes.MouseXAndY;
			this.noClip = true;
			this.noClipBreaker = 1f;
			this.cursor.SetActive(true);
			base.transform.SendMessage("EnableDriver");
		}
		this.noClipBreaker -= 1f * Time.deltaTime;
		if (this.noClip)
		{
			float z = Input.GetAxis(this.forwardAxisPad) * this.movementForwardMultiplier * Time.deltaTime;
			float x = Input.GetAxis(this.horizontalAxisPad) * this.movementSideMultiplier * Time.deltaTime;
			float num = this.movementForwardMultiplier / 2f;
			float y = Input.GetAxis("JoypadDpadY") * num * Time.deltaTime;
			Vector3 direction = new Vector3(x, y, z);
			base.transform.position += base.transform.TransformDirection(direction);
		}
		if (Input.GetKey(this.assignedInputStrings[16]) && this.sensitivity == 0 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 10f;
			this.movementSideMultiplier = 10f;
			this.sensitivity = 1;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[17]) && this.sensitivity == 0 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 10f;
			this.movementSideMultiplier = 10f;
			this.sensitivity = 1;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[16]) && this.sensitivity == 1 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 5f;
			this.movementSideMultiplier = 5f;
			this.sensitivity = 2;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[17]) && this.sensitivity == 1 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 5f;
			this.movementSideMultiplier = 5f;
			this.sensitivity = 2;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[16]) && this.sensitivity == 2 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 1f;
			this.movementSideMultiplier = 1f;
			this.sensitivity = 3;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[17]) && this.sensitivity == 2 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 1f;
			this.movementSideMultiplier = 1f;
			this.sensitivity = 3;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[16]) && this.sensitivity == 3 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 20f;
			this.movementSideMultiplier = 20f;
			this.sensitivity = 4;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[17]) && this.sensitivity == 3 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 20f;
			this.movementSideMultiplier = 20f;
			this.sensitivity = 4;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[16]) && this.sensitivity == 4 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 50f;
			this.movementSideMultiplier = 50f;
			this.sensitivity = 0;
			this.senseBreaker = 0.5f;
		}
		if (Input.GetKey(this.assignedInputStrings[17]) && this.sensitivity == 4 && this.senseBreaker <= 0f)
		{
			this.movementForwardMultiplier = 50f;
			this.movementSideMultiplier = 50f;
			this.sensitivity = 0;
			this.senseBreaker = 0.5f;
		}
		this.senseBreaker -= 1f * Time.deltaTime;
		if (this.isCamera)
		{
			if (Input.GetKeyUp(this.assignedInputStrings[20]) && this.canZoomBreaker)
			{
				this.canZoomBreaker = false;
			}
			if (Input.GetKeyUp(this.assignedInputStrings[21]) && this.canZoomBreaker)
			{
				this.canZoomBreaker = false;
			}
			if (Input.GetKey(this.assignedInputStrings[20]) && !this.canZoomBreaker)
			{
				base.GetComponent<Camera>().fieldOfView = Mathf.Lerp(base.GetComponent<Camera>().fieldOfView, this.zoomFOV, Time.deltaTime * this.zoomSmooth);
			}
			else if (Input.GetKey(this.assignedInputStrings[21]) && !this.canZoomBreaker)
			{
				base.GetComponent<Camera>().fieldOfView = Mathf.Lerp(base.GetComponent<Camera>().fieldOfView, this.zoomFOV, Time.deltaTime * this.zoomSmooth);
			}
			else if (!Input.GetButton("JoypadZoom"))
			{
				base.GetComponent<Camera>().fieldOfView = Mathf.Lerp(base.GetComponent<Camera>().fieldOfView, this.normalFOV, Time.deltaTime * this.zoomSmooth);
			}
			if (Input.GetButtonUp("JoypadZoom") && this.canZoomBreakerPad)
			{
				this.canZoomBreakerPad = false;
			}
			if (Input.GetButton("JoypadZoom") && !this.canZoomBreakerPad)
			{
				base.GetComponent<Camera>().fieldOfView = Mathf.Lerp(base.GetComponent<Camera>().fieldOfView, this.zoomFOV, Time.deltaTime * this.zoomSmooth);
			}
			else if (!Input.GetKey(this.assignedInputStrings[20]) && !Input.GetKey(this.assignedInputStrings[21]))
			{
				base.GetComponent<Camera>().fieldOfView = Mathf.Lerp(base.GetComponent<Camera>().fieldOfView, this.normalFOV, Time.deltaTime * this.zoomSmooth);
			}
		}
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x000439AC File Offset: 0x00041DAC
	private void Start()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x000439DC File Offset: 0x00041DDC
	public IEnumerator ForceZoomOut()
	{
		this.canZoomBreaker = false;
		this.canZoomBreakerPad = false;
		while (base.GetComponent<Camera>().fieldOfView < this.normalFOV)
		{
			base.GetComponent<Camera>().fieldOfView = Mathf.Lerp(base.GetComponent<Camera>().fieldOfView, this.normalFOV, Time.deltaTime * this.zoomSmooth);
			yield return null;
		}
		yield break;
	}

	// Token: 0x040005E4 RID: 1508
	public GameObject cursor;

	// Token: 0x040005E5 RID: 1509
	public int sensitivity;

	// Token: 0x040005E6 RID: 1510
	public float senseBreaker;

	// Token: 0x040005E7 RID: 1511
	public float movementForwardMultiplier = 4f;

	// Token: 0x040005E8 RID: 1512
	public float movementSideMultiplier = 4f;

	// Token: 0x040005E9 RID: 1513
	private string forwardAxis = "Vertical";

	// Token: 0x040005EA RID: 1514
	private string horizontalAxis = "Horizontal";

	// Token: 0x040005EB RID: 1515
	private string forwardAxisPad = "VerticalJoystick";

	// Token: 0x040005EC RID: 1516
	private string horizontalAxisPad = "HorizontalJoystick";

	// Token: 0x040005ED RID: 1517
	public bool parentedToCar;

	// Token: 0x040005EE RID: 1518
	public bool debugUncleDisabled;

	// Token: 0x040005EF RID: 1519
	public bool noClip;

	// Token: 0x040005F0 RID: 1520
	public float noClipBreaker;

	// Token: 0x040005F1 RID: 1521
	public GameObject myBody;

	// Token: 0x040005F2 RID: 1522
	public bool isCamera;

	// Token: 0x040005F3 RID: 1523
	public MouseLook.RotationAxes axes;

	// Token: 0x040005F4 RID: 1524
	public float sensitivityX = 15f;

	// Token: 0x040005F5 RID: 1525
	public float sensitivityY = 15f;

	// Token: 0x040005F6 RID: 1526
	public float minimumX = -360f;

	// Token: 0x040005F7 RID: 1527
	public float maximumX = 360f;

	// Token: 0x040005F8 RID: 1528
	public float minimumY = -60f;

	// Token: 0x040005F9 RID: 1529
	public float maximumY = 60f;

	// Token: 0x040005FA RID: 1530
	public float normalFOV;

	// Token: 0x040005FB RID: 1531
	public float zoomFOV;

	// Token: 0x040005FC RID: 1532
	public float zoomSmooth;

	// Token: 0x040005FD RID: 1533
	public bool canZoomBreaker;

	// Token: 0x040005FE RID: 1534
	public bool canZoomBreakerPad;

	// Token: 0x040005FF RID: 1535
	public bool debugEnabled;

	// Token: 0x04000600 RID: 1536
	public bool smoothingBool;

	// Token: 0x04000601 RID: 1537
	public bool isSat;

	// Token: 0x04000602 RID: 1538
	public float smoothing = 1f;

	// Token: 0x04000603 RID: 1539
	public float xTargetRotation = 10f;

	// Token: 0x04000604 RID: 1540
	public float yTargetRotation = 10f;

	// Token: 0x04000605 RID: 1541
	public int padInput;

	// Token: 0x04000606 RID: 1542
	public float rotationY;

	// Token: 0x04000607 RID: 1543
	public string[] assignedInputStrings;

	// Token: 0x04000608 RID: 1544
	public Vector3 debugStart = Vector3.zero;

	// Token: 0x02000088 RID: 136
	public enum RotationAxes
	{
		// Token: 0x0400060A RID: 1546
		MouseXAndY,
		// Token: 0x0400060B RID: 1547
		MouseX,
		// Token: 0x0400060C RID: 1548
		MouseY
	}
}
