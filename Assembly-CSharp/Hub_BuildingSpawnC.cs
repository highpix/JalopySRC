using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class Hub_BuildingSpawnC : MonoBehaviour
{
	// Token: 0x060006B3 RID: 1715 RVA: 0x00085DF8 File Offset: 0x000841F8
	public void Reset()
	{
		Hub_BuildingSpawn component = base.GetComponent<Hub_BuildingSpawn>();
		this.focedHollow = component.focedHollow;
		this.citySpawn = (component.citySpawn as GameObject);
		component.pavementRots.Copy(ref this.pavementRots);
		this.doNotChangeRoad = component.doNotChangeRoad;
		this.roadTarget = (component.roadTarget as GameObject);
		this.tJunctionRot = component.tJunctionRot;
		this.cornerType = component.cornerType;
		this.isCornerBuilding = component.isCornerBuilding;
		this.pavement = (component.pavement as GameObject);
		this.pavementLevel = component.pavementLevel;
		component.enabled = false;
	}

	// Token: 0x040008FA RID: 2298
	public bool focedHollow;

	// Token: 0x040008FB RID: 2299
	public GameObject citySpawn;

	// Token: 0x040008FC RID: 2300
	public Vector3[] pavementRots = new Vector3[0];

	// Token: 0x040008FD RID: 2301
	public bool doNotChangeRoad;

	// Token: 0x040008FE RID: 2302
	public GameObject roadTarget;

	// Token: 0x040008FF RID: 2303
	public Vector3 tJunctionRot;

	// Token: 0x04000900 RID: 2304
	public int cornerType;

	// Token: 0x04000901 RID: 2305
	public bool isCornerBuilding;

	// Token: 0x04000902 RID: 2306
	public GameObject pavement;

	// Token: 0x04000903 RID: 2307
	public int pavementLevel;
}
