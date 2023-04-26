using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Decal : MonoBehaviour
{
	// Token: 0x06000033 RID: 51 RVA: 0x00004069 File Offset: 0x00002469
	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x0000408C File Offset: 0x0000248C
	public Bounds GetBounds()
	{
		Vector3 lossyScale = base.transform.lossyScale;
		Vector3 vector = -lossyScale / 2f;
		Vector3 vector2 = lossyScale / 2f;
		Vector3[] array = new Vector3[]
		{
			new Vector3(vector.x, vector.y, vector.z),
			new Vector3(vector2.x, vector.y, vector.z),
			new Vector3(vector.x, vector2.y, vector.z),
			new Vector3(vector2.x, vector2.y, vector.z),
			new Vector3(vector.x, vector.y, vector2.z),
			new Vector3(vector2.x, vector.y, vector2.z),
			new Vector3(vector.x, vector2.y, vector2.z),
			new Vector3(vector2.x, vector2.y, vector2.z)
		};
		for (int i = 0; i < 8; i++)
		{
			array[i] = base.transform.TransformDirection(array[i]);
		}
		vector2 = (vector = array[0]);
		foreach (Vector3 rhs in array)
		{
			vector = Vector3.Min(vector, rhs);
			vector2 = Vector3.Max(vector2, rhs);
		}
		return new Bounds(base.transform.position, vector2 - vector);
	}

	// Token: 0x04000050 RID: 80
	public Material material;

	// Token: 0x04000051 RID: 81
	public Sprite sprite;

	// Token: 0x04000052 RID: 82
	public float maxAngle = 90f;

	// Token: 0x04000053 RID: 83
	public float pushDistance = 0.009f;

	// Token: 0x04000054 RID: 84
	public LayerMask affectedLayers = -1;
}
