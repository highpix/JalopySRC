using System;
using UnityEngine;

// Token: 0x020000EF RID: 239
public class RainLogicC : MonoBehaviour
{
	// Token: 0x0600096C RID: 2412 RVA: 0x000E02A8 File Offset: 0x000DE6A8
	private void Start()
	{
		this.player = Camera.main.gameObject;
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x000E02BA File Offset: 0x000DE6BA
	private void LateUpdate()
	{
		base.transform.position = this.player.transform.position + Vector3.up * 10f;
	}

	// Token: 0x04000CDE RID: 3294
	public GameObject player;
}
