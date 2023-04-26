using System;
using UnityEngine;

// Token: 0x0200014C RID: 332
public class SpawnDestinationC : MonoBehaviour
{
	// Token: 0x04001188 RID: 4488
	public GameObject spawnDirector;

	// Token: 0x04001189 RID: 4489
	public GameObject continueNode;

	// Token: 0x0400118A RID: 4490
	public int startSize;

	// Token: 0x0400118B RID: 4491
	public int continueSize;

	// Token: 0x0400118C RID: 4492
	public Transform[] puddleTargets = new Transform[0];

	// Token: 0x0400118D RID: 4493
	public Transform stopOffTarget;
}
