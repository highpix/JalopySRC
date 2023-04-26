using System;
using Steamworks;
using UnityEngine;

// Token: 0x02000102 RID: 258
internal class SteamStatsAndAchievements : MonoBehaviour
{
	// Token: 0x06000A1D RID: 2589 RVA: 0x000EF00C File Offset: 0x000ED40C
	private void OnEnable()
	{
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (!SteamManager.Initialized)
		{
			return;
		}
		this.m_GameID = new CGameID(SteamUtils.GetAppID());
		this.m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(new Callback<UserStatsReceived_t>.DispatchDelegate(this.OnUserStatsReceived));
		this.m_UserStatsStored = Callback<UserStatsStored_t>.Create(new Callback<UserStatsStored_t>.DispatchDelegate(this.OnUserStatsStored));
		this.m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(new Callback<UserAchievementStored_t>.DispatchDelegate(this.OnAchievementStored));
		this.m_bRequestedStats = false;
		this.m_bStatsValid = false;
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x000EF0A0 File Offset: 0x000ED4A0
	private void Update()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (!this.m_bRequestedStats)
		{
			if (!SteamManager.Initialized)
			{
				this.m_bRequestedStats = true;
				return;
			}
			bool bRequestedStats = SteamUserStats.RequestCurrentStats();
			this.m_bRequestedStats = bRequestedStats;
		}
		if (!this.m_bStatsValid)
		{
			return;
		}
		foreach (SteamStatsAndAchievements.Achievement_t achievement_t in this.m_Achievements)
		{
			if (!achievement_t.m_bAchieved)
			{
				switch (achievement_t.m_eAchievementID)
				{
				case SteamStatsAndAchievements.Achievement.ACH_WIN_ONE_GAME:
					if (this.m_nTotalNumWins != 0)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_WIN_100_GAMES:
					if (this.m_nTotalNumWins >= 100)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_TRAVEL_FAR_ACCUM:
					if (this.m_flTotalFeetTraveled >= 5280f)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_TRAVEL_FAR_SINGLE:
					if (this.m_flGameFeetTraveled >= 500f)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_STORY_1:
					if (this.jal_storyAchievement1)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_STORY_2:
					if (this.jal_storyAchievement2)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_STORY_3:
					if (this.jal_storyAchievement3)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_STORY_4:
					if (this.jal_storyAchievement4)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_STORY_5:
					if (this.jal_storyAchievement5)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_STORY_6:
					if (this.jal_storyAchievement6)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_DRIVE_1:
					if (this._odometer >= 10000)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_DRIVE_2:
					if (this._odometer >= 50000)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_DRIVE_3:
					if (this._odometer >= 100000)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_DRIVE_4:
					if (this._odometer == 999999)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_ECON_1:
					if (this._gerGoodsValue >= 300)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_ECON_2:
					if (this._csfrGoodsValue >= 350)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_ECON_3:
					if (this._hunGoodsValue >= 400)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_ECON_4:
					if (this._yugoGoodsValue >= 450)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_ECON_5:
					if (this._bulGoodsValue >= 500)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_ECON_6:
					if (this._turkGoodsValue >= 550)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_EGG_1:
					if (this._hornDead)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_EGG_2:
					if (this._ranOutOfFuel)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_CHAL_1:
					if (this._smuggledWine)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_EGG_3:
					if (this._thief)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_EGG_4:
					if (this._bigCollision)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_CHAL_2:
					if (this._thereAndBack)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_CHAL_3:
					if (this._purist)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				case SteamStatsAndAchievements.Achievement.ACH_EGG_5:
					if (this._proudOwner)
					{
						this.UnlockAchievement(achievement_t);
					}
					break;
				}
			}
		}
		if (this.m_bStoreStats)
		{
			SteamUserStats.SetStat("NumGames", this.m_nTotalGamesPlayed);
			SteamUserStats.SetStat("NumWins", this.m_nTotalNumWins);
			SteamUserStats.SetStat("NumLosses", this.m_nTotalNumLosses);
			SteamUserStats.SetStat("FeetTraveled", this.m_flTotalFeetTraveled);
			SteamUserStats.SetStat("MaxFeetTraveled", this.m_flMaxFeetTraveled);
			SteamUserStats.UpdateAvgRateStat("AverageSpeed", this.m_flGameFeetTraveled, this.m_flGameDurationSeconds);
			SteamUserStats.GetStat("AverageSpeed", out this.m_flAverageSpeed);
			bool flag = SteamUserStats.StoreStats();
			this.m_bStoreStats = !flag;
		}
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x000EF501 File Offset: 0x000ED901
	public void AddDistanceTraveled(float flDistance)
	{
		this.m_flGameFeetTraveled += flDistance;
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x000EF514 File Offset: 0x000ED914
	public void OnGameStateChange(EClientGameState eNewState)
	{
		if (!this.m_bStatsValid)
		{
			return;
		}
		if (eNewState == EClientGameState.k_EClientGameActive)
		{
			this.m_flGameFeetTraveled = 0f;
			this.m_ulTickCountGameStart = Time.time;
		}
		else if (eNewState == EClientGameState.k_EClientGameWinner || eNewState == EClientGameState.k_EClientGameLoser)
		{
			if (eNewState == EClientGameState.k_EClientGameWinner)
			{
				this.m_nTotalNumWins++;
			}
			else
			{
				this.m_nTotalNumLosses++;
			}
			this.m_nTotalGamesPlayed++;
			this.m_flTotalFeetTraveled += this.m_flGameFeetTraveled;
			if (this.m_flGameFeetTraveled > this.m_flMaxFeetTraveled)
			{
				this.m_flMaxFeetTraveled = this.m_flGameFeetTraveled;
			}
			this.m_flGameDurationSeconds = (double)(Time.time - this.m_ulTickCountGameStart);
			this.m_bStoreStats = true;
		}
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x000EF5DC File Offset: 0x000ED9DC
	private void UnlockAchievement(SteamStatsAndAchievements.Achievement_t achievement)
	{
		achievement.m_bAchieved = true;
		SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());
		this.m_bStoreStats = true;
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x000EF603 File Offset: 0x000EDA03
	public void UnlockAchievement1()
	{
		this.jal_storyAchievement1 = true;
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x000EF60C File Offset: 0x000EDA0C
	public void UnlockAchievement2()
	{
		this.jal_storyAchievement2 = true;
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x000EF615 File Offset: 0x000EDA15
	public void UnlockAchievement3()
	{
		this.jal_storyAchievement3 = true;
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x000EF61E File Offset: 0x000EDA1E
	public void UnlockAchievement4()
	{
		this.jal_storyAchievement4 = true;
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x000EF627 File Offset: 0x000EDA27
	public void UnlockAchievement5()
	{
		this.jal_storyAchievement5 = true;
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x000EF630 File Offset: 0x000EDA30
	public void UnlockAchievement6()
	{
		this.jal_storyAchievement6 = true;
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x000EF639 File Offset: 0x000EDA39
	public void OdometerUp(int odo)
	{
		this._odometer = odo;
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x000EF642 File Offset: 0x000EDA42
	public void UpdateGerGoodsTracking(int amt)
	{
		this._gerGoodsValue = amt;
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x000EF64B File Offset: 0x000EDA4B
	public void UpdateCsfrGoodsTracking(int amt)
	{
		this._csfrGoodsValue = amt;
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x000EF654 File Offset: 0x000EDA54
	public void UpdateHunGoodsTracking(int amt)
	{
		this._hunGoodsValue = amt;
	}

	// Token: 0x06000A2C RID: 2604 RVA: 0x000EF65D File Offset: 0x000EDA5D
	public void UpdateYugoGoodsTracking(int amt)
	{
		this._yugoGoodsValue = amt;
	}

	// Token: 0x06000A2D RID: 2605 RVA: 0x000EF666 File Offset: 0x000EDA66
	public void UpdateBulGoodsTracking(int amt)
	{
		this._bulGoodsValue = amt;
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x000EF66F File Offset: 0x000EDA6F
	public void UpdateTurkGoodsTracking(int amt)
	{
		this._turkGoodsValue = amt;
	}

	// Token: 0x06000A2F RID: 2607 RVA: 0x000EF678 File Offset: 0x000EDA78
	public void HornDead()
	{
		this._hornDead = true;
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x000EF681 File Offset: 0x000EDA81
	public void RanOutOfFuel()
	{
		this._ranOutOfFuel = true;
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x000EF68A File Offset: 0x000EDA8A
	public void SmugglerAchievement()
	{
		this._smuggledWine = true;
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x000EF693 File Offset: 0x000EDA93
	public void ThiefAchieve()
	{
		this._thief = true;
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x000EF69C File Offset: 0x000EDA9C
	public void BigCollision()
	{
		this._bigCollision = true;
	}

	// Token: 0x06000A34 RID: 2612 RVA: 0x000EF6A5 File Offset: 0x000EDAA5
	public void ThereAndBack()
	{
		this._thereAndBack = true;
	}

	// Token: 0x06000A35 RID: 2613 RVA: 0x000EF6AE File Offset: 0x000EDAAE
	public void Purist()
	{
		this._purist = true;
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x000EF6B7 File Offset: 0x000EDAB7
	public void UpdateProudOwner()
	{
		this._proudOwner = true;
	}

	// Token: 0x06000A37 RID: 2615 RVA: 0x000EF6C0 File Offset: 0x000EDAC0
	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (pCallback.m_eResult == EResult.k_EResultOK)
			{
				Debug.Log("Received stats and achievements from Steam\n");
				this.m_bStatsValid = true;
				foreach (SteamStatsAndAchievements.Achievement_t achievement_t in this.m_Achievements)
				{
					bool achievement = SteamUserStats.GetAchievement(achievement_t.m_eAchievementID.ToString(), out achievement_t.m_bAchieved);
					if (achievement)
					{
						achievement_t.m_strName = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "name");
						achievement_t.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "desc");
					}
					else
					{
						Debug.LogWarning("SteamUserStats.GetAchievement failed for Achievement " + achievement_t.m_eAchievementID + "\nIs it registered in the Steam Partner site?");
					}
				}
				SteamUserStats.GetStat("NumGames", out this.m_nTotalGamesPlayed);
				SteamUserStats.GetStat("NumWins", out this.m_nTotalNumWins);
				SteamUserStats.GetStat("NumLosses", out this.m_nTotalNumLosses);
				SteamUserStats.GetStat("FeetTraveled", out this.m_flTotalFeetTraveled);
				SteamUserStats.GetStat("MaxFeetTraveled", out this.m_flMaxFeetTraveled);
				SteamUserStats.GetStat("AverageSpeed", out this.m_flAverageSpeed);
			}
			else
			{
				Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	// Token: 0x06000A38 RID: 2616 RVA: 0x000EF83C File Offset: 0x000EDC3C
	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (pCallback.m_eResult == EResult.k_EResultOK)
			{
				Debug.Log("StoreStats - success");
			}
			else if (pCallback.m_eResult == EResult.k_EResultInvalidParam)
			{
				Debug.Log("StoreStats - some failed to validate");
				this.OnUserStatsReceived(new UserStatsReceived_t
				{
					m_eResult = EResult.k_EResultOK,
					m_nGameID = (ulong)this.m_GameID
				});
			}
			else
			{
				Debug.Log("StoreStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	// Token: 0x06000A39 RID: 2617 RVA: 0x000EF8DC File Offset: 0x000EDCDC
	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (pCallback.m_nMaxProgress == 0U)
			{
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
			}
			else
			{
				Debug.Log(string.Concat(new object[]
				{
					"Achievement '",
					pCallback.m_rgchAchievementName,
					"' progress callback, (",
					pCallback.m_nCurProgress,
					",",
					pCallback.m_nMaxProgress,
					")"
				}));
			}
		}
	}

	// Token: 0x06000A3A RID: 2618 RVA: 0x000EF984 File Offset: 0x000EDD84
	public void Render()
	{
		if (!SteamManager.Initialized)
		{
			GUILayout.Label("Steamworks not Initialized", new GUILayoutOption[0]);
			return;
		}
		GUILayout.Label("m_ulTickCountGameStart: " + this.m_ulTickCountGameStart, new GUILayoutOption[0]);
		GUILayout.Label("m_flGameDurationSeconds: " + this.m_flGameDurationSeconds, new GUILayoutOption[0]);
		GUILayout.Label("m_flGameFeetTraveled: " + this.m_flGameFeetTraveled, new GUILayoutOption[0]);
		GUILayout.Space(10f);
		GUILayout.Label("NumGames: " + this.m_nTotalGamesPlayed, new GUILayoutOption[0]);
		GUILayout.Label("NumWins: " + this.m_nTotalNumWins, new GUILayoutOption[0]);
		GUILayout.Label("NumLosses: " + this.m_nTotalNumLosses, new GUILayoutOption[0]);
		GUILayout.Label("FeetTraveled: " + this.m_flTotalFeetTraveled, new GUILayoutOption[0]);
		GUILayout.Label("MaxFeetTraveled: " + this.m_flMaxFeetTraveled, new GUILayoutOption[0]);
		GUILayout.Label("AverageSpeed: " + this.m_flAverageSpeed, new GUILayoutOption[0]);
		GUILayout.BeginArea(new Rect((float)(Screen.width - 300), 0f, 300f, 800f));
		foreach (SteamStatsAndAchievements.Achievement_t achievement_t in this.m_Achievements)
		{
			GUILayout.Label(achievement_t.m_eAchievementID.ToString(), new GUILayoutOption[0]);
			GUILayout.Label(achievement_t.m_strName + " - " + achievement_t.m_strDescription, new GUILayoutOption[0]);
			GUILayout.Label("Achieved: " + achievement_t.m_bAchieved, new GUILayoutOption[0]);
			GUILayout.Space(20f);
		}
		if (GUILayout.Button("RESET STATS AND ACHIEVEMENTS", new GUILayoutOption[0]))
		{
			SteamUserStats.ResetAllStats(true);
			SteamUserStats.RequestCurrentStats();
			this.OnGameStateChange(EClientGameState.k_EClientGameActive);
		}
		GUILayout.EndArea();
	}

	// Token: 0x04000DFF RID: 3583
	private SteamStatsAndAchievements.Achievement_t[] m_Achievements = new SteamStatsAndAchievements.Achievement_t[]
	{
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_WIN_ONE_GAME, "Winner", string.Empty),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_WIN_100_GAMES, "Champion", string.Empty),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_TRAVEL_FAR_ACCUM, "Interstellar", string.Empty),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_TRAVEL_FAR_SINGLE, "Orbiter", string.Empty),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_STORY_1, "State Denial, August 1989", "Read Uncle's letter in his suitcase in Germany"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_STORY_2, "Opportunity Plans, November 1989", "Read Uncle's letter in his suitcase in CSFR"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_STORY_3, "Barrier, July 1961, August 1989", "Read Uncle's letter in his suitcase in Hungary"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_STORY_4, "Censorship, July 1977", "Read Uncle's letter in his suitcase in Yugoslavia"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_STORY_5, "Time, November 1989", "Read Uncle's letter in his suitcase in Bulgaria"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_STORY_6, "Goodbye", "Read Uncle's letter in his suitcase in Turkey"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_DRIVE_1, "Explorer", "Drive 10,000 KM"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_DRIVE_2, "Voyager", "Drive 50,000 KM"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_DRIVE_3, "Grand Tourer", "Drive 100,000 KM"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_DRIVE_4, "It's a Classic", "Max out the odometer"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_ECON_1, "GDR", "Dispense 300 Marks into the East-German economy"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_ECON_2, "CSFR", "Dispense 350 Marks into the CSFR economy"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_ECON_3, "Hungary", "Dispense 400 Marks into the Hungarian economy"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_ECON_4, "Yugoslavia", "Dispense 450 Marks into the Yugoslavia economy"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_ECON_5, "Bulgaria", "Dispense 500 Marks into the Bulgarian economy"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_ECON_6, "Turkey", "Dispense 550 Marks into the Turkish economy"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_EGG_1, "Hear me Roar", "Use the horn till it burns out"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_EGG_2, "Rite of passage", "Run out of fuel"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_CHAL_1, "Bootlegger", "Smuggle 6 bottles of wine through a single checkpoint"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_EGG_3, "Garbage Cannot", "Experienced karma"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_EGG_4, "I'll be able to buff this out no problem!", "Experienced a really big collision"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_CHAL_2, "There, and back again", "Drive from Germany, to Turkey, and back to Germany in one session"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_CHAL_3, "Purist", "Drive to Istanbul with all the starting components, tyres & no upgrades"),
		new SteamStatsAndAchievements.Achievement_t(SteamStatsAndAchievements.Achievement.ACH_EGG_5, "Proud Owner", "Clean dirt off the car 50 times")
	};

	// Token: 0x04000E00 RID: 3584
	private CGameID m_GameID;

	// Token: 0x04000E01 RID: 3585
	private bool m_bRequestedStats;

	// Token: 0x04000E02 RID: 3586
	private bool m_bStatsValid;

	// Token: 0x04000E03 RID: 3587
	private bool m_bStoreStats;

	// Token: 0x04000E04 RID: 3588
	private float m_flGameFeetTraveled;

	// Token: 0x04000E05 RID: 3589
	private float m_ulTickCountGameStart;

	// Token: 0x04000E06 RID: 3590
	private double m_flGameDurationSeconds;

	// Token: 0x04000E07 RID: 3591
	public bool jal_storyAchievement1;

	// Token: 0x04000E08 RID: 3592
	public bool jal_storyAchievement2;

	// Token: 0x04000E09 RID: 3593
	public bool jal_storyAchievement3;

	// Token: 0x04000E0A RID: 3594
	public bool jal_storyAchievement4;

	// Token: 0x04000E0B RID: 3595
	public bool jal_storyAchievement5;

	// Token: 0x04000E0C RID: 3596
	public bool jal_storyAchievement6;

	// Token: 0x04000E0D RID: 3597
	public int _odometer;

	// Token: 0x04000E0E RID: 3598
	public int _gerGoodsValue;

	// Token: 0x04000E0F RID: 3599
	public int _csfrGoodsValue;

	// Token: 0x04000E10 RID: 3600
	public int _hunGoodsValue;

	// Token: 0x04000E11 RID: 3601
	public int _yugoGoodsValue;

	// Token: 0x04000E12 RID: 3602
	public int _bulGoodsValue;

	// Token: 0x04000E13 RID: 3603
	public int _turkGoodsValue;

	// Token: 0x04000E14 RID: 3604
	public bool _hornDead;

	// Token: 0x04000E15 RID: 3605
	public bool _ranOutOfFuel;

	// Token: 0x04000E16 RID: 3606
	public bool _smuggledWine;

	// Token: 0x04000E17 RID: 3607
	public bool _thief;

	// Token: 0x04000E18 RID: 3608
	public bool _bigCollision;

	// Token: 0x04000E19 RID: 3609
	public bool _thereAndBack;

	// Token: 0x04000E1A RID: 3610
	public bool _purist;

	// Token: 0x04000E1B RID: 3611
	public bool _proudOwner;

	// Token: 0x04000E1C RID: 3612
	private int m_nTotalGamesPlayed;

	// Token: 0x04000E1D RID: 3613
	private int m_nTotalNumWins;

	// Token: 0x04000E1E RID: 3614
	private int m_nTotalNumLosses;

	// Token: 0x04000E1F RID: 3615
	private float m_flTotalFeetTraveled;

	// Token: 0x04000E20 RID: 3616
	private float m_flMaxFeetTraveled;

	// Token: 0x04000E21 RID: 3617
	private float m_flAverageSpeed;

	// Token: 0x04000E22 RID: 3618
	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	// Token: 0x04000E23 RID: 3619
	protected Callback<UserStatsStored_t> m_UserStatsStored;

	// Token: 0x04000E24 RID: 3620
	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	// Token: 0x02000103 RID: 259
	private enum Achievement
	{
		// Token: 0x04000E26 RID: 3622
		ACH_WIN_ONE_GAME,
		// Token: 0x04000E27 RID: 3623
		ACH_WIN_100_GAMES,
		// Token: 0x04000E28 RID: 3624
		ACH_HEAVY_FIRE,
		// Token: 0x04000E29 RID: 3625
		ACH_TRAVEL_FAR_ACCUM,
		// Token: 0x04000E2A RID: 3626
		ACH_TRAVEL_FAR_SINGLE,
		// Token: 0x04000E2B RID: 3627
		ACH_STORY_1,
		// Token: 0x04000E2C RID: 3628
		ACH_STORY_2,
		// Token: 0x04000E2D RID: 3629
		ACH_STORY_3,
		// Token: 0x04000E2E RID: 3630
		ACH_STORY_4,
		// Token: 0x04000E2F RID: 3631
		ACH_STORY_5,
		// Token: 0x04000E30 RID: 3632
		ACH_STORY_6,
		// Token: 0x04000E31 RID: 3633
		ACH_DRIVE_1,
		// Token: 0x04000E32 RID: 3634
		ACH_DRIVE_2,
		// Token: 0x04000E33 RID: 3635
		ACH_DRIVE_3,
		// Token: 0x04000E34 RID: 3636
		ACH_DRIVE_4,
		// Token: 0x04000E35 RID: 3637
		ACH_ECON_1,
		// Token: 0x04000E36 RID: 3638
		ACH_ECON_2,
		// Token: 0x04000E37 RID: 3639
		ACH_ECON_3,
		// Token: 0x04000E38 RID: 3640
		ACH_ECON_4,
		// Token: 0x04000E39 RID: 3641
		ACH_ECON_5,
		// Token: 0x04000E3A RID: 3642
		ACH_ECON_6,
		// Token: 0x04000E3B RID: 3643
		ACH_EGG_1,
		// Token: 0x04000E3C RID: 3644
		ACH_EGG_2,
		// Token: 0x04000E3D RID: 3645
		ACH_CHAL_1,
		// Token: 0x04000E3E RID: 3646
		ACH_EGG_3,
		// Token: 0x04000E3F RID: 3647
		ACH_EGG_4,
		// Token: 0x04000E40 RID: 3648
		ACH_CHAL_2,
		// Token: 0x04000E41 RID: 3649
		ACH_CHAL_3,
		// Token: 0x04000E42 RID: 3650
		ACH_EGG_5
	}

	// Token: 0x02000104 RID: 260
	private class Achievement_t
	{
		// Token: 0x06000A3B RID: 2619 RVA: 0x000EFBAF File Offset: 0x000EDFAF
		public Achievement_t(SteamStatsAndAchievements.Achievement achievementID, string name, string desc)
		{
			this.m_eAchievementID = achievementID;
			this.m_strName = name;
			this.m_strDescription = desc;
			this.m_bAchieved = false;
		}

		// Token: 0x04000E43 RID: 3651
		public SteamStatsAndAchievements.Achievement m_eAchievementID;

		// Token: 0x04000E44 RID: 3652
		public string m_strName;

		// Token: 0x04000E45 RID: 3653
		public string m_strDescription;

		// Token: 0x04000E46 RID: 3654
		public bool m_bAchieved;
	}
}
