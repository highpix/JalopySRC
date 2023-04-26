using System;
using UnityEngine;

// Token: 0x020000FE RID: 254
internal class SpaceWarClient : MonoBehaviour
{
	// Token: 0x06000A07 RID: 2567 RVA: 0x000EDE4E File Offset: 0x000EC24E
	private void OnEnable()
	{
		this.m_StatsAndAchievements = UnityEngine.Object.FindObjectOfType<SteamStatsAndAchievements>();
		this.m_StatsAndAchievements.OnGameStateChange(EClientGameState.k_EClientGameActive);
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x000EDE68 File Offset: 0x000EC268
	private void OnGUI()
	{
		this.m_StatsAndAchievements.Render();
		GUILayout.Space(10f);
		if (GUILayout.Button("Set State to Active", new GUILayoutOption[0]))
		{
			this.m_StatsAndAchievements.OnGameStateChange(EClientGameState.k_EClientGameActive);
		}
		if (GUILayout.Button("Set State to Winner", new GUILayoutOption[0]))
		{
			this.m_StatsAndAchievements.OnGameStateChange(EClientGameState.k_EClientGameWinner);
		}
		if (GUILayout.Button("Set State to Loser", new GUILayoutOption[0]))
		{
			this.m_StatsAndAchievements.OnGameStateChange(EClientGameState.k_EClientGameLoser);
		}
		if (GUILayout.Button("Add Distance Traveled +100", new GUILayoutOption[0]))
		{
			this.m_StatsAndAchievements.AddDistanceTraveled(100f);
		}
	}

	// Token: 0x04000DE7 RID: 3559
	private SteamStatsAndAchievements m_StatsAndAchievements;
}
