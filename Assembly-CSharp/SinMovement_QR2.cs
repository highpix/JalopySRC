using System;
using UnityEngine;

// Token: 0x0200006C RID: 108
public class SinMovement_QR2 : MonoBehaviour
{
	// Token: 0x060001E2 RID: 482 RVA: 0x00019625 File Offset: 0x00017A25
	private void Update()
	{
		base.transform.position = new Vector3(Mathf.Sin(Time.time * 0.5f) * 5f, 0f, 0f);
	}
}
