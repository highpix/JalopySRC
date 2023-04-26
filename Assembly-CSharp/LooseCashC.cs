using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000C2 RID: 194
public class LooseCashC : MonoBehaviour
{
	// Token: 0x06000715 RID: 1813 RVA: 0x0008C8AC File Offset: 0x0008ACAC
	public IEnumerator PickUp()
	{
		if (this.uncle != null)
		{
			this.uncle.GetComponent<Animator>().SetBool("giveItem", false);
		}
		GameObject director = GameObject.FindWithTag("Director");
		director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().TotalWealth += (float)this.cashValue;
		director.GetComponent<DirectorC>().wallet.GetComponent<WalletC>().UpdateWealth();
		UnityEngine.Object.Destroy(base.gameObject.GetComponent<BoxCollider>());
		base.GetComponent<AudioSource>().PlayOneShot(this.audioCash, 0.8f);
		this.particles.GetComponent<ParticleSystem>().Play();
		yield return new WaitForSeconds(0.15f);
		Camera.main.GetComponent<DragRigidbodyC>().pickingUp = false;
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04000993 RID: 2451
	public GameObject uncle;

	// Token: 0x04000994 RID: 2452
	public int cashValue;

	// Token: 0x04000995 RID: 2453
	public GameObject particles;

	// Token: 0x04000996 RID: 2454
	public AudioClip audioCash;
}
