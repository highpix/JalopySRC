using System;
using UnityEngine;

// Token: 0x02000131 RID: 305
public class ShopGateC : MonoBehaviour
{
	// Token: 0x06000C5F RID: 3167 RVA: 0x0012B748 File Offset: 0x00129B48
	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			return;
		}
		iTween.Stop(base.gameObject);
	}
}
