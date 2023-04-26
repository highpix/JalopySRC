using System;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class OffRouteBlockerC : MonoBehaviour
{
	// Token: 0x06000898 RID: 2200 RVA: 0x000BC1EC File Offset: 0x000BA5EC
	private void Start()
	{
		this.spawnDirector = GameObject.FindWithTag("Director");
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().blockerObjects[0]);
		gameObject.transform.parent = base.transform;
		gameObject.transform.position = base.transform.position;
		gameObject.transform.rotation = base.transform.rotation;
	}

	// Token: 0x04000B6B RID: 2923
	public GameObject spawnDirector;
}
