using System;
using UnityEngine;

// Token: 0x02000033 RID: 51
[Serializable]
public class BendingSegment
{
	// Token: 0x0400022D RID: 557
	public Transform firstTransform;

	// Token: 0x0400022E RID: 558
	public Transform lastTransform;

	// Token: 0x0400022F RID: 559
	public float thresholdAngleDifference;

	// Token: 0x04000230 RID: 560
	public float bendingMultiplier = 0.6f;

	// Token: 0x04000231 RID: 561
	public float maxAngleDifference = 30f;

	// Token: 0x04000232 RID: 562
	public float maxBendingAngle = 80f;

	// Token: 0x04000233 RID: 563
	public float responsiveness = 5f;

	// Token: 0x04000234 RID: 564
	internal float angleH;

	// Token: 0x04000235 RID: 565
	internal float angleV;

	// Token: 0x04000236 RID: 566
	internal Vector3 dirUp;

	// Token: 0x04000237 RID: 567
	internal Vector3 referenceLookDir;

	// Token: 0x04000238 RID: 568
	internal Vector3 referenceUpDir;

	// Token: 0x04000239 RID: 569
	internal int chainLength;

	// Token: 0x0400023A RID: 570
	internal Quaternion[] origRotations;
}
