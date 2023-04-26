using System;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class OvenDialC : MonoBehaviour
{
	// Token: 0x060008AD RID: 2221 RVA: 0x000BD6FD File Offset: 0x000BBAFD
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x000BD728 File Offset: 0x000BBB28
	private void Reset()
	{
		OvenDial component = base.GetComponent<OvenDial>();
		this.openTimeToComplete = component.openTimeToComplete;
		this.closeTimeToComplete = component.closeTimeToComplete;
		this.currentPos = component.currentPos;
		this.turnAmountNegative = component.turnAmountNegative;
		this.turnAmountPositive = component.turnAmountPositive;
		this.dialAudio = component.dialAudio;
		this.dialOffAudio = component.dialOffAudio;
		this.glowMaterial = component.glowMaterial;
		this.startMaterial = component.startMaterial;
		this.easeType = component.easeType;
		this.easeType2 = component.easeType2;
		this.errorAudio = component.errorAudio;
		this.target = (component.target as GameObject);
		this.hotTap = component.hotTap;
		component.enabled = false;
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x000BD7F0 File Offset: 0x000BBBF0
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x000BD834 File Offset: 0x000BBC34
	public void Trigger()
	{
		if (base.transform.root.gameObject.GetComponent<Rigidbody>())
		{
			UnityEngine.Object.Destroy(base.transform.root.gameObject.GetComponent<Rigidbody>());
		}
		if (this.currentPos == 0)
		{
			iTween.Stop(base.gameObject);
			this.currentPos = 1;
			iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
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
				"TriggerLogicOn",
				"onCompleteTarget",
				base.gameObject
			}));
			base.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.dialAudio, 0.7f);
			return;
		}
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject);
			this.currentPos = 0;
			iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
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
				"TriggerLogicOff",
				"onCompleteTarget",
				base.gameObject
			}));
			base.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.dialOffAudio, 0.7f);
			return;
		}
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x000BDA09 File Offset: 0x000BBE09
	public void TriggerLogicOn()
	{
		if (this.target == null)
		{
			return;
		}
		if (this.hotTap)
		{
			this.target.SendMessage("HotTapOn");
			return;
		}
		this.target.SendMessage("TriggerOn");
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x000BDA49 File Offset: 0x000BBE49
	public void TriggerLogicOff()
	{
		if (this.target == null)
		{
			return;
		}
		if (this.hotTap)
		{
			this.target.SendMessage("HotTapOff");
			return;
		}
		this.target.SendMessage("TriggerOff");
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x000BDA8C File Offset: 0x000BBE8C
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

	// Token: 0x060008B4 RID: 2228 RVA: 0x000BDAFA File Offset: 0x000BBEFA
	public void OnMouseExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000B90 RID: 2960
	private GameObject _camera;

	// Token: 0x04000B91 RID: 2961
	public float openTimeToComplete = 1.05f;

	// Token: 0x04000B92 RID: 2962
	public float closeTimeToComplete = 0.75f;

	// Token: 0x04000B93 RID: 2963
	public int currentPos;

	// Token: 0x04000B94 RID: 2964
	public float turnAmountNegative;

	// Token: 0x04000B95 RID: 2965
	public float turnAmountPositive;

	// Token: 0x04000B96 RID: 2966
	public AudioClip dialAudio;

	// Token: 0x04000B97 RID: 2967
	public AudioClip dialOffAudio;

	// Token: 0x04000B98 RID: 2968
	public Material glowMaterial;

	// Token: 0x04000B99 RID: 2969
	public Material startMaterial;

	// Token: 0x04000B9A RID: 2970
	public string easeType = "easeoutelastic";

	// Token: 0x04000B9B RID: 2971
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000B9C RID: 2972
	public AudioClip errorAudio;

	// Token: 0x04000B9D RID: 2973
	public GameObject target;

	// Token: 0x04000B9E RID: 2974
	public bool hotTap;

	// Token: 0x04000B9F RID: 2975
	private bool isGlowing;
}
