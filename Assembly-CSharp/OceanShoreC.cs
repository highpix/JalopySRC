using System;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class OceanShoreC : MonoBehaviour
{
	// Token: 0x06000894 RID: 2196 RVA: 0x000BBFCF File Offset: 0x000BA3CF
	private void Start()
	{
		this.Wave1();
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x000BBFD8 File Offset: 0x000BA3D8
	public void Wave1()
	{
		iTween.MoveBy(base.gameObject, iTween.Hash(new object[]
		{
			"x",
			40,
			"islocal",
			true,
			"delay",
			3.0,
			"time",
			3.0,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"Wave2",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.FadeTo(base.gameObject, iTween.Hash(new object[]
		{
			"delay",
			3.0,
			"alpha",
			1.0,
			"time",
			3.0,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x000BC0F8 File Offset: 0x000BA4F8
	public void Wave2()
	{
		iTween.MoveBy(base.gameObject, iTween.Hash(new object[]
		{
			"x",
			-40,
			"islocal",
			true,
			"time",
			3.0,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"Wave1",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.FadeTo(base.gameObject, iTween.Hash(new object[]
		{
			"alpha",
			0.0,
			"time",
			3.0,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x04000B6A RID: 2922
	public float initialDelay;
}
