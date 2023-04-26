using System;
using UnityEngine;

// Token: 0x020000A7 RID: 167
public class ExhaustShakeC : MonoBehaviour
{
	// Token: 0x060005A2 RID: 1442 RVA: 0x00073EDC File Offset: 0x000722DC
	private void Start()
	{
		if (this.startOn)
		{
			iTween.ShakeRotation(base.gameObject, iTween.Hash(new object[]
			{
				"z",
				2.0,
				"time",
				0.2,
				"looptype",
				"loop"
			}));
		}
	}

	// Token: 0x0400083E RID: 2110
	public bool startOn = true;
}
