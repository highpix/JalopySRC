using System;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class PushDrawC : MonoBehaviour
{
	// Token: 0x06000960 RID: 2400 RVA: 0x000DFE0C File Offset: 0x000DE20C
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x000DFE34 File Offset: 0x000DE234
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			iTween.Stop(base.gameObject);
			base.transform.parent.GetComponent<AudioSource>().Stop();
			if (this.canCollideWith != null && this.canCollideWith.transform.localRotation != Quaternion.Euler(this.collideWithRot))
			{
				this.canCollideWith.SendMessage("TriggerClose");
			}
		}
	}

	// Token: 0x06000962 RID: 2402 RVA: 0x000DFEC4 File Offset: 0x000DE2C4
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x000DFF08 File Offset: 0x000DE308
	public void Trigger()
	{
		if (this.canCollideWith != null && this.canCollideWith.transform.localRotation != Quaternion.Euler(this.collideWithRot))
		{
			this.canCollideWith.SendMessage("TriggerClose");
		}
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject);
			this.currentPos = 1;
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.position2,
				"islocal",
				true,
				"time",
				this.openTimeToComplete,
				"easetype",
				this.easeType
			}));
			base.transform.parent.GetComponent<AudioSource>().clip = this.doorOpenAudio;
			base.transform.parent.GetComponent<AudioSource>().Play();
			this.TurnOvenOn();
			return;
		}
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject);
			this.currentPos = 0;
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.position1,
				"islocal",
				true,
				"time",
				this.closeTimeToComplete,
				"easetype",
				this.easeType2
			}));
			base.transform.parent.GetComponent<AudioSource>().clip = this.doorOpenAudio;
			base.transform.parent.GetComponent<AudioSource>().Play();
			return;
		}
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x000E00C8 File Offset: 0x000DE4C8
	public void TriggerClose()
	{
		iTween.Stop(base.gameObject);
		float num = this.closeTimeToComplete / 2f;
		this.currentPos = 0;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position1,
			"islocal",
			true,
			"time",
			num,
			"easetype",
			this.easeType2
		}));
		base.transform.parent.GetComponent<AudioSource>().clip = this.doorOpenAudio;
		base.transform.parent.GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x000E0183 File Offset: 0x000DE583
	public void TurnOvenOn()
	{
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x000E0188 File Offset: 0x000DE588
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

	// Token: 0x06000967 RID: 2407 RVA: 0x000E01F6 File Offset: 0x000DE5F6
	public void OnMouseExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000CCB RID: 3275
	private GameObject _camera;

	// Token: 0x04000CCC RID: 3276
	public float openTimeToComplete = 1.05f;

	// Token: 0x04000CCD RID: 3277
	public float closeTimeToComplete = 0.75f;

	// Token: 0x04000CCE RID: 3278
	public int currentPos;

	// Token: 0x04000CCF RID: 3279
	public Vector3 position2;

	// Token: 0x04000CD0 RID: 3280
	public Vector3 position1;

	// Token: 0x04000CD1 RID: 3281
	public AudioClip doorOpenAudio;

	// Token: 0x04000CD2 RID: 3282
	public AudioClip doorCloseAudio;

	// Token: 0x04000CD3 RID: 3283
	public Material glowMaterial;

	// Token: 0x04000CD4 RID: 3284
	public Material startMaterial;

	// Token: 0x04000CD5 RID: 3285
	public string easeType = "easeoutelastic";

	// Token: 0x04000CD6 RID: 3286
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000CD7 RID: 3287
	public AudioClip errorAudio;

	// Token: 0x04000CD8 RID: 3288
	public GameObject canCollideWith;

	// Token: 0x04000CD9 RID: 3289
	public Vector3 collideWithRot;

	// Token: 0x04000CDA RID: 3290
	private bool isGlowing;
}
