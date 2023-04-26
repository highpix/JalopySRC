using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000E7 RID: 231
public class PortableFuelC : MonoBehaviour
{
	// Token: 0x060008ED RID: 2285 RVA: 0x000BFB20 File Offset: 0x000BDF20
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.FuelUpdate();
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x000BFB48 File Offset: 0x000BDF48
	private void Update()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == base.gameObject && this.target != null && this.target.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount >= this.target.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount && this.isPouring)
		{
			base.StartCoroutine("StopPouring");
		}
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x000BFBD6 File Offset: 0x000BDFD6
	public void FuelToEmpty()
	{
		this.fuelLevel = 0;
		this.FuelUpdate();
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x000BFBE8 File Offset: 0x000BDFE8
	public void Action()
	{
		if (this.isInAction)
		{
			return;
		}
		this.isInAction = true;
		this.actionIsPlaying = true;
		this.target = base.gameObject.GetComponent<ObjectInteractionsC>().target;
		if (this.target.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount >= this.target.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount)
		{
			this.UnAction();
			this.ActionPart2();
			return;
		}
		this.isPouring = true;
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		if (this.animationTarget != null)
		{
			this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", true);
		}
		base.transform.parent = this.target.transform;
		this.fuelLid = this.target;
		iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
		{
			"x",
			0.1,
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutexpo"
		}));
		this.SetLayerRecursively(base.gameObject, 0);
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"ActionPart2",
			"oncompletetarget",
			base.gameObject
		}));
		if (this.fuelLevel > 0 && this.target.transform.parent.GetComponent<EngineComponentC>().currentFuelAmount < this.target.transform.parent.GetComponent<EngineComponentC>().totalFuelAmount)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.pourAudio, 1f);
			this.fuelParticles.layer = 0;
			this.fuelParticles.GetComponent<ParticleSystem>().Play();
			if (this.fuelMix == 0)
			{
				this.target.SendMessage("PortableFuelActionNoOil");
			}
			else if (this.fuelMix == 1)
			{
				this.target.SendMessage("PortableFuelActionLeanOil");
			}
			else if (this.fuelMix == 2)
			{
				this.target.SendMessage("PortableFuelActionOptimalOil");
			}
			else if (this.fuelMix == 3)
			{
				this.target.SendMessage("PortableFuelActionRichOil");
			}
			this.fuelLevel--;
			if (this.addedToShopTracking)
			{
				List<int> portableFuelRefilledNumbers;
				int index;
				(portableFuelRefilledNumbers = this.shop.GetComponent<ShopC>().portableFuelRefilledNumbers)[index = this.shopTrackingReff] = portableFuelRefilledNumbers[index] - 1;
			}
			this.FuelUpdate();
		}
		else
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.pourEmptyAudio, 1f);
		}
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x000BFFB8 File Offset: 0x000BE3B8
	public IEnumerator ContinuedPourAction()
	{
		this.actionIsPlaying = true;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
		{
			this.UnAction();
			yield break;
		}
		if (this.animationTarget != null)
		{
			this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", true);
		}
		GameObject target = base.gameObject.GetComponent<ObjectInteractionsC>().target;
		base.transform.parent = target.transform;
		this.SetLayerRecursively(base.gameObject, 0);
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank)
		{
			if (this.fuelLevel > 0 && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
			{
				this.fuelParticles.layer = 0;
				base.GetComponent<AudioSource>().PlayOneShot(this.pourAudio, 1f);
				this.fuelParticles.GetComponent<ParticleSystem>().Play();
				if (this.fuelMix == 0)
				{
					target.SendMessage("PortableFuelActionNoOil");
				}
				else if (this.fuelMix == 1)
				{
					target.SendMessage("PortableFuelActionLeanOil");
				}
				else if (this.fuelMix == 2)
				{
					target.SendMessage("PortableFuelActionOptimalOil");
				}
				else if (this.fuelMix == 3)
				{
					target.SendMessage("PortableFuelActionRichOil");
				}
				this.fuelLevel--;
				if (this.addedToShopTracking && this.shop)
				{
					List<int> portableFuelRefilledNumbers;
					int index;
					(portableFuelRefilledNumbers = this.shop.GetComponent<ShopC>().portableFuelRefilledNumbers)[index = this.shopTrackingReff] = portableFuelRefilledNumbers[index] - 1;
				}
				this.FuelUpdate();
			}
			else
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.pourEmptyAudio, 1f);
			}
			yield return new WaitForSeconds(this.timeToComplete);
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
			{
				this.actionIsPlaying = false;
				this.ActionPart2();
				yield break;
			}
		}
		yield break;
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x000BFFD4 File Offset: 0x000BE3D4
	public void SetLayerRecursively(GameObject obj, int newLayer)
	{
		base.gameObject.layer = newLayer;
		IEnumerator enumerator = obj.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				Transform transform = (Transform)obj2;
				this.SetLayerRecursively(transform.gameObject, newLayer);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000C004C File Offset: 0x000BE44C
	public void ThrowLogic()
	{
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x000C004E File Offset: 0x000BE44E
	public void MoveToSlot2()
	{
		base.StartCoroutine("StopPouringHands2");
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x000C005C File Offset: 0x000BE45C
	public void MoveToSlot3()
	{
		base.StartCoroutine("StopPouringHands3");
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x000C006C File Offset: 0x000BE46C
	public void ActionPart2()
	{
		this.actionIsPlaying = false;
		this.isInAction = false;
		if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank)
		{
			if (Input.GetButton("Fire1") && this.fuelLevel > 0 && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
			{
				base.StartCoroutine("ContinuedPourAction");
				return;
			}
			if (Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) && this.fuelLevel > 0 && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
			{
				base.StartCoroutine("ContinuedPourAction");
				return;
			}
			if (Input.GetKey(MainMenuC.Global.assignedInputStrings[17]) && this.fuelLevel > 0 && this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
			{
				base.StartCoroutine("ContinuedPourAction");
				return;
			}
		}
		if (this.isTutorial && this.fuelLevel > 0)
		{
			GameObject gameObject = GameObject.FindWithTag("Uncle");
			gameObject.GetComponent<Scene1_LogicC>().StartCoroutine("TryHoldingDownFuel");
		}
		else if (this.isTutorial && this.fuelLevel == 0)
		{
			GameObject gameObject2 = GameObject.FindWithTag("Uncle");
			gameObject2.GetComponent<Scene1_LogicC>().StartCoroutine("DropHolding");
			this.isTutorial = false;
		}
		this.isPouring = false;
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1.transform;
		if (this.fuelLid != null)
		{
			iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
			{
				"x",
				0,
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeinexpo"
			}));
		}
		this.SetLayerRecursively(base.gameObject, 11);
		if (this.animationTarget != null)
		{
			this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", false);
		}
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x000C03F8 File Offset: 0x000BE7F8
	public IEnumerator StopPouring()
	{
		this.actionIsPlaying = false;
		this.isPouring = false;
		yield return new WaitForSeconds(this.timeToComplete);
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1.transform;
		this.SetLayerRecursively(base.gameObject, 11);
		if (this.animationTarget != null)
		{
			this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", false);
		}
		if (this.fuelLid != null)
		{
			iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
			{
				"x",
				0.0,
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeoutexpo"
			}));
		}
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
		if (this.isTutorial && this.fuelLevel > 0)
		{
			GameObject gameObject = GameObject.FindWithTag("Uncle");
			gameObject.SendMessage("TryHoldingDownFuel");
			this.isTutorial = false;
		}
		else if (this.isTutorial && this.fuelLevel == 0)
		{
			GameObject gameObject2 = GameObject.FindWithTag("Uncle");
			gameObject2.GetComponent<Scene1_LogicC>().StartCoroutine("DropHolding");
			this.isTutorial = false;
		}
		yield break;
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x000C0414 File Offset: 0x000BE814
	public IEnumerator StopPouringHands2()
	{
		this.actionIsPlaying = false;
		this.isPouring = false;
		yield return new WaitForSeconds(this.timeToComplete);
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent2.transform;
		this.SetLayerRecursively(base.gameObject, 11);
		if (this.animationTarget != null)
		{
			this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", false);
		}
		if (this.fuelLid != null)
		{
			iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
			{
				"x",
				0.0,
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeoutexpo"
			}));
		}
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
		if (this.isTutorial && this.fuelLevel > 0)
		{
			GameObject gameObject = GameObject.FindWithTag("Uncle");
			gameObject.SendMessage("TryHoldingDownFuel");
			this.isTutorial = false;
		}
		else if (this.isTutorial && this.fuelLevel == 0)
		{
			GameObject gameObject2 = GameObject.FindWithTag("Uncle");
			gameObject2.GetComponent<Scene1_LogicC>().StartCoroutine("DropHolding");
			this.isTutorial = false;
		}
		yield break;
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x000C0430 File Offset: 0x000BE830
	public IEnumerator StopPouringHands3()
	{
		this.actionIsPlaying = false;
		this.isPouring = false;
		yield return new WaitForSeconds(this.timeToComplete);
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent3.transform;
		this.SetLayerRecursively(base.gameObject, 11);
		if (this.animationTarget != null)
		{
			this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", false);
		}
		if (this.fuelLid != null)
		{
			iTween.MoveTo(this.fuelLid, iTween.Hash(new object[]
			{
				"x",
				0.0,
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeoutexpo"
			}));
		}
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType2
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
		if (this.isTutorial && this.fuelLevel > 0)
		{
			GameObject gameObject = GameObject.FindWithTag("Uncle");
			gameObject.SendMessage("TryHoldingDownFuel");
			this.isTutorial = false;
		}
		else if (this.isTutorial && this.fuelLevel == 0)
		{
			GameObject gameObject2 = GameObject.FindWithTag("Uncle");
			gameObject2.GetComponent<Scene1_LogicC>().StartCoroutine("DropHolding");
			this.isTutorial = false;
		}
		yield break;
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x000C044C File Offset: 0x000BE84C
	public void UnAction()
	{
		this.actionIsPlaying = false;
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1,
			"oncomplete",
			"UnActionPart2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x000C0524 File Offset: 0x000BE924
	public void UnActionPart2()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
		this.isInAction = false;
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x000C05B0 File Offset: 0x000BE9B0
	public void FuelUpdate()
	{
		if (this.fuelLevel == 9)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = true;
			base.GetComponent<ObjectPickupC>().sellValue = 10f;
		}
		if (this.fuelLevel == 8)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 9f;
		}
		if (this.fuelLevel == 7)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 8f;
		}
		if (this.fuelLevel == 6)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 7f;
		}
		if (this.fuelLevel == 5)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 6f;
		}
		if (this.fuelLevel == 4)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 5f;
		}
		if (this.fuelLevel == 3)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 4f;
		}
		if (this.fuelLevel == 2)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 3f;
		}
		if (this.fuelLevel == 1)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = true;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 2f;
		}
		if (this.fuelLevel == 0)
		{
			this.fuelObject[0].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[1].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[2].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[3].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[4].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[5].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[6].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[7].GetComponent<MeshRenderer>().enabled = false;
			this.fuelObject[8].GetComponent<MeshRenderer>().enabled = false;
			base.GetComponent<ObjectPickupC>().sellValue = 1f;
		}
		if (this._camera == null)
		{
			this._camera = Camera.main.gameObject;
		}
		this._camera.GetComponent<DragRigidbodyC>().SetEngineCompUI1();
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x000C0DB4 File Offset: 0x000BF1B4
	public void Object2ObjectInteraction()
	{
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", true);
		GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
		isHolding.GetComponent<RefuelLogicC>().fuelTarget = base.gameObject;
		isHolding.SendMessage("Action");
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x000C0E18 File Offset: 0x000BF218
	public void FillWithFuel()
	{
		int num = UnityEngine.Random.Range(0, this.fillAudio.Length);
		base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[num], 1f);
		this.FuelUpdate();
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000C0E54 File Offset: 0x000BF254
	public void PlacedAnimate()
	{
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"x",
			5,
			"islocal",
			true,
			"time",
			0.7,
			"easetype",
			"easeoutquad",
			"looptype",
			"pingpong"
		}));
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x000C0ED4 File Offset: 0x000BF2D4
	public void StopPlacedAnimate()
	{
		iTween.Stop(base.gameObject);
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x000C0EE4 File Offset: 0x000BF2E4
	public void OilAction()
	{
		this.fuelMix++;
		if (this.fuelMix > 3)
		{
			this.fuelMix = 3;
		}
		if (this.fuelMix == 1)
		{
			this.fuelObject[0].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[1].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[2].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[3].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[4].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[5].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[6].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[7].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[8].GetComponent<Renderer>().material = this.fuelMats[1];
		}
		else if (this.fuelMix == 2)
		{
			this.fuelObject[0].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[1].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[2].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[3].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[4].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[5].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[6].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[7].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[8].GetComponent<Renderer>().material = this.fuelMats[2];
		}
		else if (this.fuelMix == 3)
		{
			this.fuelObject[0].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[1].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[2].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[3].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[4].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[5].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[6].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[7].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[8].GetComponent<Renderer>().material = this.fuelMats[3];
		}
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x000C1200 File Offset: 0x000BF600
	public void FuelOilDown()
	{
		this.fuelMix--;
		if (this.fuelMix <= 0)
		{
			this.fuelMix = 0;
			this.fuelObject[0].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[1].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[2].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[3].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[4].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[5].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[6].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[7].GetComponent<Renderer>().material = this.fuelMats[0];
			this.fuelObject[8].GetComponent<Renderer>().material = this.fuelMats[0];
		}
		else if (this.fuelMix == 1)
		{
			this.fuelObject[0].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[1].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[2].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[3].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[4].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[5].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[6].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[7].GetComponent<Renderer>().material = this.fuelMats[1];
			this.fuelObject[8].GetComponent<Renderer>().material = this.fuelMats[1];
		}
		else if (this.fuelMix == 2)
		{
			this.fuelObject[0].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[1].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[2].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[3].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[4].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[5].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[6].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[7].GetComponent<Renderer>().material = this.fuelMats[2];
			this.fuelObject[8].GetComponent<Renderer>().material = this.fuelMats[2];
		}
		else if (this.fuelMix == 3)
		{
			this.fuelObject[0].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[1].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[2].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[3].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[4].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[5].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[6].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[7].GetComponent<Renderer>().material = this.fuelMats[3];
			this.fuelObject[8].GetComponent<Renderer>().material = this.fuelMats[3];
		}
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x000C1609 File Offset: 0x000BFA09
	public void LidClose()
	{
		this.animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", false);
	}

	// Token: 0x04000BEA RID: 3050
	private GameObject _camera;

	// Token: 0x04000BEB RID: 3051
	private GameObject carLogic;

	// Token: 0x04000BEC RID: 3052
	public GameObject fuelLid;

	// Token: 0x04000BED RID: 3053
	public int fuelLevel;

	// Token: 0x04000BEE RID: 3054
	public int fuelMix;

	// Token: 0x04000BEF RID: 3055
	public int fuelTillOilDown = 3;

	// Token: 0x04000BF0 RID: 3056
	private bool isPouring;

	// Token: 0x04000BF1 RID: 3057
	private bool actionIsPlaying;

	// Token: 0x04000BF2 RID: 3058
	public GameObject[] fuelObject = new GameObject[0];

	// Token: 0x04000BF3 RID: 3059
	public Material[] fuelMats = new Material[0];

	// Token: 0x04000BF4 RID: 3060
	public Vector3[] rotation = new Vector3[0];

	// Token: 0x04000BF5 RID: 3061
	public Vector3[] position = new Vector3[0];

	// Token: 0x04000BF6 RID: 3062
	public float timeToComplete;

	// Token: 0x04000BF7 RID: 3063
	public string easeType1 = string.Empty;

	// Token: 0x04000BF8 RID: 3064
	public string easeType2 = string.Empty;

	// Token: 0x04000BF9 RID: 3065
	public GameObject fuelParticles;

	// Token: 0x04000BFA RID: 3066
	public AudioClip[] fillAudio = new AudioClip[0];

	// Token: 0x04000BFB RID: 3067
	public AudioClip pourAudio;

	// Token: 0x04000BFC RID: 3068
	public AudioClip pourEmptyAudio;

	// Token: 0x04000BFD RID: 3069
	public GameObject animationTarget;

	// Token: 0x04000BFE RID: 3070
	public Transform fuelHandlePosition;

	// Token: 0x04000BFF RID: 3071
	public Transform oilBottlePosition;

	// Token: 0x04000C00 RID: 3072
	public bool isTutorial;

	// Token: 0x04000C01 RID: 3073
	private GameObject target;

	// Token: 0x04000C02 RID: 3074
	private bool isInAction;

	// Token: 0x04000C03 RID: 3075
	public GameObject shop;

	// Token: 0x04000C04 RID: 3076
	public bool addedToShopTracking;

	// Token: 0x04000C05 RID: 3077
	public int shopTrackingReff;
}
