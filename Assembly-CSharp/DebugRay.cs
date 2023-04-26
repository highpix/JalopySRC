using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class DebugRay : MonoBehaviour
{
	// Token: 0x06000031 RID: 49 RVA: 0x00003FD8 File Offset: 0x000023D8
	private void FixedUpdate()
	{
		Ray ray = new Ray(base.transform.position + Vector3.up * this.verticalOffset, -Vector3.up);
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, this.rayLength))
		{
			MonoBehaviour.print(raycastHit.transform.gameObject.name);
		}
	}

	// Token: 0x0400004E RID: 78
	public float verticalOffset;

	// Token: 0x0400004F RID: 79
	public float rayLength;
}
