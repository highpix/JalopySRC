using System;
using UnityEngine;

// Token: 0x02000159 RID: 345
public class DemoGUI : MonoBehaviour
{
	// Token: 0x06000D58 RID: 3416 RVA: 0x00131460 File Offset: 0x0012F860
	public void Start()
	{
		this._cm = UnityEngine.Object.FindObjectOfType<VfCursorManager>();
		this._lm = UnityEngine.Object.FindObjectOfType<VfLabelManager>();
		this._demoTextStyle = new GUIStyle
		{
			alignment = TextAnchor.MiddleCenter,
			fontSize = 18
		};
		this._demoTextStyle.normal.textColor = Color.white;
		this.UpdateCursorMode();
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x001314BC File Offset: 0x0012F8BC
	private void UpdateCursorMode()
	{
		Cursor.visible = false;
		foreach (GameObject gameObject in this._cm.Cursors)
		{
			VfAnimCursor component = gameObject.GetComponent<VfAnimCursor>();
			if (component != null)
			{
				component.CursorMode = ((!this._hardwareCursors) ? CursorMode.ForceSoftware : CursorMode.Auto);
			}
		}
		this.UpdateCursorSet();
		Cursor.visible = true;
	}

	// Token: 0x06000D5A RID: 3418 RVA: 0x0013152A File Offset: 0x0012F92A
	public void Update()
	{
	}

	// Token: 0x06000D5B RID: 3419 RVA: 0x0013152C File Offset: 0x0012F92C
	public void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0f, 8f, (float)Screen.width, 32f));
		GUILayout.Label("Hover over the objects in the scene.", this._demoTextStyle, new GUILayoutOption[0]);
		GUILayout.EndArea();
		this._windowRect.height = (float)((!this._lm.enabled) ? 90 : 400);
		this._windowRect = GUILayout.Window(0, this._windowRect, new GUI.WindowFunction(this.GuiWindowHandler), "Cursor/Label Demo", new GUILayoutOption[0]);
	}

	// Token: 0x06000D5C RID: 3420 RVA: 0x001315C4 File Offset: 0x0012F9C4
	private void GuiWindowHandler(int id)
	{
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.BeginVertical(new GUILayoutOption[]
		{
			GUILayout.Width(260f)
		});
		GUILayout.Space(12f);
		if (GUILayout.Button("Fullscreen", new GUILayoutOption[0]))
		{
			this.ToggleFullScreen();
		}
		GUILayout.Space(12f);
		bool hardwareCursors = this._hardwareCursors;
		this._hardwareCursors = GUILayout.Toggle(this._hardwareCursors, "Use Hardware Cursors", new GUILayoutOption[0]);
		if (hardwareCursors != this._hardwareCursors)
		{
			this.UpdateCursorMode();
		}
		GUILayout.Space(8f);
		int cursorSet = this._cursorSet;
		this._cursorSet = GUILayout.SelectionGrid(this._cursorSet, new string[]
		{
			"Anim",
			"Hands",
			"Large",
			"Static"
		}, 4, new GUILayoutOption[0]);
		if (cursorSet != this._cursorSet)
		{
			this.UpdateCursorSet();
		}
		GUILayout.Space(8f);
		bool enabled = this._lm.enabled;
		bool flag = GUILayout.Toggle(enabled, "Show Labels", new GUILayoutOption[0]);
		if (flag != enabled)
		{
			this._lm.enabled = flag;
		}
		if (flag)
		{
			GUILayout.Space(8f);
			bool demoSkin = this._demoSkin;
			this._demoSkin = GUILayout.Toggle(this._demoSkin, "Use Demo Skin for Labels", new GUILayoutOption[0]);
			if (demoSkin != this._demoSkin)
			{
				this._lm.LabelSettings.Skin = ((!this._demoSkin) ? null : this.DemoSkin);
			}
			GUILayout.Space(8f);
			this._lm.KeepOnScreen = GUILayout.Toggle(this._lm.KeepOnScreen, "Keep Labels on Screen", new GUILayoutOption[0]);
			if (this._lm.KeepOnScreen)
			{
				this._lm.CanChangeAnchor = GUILayout.Toggle(this._lm.CanChangeAnchor, "Can Change Label Anchor", new GUILayoutOption[0]);
			}
			GUILayout.Space(8f);
			GUILayout.Label("Max Label Width: " + this._lm.LabelSettings.MaxWidth, new GUILayoutOption[0]);
			this._lm.LabelSettings.MaxWidth = (int)GUILayout.HorizontalSlider((float)this._lm.LabelSettings.MaxWidth, 100f, 600f, new GUILayoutOption[0]);
			GUILayout.Space(8f);
			GUILayout.Label("Label Position", new GUILayoutOption[0]);
			this._labelPos = GUILayout.SelectionGrid(this._labelPos, new string[9], 3, GUI.skin.toggle, new GUILayoutOption[0]);
			this.UpdateLabelPosition(this._labelPos);
		}
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x00131888 File Offset: 0x0012FC88
	private void ToggleFullScreen()
	{
		if (!Screen.fullScreen)
		{
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
		}
		else
		{
			Screen.SetResolution(1024, 768, false);
		}
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x001318D4 File Offset: 0x0012FCD4
	private void UpdateCursorSet()
	{
		Cursor.visible = false;
		GameObject[] array = (new GameObject[][]
		{
			this.AnimCursors,
			this.HandCursors,
			this.LargeCursors,
			this.StaticCursors
		})[this._cursorSet];
		GameObject[] array2 = new GameObject[array.Length + 1];
		array2[0] = this.DefaultCursor;
		for (int i = 0; i < array.Length; i++)
		{
			array2[i + 1] = array[i].gameObject;
		}
		this._cm.Cursors = array2;
		VfCursorTarget[] array3 = UnityEngine.Object.FindObjectsOfType<VfCursorTarget>();
		for (int j = 0; j < array3.Length; j++)
		{
			array3[j].CursorIndex = 1 + j % array.Length;
		}
		Cursor.visible = true;
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00131990 File Offset: 0x0012FD90
	private void UpdateLabelPosition(int pos)
	{
		switch (pos)
		{
		case 0:
			this._lm.LabelSettings.Anchor = TextAnchor.UpperLeft;
			break;
		case 1:
			this._lm.LabelSettings.Anchor = TextAnchor.UpperCenter;
			break;
		case 2:
			this._lm.LabelSettings.Anchor = TextAnchor.UpperRight;
			break;
		case 3:
			this._lm.LabelSettings.Anchor = TextAnchor.MiddleLeft;
			break;
		case 4:
			this._lm.LabelSettings.Anchor = TextAnchor.MiddleCenter;
			break;
		case 5:
			this._lm.LabelSettings.Anchor = TextAnchor.MiddleRight;
			break;
		case 6:
			this._lm.LabelSettings.Anchor = TextAnchor.LowerLeft;
			break;
		case 7:
			this._lm.LabelSettings.Anchor = TextAnchor.LowerCenter;
			break;
		case 8:
			this._lm.LabelSettings.Anchor = TextAnchor.LowerRight;
			break;
		}
	}

	// Token: 0x040011E8 RID: 4584
	public GUISkin DemoSkin;

	// Token: 0x040011E9 RID: 4585
	private Rect _windowRect = new Rect(16f, 16f, 280f, 460f);

	// Token: 0x040011EA RID: 4586
	private VfCursorManager _cm;

	// Token: 0x040011EB RID: 4587
	private VfLabelManager _lm;

	// Token: 0x040011EC RID: 4588
	private bool _hardwareCursors;

	// Token: 0x040011ED RID: 4589
	private GUIStyle _demoTextStyle;

	// Token: 0x040011EE RID: 4590
	private int _labelPos = 5;

	// Token: 0x040011EF RID: 4591
	private bool _demoSkin = true;

	// Token: 0x040011F0 RID: 4592
	private int _cursorSet;

	// Token: 0x040011F1 RID: 4593
	public GameObject DefaultCursor;

	// Token: 0x040011F2 RID: 4594
	public GameObject[] AnimCursors;

	// Token: 0x040011F3 RID: 4595
	public GameObject[] HandCursors;

	// Token: 0x040011F4 RID: 4596
	public GameObject[] LargeCursors;

	// Token: 0x040011F5 RID: 4597
	public GameObject[] StaticCursors;
}
