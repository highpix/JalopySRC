using System;
using UnityEngine;

// Token: 0x02000061 RID: 97
public class Tutorial5 : MonoBehaviour
{
	// Token: 0x060001C2 RID: 450 RVA: 0x00018BFC File Offset: 0x00016FFC
	public void SetDurationToCurrentProgress()
	{
		UITweener[] componentsInChildren = base.GetComponentsInChildren<UITweener>();
		foreach (UITweener uitweener in componentsInChildren)
		{
			uitweener.duration = Mathf.Lerp(2f, 0.5f, UIProgressBar.current.value);
		}
	}
}
