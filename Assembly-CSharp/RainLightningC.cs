using System;
using UnityEngine;

// Token: 0x020000EE RID: 238
public class RainLightningC : MonoBehaviour
{
	// Token: 0x06000969 RID: 2409 RVA: 0x000E0224 File Offset: 0x000DE624
	private void Start()
	{
		base.Invoke("Strike", 1f);
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x000E0238 File Offset: 0x000DE638
	public void Strike()
	{
		int num = UnityEngine.Random.Range(0, this.thunder.Length - 1);
		base.GetComponent<AudioSource>().PlayOneShot(this.thunder[num]);
		float time = UnityEngine.Random.Range(30f, 240f);
		if (this.heavyRain)
		{
			time = UnityEngine.Random.Range(10f, 120f);
		}
		base.Invoke("Strike", time);
	}

	// Token: 0x04000CDB RID: 3291
	public bool heavyRain;

	// Token: 0x04000CDC RID: 3292
	public GameObject lightning;

	// Token: 0x04000CDD RID: 3293
	public AudioClip[] thunder = new AudioClip[0];
}
