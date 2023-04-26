using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SoftMasking.Samples
{
	// Token: 0x0200013C RID: 316
	public class SoftMaskSampleChooser : MonoBehaviour
	{
		// Token: 0x06000C87 RID: 3207 RVA: 0x0012C238 File Offset: 0x0012A638
		public void Start()
		{
			string activeSceneName = SceneManager.GetActiveScene().name;
			this.dropdown.value = this.dropdown.options.FindIndex((Dropdown.OptionData x) => x.text == activeSceneName);
			this.dropdown.onValueChanged.AddListener(new UnityAction<int>(this.Choose));
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x0012C2A4 File Offset: 0x0012A6A4
		public void Choose(int sampleIndex)
		{
			string text = this.dropdown.options[sampleIndex].text;
			SceneManager.LoadScene(text);
		}

		// Token: 0x0400113C RID: 4412
		public Dropdown dropdown;

		// Token: 0x0400113D RID: 4413
		public Text fallbackLabel;
	}
}
