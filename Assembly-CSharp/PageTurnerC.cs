using System;
using UnityEngine;

// Token: 0x020000E2 RID: 226
public class PageTurnerC : MonoBehaviour
{
	// Token: 0x060008DC RID: 2268 RVA: 0x000BEED0 File Offset: 0x000BD2D0
	private void Start()
	{
		if (this.xboxPrompt)
		{
			this.xboxPrompt.SetActive(Application.platform == RuntimePlatform.XboxOne);
		}
		this._camera = Camera.main.gameObject;
		if (this.spriteTarget == null && base.GetComponentInChildren<SpriteRenderer>())
		{
			this.spriteTarget = base.transform.GetChild(0).gameObject;
		}
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x000BEF4C File Offset: 0x000BD34C
	private void Update()
	{
		if (this.spriteTarget != null)
		{
			if (!base.GetComponent<SphereCollider>().enabled && this.spriteTarget.active)
			{
				this.spriteTarget.active = false;
				return;
			}
			if (!this.spriteTarget.active && base.GetComponent<SphereCollider>().enabled)
			{
				this.spriteTarget.active = true;
			}
			this.spriteTarget.transform.LookAt(this._camera.transform.position, -Vector3.up);
			if (this.spriteTimer > this.spriteTimerCheck)
			{
				if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[0])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[1];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[1])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[2];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[2])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[3];
				}
				else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[3])
				{
					this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
				}
				this.spriteTimer = 0f;
			}
			this.spriteTimer += Time.deltaTime;
			if (base.gameObject.activeInHierarchy && Input.GetKeyDown((!this.isRight) ? KeyCode.JoystickButton4 : KeyCode.JoystickButton5))
			{
				this.Trigger();
			}
		}
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x000BF14C File Offset: 0x000BD54C
	public void Trigger()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		if (!gameObject.GetComponent<Scene1_LogicC>().mainManualPageTurnTutFinished)
		{
			gameObject.GetComponent<Scene1_LogicC>().SendMessage("ManualPageTurned");
		}
		if (base.transform.parent.gameObject.GetComponent<PageLogicC>().pageReturner != null)
		{
			base.transform.parent.gameObject.GetComponent<PageLogicC>().pageReturner.active = true;
		}
		base.transform.parent.gameObject.GetComponent<Animator>().SetBool("isPageTurned", true);
		base.transform.parent.gameObject.GetComponent<Animator>().SetBool("isHoverCorner", false);
		base.transform.parent.gameObject.GetComponent<PageLogicC>().TurnPage();
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x000BF223 File Offset: 0x000BD623
	public void RaycastEnter()
	{
		base.transform.parent.gameObject.GetComponent<Animator>().SetBool("isHoverCorner", true);
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x000BF245 File Offset: 0x000BD645
	public void RaycastExit()
	{
		base.transform.parent.gameObject.GetComponent<Animator>().SetBool("isHoverCorner", false);
	}

	// Token: 0x04000BCA RID: 3018
	private GameObject _camera;

	// Token: 0x04000BCB RID: 3019
	public GameObject nextPage;

	// Token: 0x04000BCC RID: 3020
	public GameObject spriteTarget;

	// Token: 0x04000BCD RID: 3021
	public Sprite[] sprites = new Sprite[0];

	// Token: 0x04000BCE RID: 3022
	public float spriteTimer;

	// Token: 0x04000BCF RID: 3023
	public float spriteTimerCheck = 0.15f;

	// Token: 0x04000BD0 RID: 3024
	public bool isRight;

	// Token: 0x04000BD1 RID: 3025
	public GameObject xboxPrompt;
}
