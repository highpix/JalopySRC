using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class DegubFly : MonoBehaviour
{
	// Token: 0x06001799 RID: 6041
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			this.flightModeEnabled = !this.flightModeEnabled;
			if (this.flightModeEnabled)
			{
				base.GetComponent<RigidbodyControllerC>().gravity = 0f;
				base.GetComponent<Collider>().enabled = false;
			}
			else
			{
				base.GetComponent<RigidbodyControllerC>().gravity = 35f;
				base.GetComponent<Collider>().enabled = true;
			}
		}
		if (this.flightModeEnabled)
		{
			float axis = Input.GetAxis("Horizontal");
			float verticalInput = 0f;
			float depthInput = Input.GetAxis("Vertical");
			if (Input.GetKey(KeyCode.Space))
			{
				verticalInput = 1f;
			}
			else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
			{
				verticalInput = -1f;
			}
			Vector3 movement = new Vector3(axis, verticalInput, depthInput) * this.flightSpeed * Time.deltaTime;
			base.transform.Translate(movement);
		}
	}

	// Token: 0x0400199A RID: 6554
	private bool flightModeEnabled;

	// Token: 0x0400199C RID: 6556
	private float flightSpeed = 15f;
}
