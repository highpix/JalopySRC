using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
[AddComponentMenu("NGUI/Examples/UI Storage Slot")]
public class UIStorageSlot : UIItemSlot
{
	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600016E RID: 366 RVA: 0x00017153 File Offset: 0x00015553
	protected override InvGameItem observedItem
	{
		get
		{
			return (!(this.storage != null)) ? null : this.storage.GetItem(this.slot);
		}
	}

	// Token: 0x0600016F RID: 367 RVA: 0x0001717D File Offset: 0x0001557D
	protected override InvGameItem Replace(InvGameItem item)
	{
		return (!(this.storage != null)) ? item : this.storage.Replace(this.slot, item);
	}

	// Token: 0x04000289 RID: 649
	public UIItemStorage storage;

	// Token: 0x0400028A RID: 650
	public int slot;
}
