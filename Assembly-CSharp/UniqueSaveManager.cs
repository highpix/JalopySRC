using System;
using UnityEngine;

// Token: 0x02000024 RID: 36
public class UniqueSaveManager : MonoBehaviour
{
	// Token: 0x060000B5 RID: 181 RVA: 0x00007934 File Offset: 0x00005D34
	public void OnApplicationQuit()
	{
		this.Save();
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x0000793C File Offset: 0x00005D3C
	public void Start()
	{
		if (ES3.Exists(this.sceneObjectFile))
		{
			int num = ES3.LoadInt(this.sceneObjectFile + "?tag=sceneObjectCount");
			for (int i = 0; i < num; i++)
			{
				this.LoadObject(i, this.sceneObjectFile);
			}
		}
		if (ES3.Exists(this.createdObjectFile))
		{
			int num2 = ES3.LoadInt(this.createdObjectFile + "?tag=createdObjectCount");
			for (int j = 0; j < num2; j++)
			{
				this.LoadObject(j, this.createdObjectFile);
			}
		}
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x000079D4 File Offset: 0x00005DD4
	private void Save()
	{
		ES2.Save<int>(UniqueObjectManager.SceneObjects.Length, this.sceneObjectFile + "?tag=sceneObjectCount");
		for (int i = 0; i < UniqueObjectManager.SceneObjects.Length; i++)
		{
			this.SaveObject(UniqueObjectManager.SceneObjects[i], i, this.sceneObjectFile);
		}
		ES2.Save<int>(UniqueObjectManager.CreatedObjects.Count, this.createdObjectFile + "?tag=createdObjectCount");
		for (int j = 0; j < UniqueObjectManager.CreatedObjects.Count; j++)
		{
			this.SaveObject(UniqueObjectManager.CreatedObjects[j], j, this.createdObjectFile);
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00007A7C File Offset: 0x00005E7C
	private void SaveObject(GameObject obj, int i, string file)
	{
		ES2UniqueID component = obj.GetComponent<ES2UniqueID>();
		ES2.Save<int>(component.id, file + "?tag=uniqueID" + i);
		ES2.Save<string>(component.prefabName, file + "?tag=prefabName" + i);
		ES2.Save<bool>(component.gameObject.activeSelf, file + "?tag=active" + i);
		Transform component2 = obj.GetComponent<Transform>();
		if (component2 != null)
		{
			ES2.Save<Transform>(component2, file + "?tag=transform" + i);
			ES2UniqueID es2UniqueID = ES2UniqueID.FindUniqueID(component2.parent);
			if (es2UniqueID == null)
			{
				ES2.Save<int>(-1, file + "?tag=parentID" + i);
			}
			else
			{
				ES2.Save<int>(es2UniqueID.id, file + "?tag=parentID" + i);
			}
		}
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00007B64 File Offset: 0x00005F64
	private void LoadObject(int i, string file)
	{
		int id = ES3.LoadInt(file + "?tag=uniqueID" + i);
		string text = ES2.Load<string>(file + "?tag=prefabName" + i);
		GameObject gameObject;
		if (text == string.Empty)
		{
			gameObject = ES2UniqueID.FindTransform(id).gameObject;
		}
		else
		{
			gameObject = UniqueObjectManager.InstantiatePrefab(text);
		}
		gameObject.SetActive(ES3.LoadBool(file + "?tag=active" + i));
		Transform component = gameObject.GetComponent<Transform>();
		if (component != null)
		{
			ES2.Load<Transform>(file + "?tag=transform" + i, component);
			int id2 = ES3.LoadInt(file + "?tag=parentID" + i);
			Transform transform = ES2UniqueID.FindTransform(id2);
			if (transform != null)
			{
				component.parent = transform;
			}
		}
	}

	// Token: 0x04000066 RID: 102
	public string sceneObjectFile = "sceneObjectsFile.txt";

	// Token: 0x04000067 RID: 103
	public string createdObjectFile = "createdObjectsFile.txt";
}
