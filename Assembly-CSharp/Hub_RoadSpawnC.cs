using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
public class Hub_RoadSpawnC : MonoBehaviour
{
	// Token: 0x060006C5 RID: 1733 RVA: 0x00088D8C File Offset: 0x0008718C
	private void Start()
	{
		if (this.isCurved)
		{
			this.roadType = 4;
		}
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00088DA0 File Offset: 0x000871A0
	private void Reset()
	{
		Hub_RoadSpawn component = base.GetComponent<Hub_RoadSpawn>();
		this.roadConnections = component.roadConnections;
		this.isCurved = component.isCurved;
		this.streetClutter = (component.streetClutter as GameObject);
		this.roadType = component.roadType;
		this.canHaveParking = component.canHaveParking;
		this.pavement = (component.pavement as GameObject);
		this.singlePavement = component.singlePavement;
		component.enabled = false;
	}

	// Token: 0x04000934 RID: 2356
	public int roadConnections;

	// Token: 0x04000935 RID: 2357
	public bool isCurved;

	// Token: 0x04000936 RID: 2358
	public GameObject streetClutter;

	// Token: 0x04000937 RID: 2359
	public int roadType;

	// Token: 0x04000938 RID: 2360
	public bool canHaveParking;

	// Token: 0x04000939 RID: 2361
	public GameObject pavement;

	// Token: 0x0400093A RID: 2362
	public bool singlePavement;
}
