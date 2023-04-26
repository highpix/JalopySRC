using System;
using UnityEngine;

// Token: 0x02000068 RID: 104
public class AttachOnCollision_QR2 : MonoBehaviour
{
	// Token: 0x060001D7 RID: 471 RVA: 0x00018FF4 File Offset: 0x000173F4
	private void Update()
	{
		if (this.isConnected && Input.GetKeyDown(this.detachKey))
		{
			this.rope.DetachObject(this.attachedObject);
			this.isConnected = false;
			if (this.HUD)
			{
				this.HUD.text = "Hook Disconnected";
			}
		}
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00019054 File Offset: 0x00017454
	private void OnCollisionEnter(Collision col)
	{
		if (this.isConnected || col.gameObject.tag != this.connectableTag)
		{
			return;
		}
		this.isConnected = true;
		this.attachedObject = col.gameObject;
		this.rope.AttachObject(this.attachedObject, this.rope.Joints.Count - 1, false);
		if (this.HUD)
		{
			this.HUD.text = "Hook Connected";
		}
	}

	// Token: 0x0400030E RID: 782
	public QuickRope2 rope;

	// Token: 0x0400030F RID: 783
	public string connectableTag = "Player";

	// Token: 0x04000310 RID: 784
	public KeyCode detachKey = KeyCode.Space;

	// Token: 0x04000311 RID: 785
	public GUIText HUD;

	// Token: 0x04000312 RID: 786
	private GameObject attachedObject;

	// Token: 0x04000313 RID: 787
	private bool isConnected;
}
