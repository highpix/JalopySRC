using System;
using UnityEngine;

// Token: 0x02000076 RID: 118
[RequireComponent(typeof(QuickRope2))]
[ExecuteInEditMode]
[Serializable]
public class QuickRope2Line : MonoBehaviour
{
	// Token: 0x0600021E RID: 542 RVA: 0x0001BD80 File Offset: 0x0001A180
	private void OnEnable()
	{
		this.rope = base.GetComponent<QuickRope2>();
		if (base.gameObject.GetComponent<LineRenderer>() == null)
		{
			this.line = base.gameObject.AddComponent<LineRenderer>();
		}
		else
		{
			this.line = base.gameObject.GetComponent<LineRenderer>();
		}
		if (this.line.sharedMaterial == null)
		{
			this.line.sharedMaterial = (Material)Resources.Load("Materials/RopeLineMaterial", typeof(Material));
		}
		this.rope.OnInitializeMesh += this.OnInitializeMesh;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x0001BE27 File Offset: 0x0001A227
	private void OnDisable()
	{
		this.rope.OnInitializeMesh -= this.OnInitializeMesh;
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0001BE40 File Offset: 0x0001A240
	private void OnDestroy()
	{
		if (this.rope)
		{
			this.rope.OnInitializeMesh -= this.OnInitializeMesh;
		}
	}

	// Token: 0x06000221 RID: 545 RVA: 0x0001BE6C File Offset: 0x0001A26C
	public void OnInitializeMesh()
	{
		if (this.rope == null)
		{
			return;
		}
		this.rope.GenerateJointObjects();
		this.Update();
		if (this.useAutoTextureTiling)
		{
			base.gameObject.GetComponent<LineRenderer>().sharedMaterial.mainTextureScale = new Vector2((float)this.rope.Joints.Count / 2f, 1f);
		}
	}

	// Token: 0x06000222 RID: 546 RVA: 0x0001BEE0 File Offset: 0x0001A2E0
	private void Update()
	{
		if (this.line == null)
		{
			return;
		}
		if (this.useAutoTextureTiling && Application.isPlaying)
		{
			this.line.material.mainTextureScale = new Vector2((float)this.rope.Joints.Count / 2f, 1f);
		}
		int num = 0;
		this.line.SetVertexCount(this.rope.Joints.Count);
		foreach (GameObject gameObject in this.rope.Joints)
		{
			this.line.SetPosition(num++, gameObject.transform.position);
		}
	}

	// Token: 0x0400037C RID: 892
	private QuickRope2 rope;

	// Token: 0x0400037D RID: 893
	private LineRenderer line;

	// Token: 0x0400037E RID: 894
	public bool useAutoTextureTiling = true;
}
