using System;
using UnityEngine;

// Token: 0x02000133 RID: 307
public class SignRotRepeatC : MonoBehaviour
{
	// Token: 0x06000C69 RID: 3177 RVA: 0x0012B974 File Offset: 0x00129D74
	private void Start()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rot1,
			"time",
			this.rotTime,
			"islocal",
			true,
			"easetype",
			"easeinoutquad",
			"looptype",
			"pingpong"
		}));
	}

	// Token: 0x04001118 RID: 4376
	public Vector3 rot1;

	// Token: 0x04001119 RID: 4377
	public Vector3 rot2;

	// Token: 0x0400111A RID: 4378
	public float rotTime;
}
