using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class QuickRope2Helper
{
	// Token: 0x06000219 RID: 537 RVA: 0x0001BB94 File Offset: 0x00019F94
	public static bool HasMoved(ref Vector3 prevPoint, Vector3 curPoint)
	{
		bool flag = Vector3.Distance(curPoint, prevPoint) >= 0.01f;
		if (flag)
		{
			prevPoint = curPoint;
		}
		return flag;
	}
}
