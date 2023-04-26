using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class UniqueObjectManager : MonoBehaviour
{
	// Token: 0x060000AB RID: 171 RVA: 0x000077A0 File Offset: 0x00005BA0
	public static GameObject InstantiatePrefab(string prefabName, Vector3 position, Quaternion rotation)
	{
		GameObject gameObject = UniqueObjectManager.FindPrefabWithName(prefabName);
		if (gameObject == null)
		{
			throw new Exception("Cannot instantiate prefab: No such prefab exists.");
		}
		if (gameObject.GetComponent<ES2UniqueID>() == null)
		{
			throw new Exception("Can't instantiate a prefab which has no UniqueID attached.");
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject, position, rotation);
		UniqueObjectManager.CreatedObjects.Add(gameObject2);
		return gameObject2;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x000077FC File Offset: 0x00005BFC
	public static GameObject InstantiatePrefab(string prefabName)
	{
		return UniqueObjectManager.InstantiatePrefab(prefabName, Vector3.zero, Quaternion.identity);
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00007810 File Offset: 0x00005C10
	public static void DestroyObject(GameObject obj)
	{
		if (!UniqueObjectManager.CreatedObjects.Remove(obj))
		{
			throw new Exception("Cannot destroy prefab: No such prefab exists.");
		}
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				UniqueObjectManager.DestroyObject(transform.gameObject);
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
		UnityEngine.Object.Destroy(obj);
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0000789C File Offset: 0x00005C9C
	public static GameObject FindPrefabWithName(string prefabName)
	{
		GameObject result = null;
		for (int i = 0; i < UniqueObjectManager.Prefabs.Length; i++)
		{
			if (UniqueObjectManager.Prefabs[i].name == prefabName)
			{
				result = UniqueObjectManager.Prefabs[i];
			}
		}
		return result;
	}

	// Token: 0x060000AF RID: 175 RVA: 0x000078E3 File Offset: 0x00005CE3
	public void Awake()
	{
		UniqueObjectManager.mgr = this;
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060000B0 RID: 176 RVA: 0x000078EB File Offset: 0x00005CEB
	public static GameObject[] SceneObjects
	{
		get
		{
			return UniqueObjectManager.mgr.sceneObjects;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060000B1 RID: 177 RVA: 0x000078F7 File Offset: 0x00005CF7
	public static GameObject[] Prefabs
	{
		get
		{
			return UniqueObjectManager.mgr.prefabs;
		}
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060000B2 RID: 178 RVA: 0x00007903 File Offset: 0x00005D03
	public static List<GameObject> CreatedObjects
	{
		get
		{
			return UniqueObjectManager.createdObjects;
		}
	}

	// Token: 0x04000062 RID: 98
	public GameObject[] sceneObjects;

	// Token: 0x04000063 RID: 99
	public GameObject[] prefabs;

	// Token: 0x04000064 RID: 100
	public static List<GameObject> createdObjects = new List<GameObject>();

	// Token: 0x04000065 RID: 101
	public static UniqueObjectManager mgr;
}
