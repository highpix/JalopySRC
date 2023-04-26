using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
public class ExtraReceiverC : MonoBehaviour
{
	// Token: 0x060005D3 RID: 1491 RVA: 0x0007512C File Offset: 0x0007352C
	public void GlowMesh()
	{
		this.glowGo = true;
		for (int i = 0; i < this.glowMesh.Length; i++)
		{
			if (this.glowMesh[i] != null)
			{
				this.glowMesh[i].GetComponent<MeshRenderer>().enabled = true;
			}
		}
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x0007517F File Offset: 0x0007357F
	public void GlowDecal()
	{
		this.glowGo = true;
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x00075188 File Offset: 0x00073588
	public void GlowStop()
	{
		this.glowGo = false;
		if (this.isDecal)
		{
			return;
		}
		for (int i = 0; i < this.glowMesh.Length; i++)
		{
			if (this.glowMesh[i] != null)
			{
				this.glowMesh[i].GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x000751E8 File Offset: 0x000735E8
	private void Update()
	{
		if (this.glowGo && !this.stopGlow)
		{
			if (this.isDecal)
			{
				for (int i = 0; i < this.glowMesh.Length; i++)
				{
					float t = Mathf.PingPong(Time.time, 0.5f) + 0.02f;
					float value = Mathf.Lerp(0.15f, 0.75f, t);
					this.glowMesh[i].GetComponent<Renderer>().materials[1].color.SetAlpha(value);
				}
			}
			else
			{
				foreach (GameObject gameObject in this.glowMesh)
				{
					float value2 = Mathf.PingPong(Time.time, 0.5f) + 0.02f;
					gameObject.GetComponent<Renderer>().material.SetFloat("_Shininess", value2);
				}
			}
		}
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x000752D0 File Offset: 0x000736D0
	public void Action()
	{
		this.extraComponent.active = true;
		base.GetComponent<BoxCollider>().enabled = false;
		for (int i = 0; i < this.glowMesh.Length; i++)
		{
			UnityEngine.Object.Destroy(this.glowMesh[i]);
			this.glowGo = false;
			this.stopGlow = true;
		}
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x00075329 File Offset: 0x00073729
	public void ToolRackToLvl2()
	{
		base.transform.GetChild(0).transform.GetChild(0).GetComponent<ToolRackC>().UpgradeToLvl2();
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x0007534C File Offset: 0x0007374C
	public void ToolRackToLvl3()
	{
		base.transform.GetChild(0).transform.GetChild(0).GetComponent<ToolRackC>().UpgradeToLvl3();
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00075370 File Offset: 0x00073770
	public void CollisionsOn()
	{
		if (this.roofRack && this.glowMesh[0] == null)
		{
			return;
		}
		BoxCollider[] components = base.gameObject.GetComponents<BoxCollider>();
		foreach (BoxCollider boxCollider in components)
		{
			boxCollider.enabled = true;
		}
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x000753CC File Offset: 0x000737CC
	public void CollisionsOff()
	{
		BoxCollider[] components = base.gameObject.GetComponents<BoxCollider>();
		foreach (BoxCollider boxCollider in components)
		{
			boxCollider.enabled = false;
		}
	}

	// Token: 0x0400084F RID: 2127
	public bool roofRack;

	// Token: 0x04000850 RID: 2128
	public bool isDecal;

	// Token: 0x04000851 RID: 2129
	public GameObject[] glowMesh;

	// Token: 0x04000852 RID: 2130
	public bool glowGo;

	// Token: 0x04000853 RID: 2131
	public bool stopGlow;

	// Token: 0x04000854 RID: 2132
	public GameObject extraComponent;
}
