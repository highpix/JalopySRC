using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000165 RID: 357
public class XboxMapHolder : MonoBehaviour
{
	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000D9A RID: 3482 RVA: 0x00132F03 File Offset: 0x00131303
	// (set) Token: 0x06000D9B RID: 3483 RVA: 0x00132F0C File Offset: 0x0013130C
	public MapRelayC CurrentRoute
	{
		get
		{
			return this.currentRoute;
		}
		set
		{
			if (this.currentRoute != null && this.currentRoute != value)
			{
				this.currentRoute.OnMouseExit();
			}
			this.currentRoute = value;
			if (value != null)
			{
				value.OnMouseEnter();
			}
		}
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x00132F5F File Offset: 0x0013135F
	private void Awake()
	{
		if (Application.platform != RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x00132F73 File Offset: 0x00131373
	public void OnEnable()
	{
		this.currentRouteSelected = 0;
		this.CurrentRoute = null;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			MainMenuC.Global.ReticuleToggle(false);
		}
	}

	// Token: 0x06000D9E RID: 3486 RVA: 0x00132F9C File Offset: 0x0013139C
	private void Update()
	{
		if (this.triggerObject.activeInHierarchy)
		{
			bool flag = false;
			bool flag2 = false;
			if (Application.platform == RuntimePlatform.XboxOne)
			{
				bool keyDown = Input.GetKeyDown(KeyCode.JoystickButton0);
				if (!this.dPadPressed)
				{
					flag = (Input.GetAxisRaw("JoypadDpadY") < 0f);
					flag2 = (Input.GetAxisRaw("JoypadDpadY") > 0f);
					this.dPadPressed = (Mathf.Abs(Input.GetAxisRaw("JoypadDpadY")) > 0f || Mathf.Abs(Input.GetAxisRaw("JoypadDpadX")) > 0f);
				}
				else if (Mathf.Abs(Input.GetAxis("JoypadDpadY")) < 0.5f && Mathf.Abs(Input.GetAxis("JoypadDpadX")) < 0.5f)
				{
					this.dPadPressed = false;
				}
				if (flag)
				{
					this.PressDown();
				}
				if (flag2)
				{
					this.PressUp();
				}
				if (keyDown && this.CurrentRoute != null)
				{
					this.CurrentRoute.LockMap();
				}
			}
		}
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x001330B8 File Offset: 0x001314B8
	private void PressDown()
	{
		this.currentRouteSelected = Mathf.Clamp(this.currentRouteSelected + 1, 0, 3);
		this.CurrentRoute = ((this.currentRouteSelected != 0) ? this.routeSelection[this.currentRouteSelected - 1].GetComponent<MapRelayC>() : null);
	}

	// Token: 0x06000DA0 RID: 3488 RVA: 0x0013310C File Offset: 0x0013150C
	private void PressUp()
	{
		this.currentRouteSelected = Mathf.Clamp(this.currentRouteSelected - 1, 0, 3);
		this.CurrentRoute = ((this.currentRouteSelected != 0) ? this.routeSelection[this.currentRouteSelected - 1].GetComponent<MapRelayC>() : null);
	}

	// Token: 0x04001235 RID: 4661
	public GameObject triggerObject;

	// Token: 0x04001236 RID: 4662
	public List<GameObject> routeSelection = new List<GameObject>();

	// Token: 0x04001237 RID: 4663
	private int currentRouteSelected;

	// Token: 0x04001238 RID: 4664
	private MapRelayC currentRoute;

	// Token: 0x04001239 RID: 4665
	private bool dPadPressed;
}
