using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x020000EB RID: 235
public class SpawnContinueC : MonoBehaviour
{
	// Token: 0x0600094A RID: 2378 RVA: 0x000D90EC File Offset: 0x000D74EC
	private void Start()
	{
		this.spawnDirector = GameObject.FindWithTag("Director");
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (this.continueNode.transform.localPosition.x > 0f || this.continueNode.transform.localPosition.x < 0f)
			{
				base.transform.position = new Vector3(base.transform.position.x - this.continueNode.transform.localPosition.x * 2f, base.transform.position.y, base.transform.position.z);
			}
			if (this.continueNode.transform.localPosition.y > 0f || this.continueNode.transform.localPosition.y < 0f)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - this.continueNode.transform.localPosition.y * 2f, base.transform.position.z);
			}
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentRoadCondition == 1)
		{
			if (this.roadConditions.Length > 0)
			{
				this.roadConditions[0].active = false;
				this.roadConditions[1].active = true;
				this.roadConditions[2].active = false;
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentRoadCondition == 2 && this.roadConditions.Length > 0)
		{
			this.roadConditions[0].active = false;
			this.roadConditions[1].active = false;
			this.roadConditions[2].active = true;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().puddlePrefabs[0] != null && this.puddleTargets.Length > 1)
		{
			this.SpawnPotHoles();
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().puddlePrefabs[0] != null && this.puddleTargets.Length > 1)
		{
			this.SpawnPuddles();
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().aiCarPrefabs[0] != null)
		{
			this.SpawnAICars();
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().cratePrefabs.Length > 0 && this.crateNodes.Count > 0)
		{
			this.SpawnCrates();
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().abandonCarPrefabs.Length > 0 && this.abandonCarNodes.Count > 0 && this.spawnDirector.GetComponent<RouteGeneratorC>().abandonCarSpawnAmmo > 0)
		{
			int num = UnityEngine.Random.Range(0, 101);
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().abandonCarSpawnChance >= num)
			{
				this.SpawnAbandonCar();
			}
		}
		base.StartCoroutine(this.SpawnContinue());
		if (this.stopOffTarget != null)
		{
			this.SpawnStopOff();
		}
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x000D9460 File Offset: 0x000D7860
	public void SpawnAbandonCar()
	{
		if (this.abandonCarNodes.Count == 0)
		{
			return;
		}
		int num = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().abandonCarPrefabs.Length);
		int index = UnityEngine.Random.Range(0, this.abandonCarNodes.Count);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().abandonCarPrefabs[num], this.abandonCarNodes[index].transform.position, Quaternion.identity);
		gameObject.transform.parent = this.abandonCarNodes[index];
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localEulerAngles = Vector3.zero;
		gameObject.transform.localScale = Vector3.one * 1.1f;
		this.abandonCarNodes.RemoveAt(index);
		this.spawnDirector.GetComponent<RouteGeneratorC>().abandonCarSpawnAmmo--;
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x000D9554 File Offset: 0x000D7954
	public void SignDistances()
	{
		int num = 70 * this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosenLength;
		int num2 = 70 * this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosenLength;
		num2 -= 70;
		if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 1)
			{
				num2 = num - num2;
				this.signForwardDistance.GetComponent<TextMeshPro>().text = num.ToString();
				this.signBackDistance.GetComponent<TextMeshPro>().text = num2.ToString();
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 2)
			{
				num2 -= 70;
				num2 = num - num2;
				num -= 70;
				this.signForwardDistance.GetComponent<TextMeshPro>().text = num.ToString();
				this.signBackDistance.GetComponent<TextMeshPro>().text = num2.ToString();
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 3)
			{
				num2 -= 140;
				num2 = num - num2;
				num -= 140;
				this.signForwardDistance.GetComponent<TextMeshPro>().text = num.ToString();
				this.signBackDistance.GetComponent<TextMeshPro>().text = num2.ToString();
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 4)
			{
				num2 -= 210;
				num2 = num - num2;
				num -= 210;
				this.signForwardDistance.GetComponent<TextMeshPro>().text = num.ToString();
				this.signBackDistance.GetComponent<TextMeshPro>().text = num2.ToString();
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 5)
			{
				num2 -= 280;
				num2 = num - num2;
				num -= 280;
				this.signForwardDistance.GetComponent<TextMeshPro>().text = num.ToString();
				this.signBackDistance.GetComponent<TextMeshPro>().text = num2.ToString();
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 6)
			{
				num2 -= 350;
				num2 = num - num2;
				num -= 350;
				this.signForwardDistance.GetComponent<TextMeshPro>().text = num.ToString();
				this.signBackDistance.GetComponent<TextMeshPro>().text = num2.ToString();
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 1)
		{
			num2 = num - num2;
			this.signBackDistance.GetComponent<TextMeshPro>().text = num.ToString();
			this.signForwardDistance.GetComponent<TextMeshPro>().text = num2.ToString();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 2)
		{
			num2 -= 70;
			num2 = num - num2;
			num -= 70;
			this.signBackDistance.GetComponent<TextMeshPro>().text = num.ToString();
			this.signForwardDistance.GetComponent<TextMeshPro>().text = num2.ToString();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 3)
		{
			num2 -= 140;
			num2 = num - num2;
			num -= 140;
			this.signBackDistance.GetComponent<TextMeshPro>().text = num.ToString();
			this.signForwardDistance.GetComponent<TextMeshPro>().text = num2.ToString();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 4)
		{
			num2 -= 210;
			num2 = num - num2;
			num -= 210;
			this.signBackDistance.GetComponent<TextMeshPro>().text = num.ToString();
			this.signForwardDistance.GetComponent<TextMeshPro>().text = num2.ToString();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 5)
		{
			num2 -= 280;
			num2 = num - num2;
			num -= 280;
			this.signBackDistance.GetComponent<TextMeshPro>().text = num.ToString();
			this.signForwardDistance.GetComponent<TextMeshPro>().text = num2.ToString();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 6)
		{
			num2 -= 350;
			num2 = num - num2;
			num -= 350;
			this.signBackDistance.GetComponent<TextMeshPro>().text = num.ToString();
			this.signForwardDistance.GetComponent<TextMeshPro>().text = num2.ToString();
		}
		for (int i = 0; i < this.signForwardDistance.transform.parent.childCount; i++)
		{
			if (this.signForwardDistance.transform.parent.GetChild(i).GetComponent<TextMeshPro>())
			{
				this.signForwardDistance.transform.parent.GetChild(i).GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
			}
		}
		for (int j = 0; j < this.signBackDistance.transform.parent.childCount; j++)
		{
			if (this.signBackDistance.transform.parent.GetChild(j).GetComponent<TextMeshPro>())
			{
				this.signBackDistance.transform.parent.GetChild(j).GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
			}
		}
		this.signForwardDistance.GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
		this.signForwardDistance.transform.parent.GetChild(0).GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
		this.signForwardDistance.transform.parent.GetChild(1).GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
		this.signBackDistance.GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
		this.signBackDistance.transform.parent.GetChild(0).GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
		this.signBackDistance.transform.parent.GetChild(1).GetComponent<TextMeshPro>().color = new Color(0.5019f, 0.4941f, 0.4627f, 1f);
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x000D9CCC File Offset: 0x000D80CC
	public IEnumerator SpawnContinue()
	{
		yield return new WaitForSeconds(Time.deltaTime * 4f);
		int spawnNumber = this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo;
		if (this.signForwardDistance != null)
		{
			this.SignDistances();
		}
		if (this.randomChance == 1 && this.sceneryTargets.Length != 0)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 4 && !this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				this.MountainGeneration();
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5 && this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				this.MountainGeneration();
			}
			else if (spawnNumber < 3)
			{
				this.ResidentialSceneryGeneration();
			}
			else if (spawnNumber >= 3 && spawnNumber <= 6)
			{
				this.IndustrialSceneryGeneration();
			}
		}
		if (spawnNumber >= this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosenLength)
		{
			Transform transform = base.transform;
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
				{
					if (this.startSize == 3)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutGer2_3);
						gameObject.transform.position = base.transform.position + new Vector3(0f, 0f, 800f);
						gameObject.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
						transform = gameObject.GetComponent<RoundaboutC>().transform;
					}
					else
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutGer2_2);
						gameObject2.transform.position = base.transform.position + new Vector3(0f, 0f, 600f);
						gameObject2.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
						transform = gameObject2.GetComponent<RoundaboutC>().transform;
					}
					int destinationNumber = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
					GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsHome[destinationNumber]);
					gameObject3.transform.position = transform.position + new Vector3(0f, 0f, 1560f);
					gameObject3.transform.rotation = transform.rotation;
					gameObject3.GetComponent<HomeLogicC>().ReturningHomeReadyUp();
					this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
					this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
					this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
					this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject3.GetComponent<HomeLogicC>().continueTarget;
					GameObject gameObject4 = GameObject.FindWithTag("Storage");
					gameObject4.transform.position = gameObject3.GetComponent<HomeLogicC>().homeStorageLoc.position;
					gameObject4.transform.eulerAngles = gameObject3.GetComponent<HomeLogicC>().homeStorageLoc.eulerAngles;
					GameObject gameObject5 = GameObject.FindWithTag("Uncle");
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
				{
					if (this.startSize == 1)
					{
						GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutCSFR1_1);
						gameObject6.transform.position = base.transform.position + new Vector3(0f, 0f, 500f);
						gameObject6.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject6);
						transform = gameObject6.GetComponent<RoundaboutC>().transform;
					}
					else
					{
						GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutCSFR0_1);
						gameObject7.transform.position = base.transform.position + new Vector3(0f, 0f, 500f);
						gameObject7.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject7);
						transform = gameObject7.GetComponent<RoundaboutC>().transform;
					}
					int destinationNumber2 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
					GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsGer[destinationNumber2]);
					gameObject8.transform.position = transform.position + new Vector3(0f, 0f, 1760f);
					gameObject8.transform.rotation = transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
					this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
					this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
					this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject8.GetComponent<Hub_CitySpawnC>().continueTarget;
					gameObject8.GetComponent<Hub_CitySpawnC>().GateClose();
					GameObject gameObject9 = GameObject.FindWithTag("Storage");
					gameObject9.transform.position = new Vector3(0f, -1000f, 0f);
					GameObject gameObject10 = GameObject.FindWithTag("Uncle");
					if (gameObject10.GetComponent<UncleLogicC>().uncleAtHome)
					{
						gameObject10.transform.position = new Vector3(-10f, -1000f, 0f);
					}
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 3)
				{
					if (this.startSize == 2)
					{
						GameObject gameObject11 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundAboutHUN2_2);
						gameObject11.transform.position = base.transform.position + new Vector3(0f, 0f, 500f);
						gameObject11.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject11);
						transform = gameObject11.GetComponent<RoundaboutC>().transform;
					}
					else
					{
						GameObject gameObject12 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundAboutHUN2_0);
						gameObject12.transform.position = base.transform.position + new Vector3(0f, 0f, 500f);
						gameObject12.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject12);
						transform = gameObject12.GetComponent<RoundaboutC>().transform;
					}
					int destinationNumber3 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
					GameObject gameObject13 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsCSFR[destinationNumber3]);
					gameObject13.transform.position = transform.position + new Vector3(0f, 0f, 1400f);
					gameObject13.transform.rotation = transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
					this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
					this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
					this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject13.GetComponent<Hub_CitySpawnC>().continueTarget;
					gameObject13.GetComponent<Hub_CitySpawnC>().GateClose();
					GameObject gameObject14 = GameObject.FindWithTag("Storage");
					gameObject14.transform.position = new Vector3(0f, -1000f, 0f);
					GameObject gameObject15 = GameObject.FindWithTag("Uncle");
					if (gameObject15.GetComponent<UncleLogicC>().uncleAtHome)
					{
						gameObject15.transform.position = new Vector3(-10f, -1000f, 0f);
					}
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 4)
				{
					if (this.startSize == 1)
					{
						GameObject gameObject16 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutYUGO0_1);
						gameObject16.transform.position = base.transform.position + new Vector3(0f, 0f, 200f);
						gameObject16.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject16);
						transform = gameObject16.GetComponent<RoundaboutC>().transform;
					}
					else
					{
						GameObject gameObject17 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutYUGO1_0);
						gameObject17.transform.position = base.transform.position + new Vector3(0f, 0f, 200f);
						gameObject17.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject17);
						transform = gameObject17.GetComponent<RoundaboutC>().transform;
					}
					int destinationNumber4 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
					GameObject gameObject18 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsHUN[destinationNumber4]);
					gameObject18.transform.position = transform.position + new Vector3(0f, 0f, 1500f);
					gameObject18.transform.rotation = transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
					this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
					this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
					this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject18.GetComponent<Hub_CitySpawnC>().continueTarget;
					gameObject18.GetComponent<Hub_CitySpawnC>().GateClose();
					GameObject gameObject19 = GameObject.FindWithTag("Storage");
					gameObject19.transform.position = new Vector3(0f, -1000f, 0f);
					GameObject gameObject20 = GameObject.FindWithTag("Uncle");
					if (gameObject20.GetComponent<UncleLogicC>().uncleAtHome)
					{
						gameObject20.transform.position = new Vector3(-10f, -1000f, 0f);
					}
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5)
				{
					if (this.startSize == 1)
					{
						GameObject gameObject21 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutBUL0_0);
						gameObject21.transform.position = base.transform.position + new Vector3(0f, 0f, 10f);
						gameObject21.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject21);
						transform = gameObject21.GetComponent<RoundaboutC>().transform;
					}
					else
					{
						GameObject gameObject22 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutBUL0_0);
						gameObject22.transform.position = base.transform.position + new Vector3(0f, 0f, 10f);
						gameObject22.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject22);
						transform = gameObject22.GetComponent<RoundaboutC>().transform;
					}
					int destinationNumber5 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
					GameObject gameObject23 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsYUGO[destinationNumber5]);
					gameObject23.transform.position = transform.position + new Vector3(0f, 0f, 1740f);
					gameObject23.transform.rotation = transform.rotation;
					GameObject gameObject24 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().yugoSea);
					gameObject24.transform.parent = gameObject23.transform;
					gameObject24.transform.localPosition = Vector3.zero;
					GameObject gameObject25 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().yugoSea);
					gameObject25.transform.parent = gameObject23.transform;
					gameObject25.transform.localPosition = new Vector3(0f, 0f, 500f);
					GameObject gameObject26 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().yugoSea);
					gameObject26.transform.parent = gameObject23.transform;
					gameObject26.transform.localPosition = new Vector3(0f, 0f, -500f);
					GameObject gameObject27 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().yugoBackdrop);
					gameObject27.transform.parent = gameObject23.transform;
					gameObject27.transform.localPosition = new Vector3(-130f, 90f, 80f);
					gameObject27.transform.localEulerAngles = new Vector3(90f, -180f, 0f);
					gameObject27.transform.localScale = new Vector3(50f, 50f, 23f);
					gameObject23.GetComponent<Hub_CitySpawnC>().spawnedYugoScenery = gameObject27;
					this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
					this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
					this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
					this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject23.GetComponent<Hub_CitySpawnC>().continueTarget;
					gameObject23.GetComponent<Hub_CitySpawnC>().GateClose();
					GameObject gameObject28 = GameObject.FindWithTag("Storage");
					gameObject28.transform.position = new Vector3(0f, -1000f, 0f);
					GameObject gameObject29 = GameObject.FindWithTag("Uncle");
					if (gameObject29.GetComponent<UncleLogicC>().uncleAtHome)
					{
						gameObject29.transform.position = new Vector3(-10f, -1000f, 0f);
					}
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 6)
				{
					if (this.startSize == 2)
					{
						GameObject gameObject30 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutTURK1_2);
						gameObject30.transform.position = base.transform.position + new Vector3(0f, 0f, 240f);
						gameObject30.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject30);
						transform = gameObject30.GetComponent<RoundaboutC>().transform;
					}
					else
					{
						GameObject gameObject31 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutTURK1_1);
						gameObject31.transform.position = base.transform.position + new Vector3(0f, 0f, 240f);
						gameObject31.transform.rotation = base.transform.rotation;
						this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject31);
						transform = gameObject31.GetComponent<RoundaboutC>().transform;
					}
					int destinationNumber6 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
					GameObject gameObject32 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsBUL[destinationNumber6]);
					gameObject32.transform.position = transform.position + new Vector3(0f, 72f, 1570f);
					gameObject32.transform.rotation = transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
					this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
					this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
					this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject32.GetComponent<Hub_CitySpawnC>().continueTarget;
					gameObject32.GetComponent<Hub_CitySpawnC>().GateClose();
					GameObject gameObject33 = GameObject.FindWithTag("Storage");
					gameObject33.transform.position = new Vector3(0f, -1000f, 0f);
					GameObject gameObject34 = GameObject.FindWithTag("Uncle");
					if (gameObject34.GetComponent<UncleLogicC>().uncleAtHome)
					{
						gameObject34.transform.position = new Vector3(-10f, -1000f, 0f);
					}
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 0)
			{
				if (this.continueSize == 3)
				{
					GameObject gameObject35 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutGer3_1);
					gameObject35.transform.position = this.continueNode.transform.position;
					gameObject35.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject35);
					transform = gameObject35.GetComponent<RoundaboutC>().continueNode.transform;
				}
				else if (this.continueSize == 2)
				{
					GameObject gameObject36 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutGer2_1);
					gameObject36.transform.position = this.continueNode.transform.position;
					gameObject36.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject36);
					transform = gameObject36.GetComponent<RoundaboutC>().continueNode.transform;
				}
				int destinationNumber7 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
				GameObject gameObject37 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsGer[destinationNumber7]);
				gameObject37.transform.position = transform.position;
				gameObject37.transform.rotation = transform.rotation;
				this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
				this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
				this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
				this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject37.GetComponent<Hub_CitySpawnC>().continueTarget;
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				if (this.continueSize == 1)
				{
					GameObject gameObject38 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutCSFR1_1);
					gameObject38.transform.position = this.continueNode.transform.position;
					gameObject38.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject38);
					transform = gameObject38.GetComponent<RoundaboutC>().continueNode.transform;
				}
				else if (this.continueSize == 0)
				{
					GameObject gameObject39 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutCSFR0_1);
					gameObject39.transform.position = this.continueNode.transform.position;
					gameObject39.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject39);
					transform = gameObject39.GetComponent<RoundaboutC>().continueNode.transform;
				}
				int destinationNumber8 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
				GameObject gameObject40 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsCSFR[destinationNumber8]);
				gameObject40.transform.position = transform.position;
				gameObject40.transform.rotation = transform.rotation;
				this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
				this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
				this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
				this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject40.GetComponent<Hub_CitySpawnC>().continueTarget;
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				if (this.continueSize == 2)
				{
					GameObject gameObject41 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutHUN2_0);
					gameObject41.transform.position = this.continueNode.transform.position;
					gameObject41.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject41);
					transform = gameObject41.GetComponent<RoundaboutC>().continueNode.transform;
				}
				else if (this.continueSize == 0)
				{
					GameObject gameObject42 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutHUN0_0);
					gameObject42.transform.position = this.continueNode.transform.position;
					gameObject42.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject42);
					transform = gameObject42.GetComponent<RoundaboutC>().continueNode.transform;
				}
				int destinationNumber9 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
				GameObject gameObject43 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsHUN[destinationNumber9]);
				gameObject43.transform.position = transform.position;
				gameObject43.transform.rotation = transform.rotation;
				this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
				this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
				this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
				this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject43.GetComponent<Hub_CitySpawnC>().continueTarget;
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				if (this.continueSize == 1)
				{
					GameObject gameObject44 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutYUGO1_0);
					gameObject44.transform.position = this.continueNode.transform.position;
					gameObject44.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject44);
					transform = gameObject44.GetComponent<RoundaboutC>().continueNode.transform;
				}
				else if (this.continueSize == 0)
				{
					GameObject gameObject45 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutYUGO0_0);
					gameObject45.transform.position = this.continueNode.transform.position;
					gameObject45.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject45);
					transform = gameObject45.GetComponent<RoundaboutC>().continueNode.transform;
				}
				int destinationNumber10 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
				GameObject gameObject46 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsYUGO[destinationNumber10]);
				gameObject46.transform.position = transform.position;
				gameObject46.transform.rotation = transform.rotation;
				this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
				this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
				this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
				this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject46.GetComponent<Hub_CitySpawnC>().continueTarget;
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 4)
			{
				GameObject gameObject47 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutBUL0_0);
				gameObject47.transform.position = this.continueNode.transform.position;
				gameObject47.transform.rotation = this.continueNode.transform.rotation;
				this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject47);
				transform = gameObject47.GetComponent<RoundaboutC>().continueNode.transform;
				int destinationNumber11 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
				GameObject gameObject48 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsBUL[destinationNumber11]);
				gameObject48.transform.position = transform.position;
				gameObject48.transform.rotation = transform.rotation;
				this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
				this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
				this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
				this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject48.GetComponent<Hub_CitySpawnC>().continueTarget;
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5)
			{
				if (this.continueSize == 1)
				{
					GameObject gameObject49 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutTURK1_3);
					gameObject49.transform.position = this.continueNode.transform.position;
					gameObject49.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject49);
					transform = gameObject49.GetComponent<RoundaboutC>().continueNode.transform;
				}
				else if (this.continueSize == 2)
				{
					GameObject gameObject50 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().roundaboutTURK2_3);
					gameObject50.transform.position = this.continueNode.transform.position;
					gameObject50.transform.rotation = this.continueNode.transform.rotation;
					this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject50);
					transform = gameObject50.GetComponent<RoundaboutC>().continueNode.transform;
				}
				int destinationNumber12 = this.spawnDirector.GetComponent<RouteGeneratorC>().destinationNumber;
				GameObject gameObject51 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().destinationObjectsTURK[destinationNumber12]);
				gameObject51.transform.position = transform.position;
				gameObject51.transform.rotation = transform.rotation;
				this.spawnDirector.GetComponent<RouteGeneratorC>().StoreLights();
				this.spawnDirector.GetComponent<DirectorC>().Astar.GetComponent<AstarPath>().Scan(null);
				this.spawnDirector.GetComponent<RouteGeneratorC>().GatherAI();
				this.spawnDirector.GetComponent<RouteGeneratorC>().firstSegmentTarget = gameObject51.GetComponent<Hub_CitySpawnC>().continueTarget;
			}
			yield break;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
		{
			this.ContinueRoute1();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
		{
			this.ContinueRoute2();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
		{
			this.ContinueRoute3();
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 4)
		{
			this.ContinueRoute4();
		}
		yield break;
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x000D9CE8 File Offset: 0x000D80E8
	public void ContinueRoute1()
	{
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 1)
		{
			GameObject original = this.spawnDirector.GetComponent<RouteGeneratorC>().route1Segments[1];
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject.transform.position = this.continueNode.transform.position;
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 2)
		{
			GameObject original2 = this.spawnDirector.GetComponent<RouteGeneratorC>().route1Segments[2];
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(original2);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject2.transform.position = this.continueNode.transform.position;
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject2.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 3)
		{
			GameObject original3 = this.spawnDirector.GetComponent<RouteGeneratorC>().route1Segments[3];
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(original3);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject3.transform.position = this.continueNode.transform.position;
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject3.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject3);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 4)
		{
			GameObject original4 = this.spawnDirector.GetComponent<RouteGeneratorC>().route1Segments[4];
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(original4);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject4.transform.position = this.continueNode.transform.position;
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject4.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject4);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 5)
		{
			GameObject original5 = this.spawnDirector.GetComponent<RouteGeneratorC>().route1Segments[5];
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(original5);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject5.transform.position = this.continueNode.transform.position;
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject5.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject5);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x000DA1EC File Offset: 0x000D85EC
	public void ContinueRoute2()
	{
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 1)
		{
			GameObject original = this.spawnDirector.GetComponent<RouteGeneratorC>().route2Segments[1];
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject.transform.position = this.continueNode.transform.position;
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 2)
		{
			GameObject original2 = this.spawnDirector.GetComponent<RouteGeneratorC>().route2Segments[2];
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(original2);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject2.transform.position = this.continueNode.transform.position;
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject2.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 3)
		{
			GameObject original3 = this.spawnDirector.GetComponent<RouteGeneratorC>().route2Segments[3];
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(original3);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject3.transform.position = this.continueNode.transform.position;
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject3.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject3);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 4)
		{
			GameObject original4 = this.spawnDirector.GetComponent<RouteGeneratorC>().route2Segments[4];
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(original4);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject4.transform.position = this.continueNode.transform.position;
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject4.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject4);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 5)
		{
			GameObject original5 = this.spawnDirector.GetComponent<RouteGeneratorC>().route2Segments[5];
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(original5);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject5.transform.position = this.continueNode.transform.position;
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject5.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject5);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x000DA6F0 File Offset: 0x000D8AF0
	public void ContinueRoute3()
	{
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 1)
		{
			GameObject original = this.spawnDirector.GetComponent<RouteGeneratorC>().route3Segments[1];
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject.transform.position = this.continueNode.transform.position;
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 2)
		{
			GameObject original2 = this.spawnDirector.GetComponent<RouteGeneratorC>().route3Segments[2];
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(original2);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject2.transform.position = this.continueNode.transform.position;
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject2.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 3)
		{
			GameObject original3 = this.spawnDirector.GetComponent<RouteGeneratorC>().route3Segments[3];
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(original3);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject3.transform.position = this.continueNode.transform.position;
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject3.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject3);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 4)
		{
			GameObject original4 = this.spawnDirector.GetComponent<RouteGeneratorC>().route3Segments[4];
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(original4);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject4.transform.position = this.continueNode.transform.position;
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject4.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject4);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 5)
		{
			GameObject original5 = this.spawnDirector.GetComponent<RouteGeneratorC>().route3Segments[5];
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(original5);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject5.transform.position = this.continueNode.transform.position;
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject5.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject5);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x000DABF4 File Offset: 0x000D8FF4
	public void ContinueRoute4()
	{
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 1)
		{
			GameObject original = this.spawnDirector.GetComponent<RouteGeneratorC>().route4Segments[1];
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject.transform.position = this.continueNode.transform.position;
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 2)
		{
			GameObject original2 = this.spawnDirector.GetComponent<RouteGeneratorC>().route4Segments[2];
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(original2);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject2.transform.position = this.continueNode.transform.position;
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject2.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject2.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 3)
		{
			GameObject original3 = this.spawnDirector.GetComponent<RouteGeneratorC>().route4Segments[3];
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(original3);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject3.transform.position = this.continueNode.transform.position;
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject3.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject3.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject3);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 4)
		{
			GameObject original4 = this.spawnDirector.GetComponent<RouteGeneratorC>().route4Segments[4];
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(original4);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject4.transform.position = this.continueNode.transform.position;
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject4.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject4.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject4);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo == 5)
		{
			GameObject original5 = this.spawnDirector.GetComponent<RouteGeneratorC>().route4Segments[5];
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(original5);
			if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				gameObject5.transform.position = this.continueNode.transform.position;
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			else
			{
				gameObject5.transform.position = base.transform.position + new Vector3(0f, 0f, 1000f);
				gameObject5.transform.rotation = this.continueNode.transform.rotation;
			}
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject5);
			this.spawnDirector.GetComponent<RouteGeneratorC>().routeAmmo++;
			return;
		}
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x000DB0F8 File Offset: 0x000D94F8
	public static void RandomizeBuiltinArray(UnityEngine.Object[] arr)
	{
		for (int i = arr.Length - 1; i > 0; i--)
		{
			int num = UnityEngine.Random.Range(0, i);
			UnityEngine.Object @object = arr[i];
			arr[i] = arr[num];
			arr[num] = @object;
		}
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x000DB134 File Offset: 0x000D9534
	public void MountainGeneration()
	{
		int num = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryMountainsBUL.Length - 1);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryMountainsBUL[num]);
		gameObject.transform.position = this.sceneryTargets[0].position;
		gameObject.transform.rotation = this.sceneryTargets[0].rotation;
		this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
		int num2 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryMountainsBUL.Length - 1);
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryMountainsBUL[num2]);
		gameObject2.transform.position = this.sceneryTargets[1].position;
		gameObject2.transform.rotation = this.sceneryTargets[1].rotation;
		this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x000DB234 File Offset: 0x000D9634
	public void ResidentialSceneryGeneration()
	{
		SpawnContinueC.RandomizeBuiltinArray(this.sceneryTargets);
		this.randomChance = UnityEngine.Random.Range(1, 100);
		if (this.randomChance > 0 && this.randomChance <= 5)
		{
			return;
		}
		if (this.randomChance > 5 && this.randomChance <= 45)
		{
			int num = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num]);
			gameObject.transform.position = this.sceneryTargets[0].position;
			gameObject.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
		}
		if (this.randomChance > 45 && this.randomChance <= 85)
		{
			int num2 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num2]);
			gameObject2.transform.position = this.sceneryTargets[0].position;
			gameObject2.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
			int num3 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num3]);
			gameObject3.transform.position = this.sceneryTargets[1].position;
			gameObject3.transform.rotation = this.sceneryTargets[1].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject3);
		}
		if (this.randomChance > 85 && this.randomChance <= 95)
		{
			int num4 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num4]);
			gameObject4.transform.position = this.sceneryTargets[0].position;
			gameObject4.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject4);
			int num5 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num5]);
			gameObject5.transform.position = this.sceneryTargets[1].position;
			gameObject5.transform.rotation = this.sceneryTargets[1].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject5);
			int num6 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num6]);
			gameObject6.transform.position = this.sceneryTargets[2].position;
			gameObject6.transform.rotation = this.sceneryTargets[2].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject6);
		}
		if (this.randomChance > 95 && this.randomChance <= 100)
		{
			int num7 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num7]);
			gameObject7.transform.position = this.sceneryTargets[0].position;
			gameObject7.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject7);
			int num8 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num8]);
			gameObject8.transform.position = this.sceneryTargets[1].position;
			gameObject8.transform.rotation = this.sceneryTargets[1].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject8);
			int num9 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num9]);
			gameObject9.transform.position = this.sceneryTargets[2].position;
			gameObject9.transform.rotation = this.sceneryTargets[2].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject9);
			int num10 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER.Length - 1);
			GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryResidentialGER[num10]);
			gameObject10.transform.position = this.sceneryTargets[3].position;
			gameObject10.transform.rotation = this.sceneryTargets[3].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject10);
		}
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x000DB7C4 File Offset: 0x000D9BC4
	public void IndustrialSceneryGeneration()
	{
		SpawnContinueC.RandomizeBuiltinArray(this.sceneryTargets);
		this.randomChance = UnityEngine.Random.Range(1, 100);
		if (this.randomChance > 0 && this.randomChance <= 5)
		{
			return;
		}
		if (this.randomChance > 5 && this.randomChance <= 45)
		{
			int num = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num]);
			gameObject.transform.position = this.sceneryTargets[0].position;
			gameObject.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
		}
		if (this.randomChance > 45 && this.randomChance <= 85)
		{
			int num2 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num2]);
			gameObject2.transform.position = this.sceneryTargets[0].position;
			gameObject2.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject2);
			int num3 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num3]);
			gameObject3.transform.position = this.sceneryTargets[1].position;
			gameObject3.transform.rotation = this.sceneryTargets[1].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject3);
		}
		if (this.randomChance > 85 && this.randomChance <= 95)
		{
			int num4 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num4]);
			gameObject4.transform.position = this.sceneryTargets[0].position;
			gameObject4.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject4);
			int num5 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num5]);
			gameObject5.transform.position = this.sceneryTargets[1].position;
			gameObject5.transform.rotation = this.sceneryTargets[1].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject5);
			int num6 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num6]);
			gameObject6.transform.position = this.sceneryTargets[2].position;
			gameObject6.transform.rotation = this.sceneryTargets[2].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject6);
		}
		if (this.randomChance > 95 && this.randomChance <= 100)
		{
			int num7 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num7]);
			gameObject7.transform.position = this.sceneryTargets[0].position;
			gameObject7.transform.rotation = this.sceneryTargets[0].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject7);
			int num8 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num8]);
			gameObject8.transform.position = this.sceneryTargets[1].position;
			gameObject8.transform.rotation = this.sceneryTargets[1].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject8);
			int num9 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num9]);
			gameObject9.transform.position = this.sceneryTargets[2].position;
			gameObject9.transform.rotation = this.sceneryTargets[2].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject9);
			int num10 = UnityEngine.Random.Range(0, this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial.Length - 1);
			GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.spawnDirector.GetComponent<RouteGeneratorC>().sceneryIndustrial[num10]);
			gameObject10.transform.position = this.sceneryTargets[3].position;
			gameObject10.transform.rotation = this.sceneryTargets[3].rotation;
			this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject10);
		}
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x000DBD54 File Offset: 0x000DA154
	public void SpawnStopOff()
	{
		GameObject original = null;
		if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 0)
			{
				if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects2[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects2[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects2[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects3[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects3[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects3[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects4[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects4[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects4[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 4)
			{
				if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects5[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects5[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects5[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5)
			{
				if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects6[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects6[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
				}
				else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
				{
					original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects6[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects2[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects2[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects2[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects3[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects3[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects3[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects4[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects4[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects4[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects5[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects5[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects5[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects6[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects6[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
			{
				original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects6[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 1)
		{
			original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route1StopOff];
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 2)
		{
			original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route2StopOff];
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeChosen == 3)
		{
			original = this.spawnDirector.GetComponent<RouteGeneratorC>().stopOffObjects[this.spawnDirector.GetComponent<RouteGeneratorC>().route3StopOff];
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
		float d = 1f;
		if (gameObject.transform.localScale.x == 1f)
		{
			d = 0.5f;
		}
		gameObject.transform.SetParent(this.stopOffTarget);
		this.stopOffTarget.localScale = Vector3.one;
		gameObject.transform.localScale = Vector3.one * d;
		gameObject.transform.position = this.stopOffTarget.transform.position;
		gameObject.transform.rotation = this.stopOffTarget.transform.rotation;
		this.spawnDirector.GetComponent<RouteGeneratorC>().spawnedRouteSegments.Add(gameObject);
	}

	// Token: 0x06000957 RID: 2391 RVA: 0x000DC930 File Offset: 0x000DAD30
	public void SpawnPotHoles()
	{
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentRoadCondition == 0)
		{
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentRoadCondition == 1)
		{
			int num = UnityEngine.Random.Range(this.spawnDirector.GetComponent<DirectorC>().potHoleCount, this.spawnDirector.GetComponent<DirectorC>().potHoleCount + 5);
			for (int i = 0; i < num; i++)
			{
				RouteGeneratorC component = this.spawnDirector.GetComponent<RouteGeneratorC>();
				int num2 = UnityEngine.Random.Range(0, component.potHolePrefabs.Length - 1);
				int num3 = UnityEngine.Random.Range(0, this.puddleTargets.Length - 1);
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(component.potHolePrefabs[num2], this.puddleTargets[num3].transform.position, Quaternion.identity);
				gameObject.transform.parent = this.puddleTargets[num3];
				gameObject.transform.localEulerAngles = Vector3.zero;
			}
			int num4 = UnityEngine.Random.Range(this.spawnDirector.GetComponent<DirectorC>().oilSpillCount, this.spawnDirector.GetComponent<DirectorC>().oilSpillCount + 3);
			for (int j = 0; j < num4; j++)
			{
				RouteGeneratorC component2 = this.spawnDirector.GetComponent<RouteGeneratorC>();
				int num5 = UnityEngine.Random.Range(0, component2.oilSpillPrefabs.Length - 1);
				int num6 = UnityEngine.Random.Range(0, this.puddleTargets.Length - 1);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(component2.oilSpillPrefabs[num5], this.puddleTargets[num6].transform.position, Quaternion.identity);
				gameObject2.transform.parent = this.puddleTargets[num6];
				gameObject2.transform.localEulerAngles = Vector3.zero;
			}
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentRoadCondition == 2)
		{
			int num7 = UnityEngine.Random.Range(this.spawnDirector.GetComponent<DirectorC>().potHoleCount + 3, this.spawnDirector.GetComponent<DirectorC>().potHoleCount + 7);
			for (int k = 0; k < num7; k++)
			{
				RouteGeneratorC component3 = this.spawnDirector.GetComponent<RouteGeneratorC>();
				int num8 = UnityEngine.Random.Range(0, component3.potHolePrefabs.Length - 1);
				int num9 = UnityEngine.Random.Range(0, this.puddleTargets.Length - 1);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(component3.potHolePrefabs[num8], this.puddleTargets[num9].transform.position, Quaternion.identity);
				gameObject3.transform.parent = this.puddleTargets[num9];
				gameObject3.transform.localEulerAngles = Vector3.zero;
			}
			int num10 = UnityEngine.Random.Range(this.spawnDirector.GetComponent<DirectorC>().oilSpillCount + 2, this.spawnDirector.GetComponent<DirectorC>().oilSpillCount + 5);
			for (int l = 0; l < num10; l++)
			{
				RouteGeneratorC component4 = this.spawnDirector.GetComponent<RouteGeneratorC>();
				int num11 = UnityEngine.Random.Range(0, component4.oilSpillPrefabs.Length - 1);
				int num12 = UnityEngine.Random.Range(0, this.puddleTargets.Length - 1);
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(component4.oilSpillPrefabs[num11], this.puddleTargets[num12].transform.position, Quaternion.identity);
				gameObject4.transform.parent = this.puddleTargets[num12];
				gameObject4.transform.localEulerAngles = Vector3.zero;
			}
			return;
		}
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x000DCC80 File Offset: 0x000DB080
	public void SpawnPuddles()
	{
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentWeatherCondition == 0)
		{
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentWeatherCondition == 1)
		{
			int num = UnityEngine.Random.Range(this.spawnDirector.GetComponent<DirectorC>().puddleCount, this.spawnDirector.GetComponent<DirectorC>().puddleCount + 5);
			for (int i = 0; i < num; i++)
			{
				RouteGeneratorC component = this.spawnDirector.GetComponent<RouteGeneratorC>();
				int num2 = UnityEngine.Random.Range(0, component.puddlePrefabs.Length - 1);
				int num3 = UnityEngine.Random.Range(0, this.puddleTargets.Length - 1);
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(component.puddlePrefabs[num2], this.puddleTargets[num3].transform.position, Quaternion.identity);
				gameObject.transform.parent = this.puddleTargets[num3];
				gameObject.transform.localEulerAngles = Vector3.zero;
			}
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentWeatherCondition == 2)
		{
			int num4 = UnityEngine.Random.Range(this.spawnDirector.GetComponent<DirectorC>().puddleCount, this.spawnDirector.GetComponent<DirectorC>().puddleCount + 5);
			for (int j = 0; j < num4; j++)
			{
				RouteGeneratorC component2 = this.spawnDirector.GetComponent<RouteGeneratorC>();
				int num5 = UnityEngine.Random.Range(0, component2.lrpuddlePrefabs.Length - 1);
				int num6 = UnityEngine.Random.Range(0, this.puddleTargets.Length - 1);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(component2.lrpuddlePrefabs[num5], this.puddleTargets[num6].transform.position, Quaternion.identity);
				gameObject2.transform.parent = this.puddleTargets[num6];
			}
			return;
		}
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().currentWeatherCondition == 3)
		{
			int num7 = UnityEngine.Random.Range(this.spawnDirector.GetComponent<DirectorC>().puddleCount + 5, this.spawnDirector.GetComponent<DirectorC>().puddleCount + 10);
			for (int k = 0; k < num7; k++)
			{
				RouteGeneratorC component3 = this.spawnDirector.GetComponent<RouteGeneratorC>();
				int num8 = UnityEngine.Random.Range(0, component3.hrpuddlePrefabs.Length - 1);
				int num9 = UnityEngine.Random.Range(0, this.puddleTargets.Length - 1);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(component3.hrpuddlePrefabs[num8], this.puddleTargets[num9].transform.position, Quaternion.identity);
				gameObject3.transform.parent = this.puddleTargets[num9];
			}
			return;
		}
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x000DCF04 File Offset: 0x000DB304
	public void SpawnCrates()
	{
		if (this.crateNodes.Count == 0)
		{
			return;
		}
		int num = 0;
		if (!this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 0)
			{
				num = UnityEngine.Random.Range(0, 3);
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				num = UnityEngine.Random.Range(0, 5);
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				num = UnityEngine.Random.Range(0, 3);
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				num = UnityEngine.Random.Range(0, 3);
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 4)
			{
				num = UnityEngine.Random.Range(0, 3);
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5)
			{
				num = UnityEngine.Random.Range(0, 3);
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			num = UnityEngine.Random.Range(0, 3);
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			num = UnityEngine.Random.Range(0, 5);
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			num = UnityEngine.Random.Range(0, 3);
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			num = UnityEngine.Random.Range(0, 3);
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			num = UnityEngine.Random.Range(0, 3);
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			num = UnityEngine.Random.Range(0, 3);
		}
		for (int i = 0; i < num; i++)
		{
			RouteGeneratorC component = this.spawnDirector.GetComponent<RouteGeneratorC>();
			int num2 = UnityEngine.Random.Range(0, component.cratePrefabs.Length);
			int index = UnityEngine.Random.Range(0, this.crateNodes.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(component.cratePrefabs[num2], this.crateNodes[index].transform.position, Quaternion.identity);
			gameObject.transform.parent = this.crateNodes[index];
			gameObject.transform.localPosition = new Vector3(0f, gameObject.transform.localPosition.y + 2f, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			component.cratesToBeCleanedUp.Add(gameObject);
			gameObject.GetComponent<ObjectPickupC>().isInGarbageCollection = component.cratesToBeCleanedUp.Count - 1;
			this.crateNodes.RemoveAt(index);
			gameObject.transform.parent = null;
		}
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x000DD1E4 File Offset: 0x000DB5E4
	public void SpawnAICars()
	{
		if (this.trafficAINodes.Count == 0)
		{
			return;
		}
		int num = 0;
		if (this.spawnDirector.GetComponent<RouteGeneratorC>().drivingTowardsHome)
		{
			if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				if (ES3.Exists("aiCount"))
				{
					this.aiCount = ES3.LoadInt("aiCount");
					if (this.aiCount == 0)
					{
						num = 0;
					}
					else if (this.aiCount == 1)
					{
						num = UnityEngine.Random.Range(0, 1);
					}
					else if (this.aiCount == 2)
					{
						num = UnityEngine.Random.Range(0, 3);
					}
					else if (this.aiCount == 3)
					{
						num = UnityEngine.Random.Range(2, 4);
					}
					else if (this.aiCount == 4)
					{
						num = 4;
					}
				}
				else
				{
					num = UnityEngine.Random.Range(2, 4);
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				if (ES3.Exists("aiCount"))
				{
					this.aiCount = ES3.LoadInt("aiCount");
					if (this.aiCount == 0)
					{
						num = 0;
					}
					else if (this.aiCount == 1)
					{
						num = UnityEngine.Random.Range(0, 1);
					}
					else if (this.aiCount == 2)
					{
						num = UnityEngine.Random.Range(0, 3);
					}
					else if (this.aiCount == 3)
					{
						num = UnityEngine.Random.Range(2, 4);
					}
					else if (this.aiCount == 4)
					{
						num = 4;
					}
				}
				else
				{
					num = UnityEngine.Random.Range(2, 4);
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				if (ES3.Exists("aiCount"))
				{
					this.aiCount = ES3.LoadInt("aiCount");
					if (this.aiCount == 0)
					{
						num = 0;
					}
					else if (this.aiCount == 1)
					{
						num = UnityEngine.Random.Range(0, 1);
					}
					else if (this.aiCount == 2)
					{
						num = UnityEngine.Random.Range(0, 3);
					}
					else if (this.aiCount == 3)
					{
						num = UnityEngine.Random.Range(2, 4);
					}
					else if (this.aiCount == 4)
					{
						num = 4;
					}
				}
				else
				{
					num = UnityEngine.Random.Range(2, 4);
				}
			}
			else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 6)
			{
				if (ES3.Exists("aiCount"))
				{
					this.aiCount = ES3.LoadInt("aiCount");
					if (this.aiCount == 0)
					{
						num = 0;
					}
					else if (this.aiCount == 1)
					{
						num = UnityEngine.Random.Range(1, 2);
					}
					else if (this.aiCount == 2)
					{
						num = UnityEngine.Random.Range(2, 4);
					}
					else if (this.aiCount == 3)
					{
						num = UnityEngine.Random.Range(3, 4);
					}
					else if (this.aiCount == 4)
					{
						num = 4;
					}
				}
				else
				{
					num = UnityEngine.Random.Range(2, 4);
				}
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			if (ES3.Exists("aiCount"))
			{
				this.aiCount = ES3.LoadInt("aiCount");
				if (this.aiCount == 0)
				{
					num = 0;
				}
				else if (this.aiCount == 1)
				{
					num = UnityEngine.Random.Range(0, 1);
				}
				else if (this.aiCount == 2)
				{
					num = UnityEngine.Random.Range(0, 3);
				}
				else if (this.aiCount == 3)
				{
					num = UnityEngine.Random.Range(2, 4);
				}
				else if (this.aiCount == 4)
				{
					num = 4;
				}
			}
			else
			{
				num = UnityEngine.Random.Range(2, 4);
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			if (ES3.Exists("aiCount"))
			{
				this.aiCount = ES3.LoadInt("aiCount");
				if (this.aiCount == 0)
				{
					num = 0;
				}
				else if (this.aiCount == 1)
				{
					num = UnityEngine.Random.Range(0, 1);
				}
				else if (this.aiCount == 2)
				{
					num = UnityEngine.Random.Range(0, 3);
				}
				else if (this.aiCount == 3)
				{
					num = UnityEngine.Random.Range(2, 4);
				}
				else if (this.aiCount == 4)
				{
					num = 4;
				}
			}
			else
			{
				num = UnityEngine.Random.Range(2, 4);
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			if (ES3.Exists("aiCount"))
			{
				this.aiCount = ES3.LoadInt("aiCount");
				if (this.aiCount == 0)
				{
					num = 0;
				}
				else if (this.aiCount == 1)
				{
					num = UnityEngine.Random.Range(0, 1);
				}
				else if (this.aiCount == 2)
				{
					num = UnityEngine.Random.Range(0, 3);
				}
				else if (this.aiCount == 3)
				{
					num = UnityEngine.Random.Range(2, 4);
				}
				else if (this.aiCount == 4)
				{
					num = 4;
				}
			}
			else
			{
				num = UnityEngine.Random.Range(2, 4);
			}
		}
		else if (this.spawnDirector.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			if (ES3.Exists("aiCount"))
			{
				this.aiCount = ES3.LoadInt("aiCount");
				if (this.aiCount == 0)
				{
					num = 0;
				}
				else if (this.aiCount == 1)
				{
					num = UnityEngine.Random.Range(1, 2);
				}
				else if (this.aiCount == 2)
				{
					num = UnityEngine.Random.Range(2, 4);
				}
				else if (this.aiCount == 3)
				{
					num = UnityEngine.Random.Range(3, 4);
				}
				else if (this.aiCount == 4)
				{
					num = 4;
				}
			}
			else
			{
				num = UnityEngine.Random.Range(2, 4);
			}
		}
		for (int i = 0; i < num; i++)
		{
			if (this.trafficAINodes.Count == 0)
			{
				return;
			}
			RouteGeneratorC component = this.spawnDirector.GetComponent<RouteGeneratorC>();
			int num2 = UnityEngine.Random.Range(0, component.aiCarPrefabs.Length);
			int index = UnityEngine.Random.Range(0, this.trafficAINodes.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(component.aiCarPrefabs[num2], this.trafficAINodes[index].transform.position, Quaternion.identity);
			gameObject.transform.parent = this.trafficAINodes[index];
			gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 2f, 0f, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			this.trafficAINodes.RemoveAt(index);
		}
	}

	// Token: 0x04000CB6 RID: 3254
	public GameObject spawnDirector;

	// Token: 0x04000CB7 RID: 3255
	public GameObject continueNode;

	// Token: 0x04000CB8 RID: 3256
	public int startSize;

	// Token: 0x04000CB9 RID: 3257
	public int continueSize;

	// Token: 0x04000CBA RID: 3258
	public Transform[] puddleTargets;

	// Token: 0x04000CBB RID: 3259
	public Transform DestinationNode;

	// Token: 0x04000CBC RID: 3260
	public Transform[] sceneryTargets;

	// Token: 0x04000CBD RID: 3261
	public Transform stopOffTarget;

	// Token: 0x04000CBE RID: 3262
	public List<Transform> trafficAINodes = new List<Transform>();

	// Token: 0x04000CBF RID: 3263
	public List<Transform> crateNodes = new List<Transform>();

	// Token: 0x04000CC0 RID: 3264
	public List<Transform> abandonCarNodes = new List<Transform>();

	// Token: 0x04000CC1 RID: 3265
	public int randomChance;

	// Token: 0x04000CC2 RID: 3266
	private int aiCount;

	// Token: 0x04000CC3 RID: 3267
	public GameObject[] roadConditions;

	// Token: 0x04000CC4 RID: 3268
	public GameObject signForwardDistance;

	// Token: 0x04000CC5 RID: 3269
	public GameObject signBackDistance;
}
