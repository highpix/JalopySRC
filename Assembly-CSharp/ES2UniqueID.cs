using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000021 RID: 33
public class ES2UniqueID : MonoBehaviour
{
	// Token: 0x0600009F RID: 159 RVA: 0x0000728E File Offset: 0x0000568E
	public void Awake()
	{
		this.id = ES2UniqueID.GenerateUniqueID();
		ES2UniqueID.uniqueIDList.Add(this);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x000072A6 File Offset: 0x000056A6
	public void OnDestroy()
	{
		ES2UniqueID.uniqueIDList.Remove(this);
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x000072B4 File Offset: 0x000056B4
	private static int GenerateUniqueID()
	{
		if (ES2UniqueID.uniqueIDList.Count == 0)
		{
			return 0;
		}
		return ES2UniqueID.uniqueIDList[ES2UniqueID.uniqueIDList.Count - 1].id + 1;
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x000072E4 File Offset: 0x000056E4
	public static ES2UniqueID FindUniqueID(Transform t)
	{
		foreach (ES2UniqueID es2UniqueID in ES2UniqueID.uniqueIDList)
		{
			if (es2UniqueID.transform == t)
			{
				return es2UniqueID;
			}
		}
		return null;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00007354 File Offset: 0x00005754
	public static Transform FindTransform(int id)
	{
		foreach (ES2UniqueID es2UniqueID in ES2UniqueID.uniqueIDList)
		{
			if (es2UniqueID.id == id)
			{
				return es2UniqueID.transform;
			}
		}
		return null;
	}

	// Token: 0x0400005F RID: 95
	[HideInInspector]
	public int id;

	// Token: 0x04000060 RID: 96
	public string prefabName = string.Empty;

	// Token: 0x04000061 RID: 97
	private static List<ES2UniqueID> uniqueIDList = new List<ES2UniqueID>();
}
