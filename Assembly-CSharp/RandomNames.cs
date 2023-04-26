using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200007B RID: 123
public class RandomNames : MonoBehaviour
{
	// Token: 0x0600024C RID: 588 RVA: 0x0001D984 File Offset: 0x0001BD84
	[ContextMenu("Start")]
	private void Start()
	{
		string text = string.Empty;
		int num = this.names.Count / 2;
		List<string> list = new List<string>(this.names);
		for (int i = 9; i < 9 + num; i++)
		{
			MonoBehaviour.print(list.Count);
			int index = i;
			string text2 = this.names[index];
			list.Remove(text2);
			int index2 = UnityEngine.Random.Range(0, list.Count);
			string text3 = list[index2];
			list.Remove(text3);
			text += string.Format("{0} -> {1}\n", text2, text3);
		}
		MonoBehaviour.print(text);
	}

	// Token: 0x040003AF RID: 943
	public List<string> names = new List<string>();
}
