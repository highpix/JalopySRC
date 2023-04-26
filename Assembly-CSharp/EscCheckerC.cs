using System;
using UnityEngine;

// Token: 0x020000C7 RID: 199
public class EscCheckerC : MonoBehaviour
{
	// Token: 0x06000758 RID: 1880 RVA: 0x00098EA0 File Offset: 0x000972A0
	private void Update()
	{
		if (Input.GetButtonDown("Cancel") || Input.GetKeyDown("escape"))
		{
			if (this.pageNumber == 1)
			{
				this.map.SendMessage("CloseOptions");
				this.map.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
			}
			else if (this.pageNumber == 2)
			{
				this.map.SendMessage("CloseOptionsVideo");
				this.map.SendMessage("CloseOptionsGameplay");
				this.map.SendMessage("CloseOptionsAudio");
				this.map.SendMessage("CloseOptionsCredits");
				this.map.SendMessage("OpenOptions");
				this.map.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
			}
			else if (this.pageNumber == 3)
			{
				this.map.SendMessage("CloseOptionsInputBack");
				this.map.SendMessage("OpenOptionsGameplay");
				this.map.GetComponent<AudioSource>().PlayOneShot(this.audioClip, 1f);
			}
		}
	}

	// Token: 0x040009D4 RID: 2516
	public GameObject map;

	// Token: 0x040009D5 RID: 2517
	public int pageNumber;

	// Token: 0x040009D6 RID: 2518
	public AudioClip audioClip;
}
