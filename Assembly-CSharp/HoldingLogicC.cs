using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class HoldingLogicC : MonoBehaviour
{
	// Token: 0x06000687 RID: 1671 RVA: 0x0008361C File Offset: 0x00081A1C
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		if (this.renderTargets.Length > 0)
		{
			this.startMaterial = this.renderTargets[0].GetComponent<Renderer>().material;
		}
		else if (base.gameObject.GetComponent<Renderer>())
		{
			this.startMaterial = base.gameObject.GetComponent<Renderer>().material;
			this.renderTargets[0] = base.gameObject;
		}
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x000836A0 File Offset: 0x00081AA0
	private void Update()
	{
		if (this.isGlowing)
		{
			if (this.isTransparent)
			{
				foreach (GameObject gameObject in this.renderTargets)
				{
					float value = Mathf.PingPong(Time.time, 0.25f) + 1.5f;
					gameObject.GetComponent<Renderer>().material.SetFloat("_Shininess", value);
				}
				return;
			}
			foreach (GameObject gameObject2 in this.renderTargets)
			{
				float value2 = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
				gameObject2.GetComponent<Renderer>().material.SetFloat("_RimPower", value2);
			}
		}
		if (this.allowRendering && !this.isOccupied)
		{
			float value3 = Mathf.PingPong(Time.time, 0.25f) + 0.05f;
			foreach (GameObject gameObject3 in this.renderTargets)
			{
				gameObject3.GetComponent<Renderer>().material.SetFloat("_Shininess", value3);
			}
		}
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x000837D4 File Offset: 0x00081BD4
	public void DropOff()
	{
		if (this.isToolRackComponent)
		{
			if (!this.targetObject.GetComponent<ObjectPickupC>().isToolRackComponent)
			{
				return;
			}
			if (this.targetObject.GetComponent<CarJackC>())
			{
				for (int i = 0; i < this.targetObject.GetComponent<CarJackC>().carJackDropOffs.Count; i++)
				{
					this.targetObject.GetComponent<CarJackC>().carJackDropOffs[i].GetComponent<BoxCollider>().enabled = false;
					MeshRenderer[] componentsInChildren = this.targetObject.GetComponent<CarJackC>().carJackDropOffs[i].GetComponentsInChildren<MeshRenderer>();
					foreach (MeshRenderer meshRenderer in componentsInChildren)
					{
						meshRenderer.enabled = false;
					}
				}
			}
		}
		if (this.wheelID == 1)
		{
			GameObject gameObject = GameObject.FindWithTag("CarLogic");
			if (gameObject.GetComponent<CarPerformanceC>().frontLeftBricks != null)
			{
				gameObject.GetComponent<CarPerformanceC>().DestroyFLBricks();
			}
			this.targetObject.GetComponent<EngineComponentC>().wheelInstallID = 1;
			gameObject.GetComponent<CarPerformanceC>().flTyreID = this.targetObject.GetComponent<EngineComponentC>().tyreType + 1;
			gameObject.GetComponent<CarPerformanceC>().flCompoundID = (float)this.targetObject.GetComponent<EngineComponentC>().compoundType;
			this.targetObject.transform.GetChild(0).GetComponent<BoltLogicC>().carBoltSide = 1;
			gameObject.GetComponent<CarPerformanceC>().frontLeftTyre = this.targetObject;
			gameObject.GetComponent<CarLogicC>().FlWheelDirt = this.targetObject.transform.GetChild(1).gameObject;
		}
		if (this.wheelID == 2)
		{
			GameObject gameObject2 = GameObject.FindWithTag("CarLogic");
			if (gameObject2.GetComponent<CarPerformanceC>().frontRightBricks != null)
			{
				gameObject2.GetComponent<CarPerformanceC>().DestroyFRBricks();
			}
			this.targetObject.GetComponent<EngineComponentC>().wheelInstallID = 2;
			gameObject2.GetComponent<CarPerformanceC>().frTyreID = this.targetObject.GetComponent<EngineComponentC>().tyreType + 1;
			gameObject2.GetComponent<CarPerformanceC>().frCompoundID = (float)this.targetObject.GetComponent<EngineComponentC>().compoundType;
			this.targetObject.transform.GetChild(0).GetComponent<BoltLogicC>().carBoltSide = 2;
			gameObject2.GetComponent<CarPerformanceC>().frontRightTyre = this.targetObject;
			gameObject2.GetComponent<CarLogicC>().FrWheelDirt = this.targetObject.transform.GetChild(1).gameObject;
		}
		if (this.wheelID == 3)
		{
			GameObject gameObject3 = GameObject.FindWithTag("CarLogic");
			if (gameObject3.GetComponent<CarPerformanceC>().rearLeftBricks != null)
			{
				gameObject3.GetComponent<CarPerformanceC>().DestroyRLBricks();
			}
			this.targetObject.GetComponent<EngineComponentC>().wheelInstallID = 3;
			gameObject3.GetComponent<CarPerformanceC>().rlTyreID = this.targetObject.GetComponent<EngineComponentC>().tyreType + 1;
			gameObject3.GetComponent<CarPerformanceC>().rlCompoundID = (float)this.targetObject.GetComponent<EngineComponentC>().compoundType;
			this.targetObject.transform.GetChild(0).GetComponent<BoltLogicC>().carBoltSide = 1;
			gameObject3.GetComponent<CarPerformanceC>().rearLeftTyre = this.targetObject;
			gameObject3.GetComponent<CarLogicC>().RlWheelDirt = this.targetObject.transform.GetChild(1).gameObject;
		}
		if (this.wheelID == 4)
		{
			GameObject gameObject4 = GameObject.FindWithTag("CarLogic");
			if (gameObject4.GetComponent<CarPerformanceC>().rearRightBricks != null)
			{
				gameObject4.GetComponent<CarPerformanceC>().DestroyRRBricks();
			}
			this.targetObject.GetComponent<EngineComponentC>().wheelInstallID = 4;
			gameObject4.GetComponent<CarPerformanceC>().rrTyreID = this.targetObject.GetComponent<EngineComponentC>().tyreType + 1;
			gameObject4.GetComponent<CarPerformanceC>().rrCompoundID = (float)this.targetObject.GetComponent<EngineComponentC>().compoundType;
			this.targetObject.transform.GetChild(0).GetComponent<BoltLogicC>().carBoltSide = 2;
			gameObject4.GetComponent<CarPerformanceC>().rearRightTyre = this.targetObject;
			gameObject4.GetComponent<CarLogicC>().RrWheelDirt = this.targetObject.transform.GetChild(1).gameObject;
		}
		foreach (GameObject gameObject5 in this.targetObject.GetComponent<ObjectPickupC>().dropOffPoints)
		{
			gameObject5.GetComponent<Collider>().enabled = false;
			if (this.isCarKey)
			{
				this.targetObject.GetComponent<Collider>().enabled = false;
			}
			if (!this.isEngineDropOff)
			{
				foreach (GameObject gameObject6 in gameObject5.GetComponent<HoldingLogicC>().renderTargets)
				{
					gameObject6.GetComponent<Renderer>().enabled = false;
				}
			}
			else
			{
				foreach (GameObject gameObject7 in gameObject5.GetComponent<HoldingLogicC>().renderTargets)
				{
					gameObject7.GetComponent<Renderer>().material = this.startMaterial;
				}
			}
		}
		if (this.allowPickupAfterDrop)
		{
			this.targetObject.GetComponent<Collider>().enabled = true;
			if (this.isEngineDropOff)
			{
			}
		}
		this.isOccupied = true;
		this.targetObject.gameObject.GetComponent<ObjectPickupC>().placedAt = base.gameObject;
		if (this.placedAudio != null)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.placedAudio, 1f);
		}
		if (this.animateTargetObjectOnPlacement)
		{
			this.targetObject.SendMessage("PlacedAnimate");
		}
		if (this.additionalLocObj != null)
		{
			this.additionalLocObj.transform.localPosition = this.additionalLocObjTarget.localPosition;
			this.additionalLocObj.transform.localRotation = this.additionalLocObjTarget.localRotation;
			this.additionalLocObj.SendMessage("Animate");
		}
		if (this.functionalTarget != null)
		{
			this.functionalTarget.SendMessage("FunctionalLogicGo");
		}
		if (this.isEngineDropOff)
		{
			GameObject gameObject8 = GameObject.FindWithTag("CarLogic");
			if (!this.targetObject.GetComponent<Collider>().isTrigger)
			{
				this.targetObject.GetComponent<Collider>().isTrigger = true;
			}
			if (!this.gateDropOff)
			{
				this.targetObject.GetComponent<ObjectPickupC>().isInEngine = true;
				this.targetObject.GetComponent<EngineComponentC>().SendStatsToCarPerf();
			}
			else if (this.targetObjectStringName == "FuelTank")
			{
				base.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateGasTank = this.targetObject;
				this.targetObject.GetComponent<ObjectPickupC>().isInGateLock = true;
				base.transform.GetComponent<Collider>().enabled = false;
				base.transform.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(false);
				base.transform.GetComponent<HoldingLogicC>().isGlowing = false;
				this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
				gameObject8.GetComponent<CarPerformanceC>().GhostStop();
			}
			else if (this.targetObjectStringName == "Battery")
			{
				base.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateBattery = this.targetObject;
				this.targetObject.GetComponent<ObjectPickupC>().isInGateLock = true;
				base.transform.GetComponent<Collider>().enabled = false;
				this.engineGhostObj.SetActive(false);
				this.isGlowing = false;
				this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
				gameObject8.GetComponent<CarPerformanceC>().GhostStop();
			}
			else if (this.targetObjectStringName == "EngineBlock")
			{
				base.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateEngine = this.targetObject;
				this.targetObject.GetComponent<ObjectPickupC>().isInGateLock = true;
				base.transform.GetComponent<Collider>().enabled = false;
				base.transform.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(false);
				base.transform.GetComponent<HoldingLogicC>().isGlowing = false;
				this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
				gameObject8.GetComponent<CarPerformanceC>().GhostStop();
			}
			else if (this.targetObjectStringName == "Carburettor")
			{
				base.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateCarburettor = this.targetObject;
				this.targetObject.GetComponent<ObjectPickupC>().isInGateLock = true;
				base.transform.GetComponent<Collider>().enabled = false;
				base.transform.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(false);
				base.transform.GetComponent<HoldingLogicC>().isGlowing = false;
				this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
				gameObject8.GetComponent<CarPerformanceC>().GhostStop();
			}
		}
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x000840CE File Offset: 0x000824CE
	public void ScrapyardGhostStop()
	{
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x000840D0 File Offset: 0x000824D0
	public void GhostGlowStart()
	{
		if (base.transform.GetComponent<HoldingLogicC>().engineGhostObj != null)
		{
			BoxCollider[] components = base.transform.GetComponents<BoxCollider>();
			foreach (BoxCollider boxCollider in components)
			{
				boxCollider.enabled = true;
			}
			base.transform.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
			base.transform.GetComponent<HoldingLogicC>().isGlowing = true;
		}
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x0008414C File Offset: 0x0008254C
	public void StopFunctionalLogic()
	{
		if (this.functionalTarget != null)
		{
			this.functionalTarget.SendMessage("FunctionalLogicStop");
		}
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x00084170 File Offset: 0x00082570
	public void IsHolding()
	{
		if (!this.isEngineDropOff)
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().enabled = true;
				gameObject.GetComponent<Renderer>().material = this.holdingGlow;
			}
		}
		if (!this.isOccupied)
		{
			base.gameObject.GetComponent<Collider>().enabled = true;
			this.allowRendering = true;
		}
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x000841E8 File Offset: 0x000825E8
	public void NoLongerHolding()
	{
		if (this.invisible)
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().enabled = false;
			}
			base.GetComponent<Collider>().enabled = false;
		}
		else
		{
			foreach (GameObject gameObject2 in this.renderTargets)
			{
				gameObject2.GetComponent<Renderer>().material = this.startMaterial;
			}
		}
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x00084274 File Offset: 0x00082674
	public void RaycastEnter()
	{
		this.isGlowing = true;
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && (this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == this.targetObjectStringName || this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == this.targetObjectStringName + "(Clone)"))
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material = this.glowMaterial;
			}
		}
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x00084328 File Offset: 0x00082728
	public void RaycastExit()
	{
		if (this.holdingGlow == null)
		{
			this.holdingGlow = this.startMaterial;
		}
		this.isGlowing = false;
		if (this.isEngineDropOff)
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material = this.startMaterial;
			}
			return;
		}
		if (!this.dontGlowFromHere)
		{
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null)
			{
				if (this._camera.GetComponent<DragRigidbodyC>().isHolding1.transform.name == base.GetComponent<ObjectInteractionsC>().targetObjectStringName)
				{
					foreach (GameObject gameObject2 in this.renderTargets)
					{
						gameObject2.GetComponent<Renderer>().materials[0] = this.holdingGlow;
					}
				}
			}
			else
			{
				foreach (GameObject gameObject3 in this.renderTargets)
				{
					gameObject3.GetComponent<Renderer>().material = this.startMaterial;
				}
			}
		}
	}

	// Token: 0x040008B4 RID: 2228
	private GameObject _camera;

	// Token: 0x040008B5 RID: 2229
	public GameObject engineGhostObj;

	// Token: 0x040008B6 RID: 2230
	public bool invisible;

	// Token: 0x040008B7 RID: 2231
	public bool isEngineDropOff;

	// Token: 0x040008B8 RID: 2232
	public GameObject targetObject;

	// Token: 0x040008B9 RID: 2233
	public bool animateTargetObjectOnPlacement;

	// Token: 0x040008BA RID: 2234
	public string targetObjectStringName = string.Empty;

	// Token: 0x040008BB RID: 2235
	public GameObject[] renderTargets = new GameObject[0];

	// Token: 0x040008BC RID: 2236
	public bool allowPickupAfterDrop = true;

	// Token: 0x040008BD RID: 2237
	public bool allowRendering;

	// Token: 0x040008BE RID: 2238
	public GameObject functionalTarget;

	// Token: 0x040008BF RID: 2239
	public GameObject additionalLocObj;

	// Token: 0x040008C0 RID: 2240
	public Transform additionalLocObjTarget;

	// Token: 0x040008C1 RID: 2241
	public bool isOccupied;

	// Token: 0x040008C2 RID: 2242
	public AudioClip placedAudio;

	// Token: 0x040008C3 RID: 2243
	public AudioClip pickUpAudio;

	// Token: 0x040008C4 RID: 2244
	public Vector3 posAdjust;

	// Token: 0x040008C5 RID: 2245
	public Vector3 rotAdjust;

	// Token: 0x040008C6 RID: 2246
	private bool animating;

	// Token: 0x040008C7 RID: 2247
	public bool isGlowing;

	// Token: 0x040008C8 RID: 2248
	public bool isTransparent;

	// Token: 0x040008C9 RID: 2249
	public Material glowMaterial;

	// Token: 0x040008CA RID: 2250
	public Material startMaterial;

	// Token: 0x040008CB RID: 2251
	public Material holdingGlow;

	// Token: 0x040008CC RID: 2252
	public AudioClip[] engineRemoveStruggleAudio = new AudioClip[0];

	// Token: 0x040008CD RID: 2253
	public AudioClip engineRemoveAudio;

	// Token: 0x040008CE RID: 2254
	public int wheelID;

	// Token: 0x040008CF RID: 2255
	public bool dontGlowFromHere;

	// Token: 0x040008D0 RID: 2256
	public bool gateDropOff;

	// Token: 0x040008D1 RID: 2257
	public bool isToolRackComponent;

	// Token: 0x040008D2 RID: 2258
	public bool isCarKey;
}
