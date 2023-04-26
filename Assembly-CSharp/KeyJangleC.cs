using System;
using UnityEngine;

// Token: 0x020000BC RID: 188
public class KeyJangleC : MonoBehaviour
{
	// Token: 0x060006D1 RID: 1745 RVA: 0x00089124 File Offset: 0x00087524
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.isAnimating = true;
		base.StartCoroutine("Rot3");
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0008914C File Offset: 0x0008754C
	private void Update()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == base.transform.parent.gameObject && !this.isAnimating)
		{
			this.isAnimating = true;
			base.StartCoroutine("Rot3");
		}
		if (!this.isAnimating && !this.stoppedAnimating)
		{
			iTween.Stop(base.gameObject);
			this.stoppedAnimating = true;
		}
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x000891CC File Offset: 0x000875CC
	public void Rot1()
	{
		iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
		{
			"x",
			-0.04,
			"islocal",
			true,
			"time",
			1,
			"easetype",
			"easeinoutquad",
			"oncomplete",
			"Rot2"
		}));
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0008924C File Offset: 0x0008764C
	public void Rot2()
	{
		iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
		{
			"x",
			0.04,
			"islocal",
			true,
			"time",
			1,
			"easetype",
			"easeinoutquad",
			"oncomplete",
			"Rot1"
		}));
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x000892CC File Offset: 0x000876CC
	public void Rot3()
	{
		iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
		{
			"z",
			-0.04,
			"islocal",
			true,
			"time",
			0.4,
			"easetype",
			"easeinoutquad",
			"oncomplete",
			"Rot4"
		}));
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x00089354 File Offset: 0x00087754
	public void Rot4()
	{
		iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
		{
			"z",
			0.04,
			"islocal",
			true,
			"time",
			0.4,
			"easetype",
			"easeinoutquad",
			"oncomplete",
			"Rot3"
		}));
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x000893DC File Offset: 0x000877DC
	public void IgnitionOn()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(45f, 110f, 105f),
			"islocal",
			true,
			"time",
			0.2,
			"easetype",
			"easeinoutquad"
		}));
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x00089460 File Offset: 0x00087860
	public void IgnitionOff()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(85f, 22f, 22f),
			"islocal",
			true,
			"time",
			0.2,
			"easetype",
			"easeinoutquad"
		}));
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x000894E4 File Offset: 0x000878E4
	public void ThrowLogic()
	{
		Debug.Log("Is working");
		iTween.Stop(base.gameObject);
		base.transform.localEulerAngles = new Vector3(90f, 20f, 0f);
		this.stoppedAnimating = true;
		this.isAnimating = false;
		base.StopAllCoroutines();
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x0008953C File Offset: 0x0008793C
	public void DropOff()
	{
		Debug.Log("Is working");
		iTween.Stop(base.gameObject);
		base.transform.localEulerAngles = new Vector3(90f, 20f, 0f);
		this.stoppedAnimating = true;
		this.isAnimating = false;
		base.StopAllCoroutines();
	}

	// Token: 0x0400094C RID: 2380
	private GameObject _camera;

	// Token: 0x0400094D RID: 2381
	public GameObject player;

	// Token: 0x0400094E RID: 2382
	private bool isAnimating;

	// Token: 0x0400094F RID: 2383
	private bool stoppedAnimating;
}
