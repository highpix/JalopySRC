using System;
using UnityEngine;

// Token: 0x0200010A RID: 266
public class ToolRackC : MonoBehaviour
{
	// Token: 0x06000A8D RID: 2701 RVA: 0x000F8F60 File Offset: 0x000F7360
	public void Wiggle()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[0],
			"islocal",
			true,
			"delay",
			0.6,
			"time",
			0.75,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x000F8FFC File Offset: 0x000F73FC
	public void Close()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotations[1],
			"delay",
			0.3,
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x000F9095 File Offset: 0x000F7495
	public void UpgradeToLvl2()
	{
		this.spanner.GetComponent<MeshFilter>().mesh = this.spannerMesh[0];
		this.spanner.GetComponent<RepairKitC>().spannerDamageLvl = 0.67f;
	}

	// Token: 0x06000A90 RID: 2704 RVA: 0x000F90C4 File Offset: 0x000F74C4
	public void UpgradeToLvl3()
	{
		this.spanner.GetComponent<MeshFilter>().mesh = this.spannerMesh[1];
		this.spanner.GetComponent<RepairKitC>().spannerDamageLvl = 1f;
	}

	// Token: 0x04000E95 RID: 3733
	public GameObject crowBarGhost;

	// Token: 0x04000E96 RID: 3734
	public GameObject jackGhost;

	// Token: 0x04000E97 RID: 3735
	public GameObject spannerGhost;

	// Token: 0x04000E98 RID: 3736
	public GameObject spanner;

	// Token: 0x04000E99 RID: 3737
	public Mesh[] spannerMesh;

	// Token: 0x04000E9A RID: 3738
	public Vector3[] rotations;
}
