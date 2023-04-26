using System;
using UnityEngine;

// Token: 0x02000132 RID: 306
public class ShopLeverC : MonoBehaviour
{
	// Token: 0x06000C61 RID: 3169 RVA: 0x0012B784 File Offset: 0x00129B84
	private void Reset()
	{
		ShopLever component = base.GetComponent<ShopLever>();
		this.shop = component.shop;
		component.renderTargets.Copy(ref this.renderTargets);
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.isGlowing = component.isGlowing;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x0012B7DF File Offset: 0x00129BDF
	private void Start()
	{
		if (this.renderTargets.Length > 0)
		{
			this.startMaterial = this.renderTargets[0].GetComponent<Renderer>().material;
		}
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x0012B808 File Offset: 0x00129C08
	private void Update()
	{
		if (this.isGlowing)
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
				gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
	}

	// Token: 0x06000C64 RID: 3172 RVA: 0x0012B86C File Offset: 0x00129C6C
	public void Hover()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (!gameObject.GetComponent<MemoryBankC>().shopLeverExplained)
		{
			this.shop.SendMessage("DialogueExplainLever");
			gameObject.GetComponent<MemoryBankC>().shopLeverExplained = true;
		}
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x0012B8B0 File Offset: 0x00129CB0
	public void Trigger()
	{
		this.shop.SendMessage("CancelTransaction");
		base.transform.parent.GetComponent<Animator>().SetTrigger("Pull");
	}

	// Token: 0x06000C66 RID: 3174 RVA: 0x0012B8DC File Offset: 0x00129CDC
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.Hover();
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.glowMaterial;
		}
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x0012B928 File Offset: 0x00129D28
	public void RaycastExit()
	{
		this.isGlowing = false;
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x04001113 RID: 4371
	public GameObject shop;

	// Token: 0x04001114 RID: 4372
	public GameObject[] renderTargets = new GameObject[0];

	// Token: 0x04001115 RID: 4373
	public Material startMaterial;

	// Token: 0x04001116 RID: 4374
	public Material glowMaterial;

	// Token: 0x04001117 RID: 4375
	public bool isGlowing;
}
