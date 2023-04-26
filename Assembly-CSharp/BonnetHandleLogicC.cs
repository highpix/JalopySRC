using System;
using UnityEngine;

// Token: 0x0200010C RID: 268
public class BonnetHandleLogicC : MonoBehaviour
{
	// Token: 0x06000A95 RID: 2709 RVA: 0x000F9286 File Offset: 0x000F7686
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000A96 RID: 2710 RVA: 0x000F92B0 File Offset: 0x000F76B0
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x000F9308 File Offset: 0x000F7708
	public void Trigger()
	{
		if (this.carLogic.GetComponent<CarLogicC>() && !this.carLogic.GetComponent<CarLogicC>().uncle.GetComponent<UncleLogicC>().hasGivenEngineRepairTutorial)
		{
			this.carLogic.GetComponent<CarLogicC>().uncle.GetComponent<UncleLogicC>().StartCoroutine("BonnetLatchPulled");
		}
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.positionMove[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType,
			"oncomplete",
			"OpenBonnet",
			"oncompletetarget",
			base.gameObject
		}));
		if (this.carLogic.GetComponent<CarLogicC>())
		{
			if (!this.carLogic.GetComponent<CarLogicC>().bonnetPopped)
			{
				this.uncle.SendMessage("PlayerOpensTheBonnetLatch");
				this.bonnetTarget.GetComponent<BonnetLogicC>().PopBonnet();
			}
		}
		else if (!this.bonnetTarget.GetComponent<BonnetLogicC>().abandonBonnetPopped)
		{
			this.bonnetTarget.GetComponent<BonnetLogicC>().PopBonnet();
		}
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x000F949A File Offset: 0x000F789A
	public void OpenBonnet()
	{
		this.MoveBack();
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x000F94A4 File Offset: 0x000F78A4
	public void MoveBack()
	{
		iTween.Stop(base.gameObject.transform.parent.gameObject);
		iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.positionMove[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
	}

	// Token: 0x06000A9A RID: 2714 RVA: 0x000F9549 File Offset: 0x000F7949
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000A9B RID: 2715 RVA: 0x000F9572 File Offset: 0x000F7972
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000E9E RID: 3742
	public GameObject carLogic;

	// Token: 0x04000E9F RID: 3743
	public GameObject uncle;

	// Token: 0x04000EA0 RID: 3744
	public float timeToComplete = 2.05f;

	// Token: 0x04000EA1 RID: 3745
	public GameObject bonnetTarget;

	// Token: 0x04000EA2 RID: 3746
	public Vector3[] positionMove;

	// Token: 0x04000EA3 RID: 3747
	public Material glowMaterial;

	// Token: 0x04000EA4 RID: 3748
	public Material startMaterial;

	// Token: 0x04000EA5 RID: 3749
	public string easeType = "easeoutelastic";

	// Token: 0x04000EA6 RID: 3750
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000EA7 RID: 3751
	private bool isGlowing;
}
