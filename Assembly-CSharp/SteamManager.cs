using System;
using System.Text;
using Steamworks;
using UnityEngine;

// Token: 0x02000105 RID: 261
[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	// Token: 0x17000032 RID: 50
	// (get) Token: 0x06000A3D RID: 2621 RVA: 0x000EFBDB File Offset: 0x000EDFDB
	private static SteamManager Instance
	{
		get
		{
			if (SteamManager.s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return SteamManager.s_instance;
		}
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x06000A3E RID: 2622 RVA: 0x000EFC02 File Offset: 0x000EE002
	public static bool Initialized
	{
		get
		{
			return SteamManager.Instance.m_bInitialized;
		}
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x000EFC0E File Offset: 0x000EE00E
	private static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x000EFC18 File Offset: 0x000EE018
	private void Awake()
	{
		if (SteamManager.s_instance != null || Application.platform == RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		SteamManager.s_instance = this;
		if (SteamManager.s_EverInialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (!Packsize.Test())
		{
			Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		this.m_bInitialized = SteamAPI.Init();
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamManager.s_EverInialized = true;
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x000EFCBC File Offset: 0x000EE0BC
	private void OnEnable()
	{
		if (SteamManager.s_instance == null)
		{
			SteamManager.s_instance = this;
		}
		if (!this.m_bInitialized)
		{
			return;
		}
		if (this.m_SteamAPIWarningMessageHook == null)
		{
			this.m_SteamAPIWarningMessageHook = new SteamAPIWarningMessageHook_t(SteamManager.SteamAPIDebugTextHook);
			SteamClient.SetWarningMessageHook(this.m_SteamAPIWarningMessageHook);
		}
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x000EFD13 File Offset: 0x000EE113
	private void OnDestroy()
	{
		if (SteamManager.s_instance != this)
		{
			return;
		}
		SteamManager.s_instance = null;
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.Shutdown();
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x000EFD3D File Offset: 0x000EE13D
	private void Update()
	{
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.RunCallbacks();
	}

	// Token: 0x04000E47 RID: 3655
	private static SteamManager s_instance;

	// Token: 0x04000E48 RID: 3656
	private static bool s_EverInialized;

	// Token: 0x04000E49 RID: 3657
	private bool m_bInitialized;

	// Token: 0x04000E4A RID: 3658
	private SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;
}
