using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class BorderGuardC : MonoBehaviour
{
	// Token: 0x06000013 RID: 19 RVA: 0x00002D5C File Offset: 0x0000115C
	private void Update()
	{
		Vector3 a = base.transform.position - this.lastLocation;
		this.lastLocation = base.transform.position;
		this.horizontalVelocity = a * 4f;
		base.GetComponent<Animator>().SetFloat("walkSpeed", this.horizontalVelocity.magnitude);
	}

	// Token: 0x04000010 RID: 16
	private Vector3 lastLocation;

	// Token: 0x04000011 RID: 17
	private Vector3 horizontalVelocity;
}
