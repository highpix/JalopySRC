using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000151 RID: 337
public class ToiletSeatLogicC : MonoBehaviour
{
	// Token: 0x06000D3A RID: 3386 RVA: 0x0012EEC8 File Offset: 0x0012D2C8
	private void Reset()
	{
		ToiletSeatLogic component = base.GetComponent<ToiletSeatLogic>();
		this.isFridge = component.isFridge;
		this.collideWithRot = component.collideWithRot;
		this.canCollideWith = component.canCollideWith;
		this.errorAudio = component.errorAudio;
		this.easeType = component.easeType;
		this.easeType2 = component.easeType2;
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.doorCloseAudio = component.doorCloseAudio;
		this.doorOpenAudio = component.doorOpenAudio;
		this.turnAmountPositive = component.turnAmountPositive;
		this.turnAmountNegative = component.turnAmountNegative;
		this.currentPos = component.currentPos;
		this.closeTimeToComplete = component.closeTimeToComplete;
		this.openTimeToComplete = component.openTimeToComplete;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x0012EF96 File Offset: 0x0012D396
	public void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x0012EFC0 File Offset: 0x0012D3C0
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			iTween.Stop(base.gameObject);
			if (this.canCollideWith != null && this.canCollideWith.transform.localEulerAngles != this.collideWithRot)
			{
				this.canCollideWith.SendMessage("TriggerClose");
			}
		}
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x0012F034 File Offset: 0x0012D434
	public void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x0012F078 File Offset: 0x0012D478
	public IEnumerator Trigger()
	{
		if (this.canCollideWith != null && this.canCollideWith.transform.localEulerAngles != this.collideWithRot)
		{
			this.canCollideWith.SendMessage("TriggerClose");
		}
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject);
			yield return new WaitForEndOfFrame();
			this.currentPos = 1;
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"z",
				this.turnAmountNegative,
				"islocal",
				true,
				"time",
				this.openTimeToComplete,
				"easetype",
				this.easeType
			}));
			base.GetComponent<AudioSource>().clip = this.doorOpenAudio;
			base.GetComponent<AudioSource>().Play();
			this.TurnOvenOn();
			yield break;
		}
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject);
			yield return new WaitForEndOfFrame();
			this.currentPos = 0;
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"z",
				this.turnAmountPositive,
				"islocal",
				true,
				"time",
				this.closeTimeToComplete,
				"easetype",
				this.easeType2,
				"oncomplete",
				"CloseAudio",
				"oncompletetarget",
				base.gameObject
			}));
			if (!this.isFridge)
			{
				base.GetComponent<AudioSource>().clip = this.doorOpenAudio;
				base.GetComponent<AudioSource>().Play();
			}
			yield break;
		}
		yield break;
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x0012F093 File Offset: 0x0012D493
	public void CloseAudio()
	{
		base.GetComponent<AudioSource>().clip = this.doorCloseAudio;
		base.GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x0012F0B4 File Offset: 0x0012D4B4
	public IEnumerator TriggerClose()
	{
		iTween.Stop(base.gameObject);
		float doubleTime = this.closeTimeToComplete / 2f;
		yield return new WaitForEndOfFrame();
		this.currentPos = 0;
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"z",
			this.turnAmountPositive,
			"islocal",
			true,
			"time",
			doubleTime,
			"easetype",
			this.easeType
		}));
		yield break;
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x0012F0CF File Offset: 0x0012D4CF
	public void TurnOvenOn()
	{
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x0012F0D4 File Offset: 0x0012D4D4
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

	// Token: 0x06000D43 RID: 3395 RVA: 0x0012F142 File Offset: 0x0012D542
	public void OnMouseExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x040011B3 RID: 4531
	private GameObject _camera;

	// Token: 0x040011B4 RID: 4532
	public float openTimeToComplete = 1.05f;

	// Token: 0x040011B5 RID: 4533
	public float closeTimeToComplete = 0.75f;

	// Token: 0x040011B6 RID: 4534
	public int currentPos;

	// Token: 0x040011B7 RID: 4535
	public float turnAmountNegative;

	// Token: 0x040011B8 RID: 4536
	public float turnAmountPositive;

	// Token: 0x040011B9 RID: 4537
	public AudioClip doorOpenAudio;

	// Token: 0x040011BA RID: 4538
	public AudioClip doorCloseAudio;

	// Token: 0x040011BB RID: 4539
	public Material glowMaterial;

	// Token: 0x040011BC RID: 4540
	public Material startMaterial;

	// Token: 0x040011BD RID: 4541
	public string easeType = "easeoutelastic";

	// Token: 0x040011BE RID: 4542
	public string easeType2 = "easeoutelastic";

	// Token: 0x040011BF RID: 4543
	public AudioClip errorAudio;

	// Token: 0x040011C0 RID: 4544
	public GameObject canCollideWith;

	// Token: 0x040011C1 RID: 4545
	public Vector3 collideWithRot;

	// Token: 0x040011C2 RID: 4546
	private bool isGlowing;

	// Token: 0x040011C3 RID: 4547
	public bool isFridge;
}
