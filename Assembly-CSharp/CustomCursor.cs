using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200000C RID: 12
public class CustomCursor : MonoBehaviour
{
	// Token: 0x06000026 RID: 38 RVA: 0x000039A7 File Offset: 0x00001DA7
	public void SetMiddle()
	{
		this.trans.anchoredPosition = new Vector2(0f, 0f);
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000039C4 File Offset: 0x00001DC4
	private void Update()
	{
		this.floats.x = Input.GetAxis("Horizontal");
		this.floats.y = Input.GetAxis("Vertical");
		if (!this.mainMenu)
		{
			if (Time.timeScale == 1E-45f)
			{
				this.visible = true;
			}
			else
			{
				this.visible = false;
			}
		}
		else
		{
			this.visible = true;
		}
		if (!this.visible)
		{
			if (base.transform.GetChild(0).gameObject.activeInHierarchy)
			{
				base.transform.GetChild(0).gameObject.SetActive(false);
			}
		}
		else if (!base.transform.GetChild(0).gameObject.activeInHierarchy)
		{
			base.transform.GetChild(0).gameObject.SetActive(true);
		}
		this.Move(this.floats);
		this.CastRay();
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00003ABC File Offset: 0x00001EBC
	private void Move(Vector2 velocity)
	{
		this.trans.anchoredPosition += velocity * this.moveSpeed;
		if (this.trans.anchoredPosition.y > this.canvasRect.sizeDelta.y / 2f + this.height)
		{
			this.trans.anchoredPosition = new Vector2(this.trans.anchoredPosition.x, this.canvasRect.sizeDelta.y / 2f + this.height);
		}
		if (this.trans.anchoredPosition.y < -this.canvasRect.sizeDelta.y / 2f - this.height)
		{
			this.trans.anchoredPosition = new Vector2(this.trans.anchoredPosition.x, -this.canvasRect.sizeDelta.y / 2f - this.height);
		}
		if (this.trans.anchoredPosition.x > this.canvasRect.sizeDelta.x / 2f + this.width)
		{
			this.trans.anchoredPosition = new Vector2(this.canvasRect.sizeDelta.x / 2f + this.width, this.trans.anchoredPosition.y);
		}
		if (this.trans.anchoredPosition.x < -this.canvasRect.sizeDelta.x / 2f - this.width)
		{
			this.trans.anchoredPosition = new Vector2(-this.canvasRect.sizeDelta.x / 2f - this.width, this.trans.anchoredPosition.y);
		}
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -20f);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00003D24 File Offset: 0x00002124
	private void Select(GameObject ob)
	{
		if (!this.visible)
		{
			EventSystem.current.SetSelectedGameObject(null);
			return;
		}
		if (ob.GetComponent<Button>() || ob.GetComponent<InputField>() || ob.GetComponent<Toggle>() || ob.GetComponent<Image>())
		{
			EventSystem.current.SetSelectedGameObject(ob);
		}
		else if (ob.GetComponent<Text>())
		{
			ob.GetComponent<Text>().raycastTarget = false;
			EventSystem.current.SetSelectedGameObject(ob.transform.parent.gameObject);
		}
		else
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00003DE0 File Offset: 0x000021E0
	private void CastRay()
	{
		if (this.aimingAt && this.aimingAt != this.lastAim)
		{
			this.lastAim = this.aimingAt;
			this.Select(this.aimingAt);
		}
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = this.trans.position;
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		if (list.Count > 0)
		{
			this.aimingAt = list[0].gameObject;
		}
	}

	// Token: 0x04000031 RID: 49
	public RectTransform canvasRect;

	// Token: 0x04000032 RID: 50
	public float width;

	// Token: 0x04000033 RID: 51
	public float height;

	// Token: 0x04000034 RID: 52
	public RectTransform trans;

	// Token: 0x04000035 RID: 53
	public float moveSpeed = 2f;

	// Token: 0x04000036 RID: 54
	public GameObject aimingAt;

	// Token: 0x04000037 RID: 55
	private GameObject lastAim;

	// Token: 0x04000038 RID: 56
	public bool visible;

	// Token: 0x04000039 RID: 57
	public bool mainMenu;

	// Token: 0x0400003A RID: 58
	public Vector2 floats;
}
