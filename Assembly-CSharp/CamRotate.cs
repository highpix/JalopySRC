using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class CamRotate : MonoBehaviour
{
	// Token: 0x06000002 RID: 2 RVA: 0x0000206E File Offset: 0x0000046E
	private void Start()
	{
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000470
	private void LateUpdate()
	{
		base.transform.position = new Vector3(this.target.position.x + Mathf.Sin(Time.time) * this.distance, base.transform.position.y, this.target.position.z + Mathf.Cos(Time.time) * this.distance);
		base.transform.LookAt(this.target.position);
	}

	// Token: 0x04000001 RID: 1
	public Transform target;

	// Token: 0x04000002 RID: 2
	public float distance = 3f;

	// Token: 0x04000003 RID: 3
	public float speed = 0.5f;
}
