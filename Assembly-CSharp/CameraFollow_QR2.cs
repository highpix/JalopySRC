using System;
using UnityEngine;

// Token: 0x02000069 RID: 105
public class CameraFollow_QR2 : MonoBehaviour
{
	// Token: 0x060001DA RID: 474 RVA: 0x0001910C File Offset: 0x0001750C
	private void Update()
	{
		base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(this.target.position.x + this.offset.x, this.target.position.y + this.offset.y, base.transform.position.z + this.offset.z), Time.deltaTime * this.lerpValue);
	}

	// Token: 0x04000314 RID: 788
	public Transform target;

	// Token: 0x04000315 RID: 789
	public Vector3 offset = new Vector3(0f, 5f, 0f);

	// Token: 0x04000316 RID: 790
	public float lerpValue = 5f;
}
