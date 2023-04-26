using System;
using UnityEngine;

// Token: 0x02000162 RID: 354
public class XboxController : MonoBehaviour
{
	// Token: 0x06000D93 RID: 3475 RVA: 0x00132C83 File Offset: 0x00131083
	public static void SaveData()
	{
	}

	// Token: 0x04001228 RID: 4648
	public GameObject padDisconnected;

	// Token: 0x04001229 RID: 4649
	public uint gamepadIndex;

	// Token: 0x0400122A RID: 4650
	private float lastTimeScale = 1f;

	// Token: 0x0400122B RID: 4651
	public bool turnPauseOn;

	// Token: 0x0400122C RID: 4652
	public bool initialiseSaves;

	// Token: 0x0400122D RID: 4653
	private const string kContainerName = "Jalopy Container";

	// Token: 0x0400122E RID: 4654
	private const string kBufferName = "JalopyGame";

	// Token: 0x0400122F RID: 4655
	private const string kSaveText = "TextToSave";

	// Token: 0x04001230 RID: 4656
	private const int kMaxSaveSize = 16384;

	// Token: 0x04001231 RID: 4657
	private int mUserId;
}
