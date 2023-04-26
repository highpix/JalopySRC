using System;
using UnityEngine;

// Token: 0x02000037 RID: 55
public class OrbitCamera : MonoBehaviour
{
	// Token: 0x06000128 RID: 296 RVA: 0x000132A8 File Offset: 0x000116A8
	private void Start()
	{
		this.cameraRotSide = base.transform.eulerAngles.y;
		this.cameraRotSideCur = base.transform.eulerAngles.y;
		this.cameraRotUp = base.transform.eulerAngles.x;
		this.cameraRotUpCur = base.transform.eulerAngles.x;
		this.distance = -this.cam.localPosition.z;
	}

	// Token: 0x06000129 RID: 297 RVA: 0x00013334 File Offset: 0x00011734
	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			this.cameraRotSide += Input.GetAxis("Mouse X") * 5f;
			this.cameraRotUp -= Input.GetAxis("Mouse Y") * 5f;
		}
		this.cameraRotSideCur = Mathf.LerpAngle(this.cameraRotSideCur, this.cameraRotSide, Time.deltaTime * 5f);
		this.cameraRotUpCur = Mathf.Lerp(this.cameraRotUpCur, this.cameraRotUp, Time.deltaTime * 5f);
		if (Input.GetMouseButton(1))
		{
			this.distance *= 1f - 0.1f * Input.GetAxis("Mouse Y");
		}
		this.distance *= 1f - 1f * Input.GetAxis("Mouse ScrollWheel");
		Vector3 position = this.target.position;
		base.transform.position = Vector3.Lerp(base.transform.position, position + this.offset, Time.deltaTime);
		base.transform.rotation = Quaternion.Euler(this.cameraRotUpCur, this.cameraRotSideCur, 0f);
		float d = Mathf.Lerp(-this.cam.transform.localPosition.z, this.distance, Time.deltaTime * 5f);
		this.cam.localPosition = -Vector3.forward * d;
	}

	// Token: 0x04000246 RID: 582
	public Transform target;

	// Token: 0x04000247 RID: 583
	public Transform cam;

	// Token: 0x04000248 RID: 584
	public Vector3 offset = Vector3.zero;

	// Token: 0x04000249 RID: 585
	private float cameraRotSide;

	// Token: 0x0400024A RID: 586
	private float cameraRotUp;

	// Token: 0x0400024B RID: 587
	private float cameraRotSideCur;

	// Token: 0x0400024C RID: 588
	private float cameraRotUpCur;

	// Token: 0x0400024D RID: 589
	private float distance;
}
