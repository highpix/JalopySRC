using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200007C RID: 124
public class RigidbodyGetter : MonoBehaviour
{
	// Token: 0x0600024E RID: 590 RVA: 0x0001DA41 File Offset: 0x0001BE41
	[ContextMenu("Get all rigidbodies")]
	public void GetAllRigidbodies()
	{
		this.rigids.AddRange(base.GetComponentsInChildren<Rigidbody>());
	}

	// Token: 0x040003B0 RID: 944
	public List<Rigidbody> rigids = new List<Rigidbody>();
}
