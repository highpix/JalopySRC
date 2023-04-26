using System;
using Steamworks;
using UnityEngine;

// Token: 0x02000101 RID: 257
public class SteamScript : MonoBehaviour
{
	// Token: 0x06000A1A RID: 2586 RVA: 0x000EED6F File Offset: 0x000ED16F
	private void Awake()
	{
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x000EED99 File Offset: 0x000ED199
	private void Start()
	{
		if (SteamManager.Initialized)
		{
			Debug.Log(base.name);
		}
	}

	// Token: 0x04000DFD RID: 3581
	protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

	// Token: 0x04000DFE RID: 3582
	private CallResult<NumberOfCurrentPlayers_t> m_NumberOfCurrentPlayers;
}
