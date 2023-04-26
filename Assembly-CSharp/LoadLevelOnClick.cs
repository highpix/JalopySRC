using System;
using UnityEngine;

// Token: 0x02000059 RID: 89
[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour
{
	// Token: 0x060001AB RID: 427 RVA: 0x000183FE File Offset: 0x000167FE
	private void OnClick()
	{
		if (!string.IsNullOrEmpty(this.levelName))
		{
			Application.LoadLevel(this.levelName);
		}
	}

	// Token: 0x040002E6 RID: 742
	public string levelName;
}
