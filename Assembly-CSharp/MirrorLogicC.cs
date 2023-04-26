using System;
using UnityEngine;

// Token: 0x02000117 RID: 279
public class MirrorLogicC : MonoBehaviour
{
	// Token: 0x06000AFD RID: 2813 RVA: 0x001012BB File Offset: 0x000FF6BB
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x001012E4 File Offset: 0x000FF6E4
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x0010133C File Offset: 0x000FF73C
	public void Trigger()
	{
		if (this.keyHolder != null)
		{
			if (this.keyHolder.transform.childCount > 0)
			{
				this.keyHolder.transform.GetChild(0).SendMessage("PickUp");
			}
			this.keyHolder = null;
		}
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 1;
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.positionRotation[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
			return;
		}
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 0;
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.positionRotation[0],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType2
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.audioSample, 0.7f);
			return;
		}
	}

	// Token: 0x06000B00 RID: 2816 RVA: 0x00101515 File Offset: 0x000FF915
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x0010153E File Offset: 0x000FF93E
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000F57 RID: 3927
	public float timeToComplete = 2.05f;

	// Token: 0x04000F58 RID: 3928
	public int currentPos;

	// Token: 0x04000F59 RID: 3929
	public Vector3[] positionRotation;

	// Token: 0x04000F5A RID: 3930
	public AudioClip audioSample;

	// Token: 0x04000F5B RID: 3931
	public Material glowMaterial;

	// Token: 0x04000F5C RID: 3932
	public Material startMaterial;

	// Token: 0x04000F5D RID: 3933
	public string easeType = "easeoutelastic";

	// Token: 0x04000F5E RID: 3934
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000F5F RID: 3935
	private bool isGlowing;

	// Token: 0x04000F60 RID: 3936
	public GameObject keyHolder;
}
