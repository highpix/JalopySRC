using System;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class MenuMouseInteractionsC : MonoBehaviour
{
	// Token: 0x0600082A RID: 2090 RVA: 0x000AACB8 File Offset: 0x000A90B8
	private void Start()
	{
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x000AACCC File Offset: 0x000A90CC
	private void Update()
	{
		if (!this.currentlyInMenu && !this.restrictRay)
		{
			Ray ray = base.gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				if (this.lastHitInteractor != null)
				{
					this.lastHitInteractor.SendMessage("RaycastExit");
				}
				if (raycastHit.collider.tag == "Pickup")
				{
					raycastHit.collider.SendMessage("RaycastEnter");
					this.lastHitInteractor = raycastHit.collider.gameObject;
					if (MainMenuC.Global)
					{
						if (Input.GetKeyDown("mouse 0") || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) || Input.GetButtonDown("Fire1"))
						{
							raycastHit.collider.gameObject.SendMessage("Action");
							this.currentlyInMenu = true;
							raycastHit.collider.SendMessage("RaycastExit");
							this.lastHitInteractor = null;
						}
					}
					else if (this.map != null && (Input.GetKeyDown("mouse 0") || Input.GetKeyDown(this.map.GetComponent<MainMenuBookC>().assignedInputStrings[16]) || Input.GetKeyDown(this.map.GetComponent<MainMenuBookC>().assignedInputStrings[17]) || Input.GetButtonDown("Fire1")))
					{
						raycastHit.collider.gameObject.SendMessage("Action");
						this.currentlyInMenu = true;
						raycastHit.collider.SendMessage("RaycastExit");
						this.lastHitInteractor = null;
					}
					return;
				}
			}
			if (this.lastHitInteractor != null)
			{
				this.lastHitInteractor.SendMessage("RaycastExit");
			}
			this.lastHitInteractor = null;
		}
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x000AAED3 File Offset: 0x000A92D3
	public void ExitMenu()
	{
		this.currentlyInMenu = false;
	}

	// Token: 0x04000ACA RID: 2762
	private GameObject _camera;

	// Token: 0x04000ACB RID: 2763
	private GameObject lastHitInteractor;

	// Token: 0x04000ACC RID: 2764
	public bool restrictRay;

	// Token: 0x04000ACD RID: 2765
	public bool currentlyInMenu;

	// Token: 0x04000ACE RID: 2766
	public int padInput;

	// Token: 0x04000ACF RID: 2767
	public GameObject map;
}
