using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class UniqueGameLogic : MonoBehaviour
{
	// Token: 0x060000A6 RID: 166 RVA: 0x000073D8 File Offset: 0x000057D8
	public void Start()
	{
		base.StartCoroutine(this.DestroyOrCreateRoutine(3f, 1f));
		base.StartCoroutine(this.ScaleRoutine(3f, 1f));
		base.StartCoroutine(this.MakeChildRoutine(3f, 1f));
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000742C File Offset: 0x0000582C
	public IEnumerator DestroyOrCreateRoutine(float delaySeconds, float runEverySeconds)
	{
		yield return new WaitForSeconds(delaySeconds);
		for (;;)
		{
			if (UniqueObjectManager.CreatedObjects.Count > 9)
			{
				UniqueObjectManager.DestroyObject(UniqueObjectManager.CreatedObjects[UnityEngine.Random.Range(0, UniqueObjectManager.CreatedObjects.Count)]);
			}
			else
			{
				UniqueObjectManager.InstantiatePrefab(UniqueObjectManager.Prefabs[UnityEngine.Random.Range(0, UniqueObjectManager.Prefabs.Length)].name, UnityEngine.Random.insideUnitSphere * 10f, UnityEngine.Random.rotation);
			}
			yield return new WaitForSeconds(runEverySeconds);
		}
		yield break;
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00007450 File Offset: 0x00005850
	public IEnumerator MakeChildRoutine(float delaySeconds, float runEverySeconds)
	{
		yield return new WaitForSeconds(delaySeconds);
		for (;;)
		{
			if (UniqueObjectManager.CreatedObjects.Count > 4)
			{
				UniqueObjectManager.CreatedObjects[0].transform.parent = UniqueObjectManager.CreatedObjects[UnityEngine.Random.Range(1, UniqueObjectManager.CreatedObjects.Count)].transform;
			}
			yield return new WaitForSeconds(runEverySeconds);
		}
		yield break;
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00007474 File Offset: 0x00005874
	public IEnumerator ScaleRoutine(float delaySeconds, float runEverySeconds)
	{
		yield return new WaitForSeconds(delaySeconds);
		for (;;)
		{
			UniqueObjectManager.SceneObjects[UnityEngine.Random.Range(0, UniqueObjectManager.SceneObjects.Length)].transform.localScale = UnityEngine.Random.insideUnitSphere;
			yield return new WaitForSeconds(runEverySeconds);
		}
		yield break;
	}
}
