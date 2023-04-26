using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A4 RID: 164
public class DragRigidbodyC : MonoBehaviour
{
	// Token: 0x0600055E RID: 1374 RVA: 0x0005AEE4 File Offset: 0x000592E4
	private void Start()
	{
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			Application.targetFrameRate = 30;
		}
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x0005AF0C File Offset: 0x0005930C
	private void Awake()
	{
		if (DragRigidbodyC.Global == null)
		{
			DragRigidbodyC.Global = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		Screen.lockCursor = true;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		this.componentUI.SetActive(false);
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x0005AF61 File Offset: 0x00059361
	private void OnDestroy()
	{
		DragRigidbodyC.Global = null;
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0005AF6C File Offset: 0x0005936C
	public void ComponentUIOff()
	{
		this.uiIsOn = false;
		this.componentUI.transform.localPosition = new Vector3(this.componentUI.transform.localPosition.x, this.componentUIPos[1].y, this.componentUI.transform.localPosition.z);
		this.componentUI.SetActive(false);
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0005AFE4 File Offset: 0x000593E4
	public void ComponentUIOn()
	{
		this.componentUI.transform.localPosition = new Vector3(this.componentUI.transform.localPosition.x, this.componentUIPos[0].y, this.componentUI.transform.localPosition.z);
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x0005B048 File Offset: 0x00059448
	public void ComponentUIOffToOn()
	{
		iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
		{
			"y",
			this.componentUIPos[0].y,
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutback",
			"oncomplete",
			"ComponentUIOn",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0005B0EC File Offset: 0x000594EC
	public void UIOff()
	{
		this.cursors[0].gameObject.SetActive(false);
		this.cursors[1].gameObject.SetActive(false);
		this.cursors[2].gameObject.SetActive(false);
		this.cursors[4].gameObject.SetActive(false);
		this.cursors[5].gameObject.SetActive(false);
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x0005B158 File Offset: 0x00059558
	private void Update()
	{
		this.debugLookingAt = string.Empty;
		if (this.inputRestrict && !this.inputRestrictDropOnly)
		{
			if (this.lastHitCarInteractor != null)
			{
				this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
				this.lastHitCarInteractor = null;
			}
			if (this.cursors[0].gameObject.active || this.cursors[1].gameObject.active || this.cursors[2].gameObject.active || this.cursors[4].gameObject.active)
			{
				this.cursors[0].gameObject.SetActive(false);
				this.cursors[1].gameObject.SetActive(false);
				this.cursors[2].gameObject.SetActive(false);
				this.cursors[4].gameObject.SetActive(false);
				this.cursors[3].gameObject.SetActive(true);
				this.cursors[5].gameObject.SetActive(false);
			}
			if (this.uiIsOn)
			{
				this.uiIsOn = false;
				iTween.Stop(this.componentUI);
				iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
				{
					"y",
					this.componentUIPos[1].y,
					"time",
					0.15,
					"islocal",
					true,
					"easetype",
					"easeinback",
					"oncomplete",
					"ComponentUIOff",
					"oncompletetarget",
					base.gameObject
				}));
			}
			return;
		}
		if ((double)this.tyreIronBoltSpamStopper > 0.0)
		{
			this.tyreIronBoltSpamStopper -= Time.deltaTime;
		}
		if (this._camera.GetComponent<MouseLook>().noClip)
		{
			if (this.cursors[0].gameObject.active || this.cursors[1].gameObject.active || this.cursors[2].gameObject.active || this.cursors[4].gameObject.active)
			{
				this.cursors[0].gameObject.SetActive(false);
				this.cursors[1].gameObject.SetActive(false);
				this.cursors[2].gameObject.SetActive(false);
				this.cursors[4].gameObject.SetActive(false);
				this.cursors[5].gameObject.SetActive(false);
			}
			return;
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if ((double)this.joypadItemSwitchDelay > 0.0)
		{
			this.joypadItemSwitchDelay -= Time.deltaTime;
		}
		if (!this.inputRestrictDropOnly)
		{
			if (axis > 0f)
			{
				this.MoveItemsRight();
			}
			if ((double)Input.GetAxis("JoypadDpadX") == 1.0 && (double)this.joypadItemSwitchDelay <= 0.1)
			{
				this.MoveItemsRight();
				this.joypadItemSwitchDelay = 0.3f;
			}
			if (axis < 0f)
			{
				this.MoveItemsLeft();
			}
			if ((double)Input.GetAxis("JoypadDpadX") == -1.0 && (double)this.joypadItemSwitchDelay <= 0.1)
			{
				this.MoveItemsRight();
				this.joypadItemSwitchDelay = 0.3f;
			}
			if (this.isHolding1 != null && this.isHolding2 != null && (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[24]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[25])))
			{
				this.Swap2With1();
			}
			if (this.isHolding1 != null && this.isHolding3 != null && (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[22]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[23])))
			{
				this.Swap3With1();
			}
			if (this.one_click)
			{
				if (Time.time - this.timer_for_double_click <= this.delay)
				{
					return;
				}
				this.one_click = false;
			}
			if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]))
			{
				if (this.one_click)
				{
					return;
				}
				this.one_click = true;
				this.timer_for_double_click = Time.time;
			}
			if ((MainMenuC.Global.padInput == 1 || MainMenuC.Global.padInput == 3) && Input.GetButtonDown("Fire1"))
			{
				if (this.one_click)
				{
					return;
				}
				this.one_click = true;
				this.timer_for_double_click = Time.time;
			}
			if (this.isDriving)
			{
				this.cursors[0].gameObject.SetActive(false);
				this.cursors[1].gameObject.SetActive(false);
				this.cursors[4].gameObject.SetActive(false);
				this.cursors[2].gameObject.SetActive(true);
				this.cursors[5].gameObject.SetActive(false);
				return;
			}
		}
		if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[18]) && this.isHolding1 != null && !this.inputRestrictDropPress)
		{
			this.ThrowHolding();
		}
		else if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[19]) && this.isHolding1 != null && !this.inputRestrictDropPress)
		{
			this.ThrowHolding();
		}
		else if (Input.GetButtonDown("Drop") && this.isHolding1 != null && !this.inputRestrictDropPress)
		{
			this.ThrowHolding();
		}
		if (this.inputRestrictDropOnly)
		{
			if (this.lastHitCarInteractor != null)
			{
				this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
			}
			if (this.cursors[0].gameObject.active || this.cursors[1].gameObject.active || this.cursors[2].gameObject.active || this.cursors[4].gameObject.active)
			{
				this.cursors[0].gameObject.SetActive(false);
				this.cursors[1].gameObject.SetActive(false);
				this.cursors[2].gameObject.SetActive(false);
				this.cursors[4].gameObject.SetActive(false);
				this.cursors[3].gameObject.SetActive(true);
				this.cursors[5].gameObject.SetActive(false);
			}
			if (this.uiIsOn)
			{
				this.uiIsOn = false;
				iTween.Stop(this.componentUI);
				iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
				{
					"y",
					this.componentUIPos[1].y,
					"time",
					0.15,
					"islocal",
					true,
					"easetype",
					"easeinback",
					"oncomplete",
					"ComponentUIOff",
					"oncompletetarget",
					base.gameObject
				}));
			}
			return;
		}
		if (this.onlyInteractWithPickUpLayer)
		{
			this.myLayerMask = 2048;
		}
		else
		{
			this.myLayerMask = this.prevLayers;
		}
		Ray ray = this._camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			ray = this._camera.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		}
		Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);
		RaycastHit raycastHit;
		if (!Physics.Raycast(ray, out raycastHit, this.maxRayDistance, this.myLayerMask, QueryTriggerInteraction.Collide))
		{
			this.cursors[5].gameObject.SetActive(false);
			if (this.isHolding1 != null && this.isHolding1.name == "PaintCan")
			{
				this.isHolding1.GetComponent<PaintCanC>().target = null;
			}
			if (this.cursors[1].gameObject.active && !this.useAnimPlay)
			{
				this.cursors[0].gameObject.SetActive(false);
				this.cursors[1].gameObject.SetActive(false);
				this.cursors[2].gameObject.SetActive(true);
				this.cursors[4].gameObject.SetActive(false);
				this.cursors[5].gameObject.SetActive(false);
			}
			if (this.uiIsOn)
			{
				this.uiIsOn = false;
				iTween.Stop(this.componentUI);
				iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
				{
					"y",
					this.componentUIPos[1].y,
					"time",
					0.15,
					"islocal",
					true,
					"easetype",
					"easeinback",
					"oncomplete",
					"ComponentUIOff",
					"oncompletetarget",
					base.gameObject
				}));
			}
			this.hitEngineComponent = null;
			this.lastHitEngineComponent = null;
			if (!this.cursors[2].gameObject.active && !this.useAnimPlay)
			{
				this.cursors[0].gameObject.SetActive(false);
				this.cursors[1].gameObject.SetActive(false);
				this.cursors[2].gameObject.SetActive(true);
				this.cursors[4].gameObject.SetActive(false);
				this.cursors[5].gameObject.SetActive(false);
			}
			if (MainMenuC.Global.padInput == 1 && Input.GetButtonDown("Fire1"))
			{
				this.isHolding1.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
			}
			else if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && this.isHolding1 != null)
			{
				this.isHolding1.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
			}
			else if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) && this.isHolding1 != null)
			{
				this.isHolding1.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
			}
			if (this.lastHitCarInteractor != null)
			{
				if (this.lastHitCarInteractor.GetComponent<ObjectInteractionsC>() != null && this.isHolding1 != null)
				{
					if (this.lastHitCarInteractor.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.transform.name)
					{
						this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
						this.lastHitCarInteractor = null;
					}
				}
				else if (this.isHolding1 == null)
				{
					this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
					this.lastHitCarInteractor = null;
				}
			}
			return;
		}
		this.debugLookingAt = raycastHit.transform.gameObject.name;
		if (raycastHit.collider.tag != "CarInteractor" && raycastHit.collider.tag != "Interactor" && raycastHit.collider.tag != "Pickup" && raycastHit.collider.tag != "Dropoff" && raycastHit.collider.tag != "CarJack" && raycastHit.collider.tag != "TyreIronBolt")
		{
			if (this.uiIsOn)
			{
				this.uiIsOn = false;
				iTween.Stop(this.componentUI);
				iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
				{
					"y",
					this.componentUIPos[1].y,
					"time",
					0.15,
					"islocal",
					true,
					"easetype",
					"easeinback",
					"oncomplete",
					"ComponentUIOff",
					"oncompletetarget",
					base.gameObject
				}));
			}
			this.hitEngineComponent = null;
			this.lastHitEngineComponent = null;
			this.cursors[0].gameObject.SetActive(false);
			this.cursors[1].gameObject.SetActive(false);
			this.cursors[4].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(true);
			this.cursors[5].gameObject.SetActive(false);
			if (this.lastHitCarInteractor != null)
			{
				this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
			}
			this.lastHitCarInteractor = null;
		}
		if (raycastHit.collider.tag == "Pickup" && raycastHit.collider.GetComponent<ObjectPickupC>() && !raycastHit.collider.GetComponent<EngineComponentC>() && raycastHit.collider.GetComponent<ObjectPickupC>().componentHeader != string.Empty)
		{
			this.hitComponent = raycastHit.collider.gameObject;
			this.componentUI.SetActive(true);
			if (!this.uiIsOn)
			{
				this.uiIsOn = true;
				iTween.Stop(this.componentUI);
				iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
				{
					"y",
					this.componentUIPos[0].y,
					"time",
					0.3,
					"islocal",
					true,
					"easetype",
					"easeoutback",
					"oncomplete",
					"ComponentUIOn",
					"oncompletetarget",
					base.gameObject
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.paperSFX, 0.8f);
			}
			ObjectPickupC component = raycastHit.collider.GetComponent<ObjectPickupC>();
			this.componentHeader.GetComponent<UILabel>().text = Language.Get(component.componentHeader, "Inspector_UI");
			this.componentHeader.GetComponent<UILabel>().color = this.gray;
			this.componentTitles[7].GetComponent<UILabel>().text = Language.Get(component.flavourText, "Inspector_UI");
			this.componentTitles[7].GetComponent<UILabel>().color = this.gray;
			this.componentTitles[0].GetComponent<UILabel>().text = string.Empty;
			this.componentTitles[1].GetComponent<UILabel>().text = string.Empty;
			this.componentTitles[2].GetComponent<UILabel>().text = string.Empty;
			this.componentTitles[3].GetComponent<UILabel>().text = string.Empty;
			this.componentTitles[4].GetComponent<UILabel>().text = string.Empty;
			if (component.isPurchased)
			{
				this.componentTitles[5].GetComponent<UILabel>().text = string.Concat(new string[]
				{
					Language.Get("ui_pickup_14", "Inspector_UI"),
					" : ",
					component.sellValue.ToString(),
					"\n(",
					Language.Get("ui_pickup_15", "Inspector_UI"),
					" :  : ",
					component.buyValue.ToString(),
					")"
				});
			}
			else
			{
				this.componentTitles[5].GetComponent<UILabel>().text = Language.Get("ui_pickup_15", "Inspector_UI") + " : " + component.buyValue.ToString();
			}
			this.componentTitles[6].GetComponent<UILabel>().text = string.Empty;
			this.componentTitles[8].GetComponent<UILabel>().text = string.Empty;
		}
		if (raycastHit.collider.tag == "CarLogic" && this.isHolding1 == null && !base.transform.parent.GetComponent<RigidbodyControllerC>().isSat && MainMenuC.Global.debugUncle.GetComponent<Scene1_LogicC>().hasGivenTutorial)
		{
			this.cursors[0].gameObject.SetActive(true);
			this.cursors[1].gameObject.SetActive(false);
			this.cursors[4].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(false);
			this.cursors[5].gameObject.SetActive(false);
		}
		else if (raycastHit.collider.tag == "CarPaintMesh" && raycastHit.collider.name == "Roof" && this.isHolding1 == null && !base.transform.parent.GetComponent<RigidbodyControllerC>().isSat && MainMenuC.Global.debugUncle.GetComponent<Scene1_LogicC>().hasGivenTutorial)
		{
			this.cursors[0].gameObject.SetActive(true);
			this.cursors[1].gameObject.SetActive(false);
			this.cursors[4].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(false);
			this.cursors[5].gameObject.SetActive(false);
		}
		if (this.isHolding1 != null)
		{
			if (this.isHolding1.name == "PaintCan")
			{
				if (raycastHit.collider.tag == "CarLogic" || raycastHit.collider.tag == "CarPaintMesh")
				{
					this.isHolding1.GetComponent<PaintCanC>().target = raycastHit.collider.gameObject;
					this.cursors[0].gameObject.SetActive(false);
					this.cursors[1].gameObject.SetActive(false);
					this.cursors[2].gameObject.SetActive(false);
					this.cursors[4].gameObject.SetActive(true);
					this.cursors[5].gameObject.SetActive(false);
				}
				else if (raycastHit.collider.tag == "CarInteractor")
				{
					if (raycastHit.collider.transform.parent.tag == "CarPaintMesh")
					{
						GameObject gameObject = raycastHit.collider.transform.parent.gameObject;
						this.isHolding1.GetComponent<PaintCanC>().target = gameObject;
						this.cursors[0].gameObject.SetActive(false);
						this.cursors[1].gameObject.SetActive(false);
						this.cursors[2].gameObject.SetActive(false);
						this.cursors[4].gameObject.SetActive(true);
						this.cursors[5].gameObject.SetActive(false);
					}
				}
				else if (raycastHit.collider.tag == "Interactor")
				{
					if (raycastHit.collider.GetComponent<FrameDirtC>())
					{
						GameObject gameObject2 = raycastHit.collider.transform.parent.gameObject;
						this.isHolding1.GetComponent<PaintCanC>().target = gameObject2;
						this.cursors[0].gameObject.SetActive(false);
						this.cursors[1].gameObject.SetActive(false);
						this.cursors[2].gameObject.SetActive(false);
						this.cursors[4].gameObject.SetActive(true);
						this.cursors[5].gameObject.SetActive(false);
					}
				}
				else
				{
					this.isHolding1.GetComponent<PaintCanC>().target = null;
					this.cursors[4].gameObject.SetActive(false);
				}
			}
			else if (this.isHolding1.GetComponent<ObjectInteractionsC>())
			{
				if (this.isHolding1.GetComponent<ObjectInteractionsC>().targetObjectStringName == "UpgradeDecal")
				{
					if (raycastHit.collider.GetComponent<ObjectInteractionsC>())
					{
						if (raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == "UpgradeDecal")
						{
							this.cursors[0].gameObject.SetActive(false);
							this.cursors[1].gameObject.SetActive(false);
							this.cursors[2].gameObject.SetActive(false);
							this.cursors[4].gameObject.SetActive(true);
						}
						else
						{
							this.cursors[4].gameObject.SetActive(false);
						}
					}
					else
					{
						this.cursors[4].gameObject.SetActive(false);
					}
				}
				else
				{
					this.cursors[4].gameObject.SetActive(false);
				}
			}
			else
			{
				this.cursors[4].gameObject.SetActive(false);
			}
		}
		else
		{
			this.cursors[4].gameObject.SetActive(false);
		}
		if (raycastHit.collider.tag == "CarInteractor" || raycastHit.collider.tag == "Interactor" || raycastHit.collider.tag == "Pickup" || raycastHit.collider.tag == "Dropoff" || raycastHit.collider.tag == "CarJack" || raycastHit.collider.tag == "TyreIronBolt")
		{
			if (raycastHit.collider.name == "Map" && !this.carLogic.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().isSat)
			{
				raycastHit.collider.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
				this.lastHitCarInteractor = null;
				return;
			}
			if (raycastHit.collider.name == "Map" && this.carLogic.GetComponent<CarLogicC>().isDriving)
			{
				raycastHit.collider.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
				this.lastHitCarInteractor = null;
				return;
			}
			if (raycastHit.collider.name == "LaikaUserManual_2" && !this.carLogic.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().isSat)
			{
				raycastHit.collider.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
				this.lastHitCarInteractor = null;
				return;
			}
			if (raycastHit.collider.name == "LaikaUserManual_2" && this.carLogic.GetComponent<CarLogicC>().isDriving)
			{
				raycastHit.collider.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
				this.lastHitCarInteractor = null;
				return;
			}
			if (!this.useAnimPlay && !this.cursors[0].active)
			{
				if (this.isHolding1 != null)
				{
					if (this.isHolding1.name == "PaintCan")
					{
						if (raycastHit.collider.tag == "CarLogic" || raycastHit.collider.tag == "CarPaintMesh")
						{
							this.cursors[4].gameObject.SetActive(true);
						}
						else if (raycastHit.collider.tag == "CarInteractor")
						{
							if (raycastHit.collider.transform.parent.tag == "CarPaintMesh")
							{
								this.cursors[4].gameObject.SetActive(true);
							}
						}
						else if (raycastHit.collider.tag == "Interactor")
						{
							if (raycastHit.collider.GetComponent<FrameDirtC>())
							{
								this.cursors[4].gameObject.SetActive(true);
							}
						}
						else
						{
							this.cursors[1].gameObject.SetActive(false);
							this.useAnimPlay = false;
							this.cursors[0].gameObject.SetActive(true);
							this.cursors[4].gameObject.SetActive(false);
							this.cursors[2].gameObject.SetActive(false);
							this.cursors[5].gameObject.SetActive(false);
						}
					}
					else if (this.isHolding1.GetComponent<ObjectInteractionsC>())
					{
						if (this.isHolding1.GetComponent<ObjectInteractionsC>().targetObjectStringName == "UpgradeDecal")
						{
							if (raycastHit.collider.GetComponent<ObjectInteractionsC>())
							{
								if (raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == "UpgradeDecal")
								{
									this.cursors[0].gameObject.SetActive(false);
									this.cursors[1].gameObject.SetActive(false);
									this.cursors[2].gameObject.SetActive(false);
									this.cursors[4].gameObject.SetActive(true);
									this.cursors[5].gameObject.SetActive(false);
								}
								else
								{
									this.cursors[1].gameObject.SetActive(false);
									this.useAnimPlay = false;
									this.cursors[0].gameObject.SetActive(true);
									this.cursors[4].gameObject.SetActive(false);
									this.cursors[2].gameObject.SetActive(false);
									this.cursors[5].gameObject.SetActive(false);
								}
							}
							else
							{
								this.cursors[1].gameObject.SetActive(false);
								this.useAnimPlay = false;
								this.cursors[0].gameObject.SetActive(true);
								this.cursors[4].gameObject.SetActive(false);
								this.cursors[2].gameObject.SetActive(false);
								this.cursors[5].gameObject.SetActive(false);
							}
						}
						else
						{
							this.cursors[1].gameObject.SetActive(false);
							this.useAnimPlay = false;
							this.cursors[0].gameObject.SetActive(true);
							this.cursors[4].gameObject.SetActive(false);
							this.cursors[2].gameObject.SetActive(false);
							this.cursors[5].gameObject.SetActive(false);
						}
					}
					else
					{
						this.cursors[1].gameObject.SetActive(false);
						this.useAnimPlay = false;
						this.cursors[0].gameObject.SetActive(true);
						this.cursors[4].gameObject.SetActive(false);
						this.cursors[2].gameObject.SetActive(false);
						this.cursors[5].gameObject.SetActive(false);
					}
				}
				else if (raycastHit.collider.tag == "Interactor" && this.isHolding1 == null && raycastHit.collider.transform.parent.tag == "CarLogic" && raycastHit.collider.GetComponent<FrameDirtC>() && !base.transform.parent.GetComponent<RigidbodyControllerC>().isSat && MainMenuC.Global.debugUncle.GetComponent<Scene1_LogicC>().hasGivenTutorial)
				{
					this.cursors[0].gameObject.SetActive(true);
					this.cursors[1].gameObject.SetActive(false);
					this.cursors[4].gameObject.SetActive(false);
					this.cursors[2].gameObject.SetActive(false);
					this.cursors[5].gameObject.SetActive(false);
				}
				else
				{
					this.cursors[1].gameObject.SetActive(false);
					this.useAnimPlay = false;
					this.cursors[0].gameObject.SetActive(true);
					this.cursors[4].gameObject.SetActive(false);
					this.cursors[2].gameObject.SetActive(false);
					this.cursors[5].gameObject.SetActive(false);
				}
			}
			if (this.isHolding1 != null)
			{
				if (raycastHit.collider.GetComponent<EngineComponentC>() && this.isHolding1.name != "Sponge" && raycastHit.collider.GetComponent<EngineComponentC>().bolt != null && !raycastHit.collider.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose)
				{
					if (this.lastHitCarInteractor != null)
					{
						this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
						this.lastHitCarInteractor = null;
					}
					return;
				}
				if (this.isHolding1.GetComponent<TyreIronC>() && raycastHit.collider.gameObject.GetComponent<EngineComponentC>() && raycastHit.collider.gameObject.GetComponent<EngineComponentC>().bolt != null)
				{
					this.lastHitCarInteractor = raycastHit.collider.gameObject;
					raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
					raycastHit.collider.gameObject.GetComponent<EngineComponentC>().bolt.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
				}
			}
			if (raycastHit.collider.GetComponent<EngineComponentC>())
			{
				this.lastHitEngineComponent = raycastHit.collider.gameObject;
			}
			if (raycastHit.collider.GetComponent<EngineComponentC>() && this.lastHitEngineComponent != this.hitEngineComponent)
			{
				this.hitComponent = raycastHit.collider.gameObject;
				this.componentUI.SetActive(true);
				if (!this.uiIsOn && DragRigidbodyC.Global._camera.GetComponent<MouseLook>().isSat)
				{
					this.uiIsOn = true;
				}
				if (!this.uiIsOn)
				{
					this.uiIsOn = true;
					iTween.Stop(this.componentUI);
					iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
					{
						"y",
						this.componentUIPos[0].y,
						"time",
						0.3,
						"islocal",
						true,
						"easetype",
						"easeoutback",
						"oncomplete",
						"ComponentUIOn",
						"oncompletetarget",
						base.gameObject
					}));
					base.GetComponent<AudioSource>().PlayOneShot(this.paperSFX, 0.8f);
				}
				else
				{
					iTween.MoveTo(this.componentUI, iTween.Hash(new object[]
					{
						"y",
						this.componentUIPos[1].y,
						"time",
						0.15,
						"islocal",
						true,
						"easetype",
						"easeoutback",
						"oncomplete",
						"ComponentUIOffToOn",
						"oncompletetarget",
						base.gameObject
					}));
				}
				EngineComponentC component2 = raycastHit.collider.GetComponent<EngineComponentC>();
				this.componentHeader.GetComponent<UILabel>().text = Language.Get(component2.componentHeader, "Inspector_UI");
				this.componentHeader.GetComponent<UILabel>().color = this.gray;
				this.SetEngineCompUI1();
				this.hitEngineComponent = raycastHit.collider.gameObject;
			}
			if (raycastHit.collider.tag == "Interactor" && this.isHolding1 == null && raycastHit.collider.GetComponent<ObjectInteractionsC>())
			{
				if (!raycastHit.collider.GetComponent<ObjectInteractionsC>().handInteractive)
				{
					this.cursors[0].gameObject.SetActive(false);
					this.cursors[1].gameObject.SetActive(false);
					this.cursors[2].gameObject.SetActive(true);
					if (this.lastHitCarInteractor != null)
					{
						this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
						this.lastHitCarInteractor = null;
					}
				}
				else
				{
					GameObject gameObject3 = raycastHit.collider.gameObject;
					if (this.lastHitCarInteractor == null)
					{
						this.lastHitCarInteractor = raycastHit.collider.gameObject;
						if (raycastHit.collider.tag == "TyreIronBolt")
						{
							if (raycastHit.transform.GetComponent<BoltLogicC>().isFitted)
							{
								raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
						}
						else
						{
							raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
						}
						this.cursors[2].gameObject.SetActive(false);
						this.cursors[0].gameObject.SetActive(true);
					}
					else if (gameObject3 != this.lastHitCarInteractor)
					{
						this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
						this.lastHitCarInteractor = null;
						this.lastHitCarInteractor = raycastHit.collider.gameObject;
						raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
						this.cursors[2].gameObject.SetActive(false);
						this.cursors[0].gameObject.SetActive(true);
					}
				}
			}
			else
			{
				GameObject gameObject4 = raycastHit.collider.gameObject;
				if (this.lastHitCarInteractor == null)
				{
					if (this.isHolding1 != null)
					{
						if (this.isHolding1.GetComponent<PortableFuelC>() && raycastHit.collider.GetComponent<EngineComponentC>())
						{
							if (raycastHit.collider.GetComponent<EngineComponentC>().fuelLid != null)
							{
								gameObject4 = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								this.lastHitCarInteractor = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								this.lastHitCarInteractor = raycastHit.collider.gameObject;
								raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
						}
						else if (this.isHolding1.GetComponent<RefuelLogicC>() && raycastHit.collider.GetComponent<EngineComponentC>())
						{
							if (raycastHit.collider.GetComponent<EngineComponentC>().fuelLid != null)
							{
								gameObject4 = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								this.lastHitCarInteractor = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								this.lastHitCarInteractor = raycastHit.collider.gameObject;
								raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
						}
						else if (this.isHolding1.GetComponent<OilBottleC>() && raycastHit.collider.GetComponent<EngineComponentC>())
						{
							if (raycastHit.collider.GetComponent<EngineComponentC>().fuelLid != null)
							{
								gameObject4 = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								this.lastHitCarInteractor = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								this.lastHitCarInteractor = raycastHit.collider.gameObject;
								raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
						}
						else
						{
							this.lastHitCarInteractor = raycastHit.collider.gameObject;
							raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
						}
					}
					else
					{
						this.lastHitCarInteractor = raycastHit.collider.gameObject;
						raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
					}
					this.cursors[2].gameObject.SetActive(false);
					this.cursors[0].gameObject.SetActive(true);
				}
				else if (gameObject4 != this.lastHitCarInteractor && this.lastHitCarInteractor != null)
				{
					this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
					this.lastHitCarInteractor = null;
					if (this.isHolding1 != null)
					{
						if (this.isHolding1.GetComponent<PortableFuelC>() && raycastHit.collider.GetComponent<EngineComponentC>())
						{
							if (raycastHit.collider.GetComponent<EngineComponentC>().fuelLid != null)
							{
								gameObject4 = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								this.lastHitCarInteractor = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								this.lastHitCarInteractor = raycastHit.collider.gameObject;
								raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
						}
						else if (this.isHolding1.GetComponent<RefuelLogicC>() && raycastHit.collider.GetComponent<EngineComponentC>())
						{
							if (raycastHit.collider.GetComponent<EngineComponentC>().fuelLid != null)
							{
								gameObject4 = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								this.lastHitCarInteractor = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								this.lastHitCarInteractor = raycastHit.collider.gameObject;
								raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
						}
						else if (this.isHolding1.GetComponent<OilBottleC>() && raycastHit.collider.GetComponent<EngineComponentC>())
						{
							if (raycastHit.collider.GetComponent<EngineComponentC>().fuelLid != null)
							{
								gameObject4 = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								this.lastHitCarInteractor = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
								raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								this.lastHitCarInteractor = raycastHit.collider.gameObject;
								raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
							}
						}
						else
						{
							this.lastHitCarInteractor = raycastHit.collider.gameObject;
							raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
						}
					}
					else
					{
						this.lastHitCarInteractor = raycastHit.collider.gameObject;
						raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
					}
					this.cursors[2].gameObject.SetActive(false);
					this.cursors[0].gameObject.SetActive(true);
				}
				else if (this.lastHitCarInteractor != null && this.lastHitCarInteractor != raycastHit.collider.gameObject)
				{
					this.lastHitCarInteractor.SendMessage("RaycastExit", SendMessageOptions.DontRequireReceiver);
					this.lastHitCarInteractor = null;
				}
			}
		}
		else if (raycastHit.collider.tag == "Interactor" && raycastHit.collider.GetComponent<FrameDirtC>() != null && raycastHit.collider.GetComponent<ObjectInteractionsC>() != null)
		{
			if (this.isHolding1 != null)
			{
				if (raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.transform.name || raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName + "(Clone)" == this.isHolding1.transform.name || raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.GetComponent<ObjectInteractionsC>().targetObjectStringName)
				{
					raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
					this.cursors[2].gameObject.SetActive(true);
					this.cursors[0].gameObject.SetActive(false);
				}
			}
			else if (this.isHolding1.GetComponent<TyreIronC>() && raycastHit.collider.gameObject.GetComponent<EngineComponentC>() && raycastHit.collider.gameObject.GetComponent<EngineComponentC>().bolt != null)
			{
				raycastHit.collider.SendMessage("StopBoltRaycast", SendMessageOptions.DontRequireReceiver);
			}
		}
		else if (raycastHit.collider.tag == "Inventory" && this.isHolding1 != null)
		{
			this.lastHitCarInteractor = raycastHit.collider.gameObject;
			raycastHit.collider.SendMessage("RaycastEnter", SendMessageOptions.DontRequireReceiver);
			this.cursors[2].gameObject.SetActive(false);
			this.cursors[0].gameObject.SetActive(true);
		}
		else if (raycastHit.collider.tag == "Inventory" && this.isHolding1 == null)
		{
			this.cursors[0].gameObject.SetActive(false);
			this.cursors[1].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(true);
		}
		if (!Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && !Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) && !Input.GetButtonDown("Fire1"))
		{
			return;
		}
		if (!Physics.Raycast(ray, out raycastHit, this.maxRayDistance, this.myLayerMask))
		{
			return;
		}
		if (raycastHit.collider.tag == "CarLogic" && this.isHolding1 == null && !base.transform.parent.GetComponent<RigidbodyControllerC>().isSat && MainMenuC.Global.debugUncle.GetComponent<Scene1_LogicC>().hasGivenTutorial)
		{
			if (raycastHit.collider.GetComponent<CarLogicC>() && raycastHit.collider.GetComponent<CarLogicC>().jackInUse != null)
			{
				if (raycastHit.collider.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().isJackedUp)
				{
					return;
				}
				if (raycastHit.collider.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().isPurchased)
				{
					raycastHit.collider.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
					raycastHit.collider.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().ThrowLogic();
				}
				else
				{
					raycastHit.collider.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
					raycastHit.collider.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().ReturnToShelf();
				}
				raycastHit.collider.GetComponent<CarLogicC>().jackInUse = null;
			}
			this.cursors[0].gameObject.SetActive(false);
			this.cursors[1].gameObject.SetActive(false);
			this.cursors[4].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(false);
			this.cursors[5].gameObject.SetActive(true);
			MonoBehaviour.print("Push Over");
			base.GetComponent<AudioSource>().PlayOneShot(this.pushAudio, 1f);
			GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.pushParticle);
			gameObject5.transform.parent = base.transform;
			gameObject5.transform.localPosition = new Vector3(0f, 0f, 1.5f);
			gameObject5.transform.parent = null;
			UnityEngine.Object.Destroy(gameObject5, 0.25f);
			MonoBehaviour.print("Pushing " + base.transform.forward * this.pushPower);
			this.carLogic.transform.parent.transform.parent.GetComponent<Rigidbody>().AddForce(base.transform.forward * this.pushPower);
			float num = this.pushPower / 4f;
			return;
		}
		if (raycastHit.collider.tag == "CarPaintMesh" && raycastHit.collider.name == "Roof" && this.isHolding1 == null && !base.transform.parent.GetComponent<RigidbodyControllerC>().isSat && MainMenuC.Global.debugUncle.GetComponent<Scene1_LogicC>().hasGivenTutorial)
		{
			if (raycastHit.collider.transform.parent.GetComponent<CarLogicC>() && raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse != null)
			{
				if (raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().isJackedUp)
				{
					return;
				}
				if (raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().isPurchased)
				{
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().ThrowLogic();
				}
				else
				{
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().ReturnToShelf();
				}
				raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse = null;
			}
			this.cursors[0].gameObject.SetActive(false);
			this.cursors[1].gameObject.SetActive(false);
			this.cursors[4].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(false);
			this.cursors[5].gameObject.SetActive(true);
			MonoBehaviour.print("UberPush");
			base.GetComponent<AudioSource>().PlayOneShot(this.pushAudio, 1f);
			GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.pushParticle);
			gameObject6.transform.parent = base.transform;
			gameObject6.transform.localPosition = new Vector3(0f, 0f, 1.5f);
			gameObject6.transform.parent = null;
			UnityEngine.Object.Destroy(gameObject6, 0.25f);
			this.carLogic.transform.parent.transform.parent.GetComponent<Rigidbody>().AddForce(base.transform.forward * this.pushPower);
			float num2 = this.pushPower / 4f;
			return;
		}
		if (raycastHit.collider.tag == "Interactor" && this.isHolding1 == null && raycastHit.collider.transform.parent.tag == "CarLogic" && raycastHit.collider.GetComponent<FrameDirtC>() && !base.transform.parent.GetComponent<RigidbodyControllerC>().isSat && MainMenuC.Global.debugUncle.GetComponent<Scene1_LogicC>().hasGivenTutorial)
		{
			if (raycastHit.collider.GetComponent<FrameDirtC>() && raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse != null)
			{
				if (raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().isJackedUp)
				{
					return;
				}
				if (raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().isPurchased)
				{
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().ThrowLogic();
				}
				else
				{
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().JackOutFromDrivingAway();
					raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse.GetComponent<ObjectPickupC>().ReturnToShelf();
				}
				raycastHit.collider.transform.parent.GetComponent<CarLogicC>().jackInUse = null;
			}
			this.cursors[0].gameObject.SetActive(false);
			this.cursors[1].gameObject.SetActive(false);
			this.cursors[4].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(false);
			this.cursors[5].gameObject.SetActive(true);
			base.GetComponent<AudioSource>().PlayOneShot(this.pushAudio, 1f);
			GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.pushParticle);
			gameObject7.transform.parent = base.transform;
			gameObject7.transform.localPosition = new Vector3(0f, 0f, 1.5f);
			gameObject7.transform.parent = null;
			UnityEngine.Object.Destroy(gameObject7, 0.25f);
			this.carLogic.transform.parent.transform.parent.GetComponent<Rigidbody>().AddForce(base.transform.parent.forward * this.pushPower);
			float num3 = this.pushPower / 4f;
			return;
		}
		if (this.isHolding1 != null && this.isHolding1.name == "PaintCan")
		{
			if (raycastHit.collider.tag == "CarLogic" || raycastHit.collider.tag == "CarPaintMesh")
			{
				this.isHolding1.GetComponent<PaintCanC>().target = raycastHit.collider.gameObject;
				this.isHolding1.GetComponent<PaintCanC>().Action();
				return;
			}
			if (raycastHit.collider.tag == "CarInteractor" && raycastHit.collider.transform.parent.tag == "CarPaintMesh")
			{
				GameObject gameObject8 = raycastHit.collider.transform.parent.gameObject;
				this.isHolding1.GetComponent<PaintCanC>().target = gameObject8;
				this.isHolding1.GetComponent<PaintCanC>().Action();
				return;
			}
			if (raycastHit.collider.tag == "Interactor" && raycastHit.collider.GetComponent<FrameDirtC>())
			{
				GameObject gameObject9 = raycastHit.collider.transform.parent.gameObject;
				this.isHolding1.GetComponent<PaintCanC>().target = gameObject9;
				this.isHolding1.GetComponent<PaintCanC>().Action();
				return;
			}
		}
		if (raycastHit.collider.tag == "CarInteractor")
		{
			if (this.isHolding1 != null)
			{
				if (raycastHit.collider.GetComponent<ObjectInteractionsC>() != null)
				{
					if (raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.transform.name)
					{
						if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 0 && raycastHit.collider.transform.name == "CarEngine")
						{
							this.isHolding1.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
						}
						else
						{
							this.isHolding1.GetComponent<ObjectInteractionsC>().target = raycastHit.collider.gameObject;
							this.isHolding1.SendMessage("Action");
							if (raycastHit.collider.GetComponent<HoldingLogicC>())
							{
								raycastHit.collider.GetComponent<HoldingLogicC>().NoLongerHolding();
							}
						}
					}
					else
					{
						raycastHit.collider.gameObject.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
						base.StopCoroutine("Cursor1Go");
						this.cursors[1].gameObject.SetActive(false);
						this.useAnimPlay = false;
						base.StartCoroutine("Cursor1Go");
						this.isHolding1.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
					}
				}
				else
				{
					raycastHit.collider.gameObject.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
					base.StopCoroutine("Cursor1Go");
					this.cursors[1].gameObject.SetActive(false);
					this.useAnimPlay = false;
					base.StartCoroutine("Cursor1Go");
				}
			}
			else
			{
				this.cursors[0].gameObject.SetActive(false);
				this.cursors[2].gameObject.SetActive(false);
				this.cursors[4].gameObject.SetActive(false);
				this.cursors[5].gameObject.SetActive(false);
				raycastHit.collider.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
				base.StopCoroutine("Cursor1Go");
				this.cursors[1].gameObject.SetActive(false);
				this.useAnimPlay = false;
				base.StartCoroutine("Cursor1Go");
			}
		}
		if (raycastHit.collider.tag == "Interactor")
		{
			if (this.isHolding1 != null)
			{
				if (raycastHit.collider.GetComponent<ObjectInteractionsC>() != null && this.isHolding1.GetComponent<ObjectInteractionsC>() != null)
				{
					if (raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.transform.name || this.isHolding1.GetComponent<ObjectInteractionsC>().targetObjectStringName == raycastHit.collider.transform.name)
					{
						if (this.isHolding1.GetComponent<WaterBottleLogicC>())
						{
							this.isHolding1.GetComponent<WaterBottleLogicC>().hitTarget = raycastHit.collider.gameObject;
							this.isHolding1.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
							return;
						}
						this.isHolding1.GetComponent<ObjectInteractionsC>().target = raycastHit.collider.gameObject;
						this.isHolding1.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
						if (raycastHit.collider.GetComponent<HoldingLogicC>())
						{
							raycastHit.collider.GetComponent<HoldingLogicC>().NoLongerHolding();
						}
					}
					else if (this.isHolding1.GetComponent<ObjectInteractionsC>())
					{
						if (raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.GetComponent<ObjectInteractionsC>().targetObjectStringName)
						{
							if (this.isHolding1.GetComponent<WaterBottleLogicC>())
							{
								this.isHolding1.GetComponent<WaterBottleLogicC>().hitTarget = raycastHit.collider.gameObject;
								this.isHolding1.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
								return;
							}
							this.isHolding1.GetComponent<ObjectInteractionsC>().target = raycastHit.collider.gameObject;
							this.isHolding1.SendMessage("Action");
							if (raycastHit.collider.GetComponent<HoldingLogicC>())
							{
								raycastHit.collider.GetComponent<HoldingLogicC>().NoLongerHolding();
							}
						}
					}
					else
					{
						this.isHolding1.SendMessage("UnAction", SendMessageOptions.DontRequireReceiver);
					}
				}
				else
				{
					raycastHit.collider.gameObject.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
					base.StopCoroutine("Cursor1Go");
					this.cursors[1].gameObject.SetActive(false);
					this.useAnimPlay = false;
					base.StartCoroutine("Cursor1Go");
				}
			}
			else if (raycastHit.collider.GetComponent<ObjectInteractionsC>() != null)
			{
				if (raycastHit.collider.GetComponent<ObjectInteractionsC>().handInteractive)
				{
					raycastHit.collider.gameObject.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
					base.StopCoroutine("Cursor1Go");
					this.cursors[1].gameObject.SetActive(false);
					this.useAnimPlay = false;
					base.StartCoroutine("Cursor1Go");
				}
			}
			else
			{
				raycastHit.collider.gameObject.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
				base.StopCoroutine("Cursor1Go");
				this.cursors[1].gameObject.SetActive(false);
				this.useAnimPlay = false;
				base.StartCoroutine("Cursor1Go");
			}
		}
		if (raycastHit.collider.tag == "Pickup" && !this.pickingUp)
		{
			if (this.isHolding1 != null)
			{
				if (this.isHolding1.GetComponent<RepairKitC>() && raycastHit.collider.GetComponent<EngineComponentC>())
				{
					if (this.isHolding1.GetComponent<RepairKitC>().isToolRack)
					{
						float num4 = raycastHit.collider.GetComponent<EngineComponentC>().durability * this.isHolding1.GetComponent<RepairKitC>().spannerDamageLvl;
						if (raycastHit.collider.GetComponent<EngineComponentC>().Condition < num4)
						{
							this.isHolding1.GetComponent<RepairKitC>().ToolRackAction(raycastHit.collider.gameObject);
							return;
						}
						this.isHolding1.GetComponent<RepairKitC>().ToolRackAction(raycastHit.collider.gameObject);
						return;
					}
					else if (raycastHit.collider.GetComponent<EngineComponentC>().Condition < raycastHit.collider.GetComponent<EngineComponentC>().durability)
					{
						this.isHolding1.GetComponent<RepairKitC>().Action(raycastHit.collider.gameObject);
						return;
					}
				}
				if (raycastHit.collider.GetComponent<ObjectInteractionsC>() != null && raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.transform.name && this.isHolding1.GetComponent<WaterBottleLogicC>())
				{
					this.isHolding1.GetComponent<WaterBottleLogicC>().hitTarget = raycastHit.collider.gameObject;
					this.isHolding1.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
					return;
				}
				if (this.isHolding1.GetComponent<RefuelLogicC>() && raycastHit.collider.GetComponent<PortableFuelC>())
				{
					Debug.Log("Fuel Logic should fire");
					this.isHolding1.GetComponent<RefuelLogicC>().fuelTarget = raycastHit.collider.gameObject;
					this.isHolding1.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
					return;
				}
				if (this.isHolding1.GetComponent<OilBottleC>() && raycastHit.collider.GetComponent<PortableFuelC>())
				{
					this.isHolding1.GetComponent<ObjectInteractionsC>().target = raycastHit.collider.gameObject;
					this.isHolding1.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
					return;
				}
				if ((this.isHolding1.GetComponent<PortableFuelC>() || this.isHolding1.GetComponent<RefuelLogicC>() || this.isHolding1.GetComponent<OilBottleC>()) && raycastHit.collider.GetComponent<EngineComponentC>() && raycastHit.collider.GetComponent<EngineComponentC>().fuelLid != null)
				{
					this.isHolding1.GetComponent<ObjectInteractionsC>().target = raycastHit.collider.GetComponent<EngineComponentC>().fuelLid.transform.parent.gameObject;
					this.isHolding1.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
					return;
				}
			}
			this.pickingUp = true;
			raycastHit.collider.gameObject.SendMessage("PickUp", SendMessageOptions.DontRequireReceiver);
			base.StopCoroutine("Cursor1Go");
			this.cursors[1].gameObject.SetActive(false);
			this.useAnimPlay = false;
			this.cursors[0].gameObject.SetActive(false);
			this.cursors[2].gameObject.SetActive(false);
			this.cursors[4].gameObject.SetActive(false);
			this.cursors[5].gameObject.SetActive(false);
			this.useAnimPlay = true;
			base.StartCoroutine("Cursor1Go");
			return;
		}
		if (!(raycastHit.collider.tag == "Inventory") || !(this.isHolding1 != null))
		{
			if (raycastHit.collider.tag == "Dropoff" && !this.pickingUp)
			{
				if (this.isHolding1 == null)
				{
					return;
				}
				iTween.Stop(this.isHolding1);
				if (raycastHit.collider.GetComponent<HoldingLogicC>().targetObject == this.isHolding1.gameObject && !this.droppingOff)
				{
					this.DropOffCheck2(raycastHit.collider.gameObject);
				}
				else if (this.isHolding1.GetComponent<ObjectInteractionsC>())
				{
					if (raycastHit.collider.GetComponent<HoldingLogicC>().targetObjectStringName == this.isHolding1.transform.name || (raycastHit.collider.GetComponent<ObjectInteractionsC>().targetObjectStringName == this.isHolding1.GetComponent<ObjectInteractionsC>().targetObjectStringName && !this.droppingOff))
					{
						if (!(raycastHit.collider.name == "FuelHandleHolder") || !this.isHolding1.GetComponent<PortableFuelC>())
						{
							this.DropOffCheck(raycastHit.collider.gameObject);
						}
					}
				}
				else if (raycastHit.collider.GetComponent<HoldingLogicC>().targetObjectStringName == this.isHolding1.transform.name && !this.droppingOff)
				{
					if (!(raycastHit.collider.name == "FuelHandleHolder") || !this.isHolding1.GetComponent<PortableFuelC>())
					{
						this.DropOffCheck(raycastHit.collider.gameObject);
					}
				}
			}
			if (raycastHit.collider.tag == "CarJack")
			{
				if (this.isHolding1 == null)
				{
					return;
				}
				iTween.Stop(this.isHolding1);
				if (raycastHit.collider.GetComponent<ObjectInteractionsC>().target == this.isHolding1.gameObject)
				{
					this.isHolding1.GetComponent<CarJackC>().jackInstalledAt = raycastHit.collider.gameObject;
					this.isHolding1.GetComponent<ObjectPickupC>().targetDropOff = raycastHit.collider.gameObject;
					Transform[] componentsInChildren = this.isHolding1.GetComponentsInChildren<Transform>();
					foreach (Transform transform in componentsInChildren)
					{
						transform.gameObject.layer = LayerMask.NameToLayer("Default");
					}
					this.isHolding1.SendMessage("JackEngaged", SendMessageOptions.DontRequireReceiver);
					if (this.isHolding2 != null)
					{
						this.Holding2ToHands();
						return;
					}
					this.isHolding1 = null;
					return;
				}
			}
			if (raycastHit.collider.tag == "TyreIronBolt" && (double)this.tyreIronBoltSpamStopper <= 0.0)
			{
				if (this.isHolding1 == null)
				{
					return;
				}
				if (!this.isHolding1.GetComponent<TyreIronC>())
				{
					return;
				}
				if (!raycastHit.collider.GetComponent<BoltLogicC>().isFitted)
				{
					return;
				}
				iTween.Stop(this.isHolding1);
				this.isHolding1.GetComponent<TyreIronC>().targetBolt = raycastHit.collider.gameObject;
				this.isHolding1.GetComponent<TyreIronC>().StartCoroutine("Action");
				this.tyreIronBoltSpamStopper = 1.25f;
			}
			return;
		}
		if (this.isHolding1.GetComponent<CarJackC>())
		{
			this.isHolding1.GetComponent<CarJackC>().IntoInventory();
		}
		for (int j = 0; j < this.isHolding1.GetComponent<ObjectPickupC>().dropOffPoints.Length; j++)
		{
			this.isHolding1.GetComponent<ObjectPickupC>().dropOffPoints[j].GetComponent<HoldingLogicC>().NoLongerHolding();
		}
		base.StopCoroutine("Cursor1Go");
		this.cursors[1].gameObject.SetActive(false);
		this.useAnimPlay = false;
		this.cursors[0].gameObject.SetActive(false);
		this.cursors[2].gameObject.SetActive(false);
		this.cursors[4].gameObject.SetActive(false);
		this.cursors[5].gameObject.SetActive(false);
		this.useAnimPlay = true;
		base.StartCoroutine("Cursor1Go");
		if (this.isHolding1.name == "Wheel")
		{
			raycastHit.collider.SendMessage("WheelIntoInventory", SendMessageOptions.DontRequireReceiver);
			return;
		}
		raycastHit.collider.SendMessage("Trigger", SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0005F724 File Offset: 0x0005DB24
	private IEnumerator DragObject(float distance)
	{
		float oldDrag = this.springJoint.connectedBody.drag;
		float oldAngularDrag = this.springJoint.connectedBody.angularDrag;
		this.springJoint.connectedBody.drag = this.drag;
		this.springJoint.connectedBody.angularDrag = this.angularDrag;
		Camera mainCamera = this.FindCamera();
		while (Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[17]))
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			this.springJoint.transform.position = ray.GetPoint(distance);
			yield return new WaitForEndOfFrame();
		}
		if (this.springJoint.connectedBody)
		{
			this.springJoint.connectedBody.drag = oldDrag;
			this.springJoint.connectedBody.angularDrag = oldAngularDrag;
			this.springJoint.connectedBody = null;
		}
		yield break;
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x0005F746 File Offset: 0x0005DB46
	public Camera FindCamera()
	{
		if (base.GetComponent<Camera>())
		{
			return base.GetComponent<Camera>();
		}
		return Camera.main;
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x0005F764 File Offset: 0x0005DB64
	private IEnumerator Cursor1Go()
	{
		this.useAnimPlay = true;
		this.cursors[1].gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		this.cursors[1].gameObject.SetActive(false);
		this.useAnimPlay = false;
		this.cursors[0].gameObject.SetActive(false);
		this.cursors[1].gameObject.SetActive(false);
		this.cursors[2].gameObject.SetActive(true);
		this.cursors[4].gameObject.SetActive(false);
		this.cursors[5].gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x0005F77F File Offset: 0x0005DB7F
	public void PickUpError()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.errorAudio, 1f);
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x0005F798 File Offset: 0x0005DB98
	public void DropAllItems()
	{
		if (this.isHolding1 != null && this.isHolding1.transform.name != "CarKey" && !this.isHolding1.transform.name.Contains("Motel_Key"))
		{
			for (int i = 0; i < this.isHolding1.GetComponent<ObjectPickupC>().dropOffPoints.Length; i++)
			{
				this.isHolding1.GetComponent<ObjectPickupC>().dropOffPoints[i].GetComponent<HoldingLogicC>().NoLongerHolding();
			}
			this.isHolding1.layer = LayerMask.NameToLayer("Interactor");
			if (this.isHolding1.GetComponent<ObjectPickupC>().connectedTo == null && this.isHolding1.GetComponent<ObjectPickupC>().isPurchased && this.isHolding1.GetComponent<ObjectPickupC>().returnObject == null && !this.isHolding1.GetComponent<SpongeC>() && !this.isHolding1.GetComponent<TyreIronC>())
			{
				this.isHolding1.gameObject.AddComponent<Rigidbody>();
				this.isHolding1.GetComponent<Rigidbody>().mass = this.isHolding1.GetComponent<ObjectPickupC>().rigidMass;
			}
			Transform[] componentsInChildren = this.isHolding1.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				transform.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			this.isHolding1.transform.localEulerAngles = new Vector3(this.isHolding1.transform.localEulerAngles.x, this.isHolding1.GetComponent<ObjectPickupC>().throwRotAdjustment.y, this.isHolding1.transform.localEulerAngles.z);
			if (this.isHolding1.GetComponent<Rigidbody>() != null)
			{
				this.isHolding1.GetComponent<Rigidbody>().isKinematic = false;
				this.isHolding1.GetComponent<Rigidbody>().detectCollisions = true;
			}
			this.isHolding1.SendMessage("ThrowLogic", SendMessageOptions.DontRequireReceiver);
			this.isHolding1.GetComponent<Collider>().enabled = true;
			if (this.isHolding1.GetComponent<Rigidbody>() != null)
			{
				this.isHolding1.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)80;
			}
			this.isHolding1.transform.localEulerAngles = new Vector3(this.isHolding1.GetComponent<ObjectPickupC>().throwRotAdjustment.x, this.isHolding1.transform.localEulerAngles.y, this.isHolding1.transform.localEulerAngles.z);
			this.isHolding1.transform.localEulerAngles = new Vector3(this.isHolding1.transform.localEulerAngles.x, this.isHolding1.transform.localEulerAngles.y, this.isHolding1.GetComponent<ObjectPickupC>().throwRotAdjustment.z);
			if (this.isHolding1.GetComponent<Rigidbody>() != null)
			{
				this.isHolding1.GetComponent<Rigidbody>().AddForce(this._camera.transform.forward * this.throwPower);
			}
			if (this.isHolding1.GetComponent<Rigidbody>() == null && this.isHolding1.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding1.SendMessage("DropNoRigidbody", SendMessageOptions.DontRequireReceiver);
			}
			if (!this.isHolding1.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding1.GetComponent<ObjectPickupC>().ReturnToShelf();
			}
			this.isHolding1 = null;
		}
		if (this.isHolding2 != null)
		{
			for (int k = 0; k < this.isHolding2.GetComponent<ObjectPickupC>().dropOffPoints.Length; k++)
			{
				this.isHolding2.GetComponent<ObjectPickupC>().dropOffPoints[k].GetComponent<HoldingLogicC>().NoLongerHolding();
			}
			this.isHolding2.layer = LayerMask.NameToLayer("Interactor");
			if (this.isHolding2.GetComponent<ObjectPickupC>().connectedTo == null && this.isHolding2.GetComponent<ObjectPickupC>().isPurchased && this.isHolding2.GetComponent<ObjectPickupC>().returnObject == null && !this.isHolding2.GetComponent<SpongeC>() && !this.isHolding2.GetComponent<TyreIronC>())
			{
				this.isHolding2.gameObject.AddComponent<Rigidbody>();
				this.isHolding2.GetComponent<Rigidbody>().mass = this.isHolding2.GetComponent<ObjectPickupC>().rigidMass;
			}
			Transform[] componentsInChildren2 = this.isHolding2.GetComponentsInChildren<Transform>();
			foreach (Transform transform2 in componentsInChildren2)
			{
				transform2.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			this.isHolding2.transform.localEulerAngles = new Vector3(this.isHolding2.transform.localEulerAngles.x, this.isHolding2.GetComponent<ObjectPickupC>().throwRotAdjustment.y, this.isHolding2.transform.localEulerAngles.z);
			if (this.isHolding2.GetComponent<Rigidbody>() != null)
			{
				this.isHolding2.GetComponent<Rigidbody>().isKinematic = false;
				this.isHolding2.GetComponent<Rigidbody>().detectCollisions = true;
			}
			this.isHolding2.SendMessage("ThrowLogic", SendMessageOptions.DontRequireReceiver);
			this.isHolding2.GetComponent<Collider>().enabled = true;
			if (this.isHolding2.GetComponent<Rigidbody>() != null)
			{
				this.isHolding2.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)80;
			}
			this.isHolding2.transform.localEulerAngles = new Vector3(this.isHolding2.GetComponent<ObjectPickupC>().throwRotAdjustment.x, this.isHolding2.transform.localEulerAngles.y, this.isHolding2.transform.localEulerAngles.z);
			this.isHolding2.transform.localEulerAngles = new Vector3(this.isHolding2.transform.localEulerAngles.x, this.isHolding2.transform.localEulerAngles.y, this.isHolding2.GetComponent<ObjectPickupC>().throwRotAdjustment.z);
			if (this.isHolding2.GetComponent<Rigidbody>() != null)
			{
				this.isHolding2.GetComponent<Rigidbody>().AddForce(this._camera.transform.forward * this.throwPower);
			}
			if (this.isHolding2.GetComponent<Rigidbody>() == null && this.isHolding2.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding2.SendMessage("DropNoRigidbody", SendMessageOptions.DontRequireReceiver);
			}
			if (!this.isHolding2.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding2.GetComponent<ObjectPickupC>().ReturnToShelf();
			}
			this.isHolding2 = null;
		}
		if (this.isHolding3 != null)
		{
			for (int m = 0; m < this.isHolding3.GetComponent<ObjectPickupC>().dropOffPoints.Length; m++)
			{
				this.isHolding3.GetComponent<ObjectPickupC>().dropOffPoints[m].GetComponent<HoldingLogicC>().NoLongerHolding();
			}
			this.isHolding3.layer = LayerMask.NameToLayer("Interactor");
			if (this.isHolding3.GetComponent<ObjectPickupC>().connectedTo == null && this.isHolding3.GetComponent<ObjectPickupC>().isPurchased && this.isHolding3.GetComponent<ObjectPickupC>().returnObject == null && !this.isHolding3.GetComponent<SpongeC>() && !this.isHolding3.GetComponent<TyreIronC>())
			{
				this.isHolding3.gameObject.AddComponent<Rigidbody>();
				this.isHolding3.GetComponent<Rigidbody>().mass = this.isHolding3.GetComponent<ObjectPickupC>().rigidMass;
			}
			Transform[] componentsInChildren3 = this.isHolding3.GetComponentsInChildren<Transform>();
			foreach (Transform transform3 in componentsInChildren3)
			{
				transform3.gameObject.layer = LayerMask.NameToLayer("Default");
			}
			this.isHolding3.transform.localEulerAngles = new Vector3(this.isHolding3.transform.localEulerAngles.x, this.isHolding3.GetComponent<ObjectPickupC>().throwRotAdjustment.y, this.isHolding3.transform.localEulerAngles.z);
			if (this.isHolding3.GetComponent<Rigidbody>() != null)
			{
				this.isHolding3.GetComponent<Rigidbody>().isKinematic = false;
				this.isHolding3.GetComponent<Rigidbody>().detectCollisions = true;
			}
			this.isHolding3.SendMessage("ThrowLogic", SendMessageOptions.DontRequireReceiver);
			this.isHolding3.GetComponent<Collider>().enabled = true;
			if (this.isHolding3.GetComponent<Rigidbody>() != null)
			{
				this.isHolding3.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)80;
			}
			this.isHolding3.transform.localEulerAngles = new Vector3(this.isHolding3.GetComponent<ObjectPickupC>().throwRotAdjustment.x, this.isHolding3.transform.localEulerAngles.y, this.isHolding3.transform.localEulerAngles.z);
			this.isHolding3.transform.localEulerAngles = new Vector3(this.isHolding3.transform.localEulerAngles.x, this.isHolding3.transform.localEulerAngles.y, this.isHolding3.GetComponent<ObjectPickupC>().throwRotAdjustment.z);
			if (this.isHolding3.GetComponent<Rigidbody>() != null)
			{
				this.isHolding3.GetComponent<Rigidbody>().AddForce(this._camera.transform.forward * this.throwPower);
			}
			if (this.isHolding3.GetComponent<Rigidbody>() == null && this.isHolding3.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding3.SendMessage("DropNoRigidbody", SendMessageOptions.DontRequireReceiver);
			}
			if (!this.isHolding3.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding3.GetComponent<ObjectPickupC>().ReturnToShelf();
			}
			this.isHolding3 = null;
		}
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x0006029C File Offset: 0x0005E69C
	public void DropOffCheck2(GameObject hit)
	{
		if (this.droppingOff)
		{
			return;
		}
		if (this.pickingUp)
		{
			return;
		}
		this.droppingOff = true;
		this.isHolding1.GetComponent<ObjectPickupC>().targetDropOff = hit.GetComponent<Collider>().gameObject;
		this.isHolding1.SendMessage("DropOff", SendMessageOptions.DontRequireReceiver);
		if (this.isHolding2 != null)
		{
			this.Holding2ToHands();
			return;
		}
		this.isHolding1 = null;
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x00060314 File Offset: 0x0005E714
	public void DropOffCheck(GameObject hit)
	{
		if (this.droppingOff)
		{
			return;
		}
		if (this.pickingUp)
		{
			return;
		}
		this.droppingOff = true;
		this.isHolding1.GetComponent<ObjectPickupC>().targetDropOff = hit.GetComponent<Collider>().gameObject;
		this.isHolding1.SendMessage("DropOff", SendMessageOptions.DontRequireReceiver);
		hit.GetComponent<Collider>().GetComponent<HoldingLogicC>().targetObject = this.isHolding1;
		this.isHolding1.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = this.isHolding1.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		if (this.isHolding2 != null)
		{
			this.Holding2ToHands();
			return;
		}
		this.isHolding1 = null;
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x000603F4 File Offset: 0x0005E7F4
	public void ThrowHolding()
	{
		if (this.isHolding1.name == "CarKey")
		{
			return;
		}
		if (this.isHolding1.name.Contains("Motel_Key"))
		{
			return;
		}
		for (int i = 0; i < this.isHolding1.GetComponent<ObjectPickupC>().dropOffPoints.Length; i++)
		{
			this.isHolding1.GetComponent<ObjectPickupC>().dropOffPoints[i].GetComponent<HoldingLogicC>().NoLongerHolding();
		}
		this.isHolding1.layer = LayerMask.NameToLayer("PickUpDropped");
		if (this.isHolding1.GetComponent<ObjectPickupC>().connectedTo == null && this.isHolding1.GetComponent<ObjectPickupC>().isPurchased && this.isHolding1.GetComponent<ObjectPickupC>().returnObject == null && !this.isHolding1.GetComponent<SpongeC>() && !this.isHolding1.GetComponent<TyreIronC>())
		{
			this.isHolding1.gameObject.AddComponent<Rigidbody>();
			this.isHolding1.gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
			this.isHolding1.GetComponent<Rigidbody>().mass = this.isHolding1.GetComponent<ObjectPickupC>().rigidMass;
		}
		Transform[] componentsInChildren = this.isHolding1.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("PickUpDropped");
		}
		this.isHolding1.transform.localEulerAngles = new Vector3(this.isHolding1.transform.localEulerAngles.x, this.isHolding1.GetComponent<ObjectPickupC>().throwRotAdjustment.y, this.isHolding1.transform.localEulerAngles.z);
		if (this.isHolding1.GetComponent<Rigidbody>() != null)
		{
			this.isHolding1.GetComponent<Rigidbody>().isKinematic = false;
			this.isHolding1.GetComponent<Rigidbody>().detectCollisions = true;
		}
		this.isHolding1.SendMessage("ThrowLogic", SendMessageOptions.DontRequireReceiver);
		if (this.isHolding1 != null)
		{
			this.isHolding1.GetComponent<Collider>().enabled = true;
			if (this.isHolding1.GetComponent<Rigidbody>() != null)
			{
				this.isHolding1.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)80;
			}
			this.isHolding1.transform.localEulerAngles = new Vector3(this.isHolding1.GetComponent<ObjectPickupC>().throwRotAdjustment.x, this.isHolding1.transform.localEulerAngles.y, this.isHolding1.transform.localEulerAngles.z);
			this.isHolding1.transform.localEulerAngles = new Vector3(this.isHolding1.transform.localEulerAngles.x, this.isHolding1.transform.localEulerAngles.y, this.isHolding1.GetComponent<ObjectPickupC>().throwRotAdjustment.z);
			if (this.isHolding1.GetComponent<Rigidbody>() != null)
			{
				this.isHolding1.GetComponent<Rigidbody>().AddForce(this._camera.transform.forward * this.throwPower);
			}
			if (this.isHolding1.GetComponent<Rigidbody>() == null && this.isHolding1.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding1.SendMessage("DropNoRigidbody", SendMessageOptions.DontRequireReceiver);
			}
			if (!this.isHolding1.GetComponent<ObjectPickupC>().isPurchased)
			{
				this.isHolding1.GetComponent<ObjectPickupC>().ReturnToShelf();
			}
		}
		this.isHolding1 = null;
		if (this.isHolding2 != null)
		{
			this.Holding2ToHands();
		}
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x000607EE File Offset: 0x0005EBEE
	public void GhostEngineHolding1()
	{
		if (this.isHolding1 != null && this.isHolding1.GetComponent<EngineComponentC>())
		{
			this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
		}
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x0006082C File Offset: 0x0005EC2C
	public void Holding2ToHands()
	{
		this.isHolding1 = this.isHolding2;
		this.isHolding2 = null;
		this.isHolding1.transform.parent = this.holdingParent1;
		this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
		if (this.isHolding1.GetComponent<EngineComponentC>())
		{
			this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
		}
		if (this.isHolding3 != null)
		{
			this.Holding3To2();
		}
		this.isHolding1.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot1");
	}

	// Token: 0x06000570 RID: 1392 RVA: 0x000608DC File Offset: 0x0005ECDC
	public void ResetItemSway()
	{
		if (this.isHolding1 != null)
		{
			this.isHolding1.transform.localEulerAngles = this.isHolding1.GetComponent<ObjectPickupC>().setRotation;
		}
		if (this.isHolding2 != null)
		{
			this.isHolding2.transform.localEulerAngles = this.isHolding2.GetComponent<ObjectPickupC>().setRotation;
		}
		if (this.isHolding3 != null)
		{
			this.isHolding3.transform.localEulerAngles = this.isHolding3.GetComponent<ObjectPickupC>().setRotation;
		}
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x0006097C File Offset: 0x0005ED7C
	public void Holding3To2()
	{
		this.isHolding2 = this.isHolding3;
		this.isHolding3 = null;
		this.isHolding2.transform.parent = this.holdingParent2;
		this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
		this.ResetItemSway();
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x000609D8 File Offset: 0x0005EDD8
	public void Swap2With1()
	{
		GameObject gameObject = this.isHolding1;
		GameObject gameObject2 = this.isHolding2;
		this.isHolding1 = gameObject2;
		this.isHolding2 = gameObject;
		this.isHolding2.transform.parent = this.holdingParent2;
		this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding1.transform.parent = this.holdingParent1;
		this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
		if (this.isHolding1.GetComponent<EngineComponentC>())
		{
			this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
		}
		this.ResetItemSway();
		if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
		{
			this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
		}
		this.isHolding1.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot1");
		this.isHolding2.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot2");
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x00060B1C File Offset: 0x0005EF1C
	public void Swap3With1()
	{
		GameObject gameObject = this.isHolding1;
		GameObject gameObject2 = this.isHolding3;
		this.isHolding1 = gameObject2;
		this.isHolding3 = gameObject;
		this.isHolding3.transform.parent = this.holdingParent3;
		this.isHolding3.transform.localPosition = this.isHolding3.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding1.transform.parent = this.holdingParent1;
		this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
		if (this.isHolding1.GetComponent<EngineComponentC>())
		{
			this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
		}
		this.ResetItemSway();
		if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
		{
			this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
		}
		this.isHolding1.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot1");
		this.isHolding3.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot3");
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x00060C60 File Offset: 0x0005F060
	public void MoveItemsRightInventory()
	{
		if (this.isHolding2 == null)
		{
			return;
		}
		GameObject gameObject = this.isHolding1;
		GameObject gameObject2 = this.isHolding2;
		if (this.isHolding3 != null)
		{
			GameObject gameObject3 = this.isHolding3;
			this.isHolding1 = gameObject2;
			this.isHolding2 = gameObject3;
			this.isHolding3 = gameObject;
			this.isHolding1.transform.parent = this.holdingParent1;
			this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding2.transform.parent = this.holdingParent2;
			this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
			if (this.isHolding1.GetComponent<EngineComponentC>())
			{
				this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
			}
			this.ResetItemSway();
			if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
			{
				this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
			}
			return;
		}
		this.isHolding1 = gameObject2;
		this.isHolding2 = gameObject;
		this.isHolding1.transform.parent = this.holdingParent1;
		this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
		if (this.isHolding1.GetComponent<EngineComponentC>())
		{
			this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
		}
		this.ResetItemSway();
		if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
		{
			this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
		}
		this.isHolding1.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot1");
		if (this.isHolding2 != null)
		{
			this.isHolding2.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot2");
		}
		if (this.isHolding3 != null)
		{
			this.isHolding3.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot3");
		}
	}

	// Token: 0x06000575 RID: 1397 RVA: 0x00060ED4 File Offset: 0x0005F2D4
	public void MoveItemsRight()
	{
		if (this.isHolding2 == null)
		{
			return;
		}
		GameObject gameObject = this.isHolding1;
		GameObject gameObject2 = this.isHolding2;
		if (this.isHolding3 != null)
		{
			GameObject gameObject3 = this.isHolding3;
			this.isHolding1 = gameObject2;
			this.isHolding2 = gameObject3;
			this.isHolding3 = gameObject;
			this.isHolding1.transform.parent = this.holdingParent1;
			this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding2.transform.parent = this.holdingParent2;
			this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding3.transform.parent = this.holdingParent3;
			this.isHolding3.transform.localPosition = this.isHolding3.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
			if (this.isHolding1.GetComponent<EngineComponentC>())
			{
				this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
			}
			this.ResetItemSway();
			if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
			{
				this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
			}
			return;
		}
		this.isHolding1 = gameObject2;
		this.isHolding2 = gameObject;
		this.isHolding1.transform.parent = this.holdingParent1;
		this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding2.transform.parent = this.holdingParent2;
		this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
		if (this.isHolding1.GetComponent<EngineComponentC>())
		{
			this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
		}
		this.ResetItemSway();
		if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
		{
			this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
		}
		this.isHolding1.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot1");
		if (this.isHolding2 != null)
		{
			this.isHolding2.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot2");
		}
		if (this.isHolding3 != null)
		{
			this.isHolding3.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot3");
		}
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x000611B4 File Offset: 0x0005F5B4
	public void MoveItemsLeft()
	{
		if (this.isHolding2 == null)
		{
			return;
		}
		GameObject gameObject = this.isHolding1;
		GameObject gameObject2 = this.isHolding2;
		if (this.isHolding3 != null)
		{
			GameObject gameObject3 = this.isHolding3;
			this.isHolding1 = gameObject3;
			this.isHolding2 = gameObject;
			this.isHolding3 = gameObject2;
			this.isHolding1.transform.parent = this.holdingParent1;
			this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding2.transform.parent = this.holdingParent2;
			this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding3.transform.parent = this.holdingParent3;
			this.isHolding3.transform.localPosition = this.isHolding3.GetComponent<ObjectPickupC>().positionAdjust;
			this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
			if (this.isHolding1.GetComponent<EngineComponentC>())
			{
				this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
			}
			this.ResetItemSway();
			if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
			{
				this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
			}
			return;
		}
		this.isHolding1 = gameObject2;
		this.isHolding2 = gameObject;
		this.isHolding1.transform.parent = this.holdingParent1;
		this.isHolding1.transform.localPosition = this.isHolding1.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding2.transform.parent = this.holdingParent2;
		this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
		this.isHolding1.GetComponent<ObjectPickupC>().RandomAudio();
		if (this.isHolding1.GetComponent<EngineComponentC>())
		{
			this.isHolding1.GetComponent<EngineComponentC>().StartCoroutine("UpdateHands");
		}
		this.ResetItemSway();
		if (this.isHolding1.GetComponent<ExtraComponentC>() && this.isHolding1.GetComponent<ExtraComponentC>().isCustomDecal)
		{
			this.isHolding1.GetComponent<ExtraComponentC>().StartCoroutine("DecalReload");
		}
		this.isHolding1.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot1");
		if (this.isHolding2 != null)
		{
			this.isHolding2.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot2");
		}
		if (this.isHolding3 != null)
		{
			this.isHolding3.GetComponent<ObjectPickupC>().StartCoroutine("MoveToSlot3");
		}
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x00061494 File Offset: 0x0005F894
	public void ConnectedPickup()
	{
		if (this.isHolding2 != null)
		{
			this.isHolding3 = this.isHolding2;
		}
		this.isHolding2 = this.isHolding1;
		this.isHolding1 = null;
		this.isHolding2.transform.parent = this.holdingParent2;
		this.isHolding2.transform.localPosition = this.isHolding2.GetComponent<ObjectPickupC>().positionAdjust;
		if (this.isHolding3 != null)
		{
			this.isHolding3.transform.parent = this.holdingParent3;
			this.isHolding3.transform.localPosition = this.isHolding3.GetComponent<ObjectPickupC>().positionAdjust;
		}
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x0006154E File Offset: 0x0005F94E
	public void UpdateItems1DroppedIntoInventory()
	{
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x00061550 File Offset: 0x0005F950
	public void SetEngineCompUI1()
	{
		if (this.hitComponent == null)
		{
			return;
		}
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		for (int i = 0; i < this.valueUsed.Length; i++)
		{
			this.valueUsed[i] = false;
		}
		this.componentTitles[0].GetComponent<UILabel>().text = string.Empty;
		this.componentTitles[1].GetComponent<UILabel>().text = string.Empty;
		this.componentTitles[2].GetComponent<UILabel>().text = string.Empty;
		this.componentTitles[3].GetComponent<UILabel>().text = string.Empty;
		this.componentTitles[4].GetComponent<UILabel>().text = string.Empty;
		this.componentTitles[5].GetComponent<UILabel>().text = Language.Get((!component2.isPurchased) ? "ui_pickup_15" : "ui_pickup_14", "Inspector_UI") + " : " + component2.sellValue.ToString();
		if (component2.sellValue < component2.originalSellValue * 0.67f && component2.sellValue > 0f)
		{
			this.componentTitles[5].GetComponent<UILabel>().color = this.orange;
		}
		else if (component2.sellValue == 0f)
		{
			this.componentTitles[5].GetComponent<UILabel>().color = this.red;
		}
		else
		{
			this.componentTitles[5].GetComponent<UILabel>().color = this.blue;
		}
		if (this.hitComponent == null)
		{
			return;
		}
		if (!this.hitComponent.GetComponent<EngineComponentC>())
		{
			return;
		}
		this.componentTitles[6].GetComponent<UILabel>().text = string.Concat(new string[]
		{
			Language.Get("ui_pickup_21", "Inspector_UI"),
			" : ",
			Mathf.Round(component.Condition).ToString(),
			"/",
			component.durability.ToString()
		});
		double num = (double)component.durability * 0.34;
		double num2 = (double)component.durability * 0.67;
		if (component.Condition == 0f)
		{
			this.componentTitles[6].GetComponent<UILabel>().color = this.red;
		}
		if ((double)component.Condition < num)
		{
			this.componentTitles[6].GetComponent<UILabel>().color = this.red;
		}
		else if ((double)component.Condition > num && (double)component.Condition < num2)
		{
			this.componentTitles[6].GetComponent<UILabel>().color = this.orange;
		}
		else if ((double)component.Condition > num2)
		{
			this.componentTitles[6].GetComponent<UILabel>().color = this.green;
		}
		this.componentTitles[7].GetComponent<UILabel>().text = Language.Get(component.flavourText, "Inspector_UI");
		this.componentTitles[7].GetComponent<UILabel>().color = this.gray;
		this.componentTitles[8].GetComponent<UILabel>().text = component.uniqueProperty;
		if (component.totalFuelAmount > 0f)
		{
			float f = component.totalFuelAmount;
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				f = component.totalFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
			}
			if (this.hitComponent.transform.parent && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>() && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>().gateDropOff)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = string.Concat(new string[]
				{
					Mathf.Round(component.currentFuelAmount).ToString(),
					" / ",
					component.totalFuelAmount.ToString(),
					" ",
					Language.Get("ui_pickup_22", "Inspector_UI")
				});
				this.valueUsed[0] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				if (component.totalFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_23", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				else if (component.totalFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Round(component.currentFuelAmount).ToString(),
							" / ",
							component.totalFuelAmount.ToString(),
							" ",
							Language.Get("ui_pickup_50", "Inspector_UI")
						});
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_23", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.totalFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component.totalFuelAmount == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_23", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_23", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
				}
			}
			else
			{
				this.componentTitles[0].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_23", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			this.valueUsed[0] = true;
			this.SetEngineCompUI2();
			return;
		}
		else
		{
			if (component.totalFuelAmount > 0f && !component2.isInEngine && !this.valueUsed[17])
			{
				float f2 = component.currentFuelAmount;
				if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
				{
					f2 = component.currentFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount;
					if (component.currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_24", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.red;
					}
					else if (component.currentFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Round(f2).ToString() + " " + Language.Get("ui_pickup_24", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
					}
					else if (component.currentFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						if (component.currentFuelAmount == 0f)
						{
							this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_24", "Inspector_UI");
							this.componentTitles[0].GetComponent<UILabel>().color = this.green;
						}
						else
						{
							this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_24", "Inspector_UI");
							this.componentTitles[0].GetComponent<UILabel>().color = this.green;
						}
					}
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_24", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				}
				this.valueUsed[17] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.totalFuelAmount > 0f && !this.valueUsed[19])
			{
				if (component.fuelMix == 0)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = Language.Get("ui_pickup_25", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				if (component.fuelMix == 1)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = Language.Get("ui_pickup_26", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.orange;
				}
				if (component.fuelMix == 2)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = Language.Get("ui_pickup_27", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				}
				if (component.fuelMix == 3)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = Language.Get("ui_pickup_28", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.orange;
				}
				this.valueUsed[19] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.fuelConsumptionRate > 0f && !this.valueUsed[1])
			{
				float f3 = component.fuelConsumptionRate - this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate;
				if (component.fuelConsumptionRate < this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				else if (component.fuelConsumptionRate == this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = component.fuelConsumptionRate.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.fuelConsumptionRate > this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[1] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.initialFuelConsumptionAmount > 0f)
			{
				float f4 = component.initialFuelConsumptionAmount - this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount;
				if (component.initialFuelConsumptionAmount < this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				}
				else if (component.initialFuelConsumptionAmount == this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = component.initialFuelConsumptionAmount.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.initialFuelConsumptionAmount > this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[2] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.ignitionTimer != 0f)
			{
				float f5 = component.ignitionTimer - this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime;
				if (component.ignitionTimer < this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				}
				else if (component.ignitionTimer == this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = component.ignitionTimer.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.ignitionTimer > this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[3] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.acceleration > 0f)
			{
				float f6 = component.acceleration - this.carLogic.GetComponent<CarPerformanceC>().carAcceleration;
				if (component.acceleration < this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				}
				else if (component.acceleration == this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = component.acceleration.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.acceleration > this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carAcceleration == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[4] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.TopSpeed > 0f)
			{
				float f7 = component.TopSpeed - this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed;
				if (component.TopSpeed < this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				else if (component.TopSpeed == this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = component.TopSpeed.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.TopSpeed > this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[5] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.turnRate > 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				this.valueUsed[6] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.turnRate < 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				this.valueUsed[6] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.roadGrip > 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = (component.roadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_53", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[7] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.wetGrip > 0f && !this.valueUsed[21])
			{
				this.componentTitles[0].GetComponent<UILabel>().text = (component.wetGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_36", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[21] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.offRoadGrip > 0f && !this.valueUsed[22])
			{
				this.componentTitles[0].GetComponent<UILabel>().text = (component.offRoadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_54", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[22] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.compoundType > 0)
			{
				if (component.compoundType == 1)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_37", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 2)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_38", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 3)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_39", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				this.valueUsed[20] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.dirtAccumilation > 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				this.valueUsed[10] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.dirtAccumilation < 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				this.valueUsed[10] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[11])
			{
				float num3 = 0.083f * (float)component.totalWaterCharges;
				float num4 = 0.083f * (float)component.currentWaterCharges;
				float num5 = 0f;
				float num6 = num3 - num5;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num5 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges;
					float num7 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
					num6 = num3 - num5;
				}
				if (num3 < num5)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num6 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				else if (num3 == num5)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString(),
							" / ",
							Mathf.Abs(Mathf.Round(num3 * 10f) / 10f).ToString(),
							" ",
							Language.Get("ui_pickup_42", "Inspector_UI")
						});
					}
					else
					{
						float num8 = Mathf.Round(num6 * 10f) / 10f;
						this.componentTitles[0].GetComponent<UILabel>().text = num8.ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (num3 > num5)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num3 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num6 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[11] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[18])
			{
				float num9 = 0.083f * (float)component.currentWaterCharges;
				float num10 = 0f;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num10 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
				}
				float num11 = num9 - num10;
				if (num9 < num10)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num11 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				else if (num9 == num10)
				{
					float num12 = Mathf.Round(num11 * 10f) / 10f;
					this.componentTitles[0].GetComponent<UILabel>().text = num12.ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (num9 > num10)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num11 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[18] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.storage > 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				this.valueUsed[12] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.storage < 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				this.valueUsed[12] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.damageResistance > 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
				this.valueUsed[13] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.damageResistance < 0f)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				this.valueUsed[13] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.engineWearRate > 0f)
			{
				float num13 = component.engineWearRate - this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate;
				if (component.engineWearRate < this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(num13 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				else if (component.engineWearRate == this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(component.engineWearRate * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = num13.ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.engineWearRate > this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Abs(num13 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(num13 * 100f).ToString() + " " + Language.Get("ui_pickup_47", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[14] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (component.isBattery && !this.valueUsed[16])
			{
				float f8 = 0f;
				float num14 = 0f;
				if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
				{
					f8 = component.charge - this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge;
					num14 = this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge;
				}
				if (this.hitComponent.transform.parent && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>() && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>().gateDropOff)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Round(component.charge).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					this.valueUsed[16] = true;
					this.SetEngineCompUI2();
					return;
				}
				if (component.charge < num14)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					this.componentTitles[0].GetComponent<UILabel>().color = this.red;
				}
				else if (component.charge == num14)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Round(component.charge).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = Mathf.Round(f8).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.charge > num14)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[0].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[16] = true;
				this.SetEngineCompUI2();
				return;
			}
			else
			{
				if (component.weight > 0f)
				{
					this.valueUsed[15] = true;
					this.SetEngineCompUI2();
					this.SetEngineComponentWeight1();
					return;
				}
				return;
			}
		}
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x00063F4C File Offset: 0x0006234C
	public void SetEngineComponentWeight1()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.ignitionTimer != 0f)
		{
			float f = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.acceleration != 0f)
		{
			float f2 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = f2.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.fuelConsumptionRate != 0f)
		{
			float f3 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalFuelAmount != 0f)
		{
			float f4 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.engineWearRate != 0f)
		{
			float f5 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.isBattery)
		{
			float f6 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalWaterCharges != 0)
		{
			float f7 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[0].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[0].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[0].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[0].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[0].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x00064C70 File Offset: 0x00063070
	public void SetEngineComponentWeight2()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.ignitionTimer != 0f)
		{
			float f = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.acceleration != 0f)
		{
			float f2 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = f2.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.fuelConsumptionRate != 0f)
		{
			float f3 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalFuelAmount != 0f)
		{
			float f4 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.engineWearRate != 0f)
		{
			float f5 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.isBattery)
		{
			float f6 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalWaterCharges != 0)
		{
			float f7 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
	}

	// Token: 0x0600057C RID: 1404 RVA: 0x00065994 File Offset: 0x00063D94
	public void SetEngineComponentWeight3()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.ignitionTimer != 0f)
		{
			float f = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.acceleration != 0f)
		{
			float f2 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = f2.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.fuelConsumptionRate != 0f)
		{
			float f3 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalFuelAmount != 0f)
		{
			float f4 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.engineWearRate != 0f)
		{
			float f5 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.isBattery)
		{
			float f6 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalWaterCharges != 0)
		{
			float f7 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x000666B8 File Offset: 0x00064AB8
	public void SetEngineComponentWeight4()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.ignitionTimer != 0f)
		{
			float f = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.acceleration != 0f)
		{
			float f2 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = f2.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.fuelConsumptionRate != 0f)
		{
			float f3 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalFuelAmount != 0f)
		{
			float f4 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.engineWearRate != 0f)
		{
			float f5 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.isBattery)
		{
			float f6 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalWaterCharges != 0)
		{
			float f7 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
	}

	// Token: 0x0600057E RID: 1406 RVA: 0x000673DC File Offset: 0x000657DC
	public void SetEngineComponentWeight5()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.ignitionTimer != 0f)
		{
			float f = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoilWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.acceleration != 0f)
		{
			float f2 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = f2.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedEngineWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f2).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.fuelConsumptionRate != 0f)
		{
			float f3 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedCarburettorWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalFuelAmount != 0f)
		{
			float f4 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTankWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.engineWearRate != 0f)
		{
			float f5 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedAirFilterWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.isBattery)
		{
			float f6 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedBatteryWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
		if (component.totalWaterCharges != 0)
		{
			float f7 = component.weight - this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight;
			if (component.weight < this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			else if (component.weight == this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				if (component2.isInEngine)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = component.weight.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				}
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
			}
			else if (component.weight > this.carLogic.GetComponent<CarPerformanceC>().installedWaterTankWeight)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_49", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
			}
			return;
		}
	}

	// Token: 0x0600057F RID: 1407 RVA: 0x00068100 File Offset: 0x00066500
	public void SetEngineCompUI2()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.totalFuelAmount > 0f && !this.valueUsed[0] && component.totalFuelAmount > 0f)
		{
			float f = component.totalFuelAmount;
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				f = component.totalFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
			}
			if (this.hitComponent.transform.parent && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>() && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>().gateDropOff)
			{
				this.componentTitles[1].GetComponent<UILabel>().text = string.Concat(new string[]
				{
					Mathf.Round(component.currentFuelAmount).ToString(),
					" / ",
					component.totalFuelAmount.ToString(),
					" ",
					Language.Get("ui_pickup_50", "Inspector_UI")
				});
				this.valueUsed[0] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				if (component.totalFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				else if (component.totalFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Round(component.currentFuelAmount).ToString(),
							" / ",
							component.totalFuelAmount.ToString(),
							" ",
							Language.Get("ui_pickup_50", "Inspector_UI")
						});
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.totalFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component.totalFuelAmount == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
				}
			}
			else
			{
				this.componentTitles[1].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
			}
			this.valueUsed[0] = true;
			this.SetEngineCompUI3();
			return;
		}
		else
		{
			if (component.totalFuelAmount > 0f && !component2.isInEngine && !this.valueUsed[17])
			{
				float f2 = component.currentFuelAmount;
				if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
				{
					f2 = component.currentFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount;
					if (component.currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.red;
					}
					else if (component.currentFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Round(f2).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
					}
					else if (component.currentFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						if (component.currentFuelAmount == 0f)
						{
							this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[1].GetComponent<UILabel>().color = this.green;
						}
						else
						{
							this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[1].GetComponent<UILabel>().color = this.green;
						}
					}
				}
				else
				{
					this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				}
				this.valueUsed[17] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.totalFuelAmount > 0f && !this.valueUsed[19])
			{
				if (component.fuelMix == 0)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = Language.Get("ui_pickup_25", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				if (component.fuelMix == 1)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = Language.Get("ui_pickup_26", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.orange;
				}
				if (component.fuelMix == 2)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = Language.Get("ui_pickup_27", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				}
				if (component.fuelMix == 3)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = Language.Get("ui_pickup_28", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.orange;
				}
				this.valueUsed[19] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.fuelConsumptionRate > 0f && !this.valueUsed[1])
			{
				float f3 = component.fuelConsumptionRate - this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate;
				if (component.fuelConsumptionRate < this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				else if (component.fuelConsumptionRate == this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = component.fuelConsumptionRate.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.fuelConsumptionRate > this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[1] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.initialFuelConsumptionAmount > 0f && !this.valueUsed[2])
			{
				float f4 = component.initialFuelConsumptionAmount - this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount;
				if (component.initialFuelConsumptionAmount < this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				}
				else if (component.initialFuelConsumptionAmount == this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = component.initialFuelConsumptionAmount.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.initialFuelConsumptionAmount > this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[2] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.ignitionTimer != 0f && !this.valueUsed[3])
			{
				float f5 = component.ignitionTimer - this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime;
				if (component.ignitionTimer < this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				}
				else if (component.ignitionTimer == this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = component.ignitionTimer.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.ignitionTimer > this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[3] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.acceleration > 0f && !this.valueUsed[4])
			{
				float f6 = component.acceleration - this.carLogic.GetComponent<CarPerformanceC>().carAcceleration;
				if (component.acceleration < this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				}
				else if (component.acceleration == this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = component.acceleration.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.acceleration > this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carAcceleration == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[4] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.TopSpeed > 0f && !this.valueUsed[5])
			{
				float f7 = component.TopSpeed - this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed;
				if (component.TopSpeed < this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				else if (component.TopSpeed == this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = component.TopSpeed.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.TopSpeed > this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[5] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.turnRate > 0f && !this.valueUsed[6])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				this.valueUsed[6] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.turnRate < 0f && !this.valueUsed[6])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				this.valueUsed[6] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.roadGrip > 0f && !this.valueUsed[7])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = (component.roadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_53", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[7] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.wetGrip > 0f && !this.valueUsed[21])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = (component.wetGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_36", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[21] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.offRoadGrip > 0f && !this.valueUsed[22])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = (component.offRoadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_54", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[22] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.compoundType > 0 && !this.valueUsed[20])
			{
				if (component.compoundType == 1)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_37", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 2)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_38", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 3)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_39", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				this.valueUsed[20] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.dirtAccumilation > 0f && !this.valueUsed[10])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				this.valueUsed[10] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.dirtAccumilation < 0f && !this.valueUsed[10])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				this.valueUsed[10] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[11])
			{
				float num = 0.083f * (float)component.totalWaterCharges;
				float num2 = 0.083f * (float)component.currentWaterCharges;
				float num3 = 0f;
				float num4 = num - num3;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num3 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges;
					float num5 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
					num4 = num - num3;
				}
				if (num < num3)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				else if (num == num3)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Abs(Mathf.Round(num2 * 10f) / 10f).ToString(),
							" / ",
							Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString(),
							" ",
							Language.Get("ui_pickup_42", "Inspector_UI")
						});
					}
					else
					{
						float num6 = Mathf.Round(num4 * 10f) / 10f;
						this.componentTitles[1].GetComponent<UILabel>().text = num6.ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (num > num3)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[11] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[18])
			{
				float num7 = 0.083f * (float)component.currentWaterCharges;
				float num8 = 0f;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num8 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
				}
				float num9 = num7 - num8;
				if (num7 < num8)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				else if (num7 == num8)
				{
					float num10 = Mathf.Round(num9 * 10f) / 10f;
					this.componentTitles[1].GetComponent<UILabel>().text = num10.ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (num7 > num8)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num7 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[18] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.storage > 0f && !this.valueUsed[12])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				this.valueUsed[12] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.storage < 0f && !this.valueUsed[12])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				this.valueUsed[12] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.damageResistance > 0f && !this.valueUsed[13])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "+ " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.green;
				this.valueUsed[13] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.damageResistance < 0f && !this.valueUsed[13])
			{
				this.componentTitles[1].GetComponent<UILabel>().text = "- " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				this.valueUsed[13] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.engineWearRate > 0f && !this.valueUsed[14])
			{
				float num11 = component.engineWearRate - this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate;
				if (component.engineWearRate < this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				else if (component.engineWearRate == this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(component.engineWearRate * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = num11.ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.engineWearRate > this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_47", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[14] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.isBattery && !this.valueUsed[16])
			{
				float f8 = 0f;
				float num12 = 0f;
				if (this.carLogic.GetComponent<CarPerformanceC>().installedBattery != null)
				{
					f8 = component.charge - this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge;
					num12 = this.carLogic.GetComponent<CarPerformanceC>().installedBattery.GetComponent<EngineComponentC>().charge;
				}
				if (component.charge < num12)
				{
					this.componentTitles[1].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					this.componentTitles[1].GetComponent<UILabel>().color = this.red;
				}
				else if (component.charge == num12)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Round(component.charge).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Round(f8).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					this.componentTitles[1].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.charge > num12)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[1].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[1].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[1].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[16] = true;
				this.SetEngineCompUI3();
				return;
			}
			if (component.weight > 0f && !this.valueUsed[15])
			{
				this.valueUsed[15] = true;
				this.SetEngineCompUI3();
				this.SetEngineComponentWeight2();
				return;
			}
			return;
		}
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x0006A7F8 File Offset: 0x00068BF8
	public void SetEngineCompUI3()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.totalFuelAmount > 0f && !this.valueUsed[0] && component.totalFuelAmount > 0f)
		{
			float f = component.totalFuelAmount;
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				f = component.totalFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
			}
			if (this.hitComponent.transform.parent && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>() && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>().gateDropOff)
			{
				this.componentTitles[2].GetComponent<UILabel>().text = string.Concat(new string[]
				{
					Mathf.Round(component.currentFuelAmount).ToString(),
					" / ",
					component.totalFuelAmount.ToString(),
					" ",
					Language.Get("ui_pickup_50", "Inspector_UI")
				});
				this.valueUsed[0] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				if (component.totalFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				else if (component.totalFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Round(component.currentFuelAmount).ToString(),
							" / ",
							component.totalFuelAmount.ToString(),
							" ",
							Language.Get("ui_pickup_50", "Inspector_UI")
						});
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.totalFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component.totalFuelAmount == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
				}
			}
			else
			{
				this.componentTitles[2].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
			}
			this.valueUsed[0] = true;
			this.SetEngineCompUI4();
			return;
		}
		else
		{
			if (component.totalFuelAmount > 0f && !component2.isInEngine && !this.valueUsed[17])
			{
				float f2 = component.currentFuelAmount;
				if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
				{
					f2 = component.currentFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount;
					if (component.currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.red;
					}
					else if (component.currentFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Round(f2).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
					}
					else if (component.currentFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						if (component.currentFuelAmount == 0f)
						{
							this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[2].GetComponent<UILabel>().color = this.green;
						}
						else
						{
							this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[2].GetComponent<UILabel>().color = this.green;
						}
					}
				}
				else
				{
					this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				}
				this.valueUsed[17] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.totalFuelAmount > 0f && !this.valueUsed[19])
			{
				if (component.fuelMix == 0)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = Language.Get("ui_pickup_25", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				if (component.fuelMix == 1)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = Language.Get("ui_pickup_26", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.orange;
				}
				if (component.fuelMix == 2)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = Language.Get("ui_pickup_27", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				}
				if (component.fuelMix == 3)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = Language.Get("ui_pickup_28", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.orange;
				}
				this.valueUsed[19] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.fuelConsumptionRate > 0f && !this.valueUsed[1])
			{
				float f3 = component.fuelConsumptionRate - this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate;
				if (component.fuelConsumptionRate < this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				else if (component.fuelConsumptionRate == this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = component.fuelConsumptionRate.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.fuelConsumptionRate > this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[1] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.initialFuelConsumptionAmount > 0f && !this.valueUsed[2])
			{
				float f4 = component.initialFuelConsumptionAmount - this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount;
				if (component.initialFuelConsumptionAmount < this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				}
				else if (component.initialFuelConsumptionAmount == this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = component.initialFuelConsumptionAmount.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.initialFuelConsumptionAmount > this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[2] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.ignitionTimer != 0f && !this.valueUsed[3])
			{
				float f5 = component.ignitionTimer - this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime;
				if (component.ignitionTimer < this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				}
				else if (component.ignitionTimer == this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = component.ignitionTimer.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.ignitionTimer > this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[3] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.acceleration > 0f && !this.valueUsed[4])
			{
				float f6 = component.acceleration - this.carLogic.GetComponent<CarPerformanceC>().carAcceleration;
				if (component.acceleration < this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				}
				else if (component.acceleration == this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = component.acceleration.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.acceleration > this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carAcceleration == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[4] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.TopSpeed > 0f && !this.valueUsed[5])
			{
				float f7 = component.TopSpeed - this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed;
				if (component.TopSpeed < this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				else if (component.TopSpeed == this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = component.TopSpeed.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.TopSpeed > this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[5] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.turnRate > 0f && !this.valueUsed[6])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				this.valueUsed[6] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.turnRate < 0f && !this.valueUsed[6])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				this.valueUsed[6] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.roadGrip > 0f && !this.valueUsed[7])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = (component.roadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_53", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[7] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.wetGrip > 0f && !this.valueUsed[21])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = (component.wetGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_36", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[21] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.offRoadGrip > 0f && !this.valueUsed[22])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = (component.offRoadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_54", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[22] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.compoundType > 0 && !this.valueUsed[20])
			{
				if (component.compoundType == 1)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_37", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 2)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_38", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 3)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_39", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				this.valueUsed[20] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.dirtAccumilation > 0f && !this.valueUsed[10])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				this.valueUsed[10] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.dirtAccumilation < 0f && !this.valueUsed[10])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				this.valueUsed[10] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[11])
			{
				float num = 0.083f * (float)component.totalWaterCharges;
				float num2 = 0.083f * (float)component.currentWaterCharges;
				float num3 = 0f;
				float num4 = num - num3;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num3 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges;
					float num5 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
					num4 = num - num3;
				}
				if (num < num3)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				else if (num == num3)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Abs(Mathf.Round(num2 * 10f) / 10f).ToString(),
							" / ",
							Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString(),
							" ",
							Language.Get("ui_pickup_42", "Inspector_UI")
						});
					}
					else
					{
						float num6 = Mathf.Round(num4 * 10f) / 10f;
						this.componentTitles[2].GetComponent<UILabel>().text = num6.ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (num > num3)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[11] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[18])
			{
				float num7 = 0.083f * (float)component.currentWaterCharges;
				float num8 = 0f;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num8 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
				}
				float num9 = num7 - num8;
				if (num7 < num8)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				else if (num7 == num8)
				{
					float num10 = Mathf.Round(num9 * 10f) / 10f;
					this.componentTitles[2].GetComponent<UILabel>().text = num10.ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (num7 > num8)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num7 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[18] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.storage > 0f && !this.valueUsed[12])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				this.valueUsed[12] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.storage < 0f && !this.valueUsed[12])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				this.valueUsed[12] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.damageResistance > 0f && !this.valueUsed[13])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "+ " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.green;
				this.valueUsed[13] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.damageResistance < 0f && !this.valueUsed[13])
			{
				this.componentTitles[2].GetComponent<UILabel>().text = "- " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				this.valueUsed[13] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.engineWearRate > 0f && !this.valueUsed[14])
			{
				float num11 = component.engineWearRate - this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate;
				if (component.engineWearRate < this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				else if (component.engineWearRate == this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(component.engineWearRate * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = num11.ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.engineWearRate > this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_47", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[14] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.isBattery && !this.valueUsed[16])
			{
				float f8 = component.charge - this.carLogic.GetComponent<CarPerformanceC>().carCharge;
				if (component.charge < this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					this.componentTitles[2].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					this.componentTitles[2].GetComponent<UILabel>().color = this.red;
				}
				else if (component.charge == this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Round(component.charge).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Round(f8).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					this.componentTitles[2].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.charge > this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[2].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[2].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[2].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[16] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.weight > 0f && !this.valueUsed[15])
			{
				this.valueUsed[15] = true;
				this.SetEngineCompUI4();
				this.SetEngineComponentWeight3();
				return;
			}
			return;
		}
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x0006CECC File Offset: 0x0006B2CC
	public void SetEngineCompUI4()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.totalFuelAmount > 0f && !this.valueUsed[0] && component.totalFuelAmount > 0f)
		{
			float f = component.totalFuelAmount;
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				f = component.totalFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
			}
			if (this.hitComponent.transform.parent && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>() && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>().gateDropOff)
			{
				this.componentTitles[3].GetComponent<UILabel>().text = string.Concat(new string[]
				{
					Mathf.Round(component.currentFuelAmount).ToString(),
					" / ",
					component.totalFuelAmount.ToString(),
					" ",
					Language.Get("ui_pickup_50", "Inspector_UI")
				});
				this.valueUsed[0] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				if (component.totalFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				else if (component.totalFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Round(component.currentFuelAmount).ToString(),
							" / ",
							component.totalFuelAmount.ToString(),
							" ",
							Language.Get("ui_pickup_50", "Inspector_UI")
						});
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.totalFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component.totalFuelAmount == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
				}
			}
			else
			{
				this.componentTitles[3].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
			}
			this.valueUsed[0] = true;
			this.SetEngineCompUI5();
			return;
		}
		else
		{
			if (component.totalFuelAmount > 0f && !component2.isInEngine && !this.valueUsed[17])
			{
				float f2 = component.currentFuelAmount;
				if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
				{
					f2 = component.currentFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount;
					if (component.currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.red;
					}
					else if (component.currentFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Round(f2).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
					}
					else if (component.currentFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						if (component.currentFuelAmount == 0f)
						{
							this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[3].GetComponent<UILabel>().color = this.green;
						}
						else
						{
							this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[3].GetComponent<UILabel>().color = this.green;
						}
					}
				}
				else
				{
					this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				}
				this.valueUsed[17] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.totalFuelAmount > 0f && !this.valueUsed[19])
			{
				if (component.fuelMix == 0)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = Language.Get("ui_pickup_25", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				if (component.fuelMix == 1)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = Language.Get("ui_pickup_26", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.orange;
				}
				if (component.fuelMix == 2)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = Language.Get("ui_pickup_27", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				}
				if (component.fuelMix == 3)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = Language.Get("ui_pickup_28", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.orange;
				}
				this.valueUsed[19] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.fuelConsumptionRate > 0f && !this.valueUsed[1])
			{
				float f3 = component.fuelConsumptionRate - this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate;
				if (component.fuelConsumptionRate < this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				else if (component.fuelConsumptionRate == this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = component.fuelConsumptionRate.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.fuelConsumptionRate > this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[1] = true;
				this.SetEngineCompUI4();
				return;
			}
			if (component.initialFuelConsumptionAmount > 0f && !this.valueUsed[2])
			{
				float f4 = component.initialFuelConsumptionAmount - this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount;
				if (component.initialFuelConsumptionAmount < this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				}
				else if (component.initialFuelConsumptionAmount == this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = component.initialFuelConsumptionAmount.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.initialFuelConsumptionAmount > this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[2] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.ignitionTimer != 0f && !this.valueUsed[3])
			{
				float f5 = component.ignitionTimer - this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime;
				if (component.ignitionTimer < this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				}
				else if (component.ignitionTimer == this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = component.ignitionTimer.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.ignitionTimer > this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[3] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.acceleration > 0f && !this.valueUsed[4])
			{
				float f6 = component.acceleration - this.carLogic.GetComponent<CarPerformanceC>().carAcceleration;
				if (component.acceleration < this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				}
				else if (component.acceleration == this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = component.acceleration.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.acceleration > this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carAcceleration == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[4] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.TopSpeed > 0f && !this.valueUsed[5])
			{
				float f7 = component.TopSpeed - this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed;
				if (component.TopSpeed < this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				else if (component.TopSpeed == this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = component.TopSpeed.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.TopSpeed > this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[5] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.turnRate > 0f && !this.valueUsed[6])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				this.valueUsed[6] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.turnRate < 0f && !this.valueUsed[6])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				this.valueUsed[6] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.roadGrip > 0f && !this.valueUsed[7])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = (component.roadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_53", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[7] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.wetGrip > 0f && !this.valueUsed[21])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = (component.wetGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_36", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[21] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.offRoadGrip > 0f && !this.valueUsed[22])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = (component.offRoadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_54", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[22] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.compoundType > 0 && !this.valueUsed[20])
			{
				if (component.compoundType == 1)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_37", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 2)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_38", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 3)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_39", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				this.valueUsed[20] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.dirtAccumilation > 0f && !this.valueUsed[10])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				this.valueUsed[10] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.dirtAccumilation < 0f && !this.valueUsed[10])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				this.valueUsed[10] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[11])
			{
				float num = 0.083f * (float)component.totalWaterCharges;
				float num2 = 0.083f * (float)component.currentWaterCharges;
				float num3 = 0f;
				float num4 = num - num3;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num3 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges;
					float num5 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
					num4 = num - num3;
				}
				if (num < num3)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				else if (num == num3)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Abs(Mathf.Round(num2 * 10f) / 10f).ToString(),
							" / ",
							Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString(),
							" ",
							Language.Get("ui_pickup_42", "Inspector_UI")
						});
					}
					else
					{
						float num6 = Mathf.Round(num4 * 10f) / 10f;
						this.componentTitles[3].GetComponent<UILabel>().text = num6.ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (num > num3)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[11] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[18])
			{
				float num7 = 0.083f * (float)component.currentWaterCharges;
				float num8 = 0f;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num8 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
				}
				float num9 = num7 - num8;
				if (num7 < num8)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				else if (num7 == num8)
				{
					float num10 = Mathf.Round(num9 * 10f) / 10f;
					this.componentTitles[3].GetComponent<UILabel>().text = num10.ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (num7 > num8)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num7 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[18] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.storage > 0f && !this.valueUsed[12])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				this.valueUsed[12] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.storage < 0f && !this.valueUsed[12])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				this.valueUsed[12] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.damageResistance > 0f && !this.valueUsed[13])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "+ " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.green;
				this.valueUsed[13] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.damageResistance < 0f && !this.valueUsed[13])
			{
				this.componentTitles[3].GetComponent<UILabel>().text = "- " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				this.valueUsed[13] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.engineWearRate > 0f && !this.valueUsed[14])
			{
				float num11 = component.engineWearRate - this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate;
				if (component.engineWearRate < this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				else if (component.engineWearRate == this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(component.engineWearRate * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = num11.ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.engineWearRate > this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_47", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[14] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.isBattery && !this.valueUsed[16])
			{
				float f8 = component.charge - this.carLogic.GetComponent<CarPerformanceC>().carCharge;
				if (component.charge < this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					this.componentTitles[3].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					this.componentTitles[3].GetComponent<UILabel>().color = this.red;
				}
				else if (component.charge == this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Round(component.charge).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Round(f8).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					this.componentTitles[3].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.charge > this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[3].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[3].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[3].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[16] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.weight > 0f && !this.valueUsed[15])
			{
				this.valueUsed[15] = true;
				this.SetEngineCompUI5();
				this.SetEngineComponentWeight4();
				return;
			}
			return;
		}
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x0006F5A0 File Offset: 0x0006D9A0
	public void SetEngineCompUI5()
	{
		EngineComponentC component = this.hitComponent.GetComponent<EngineComponentC>();
		ObjectPickupC component2 = this.hitComponent.GetComponent<ObjectPickupC>();
		if (component.totalFuelAmount > 0f && !this.valueUsed[0] && component.totalFuelAmount > 0f)
		{
			float f = component.totalFuelAmount;
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				f = component.totalFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount;
			}
			if (this.hitComponent.transform.parent && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>() && this.hitComponent.transform.parent.GetComponent<HoldingLogicC>().gateDropOff)
			{
				this.componentTitles[4].GetComponent<UILabel>().text = string.Concat(new string[]
				{
					Mathf.Round(component.currentFuelAmount).ToString(),
					" / ",
					component.totalFuelAmount.ToString(),
					" ",
					Language.Get("ui_pickup_50", "Inspector_UI")
				});
				this.valueUsed[0] = true;
				this.SetEngineCompUI2();
				return;
			}
			if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
			{
				if (component.totalFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				else if (component.totalFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Round(component.currentFuelAmount).ToString(),
							" / ",
							component.totalFuelAmount.ToString(),
							" ",
							Language.Get("ui_pickup_50", "Inspector_UI")
						});
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.totalFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().totalFuelAmount)
				{
					if (component.totalFuelAmount == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f).ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
				}
			}
			else
			{
				this.componentTitles[4].GetComponent<UILabel>().text = f.ToString() + " " + Language.Get("ui_pickup_51", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
			}
			this.valueUsed[0] = true;
			return;
		}
		else
		{
			if (component.totalFuelAmount > 0f && !component2.isInEngine && !this.valueUsed[17])
			{
				float f2 = component.currentFuelAmount;
				if (this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank != null)
				{
					f2 = component.currentFuelAmount - this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount;
					if (component.currentFuelAmount < this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.red;
					}
					else if (component.currentFuelAmount == this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Round(f2).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
					}
					else if (component.currentFuelAmount > this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank.GetComponent<EngineComponentC>().currentFuelAmount)
					{
						if (component.currentFuelAmount == 0f)
						{
							this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[4].GetComponent<UILabel>().color = this.green;
						}
						else
						{
							this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
							this.componentTitles[4].GetComponent<UILabel>().color = this.green;
						}
					}
				}
				else
				{
					this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f2)).ToString() + " " + Language.Get("ui_pickup_52", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				}
				this.valueUsed[17] = true;
				return;
			}
			if (component.totalFuelAmount > 0f && !this.valueUsed[19])
			{
				if (component.fuelMix == 0)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = Language.Get("ui_pickup_25", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				if (component.fuelMix == 1)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = Language.Get("ui_pickup_26", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.orange;
				}
				if (component.fuelMix == 2)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = Language.Get("ui_pickup_27", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				}
				if (component.fuelMix == 3)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = Language.Get("ui_pickup_28", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.orange;
				}
				this.valueUsed[19] = true;
				return;
			}
			if (component.fuelConsumptionRate > 0f && !this.valueUsed[1])
			{
				float f3 = component.fuelConsumptionRate - this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate;
				if (component.fuelConsumptionRate < this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				else if (component.fuelConsumptionRate == this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = component.fuelConsumptionRate.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = f3.ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.fuelConsumptionRate > this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carFuelConsumptionRate == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f3).ToString() + " " + Language.Get("ui_pickup_30", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[1] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.initialFuelConsumptionAmount > 0f && !this.valueUsed[2])
			{
				float f4 = component.initialFuelConsumptionAmount - this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount;
				if (component.initialFuelConsumptionAmount < this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				}
				else if (component.initialFuelConsumptionAmount == this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = component.initialFuelConsumptionAmount.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = f4.ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.initialFuelConsumptionAmount > this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carInitialFuelConsumptionAmount == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f4).ToString() + " " + Language.Get("ui_pickup_31", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[2] = true;
				return;
			}
			if (component.ignitionTimer != 0f && !this.valueUsed[3])
			{
				float f5 = component.ignitionTimer - this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime;
				if (component.ignitionTimer < this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				}
				else if (component.ignitionTimer == this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = component.ignitionTimer.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = f5.ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.ignitionTimer > this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carIgnitionTime == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f5).ToString() + " " + Language.Get("ui_pickup_32", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[3] = true;
				return;
			}
			if (component.acceleration > 0f && !this.valueUsed[4])
			{
				float f6 = component.acceleration - this.carLogic.GetComponent<CarPerformanceC>().carAcceleration;
				if (component.acceleration < this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				}
				else if (component.acceleration == this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = component.acceleration.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = f6.ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.acceleration > this.carLogic.GetComponent<CarPerformanceC>().carAcceleration)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carAcceleration == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f6).ToString() + " " + Language.Get("ui_pickup_33", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.red;
					}
				}
				this.valueUsed[4] = true;
				this.SetEngineCompUI5();
				return;
			}
			if (component.TopSpeed > 0f && !this.valueUsed[5])
			{
				float f7 = component.TopSpeed - this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed;
				if (component.TopSpeed < this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				else if (component.TopSpeed == this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = component.TopSpeed.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = f7.ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.TopSpeed > this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carTopSpeed == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(f7).ToString() + " " + Language.Get("ui_pickup_34", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[5] = true;
				return;
			}
			if (component.turnRate > 0f && !this.valueUsed[6])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				this.valueUsed[6] = true;
				return;
			}
			if (component.turnRate < 0f && !this.valueUsed[6])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + component.turnRate.ToString() + " " + Language.Get("ui_pickup_35", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				this.valueUsed[6] = true;
				return;
			}
			if (component.roadGrip > 0f && !this.valueUsed[7])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = (component.roadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_53", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[7] = true;
				return;
			}
			if (component.wetGrip > 0f && !this.valueUsed[21])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = (component.wetGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_36", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[21] = true;
				return;
			}
			if (component.offRoadGrip > 0f && !this.valueUsed[22])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = (component.offRoadGrip / 0.0044f).ToString("F0") + " " + Language.Get("ui_pickup_54", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				this.valueUsed[22] = true;
				return;
			}
			if (component.compoundType > 0 && !this.valueUsed[20])
			{
				if (component.compoundType == 1)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_37", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 2)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_38", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.compoundType == 3)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = " " + Language.Get("ui_pickup_39", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				this.valueUsed[20] = true;
				return;
			}
			if (component.dirtAccumilation > 0f && !this.valueUsed[10])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				this.valueUsed[10] = true;
				return;
			}
			if (component.dirtAccumilation < 0f && !this.valueUsed[10])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + component.dirtAccumilation.ToString() + " " + Language.Get("ui_pickup_40", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				this.valueUsed[10] = true;
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[11])
			{
				float num = 0.083f * (float)component.totalWaterCharges;
				float num2 = 0.083f * (float)component.currentWaterCharges;
				float num3 = 0f;
				float num4 = num - num3;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num3 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges;
					float num5 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
					num4 = num - num3;
				}
				if (num < num3)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				else if (num == num3)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = string.Concat(new string[]
						{
							Mathf.Abs(Mathf.Round(num2 * 10f) / 10f).ToString(),
							" / ",
							Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString(),
							" ",
							Language.Get("ui_pickup_42", "Inspector_UI")
						});
					}
					else
					{
						float num6 = Mathf.Round(num4 * 10f) / 10f;
						this.componentTitles[4].GetComponent<UILabel>().text = num6.ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (num > num3)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num4 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_41", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[11] = true;
				return;
			}
			if (component.totalWaterCharges > 0 && !this.valueUsed[18])
			{
				float num7 = 0.083f * (float)component.currentWaterCharges;
				float num8 = 0f;
				if (this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null)
				{
					num8 = 0.083f * (float)this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges;
				}
				float num9 = num7 - num8;
				if (num7 < num8)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				else if (num7 == num8)
				{
					float num10 = Mathf.Round(num9 * 10f) / 10f;
					this.componentTitles[4].GetComponent<UILabel>().text = num10.ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (num7 > num8)
				{
					if (component.totalWaterCharges == 0)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(num7 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(num9 * 10f) / 10f).ToString() + " " + Language.Get("ui_pickup_43", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[18] = true;
				return;
			}
			if (component.storage > 0f && !this.valueUsed[12])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				this.valueUsed[12] = true;
				return;
			}
			if (component.storage < 0f && !this.valueUsed[12])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + component.storage.ToString() + " " + Language.Get("ui_pickup_44", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				this.valueUsed[12] = true;
				return;
			}
			if (component.damageResistance > 0f && !this.valueUsed[13])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "+ " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.green;
				this.valueUsed[13] = true;
				return;
			}
			if (component.damageResistance < 0f && !this.valueUsed[13])
			{
				this.componentTitles[4].GetComponent<UILabel>().text = "- " + component.damageResistance.ToString() + " " + Language.Get("ui_pickup_45", "Inspector_UI");
				this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				this.valueUsed[13] = true;
				return;
			}
			if (component.engineWearRate > 0f && !this.valueUsed[14])
			{
				float num11 = component.engineWearRate - this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate;
				if (component.engineWearRate < this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				else if (component.engineWearRate == this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(component.engineWearRate * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = num11.ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.engineWearRate > this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_46", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(num11 * 100f).ToString() + " " + Language.Get("ui_pickup_47", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[14] = true;
				return;
			}
			if (component.isBattery && !this.valueUsed[16])
			{
				float f8 = component.charge - this.carLogic.GetComponent<CarPerformanceC>().carCharge;
				if (component.charge < this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					this.componentTitles[4].GetComponent<UILabel>().text = "- " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					this.componentTitles[4].GetComponent<UILabel>().color = this.red;
				}
				else if (component.charge == this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					if (component2.isInEngine)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Round(component.charge).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Round(f8).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
					}
					this.componentTitles[4].GetComponent<UILabel>().color = this.blue;
				}
				else if (component.charge > this.carLogic.GetComponent<CarPerformanceC>().carCharge)
				{
					if (this.carLogic.GetComponent<CarPerformanceC>().carEngineWearRate == 0f)
					{
						this.componentTitles[4].GetComponent<UILabel>().text = Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
					else
					{
						this.componentTitles[4].GetComponent<UILabel>().text = "+ " + Mathf.Abs(Mathf.Round(f8)).ToString() + " " + Language.Get("ui_pickup_48", "Inspector_UI");
						this.componentTitles[4].GetComponent<UILabel>().color = this.green;
					}
				}
				this.valueUsed[16] = true;
				return;
			}
			if (component.weight > 0f && !this.valueUsed[15])
			{
				this.valueUsed[15] = true;
				this.SetEngineComponentWeight5();
				return;
			}
			return;
		}
	}

	// Token: 0x040007E4 RID: 2020
	public static DragRigidbodyC Global;

	// Token: 0x040007E5 RID: 2021
	public LayerMask myLayerMask;

	// Token: 0x040007E6 RID: 2022
	public LayerMask prevLayers;

	// Token: 0x040007E7 RID: 2023
	private GameObject _camera;

	// Token: 0x040007E8 RID: 2024
	public GameObject carLogic;

	// Token: 0x040007E9 RID: 2025
	public bool onlyInteractWithPickUpLayer;

	// Token: 0x040007EA RID: 2026
	public bool inputRestrict;

	// Token: 0x040007EB RID: 2027
	public bool inputRestrictDropPress;

	// Token: 0x040007EC RID: 2028
	public AudioClip pushAudio;

	// Token: 0x040007ED RID: 2029
	public GameObject pushParticle;

	// Token: 0x040007EE RID: 2030
	public Vector3 pushDir;

	// Token: 0x040007EF RID: 2031
	public float pushPower = 500f;

	// Token: 0x040007F0 RID: 2032
	public float spring = 50f;

	// Token: 0x040007F1 RID: 2033
	public float damper = 5f;

	// Token: 0x040007F2 RID: 2034
	public float drag = 10f;

	// Token: 0x040007F3 RID: 2035
	public float angularDrag = 5f;

	// Token: 0x040007F4 RID: 2036
	public float distance = 0.2f;

	// Token: 0x040007F5 RID: 2037
	public bool attachToCenterOfMass;

	// Token: 0x040007F6 RID: 2038
	public float maxRayDistance = 4.25f;

	// Token: 0x040007F7 RID: 2039
	public GameObject[] cursors = new GameObject[2];

	// Token: 0x040007F8 RID: 2040
	private bool useAnimPlay;

	// Token: 0x040007F9 RID: 2041
	private SpringJoint springJoint;

	// Token: 0x040007FA RID: 2042
	public bool isDriving;

	// Token: 0x040007FB RID: 2043
	public AudioClip errorAudio;

	// Token: 0x040007FC RID: 2044
	public GameObject isHolding1;

	// Token: 0x040007FD RID: 2045
	public GameObject isHolding2;

	// Token: 0x040007FE RID: 2046
	public GameObject isHolding3;

	// Token: 0x040007FF RID: 2047
	public Transform holdingParent1;

	// Token: 0x04000800 RID: 2048
	public Transform holdingParent2;

	// Token: 0x04000801 RID: 2049
	public Transform holdingParent3;

	// Token: 0x04000802 RID: 2050
	public float throwPower;

	// Token: 0x04000803 RID: 2051
	public GameObject lastHitCarInteractor;

	// Token: 0x04000804 RID: 2052
	public bool pickingUp;

	// Token: 0x04000805 RID: 2053
	public GameObject componentUI;

	// Token: 0x04000806 RID: 2054
	public GameObject componentHeader;

	// Token: 0x04000807 RID: 2055
	public GameObject[] componentTitles = new GameObject[8];

	// Token: 0x04000808 RID: 2056
	public bool[] valueUsed = new bool[23];

	// Token: 0x04000809 RID: 2057
	public GameObject hitComponent;

	// Token: 0x0400080A RID: 2058
	private GameObject hitEngineComponent;

	// Token: 0x0400080B RID: 2059
	private GameObject lastHitEngineComponent;

	// Token: 0x0400080C RID: 2060
	public Vector3[] componentUIPos = new Vector3[0];

	// Token: 0x0400080D RID: 2061
	private bool uiIsOn;

	// Token: 0x0400080E RID: 2062
	public AudioClip paperSFX;

	// Token: 0x0400080F RID: 2063
	public Color orange;

	// Token: 0x04000810 RID: 2064
	public Color green;

	// Token: 0x04000811 RID: 2065
	public Color red;

	// Token: 0x04000812 RID: 2066
	public Color blue;

	// Token: 0x04000813 RID: 2067
	public Color gray;

	// Token: 0x04000814 RID: 2068
	public bool one_click;

	// Token: 0x04000815 RID: 2069
	public bool timer_running;

	// Token: 0x04000816 RID: 2070
	public float timer_for_double_click;

	// Token: 0x04000817 RID: 2071
	public float delay = 0.3f;

	// Token: 0x04000818 RID: 2072
	public bool inputRestrictDropOnly;

	// Token: 0x04000819 RID: 2073
	public float tyreIronBoltSpamStopper;

	// Token: 0x0400081A RID: 2074
	[HideInInspector]
	public bool droppingOff;

	// Token: 0x0400081B RID: 2075
	private float joypadItemSwitchDelay;

	// Token: 0x0400081C RID: 2076
	public string debugLookingAt;
}
