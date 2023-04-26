using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class Logger : MonoBehaviour
{
	// Token: 0x0600067A RID: 1658 RVA: 0x00083081 File Offset: 0x00081481
	private void OnEnable()
	{
		Application.RegisterLogCallback(new Application.LogCallback(this.HandleLog));
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x00083094 File Offset: 0x00081494
	private void OnDisable()
	{
		Application.RegisterLogCallback(null);
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x0008309C File Offset: 0x0008149C
	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0f, (float)(Screen.height - 140), (float)Screen.width, 140f));
		foreach (string text in global::Logger.queue)
		{
			GUILayout.Label(text, new GUILayoutOption[0]);
		}
		GUILayout.EndArea();
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x00083128 File Offset: 0x00081528
	private void HandleLog(string message, string stackTrace, LogType type)
	{
		global::Logger.queue.Enqueue(Time.time + " - " + message);
		if (global::Logger.queue.Count > 5)
		{
			global::Logger.queue.Dequeue();
		}
	}

	// Token: 0x040008A7 RID: 2215
	private static Queue<string> queue = new Queue<string>(6);
}
