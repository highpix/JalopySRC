using System;
using UnityEngine;

// Token: 0x0200006B RID: 107
public class FreeFall_Controller_Example_QR2 : MonoBehaviour
{
	// Token: 0x060001DE RID: 478 RVA: 0x00019464 File Offset: 0x00017864
	private void Start()
	{
		this.rope = QuickRope2.Create(Vector3.zero, new Vector3(0f, -10f, 0f), BasicRopeTypes.Mesh);
		this.rope.enablePhysics = true;
		this.rope.enableRopeController = true;
		this.rope.ApplyRopeSettings();
		this.rope.GetComponent<Rigidbody>().isKinematic = true;
	}

	// Token: 0x060001DF RID: 479 RVA: 0x000194CA File Offset: 0x000178CA
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.rope.FreeFallMode = !this.rope.FreeFallMode;
		}
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x000194F4 File Offset: 0x000178F4
	private void OnGUI()
	{
		GUI.Label(new Rect(10f, 10f, 300f, 30f), "Press SPACE to toggle freefall mode!");
		GUI.Label(new Rect(10f, 40f, 300f, 30f), "Press ARROW UP to shorten rope!");
		GUI.Label(new Rect(10f, 70f, 300f, 30f), "Press ARROW DOWN to lengthen rope!");
		GUI.Label(new Rect(10f, 110f, 150f, 30f), "FreeFall: " + this.rope.FreeFallMode);
		GUI.Label(new Rect(10f, 140f, 150f, 30f), "Max Length: " + this.rope.maxRopeLength.ToString("00"));
		this.rope.maxRopeLength = GUI.HorizontalSlider(new Rect(150f, 150f, 150f, 30f), this.rope.maxRopeLength, 5f, 50f);
	}

	// Token: 0x04000324 RID: 804
	private QuickRope2 rope;
}
