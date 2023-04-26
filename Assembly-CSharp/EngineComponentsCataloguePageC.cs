using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x0200002A RID: 42
public class EngineComponentsCataloguePageC : MonoBehaviour
{
	// Token: 0x060000CF RID: 207 RVA: 0x000085CC File Offset: 0x000069CC
	private void Reset()
	{
		EngineComponentsCataloguePage component = base.GetComponent<EngineComponentsCataloguePage>();
		this.director = component.director;
		this.shop = component.shop;
		this.receipt = component.receipt;
		this.letter = component.letter;
		this.envelope = component.envelope;
		this.componentLogo1 = component.componentLogo1;
		this.componentLogo2 = component.componentLogo2;
		this.componentLogo3 = component.componentLogo3;
		this.totalPrice = component.totalPrice;
		this.componentTarget1 = component.componentTarget1;
		this.componentTarget2 = component.componentTarget2;
		this.componentTarget3 = component.componentTarget3;
		this.componentTarget4 = component.componentTarget4;
		this.componentTarget5 = component.componentTarget5;
		this.componentTarget6 = component.componentTarget6;
		this.componentTarget7 = component.componentTarget7;
		this.pageDescription = component.pageDescription;
		component.envelopePos.Copy(ref this.envelopePos);
		component.spawnLocations.Copy(ref this.spawnLocations);
		component.purchaseDetails.Copy(ref this.purchaseDetails);
		this.shoppingList = new List<GameObject>(component.shoppingList);
		this.prefabs = new List<GameObject>(component.prefabs);
		this.prefabSelected = new List<GameObject>(component.prefabSelected);
		this.prefabExtras = new List<GameObject>(component.prefabExtras);
		this.prefabExtrasSelected = new List<GameObject>(component.prefabExtrasSelected);
		this.prefabExtrasUpgradeLvls = new List<GameObject>(component.prefabExtrasUpgradeLvls);
		this.prefabPaintDecals = new List<GameObject>(component.prefabPaintDecals);
		this.prefabPaintDecalsSelected = new List<GameObject>(component.prefabPaintDecalsSelected);
		component.localisationPickup.Copy(ref this.localisationPickup);
		component.receiptStrings.Copy(ref this.receiptStrings);
		component.receiptPrices.Copy(ref this.receiptPrices);
		this.componentSprites = new List<Sprite>(component.componentSprites);
		this.prefabSpritesSelected = new List<Sprite>(component.prefabSpritesSelected);
		this.prefabExtrasSpritesLibrary = new List<Sprite>(component.prefabExtrasSpritesLibrary);
		this.prefabExtrasSprites = new List<Sprite>(component.prefabExtrasSprites);
		this.prefabPaintDecalsSpritesLibrary = new List<Sprite>(component.prefabPaintDecalsSpritesLibrary);
		this.prefabPaintDecalsSprites = new List<Sprite>(component.prefabPaintDecalsSprites);
		this.numTotalPrice = component.numTotalPrice;
		this.audioError = component.audioError;
		this.walletHolder = component.walletHolder;
		this.engNumHolder = component.engNumHolder;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00008836 File Offset: 0x00006C36
	public void Start()
	{
		this.director = GameObject.FindWithTag("Director");
		this.SelectExtras();
		this.SelectPaintDecals();
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00008854 File Offset: 0x00006C54
	private void SelectExtras()
	{
		int index = UnityEngine.Random.Range(0, this.prefabExtras.Count);
		this.prefabExtrasSelected.Add(this.prefabExtras[index]);
		this.prefabExtras.RemoveAt(index);
		this.prefabExtrasSprites.Add(this.prefabExtrasSpritesLibrary[index]);
		this.prefabExtrasSpritesLibrary.RemoveAt(index);
		int index2 = UnityEngine.Random.Range(0, this.prefabExtras.Count);
		this.prefabExtrasSelected.Add(this.prefabExtras[index2]);
		this.prefabExtras.RemoveAt(index2);
		this.prefabExtrasSprites.Add(this.prefabExtrasSpritesLibrary[index2]);
		this.prefabExtrasSpritesLibrary.RemoveAt(index2);
		int index3 = UnityEngine.Random.Range(0, this.prefabExtras.Count);
		this.prefabExtrasSelected.Add(this.prefabExtras[index3]);
		this.prefabExtras.RemoveAt(index3);
		this.prefabExtrasSprites.Add(this.prefabExtrasSpritesLibrary[index3]);
		this.prefabExtrasSpritesLibrary.RemoveAt(index3);
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		if (this.prefabExtrasSelected[0].transform.name == "Upgrade06_ToolRack")
		{
			if (gameObject.GetComponent<ExtraUpgradesC>().toolRackLevel == 1)
			{
				this.prefabExtrasSelected[0] = this.prefabExtrasUpgradeLvls[0];
			}
			else if (gameObject.GetComponent<ExtraUpgradesC>().toolRackLevel == 2)
			{
				this.prefabExtrasSelected[0] = this.prefabExtrasUpgradeLvls[1];
			}
		}
		else if (this.prefabExtrasSelected[1].transform.name == "Upgrade06_ToolRack")
		{
			if (gameObject.GetComponent<ExtraUpgradesC>().toolRackLevel == 1)
			{
				this.prefabExtrasSelected[1] = this.prefabExtrasUpgradeLvls[0];
			}
			else if (gameObject.GetComponent<ExtraUpgradesC>().toolRackLevel == 2)
			{
				this.prefabExtrasSelected[1] = this.prefabExtrasUpgradeLvls[1];
			}
		}
		else if (this.prefabExtrasSelected[2].transform.name == "Upgrade06_ToolRack")
		{
			if (gameObject.GetComponent<ExtraUpgradesC>().toolRackLevel == 1)
			{
				this.prefabExtrasSelected[2] = this.prefabExtrasUpgradeLvls[0];
			}
			else if (gameObject.GetComponent<ExtraUpgradesC>().toolRackLevel == 2)
			{
				this.prefabExtrasSelected[2] = this.prefabExtrasUpgradeLvls[1];
			}
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00008AF4 File Offset: 0x00006EF4
	public void SelectPaintDecals()
	{
		int index = UnityEngine.Random.Range(0, this.prefabPaintDecals.Count);
		this.prefabPaintDecalsSelected.Add(this.prefabPaintDecals[index]);
		this.prefabPaintDecals.RemoveAt(index);
		this.prefabPaintDecalsSprites.Add(this.prefabPaintDecalsSpritesLibrary[index]);
		this.prefabPaintDecalsSpritesLibrary.RemoveAt(index);
		int index2 = UnityEngine.Random.Range(0, this.prefabPaintDecals.Count);
		this.prefabPaintDecalsSelected.Add(this.prefabPaintDecals[index2]);
		this.prefabPaintDecals.RemoveAt(index2);
		this.prefabPaintDecalsSprites.Add(this.prefabPaintDecalsSpritesLibrary[index2]);
		this.prefabPaintDecalsSpritesLibrary.RemoveAt(index2);
		int index3 = UnityEngine.Random.Range(0, this.prefabPaintDecals.Count);
		this.prefabPaintDecalsSelected.Add(this.prefabPaintDecals[index3]);
		this.prefabPaintDecals.RemoveAt(index3);
		this.prefabPaintDecalsSprites.Add(this.prefabPaintDecalsSpritesLibrary[index3]);
		this.prefabPaintDecalsSpritesLibrary.RemoveAt(index3);
		int index4 = UnityEngine.Random.Range(0, this.prefabPaintDecals.Count);
		this.prefabPaintDecalsSelected.Add(this.prefabPaintDecals[index4]);
		this.prefabPaintDecals.RemoveAt(index4);
		this.prefabPaintDecalsSprites.Add(this.prefabPaintDecalsSpritesLibrary[index4]);
		this.prefabPaintDecalsSpritesLibrary.RemoveAt(index4);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00008C64 File Offset: 0x00007064
	public void SelectEngineComponents()
	{
		int index = UnityEngine.Random.Range(0, 27);
		this.prefabSelected.Add(this.prefabs[index]);
		this.prefabs.RemoveAt(index);
		this.prefabSpritesSelected.Add(this.componentSprites[index]);
		this.componentSprites.RemoveAt(index);
		int index2 = UnityEngine.Random.Range(0, 26);
		this.prefabSelected.Add(this.prefabs[index2]);
		this.prefabs.RemoveAt(index2);
		this.prefabSpritesSelected.Add(this.componentSprites[index2]);
		this.componentSprites.RemoveAt(index2);
		int index3 = UnityEngine.Random.Range(0, 25);
		this.prefabSelected.Add(this.prefabs[index3]);
		this.prefabs.RemoveAt(index3);
		this.prefabSpritesSelected.Add(this.componentSprites[index3]);
		this.componentSprites.RemoveAt(index3);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00008D60 File Offset: 0x00007160
	public void SelectFuelTankComponents()
	{
		int index = UnityEngine.Random.Range(25, 52);
		this.prefabSelected.Add(this.prefabs[index]);
		this.prefabs.RemoveAt(index);
		this.prefabSpritesSelected.Add(this.componentSprites[index]);
		this.componentSprites.RemoveAt(index);
		int index2 = UnityEngine.Random.Range(25, 51);
		this.prefabSelected.Add(this.prefabs[index2]);
		this.prefabs.RemoveAt(index2);
		this.prefabSpritesSelected.Add(this.componentSprites[index2]);
		this.componentSprites.RemoveAt(index2);
		int index3 = UnityEngine.Random.Range(25, 50);
		this.prefabSelected.Add(this.prefabs[index3]);
		this.prefabs.RemoveAt(index3);
		this.prefabSpritesSelected.Add(this.componentSprites[index3]);
		this.componentSprites.RemoveAt(index3);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00008E60 File Offset: 0x00007260
	public void SelectCarburettorComponents()
	{
		int index = UnityEngine.Random.Range(50, 77);
		this.prefabSelected.Add(this.prefabs[index]);
		this.prefabs.RemoveAt(index);
		this.prefabSpritesSelected.Add(this.componentSprites[index]);
		this.componentSprites.RemoveAt(index);
		int index2 = UnityEngine.Random.Range(50, 76);
		this.prefabSelected.Add(this.prefabs[index2]);
		this.prefabs.RemoveAt(index2);
		this.prefabSpritesSelected.Add(this.componentSprites[index2]);
		this.componentSprites.RemoveAt(index2);
		int index3 = UnityEngine.Random.Range(50, 75);
		this.prefabSelected.Add(this.prefabs[index3]);
		this.prefabs.RemoveAt(index3);
		this.prefabSpritesSelected.Add(this.componentSprites[index3]);
		this.componentSprites.RemoveAt(index3);
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00008F60 File Offset: 0x00007360
	public void SelectAirFilterComponents()
	{
		int index = UnityEngine.Random.Range(75, 102);
		this.prefabSelected.Add(this.prefabs[index]);
		this.prefabs.RemoveAt(index);
		this.prefabSpritesSelected.Add(this.componentSprites[index]);
		this.componentSprites.RemoveAt(index);
		int index2 = UnityEngine.Random.Range(75, 101);
		this.prefabSelected.Add(this.prefabs[index2]);
		this.prefabs.RemoveAt(index2);
		this.prefabSpritesSelected.Add(this.componentSprites[index2]);
		this.componentSprites.RemoveAt(index2);
		int index3 = UnityEngine.Random.Range(75, 100);
		this.prefabSelected.Add(this.prefabs[index3]);
		this.prefabs.RemoveAt(index3);
		this.prefabSpritesSelected.Add(this.componentSprites[index3]);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00009054 File Offset: 0x00007454
	public void SelectIgnitionCoilComponents()
	{
		int index = UnityEngine.Random.Range(100, 127);
		this.prefabSelected.Add(this.prefabs[index]);
		this.prefabs.RemoveAt(index);
		this.prefabSpritesSelected.Add(this.componentSprites[index]);
		this.componentSprites.RemoveAt(index);
		int index2 = UnityEngine.Random.Range(100, 126);
		this.prefabSelected.Add(this.prefabs[index2]);
		this.prefabs.RemoveAt(index2);
		this.prefabSpritesSelected.Add(this.componentSprites[index2]);
		this.componentSprites.RemoveAt(index2);
		int index3 = UnityEngine.Random.Range(100, 125);
		this.prefabSelected.Add(this.prefabs[index3]);
		this.prefabs.RemoveAt(index3);
		this.prefabSpritesSelected.Add(this.componentSprites[index3]);
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00009148 File Offset: 0x00007548
	public void SelectBatteryComponents()
	{
		int index = UnityEngine.Random.Range(125, 128);
		this.prefabSelected.Add(this.prefabs[index]);
		this.prefabs.RemoveAt(index);
		this.prefabSpritesSelected.Add(this.componentSprites[index]);
		this.componentSprites.RemoveAt(index);
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x000091A8 File Offset: 0x000075A8
	public void SelectWaterTankComponents()
	{
		int index = UnityEngine.Random.Range(128, 131);
		this.prefabSelected.Add(this.prefabs[index]);
		this.prefabs.RemoveAt(index);
		this.prefabSpritesSelected.Add(this.componentSprites[index]);
		this.componentSprites.RemoveAt(index);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0000920C File Offset: 0x0000760C
	public void PageGo()
	{
		this.receipt.transform.localPosition = this.envelopePos[4];
		if (this.localisationPickup.Length > 0)
		{
			this.localisationPickup[0].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_82", "Inspector_UI");
			this.localisationPickup[1].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_83", "Inspector_UI");
			this.localisationPickup[2].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_84", "Inspector_UI");
			this.localisationPickup[3].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_85", "Inspector_UI");
			this.localisationPickup[4].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_86", "Inspector_UI");
			this.localisationPickup[5].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_87", "Inspector_UI");
			this.localisationPickup[6].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_88", "Inspector_UI");
			this.localisationPickup[7].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_89", "Inspector_UI");
			this.localisationPickup[8].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_90", "Inspector_UI");
			this.localisationPickup[9].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_91", "Inspector_UI");
			this.localisationPickup[10].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_92", "Inspector_UI");
			this.localisationPickup[11].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_93", "Inspector_UI");
			this.localisationPickup[12].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_94", "Inspector_UI");
			this.localisationPickup[13].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_95", "Inspector_UI");
			this.localisationPickup[14].GetComponent<TextMeshPro>().text = Language.Get("ui_pickup_96", "Inspector_UI");
		}
		iTween.MoveTo(this.receipt, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[3],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutquad"
		}));
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		this.letter.GetComponent<Animator>().SetBool("open", true);
		this.EnvelopeDown();
		GameObject wallet = this.director.GetComponent<DirectorC>().wallet;
		this.walletPrevParent = wallet.transform.parent;
		this.walletPrevPos = wallet.transform.localPosition;
		this.walletPrevRot = wallet.transform.localEulerAngles;
		iTween.MoveTo(wallet, iTween.Hash(new object[]
		{
			"position",
			this.walletHolder,
			"time",
			0.3,
			"islocal",
			false,
			"easetype",
			"easeoutquad"
		}));
		iTween.RotateTo(wallet, iTween.Hash(new object[]
		{
			"rotation",
			this.walletHolder,
			"time",
			0.25,
			"easetype",
			"easeoutquad"
		}));
		this.ComponentGo(0);
	}

	// Token: 0x060000DB RID: 219 RVA: 0x000095E0 File Offset: 0x000079E0
	public void EnvelopeDown()
	{
		iTween.MoveTo(this.envelope, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[1],
			"delay",
			1.0,
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"EnvelopeBehind",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060000DC RID: 220 RVA: 0x000096A0 File Offset: 0x00007AA0
	public void EnvelopeBehind()
	{
		iTween.MoveTo(this.envelope, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[2],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00009720 File Offset: 0x00007B20
	public void PageClose()
	{
		GameObject wallet = this.director.GetComponent<DirectorC>().wallet;
		this.envelope.transform.localPosition = this.envelopePos[0];
		wallet.transform.localPosition = this.walletPrevPos;
		wallet.transform.localEulerAngles = this.walletPrevRot;
		this.receipt.transform.localPosition = this.envelopePos[5];
		this.letter.GetComponent<Animator>().SetBool("open", false);
		this.ClearShoppingList();
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000097C0 File Offset: 0x00007BC0
	public void Close()
	{
		GameObject wallet = this.director.GetComponent<DirectorC>().wallet;
		wallet.transform.localPosition = this.walletPrevPos;
		wallet.transform.localEulerAngles = this.walletPrevRot;
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00009800 File Offset: 0x00007C00
	public void EngineComponentsGo()
	{
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00009804 File Offset: 0x00007C04
	public void ExtrasGo()
	{
		this.pageDescription.GetComponent<TextMeshPro>().text = "Extras!";
		this.componentTarget1.GetComponent<SpriteRenderer>().sprite = this.prefabExtrasSprites[0];
		this.componentTarget2.GetComponent<SpriteRenderer>().sprite = this.prefabExtrasSprites[1];
		this.componentTarget3.GetComponent<SpriteRenderer>().sprite = this.prefabExtrasSprites[2];
		this.componentTarget4.active = false;
		if (this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
		}
		this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
		this.componentTarget5.active = false;
		if (this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
		}
		this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
		this.componentLogo1.active = false;
		this.componentTarget6.active = false;
		if (this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
		}
		this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
		this.componentLogo2.active = false;
		this.componentTarget7.active = false;
		if (this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
		}
		this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
		this.componentLogo3.active = false;
		if (this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabExtrasSelected[0].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabExtrasSelected[0].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		if (this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabExtrasSelected[1].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabExtrasSelected[1].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		if (this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabExtrasSelected[2].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabExtrasSelected[2].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.GetComponent<TextMeshPro>().text = this.prefabExtrasSelected[0].GetComponent<ObjectPickupC>().buyValue.ToString();
		this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.GetComponent<TextMeshPro>().text = this.prefabExtrasSelected[1].GetComponent<ObjectPickupC>().buyValue.ToString();
		this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.GetComponent<TextMeshPro>().text = this.prefabExtrasSelected[2].GetComponent<ObjectPickupC>().buyValue.ToString();
		this.componentTarget1.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		this.componentTarget2.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		this.componentTarget3.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		this.componentTarget4.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		this.componentTarget5.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		this.componentTarget6.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00009E44 File Offset: 0x00008244
	public void PaintDecalsGo()
	{
		this.pageDescription.GetComponent<TextMeshPro>().text = "Paint!";
		this.componentTarget1.GetComponent<SpriteRenderer>().sprite = this.prefabPaintDecalsSprites[0];
		if (this.prefabPaintDecalsSelected[0].GetComponent<PaintCanC>())
		{
			this.componentTarget1.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[0].GetComponent<PaintCanC>().canColor;
		}
		else if (this.prefabPaintDecalsSelected[0].GetComponent<ExtraComponentC>())
		{
			this.componentTarget1.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[0].GetComponent<ExtraComponentC>().materialColour;
		}
		this.componentTarget2.GetComponent<SpriteRenderer>().sprite = this.prefabPaintDecalsSprites[1];
		if (this.prefabPaintDecalsSelected[1].GetComponent<PaintCanC>())
		{
			this.componentTarget2.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[1].GetComponent<PaintCanC>().canColor;
		}
		else if (this.prefabPaintDecalsSelected[1].GetComponent<ExtraComponentC>())
		{
			this.componentTarget2.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[1].GetComponent<ExtraComponentC>().materialColour;
		}
		this.componentTarget3.GetComponent<SpriteRenderer>().sprite = this.prefabPaintDecalsSprites[2];
		if (this.prefabPaintDecalsSelected[2].GetComponent<PaintCanC>())
		{
			this.componentTarget3.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[2].GetComponent<PaintCanC>().canColor;
		}
		else if (this.prefabPaintDecalsSelected[2].GetComponent<ExtraComponentC>())
		{
			this.componentTarget3.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[2].GetComponent<ExtraComponentC>().materialColour;
		}
		this.componentTarget4.active = true;
		if (this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(true);
		}
		this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget4.GetComponent<SpriteRenderer>().sprite = this.prefabPaintDecalsSprites[3];
		if (this.prefabPaintDecalsSelected[3].GetComponent<PaintCanC>())
		{
			this.componentTarget4.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[3].GetComponent<PaintCanC>().canColor;
		}
		else if (this.prefabPaintDecalsSelected[3].GetComponent<ExtraComponentC>())
		{
			this.componentTarget4.GetComponent<SpriteRenderer>().color = this.prefabPaintDecalsSelected[3].GetComponent<ExtraComponentC>().materialColour;
		}
		this.componentTarget5.active = false;
		if (this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
		}
		this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
		this.componentLogo1.active = false;
		this.componentTarget6.active = false;
		if (this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
		}
		this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
		this.componentLogo2.active = false;
		this.componentTarget7.active = false;
		if (this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
		}
		this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
		this.componentLogo3.active = false;
		if (this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[0].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[0].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		if (this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[1].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[1].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		if (this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[2].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[2].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		if (this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[3].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[3].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.GetComponent<TextMeshPro>().text = this.prefabPaintDecalsSelected[0].GetComponent<ObjectPickupC>().buyValue.ToString();
		this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.GetComponent<TextMeshPro>().text = this.prefabPaintDecalsSelected[1].GetComponent<ObjectPickupC>().buyValue.ToString();
		this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.GetComponent<TextMeshPro>().text = this.prefabPaintDecalsSelected[2].GetComponent<ObjectPickupC>().buyValue.ToString();
		this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.GetComponent<TextMeshPro>().text = this.prefabPaintDecalsSelected[3].GetComponent<ObjectPickupC>().buyValue.ToString();
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x0000A6E8 File Offset: 0x00008AE8
	public void AddToShoppingListExtras(int selected)
	{
		float num = this.numTotalPrice + this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue;
		if (this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth < num)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audioError, 0.7f);
			return;
		}
		this.shoppingList.Add(this.prefabExtrasSelected[selected]);
		int num2 = this.shoppingList.Count - 1;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.EN)
		{
			this.receiptStrings[num2].GetComponent<TextMeshPro>().text = Language.Get(this.prefabExtrasSelected[selected].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
		}
		this.receiptPrices[num2].GetComponent<TextMeshPro>().text = this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString();
		if (this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue < 10f && this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue > 0f)
		{
			if (this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue % 1f != 0f)
			{
				this.receiptPrices[num2].GetComponent<TextMeshPro>().text = "0" + this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + "0";
			}
			else
			{
				this.receiptPrices[num2].GetComponent<TextMeshPro>().text = "0" + this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + ".00";
			}
		}
		else if (this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue % 1f != 0f)
		{
			this.receiptPrices[num2].GetComponent<TextMeshPro>().text = this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + "0";
		}
		else
		{
			this.receiptPrices[num2].GetComponent<TextMeshPro>().text = this.prefabExtrasSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + ".00";
		}
		this.numTotalPrice = 0f;
		for (int i = 0; i < this.shoppingList.Count; i++)
		{
			this.numTotalPrice += this.shoppingList[i].GetComponent<ObjectPickupC>().buyValue;
		}
		if (this.numTotalPrice < 10f && this.numTotalPrice > 0f)
		{
			if (this.numTotalPrice % 1f != 0f)
			{
				this.totalPrice.GetComponent<TextMeshPro>().text = "0" + this.numTotalPrice.ToString() + "0";
			}
			else
			{
				this.totalPrice.GetComponent<TextMeshPro>().text = "0" + this.numTotalPrice.ToString() + ".00";
			}
		}
		else if (this.numTotalPrice % 1f != 0f)
		{
			this.totalPrice.GetComponent<TextMeshPro>().text = this.numTotalPrice.ToString() + "0";
		}
		else
		{
			this.totalPrice.GetComponent<TextMeshPro>().text = this.numTotalPrice.ToString() + ".00";
		}
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000AAD8 File Offset: 0x00008ED8
	public void AddToShoppingListPaintDecals(int selected)
	{
		float num = this.numTotalPrice + this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue;
		if (this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth < num)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audioError, 0.7f);
			return;
		}
		this.shoppingList.Add(this.prefabPaintDecalsSelected[selected]);
		int num2 = this.shoppingList.Count - 1;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.EN)
		{
			this.receiptStrings[num2].GetComponent<TextMeshPro>().text = Language.Get(this.prefabPaintDecalsSelected[selected].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
		}
		this.receiptPrices[num2].GetComponent<TextMeshPro>().text = this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString();
		if (this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue < 10f && this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue > 0f)
		{
			if (this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue % 1f != 0f)
			{
				this.receiptPrices[num2].GetComponent<TextMeshPro>().text = "0" + this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + "0";
			}
			else
			{
				this.receiptPrices[num2].GetComponent<TextMeshPro>().text = "0" + this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + ".00";
			}
		}
		else if (this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue % 1f != 0f)
		{
			this.receiptPrices[num2].GetComponent<TextMeshPro>().text = this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + "0";
		}
		else
		{
			this.receiptPrices[num2].GetComponent<TextMeshPro>().text = this.prefabPaintDecalsSelected[selected].GetComponent<ObjectPickupC>().buyValue.ToString() + ".00";
		}
		this.numTotalPrice = 0f;
		for (int i = 0; i < this.shoppingList.Count; i++)
		{
			this.numTotalPrice += this.shoppingList[i].GetComponent<ObjectPickupC>().buyValue;
		}
		if (this.numTotalPrice < 10f && this.numTotalPrice > 0f)
		{
			if (this.numTotalPrice % 1f != 0f)
			{
				this.totalPrice.GetComponent<TextMeshPro>().text = "0" + this.numTotalPrice.ToString() + "0";
			}
			else
			{
				this.totalPrice.GetComponent<TextMeshPro>().text = "0" + this.numTotalPrice.ToString() + ".00";
			}
		}
		else if (this.numTotalPrice % 1f != 0f)
		{
			this.totalPrice.GetComponent<TextMeshPro>().text = this.numTotalPrice.ToString() + "0";
		}
		else
		{
			this.totalPrice.GetComponent<TextMeshPro>().text = this.numTotalPrice.ToString() + ".00";
		}
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000AEC8 File Offset: 0x000092C8
	public void ComponentGo(int engNum)
	{
		this.engNumHolder = engNum;
		if (engNum == 148)
		{
			base.StartCoroutine("ExtrasGo");
			return;
		}
		if (engNum == 151)
		{
			base.StartCoroutine("PaintDecalsGo");
			return;
		}
		if (this.pageDescription != null)
		{
			this.pageDescription.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
		}
		this.componentTarget1.GetComponent<SpriteRenderer>().sprite = this.componentSprites[engNum];
		this.componentTarget1.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		if (this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
			if (this.prefabs[engNum].GetComponent<EngineComponentC>().componentHeader.Length > 13)
			{
				this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 130f;
			}
			else
			{
				this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 220f;
			}
		}
		this.componentTarget2.GetComponent<SpriteRenderer>().sprite = this.componentSprites[engNum + 1];
		this.componentTarget2.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		if (this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 1].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 1].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
			if (this.prefabs[engNum + 1].GetComponent<EngineComponentC>().componentHeader.Length > 13)
			{
				this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 130f;
			}
			else
			{
				this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 220f;
			}
		}
		this.componentTarget3.GetComponent<SpriteRenderer>().sprite = this.componentSprites[engNum + 2];
		this.componentTarget3.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		if (this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 2].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 2].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
			if (this.prefabs[engNum + 2].GetComponent<EngineComponentC>().componentHeader.Length > 13)
			{
				this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 130f;
			}
			else
			{
				this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 220f;
			}
		}
		this.componentTarget4.active = true;
		if (this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(true);
		}
		this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
		this.componentTarget4.GetComponent<SpriteRenderer>().sprite = this.componentSprites[engNum + 3];
		this.componentTarget4.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		if (this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
		{
			this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 3].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
			this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 3].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
			if (this.prefabs[engNum + 3].GetComponent<EngineComponentC>().componentHeader.Length > 13)
			{
				this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 130f;
			}
			else
			{
				this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.GetComponent<TextMeshPro>().fontSize = 220f;
			}
		}
		if (engNum < 140)
		{
			this.componentTarget5.active = true;
			if (this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(true);
			}
			this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
			this.componentLogo1.active = true;
			this.componentTarget5.GetComponent<SpriteRenderer>().sprite = this.componentSprites[engNum + 4];
			this.componentTarget5.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
			if (this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 4].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
			}
			this.componentTarget6.active = true;
			if (this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(true);
			}
			this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
			this.componentLogo2.active = true;
			this.componentTarget6.GetComponent<SpriteRenderer>().sprite = this.componentSprites[engNum + 5];
			this.componentTarget6.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
			if (this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 5].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
			}
			this.componentTarget7.active = true;
			if (this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(true);
			}
			this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(true);
			this.componentLogo3.active = true;
			this.componentTarget7.GetComponent<SpriteRenderer>().sprite = this.componentSprites[engNum + 6];
			this.componentTarget7.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
			if (this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj.GetComponent<TextMeshPro>().text = Language.Get(this.prefabs[engNum + 6].GetComponent<EngineComponentC>().flavourTextDetailed, "Inspector_UI");
			}
		}
		else
		{
			this.componentLogo1.active = false;
			this.componentLogo2.active = false;
			this.componentLogo3.active = false;
			if (this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
			}
			this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
			this.componentTarget5.active = false;
			if (this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
			}
			this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
			this.componentTarget6.active = false;
			if (this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj != null)
			{
				this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().descObj.transform.parent.gameObject.SetActive(false);
			}
			this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().priceBackdrop.transform.parent.gameObject.SetActive(false);
			this.componentTarget7.active = false;
		}
		this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().state = engNum;
		this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().state = engNum + 1;
		this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().state = engNum + 2;
		this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().state = engNum + 3;
		if (engNum < 140)
		{
			this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().state = engNum + 4;
			this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().state = engNum + 5;
			this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().state = engNum + 6;
		}
		this.componentTarget1.GetComponent<CataloguePagePurchaseRelayC>().UpdateState();
		this.componentTarget2.GetComponent<CataloguePagePurchaseRelayC>().UpdateState();
		this.componentTarget3.GetComponent<CataloguePagePurchaseRelayC>().UpdateState();
		this.componentTarget4.GetComponent<CataloguePagePurchaseRelayC>().UpdateState();
		if (engNum < 140)
		{
			this.componentTarget5.GetComponent<CataloguePagePurchaseRelayC>().UpdateState();
			this.componentTarget6.GetComponent<CataloguePagePurchaseRelayC>().UpdateState();
			this.componentTarget7.GetComponent<CataloguePagePurchaseRelayC>().UpdateState();
		}
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x0000BAF0 File Offset: 0x00009EF0
	public void AddToShoppingList(GameObject comp)
	{
		float num = this.numTotalPrice + comp.GetComponent<ObjectPickupC>().buyValue;
		if (this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth < num)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audioError, 0.7f);
			return;
		}
		this.shoppingList.Add(comp);
		int num2 = this.shoppingList.Count - 1;
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.EN)
		{
			this.receiptStrings[num2].GetComponent<TextMeshPro>().text = Language.Get(comp.GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
		}
		this.receiptPrices[num2].GetComponent<TextMeshPro>().text = comp.GetComponent<ObjectPickupC>().buyValue.ToString();
		if (comp.GetComponent<ObjectPickupC>().buyValue < 10f && comp.GetComponent<ObjectPickupC>().buyValue > 0f)
		{
			if (comp.GetComponent<ObjectPickupC>().buyValue % 1f != 0f)
			{
				this.receiptPrices[num2].GetComponent<TextMeshPro>().text = "0" + comp.GetComponent<ObjectPickupC>().buyValue.ToString() + "0";
			}
			else
			{
				this.receiptPrices[num2].GetComponent<TextMeshPro>().text = "0" + comp.GetComponent<ObjectPickupC>().buyValue.ToString() + ".00";
			}
		}
		else if (comp.GetComponent<ObjectPickupC>().buyValue % 1f != 0f)
		{
			this.receiptPrices[num2].GetComponent<TextMeshPro>().text = comp.GetComponent<ObjectPickupC>().buyValue.ToString() + "0";
		}
		else
		{
			this.receiptPrices[num2].GetComponent<TextMeshPro>().text = comp.GetComponent<ObjectPickupC>().buyValue.ToString() + ".00";
		}
		this.numTotalPrice = 0f;
		for (int i = 0; i < this.shoppingList.Count; i++)
		{
			this.numTotalPrice += this.shoppingList[i].GetComponent<ObjectPickupC>().buyValue;
		}
		if (this.numTotalPrice < 10f && this.numTotalPrice > 0f)
		{
			if (this.numTotalPrice % 1f != 0f)
			{
				this.totalPrice.GetComponent<TextMeshPro>().text = "0" + this.numTotalPrice.ToString() + "0";
			}
			else
			{
				this.totalPrice.GetComponent<TextMeshPro>().text = "0" + this.numTotalPrice.ToString() + ".00";
			}
		}
		else if (this.numTotalPrice % 1f != 0f)
		{
			this.totalPrice.GetComponent<TextMeshPro>().text = this.numTotalPrice.ToString() + "0";
		}
		else
		{
			this.totalPrice.GetComponent<TextMeshPro>().text = this.numTotalPrice.ToString() + ".00";
		}
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x0000BE5C File Offset: 0x0000A25C
	public void PurchaseGo()
	{
		if (this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth < this.numTotalPrice)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.audioError, 0.7f);
			return;
		}
		this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().incomingFunds -= this.numTotalPrice;
		this.director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().UpdateWealth();
		this.SpawnGo();
		this.SendOrderOut();
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x0000BEF2 File Offset: 0x0000A2F2
	public void SendOrderOut()
	{
		this.shop.GetComponent<LaikaBuildingC>().StartCoroutine("PartsOrdered");
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x0000BF0A File Offset: 0x0000A30A
	public void SendOrderOut2()
	{
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x0000BF0C File Offset: 0x0000A30C
	private IEnumerator SendOrderOut3()
	{
		this.letter.GetComponent<Animator>().SetBool("open", false);
		yield return new WaitForSeconds(0.8f);
		this.letter.transform.localPosition = Vector3.zero;
		this.SendOrderOut4();
		yield break;
	}

	// Token: 0x060000EA RID: 234 RVA: 0x0000BF28 File Offset: 0x0000A328
	public void SendOrderOut4()
	{
		iTween.RotateTo(this.receipt, iTween.Hash(new object[]
		{
			"y",
			0,
			"time",
			0.7,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"SendOrderOut5",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060000EB RID: 235 RVA: 0x0000BFBC File Offset: 0x0000A3BC
	public void SendOrderOut5()
	{
		iTween.MoveTo(this.receipt, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[5],
			"delay",
			0.2,
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000C058 File Offset: 0x0000A458
	public void ReturnEnvelope()
	{
		this.receipt.transform.localEulerAngles = new Vector3(-90f, 180f, 0f);
		iTween.MoveTo(this.receipt, iTween.Hash(new object[]
		{
			"position",
			this.envelopePos[3],
			"time",
			0.8,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"EnvelopeDown",
			"oncompletetarget",
			base.gameObject
		}));
		this.letter.GetComponent<Animator>().SetBool("open", true);
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000C135 File Offset: 0x0000A535
	public void BoughtDoor()
	{
		this.doorObject.SetActive(true);
		this.shop.GetComponent<LaikaBuildingC>().PurchasedDoor();
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000C154 File Offset: 0x0000A554
	public void SpawnGo()
	{
		if (this.shoppingList.Count >= 1)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.shoppingList[0], this.spawnLocations[0].transform.position, Quaternion.identity);
			if (gameObject.GetComponent<ObjectPickupC>())
			{
				gameObject.GetComponent<ObjectPickupC>().forceCollision = true;
			}
			gameObject.GetComponent<Collider>().isTrigger = false;
			if (gameObject.GetComponent<Rigidbody>())
			{
				gameObject.GetComponent<Rigidbody>().isKinematic = false;
			}
			gameObject.transform.eulerAngles = gameObject.GetComponent<ObjectPickupC>().throwRotAdjustment;
			if (gameObject.GetComponent<FixDoorScriptC>())
			{
				this.BoughtDoor();
			}
		}
		if (this.shoppingList.Count >= 2)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.shoppingList[1], this.spawnLocations[1].transform.position, Quaternion.identity);
			if (gameObject2.GetComponent<ObjectPickupC>())
			{
				gameObject2.GetComponent<ObjectPickupC>().forceCollision = true;
			}
			gameObject2.GetComponent<Collider>().isTrigger = false;
			if (gameObject2.GetComponent<Rigidbody>())
			{
				gameObject2.GetComponent<Rigidbody>().isKinematic = false;
			}
			gameObject2.transform.eulerAngles = gameObject2.GetComponent<ObjectPickupC>().throwRotAdjustment;
			if (gameObject2.GetComponent<FixDoorScriptC>())
			{
				this.BoughtDoor();
			}
		}
		if (this.shoppingList.Count >= 3)
		{
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.shoppingList[2], this.spawnLocations[2].transform.position, Quaternion.identity);
			if (gameObject3.GetComponent<ObjectPickupC>())
			{
				gameObject3.GetComponent<ObjectPickupC>().forceCollision = true;
			}
			gameObject3.GetComponent<Collider>().isTrigger = false;
			if (gameObject3.GetComponent<Rigidbody>())
			{
				gameObject3.GetComponent<Rigidbody>().isKinematic = false;
			}
			gameObject3.transform.eulerAngles = gameObject3.GetComponent<ObjectPickupC>().throwRotAdjustment;
			if (gameObject3.GetComponent<FixDoorScriptC>())
			{
				this.BoughtDoor();
			}
		}
		if (this.shoppingList.Count >= 4)
		{
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.shoppingList[3], this.spawnLocations[3].transform.position, Quaternion.identity);
			if (gameObject4.GetComponent<ObjectPickupC>())
			{
				gameObject4.GetComponent<ObjectPickupC>().forceCollision = true;
			}
			gameObject4.GetComponent<Collider>().isTrigger = false;
			if (gameObject4.GetComponent<Rigidbody>())
			{
				gameObject4.GetComponent<Rigidbody>().isKinematic = false;
			}
			gameObject4.transform.eulerAngles = gameObject4.GetComponent<ObjectPickupC>().throwRotAdjustment;
			if (gameObject4.GetComponent<FixDoorScriptC>())
			{
				this.BoughtDoor();
			}
		}
		if (this.shoppingList.Count >= 5)
		{
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.shoppingList[4], this.spawnLocations[4].transform.position, Quaternion.identity);
			if (gameObject5.GetComponent<ObjectPickupC>())
			{
				gameObject5.GetComponent<ObjectPickupC>().forceCollision = true;
			}
			gameObject5.GetComponent<Collider>().isTrigger = false;
			if (gameObject5.GetComponent<Rigidbody>())
			{
				gameObject5.GetComponent<Rigidbody>().isKinematic = false;
			}
			gameObject5.transform.eulerAngles = gameObject5.GetComponent<ObjectPickupC>().throwRotAdjustment;
			if (gameObject5.GetComponent<FixDoorScriptC>())
			{
				this.BoughtDoor();
			}
		}
		if (this.shoppingList.Count >= 6)
		{
			GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.shoppingList[5], this.spawnLocations[5].transform.position, Quaternion.identity);
			if (gameObject6.GetComponent<ObjectPickupC>())
			{
				gameObject6.GetComponent<ObjectPickupC>().forceCollision = true;
			}
			gameObject6.GetComponent<Collider>().isTrigger = false;
			if (gameObject6.GetComponent<Rigidbody>())
			{
				gameObject6.GetComponent<Rigidbody>().isKinematic = false;
			}
			gameObject6.transform.eulerAngles = gameObject6.GetComponent<ObjectPickupC>().throwRotAdjustment;
			if (gameObject6.GetComponent<FixDoorScriptC>())
			{
				this.BoughtDoor();
			}
		}
		this.ClearShoppingList();
		this.ReturnEnvelope();
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0000C57C File Offset: 0x0000A97C
	public void ClearShoppingList()
	{
		LanguageCode languageCode = Language.CurrentLanguage();
		this.numTotalPrice = 0f;
		this.totalPrice.GetComponent<TextMeshPro>().text = "00.00";
		for (int i = 0; i < this.shoppingList.Count; i++)
		{
			if (languageCode == LanguageCode.EN)
			{
				this.receiptStrings[i].GetComponent<TextMeshPro>().text = string.Empty;
			}
			this.receiptPrices[i].GetComponent<TextMeshPro>().text = string.Empty;
		}
		for (int j = 0; j < this.shoppingList.Count; j++)
		{
			this.shoppingList.RemoveAt(j);
		}
		for (int k = 0; k < this.shoppingList.Count; k++)
		{
			this.shoppingList.RemoveAt(k);
		}
		for (int l = 0; l < this.shoppingList.Count; l++)
		{
			this.shoppingList.RemoveAt(l);
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0000C67E File Offset: 0x0000AA7E
	public void Error()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioError, 0.7f);
	}

	// Token: 0x04000077 RID: 119
	public GameObject director;

	// Token: 0x04000078 RID: 120
	public GameObject shop;

	// Token: 0x04000079 RID: 121
	public GameObject receipt;

	// Token: 0x0400007A RID: 122
	public GameObject letter;

	// Token: 0x0400007B RID: 123
	public GameObject envelope;

	// Token: 0x0400007C RID: 124
	public GameObject componentLogo1;

	// Token: 0x0400007D RID: 125
	public GameObject componentLogo2;

	// Token: 0x0400007E RID: 126
	public GameObject componentLogo3;

	// Token: 0x0400007F RID: 127
	public GameObject totalPrice;

	// Token: 0x04000080 RID: 128
	public GameObject componentTarget1;

	// Token: 0x04000081 RID: 129
	public GameObject componentTarget2;

	// Token: 0x04000082 RID: 130
	public GameObject componentTarget3;

	// Token: 0x04000083 RID: 131
	public GameObject componentTarget4;

	// Token: 0x04000084 RID: 132
	public GameObject componentTarget5;

	// Token: 0x04000085 RID: 133
	public GameObject componentTarget6;

	// Token: 0x04000086 RID: 134
	public GameObject componentTarget7;

	// Token: 0x04000087 RID: 135
	public GameObject pageDescription;

	// Token: 0x04000088 RID: 136
	public Vector3[] envelopePos;

	// Token: 0x04000089 RID: 137
	public Transform[] spawnLocations;

	// Token: 0x0400008A RID: 138
	public int[] purchaseDetails;

	// Token: 0x0400008B RID: 139
	public List<GameObject> shoppingList = new List<GameObject>();

	// Token: 0x0400008C RID: 140
	public List<GameObject> prefabs = new List<GameObject>();

	// Token: 0x0400008D RID: 141
	public List<GameObject> prefabSelected = new List<GameObject>();

	// Token: 0x0400008E RID: 142
	public List<GameObject> prefabExtras = new List<GameObject>();

	// Token: 0x0400008F RID: 143
	public List<GameObject> prefabExtrasSelected = new List<GameObject>();

	// Token: 0x04000090 RID: 144
	public List<GameObject> prefabExtrasUpgradeLvls = new List<GameObject>();

	// Token: 0x04000091 RID: 145
	public List<GameObject> prefabPaintDecals = new List<GameObject>();

	// Token: 0x04000092 RID: 146
	public List<GameObject> prefabPaintDecalsSelected = new List<GameObject>();

	// Token: 0x04000093 RID: 147
	public GameObject[] localisationPickup;

	// Token: 0x04000094 RID: 148
	public GameObject[] receiptStrings;

	// Token: 0x04000095 RID: 149
	public GameObject[] receiptPrices;

	// Token: 0x04000096 RID: 150
	public List<Sprite> componentSprites = new List<Sprite>();

	// Token: 0x04000097 RID: 151
	public List<Sprite> prefabSpritesSelected = new List<Sprite>();

	// Token: 0x04000098 RID: 152
	public List<Sprite> prefabExtrasSpritesLibrary = new List<Sprite>();

	// Token: 0x04000099 RID: 153
	public List<Sprite> prefabExtrasSprites = new List<Sprite>();

	// Token: 0x0400009A RID: 154
	public List<Sprite> prefabPaintDecalsSpritesLibrary = new List<Sprite>();

	// Token: 0x0400009B RID: 155
	public List<Sprite> prefabPaintDecalsSprites = new List<Sprite>();

	// Token: 0x0400009C RID: 156
	public float numTotalPrice;

	// Token: 0x0400009D RID: 157
	public AudioClip audioError;

	// Token: 0x0400009E RID: 158
	public Transform walletHolder;

	// Token: 0x0400009F RID: 159
	private Transform walletPrevParent;

	// Token: 0x040000A0 RID: 160
	private Vector3 walletPrevPos;

	// Token: 0x040000A1 RID: 161
	private Vector3 walletPrevRot;

	// Token: 0x040000A2 RID: 162
	public int engNumHolder;

	// Token: 0x040000A3 RID: 163
	public GameObject doorObject;
}
