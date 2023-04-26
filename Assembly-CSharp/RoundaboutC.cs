using System;
using UnityEngine;

// Token: 0x020000E9 RID: 233
public class RoundaboutC : MonoBehaviour
{
	// Token: 0x06000907 RID: 2311 RVA: 0x000C24D6 File Offset: 0x000C08D6
	private void Start()
	{
		if (this.aiRouteFlick1 != null && this.aiRouteFlick2 != null)
		{
			base.InvokeRepeating("Flick1", 0f, 5f);
		}
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000C2510 File Offset: 0x000C0910
	private void Flick1()
	{
		if (!this.aiRouteFlick1.active)
		{
			this.aiRouteFlick1.active = true;
			this.aiRouteFlick2.active = false;
			return;
		}
		this.aiRouteFlick1.active = false;
		this.aiRouteFlick2.active = true;
	}

	// Token: 0x04000C06 RID: 3078
	public GameObject continueNode;

	// Token: 0x04000C07 RID: 3079
	public GameObject aiRouteFlick1;

	// Token: 0x04000C08 RID: 3080
	public GameObject aiRouteFlick2;
}
