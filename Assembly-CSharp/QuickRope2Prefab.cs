using System;
using UnityEngine;

// Token: 0x02000078 RID: 120
[RequireComponent(typeof(QuickRope2))]
[ExecuteInEditMode]
public class QuickRope2Prefab : MonoBehaviour
{
	// Token: 0x0600022B RID: 555 RVA: 0x0001C2A0 File Offset: 0x0001A6A0
	private void OnEnable()
	{
		this.rope = base.GetComponent<QuickRope2>();
		if (this.prefab == null)
		{
			this.prefab = (GameObject)Resources.Load("Link", typeof(GameObject));
		}
		this.rope.OnInitializeMesh += this.OnInitializeMesh;
	}

	// Token: 0x0600022C RID: 556 RVA: 0x0001C300 File Offset: 0x0001A700
	private void OnDisable()
	{
		this.rope.OnInitializeMesh -= this.OnInitializeMesh;
	}

	// Token: 0x0600022D RID: 557 RVA: 0x0001C319 File Offset: 0x0001A719
	private void OnDestroy()
	{
		this.rope.OnInitializeMesh -= this.OnInitializeMesh;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x0001C332 File Offset: 0x0001A732
	public void OnInitializeMesh()
	{
		if (!this.prefab)
		{
			return;
		}
		this.rope.JointPrefab = this.prefab;
		this.rope.JointScale = this.jointScale;
		this.rope.GenerateJointObjects();
	}

	// Token: 0x04000388 RID: 904
	public GameObject prefab;

	// Token: 0x04000389 RID: 905
	public float jointScale = 1f;

	// Token: 0x0400038A RID: 906
	public bool alternateJoints = true;

	// Token: 0x0400038B RID: 907
	public bool firstJointAlternated;

	// Token: 0x0400038C RID: 908
	private QuickRope2 rope;
}
