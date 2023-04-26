using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

// Token: 0x02000091 RID: 145
public class BorderLogicC : MonoBehaviour
{
	// Token: 0x06000463 RID: 1123 RVA: 0x000496C8 File Offset: 0x00047AC8
	private void Start()
	{
		this.director = GameObject.FindWithTag("Director");
		this._camera = Camera.main.gameObject;
		int num = this.director.GetComponent<RouteGeneratorC>().routeLevel;
		if (this.director.GetComponent<DirectorC>().wakeUpInTown)
		{
			num--;
		}
		if (num == 0)
		{
			if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
			{
				this.bannedNumber = 4;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
			{
				this.bannedNumber = 3;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
			{
				this.bannedNumber = 0;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
			{
				this.bannedNumber = 2;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
			{
				this.bannedNumber = 1;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
			{
				this.bannedNumber = 5;
			}
		}
		if (num == 1)
		{
			if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
			{
				this.bannedNumber = 0;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
			{
				this.bannedNumber = 1;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
			{
				this.bannedNumber = 5;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
			{
				this.bannedNumber = 4;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
			{
				this.bannedNumber = 3;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
			{
				this.bannedNumber = 2;
			}
		}
		if (num == 2)
		{
			if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
			{
				this.bannedNumber = 1;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
			{
				this.bannedNumber = 0;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
			{
				this.bannedNumber = 4;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
			{
				this.bannedNumber = 5;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
			{
				this.bannedNumber = 2;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
			{
				this.bannedNumber = 3;
			}
		}
		if (num == 3)
		{
			if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
			{
				this.bannedNumber = 2;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
			{
				this.bannedNumber = 4;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
			{
				this.bannedNumber = 1;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
			{
				this.bannedNumber = 3;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
			{
				this.bannedNumber = 5;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
			{
				this.bannedNumber = 0;
			}
		}
		if (num == 4)
		{
			if (this.director.GetComponent<RouteGeneratorC>().economyState == 1)
			{
				this.bannedNumber = 5;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 2)
			{
				this.bannedNumber = 2;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 3)
			{
				this.bannedNumber = 3;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 4)
			{
				this.bannedNumber = 0;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 5)
			{
				this.bannedNumber = 4;
			}
			else if (this.director.GetComponent<RouteGeneratorC>().economyState == 6)
			{
				this.bannedNumber = 1;
			}
		}
		this.SpawnSignage();
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x00049B2A File Offset: 0x00047F2A
	public void SpawnSignage()
	{
		this.bannedSigns[this.bannedNumber].transform.localPosition = Vector3.zero;
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x00049B48 File Offset: 0x00047F48
	public void Update()
	{
		this.timeCheck += Time.deltaTime;
		if (this.checkingForRoute && (double)this.timeCheck > 0.2)
		{
			this.timeCheck = 0f;
			if (this.director.GetComponent<RouteGeneratorC>().routeGenerated)
			{
				this.checkingForRoute = false;
				base.StartCoroutine("OpenGate");
			}
		}
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x00049BBC File Offset: 0x00047FBC
	public void ActionRelay()
	{
		if (this.readyToTakePapers && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "PassportStuff")
		{
			this.theObject = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
			this.theObject.transform.parent = null;
			this.windowRelay.GetComponent<Collider>().enabled = false;
			iTween.MoveTo(this.theObject, iTween.Hash(new object[]
			{
				"position",
				this.path[1],
				"time",
				1.0,
				"islocal",
				false,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"ReadThroughPapers",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(this.theObject, iTween.Hash(new object[]
			{
				"rotation",
				this.path[0].eulerAngles + this.theObject.GetComponent<ObjectPickupC>().inventoryAdjustRotation,
				"time",
				0.5,
				"islocal",
				false,
				"easetype",
				"easeinoutexpo"
			}));
			this.theObject.layer = LayerMask.NameToLayer("Default");
			Transform[] componentsInChildren = this.theObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				transform.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
		}
		if (this.readyToTakeWallet && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "Wallet")
		{
			this.walletObj = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
			this.FinePaid();
		}
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x00049DE8 File Offset: 0x000481E8
	public void CloseGate()
	{
		iTween.MoveTo(this.gate, iTween.Hash(new object[]
		{
			"position",
			this.gatePos[0],
			"time",
			5.0,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo"
		}));
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x00049E68 File Offset: 0x00048268
	public void OnTriggerEnter(Collider col)
	{
		if (!this.borderCrossed && (col.gameObject.tag == "CarLogic" || col.gameObject.tag == "CarInteractor" || col.gameObject.tag == "Wheel"))
		{
			if (this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome && this.isReturnBorder)
			{
				this.DrivingBackTrigger();
				return;
			}
			if (this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome && !this.isReturnBorder && this.director.GetComponent<RouteGeneratorC>().routeGenerated)
			{
				base.StartCoroutine("BorderClosed");
				return;
			}
			if (this.director.GetComponent<RouteGeneratorC>().borderOpen && !this.awaitingFinePayment)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
				{
					base.StartCoroutine(this.PapersPlease());
					this.RestrictCarControl();
				}
				else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
				{
					base.StartCoroutine("PapersPlease");
					this.RestrictCarControl();
				}
				else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
				{
					base.StartCoroutine("PapersPlease");
					this.RestrictCarControl();
				}
				else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
				{
					base.StartCoroutine("PapersPlease");
					this.RestrictCarControl();
				}
				else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
				{
					base.StartCoroutine("PapersPlease");
					this.RestrictCarControl();
				}
			}
			else if (this.awaitingFinePayment)
			{
				base.StartCoroutine("RepayFine");
				this.RestrictCarControl();
			}
			else
			{
				base.StartCoroutine("BorderClosed");
			}
		}
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x0004A068 File Offset: 0x00048468
	public void DrivingBackTrigger()
	{
		if (!this.awaitingFinePayment && !this.borderCrossed)
		{
			if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
			{
				base.StartCoroutine("PapersPlease");
				this.RestrictCarControl();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
			{
				base.StartCoroutine("PapersPlease");
				this.RestrictCarControl();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
			{
				base.StartCoroutine("PapersPlease");
				this.RestrictCarControl();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
			{
				base.StartCoroutine("PapersPlease");
				this.RestrictCarControl();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
			{
				base.StartCoroutine("PapersPlease");
				this.RestrictCarControl();
			}
			else if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
			{
				base.StartCoroutine("PapersPlease");
				this.RestrictCarControl();
			}
		}
		else if (this.awaitingFinePayment)
		{
			base.StartCoroutine("RepayFine");
			this.RestrictCarControl();
		}
		else
		{
			base.StartCoroutine("BorderClosed");
		}
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x0004A1C8 File Offset: 0x000485C8
	public void RestrictCarControl()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		gameObject.GetComponent<UncleLogicC>().restrictTalk = true;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.carLogic.GetComponent<CarLogicC>().BorderControlState();
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x0004A20C File Offset: 0x0004860C
	private IEnumerator PapersPlease()
	{
		this.director.GetComponent<DirectorC>().isSatAtBorder = true;
		this.director.GetComponent<RouteGeneratorC>().mapObject.GetComponent<MapLogicC>().changeDirectionText.GetComponent<TextMesh>().text = Language.Get("ui_headback_01", "Inspector_UI");
		this.director.GetComponent<RouteGeneratorC>().mapObject.GetComponent<MapLogicC>().ChangeMap2();
		this._camera.GetComponent<DragRigidbodyC>().maxRayDistance = 100f;
		this.dialogueChecker = "PapersPlease";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_greet_01", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		while (!this.dialogueSpeechComplete)
		{
			yield return new WaitForEndOfFrame();
		}
		iTween.RotateTo(this.window, iTween.Hash(new object[]
		{
			"rotation",
			this.windowRot[1],
			"time",
			1.5,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
		this.readyToTakePapers = true;
		yield break;
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0004A228 File Offset: 0x00048628
	private IEnumerator ReadThroughPapers()
	{
		this.dialogueChecker = "ReadThroughPapers";
		base.StopCoroutine("PapersPlease");
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_10", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			while (!this.dialogueSpeechComplete)
			{
				yield return new WaitForEndOfFrame();
			}
		}
		this.readyToTakePapers = false;
		this._camera.GetComponent<DragRigidbodyC>().maxRayDistance = 4.25f;
		int noSearch = 0;
		int bootSearch = 0;
		int penaltyScore = this.carLogic.GetComponent<CarLogicC>().penaltyFare;
		if (penaltyScore == 0)
		{
			noSearch = 75;
			bootSearch = 95;
			int rnd = UnityEngine.Random.Range(0, 100);
			if (this.director.GetComponent<DirectorC>().guestAnnoyance > 0)
			{
				rnd += this.director.GetComponent<DirectorC>().guestAnnoyance * 5;
				if (rnd > 100)
				{
					rnd = 100;
				}
			}
			Debug.Log("Pen == 0, Random Search Value is : " + rnd);
			if (rnd <= noSearch)
			{
				base.StartCoroutine("NoSearch");
				Debug.Log("No Search @ " + rnd);
			}
			else if (rnd > noSearch && rnd <= bootSearch)
			{
				if (this.director.GetComponent<DirectorC>().guestAnnoyance > 0)
				{
					yield return new WaitForSeconds(0.1f);
					if (this.canSpeak)
					{
						this.speechStack.Clear();
						this.speechStack.Add(Language.Get("ba_gen_journ_37", "Speech"));
						base.StartCoroutine("DialogueSpeech");
						while (!this.dialogueSpeechComplete)
						{
							yield return new WaitForEndOfFrame();
						}
					}
				}
				this.searchState = 1;
				base.StartCoroutine("GuardToBoot");
				Debug.Log("Guard to boot at search state 1");
			}
			else if (rnd > bootSearch)
			{
				this.searchState = 2;
				base.StartCoroutine("GuardToBoot");
				Debug.Log("Guard to boot at search state 2");
			}
		}
		else if (penaltyScore > 0 && penaltyScore <= 30)
		{
			noSearch = -1;
			bootSearch = 100;
			int num = UnityEngine.Random.Range(0, 100);
			Debug.Log("Pen 0 - 30, Random Search Value is : " + num);
			if (num <= noSearch)
			{
				base.StartCoroutine("NoSearch");
			}
			else if (num > noSearch && num <= bootSearch)
			{
				this.searchState = 1;
				base.StartCoroutine("GuardToBoot");
				Debug.Log("Guard to boot at search state 1");
			}
			else if (num > bootSearch)
			{
				this.searchState = 2;
				base.StartCoroutine("GuardToBoot");
				Debug.Log("Guard to boot at search state 2");
			}
		}
		else if (penaltyScore > 30)
		{
			noSearch = 5;
			bootSearch = 50;
			int num2 = UnityEngine.Random.Range(0, 100);
			Debug.Log("Pen above 30, Random Search Value is : " + num2);
			if (num2 <= noSearch)
			{
				base.StartCoroutine("NoSearch");
				Debug.Log("No Search");
			}
			else if (num2 > noSearch && num2 <= bootSearch)
			{
				this.searchState = 1;
				base.StartCoroutine("GuardToBoot");
			}
			else if (num2 > bootSearch)
			{
				this.searchState = 2;
				base.StartCoroutine("GuardToBoot");
			}
		}
		yield break;
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0004A244 File Offset: 0x00048644
	public IEnumerator GuardToBoot()
	{
		yield return new WaitForSeconds(Time.deltaTime);
		this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", false);
		this.searchGuard.GetComponent<AIPath>().destination = this.carLogic.GetComponent<CarLogicC>().bootStandingLoc.position;
		AstarPath.active.Scan(null);
		yield break;
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x0004A25F File Offset: 0x0004865F
	public void GuardArrivedAtBoot()
	{
		this.rotateGuard = true;
		if (this.searchState == 1)
		{
			this.PerformBootSearch();
		}
		else if (this.searchState == 2)
		{
			this.PerformCrateSearch();
		}
		else
		{
			this.NoSearch();
		}
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x0004A2A0 File Offset: 0x000486A0
	public void PerformBootSearch()
	{
		this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", true);
		if (!this.carLogic.GetComponent<CarLogicC>().bootLid.GetComponent<DoorLogicC>().open)
		{
			this.carLogic.GetComponent<CarLogicC>().bootLid.SendMessage("Trigger");
		}
		GameObject bootInventory = this.carLogic.GetComponent<CarLogicC>().bootInventory;
		Transform[] inventorySlots = bootInventory.GetComponent<InventoryLogicC>().inventorySlots;
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			IEnumerator enumerator = inventorySlots[i].transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (transform.GetComponent<ObjectPickupC>())
					{
						if (transform.GetComponent<ObjectPickupC>().isTradeGood)
						{
							if (transform.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
							{
								this.bannedGoodsFound++;
								transform.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
							}
						}
						else if (!transform.GetComponent<ObjectPickupC>().isPurchased)
						{
							this.stolenGoodsFound++;
							transform.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
						}
					}
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
		for (int j = 0; j < bootInventory.GetComponent<InventoryLogicC>().slot3x2x3.Length; j++)
		{
			IEnumerator enumerator2 = bootInventory.GetComponent<InventoryLogicC>().slot3x2x3[j].transform.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					Transform transform2 = (Transform)obj2;
					if (transform2.GetComponent<ObjectPickupC>().objectID == 210)
					{
						Debug.Log("We see basket");
						for (int k = 0; k < transform2.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots.Length; k++)
						{
							Debug.Log("We see basket2");
							IEnumerator enumerator3 = transform2.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots[k].transform.GetEnumerator();
							try
							{
								while (enumerator3.MoveNext())
								{
									object obj3 = enumerator3.Current;
									Transform transform3 = (Transform)obj3;
									Debug.Log("We see basket3");
									if (transform3.GetComponent<ObjectPickupC>())
									{
										Debug.Log("We see basket4");
										if (transform3.GetComponent<ObjectPickupC>().isTradeGood)
										{
											Debug.Log("We see basket5");
											if (transform3.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
											{
												Debug.Log("We see basket6");
												this.bannedGoodsFound++;
												transform3.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
											}
											else if (!transform3.GetComponent<ObjectPickupC>().isPurchased)
											{
												this.stolenGoodsFound++;
												transform3.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
											}
										}
									}
								}
							}
							finally
							{
								IDisposable disposable2;
								if ((disposable2 = (enumerator3 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
					}
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator2 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		if (this.carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled)
		{
			GameObject roofInventory = this.carLogic.GetComponent<CarLogicC>().roofInventory;
			Transform[] inventorySlots2 = roofInventory.GetComponent<InventoryLogicC>().inventorySlots;
			for (int l = 0; l < inventorySlots2.Length; l++)
			{
				IEnumerator enumerator4 = inventorySlots2[l].transform.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object obj4 = enumerator4.Current;
						Transform transform4 = (Transform)obj4;
						if (transform4.GetComponent<ObjectPickupC>().isTradeGood)
						{
							if (transform4.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
							{
								this.bannedGoodsFound++;
								transform4.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
							}
						}
						else if (!transform4.GetComponent<ObjectPickupC>().isPurchased)
						{
							this.stolenGoodsFound++;
							transform4.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
						}
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			for (int m = 0; m < roofInventory.GetComponent<InventoryLogicC>().slot3x2x3.Length; m++)
			{
				IEnumerator enumerator5 = bootInventory.GetComponent<InventoryLogicC>().slot3x2x3[m].transform.GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object obj5 = enumerator5.Current;
						Transform transform5 = (Transform)obj5;
						if (transform5.GetComponent<ObjectPickupC>().objectID == 210)
						{
							Debug.Log("We see basket");
							for (int n = 0; n < transform5.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots.Length; n++)
							{
								Debug.Log("We see basket2");
								IEnumerator enumerator6 = transform5.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots[n].transform.GetEnumerator();
								try
								{
									while (enumerator6.MoveNext())
									{
										object obj6 = enumerator6.Current;
										Transform transform6 = (Transform)obj6;
										Debug.Log("We see basket3");
										if (transform6.GetComponent<ObjectPickupC>())
										{
											Debug.Log("We see basket4");
											if (transform6.GetComponent<ObjectPickupC>().isTradeGood)
											{
												Debug.Log("We see basket5");
												if (transform6.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
												{
													Debug.Log("We see basket6");
													this.bannedGoodsFound++;
													transform6.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
												}
												else if (!transform6.GetComponent<ObjectPickupC>().isPurchased)
												{
													this.stolenGoodsFound++;
													transform6.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
												}
											}
										}
									}
								}
								finally
								{
									IDisposable disposable5;
									if ((disposable5 = (enumerator6 as IDisposable)) != null)
									{
										disposable5.Dispose();
									}
								}
							}
						}
					}
				}
				finally
				{
					IDisposable disposable6;
					if ((disposable6 = (enumerator5 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
		}
		base.StartCoroutine("BannedGoodsSearch");
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x0004A944 File Offset: 0x00048D44
	public void WineAchievementCheck()
	{
		GameObject bootInventory = this.carLogic.GetComponent<CarLogicC>().bootInventory;
		Transform[] inventorySlots = bootInventory.GetComponent<InventoryLogicC>().inventorySlots;
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			IEnumerator enumerator = inventorySlots[i].transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (transform.GetComponent<ObjectPickupC>() && transform.GetComponent<ObjectPickupC>().isTradeGood && transform.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
					{
						this.bannedGoodsFound++;
					}
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
		for (int j = 0; j < bootInventory.GetComponent<InventoryLogicC>().slot3x2x3.Length; j++)
		{
			IEnumerator enumerator2 = bootInventory.GetComponent<InventoryLogicC>().slot3x2x3[j].transform.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					Transform transform2 = (Transform)obj2;
					if (transform2.GetComponent<ObjectPickupC>().objectID == 210)
					{
						for (int k = 0; k < transform2.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots.Length; k++)
						{
							IEnumerator enumerator3 = transform2.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots[k].transform.GetEnumerator();
							try
							{
								while (enumerator3.MoveNext())
								{
									object obj3 = enumerator3.Current;
									Transform transform3 = (Transform)obj3;
									if (transform3.GetComponent<ObjectPickupC>() && transform3.GetComponent<ObjectPickupC>().isTradeGood && transform3.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
									{
										this.bannedGoodsFound++;
									}
								}
							}
							finally
							{
								IDisposable disposable2;
								if ((disposable2 = (enumerator3 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
					}
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator2 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		if (this.carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled)
		{
			GameObject roofInventory = this.carLogic.GetComponent<CarLogicC>().roofInventory;
			Transform[] inventorySlots2 = roofInventory.GetComponent<InventoryLogicC>().inventorySlots;
			for (int l = 0; l < inventorySlots2.Length; l++)
			{
				IEnumerator enumerator4 = inventorySlots2[l].transform.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object obj4 = enumerator4.Current;
						Transform transform4 = (Transform)obj4;
						if (transform4.GetComponent<ObjectPickupC>().isTradeGood && transform4.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
						{
							this.bannedGoodsFound++;
						}
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			for (int m = 0; m < roofInventory.GetComponent<InventoryLogicC>().slot3x2x3.Length; m++)
			{
				IEnumerator enumerator5 = bootInventory.GetComponent<InventoryLogicC>().slot3x2x3[m].transform.GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object obj5 = enumerator5.Current;
						Transform transform5 = (Transform)obj5;
						if (transform5.GetComponent<ObjectPickupC>().objectID == 210)
						{
							for (int n = 0; n < transform5.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots.Length; n++)
							{
								IEnumerator enumerator6 = transform5.GetChild(0).GetComponent<InventoryLogicC>().inventorySlots[n].transform.GetEnumerator();
								try
								{
									while (enumerator6.MoveNext())
									{
										object obj6 = enumerator6.Current;
										Transform transform6 = (Transform)obj6;
										if (transform6.GetComponent<ObjectPickupC>() && transform6.GetComponent<ObjectPickupC>().isTradeGood && transform6.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
										{
											this.bannedGoodsFound++;
										}
									}
								}
								finally
								{
									IDisposable disposable5;
									if ((disposable5 = (enumerator6 as IDisposable)) != null)
									{
										disposable5.Dispose();
									}
								}
							}
						}
					}
				}
				finally
				{
					IDisposable disposable6;
					if ((disposable6 = (enumerator5 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
		}
		if (this.bannedGoodsFound >= 6)
		{
			GameObject gameObject = GameObject.FindWithTag("Steam");
			if (gameObject != null)
			{
				gameObject.SendMessage("SmugglerAchievement");
			}
		}
		this.bannedGoodsFound = 0;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0004AE60 File Offset: 0x00049260
	public void PerformCrateSearch()
	{
		this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", true);
		this.carLogic.GetComponent<CarLogicC>().bootLid.SendMessage("Trigger");
		GameObject bootInventory = this.carLogic.GetComponent<CarLogicC>().bootInventory;
		Transform[] inventorySlots = bootInventory.GetComponent<InventoryLogicC>().inventorySlots;
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			IEnumerator enumerator = inventorySlots[i].transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (transform.GetComponent<ObjectPickupC>().isTradeGood)
					{
						if (transform.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
						{
							this.bannedGoodsFound++;
							transform.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
						}
					}
					else if (!transform.GetComponent<ObjectPickupC>().isPurchased)
					{
						this.stolenGoodsFound++;
						transform.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
					}
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
		if (this.carLogic.GetComponent<ExtraUpgradesC>().roofRackInstalled)
		{
			GameObject roofInventory = this.carLogic.GetComponent<CarLogicC>().roofInventory;
			Transform[] inventorySlots2 = roofInventory.GetComponent<InventoryLogicC>().inventorySlots;
			for (int j = 0; j < inventorySlots2.Length; j++)
			{
				IEnumerator enumerator2 = inventorySlots2[j].transform.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						Transform transform2 = (Transform)obj2;
						if (transform2.GetComponent<ObjectPickupC>().isTradeGood)
						{
							if (transform2.GetComponent<ObjectPickupC>().supplyNumber == this.bannedNumber)
							{
								this.bannedGoodsFound++;
								transform2.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
							}
						}
						else if (!transform2.GetComponent<ObjectPickupC>().isPurchased)
						{
							this.stolenGoodsFound++;
							transform2.GetComponent<ObjectPickupC>().BorderRemoveFromInventory();
						}
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		base.StartCoroutine("BannedGoodsSearch");
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x0004B0B8 File Offset: 0x000494B8
	private IEnumerator BannedGoodsSearch()
	{
		yield return new WaitForSeconds(2f);
		this.carLogic.GetComponent<CarLogicC>().leftDoor.SendMessage("CarShake");
		yield return new WaitForSeconds(2f);
		this.carLogic.GetComponent<CarLogicC>().leftDoor.SendMessage("CarShake");
		yield return new WaitForSeconds(2f);
		this.carLogic.GetComponent<CarLogicC>().leftDoor.SendMessage("CarShake");
		yield return new WaitForSeconds(2f);
		if (this.bannedGoodsFound == 0 && this.stolenGoodsFound == 0)
		{
			base.StartCoroutine("NoSearch");
		}
		else if (this.bannedGoodsFound > 0 && this.stolenGoodsFound == 0)
		{
			base.StartCoroutine("BannedGoodsFound");
		}
		else if (this.bannedGoodsFound == 0 && this.stolenGoodsFound > 0)
		{
			base.StartCoroutine("StolenGoodsFound");
		}
		else if (this.bannedGoodsFound > 0 && this.stolenGoodsFound > 0)
		{
			base.StartCoroutine("StolenAndBannedGoodsFound");
		}
		this.carLogic.GetComponent<CarLogicC>().bootLid.SendMessage("Trigger");
		yield break;
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x0004B0D4 File Offset: 0x000494D4
	private IEnumerator BannedGoodsFound()
	{
		this.dialogueChecker = "BannedGoodsFound";
		base.StartCoroutine("DialogueCheck");
		this.carLogic.GetComponent<CarLogicC>().bootLid.SendMessage("Trigger");
		this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", false);
		this.searchGuard.GetComponent<AIPath>().target = this.guardPostNode;
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			int num = this.bannedGoodsFound * 10;
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_11", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_12", "Speech"));
			this.speechStack.Add(string.Concat(new string[]
			{
				Language.Get("ba_gen_journ_13", "Speech"),
				" ",
				this.bannedGoodsFound.ToString(),
				" ",
				Language.Get("ba_gen_journ_29", "Speech")
			}));
			this.speechStack.Add(Language.Get("ba_gen_journ_14", "Speech") + " [b]" + num.ToString() + "[/b]");
			this.speechStack.Add(Language.Get("ba_gen_journ_15", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.readyToTakeWallet = true;
			this.windowRelay.GetComponent<Collider>().enabled = true;
			this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", true);
		}
		yield break;
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x0004B0F0 File Offset: 0x000494F0
	private IEnumerator StolenGoodsFound()
	{
		this.dialogueChecker = "StolenGoodsFound";
		base.StartCoroutine("DialogueCheck");
		this.carLogic.GetComponent<CarLogicC>().bootLid.SendMessage("Trigger");
		this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", false);
		this.searchGuard.GetComponent<AIPath>().target = this.guardPostNode;
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			int num = this.stolenGoodsFound * 10;
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_11", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_28", "Speech"));
			this.speechStack.Add(string.Concat(new string[]
			{
				Language.Get("ba_gen_journ_13", "Speech"),
				" ",
				this.stolenGoodsFound.ToString(),
				" ",
				Language.Get("ba_gen_journ_30", "Speech")
			}));
			this.speechStack.Add(Language.Get("ba_gen_journ_14", "Speech") + " [b]" + num.ToString() + "[/b]");
			this.speechStack.Add(Language.Get("ba_gen_journ_15", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.readyToTakeWallet = true;
			this.windowRelay.GetComponent<Collider>().enabled = true;
			this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", true);
		}
		yield break;
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x0004B10C File Offset: 0x0004950C
	private IEnumerator StolenAndBannedGoodsFound()
	{
		this.dialogueChecker = "StolenAndBannedGoodsFound";
		base.StartCoroutine("DialogueCheck");
		this.carLogic.GetComponent<CarLogicC>().bootLid.SendMessage("Trigger");
		this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", false);
		this.searchGuard.GetComponent<AIPath>().target = this.guardPostNode;
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_11", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_31", "Speech"));
			int num = this.stolenGoodsFound + this.bannedGoodsFound;
			int num2 = num * 10;
			this.speechStack.Add(string.Concat(new string[]
			{
				Language.Get("ba_gen_journ_13", "Speech"),
				" ",
				num.ToString(),
				" ",
				Language.Get("ba_gen_journ_32", "Speech")
			}));
			this.speechStack.Add(Language.Get("ba_gen_journ_14", "Speech") + " [b]" + num2.ToString() + "[/b]");
			this.speechStack.Add(Language.Get("ba_gen_journ_15", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.readyToTakeWallet = true;
			this.windowRelay.GetComponent<Collider>().enabled = true;
			this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", true);
		}
		yield break;
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0004B128 File Offset: 0x00049528
	private IEnumerator RepayFine()
	{
		this.dialogueChecker = "RepayFine";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_15", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0004B144 File Offset: 0x00049544
	private IEnumerator FineReminder()
	{
		this.dialogueChecker = "FineReminder";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_15", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x0004B15F File Offset: 0x0004955F
	public void FineReminder2()
	{
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x0004B180 File Offset: 0x00049580
	public void FinePaid()
	{
		this.readyToTakeWallet = false;
		this.windowRelay.GetComponent<Collider>().enabled = false;
		base.CancelInvoke("FineReminder");
		base.CancelInvoke("FineReminder2");
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		if (this.bannedGoodsFound > 0 || this.stolenGoodsFound > 0)
		{
			int num = this.bannedGoodsFound + this.stolenGoodsFound;
			num *= 10;
			if ((float)num > this.walletObj.GetComponent<WalletC>().TotalWealth)
			{
				base.StartCoroutine("FinePaidInsufficiantFunds");
				return;
			}
			this.walletObj.GetComponent<WalletC>().TotalWealth -= (float)num;
			this.walletObj.GetComponent<WalletC>().UpdateWealth();
			base.StartCoroutine("NoSearch");
		}
		else if (this.carLogic.GetComponent<CarLogicC>().penaltyFare > 0)
		{
			int num = this.carLogic.GetComponent<CarLogicC>().penaltyFare;
			if ((float)num > this.walletObj.GetComponent<WalletC>().TotalWealth)
			{
				base.StartCoroutine("FinePaidInsufficiantFunds");
				return;
			}
			this.walletObj.GetComponent<WalletC>().TotalWealth -= (float)num;
			this.walletObj.GetComponent<WalletC>().UpdateWealth();
			this.carLogic.GetComponent<CarLogicC>().penaltyFare = 0;
			base.StartCoroutine("NoSearch");
		}
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x0004B318 File Offset: 0x00049718
	private IEnumerator FinePaidInsufficiantFunds()
	{
		this.awaitingFinePayment = true;
		this.dialogueChecker = "FinePaidInsufficiantFunds";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_24", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_25", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_26", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_27", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		Transform objectPos = this.theObject.GetComponent<PassportLogicC>().holdingPosition;
		iTween.MoveTo(this.theObject, iTween.Hash(new object[]
		{
			"position",
			objectPos,
			"time",
			1.0,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo",
			"oncomplete",
			"WaitingForFineToBePaid",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(this.theObject, iTween.Hash(new object[]
		{
			"rotation",
			objectPos.localEulerAngles,
			"time",
			0.5,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo"
		}));
		this.readyToTakeWallet = true;
		this.windowRelay.GetComponent<Collider>().enabled = true;
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		this.carLogic.GetComponent<CarLogicC>().BorderControlStateOff();
		this.director.GetComponent<DirectorC>().isSatAtBorder = false;
		GameObject uncle = GameObject.FindWithTag("Uncle");
		uncle.GetComponent<UncleLogicC>().restrictTalk = false;
		yield break;
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x0004B334 File Offset: 0x00049734
	public void WaitingForFineToBePaid()
	{
		this.theObject.transform.parent = this.theObject.GetComponent<PassportLogicC>().holdingPosition;
		this.theObject.transform.localPosition = Vector3.zero;
		this.theObject.transform.localEulerAngles = Vector3.zero;
		this.theObject.GetComponent<Collider>().enabled = true;
		this.theObject.layer = 8;
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x0004B3A8 File Offset: 0x000497A8
	private IEnumerator DrivingFine()
	{
		this.dialogueChecker = "StolenGoodsFound";
		base.StartCoroutine("DialogueCheck");
		this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", false);
		this.searchGuard.GetComponent<AIPath>().target = this.guardPostNode;
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			int num = this.stolenGoodsFound * 10;
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_33", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_34", "Speech"));
			this.speechStack.Add(string.Concat(new string[]
			{
				Language.Get("ba_gen_journ_35", "Speech"),
				" ",
				this.carLogic.GetComponent<CarLogicC>().penaltyFare.ToString(),
				" ",
				Language.Get("ba_gen_journ_36", "Speech")
			}));
			this.speechStack.Add(Language.Get("ba_gen_journ_15", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			this.readyToTakeWallet = true;
			this.windowRelay.GetComponent<Collider>().enabled = true;
			this.searchGuard.GetComponent<Animator>().SetBool("forceStandStill", true);
		}
		yield break;
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x0004B3C4 File Offset: 0x000497C4
	private IEnumerator NoSearch()
	{
		if (this.carLogic == null)
		{
			this.carLogic = GameObject.FindWithTag("CarLogic");
		}
		if (this.bannedNumber == 0)
		{
			base.StartCoroutine("WineAchievementCheck");
		}
		this.bannedGoodsFound = 0;
		this.stolenGoodsFound = 0;
		if (this.carLogic.GetComponent<CarLogicC>().penaltyFare > 0)
		{
			base.StartCoroutine("DrivingFine");
			yield break;
		}
		this.dialogueChecker = "NoSearch";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_04", "Speech"));
			base.StartCoroutine("DialogueSpeech");
			while (!this.dialogueSpeechComplete)
			{
				yield return new WaitForEndOfFrame();
			}
			Transform objectPos = this.theObject.GetComponent<PassportLogicC>().holdingPosition;
			iTween.MoveTo(this.theObject, iTween.Hash(new object[]
			{
				"position",
				objectPos,
				"time",
				1.0,
				"islocal",
				false,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"OpenGate",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(this.theObject, iTween.Hash(new object[]
			{
				"rotation",
				objectPos.localEulerAngles,
				"time",
				0.5,
				"islocal",
				false,
				"easetype",
				"easeinoutexpo"
			}));
		}
		this.director.GetComponent<DirectorC>().guestAnnoyance = 0;
		yield break;
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x0004B3E0 File Offset: 0x000497E0
	private IEnumerator NeedToSelectRoute()
	{
		this.dialogueChecker = "NeedToSelectRoute";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_19", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_20", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x0004B3FC File Offset: 0x000497FC
	private IEnumerator CSFRBorderClosed()
	{
		this.dialogueChecker = "CSFRBorderClosed";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_21", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_22", "Speech"));
			this.speechStack.Add(Language.Get("ba_gen_journ_23", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x0004B418 File Offset: 0x00049818
	public void OpenGate()
	{
		if (!this.director.GetComponent<RouteGeneratorC>().routeGenerated)
		{
			base.StartCoroutine("NeedToSelectRoute");
			this.checkingForRoute = true;
			return;
		}
		this.director.GetComponent<DirectorC>().isSatAtBorder = false;
		this.theObject.transform.parent = this.theObject.GetComponent<PassportLogicC>().holdingPosition;
		this.theObject.transform.localPosition = Vector3.zero;
		this.theObject.transform.localEulerAngles = Vector3.zero;
		this.theObject.GetComponent<Collider>().enabled = true;
		this.theObject.layer = 8;
		iTween.MoveTo(this.gate, iTween.Hash(new object[]
		{
			"position",
			this.gatePos[1],
			"time",
			5.0,
			"islocal",
			true,
			"easetype",
			"easeinoutexpo"
		}));
		this.borderCrossed = true;
		this.director.GetComponent<RouteGeneratorC>().borderOpen = false;
		this.director.GetComponent<DirectorC>().dayNightCycle.GetComponent<DNC_DayNight>().isMorning = false;
		this.director.GetComponent<DirectorC>().dayNightCycle.GetComponent<DNC_DayNight>().isPaused = false;
		this.carLogic.GetComponent<CarLogicC>().BorderControlStateOff();
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		gameObject.GetComponent<UncleLogicC>().restrictTalk = false;
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x0004B5AC File Offset: 0x000499AC
	private IEnumerator ClearDialogue(float delay)
	{
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<UILabel>().text = string.Empty;
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>()._nameHolder.GetComponent<UILabel>().text = string.Empty;
		yield return new WaitForSeconds(delay);
		this.director.GetComponent<DirectorC>().BubbleOff();
		yield break;
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0004B5D0 File Offset: 0x000499D0
	public void DialogueCheck()
	{
		if (this.dialogueConvoItem != string.Empty && this.dialogueConvoItem != this.dialogueChecker)
		{
			this.canSpeak = false;
			this.AddItemToStartOfQueue();
			return;
		}
		base.StopCoroutine("ClearDialogue");
		base.StartCoroutine("ClearDialogue", 0.0);
		base.StopCoroutine("DialogueSpeech");
		this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StopTypeText();
		this.isTalking = true;
		this.dialogueConvoItem = this.dialogueChecker;
		this.dialogueChecker = string.Empty;
		this.textFinished = false;
		this.canSpeak = true;
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0004B68C File Offset: 0x00049A8C
	private IEnumerator DialogueSpeech()
	{
		base.StopCoroutine("StopInputRestrict");
		this.dialogueSpeechComplete = false;
		this.canSpeak = false;
		this.AnimateSpeaker();
		for (int i = 0; i < this.speechStack.Count; i++)
		{
			this.textFinished = false;
			yield return new WaitForSeconds(0.2f);
			this.director.GetComponent<DirectorC>().BubbleOn(this.shopCharacterMouth.transform, this.characterName);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().word = this.speechStack[i];
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().StartTypeText(base.gameObject);
			int rnd = UnityEngine.Random.Range(0, this.audioMumble.Length);
			this.shopCharacter.GetComponent<AudioSource>().clip = this.audioMumble[rnd];
			this.shopCharacter.GetComponent<AudioSource>().Play();
			while (!this.textFinished)
			{
				yield return new WaitForEndOfFrame();
			}
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnim();
			yield return new WaitWhile(() => !Input.GetButtonDown("Fire1") && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]));
			while (this.inputRestrictDropItem)
			{
				yield return new WaitForEndOfFrame();
			}
			base.StartCoroutine("StopInputRestrict");
			base.StopCoroutine("ClearDialogue");
			base.StartCoroutine("ClearDialogue", 0.0);
			this.director.GetComponent<DirectorC>().dialogueHolder.GetComponent<DialogueStuffsC>().LeftClickAnimStop();
			yield return new WaitForEndOfFrame();
		}
		this.isTalking = false;
		this.dialogueSpeechComplete = true;
		this.dialogueConvoItem = string.Empty;
		yield break;
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0004B6A8 File Offset: 0x00049AA8
	public void AddItemToStartOfQueue()
	{
		for (int i = 0; i < this.textQueue.Count; i++)
		{
			if (this.textQueue[i] == this.dialogueConvoItem)
			{
				return;
			}
		}
		this.textQueue.Insert(0, this.dialogueConvoItem);
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0004B700 File Offset: 0x00049B00
	public void StopInputRestrictStopper()
	{
		base.StopCoroutine("StopInputRestrict");
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0004B710 File Offset: 0x00049B10
	private IEnumerator StopInputRestrict()
	{
		yield return new WaitForSeconds(0.5f);
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
		yield break;
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0004B72B File Offset: 0x00049B2B
	public void TextFinished()
	{
		this.textFinished = true;
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0004B734 File Offset: 0x00049B34
	private IEnumerator BorderClosed()
	{
		this.dialogueChecker = "BorderClosed";
		base.StartCoroutine("DialogueCheck");
		yield return new WaitForSeconds(0.1f);
		if (this.canSpeak)
		{
			this.hasGreeted = true;
			this.speechStack.Clear();
			this.speechStack.Add(Language.Get("ba_gen_journ_08", "Speech"));
			base.StartCoroutine("DialogueSpeech");
		}
		yield break;
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x0004B74F File Offset: 0x00049B4F
	public void AnimateSpeaker()
	{
	}

	// Token: 0x0400066D RID: 1645
	public GameObject carLogic;

	// Token: 0x0400066E RID: 1646
	private GameObject _camera;

	// Token: 0x0400066F RID: 1647
	public bool isReturnBorder;

	// Token: 0x04000670 RID: 1648
	public GameObject director;

	// Token: 0x04000671 RID: 1649
	public GameObject borderAgent;

	// Token: 0x04000672 RID: 1650
	public Vector3 scaleAmount;

	// Token: 0x04000673 RID: 1651
	public Transform[] path = new Transform[0];

	// Token: 0x04000674 RID: 1652
	public bool readyToTakePapers;

	// Token: 0x04000675 RID: 1653
	public bool readyToTakeWallet;

	// Token: 0x04000676 RID: 1654
	private GameObject walletObj;

	// Token: 0x04000677 RID: 1655
	public GameObject gate;

	// Token: 0x04000678 RID: 1656
	public Vector3[] gatePos = new Vector3[0];

	// Token: 0x04000679 RID: 1657
	public bool borderCrossed;

	// Token: 0x0400067A RID: 1658
	public GameObject window;

	// Token: 0x0400067B RID: 1659
	public GameObject windowRelay;

	// Token: 0x0400067C RID: 1660
	public Vector3[] windowRot = new Vector3[0];

	// Token: 0x0400067D RID: 1661
	public GameObject searchGuard;

	// Token: 0x0400067E RID: 1662
	public Transform guardPostNode;

	// Token: 0x0400067F RID: 1663
	public bool rotateGuard;

	// Token: 0x04000680 RID: 1664
	public int searchState;

	// Token: 0x04000681 RID: 1665
	public int bannedNumber;

	// Token: 0x04000682 RID: 1666
	public int bannedGoodsFound;

	// Token: 0x04000683 RID: 1667
	public int stolenGoodsFound;

	// Token: 0x04000684 RID: 1668
	public GameObject[] bannedSigns = new GameObject[0];

	// Token: 0x04000685 RID: 1669
	private GameObject theObject;

	// Token: 0x04000686 RID: 1670
	private bool checkingForRoute;

	// Token: 0x04000687 RID: 1671
	private float timeCheck;

	// Token: 0x04000688 RID: 1672
	public bool isTalking;

	// Token: 0x04000689 RID: 1673
	public bool textFinished;

	// Token: 0x0400068A RID: 1674
	public List<string> textQueue = new List<string>();

	// Token: 0x0400068B RID: 1675
	public string currentConvoItem;

	// Token: 0x0400068C RID: 1676
	public string interruptConvoItem;

	// Token: 0x0400068D RID: 1677
	public string dialogueConvoItem;

	// Token: 0x0400068E RID: 1678
	public List<string> speechStack = new List<string>();

	// Token: 0x0400068F RID: 1679
	public bool inputRestrictDropItem;

	// Token: 0x04000690 RID: 1680
	public string interruptChecker = string.Empty;

	// Token: 0x04000691 RID: 1681
	public string dialogueChecker = string.Empty;

	// Token: 0x04000692 RID: 1682
	public bool canSpeak;

	// Token: 0x04000693 RID: 1683
	public bool interruptSpeechComplete;

	// Token: 0x04000694 RID: 1684
	public bool dialogueSpeechComplete;

	// Token: 0x04000695 RID: 1685
	public bool isWelcomed;

	// Token: 0x04000696 RID: 1686
	public bool hasGreeted;

	// Token: 0x04000697 RID: 1687
	public GameObject shopCharacter;

	// Token: 0x04000698 RID: 1688
	public GameObject shopCharacterMouth;

	// Token: 0x04000699 RID: 1689
	public AudioClip[] audioMumble = new AudioClip[0];

	// Token: 0x0400069A RID: 1690
	public bool awaitingFinePayment;

	// Token: 0x0400069B RID: 1691
	public string characterName = "ui_name_05";
}
