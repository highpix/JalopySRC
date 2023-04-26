using System;
using UnityEngine;

// Token: 0x02000077 RID: 119
[RequireComponent(typeof(QuickRope2))]
[ExecuteInEditMode]
[Serializable]
public class QuickRope2Mesh : MonoBehaviour
{
	// Token: 0x06000224 RID: 548 RVA: 0x0001C03F File Offset: 0x0001A43F
	private void OnEnable()
	{
		this.rope = base.GetComponent<QuickRope2>();
		this.rope.OnInitializeMesh += this.OnInitializeMesh;
	}

	// Token: 0x06000225 RID: 549 RVA: 0x0001C064 File Offset: 0x0001A464
	private void OnDisable()
	{
		this.rope.OnInitializeMesh -= this.OnInitializeMesh;
	}

	// Token: 0x06000226 RID: 550 RVA: 0x0001C07D File Offset: 0x0001A47D
	private void OnDestroy()
	{
		this.rope.OnInitializeMesh -= this.OnInitializeMesh;
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0001C096 File Offset: 0x0001A496
	public void OnInitializeMesh()
	{
		if (this.tube == null)
		{
			this.tube = new RopeTubeRenderer(base.gameObject, false);
		}
		this.tube.calculateTangents = true;
		this.UpdateMesh();
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0001C0C8 File Offset: 0x0001A4C8
	public void UpdateMesh()
	{
		this.tube.SetPointsAndRotations(this.rope.JointPositions, this.rope.GetRotations(this.rope.JointPositions));
		this.tube.SetEdgeCount(this.crossSegments);
		float[] array = new float[this.rope.JointPositions.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = this.curve.Evaluate((float)i * (1f / (float)array.Length));
		}
		this.tube.SetRadiuses(array);
		this.tube.Update();
		base.gameObject.GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2((float)this.rope.Joints.Count * this.textureTiling, 1f);
	}

	// Token: 0x06000229 RID: 553 RVA: 0x0001C1A4 File Offset: 0x0001A5A4
	private void Update()
	{
		if (this.meshStatic || !Application.isPlaying)
		{
			return;
		}
		float[] array = new float[this.rope.JointPositions.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = this.curve.Evaluate((float)i * (1f / (float)array.Length));
		}
		this.tube.SetPointsAndRotations(this.rope.JointPositions, this.rope.GetRotations(this.rope.JointPositions));
		this.tube.SetRadiuses(array);
		this.tube.Update();
		base.gameObject.GetComponent<Renderer>().material.mainTextureScale = new Vector2((float)this.rope.Joints.Count * this.textureTiling, 1f);
	}

	// Token: 0x0400037F RID: 895
	public bool meshStatic;

	// Token: 0x04000380 RID: 896
	public int maxRadius = 5;

	// Token: 0x04000381 RID: 897
	public float textureTiling = 1f;

	// Token: 0x04000382 RID: 898
	[SerializeField]
	public AnimationCurve curve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0.3f),
		new Keyframe(1f, 0.3f)
	});

	// Token: 0x04000383 RID: 899
	public Color[] grad;

	// Token: 0x04000384 RID: 900
	public int crossSegments = 6;

	// Token: 0x04000385 RID: 901
	[SerializeField]
	public RopeTubeRenderer tube;

	// Token: 0x04000386 RID: 902
	[SerializeField]
	private QuickRope2 rope;

	// Token: 0x04000387 RID: 903
	[SerializeField]
	private MeshFilter mFilter;
}
