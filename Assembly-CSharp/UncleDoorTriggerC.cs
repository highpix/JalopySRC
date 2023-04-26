using System;
using UnityEngine;

// Token: 0x02000155 RID: 341
public class UncleDoorTriggerC : MonoBehaviour
{
	// Token: 0x06000D4D RID: 3405 RVA: 0x0012F97C File Offset: 0x0012DD7C
	public void OnTriggerEnter(Collider uncle)
	{
		if (uncle.tag == "Uncle")
		{
			this.uncleIn = true;
			if (!this.doorTarget.GetComponent<EnvironmentDoorsC>().open)
			{
				this.doorTarget.SendMessage("Trigger");
			}
		}
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x0012F9CA File Offset: 0x0012DDCA
	public void OnTriggerExit(Collider uncle)
	{
		if (uncle.tag == "Uncle")
		{
			this.uncleIn = false;
			if (this.doorTarget.GetComponent<EnvironmentDoorsC>().open)
			{
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040011CB RID: 4555
	public GameObject doorTarget;

	// Token: 0x040011CC RID: 4556
	public bool uncleIn;
}
