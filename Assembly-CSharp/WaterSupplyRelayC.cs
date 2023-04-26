using System;
using UnityEngine;

// Token: 0x0200012C RID: 300
public class WaterSupplyRelayC : MonoBehaviour
{
	// Token: 0x06000C39 RID: 3129 RVA: 0x00128C9C File Offset: 0x0012709C
	private void Start()
	{
		WaterSupplyRelay component = base.GetComponent<WaterSupplyRelay>();
		UnityEngine.Object.DestroyImmediate(component);
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.WaterUpdate();
		this.myLid = this.lid.GetComponent<WaterLidC>();
		base.Invoke("WaterUpdate", 1f);
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x00128D00 File Offset: 0x00127100
	private void Update()
	{
		if (base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges == base.transform.parent.GetComponent<EngineComponentC>().totalWaterCharges)
		{
			if (this.spriteTarget.active)
			{
				this.spriteTarget.SetActive(false);
			}
		}
		else
		{
			if (!this.spriteTarget.active)
			{
				this.spriteTarget.SetActive(true);
			}
			this.spriteTarget.transform.LookAt(this._camera.transform.position, -Vector3.up);
			if (this.spriteTimer > this.spriteTimerCheck)
			{
				if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[0])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[1];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[1])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[2];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[2])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[3];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[3])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
				}
				this.spriteTimer = 0f;
			}
			this.spriteTimer += Time.deltaTime;
		}
	}

	// Token: 0x06000C3B RID: 3131 RVA: 0x00128EC8 File Offset: 0x001272C8
	private void Action()
	{
		base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges += 4;
		if (base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges > base.transform.parent.GetComponent<EngineComponentC>().totalWaterCharges)
		{
			base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges = base.transform.parent.GetComponent<EngineComponentC>().totalWaterCharges;
		}
		if (this.carLogic.GetComponent<ExtraUpgradesC>().dashUIInstalled && this.carLogic.GetComponent<CarLogicC>().engineOn)
		{
			double num = (double)base.transform.parent.GetComponent<EngineComponentC>().totalWaterCharges * 0.34;
			double num2 = (double)base.transform.parent.GetComponent<EngineComponentC>().totalWaterCharges * 0.67;
			if ((double)base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges > num)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().HighWaterUI();
			}
			else if ((double)base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges < num && (double)base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges > 0.0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LowWaterUI();
			}
			else if (base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().OutOfWaterUI();
			}
		}
		this.WaterUpdate();
	}

	// Token: 0x06000C3C RID: 3132 RVA: 0x00129070 File Offset: 0x00127470
	public void WaterUpdate()
	{
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		int currentWaterCharges = base.transform.parent.GetComponent<EngineComponentC>().currentWaterCharges;
		for (int i = 0; i < this.waterSegments.Length; i++)
		{
			if (i < currentWaterCharges)
			{
				this.waterSegments[i].SetActive(true);
			}
			else
			{
				this.waterSegments[i].SetActive(false);
			}
		}
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x001290F5 File Offset: 0x001274F5
	public void LidUp()
	{
		if (this.myLid.currentPos == 0)
		{
			this.lid.SendMessage("Trigger");
		}
		this.lidOpen = true;
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x0012911E File Offset: 0x0012751E
	public void LidDown()
	{
		if (this.myLid.currentPos == 1)
		{
			this.lid.SendMessage("Trigger");
		}
		this.lidOpen = false;
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x00129148 File Offset: 0x00127548
	public void RayCastEnter()
	{
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x0012914A File Offset: 0x0012754A
	public void RayCastExit()
	{
	}

	// Token: 0x040010CB RID: 4299
	private GameObject _camera;

	// Token: 0x040010CC RID: 4300
	public GameObject lid;

	// Token: 0x040010CD RID: 4301
	public GameObject carLogic;

	// Token: 0x040010CE RID: 4302
	public bool lidOpen;

	// Token: 0x040010CF RID: 4303
	public GameObject[] waterSegments = new GameObject[0];

	// Token: 0x040010D0 RID: 4304
	public Sprite[] sprites = new Sprite[0];

	// Token: 0x040010D1 RID: 4305
	public GameObject spriteTarget;

	// Token: 0x040010D2 RID: 4306
	private float spriteTimer;

	// Token: 0x040010D3 RID: 4307
	public float spriteTimerCheck = 0.3f;

	// Token: 0x040010D4 RID: 4308
	public WaterLidC myLid;
}
