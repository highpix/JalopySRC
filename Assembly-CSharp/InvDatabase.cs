using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004B RID: 75
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Item Database")]
public class InvDatabase : MonoBehaviour
{
	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000174 RID: 372 RVA: 0x000172AB File Offset: 0x000156AB
	public static InvDatabase[] list
	{
		get
		{
			if (InvDatabase.mIsDirty)
			{
				InvDatabase.mIsDirty = false;
				InvDatabase.mList = NGUITools.FindActive<InvDatabase>();
			}
			return InvDatabase.mList;
		}
	}

	// Token: 0x06000175 RID: 373 RVA: 0x000172CC File Offset: 0x000156CC
	private void OnEnable()
	{
		InvDatabase.mIsDirty = true;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x000172D4 File Offset: 0x000156D4
	private void OnDisable()
	{
		InvDatabase.mIsDirty = true;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x000172DC File Offset: 0x000156DC
	private InvBaseItem GetItem(int id16)
	{
		int i = 0;
		int count = this.items.Count;
		while (i < count)
		{
			InvBaseItem invBaseItem = this.items[i];
			if (invBaseItem.id16 == id16)
			{
				return invBaseItem;
			}
			i++;
		}
		return null;
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00017324 File Offset: 0x00015724
	private static InvDatabase GetDatabase(int dbID)
	{
		int i = 0;
		int num = InvDatabase.list.Length;
		while (i < num)
		{
			InvDatabase invDatabase = InvDatabase.list[i];
			if (invDatabase.databaseID == dbID)
			{
				return invDatabase;
			}
			i++;
		}
		return null;
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00017364 File Offset: 0x00015764
	public static InvBaseItem FindByID(int id32)
	{
		InvDatabase database = InvDatabase.GetDatabase(id32 >> 16);
		return (!(database != null)) ? null : database.GetItem(id32 & 65535);
	}

	// Token: 0x0600017A RID: 378 RVA: 0x0001739C File Offset: 0x0001579C
	public static InvBaseItem FindByName(string exact)
	{
		int i = 0;
		int num = InvDatabase.list.Length;
		while (i < num)
		{
			InvDatabase invDatabase = InvDatabase.list[i];
			int j = 0;
			int count = invDatabase.items.Count;
			while (j < count)
			{
				InvBaseItem invBaseItem = invDatabase.items[j];
				if (invBaseItem.name == exact)
				{
					return invBaseItem;
				}
				j++;
			}
			i++;
		}
		return null;
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00017410 File Offset: 0x00015810
	public static int FindItemID(InvBaseItem item)
	{
		int i = 0;
		int num = InvDatabase.list.Length;
		while (i < num)
		{
			InvDatabase invDatabase = InvDatabase.list[i];
			if (invDatabase.items.Contains(item))
			{
				return invDatabase.databaseID << 16 | item.id16;
			}
			i++;
		}
		return -1;
	}

	// Token: 0x040002A3 RID: 675
	private static InvDatabase[] mList;

	// Token: 0x040002A4 RID: 676
	private static bool mIsDirty = true;

	// Token: 0x040002A5 RID: 677
	public int databaseID;

	// Token: 0x040002A6 RID: 678
	public List<InvBaseItem> items = new List<InvBaseItem>();

	// Token: 0x040002A7 RID: 679
	public UIAtlas iconAtlas;
}
