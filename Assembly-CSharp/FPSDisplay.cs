using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000135 RID: 309
[AddComponentMenu("Utilities/HUDFPS")]
public class FPSDisplay : MonoBehaviour
{
	// Token: 0x06000C6E RID: 3182 RVA: 0x0012BBC0 File Offset: 0x00129FC0
	private void Start()
	{
		base.StartCoroutine(this.FPS());
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x0012BBCF File Offset: 0x00129FCF
	private void Update()
	{
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x0012BBF8 File Offset: 0x00129FF8
	private IEnumerator FPS()
	{
		for (;;)
		{
			float fps = this.accum / (float)this.frames;
			this.sFPS = fps.ToString("f" + Mathf.Clamp(this.nbDecimal, 0, 10));
			this.color = ((fps < 30f) ? ((fps <= 10f) ? Color.yellow : Color.red) : Color.green);
			this.accum = 0f;
			this.frames = 0;
			yield return new WaitForSeconds(this.frequency);
		}
		yield break;
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x0012BC14 File Offset: 0x0012A014
	private void OnGUI()
	{
		if (this.style == null)
		{
			this.style = new GUIStyle(GUI.skin.label);
			this.style.normal.textColor = Color.white;
			this.style.alignment = TextAnchor.MiddleCenter;
		}
		GUI.color = ((!this.updateColor) ? Color.white : this.color);
		this.startRect = GUI.Window(0, this.startRect, new GUI.WindowFunction(this.DoMyWindow), string.Empty);
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x0012BCA8 File Offset: 0x0012A0A8
	private void DoMyWindow(int windowID)
	{
		GUI.Label(new Rect(0f, 0f, this.startRect.width, this.startRect.height), this.sFPS + " FPS", this.style);
		if (this.allowDrag)
		{
			GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}
	}

	// Token: 0x0400111E RID: 4382
	public Rect startRect = new Rect(10f, 10f, 75f, 50f);

	// Token: 0x0400111F RID: 4383
	public bool updateColor = true;

	// Token: 0x04001120 RID: 4384
	public bool allowDrag = true;

	// Token: 0x04001121 RID: 4385
	public float frequency = 0.5f;

	// Token: 0x04001122 RID: 4386
	public int nbDecimal = 1;

	// Token: 0x04001123 RID: 4387
	private float accum;

	// Token: 0x04001124 RID: 4388
	private int frames;

	// Token: 0x04001125 RID: 4389
	private Color color = Color.white;

	// Token: 0x04001126 RID: 4390
	private string sFPS = string.Empty;

	// Token: 0x04001127 RID: 4391
	private GUIStyle style;
}
