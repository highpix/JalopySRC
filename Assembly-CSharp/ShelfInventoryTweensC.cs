using System;
using UnityEngine;

// Token: 0x020000F7 RID: 247
public class ShelfInventoryTweensC : MonoBehaviour
{
	// Token: 0x060009B3 RID: 2483 RVA: 0x000E3FD7 File Offset: 0x000E23D7
	private void Start()
	{
		this.delay = MainMenuC.Global.inventoryShelfDelay;
		MainMenuC.Global.inventoryShelfDelay += 0.25f;
		this.TweenBar1In();
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x000E4008 File Offset: 0x000E2408
	public void TweenBar1In()
	{
		iTween.MoveTo(this.bar1, iTween.Hash(new object[]
		{
			"position",
			new Vector3(0.07139587f, 1.104614f, 0.5715477f),
			"delay",
			this.delay,
			"time",
			0.2,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"TweenBar2In",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x000E40C8 File Offset: 0x000E24C8
	public void TweenBar2In()
	{
		if (!this.isLoaded)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.metalAudio, 1f);
		}
		iTween.MoveTo(this.bar2, iTween.Hash(new object[]
		{
			"position",
			new Vector3(0.07139587f, 1.104614f, 0.5715477f),
			"time",
			0.2,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"TweenPalette1In",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x000E4190 File Offset: 0x000E2590
	public void TweenPalette1In()
	{
		if (!this.isLoaded)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.metalAudio, 1f);
		}
		iTween.MoveTo(this.palette1, iTween.Hash(new object[]
		{
			"position",
			new Vector3(-0.00396862f, -0.01915705f, -0.4039912f),
			"time",
			0.2,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"TweenBox1In",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x000E4258 File Offset: 0x000E2658
	public void TweenBox1In()
	{
		if (!this.isLoaded)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.woodAudio, 1f);
		}
		iTween.MoveTo(this.box1, iTween.Hash(new object[]
		{
			"position",
			Vector3.zero,
			"time",
			0.2,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"TweenPalette2In",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x000E4310 File Offset: 0x000E2710
	public void TweenPalette2In()
	{
		if (!this.isLoaded)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.plasticAudio, 1f);
		}
		iTween.MoveTo(this.palette2, iTween.Hash(new object[]
		{
			"position",
			new Vector3(0.02712258f, -0.01060744f, -0.364088f),
			"time",
			0.2,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"TweenBox2In",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x000E43D8 File Offset: 0x000E27D8
	public void TweenBox2In()
	{
		if (!this.isLoaded)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.woodAudio, 1f);
		}
		iTween.MoveTo(this.box2, iTween.Hash(new object[]
		{
			"position",
			Vector3.zero,
			"time",
			0.2,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"Box2Audio",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x000E4490 File Offset: 0x000E2890
	public void Box2Audio()
	{
		if (!this.isLoaded)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.plasticAudio, 1f);
		}
	}

	// Token: 0x04000D36 RID: 3382
	public GameObject bar1;

	// Token: 0x04000D37 RID: 3383
	public GameObject bar2;

	// Token: 0x04000D38 RID: 3384
	public GameObject palette1;

	// Token: 0x04000D39 RID: 3385
	public GameObject box1;

	// Token: 0x04000D3A RID: 3386
	public GameObject palette2;

	// Token: 0x04000D3B RID: 3387
	public GameObject box2;

	// Token: 0x04000D3C RID: 3388
	public AudioClip woodAudio;

	// Token: 0x04000D3D RID: 3389
	public AudioClip metalAudio;

	// Token: 0x04000D3E RID: 3390
	public AudioClip plasticAudio;

	// Token: 0x04000D3F RID: 3391
	public bool isLoaded;

	// Token: 0x04000D40 RID: 3392
	private float delay;
}
