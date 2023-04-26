using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
public class MotelPlayerTriggerC : MonoBehaviour
{
	// Token: 0x0600014C RID: 332 RVA: 0x000163D4 File Offset: 0x000147D4
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		base.gameObject.layer = 0;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x000163F4 File Offset: 0x000147F4
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			if (base.transform.parent.GetComponent<ShopC>())
			{
				if (base.transform.parent.GetComponent<ShopC>().player == null)
				{
					base.transform.parent.GetComponent<ShopC>().player = this._camera.gameObject;
				}
				base.gameObject.GetComponent<BoxCollider>().center = new Vector3(7.776019f, 1.37f, -0.3360187f);
				base.gameObject.GetComponent<BoxCollider>().size = new Vector3(13.06786f, 1.120261f, 5.601358f);
			}
			else if (base.transform.parent.GetComponent<MotelLogicC>())
			{
				if (base.transform.parent.GetComponent<MotelLogicC>().player == null)
				{
					base.transform.parent.GetComponent<MotelLogicC>().player = this._camera.gameObject;
				}
				base.gameObject.GetComponent<BoxCollider>().enabled = false;
			}
			base.transform.parent.SendMessage("PlayerTriggerEnter");
		}
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00016540 File Offset: 0x00014940
	private void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player")
		{
			if (base.transform.parent.GetComponent<ShopC>())
			{
				if (base.transform.parent.GetComponent<ShopC>().player == null)
				{
					base.transform.parent.GetComponent<ShopC>().player = this._camera.gameObject;
				}
			}
			else if (base.transform.parent.GetComponent<MotelLogicC>() && base.transform.parent.GetComponent<MotelLogicC>().player == null)
			{
				base.transform.parent.GetComponent<MotelLogicC>().player = this._camera.gameObject;
			}
			base.transform.parent.SendMessage("PlayerTriggerExit");
		}
	}

	// Token: 0x0400026C RID: 620
	private GameObject _camera;
}
