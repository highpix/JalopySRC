using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000309 RID: 777
public class MultiplayerUI : MonoBehaviour
{
	// Token: 0x06001792 RID: 6034
	private void Start()
	{
		GameObject gameObject = new GameObject("Text");
		Text textComponent = gameObject.AddComponent<Text>();
		textComponent.text = "Hello World";
		textComponent.fontSize = 24;
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.anchorMin = new Vector2(0.5f, 0.5f);
		component.anchorMax = new Vector2(0.5f, 0.5f);
		component.anchoredPosition = Vector2.zero;
		gameObject.transform.SetParent(base.transform, false);
		Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		textComponent.font = ArialFont;
	}
}
