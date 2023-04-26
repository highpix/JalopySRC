using System;
using UnityEngine;

// Token: 0x0200015E RID: 350
[AddComponentMenu("Cursors/Cursor Manager")]
public class VfCursorManager : MonoBehaviour
{
	// Token: 0x06000D77 RID: 3447 RVA: 0x00132220 File Offset: 0x00130620
	public void Reset()
	{
		this.Cursors = new GameObject[0];
		this.DefaultCursorIndex = 0;
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x00132235 File Offset: 0x00130635
	public void Start()
	{
		this.DefaultCursorIndex = Mathf.Clamp(this.DefaultCursorIndex, 0, this.Cursors.Length);
		base.Invoke("InitializeCursor", 0.5f);
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x00132261 File Offset: 0x00130661
	private void InitializeCursor()
	{
		this.SetCursor(this.DefaultCursorIndex);
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x00132270 File Offset: 0x00130670
	public void SetCursor(int cursorIndex)
	{
		this.CurrentCursorIndex = cursorIndex;
		for (int i = 0; i < this.Cursors.Length; i++)
		{
			if (!(this.Cursors[i] == null))
			{
				this.Cursors[i].SetActive(i == cursorIndex);
			}
		}
	}

	// Token: 0x04001213 RID: 4627
	public GameObject[] Cursors;

	// Token: 0x04001214 RID: 4628
	public int DefaultCursorIndex;

	// Token: 0x04001215 RID: 4629
	[HideInInspector]
	public int CurrentCursorIndex;
}
