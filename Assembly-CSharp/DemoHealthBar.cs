using System;
using UnityEngine;

// Token: 0x0200015A RID: 346
public class DemoHealthBar : MonoBehaviour
{
	// Token: 0x06000D61 RID: 3425 RVA: 0x00131A9C File Offset: 0x0012FE9C
	public void Start()
	{
		if (this.Health == 0)
		{
			this.Health = UnityEngine.Random.Range(10, 90);
		}
		this._bkg = new Texture2D(1, 1, TextureFormat.ARGB32, false, false);
		this._bkg.SetPixel(0, 0, new Color(0f, 0f, 0f, 0.5f));
		this._bkg.Apply();
		this._bkg2 = new Texture2D(1, 1, TextureFormat.ARGB32, false, false);
		this._bkg2.SetPixel(0, 0, new Color(1f, 0f, 0f, 0.25f));
		this._bkg2.Apply();
		this._fg = new Texture2D(1, 1, TextureFormat.ARGB32, false, false);
		this._fg.SetPixel(0, 0, Color.red);
		this._fg.Apply();
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x00131B72 File Offset: 0x0012FF72
	public void Update()
	{
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x00131B74 File Offset: 0x0012FF74
	public void OnMouseEnter()
	{
		this._mouseOver = true;
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x00131B7D File Offset: 0x0012FF7D
	public void OnMouseExit()
	{
		this._mouseOver = false;
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x00131B88 File Offset: 0x0012FF88
	public void OnGUI()
	{
		if (!this._mouseOver)
		{
			return;
		}
		float num = Input.mousePosition.x + this.Offset.x - 52f;
		float num2 = (float)Screen.height - Input.mousePosition.y + this.Offset.y - 8f;
		GUI.DrawTexture(new Rect(num, num2, 104f, 16f), this._bkg);
		GUI.DrawTexture(new Rect(num + 2f, num2 + 2f, 100f, 12f), this._bkg2);
		GUI.DrawTexture(new Rect(num + 2f, num2 + 2f, (float)this.Health, 12f), this._fg);
	}

	// Token: 0x040011F6 RID: 4598
	public int Health;

	// Token: 0x040011F7 RID: 4599
	public Vector2 Offset;

	// Token: 0x040011F8 RID: 4600
	private bool _mouseOver;

	// Token: 0x040011F9 RID: 4601
	private Texture2D _bkg;

	// Token: 0x040011FA RID: 4602
	private Texture2D _bkg2;

	// Token: 0x040011FB RID: 4603
	private Texture2D _fg;
}
