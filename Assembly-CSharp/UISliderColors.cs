using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
[AddComponentMenu("NGUI/Examples/Slider Colors")]
public class UISliderColors : MonoBehaviour
{
	// Token: 0x060001C4 RID: 452 RVA: 0x00018C9E File Offset: 0x0001709E
	private void Start()
	{
		this.mBar = base.GetComponent<UIProgressBar>();
		this.mSprite = base.GetComponent<UIBasicSprite>();
		this.Update();
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x00018CC0 File Offset: 0x000170C0
	private void Update()
	{
		if (this.sprite == null || this.colors.Length == 0)
		{
			return;
		}
		float num = (!(this.mBar != null)) ? this.mSprite.fillAmount : this.mBar.value;
		num *= (float)(this.colors.Length - 1);
		int num2 = Mathf.FloorToInt(num);
		Color color = this.colors[0];
		if (num2 >= 0)
		{
			if (num2 + 1 < this.colors.Length)
			{
				float t = num - (float)num2;
				color = Color.Lerp(this.colors[num2], this.colors[num2 + 1], t);
			}
			else if (num2 < this.colors.Length)
			{
				color = this.colors[num2];
			}
			else
			{
				color = this.colors[this.colors.Length - 1];
			}
		}
		color.a = this.sprite.color.a;
		this.sprite.color = color;
	}

	// Token: 0x040002FE RID: 766
	public UISprite sprite;

	// Token: 0x040002FF RID: 767
	public Color[] colors = new Color[]
	{
		Color.red,
		Color.yellow,
		Color.green
	};

	// Token: 0x04000300 RID: 768
	private UIProgressBar mBar;

	// Token: 0x04000301 RID: 769
	private UIBasicSprite mSprite;
}
