using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000025 RID: 37
public class PrefabManager : MonoBehaviour
{
	// Token: 0x060000BB RID: 187 RVA: 0x00007C61 File Offset: 0x00006061
	private void Start()
	{
		if (ES3.Exists(this.filename))
		{
			this.LoadAllPrefabs();
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00007C7C File Offset: 0x0000607C
	private void LoadAllPrefabs()
	{
		int num = ES3.LoadInt(this.filename + "?tag=prefabCount");
		for (int i = 0; i < num; i++)
		{
			this.LoadPrefab(i);
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00007CB8 File Offset: 0x000060B8
	private void LoadPrefab(int tag)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefab);
		ES2.Load<Transform>(this.filename + "?tag=" + tag, gameObject.transform);
		this.createdPrefabs.Add(gameObject);
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00007D00 File Offset: 0x00006100
	private void CreateRandomPrefab()
	{
		GameObject item = UnityEngine.Object.Instantiate<GameObject>(this.prefab, UnityEngine.Random.insideUnitSphere * 5f, UnityEngine.Random.rotation);
		this.createdPrefabs.Add(item);
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00007D3C File Offset: 0x0000613C
	private void OnApplicationQuit()
	{
		ES2.Save<int>(this.createdPrefabs.Count, this.filename + "?tag=prefabCount");
		for (int i = 0; i < this.createdPrefabs.Count; i++)
		{
			this.SavePrefab(this.createdPrefabs[i], i);
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00007D98 File Offset: 0x00006198
	private void SavePrefab(GameObject prefabToSave, int tag)
	{
		ES2.Save<Transform>(prefabToSave.transform, this.filename + "?tag=" + tag);
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00007DBC File Offset: 0x000061BC
	private void OnGUI()
	{
		if (GUI.Button(new Rect((float)this.buttonPositionX, 0f, 250f, 100f), "Create Random " + this.prefab.name))
		{
			this.CreateRandomPrefab();
		}
		if (GUI.Button(new Rect((float)this.buttonPositionX, 100f, 250f, 100f), "Delete Saved " + this.prefab.name))
		{
			ES2.Delete(this.filename);
			for (int i = 0; i < this.createdPrefabs.Count; i++)
			{
				UnityEngine.Object.Destroy(this.createdPrefabs[i]);
			}
			this.createdPrefabs.Clear();
		}
	}

	// Token: 0x04000068 RID: 104
	public GameObject prefab;

	// Token: 0x04000069 RID: 105
	public string filename = "SavedPrefabs.txt";

	// Token: 0x0400006A RID: 106
	public int buttonPositionX;

	// Token: 0x0400006B RID: 107
	private List<GameObject> createdPrefabs = new List<GameObject>();
}
