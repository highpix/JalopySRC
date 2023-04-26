using System;
using UnityEngine;

// Token: 0x020000F4 RID: 244
public class Rope : MonoBehaviour
{
	// Token: 0x06000994 RID: 2452 RVA: 0x000E349C File Offset: 0x000E189C
	public void SetMin()
	{
		this.dstMin = (this.start - this.end).magnitude;
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x000E34C8 File Offset: 0x000E18C8
	public void SetMax()
	{
		this.dstMax = (this.start - this.end).magnitude;
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x000E34F4 File Offset: 0x000E18F4
	private void Awake()
	{
		this.startT = base.transform;
		base.GetComponent<QuickRope2>().enabled = false;
		base.GetComponent<QuickRope2Line>().enabled = false;
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x000E351C File Offset: 0x000E191C
	private void Start()
	{
		this.lineRenderer = base.GetComponent<LineRenderer>();
		this.lineRenderer.positionCount = this.numPoints;
		this.points = new Vector3[this.numPoints];
		for (int i = 0; i < this.numPoints; i++)
		{
			float t = (float)i / ((float)this.numPoints - 1f);
			this.points[i] = Vector3.Lerp(this.start, this.end, t);
		}
		for (int j = 0; j < 200; j++)
		{
			this.UpdateRope();
		}
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x000E35C0 File Offset: 0x000E19C0
	private void FixedUpdate()
	{
		this.UpdateRope();
		for (int i = 0; i < this.lineRenderer.positionCount; i++)
		{
			this.lineRenderer.SetPosition(i, this.points[i]);
		}
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x000E360C File Offset: 0x000E1A0C
	private void UpdateRope()
	{
		float t = Mathf.InverseLerp(this.dstMin, this.dstMax, (this.start - this.end).magnitude);
		float d = Mathf.Lerp(this.forceMin, this.forceMax, t);
		this.points[0] = this.start;
		this.points[this.points.Length - 1] = this.end;
		for (int i = 0; i < this.k; i++)
		{
			for (int j = 1; j < this.points.Length - 1; j++)
			{
				Vector3 vector = this.points[j - 1] - this.points[j];
				Vector3 vector2 = this.points[j + 1] - this.points[j];
				Vector3 a = vector.normalized * vector.magnitude * d + vector2.normalized * vector2.magnitude * d;
				this.points[j] += a * Time.deltaTime / (float)this.k;
			}
			for (int k = 1; k < this.points.Length - 1; k++)
			{
				this.points[k] += Vector3.down * 9.8f * Time.deltaTime / (float)this.k;
			}
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x0600099A RID: 2458 RVA: 0x000E37ED File Offset: 0x000E1BED
	private Vector3 start
	{
		get
		{
			return this.startT.position + Vector3.back * 0.01f;
		}
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x0600099B RID: 2459 RVA: 0x000E380E File Offset: 0x000E1C0E
	private Vector3 end
	{
		get
		{
			return this.endT.position + Vector3.back * 0.01f;
		}
	}

	// Token: 0x04000D1B RID: 3355
	public Transform startT;

	// Token: 0x04000D1C RID: 3356
	public Transform endT;

	// Token: 0x04000D1D RID: 3357
	public int numPoints = 10;

	// Token: 0x04000D1E RID: 3358
	public float forceMax = 200f;

	// Token: 0x04000D1F RID: 3359
	public float forceMin;

	// Token: 0x04000D20 RID: 3360
	public float dstMin;

	// Token: 0x04000D21 RID: 3361
	public float dstMax;

	// Token: 0x04000D22 RID: 3362
	private Vector3[] points;

	// Token: 0x04000D23 RID: 3363
	public int k = 30;

	// Token: 0x04000D24 RID: 3364
	private Vector3 startOld;

	// Token: 0x04000D25 RID: 3365
	private Vector3 endOld;

	// Token: 0x04000D26 RID: 3366
	private LineRenderer lineRenderer;
}
