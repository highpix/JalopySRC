using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
public class CursorHit : MonoBehaviour
{
	// Token: 0x0600011C RID: 284 RVA: 0x00012A8A File Offset: 0x00010E8A
	private void LateUpdate()
	{
		this.headLook.target = base.transform.position;
	}

	// Token: 0x0400022B RID: 555
	public HeadLookController headLook;

	// Token: 0x0400022C RID: 556
	private float offset = 1.5f;
}
