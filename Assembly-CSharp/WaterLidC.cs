using System;
using UnityEngine;

// Token: 0x0200012B RID: 299
public class WaterLidC : MonoBehaviour
{
	// Token: 0x06000C33 RID: 3123 RVA: 0x0012893C File Offset: 0x00126D3C
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000C34 RID: 3124 RVA: 0x00128974 File Offset: 0x00126D74
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000C35 RID: 3125 RVA: 0x001289CC File Offset: 0x00126DCC
	public void Trigger()
	{
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 1;
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
			this.waterSupply.SetActive(true);
			this.waterSupply.GetComponent<WaterSupplyRelayC>().StartCoroutine("LidUp");
			return;
		}
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 0;
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.position[0],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType2
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
			this.waterSupply.GetComponent<WaterSupplyRelayC>().StartCoroutine("LidDown");
			this.waterSupply.SetActive(false);
			return;
		}
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x00128BA0 File Offset: 0x00126FA0
	public void OnMouseOver()
	{
		if (!this._camera.GetComponent<DragRigidbodyC>().cursors[2].gameObject.active)
		{
			this.isGlowing = true;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.glowMaterial;
		}
		else if (this.isGlowing)
		{
			this.isGlowing = false;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x00128C36 File Offset: 0x00127036
	public void OnMouseExit()
	{
		if (this.currentPos == 1)
		{
			this.Trigger();
		}
		base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x040010BF RID: 4287
	private GameObject _camera;

	// Token: 0x040010C0 RID: 4288
	public GameObject waterSupply;

	// Token: 0x040010C1 RID: 4289
	public float timeToComplete = 2.05f;

	// Token: 0x040010C2 RID: 4290
	public int currentPos;

	// Token: 0x040010C3 RID: 4291
	public Vector3[] position = new Vector3[0];

	// Token: 0x040010C4 RID: 4292
	public AudioClip audioSample;

	// Token: 0x040010C5 RID: 4293
	public Material glowMaterial;

	// Token: 0x040010C6 RID: 4294
	public Material startMaterial;

	// Token: 0x040010C7 RID: 4295
	public string easeType = "easeoutelastic";

	// Token: 0x040010C8 RID: 4296
	public string easeType2 = "easeoutelastic";

	// Token: 0x040010C9 RID: 4297
	public AudioClip errorAudio;

	// Token: 0x040010CA RID: 4298
	private bool isGlowing;
}
