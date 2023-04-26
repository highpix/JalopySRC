using System;
using UnityEngine;

// Token: 0x02000094 RID: 148
public class BreadBinDoorC : MonoBehaviour
{
	// Token: 0x060004A0 RID: 1184 RVA: 0x0004E96F File Offset: 0x0004CD6F
	private void Start()
	{
		this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
		if (this.glowTarget == null)
		{
			this.glowTarget = base.gameObject;
		}
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x0004E9A4 File Offset: 0x0004CDA4
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

	// Token: 0x060004A2 RID: 1186 RVA: 0x0004EA18 File Offset: 0x0004CE18
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.glowTarget.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x0004EA64 File Offset: 0x0004CE64
	public void Trigger()
	{
		if (this.canCollideWith != null && this.canCollideWith.transform.localEulerAngles != this.collideWithRot)
		{
			this.canCollideWith.SendMessage("TriggerClose");
		}
		if (this.isLocked)
		{
			base.GetComponent<AudioSource>().clip = this.doorLockedAudio;
			base.GetComponent<AudioSource>().Play();
			return;
		}
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject);
			this.currentPos = 1;
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
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
			if (this.useOnce)
			{
				this.PreventAdditionalUsage();
			}
			return;
		}
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject);
			this.currentPos = 0;
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
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
			return;
		}
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0004EC5E File Offset: 0x0004D05E
	public void PreventAdditionalUsage()
	{
		UnityEngine.Object.Destroy(base.gameObject.GetComponent<BoxCollider>());
		this.isGlowing = false;
		this.glowTarget.GetComponent<Renderer>().material = this.startMaterial;
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x0004EC93 File Offset: 0x0004D093
	public void CloseAudio()
	{
		base.GetComponent<AudioSource>().clip = this.doorCloseAudio;
		base.GetComponent<AudioSource>().Play();
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x0004ECB4 File Offset: 0x0004D0B4
	public void TriggerClose()
	{
		iTween.Stop(base.gameObject);
		float num = this.closeTimeToComplete / 2f;
		this.currentPos = 0;
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.turnAmountPositive,
			"islocal",
			true,
			"time",
			num,
			"easetype",
			this.easeType
		}));
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x0004ED3F File Offset: 0x0004D13F
	public void TurnOvenOn()
	{
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x0004ED41 File Offset: 0x0004D141
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.glowTarget.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0004ED60 File Offset: 0x0004D160
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.glowTarget.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x040006B7 RID: 1719
	public float openTimeToComplete = 1.05f;

	// Token: 0x040006B8 RID: 1720
	public float closeTimeToComplete = 0.75f;

	// Token: 0x040006B9 RID: 1721
	public int currentPos;

	// Token: 0x040006BA RID: 1722
	public Vector3 turnAmountNegative = new Vector3(0f, -90f, 0f);

	// Token: 0x040006BB RID: 1723
	public Vector3 turnAmountPositive = new Vector3(0f, 0f, 0f);

	// Token: 0x040006BC RID: 1724
	public AudioClip doorOpenAudio;

	// Token: 0x040006BD RID: 1725
	public AudioClip doorCloseAudio;

	// Token: 0x040006BE RID: 1726
	public AudioClip doorLockedAudio;

	// Token: 0x040006BF RID: 1727
	public Material glowMaterial;

	// Token: 0x040006C0 RID: 1728
	public Material startMaterial;

	// Token: 0x040006C1 RID: 1729
	public string easeType = "easeoutelastic";

	// Token: 0x040006C2 RID: 1730
	public string easeType2 = "easeoutelastic";

	// Token: 0x040006C3 RID: 1731
	public AudioClip errorAudio;

	// Token: 0x040006C4 RID: 1732
	public GameObject canCollideWith;

	// Token: 0x040006C5 RID: 1733
	public Vector3 collideWithRot;

	// Token: 0x040006C6 RID: 1734
	public GameObject glowTarget;

	// Token: 0x040006C7 RID: 1735
	private bool isGlowing;

	// Token: 0x040006C8 RID: 1736
	public bool isFridge;

	// Token: 0x040006C9 RID: 1737
	public bool useOnce;

	// Token: 0x040006CA RID: 1738
	public bool isLocked;
}
