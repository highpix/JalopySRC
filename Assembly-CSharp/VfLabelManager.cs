using System;
using UnityEngine;

// Token: 0x02000160 RID: 352
[AddComponentMenu("Cursors/Label Manager")]
public class VfLabelManager : MonoBehaviour
{
	// Token: 0x17000050 RID: 80
	// (get) Token: 0x06000D82 RID: 3458 RVA: 0x00132492 File Offset: 0x00130892
	// (set) Token: 0x06000D83 RID: 3459 RVA: 0x0013249A File Offset: 0x0013089A
	public string LabelText
	{
		get
		{
			return this._labelText;
		}
		set
		{
			this._labelText = value;
			this._textDirty = true;
		}
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x001324AC File Offset: 0x001308AC
	public void Reset()
	{
		this.ShowLabels = true;
		this.LabelSettings = new LabelSettings();
		this.KeepOnScreen = true;
		this.CanChangeAnchor = true;
		this.CursorSize = new Vector2(32f, 32f);
		this.HotSpot = Vector2.zero;
		this.LabelText = null;
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x00132500 File Offset: 0x00130900
	public void OnGUI()
	{
		if (string.IsNullOrEmpty(this._labelText))
		{
			return;
		}
		if (this._textDirty || this.NeedStyleUpdate)
		{
			this.UpdateStyle();
		}
		bool wordWrap = this._style.wordWrap;
		this._style.wordWrap = true;
		Rect rect = default(Rect);
		this.CalculateRect(this.LabelSettings.Anchor, ref rect);
		rect = this.EnsureRectIsOnScreen(rect);
		GUI.Label(rect, this._labelText, this._style);
		this._style.wordWrap = wordWrap;
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x00132594 File Offset: 0x00130994
	private Rect EnsureRectIsOnScreen(Rect rect)
	{
		if (this.KeepOnScreen && this.IsOffScreen(rect))
		{
			if (this.CanChangeAnchor)
			{
				this.RepositionLabel(ref rect);
			}
			this.ClampToScreen(ref rect);
		}
		return rect;
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x001325CC File Offset: 0x001309CC
	private void UpdateStyle()
	{
		if (this.NeedStyleUpdate)
		{
			GUISkin skin = GUI.skin;
			GUI.skin = this.LabelSettings.Skin;
			this._style = GUI.skin.FindStyle(this.LabelSettings.GuiStyleName);
			GUI.skin = skin;
		}
		bool wordWrap = this._style.wordWrap;
		this._style.wordWrap = true;
		this._guirect = this.CalculateLayoutRectangle(new GUIContent(this._labelText), this._style);
		this._style.wordWrap = wordWrap;
		if (this._guirect.width > 1f)
		{
			this._textDirty = false;
		}
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000D88 RID: 3464 RVA: 0x00132678 File Offset: 0x00130A78
	private bool NeedStyleUpdate
	{
		get
		{
			if (this._style == null)
			{
				return true;
			}
			if (this.LabelSettings.Skin != this._lastSkin)
			{
				this._lastSkin = this.LabelSettings.Skin;
				return true;
			}
			return false;
		}
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x001326B8 File Offset: 0x00130AB8
	private bool IsOffScreen(Rect rect)
	{
		return rect.x < 0f || rect.y < 0f || rect.xMax > (float)Screen.width || rect.yMax > (float)Screen.height;
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x0013270C File Offset: 0x00130B0C
	private void RepositionLabel(ref Rect rect)
	{
		TextAnchor anchor = this.LabelSettings.Anchor;
		switch (anchor)
		{
		case TextAnchor.UpperLeft:
			anchor = TextAnchor.LowerRight;
			break;
		case TextAnchor.UpperCenter:
			anchor = TextAnchor.LowerCenter;
			break;
		case TextAnchor.UpperRight:
			anchor = TextAnchor.LowerLeft;
			break;
		case TextAnchor.MiddleLeft:
			anchor = TextAnchor.MiddleRight;
			break;
		case TextAnchor.MiddleCenter:
			anchor = TextAnchor.MiddleCenter;
			break;
		case TextAnchor.MiddleRight:
			anchor = TextAnchor.MiddleLeft;
			break;
		case TextAnchor.LowerLeft:
			anchor = TextAnchor.UpperRight;
			break;
		case TextAnchor.LowerCenter:
			anchor = TextAnchor.UpperCenter;
			break;
		case TextAnchor.LowerRight:
			anchor = TextAnchor.UpperLeft;
			break;
		}
		this.CalculateRect(anchor, ref rect);
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x0013279C File Offset: 0x00130B9C
	private Rect CalculateRect(TextAnchor anchor, ref Rect rect)
	{
		Vector2 offset = this.GetOffset(anchor);
		float num = Input.mousePosition.x + offset.x;
		float num2 = (float)Screen.height - Input.mousePosition.y + offset.y;
		this.OffsetRectangle(this._guirect, ref num, ref num2, anchor);
		rect.x = this._guirect.x + num;
		rect.y = this._guirect.y + num2;
		rect.width = this._guirect.width;
		rect.height = this._guirect.height;
		return rect;
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x00132844 File Offset: 0x00130C44
	private Vector2 GetOffset(TextAnchor anchor)
	{
		float x = -this.HotSpot.x - this.LabelSettings.CursorMargin.x;
		float x2 = this.CursorSize.x - this.HotSpot.x + this.LabelSettings.CursorMargin.x;
		float y = this.CursorSize.y - this.HotSpot.y + this.LabelSettings.CursorMargin.y;
		float y2 = -this.HotSpot.y - this.LabelSettings.CursorMargin.y;
		switch (anchor)
		{
		case TextAnchor.UpperLeft:
			return new Vector2(x, y2);
		case TextAnchor.UpperCenter:
			return new Vector2(0f, y2);
		case TextAnchor.UpperRight:
			return new Vector2(x2, y2);
		case TextAnchor.MiddleLeft:
			return new Vector2(x, 0f);
		case TextAnchor.MiddleRight:
			return new Vector2(x2, 0f);
		case TextAnchor.LowerLeft:
			return new Vector2(x, y);
		case TextAnchor.LowerCenter:
			return new Vector2(0f, y);
		case TextAnchor.LowerRight:
			return new Vector2(x2, y);
		}
		return new Vector2(0f, 0f);
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x00132970 File Offset: 0x00130D70
	private void ClampToScreen(ref Rect rect)
	{
		if (rect.x < this.LabelSettings.ScreenMargin.x)
		{
			rect.x = this.LabelSettings.ScreenMargin.x;
		}
		if (rect.xMax > (float)Screen.width - this.LabelSettings.ScreenMargin.x)
		{
			rect.x -= rect.xMax - (float)Screen.width + this.LabelSettings.ScreenMargin.x;
		}
		if (rect.y < this.LabelSettings.ScreenMargin.y)
		{
			rect.y = this.LabelSettings.ScreenMargin.y;
		}
		if (rect.yMax > (float)Screen.height - this.LabelSettings.ScreenMargin.y)
		{
			rect.y -= rect.yMax - (float)Screen.height + this.LabelSettings.ScreenMargin.y;
		}
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x00132A7C File Offset: 0x00130E7C
	private Rect CalculateLayoutRectangle(GUIContent content, GUIStyle style)
	{
		Rect rect = GUILayoutUtility.GetRect(content, style);
		if (rect.width > (float)this.LabelSettings.MaxWidth)
		{
			rect.width = (float)this.LabelSettings.MaxWidth;
		}
		float height = style.CalcHeight(content, rect.width);
		rect.height = height;
		if (this.LabelSettings.MaxHeight > 0 && rect.height > (float)this.LabelSettings.MaxHeight)
		{
			rect.height = (float)this.LabelSettings.MaxHeight;
		}
		return rect;
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x00132B10 File Offset: 0x00130F10
	private void OffsetRectangle(Rect guirect, ref float xOfs, ref float yOfs, TextAnchor anchor)
	{
		switch (anchor)
		{
		case TextAnchor.UpperLeft:
			xOfs -= guirect.width;
			yOfs -= guirect.height;
			break;
		case TextAnchor.UpperCenter:
			xOfs -= guirect.width / 2f;
			yOfs -= guirect.height;
			break;
		case TextAnchor.UpperRight:
			yOfs -= guirect.height;
			break;
		case TextAnchor.MiddleLeft:
			xOfs -= guirect.width;
			yOfs -= guirect.height / 2f;
			break;
		case TextAnchor.MiddleCenter:
			xOfs -= guirect.width / 2f;
			yOfs -= guirect.height / 2f;
			break;
		case TextAnchor.MiddleRight:
			yOfs -= guirect.height / 2f;
			break;
		case TextAnchor.LowerLeft:
			xOfs -= guirect.width;
			break;
		case TextAnchor.LowerCenter:
			xOfs -= guirect.width / 2f;
			break;
		}
	}

	// Token: 0x0400121C RID: 4636
	public bool ShowLabels = true;

	// Token: 0x0400121D RID: 4637
	public LabelSettings LabelSettings = new LabelSettings();

	// Token: 0x0400121E RID: 4638
	public bool KeepOnScreen = true;

	// Token: 0x0400121F RID: 4639
	public bool CanChangeAnchor = true;

	// Token: 0x04001220 RID: 4640
	public Vector2 CursorSize = new Vector2(32f, 32f);

	// Token: 0x04001221 RID: 4641
	public Vector2 HotSpot = Vector2.zero;

	// Token: 0x04001222 RID: 4642
	private string _labelText;

	// Token: 0x04001223 RID: 4643
	private Rect _guirect;

	// Token: 0x04001224 RID: 4644
	private bool _textDirty = true;

	// Token: 0x04001225 RID: 4645
	private GUIStyle _style;

	// Token: 0x04001226 RID: 4646
	private GUISkin _lastSkin;
}
