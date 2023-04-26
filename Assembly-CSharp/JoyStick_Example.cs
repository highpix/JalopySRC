using System;
using UnityEngine;

// Token: 0x0200002F RID: 47
public class JoyStick_Example : MonoBehaviour
{
	// Token: 0x0600010E RID: 270 RVA: 0x000123DC File Offset: 0x000107DC
	public void PadInputOn()
	{
		this.padInput = 1;
	}

	// Token: 0x0600010F RID: 271 RVA: 0x000123E5 File Offset: 0x000107E5
	public void PadInputOff()
	{
		this.padInput = 0;
	}

	// Token: 0x06000110 RID: 272 RVA: 0x000123F0 File Offset: 0x000107F0
	private void Update()
	{
		if (base.GetComponent<MouseLook>())
		{
			if (base.GetComponent<MouseLook>().padInput == 1)
			{
				if (Input.GetAxis("RJoystick X") != 0f || Input.GetAxis("RJoystick Y") != 0f)
				{
					ScreenCursor.SimulateController(Input.GetAxis("RJoystick X"), Input.GetAxis("RJoystick Y"), this.Speed);
				}
				else if (Input.GetAxis("JoypadX") != 0f || Input.GetAxis("JoypadY") != 0f)
				{
					ScreenCursor.SimulateController(Input.GetAxis("JoypadX"), Input.GetAxis("JoypadY"), this.Speed);
				}
			}
		}
		else if (this.padInput == 1)
		{
			if (Input.GetAxis("RJoystick X") != 0f || Input.GetAxis("RJoystick Y") != 0f)
			{
				ScreenCursor.SimulateController(Input.GetAxis("RJoystick X"), Input.GetAxis("RJoystick Y"), this.Speed);
			}
			else if (Input.GetAxis("JoypadX") != 0f || Input.GetAxis("JoypadY") != 0f)
			{
				ScreenCursor.SimulateController(Input.GetAxis("JoypadX"), Input.GetAxis("JoypadY"), this.Speed);
			}
		}
	}

	// Token: 0x0400021C RID: 540
	public float Speed = 5f;

	// Token: 0x0400021D RID: 541
	public bool mainMenu = true;

	// Token: 0x0400021E RID: 542
	public int padInput;
}
