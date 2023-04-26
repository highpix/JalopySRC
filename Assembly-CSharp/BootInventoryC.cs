using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
public class BootInventoryC : MonoBehaviour
{
	// Token: 0x06000450 RID: 1104 RVA: 0x00048FC1 File Offset: 0x000473C1
	private void Start()
	{
		this.startMaterial = base.GetComponent<Renderer>().material;
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x00048FE4 File Offset: 0x000473E4
	private void CheckObject(GameObject theObject, string placement)
	{
		theObject.transform.parent = null;
		theObject.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = theObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		this.tweenTransition = true;
		iTween.MoveTo(theObject, iTween.Hash(new object[]
		{
			"path",
			this.sleepingBag2Loc.transform.position + new Vector3(0f, 0.5f, 0f),
			this.sleepingBag2Loc.transform.position,
			"time",
			0.5,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo",
			"oncomplete",
			placement,
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(theObject, iTween.Hash(new object[]
		{
			"rotation",
			this.sleepingBag2Loc.transform.eulerAngles + theObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
			"time",
			0.45,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x00049184 File Offset: 0x00047584
	public void Trigger()
	{
		if (this.tweenTransition)
		{
			return;
		}
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		int dimensionX = isHolding.GetComponent<ObjectPickupC>().dimensionX;
		int dimensionY = isHolding.GetComponent<ObjectPickupC>().dimensionY;
		int dimensionZ = isHolding.GetComponent<ObjectPickupC>().dimensionZ;
		if (isHolding.name == this.sleepingBag2Name && !this.sleepingBag2Occupied)
		{
			this.CheckObject(isHolding, "PlaceSleepingBag2");
		}
		if (isHolding.name == this.suitcase1Name && !this.suitcase1Occupied)
		{
			this.CheckObject(isHolding, "PlaceSuitCase1");
		}
		if (isHolding.name == this.suitcase2Name && !this.suitcase2Occupied)
		{
			this.CheckObject(isHolding, "PlaceSuitCase2");
		}
		if (isHolding.name == this.foodBasketName && !this.foodBasketOccupied)
		{
			this.CheckObject(isHolding, "PlaceFoodBasket");
		}
		if (isHolding.name == this.crowbarName && !this.crowbarOccupied)
		{
			this.CheckObject(isHolding, "PlacedCrowbar");
		}
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x000492B4 File Offset: 0x000476B4
	private void PlaceItem()
	{
		this.tweenTransition = false;
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		isHolding.GetComponent<ObjectPickupC>().bootPlacedAt = base.gameObject.transform;
		isHolding.transform.parent = this.sleepingBag1Loc.transform;
		isHolding.transform.localScale = Vector3.one;
		isHolding.transform.localPosition = isHolding.GetComponent<ObjectPickupC>().inventoryAdjustPosition;
		isHolding.transform.localEulerAngles = isHolding.GetComponent<ObjectPickupC>().inventoryAdjustRotation;
		DragRigidbodyC component = this._camera.GetComponent<DragRigidbodyC>();
		isHolding.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = isHolding.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		component.isHolding1 = null;
		component.MoveItemsRightInventory();
		isHolding.GetComponent<Collider>().enabled = true;
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x000493B4 File Offset: 0x000477B4
	private void PlaceSleepingBag(int ID)
	{
		this.PlaceItem();
		if (ID == 0)
		{
			this.sleepingBag1Occupied = true;
		}
		else
		{
			this.sleepingBag2Occupied = true;
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x000493D5 File Offset: 0x000477D5
	public void PlaceSleepingBag1()
	{
		this.PlaceSleepingBag(0);
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x000493DE File Offset: 0x000477DE
	public void PlaceSleepingBag2()
	{
		this.PlaceSleepingBag(1);
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x000493E7 File Offset: 0x000477E7
	private void PlaceSuitCase(int ID)
	{
		this.PlaceItem();
		if (ID == 0)
		{
			this.suitcase1Occupied = true;
		}
		else
		{
			this.suitcase2Occupied = true;
		}
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x00049408 File Offset: 0x00047808
	public void PlaceSuitCase1()
	{
		this.PlaceSuitCase(0);
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x00049411 File Offset: 0x00047811
	public void PlaceSuitCase2()
	{
		this.PlaceSuitCase(1);
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x0004941A File Offset: 0x0004781A
	public void PlaceFoodBasket()
	{
		this.PlaceItem();
		this.foodBasketOccupied = true;
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x00049429 File Offset: 0x00047829
	public void PlacedCrowbar()
	{
		this.PlaceItem();
		this.crowbarOccupied = true;
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x00049438 File Offset: 0x00047838
	private void RemoveFromBoot(GameObject holdingObject)
	{
		if (holdingObject.transform.name == this.sleepingBag1Name && this.sleepingBag1Occupied)
		{
			Debug.Log("sleeping bag 1 now free");
			this.sleepingBag1Occupied = false;
		}
		if (holdingObject.transform.name == this.sleepingBag2Name && this.sleepingBag2Occupied)
		{
			Debug.Log("sleeping bag 2 now free");
			this.sleepingBag2Occupied = false;
		}
		if (holdingObject.transform.name == this.suitcase1Name && this.suitcase1Occupied)
		{
			Debug.Log("Suitcase now free");
			this.suitcase1Occupied = false;
		}
		if (holdingObject.transform.name == this.suitcase2Name && this.suitcase2Occupied)
		{
			Debug.Log("Suitcase 2 now free");
			this.suitcase2Occupied = false;
		}
		if (holdingObject.transform.name == this.foodBasketName && this.foodBasketOccupied)
		{
			Debug.Log("Food Basket is now free");
			this.foodBasketOccupied = false;
		}
		if (holdingObject.transform.name == this.crowbarName && this.crowbarOccupied)
		{
			Debug.Log("Crowbar is now free");
			this.crowbarOccupied = false;
		}
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x00049590 File Offset: 0x00047990
	public void RemoveFromBootSlot1()
	{
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		this.RemoveFromBoot(isHolding);
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x000495B8 File Offset: 0x000479B8
	public void RemoveFromBootSlot2()
	{
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding2;
		this.RemoveFromBoot(isHolding);
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x000495E0 File Offset: 0x000479E0
	public void RemoveFromBootSlot3()
	{
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding3;
		this.RemoveFromBoot(isHolding);
	}

	// Token: 0x04000656 RID: 1622
	private GameObject _camera;

	// Token: 0x04000657 RID: 1623
	public GameObject sleepingBag1Loc;

	// Token: 0x04000658 RID: 1624
	public string sleepingBag1Name = string.Empty;

	// Token: 0x04000659 RID: 1625
	[HideInInspector]
	public bool sleepingBag1Occupied;

	// Token: 0x0400065A RID: 1626
	public GameObject sleepingBag2Loc;

	// Token: 0x0400065B RID: 1627
	public string sleepingBag2Name = string.Empty;

	// Token: 0x0400065C RID: 1628
	[HideInInspector]
	public bool sleepingBag2Occupied;

	// Token: 0x0400065D RID: 1629
	public GameObject suitcase1Loc;

	// Token: 0x0400065E RID: 1630
	public string suitcase1Name = string.Empty;

	// Token: 0x0400065F RID: 1631
	[HideInInspector]
	public bool suitcase1Occupied;

	// Token: 0x04000660 RID: 1632
	public GameObject suitcase2Loc;

	// Token: 0x04000661 RID: 1633
	public string suitcase2Name = string.Empty;

	// Token: 0x04000662 RID: 1634
	[HideInInspector]
	public bool suitcase2Occupied;

	// Token: 0x04000663 RID: 1635
	public GameObject foodBasketLoc;

	// Token: 0x04000664 RID: 1636
	public string foodBasketName = string.Empty;

	// Token: 0x04000665 RID: 1637
	[HideInInspector]
	public bool foodBasketOccupied;

	// Token: 0x04000666 RID: 1638
	public GameObject crowbarLoc;

	// Token: 0x04000667 RID: 1639
	public string crowbarName = string.Empty;

	// Token: 0x04000668 RID: 1640
	[HideInInspector]
	public bool crowbarOccupied;

	// Token: 0x04000669 RID: 1641
	public Material startMaterial;

	// Token: 0x0400066A RID: 1642
	public Material glowMaterial;

	// Token: 0x0400066B RID: 1643
	private bool isGlowing;

	// Token: 0x0400066C RID: 1644
	private bool tweenTransition;
}
