using System;
using UnityEngine;

// Token: 0x0200009F RID: 159
public class ColliderBriefcaseLogicC : MonoBehaviour
{
	// Token: 0x06000524 RID: 1316 RVA: 0x000580A2 File Offset: 0x000564A2
	private void Start()
	{
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x000580B4 File Offset: 0x000564B4
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x000580FD File Offset: 0x000564FD
	public void Trigger()
	{
		if (this.openCloseObject.GetComponent<OpenBriefcaseLogicC>().currentPos == 1)
		{
			this.openCloseObject.GetComponent<OpenBriefcaseLogicC>().CloseBreifcase();
			this.CloseStateGo();
		}
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x0005812B File Offset: 0x0005652B
	public void OpenStateGo()
	{
		base.gameObject.tag = "Interactor";
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x00058140 File Offset: 0x00056540
	public void CloseStateGo()
	{
		base.gameObject.tag = "Untagged";
		if (!base.transform.parent.gameObject.GetComponent<Rigidbody>())
		{
			base.transform.parent.gameObject.AddComponent<Rigidbody>();
			base.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			base.transform.parent.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
		}
		this.twinObject.GetComponent<ColliderBriefcaseLogicC>().CloseTwin();
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x000581D8 File Offset: 0x000565D8
	public void ReturnPickupFunctionality()
	{
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x000581DA File Offset: 0x000565DA
	public void CloseTwin()
	{
		base.gameObject.tag = "Untagged";
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x000581EC File Offset: 0x000565EC
	public void OnMouseOver()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().cursors[0].gameObject.active)
		{
			this.isGlowing = true;
			base.gameObject.GetComponent<Renderer>().material = this.glowMaterial;
			this.twinObject.GetComponent<Renderer>().material = this.glowMaterial;
		}
		else if (this.isGlowing)
		{
			this.isGlowing = false;
			base.gameObject.GetComponent<Renderer>().material = this.startMaterial;
			this.twinObject.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00058290 File Offset: 0x00056690
	public void OnMouseExit()
	{
		this.isGlowing = false;
		base.gameObject.GetComponent<Renderer>().material = this.startMaterial;
		this.twinObject.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x0400079A RID: 1946
	private GameObject _camera;

	// Token: 0x0400079B RID: 1947
	public GameObject openCloseObject;

	// Token: 0x0400079C RID: 1948
	public GameObject twinObject;

	// Token: 0x0400079D RID: 1949
	private bool isGlowing;

	// Token: 0x0400079E RID: 1950
	public Material glowMaterial;

	// Token: 0x0400079F RID: 1951
	public Material startMaterial;
}
