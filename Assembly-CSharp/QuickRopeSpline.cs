using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000075 RID: 117
[Serializable]
public class QuickRopeSpline
{
	// Token: 0x0600021B RID: 539 RVA: 0x0001BBD0 File Offset: 0x00019FD0
	public Vector3 Interpolate(float t)
	{
		if (this.Points.Count < 4)
		{
			return Vector3.zero;
		}
		int num = this.Points.Count - 3;
		int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
		float num3 = t * (float)num - (float)num2;
		Vector3 a = this.Points[num2];
		Vector3 a2 = this.Points[num2 + 1];
		Vector3 vector = this.Points[num2 + 2];
		Vector3 b = this.Points[num2 + 3];
		return 0.5f * ((-a + 3f * a2 - 3f * vector + b) * (num3 * num3 * num3) + (2f * a - 5f * a2 + 4f * vector - b) * (num3 * num3) + (-a + vector) * num3 + 2f * a2);
	}

	// Token: 0x0600021C RID: 540 RVA: 0x0001BD08 File Offset: 0x0001A108
	public void DrawGizmo(float t, int precision, Color splineColor)
	{
		if (this.Points.Count < 3)
		{
			return;
		}
		Gizmos.color = splineColor;
		Vector3 to = this.Interpolate(0f);
		for (int i = 1; i <= 100; i++)
		{
			float t2 = (float)i / 100f;
			Vector3 vector = this.Interpolate(t2);
			Gizmos.DrawLine(vector, to);
			to = vector;
		}
		Gizmos.color = Color.white;
	}

	// Token: 0x0400037B RID: 891
	public List<Vector3> Points;
}
