using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class NPCAIC : MonoBehaviour
{
	// Token: 0x0600086E RID: 2158 RVA: 0x000B697C File Offset: 0x000B4D7C
	private void Start()
	{
		base.GetComponent<Animator>().SetInteger("persona", this.persona);
		base.GetComponent<Animator>().SetBool("driving", this.isDriving);
	}

	// Token: 0x04000B21 RID: 2849
	public int persona;

	// Token: 0x04000B22 RID: 2850
	public bool isDriving;
}
