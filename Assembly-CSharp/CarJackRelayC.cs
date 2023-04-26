using System;
using UnityEngine;

// Token: 0x0200009A RID: 154
public class CarJackRelayC : MonoBehaviour
{
	// Token: 0x060004CA RID: 1226 RVA: 0x00051375 File Offset: 0x0004F775
	private void Start()
	{
		this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x00051390 File Offset: 0x0004F790
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x000513D4 File Offset: 0x0004F7D4
	public void Trigger()
	{
		base.transform.parent.transform.parent.SendMessage("JackUp");
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x000513F5 File Offset: 0x0004F7F5
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x0005140F File Offset: 0x0004F80F
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x040006F3 RID: 1779
	public bool isGlowing;

	// Token: 0x040006F4 RID: 1780
	public Material startMaterial;

	// Token: 0x040006F5 RID: 1781
	public Material glowMaterial;
}
