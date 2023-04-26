using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000F8 RID: 248
public class ShopC : MonoBehaviour
{
	// Token: 0x060009BC RID: 2492 RVA: 0x000E457C File Offset: 0x000E297C
	private void Reset()
	{
		Shop component = base.GetComponent<Shop>();
		this.director = component.director;
		this.player = component.player;
		this.shopCharacter = component.shopCharacter;
		this.shopCharacterMouth = component.shopCharacterMouth;
		component.audioMumble.Copy(ref this.audioMumble);
		this.shoppingKart = new List<GameObject>(component.shoppingKart);
		this.wallet = component.wallet;
		this.shopCash = component.shopCash;
		this.totalPrice = component.totalPrice;
		this.fuelUsed = component.fuelUsed;
		this.fuelPrice = component.fuelPrice;
		this.visualPrice = component.visualPrice;
		this.fuelHandle = component.fuelHandle;
		component.petrolCounters.Copy(ref this.petrolCounters);
		component.petrolPriceCounters.Copy(ref this.petrolPriceCounters);
		this.shutter = component.shutter;
		this.shutterOpen = component.shutterOpen;
		component.shutterPos.Copy(ref this.shutterPos);
		component.path.Copy(ref this.path);
		this.glowMaterial = component.glowMaterial;
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.cashRegisterAudio = component.cashRegisterAudio;
		this.insfAudio = component.insfAudio;
		this.payedAudio = component.payedAudio;
		this.leverAudio = component.leverAudio;
		component.renderTargets.Copy(ref this.renderTargets);
		this.isTalking = component.isTalking;
		this.textFinished = component.textFinished;
		this.textQueue = new List<string>(component.textQueue);
		this.currentConvoItem = component.currentConvoItem;
		this.interruptConvoItem = component.interruptConvoItem;
		this.dialogueConvoItem = component.dialogueConvoItem;
		this.speechStack = new List<string>(component.speechStack);
		this.inputRestrictDropItem = component.inputRestrictDropItem;
		this.interruptChecker = component.interruptChecker;
		this.dialogueChecker = component.dialogueChecker;
		this.canSpeak = component.canSpeak;
		this.interruptSpeechComplete = component.interruptSpeechComplete;
		this.dialogueSpeechComplete = component.dialogueSpeechComplete;
		this.isWelcomed = component.isWelcomed;
		this.hasGreeted = component.hasGreeted;
		this.portableFuelRefilledList = new List<GameObject>(component.portableFuelRefilledList);
		this.portableFuelRefilledNumbers = new List<int>(component.portableFuelRefilledNumbers);
		this.characterName = component.characterName;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x060009BD RID: 2493 RVA: 0x000E47EC File Offset: 0x000E2BEC
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = this.renderTargets[0].GetComponent<Renderer>().material;
		this.director = GameObject.FindWithTag("Director");
		this.wallet = this.director.GetComponent<DirectorC>().wallet;
		if (ES3.Exists("shopIsWelcomed"))
		{
			this.isWelcomed = ES3.LoadBool("shopIsWelcomed");
		}
		this.GenerateShopCashAmount();
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x000E486C File Offset: 0x000E2C6C
	public void GenerateShopCashAmount()
	{
		this.shopCash = (float)UnityEngine.Random.Range(200, 600);
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x000E4884 File Offset: 0x000E2C84
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

	// Token: 0x060009C0 RID: 2496 RVA: 0x000E48E7 File Offset: 0x000E2CE7
	public void WheelIntoInventory()
	{
		base.StartCoroutine("Trigger");
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x000E48F8 File Offset: 0x000E2CF8
	public void Trigger()
	{
		if (!this.ready)
		{
			return;
		}
		this.ready = false;
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		if (isHolding == this.wallet)
		{
			if (isHolding.GetComponent<WalletC>().TotalWealth >= this.totalPrice)
			{
				this.Payed();
				isHolding.SendMessage("ChangeMoney");
				base.transform.parent.GetComponent<StoreC>().GateCheck();
				this.ready = true;
				return;
			}
			isHolding.SendMessage("UnAction");
			base.StartCoroutine("ReturnAllToShelf");
			this.ready = true;
			return;
		}
		else
		{
			if (isHolding.GetComponent<ObjectPickupC>().objectID == 210)
			{
				base.StartCoroutine(this.BulkTransaction());
				return;
			}
			if (!isHolding.GetComponent<ObjectPickupC>().isPurchased)
			{
				float num = this.totalPrice + isHolding.GetComponent<ObjectPickupC>().buyValue;
				if (this.wallet.GetComponent<WalletC>().TotalWealth < num)
				{
					base.StartCoroutine("InsufficientFunds");
					return;
				}
				if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
				{
					int num2 = base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count - 1;
					base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.RemoveAt(0);
				}
				if (this.shutterOpen)
				{
					this.CloseShutter();
				}
				this.currentlyProcessedObject = isHolding;
				isHolding.transform.parent = null;
				isHolding.layer = LayerMask.NameToLayer("Interactor");
				Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
				foreach (Transform transform in componentsInChildren)
				{
					transform.gameObject.layer = LayerMask.NameToLayer("Interactor");
				}
				iTween.MoveTo(isHolding, iTween.Hash(new object[]
				{
					"position",
					this.path[1],
					"time",
					0.5,
					"islocal",
					false,
					"easetype",
					"easeinoutexpo",
					"oncomplete",
					"PlaceObjectIntoShoppingBag",
					"oncompletetarget",
					base.gameObject
				}));
				iTween.RotateTo(isHolding, iTween.Hash(new object[]
				{
					"rotation",
					this.path[0].eulerAngles + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
					"time",
					0.05,
					"islocal",
					false,
					"easetype",
					"easeinoutexpo"
				}));
				isHolding.GetComponent<ObjectPickupC>().RandomAudio();
				this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
				this._camera.GetComponent<DragRigidbodyC>().MoveItemsRightInventory();
			}
			if (isHolding.GetComponent<ObjectPickupC>().isPurchased)
			{
				if (isHolding.GetComponent<ObjectPickupC>().sellValue == 0f)
				{
					isHolding.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
					this.ClearDialogue(0f);
					base.StopCoroutine(this.NoneSellable());
					base.StartCoroutine(this.NoneSellable());
					this.ready = true;
					return;
				}
				float num3 = this.totalPrice - isHolding.GetComponent<ObjectPickupC>().sellValue;
				num3 *= -1f;
				if (num3 > this.shopCash)
				{
					isHolding.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
					this.ClearDialogue(0f);
					base.StopCoroutine(this.ShopInsufficientFunds());
					base.StartCoroutine(this.ShopInsufficientFunds());
					this.ready = true;
					return;
				}
				if (this.shutterOpen)
				{
					this.CloseShutter();
				}
				this.currentlyProcessedObject = isHolding;
				isHolding.transform.parent = null;
				if (isHolding.GetComponent<ExtraComponentC>())
				{
					isHolding.GetComponent<ExtraComponentC>().StopRendering();
				}
				isHolding.layer = LayerMask.NameToLayer("Interactor");
				Transform[] componentsInChildren2 = isHolding.GetComponentsInChildren<Transform>();
				foreach (Transform transform2 in componentsInChildren2)
				{
					transform2.gameObject.layer = LayerMask.NameToLayer("Interactor");
				}
				iTween.MoveTo(isHolding, iTween.Hash(new object[]
				{
					"position",
					this.path[2],
					"time",
					0.5,
					"islocal",
					false,
					"easetype",
					"easeinoutexpo",
					"oncomplete",
					"PlaceObjectIntoShoppingBagConvertToMoney",
					"oncompletetarget",
					base.gameObject
				}));
				iTween.RotateTo(isHolding, iTween.Hash(new object[]
				{
					"rotation",
					this.path[0].eulerAngles + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
					"time",
					0.05,
					"islocal",
					false,
					"easetype",
					"easeinoutexpo"
				}));
				isHolding.GetComponent<ObjectPickupC>().RandomAudio();
				this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
				this._camera.GetComponent<DragRigidbodyC>().MoveItemsRightInventory();
			}
			return;
		}
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x000E4E74 File Offset: 0x000E3274
	public IEnumerator BulkTransaction()
	{
		MonoBehaviour.print("Bulk Transaction started");
		GameObject tempObject = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		GameObject inventory = tempObject.transform.GetChild(0).gameObject;
		bool empty = true;
		for (int i = 0; i < inventory.GetComponent<InventoryLogicC>().inventorySlots.Length; i++)
		{
			if (inventory.GetComponent<InventoryLogicC>().inventorySlots[i].GetComponent<InventoryRelayC>().isOccupied && inventory.GetComponent<InventoryLogicC>().inventorySlots[i].transform.childCount > 0)
			{
				GameObject obj = inventory.GetComponent<InventoryLogicC>().inventorySlots[i].transform.GetChild(0).gameObject;
				empty = false;
				if (obj.GetComponent<ObjectPickupC>().isPurchased)
				{
					if (obj.GetComponent<ObjectPickupC>().sellValue == 0f)
					{
						this.ClearDialogue(0f);
						base.StopCoroutine("NoneSellable");
						base.StartCoroutine("NoneSellable");
						this.ready = true;
						yield break;
					}
					float calcShopLiquidity = this.totalPrice - obj.GetComponent<ObjectPickupC>().sellValue;
					calcShopLiquidity *= -1f;
					if (calcShopLiquidity > this.shopCash)
					{
						this.ClearDialogue(0f);
						base.StopCoroutine("ShopInsufficientFunds");
						base.StartCoroutine("ShopInsufficientFunds");
						this.ready = true;
						yield break;
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj;
					obj.transform.parent.GetComponent<InventoryRelayC>().isOccupied = false;
					if (obj.GetComponent<ObjectPickupC>().dimensionY == 2 && obj.GetComponent<ObjectPickupC>().dimensionX == 1 && obj.GetComponent<ObjectPickupC>().dimensionZ == 1)
					{
						obj.transform.parent.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
					}
					obj.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj.transform.parent = null;
					obj.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren = obj.GetComponentsInChildren<Transform>();
					foreach (Transform transform in allChildren)
					{
						transform.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj, iTween.Hash(new object[]
					{
						"position",
						this.path[2],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBagConvertToMoney",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
				else if (!obj.GetComponent<ObjectPickupC>().isPurchased)
				{
					float priceCheck = this.totalPrice + obj.GetComponent<ObjectPickupC>().buyValue;
					if (this.wallet.GetComponent<WalletC>().TotalWealth < priceCheck)
					{
						base.StartCoroutine("InsufficientFunds");
						yield break;
					}
					if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
					{
						int num = base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count - 1;
						base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.RemoveAt(0);
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj;
					obj.transform.parent.GetComponent<InventoryRelayC>().isOccupied = false;
					if (obj.GetComponent<ObjectPickupC>().dimensionY == 2 && obj.GetComponent<ObjectPickupC>().dimensionX == 1 && obj.GetComponent<ObjectPickupC>().dimensionZ == 1)
					{
						obj.transform.parent.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
					}
					obj.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj.transform.parent = null;
					obj.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren2 = obj.GetComponentsInChildren<Transform>();
					foreach (Transform transform2 in allChildren2)
					{
						transform2.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj, iTween.Hash(new object[]
					{
						"position",
						this.path[1],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBag",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
			}
		}
		for (int ii = 0; ii < inventory.GetComponent<InventoryLogicC>().slot2x2x1.Length; ii++)
		{
			if (inventory.GetComponent<InventoryLogicC>().slot2x2x1[ii].transform.childCount > 0)
			{
				GameObject obj2 = inventory.GetComponent<InventoryLogicC>().slot2x2x1[ii].transform.GetChild(0).gameObject;
				empty = false;
				if (obj2.GetComponent<ObjectPickupC>().isPurchased)
				{
					if (obj2.GetComponent<ObjectPickupC>().sellValue == 0f)
					{
						obj2.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
						this.ClearDialogue(0f);
						base.StopCoroutine("NoneSellable");
						base.StartCoroutine("NoneSellable");
						this.ready = true;
						yield break;
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj2;
					obj2.transform.parent.GetComponent<InventoryRelayC>().isOccupied = false;
					if (obj2.GetComponent<ObjectPickupC>().dimensionY == 2 && obj2.GetComponent<ObjectPickupC>().dimensionX == 1 && obj2.GetComponent<ObjectPickupC>().dimensionZ == 1)
					{
						obj2.transform.parent.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
					}
					obj2.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj2.transform.parent = null;
					obj2.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren3 = obj2.GetComponentsInChildren<Transform>();
					foreach (Transform transform3 in allChildren3)
					{
						transform3.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj2, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						this.path[2],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBagConvertToMoney",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj2, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj2.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj2.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
				else if (!obj2.GetComponent<ObjectPickupC>().isPurchased)
				{
					float priceCheck2 = this.totalPrice + obj2.GetComponent<ObjectPickupC>().buyValue;
					if (this.wallet.GetComponent<WalletC>().TotalWealth < priceCheck2)
					{
						base.StartCoroutine("InsufficientFunds");
						yield break;
					}
					if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
					{
						int num2 = base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count - 1;
						base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.RemoveAt(0);
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj2;
					obj2.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj2.transform.parent = null;
					obj2.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren4 = obj2.GetComponentsInChildren<Transform>();
					foreach (Transform transform4 in allChildren4)
					{
						transform4.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj2, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBag",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj2, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj2.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj2.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
			}
		}
		for (int iii = 0; iii < inventory.GetComponent<InventoryLogicC>().slot2x1x2.Length; iii++)
		{
			if (inventory.GetComponent<InventoryLogicC>().slot2x1x2[iii].transform.childCount > 0)
			{
				GameObject obj3 = inventory.GetComponent<InventoryLogicC>().slot2x1x2[iii].transform.GetChild(0).gameObject;
				empty = false;
				if (obj3.GetComponent<ObjectPickupC>().isPurchased)
				{
					if (obj3.GetComponent<ObjectPickupC>().sellValue == 0f)
					{
						obj3.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
						this.ClearDialogue(0f);
						base.StopCoroutine("NoneSellable");
						base.StartCoroutine("NoneSellable");
						this.ready = true;
						yield break;
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj3;
					obj3.transform.parent.GetComponent<InventoryRelayC>().isOccupied = false;
					if (obj3.GetComponent<ObjectPickupC>().dimensionY == 2 && obj3.GetComponent<ObjectPickupC>().dimensionX == 1 && obj3.GetComponent<ObjectPickupC>().dimensionZ == 1)
					{
						obj3.transform.parent.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
					}
					obj3.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj3.transform.parent = null;
					obj3.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren5 = obj3.GetComponentsInChildren<Transform>();
					foreach (Transform transform5 in allChildren5)
					{
						transform5.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj3, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						this.path[2],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBagConvertToMoney",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj3, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj3.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj3.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
				else if (!obj3.GetComponent<ObjectPickupC>().isPurchased)
				{
					float priceCheck3 = this.totalPrice + obj3.GetComponent<ObjectPickupC>().buyValue;
					if (this.wallet.GetComponent<WalletC>().TotalWealth < priceCheck3)
					{
						base.StartCoroutine("InsufficientFunds");
						yield break;
					}
					if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
					{
						int num3 = base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count - 1;
						base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.RemoveAt(0);
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj3;
					obj3.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj3.transform.parent = null;
					obj3.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren6 = obj3.GetComponentsInChildren<Transform>();
					foreach (Transform transform6 in allChildren6)
					{
						transform6.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj3, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBag",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj3, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj3.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj3.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
			}
		}
		for (int iiii = 0; iiii < inventory.GetComponent<InventoryLogicC>().slot2x2x2.Length; iiii++)
		{
			if (inventory.GetComponent<InventoryLogicC>().slot2x2x2[iiii].transform.childCount > 0)
			{
				GameObject obj4 = inventory.GetComponent<InventoryLogicC>().slot2x2x2[iiii].transform.GetChild(0).gameObject;
				empty = false;
				if (obj4.GetComponent<ObjectPickupC>().isPurchased)
				{
					if (obj4.GetComponent<ObjectPickupC>().sellValue == 0f)
					{
						obj4.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
						this.ClearDialogue(0f);
						base.StopCoroutine("NoneSellable");
						base.StartCoroutine("NoneSellable");
						this.ready = true;
						yield break;
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj4;
					obj4.transform.parent.GetComponent<InventoryRelayC>().isOccupied = false;
					if (obj4.GetComponent<ObjectPickupC>().dimensionY == 2 && obj4.GetComponent<ObjectPickupC>().dimensionX == 1 && obj4.GetComponent<ObjectPickupC>().dimensionZ == 1)
					{
						obj4.transform.parent.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
					}
					obj4.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj4.transform.parent = null;
					obj4.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren7 = obj4.GetComponentsInChildren<Transform>();
					foreach (Transform transform7 in allChildren7)
					{
						transform7.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj4, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						this.path[2],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBagConvertToMoney",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj4, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj4.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj4.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
				else if (!obj4.GetComponent<ObjectPickupC>().isPurchased)
				{
					float priceCheck4 = this.totalPrice + obj4.GetComponent<ObjectPickupC>().buyValue;
					if (this.wallet.GetComponent<WalletC>().TotalWealth < priceCheck4)
					{
						base.StartCoroutine("InsufficientFunds");
						yield break;
					}
					if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
					{
						int num6 = base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count - 1;
						base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.RemoveAt(0);
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj4;
					obj4.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj4.transform.parent = null;
					obj4.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren8 = obj4.GetComponentsInChildren<Transform>();
					foreach (Transform transform8 in allChildren8)
					{
						transform8.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj4, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBag",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj4, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj4.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj4.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
			}
		}
		for (int iiiii = 0; iiiii < inventory.GetComponent<InventoryLogicC>().slot2x2x3.Length; iiiii++)
		{
			if (inventory.GetComponent<InventoryLogicC>().slot2x2x3[iiiii].transform.childCount > 0)
			{
				GameObject obj5 = inventory.GetComponent<InventoryLogicC>().slot2x2x3[iiiii].transform.GetChild(0).gameObject;
				empty = false;
				if (obj5.GetComponent<ObjectPickupC>().isPurchased)
				{
					if (obj5.GetComponent<ObjectPickupC>().sellValue == 0f)
					{
						obj5.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
						this.ClearDialogue(0f);
						base.StopCoroutine("NoneSellable");
						base.StartCoroutine("NoneSellable");
						this.ready = true;
						yield break;
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj5;
					obj5.transform.parent.GetComponent<InventoryRelayC>().isOccupied = false;
					if (obj5.GetComponent<ObjectPickupC>().dimensionY == 2 && obj5.GetComponent<ObjectPickupC>().dimensionX == 1 && obj5.GetComponent<ObjectPickupC>().dimensionZ == 1)
					{
						obj5.transform.parent.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
					}
					obj5.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj5.transform.parent = null;
					obj5.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren9 = obj5.GetComponentsInChildren<Transform>();
					foreach (Transform transform9 in allChildren9)
					{
						transform9.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj5, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						this.path[2],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBagConvertToMoney",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj5, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj5.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj5.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
				else if (!obj5.GetComponent<ObjectPickupC>().isPurchased)
				{
					float priceCheck5 = this.totalPrice + obj5.GetComponent<ObjectPickupC>().buyValue;
					if (this.wallet.GetComponent<WalletC>().TotalWealth < priceCheck5)
					{
						base.StartCoroutine("InsufficientFunds");
						yield break;
					}
					if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
					{
						int num9 = base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count - 1;
						base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.RemoveAt(0);
					}
					if (this.shutterOpen)
					{
						this.CloseShutter();
					}
					this.currentlyProcessedObject = obj5;
					obj5.transform.parent.GetComponent<InventoryRelayC>().UnOccupy();
					obj5.transform.parent = null;
					obj5.layer = LayerMask.NameToLayer("Interactor");
					Transform[] allChildren10 = obj5.GetComponentsInChildren<Transform>();
					foreach (Transform transform10 in allChildren10)
					{
						transform10.gameObject.layer = LayerMask.NameToLayer("Interactor");
					}
					iTween.MoveTo(obj5, iTween.Hash(new object[]
					{
						"path",
						this.path[0],
						this.path[1],
						"time",
						0.1,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo",
						"oncomplete",
						"PlaceObjectIntoShoppingBag",
						"oncompletetarget",
						base.gameObject
					}));
					iTween.RotateTo(obj5, iTween.Hash(new object[]
					{
						"rotation",
						this.path[0].eulerAngles + obj5.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
						"time",
						0.05,
						"islocal",
						false,
						"easetype",
						"easeinoutexpo"
					}));
					obj5.GetComponent<ObjectPickupC>().RandomAudio();
					yield return new WaitForSeconds(0.12f);
				}
			}
		}
		if (empty)
		{
			tempObject.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
			this.ClearDialogue(0f);
			base.StopCoroutine("NoneSellable");
			base.StartCoroutine("NoneSellable");
			this.ready = true;
			yield break;
		}
		inventory.GetComponent<InventoryLogicC>().UpdateInventory();
		yield break;
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x000E4E90 File Offset: 0x000E3290
	public void PlaceObjectIntoShoppingBag()
	{
		iTween.MoveTo(this.currentlyProcessedObject, iTween.Hash(new object[]
		{
			"position",
			this.path[3],
			"time",
			0.5,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
		this.currentlyProcessedObject.GetComponent<Collider>().enabled = true;
		this.currentlyProcessedObject.GetComponent<Collider>().isTrigger = false;
		this.currentlyProcessedObject.gameObject.AddComponent<Rigidbody>();
		this.currentlyProcessedObject.GetComponent<Rigidbody>().mass = this.currentlyProcessedObject.GetComponent<ObjectPickupC>().rigidMass;
		this.shoppingKart.Add(this.currentlyProcessedObject);
		this.currentlyProcessedObject.GetComponent<ObjectPickupC>().isInShoppingKart = true;
		if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().store == null)
		{
			this.currentlyProcessedObject.GetComponent<ObjectPickupC>().store = base.transform.parent;
		}
		if (!this.currentlyProcessedObject.GetComponent<ObjectPickupC>().isPurchased)
		{
			this.totalPrice += this.currentlyProcessedObject.GetComponent<ObjectPickupC>().buyValue;
		}
		else if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().isTradeGood)
		{
			float num = 0f;
			if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().supplyNumber == 0)
			{
				num = base.transform.parent.GetComponent<StoreC>().supplyCatalogueSellPrices[base.transform.parent.GetComponent<StoreC>().supplyNumbers[0]];
			}
			else if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().supplyNumber == 1)
			{
				num = base.transform.parent.GetComponent<StoreC>().supplyCatalogueSellPrices[base.transform.parent.GetComponent<StoreC>().supplyNumbers[1]];
			}
			else if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().supplyNumber == 2)
			{
				num = base.transform.parent.GetComponent<StoreC>().supplyCatalogueSellPrices[base.transform.parent.GetComponent<StoreC>().supplyNumbers[2]];
			}
			else if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().supplyNumber == 3)
			{
				num = base.transform.parent.GetComponent<StoreC>().supplyCatalogueSellPrices[base.transform.parent.GetComponent<StoreC>().supplyNumbers[3]];
			}
			else if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().supplyNumber == 4)
			{
				num = base.transform.parent.GetComponent<StoreC>().supplyCatalogueSellPrices[base.transform.parent.GetComponent<StoreC>().supplyNumbers[4]];
			}
			else if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().supplyNumber == 5)
			{
				num = base.transform.parent.GetComponent<StoreC>().supplyCatalogueSellPrices[base.transform.parent.GetComponent<StoreC>().supplyNumbers[5]];
			}
			this.totalPrice -= num;
			float num2 = num - this.currentlyProcessedObject.GetComponent<ObjectPickupC>().sellValue;
			Debug.Log("Profit made" + num2);
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.cashRegisterAudio, 1f);
		this.totalPrice = Mathf.Round(this.totalPrice * 100f) / 100f;
		if (this.totalPrice < 10f && this.totalPrice > 0f)
		{
			if (this.totalPrice % 1f != 0f)
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + "0";
			}
			else
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + ".00";
			}
		}
		else if (this.totalPrice % 1f != 0f)
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + "0";
		}
		else
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + ".00";
		}
		base.transform.parent.GetComponent<StoreC>().GateCheck();
		base.StartCoroutine("PriceFlicker");
		this.ready = true;
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x000E5368 File Offset: 0x000E3768
	public void PlaceObjectIntoShoppingBagConvertToMoney()
	{
		this.currentlyProcessedObject.GetComponent<Collider>().enabled = true;
		this.currentlyProcessedObject.GetComponent<Collider>().isTrigger = false;
		this.currentlyProcessedObject.gameObject.AddComponent<Rigidbody>();
		this.currentlyProcessedObject.GetComponent<Rigidbody>().mass = this.currentlyProcessedObject.GetComponent<ObjectPickupC>().rigidMass;
		this.shoppingKart.Add(this.currentlyProcessedObject);
		this.currentlyProcessedObject.GetComponent<ObjectPickupC>().isInShoppingKart = true;
		if (!this.currentlyProcessedObject.GetComponent<ObjectPickupC>().isPurchased)
		{
			this.totalPrice += this.currentlyProcessedObject.GetComponent<ObjectPickupC>().buyValue;
		}
		else
		{
			this.totalPrice -= this.currentlyProcessedObject.GetComponent<ObjectPickupC>().sellValue;
		}
		if (this.currentlyProcessedObject.GetComponent<ObjectPickupC>().store == null)
		{
			this.currentlyProcessedObject.GetComponent<ObjectPickupC>().store = base.transform.parent;
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.cashRegisterAudio, 1f);
		this.totalPrice = Mathf.Round(this.totalPrice * 100f) / 100f;
		if (this.totalPrice < 10f && this.totalPrice >= 0f)
		{
			if (this.totalPrice % 1f != 0f)
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + "0";
			}
			else
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + ".00";
			}
		}
		else if (this.totalPrice % 1f != 0f)
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + "0";
		}
		else
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + ".00";
		}
		base.transform.parent.GetComponent<StoreC>().GateCheck();
		base.StartCoroutine("PriceFlicker");
		this.ready = true;
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x000E55E0 File Offset: 0x000E39E0
	private IEnumerator PriceFlicker()
	{
		this.visualPrice.active = false;
		yield return new WaitForSeconds(0.05f);
		this.visualPrice.active = true;
		yield return new WaitForSeconds(0.1f);
		this.visualPrice.active = false;
		yield return new WaitForSeconds(0.1f);
		this.visualPrice.active = true;
		yield break;
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x000E55FC File Offset: 0x000E39FC
	public void CloseShutter()
	{
		this.shutterOpen = false;
		iTween.MoveTo(this.shutter, iTween.Hash(new object[]
		{
			"y",
			this.shutterPos[0].y,
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo"
		}));
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x000E5684 File Offset: 0x000E3A84
	public void CheckAchievements()
	{
		if (this.totalPrice < 0f)
		{
			float num = this.totalPrice * -1f;
			if (this._steam == null)
			{
				this._steam = GameObject.FindWithTag("Steam");
			}
			if (base.transform.parent.GetComponent<StoreC>().countryCode == 0)
			{
				this.director.GetComponent<DirectorC>().gerGoodTracker += num;
			}
			else if (base.transform.parent.GetComponent<StoreC>().countryCode == 1)
			{
				this.director.GetComponent<DirectorC>().csfrGoodTracker += num;
			}
			else if (base.transform.parent.GetComponent<StoreC>().countryCode == 2)
			{
				this.director.GetComponent<DirectorC>().hunGoodTracker += num;
			}
			else if (base.transform.parent.GetComponent<StoreC>().countryCode == 3)
			{
				this.director.GetComponent<DirectorC>().yugoGoodTracker += num;
			}
			else if (base.transform.parent.GetComponent<StoreC>().countryCode == 4)
			{
				this.director.GetComponent<DirectorC>().bulGoodTracker += num;
			}
			else if (base.transform.parent.GetComponent<StoreC>().countryCode == 5)
			{
				this.director.GetComponent<DirectorC>().turkGoodTracker += num;
			}
			if (this._steam != null)
			{
				if (base.transform.parent.GetComponent<StoreC>().countryCode == 0)
				{
					this._steam.GetComponent<SteamStatsAndAchievements>().UpdateGerGoodsTracking((int)num);
				}
				else if (base.transform.parent.GetComponent<StoreC>().countryCode == 1)
				{
					this.director.GetComponent<DirectorC>().csfrGoodTracker += num;
					this._steam.SendMessage("UpdateCsfrGoodsTracking", num);
				}
				else if (base.transform.parent.GetComponent<StoreC>().countryCode == 2)
				{
					this.director.GetComponent<DirectorC>().hunGoodTracker += num;
					this._steam.SendMessage("UpdateHunGoodsTracking", num);
				}
				else if (base.transform.parent.GetComponent<StoreC>().countryCode == 3)
				{
					this.director.GetComponent<DirectorC>().yugoGoodTracker += num;
					this._steam.SendMessage("UpdateYugoGoodsTracking", num);
				}
				else if (base.transform.parent.GetComponent<StoreC>().countryCode == 4)
				{
					this.director.GetComponent<DirectorC>().bulGoodTracker += num;
					this._steam.SendMessage("UpdateBulGoodsTracking", num);
				}
				else if (base.transform.parent.GetComponent<StoreC>().countryCode == 5)
				{
					this.director.GetComponent<DirectorC>().turkGoodTracker += num;
					this._steam.SendMessage("UpdateTurkGoodsTracking", num);
				}
			}
		}
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x000E59DC File Offset: 0x000E3DDC
	public void Payed()
	{
		this.wallet.GetComponent<WalletC>().incomingFunds -= this.totalPrice;
		this.wallet.GetComponent<WalletC>().UpdateWealth();
		this.CheckAchievements();
		this.shopCash += this.totalPrice;
		this.ClearDialogue(0f);
		base.StopCoroutine("TransactionCompleted");
		base.StartCoroutine("TransactionCompleted");
		for (int i = 0; i < this.shoppingKart.Count; i++)
		{
			if (this.fuelUsed > 0f)
			{
				float totalFuelPrice = this.fuelUsed * this.fuelPrice;
				this.director.GetComponent<DirectorC>().EventLogPurchasedFuel(this.fuelUsed, totalFuelPrice);
			}
			if (!this.shoppingKart[i].GetComponent<ObjectPickupC>().isPurchased)
			{
				this.director.GetComponent<DirectorC>().eventLogPurchasedObj.Add(this.shoppingKart[i]);
			}
			else
			{
				this.director.GetComponent<DirectorC>().eventLogSoldObj.Add(this.shoppingKart[i]);
			}
		}
		if (this.director.GetComponent<DirectorC>().eventLogPurchasedObj.Count > 0)
		{
			this.director.GetComponent<DirectorC>().UpdateEventLogPurchased();
		}
		if (this.director.GetComponent<DirectorC>().eventLogSoldObj.Count > 0)
		{
			this.director.GetComponent<DirectorC>().UpdateEventLogSold();
		}
		for (int j = 0; j < this.shoppingKart.Count; j++)
		{
			this.shoppingKart[j].GetComponent<ObjectPickupC>().isPurchased = true;
			this.shoppingKart[j].GetComponent<ObjectPickupC>().isInShoppingKart = false;
		}
		this.shoppingKart.Clear();
		this.totalPrice = 0f;
		this.fuelUsed = 0f;
		this.fuelHandle.GetComponent<RefuelLogicC>().fuelUsed = 0f;
		this.fuelHandle.GetComponent<RefuelLogicC>().fuelWatcher = 1f;
		base.GetComponent<AudioSource>().PlayOneShot(this.payedAudio, 1f);
		this.visualPrice.GetComponent<TextMesh>().text = "00.00";
		base.StartCoroutine("PriceFlicker");
		for (int k = 0; k < this.petrolCounters.Length; k++)
		{
			Vector3 localEulerAngles = this.petrolCounters[k].transform.localEulerAngles;
			localEulerAngles.z = 0f;
			this.petrolCounters[k].transform.localEulerAngles = localEulerAngles;
		}
		for (int l = 0; l < this.petrolPriceCounters.Length; l++)
		{
			Vector3 localEulerAngles2 = this.petrolPriceCounters[l].transform.localEulerAngles;
			localEulerAngles2.z = 0f;
			this.petrolPriceCounters[l].transform.localEulerAngles = localEulerAngles2;
		}
		this.OpenShutter();
		base.transform.parent.GetComponent<StoreC>().GateCheck();
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		GameObject uncle = gameObject.GetComponent<CarLogicC>().uncle;
		if (uncle.GetComponent<UncleLogicC>().fuelTutorialState == 3)
		{
			uncle.GetComponent<UncleLogicC>().fuelTutorialState = 4;
		}
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x000E5D1B File Offset: 0x000E411B
	public void CancelTransaction()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.leverAudio, 1f);
		base.StartCoroutine("ReturnAllToShelf");
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x000E5D40 File Offset: 0x000E4140
	public void ReturnAllToShelf()
	{
		for (int i = 0; i < this.shoppingKart.Count; i++)
		{
			if (!this.shoppingKart[i].GetComponent<ObjectPickupC>().isPurchased)
			{
				this.shoppingKart[i].GetComponent<ObjectPickupC>().isInShoppingKart = false;
				this.shoppingKart[i].SendMessage("ReturnToShelfFromKart");
				this.shoppingKart[i].GetComponent<ObjectPickupC>().store.GetComponent<StoreC>().GateCheck();
			}
			else
			{
				this.shoppingKart[i].GetComponent<ObjectPickupC>().isInShoppingKart = false;
				this.shoppingKart[i].transform.parent = base.transform;
				Vector3 localPosition = new Vector3(0f, -1f, 0f);
				this.shoppingKart[i].transform.localPosition = localPosition;
				this.shoppingKart[i].transform.parent = null;
				this.shoppingKart[i].GetComponent<ObjectPickupC>().store.GetComponent<StoreC>().GateCheck();
			}
		}
		this.shoppingKart.Clear();
		int count = base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count;
		for (int j = 0; j < count; j++)
		{
			Debug.Log("i2 total == " + base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count);
			Debug.Log("i2 == " + j);
			if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].transform.parent != null)
			{
				if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].transform.parent.name == "CarryHolder1")
				{
					base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].GetComponent<ObjectPickupC>().ReturnToShelf();
					this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
					if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null)
					{
						this._camera.GetComponent<DragRigidbodyC>().Holding2ToHands();
					}
				}
				else if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].transform.parent.name == "CarryHolder2")
				{
					this._camera.GetComponent<DragRigidbodyC>().Swap2With1();
					base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].GetComponent<ObjectPickupC>().ReturnToShelf();
					this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
					if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null)
					{
						this._camera.GetComponent<DragRigidbodyC>().Holding2ToHands();
					}
				}
				else if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].transform.parent.name == "CarryHolder3")
				{
					this._camera.GetComponent<DragRigidbodyC>().Swap3With1();
					base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].GetComponent<ObjectPickupC>().ReturnToShelf();
					this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
					if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null)
					{
						this._camera.GetComponent<DragRigidbodyC>().Holding2ToHands();
					}
				}
				else if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].transform.parent.GetComponent<InventoryRelayC>())
				{
					base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].GetComponent<ObjectPickupC>().ShopOutOfInventory();
					base.transform.parent.GetComponent<StoreC>().unPaidCatalogue[0].GetComponent<ObjectPickupC>().ReturnToShelf();
				}
			}
		}
		if (base.transform.parent.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
		{
		}
		this.totalPrice = 0f;
		for (int k = 0; k < this.portableFuelRefilledList.Count; k++)
		{
			this.portableFuelRefilledList[k].GetComponent<PortableFuelC>().fuelLevel -= this.portableFuelRefilledNumbers[k];
			this.fuelUsed -= (float)this.portableFuelRefilledNumbers[k];
			if (this.portableFuelRefilledList[k].GetComponent<PortableFuelC>().fuelLevel < 0)
			{
				this.portableFuelRefilledList[k].GetComponent<PortableFuelC>().fuelLevel = 0;
			}
			this.portableFuelRefilledList[k].GetComponent<PortableFuelC>().FuelUpdate();
			this.portableFuelRefilledList[k].GetComponent<PortableFuelC>().addedToShopTracking = false;
			this.portableFuelRefilledList[k].GetComponent<PortableFuelC>().shop = null;
			this.portableFuelRefilledList[k].GetComponent<PortableFuelC>().shopTrackingReff = 0;
		}
		this.portableFuelRefilledList.Clear();
		this.portableFuelRefilledNumbers.Clear();
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		if (gameObject.GetComponent<CarPerformanceC>().installedFuelTank)
		{
			Debug.Log("Fuel Used = " + this.fuelUsed);
			gameObject.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount -= this.fuelUsed;
			gameObject.GetComponent<CarPerformanceC>().UpdateFuelInTank();
		}
		this.fuelUsed = 0f;
		this.fuelHandle.GetComponent<RefuelLogicC>().fuelUsed = 0f;
		this.fuelHandle.GetComponent<RefuelLogicC>().fuelWatcher = 1f;
		for (int l = 0; l < this.petrolCounters.Length; l++)
		{
			Vector3 localEulerAngles = this.petrolCounters[l].transform.localEulerAngles;
			localEulerAngles.z = 0f;
			this.petrolCounters[l].transform.localEulerAngles = localEulerAngles;
		}
		for (int m = 0; m < this.petrolPriceCounters.Length; m++)
		{
			Vector3 localEulerAngles2 = this.petrolPriceCounters[m].transform.localEulerAngles;
			localEulerAngles2.z = 0f;
			this.petrolPriceCounters[m].transform.localEulerAngles = localEulerAngles2;
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.insfAudio, 1f);
		this.totalPrice = Mathf.Round(this.totalPrice * 100f) / 100f;
		if (this.totalPrice < 10f && this.totalPrice >= 0f)
		{
			if (this.totalPrice % 1f != 0f)
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + "0";
			}
			else
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + ".00";
			}
		}
		else if (this.totalPrice % 1f != 0f)
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + "0";
		}
		else
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + ".00";
		}
		base.StartCoroutine("PriceFlicker");
		this.OpenShutter();
		base.transform.parent.GetComponent<StoreC>().GateCheck();
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x000E6580 File Offset: 0x000E4980
	private IEnumerator InsufficientFunds()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.insfAudio, 1f);
		this.visualPrice.GetComponent<TextMesh>().text = "INSUF FNDS";
		this.visualPrice.active = false;
		yield return new WaitForSeconds(0.05f);
		this.visualPrice.active = true;
		yield return new WaitForSeconds(0.1f);
		this.visualPrice.active = false;
		yield return new WaitForSeconds(0.1f);
		this.visualPrice.active = true;
		yield return new WaitForSeconds(0.2f);
		if (this.totalPrice < 10f && this.totalPrice >= 0f)
		{
			if (this.totalPrice % 1f != 0f)
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + "0";
			}
			else
			{
				this.visualPrice.GetComponent<TextMesh>().text = "0" + this.totalPrice.ToString() + ".00";
			}
		}
		else if (this.totalPrice % 1f != 0f)
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + "0";
		}
		else
		{
			this.visualPrice.GetComponent<TextMesh>().text = this.totalPrice.ToString() + ".00";
		}
		this.ready = true;
		yield break;
	}

	// Token: 0x060009CC RID: 2508 RVA: 0x000E659C File Offset: 0x000E499C
	public void DialogueExplainLever()
	{
		this.shopCharacter.GetComponent<Animator>().SetBool("talking", true);
		int num = UnityEngine.Random.Range(0, this.audioMumble.Length);
		base.GetComponent<AudioSource>().PlayOneShot(this.audioMumble[num], 1f);
		GameObject dialogueHolder = this.director.GetComponent<DirectorC>().dialogueHolder;
		base.StartCoroutine("DialogueForTheLever");
	}

	// Token: 0x060009CD RID: 2509 RVA: 0x000E6604 File Offset: 0x000E4A04
	private IEnumerator DialogueForTheLever()
	{
		this.dialogueChecker = "DialogueForTheLever";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("sk_levertut_01", "Speech"));
			base.StartCoroutine(this.DialogueSpeech());
		}
		yield break;
	}

	// Token: 0x060009CE RID: 2510 RVA: 0x000E6620 File Offset: 0x000E4A20
	public void OpenShutter()
	{
		iTween.MoveTo(this.shutter, iTween.Hash(new object[]
		{
			"y",
			this.shutterPos[1].y,
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo"
		}));
		this.shutterOpen = true;
		this.ready = true;
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x000E66AC File Offset: 0x000E4AAC
	public IEnumerator ResumeTalkingFromList()
	{
		if (this.textQueue.Count > 0)
		{
			base.StartCoroutine(this.DialogueSpeech());
		}
		yield return new WaitForSeconds(Time.deltaTime * 3f);
		yield break;
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x000E66C8 File Offset: 0x000E4AC8
	public IEnumerator RemoveCurrentItemFromList()
	{
		for (int i = 0; i < this.textQueue.Count; i++)
		{
			if (this.textQueue[i] == this.dialogueConvoItem)
			{
				this.textQueue.RemoveAt(i);
			}
		}
		yield return new WaitForEndOfFrame();
		yield break;
	}

	// Token: 0x060009D1 RID: 2513 RVA: 0x000E66E4 File Offset: 0x000E4AE4
	private IEnumerator ClearDialogue(float delay)
	{
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().text = string.Empty;
		yield return new WaitForSeconds(delay);
		this.director.GetComponent<DirectorC>().BubbleOff();
		yield break;
	}

	// Token: 0x060009D2 RID: 2514 RVA: 0x000E6708 File Offset: 0x000E4B08
	public IEnumerator DialogueCheck()
	{
		if (this.dialogueConvoItem != string.Empty && this.dialogueConvoItem != this.dialogueChecker)
		{
			this.canSpeak = false;
			this.AddItemToStartOfQueue();
			yield break;
		}
		yield return new WaitForSeconds(Time.deltaTime * 3f);
		base.StopCoroutine(this.ClearDialogue(0f));
		base.StartCoroutine(this.ClearDialogue(0f));
		base.StopCoroutine(this.DialogueSpeech());
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StopTypeText();
		this.isTalking = true;
		this.dialogueConvoItem = this.dialogueChecker;
		this.dialogueChecker = string.Empty;
		this.textFinished = false;
		this.canSpeak = true;
		yield break;
	}

	// Token: 0x060009D3 RID: 2515 RVA: 0x000E6724 File Offset: 0x000E4B24
	private IEnumerator DialogueSpeech()
	{
		base.StopCoroutine(this.StopInputRestrict());
		this.dialogueSpeechComplete = false;
		this.canSpeak = false;
		for (int i = 0; i < this.speechStack.Count; i++)
		{
			this.textFinished = false;
			yield return new WaitForSeconds(0.2f);
			this.director.GetComponent<DirectorC>().BubbleOn(this.shopCharacterMouth.transform, this.characterName);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().word = this.speechStack[i];
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			int rnd = UnityEngine.Random.Range(0, this.audioMumble.Length);
			this.shopCharacter.GetComponent<AudioSource>().clip = this.audioMumble[rnd];
			this.shopCharacter.GetComponent<AudioSource>().Play();
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			while (!Input.GetButton("Fire1") && !Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKey(MainMenuC.Global.assignedInputStrings[17]))
			{
				yield return new WaitForEndOfFrame();
			}
			while (this.inputRestrictDropItem)
			{
				yield return new WaitForEndOfFrame();
			}
			base.StartCoroutine(this.StopInputRestrict());
			base.StopCoroutine(this.ClearDialogue(0f));
			base.StartCoroutine(this.ClearDialogue(0f));
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForEndOfFrame();
		}
		this.isTalking = false;
		this.dialogueSpeechComplete = true;
		base.StartCoroutine(this.RemoveCurrentItemFromList());
		this.dialogueConvoItem = string.Empty;
		base.StartCoroutine(this.ResumeTalkingFromList());
		yield break;
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x000E6740 File Offset: 0x000E4B40
	public void AddItemToStartOfQueue()
	{
		for (int i = 0; i < this.textQueue.Count; i++)
		{
			if (this.textQueue[i] == this.dialogueConvoItem)
			{
				return;
			}
		}
		this.textQueue.Insert(0, this.dialogueConvoItem);
	}

	// Token: 0x060009D5 RID: 2517 RVA: 0x000E6798 File Offset: 0x000E4B98
	public void StopInputRestrictStopper()
	{
		base.StopCoroutine("StopInputRestrict");
	}

	// Token: 0x060009D6 RID: 2518 RVA: 0x000E67A8 File Offset: 0x000E4BA8
	private IEnumerator StopInputRestrict()
	{
		yield return new WaitForSeconds(0.5f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x060009D7 RID: 2519 RVA: 0x000E67C3 File Offset: 0x000E4BC3
	public void TextFinished()
	{
		this.textFinished = true;
	}

	// Token: 0x060009D8 RID: 2520 RVA: 0x000E67CC File Offset: 0x000E4BCC
	public void PlayerTriggerEnter()
	{
		if (!this.isWelcomed && !this.hasGreeted)
		{
			this.isWelcomed = true;
			ES3.Save(this.isWelcomed, "shopIsWelcomed");
			base.StartCoroutine(this.Welcome());
		}
		this.shopCharacter.GetComponent<Animator>().SetTrigger("PlayerEnters");
	}

	// Token: 0x060009D9 RID: 2521 RVA: 0x000E6828 File Offset: 0x000E4C28
	public void PlayerTriggerExit()
	{
		base.StopCoroutine("Welcome");
		base.StopCoroutine("WelcomeAgain");
		if (!this.hasRemindedPlayerNotToSteal)
		{
			if (this.player.GetComponent<DragRigidbodyC>().isHolding1 != null)
			{
				if (this.player.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ObjectPickupC>() && !this.player.GetComponent<DragRigidbodyC>().isHolding1.GetComponent<ObjectPickupC>().isPurchased)
				{
					base.StartCoroutine(this.PayForThatItem());
				}
			}
			else if (this.player.GetComponent<DragRigidbodyC>().isHolding2 != null)
			{
				if (this.player.GetComponent<DragRigidbodyC>().isHolding2.GetComponent<ObjectPickupC>() && !this.player.GetComponent<DragRigidbodyC>().isHolding2.GetComponent<ObjectPickupC>().isPurchased)
				{
					base.StartCoroutine(this.PayForThatItem());
				}
			}
			else if (this.player.GetComponent<DragRigidbodyC>().isHolding3 != null && this.player.GetComponent<DragRigidbodyC>().isHolding3.GetComponent<ObjectPickupC>() && !this.player.GetComponent<DragRigidbodyC>().isHolding3.GetComponent<ObjectPickupC>().isPurchased)
			{
				base.StartCoroutine(this.PayForThatItem());
			}
		}
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x000E6994 File Offset: 0x000E4D94
	private IEnumerator PayForThatItem()
	{
		this.dialogueChecker = "PayForThatItem";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("sk_thf_stp_ger_01", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.hasRemindedPlayerNotToSteal = true;
		}
		yield break;
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x000E69B0 File Offset: 0x000E4DB0
	private IEnumerator Welcome()
	{
		this.dialogueChecker = "Welcome";
		base.StartCoroutine(this.DialogueCheck());
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.hasGreeted = true;
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("sk_pet_greet_ger_06", "Speech"));
			this.speechStack.Add(Language.Get("sk_pet_greet_ger_07", "Speech"));
			this.speechStack.Add(Language.Get("sk_pet_greet_ger_08", "Speech"));
			base.StartCoroutine(this.DialogueSpeech());
		}
		yield break;
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x000E69CC File Offset: 0x000E4DCC
	private IEnumerator WelcomeAgain()
	{
		this.dialogueChecker = "WelcomeAgain";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			int num = UnityEngine.Random.Range(0, 2);
			this.speechStack.Clear();
			if (num == 0)
			{
				this.speechStack.Add(Language.Get("sk_pet_greet_ger_01", "Speech"));
			}
			else if (num == 1)
			{
				this.speechStack.Add(Language.Get("sk_pet_greet_ger_02", "Speech"));
			}
			else if (num == 2)
			{
				this.speechStack.Add(Language.Get("sk_pet_greet_ger_03", "Speech"));
			}
			base.StartCoroutine("DialogueSpeech");
			yield break;
		}
		yield break;
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x000E69E8 File Offset: 0x000E4DE8
	private IEnumerator ShopInsufficientFunds()
	{
		this.dialogueChecker = "ShopInsufficientFunds";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			int num = UnityEngine.Random.Range(0, 3);
			this.speechStack.Clear();
			if (num == 0)
			{
				this.speechStack.Add(Language.Get("sk_shp_nomny_01", "Speech"));
			}
			else if (num == 1)
			{
				this.speechStack.Add(Language.Get("sk_shp_nomny_02", "Speech"));
			}
			else if (num == 2)
			{
				this.speechStack.Add(Language.Get("sk_shp_nomny_03", "Speech"));
			}
			else if (num == 3)
			{
				this.speechStack.Add(Language.Get("sk_shp_nomny_04", "Speech"));
			}
			base.StartCoroutine("DialogueSpeech");
			yield break;
		}
		yield break;
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x000E6A04 File Offset: 0x000E4E04
	private IEnumerator NoneSellable()
	{
		this.dialogueChecker = "NoneSellable";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			int num = UnityEngine.Random.Range(0, 2);
			this.speechStack.Clear();
			if (num == 0)
			{
				this.speechStack.Add(Language.Get("sk_nonesell_01", "Speech"));
			}
			else if (num == 1)
			{
				this.speechStack.Add(Language.Get("sk_nonesell_02", "Speech"));
			}
			else if (num == 2)
			{
				this.speechStack.Add(Language.Get("sk_nonesell_03", "Speech"));
			}
			base.StartCoroutine("DialogueSpeech");
			yield break;
		}
		yield break;
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x000E6A1F File Offset: 0x000E4E1F
	public void TransactionCompleted()
	{
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x000E6A24 File Offset: 0x000E4E24
	public void RaycastEnter()
	{
		this.isGlowing = true;
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.glowMaterial;
		}
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x000E6A68 File Offset: 0x000E4E68
	public void RaycastExit()
	{
		this.isGlowing = false;
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x04000D41 RID: 3393
	private GameObject _steam;

	// Token: 0x04000D42 RID: 3394
	private GameObject _camera;

	// Token: 0x04000D43 RID: 3395
	[HideInInspector]
	public GameObject director;

	// Token: 0x04000D44 RID: 3396
	public GameObject player;

	// Token: 0x04000D45 RID: 3397
	public GameObject shopCharacter;

	// Token: 0x04000D46 RID: 3398
	public GameObject shopCharacterMouth;

	// Token: 0x04000D47 RID: 3399
	public AudioClip[] audioMumble = new AudioClip[0];

	// Token: 0x04000D48 RID: 3400
	public List<GameObject> shoppingKart = new List<GameObject>();

	// Token: 0x04000D49 RID: 3401
	public GameObject wallet;

	// Token: 0x04000D4A RID: 3402
	public float shopCash = 200f;

	// Token: 0x04000D4B RID: 3403
	public float totalPrice;

	// Token: 0x04000D4C RID: 3404
	public float fuelUsed;

	// Token: 0x04000D4D RID: 3405
	public float fuelPrice;

	// Token: 0x04000D4E RID: 3406
	public GameObject visualPrice;

	// Token: 0x04000D4F RID: 3407
	private GameObject currentlyProcessedObject;

	// Token: 0x04000D50 RID: 3408
	public GameObject fuelHandle;

	// Token: 0x04000D51 RID: 3409
	public GameObject[] petrolCounters = new GameObject[0];

	// Token: 0x04000D52 RID: 3410
	public GameObject[] petrolPriceCounters = new GameObject[0];

	// Token: 0x04000D53 RID: 3411
	public GameObject shutter;

	// Token: 0x04000D54 RID: 3412
	public bool shutterOpen;

	// Token: 0x04000D55 RID: 3413
	public Vector3[] shutterPos = new Vector3[0];

	// Token: 0x04000D56 RID: 3414
	public Transform[] path = new Transform[0];

	// Token: 0x04000D57 RID: 3415
	public GameObject glowTarget;

	// Token: 0x04000D58 RID: 3416
	public Material startMaterial;

	// Token: 0x04000D59 RID: 3417
	public Material glowMaterial;

	// Token: 0x04000D5A RID: 3418
	private bool ready = true;

	// Token: 0x04000D5B RID: 3419
	public AudioClip cashRegisterAudio;

	// Token: 0x04000D5C RID: 3420
	public AudioClip insfAudio;

	// Token: 0x04000D5D RID: 3421
	public AudioClip payedAudio;

	// Token: 0x04000D5E RID: 3422
	public AudioClip leverAudio;

	// Token: 0x04000D5F RID: 3423
	public GameObject[] renderTargets = new GameObject[0];

	// Token: 0x04000D60 RID: 3424
	private bool isGlowing;

	// Token: 0x04000D61 RID: 3425
	public bool isTalking;

	// Token: 0x04000D62 RID: 3426
	public bool textFinished;

	// Token: 0x04000D63 RID: 3427
	public List<string> textQueue = new List<string>();

	// Token: 0x04000D64 RID: 3428
	public string currentConvoItem;

	// Token: 0x04000D65 RID: 3429
	public string interruptConvoItem;

	// Token: 0x04000D66 RID: 3430
	public string dialogueConvoItem;

	// Token: 0x04000D67 RID: 3431
	public List<string> speechStack = new List<string>();

	// Token: 0x04000D68 RID: 3432
	public bool inputRestrictDropItem;

	// Token: 0x04000D69 RID: 3433
	public string interruptChecker = string.Empty;

	// Token: 0x04000D6A RID: 3434
	public string dialogueChecker = string.Empty;

	// Token: 0x04000D6B RID: 3435
	public bool canSpeak;

	// Token: 0x04000D6C RID: 3436
	public bool interruptSpeechComplete;

	// Token: 0x04000D6D RID: 3437
	public bool dialogueSpeechComplete;

	// Token: 0x04000D6E RID: 3438
	public bool isWelcomed;

	// Token: 0x04000D6F RID: 3439
	public bool hasGreeted;

	// Token: 0x04000D70 RID: 3440
	public bool hasRemindedPlayerNotToSteal;

	// Token: 0x04000D71 RID: 3441
	public List<GameObject> portableFuelRefilledList = new List<GameObject>();

	// Token: 0x04000D72 RID: 3442
	public List<int> portableFuelRefilledNumbers = new List<int>();

	// Token: 0x04000D73 RID: 3443
	public string characterName = "ui_name_03";
}
