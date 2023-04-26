using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class ExtraComponentC : MonoBehaviour
{
	// Token: 0x060005C4 RID: 1476 RVA: 0x00074366 File Offset: 0x00072766
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x00074388 File Offset: 0x00072788
	private void Update()
	{
		if ((double)this.openTimer >= 0.7 && !this.debugOpen)
		{
			this.debugOpen = true;
			this.ActionPart2();
		}
		if (Input.GetButton("Fire1") && (double)this.openTimer < 0.7 && this.readyToOpen)
		{
			this.openTimer += Time.deltaTime;
		}
		else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) && (double)this.openTimer < 0.7 && this.readyToOpen)
		{
			this.openTimer += Time.deltaTime;
		}
		else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[17]) && (double)this.openTimer < 0.7 && this.readyToOpen)
		{
			this.openTimer += Time.deltaTime;
		}
		if (Input.GetButtonUp("Fire1") && !this.debugOpen && this.readyToOpen)
		{
			this.StopOpen();
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) && !this.debugOpen && this.readyToOpen)
		{
			this.StopOpen();
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17]) && !this.debugOpen && this.readyToOpen)
		{
			this.StopOpen();
		}
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x0007453C File Offset: 0x0007293C
	public void PickUp()
	{
		if (this.isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().decalColour = this.materialColour;
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.material, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlow();
		}
		else
		{
			if (this.componentID == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().RoofRackGlow();
			}
			if (this.componentID == 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BullBarGlow();
			}
			if (this.componentID == 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().MudGuardsGlow();
			}
			if (this.componentID == 3)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().DigitalDashGlow();
			}
			if (this.componentID == 4)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LightRackGlow();
			}
			if (this.componentID == 5)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlow();
			}
			if (this.componentID == 6)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlow();
			}
			if (this.componentID == 7)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlow();
			}
		}
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x00074675 File Offset: 0x00072A75
	public void DecalReload()
	{
		this.carLogic.GetComponent<ExtraUpgradesC>().decalColour = this.materialColour;
		this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.material, true);
		this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlow();
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x000746B4 File Offset: 0x00072AB4
	public void MoveToSlot1()
	{
		if (this.isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().decalColour = this.materialColour;
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.material, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlow();
		}
		else
		{
			if (this.componentID == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().RoofRackGlow();
			}
			if (this.componentID == 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BullBarGlow();
			}
			if (this.componentID == 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().MudGuardsGlow();
			}
			if (this.componentID == 3)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().DigitalDashGlow();
			}
			if (this.componentID == 4)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LightRackGlow();
			}
			if (this.componentID == 5)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlow();
			}
			if (this.componentID == 6)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlow();
			}
			if (this.componentID == 7)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlow();
			}
		}
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x000747F0 File Offset: 0x00072BF0
	public void MoveToSlot2()
	{
		if (this.isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.carLogic.GetComponent<ExtraUpgradesC>().currentDecal, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlowStop();
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ExtraComponentC>() && this._camera.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
			{
				this._camera.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ExtraComponentC>().MoveToSlot1();
			}
		}
		else
		{
			if (this.componentID == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().RoofRackGlowStop();
			}
			if (this.componentID == 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BullBarGlowStop();
			}
			if (this.componentID == 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().MudGuardsGlowStop();
			}
			if (this.componentID == 3)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().DigitalDashGlowStop();
			}
			if (this.componentID == 4)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LightRackGlowStop();
			}
			if (this.componentID == 5)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
			if (this.componentID == 6)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
			if (this.componentID == 7)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
		}
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x00074990 File Offset: 0x00072D90
	public void MoveToSlot3()
	{
		if (this.isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.carLogic.GetComponent<ExtraUpgradesC>().currentDecal, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlowStop();
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ExtraComponentC>() && this._camera.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
			{
				this._camera.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ExtraComponentC>().MoveToSlot1();
			}
		}
		else
		{
			if (this.componentID == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().RoofRackGlowStop();
			}
			if (this.componentID == 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BullBarGlowStop();
			}
			if (this.componentID == 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().MudGuardsGlowStop();
			}
			if (this.componentID == 3)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().DigitalDashGlowStop();
			}
			if (this.componentID == 4)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LightRackGlowStop();
			}
			if (this.componentID == 5)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
			if (this.componentID == 6)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
			if (this.componentID == 7)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
		}
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x00074B30 File Offset: 0x00072F30
	public void StopRendering()
	{
		if (this.isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.carLogic.GetComponent<ExtraUpgradesC>().currentDecal, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlowStop();
		}
		if (this.componentID == 0)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().RoofRackGlowStop();
		}
		if (this.componentID == 1)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().BullBarGlowStop();
		}
		if (this.componentID == 2)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().MudGuardsGlowStop();
		}
		if (this.componentID == 3)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().DigitalDashGlowStop();
		}
		if (this.componentID == 4)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().LightRackGlowStop();
		}
		if (this.componentID == 5)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
		}
		if (this.componentID == 6)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
		}
		if (this.componentID == 7)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
		}
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x00074C58 File Offset: 0x00073058
	public void ThrowLogic()
	{
		if (this.isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.carLogic.GetComponent<ExtraUpgradesC>().currentDecal, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlowStop();
		}
		else
		{
			if (this.componentID == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().RoofRackGlowStop();
			}
			if (this.componentID == 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BullBarGlowStop();
			}
			if (this.componentID == 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().MudGuardsGlowStop();
			}
			if (this.componentID == 3)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().DigitalDashGlowStop();
			}
			if (this.componentID == 4)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LightRackGlowStop();
			}
			if (this.componentID == 5)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
			if (this.componentID == 6)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
			if (this.componentID == 7)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackGlowStop();
			}
		}
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x00074D88 File Offset: 0x00073188
	public void Action()
	{
		if (!this.debugOpen && !this.readyToOpen)
		{
			this.readyToOpen = true;
			this.animTarget.GetComponent<Animator>().SetBool("Open", true);
			base.gameObject.GetComponent<AudioSource>().clip = this.audioOpen;
			base.gameObject.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x00074DF0 File Offset: 0x000731F0
	public void DestroySprites()
	{
		for (int i = 0; i < this.sprites.Length; i++)
		{
			this.sprites[i].SetActive(false);
		}
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x00074E24 File Offset: 0x00073224
	public void StopOpen()
	{
		this.openTimer = 0f;
		base.GetComponent<AudioSource>().Stop();
		this.animTarget.GetComponent<Animator>().SetBool("Open", false);
		this.readyToOpen = false;
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x00074E5C File Offset: 0x0007325C
	public void ActionPart2()
	{
		if (this.isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().decalColour = this.materialColour;
			this.carLogic.GetComponent<ExtraUpgradesC>().installedDecalID = this.componentID;
			this.carLogic.GetComponent<ExtraUpgradesC>().NewDecal(this.material);
		}
		else
		{
			int weight = Mathf.RoundToInt(base.GetComponent<EngineComponentC>().weight);
			if (this.componentID == 0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().RoofRackFitted(weight);
			}
			if (this.componentID == 1)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().BullBarFitted(weight);
			}
			if (this.componentID == 2)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().MudGuardsFitted(weight);
			}
			if (this.componentID == 3)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().DigitalDashFitted(weight);
			}
			if (this.componentID == 4)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().LightRackFitted(weight);
			}
			if (this.componentID == 5)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackFitted(weight, 1);
			}
			if (this.componentID == 6)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackFitted(weight, 2);
			}
			if (this.componentID == 7)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().ToolRackFitted(weight, 3);
			}
		}
		base.StartCoroutine("ParticlesAndAnim");
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x00074FC4 File Offset: 0x000733C4
	private IEnumerator ParticlesAndAnim()
	{
		GameObject particleInstance = UnityEngine.Object.Instantiate<GameObject>(this.particlePrefab, base.transform.position, Quaternion.identity);
		UnityEngine.Object.Destroy(particleInstance, 0.55f);
		this.carLogic.GetComponent<ExtraUpgradesC>().ParticlesAndAnim(particleInstance);
		this.animTarget.GetComponent<Animator>().SetBool("Die", true);
		this.DestroySprites();
		yield return new WaitForSeconds(0.6f);
		this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
		this._camera.GetComponent<DragRigidbodyC>().MoveItemsRightInventory();
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x0400083F RID: 2111
	private GameObject _camera;

	// Token: 0x04000840 RID: 2112
	public GameObject carLogic;

	// Token: 0x04000841 RID: 2113
	public int componentID;

	// Token: 0x04000842 RID: 2114
	public bool debugFitCar;

	// Token: 0x04000843 RID: 2115
	public GameObject particlePrefab;

	// Token: 0x04000844 RID: 2116
	public GameObject animTarget;

	// Token: 0x04000845 RID: 2117
	public AudioClip audioOpen;

	// Token: 0x04000846 RID: 2118
	public float openTimer;

	// Token: 0x04000847 RID: 2119
	public bool readyToOpen;

	// Token: 0x04000848 RID: 2120
	public bool debugOpen;

	// Token: 0x04000849 RID: 2121
	public bool debugDie;

	// Token: 0x0400084A RID: 2122
	public bool isCustomDecal;

	// Token: 0x0400084B RID: 2123
	public Material material;

	// Token: 0x0400084C RID: 2124
	public Material noDecalMaterial;

	// Token: 0x0400084D RID: 2125
	public Color materialColour;

	// Token: 0x0400084E RID: 2126
	public GameObject[] sprites = new GameObject[0];
}
