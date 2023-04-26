using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000110 RID: 272
public class CigLighterC : MonoBehaviour
{
	// Token: 0x06000AC1 RID: 2753 RVA: 0x000FAF04 File Offset: 0x000F9304
	private void Start()
	{
		this.startMaterial = base.gameObject.transform.parent.GetComponent<Renderer>().material;
	}

	// Token: 0x06000AC2 RID: 2754 RVA: 0x000FAF28 File Offset: 0x000F9328
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.transform.parent.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000AC3 RID: 2755 RVA: 0x000FAF80 File Offset: 0x000F9380
	public IEnumerator Trigger()
	{
		if (!this.carLogic.GetComponent<CarLogicC>().engineOn)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject, "MoveTo");
			base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 0.5f);
			iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.cigPos[1],
				"islocal",
				true,
				"time",
				0.25,
				"easetype",
				"cigEaseType"
			}));
			yield return new WaitForSeconds(0.25f);
			iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.cigPos[0],
				"islocal",
				true,
				"time",
				0.25,
				"easetype",
				"cigEaseType"
			}));
			yield break;
		}
		if (this.heatStage == 0)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject, "MoveTo");
			iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.cigPos[1],
				"islocal",
				true,
				"time",
				0.25,
				"easetype",
				"cigEaseType",
				"onComplete",
				"Heating",
				"onCompleteTarget",
				base.gameObject
			}));
			this.heatStage = 1;
			yield break;
		}
		if (this.heatStage == 1)
		{
			yield break;
		}
		if (this.heatStage == 2)
		{
			this.heatStage = 0;
		}
		yield break;
	}

	// Token: 0x06000AC4 RID: 2756 RVA: 0x000FAF9C File Offset: 0x000F939C
	public IEnumerator Heating()
	{
		yield return new WaitForSeconds(5f);
		this.heatStage = 2;
		iTween.MoveTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.cigPos[2],
			"islocal",
			true,
			"time",
			0.25,
			"easetype",
			"cigEaseType",
			"onComplete",
			"Heating",
			"onCompleteTarget",
			base.gameObject
		}));
		yield break;
	}

	// Token: 0x06000AC5 RID: 2757 RVA: 0x000FAFB7 File Offset: 0x000F93B7
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000AC6 RID: 2758 RVA: 0x000FAFE0 File Offset: 0x000F93E0
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.gameObject.transform.parent.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000ED7 RID: 3799
	public GameObject carLogic;

	// Token: 0x04000ED8 RID: 3800
	public Vector3[] cigPos = new Vector3[0];

	// Token: 0x04000ED9 RID: 3801
	private bool isGlowing;

	// Token: 0x04000EDA RID: 3802
	public Material startMaterial;

	// Token: 0x04000EDB RID: 3803
	public Material glowMaterial;

	// Token: 0x04000EDC RID: 3804
	public int heatStage;

	// Token: 0x04000EDD RID: 3805
	public string cigEaseType = string.Empty;

	// Token: 0x04000EDE RID: 3806
	public AudioClip errorAudio;
}
