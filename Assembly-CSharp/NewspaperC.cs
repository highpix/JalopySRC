using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x020000D5 RID: 213
public class NewspaperC : MonoBehaviour
{
	// Token: 0x0600085F RID: 2143 RVA: 0x000ADA88 File Offset: 0x000ABE88
	private IEnumerator Start()
	{
		LanguageCode currentLang = Language.CurrentLanguage();
		if (currentLang != LanguageCode.EN)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		this.director = GameObject.FindWithTag("Director");
		if (this.director == null)
		{
			yield break;
		}
		yield return new WaitForSeconds(2.5f);
		if (this.motel != null && this.motel.GetComponent<MotelLogicC>().parkingTrigger.GetComponent<MotelParkingTriggerC>().isMorning)
		{
			if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
			{
				this.EconomyState1_FromStart();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
			{
				this.EconomyState2_FromStart();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
			{
				this.EconomyState3_FromStart();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
			{
				this.EconomyState4_FromStart();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
			{
				this.EconomyState5_FromStart();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
			{
				this.EconomyState6_FromStart();
			}
			this.title.GetComponent<TextMeshPro>().fontSize = 74f;
			yield break;
		}
		if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
		{
			this.EconomyState1();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
		{
			this.EconomyState2();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
		{
			this.EconomyState3();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
		{
			this.EconomyState4();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.EconomyState5();
		}
		else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
		{
			this.EconomyState6();
		}
		this.title.GetComponent<TextMeshPro>().fontSize = 74f;
		yield break;
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x000ADAA4 File Offset: 0x000ABEA4
	private void EconomyState1()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[8];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[8];
				}
				else if (num2 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[9];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[9];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(0, 1);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(6, 7);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[36];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[36];
				}
				else if (num8 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[37];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 2;
				int num11 = num9 + 38;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 8;
				int num14 = num12 + 40;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num13], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[74];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[74];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[75];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[75];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17 + 4;
				int num19 = num17 + 88;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20;
				int num22 = num20 + 96;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = -0.72f;
					this.title.GetComponent<TextMeshPro>().fontSize = 130f;
				}
				else if (num24 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = 2.9f;
					this.title.GetComponent<TextMeshPro>().fontSize = 70f;
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num25 + 10;
				int num27 = num25 + 10 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 2;
				int num30 = num28 + 2 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[154];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[154];
				}
				else if (num32 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[155];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[155];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33 + 6;
				int num35 = num33 + 6 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36 + 4;
				int num38 = num36 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x000AE638 File Offset: 0x000ACA38
	private void EconomyState1_FromStart()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[8];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[8];
				}
				else if (num2 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[9];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[9];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(0, 1);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(6, 7);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[36];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[36];
				}
				else if (num8 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[37];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 2;
				int num11 = num9 + 38;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 8;
				int num14 = num12 + 40;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num13], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[74];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[74];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[75];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[75];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17 + 4;
				int num19 = num17 + 88;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20;
				int num22 = num20 + 96;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[112];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[112];
				}
				else if (num24 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[113];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[113];
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num25 + 10;
				int num27 = num25 + 10 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 2;
				int num30 = num28 + 2 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[154];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[154];
				}
				else if (num32 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[155];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[155];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33 + 6;
				int num35 = num33 + 6 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36 + 4;
				int num38 = num36 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x000AF1DC File Offset: 0x000AD5DC
	private void EconomyState2()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[6];
				}
				else if (num2 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[7];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[7];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(2, 3);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(10, 11);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[42];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[42];
				}
				else if (num8 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[43];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[43];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num7 + 44;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num9], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num10];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num10];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num10];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num10];
				}
			}
			else if (num7 == 3)
			{
				int num11 = UnityEngine.Random.Range(0, 1);
				int num12 = num11 + 6;
				int num13 = num11 + 46;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num11], "Inspector_UI");
				if (num11 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
				else if (num11 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num14 = UnityEngine.Random.Range(1, 3);
			if (num14 == 1)
			{
				int num15 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num15], "Inspector_UI");
				if (num15 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[72];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[72];
				}
				else if (num15 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[73];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[73];
				}
			}
			else if (num14 == 2)
			{
				int num16 = UnityEngine.Random.Range(0, 1);
				int num17 = num16 + 8;
				int num18 = num16 + 92;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num17], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
			}
			else if (num14 == 3)
			{
				int num19 = UnityEngine.Random.Range(0, 1);
				int num20 = num19;
				int num21 = num19 + 96;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num20], "Inspector_UI");
				if (num19 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
				else if (num19 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num22 = UnityEngine.Random.Range(1, 3);
			if (num22 == 1)
			{
				int num23 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num23], "Inspector_UI");
				if (num23 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[116];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[116];
				}
				else if (num23 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[117];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[117];
				}
			}
			else if (num22 == 2)
			{
				int num24 = UnityEngine.Random.Range(0, 1);
				int num25 = num22 + 4;
				int num26 = num22 + 4 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num25], "Inspector_UI");
				if (num24 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
				else if (num24 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
			}
			else if (num22 == 3)
			{
				int num27 = UnityEngine.Random.Range(0, 1);
				int num28 = num27;
				int num29 = num27 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num28], "Inspector_UI");
				if (num27 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
				else if (num27 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num30 = UnityEngine.Random.Range(1, 3);
			if (num30 == 1)
			{
				int num31 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num31], "Inspector_UI");
				if (num31 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[148];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[148];
				}
				else if (num31 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[149];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[149];
				}
			}
			else if (num30 == 2)
			{
				int num32 = UnityEngine.Random.Range(0, 1);
				int num33 = num32 + 10;
				int num34 = num32 + 10 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num33], "Inspector_UI");
				if (num32 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
				else if (num32 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
			}
			else if (num30 == 3)
			{
				int num35 = UnityEngine.Random.Range(0, 1);
				int num36 = num35 + 8;
				int num37 = num35 + 8 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num36], "Inspector_UI");
				if (num35 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
				else if (num35 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
			}
		}
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x000AFD74 File Offset: 0x000AE174
	private void EconomyState2_FromStart()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[6];
				}
				else if (num2 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[7];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[7];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(2, 3);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(10, 11);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[42];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[42];
				}
				else if (num8 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[43];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[43];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num7 + 44;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num9], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num10];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num10];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num10];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num10];
				}
			}
			else if (num7 == 3)
			{
				int num11 = UnityEngine.Random.Range(0, 1);
				int num12 = num11 + 6;
				int num13 = num11 + 46;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num11], "Inspector_UI");
				if (num11 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
				else if (num11 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num14 = UnityEngine.Random.Range(1, 3);
			if (num14 == 1)
			{
				int num15 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num15], "Inspector_UI");
				if (num15 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[72];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[72];
				}
				else if (num15 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[73];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[73];
				}
			}
			else if (num14 == 2)
			{
				int num16 = UnityEngine.Random.Range(0, 1);
				int num17 = num16 + 8;
				int num18 = num16 + 92;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num17], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
			}
			else if (num14 == 3)
			{
				int num19 = UnityEngine.Random.Range(0, 1);
				int num20 = num19;
				int num21 = num19 + 96;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num20], "Inspector_UI");
				if (num19 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
				else if (num19 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num22 = UnityEngine.Random.Range(1, 3);
			if (num22 == 1)
			{
				int num23 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num23], "Inspector_UI");
				if (num23 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[116];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[116];
				}
				else if (num23 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[117];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[117];
				}
			}
			else if (num22 == 2)
			{
				int num24 = UnityEngine.Random.Range(0, 1);
				int num25 = num22 + 4;
				int num26 = num22 + 4 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num25], "Inspector_UI");
				if (num24 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
				else if (num24 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
			}
			else if (num22 == 3)
			{
				int num27 = UnityEngine.Random.Range(0, 1);
				int num28 = num27;
				int num29 = num27 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num28], "Inspector_UI");
				if (num27 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
				else if (num27 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			int num30 = UnityEngine.Random.Range(1, 3);
			if (num30 == 1)
			{
				int num31 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num31], "Inspector_UI");
				if (num31 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[148];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[148];
				}
				else if (num31 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[149];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[149];
				}
			}
			else if (num30 == 2)
			{
				int num32 = UnityEngine.Random.Range(0, 1);
				int num33 = num32 + 10;
				int num34 = num32 + 10 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num33], "Inspector_UI");
				if (num32 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
				else if (num32 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
			}
			else if (num30 == 3)
			{
				int num35 = UnityEngine.Random.Range(0, 1);
				int num36 = num35 + 8;
				int num37 = num35 + 8 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num36], "Inspector_UI");
				if (num35 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
				else if (num35 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
			}
		}
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x000B090C File Offset: 0x000AED0C
	private void EconomyState3()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[0];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[0];
				}
				else if (num2 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[1];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[1];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(10, 11);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(4, 5);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[48];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[48];
				}
				else if (num8 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[49];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[49];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 8;
				int num11 = num9 + 50;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 52;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num12], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num14 = UnityEngine.Random.Range(1, 3);
			if (num14 == 1)
			{
				int num15 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num15], "Inspector_UI");
				if (num15 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[80];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[80];
				}
				else if (num15 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[81];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[81];
				}
			}
			else if (num14 == 2)
			{
				int num16 = UnityEngine.Random.Range(0, 1);
				int num17 = num16 + 2;
				int num18 = num16 + 86;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num17], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
			}
			else if (num14 == 3)
			{
				int num19 = UnityEngine.Random.Range(0, 1);
				int num20 = num19 + 10;
				int num21 = num19 + 106;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num20], "Inspector_UI");
				if (num19 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
				else if (num19 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num22 = UnityEngine.Random.Range(1, 3);
			if (num22 == 1)
			{
				int num23 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num23], "Inspector_UI");
				if (num23 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[114];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[114];
				}
				else if (num23 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[115];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[115];
				}
			}
			else if (num22 == 2)
			{
				int num24 = UnityEngine.Random.Range(0, 1);
				int num25 = num22 + 6;
				int num26 = num22 + 6 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num25], "Inspector_UI");
				if (num24 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
				else if (num24 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
			}
			else if (num22 == 3)
			{
				int num27 = UnityEngine.Random.Range(0, 1);
				int num28 = num27 + 8;
				int num29 = num27 + 8 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num28], "Inspector_UI");
				if (num27 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
				else if (num27 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num30 = UnityEngine.Random.Range(1, 3);
			if (num30 == 1)
			{
				int num31 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num31], "Inspector_UI");
				if (num31 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num31 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num30 == 2)
			{
				int num32 = UnityEngine.Random.Range(0, 1);
				int num33 = num32 + 4;
				int num34 = num32 + 4 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num33], "Inspector_UI");
				if (num32 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
				else if (num32 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
			}
			else if (num30 == 3)
			{
				int num35 = UnityEngine.Random.Range(0, 1);
				int num36 = num35 + 2;
				int num37 = num35 + 2 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num36], "Inspector_UI");
				if (num35 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
				else if (num35 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
			}
		}
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x000B14AC File Offset: 0x000AF8AC
	private void EconomyState3_FromStart()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[0];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[0];
				}
				else if (num2 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[1];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[1];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(10, 11);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(4, 5);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[48];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[48];
				}
				else if (num8 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[49];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[49];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 8;
				int num11 = num9 + 50;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 52;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num12], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num13];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num13];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num14 = UnityEngine.Random.Range(1, 3);
			if (num14 == 1)
			{
				int num15 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num15], "Inspector_UI");
				if (num15 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[80];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[80];
				}
				else if (num15 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[81];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[81];
				}
			}
			else if (num14 == 2)
			{
				int num16 = UnityEngine.Random.Range(0, 1);
				int num17 = num16 + 2;
				int num18 = num16 + 86;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num17], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num18];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num18];
				}
			}
			else if (num14 == 3)
			{
				int num19 = UnityEngine.Random.Range(0, 1);
				int num20 = num19 + 10;
				int num21 = num19 + 106;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num20], "Inspector_UI");
				if (num19 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
				else if (num19 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num21];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num21];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num22 = UnityEngine.Random.Range(1, 3);
			if (num22 == 1)
			{
				int num23 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num23], "Inspector_UI");
				if (num23 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[114];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[114];
				}
				else if (num23 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[115];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[115];
				}
			}
			else if (num22 == 2)
			{
				int num24 = UnityEngine.Random.Range(0, 1);
				int num25 = num22 + 6;
				int num26 = num22 + 6 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num25], "Inspector_UI");
				if (num24 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
				else if (num24 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num26];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num26];
				}
			}
			else if (num22 == 3)
			{
				int num27 = UnityEngine.Random.Range(0, 1);
				int num28 = num27 + 8;
				int num29 = num27 + 8 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num28], "Inspector_UI");
				if (num27 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
				else if (num27 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num29];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num29];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			int num30 = UnityEngine.Random.Range(1, 3);
			if (num30 == 1)
			{
				int num31 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num31], "Inspector_UI");
				if (num31 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num31 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num30 == 2)
			{
				int num32 = UnityEngine.Random.Range(0, 1);
				int num33 = num32 + 4;
				int num34 = num32 + 4 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num33], "Inspector_UI");
				if (num32 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
				else if (num32 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num34];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num34];
				}
			}
			else if (num30 == 3)
			{
				int num35 = UnityEngine.Random.Range(0, 1);
				int num36 = num35 + 2;
				int num37 = num35 + 2 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num36], "Inspector_UI");
				if (num35 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
				else if (num35 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num37];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num37];
				}
			}
		}
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x000B2050 File Offset: 0x000B0450
	private void EconomyState4()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[4];
				}
				else if (num2 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[5];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[5];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(8, 9);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(2, 3);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(8, 8);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[54];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[54];
				}
				else if (num8 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[55];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[55];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 10;
				int num11 = num9 + 56;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 4;
				int num14 = num12 + 58;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num12], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[82];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[82];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[83];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[83];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17 + 6;
				int num19 = num17 + 90;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20 + 8;
				int num22 = num20 + 104;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[118];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[118];
				}
				else if (num24 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[119];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[119];
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num23;
				int num27 = num23 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 10;
				int num30 = num28 + 10 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num32 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33 + 2;
				int num35 = num33 + 2 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36 + 6;
				int num38 = num36 + 6 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x000B2BF0 File Offset: 0x000B0FF0
	private void EconomyState4_FromStart()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[4];
				}
				else if (num2 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[5];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[5];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(8, 9);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(2, 3);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(8, 8);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[54];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[54];
				}
				else if (num8 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[55];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[55];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 10;
				int num11 = num9 + 56;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 4;
				int num14 = num12 + 58;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num12], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[82];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[82];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[83];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[83];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17 + 6;
				int num19 = num17 + 90;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20 + 8;
				int num22 = num20 + 104;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[118];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[118];
				}
				else if (num24 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[119];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[119];
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num23;
				int num27 = num23 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 10;
				int num30 = num28 + 10 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num32 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33 + 2;
				int num35 = num33 + 2 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36 + 6;
				int num38 = num36 + 6 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x000B3794 File Offset: 0x000B1B94
	private void EconomyState5()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[2];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[2];
				}
				else if (num2 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[3];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[3];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(6, 7);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(0, 1);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[60];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[60];
				}
				else if (num8 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[61];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[61];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 4;
				int num11 = num9 + 62;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 2;
				int num14 = num12 + 64;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num13], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[76];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[76];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[77];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[77];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17 + 10;
				int num19 = num17 + 94;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20 + 6;
				int num22 = num20 + 102;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[118];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[118];
				}
				else if (num24 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[119];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[119];
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num23 + 8;
				int num27 = num23 + 8 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 4;
				int num30 = num28 + 4 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num32 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33;
				int num35 = num33 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36 + 10;
				int num38 = num36 + 10 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x000B4338 File Offset: 0x000B2738
	private void EconomyState5_FromStart()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[2];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[2];
				}
				else if (num2 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[3];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[3];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(6, 7);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(0, 1);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 6)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[60];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[60];
				}
				else if (num8 == 7)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[61];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[61];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 4;
				int num11 = num9 + 62;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 2;
				int num14 = num12 + 64;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num13], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[76];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[76];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[77];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[77];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17 + 10;
				int num19 = num17 + 94;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20 + 6;
				int num22 = num20 + 102;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[118];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[118];
				}
				else if (num24 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[119];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[119];
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num23 + 8;
				int num27 = num23 + 8 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 4;
				int num30 = num28 + 4 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(8, 9);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num32 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33;
				int num35 = num33 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36 + 10;
				int num38 = num36 + 10 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x000B4EDC File Offset: 0x000B32DC
	private void EconomyState6()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[10];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[10];
				}
				else if (num2 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[11];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(4, 5);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(8, 9);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[66];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[66];
				}
				else if (num8 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[67];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[67];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 6;
				int num11 = num9 + 68;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 10;
				int num14 = num12 + 70;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num13], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[78];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[78];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[79];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[79];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17;
				int num19 = num17 + 84;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20 + 4;
				int num22 = num20 + 100;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[118];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[118];
				}
				else if (num24 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[119];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[119];
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num23 + 2;
				int num27 = num23 + 2 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 6;
				int num30 = num28 + 6 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num32 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33 + 8;
				int num35 = num33 + 8 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36;
				int num38 = num36 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x000B5A80 File Offset: 0x000B3E80
	private void EconomyState6_FromStart()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			int num = UnityEngine.Random.Range(1, 3);
			if (num == 1)
			{
				int num2 = UnityEngine.Random.Range(10, 11);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedCSFR[num2], "Inspector_UI");
				if (num2 == 10)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[10];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[10];
				}
				else if (num2 == 11)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[11];
				}
			}
			else if (num == 2)
			{
				int num3 = UnityEngine.Random.Range(4, 5);
				int num4 = num3 + 12;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num3], "Inspector_UI");
				if (num3 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
				else if (num3 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num4];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num4];
				}
			}
			else if (num == 3)
			{
				int num5 = UnityEngine.Random.Range(8, 9);
				int num6 = num5 + 24;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableCSFR[num5], "Inspector_UI");
				if (num5 == 8)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
				else if (num5 == 9)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num6];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num6];
				}
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			int num7 = UnityEngine.Random.Range(1, 3);
			if (num7 == 1)
			{
				int num8 = UnityEngine.Random.Range(4, 5);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedHUN[num8], "Inspector_UI");
				if (num8 == 4)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[66];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[66];
				}
				else if (num8 == 5)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[67];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[67];
				}
			}
			else if (num7 == 2)
			{
				int num9 = UnityEngine.Random.Range(0, 1);
				int num10 = num9 + 6;
				int num11 = num9 + 68;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num10], "Inspector_UI");
				if (num9 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
				else if (num9 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num11];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num11];
				}
			}
			else if (num7 == 3)
			{
				int num12 = UnityEngine.Random.Range(0, 1);
				int num13 = num12 + 10;
				int num14 = num12 + 70;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableHUN[num13], "Inspector_UI");
				if (num12 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
				else if (num12 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num14];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num14];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num15 = UnityEngine.Random.Range(1, 3);
			if (num15 == 1)
			{
				int num16 = UnityEngine.Random.Range(6, 7);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedYUGO[num16], "Inspector_UI");
				if (num16 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[78];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[78];
				}
				else if (num16 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[79];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[79];
				}
			}
			else if (num15 == 2)
			{
				int num17 = UnityEngine.Random.Range(0, 1);
				int num18 = num17;
				int num19 = num17 + 84;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num18], "Inspector_UI");
				if (num17 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
				else if (num17 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num19];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num19];
				}
			}
			else if (num15 == 3)
			{
				int num20 = UnityEngine.Random.Range(0, 1);
				int num21 = num20 + 4;
				int num22 = num20 + 100;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableYUGO[num21], "Inspector_UI");
				if (num20 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
				else if (num20 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num22];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num22];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			int num23 = UnityEngine.Random.Range(1, 3);
			if (num23 == 1)
			{
				int num24 = UnityEngine.Random.Range(0, 1);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedBUL[num24], "Inspector_UI");
				if (num24 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[118];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[118];
				}
				else if (num24 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[119];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[119];
				}
			}
			else if (num23 == 2)
			{
				int num25 = UnityEngine.Random.Range(0, 1);
				int num26 = num23 + 2;
				int num27 = num23 + 2 + 120;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num26], "Inspector_UI");
				if (num25 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
				else if (num25 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num27];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num27];
				}
			}
			else if (num23 == 3)
			{
				int num28 = UnityEngine.Random.Range(0, 1);
				int num29 = num28 + 6;
				int num30 = num28 + 6 + 132;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableBUL[num29], "Inspector_UI");
				if (num28 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
				else if (num28 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num30];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num30];
				}
			}
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			int num31 = UnityEngine.Random.Range(1, 3);
			if (num31 == 1)
			{
				int num32 = UnityEngine.Random.Range(2, 3);
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.bannedTURK[num32], "Inspector_UI");
				if (num32 == 2)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[150];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[150];
				}
				else if (num32 == 3)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[151];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[151];
				}
			}
			else if (num31 == 2)
			{
				int num33 = UnityEngine.Random.Range(0, 1);
				int num34 = num33 + 8;
				int num35 = num33 + 8 + 156;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num34], "Inspector_UI");
				if (num33 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
				else if (num33 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num35];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num35];
				}
			}
			else if (num31 == 3)
			{
				int num36 = UnityEngine.Random.Range(0, 1);
				int num37 = num36;
				int num38 = num36 + 168;
				this.title.GetComponent<TextMeshPro>().text = Language.Get(this.valuableTURK[num37], "Inspector_UI");
				if (num36 == 0)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
				else if (num36 == 1)
				{
					this.title.GetComponent<TextMeshPro>().characterSpacing = this.characterSpacing[num38];
					this.title.GetComponent<TextMeshPro>().fontSize = (float)this.fontSize[num38];
				}
			}
		}
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x000B6622 File Offset: 0x000B4A22
	private void UnAction()
	{
	}

	// Token: 0x04000B0D RID: 2829
	public GameObject director;

	// Token: 0x04000B0E RID: 2830
	public GameObject motel;

	// Token: 0x04000B0F RID: 2831
	public GameObject title;

	// Token: 0x04000B10 RID: 2832
	public int[] fontSize = new int[0];

	// Token: 0x04000B11 RID: 2833
	public float[] characterSpacing = new float[0];

	// Token: 0x04000B12 RID: 2834
	public string[] bannedCSFR = new string[0];

	// Token: 0x04000B13 RID: 2835
	public string[] valuableCSFR = new string[0];

	// Token: 0x04000B14 RID: 2836
	public string[] surplussCSFR = new string[0];

	// Token: 0x04000B15 RID: 2837
	public string[] bannedHUN = new string[0];

	// Token: 0x04000B16 RID: 2838
	public string[] valuableHUN = new string[0];

	// Token: 0x04000B17 RID: 2839
	public string[] surplussHUN = new string[0];

	// Token: 0x04000B18 RID: 2840
	public string[] bannedYUGO = new string[0];

	// Token: 0x04000B19 RID: 2841
	public string[] valuableYUGO = new string[0];

	// Token: 0x04000B1A RID: 2842
	public string[] surplussYUGO = new string[0];

	// Token: 0x04000B1B RID: 2843
	public string[] bannedBUL = new string[0];

	// Token: 0x04000B1C RID: 2844
	public string[] valuableBUL = new string[0];

	// Token: 0x04000B1D RID: 2845
	public string[] surplussBUL = new string[0];

	// Token: 0x04000B1E RID: 2846
	public string[] bannedTURK = new string[0];

	// Token: 0x04000B1F RID: 2847
	public string[] valuableTURK = new string[0];

	// Token: 0x04000B20 RID: 2848
	public string[] surplussTURK = new string[0];
}
