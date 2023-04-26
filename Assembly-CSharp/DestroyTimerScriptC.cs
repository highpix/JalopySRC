using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
public class DestroyTimerScriptC : MonoBehaviour
{
	// Token: 0x06000D52 RID: 3410 RVA: 0x0012FA4C File Offset: 0x0012DE4C
	private void Update()
	{
		this.timer += Time.deltaTime;
		if (this.destroyAfter <= this.timer)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040011CE RID: 4558
	public float destroyAfter = 7f;

	// Token: 0x040011CF RID: 4559
	private float timer;
}
