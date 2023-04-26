using System;
using UnityEngine;

// Token: 0x02000121 RID: 289
public class TyreIronC : MonoBehaviour
{
	// Token: 0x06000B42 RID: 2882 RVA: 0x00105E9D File Offset: 0x0010429D
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x06000B43 RID: 2883 RVA: 0x00105EC0 File Offset: 0x001042C0
	public void CheckCollisions()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioTyreIronDropped, 1f);
		if (!this.carJack.GetComponent<CarJackC>().isJackedUp)
		{
			base.GetComponent<BoxCollider>().enabled = false;
		}
		else
		{
			base.GetComponent<BoxCollider>().enabled = true;
		}
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null && this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null)
		{
			this._camera.GetComponent<DragRigidbodyC>().MoveItemsRight();
		}
	}

	// Token: 0x06000B44 RID: 2884 RVA: 0x00105F5C File Offset: 0x0010435C
	public void ReturnToJack()
	{
		base.transform.parent = this.carJack.transform;
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == base.gameObject)
		{
			this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
		}
		base.gameObject.layer = LayerMask.NameToLayer("Default");
		if (!this.carJack.GetComponent<CarJackC>().isJackedUp)
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.carJackPosAdjust,
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeinquint",
				"oncomplete",
				"CheckCollisions",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.carJackRotAdjust,
				"islocal",
				true,
				"time",
				0.25,
				"easetype",
				"easeinquint"
			}));
		}
		else
		{
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				this.carJackPosAdjust2,
				"islocal",
				true,
				"time",
				1.0,
				"easetype",
				"easeinquint",
				"oncomplete",
				"CheckCollisions",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.carJackRotAdjust2,
				"islocal",
				true,
				"time",
				0.75,
				"easetype",
				"easeinquint"
			}));
		}
		base.GetComponent<ObjectPickupC>().isTweenTransition = false;
	}

	// Token: 0x06000B45 RID: 2885 RVA: 0x001061CD File Offset: 0x001045CD
	public void UnAction()
	{
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x001061D0 File Offset: 0x001045D0
	public void Action()
	{
		if (!this.actionGo)
		{
			this.actionGo = true;
			if (!this.targetBolt.GetComponent<BoltLogicC>().boltStateLoose)
			{
				if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 1)
				{
					this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseFL = true;
				}
				else if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 2)
				{
					this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseFR = true;
				}
				else if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 3)
				{
					this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseRL = true;
				}
				else if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 4)
				{
					this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseRR = true;
				}
			}
			this.targetBolt.transform.parent.gameObject.GetComponent<ObjectPickupC>().enabled = false;
			this.targetBolt.GetComponent<BoltLogicC>().isLoose = false;
			double num = (double)this.targetBolt.transform.parent.GetComponent<EngineComponentC>().durability * 0.34;
			if ((double)this.targetBolt.transform.parent.GetComponent<EngineComponentC>().Condition > num)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().TyreHighUI(this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID - 1);
			}
			else if ((double)this.targetBolt.transform.parent.GetComponent<EngineComponentC>().Condition <= num && (double)this.targetBolt.transform.parent.GetComponent<EngineComponentC>().Condition > 0.0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().TyreLowUI(this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID - 1);
			}
			else if ((double)this.targetBolt.transform.parent.GetComponent<EngineComponentC>().Condition <= 0.0)
			{
				this.carLogic.GetComponent<ExtraUpgradesC>().TyreFlatUI(this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID - 1);
			}
			if (this.targetBolt.GetComponent<BoltLogicC>().isCarBolt)
			{
				if (this.targetBolt.GetComponent<BoltLogicC>().carBoltSide == 1 && this.carLogic.GetComponent<CarLogicC>().sideJackedUp == 1)
				{
					this.ActionPart1();
				}
				else if (this.targetBolt.GetComponent<BoltLogicC>().carBoltSide == 2 && this.carLogic.GetComponent<CarLogicC>().sideJackedUp == 2)
				{
					this.ActionPart1();
				}
			}
			else
			{
				this.ActionPart1();
			}
		}
		else
		{
			base.StartCoroutine("AllowAction", 1.0);
		}
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x00106520 File Offset: 0x00104920
	public void ActionPart1()
	{
		base.transform.parent = this.targetBolt.transform;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = true;
		base.gameObject.layer = LayerMask.NameToLayer("Default");
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			Vector3.zero,
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			this.easeType1,
			"oncomplete",
			"ActionPart2",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			Vector3.zero,
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			this.easeType1
		}));
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x0010666C File Offset: 0x00104A6C
	public void ActionPart2()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioTyreIronConnected, 1f);
		iTween.Stop(this.targetBolt);
		if (!this.targetBolt.GetComponent<BoltLogicC>().boltStateLoose)
		{
			iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0.5f, 0f),
				"islocal",
				true,
				"time",
				0.25,
				"oncomplete",
				"Turn2BeforeWheelLoose",
				"oncompletetarget",
				base.gameObject,
				"easetype",
				"easeoutquad"
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.wheelTurnAudio, 1f);
			iTween.MoveBy(this.targetBolt, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, -0.1f, 0f),
				"islocal",
				true,
				"time",
				1.0,
				"oncomplete",
				"ReturnTyreIron",
				"oncompletetarget",
				base.gameObject,
				"easetype",
				this.easeType1
			}));
			this.targetBolt.GetComponent<BoltLogicC>().boltStateLoose = true;
			this.targetBolt.GetComponent<BoltLogicC>().isLoose = true;
			this.carLogic.GetComponent<ExtraUpgradesC>().TyreFlatUI(this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID - 1);
		}
		else
		{
			if (this.isTutorial)
			{
				this.isTutorial = false;
				GameObject gameObject = GameObject.FindWithTag("Uncle");
				gameObject.SendMessage("WheelTightened");
			}
			GameObject gameObject2 = this.targetBolt.transform.parent.gameObject;
			if (gameObject2.transform.parent.GetComponent<HoldingLogicC>().wheelID == 1 || gameObject2.transform.parent.GetComponent<HoldingLogicC>().wheelID == 3)
			{
				iTween.RotateTo(gameObject2, iTween.Hash(new object[]
				{
					"rotation",
					Vector3.zero,
					"islocal",
					true,
					"time",
					0.3,
					"easetype",
					this.easeType1
				}));
			}
			else
			{
				iTween.RotateTo(gameObject2, iTween.Hash(new object[]
				{
					"rotation",
					new Vector3(0f, 180f, 0f),
					"islocal",
					true,
					"time",
					0.3,
					"easetype",
					this.easeType1
				}));
			}
			iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, -0.5f, 0f),
				"islocal",
				true,
				"time",
				0.25,
				"oncomplete",
				"Turn2BeforeWheelTight",
				"oncompletetarget",
				base.gameObject,
				"easetype",
				"easeoutquad"
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.wheelTurnAudio, 1f);
			iTween.MoveBy(this.targetBolt, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0.1f, 0f),
				"islocal",
				true,
				"time",
				1.0,
				"oncomplete",
				"ReturnTyreIron",
				"oncompletetarget",
				base.gameObject,
				"easetype",
				this.easeType1
			}));
			this.targetBolt.GetComponent<BoltLogicC>().boltStateLoose = false;
			this.targetBolt.GetComponent<BoltLogicC>().isLoose = false;
			if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 1)
			{
				this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseFL = false;
			}
			else if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 2)
			{
				this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseFR = false;
			}
			else if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 3)
			{
				this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseRL = false;
			}
			else if (this.targetBolt.transform.parent.GetComponent<EngineComponentC>().wheelInstallID == 4)
			{
				this.carLogic.GetComponent<CarLogicC>().jackInUse.GetComponent<CarJackC>().preventJackReleaseRR = false;
			}
		}
	}

	// Token: 0x06000B49 RID: 2889 RVA: 0x00106BFC File Offset: 0x00104FFC
	public void Turn2BeforeWheelTight()
	{
		iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, 0.5f, 0f),
			"islocal",
			true,
			"time",
			0.49,
			"oncomplete",
			"Turn3BeforeWheelTight",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeinoutquart"
		}));
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x00106CA4 File Offset: 0x001050A4
	public void Turn3BeforeWheelTight()
	{
		iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, -0.5f, 0f),
			"islocal",
			true,
			"time",
			0.25,
			"oncomplete",
			"Turn4BeforeWheelTight",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x00106D4C File Offset: 0x0010514C
	public void Turn4BeforeWheelTight()
	{
		iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, 0.5f, 0f),
			"islocal",
			true,
			"time",
			0.49,
			"oncomplete",
			"WheelTight",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeinoutquart"
		}));
	}

	// Token: 0x06000B4C RID: 2892 RVA: 0x00106DF4 File Offset: 0x001051F4
	public void Turn2BeforeWheelLoose()
	{
		iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, -0.5f, 0f),
			"islocal",
			true,
			"time",
			0.49,
			"oncomplete",
			"Turn3BeforeWheelLoose",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeinoutquart"
		}));
	}

	// Token: 0x06000B4D RID: 2893 RVA: 0x00106E9C File Offset: 0x0010529C
	public void Turn3BeforeWheelLoose()
	{
		iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, 0.5f, 0f),
			"islocal",
			true,
			"time",
			0.25,
			"oncomplete",
			"Turn4BeforeWheelLoose",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x06000B4E RID: 2894 RVA: 0x00106F44 File Offset: 0x00105344
	public void Turn4BeforeWheelLoose()
	{
		iTween.RotateBy(this.targetBolt, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, -0.5f, 0f),
			"islocal",
			true,
			"time",
			0.49,
			"oncomplete",
			"WheelLoose",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeinoutquart"
		}));
	}

	// Token: 0x06000B4F RID: 2895 RVA: 0x00106FEC File Offset: 0x001053EC
	public void ReturnTyreIron()
	{
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1.transform;
		base.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			base.GetComponent<ObjectPickupC>().positionAdjust,
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			this.easeType1
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			base.GetComponent<ObjectPickupC>().setRotation,
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			this.easeType1,
			"oncomplete",
			"AllowAction",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000B50 RID: 2896 RVA: 0x0010714A File Offset: 0x0010554A
	public void AllowAction()
	{
		this.actionGo = false;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = false;
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x00107178 File Offset: 0x00105578
	public void WheelLoose()
	{
		GameObject gameObject = this.targetBolt.transform.parent.gameObject;
		if (gameObject.transform.parent.GetComponent<HoldingLogicC>().wheelID == 1 || gameObject.transform.parent.GetComponent<HoldingLogicC>().wheelID == 3)
		{
			iTween.RotateBy(gameObject, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0f, 0.03f),
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeinquint"
			}));
		}
		else
		{
			iTween.RotateBy(gameObject, iTween.Hash(new object[]
			{
				"amount",
				new Vector3(0f, 0f, 0.03f),
				"islocal",
				true,
				"time",
				0.3,
				"easetype",
				"easeinquint"
			}));
		}
		gameObject.GetComponent<ObjectPickupC>().enabled = true;
		gameObject.GetComponent<EngineComponentC>().enabled = true;
		gameObject.tag = "Pickup";
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x001072D8 File Offset: 0x001056D8
	public void WheelTight()
	{
		GameObject gameObject = this.targetBolt.transform.parent.gameObject;
		gameObject.GetComponent<ObjectPickupC>().enabled = false;
		gameObject.tag = "Interactor";
	}

	// Token: 0x04000FC4 RID: 4036
	private GameObject _camera;

	// Token: 0x04000FC5 RID: 4037
	public GameObject carLogic;

	// Token: 0x04000FC6 RID: 4038
	public GameObject carJack;

	// Token: 0x04000FC7 RID: 4039
	public Vector3 carJackPosAdjust;

	// Token: 0x04000FC8 RID: 4040
	public Vector3 carJackRotAdjust;

	// Token: 0x04000FC9 RID: 4041
	public Vector3 carJackPosAdjust2;

	// Token: 0x04000FCA RID: 4042
	public Vector3 carJackRotAdjust2;

	// Token: 0x04000FCB RID: 4043
	public GameObject targetBolt;

	// Token: 0x04000FCC RID: 4044
	public string easeType1 = string.Empty;

	// Token: 0x04000FCD RID: 4045
	public bool actionGo;

	// Token: 0x04000FCE RID: 4046
	public bool isTutorial;

	// Token: 0x04000FCF RID: 4047
	public AudioClip audioTyreIronConnected;

	// Token: 0x04000FD0 RID: 4048
	public AudioClip audioTyreIronDropped;

	// Token: 0x04000FD1 RID: 4049
	public AudioClip wheelTurnAudio;
}
