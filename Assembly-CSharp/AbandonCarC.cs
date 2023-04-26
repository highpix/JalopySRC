using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x0200008A RID: 138
public class AbandonCarC : MonoBehaviour
{
	// Token: 0x06000428 RID: 1064 RVA: 0x00043C58 File Offset: 0x00042058
	private void Start()
	{
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.SpawnEngine();
		this.SpawnAirFilter();
		this.SpawnCarburettor();
		this.SpawnIgnitionCoil();
		this.SpawnFuelTank();
		this.SpawnBattery();
		this.SpawnWaterTank();
		this.SpawnBoot();
		this.SpawnTyre();
		this.SetLicensePlate(this.carLogic);
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x00043CB8 File Offset: 0x000420B8
	public void SetLicensePlate(GameObject carLogic)
	{
		if (carLogic.GetComponent<ExtraUpgradesC>().licencePlateStrings.Count == 0)
		{
			UnityEngine.Object.Destroy(this.licencePlate);
			return;
		}
		int num = UnityEngine.Random.Range(0, carLogic.GetComponent<ExtraUpgradesC>().licencePlateStrings.Count);
		if (num >= 75)
		{
			this.licencePlate.GetComponent<MeshFilter>().mesh = this.licencePlateMeshChange[1];
			this.licencePlateTexts[0].SetActive(false);
			this.licencePlateTexts[1].SetActive(true);
			this.licencePlateTexts[1].GetComponent<TextMeshPro>().text = Language.Get(carLogic.GetComponent<ExtraUpgradesC>().licencePlateStrings[num], "Inspector_UI");
		}
		else
		{
			this.licencePlate.GetComponent<MeshFilter>().mesh = this.licencePlateMeshChange[0];
			this.licencePlateTexts[0].SetActive(true);
			this.licencePlateTexts[1].SetActive(false);
			this.licencePlateTexts[0].GetComponent<TextMeshPro>().text = Language.Get(carLogic.GetComponent<ExtraUpgradesC>().licencePlateStrings[num], "Inspector_UI");
		}
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x00043DCC File Offset: 0x000421CC
	public void SpawnTyre()
	{
		int num = UnityEngine.Random.Range(0, this.tyres.Length);
		int num2 = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarLogicC>().bootInventory.GetComponent<InventoryLogicC>().wheelHolder2Available)
		{
			num2 += 10;
			if (this.carLogic.GetComponent<CarLogicC>().bootInventory.GetComponent<InventoryLogicC>().wheelHolder1Available)
			{
				num2 += 10;
			}
		}
		if (num2 > 25)
		{
			int index = UnityEngine.Random.Range(0, this.tyreTargets.Count);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.tyres[num], this.tyreTargets[index].position, this.tyreTargets[index].rotation);
			if (gameObject.GetComponent<Rigidbody>())
			{
				gameObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
				gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			}
			gameObject.transform.parent = this.tyreTargets[index];
			gameObject.transform.localScale = new Vector3(0.160587f, 0.160587f, 0.1404649f);
			this.tyreTargets.RemoveAt(index);
			gameObject.name = this.tyres[num].name;
			float condition = Mathf.Round(UnityEngine.Random.Range(1f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
			if (num2 > 60)
			{
				int index2 = UnityEngine.Random.Range(0, this.tyreTargets.Count);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.tyres[num], this.tyreTargets[index2].position, this.tyreTargets[index2].rotation);
				if (gameObject2.GetComponent<Rigidbody>())
				{
					gameObject2.gameObject.GetComponent<Rigidbody>().useGravity = false;
					gameObject2.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				}
				gameObject2.transform.parent = this.tyreTargets[index2];
				gameObject2.transform.localScale = new Vector3(0.160587f, 0.160587f, 0.1404649f);
				this.tyreTargets.RemoveAt(index2);
				gameObject2.name = this.tyres[num].name;
				float condition2 = Mathf.Round(UnityEngine.Random.Range(1f, gameObject2.GetComponent<EngineComponentC>().durability));
				gameObject2.GetComponent<EngineComponentC>().Condition = condition2;
				gameObject2.GetComponent<EngineComponentC>().UpdateCondition();
			}
			if (num2 > 80)
			{
				int index3 = UnityEngine.Random.Range(0, this.tyreTargets.Count);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.tyres[num], this.tyreTargets[index3].position, this.tyreTargets[index3].rotation);
				if (gameObject3.GetComponent<Rigidbody>())
				{
					gameObject3.gameObject.GetComponent<Rigidbody>().useGravity = false;
					gameObject3.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				}
				gameObject3.transform.parent = this.tyreTargets[index3];
				gameObject3.transform.localScale = new Vector3(0.160587f, 0.160587f, 0.1404649f);
				this.tyreTargets.RemoveAt(index3);
				gameObject3.name = this.tyres[num].name;
				float condition3 = Mathf.Round(UnityEngine.Random.Range(1f, gameObject3.GetComponent<EngineComponentC>().durability));
				gameObject3.GetComponent<EngineComponentC>().Condition = condition3;
				gameObject3.GetComponent<EngineComponentC>().UpdateCondition();
			}
			if (num2 > 90)
			{
				int index4 = UnityEngine.Random.Range(0, this.tyreTargets.Count);
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.tyres[num], this.tyreTargets[index4].position, this.tyreTargets[index4].rotation);
				if (gameObject4.GetComponent<Rigidbody>())
				{
					gameObject4.gameObject.GetComponent<Rigidbody>().useGravity = false;
					gameObject4.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				}
				gameObject4.transform.parent = this.tyreTargets[index4];
				gameObject4.transform.localScale = new Vector3(0.160587f, 0.160587f, 0.1404649f);
				this.tyreTargets.RemoveAt(index4);
				gameObject4.name = this.tyres[num].name;
				float condition4 = Mathf.Round(UnityEngine.Random.Range(1f, gameObject4.GetComponent<EngineComponentC>().durability));
				gameObject4.GetComponent<EngineComponentC>().Condition = condition4;
				gameObject4.GetComponent<EngineComponentC>().UpdateCondition();
			}
			if (num2 > 95)
			{
				int index5 = UnityEngine.Random.Range(0, this.tyreTargets.Count);
				GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.tyres[num], this.tyreTargets[index5].position, this.tyreTargets[index5].rotation);
				if (gameObject5.GetComponent<Rigidbody>())
				{
					gameObject5.gameObject.GetComponent<Rigidbody>().useGravity = false;
					gameObject5.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				}
				gameObject5.transform.parent = this.tyreTargets[index5];
				gameObject5.transform.localScale = new Vector3(0.160587f, 0.160587f, 0.1404649f);
				this.tyreTargets.RemoveAt(index5);
				gameObject5.name = this.tyres[num].name;
				float condition5 = Mathf.Round(UnityEngine.Random.Range(1f, gameObject5.GetComponent<EngineComponentC>().durability));
				gameObject5.GetComponent<EngineComponentC>().Condition = condition5;
				gameObject5.GetComponent<EngineComponentC>().UpdateCondition();
			}
		}
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00044390 File Offset: 0x00042790
	public void SpawnBoot()
	{
		int num = UnityEngine.Random.Range(0, 101);
		int index = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
		if (this.debugAmountToSpawn != 0)
		{
			num = this.debugAmountToSpawn;
		}
		if (num < 5)
		{
			return;
		}
		if (num >= 5 && num < 50)
		{
			int num2 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num2 += this.paintDecalSpawnModifier;
			if (num2 > this.bootSpawns.Length)
			{
				int num3 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num3], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject.GetComponent<Rigidbody>())
				{
					gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				}
				gameObject.GetComponent<BoxCollider>().isTrigger = false;
				if (gameObject.GetComponent<ObjectPickupC>())
				{
					gameObject.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject.name = this.paintAndDecals[num3].name;
				if (gameObject.GetComponent<Rigidbody>())
				{
					gameObject.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject.AddComponent<Rigidbody>();
				}
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num2], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject2.GetComponent<Rigidbody>())
				{
					gameObject2.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject2.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject2.GetComponent<BoxCollider>().isTrigger = false;
				}
				gameObject2.name = this.bootSpawns[num2].name;
				if (gameObject2.GetComponent<ObjectPickupC>())
				{
					gameObject2.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				if (gameObject2.GetComponent<Rigidbody>())
				{
					gameObject2.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject2.AddComponent<Rigidbody>();
				}
				gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		else if (num >= 50 && num < 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num4 += this.paintDecalSpawnModifier;
			int index2 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num4 > this.bootSpawns.Length)
			{
				int num5 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num5], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject3.GetComponent<Rigidbody>())
				{
					gameObject3.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject3.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject3.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject3.GetComponent<ObjectPickupC>())
				{
					gameObject3.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject3.name = this.paintAndDecals[num5].name;
				if (gameObject3.GetComponent<Rigidbody>())
				{
					gameObject3.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject3.AddComponent<Rigidbody>();
				}
				gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num4], this.bootSpawnTargets[index2].position, this.bootSpawnTargets[index2].rotation);
				if (gameObject4.GetComponent<Rigidbody>())
				{
					gameObject4.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject4.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject4.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject4.GetComponent<ObjectPickupC>())
				{
					gameObject4.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject4.name = this.bootSpawns[num4].name;
				if (gameObject4.GetComponent<Rigidbody>())
				{
					gameObject4.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject4.AddComponent<Rigidbody>();
				}
				gameObject4.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index2);
			}
			int num6 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num6 += this.paintDecalSpawnModifier;
			int index3 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num6 > this.bootSpawns.Length)
			{
				int num7 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num7], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject5.GetComponent<Rigidbody>())
				{
					gameObject5.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject5.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject5.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject5.GetComponent<ObjectPickupC>())
				{
					gameObject5.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject5.name = this.paintAndDecals[num7].name;
				if (gameObject5.GetComponent<Rigidbody>())
				{
					gameObject5.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject5.AddComponent<Rigidbody>();
				}
				gameObject5.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num6], this.bootSpawnTargets[index3].position, this.bootSpawnTargets[index3].rotation);
				if (gameObject6.GetComponent<Rigidbody>())
				{
					gameObject6.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject6.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject6.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject6.GetComponent<ObjectPickupC>())
				{
					gameObject6.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject6.name = this.bootSpawns[num6].name;
				if (gameObject6.GetComponent<Rigidbody>())
				{
					gameObject6.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject6.AddComponent<Rigidbody>();
				}
				gameObject6.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index3);
			}
		}
		else if (num >= 75 && (double)num < 87.5)
		{
			int num8 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num8 += this.paintDecalSpawnModifier;
			int index4 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num8 > this.bootSpawns.Length)
			{
				int num9 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num9], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject7.GetComponent<Rigidbody>())
				{
					gameObject7.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject7.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject7.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject7.GetComponent<ObjectPickupC>())
				{
					gameObject7.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject7.name = this.paintAndDecals[num9].name;
				if (gameObject7.GetComponent<Rigidbody>())
				{
					gameObject7.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject7.AddComponent<Rigidbody>();
				}
				gameObject7.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num8], this.bootSpawnTargets[index4].position, this.bootSpawnTargets[index4].rotation);
				if (gameObject8.GetComponent<Rigidbody>())
				{
					gameObject8.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject8.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject8.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject8.GetComponent<ObjectPickupC>())
				{
					gameObject8.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject8.name = this.bootSpawns[num8].name;
				if (gameObject8.GetComponent<Rigidbody>())
				{
					gameObject8.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject8.AddComponent<Rigidbody>();
				}
				gameObject8.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index4);
			}
			int num10 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num10 += this.paintDecalSpawnModifier;
			int index5 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num10 > this.bootSpawns.Length)
			{
				int num11 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num11], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject9.GetComponent<Rigidbody>())
				{
					gameObject9.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject9.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject9.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject9.GetComponent<ObjectPickupC>())
				{
					gameObject9.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject9.name = this.paintAndDecals[num11].name;
				if (gameObject9.GetComponent<Rigidbody>())
				{
					gameObject9.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject9.AddComponent<Rigidbody>();
				}
				gameObject9.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num10], this.bootSpawnTargets[index5].position, this.bootSpawnTargets[index5].rotation);
				if (gameObject10.GetComponent<Rigidbody>())
				{
					gameObject10.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject10.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject10.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject10.GetComponent<ObjectPickupC>())
				{
					gameObject10.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject10.name = this.bootSpawns[num10].name;
				if (gameObject10.GetComponent<Rigidbody>())
				{
					gameObject10.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject10.AddComponent<Rigidbody>();
				}
				gameObject10.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index5);
			}
			int num12 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num12 += this.paintDecalSpawnModifier;
			int index6 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num12 >= this.bootSpawns.Length)
			{
				int num13 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject11 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num13], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject11.GetComponent<Rigidbody>())
				{
					gameObject11.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject11.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject11.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject11.GetComponent<ObjectPickupC>())
				{
					gameObject11.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject11.name = this.paintAndDecals[num13].name;
				if (gameObject11.GetComponent<Rigidbody>())
				{
					gameObject11.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject11.AddComponent<Rigidbody>();
				}
				gameObject11.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject12 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num12], this.bootSpawnTargets[index6].position, this.bootSpawnTargets[index6].rotation);
				if (gameObject12.GetComponent<Rigidbody>())
				{
					gameObject12.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject12.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject12.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject12.GetComponent<ObjectPickupC>())
				{
					gameObject12.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject12.name = this.bootSpawns[num12].name;
				if (gameObject12.GetComponent<Rigidbody>())
				{
					gameObject12.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject12.AddComponent<Rigidbody>();
				}
				gameObject12.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index6);
			}
		}
		else if ((double)num >= 87.5 && num <= 100)
		{
			int num14 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num14 += this.paintDecalSpawnModifier;
			int index7 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num14 > this.bootSpawns.Length)
			{
				int num15 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject13 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num15], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject13.GetComponent<Rigidbody>())
				{
					gameObject13.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject13.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject13.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject13.GetComponent<ObjectPickupC>())
				{
					gameObject13.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject13.name = this.paintAndDecals[num15].name;
				if (gameObject13.GetComponent<Rigidbody>())
				{
					gameObject13.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject13.AddComponent<Rigidbody>();
				}
				gameObject13.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject14 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num14], this.bootSpawnTargets[index7].position, this.bootSpawnTargets[index7].rotation);
				if (gameObject14.GetComponent<Rigidbody>())
				{
					gameObject14.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject14.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject14.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject14.GetComponent<ObjectPickupC>())
				{
					gameObject14.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject14.name = this.bootSpawns[num14].name;
				if (gameObject14.GetComponent<Rigidbody>())
				{
					gameObject14.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject14.AddComponent<Rigidbody>();
				}
				gameObject14.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index7);
			}
			int num16 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num16 += this.paintDecalSpawnModifier;
			int index8 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count - 1);
			if (num16 > this.bootSpawns.Length)
			{
				int num17 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject15 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num17], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject15.GetComponent<Rigidbody>())
				{
					gameObject15.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject15.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject15.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject15.GetComponent<ObjectPickupC>())
				{
					gameObject15.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject15.name = this.paintAndDecals[num17].name;
				if (gameObject15.GetComponent<Rigidbody>())
				{
					gameObject15.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject15.AddComponent<Rigidbody>();
				}
				gameObject15.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject16 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num16], this.bootSpawnTargets[index8].position, this.bootSpawnTargets[index8].rotation);
				if (gameObject16.GetComponent<Rigidbody>())
				{
					gameObject16.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject16.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject16.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject16.GetComponent<ObjectPickupC>())
				{
					gameObject16.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject16.name = this.bootSpawns[num16].name;
				if (gameObject16.GetComponent<Rigidbody>())
				{
					gameObject16.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject16.AddComponent<Rigidbody>();
				}
				gameObject16.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index8);
			}
			int num18 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num18 += this.paintDecalSpawnModifier;
			int index9 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num18 > this.bootSpawns.Length)
			{
				int num19 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject17 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num19], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject17.GetComponent<ObjectPickupC>())
				{
					gameObject17.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject17.name = this.paintAndDecals[num19].name;
				if (gameObject17.GetComponent<Rigidbody>())
				{
					gameObject17.GetComponent<Rigidbody>().isKinematic = false;
					gameObject17.GetComponent<BoxCollider>().isTrigger = false;
				}
				else
				{
					gameObject17.AddComponent<Rigidbody>();
				}
				gameObject17.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject18 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num18], this.bootSpawnTargets[index9].position, this.bootSpawnTargets[index9].rotation);
				if (gameObject18.GetComponent<Rigidbody>())
				{
					gameObject18.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject18.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject18.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject18.GetComponent<ObjectPickupC>())
				{
					gameObject18.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject18.name = this.bootSpawns[num18].name;
				if (gameObject18.GetComponent<Rigidbody>())
				{
					gameObject18.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject18.AddComponent<Rigidbody>();
				}
				gameObject18.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index9);
			}
			int num20 = UnityEngine.Random.Range(0, this.bootSpawns.Length);
			num20 += this.paintDecalSpawnModifier;
			int index10 = UnityEngine.Random.Range(0, this.bootSpawnTargets.Count);
			if (num20 > this.bootSpawns.Length)
			{
				int num21 = UnityEngine.Random.Range(0, this.paintAndDecals.Length);
				GameObject gameObject19 = UnityEngine.Object.Instantiate<GameObject>(this.paintAndDecals[num21], this.bootSpawnTargets[index].position, this.bootSpawnTargets[index].rotation);
				if (gameObject19.GetComponent<Rigidbody>())
				{
					gameObject19.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject19.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject19.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject19.GetComponent<ObjectPickupC>())
				{
					gameObject19.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject19.name = this.paintAndDecals[num21].name;
				if (gameObject19.GetComponent<Rigidbody>())
				{
					gameObject19.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject19.AddComponent<Rigidbody>();
				}
				gameObject19.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				GameObject gameObject20 = UnityEngine.Object.Instantiate<GameObject>(this.bootSpawns[num20], this.bootSpawnTargets[index10].position, this.bootSpawnTargets[index10].rotation);
				if (gameObject20.GetComponent<Rigidbody>())
				{
					gameObject20.gameObject.GetComponent<Rigidbody>().useGravity = true;
					gameObject20.gameObject.GetComponent<Rigidbody>().isKinematic = false;
					gameObject20.GetComponent<BoxCollider>().isTrigger = false;
				}
				if (gameObject20.GetComponent<ObjectPickupC>())
				{
					gameObject20.GetComponent<ObjectPickupC>().forceCollision = true;
				}
				gameObject20.name = this.bootSpawns[num20].name;
				if (gameObject20.GetComponent<Rigidbody>())
				{
					gameObject20.GetComponent<Rigidbody>().isKinematic = false;
				}
				else
				{
					gameObject20.AddComponent<Rigidbody>();
				}
				gameObject20.transform.localScale = new Vector3(1f, 1f, 1f);
				this.bootSpawnTargets.RemoveAt(index10);
			}
		}
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00045A84 File Offset: 0x00043E84
	public void SpawnEngine()
	{
		int num = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine != null)
		{
			double num2 = (double)this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability * 0.34;
			double num3 = (double)this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().durability * 0.67;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition < num2)
			{
				num += 20;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition > num2 && (double)this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition < num3)
			{
				num += 10;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().InstalledEngine.GetComponent<EngineComponentC>().Condition > num3)
			{
			}
		}
		if (num > 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.engineBlocks.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.engineBlocks[num4], this.engineBlockTarget.position, this.engineBlockTarget.rotation);
			gameObject.name = this.engineBlocks[num4].name;
			gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.transform.parent = this.engineBlockTarget;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			float condition = Mathf.Round(UnityEngine.Random.Range(1f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x00045CAC File Offset: 0x000440AC
	public void SpawnAirFilter()
	{
		int num = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter != null)
		{
			double num2 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability * 0.34;
			double num3 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().durability * 0.67;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition < num2)
			{
				num += 20;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition > num2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition < num3)
			{
				num += 10;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedAirFilter.GetComponent<EngineComponentC>().Condition > num3)
			{
			}
		}
		if (num > 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.airFilters.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.airFilters[num4], this.airFilterTarget.position, this.airFilterTarget.rotation);
			gameObject.name = this.airFilters[num4].name;
			gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.transform.parent = this.airFilterTarget;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			float condition = Mathf.Round(UnityEngine.Random.Range(1f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x00045ED4 File Offset: 0x000442D4
	public void SpawnCarburettor()
	{
		int num = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor != null)
		{
			double num2 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability * 0.34;
			double num3 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().durability * 0.67;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition < num2)
			{
				num += 20;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition > num2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition < num3)
			{
				num += 10;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedCarburettor.GetComponent<EngineComponentC>().Condition > num3)
			{
			}
		}
		if (num > 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.carburettors.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.carburettors[num4], this.carburettorTarget.position, this.carburettorTarget.rotation);
			gameObject.name = this.carburettors[num4].name;
			gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.transform.parent = this.carburettorTarget;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			float condition = Mathf.Round(UnityEngine.Random.Range(1f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x000460FC File Offset: 0x000444FC
	public void SpawnIgnitionCoil()
	{
		int num = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil != null)
		{
			double num2 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability * 0.34;
			double num3 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().durability * 0.67;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition < num2)
			{
				num += 20;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition > num2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition < num3)
			{
				num += 10;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil.GetComponent<EngineComponentC>().Condition > num3)
			{
			}
		}
		if (num > 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.ignitionCoils.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ignitionCoils[num4], this.ignitionCoilTarget.position, this.ignitionCoilTarget.rotation);
			gameObject.name = this.ignitionCoils[num4].name;
			gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.transform.parent = this.ignitionCoilTarget;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			float condition = Mathf.Round(UnityEngine.Random.Range(1f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x00046324 File Offset: 0x00044724
	public void SpawnFuelTank()
	{
		int num = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
		{
			double num2 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability * 0.34;
			double num3 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().durability * 0.67;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition < num2)
			{
				num += 20;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition > num2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition < num3)
			{
				num += 10;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().Condition > num3)
			{
			}
		}
		if (num > 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.fuelTanks.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.fuelTanks[num4], this.fuelTankTarget.position, this.fuelTankTarget.rotation);
			gameObject.name = this.fuelTanks[num4].name;
			gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.transform.parent = this.fuelTankTarget;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			float currentFuelAmount = UnityEngine.Random.Range(0f, gameObject.GetComponent<EngineComponentC>().totalFuelAmount);
			gameObject.GetComponent<EngineComponentC>().currentFuelAmount = currentFuelAmount;
			float condition = Mathf.Round(UnityEngine.Random.Range(1f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x00046570 File Offset: 0x00044970
	public void SpawnBattery()
	{
		int num = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
		{
			double num2 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability * 0.34;
			double num3 = (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().durability * 0.67;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition < num2)
			{
				num += 20;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > num2 && (double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition < num3)
			{
				num += 10;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().Condition > num3)
			{
			}
		}
		if (num > 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.batteries.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.batteries[num4], this.batteryTarget.position, this.batteryTarget.rotation);
			gameObject.name = this.batteries[num4].name;
			gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.transform.parent = this.batteryTarget;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			float condition = Mathf.Round(UnityEngine.Random.Range(1f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x00046798 File Offset: 0x00044B98
	public void SpawnWaterTank()
	{
		int num = UnityEngine.Random.Range(0, 101);
		if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
		{
			double num2 = (double)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability * 0.34;
			double num3 = (double)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().durability * 0.67;
			if ((double)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition < num2)
			{
				num += 20;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition > num2 && (double)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition < num3)
			{
				num += 10;
			}
			else if ((double)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().Condition > num3)
			{
			}
		}
		if (num > 75)
		{
			int num4 = UnityEngine.Random.Range(0, this.waterTanks.Length);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.waterTanks[num4], this.waterTankTarget.position, this.waterTankTarget.rotation);
			gameObject.name = this.waterTanks[num4].name;
			gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			gameObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			gameObject.transform.parent = this.waterTankTarget;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			int currentWaterCharges = UnityEngine.Random.Range(0, gameObject.GetComponent<EngineComponentC>().totalWaterCharges);
			gameObject.GetComponent<EngineComponentC>().currentWaterCharges = currentWaterCharges;
			gameObject.transform.GetChild(0).gameObject.GetComponent<WaterSupplyRelayC>().WaterUpdate();
			float condition = Mathf.Round(UnityEngine.Random.Range(0f, gameObject.GetComponent<EngineComponentC>().durability));
			gameObject.GetComponent<EngineComponentC>().Condition = condition;
			gameObject.GetComponent<EngineComponentC>().UpdateCondition();
		}
	}

	// Token: 0x04000610 RID: 1552
	public GameObject carLogic;

	// Token: 0x04000611 RID: 1553
	public Transform engineBlockTarget;

	// Token: 0x04000612 RID: 1554
	public Transform airFilterTarget;

	// Token: 0x04000613 RID: 1555
	public Transform carburettorTarget;

	// Token: 0x04000614 RID: 1556
	public Transform ignitionCoilTarget;

	// Token: 0x04000615 RID: 1557
	public Transform fuelTankTarget;

	// Token: 0x04000616 RID: 1558
	public Transform batteryTarget;

	// Token: 0x04000617 RID: 1559
	public Transform waterTankTarget;

	// Token: 0x04000618 RID: 1560
	public List<Transform> tyreTargets = new List<Transform>();

	// Token: 0x04000619 RID: 1561
	public GameObject[] engineBlocks = new GameObject[0];

	// Token: 0x0400061A RID: 1562
	public GameObject[] airFilters = new GameObject[0];

	// Token: 0x0400061B RID: 1563
	public GameObject[] carburettors = new GameObject[0];

	// Token: 0x0400061C RID: 1564
	public GameObject[] ignitionCoils = new GameObject[0];

	// Token: 0x0400061D RID: 1565
	public GameObject[] fuelTanks = new GameObject[0];

	// Token: 0x0400061E RID: 1566
	public GameObject[] batteries = new GameObject[0];

	// Token: 0x0400061F RID: 1567
	public GameObject[] waterTanks = new GameObject[0];

	// Token: 0x04000620 RID: 1568
	public GameObject[] tyres = new GameObject[0];

	// Token: 0x04000621 RID: 1569
	public GameObject[] bootSpawns = new GameObject[0];

	// Token: 0x04000622 RID: 1570
	public GameObject[] paintAndDecals = new GameObject[0];

	// Token: 0x04000623 RID: 1571
	public List<Transform> bootSpawnTargets = new List<Transform>();

	// Token: 0x04000624 RID: 1572
	public int paintDecalSpawnModifier;

	// Token: 0x04000625 RID: 1573
	public int debugAmountToSpawn;

	// Token: 0x04000626 RID: 1574
	public GameObject licencePlate;

	// Token: 0x04000627 RID: 1575
	public GameObject[] licencePlateTexts = new GameObject[0];

	// Token: 0x04000628 RID: 1576
	public Mesh[] licencePlateMeshChange = new Mesh[0];
}
