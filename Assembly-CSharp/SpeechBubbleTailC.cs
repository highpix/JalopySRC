using System;
using UnityEngine;

// Token: 0x020000FF RID: 255
public class SpeechBubbleTailC : MonoBehaviour
{
	// Token: 0x06000A0A RID: 2570 RVA: 0x000EDF1A File Offset: 0x000EC31A
	private void Start()
	{
		this.uncleMouth = this.uncle.GetComponent<UncleLogicC>().mouth;
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x000EDF34 File Offset: 0x000EC334
	private void Update()
	{
		this.timer += Time.deltaTime;
		if ((double)this.timer > 0.01)
		{
			base.GetComponent<LineRenderer>().SetPosition(0, this.uncleMouth.position);
			base.GetComponent<LineRenderer>().SetPosition(1, this.playerMouth.position);
			this.timer = 0f;
		}
	}

	// Token: 0x04000DE8 RID: 3560
	public GameObject uncle;

	// Token: 0x04000DE9 RID: 3561
	public Transform uncleMouth;

	// Token: 0x04000DEA RID: 3562
	public Transform playerMouth;

	// Token: 0x04000DEB RID: 3563
	private float timer;
}
