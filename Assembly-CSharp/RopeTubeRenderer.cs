using System;
using UnityEngine;

// Token: 0x02000079 RID: 121
public class RopeTubeRenderer
{
	// Token: 0x0600022F RID: 559 RVA: 0x0001C374 File Offset: 0x0001A774
	public RopeTubeRenderer(GameObject _gameObject, bool useMeshOnly)
	{
		if (!useMeshOnly)
		{
			this._gameObject = _gameObject;
			this._transform = _gameObject.transform;
			MeshFilter meshFilter = _gameObject.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = _gameObject.AddComponent<MeshFilter>();
			}
			MeshRenderer meshRenderer = _gameObject.GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				meshRenderer = _gameObject.AddComponent<MeshRenderer>();
			}
			this._mesh = new Mesh();
			this._mesh.name = "RopeTube_" + _gameObject.GetInstanceID();
			this._mesh.hideFlags = HideFlags.HideAndDontSave;
			meshFilter.mesh = this._mesh;
			if (meshRenderer.sharedMaterial == null)
			{
				meshRenderer.sharedMaterial = (Material)Resources.Load("Materials/Rope", typeof(Material));
			}
		}
		else
		{
			this._gameObject = _gameObject;
			this._transform = _gameObject.transform;
			this._mesh = new Mesh();
			this._mesh.name = "RopeTube_" + _gameObject.GetInstanceID();
			this._mesh.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000230 RID: 560 RVA: 0x0001C525 File Offset: 0x0001A925
	public GameObject gameObject
	{
		get
		{
			return this._gameObject;
		}
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000231 RID: 561 RVA: 0x0001C52D File Offset: 0x0001A92D
	public Transform transform
	{
		get
		{
			return this._transform;
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000232 RID: 562 RVA: 0x0001C535 File Offset: 0x0001A935
	// (set) Token: 0x06000233 RID: 563 RVA: 0x0001C55C File Offset: 0x0001A95C
	public Vector3 up
	{
		get
		{
			return (!(this.pastUp != Vector3.zero)) ? Vector3.up : this.pastUp;
		}
		set
		{
			this.pastUp = value;
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000234 RID: 564 RVA: 0x0001C565 File Offset: 0x0001A965
	public Mesh mesh
	{
		get
		{
			return this._mesh;
		}
	}

	// Token: 0x06000235 RID: 565 RVA: 0x0001C570 File Offset: 0x0001A970
	public void Update()
	{
		if (this.points.Length == 0)
		{
			return;
		}
		if (this.updateCircleLookupFlag)
		{
			this.UpdateCircleLookup();
		}
		if (this.updateUVsFlag)
		{
			this.UpdateUVs();
		}
		if (this.updateTangentsFlag && this.calculateTangents)
		{
			this.UpdateTangents();
		}
		if (this.updateTrianglesFlag)
		{
			this.UpdateTriangles();
		}
		if (this.redrawFlag)
		{
			this.ReDraw();
		}
		if (this.updateColorsFlag)
		{
			this.UpdateColors();
		}
		this.updateCircleLookupFlag = false;
		this.updateTangentsFlag = false;
		this.updateTrianglesFlag = false;
		this.updateUVsFlag = false;
		this.redrawFlag = false;
		this.updateColorsFlag = false;
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0001C628 File Offset: 0x0001AA28
	private void ReDraw()
	{
		if (this.vertices.Length != this.targetVertexCount)
		{
			this._mesh.triangles = new int[0];
			this.vertices = new Vector3[this.targetVertexCount];
		}
		if (this.normals.Length != this.targetVertexCount)
		{
			this.normals = new Vector3[this.targetVertexCount];
		}
		int num = 1 + this.edgeCount + 1;
		Vector3 vector = new Vector3(10000f, 10000f, 10000f);
		Vector3 vector2 = new Vector3(-10000f, -10000f, -10000f);
		for (int i = 0; i < this.points.Length; i++)
		{
			if (this.radiuses != null)
			{
				if (this.points[i].x - this.radiuses[i] < vector.x)
				{
					vector.x = this.points[i].x - this.radiuses[i];
				}
				if (this.points[i].y - this.radiuses[i] < vector.y)
				{
					vector.y = this.points[i].y - this.radiuses[i];
				}
				if (this.points[i].z - this.radiuses[i] < vector.z)
				{
					vector.z = this.points[i].z - this.radiuses[i];
				}
				if (this.points[i].x + this.radiuses[i] > vector2.x)
				{
					vector2.x = this.points[i].x + this.radiuses[i];
				}
				if (this.points[i].y + this.radiuses[i] > vector2.y)
				{
					vector2.y = this.points[i].y + this.radiuses[i];
				}
				if (this.points[i].z + this.radiuses[i] > vector2.z)
				{
					vector2.z = this.points[i].z + this.radiuses[i];
				}
				for (int j = 0; j < this.edgeCount + 1; j++)
				{
					this.vertices[num] = this._transform.InverseTransformPoint(this.points[i] + this.rotations[i] * this.circleLookup[j] * this.radiuses[i]);
					this.normals[num] = this._transform.InverseTransformDirection(this.rotations[i] * this.circleLookup[j]);
					num++;
				}
			}
			else
			{
				if (this.points[i].x - this.radius < vector.x)
				{
					vector.x = this.points[i].x - this.radius;
				}
				if (this.points[i].y - this.radius < vector.y)
				{
					vector.y = this.points[i].y - this.radius;
				}
				if (this.points[i].z - this.radius < vector.z)
				{
					vector.z = this.points[i].z - this.radius;
				}
				if (this.points[i].x + this.radius > vector2.x)
				{
					vector2.x = this.points[i].x + this.radius;
				}
				if (this.points[i].y + this.radius > vector2.y)
				{
					vector2.y = this.points[i].y + this.radius;
				}
				if (this.points[i].z + this.radius > vector2.z)
				{
					vector2.z = this.points[i].z + this.radius;
				}
				for (int k = 0; k < this.edgeCount + 1; k++)
				{
					this.vertices[num] = this._transform.InverseTransformPoint(this.points[i] + this.rotations[i] * this.circleLookup[k] * this.radius);
					this.normals[num] = this._transform.InverseTransformDirection(this.rotations[i] * this.circleLookup[k]);
					num++;
				}
			}
		}
		this.vertices[0] = this._transform.InverseTransformPoint(this.points[0]);
		this.vertices[this.vertices.Length - 1] = this._transform.InverseTransformPoint(this.points[this.points.Length - 1]);
		this.normals[0] = this._transform.InverseTransformDirection(this.rotations[0] * Vector3.forward);
		this.normals[this.targetVertexCount - 1] = this._transform.InverseTransformDirection(this.rotations[0] * -Vector3.forward);
		num = 1;
		for (int l = 0; l < this.edgeCount + 1; l++)
		{
			this.vertices[num] = this.vertices[num + this.edgeCount + 1];
			this.normals[num] = this.normals[0];
			num++;
		}
		num = this.vertices.Length - this.edgeCount - 2;
		for (int m = 0; m < this.edgeCount + 1; m++)
		{
			this.vertices[num] = this.vertices[num - this.edgeCount - 1];
			this.normals[num] = this.normals[this.targetVertexCount - 1];
			num++;
		}
		this._mesh.vertices = this.vertices;
		if (this.updateUVsFlag)
		{
			this._mesh.uv = this.uvs;
		}
		if (this.updateTrianglesFlag)
		{
			this._mesh.triangles = this.triangles;
		}
		this._mesh.normals = this.normals;
		if (this.calculateTangents)
		{
			this._mesh.tangents = this.tangents;
		}
		this._mesh.RecalculateBounds();
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0001CE20 File Offset: 0x0001B220
	private void UpdateCircleLookup()
	{
		this.circleLookup = new Vector3[this.edgeCount + 1];
		float num = 1f / (float)this.edgeCount;
		for (int i = 0; i < this.circleLookup.Length; i++)
		{
			float f = (float)i * num * 6.2831855f;
			this.circleLookup[i] = new Vector3(0f, Mathf.Cos(f), Mathf.Sin(f));
		}
	}

	// Token: 0x06000238 RID: 568 RVA: 0x0001CE9C File Offset: 0x0001B29C
	private void UpdateUVs()
	{
		this.uvs = new Vector2[this.targetVertexCount];
		float num = 1f / ((float)this.points.Length - 1f);
		float num2 = 1f / (float)this.edgeCount;
		int num3 = 0;
		this.uvs[num3++] = new Vector2(this.capUVRect.width * 0.5f + this.capUVRect.x, this.capUVRect.height * 0.5f + this.capUVRect.y);
		for (int i = 0; i < this.edgeCount + 1; i++)
		{
			float f = (float)i * num2 * 6.2831855f + 1.5707964f;
			this.uvs[num3++] = new Vector2(this.uvs[0].x + Mathf.Cos(f) * 0.5f * this.capUVRect.width, this.uvs[0].y + Mathf.Sin(f) * 0.5f * this.capUVRect.height);
		}
		for (int j = 0; j < this.points.Length; j++)
		{
			float num4 = (float)j * num;
			for (int k = 0; k < this.edgeCount + 1; k++)
			{
				float num5 = (float)k * num2;
				this.uvs[num3++] = new Vector2(this.bodyUVRect.x + num4 * this.bodyUVRect.width, this.bodyUVRect.y + num5 * this.bodyUVRect.height);
			}
		}
		for (int l = 0; l < this.edgeCount + 1; l++)
		{
			this.uvs[num3++] = this.uvs[l + 1];
		}
		this.uvs[num3++] = this.uvs[0];
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0001D0D4 File Offset: 0x0001B4D4
	private void UpdateTangents()
	{
		this.tangents = new Vector4[this.targetVertexCount];
		int num = 0;
		Vector3 vector = this._transform.InverseTransformDirection(this.rotations[0] * Vector3.right);
		for (int i = 0; i < this.edgeCount + 2; i++)
		{
			this.tangents[num++] = new Vector4(vector.x, vector.y, vector.z, 1f);
		}
		for (int j = 0; j < this.rotations.Length; j++)
		{
			vector = this._transform.InverseTransformDirection(this.rotations[j] * Vector3.forward);
			if (this.calculateTangents)
			{
				for (int k = 0; k < this.edgeCount + 1; k++)
				{
					this.tangents[num++] = new Vector4(vector.x, vector.y, vector.z, 1f);
				}
			}
		}
		vector = this._transform.InverseTransformDirection(this.rotations[this.rotations.Length - 1] * Vector3.left);
		for (int l = 0; l < this.edgeCount + 2; l++)
		{
			this.tangents[num++] = new Vector4(vector.x, vector.y, vector.z, 1f);
		}
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0001D288 File Offset: 0x0001B688
	private void UpdateTriangles()
	{
		int num = (this.points.Length - 1) * this.edgeCount * 2;
		int num2 = 2 * this.edgeCount;
		this.triangles = new int[(num + num2) * 3];
		int num3 = 1;
		int num4 = 0;
		for (int i = 0; i < this.edgeCount; i++)
		{
			this.triangles[num4++] = num3 + 1;
			this.triangles[num4++] = num3;
			this.triangles[num4++] = 0;
			num3++;
		}
		num3++;
		int[] array = new int[]
		{
			0,
			1,
			this.edgeCount + 2,
			0,
			this.edgeCount + 2,
			this.edgeCount + 1
		};
		for (int j = 0; j < this.points.Length - 1; j++)
		{
			for (int k = 0; k < this.edgeCount; k++)
			{
				for (int l = 0; l < array.Length; l++)
				{
					this.triangles[num4++] = num3 + array[l];
				}
				num3++;
			}
			num3++;
		}
		num3++;
		num3 += this.edgeCount;
		for (int m = 0; m < this.edgeCount; m++)
		{
			this.triangles[num4++] = num3;
			this.triangles[num4++] = num3 + 1;
			this.triangles[num4++] = this.targetVertexCount - 1;
			num3++;
		}
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0001D40C File Offset: 0x0001B80C
	private void UpdateColors()
	{
		if (this.pointColors != null)
		{
			this.colors = new Color[this.targetVertexCount];
			int num = 0;
			this.colors[num++] = this.pointColors[0];
			for (int i = 0; i < this.edgeCount + 1; i++)
			{
				this.colors[num++] = this.pointColors[0];
			}
			for (int j = 0; j < this.points.Length; j++)
			{
				for (int k = 0; k < this.edgeCount + 1; k++)
				{
					this.colors[num++] = this.pointColors[j];
				}
			}
			for (int l = 0; l < this.edgeCount + 1; l++)
			{
				this.colors[num++] = this.pointColors[this.pointColors.Length - 1];
			}
			this.colors[num++] = this.pointColors[this.pointColors.Length - 1];
			this.mesh.colors = this.colors;
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0001D580 File Offset: 0x0001B980
	public void SetPointCount(int pointCount)
	{
		if (pointCount < 2)
		{
			Debug.LogWarning("TubeRenderer must have at two three points.");
			return;
		}
		this.updateTrianglesFlag = true;
		this.updateUVsFlag = true;
		this.updateColorsFlag = true;
		this.updateTangentsFlag = true;
		if (this.circleLookup == null)
		{
			this.updateCircleLookupFlag = true;
		}
		this.redrawFlag = true;
		this.targetVertexCount = pointCount * (this.edgeCount + 1);
		this.points = new Vector3[pointCount];
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0001D5F0 File Offset: 0x0001B9F0
	public void SetPointsAndRotations(Vector3[] points, Quaternion[] rotations)
	{
		if (points.Length < 2)
		{
			Debug.LogWarning("RopeTubeRenderer must have at two three points.");
			return;
		}
		if (points.Length != rotations.Length)
		{
			Debug.LogWarning("point array must match length of rotation array.");
			return;
		}
		int num = (this.points == null) ? 0 : this.points.Length;
		if (points.Length != num)
		{
			this.updateTrianglesFlag = true;
			this.updateUVsFlag = true;
			this.updateColorsFlag = true;
		}
		this.updateTangentsFlag = true;
		if (this.circleLookup == null)
		{
			this.updateCircleLookupFlag = true;
		}
		this.redrawFlag = true;
		if (this.radiuses != null && points.Length != this.radiuses.Length)
		{
			this.radiuses = null;
		}
		this.targetVertexCount = (points.Length + 2) * (this.edgeCount + 1) + 2;
		this.points = points;
		this.rotations = rotations;
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0001D6C8 File Offset: 0x0001BAC8
	public void SetEdgeCount(int edgeCount)
	{
		if (edgeCount < 3)
		{
			edgeCount = 3;
		}
		this.edgeCount = edgeCount;
		this.updateTrianglesFlag = true;
		this.updateUVsFlag = true;
		this.updateCircleLookupFlag = true;
		this.updateColorsFlag = true;
		this.redrawFlag = true;
		this.targetVertexCount = (this.points.Length + 2) * (edgeCount + 1) + 2;
	}

	// Token: 0x0600023F RID: 575 RVA: 0x0001D71F File Offset: 0x0001BB1F
	public void SetRadius(float radius)
	{
		this.radius = radius;
		this.redrawFlag = true;
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0001D72F File Offset: 0x0001BB2F
	public void SetRadiuses(float[] radiuses)
	{
		if (radiuses == null)
		{
			this.radiuses = null;
			return;
		}
		if (radiuses.Length != this.points.Length)
		{
			Debug.Log("TubeRenderer only receives as many radius values as it has points. Use SetPoints() or SetPointCount() before using SetRadiuses()");
			return;
		}
		this.radiuses = radiuses;
		this.redrawFlag = true;
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0001D768 File Offset: 0x0001BB68
	public void SetColors(Color[] colors)
	{
		if (colors.Length != this.points.Length)
		{
			Debug.Log("TubeRenderer only receives as many color values as it has points. Use SetPoints() or SetPointCount() before using SetColors()");
			return;
		}
		this.pointColors = colors;
		this.updateColorsFlag = true;
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0001D793 File Offset: 0x0001BB93
	public void SetBodyUVRect(Rect uvRect)
	{
		this.bodyUVRect = uvRect;
		this.updateUVsFlag = true;
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0001D7A3 File Offset: 0x0001BBA3
	public void SetCapsUVRect(Rect uvRect)
	{
		this.capUVRect = uvRect;
		this.updateUVsFlag = true;
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0001D7B4 File Offset: 0x0001BBB4
	public Vector3[] Points()
	{
		Vector3[] array = new Vector3[this.points.Length];
		this.points.CopyTo(array, 0);
		return array;
	}

	// Token: 0x06000245 RID: 581 RVA: 0x0001D7E0 File Offset: 0x0001BBE0
	public float[] Radiuses()
	{
		float[] array = new float[this.radiuses.Length];
		this.radiuses.CopyTo(array, 0);
		return array;
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0001D809 File Offset: 0x0001BC09
	public int EdgeCount()
	{
		return this.edgeCount;
	}

	// Token: 0x0400038D RID: 909
	public bool calculateTangents;

	// Token: 0x0400038E RID: 910
	private GameObject _gameObject;

	// Token: 0x0400038F RID: 911
	private Transform _transform;

	// Token: 0x04000390 RID: 912
	private int targetVertexCount;

	// Token: 0x04000391 RID: 913
	private Vector3[] points = new Vector3[0];

	// Token: 0x04000392 RID: 914
	private float radius = 0.5f;

	// Token: 0x04000393 RID: 915
	private float[] radiuses;

	// Token: 0x04000394 RID: 916
	private int edgeCount = 12;

	// Token: 0x04000395 RID: 917
	private Color[] pointColors;

	// Token: 0x04000396 RID: 918
	private Rect capUVRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x04000397 RID: 919
	private Rect bodyUVRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x04000398 RID: 920
	private Vector3[] vertices = new Vector3[0];

	// Token: 0x04000399 RID: 921
	private Vector3[] normals = new Vector3[0];

	// Token: 0x0400039A RID: 922
	private int[] triangles;

	// Token: 0x0400039B RID: 923
	private Vector2[] uvs;

	// Token: 0x0400039C RID: 924
	private Vector4[] tangents = new Vector4[0];

	// Token: 0x0400039D RID: 925
	private Color[] colors;

	// Token: 0x0400039E RID: 926
	private Vector3[] circleLookup;

	// Token: 0x0400039F RID: 927
	private Quaternion[] rotations = new Quaternion[0];

	// Token: 0x040003A0 RID: 928
	private MeshFilter filter;

	// Token: 0x040003A1 RID: 929
	private bool updateCircleLookupFlag;

	// Token: 0x040003A2 RID: 930
	private bool updateUVsFlag;

	// Token: 0x040003A3 RID: 931
	private bool updateTrianglesFlag;

	// Token: 0x040003A4 RID: 932
	private bool updateTangentsFlag;

	// Token: 0x040003A5 RID: 933
	private bool updateColorsFlag;

	// Token: 0x040003A6 RID: 934
	private bool redrawFlag;

	// Token: 0x040003A7 RID: 935
	private bool pointCountChanged;

	// Token: 0x040003A8 RID: 936
	private const float TWO_PI = 6.2831855f;

	// Token: 0x040003A9 RID: 937
	private Vector3 pastUp;

	// Token: 0x040003AA RID: 938
	private Mesh _mesh;
}
