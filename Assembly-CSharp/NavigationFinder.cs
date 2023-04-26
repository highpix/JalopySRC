using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class NavigationFinder : MonoBehaviour
{
	// Token: 0x06000150 RID: 336 RVA: 0x00016643 File Offset: 0x00014A43
	[ContextMenu("Find Nav Nodes")]
	public void FindNavNodes()
	{
		this.navigationNodes.AddRange(GameObject.FindGameObjectsWithTag("Nav"));
	}

	// Token: 0x0400026D RID: 621
	public List<GameObject> navigationNodes = new List<GameObject>();
}
