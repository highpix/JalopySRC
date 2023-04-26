using System;
using UnityEngine;

// Token: 0x02000043 RID: 67
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/Examples/UI Cursor")]
public class UICursor : MonoBehaviour
{
	// Token: 0x06000156 RID: 342 RVA: 0x000167DD File Offset: 0x00014BDD
	private void Awake()
	{
		UICursor.instance = this;
	}

	// Token: 0x06000157 RID: 343 RVA: 0x000167E5 File Offset: 0x00014BE5
	private void OnDestroy()
	{
		UICursor.instance = null;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x000167F0 File Offset: 0x00014BF0
	private void Start()
	{
		this.mTrans = base.transform;
		this.mSprite = base.GetComponentInChildren<UISprite>();
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		if (this.mSprite != null)
		{
			this.mAtlas = this.mSprite.atlas;
			this.mSpriteName = this.mSprite.spriteName;
			if (this.mSprite.depth < 100)
			{
				this.mSprite.depth = 100;
			}
		}
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00016890 File Offset: 0x00014C90
	private void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		if (this.uiCamera != null)
		{
			mousePosition.x = Mathf.Clamp01(mousePosition.x / (float)Screen.width);
			mousePosition.y = Mathf.Clamp01(mousePosition.y / (float)Screen.height);
			this.mTrans.position = this.uiCamera.ViewportToWorldPoint(mousePosition);
			if (this.uiCamera.orthographic)
			{
				Vector3 localPosition = this.mTrans.localPosition;
				localPosition.x = Mathf.Round(localPosition.x);
				localPosition.y = Mathf.Round(localPosition.y);
				this.mTrans.localPosition = localPosition;
			}
		}
		else
		{
			mousePosition.x -= (float)Screen.width * 0.5f;
			mousePosition.y -= (float)Screen.height * 0.5f;
			mousePosition.x = Mathf.Round(mousePosition.x);
			mousePosition.y = Mathf.Round(mousePosition.y);
			this.mTrans.localPosition = mousePosition;
		}
	}

	// Token: 0x0600015A RID: 346 RVA: 0x000169B8 File Offset: 0x00014DB8
	public static void Clear()
	{
		if (UICursor.instance != null && UICursor.instance.mSprite != null)
		{
			UICursor.Set(UICursor.instance.mAtlas, UICursor.instance.mSpriteName);
		}
	}

	// Token: 0x0600015B RID: 347 RVA: 0x000169F8 File Offset: 0x00014DF8
	public static void Set(UIAtlas atlas, string sprite)
	{
		if (UICursor.instance != null && UICursor.instance.mSprite)
		{
			UICursor.instance.mSprite.atlas = atlas;
			UICursor.instance.mSprite.spriteName = sprite;
			UICursor.instance.mSprite.MakePixelPerfect();
			UICursor.instance.Update();
		}
	}

	// Token: 0x04000270 RID: 624
	public static UICursor instance;

	// Token: 0x04000271 RID: 625
	public Camera uiCamera;

	// Token: 0x04000272 RID: 626
	private Transform mTrans;

	// Token: 0x04000273 RID: 627
	private UISprite mSprite;

	// Token: 0x04000274 RID: 628
	private UIAtlas mAtlas;

	// Token: 0x04000275 RID: 629
	private string mSpriteName;
}
