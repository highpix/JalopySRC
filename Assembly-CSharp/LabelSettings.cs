using System;
using UnityEngine;

// Token: 0x0200015B RID: 347
[Serializable]
public class LabelSettings
{
	// Token: 0x040011FC RID: 4604
	public GUISkin Skin;

	// Token: 0x040011FD RID: 4605
	public string GuiStyleName = "box";

	// Token: 0x040011FE RID: 4606
	public TextAnchor Anchor = TextAnchor.LowerCenter;

	// Token: 0x040011FF RID: 4607
	public Vector2 ScreenMargin = new Vector2(8f, 8f);

	// Token: 0x04001200 RID: 4608
	public Vector2 CursorMargin = new Vector2(8f, 8f);

	// Token: 0x04001201 RID: 4609
	public int MaxWidth = 300;

	// Token: 0x04001202 RID: 4610
	public int MaxHeight;
}
