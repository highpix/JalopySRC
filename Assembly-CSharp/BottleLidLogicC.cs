using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class BottleLidLogicC : MonoBehaviour
{
	// Token: 0x06000015 RID: 21 RVA: 0x00002DC5 File Offset: 0x000011C5
	private void Start()
	{
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002DC8 File Offset: 0x000011C8
	public void Animate()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"z",
			-0.1,
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutquad",
			"looptype",
			"pingpong"
		}));
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002E50 File Offset: 0x00001250
	public void StopAnimate()
	{
		iTween.Stop(base.gameObject);
	}
}
