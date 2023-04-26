using System;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class LangDemo : MonoBehaviour
{
	// Token: 0x0600013B RID: 315 RVA: 0x000139B0 File Offset: 0x00011DB0
	private void OnGUI()
	{
		GUI.skin = this.mySkin;
		GUILayout.BeginArea(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		GUILayout.FlexibleSpace();
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical(new GUILayoutOption[0]);
		GUILayout.Label(Language.Get("MAIN_WELCOME"), new GUILayoutOption[]
		{
			GUILayout.Width(300f)
		});
		GUILayout.Label(Language.Get("MAIN_INTRO"), new GUILayoutOption[0]);
		GUILayout.Space(20f);
		float num = (float)((int)(Time.time % 4f * 25f));
		GUILayout.Label(Language.Get("MAIN_PROGRESSBAR").Replace("{X}", num + string.Empty), new GUILayoutOption[0]);
		GUILayout.Label(Language.Get("MAIN_SELECT_LANGUAGE"), new GUILayoutOption[0]);
		this.scrollView = GUILayout.BeginScrollView(this.scrollView, new GUILayoutOption[]
		{
			GUILayout.Height(100f)
		});
		foreach (string text in Language.GetLanguages())
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space(20f);
			if (GUILayout.Button(text, new GUILayoutOption[]
			{
				GUILayout.Width(50f)
			}))
			{
				Language.SwitchLanguage(text);
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndScrollView();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.EndArea();
		GUILayout.Label(Language.Get("TEST_CHARACTERS"), new GUILayoutOption[0]);
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00013B58 File Offset: 0x00011F58
	private void ChangedLanguage(LanguageCode code)
	{
		Debug.Log("DEMO We switched to: " + code);
		this.mySkin.font = (Font)Language.GetAsset("font");
		Debug.Log("DEMO Font: " + this.mySkin.font);
	}

	// Token: 0x0400025B RID: 603
	private Vector2 scrollView;

	// Token: 0x0400025C RID: 604
	public GUISkin mySkin;
}
