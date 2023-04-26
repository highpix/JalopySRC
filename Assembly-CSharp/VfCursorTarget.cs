using System;
using UnityEngine;

// Token: 0x0200015F RID: 351
[AddComponentMenu("Cursors/Cursor Target")]
public class VfCursorTarget : MonoBehaviour
{
	// Token: 0x06000D7C RID: 3452 RVA: 0x001322CE File Offset: 0x001306CE
	public void Reset()
	{
		this.CursorIndex = 0;
		this.LabelText = null;
		this.ApplyToChildren = false;
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x001322E8 File Offset: 0x001306E8
	public void Start()
	{
		this._cursorManager = UnityEngine.Object.FindObjectOfType<VfCursorManager>();
		this._labelManager = UnityEngine.Object.FindObjectOfType<VfLabelManager>();
		if (this.ApplyToChildren)
		{
			Collider[] componentsInChildren = base.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				if (collider.gameObject.GetComponent<VfCursorTarget>() == null)
				{
					VfCursorTarget vfCursorTarget = collider.gameObject.AddComponent<VfCursorTarget>();
					vfCursorTarget.CopySettings(this);
				}
			}
		}
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x00132362 File Offset: 0x00130762
	private void CopySettings(VfCursorTarget other)
	{
		this.CursorIndex = other.CursorIndex;
		this.LabelText = other.LabelText;
		this.IsMouseOver = other.IsMouseOver;
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x00132388 File Offset: 0x00130788
	public void OnMouseEnter()
	{
		this.IsMouseOver = true;
		if (this._cursorManager != null)
		{
			this._cursorManager.SetCursor(this.CursorIndex);
		}
		if (this._labelManager != null)
		{
			this._labelManager.LabelText = this.LabelText;
		}
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x001323E0 File Offset: 0x001307E0
	public void OnMouseExit()
	{
		this.IsMouseOver = false;
		if (this._cursorManager != null)
		{
			this._cursorManager.SetCursor(this._cursorManager.DefaultCursorIndex);
		}
		if (this._labelManager != null)
		{
			this._labelManager.LabelText = null;
		}
	}

	// Token: 0x04001216 RID: 4630
	public int CursorIndex;

	// Token: 0x04001217 RID: 4631
	public string LabelText;

	// Token: 0x04001218 RID: 4632
	public bool ApplyToChildren;

	// Token: 0x04001219 RID: 4633
	[HideInInspector]
	public bool IsMouseOver;

	// Token: 0x0400121A RID: 4634
	private VfCursorManager _cursorManager;

	// Token: 0x0400121B RID: 4635
	private VfLabelManager _labelManager;
}
