using System;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class JalopyCursor : MonoBehaviour
{
	// Token: 0x0600012B RID: 299 RVA: 0x000134DD File Offset: 0x000118DD
	private void Start()
	{
		if (Application.platform != RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600012C RID: 300 RVA: 0x000134F6 File Offset: 0x000118F6
	// (set) Token: 0x0600012D RID: 301 RVA: 0x00013500 File Offset: 0x00011900
	public GameObject AimingAt
	{
		get
		{
			return this.aimingAt;
		}
		set
		{
			if (this.AimingAt != null)
			{
				if (this.AimingAt.GetComponent<UIButton>())
				{
					this.AimingAt.GetComponent<UIButton>().SetState(UIButtonColor.State.Normal, false);
				}
				if (this.AimingAt.GetComponent<MainMenuBookC>() || this.AimingAt.GetComponent<MainMenuToolboxC>())
				{
					this.AimingAt.SendMessage("RaycastExit");
				}
			}
			this.aimingAt = value;
			if (value != null)
			{
				if (this.AimingAt.GetComponent<UIButton>())
				{
					this.AimingAt.GetComponent<UIButton>().SetState(UIButtonColor.State.Hover, false);
				}
				if (this.AimingAt.GetComponent<MainMenuBookC>() || this.AimingAt.GetComponent<MainMenuToolboxC>())
				{
					this.AimingAt.SendMessage("RaycastEnter");
				}
			}
		}
	}

	// Token: 0x0600012E RID: 302 RVA: 0x000135F4 File Offset: 0x000119F4
	private void Update()
	{
		this.floats.x = Input.GetAxis("JoypadX");
		this.floats.y = Input.GetAxis("JoypadY");
		base.transform.GetChild(0).gameObject.SetActive(this.visible);
		if (this.visible)
		{
			this.Move(this.floats * this.speed);
			this.CastRay();
		}
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00013670 File Offset: 0x00011A70
	private void Move(Vector2 values)
	{
		base.transform.localPosition = new Vector3(Mathf.Clamp(base.transform.localPosition.x + values.x, -this.maximumBorders.x, this.maximumBorders.x), Mathf.Clamp(base.transform.localPosition.y + values.y, -this.maximumBorders.y, this.maximumBorders.y), this.zOffset);
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00013704 File Offset: 0x00011B04
	private void CastRay()
	{
		Ray ray = new Ray(base.transform.position, base.transform.forward);
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, float.PositiveInfinity))
		{
			this.AimingAt = raycastHit.collider.gameObject;
			Debug.DrawRay(base.transform.position, raycastHit.point, Color.red);
		}
		else
		{
			this.AimingAt = null;
			Debug.DrawRay(base.transform.position, base.transform.forward * 10f, Color.green);
		}
		if (this.AimingAt && (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetButtonDown("Submit")))
		{
			if (this.AimingAt.GetComponent<UIButton>())
			{
				this.AimingAt.GetComponent<UIButton>().OnClick();
			}
			if (this.AimingAt.GetComponent<MainMenuBookC>() || this.AimingAt.GetComponent<MainMenuToolboxC>())
			{
				this.AimingAt.SendMessage("Action");
			}
		}
	}

	// Token: 0x0400024E RID: 590
	public Vector2 floats;

	// Token: 0x0400024F RID: 591
	public float speed = 2f;

	// Token: 0x04000250 RID: 592
	public float zOffset = -82.95f;

	// Token: 0x04000251 RID: 593
	public GameObject aimingAt;

	// Token: 0x04000252 RID: 594
	public bool visible;

	// Token: 0x04000253 RID: 595
	public Vector2 maximumBorders;
}
