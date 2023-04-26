using System;
using UnityEngine;

// Token: 0x02000036 RID: 54
public class HelpText : MonoBehaviour
{
	// Token: 0x06000126 RID: 294 RVA: 0x00013248 File Offset: 0x00011648
	private void OnGUI()
	{
		GUILayout.Label("Move mouse to move look-at point", new GUILayoutOption[0]);
		GUILayout.Label("Use up and down arrows to change height", new GUILayoutOption[0]);
		GUILayout.Label("Left-drag to orbit camera", new GUILayoutOption[0]);
		GUILayout.Label("Right-drag to zoom camera", new GUILayoutOption[0]);
	}
}
