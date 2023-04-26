using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000098 RID: 152
public class CarJackC : MonoBehaviour
{
	// Token: 0x060004B9 RID: 1209 RVA: 0x0004F7FC File Offset: 0x0004DBFC
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		if (this.isTutorial)
		{
			this.preventJackReleaseFL = true;
			this.preventJackReleaseFR = true;
			this.preventJackReleaseRL = true;
			this.preventJackReleaseRR = true;
		}
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0004F850 File Offset: 0x0004DC50
	private void Awake()
	{
		WaterSupplyRelay component = base.GetComponent<WaterSupplyRelay>();
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x0004F86C File Offset: 0x0004DC6C
	private void PickUp()
	{
		if (this.carLogic.GetComponent<CarLogicC>().jackInUse != null && this.carLogic.GetComponent<CarLogicC>().jackInUse != base.gameObject)
		{
			return;
		}
		base.GetComponent<Animator>().SetBool("isJackedUp", false);
		this.carLogic.GetComponent<CarLogicC>().jackInUse = null;
		this.jackBar.GetComponent<BoxCollider>().enabled = false;
		this.carJackDropOffs.AddRange(GameObject.FindGameObjectsWithTag("CarJack"));
		for (int i = 0; i < this.carJackDropOffs.Count; i++)
		{
			if (this.carJackDropOffs[i] != null)
			{
				Ray ray = new Ray(this.carJackDropOffs[i].GetComponent<CarJackReceiverC>().rayCaster.transform.position, -Vector3.up);
				RaycastHit raycastHit;
				if (Physics.Raycast(ray, out raycastHit))
				{
					this.carJackDropOffs[i].transform.position = new Vector3(this.carJackDropOffs[i].transform.position.x, raycastHit.point.y + this.carJackHeightAdjust, this.carJackDropOffs[i].transform.position.z);
				}
				this.carJackDropOffs[i].GetComponent<BoxCollider>().enabled = true;
				this.carJackDropOffs[i].GetComponent<ObjectInteractionsC>().target = base.gameObject;
				MeshRenderer[] componentsInChildren = this.carJackDropOffs[i].GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer meshRenderer in componentsInChildren)
				{
					meshRenderer.enabled = true;
				}
			}
		}
		iTween.MoveTo(this.jackBar, iTween.Hash(new object[]
		{
			"position",
			this.jackPosition[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
		iTween.RotateTo(this.jackBar, iTween.Hash(new object[]
		{
			"rotation",
			this.jackRotation[0],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
		this.jackBar.GetComponent<BoxCollider>().enabled = false;
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x0004FB40 File Offset: 0x0004DF40
	public void ThrowLogic()
	{
		if (this.carLogic.GetComponent<CarLogicC>().jackInUse == null)
		{
			for (int i = 0; i < this.carJackDropOffs.Count; i++)
			{
				this.carJackDropOffs[i].GetComponent<BoxCollider>().enabled = false;
				MeshRenderer[] componentsInChildren = this.carJackDropOffs[i].GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer meshRenderer in componentsInChildren)
				{
					meshRenderer.enabled = false;
				}
			}
		}
		for (int k = 0; k < this.carJackDropOffs.Count; k++)
		{
			this.carJackDropOffs.RemoveAt(k);
		}
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x0004FC00 File Offset: 0x0004E000
	public void JackOutFromDrivingAway()
	{
		MonoBehaviour.print("Jack out");
		if (this.carLogic.GetComponent<CarLogicC>().jackInUse != null && this.carLogic.GetComponent<CarLogicC>().jackInUse != base.gameObject)
		{
			return;
		}
		base.GetComponent<Animator>().SetBool("isJackedUp", false);
		this.jackBar.GetComponent<BoxCollider>().enabled = false;
		this.jackBar.transform.localPosition = this.jackPosition[0];
		this.jackBar.transform.localEulerAngles = this.jackRotation[0];
		this.jackBar.GetComponent<BoxCollider>().enabled = false;
		this.JackDown();
		this.ThrowLogic();
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x0004FCD4 File Offset: 0x0004E0D4
	public void JackEngaged()
	{
		for (int i = 0; i < this.carJackDropOffs.Count; i++)
		{
			this.carJackDropOffs[i].GetComponent<BoxCollider>().enabled = false;
			MeshRenderer[] componentsInChildren = this.carJackDropOffs[i].GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				meshRenderer.enabled = false;
			}
		}
		for (int k = 0; k < this.carJackDropOffs.Count; k++)
		{
			this.carJackDropOffs.RemoveAt(k);
		}
		iTween.Stop(base.gameObject);
		base.transform.parent = base.GetComponent<ObjectPickupC>().targetDropOff.transform;
		this.carParent = this.carLogic.transform.parent.transform.parent.gameObject;
		this.carLogic.GetComponent<CarLogicC>().jackInUse = base.gameObject;
		if (this.isTutorial)
		{
			GameObject gameObject = GameObject.FindWithTag("Uncle");
			if (gameObject.GetComponent<Scene1_LogicC>().tyreTutorialFinished)
			{
				this.isTutorial = false;
			}
			else
			{
				gameObject.SendMessage("JackPlacedUnderCar");
			}
		}
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			Vector3.zero,
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1,
			"oncomplete",
			"ReadyJack",
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
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x0004FF08 File Offset: 0x0004E308
	public void ReadyJack()
	{
		iTween.MoveTo(this.jackBar, iTween.Hash(new object[]
		{
			"position",
			this.jackPosition[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
		iTween.RotateTo(this.jackBar, iTween.Hash(new object[]
		{
			"rotation",
			this.jackRotation[1],
			"islocal",
			true,
			"time",
			this.timeToComplete,
			"easetype",
			this.easeType1
		}));
		this.jackBar.GetComponent<BoxCollider>().enabled = true;
		base.gameObject.GetComponent<BoxCollider>().enabled = true;
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x00050018 File Offset: 0x0004E418
	private IEnumerator JackUp()
	{
		if (this.isJackedUp)
		{
			this.JackDown();
			yield break;
		}
		base.transform.parent = null;
		base.transform.position = base.GetComponent<ObjectPickupC>().targetDropOff.transform.position;
		base.GetComponent<BoxCollider>().enabled = false;
		this.tyreIron.GetComponent<BoxCollider>().enabled = false;
		this.isJackedUp = true;
		if (this.isTutorial)
		{
			GameObject gameObject = GameObject.FindWithTag("Uncle");
			gameObject.SendMessage("TurnJackHandleUp");
		}
		base.GetComponent<Animator>().SetBool("isJackedUp", true);
		base.GetComponent<AudioSource>().PlayOneShot(this.audioCrank, 1f);
		iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(2f, 0f, 0f),
			"islocal",
			true,
			"time",
			0.2,
			"easetype",
			"easeoutquint"
		}));
		if (this.jackInstalledAt.GetComponent<CarJackReceiverC>().type == 1)
		{
			this.carParent.GetComponent<Rigidbody>().isKinematic = true;
			if (this.carLogic.GetComponent<CarLogicC>().wheelObjects[0].GetComponent<WheelCollider>().radius < 0.55f || this.carLogic.GetComponent<CarLogicC>().wheelObjects[1].GetComponent<WheelCollider>().radius < 0.55f)
			{
				this.carParent.transform.MoveRotateBy(new Vector3(this.leftXAmount, 0f, 0f), new Vector3(0f, 0f, this.leftXRotation), 0.35f, 0.25f, true, this);
			}
			else
			{
				this.carParent.transform.MoveRotateBy(new Vector3(this.leftXAmount, 0f, 0f), new Vector3(0f, 0f, this.leftXRotation), 0.35f, 0.25f, true, this);
			}
			this.carLogic.GetComponent<CarLogicC>().sideJackedUp = 1;
			this.carLogic.GetComponent<CarLogicC>().LeftTyresReadyForRemoval();
		}
		if (this.jackInstalledAt.GetComponent<CarJackReceiverC>().type == 2)
		{
			this.carParent.GetComponent<Rigidbody>().isKinematic = true;
			if (this.carLogic.GetComponent<CarLogicC>().wheelObjects[2].GetComponent<WheelCollider>().radius < 0.55f || this.carLogic.GetComponent<CarLogicC>().wheelObjects[3].GetComponent<WheelCollider>().radius < 0.55f)
			{
				this.carParent.transform.MoveRotateBy(new Vector3(this.rightXAmount, 0f, 0f), new Vector3(0f, 0f, this.rightXRotation), 0.35f, 0.25f, true, this);
			}
			else
			{
				this.carParent.transform.MoveRotateBy(new Vector3(this.rightXAmount, 0f, 0f), new Vector3(0f, 0f, this.rightXRotation), 0.35f, 0.25f, true, this);
			}
			this.carLogic.GetComponent<CarLogicC>().sideJackedUp = 2;
			this.carLogic.GetComponent<CarLogicC>().RightTyresReadyForRemoval();
		}
		yield return new WaitForSeconds(0.2f);
		this.tyreIron.SendMessage("PickUp");
		yield break;
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x00050034 File Offset: 0x0004E434
	public void SetJackToMe()
	{
		this.carLogic.GetComponent<CarLogicC>().jackInUse = base.gameObject;
		for (int i = 0; i < this.carJackDropOffs.Count; i++)
		{
			this.carJackDropOffs[i].GetComponent<ObjectInteractionsC>().target = base.gameObject;
		}
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00050090 File Offset: 0x0004E490
	public void JackDown()
	{
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		if (this.preventJackReleaseFL || this.preventJackReleaseFR || this.preventJackReleaseRL || this.preventJackReleaseRR)
		{
			if (this.jackInstalledAt.GetComponent<CarJackReceiverC>().type == 1)
			{
				if (gameObject.GetComponent<CarPerformanceC>().frontLeftTyre == null || gameObject.GetComponent<CarPerformanceC>().rearLeftTyre == null)
				{
					iTween.Stop(this.jackBar);
					this.jackBar.transform.localEulerAngles = new Vector3(0f, this.jackBar.transform.localEulerAngles.y, this.jackBar.transform.localEulerAngles.z);
					base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
					iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
					{
						"amount",
						new Vector3(-0.2f, 0f, 0f),
						"islocal",
						true,
						"time",
						0.2,
						"oncomplete",
						"StuckJackPart2",
						"oncompletetarget",
						base.gameObject,
						"easetype",
						"easeoutquint"
					}));
					return;
				}
				if (gameObject.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>() == null || gameObject.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>() == null)
				{
					iTween.Stop(this.jackBar);
					this.jackBar.transform.localEulerAngles = new Vector3(0f, this.jackBar.transform.localEulerAngles.y, this.jackBar.transform.localEulerAngles.z);
					base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
					iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
					{
						"amount",
						new Vector3(-0.2f, 0f, 0f),
						"islocal",
						true,
						"time",
						0.2,
						"oncomplete",
						"StuckJackPart2",
						"oncompletetarget",
						base.gameObject,
						"easetype",
						"easeoutquint"
					}));
					return;
				}
				if (gameObject.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose || gameObject.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose)
				{
					iTween.Stop(this.jackBar);
					this.jackBar.transform.localEulerAngles = new Vector3(0f, this.jackBar.transform.localEulerAngles.y, this.jackBar.transform.localEulerAngles.z);
					base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
					iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
					{
						"amount",
						new Vector3(-0.2f, 0f, 0f),
						"islocal",
						true,
						"time",
						0.2,
						"oncomplete",
						"StuckJackPart2",
						"oncompletetarget",
						base.gameObject,
						"easetype",
						"easeoutquint"
					}));
					return;
				}
			}
			if (this.jackInstalledAt.GetComponent<CarJackReceiverC>().type == 2)
			{
				if (gameObject.GetComponent<CarPerformanceC>().frontRightTyre == null || gameObject.GetComponent<CarPerformanceC>().rearRightTyre == null)
				{
					iTween.Stop(this.jackBar);
					this.jackBar.transform.localEulerAngles = new Vector3(0f, this.jackBar.transform.localEulerAngles.y, this.jackBar.transform.localEulerAngles.z);
					base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
					iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
					{
						"amount",
						new Vector3(-0.2f, 0f, 0f),
						"islocal",
						true,
						"time",
						0.2,
						"oncomplete",
						"StuckJackPart2",
						"oncompletetarget",
						base.gameObject,
						"easetype",
						"easeoutquint"
					}));
					return;
				}
				if (gameObject.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>() == null || gameObject.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>() == null)
				{
					iTween.Stop(this.jackBar);
					this.jackBar.transform.localEulerAngles = new Vector3(0f, this.jackBar.transform.localEulerAngles.y, this.jackBar.transform.localEulerAngles.z);
					base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
					iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
					{
						"amount",
						new Vector3(-0.2f, 0f, 0f),
						"islocal",
						true,
						"time",
						0.2,
						"oncomplete",
						"StuckJackPart2",
						"oncompletetarget",
						base.gameObject,
						"easetype",
						"easeoutquint"
					}));
					return;
				}
				if (gameObject.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose || gameObject.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose)
				{
					iTween.Stop(this.jackBar);
					this.jackBar.transform.localEulerAngles = new Vector3(0f, this.jackBar.transform.localEulerAngles.y, this.jackBar.transform.localEulerAngles.z);
					base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
					iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
					{
						"amount",
						new Vector3(-0.2f, 0f, 0f),
						"islocal",
						true,
						"time",
						0.2,
						"oncomplete",
						"StuckJackPart2",
						"oncompletetarget",
						base.gameObject,
						"easetype",
						"easeoutquint"
					}));
					return;
				}
			}
		}
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		this.tyreIron.GetComponent<TyreIronC>().actionGo = false;
		if (!(this._camera.GetComponent<DragRigidbodyC>().isHolding1 == this.tyreIron))
		{
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 == this.tyreIron)
			{
				Debug.Log("Move items right started");
				this._camera.GetComponent<DragRigidbodyC>().MoveItemsRight();
			}
			else if (this._camera.GetComponent<DragRigidbodyC>().isHolding3 == this.tyreIron)
			{
				Debug.Log("Move items left started");
				this._camera.GetComponent<DragRigidbodyC>().MoveItemsLeft();
			}
		}
		this.isJackedUp = false;
		this.tyreIron.SendMessage("ReturnToJack");
		base.GetComponent<Animator>().SetBool("isJackedUp", false);
		base.GetComponent<AudioSource>().PlayOneShot(this.audioCrank, 1f);
		iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(-2f, 0f, 0f),
			"islocal",
			true,
			"time",
			0.5,
			"easetype",
			"easeoutquint"
		}));
		if (this.jackInstalledAt.GetComponent<CarJackReceiverC>().type == 1)
		{
			iTween.MoveBy(this.carParent, iTween.Hash(new object[]
			{
				"x",
				-0.07,
				"islocal",
				true,
				"time",
				0.1,
				"easetype",
				this.easeType1,
				"oncomplete",
				"ReScanAStar",
				"oncompletetarget",
				base.gameObject
			}));
			gameObject.GetComponent<CarLogicC>().sideJackedUp = 0;
			gameObject.GetComponent<CarLogicC>().LeftTyresRestricted();
		}
		else if (this.jackInstalledAt.GetComponent<CarJackReceiverC>().type == 2)
		{
			iTween.MoveBy(this.carParent, iTween.Hash(new object[]
			{
				"x",
				0.07,
				"islocal",
				true,
				"time",
				0.1,
				"easetype",
				this.easeType1,
				"oncomplete",
				"ReScanAStar",
				"oncompletetarget",
				base.gameObject
			}));
			gameObject.GetComponent<CarLogicC>().sideJackedUp = 0;
			gameObject.GetComponent<CarLogicC>().RightTyresRestricted();
		}
		this.carParent.GetComponent<Rigidbody>().isKinematic = false;
		this.carParent.GetComponent<Rigidbody>().AddForce(base.transform.up * 0.002f);
		base.GetComponent<BoxCollider>().enabled = true;
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x00050BAC File Offset: 0x0004EFAC
	public void StuckJackPart2()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
		iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0.2f, 0f, 0f),
			"islocal",
			true,
			"time",
			0.2,
			"oncomplete",
			"StuckJackPart3",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x00050C68 File Offset: 0x0004F068
	public void StuckJackPart3()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.audioJackStuck, 1f);
		iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(-0.2f, 0f, 0f),
			"islocal",
			true,
			"time",
			0.2,
			"oncomplete",
			"StuckJackPart4",
			"oncompletetarget",
			base.gameObject,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x00050D24 File Offset: 0x0004F124
	public void StuckJackPart4()
	{
		iTween.RotateBy(this.jackBar, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0.2f, 0f, 0f),
			"islocal",
			true,
			"time",
			0.2,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x00050DA8 File Offset: 0x0004F1A8
	public void IntoInventory()
	{
		if (this.carLogic.GetComponent<CarLogicC>().jackInUse != null && this.carLogic.GetComponent<CarLogicC>().jackInUse != base.gameObject)
		{
			return;
		}
		for (int i = 0; i < this.carJackDropOffs.Count; i++)
		{
			if (this.carJackDropOffs[i] != null)
			{
				this.carJackDropOffs[i].GetComponent<BoxCollider>().enabled = false;
				MeshRenderer[] componentsInChildren = this.carJackDropOffs[i].GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer meshRenderer in componentsInChildren)
				{
					meshRenderer.enabled = false;
				}
			}
			this.carJackDropOffs.RemoveAt(i);
		}
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00050E7F File Offset: 0x0004F27F
	public void ReScanAStar()
	{
		AstarPath.active.Scan(null);
	}

	// Token: 0x040006D7 RID: 1751
	private GameObject _camera;

	// Token: 0x040006D8 RID: 1752
	public GameObject carParent;

	// Token: 0x040006D9 RID: 1753
	public GameObject carLogic;

	// Token: 0x040006DA RID: 1754
	public GameObject tyreIron;

	// Token: 0x040006DB RID: 1755
	public List<GameObject> carJackDropOffs = new List<GameObject>();

	// Token: 0x040006DC RID: 1756
	public AudioClip audioCrank;

	// Token: 0x040006DD RID: 1757
	public AudioClip audioJackStuck;

	// Token: 0x040006DE RID: 1758
	public GameObject jackBar;

	// Token: 0x040006DF RID: 1759
	public GameObject jackInstalledAt;

	// Token: 0x040006E0 RID: 1760
	public Vector3[] jackPosition;

	// Token: 0x040006E1 RID: 1761
	public Vector3[] jackRotation;

	// Token: 0x040006E2 RID: 1762
	public Vector3[] carJackRotation;

	// Token: 0x040006E3 RID: 1763
	public float timeToComplete = 0.6f;

	// Token: 0x040006E4 RID: 1764
	public string easeType1 = string.Empty;

	// Token: 0x040006E5 RID: 1765
	public string easeType2 = string.Empty;

	// Token: 0x040006E6 RID: 1766
	public bool isJackedUp;

	// Token: 0x040006E7 RID: 1767
	public bool preventJackReleaseFL;

	// Token: 0x040006E8 RID: 1768
	public bool preventJackReleaseFR;

	// Token: 0x040006E9 RID: 1769
	public bool preventJackReleaseRL;

	// Token: 0x040006EA RID: 1770
	public bool preventJackReleaseRR;

	// Token: 0x040006EB RID: 1771
	public bool isTutorial;

	// Token: 0x040006EC RID: 1772
	public float carJackHeightAdjust = 0.2f;

	// Token: 0x040006ED RID: 1773
	public float leftXAmount = 0.11f;

	// Token: 0x040006EE RID: 1774
	public float leftXRotation = -0.004f;

	// Token: 0x040006EF RID: 1775
	public float rightXAmount = -0.11f;

	// Token: 0x040006F0 RID: 1776
	public float rightXRotation = 0.004f;
}
