using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000150 RID: 336
public class ToiletFlushC : MonoBehaviour
{
	// Token: 0x06000D32 RID: 3378 RVA: 0x0012EA48 File Offset: 0x0012CE48
	private void Reset()
	{
		ToiletFlush component = base.GetComponent<ToiletFlush>();
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.currentPos = component.currentPos;
		this.rotTo = component.rotTo;
		this.rotOrigin = component.rotOrigin;
		this.easeType = component.easeType;
		this.handleAudio = component.handleAudio;
		this.flushAudio = component.flushAudio;
		this.flushObject = component.flushObject;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x06000D33 RID: 3379 RVA: 0x0012EACE File Offset: 0x0012CECE
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x0012EAF8 File Offset: 0x0012CEF8
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x0012EB3C File Offset: 0x0012CF3C
	public IEnumerator Trigger()
	{
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject);
			yield return new WaitForEndOfFrame();
			this.currentPos = 1;
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotTo,
				"islocal",
				true,
				"time",
				0.12,
				"easetype",
				this.easeType,
				"oncomplete",
				"RotBack",
				"oncompletetarget",
				base.gameObject
			}));
			base.GetComponent<AudioSource>().clip = this.handleAudio;
			base.GetComponent<AudioSource>().Play();
		}
		yield break;
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x0012EB58 File Offset: 0x0012CF58
	public IEnumerator RotBack()
	{
		iTween.Stop(base.gameObject);
		yield return new WaitForEndOfFrame();
		this.currentPos = 0;
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotOrigin,
			"islocal",
			true,
			"time",
			0.25,
			"easetype",
			this.easeType
		}));
		yield break;
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x0012EB74 File Offset: 0x0012CF74
	public void OnMouseOver()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().cursors[0].gameObject.active)
		{
			this.isGlowing = true;
			base.GetComponent<Renderer>().material = this.glowMaterial;
		}
		else if (this.isGlowing)
		{
			this.isGlowing = false;
			base.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x0012EBE2 File Offset: 0x0012CFE2
	public void OnMouseExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x040011A8 RID: 4520
	private GameObject _camera;

	// Token: 0x040011A9 RID: 4521
	public Material startMaterial;

	// Token: 0x040011AA RID: 4522
	public Material glowMaterial;

	// Token: 0x040011AB RID: 4523
	public int currentPos;

	// Token: 0x040011AC RID: 4524
	public Vector3 rotTo;

	// Token: 0x040011AD RID: 4525
	public Vector3 rotOrigin;

	// Token: 0x040011AE RID: 4526
	public string easeType = string.Empty;

	// Token: 0x040011AF RID: 4527
	public AudioClip handleAudio;

	// Token: 0x040011B0 RID: 4528
	public AudioClip flushAudio;

	// Token: 0x040011B1 RID: 4529
	public GameObject flushObject;

	// Token: 0x040011B2 RID: 4530
	private bool isGlowing;
}
