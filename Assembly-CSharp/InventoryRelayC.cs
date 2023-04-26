using System;
using UnityEngine;

// Token: 0x020000BB RID: 187
public class InventoryRelayC : MonoBehaviour
{
	// Token: 0x060006CD RID: 1741 RVA: 0x00088FF4 File Offset: 0x000873F4
	public void Reset()
	{
		InventoryRelay component = base.GetComponent<InventoryRelay>();
		this.spaceAbove = component.spaceAbove;
		this.inventoryBase = component.inventoryBase;
		this.isOccupied = component.isOccupied;
		this.horizontalSpace = new GameObject[component.horizontalSpace.Length];
		for (int i = 0; i < this.horizontalSpace.Length; i++)
		{
			this.horizontalSpace[i] = component.horizontalSpace[i];
		}
		this.slots = new GameObject[component.slots.Length];
		for (int j = 0; j < this.slots.Length; j++)
		{
			this.slots[j] = component.slots[j];
		}
		component.enabled = false;
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x000890AC File Offset: 0x000874AC
	[ContextMenu("Unoccupy")]
	public void UnOccupy()
	{
		foreach (GameObject gameObject in this.slots)
		{
			gameObject.GetComponent<InventoryRelayC>().isOccupied = false;
		}
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x000890E4 File Offset: 0x000874E4
	[ContextMenu("Occupy")]
	public void Occupy()
	{
		foreach (GameObject gameObject in this.slots)
		{
			gameObject.GetComponent<InventoryRelayC>().isOccupied = true;
		}
	}

	// Token: 0x04000947 RID: 2375
	public bool isOccupied;

	// Token: 0x04000948 RID: 2376
	public GameObject spaceAbove;

	// Token: 0x04000949 RID: 2377
	public GameObject[] horizontalSpace = new GameObject[0];

	// Token: 0x0400094A RID: 2378
	public GameObject[] slots = new GameObject[0];

	// Token: 0x0400094B RID: 2379
	public GameObject inventoryBase;
}
