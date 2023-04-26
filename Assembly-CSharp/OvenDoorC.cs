using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
public class OvenDoorC : MonoBehaviour
{
	// Token: 0x060008B6 RID: 2230 RVA: 0x000BDB48 File Offset: 0x000BBF48
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x000BDB70 File Offset: 0x000BBF70
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x000BDBB4 File Offset: 0x000BBFB4
	public void Trigger()
	{
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject);
			base.transform.GetComponent<Collider>().enabled = false;
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"x",
				this.turnAmountNegative,
				"islocal",
				true,
				"time",
				this.openTimeToComplete,
				"easetype",
				this.easeType,
				"onComplete",
				"AllowCollider",
				"onCompleteTarget",
				base.gameObject
			}));
			base.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.doorOpenAudio, 1f);
			this.TurnOvenOn();
			return;
		}
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject);
			base.transform.GetComponent<Collider>().enabled = false;
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"x",
				this.turnAmountPositive,
				"islocal",
				true,
				"time",
				this.closeTimeToComplete,
				"easetype",
				this.easeType2,
				"onComplete",
				"AllowColliderClose",
				"onCompleteTarget",
				base.gameObject
			}));
			base.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.doorCloseAudio, 1f);
			return;
		}
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x000BDD6A File Offset: 0x000BC16A
	public void TurnOvenOn()
	{
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x000BDD6C File Offset: 0x000BC16C
	public void AllowCollider()
	{
		this.currentPos = 1;
		base.transform.GetComponent<Collider>().enabled = true;
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x000BDD86 File Offset: 0x000BC186
	public void AllowColliderClose()
	{
		this.currentPos = 0;
		base.transform.localEulerAngles = this.closeRotation;
		base.transform.GetComponent<Collider>().enabled = true;
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x000BDDB4 File Offset: 0x000BC1B4
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

	// Token: 0x060008BD RID: 2237 RVA: 0x000BDE22 File Offset: 0x000BC222
	public void OnMouseExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000BA0 RID: 2976
	private GameObject _camera;

	// Token: 0x04000BA1 RID: 2977
	public float openTimeToComplete = 1.05f;

	// Token: 0x04000BA2 RID: 2978
	public float closeTimeToComplete = 0.75f;

	// Token: 0x04000BA3 RID: 2979
	public int currentPos;

	// Token: 0x04000BA4 RID: 2980
	public Vector3 closeRotation;

	// Token: 0x04000BA5 RID: 2981
	public float turnAmountNegative;

	// Token: 0x04000BA6 RID: 2982
	public float turnAmountPositive;

	// Token: 0x04000BA7 RID: 2983
	public AudioClip doorOpenAudio;

	// Token: 0x04000BA8 RID: 2984
	public AudioClip doorCloseAudio;

	// Token: 0x04000BA9 RID: 2985
	public Material glowMaterial;

	// Token: 0x04000BAA RID: 2986
	public Material startMaterial;

	// Token: 0x04000BAB RID: 2987
	public string easeType = "easeoutelastic";

	// Token: 0x04000BAC RID: 2988
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000BAD RID: 2989
	public AudioClip errorAudio;

	// Token: 0x04000BAE RID: 2990
	private bool isGlowing;
}
