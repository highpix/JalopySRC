using System;
using UnityEngine;

// Token: 0x02000152 RID: 338
public class DNC_SpectateCam : MonoBehaviour
{
	// Token: 0x06000D45 RID: 3397 RVA: 0x0012F5A4 File Offset: 0x0012D9A4
	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
		}
		float num = Vector3.Distance(base.transform.position, this.MidPoint.transform.position);
		this.rotationX += Input.GetAxis("Mouse X") * this.lookSpeed;
		this.rotationY += Input.GetAxis("Mouse Y") * this.lookSpeed;
		this.rotationY = Mathf.Clamp(this.rotationY, -90f, 90f);
		base.transform.localRotation = Quaternion.AngleAxis(this.rotationX, Vector3.up);
		base.transform.localRotation *= Quaternion.AngleAxis(this.rotationY, Vector3.left);
		if (num <= this.m_maxDistance)
		{
			base.transform.position += base.transform.forward * this.moveSpeed * Input.GetAxis("Vertical");
			base.transform.position += base.transform.right * this.moveSpeed * Input.GetAxis("Horizontal");
		}
		else
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this.MidPoint.transform.position, Time.deltaTime * 5f);
		}
	}

	// Token: 0x040011C4 RID: 4548
	public float lookSpeed = 15f;

	// Token: 0x040011C5 RID: 4549
	public float moveSpeed = 15f;

	// Token: 0x040011C6 RID: 4550
	public Transform MidPoint;

	// Token: 0x040011C7 RID: 4551
	public float m_maxDistance = 200f;

	// Token: 0x040011C8 RID: 4552
	private float rotationX;

	// Token: 0x040011C9 RID: 4553
	private float rotationY;
}
