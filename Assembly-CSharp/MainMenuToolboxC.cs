using System;
using UnityEngine;

// Token: 0x020000CA RID: 202
public class MainMenuToolboxC : MonoBehaviour
{
	// Token: 0x060007F5 RID: 2037 RVA: 0x000A1A0C File Offset: 0x0009FE0C
	public void Action()
	{
		this.book.SendMessage("CloseBookNoParticle");
		this.book.SendMessage("OpenOptions");
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x000A1A30 File Offset: 0x0009FE30
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.renderTarget.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x000A1A79 File Offset: 0x0009FE79
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.renderTarget.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x000A1A98 File Offset: 0x0009FE98
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.renderTarget.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000A4B RID: 2635
	public bool isGlowing;

	// Token: 0x04000A4C RID: 2636
	public Material startMaterial;

	// Token: 0x04000A4D RID: 2637
	public Material glowMaterial;

	// Token: 0x04000A4E RID: 2638
	public GameObject renderTarget;

	// Token: 0x04000A4F RID: 2639
	public GameObject book;
}
