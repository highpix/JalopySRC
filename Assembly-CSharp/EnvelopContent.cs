using System;
using UnityEngine;

// Token: 0x02000054 RID: 84
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Examples/Envelop Content")]
public class EnvelopContent : MonoBehaviour
{
	// Token: 0x0600019A RID: 410 RVA: 0x00017FCB File Offset: 0x000163CB
	private void Start()
	{
		this.mStarted = true;
		this.Execute();
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00017FDA File Offset: 0x000163DA
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.Execute();
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x00017FF0 File Offset: 0x000163F0
	[ContextMenu("Execute")]
	public void Execute()
	{
		if (this.targetRoot == base.transform)
		{
			Debug.LogError("Target Root object cannot be the same object that has Envelop Content. Make it a sibling instead.", this);
		}
		else if (NGUITools.IsChild(this.targetRoot, base.transform))
		{
			Debug.LogError("Target Root object should not be a parent of Envelop Content. Make it a sibling instead.", this);
		}
		else
		{
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(base.transform.parent, this.targetRoot, false);
			float num = bounds.min.x + (float)this.padLeft;
			float num2 = bounds.min.y + (float)this.padBottom;
			float num3 = bounds.max.x + (float)this.padRight;
			float num4 = bounds.max.y + (float)this.padTop;
			UIWidget component = base.GetComponent<UIWidget>();
			component.SetRect(num, num2, num3 - num, num4 - num2);
			base.BroadcastMessage("UpdateAnchors", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x040002D4 RID: 724
	public Transform targetRoot;

	// Token: 0x040002D5 RID: 725
	public int padLeft;

	// Token: 0x040002D6 RID: 726
	public int padRight;

	// Token: 0x040002D7 RID: 727
	public int padBottom;

	// Token: 0x040002D8 RID: 728
	public int padTop;

	// Token: 0x040002D9 RID: 729
	private bool mStarted;
}
