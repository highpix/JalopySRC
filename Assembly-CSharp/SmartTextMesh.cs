using System;
using UnityEngine;

// Token: 0x020000FC RID: 252
[RequireComponent(typeof(TextMesh))]
public class SmartTextMesh : MonoBehaviour
{
	// Token: 0x06000A03 RID: 2563 RVA: 0x000EDBE5 File Offset: 0x000EBFE5
	private void Start()
	{
		this.TheMesh = base.GetComponent<TextMesh>();
		if (this.ConvertNewLines)
		{
			this.UnwrappedText = this.UnwrappedText.Replace("\\n", Environment.NewLine);
		}
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x000EDC1C File Offset: 0x000EC01C
	private string BreakPartIfNeeded(string part)
	{
		string text = this.TheMesh.text;
		this.TheMesh.text = part;
		if (this.TheMesh.GetComponent<Renderer>().bounds.extents.x > this.MaxWidth)
		{
			string text2 = part;
			part = string.Empty;
			for (;;)
			{
				int i;
				for (i = 2; i <= text2.Length; i++)
				{
					this.TheMesh.text = text2.Substring(0, i);
					if (this.TheMesh.GetComponent<Renderer>().bounds.extents.x > this.MaxWidth)
					{
						i--;
						break;
					}
				}
				if (i >= text2.Length)
				{
					break;
				}
				part = part + text2.Substring(0, i) + Environment.NewLine;
				text2 = text2.Substring(i);
			}
			part += text2;
			part = part.TrimEnd(new char[0]);
		}
		this.TheMesh.text = text;
		return part;
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x000EDD38 File Offset: 0x000EC138
	private void Update()
	{
		if (!this.NeedsLayout)
		{
			return;
		}
		this.NeedsLayout = false;
		if (this.MaxWidth == 0f)
		{
			this.TheMesh.text = this.UnwrappedText;
			return;
		}
		string text = string.Empty;
		string unwrappedText = this.UnwrappedText;
		this.TheMesh.text = string.Empty;
		string[] array = unwrappedText.Split(new char[]
		{
			' '
		});
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = this.BreakPartIfNeeded(array[i]);
			TextMesh theMesh = this.TheMesh;
			theMesh.text = theMesh.text + text2 + " ";
			if (this.TheMesh.GetComponent<Renderer>().bounds.extents.x > this.MaxWidth)
			{
				this.TheMesh.text = text.TrimEnd(new char[0]) + Environment.NewLine + text2 + " ";
			}
			text = this.TheMesh.text;
		}
	}

	// Token: 0x04000DDE RID: 3550
	private TextMesh TheMesh;

	// Token: 0x04000DDF RID: 3551
	public string UnwrappedText;

	// Token: 0x04000DE0 RID: 3552
	public float MaxWidth;

	// Token: 0x04000DE1 RID: 3553
	public bool NeedsLayout = true;

	// Token: 0x04000DE2 RID: 3554
	public bool ConvertNewLines;
}
