using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
[AddComponentMenu("NGUI/Examples/UI Equipment Slot")]
public class UIEquipmentSlot : UIItemSlot
{
	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600015D RID: 349 RVA: 0x00016EB0 File Offset: 0x000152B0
	protected override InvGameItem observedItem
	{
		get
		{
			return (!(this.equipment != null)) ? null : this.equipment.GetItem(this.slot);
		}
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00016EDA File Offset: 0x000152DA
	protected override InvGameItem Replace(InvGameItem item)
	{
		return (!(this.equipment != null)) ? item : this.equipment.Replace(this.slot, item);
	}

	// Token: 0x04000276 RID: 630
	public InvEquipment equipment;

	// Token: 0x04000277 RID: 631
	public InvBaseItem.Slot slot;
}
