using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
public class InventoryLogicC : MonoBehaviour
{
	// Token: 0x06000314 RID: 788 RVA: 0x0002B6E3 File Offset: 0x00029AE3
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		if (base.GetComponent<Renderer>())
		{
			this.startMaterial = base.GetComponent<Renderer>().material;
		}
	}

	// Token: 0x06000315 RID: 789 RVA: 0x0002B718 File Offset: 0x00029B18
	private void Update()
	{
		if (base.transform.parent && base.transform.parent.GetComponent<ObjectPickupC>() && base.transform.parent.GetComponent<ObjectPickupC>().isGlowing)
		{
			this.isGlowing = false;
			this.glowTarget1.GetComponent<Renderer>().material = this.startMaterial;
			if (this.glowTarget2)
			{
				this.glowTarget2.GetComponent<Renderer>().material = this.startMaterial;
			}
		}
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.glowTarget1.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			if (this.glowTarget2)
			{
				this.glowTarget2.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0002B818 File Offset: 0x00029C18
	private void IsHolding()
	{
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0002B81A File Offset: 0x00029C1A
	private void NoLongerHolding()
	{
	}

	// Token: 0x06000318 RID: 792 RVA: 0x0002B81C File Offset: 0x00029C1C
	private void RemoveAllFromInventory()
	{
		for (int i = 0; i < this.inventorySlots.Length; i++)
		{
			if (this.inventorySlots[i].GetComponent<InventoryRelayC>().isOccupied && this.inventorySlots[i].transform.childCount > 0)
			{
				Transform child = this.inventorySlots[i].transform.GetChild(0);
				if (child.GetComponent<ObjectPickupC>())
				{
					child.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int j = 0; j < this.slot2x2x1.Length; j++)
		{
			if (this.slot2x2x1[j].transform.childCount > 0)
			{
				Transform child2 = this.slot2x2x1[j].GetChild(0);
				if (child2.GetComponent<ObjectPickupC>())
				{
					child2.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int k = 0; k < this.slot3x2x1.Length; k++)
		{
			if (this.slot3x2x1[k].transform.childCount > 0)
			{
				Transform child3 = this.slot3x2x1[k].GetChild(0);
				if (child3.GetComponent<ObjectPickupC>())
				{
					child3.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int l = 0; l < this.slot2x1x2.Length; l++)
		{
			if (this.slot2x1x2[l].transform.childCount > 0)
			{
				Transform child4 = this.slot2x1x2[l].GetChild(0);
				if (child4.GetComponent<ObjectPickupC>())
				{
					child4.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int m = 0; m < this.slot2x2x2.Length; m++)
		{
			if (this.slot2x2x2[m].transform.childCount > 0)
			{
				Transform child5 = this.slot2x2x2[m].GetChild(0);
				if (child5.GetComponent<ObjectPickupC>())
				{
					child5.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int n = 0; n < this.slot2x2x3.Length; n++)
		{
			if (this.slot2x2x3[n].transform.childCount > 0)
			{
				Transform child6 = this.slot2x2x3[n].GetChild(0);
				if (child6.GetComponent<ObjectPickupC>())
				{
					child6.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int num = 0; num < this.slot2x1x3.Length; num++)
		{
			if (this.slot2x1x3[num].transform.childCount > 0)
			{
				Transform child7 = this.slot2x1x3[num].GetChild(0);
				if (child7.GetComponent<ObjectPickupC>())
				{
					child7.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int num2 = 0; num2 < this.slot3x2x3.Length; num2++)
		{
			if (this.slot3x2x3[num2].transform.childCount > 0)
			{
				Transform child8 = this.slot3x2x3[num2].GetChild(0);
				if (child8.GetComponent<ObjectPickupC>())
				{
					child8.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int num3 = 0; num3 < this.slot4x2x2.Length; num3++)
		{
			if (this.slot4x2x2[num3].transform.childCount > 0)
			{
				Transform child9 = this.slot4x2x2[num3].GetChild(0);
				if (child9.GetComponent<ObjectPickupC>())
				{
					child9.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int num4 = 0; num4 < this.slot4x2x3.Length; num4++)
		{
			if (this.slot4x2x3[num4].transform.childCount > 0)
			{
				Transform child10 = this.slot4x2x3[num4].GetChild(0);
				if (child10.GetComponent<ObjectPickupC>())
				{
					child10.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int num5 = 0; num5 < this.slot4x1x1.Length; num5++)
		{
			if (this.slot4x1x1[num5].transform.childCount > 0)
			{
				Transform child11 = this.slot4x1x1[num5].GetChild(0);
				if (child11.GetComponent<ObjectPickupC>())
				{
					child11.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
		for (int num6 = 0; num6 < this.slot4x2x1.Length; num6++)
		{
			if (this.slot4x2x1[num6].transform.childCount > 0)
			{
				Transform child12 = this.slot4x2x1[num6].GetChild(0);
				if (child12.GetComponent<ObjectPickupC>())
				{
					child12.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
				}
			}
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0002BCE4 File Offset: 0x0002A0E4
	private void WheelIntoInventory()
	{
		if (this.tweenTransition || this.inventoryClickBlock)
		{
			return;
		}
		if (this.wheelHolder1 == null || this.wheelHolder2 == null)
		{
			return;
		}
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		float num = (float)isHolding.GetComponent<ObjectPickupC>().dimensionX;
		float num2 = (float)isHolding.GetComponent<ObjectPickupC>().dimensionY;
		float num3 = (float)isHolding.GetComponent<ObjectPickupC>().dimensionZ;
		iTween.Stop(isHolding);
		isHolding.transform.localPosition = isHolding.GetComponent<ObjectPickupC>().positionAdjust;
		if (!this.wheelHolder1Available && !this.wheelHolder2Available && !this.wheelHolder3Available && !this.wheelHolder4Available)
		{
			return;
		}
		isHolding.transform.parent = null;
		base.gameObject.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		this.tweenTransition = true;
		if (this.wheelHolder1Available)
		{
			iTween.MoveTo(isHolding, iTween.Hash(new object[]
			{
				"position",
				this.wheelHolder1.transform.position + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition,
				"time",
				0.5,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"PlaceWheel1IntoInventory",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(isHolding, iTween.Hash(new object[]
			{
				"rotation",
				this.wheelHolder1.transform.eulerAngles,
				"time",
				0.45,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo"
			}));
		}
		else if (this.wheelHolder2Available)
		{
			iTween.MoveTo(isHolding, iTween.Hash(new object[]
			{
				"position",
				this.wheelHolder2.transform.position + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition,
				"time",
				0.5,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"PlaceWheel2IntoInventory",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(isHolding, iTween.Hash(new object[]
			{
				"rotation",
				this.wheelHolder2.transform.eulerAngles,
				"time",
				0.45,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo"
			}));
		}
		else if (this.wheelHolder3Available)
		{
			iTween.MoveTo(isHolding, iTween.Hash(new object[]
			{
				"position",
				this.wheelHolder3.transform.position + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition,
				"time",
				0.5,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"PlaceWheel3IntoInventory",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(isHolding, iTween.Hash(new object[]
			{
				"rotation",
				this.wheelHolder3.transform.eulerAngles,
				"time",
				0.45,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo"
			}));
		}
		else if (this.wheelHolder4Available)
		{
			iTween.MoveTo(isHolding, iTween.Hash(new object[]
			{
				"position",
				this.wheelHolder4.transform.position + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition,
				"time",
				0.5,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"PlaceWheel4IntoInventory",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(isHolding, iTween.Hash(new object[]
			{
				"rotation",
				this.wheelHolder4.transform.eulerAngles,
				"time",
				0.45,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo"
			}));
		}
		isHolding.GetComponent<ObjectPickupC>().RandomAudio();
	}

	// Token: 0x0600031A RID: 794 RVA: 0x0002C288 File Offset: 0x0002A688
	private DragRigidbodyC RemoveFromHand(Transform holdingObject)
	{
		holdingObject.transform.localPosition = holdingObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		DragRigidbodyC component = this._camera.GetComponent<DragRigidbodyC>();
		holdingObject.gameObject.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = holdingObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		return component;
	}

	// Token: 0x0600031B RID: 795 RVA: 0x0002C308 File Offset: 0x0002A708
	private void UpdateHolderColliders(Transform holdingObject)
	{
		Collider[] components = holdingObject.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
	}

	// Token: 0x0600031C RID: 796 RVA: 0x0002C344 File Offset: 0x0002A744
	private void ModifyWeight(Transform holdingObject)
	{
		if (!this.isHomeInventory && !this.isCrateInventory)
		{
			GameObject gameObject = GameObject.FindWithTag("CarLogic");
			gameObject.GetComponent<CarPerformanceC>().carBootWeight += holdingObject.GetComponent<ObjectPickupC>().rigidMass;
			gameObject.GetComponent<CarPerformanceC>().totalCarWeight += holdingObject.GetComponent<ObjectPickupC>().rigidMass;
			gameObject.GetComponent<CarPerformanceC>().UpdateWeight();
			if (gameObject.GetComponent<CarPerformanceC>().frontLeftTyre != null)
			{
				EngineComponentC component = gameObject.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>();
				gameObject.GetComponent<CarPerformanceC>().UpdateGrip(1, component.roadGrip, component.Condition, component.durability, gameObject.GetComponent<CarPerformanceC>().frontLeftTyre, component.wetGrip, component.offRoadGrip);
			}
			if (gameObject.GetComponent<CarPerformanceC>().frontRightTyre != null)
			{
				EngineComponentC component2 = gameObject.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>();
				gameObject.GetComponent<CarPerformanceC>().UpdateGrip(2, component2.roadGrip, component2.Condition, component2.durability, gameObject.GetComponent<CarPerformanceC>().frontRightTyre, component2.wetGrip, component2.offRoadGrip);
			}
			if (gameObject.GetComponent<CarPerformanceC>().rearLeftTyre != null)
			{
				EngineComponentC component3 = gameObject.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>();
				gameObject.GetComponent<CarPerformanceC>().UpdateGrip(3, component3.roadGrip, component3.Condition, component3.durability, gameObject.GetComponent<CarPerformanceC>().rearLeftTyre, component3.wetGrip, component3.offRoadGrip);
			}
			if (gameObject.GetComponent<CarPerformanceC>().rearRightTyre != null)
			{
				EngineComponentC component4 = gameObject.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>();
				gameObject.GetComponent<CarPerformanceC>().UpdateGrip(4, component4.roadGrip, component4.Condition, component4.durability, gameObject.GetComponent<CarPerformanceC>().rearRightTyre, component4.wetGrip, component4.offRoadGrip);
			}
		}
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0002C530 File Offset: 0x0002A930
	private Transform BeginWheelPlace()
	{
		this.inventoryClickBlock = true;
		this.tweenTransition = false;
		Transform transform = this._camera.GetComponent<DragRigidbodyC>().isHolding1.transform;
		this.ModifyWeight(transform);
		return transform;
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0002C56C File Offset: 0x0002A96C
	private Transform BeginWheelPlace2()
	{
		this.inventoryClickBlock = true;
		this.tweenTransition = false;
		Transform transform = this._camera.GetComponent<DragRigidbodyC>().isHolding1.transform;
		if (!this.isHomeInventory && !this.isCrateInventory)
		{
			GameObject gameObject = GameObject.FindWithTag("CarLogic");
			gameObject.GetComponent<CarPerformanceC>().carBootWeight += transform.GetComponent<ObjectPickupC>().rigidMass;
			gameObject.GetComponent<CarPerformanceC>().totalCarWeight += transform.GetComponent<ObjectPickupC>().rigidMass;
			gameObject.GetComponent<CarPerformanceC>().UpdateWeight();
		}
		return transform;
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0002C604 File Offset: 0x0002AA04
	private void PlaceWheel1IntoInventory()
	{
		Transform transform = this.BeginWheelPlace();
		transform.transform.parent = this.wheelHolder1.transform;
		DragRigidbodyC dragRigidbodyC = this.RemoveFromHand(transform);
		this.wheelHolder1Available = false;
		this.UpdateHolderColliders(transform);
		transform.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.wheelHolder1.transform;
		dragRigidbodyC.isHolding1 = null;
		dragRigidbodyC.MoveItemsRightInventory();
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0002C670 File Offset: 0x0002AA70
	private void PlaceWheel2IntoInventory()
	{
		Transform transform = this.BeginWheelPlace();
		transform.transform.parent = this.wheelHolder2.transform;
		DragRigidbodyC dragRigidbodyC = this.RemoveFromHand(transform);
		this.wheelHolder2Available = false;
		this.UpdateHolderColliders(transform);
		transform.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.wheelHolder2.transform;
		dragRigidbodyC.isHolding1 = null;
		dragRigidbodyC.MoveItemsRightInventory();
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0002C6DC File Offset: 0x0002AADC
	private void PlaceWheel3IntoInventory()
	{
		Transform transform = this.BeginWheelPlace2();
		transform.transform.parent = this.wheelHolder3.transform;
		DragRigidbodyC dragRigidbodyC = this.RemoveFromHand(transform);
		this.wheelHolder3Available = false;
		this.UpdateHolderColliders(transform);
		transform.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.wheelHolder3.transform;
		dragRigidbodyC.isHolding1 = null;
		dragRigidbodyC.MoveItemsRightInventory();
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0002C748 File Offset: 0x0002AB48
	private void PlaceWheel4IntoInventory()
	{
		Transform transform = this.BeginWheelPlace2();
		transform.transform.parent = this.wheelHolder4.transform;
		DragRigidbodyC dragRigidbodyC = this.RemoveFromHand(transform);
		this.wheelHolder4Available = false;
		this.UpdateHolderColliders(transform);
		transform.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.wheelHolder4.transform;
		dragRigidbodyC.isHolding1 = null;
		dragRigidbodyC.MoveItemsRightInventory();
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000323 RID: 803 RVA: 0x0002C7B4 File Offset: 0x0002ABB4
	public void WheelOut(GameObject holdingObject)
	{
		if (holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt.gameObject == this.wheelHolder1)
		{
			holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = null;
			this.wheelHolder1Available = true;
		}
		else if (holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt.gameObject == this.wheelHolder2)
		{
			holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = null;
			this.wheelHolder2Available = true;
		}
		else if (holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt.gameObject == this.wheelHolder3)
		{
			holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = null;
			this.wheelHolder3Available = true;
		}
		else if (holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt.gameObject == this.wheelHolder4)
		{
			holdingObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = null;
			this.wheelHolder4Available = true;
		}
	}

	// Token: 0x06000324 RID: 804 RVA: 0x0002C89C File Offset: 0x0002AC9C
	private void Trigger()
	{
		if (this.tweenTransition || this.inventoryClickBlock)
		{
			return;
		}
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		int dimensionX = isHolding.GetComponent<ObjectPickupC>().dimensionX;
		int dimensionY = isHolding.GetComponent<ObjectPickupC>().dimensionY;
		int dimensionZ = isHolding.GetComponent<ObjectPickupC>().dimensionZ;
		iTween.Stop(isHolding);
		isHolding.transform.localPosition = isHolding.GetComponent<ObjectPickupC>().positionAdjust;
		Collider[] components = isHolding.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
		if (this.slotsAvailable == 0 || this.slotsAvailable > this.inventorySlots.Length)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			return;
		}
		if (dimensionX == 1 && dimensionY == 1 && dimensionZ == 1)
		{
			if (isHolding.GetComponent<ObjectPickupC>().objectID == 0 && isHolding.name == "CarKey")
			{
				this._camera.GetComponent<DragRigidbodyC>().PickUpError();
				return;
			}
			if (isHolding.GetComponent<ObjectPickupC>().objectID == 0 && isHolding.name == "PassportStuff")
			{
				this._camera.GetComponent<DragRigidbodyC>().PickUpError();
				return;
			}
			if (isHolding.GetComponent<ObjectPickupC>().objectID == 0 && isHolding.name == "Wallet")
			{
				this._camera.GetComponent<DragRigidbodyC>().PickUpError();
				return;
			}
			isHolding.transform.parent = null;
			isHolding.layer = LayerMask.NameToLayer("Default");
			Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				transform.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			this.tweenTransition = true;
			isHolding.transform.parent = this.nextInventorySlot.transform;
			iTween.MoveTo(isHolding, iTween.Hash(new object[]
			{
				"position",
				isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition,
				"time",
				0.25,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"Place1x1x1ObjectIntoInventory",
				"oncompleteparams",
				isHolding,
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(isHolding, iTween.Hash(new object[]
			{
				"rotation",
				isHolding.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
				"time",
				0.15,
				"islocal",
				true,
				"easetype",
				"easeinoutexpo"
			}));
			isHolding.GetComponent<ObjectPickupC>().RandomAudio();
		}
		if (isHolding.GetComponent<ExtraComponentC>() && isHolding.GetComponent<ExtraComponentC>().isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.carLogic.GetComponent<ExtraUpgradesC>().currentDecal, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlowStop();
		}
		if (dimensionX == 1 && dimensionY == 2 && dimensionZ == 1)
		{
			this.CheckSpaceFor1x2x1();
			return;
		}
		if (dimensionX == 2 && dimensionY == 2 && dimensionZ == 1)
		{
			this.CheckSpaceFor2x2x1();
			return;
		}
		if (dimensionX == 3 && dimensionY == 2 && dimensionZ == 1)
		{
			this.CheckSpaceFor3x2x1();
			return;
		}
		if (dimensionX == 2 && dimensionY == 1 && dimensionZ == 2)
		{
			this.CheckSpaceFor2x1x2();
			return;
		}
		if (dimensionX == 2 && dimensionY == 2 && dimensionZ == 2)
		{
			this.CheckSpaceFor2x2x2();
			return;
		}
		if (dimensionX == 2 && dimensionY == 2 && dimensionZ == 3)
		{
			this.CheckSpaceFor2x2x3();
			return;
		}
		if (dimensionX == 2 && dimensionY == 1 && dimensionZ == 3)
		{
			this.CheckSpaceFor2x1x3();
			return;
		}
		if (dimensionX == 3 && dimensionY == 2 && dimensionZ == 3)
		{
			this.CheckSpaceFor3x2x3();
			return;
		}
		if (dimensionX == 4 && dimensionY == 2 && dimensionZ == 2)
		{
			this.CheckSpaceFor4x2x2();
			return;
		}
		if (dimensionX == 4 && dimensionY == 2 && dimensionZ == 3)
		{
			this.CheckSpaceFor4x2x3();
			return;
		}
		if (dimensionX == 4 && dimensionY == 1 && dimensionZ == 1)
		{
			this.CheckSpaceFor4x1x1();
			return;
		}
		if (dimensionX == 4 && dimensionY == 2 && dimensionZ == 1)
		{
			this.CheckSpaceFor4x2x1();
		}
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0002CD58 File Offset: 0x0002B158
	public void InstantTrigger(GameObject targetObject = null)
	{
		if (this.tweenTransition || this.inventoryClickBlock)
		{
			return;
		}
		GameObject gameObject = (!(targetObject == null)) ? targetObject : this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		int dimensionX = gameObject.GetComponent<ObjectPickupC>().dimensionX;
		int dimensionY = gameObject.GetComponent<ObjectPickupC>().dimensionY;
		int dimensionZ = gameObject.GetComponent<ObjectPickupC>().dimensionZ;
		iTween.Stop(gameObject);
		gameObject.transform.localPosition = gameObject.GetComponent<ObjectPickupC>().positionAdjust;
		Collider[] components = gameObject.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
		if (this.slotsAvailable == 0 || this.slotsAvailable > this.inventorySlots.Length)
		{
			return;
		}
		if (dimensionX == 1 && dimensionY == 1 && dimensionZ == 1)
		{
			gameObject.transform.parent = null;
			gameObject.layer = LayerMask.NameToLayer("Default");
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				transform.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			this.tweenTransition = true;
			gameObject.transform.parent = this.nextInventorySlot.transform;
			gameObject.transform.localPosition = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
			gameObject.transform.localEulerAngles = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
			this.Place1x1x1ObjectIntoInventory(targetObject);
		}
		if (gameObject.GetComponent<ExtraComponentC>() && gameObject.GetComponent<ExtraComponentC>().isCustomDecal)
		{
			this.carLogic.GetComponent<ExtraUpgradesC>().SetDecals(this.carLogic.GetComponent<ExtraUpgradesC>().currentDecal, false);
			this.carLogic.GetComponent<ExtraUpgradesC>().DecalGlowStop();
		}
		if (dimensionX == 1 && dimensionY == 2 && dimensionZ == 1)
		{
			this.InstantCheckSpaceFor1x2x1(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 2 && dimensionY == 2 && dimensionZ == 1)
		{
			this.InstantCheckSpaceFor2x2x1(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 3 && dimensionY == 2 && dimensionZ == 1)
		{
			this.InstantCheckSpaceFor3x2x1(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 2 && dimensionY == 1 && dimensionZ == 2)
		{
			this.InstantCheckSpaceFor2x1x2(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 2 && dimensionY == 2 && dimensionZ == 2)
		{
			this.InstantCheckSpaceFor2x2x2(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 2 && dimensionY == 2 && dimensionZ == 3)
		{
			this.InstantCheckSpaceFor2x2x3(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 2 && dimensionY == 1 && dimensionZ == 3)
		{
			this.InstantCheckSpaceFor2x1x3(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 3 && dimensionY == 2 && dimensionZ == 3)
		{
			this.InstantCheckSpaceFor3x2x3(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 4 && dimensionY == 2 && dimensionZ == 2)
		{
			this.InstantCheckSpaceFor4x2x2(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 4 && dimensionY == 2 && dimensionZ == 3)
		{
			this.InstantCheckSpaceFor4x2x3(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 4 && dimensionY == 1 && dimensionZ == 1)
		{
			this.InstantCheckSpaceFor4x1x1(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
			return;
		}
		if (dimensionX == 4 && dimensionY == 2 && dimensionZ == 1)
		{
			this.InstantCheckSpaceFor4x2x1(targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1);
		}
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0002D1C0 File Offset: 0x0002B5C0
	private void ModifyBoxContents(GameObject obj2)
	{
		if (obj2.GetComponent<BoxContentsC>())
		{
			for (int i = 0; i < obj2.GetComponent<BoxContentsC>().slots.Length; i++)
			{
				if (obj2.GetComponent<BoxContentsC>().slots[i].transform.childCount > 0 && obj2.GetComponent<BoxContentsC>().slots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().isTradeGood)
				{
					obj2.GetComponent<BoxContentsC>().slots[i].transform.GetChild(0).GetComponent<ObjectPickupC>().SetPriceTag();
				}
			}
		}
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0002D264 File Offset: 0x0002B664
	public void UpdateBootPrices()
	{
		for (int i = 0; i < this.inventorySlots.Length; i++)
		{
			if (this.inventorySlots[i].GetComponent<InventoryRelayC>().isOccupied && this.inventorySlots[i].transform.childCount > 0)
			{
				Transform child = this.inventorySlots[i].transform.GetChild(0);
				if (child.GetComponent<ObjectPickupC>() && child.GetComponent<ObjectPickupC>().isTradeGood)
				{
					child.GetComponent<ObjectPickupC>().SetPriceTag();
				}
			}
		}
		for (int j = 0; j < this.slot2x1x3.Length; j++)
		{
			if (this.slot2x1x3[j].transform.childCount > 0)
			{
				Transform child2 = this.slot2x1x3[j].transform.GetChild(0);
				this.ModifyBoxContents(child2.gameObject);
			}
		}
		for (int k = 0; k < this.slot2x2x3.Length; k++)
		{
			if (this.slot2x2x3[k].transform.childCount > 0)
			{
				Transform child3 = this.slot2x2x3[k].transform.GetChild(0);
				this.ModifyBoxContents(child3.gameObject);
			}
		}
		for (int l = 0; l < this.slot4x2x3.Length; l++)
		{
			if (this.slot4x2x3[l].transform.childCount > 0)
			{
				Transform child4 = this.slot4x2x3[l].transform.GetChild(0);
				this.ModifyBoxContents(child4.gameObject);
			}
		}
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0002D3FC File Offset: 0x0002B7FC
	private void FindNext1x2x1Slot()
	{
		for (int i = 0; i < this.inventorySlots.Length; i++)
		{
			if (!this.inventorySlots[i].GetComponent<InventoryRelayC>().isOccupied && this.inventorySlots[i].GetComponent<InventoryRelayC>().spaceAbove != null && !this.inventorySlots[i].GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied)
			{
				this.nextInventorySlot = this.inventorySlots[i];
				GameObject spaceAbove = this.inventorySlots[i].GetComponent<InventoryRelayC>().spaceAbove;
				GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
				isHolding.transform.parent = null;
				isHolding.GetComponent<ObjectPickupC>().RandomAudio();
				isHolding.layer = LayerMask.NameToLayer("Default");
				Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
				foreach (Transform transform in componentsInChildren)
				{
					transform.gameObject.layer = LayerMask.NameToLayer("Default");
				}
				this.tweenTransition = true;
				isHolding.transform.parent = this.nextInventorySlot.transform;
				iTween.MoveTo(isHolding, iTween.Hash(new object[]
				{
					"position",
					isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition,
					"time",
					0.25,
					"islocal",
					true,
					"easetype",
					"easeinoutexpo",
					"oncomplete",
					"Place1x2x1ObjectIntoInventory",
					"oncompletetarget",
					base.gameObject
				}));
				iTween.RotateTo(isHolding, iTween.Hash(new object[]
				{
					"rotation",
					isHolding.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
					"time",
					0.15,
					"islocal",
					true,
					"easetype",
					"easeinoutexpo"
				}));
				this.findNextSlot = this.inventorySlots[i];
				return;
			}
		}
		this._camera.GetComponent<DragRigidbodyC>().PickUpError();
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0002D644 File Offset: 0x0002BA44
	private void PlaceNext1x2x1ObjectIntoInventory()
	{
		this.tweenTransition = false;
		GameObject spaceAbove = this.findNextSlot.GetComponent<InventoryRelayC>().spaceAbove;
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		isHolding.transform.parent = this.findNextSlot.transform;
		isHolding.transform.localPosition = isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		isHolding.transform.localEulerAngles = isHolding.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
		this.ModifyWeight(isHolding.transform);
		DragRigidbodyC component = this._camera.GetComponent<DragRigidbodyC>();
		isHolding.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		isHolding.SendMessage("IntoInventory");
		this.findNextSlot.GetComponent<InventoryRelayC>().isOccupied = true;
		spaceAbove.GetComponent<InventoryRelayC>().isOccupied = true;
		Collider[] components = isHolding.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
		isHolding.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.findNextSlot;
		this.AvailableSlotCount();
		this.UpdateInventory();
		component.isHolding1 = null;
		component.MoveItemsRightInventory();
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0002D7BC File Offset: 0x0002BBBC
	private void ModifyHolderObject(GameObject theObject)
	{
		theObject.transform.parent = null;
		theObject.GetComponent<ObjectPickupC>().RandomAudio();
		theObject.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = theObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		this.tweenTransition = true;
		theObject.transform.parent = this.nextInventorySlot.transform;
		theObject.transform.localPosition = theObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		theObject.transform.localEulerAngles = theObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
	}

	// Token: 0x0600032B RID: 811 RVA: 0x0002D870 File Offset: 0x0002BC70
	private void RotateTheWood(GameObject theObject, string onComplete = "Place1x2x1ObjectIntoInventory")
	{
		iTween.MoveTo(theObject, iTween.Hash(new object[]
		{
			"position",
			theObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition,
			"time",
			0.25,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo",
			"oncomplete",
			onComplete,
			"oncompleteparams",
			theObject,
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(theObject, iTween.Hash(new object[]
		{
			"rotation",
			theObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
			"time",
			0.15,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo"
		}));
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0002D978 File Offset: 0x0002BD78
	private void ResetNextInventorySlot()
	{
		for (int i = 0; i < this.inventorySlots.Length; i++)
		{
			if (!this.inventorySlots[i].GetComponent<InventoryRelayC>().isOccupied)
			{
				this.nextInventorySlot = this.inventorySlots[i];
				return;
			}
		}
	}

	// Token: 0x0600032D RID: 813 RVA: 0x0002D9C4 File Offset: 0x0002BDC4
	public void AvailableSlotCount()
	{
		this.slotsAvailable = this.maxSlots;
		foreach (Transform transform in this.inventorySlots)
		{
			if (transform.GetComponent<InventoryRelayC>().isOccupied)
			{
				this.slotsAvailable--;
			}
		}
	}

	// Token: 0x0600032E RID: 814 RVA: 0x0002DA1C File Offset: 0x0002BE1C
	public void UpdateInventory()
	{
		foreach (Transform transform in this.inventorySlots)
		{
			if (!transform.GetComponent<InventoryRelayC>().isOccupied)
			{
				this.nextInventorySlot = transform;
				return;
			}
		}
	}

	// Token: 0x0600032F RID: 815 RVA: 0x0002DA60 File Offset: 0x0002BE60
	private void RaycastEnter()
	{
		if (!this.isGlowing)
		{
			this.isGlowing = true;
			this.glowTarget1.GetComponent<Renderer>().material = this.glowMaterial;
			if (this.glowTarget2)
			{
				this.glowTarget2.GetComponent<Renderer>().material = this.glowMaterial;
			}
		}
	}

	// Token: 0x06000330 RID: 816 RVA: 0x0002DABC File Offset: 0x0002BEBC
	private void RaycastExit()
	{
		if (this.isGlowing)
		{
			this.isGlowing = false;
			this.glowTarget1.GetComponent<Renderer>().material = this.startMaterial;
			if (this.glowTarget2)
			{
				this.glowTarget2.GetComponent<Renderer>().material = this.startMaterial;
			}
		}
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0002DB18 File Offset: 0x0002BF18
	private bool IsOccupied(GameObject[] checkObjects)
	{
		for (int i = 0; i < checkObjects.Length; i++)
		{
			if (checkObjects[i].GetComponent<InventoryRelayC>().isOccupied)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0002DB50 File Offset: 0x0002BF50
	private int CheckHelper(Transform[] slotCheck, int count, string onComplete = "Place4x2x3ObjectIntoInventory")
	{
		int num = 0;
		for (int i = 0; i < slotCheck.Length; i++)
		{
			num = i;
			GameObject[] array = new GameObject[count];
			for (int j = 0; j < count; j++)
			{
				array[j] = slotCheck[i].gameObject.GetComponent<InventoryRelayC>().slots[j];
			}
			GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
			if (!this.IsOccupied(array))
			{
				isHolding.transform.parent = null;
				isHolding.GetComponent<ObjectPickupC>().RandomAudio();
				this.tweenTransition = true;
				isHolding.transform.parent = slotCheck[num].transform;
				this.RotateTheWood(isHolding, onComplete);
				return num;
			}
		}
		return num;
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0002DC04 File Offset: 0x0002C004
	private int InstantCheckHelper(Transform[] slotCheck, int count, ref bool doIt, GameObject targetObject)
	{
		int num = 0;
		for (int i = 0; i < slotCheck.Length; i++)
		{
			num = i;
			GameObject[] array = new GameObject[count];
			for (int j = 0; j < count; j++)
			{
				array[j] = slotCheck[i].gameObject.GetComponent<InventoryRelayC>().slots[j];
			}
			if (!this.IsOccupied(array))
			{
				targetObject.transform.parent = null;
				targetObject.GetComponent<ObjectPickupC>().RandomAudio();
				this.tweenTransition = true;
				targetObject.transform.parent = slotCheck[num].transform;
				targetObject.transform.localPosition = targetObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
				targetObject.transform.localEulerAngles = targetObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
				doIt = true;
				return num;
			}
		}
		return num;
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0002DCD4 File Offset: 0x0002C0D4
	private void CheckSpaceFor1x2x1()
	{
		this.inventoryClickBlock = true;
		GameObject spaceAbove = this.nextInventorySlot.GetComponent<InventoryRelayC>().spaceAbove;
		if (spaceAbove == null)
		{
			base.StartCoroutine("FindNext1x2x1Slot");
			return;
		}
		if (spaceAbove.GetComponent<InventoryRelayC>().isOccupied)
		{
			base.StartCoroutine("FindNext1x2x1Slot");
			return;
		}
		if (!spaceAbove.GetComponent<InventoryRelayC>().isOccupied && !this.nextInventorySlot.GetComponent<InventoryRelayC>().isOccupied)
		{
			GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
			isHolding.transform.parent = null;
			isHolding.GetComponent<ObjectPickupC>().RandomAudio();
			isHolding.layer = LayerMask.NameToLayer("Default");
			Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				transform.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			this.tweenTransition = true;
			isHolding.transform.parent = this.nextInventorySlot.transform;
			this.RotateTheWood(isHolding, "Place1x2x1ObjectIntoInventory");
			return;
		}
		this._camera.GetComponent<DragRigidbodyC>().PickUpError();
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000335 RID: 821 RVA: 0x0002DE0C File Offset: 0x0002C20C
	private void CheckSpaceFor4x2x2()
	{
		this.inventoryClickBlock = true;
		if (this.slot4x2x2.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target4x2x2 = this.CheckHelper(this.slot4x2x2, 16, "Place4x2x2ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000336 RID: 822 RVA: 0x0002DE68 File Offset: 0x0002C268
	private void CheckSpaceFor3x2x3()
	{
		this.inventoryClickBlock = true;
		if (this.slot3x2x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target3x2x3 = this.CheckHelper(this.slot3x2x3, 18, "Place3x2x3ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0002DEC4 File Offset: 0x0002C2C4
	private void CheckSpaceFor4x2x1()
	{
		this.inventoryClickBlock = true;
		if (this.slot4x2x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target4x2x1 = this.CheckHelper(this.slot4x2x1, 8, "Place4x2x1ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0002DF1C File Offset: 0x0002C31C
	private void CheckSpaceFor4x2x3()
	{
		this.inventoryClickBlock = true;
		if (this.slot4x2x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target4x2x3 = this.CheckHelper(this.slot4x2x3, 24, "Place4x2x3ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x0002DF78 File Offset: 0x0002C378
	private void CheckSpaceFor2x2x3()
	{
		this.inventoryClickBlock = true;
		if (this.slot2x2x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target2x2x3 = this.CheckHelper(this.slot2x2x3, 12, "Place2x2x3ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0002DFD4 File Offset: 0x0002C3D4
	private void CheckSpaceFor2x1x3()
	{
		this.inventoryClickBlock = true;
		if (this.slot2x1x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target2x1x3 = this.CheckHelper(this.slot2x1x3, 6, "Place2x1x3ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0002E02C File Offset: 0x0002C42C
	private void CheckSpaceFor3x2x1()
	{
		this.inventoryClickBlock = true;
		if (this.slot3x2x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target3x2x1 = this.CheckHelper(this.slot3x2x1, 6, "Place3x2x1ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600033C RID: 828 RVA: 0x0002E084 File Offset: 0x0002C484
	private void CheckSpaceFor2x2x1()
	{
		this.inventoryClickBlock = true;
		if (this.slot2x2x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target2x2x1 = this.CheckHelper(this.slot2x2x1, 4, "Place2x2x1ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600033D RID: 829 RVA: 0x0002E0DC File Offset: 0x0002C4DC
	private void CheckSpaceFor2x1x2()
	{
		this.inventoryClickBlock = true;
		if (this.slot2x1x2.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target2x1x2 = this.CheckHelper(this.slot2x1x2, 4, "Place2x1x2ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600033E RID: 830 RVA: 0x0002E134 File Offset: 0x0002C534
	private void CheckSpaceFor4x1x1()
	{
		this.inventoryClickBlock = true;
		if (this.slot4x1x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target4x1x1 = this.CheckHelper(this.slot4x1x1, 4, "Place4x1x1ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600033F RID: 831 RVA: 0x0002E18C File Offset: 0x0002C58C
	private void CheckSpaceFor2x2x2()
	{
		this.inventoryClickBlock = true;
		if (this.slot2x2x2.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		this.target2x2x2 = this.CheckHelper(this.slot2x2x2, 8, "Place2x2x2ObjectIntoInventory");
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0002E1E4 File Offset: 0x0002C5E4
	private void InstantCheckSpaceFor1x2x1(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		GameObject spaceAbove = this.nextInventorySlot.GetComponent<InventoryRelayC>().spaceAbove;
		if (spaceAbove == null)
		{
			base.StartCoroutine("FindNext1x2x1Slot");
			Debug.Log("Checking for next inventory slot that isn't a space above");
			return;
		}
		if (spaceAbove.GetComponent<InventoryRelayC>().isOccupied)
		{
			base.StartCoroutine("FindNext1x2x1Slot");
			Debug.Log("Checking for next inventory slot that isn't a space above");
			return;
		}
		if (!spaceAbove.GetComponent<InventoryRelayC>().isOccupied && !this.nextInventorySlot.GetComponent<InventoryRelayC>().isOccupied)
		{
			this.ModifyHolderObject(targetObject);
			this.Place1x2x1ObjectIntoInventory(targetObject);
		}
		else
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0002E2A4 File Offset: 0x0002C6A4
	private void InstantCheckSpaceFor4x2x2(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot4x2x2.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target4x2x2 = this.InstantCheckHelper(this.slot4x2x2, 16, ref flag, targetObject);
		if (flag)
		{
			this.Place4x2x2ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0002E30C File Offset: 0x0002C70C
	private void InstantCheckSpaceFor3x2x3(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot3x2x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target3x2x3 = this.InstantCheckHelper(this.slot3x2x3, 18, ref flag, targetObject);
		if (flag)
		{
			this.Place3x2x3ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000343 RID: 835 RVA: 0x0002E374 File Offset: 0x0002C774
	private void InstantCheckSpaceFor4x2x1(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot4x2x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target4x2x1 = this.InstantCheckHelper(this.slot4x2x1, 8, ref flag, targetObject);
		if (flag)
		{
			this.Place4x2x1ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000344 RID: 836 RVA: 0x0002E3D8 File Offset: 0x0002C7D8
	private void InstantCheckSpaceFor4x2x3(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot4x2x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target4x2x3 = this.InstantCheckHelper(this.slot4x2x3, 24, ref flag, targetObject);
		if (flag)
		{
			this.Place4x2x3ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000345 RID: 837 RVA: 0x0002E440 File Offset: 0x0002C840
	private void InstantCheckSpaceFor2x2x3(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot2x2x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target2x2x3 = this.InstantCheckHelper(this.slot2x2x3, 12, ref flag, targetObject);
		if (flag)
		{
			this.Place2x2x3ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000346 RID: 838 RVA: 0x0002E4A8 File Offset: 0x0002C8A8
	private void InstantCheckSpaceFor2x1x3(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot2x1x3.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target2x1x3 = this.InstantCheckHelper(this.slot2x1x3, 6, ref flag, targetObject);
		if (flag)
		{
			this.Place2x1x3ObjectIntoInventory();
			GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
			if (isHolding.GetComponent<ExtraComponentC>() && isHolding.GetComponent<ExtraComponentC>().isCustomDecal)
			{
				GameObject gameObject = GameObject.FindWithTag("CarLogic");
				gameObject.GetComponent<ExtraUpgradesC>().SetDecals(isHolding.GetComponent<ExtraComponentC>().noDecalMaterial, false);
				gameObject.GetComponent<ExtraUpgradesC>().DecalGlowStop();
			}
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000347 RID: 839 RVA: 0x0002E56C File Offset: 0x0002C96C
	private void InstantCheckSpaceFor3x2x1(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot3x2x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target3x2x1 = this.InstantCheckHelper(this.slot3x2x1, 6, ref flag, targetObject);
		if (flag)
		{
			this.Place3x2x1ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0002E5D0 File Offset: 0x0002C9D0
	private void InstantCheckSpaceFor2x2x1(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot2x2x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target2x2x1 = this.InstantCheckHelper(this.slot2x2x1, 4, ref flag, targetObject);
		if (flag)
		{
			this.Place2x2x1ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0002E634 File Offset: 0x0002CA34
	private void InstantCheckSpaceFor2x1x2(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot2x1x2.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target2x1x2 = this.InstantCheckHelper(this.slot2x1x2, 4, ref flag, targetObject);
		if (flag)
		{
			this.Place2x1x2ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600034A RID: 842 RVA: 0x0002E698 File Offset: 0x0002CA98
	private void InstantCheckSpaceFor4x1x1(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot4x1x1.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target4x1x1 = this.InstantCheckHelper(this.slot4x1x1, 4, ref flag, targetObject);
		if (flag)
		{
			this.Place4x1x1ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600034B RID: 843 RVA: 0x0002E6FC File Offset: 0x0002CAFC
	private void InstantCheckSpaceFor2x2x2(GameObject targetObject)
	{
		this.inventoryClickBlock = true;
		if (this.slot2x2x2.Length == 0)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this.inventoryClickBlock = false;
			return;
		}
		bool flag = false;
		this.target2x2x2 = this.InstantCheckHelper(this.slot2x2x2, 8, ref flag, targetObject);
		if (flag)
		{
			this.Place2x2x2ObjectIntoInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600034C RID: 844 RVA: 0x0002E760 File Offset: 0x0002CB60
	private void OccupySlots(ref GameObject[] objects)
	{
		for (int i = 0; i < objects.Length; i++)
		{
			objects[i].GetComponent<InventoryRelayC>().isOccupied = true;
		}
	}

	// Token: 0x0600034D RID: 845 RVA: 0x0002E794 File Offset: 0x0002CB94
	private GameObject[] ReturnSlots(Transform[] slots, int target, int count)
	{
		GameObject[] array = new GameObject[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = slots[target].gameObject.GetComponent<InventoryRelayC>().slots[i];
		}
		return array;
	}

	// Token: 0x0600034E RID: 846 RVA: 0x0002E7D4 File Offset: 0x0002CBD4
	private GameObject BeginPlacing(Transform[] slots, int target)
	{
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		GameObject gameObject = isHolding;
		this.ModifyWeight(isHolding.transform);
		gameObject.transform.parent = slots[target].transform;
		gameObject.transform.localPosition = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		gameObject.transform.localEulerAngles = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
		this.tweenTransition = false;
		isHolding.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		gameObject.SendMessage("IntoInventory");
		Collider[] components = isHolding.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
		isHolding.GetComponent<ObjectPickupC>().inventoryPlacedAt = slots[target];
		return isHolding;
	}

	// Token: 0x0600034F RID: 847 RVA: 0x0002E8EC File Offset: 0x0002CCEC
	private void PlaceInInventory(Transform[] slots, int target, int count)
	{
		GameObject gameObject = this.BeginPlacing(slots, target);
		DragRigidbodyC component = this._camera.GetComponent<DragRigidbodyC>();
		GameObject[] array = this.ReturnSlots(slots, target, count);
		this.OccupySlots(ref array);
		this.AvailableSlotCount();
		this.UpdateInventory();
		component.isHolding1 = null;
		component.MoveItemsRightInventory();
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0002E940 File Offset: 0x0002CD40
	private void Place1x1x1ObjectIntoInventory(GameObject targetObject = null)
	{
		this.tweenTransition = false;
		Transform transform = (!targetObject) ? this.BeginWheelPlace() : targetObject.transform;
		transform.transform.parent = this.nextInventorySlot.transform;
		transform.transform.localPosition = transform.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		transform.transform.localEulerAngles = transform.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
		DragRigidbodyC dragRigidbodyC = (!this._camera) ? null : this.RemoveFromHand(transform.transform);
		this.nextInventorySlot.GetComponent<InventoryRelayC>().isOccupied = true;
		this.UpdateHolderColliders(transform.transform);
		transform.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.nextInventorySlot;
		this.AvailableSlotCount();
		this.UpdateInventory();
		if (dragRigidbodyC)
		{
			dragRigidbodyC.isHolding1 = null;
			dragRigidbodyC.MoveItemsRightInventory();
		}
		this.inventoryClickBlock = false;
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0002EA30 File Offset: 0x0002CE30
	private void Place1x2x1ObjectIntoInventory(GameObject targetObject = null)
	{
		this.tweenTransition = false;
		GameObject spaceAbove = this.nextInventorySlot.GetComponent<InventoryRelayC>().spaceAbove;
		GameObject gameObject = targetObject ?? this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		gameObject.transform.parent = this.nextInventorySlot.transform;
		gameObject.transform.localPosition = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		gameObject.transform.localEulerAngles = gameObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
		this.ModifyWeight(gameObject.transform);
		DragRigidbodyC dragRigidbodyC = (!this._camera) ? null : this._camera.GetComponent<DragRigidbodyC>();
		gameObject.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		gameObject.SendMessage("IntoInventory");
		this.nextInventorySlot.GetComponent<InventoryRelayC>().isOccupied = true;
		spaceAbove.GetComponent<InventoryRelayC>().isOccupied = true;
		Collider[] components = gameObject.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
		gameObject.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.nextInventorySlot;
		this.AvailableSlotCount();
		this.UpdateInventory();
		if (dragRigidbodyC)
		{
			dragRigidbodyC.isHolding1 = null;
			dragRigidbodyC.MoveItemsRightInventory();
		}
		this.inventoryClickBlock = false;
		this.ResetNextInventorySlot();
	}

	// Token: 0x06000352 RID: 850 RVA: 0x0002EBD4 File Offset: 0x0002CFD4
	private void Place3x2x3ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot3x2x3, this.target3x2x3, 18);
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0002EBEA File Offset: 0x0002CFEA
	private void Place4x2x2ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot4x2x2, this.target4x2x2, 16);
	}

	// Token: 0x06000354 RID: 852 RVA: 0x0002EC00 File Offset: 0x0002D000
	private void Place4x2x1ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot4x2x1, this.target4x2x1, 8);
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0002EC15 File Offset: 0x0002D015
	private void Place4x2x3ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot4x2x3, this.target4x2x3, 24);
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0002EC2B File Offset: 0x0002D02B
	private void Place2x2x3ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot2x2x3, this.target2x2x3, 12);
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0002EC41 File Offset: 0x0002D041
	private void Place2x1x3ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot2x1x3, this.target2x1x3, 6);
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0002EC56 File Offset: 0x0002D056
	private void Place3x2x1ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot3x2x1, this.target3x2x1, 4);
	}

	// Token: 0x06000359 RID: 857 RVA: 0x0002EC6B File Offset: 0x0002D06B
	private void Place2x2x1ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot2x2x1, this.target2x2x1, 4);
	}

	// Token: 0x0600035A RID: 858 RVA: 0x0002EC80 File Offset: 0x0002D080
	private void Place2x1x2ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot2x1x2, this.target2x1x2, 4);
	}

	// Token: 0x0600035B RID: 859 RVA: 0x0002EC95 File Offset: 0x0002D095
	private void Place4x1x1ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot4x1x1, this.target4x1x1, 4);
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0002ECAA File Offset: 0x0002D0AA
	private void Place2x2x2ObjectIntoInventory()
	{
		this.PlaceInInventory(this.slot2x2x2, this.target2x2x2, 8);
	}

	// Token: 0x0600035D RID: 861 RVA: 0x0002ECC0 File Offset: 0x0002D0C0
	private void Place2x2x2ObjectIntoInventory1(int ID = 0)
	{
		this.tweenTransition = false;
		GameObject spaceAbove = this.nextInventorySlot.GetComponent<InventoryRelayC>().spaceAbove;
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		this.ModifyWeight(isHolding.transform);
		isHolding.transform.parent = this.slot2x2x2[ID];
		isHolding.transform.position = this.slot2x2x2[ID].transform.position + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		isHolding.transform.eulerAngles = base.transform.parent.eulerAngles + isHolding.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
		DragRigidbodyC component = this._camera.GetComponent<DragRigidbodyC>();
		isHolding.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		isHolding.SendMessage("IntoInventory");
		GameObject[] array2 = this.ReturnSlots(this.slot2x2x2, ID, 8);
		this.OccupySlots(ref array2);
		Collider[] components = isHolding.GetComponents<Collider>();
		foreach (Collider collider in components)
		{
			collider.isTrigger = true;
			collider.enabled = true;
		}
		isHolding.GetComponent<ObjectPickupC>().inventoryPlacedAt = this.slot2x2x2[ID].gameObject.transform;
		this.AvailableSlotCount();
		this.UpdateInventory();
		component.isHolding1 = null;
		component.MoveItemsRightInventory();
		this.inventoryClickBlock = false;
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0002EE65 File Offset: 0x0002D265
	private void Place2x2x2ObjectIntoInventory2()
	{
		this.Place2x2x2ObjectIntoInventory1(1);
	}

	// Token: 0x0400049F RID: 1183
	private GameObject _camera;

	// Token: 0x040004A0 RID: 1184
	public GameObject glowTarget1;

	// Token: 0x040004A1 RID: 1185
	public GameObject glowTarget2;

	// Token: 0x040004A2 RID: 1186
	public Transform nextInventorySlot;

	// Token: 0x040004A3 RID: 1187
	private Transform findNextSlot;

	// Token: 0x040004A4 RID: 1188
	public int slotsAvailable = 12;

	// Token: 0x040004A5 RID: 1189
	public Transform[] inventorySlots;

	// Token: 0x040004A6 RID: 1190
	public GameObject wheelHolder1;

	// Token: 0x040004A7 RID: 1191
	public GameObject wheelHolder2;

	// Token: 0x040004A8 RID: 1192
	public GameObject wheelHolder3;

	// Token: 0x040004A9 RID: 1193
	public GameObject wheelHolder4;

	// Token: 0x040004AA RID: 1194
	public bool wheelHolder1Available;

	// Token: 0x040004AB RID: 1195
	public bool wheelHolder2Available = true;

	// Token: 0x040004AC RID: 1196
	public bool wheelHolder3Available;

	// Token: 0x040004AD RID: 1197
	public bool wheelHolder4Available;

	// Token: 0x040004AE RID: 1198
	public int maxSlots = 12;

	// Token: 0x040004AF RID: 1199
	public Material glowMaterial;

	// Token: 0x040004B0 RID: 1200
	public Material startMaterial;

	// Token: 0x040004B1 RID: 1201
	public bool isGlowing;

	// Token: 0x040004B2 RID: 1202
	public Transform[] slot3x2x1;

	// Token: 0x040004B3 RID: 1203
	public int target3x2x1;

	// Token: 0x040004B4 RID: 1204
	public Transform[] slot2x2x1;

	// Token: 0x040004B5 RID: 1205
	public int target2x2x1;

	// Token: 0x040004B6 RID: 1206
	public Transform[] slot2x1x2;

	// Token: 0x040004B7 RID: 1207
	public int target2x1x2;

	// Token: 0x040004B8 RID: 1208
	public Transform[] slot2x2x2;

	// Token: 0x040004B9 RID: 1209
	public int target2x2x2;

	// Token: 0x040004BA RID: 1210
	public Transform[] slot2x2x3;

	// Token: 0x040004BB RID: 1211
	public int target2x2x3;

	// Token: 0x040004BC RID: 1212
	public Transform[] slot3x2x3;

	// Token: 0x040004BD RID: 1213
	public int target3x2x3;

	// Token: 0x040004BE RID: 1214
	public Transform[] slot4x2x2;

	// Token: 0x040004BF RID: 1215
	public int target4x2x2;

	// Token: 0x040004C0 RID: 1216
	public Transform[] slot4x2x3;

	// Token: 0x040004C1 RID: 1217
	public int target4x2x3;

	// Token: 0x040004C2 RID: 1218
	public Transform[] slot4x1x1;

	// Token: 0x040004C3 RID: 1219
	public int target4x1x1;

	// Token: 0x040004C4 RID: 1220
	public Transform[] slot4x2x1;

	// Token: 0x040004C5 RID: 1221
	public int target4x2x1;

	// Token: 0x040004C6 RID: 1222
	public Transform[] slot2x1x3;

	// Token: 0x040004C7 RID: 1223
	public int target2x1x3;

	// Token: 0x040004C8 RID: 1224
	private bool inventoryClickBlock;

	// Token: 0x040004C9 RID: 1225
	private bool tweenTransition;

	// Token: 0x040004CA RID: 1226
	public bool isHomeInventory;

	// Token: 0x040004CB RID: 1227
	public bool isCrateInventory;

	// Token: 0x040004CC RID: 1228
	public CarLogicC carLogic;
}
