using System;
using UnityEngine;

// Token: 0x02000071 RID: 113
[Serializable]
public class RopeAttachedObject
{
	// Token: 0x04000337 RID: 823
	public GameObject go;

	// Token: 0x04000338 RID: 824
	public RopeAttachmentJointType jointType;

	// Token: 0x04000339 RID: 825
	public int jointIndex;

	// Token: 0x0400033A RID: 826
	public Vector3 hingeAxis = Vector3.forward;

	// Token: 0x0400033B RID: 827
	public Joint jointRef;
}
