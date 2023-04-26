using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
public class DNC_Test : MonoBehaviour
{
	// Token: 0x06000D47 RID: 3399 RVA: 0x0012F74C File Offset: 0x0012DB4C
	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10f, 25f, 250f, 150f), string.Empty, "box");
		GUILayout.Label("Day progress speed", new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.DNC.dayCycleInMinutes = GUILayout.HorizontalSlider(this.DNC.dayCycleInMinutes, 30f, 1f, new GUILayoutOption[0]);
		GUILayout.Box(this.DNC.dayCycleInMinutes.ToString("00"), new GUILayoutOption[]
		{
			GUILayout.Width(30f)
		});
		GUILayout.EndHorizontal();
		if (this.DNC.isDay)
		{
			GUILayout.Box("Is Day", new GUILayoutOption[0]);
		}
		else
		{
			GUILayout.Box("Is Night", new GUILayoutOption[0]);
		}
		GUILayout.Label("Day Progress in Hour", new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.HorizontalSlider(this.DNC.timeInHours, 0f, 24f, new GUILayoutOption[0]);
		GUILayout.Box(this.DNC.timeInHours.ToString("00"), new GUILayoutOption[]
		{
			GUILayout.Width(40f)
		});
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

	// Token: 0x06000D48 RID: 3400 RVA: 0x0012F8A6 File Offset: 0x0012DCA6
	public void CalledOnDay()
	{
		Debug.Log("IsDay");
	}

	// Token: 0x06000D49 RID: 3401 RVA: 0x0012F8B2 File Offset: 0x0012DCB2
	public void CalledOnNight()
	{
		Debug.Log("IsNight");
	}

	// Token: 0x040011CA RID: 4554
	public DNC_DayNight DNC;
}
