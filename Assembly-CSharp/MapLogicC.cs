using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x020000CC RID: 204
public class MapLogicC : MonoBehaviour
{
	// Token: 0x060007FD RID: 2045 RVA: 0x000A56DC File Offset: 0x000A3ADC
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		MapLogic component = base.GetComponent<MapLogic>();
		this.director = component.director;
		this.carLogic = component.carLogic;
		this.doorLoc = component.doorLoc;
		this.animatedBook = component.animatedBook;
		this.playerCamLocAdjustment = component.playerCamLocAdjustment;
		this.holdingPosition = component.holdingPosition;
		this.isBookOpen = component.isBookOpen;
		this.audioPageTurn = component.audioPageTurn;
		this.audioError = component.audioError;
		component.routeText1.Copy(ref this.routeText1);
		this.routeTextReturn = component.routeTextReturn;
		this.dateText = component.dateText;
		this.titleText = component.titleText;
		this.driveHomeText = component.driveHomeText;
		this.changeDirectionText = component.changeDirectionText;
		component.originName.Copy(ref this.originName);
		component.returnName.Copy(ref this.returnName);
		component.destinations.Copy(ref this.destinations);
		component.mapMaterials.Copy(ref this.mapMaterials);
		this.mapObject = component.mapObject;
		this.glowMaterial = component.glowMaterial;
		this.startMaterial = component.startMaterial;
		this.isGlowing = component.isGlowing;
		this.book = component.book;
		this.pageTurnerR = component.pageTurnerR;
		this.pageTurnerL = component.pageTurnerL;
		this.pageNumber = component.pageNumber;
		this.inputBlocker = component.inputBlocker;
		this.isTurningPage = component.isTurningPage;
		this.restartHeader = component.restartHeader;
		this.restartYes = component.restartYes;
		this.restartNo = component.restartNo;
		this.eventHeader = component.eventHeader;
		this.eventBody = component.eventBody;
		this.statsHeader = component.statsHeader;
		component.stats.Copy(ref this.stats);
		this.unlockHeader = component.unlockHeader;
		component.unlockIcons.Copy(ref this.unlockIcons);
		this.unlockBigIcon = component.unlockBigIcon;
		this.unlockIconTitle = component.unlockIconTitle;
		this.unlockIconDescription = component.unlockIconDescription;
		component.stopOffIcons.Copy(ref this.stopOffIcons);
		component.pickupStrings.Copy(ref this.pickupStrings);
		component.mapFontTargets.Copy(ref this.mapFontTargets);
		component.enabled = false;
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x000A5944 File Offset: 0x000A3D44
	public void PlayError()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioError, 1f);
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x000A595C File Offset: 0x000A3D5C
	public void UpdateStats()
	{
		this.pickupStrings[0].GetComponent<TextMesh>().text = Language.Get("ui_pickup_55", "Inspector_UI");
		this.pickupStrings[1].GetComponent<TextMesh>().text = Language.Get("ui_pickup_56", "Inspector_UI");
		int num = this.director.GetComponent<DirectorC>().footSteps / 2;
		this.stats[9].GetComponent<TextMesh>().text = num.ToString();
		if (num > 999999)
		{
			double num2 = (double)num * 1.0;
			num2 *= 1E-06;
			this.stats[9].GetComponent<TextMesh>().text = num2.ToString() + " M";
		}
		else if (num > 999)
		{
			double num3 = (double)num * 1.0;
			num3 *= 0.001;
			this.stats[9].GetComponent<TextMesh>().text = num3.ToString() + " K";
		}
		this.pickupStrings[2].GetComponent<TextMesh>().text = Language.Get("ui_pickup_57", "Inspector_UI");
		this.stats[10].GetComponent<TextMesh>().text = this.carLogic.GetComponent<CarLogicC>().actualOdometer.ToString() + " km";
		this.pickupStrings[3].GetComponent<TextMesh>().text = Language.Get("ui_pickup_58", "Inspector_UI");
		this.stats[11].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().fuelUsedStats.ToString() + " ltr";
		this.pickupStrings[4].GetComponent<TextMesh>().text = Language.Get("ui_pickup_59", "Inspector_UI");
		this.stats[12].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().tyrePoppedStats.ToString();
		this.pickupStrings[5].GetComponent<TextMesh>().text = Language.Get("ui_pickup_60", "Inspector_UI");
		float num4 = this.director.GetComponent<DirectorC>().topSpeedStats + this.director.GetComponent<DirectorC>().topSpeedStats;
		this.stats[13].GetComponent<TextMesh>().text = num4.ToString() + " km/h";
		this.pickupStrings[6].GetComponent<TextMesh>().text = Language.Get("ui_pickup_61", "Inspector_UI");
		this.stats[14].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().repairKitsUsedStats.ToString();
		this.pickupStrings[7].GetComponent<TextMesh>().text = Language.Get("ui_pickup_62", "Inspector_UI");
		this.stats[15].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().gerGoodTracker.ToString();
		this.pickupStrings[8].GetComponent<TextMesh>().text = Language.Get("ui_pickup_63", "Inspector_UI");
		this.stats[16].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().csfrGoodTracker.ToString();
		this.pickupStrings[9].GetComponent<TextMesh>().text = Language.Get("ui_pickup_64", "Inspector_UI");
		this.stats[17].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().hunGoodTracker.ToString();
		this.pickupStrings[10].GetComponent<TextMesh>().text = Language.Get("ui_pickup_65", "Inspector_UI");
		this.stats[22].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().yugoGoodTracker.ToString();
		this.pickupStrings[11].GetComponent<TextMesh>().text = Language.Get("ui_pickup_66", "Inspector_UI");
		this.stats[23].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().bulGoodTracker.ToString();
		this.pickupStrings[12].GetComponent<TextMesh>().text = Language.Get("ui_pickup_67", "Inspector_UI");
		this.stats[24].GetComponent<TextMesh>().text = this.director.GetComponent<DirectorC>().turkGoodTracker.ToString();
		this.pickupStrings[13].GetComponent<TextMesh>().text = Language.Get("ui_pickup_68", "Inspector_UI");
		float num5 = this.director.GetComponent<DirectorC>().gerGoodTracker + this.director.GetComponent<DirectorC>().csfrGoodTracker + this.director.GetComponent<DirectorC>().hunGoodTracker + this.director.GetComponent<DirectorC>().yugoGoodTracker + this.director.GetComponent<DirectorC>().bulGoodTracker + this.director.GetComponent<DirectorC>().turkGoodTracker;
		this.stats[25].GetComponent<TextMesh>().text = num5.ToString();
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x000A5EC4 File Offset: 0x000A42C4
	public void ChangeMap1()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			this.routeText1[0].SetActive(true);
			this.routeText1[1].SetActive(true);
			this.routeText1[2].SetActive(true);
		}
		this.director.GetComponent<RouteGeneratorC>().RouteDistances();
		base.GetComponent<AudioSource>().PlayOneShot(this.audioPageTurn, 1f);
		this.routeText1[0].GetComponent<MapRelayC>().spawnedRoute = this.routeText1[0].GetComponent<MapRelayC>().routeHolder2;
		this.routeText1[1].GetComponent<MapRelayC>().spawnedRoute = this.routeText1[1].GetComponent<MapRelayC>().routeHolder2;
		this.routeText1[2].GetComponent<MapRelayC>().spawnedRoute = this.routeText1[2].GetComponent<MapRelayC>().routeHolder2;
		if (this.routeText1[0].GetComponent<MapRelayC>().distance > 3)
		{
			this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.SetActive(true);
			if (this.director.GetComponent<RouteGeneratorC>().route1StopOff == 0)
			{
				this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
			}
			else if (this.director.GetComponent<RouteGeneratorC>().route1StopOff == 1)
			{
				this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
			}
		}
		else
		{
			this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.SetActive(false);
		}
		if (this.routeText1[1].GetComponent<MapRelayC>().distance > 3)
		{
			this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.SetActive(true);
			if (this.director.GetComponent<RouteGeneratorC>().route2StopOff == 0)
			{
				this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
			}
			else if (this.director.GetComponent<RouteGeneratorC>().route2StopOff == 1)
			{
				this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
			}
		}
		else
		{
			this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.SetActive(false);
		}
		if (this.routeText1[2].GetComponent<MapRelayC>().distance > 3)
		{
			this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.SetActive(true);
			if (this.director.GetComponent<RouteGeneratorC>().route3StopOff == 0)
			{
				this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
			}
			else if (this.director.GetComponent<RouteGeneratorC>().route3StopOff == 1)
			{
				this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
			}
		}
		else
		{
			this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.SetActive(false);
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[0];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.returnName[0], "Inspector_UI");
			this.destinations[0].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[1];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.returnName[1], "Inspector_UI");
			this.destinations[1].SetActive(true);
			this.destinations[0].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[2];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.returnName[2], "Inspector_UI");
			this.destinations[2].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[3];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.returnName[3], "Inspector_UI");
			this.destinations[3].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[4];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.returnName[4], "Inspector_UI");
			this.destinations[4].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[5];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.returnName[5], "Inspector_UI");
			this.destinations[5].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[6].SetActive(false);
		}
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x000A6638 File Offset: 0x000A4A38
	public void ChangeMap2()
	{
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			this.routeText1[0].SetActive(false);
			this.routeText1[1].SetActive(false);
			this.routeText1[2].SetActive(false);
		}
		this.director.GetComponent<RouteGeneratorC>().RouteDistances();
		if (this.routeText1[0].GetComponent<MapRelayC>().distance > 3)
		{
			this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.SetActive(true);
			if (this.director.GetComponent<RouteGeneratorC>().route1StopOff == 0)
			{
				this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
			}
			else if (this.director.GetComponent<RouteGeneratorC>().route1StopOff == 1)
			{
				this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
			}
		}
		else
		{
			this.routeText1[0].GetComponent<MapRelayC>().fuelIcon.SetActive(false);
		}
		if (this.routeText1[1].GetComponent<MapRelayC>().distance > 3)
		{
			this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.SetActive(true);
			if (this.director.GetComponent<RouteGeneratorC>().route2StopOff == 0)
			{
				this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
			}
			else if (this.director.GetComponent<RouteGeneratorC>().route2StopOff == 1)
			{
				this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
			}
		}
		else
		{
			this.routeText1[1].GetComponent<MapRelayC>().fuelIcon.SetActive(false);
		}
		if (this.routeText1[2].GetComponent<MapRelayC>().distance > 3)
		{
			this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.SetActive(true);
			if (this.director.GetComponent<RouteGeneratorC>().route3StopOff == 0)
			{
				this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
			}
			else if (this.director.GetComponent<RouteGeneratorC>().route3StopOff == 1)
			{
				this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
			}
		}
		else
		{
			this.routeText1[2].GetComponent<MapRelayC>().fuelIcon.SetActive(false);
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.audioPageTurn, 1f);
		this.routeText1[0].GetComponent<MapRelayC>().spawnedRoute = this.routeText1[0].GetComponent<MapRelayC>().routeHolder;
		this.routeText1[1].GetComponent<MapRelayC>().spawnedRoute = this.routeText1[1].GetComponent<MapRelayC>().routeHolder;
		this.routeText1[2].GetComponent<MapRelayC>().spawnedRoute = this.routeText1[2].GetComponent<MapRelayC>().routeHolder;
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[1];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.originName[1], "Inspector_UI");
			this.destinations[1].SetActive(true);
			this.destinations[0].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[2];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.originName[2], "Inspector_UI");
			this.destinations[2].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[3];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.originName[3], "Inspector_UI");
			this.destinations[3].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[4];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.originName[4], "Inspector_UI");
			this.destinations[4].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[5];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.originName[5], "Inspector_UI");
			this.destinations[5].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[0].SetActive(false);
			this.destinations[6].SetActive(false);
		}
		else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[6];
			this.titleText.GetComponent<TextMesh>().text = Language.Get(this.originName[6], "Inspector_UI");
			this.destinations[6].SetActive(true);
			this.destinations[1].SetActive(false);
			this.destinations[2].SetActive(false);
			this.destinations[3].SetActive(false);
			this.destinations[4].SetActive(false);
			this.destinations[5].SetActive(false);
			this.destinations[0].SetActive(false);
		}
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x000A6DAC File Offset: 0x000A51AC
	public void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.director = GameObject.FindWithTag("Director");
		this.startMaterial = this.book.GetComponent<Renderer>().material;
		int routeLevel = this.director.GetComponent<RouteGeneratorC>().routeLevel;
		this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[routeLevel];
		this.SetUnlocks();
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x000A6E30 File Offset: 0x000A5230
	public void SetUnlocks()
	{
		for (int i = 0; i < this.unlockIcons.Length; i++)
		{
			if (this.director.GetComponent<DirectorC>().diaryUnlockStates[i])
			{
				MonoBehaviour.print("Unlocked " + i);
				this.unlockIcons[i].GetComponent<IconRelayC>().UnlockIcon();
			}
		}
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x000A6E94 File Offset: 0x000A5294
	public IEnumerator Page0Go()
	{
		yield return new WaitForSeconds(0.1f);
		this.eventHeader.SetActive(false);
		this.eventBody.SetActive(false);
		this.restartHeader.SetActive(false);
		this.restartYes.SetActive(false);
		this.restartNo.SetActive(false);
		this.unlockHeader.SetActive(false);
		this.unlockIconTitle.SetActive(false);
		this.unlockIconDescription.SetActive(false);
		this.unlockBigIcon.SetActive(false);
		this.statsHeader.SetActive(false);
		for (int i = 0; i < this.stats.Length; i++)
		{
			this.stats[i].SetActive(false);
		}
		yield return new WaitForSeconds(0.2f);
		this.dateText.SetActive(true);
		this.titleText.SetActive(true);
		if (this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome || this.director.GetComponent<RouteGeneratorC>().routeLevel != 6)
		{
			this.routeText1[0].SetActive(true);
			this.routeText1[1].SetActive(true);
			this.routeText1[2].SetActive(true);
		}
		this.changeDirectionText.SetActive(true);
		this.routeTextReturn.SetActive(true);
		int routeLevel = this.director.GetComponent<RouteGeneratorC>().routeLevel;
		this.destinations[routeLevel].SetActive(true);
		for (int j = 0; j < this.routeText1.Length; j++)
		{
			if (this.routeText1[j].GetComponent<MapRelayC>().spawnedRoute != null)
			{
			}
		}
		this.pageTurnerR.SetActive(true);
		yield break;
	}

	// Token: 0x06000805 RID: 2053 RVA: 0x000A6EB0 File Offset: 0x000A52B0
	public IEnumerator Page1Go()
	{
		yield return new WaitForSeconds(0.1f);
		this.dateText.SetActive(false);
		this.titleText.SetActive(false);
		this.routeText1[0].SetActive(false);
		this.routeText1[1].SetActive(false);
		this.routeText1[2].SetActive(false);
		this.routeTextReturn.SetActive(false);
		int routeLevel = this.director.GetComponent<RouteGeneratorC>().routeLevel;
		this.destinations[routeLevel].SetActive(false);
		this.unlockHeader.SetActive(false);
		this.unlockIconTitle.SetActive(false);
		this.unlockIconDescription.SetActive(false);
		this.unlockBigIcon.SetActive(false);
		this.restartHeader.SetActive(false);
		this.restartYes.SetActive(false);
		this.restartNo.SetActive(false);
		for (int i = 0; i < this.unlockIcons.Length; i++)
		{
			this.unlockIcons[i].SetActive(false);
		}
		for (int j = 0; j < this.routeText1.Length; j++)
		{
			if (this.routeText1[j].GetComponent<MapRelayC>().spawnedRoute != null)
			{
				this.routeText1[j].GetComponent<MapRelayC>().spawnedRoute.SetActive(false);
			}
			this.routeText1[j].SetActive(false);
		}
		yield return new WaitForSeconds(0.2f);
		LanguageCode currentLang = Language.CurrentLanguage();
		if (currentLang == LanguageCode.EN)
		{
			this.eventHeader.GetComponent<TextMesh>().text = Language.Get("ui_pickup_68", "Inspector_UI");
			this.eventHeader.SetActive(true);
			this.eventBody.SetActive(true);
		}
		this.statsHeader.GetComponent<TextMesh>().text = Language.Get("ui_pickup_55", "Inspector_UI");
		this.statsHeader.SetActive(true);
		for (int k = 0; k < this.stats.Length; k++)
		{
			this.stats[k].SetActive(true);
			this.UpdateStats();
		}
		this.pageTurnerL.SetActive(true);
		this.pageTurnerR.SetActive(true);
		yield break;
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x000A6ECC File Offset: 0x000A52CC
	private IEnumerator RestartPageGo()
	{
		base.transform.GetChild(0).GetComponent<Animator>().SetBool("page1FoldHover", false);
		base.transform.GetChild(0).GetComponent<Animator>().SetBool("page1FoldGo", true);
		yield return new WaitForSeconds(0.1f);
		base.transform.GetChild(0).GetComponent<Animator>().SetBool("page1FoldGo", false);
		this.dateText.SetActive(false);
		this.titleText.SetActive(false);
		this.routeText1[0].SetActive(false);
		this.routeText1[1].SetActive(false);
		this.routeText1[2].SetActive(false);
		this.routeTextReturn.SetActive(false);
		this.changeDirectionText.SetActive(false);
		this.unlockHeader.SetActive(false);
		this.unlockIconTitle.SetActive(false);
		this.unlockIconDescription.SetActive(false);
		this.unlockBigIcon.SetActive(false);
		for (int i = 0; i < this.unlockIcons.Length; i++)
		{
			this.unlockIcons[i].SetActive(false);
		}
		for (int j = 0; j < this.routeText1.Length; j++)
		{
			if (this.routeText1[j].GetComponent<MapRelayC>().spawnedRoute != null)
			{
				this.routeText1[j].GetComponent<MapRelayC>().spawnedRoute.SetActive(false);
			}
			this.routeText1[j].SetActive(false);
		}
		this.pageTurnerL.SetActive(false);
		this.pageTurnerR.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		this.restartHeader.GetComponent<TextMesh>().text = Language.Get("ui_pickup_19", "Inspector_UI");
		this.restartYes.GetComponent<TextMesh>().text = Language.Get("ui_pickup_11", "Inspector_UI");
		this.restartNo.GetComponent<TextMesh>().text = Language.Get("ui_pickup_12", "Inspector_UI");
		this.restartHeader.SetActive(true);
		this.restartYes.SetActive(true);
		this.restartNo.SetActive(true);
		yield break;
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x000A6EE8 File Offset: 0x000A52E8
	public IEnumerator LastPageGo(int pageNum)
	{
		yield return new WaitForSeconds(0.1f);
		this.eventHeader.SetActive(false);
		this.eventBody.SetActive(false);
		this.statsHeader.SetActive(false);
		for (int i = 0; i < this.stats.Length; i++)
		{
			this.stats[i].SetActive(false);
		}
		yield return new WaitForSeconds(0.2f);
		this.unlockHeader.GetComponent<TextMesh>().text = Language.Get("ui_pickup_69", "Inspector_UI");
		this.unlockHeader.SetActive(true);
		this.unlockIconTitle.SetActive(true);
		LanguageCode currentLang = Language.CurrentLanguage();
		if (currentLang == LanguageCode.EN)
		{
			this.unlockIconDescription.SetActive(true);
		}
		this.unlockBigIcon.SetActive(true);
		for (int j = 0; j < this.unlockIcons.Length; j++)
		{
			this.unlockIcons[j].SetActive(true);
			if (!this.director.GetComponent<DirectorC>().diaryUnlockStates[j])
			{
				Color color = this.unlockIcons[j].GetComponent<SpriteRenderer>().color;
				color.a = 0.3f;
				this.unlockIcons[j].GetComponent<SpriteRenderer>().color = color;
			}
			else
			{
				Color color2 = this.unlockIcons[j].GetComponent<SpriteRenderer>().color;
				color2.a = 1f;
				this.unlockIcons[j].GetComponent<SpriteRenderer>().color = color2;
			}
		}
		yield break;
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x000A6F04 File Offset: 0x000A5304
	public void SetDistances()
	{
		this.routeText1[0].GetComponent<MapRelayC>().distance = this.director.GetComponent<RouteGeneratorC>().route1Distance;
		this.routeText1[1].GetComponent<MapRelayC>().distance = this.director.GetComponent<RouteGeneratorC>().route2Distance;
		this.routeText1[2].GetComponent<MapRelayC>().distance = this.director.GetComponent<RouteGeneratorC>().route3Distance;
		this.routeText1[3].GetComponent<MapRelayC>().distance = this.director.GetComponent<RouteGeneratorC>().route4Distance;
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x000A6F9C File Offset: 0x000A539C
	public void NewLevelUpdate()
	{
		int routeLevel = this.director.GetComponent<RouteGeneratorC>().routeLevel;
		this.mapObject.GetComponent<Renderer>().material = this.mapMaterials[routeLevel];
		int routeLevel2 = this.director.GetComponent<RouteGeneratorC>().routeLevel;
		this.titleText.GetComponent<TextMesh>().text = Language.Get(this.originName[routeLevel2], "Inspector_UI");
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x000A7008 File Offset: 0x000A5408
	public void PickUp()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		gameObject.GetComponent<Scene1_LogicC>().StopRemindingPlayerOfMap();
		this.StopGlow();
		this._camera.GetComponent<MouseLook>().SendMessage("ForceNormalFOV");
		GameObject gameObject2 = GameObject.FindWithTag("CarLogic");
		if (!gameObject2.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().isSat)
		{
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			return;
		}
		if (gameObject2.GetComponent<CarLogicC>().isDriving)
		{
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			return;
		}
		base.transform.parent = this.doorLoc;
		MainMenuC.Global.restrictPause = true;
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		Transform parent = this._camera.transform.parent;
		this._camera.GetComponent<MouseLook>().enabled = false;
		parent.gameObject.GetComponent<MouseLook>().enabled = false;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = false;
		iTween.RotateTo(parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(0f, 180f, 0f),
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeInQuad",
			"oncomplete",
			"TweenBookPos",
			"oncompletetarget",
			base.gameObject
		}));
		base.gameObject.GetComponent<Collider>().enabled = false;
		MainMenuC.Global.lockCursor = false;
		Screen.lockCursor = false;
		this.inputBlocker.GetComponent<BoxCollider>().enabled = true;
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x000A71DC File Offset: 0x000A55DC
	public void TweenBookPos()
	{
		this._camera.transform.parent.localRotation = Quaternion.identity;
		this._camera.transform.parent.localEulerAngles = new Vector3(0f, 180f, 0f);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.holdingPosition,
			"time",
			1.0,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"OpenBook",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.holdingPosition,
			"time",
			1.0,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x000A72F0 File Offset: 0x000A56F0
	private IEnumerator OpenBook()
	{
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			VfAnimCursor.TurnOffXbox = true;
		}
		base.transform.position = this.holdingPosition.position;
		this.isBookOpen = true;
		this.animatedBook.GetComponent<Animator>().SetBool("isBookOpen", true);
		base.GetComponent<AudioSource>().PlayOneShot(this.audioPageTurn, 1f);
		yield return new WaitForSeconds(1.2f);
		if (!this.isBookOpen)
		{
			yield break;
		}
		this.pageTurnerR.SetActive(true);
		this.pageTurnerL.SetActive(true);
		int routeLevel = this.director.GetComponent<RouteGeneratorC>().routeLevel;
		this.destinations[routeLevel].SetActive(true);
		this.dateText.SetActive(true);
		this.titleText.SetActive(true);
		this.routeTextReturn.SetActive(true);
		this.changeDirectionText.SetActive(true);
		for (int i = 0; i < this.routeText1.Length; i++)
		{
			if (this.routeText1[i].GetComponent<MapRelayC>().routeNumber == 4 && !this.routeText1[i].GetComponent<MapRelayC>().routeDiscovered)
			{
				yield break;
			}
			if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6 && !this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				this.routeText1[i].SetActive(false);
				yield break;
			}
			this.routeText1[i].SetActive(true);
			if (this.routeText1[i].GetComponent<MapRelayC>().selectedRoute)
			{
				this.routeText1[i].GetComponent<MapRelayC>().spawnedRoute.SetActive(true);
			}
			if (this.routeText1[i].GetComponent<MapRelayC>().distance > 3)
			{
				this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.SetActive(true);
				if (i == 0)
				{
					if (this.director.GetComponent<RouteGeneratorC>().route1StopOff == 0)
					{
						this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
					}
					else if (this.director.GetComponent<RouteGeneratorC>().route1StopOff == 1)
					{
						this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
					}
				}
				else if (i == 1)
				{
					if (this.director.GetComponent<RouteGeneratorC>().route2StopOff == 0)
					{
						this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
					}
					else if (this.director.GetComponent<RouteGeneratorC>().route2StopOff == 1)
					{
						this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
					}
				}
				else if (i == 2)
				{
					if (this.director.GetComponent<RouteGeneratorC>().route3StopOff == 0)
					{
						this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[0];
					}
					else if (this.director.GetComponent<RouteGeneratorC>().route3StopOff == 1)
					{
						this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.GetComponent<Renderer>().material = this.stopOffIcons[1];
					}
				}
			}
			else
			{
				this.routeText1[i].GetComponent<MapRelayC>().fuelIcon.SetActive(false);
			}
			this.routeText1[i].GetComponent<MapRelayC>().weatherIcon.SetActive(true);
		}
		yield break;
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x000A730C File Offset: 0x000A570C
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.book.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if ((Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) || Input.GetButtonDown("Drop") || Input.GetButtonDown("Pause")) && ((this.isBookOpen && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress) || (Input.GetButtonDown("Pause") && this.isBookOpen && !this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress)))
		{
			this.isBookOpen = false;
			if (Application.platform == RuntimePlatform.XboxOne)
			{
				VfAnimCursor.TurnOffXbox = false;
			}
			this.pageNumber = 0;
			MainMenuC.Global.restrictPause = false;
			this.pageTurnerL.GetComponent<SphereCollider>().enabled = false;
			this.pageTurnerR.GetComponent<SphereCollider>().enabled = true;
			this.pageTurnerL.SetActive(false);
			this.pageTurnerR.SetActive(false);
			for (int i = 0; i < this.routeText1.Length; i++)
			{
				if (this.routeText1[i].GetComponent<MapRelayC>().spawnedRoute != null)
				{
					this.routeText1[i].GetComponent<MapRelayC>().spawnedRoute.SetActive(false);
				}
				this.routeText1[i].SetActive(false);
			}
			this.driveHomeText.SetActive(false);
			this.changeDirectionText.SetActive(false);
			this.eventHeader.SetActive(false);
			this.eventBody.SetActive(false);
			this.statsHeader.SetActive(false);
			for (int j = 0; j < this.stats.Length; j++)
			{
				this.stats[j].SetActive(false);
			}
			this.restartHeader.SetActive(false);
			this.restartYes.SetActive(false);
			this.restartNo.SetActive(false);
			this.unlockHeader.SetActive(false);
			this.unlockIconTitle.SetActive(false);
			this.unlockIconDescription.SetActive(false);
			this.unlockBigIcon.SetActive(false);
			for (int k = 0; k < this.unlockIcons.Length; k++)
			{
				this.unlockIcons[k].SetActive(false);
			}
			this.dateText.SetActive(false);
			this.titleText.SetActive(false);
			this.animatedBook.GetComponent<Animator>().SetBool("isBookOpen", false);
			int routeLevel = this.director.GetComponent<RouteGeneratorC>().routeLevel;
			this.destinations[routeLevel].SetActive(false);
			int num = routeLevel - 1;
			if (num >= 0)
			{
				this.destinations[num].SetActive(false);
			}
			base.GetComponent<AudioSource>().PlayOneShot(this.audioPageTurn, 1f);
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.doorLoc,
				"delay",
				0.5,
				"time",
				1.0,
				"easetype",
				"easeinquad",
				"oncomplete",
				"ResumeCamera",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.doorLoc,
				"delay",
				0.5,
				"time",
				1.0,
				"easetype",
				"easeinquad"
			}));
			base.gameObject.GetComponent<Collider>().enabled = true;
			this.inputBlocker.GetComponent<BoxCollider>().enabled = false;
		}
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x000A772C File Offset: 0x000A5B2C
	public void ResumeCamera()
	{
		if (MainMenuC.Global.isPaused != 0)
		{
			return;
		}
		MainMenuC.Global.lockCursor = true;
		Screen.lockCursor = true;
		Transform parent = this._camera.transform.parent;
		this._camera.GetComponent<MouseLook>().enabled = true;
		if (!this.carLogic.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().isSat)
		{
			this._camera.GetComponent<HeadBobberC>().enabled = true;
		}
		parent.gameObject.GetComponent<MouseLook>().enabled = true;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = true;
		this._camera.transform.parent.localRotation = Quaternion.identity;
		this._camera.transform.parent.localEulerAngles = new Vector3(0f, 180f, 0f);
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x000A7811 File Offset: 0x000A5C11
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.book.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x000A7830 File Offset: 0x000A5C30
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.book.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x000A784F File Offset: 0x000A5C4F
	public void StopGlow()
	{
		this.isGlowing = false;
		this.book.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000A5A RID: 2650
	private GameObject _camera;

	// Token: 0x04000A5B RID: 2651
	public GameObject director;

	// Token: 0x04000A5C RID: 2652
	public GameObject carLogic;

	// Token: 0x04000A5D RID: 2653
	public Transform doorLoc;

	// Token: 0x04000A5E RID: 2654
	public GameObject animatedBook;

	// Token: 0x04000A5F RID: 2655
	public Vector3 playerCamLocAdjustment;

	// Token: 0x04000A60 RID: 2656
	public Transform holdingPosition;

	// Token: 0x04000A61 RID: 2657
	public bool isBookOpen = true;

	// Token: 0x04000A62 RID: 2658
	public AudioClip audioPageTurn;

	// Token: 0x04000A63 RID: 2659
	public AudioClip audioError;

	// Token: 0x04000A64 RID: 2660
	public GameObject[] routeText1 = new GameObject[0];

	// Token: 0x04000A65 RID: 2661
	public GameObject routeTextReturn;

	// Token: 0x04000A66 RID: 2662
	public GameObject dateText;

	// Token: 0x04000A67 RID: 2663
	public GameObject titleText;

	// Token: 0x04000A68 RID: 2664
	public GameObject driveHomeText;

	// Token: 0x04000A69 RID: 2665
	public GameObject changeDirectionText;

	// Token: 0x04000A6A RID: 2666
	public string[] originName = new string[0];

	// Token: 0x04000A6B RID: 2667
	public string[] returnName = new string[0];

	// Token: 0x04000A6C RID: 2668
	public GameObject[] destinations = new GameObject[0];

	// Token: 0x04000A6D RID: 2669
	public Material[] mapMaterials = new Material[0];

	// Token: 0x04000A6E RID: 2670
	public GameObject mapObject;

	// Token: 0x04000A6F RID: 2671
	public Material glowMaterial;

	// Token: 0x04000A70 RID: 2672
	public Material startMaterial;

	// Token: 0x04000A71 RID: 2673
	public bool isGlowing;

	// Token: 0x04000A72 RID: 2674
	public GameObject book;

	// Token: 0x04000A73 RID: 2675
	public GameObject pageTurnerR;

	// Token: 0x04000A74 RID: 2676
	public GameObject pageTurnerL;

	// Token: 0x04000A75 RID: 2677
	public int pageNumber;

	// Token: 0x04000A76 RID: 2678
	public GameObject inputBlocker;

	// Token: 0x04000A77 RID: 2679
	[HideInInspector]
	public bool isTurningPage;

	// Token: 0x04000A78 RID: 2680
	public GameObject restartHeader;

	// Token: 0x04000A79 RID: 2681
	public GameObject restartYes;

	// Token: 0x04000A7A RID: 2682
	public GameObject restartNo;

	// Token: 0x04000A7B RID: 2683
	public GameObject eventHeader;

	// Token: 0x04000A7C RID: 2684
	public GameObject eventBody;

	// Token: 0x04000A7D RID: 2685
	public GameObject statsHeader;

	// Token: 0x04000A7E RID: 2686
	public GameObject[] stats = new GameObject[0];

	// Token: 0x04000A7F RID: 2687
	public GameObject unlockHeader;

	// Token: 0x04000A80 RID: 2688
	public GameObject[] unlockIcons = new GameObject[0];

	// Token: 0x04000A81 RID: 2689
	public GameObject unlockBigIcon;

	// Token: 0x04000A82 RID: 2690
	public GameObject unlockIconTitle;

	// Token: 0x04000A83 RID: 2691
	public GameObject unlockIconDescription;

	// Token: 0x04000A84 RID: 2692
	private bool routeBackBreaker;

	// Token: 0x04000A85 RID: 2693
	public Material[] stopOffIcons = new Material[0];

	// Token: 0x04000A86 RID: 2694
	public GameObject[] pickupStrings = new GameObject[0];

	// Token: 0x04000A87 RID: 2695
	public GameObject[] mapFontTargets = new GameObject[0];

	// Token: 0x04000A88 RID: 2696
	public TextMeshProFont mapFontFallback;
}
