using System;
using UnityEngine;

// Token: 0x020000F2 RID: 242
public class ReverseDoorLogicC : MonoBehaviour
{
	// Token: 0x0600098A RID: 2442 RVA: 0x000E2937 File Offset: 0x000E0D37
	private void Start()
	{
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x000E2949 File Offset: 0x000E0D49
	public void Trigger()
	{
		base.StartCoroutine(this.doorHandle.GetComponent<EnvironmentDoorsC>().Trigger());
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x000E2964 File Offset: 0x000E0D64
	public void OnMouseOver()
	{
		if (!this._camera.GetComponent<DragRigidbodyC>().cursors[2].gameObject.active)
		{
			this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing = true;
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle != null)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().handle.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().glowMaterial;
			}
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2 != null)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().glowMaterial;
			}
			return;
		}
		if (this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing)
		{
			this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing = false;
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle != null)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().handle.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial;
			}
			if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2 != null)
			{
				this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial2;
			}
			return;
		}
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x000E2AE0 File Offset: 0x000E0EE0
	public void OnMouseExit()
	{
		this.doorHandle.GetComponent<EnvironmentDoorsC>().isGlowing = false;
		if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle != null)
		{
			this.doorHandle.GetComponent<EnvironmentDoorsC>().handle.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial;
		}
		if (this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2 != null)
		{
			this.doorHandle.GetComponent<EnvironmentDoorsC>().handle2.GetComponent<Renderer>().material = this.doorHandle.GetComponent<EnvironmentDoorsC>().startMaterial2;
		}
	}

	// Token: 0x04000D0D RID: 3341
	public GameObject doorHandle;

	// Token: 0x04000D0E RID: 3342
	private GameObject _camera;
}
