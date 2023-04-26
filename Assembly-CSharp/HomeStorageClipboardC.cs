using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x020000B5 RID: 181
public class HomeStorageClipboardC : MonoBehaviour
{
	// Token: 0x06000698 RID: 1688 RVA: 0x00084704 File Offset: 0x00082B04
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject wallet = gameObject.GetComponent<DirectorC>().wallet;
		if (wallet.transform.parent)
		{
			this.prevWalletParent = wallet.transform.parent;
		}
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode != LanguageCode.EN)
		{
			this.localisationObjs[0].active = false;
			this.localisationObjs[1].active = true;
			this.storageText = this.localisationObjs[1];
			this.localisationObjs[2].active = false;
			this.localisationObjs[3].active = false;
			this.valueText = this.localisationObjs[3];
			this.localisationObjs[4].active = false;
			this.localisationObjs[5].active = false;
			this.totalValueText = this.localisationObjs[5];
		}
		this.LocalisationPickup();
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x000847F0 File Offset: 0x00082BF0
	private void Awake()
	{
		HomeStorageClipboardC.Global = this;
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x000847F8 File Offset: 0x00082BF8
	private void OnDestroy()
	{
		HomeStorageClipboardC.Global = null;
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x00084800 File Offset: 0x00082C00
	public void LocalisationPickup()
	{
		this.localisationTexts[0].GetComponent<TextMesh>().text = Language.Get("ui_pickup_103", "Inspector_UI");
		this.localisationTexts[1].GetComponent<TextMesh>().text = Language.Get("ui_pickup_104", "Inspector_UI");
		this.localisationTexts[2].GetComponent<TextMesh>().text = Language.Get("ui_pickup_92", "Inspector_UI");
		this.localisationTexts[3].GetComponent<TextMesh>().text = Language.Get("ui_pickup_93", "Inspector_UI");
		this.localisationTexts[4].GetComponent<TextMesh>().text = Language.Get("ui_pickup_94", "Inspector_UI");
		this.localisationTexts[5].GetComponent<TextMesh>().text = Language.Get("ui_pickup_95", "Inspector_UI");
		this.localisationTexts[6].GetComponent<TextMesh>().text = Language.Get("ui_pickup_96", "Inspector_UI");
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x000848F4 File Offset: 0x00082CF4
	public void AddStorageOrder()
	{
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.EN)
		{
			this.receiptStrings[this.storageOrder].GetComponent<TextMeshPro>().text = "Home Storage Solution";
		}
		else
		{
			this.receiptStrings[this.storageOrder].GetComponent<TextMeshPro>().text = "0";
		}
		this.receiptPrices[this.storageOrder].GetComponent<TextMeshPro>().text = this.storagePrice.ToString();
		this.storageOrder++;
		int num = this.storageOrder * this.storagePrice;
		this.totalSaleValueText.GetComponent<TextMeshPro>().text = num.ToString();
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x000849B0 File Offset: 0x00082DB0
	public void PlaceOrder()
	{
		base.GetComponent<MagazineLogicC>().SendReceiptOff();
		int count = this.storageInventory.Count;
		for (int i = 0; i < this.storageOrder; i++)
		{
			int num = i + count;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.storagePrefab, this.storageParents[num].transform.position, this.storageParents[num].transform.rotation);
			gameObject.transform.parent = this.storageParents[num];
			this.storageInventory.Add(gameObject);
			this.currentStorage++;
		}
		this.storageOrder = 0;
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x00084A54 File Offset: 0x00082E54
	public void LoadShelf(int ID)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.storagePrefab, this.storageParents[ID].transform.position, this.storageParents[ID].transform.rotation);
		gameObject.transform.parent = this.storageParents[ID];
		gameObject.GetComponent<ShelfInventoryTweensC>().isLoaded = true;
		this.storageInventory.Add(gameObject);
		this.currentStorage++;
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00084ACA File Offset: 0x00082ECA
	public void LoadShelf1()
	{
		this.LoadShelf(0);
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00084AD3 File Offset: 0x00082ED3
	public void LoadShelf2()
	{
		this.LoadShelf(1);
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00084ADC File Offset: 0x00082EDC
	public void LoadShelf3()
	{
		this.LoadShelf(2);
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x00084AE5 File Offset: 0x00082EE5
	public void LoadShelf4()
	{
		this.LoadShelf(3);
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00084AEE File Offset: 0x00082EEE
	public void LoadShelf5()
	{
		this.LoadShelf(4);
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x00084AF8 File Offset: 0x00082EF8
	public void ClearOrder()
	{
		for (int i = 0; i < this.receiptStrings.Length; i++)
		{
			this.receiptStrings[i].GetComponent<TextMeshPro>().text = string.Empty;
		}
		for (int j = 0; j < this.receiptPrices.Length; j++)
		{
			this.receiptPrices[j].GetComponent<TextMeshPro>().text = string.Empty;
		}
		this.totalSaleValueText.GetComponent<TextMeshPro>().text = string.Empty;
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x00084B7A File Offset: 0x00082F7A
	public void Error()
	{
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x00084B7C File Offset: 0x00082F7C
	public void PurchaseGo()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (this.storageOrder == 0)
		{
			return;
		}
		int num = this.storageOrder * this.storagePrice;
		if (gameObject.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth < (float)num)
		{
			return;
		}
		gameObject.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().incomingFunds -= (float)num;
		gameObject.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().UpdateWealth();
		base.StartCoroutine("PlaceOrder");
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x00084C0C File Offset: 0x0008300C
	public void ClearShoppingList()
	{
		if (this.receiptStrings[0].GetComponent<TextMeshPro>().text == string.Empty)
		{
			base.GetComponent<MagazineLogicC>().Close();
			return;
		}
		for (int i = 0; i < this.receiptStrings.Length; i++)
		{
			this.receiptStrings[i].GetComponent<TextMeshPro>().text = string.Empty;
			this.receiptPrices[i].GetComponent<TextMeshPro>().text = string.Empty;
			this.totalSaleValueText.GetComponent<TextMeshPro>().text = string.Empty;
		}
		this.storageOrder = 0;
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x00084CAC File Offset: 0x000830AC
	public void TweenWalletBack()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject wallet = gameObject.GetComponent<DirectorC>().wallet;
		wallet.GetComponent<ObjectPickupC>().ThrowLogic();
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x00084CDC File Offset: 0x000830DC
	public void TweenWallet()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject wallet = gameObject.GetComponent<DirectorC>().wallet;
		wallet.transform.parent = null;
		this._camera.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x00084DD4 File Offset: 0x000831D4
	private void WheelLoop(GameObject wheel)
	{
		if (wheel != null)
		{
			IEnumerator enumerator = wheel.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int i = 0; i < this.inventoryCatalogue.Count; i++)
						{
							EngineComponentC component = transform.GetComponent<EngineComponentC>();
							EngineComponentC component2 = this.inventoryCatalogue[i].GetComponent<EngineComponentC>();
							if (component && component2 && !this.stockChecked)
							{
								if (component2.componentHeader == component.componentHeader)
								{
									List<int> list;
									int index;
									(list = this.inventoryCatalogueStockCount)[index = i] = list[index] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[i].name == transform.name && !this.stockChecked)
							{
								List<int> list;
								int index2;
								(list = this.inventoryCatalogueStockCount)[index2 = i] = list[index2] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x00084F98 File Offset: 0x00083398
	private void ExtraLoop(Transform[] inventorySlots)
	{
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			IEnumerator enumerator = inventorySlots[i].transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int j = 0; j < this.inventoryCatalogue.Count; j++)
						{
							EngineComponentC component = transform.GetComponent<EngineComponentC>();
							EngineComponentC component2 = this.inventoryCatalogue[j].GetComponent<EngineComponentC>();
							if (component && component2 && !this.stockChecked)
							{
								if (component2.componentHeader == component.componentHeader)
								{
									List<int> list;
									int index;
									(list = this.inventoryCatalogueStockCount)[index = j] = list[index] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[j].name == transform.name && !this.stockChecked)
							{
								List<int> list;
								int index2;
								(list = this.inventoryCatalogueStockCount)[index2 = j] = list[index2] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x00085168 File Offset: 0x00083568
	private void ExtraExtraLoop(int ID)
	{
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().inventorySlots);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot3x2x1);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot2x2x1);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot2x1x2);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot2x2x2);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot2x2x3);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot3x2x3);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot4x2x2);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot4x2x3);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot4x1x1);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot4x2x1);
		this.ExtraLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().slot2x1x3);
		this.WheelLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().wheelHolder1);
		this.WheelLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().wheelHolder2);
		this.WheelLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().wheelHolder3);
		this.WheelLoop(this.storageInventory[ID].GetComponent<InventoryLogicC>().wheelHolder4);
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x00085338 File Offset: 0x00083738
	public void PageGo()
	{
		this.inventoryCatalogue.Clear();
		this.inventoryCatalogueStockCount.Clear();
		LanguageCode languageCode = Language.CurrentLanguage();
		if (languageCode == LanguageCode.EN)
		{
			this.storageText.GetComponent<TextMeshPro>().text = string.Empty;
		}
		else
		{
			this.storageText.GetComponent<TextMesh>().text = string.Empty;
		}
		if (languageCode == LanguageCode.EN)
		{
			this.valueText.GetComponent<TextMeshPro>().text = string.Empty;
		}
		else
		{
			this.valueText.GetComponent<TextMesh>().text = string.Empty;
		}
		this.totalValue = 0f;
		if (languageCode == LanguageCode.EN)
		{
			this.totalValueText.GetComponent<TextMeshPro>().text = string.Empty;
		}
		else
		{
			this.totalValueText.GetComponent<TextMesh>().text = string.Empty;
		}
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject wallet = gameObject.GetComponent<DirectorC>().wallet;
		this.walletPrevParent = wallet.transform.parent;
		this.walletPrevPos = wallet.transform.localPosition;
		this.walletPrevRot = wallet.transform.localEulerAngles;
		if (this.storageInventory.Count != 0)
		{
			if (this.storageInventory.Count > 0)
			{
				this.ExtraExtraLoop(0);
			}
		}
		if (this.storageInventory.Count > 1)
		{
			this.ExtraExtraLoop(1);
		}
		if (this.storageInventory.Count > 2)
		{
			this.ExtraExtraLoop(2);
		}
		if (this.storageInventory.Count > 3)
		{
			this.ExtraExtraLoop(3);
		}
		if (this.storageInventory.Count > 4)
		{
			this.ExtraExtraLoop(4);
		}
		this.finalValueString = 0f;
		for (int i = 0; i < this.inventoryCatalogue.Count; i++)
		{
			if (this.inventoryCatalogue[i] != null)
			{
				if (i < 15)
				{
					if (languageCode == LanguageCode.EN)
					{
						if (this.inventoryCatalogue[i].GetComponent<EngineComponentC>())
						{
							TextMeshPro component = this.storageText.GetComponent<TextMeshPro>();
							component.text += Language.Get(this.inventoryCatalogue[i].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
						}
						else
						{
							this.inventoryCatalogue[i].name = this.inventoryCatalogue[i].name.Replace("(Clone)", string.Empty).Trim();
							TextMeshPro component2 = this.storageText.GetComponent<TextMeshPro>();
							component2.text += this.inventoryCatalogue[i].name;
						}
						if (this.inventoryCatalogueStockCount[i] > 1)
						{
							TextMeshPro component3 = this.storageText.GetComponent<TextMeshPro>();
							component3.text += " x";
							TextMeshPro component4 = this.storageText.GetComponent<TextMeshPro>();
							component4.text += this.inventoryCatalogueStockCount[i].ToString();
						}
						TextMeshPro component5 = this.storageText.GetComponent<TextMeshPro>();
						component5.text += "\\n";
						this.storageText.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
					}
					else
					{
						if (this.inventoryCatalogue[i].GetComponent<EngineComponentC>())
						{
							TextMesh component6 = this.storageText.GetComponent<TextMesh>();
							component6.text += Language.Get(this.inventoryCatalogue[i].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
						}
						else
						{
							this.inventoryCatalogue[i].name = this.inventoryCatalogue[i].name.Replace("(Clone)", string.Empty).Trim();
							TextMesh component7 = this.storageText.GetComponent<TextMesh>();
							component7.text += this.inventoryCatalogue[i].name;
						}
						if (this.inventoryCatalogueStockCount[i] > 1)
						{
							TextMesh component8 = this.storageText.GetComponent<TextMesh>();
							component8.text += " x";
							TextMesh component9 = this.storageText.GetComponent<TextMesh>();
							component9.text += this.inventoryCatalogueStockCount[i].ToString();
						}
						TextMesh component10 = this.storageText.GetComponent<TextMesh>();
						component10.text += "\n";
						this.storageText.GetComponent<TextMesh>().text.Replace("\\n", "\n");
					}
					if (this.inventoryCatalogueStockCount[i] > 1)
					{
						float num = this.inventoryCatalogue[i].GetComponent<ObjectPickupC>().sellValue * (float)this.inventoryCatalogueStockCount[i];
						if (languageCode == LanguageCode.EN)
						{
							TextMeshPro component11 = this.valueText.GetComponent<TextMeshPro>();
							component11.text = component11.text + "- " + num.ToString() + " M";
						}
						else
						{
							TextMesh component12 = this.valueText.GetComponent<TextMesh>();
							component12.text = component12.text + "- " + num.ToString() + " M";
						}
						this.totalValue += num;
					}
					else
					{
						if (languageCode == LanguageCode.EN)
						{
							TextMeshPro component13 = this.valueText.GetComponent<TextMeshPro>();
							string text = component13.text;
							component13.text = string.Concat(new object[]
							{
								text,
								"- ",
								this.inventoryCatalogue[i].GetComponent<ObjectPickupC>().sellValue,
								" M"
							});
						}
						else
						{
							TextMesh component14 = this.valueText.GetComponent<TextMesh>();
							string text = component14.text;
							component14.text = string.Concat(new object[]
							{
								text,
								"- ",
								this.inventoryCatalogue[i].GetComponent<ObjectPickupC>().sellValue,
								" M"
							});
						}
						this.totalValue += this.inventoryCatalogue[i].GetComponent<ObjectPickupC>().sellValue;
					}
					if (languageCode == LanguageCode.EN)
					{
						TextMeshPro component15 = this.valueText.GetComponent<TextMeshPro>();
						component15.text += "\\n";
						this.valueText.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
					}
					else
					{
						TextMesh component16 = this.valueText.GetComponent<TextMesh>();
						component16.text += "\\n";
						this.valueText.GetComponent<TextMesh>().text.Replace("\\n", "\n");
					}
				}
				else
				{
					float num2 = this.inventoryCatalogue[i].GetComponent<ObjectPickupC>().sellValue * (float)this.inventoryCatalogueStockCount[i];
					if (i == 15)
					{
						if (languageCode == LanguageCode.EN)
						{
							TextMeshPro component17 = this.storageText.GetComponent<TextMeshPro>();
							component17.text += "...Etc";
						}
						else
						{
							TextMesh component18 = this.storageText.GetComponent<TextMesh>();
							component18.text += "...Etc";
						}
					}
					if (this.inventoryCatalogueStockCount[i] > 1)
					{
						this.finalValueString += num2;
					}
					else
					{
						this.finalValueString += num2;
					}
				}
			}
		}
		if (this.inventoryCatalogue.Count >= 15)
		{
			if (languageCode == LanguageCode.EN)
			{
				TextMeshPro component19 = this.valueText.GetComponent<TextMeshPro>();
				string text = component19.text;
				component19.text = string.Concat(new object[]
				{
					text,
					"- ",
					this.finalValueString,
					" M"
				});
			}
			else
			{
				TextMesh component20 = this.valueText.GetComponent<TextMesh>();
				string text = component20.text;
				component20.text = string.Concat(new object[]
				{
					text,
					"- ",
					this.finalValueString,
					" M"
				});
			}
			this.totalValue += this.finalValueString;
		}
		if (languageCode == LanguageCode.EN)
		{
			TextMeshPro component21 = this.totalValueText.GetComponent<TextMeshPro>();
			component21.text = component21.text + "Total Value : " + this.totalValue.ToString() + " M";
		}
		else
		{
			TextMesh component22 = this.totalValueText.GetComponent<TextMesh>();
			component22.text = component22.text + this.totalValue.ToString() + " M";
		}
	}

	// Token: 0x040008DA RID: 2266
	public static HomeStorageClipboardC Global;

	// Token: 0x040008DB RID: 2267
	private GameObject _camera;

	// Token: 0x040008DC RID: 2268
	private Transform prevWalletParent;

	// Token: 0x040008DD RID: 2269
	public int storageOrder;

	// Token: 0x040008DE RID: 2270
	public int storageMax = 5;

	// Token: 0x040008DF RID: 2271
	public int currentStorage;

	// Token: 0x040008E0 RID: 2272
	public GameObject storagePrefab;

	// Token: 0x040008E1 RID: 2273
	public Transform[] storageParents;

	// Token: 0x040008E2 RID: 2274
	public int storagePrice = 10;

	// Token: 0x040008E3 RID: 2275
	public GameObject[] receiptStrings;

	// Token: 0x040008E4 RID: 2276
	public GameObject[] receiptPrices;

	// Token: 0x040008E5 RID: 2277
	public GameObject totalSaleValueText;

	// Token: 0x040008E6 RID: 2278
	public GameObject[] localisationObjs;

	// Token: 0x040008E7 RID: 2279
	public GameObject storageText;

	// Token: 0x040008E8 RID: 2280
	public List<GameObject> storageInventory = new List<GameObject>();

	// Token: 0x040008E9 RID: 2281
	public GameObject valueText;

	// Token: 0x040008EA RID: 2282
	public GameObject totalValueText;

	// Token: 0x040008EB RID: 2283
	public List<GameObject> inventoryCatalogue = new List<GameObject>();

	// Token: 0x040008EC RID: 2284
	public List<int> inventoryCatalogueStockCount = new List<int>();

	// Token: 0x040008ED RID: 2285
	public List<int> removeNumbers = new List<int>();

	// Token: 0x040008EE RID: 2286
	private bool stockChecked;

	// Token: 0x040008EF RID: 2287
	private float totalValue;

	// Token: 0x040008F0 RID: 2288
	private float finalValueString;

	// Token: 0x040008F1 RID: 2289
	public Transform walletHolder;

	// Token: 0x040008F2 RID: 2290
	private Transform walletPrevParent;

	// Token: 0x040008F3 RID: 2291
	private Vector3 walletPrevPos;

	// Token: 0x040008F4 RID: 2292
	private Vector3 walletPrevRot;

	// Token: 0x040008F5 RID: 2293
	public GameObject[] localisationTexts;
}
