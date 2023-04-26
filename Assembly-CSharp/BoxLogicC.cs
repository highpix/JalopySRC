using System;
using UnityEngine;

// Token: 0x02000093 RID: 147
public class BoxLogicC : MonoBehaviour
{
	// Token: 0x06000496 RID: 1174 RVA: 0x0004E420 File Offset: 0x0004C820
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.startMaterial = this.renderTargets[0].GetComponent<Renderer>().material;
		base.GetComponent<Collider>().enabled = false;
		base.GetComponent<Collider>().enabled = true;
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x0004E470 File Offset: 0x0004C870
	private void Reset()
	{
		BoxLogic component = base.GetComponent<BoxLogic>();
		this.debugOpen = component.debugOpen;
		this.debugDie = component.debugDie;
		this.audioOpen = component.audioOpen;
		component.renderTargets.Copy(ref this.renderTargets);
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.openTimer = component.openTimer;
		this.readyToOpen = component.readyToOpen;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x0004E4F0 File Offset: 0x0004C8F0
	private void Update()
	{
		if (this.isGlowing)
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
				gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
		if ((double)this.openTimer >= 0.7 && !this.debugOpen)
		{
			this.debugOpen = true;
			UnityEngine.Object.Destroy(base.GetComponent<BoxCollider>());
			UnityEngine.Object.Destroy(base.transform.parent.GetComponent<Rigidbody>());
			UnityEngine.Object.Destroy(base.transform.parent.GetComponent<BoxCollider>());
		}
		if (Input.GetButton("Fire1") && (double)this.openTimer < 0.7 && this.readyToOpen)
		{
			this.openTimer += Time.deltaTime;
		}
		else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) && (double)this.openTimer < 0.7 && this.readyToOpen)
		{
			this.openTimer += Time.deltaTime;
		}
		else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[17]) && (double)this.openTimer < 0.7 && this.readyToOpen)
		{
			this.openTimer += Time.deltaTime;
		}
		if (Input.GetButtonUp("Fire1") && !this.debugOpen && this.readyToOpen)
		{
			this.StopOpen();
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) && !this.debugOpen && this.readyToOpen)
		{
			this.StopOpen();
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17]) && !this.debugOpen && this.readyToOpen)
		{
			this.StopOpen();
		}
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x0004E728 File Offset: 0x0004CB28
	public void StopOpen()
	{
		this.openTimer = 0f;
		base.transform.parent.GetComponent<AudioSource>().Stop();
		base.transform.parent.gameObject.GetComponent<Animator>().SetBool("Open", false);
		this.readyToOpen = false;
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x0004E77C File Offset: 0x0004CB7C
	public void Trigger()
	{
		if (!this.debugOpen && base.transform.root == base.transform.parent && !this.readyToOpen)
		{
			this.readyToOpen = true;
			base.transform.parent.gameObject.GetComponent<Animator>().SetBool("Open", true);
			base.transform.parent.GetComponent<AudioSource>().clip = this.audioOpen;
			base.transform.parent.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x0004E816 File Offset: 0x0004CC16
	public void IntoInventory()
	{
		base.GetComponent<Collider>().enabled = false;
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x0004E824 File Offset: 0x0004CC24
	public void OutOfInventory()
	{
		base.GetComponent<Collider>().enabled = true;
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x0004E834 File Offset: 0x0004CC34
	public void RaycastEnter()
	{
		if (base.transform.root == base.transform.parent)
		{
			this.isGlowing = true;
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material = this.glowMaterial;
			}
		}
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x0004E898 File Offset: 0x0004CC98
	public void RaycastExit()
	{
		if (base.transform.root == base.transform.parent)
		{
			this.isGlowing = false;
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material = this.startMaterial;
			}
		}
	}

	// Token: 0x040006AC RID: 1708
	private GameObject director;

	// Token: 0x040006AD RID: 1709
	public bool debugOpen;

	// Token: 0x040006AE RID: 1710
	public bool debugDie;

	// Token: 0x040006AF RID: 1711
	private GameObject _camera;

	// Token: 0x040006B0 RID: 1712
	public AudioClip audioOpen;

	// Token: 0x040006B1 RID: 1713
	public GameObject[] renderTargets = new GameObject[0];

	// Token: 0x040006B2 RID: 1714
	public Material startMaterial;

	// Token: 0x040006B3 RID: 1715
	public Material glowMaterial;

	// Token: 0x040006B4 RID: 1716
	private bool isGlowing;

	// Token: 0x040006B5 RID: 1717
	public float openTimer;

	// Token: 0x040006B6 RID: 1718
	public bool readyToOpen;
}
