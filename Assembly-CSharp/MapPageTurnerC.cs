using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000CD RID: 205
public class MapPageTurnerC : MonoBehaviour
{
	// Token: 0x06000813 RID: 2067 RVA: 0x000A894C File Offset: 0x000A6D4C
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.map = base.transform.parent.transform.parent.gameObject;
		this.mapAnim = base.transform.parent.gameObject;
		int pageNumber = this.map.GetComponent<MapLogicC>().pageNumber;
		if (this.xboxPrompt && Application.platform != RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(this.xboxPrompt);
		}
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x000A89D8 File Offset: 0x000A6DD8
	private void Update()
	{
		if (this.spriteTarget != null)
		{
			if (!base.GetComponent<SphereCollider>().enabled && this.spriteTarget.active)
			{
				this.spriteTarget.active = false;
				if (this.xboxPrompt)
				{
					this.xboxPrompt.SetActive(false);
				}
				return;
			}
			if (!this.spriteTarget.active && base.GetComponent<SphereCollider>().enabled)
			{
				this.spriteTarget.active = true;
				if (this.xboxPrompt)
				{
					this.xboxPrompt.SetActive(true);
				}
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
			if (base.gameObject.activeInHierarchy && Application.platform == RuntimePlatform.XboxOne && Input.GetKeyDown((!this.isRight) ? KeyCode.JoystickButton4 : KeyCode.JoystickButton5))
			{
				this.Trigger();
			}
		}
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x000A8C1C File Offset: 0x000A701C
	public void Trigger()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		if (!gameObject.GetComponent<Scene1_LogicC>().hasGivenMapPageTurnTutorial)
		{
			gameObject.GetComponent<Scene1_LogicC>().StartCoroutine("MapPageTurnTutorial");
		}
		if (this.rightPage && !this.map.GetComponent<MapLogicC>().isTurningPage)
		{
			this.map.GetComponent<MapLogicC>().isTurningPage = true;
			base.StartCoroutine(this.TurnRight());
			return;
		}
		if (!this.rightPage && !this.map.GetComponent<MapLogicC>().isTurningPage)
		{
			this.map.GetComponent<MapLogicC>().isTurningPage = true;
			base.StartCoroutine(this.TurnLeft());
			return;
		}
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x000A8CD4 File Offset: 0x000A70D4
	public IEnumerator TurnRight()
	{
		int pageNumber = this.map.GetComponent<MapLogicC>().pageNumber;
		if (pageNumber == 0)
		{
			if (this.otherPage != null)
			{
				this.otherPage.gameObject.GetComponent<SphereCollider>().enabled = true;
			}
			base.StartCoroutine(this.map.GetComponent<MapLogicC>().Page1Go());
			this.mapAnim.GetComponent<Animator>().SetBool("page1FoldHover", false);
			this.mapAnim.GetComponent<Animator>().Play("Page1Turn");
			this.map.GetComponent<MapLogicC>().pageNumber++;
			if (this.isHovering)
			{
				this.RaycastEnter();
			}
			yield return new WaitForSeconds(1f);
			this.map.GetComponent<MapLogicC>().isTurningPage = false;
			yield break;
		}
		if (pageNumber == 1)
		{
			base.gameObject.GetComponent<SphereCollider>().enabled = false;
			int lastPageVal = pageNumber + 1;
			base.StartCoroutine(this.map.GetComponent<MapLogicC>().LastPageGo(lastPageVal));
			this.mapAnim.GetComponent<Animator>().SetBool("page2FoldHover", false);
			this.mapAnim.GetComponent<Animator>().Play("Page2Turn");
			this.map.GetComponent<MapLogicC>().pageNumber++;
			yield return new WaitForSeconds(1f);
			this.map.GetComponent<MapLogicC>().isTurningPage = false;
			yield break;
		}
		yield break;
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x000A8CF0 File Offset: 0x000A70F0
	public IEnumerator TurnLeft()
	{
		int pageNumber = this.map.GetComponent<MapLogicC>().pageNumber;
		if (pageNumber == 1)
		{
			base.gameObject.GetComponent<SphereCollider>().enabled = false;
			base.StartCoroutine(this.map.GetComponent<MapLogicC>().Page0Go());
			this.mapAnim.GetComponent<Animator>().SetBool("page2FoldBackHover", false);
			this.mapAnim.GetComponent<Animator>().Play("Page1TurnBack");
			this.map.GetComponent<MapLogicC>().pageNumber--;
			yield return new WaitForSeconds(1f);
			this.map.GetComponent<MapLogicC>().isTurningPage = false;
			yield break;
		}
		if (pageNumber >= 2)
		{
			this.otherPage.gameObject.GetComponent<SphereCollider>().enabled = true;
			int lastPageVal = pageNumber - 1;
			base.StartCoroutine(this.map.GetComponent<MapLogicC>().Page1Go());
			this.mapAnim.GetComponent<Animator>().SetBool("page3FoldBackHover", false);
			this.mapAnim.GetComponent<Animator>().Play("Page2TurnBack");
			this.map.GetComponent<MapLogicC>().pageNumber--;
			if (this.isHovering)
			{
				this.RaycastEnter();
			}
			yield return new WaitForSeconds(1f);
			this.map.GetComponent<MapLogicC>().isTurningPage = false;
			yield break;
		}
		yield break;
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x000A8D0C File Offset: 0x000A710C
	public void RaycastEnter()
	{
		int pageNumber = this.map.GetComponent<MapLogicC>().pageNumber;
		this.isHovering = true;
		if (pageNumber == 0 && this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page1FoldHover", true);
		}
		else if (pageNumber == 1 && this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page2FoldHover", true);
		}
		else if (pageNumber >= 1 && this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page3FoldHover", true);
		}
		else if (pageNumber == 1 && !this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page2FoldBackHover", true);
		}
		else if (pageNumber >= 2 && !this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page3FoldBackHover", true);
		}
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x000A8E0C File Offset: 0x000A720C
	public void RaycastExit()
	{
		this.isHovering = false;
		int pageNumber = this.map.GetComponent<MapLogicC>().pageNumber;
		if (pageNumber == 0 && this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page1FoldHover", false);
		}
		else if (pageNumber == 1 && this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page2FoldHover", false);
		}
		else if (pageNumber >= 1 && this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page3FoldHover", false);
		}
		else if (pageNumber == 1 && !this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page2FoldBackHover", false);
		}
		else if (pageNumber >= 2 && !this.rightPage)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page3FoldBackHover", false);
		}
	}

	// Token: 0x04000A89 RID: 2697
	private GameObject _camera;

	// Token: 0x04000A8A RID: 2698
	public bool rightPage;

	// Token: 0x04000A8B RID: 2699
	public GameObject map;

	// Token: 0x04000A8C RID: 2700
	public GameObject mapAnim;

	// Token: 0x04000A8D RID: 2701
	public GameObject otherPage;

	// Token: 0x04000A8E RID: 2702
	private bool isHovering;

	// Token: 0x04000A8F RID: 2703
	public GameObject spriteTarget;

	// Token: 0x04000A90 RID: 2704
	public Sprite[] sprites;

	// Token: 0x04000A91 RID: 2705
	public float spriteTimer;

	// Token: 0x04000A92 RID: 2706
	public float spriteTimerCheck = 0.15f;

	// Token: 0x04000A93 RID: 2707
	public GameObject xboxPrompt;

	// Token: 0x04000A94 RID: 2708
	public bool isRight;
}
