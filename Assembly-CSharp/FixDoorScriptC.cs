using System;
using UnityEngine;

// Token: 0x020000AC RID: 172
public class FixDoorScriptC : MonoBehaviour
{
	// Token: 0x06000665 RID: 1637 RVA: 0x000815E0 File Offset: 0x0007F9E0
	private void Start()
	{
		if (this.isReplacementDoor)
		{
			CarPerformanceC component = GameObject.FindWithTag("CarLogic").GetComponent<CarPerformanceC>();
			component.RepairDoor();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x0008161C File Offset: 0x0007FA1C
	public void AllowFunctionality()
	{
		this.uncle.GetComponent<Scene1_LogicC>().StartCoroutine("DoorFitted");
		base.GetComponent<AudioSource>().PlayOneShot(this.doorCrashAudio, 1f);
		this.particles = UnityEngine.Object.Instantiate<GameObject>(this.particles, base.transform.position, base.transform.rotation);
		UnityEngine.Object.Destroy(this.particles, 0.5f);
		this.doorTrigger.SetActive(true);
		base.gameObject.layer = 2;
		base.gameObject.tag = "CarPaintMesh";
	}

	// Token: 0x04000890 RID: 2192
	public GameObject doorTrigger;

	// Token: 0x04000891 RID: 2193
	public GameObject uncle;

	// Token: 0x04000892 RID: 2194
	public AudioClip doorCrashAudio;

	// Token: 0x04000893 RID: 2195
	public GameObject particles;

	// Token: 0x04000894 RID: 2196
	public bool isReplacementDoor;
}
