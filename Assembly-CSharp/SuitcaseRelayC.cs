using System;
using UnityEngine;

// Token: 0x02000108 RID: 264
public class SuitcaseRelayC : MonoBehaviour
{
	// Token: 0x06000A6E RID: 2670 RVA: 0x000F8933 File Offset: 0x000F6D33
	public void ChangeToCarMesh()
	{
		this._handle.GetComponent<MeshFilter>().mesh = this._carMesh;
	}

	// Token: 0x04000E87 RID: 3719
	public GameObject _lock;

	// Token: 0x04000E88 RID: 3720
	public Mesh _carMesh;

	// Token: 0x04000E89 RID: 3721
	public GameObject _handle;
}
