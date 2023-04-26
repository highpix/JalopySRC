using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000D8 RID: 216
public class ObjectPickupC : MonoBehaviour
{
	// Token: 0x06000871 RID: 2161 RVA: 0x000B6A4C File Offset: 0x000B4E4C
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.originalSellValue = this.sellValue;
		base.transform.name = base.transform.name.Replace("(Clone)", string.Empty).Trim();
		if (!this.isPurchased)
		{
			if (this.isTradeGood)
			{
				this.store = base.transform.parent.transform.parent.transform.parent.transform.parent;
				base.StartCoroutine("SetCountryStuffs");
			}
			else
			{
				this.store = base.transform.parent.transform.parent.transform.parent;
			}
		}
		else if (this.isTradeGood)
		{
			base.StartCoroutine("SetCountryStuffs");
		}
		if (this.isEngineComponent || this.engineString != string.Empty)
		{
			base.transform.name = this.engineString;
		}
		this.returnPosition = base.transform.parent;
		if (base.GetComponent<EngineComponentC>())
		{
			if (!(base.GetComponent<EngineComponentC>().bolt != null))
			{
				if (this.renderTargets.Length > 0 && this.startMaterial == null)
				{
					this.startMaterial = this.renderTargets[0].GetComponent<Renderer>().material;
				}
			}
		}
		else if (this.renderTargets.Length > 0 && this.startMaterial == null)
		{
			this.startMaterial = this.renderTargets[0].GetComponent<Renderer>().material;
		}
		base.StartCoroutine(this.WaitForPriceTags());
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x000B6C24 File Offset: 0x000B5024
	private IEnumerator WaitForPriceTags()
	{
		if (MainMenuC.Global == null)
		{
			yield break;
		}
		yield return new WaitWhile(() => !MainMenuC.Global.director.GetComponent<DirectorC>().economyReady);
		this.SetPriceTag();
		yield break;
	}

	// Token: 0x06000873 RID: 2163 RVA: 0x000B6C40 File Offset: 0x000B5040
	public void SetCountryStuffs()
	{
		if (!this.hasBeenTradeUpdated)
		{
			RouteGeneratorC component = MainMenuC.Global.director.GetComponent<RouteGeneratorC>();
			if (this.morningShop)
			{
				if (component.routeLevel == 1)
				{
					foreach (GameObject gameObject in this.renderTargets)
					{
						gameObject.GetComponent<Renderer>().material = this.countryMat[0];
					}
					this.startMaterial = this.countryMat[0];
					this.glowMaterial = this.glowMat[0];
					this.tradeGoodCountryCode = 0;
				}
				else if (component.routeLevel == 2)
				{
					foreach (GameObject gameObject2 in this.renderTargets)
					{
						gameObject2.GetComponent<Renderer>().material = this.countryMat[1];
					}
					this.startMaterial = this.countryMat[1];
					this.glowMaterial = this.glowMat[1];
					this.tradeGoodCountryCode = 1;
				}
				else if (component.routeLevel == 3)
				{
					foreach (GameObject gameObject3 in this.renderTargets)
					{
						gameObject3.GetComponent<Renderer>().material = this.countryMat[2];
					}
					this.startMaterial = this.countryMat[2];
					this.glowMaterial = this.glowMat[2];
					this.tradeGoodCountryCode = 2;
				}
				else if (component.routeLevel == 4)
				{
					foreach (GameObject gameObject4 in this.renderTargets)
					{
						gameObject4.GetComponent<Renderer>().material = this.countryMat[3];
					}
					this.startMaterial = this.countryMat[3];
					this.glowMaterial = this.glowMat[3];
					this.tradeGoodCountryCode = 3;
				}
				else if (component.routeLevel == 5)
				{
					foreach (GameObject gameObject5 in this.renderTargets)
					{
						gameObject5.GetComponent<Renderer>().material = this.countryMat[4];
					}
					this.startMaterial = this.countryMat[4];
					this.glowMaterial = this.glowMat[4];
					this.tradeGoodCountryCode = 4;
				}
				else if (component.routeLevel == 6)
				{
					foreach (GameObject gameObject6 in this.renderTargets)
					{
						gameObject6.GetComponent<Renderer>().material = this.countryMat[5];
					}
					this.startMaterial = this.countryMat[5];
					this.glowMaterial = this.glowMat[5];
					this.tradeGoodCountryCode = 5;
				}
			}
			else if (component.routeLevel == 1)
			{
				foreach (GameObject gameObject7 in this.renderTargets)
				{
					gameObject7.GetComponent<Renderer>().material = this.countryMat[1];
				}
				this.startMaterial = this.countryMat[1];
				this.glowMaterial = this.glowMat[1];
				this.tradeGoodCountryCode = 1;
			}
			else if (component.routeLevel == 2)
			{
				foreach (GameObject gameObject8 in this.renderTargets)
				{
					gameObject8.GetComponent<Renderer>().material = this.countryMat[2];
				}
				this.startMaterial = this.countryMat[2];
				this.glowMaterial = this.glowMat[2];
				this.tradeGoodCountryCode = 2;
			}
			else if (component.routeLevel == 3)
			{
				foreach (GameObject gameObject9 in this.renderTargets)
				{
					gameObject9.GetComponent<Renderer>().material = this.countryMat[3];
				}
				this.startMaterial = this.countryMat[3];
				this.glowMaterial = this.glowMat[3];
				this.tradeGoodCountryCode = 3;
			}
			else if (component.routeLevel == 4)
			{
				foreach (GameObject gameObject10 in this.renderTargets)
				{
					gameObject10.GetComponent<Renderer>().material = this.countryMat[4];
				}
				this.startMaterial = this.countryMat[4];
				this.glowMaterial = this.glowMat[4];
				this.tradeGoodCountryCode = 4;
			}
			else if (component.routeLevel == 5)
			{
				foreach (GameObject gameObject11 in this.renderTargets)
				{
					gameObject11.GetComponent<Renderer>().material = this.countryMat[5];
				}
				this.startMaterial = this.countryMat[5];
				this.glowMaterial = this.glowMat[5];
				this.tradeGoodCountryCode = 5;
			}
			this.hasBeenTradeUpdated = true;
		}
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x000B713C File Offset: 0x000B553C
	public void SetPriceTag()
	{
		if (this.isTradeGood)
		{
			if (this.supplyNumber == 0)
			{
				this.buyValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[0]];
				this.sellValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[0]];
			}
			if (this.supplyNumber == 1)
			{
				this.buyValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[1]];
				this.sellValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[1]];
			}
			if (this.supplyNumber == 2)
			{
				this.buyValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[2]];
				this.sellValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[2]];
			}
			if (this.supplyNumber == 3)
			{
				this.buyValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[3]];
				this.sellValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[3]];
			}
			if (this.supplyNumber == 4)
			{
				this.buyValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[4]];
				this.sellValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[4]];
			}
			if (this.supplyNumber == 5)
			{
				this.buyValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueBuyPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[5]];
				this.sellValue = MainMenuC.Global.director.GetComponent<DirectorC>().supplyCatalogueSellPrices[MainMenuC.Global.director.GetComponent<DirectorC>().supplyNumbers[5]];
			}
		}
		if (this.buyValue < 10f)
		{
			if (this.buyValue < 0.1f && this.buyValue > 0f && this.buyPriceObj != null)
			{
				this.buyPriceObj.GetComponent<TextMesh>().text = this.buyValue.ToString();
			}
			else if (this.buyValue % 1f != 0f && this.buyPriceObj != null)
			{
				this.buyPriceObj.GetComponent<TextMesh>().text = "0" + this.buyValue.ToString() + "0";
			}
			else if (this.buyPriceObj != null)
			{
				this.buyPriceObj.GetComponent<TextMesh>().text = "0" + this.buyValue.ToString() + ".00";
			}
		}
		else
		{
			if (this.buyValue < 0.1f && this.buyValue > 0f && this.buyPriceObj != null)
			{
				this.buyPriceObj.GetComponent<TextMesh>().text = this.buyValue.ToString();
			}
			if (this.buyValue % 1f != 0f && this.buyPriceObj != null)
			{
				this.buyPriceObj.GetComponent<TextMesh>().text = this.buyValue.ToString() + "0";
			}
			else if (this.buyPriceObj != null)
			{
				this.buyPriceObj.GetComponent<TextMesh>().text = this.buyValue.ToString() + ".00";
			}
		}
		if (base.GetComponent<EngineComponentC>())
		{
			float num = base.GetComponent<EngineComponentC>().durability * 0.34f;
			float num2 = base.GetComponent<EngineComponentC>().durability * 0.67f;
			if (base.GetComponent<EngineComponentC>().Condition <= 0f)
			{
				this.sellValue = 0f;
			}
			else if (base.GetComponent<EngineComponentC>().Condition < num)
			{
				this.sellValue = Mathf.Round(this.originalSellValue * 0.34f);
			}
			else if (base.GetComponent<EngineComponentC>().Condition > num && base.GetComponent<EngineComponentC>().Condition < num2)
			{
				this.sellValue = Mathf.Round(this.originalSellValue * 0.67f);
			}
			else if (base.GetComponent<EngineComponentC>().Condition == base.GetComponent<EngineComponentC>().durability)
			{
				this.sellValue = this.originalSellValue;
			}
		}
		if (this.sellValue < 10f)
		{
			if (this.sellValue < 0.1f && this.sellValue > 0f && this.sellPriceObj != null)
			{
				this.sellPriceObj.GetComponent<TextMesh>().text = "0" + this.sellValue.ToString();
			}
			else if (this.sellValue % 1f != 0f && this.sellPriceObj != null)
			{
				this.sellPriceObj.GetComponent<TextMesh>().text = "0" + this.sellValue.ToString() + "0";
			}
			else if (this.sellPriceObj != null)
			{
				this.sellPriceObj.GetComponent<TextMesh>().text = "0" + this.sellValue.ToString() + ".00";
			}
		}
		else if ((double)this.sellValue < 0.1 && (double)this.sellValue > 0.0 && this.sellPriceObj != null)
		{
			this.sellPriceObj.GetComponent<TextMesh>().text = "0" + this.sellValue.ToString();
		}
		else if (this.sellValue % 1f != 0f && this.sellPriceObj != null)
		{
			this.sellPriceObj.GetComponent<TextMesh>().text = this.sellValue.ToString() + "0";
		}
		else if (this.sellPriceObj != null)
		{
			this.sellPriceObj.GetComponent<TextMesh>().text = this.sellValue.ToString() + ".00";
		}
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x000B78D4 File Offset: 0x000B5CD4
	private IEnumerator RemoveFromGateLock()
	{
		this.isBeingRemoved = true;
		base.transform.localPosition += new Vector3(0f, 0f, 0.0025f);
		base.transform.localEulerAngles += new Vector3(0f, 1f, 0f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[0], 0.7f);
		yield return new WaitForSeconds(0.15f);
		base.transform.localPosition += new Vector3(0f, 0f, 0.005f);
		base.transform.localEulerAngles += new Vector3(0f, -2.5f, 0f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[1], 0.7f);
		yield return new WaitForSeconds(0.15f);
		base.transform.localPosition += new Vector3(0f, 0f, 0.01f);
		base.transform.localEulerAngles += new Vector3(0f, 5f, 0f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[2], 0.7f);
		yield return new WaitForSeconds(0.15f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveAudio, 0.7f);
		this.isInEngine = false;
		this.isBeingRemoved = false;
		if (this.engineString == "Battery")
		{
			base.transform.parent.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateBattery = null;
			this.placedAt.GetComponent<HoldingLogicC>().GhostGlowStart();
		}
		else if (this.engineString == "EngineBlock")
		{
			base.transform.parent.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateEngine = null;
			this.placedAt.GetComponent<HoldingLogicC>().GhostGlowStart();
		}
		else if (this.engineString == "Carburettor")
		{
			base.transform.parent.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateCarburettor = null;
			this.placedAt.GetComponent<HoldingLogicC>().GhostGlowStart();
		}
		else if (this.engineString == "FuelTank")
		{
			base.transform.parent.transform.parent.transform.parent.GetComponent<ScrapYardC>().gateGasTank = null;
			this.placedAt.GetComponent<HoldingLogicC>().GhostGlowStart();
		}
		this.previousParent = base.transform.parent;
		if (this.previousParent.GetComponent<HoldingLogicC>())
		{
			this.previousParent.GetComponent<Collider>().enabled = false;
		}
		this.isInGateLock = false;
		this.stillInGateLock = true;
		this.PickUp();
		base.StopCoroutine("RemoveFromGateLock");
		yield break;
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x000B78F0 File Offset: 0x000B5CF0
	private IEnumerator RemoveFromEngine()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "GasCan")
		{
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			yield break;
		}
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding3 != null)
		{
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			yield break;
		}
		if (base.GetComponent<EngineComponentC>().bolt != null && !base.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isLoose)
		{
			base.transform.localEulerAngles += new Vector3(0f, 1f, 0f);
			base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[0], 0.7f);
			yield return new WaitForSeconds(0.1f);
			base.transform.localEulerAngles -= new Vector3(0f, 1f, 0f);
			yield return new WaitForSeconds(0.1f);
			base.transform.localEulerAngles += new Vector3(0f, 1f, 0f);
			base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[0], 0.7f);
			yield return new WaitForSeconds(0.1f);
			base.transform.localEulerAngles -= new Vector3(0f, 1f, 0f);
			yield return new WaitForSeconds(0.1f);
			base.StartCoroutine("RaycastExit");
			yield break;
		}
		this.isBeingRemoved = true;
		base.transform.localPosition += new Vector3(0f, 0f, 0.0025f);
		base.transform.localEulerAngles += new Vector3(0f, 1f, 0f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[0], 0.7f);
		yield return new WaitForSeconds(0.15f);
		base.transform.localPosition += new Vector3(0f, 0f, 0.005f);
		base.transform.localEulerAngles += new Vector3(0f, -2.5f, 0f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[1], 0.7f);
		yield return new WaitForSeconds(0.15f);
		base.transform.localPosition += new Vector3(0f, 0f, 0.01f);
		base.transform.localEulerAngles += new Vector3(0f, 5f, 0f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveStruggleAudio[2], 0.7f);
		yield return new WaitForSeconds(0.15f);
		base.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().engineRemoveAudio, 0.7f);
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null)
		{
			this.placedAt.GetComponent<HoldingLogicC>().GhostGlowStart();
		}
		if (base.GetComponent<EngineComponentC>().acceleration > 0f)
		{
			base.GetComponent<EngineComponentC>().carLogic.SendMessage("EngineDamageNone");
		}
		this.isInEngine = false;
		this.isBeingRemoved = false;
		base.GetComponent<EngineComponentC>().RemoveStatsFromCarPerf();
		this.PickUp();
		if (base.GetComponent<EngineComponentC>().bolt != null)
		{
			EngineComponentC component = base.GetComponent<EngineComponentC>();
			int num = component.wheelInstallID - 1;
			component.carLogic.GetComponent<CarLogicC>().wheelObjects[num].GetComponent<WheelScriptPCC>().wheelTransform = null;
			component.carLogic.GetComponent<CarPerformanceC>().RemoveTyreRefs();
		}
		base.StopCoroutine("RemoveFromEngine");
		yield break;
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x000B790C File Offset: 0x000B5D0C
	public void ForceCollisions()
	{
		Collider[] array = new Collider[0];
		array = base.GetComponents<Collider>();
		foreach (Collider collider in array)
		{
			collider.isTrigger = false;
			collider.enabled = true;
		}
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x000B7950 File Offset: 0x000B5D50
	private void Update()
	{
		if (this.forceCollision && base.gameObject.GetComponent<Collider>().isTrigger)
		{
			base.StartCoroutine("ForceCollisions");
			this.forceCollision = false;
		}
		if (base.transform.parent && this.renderTargets != null && this.renderTargets.Length > 0 && this.renderTargets[0].GetComponent<Renderer>().material == this.glowMaterial)
		{
			if (base.transform.parent.name != "CarryHolder1")
			{
				this.RaycastExit();
			}
			else if (base.transform.parent.name != "CarryHolder2")
			{
				this.RaycastExit();
			}
			else if (base.transform.parent.name != "CarryHolder3")
			{
				this.RaycastExit();
			}
		}
		if (this.isBeingRemoved && (Input.GetButtonUp("Fire1") || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17])))
		{
			base.StopCoroutine("RemoveFromEngine");
			base.StopCoroutine("RemoveFromGateLock");
			this.isBeingRemoved = false;
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			base.transform.localPosition = base.transform.parent.GetComponent<HoldingLogicC>().posAdjust;
			base.transform.localEulerAngles = base.transform.parent.GetComponent<HoldingLogicC>().rotAdjust;
			if (base.GetComponent<EngineComponentC>() && base.GetComponent<EngineComponentC>().bolt)
			{
				base.GetComponent<EngineComponentC>().bolt.GetComponent<BoltLogicC>().isFitted = true;
				if (base.transform.parent.GetComponent<HoldingLogicC>().wheelID == 4 || base.transform.parent.GetComponent<HoldingLogicC>().wheelID == 2)
				{
					iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
					{
						"amount",
						new Vector3(0f, 0f, -0.03f),
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
					iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
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
			}
		}
		if (this.isGlowing)
		{
			if (this.isTransparent)
			{
				foreach (GameObject gameObject in this.renderTargets)
				{
					float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
					gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
				}
				return;
			}
			foreach (GameObject gameObject2 in this.renderTargets)
			{
				if (gameObject2 != null)
				{
					float value2 = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
					gameObject2.GetComponent<Renderer>().material.SetFloat("_RimPower", value2);
				}
			}
		}
		if (this.connectedTo != null)
		{
			this.distanceForDrop = Vector3.Distance(base.transform.position, this.connectedTo.transform.position);
			this.distanceForDrop += 1f;
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == base.gameObject && this.distanceForDrop >= this.connectedTo.GetComponent<RopeConnectionC>().ConnectionValue)
			{
				iTween.Stop(base.gameObject);
				base.gameObject.layer = LayerMask.NameToLayer("Default");
				base.GetComponent<RefuelLogicC>().PlaceAtPump();
				this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
				if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null)
				{
					this._camera.GetComponent<DragRigidbodyC>().Holding2ToHands();
				}
				base.gameObject.SendMessage("DistanceTooLarge");
			}
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 == base.gameObject && this.distanceForDrop >= this.connectedTo.GetComponent<RopeConnectionC>().ConnectionValue)
			{
				iTween.Stop(base.gameObject);
				base.gameObject.layer = LayerMask.NameToLayer("Default");
				base.GetComponent<RefuelLogicC>().PlaceAtPump();
				this._camera.GetComponent<DragRigidbodyC>().isHolding2 = null;
				if (this._camera.GetComponent<DragRigidbodyC>().isHolding3 != null)
				{
					this._camera.GetComponent<DragRigidbodyC>().Holding3To2();
				}
				base.gameObject.SendMessage("DistanceTooLarge");
			}
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding3 == base.gameObject && this.distanceForDrop >= this.connectedTo.GetComponent<RopeConnectionC>().ConnectionValue)
			{
				iTween.Stop(base.gameObject);
				this._camera.GetComponent<DragRigidbodyC>().isHolding3 = null;
				base.gameObject.layer = LayerMask.NameToLayer("Default");
				base.GetComponent<RefuelLogicC>().PlaceAtPump();
				base.gameObject.SendMessage("DistanceTooLarge");
			}
		}
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x000B7F67 File Offset: 0x000B6367
	public void AnimationStopped()
	{
		this.animating = false;
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x000B7F70 File Offset: 0x000B6370
	public void IntoInventory()
	{
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x000B7F72 File Offset: 0x000B6372
	public void OutOfInventory()
	{
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x000B7F74 File Offset: 0x000B6374
	public void PickUp()
	{
		iTween.Stop(base.gameObject);
		if (base.gameObject.GetComponent<MotelRelayC>())
		{
			base.gameObject.GetComponent<MotelRelayC>().PickUp();
		}
		if (this.isInGarbageCollection >= 0)
		{
			if (RouteGeneratorC.Global.cratesToBeCleanedUp.Contains(base.gameObject))
			{
				MainMenuC.Global.director.GetComponent<RouteGeneratorC>().cratesToBeCleanedUp.RemoveAt(this.isInGarbageCollection);
				MainMenuC.Global.director.GetComponent<RouteGeneratorC>().UpdateGarbageCollection(this.isInGarbageCollection);
			}
			this.isInGarbageCollection = -1;
		}
		if (this.placedAt != null && this.isInEngine)
		{
			base.StartCoroutine("RemoveFromEngine");
			return;
		}
		if (this.placedAt != null && this.isInGateLock)
		{
			base.StartCoroutine("RemoveFromGateLock");
			return;
		}
		base.StartCoroutine("RaycastExit");
		if (base.GetComponent<EngineComponentC>())
		{
			if (base.GetComponent<EngineComponentC>().isTutorialObj)
			{
				GameObject gameObject = GameObject.FindWithTag("Uncle");
				if (base.GetComponent<EngineComponentC>().ignitionTimer != 0f)
				{
					gameObject.SendMessage("IgnitionCoilTutorialRemoved");
				}
				if (base.GetComponent<EngineComponentC>().acceleration != 0f)
				{
					gameObject.SendMessage("EngineBlockTutorialRemoved");
				}
				if (base.GetComponent<EngineComponentC>().fuelConsumptionRate != 0f)
				{
					gameObject.SendMessage("CarburettorTutorialRemoved");
				}
				if (base.GetComponent<EngineComponentC>().totalFuelAmount != 0f)
				{
					gameObject.SendMessage("FuelTankTutorialRemoved");
				}
				if (base.GetComponent<EngineComponentC>().engineWearRate != 0f)
				{
					gameObject.SendMessage("AirFilterTutorialRemoved");
				}
				if (base.GetComponent<EngineComponentC>().isBattery)
				{
					gameObject.SendMessage("BatteryTutorialRemoved");
				}
				if (base.GetComponent<EngineComponentC>().totalWaterCharges != 0)
				{
					gameObject.SendMessage("WaterTankTutorialRemoved");
				}
			}
			if (base.GetComponent<EngineComponentC>().carLogic == null)
			{
				base.GetComponent<EngineComponentC>().carLogic = GameObject.FindWithTag("CarLogic");
			}
			if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null)
			{
				if (base.GetComponent<EngineComponentC>().totalFuelAmount > 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedFuelTank == null)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostFuelTankGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				else if (base.GetComponent<EngineComponentC>().totalFuelAmount > 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedFuelTank == base.gameObject)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostFuelTankGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (base.GetComponent<EngineComponentC>().isBattery && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedBattery == null)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostBatteryGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				else if (base.GetComponent<EngineComponentC>().isBattery && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedBattery == base.gameObject)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostBatteryGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (base.GetComponent<EngineComponentC>().totalWaterCharges != 0 && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().waterTankObj == null)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostWaterTankGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				else if (base.GetComponent<EngineComponentC>().totalWaterCharges != 0 && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().waterTankObj == base.gameObject)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostWaterTankGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (base.GetComponent<EngineComponentC>().acceleration != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().InstalledEngine == null)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostEngineBlockGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				else if (base.GetComponent<EngineComponentC>().acceleration != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().InstalledEngine == base.gameObject)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostEngineBlockGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (base.GetComponent<EngineComponentC>().ignitionTimer != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil == null)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostIgnitionCoilGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				else if (base.GetComponent<EngineComponentC>().ignitionTimer != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedIgnitionCoil == base.gameObject)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostIgnitionCoilGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (base.GetComponent<EngineComponentC>().fuelConsumptionRate != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedCarburettor == null)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostCarburettorGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				else if (base.GetComponent<EngineComponentC>().fuelConsumptionRate != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedCarburettor == base.gameObject)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostCarburettorGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				if (base.GetComponent<EngineComponentC>().engineWearRate != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedAirFilter == null)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostAirFilterGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
				else if (base.GetComponent<EngineComponentC>().engineWearRate != 0f && base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().installedAirFilter == base.gameObject)
				{
					base.GetComponent<EngineComponentC>().carLogic.GetComponent<CarPerformanceC>().GhostAirFilterGo(base.GetComponent<ObjectPickupC>().renderTargets[0].GetComponent<MeshFilter>().mesh);
				}
			}
		}
		this.RaycastExit();
		if (base.transform.parent != null && base.transform.parent.parent != null && base.transform.parent.transform.parent.GetComponent<MirrorLogicC>())
		{
			base.transform.parent.transform.parent.GetComponent<MirrorLogicC>().keyHolder = null;
		}
		if (this.inventoryPlacedAt != null && this.inventoryPlacedAt.name == "WheelHolder")
		{
			if (!this.inventoryPlacedAt.transform.parent.GetComponent<InventoryLogicC>().isHomeInventory && !this.inventoryPlacedAt.transform.parent.GetComponent<InventoryLogicC>().isCrateInventory)
			{
				GameObject gameObject2 = GameObject.FindWithTag("CarLogic");
				gameObject2.GetComponent<CarPerformanceC>().carBootWeight -= this.rigidMass;
				gameObject2.GetComponent<CarPerformanceC>().totalCarWeight -= this.rigidMass;
				gameObject2.GetComponent<CarPerformanceC>().UpdateWeight();
				if (gameObject2.GetComponent<CarPerformanceC>().frontLeftTyre != null)
				{
					EngineComponentC component = gameObject2.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>();
					gameObject2.GetComponent<CarPerformanceC>().UpdateGrip(1, component.roadGrip, component.Condition, component.durability, gameObject2.GetComponent<CarPerformanceC>().frontLeftTyre, component.wetGrip, component.offRoadGrip);
				}
				if (gameObject2.GetComponent<CarPerformanceC>().frontRightTyre != null)
				{
					EngineComponentC component2 = gameObject2.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>();
					gameObject2.GetComponent<CarPerformanceC>().UpdateGrip(2, component2.roadGrip, component2.Condition, component2.durability, gameObject2.GetComponent<CarPerformanceC>().frontRightTyre, component2.wetGrip, component2.offRoadGrip);
				}
				if (gameObject2.GetComponent<CarPerformanceC>().rearLeftTyre != null)
				{
					EngineComponentC component3 = gameObject2.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>();
					gameObject2.GetComponent<CarPerformanceC>().UpdateGrip(3, component3.roadGrip, component3.Condition, component3.durability, gameObject2.GetComponent<CarPerformanceC>().rearLeftTyre, component3.wetGrip, component3.offRoadGrip);
				}
				if (gameObject2.GetComponent<CarPerformanceC>().rearRightTyre != null)
				{
					EngineComponentC component4 = gameObject2.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>();
					gameObject2.GetComponent<CarPerformanceC>().UpdateGrip(4, component4.roadGrip, component4.Condition, component4.durability, gameObject2.GetComponent<CarPerformanceC>().rearRightTyre, component4.wetGrip, component4.offRoadGrip);
				}
			}
			this.inventoryPlacedAt.transform.parent.GetComponent<InventoryLogicC>().WheelOut(base.gameObject);
		}
		if (this._camera == null)
		{
			this._camera = Camera.main.gameObject;
		}
		if (base.transform.parent != null && this._camera.GetComponent<DragRigidbodyC>().isHolding3 == null && base.transform.root.GetComponent<BoxContentsC>())
		{
			base.transform.root.GetComponent<BoxContentsC>().RemoveContent();
		}
		if (!this.isPurchased && this._camera.GetComponent<DragRigidbodyC>().isHolding3 == null)
		{
			Transform parent = this.returnPosition.transform.parent;
			Transform parent2 = parent.transform.parent;
			if (parent2.name == "Spawners")
			{
				parent2 = parent2.transform.parent;
			}
			parent2.GetComponent<StoreC>().GateClose();
			if (base.transform.parent != null && !this.isInUnpaidCatalogue)
			{
				parent2.GetComponent<StoreC>().unPaidCatalogue.Add(base.gameObject);
				this.isInUnpaidCatalogue = true;
			}
		}
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null || this._camera.GetComponent<DragRigidbodyC>().isHolding2 == null || this._camera.GetComponent<DragRigidbodyC>().isHolding3 == null)
		{
			base.transform.parent = null;
			base.SendMessage("IntoInventory");
		}
		if (base.gameObject.GetComponent<ObjectInteractionsC>() && this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().transform.name == base.gameObject.GetComponent<ObjectInteractionsC>().targetObjectStringName)
		{
			Debug.Log("OBject 2 object going on");
			base.gameObject.SendMessage("Object2ObjectInteraction");
			this._camera.GetComponent<DragRigidbodyC>().SendMessage("Action");
			return;
		}
		if (this.connectedTo != null && this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null)
		{
			this._camera.GetComponent<DragRigidbodyC>().ConnectedPickup();
		}
		if (this.animating)
		{
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			return;
		}
		if (this.isTweenTransition)
		{
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			return;
		}
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding3 != null)
		{
			this._camera.GetComponent<DragRigidbodyC>().PickUpError();
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			return;
		}
		if (this.locked)
		{
			base.gameObject.SendMessage("StuckAnimation");
			this.animating = true;
			this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
			return;
		}
		if (this.inventoryPlacedAt != null)
		{
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().isOccupied = false;
			if (!this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().isHomeInventory && !this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().isCrateInventory)
			{
				GameObject gameObject3 = GameObject.FindWithTag("CarLogic");
				gameObject3.GetComponent<CarPerformanceC>().carBootWeight -= this.rigidMass;
				gameObject3.GetComponent<CarPerformanceC>().totalCarWeight -= this.rigidMass;
				gameObject3.GetComponent<CarPerformanceC>().UpdateWeight();
				if (gameObject3.GetComponent<CarPerformanceC>().frontLeftTyre != null)
				{
					EngineComponentC component5 = gameObject3.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>();
					gameObject3.GetComponent<CarPerformanceC>().UpdateGrip(1, component5.roadGrip, component5.Condition, component5.durability, gameObject3.GetComponent<CarPerformanceC>().frontLeftTyre, component5.wetGrip, component5.offRoadGrip);
				}
				if (gameObject3.GetComponent<CarPerformanceC>().frontRightTyre != null)
				{
					EngineComponentC component6 = gameObject3.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>();
					gameObject3.GetComponent<CarPerformanceC>().UpdateGrip(2, component6.roadGrip, component6.Condition, component6.durability, gameObject3.GetComponent<CarPerformanceC>().frontRightTyre, component6.wetGrip, component6.offRoadGrip);
				}
				if (gameObject3.GetComponent<CarPerformanceC>().rearLeftTyre != null)
				{
					EngineComponentC component7 = gameObject3.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>();
					gameObject3.GetComponent<CarPerformanceC>().UpdateGrip(3, component7.roadGrip, component7.Condition, component7.durability, gameObject3.GetComponent<CarPerformanceC>().rearLeftTyre, component7.wetGrip, component7.offRoadGrip);
				}
				if (gameObject3.GetComponent<CarPerformanceC>().rearRightTyre != null)
				{
					EngineComponentC component8 = gameObject3.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>();
					gameObject3.GetComponent<CarPerformanceC>().UpdateGrip(4, component8.roadGrip, component8.Condition, component8.durability, gameObject3.GetComponent<CarPerformanceC>().rearRightTyre, component8.wetGrip, component8.offRoadGrip);
				}
			}
			if (this.dimensionY == 2 && this.dimensionX == 1 && this.dimensionZ == 1)
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
			}
			if (this.inventoryPlacedAt.name == "2x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "3x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x1x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x2x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x1x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "3x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x1x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().AvailableSlotCount();
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().UpdateInventory();
			this.inventoryPlacedAt = null;
		}
		if (this._audio.Length > 0 && this._audio[0] != null)
		{
			float pitch = UnityEngine.Random.Range(0.9f, 1.1f);
			base.GetComponent<AudioSource>().pitch = pitch;
			int num = UnityEngine.Random.Range(0, this._audio.Length);
			base.GetComponent<AudioSource>().PlayOneShot(this._audio[num], 1f);
		}
		if (this.additionalLocObj != null)
		{
			this.additionalLocObj.transform.localPosition = this.additionalLocObjTarget.localPosition;
			this.additionalLocObj.transform.localRotation = this.additionalLocObjTarget.localRotation;
			this.additionalLocObj.SendMessage("StopAnimate");
		}
		if (this.placedAt != null)
		{
			this.placedAt.GetComponent<HoldingLogicC>().isOccupied = false;
			this.placedAt.GetComponent<HoldingLogicC>().StopFunctionalLogic();
			if (this.placedAt.GetComponent<HoldingLogicC>().animateTargetObjectOnPlacement)
			{
				base.gameObject.SendMessage("StopPlacedAnimate");
			}
			if (this.placedAt.GetComponent<HoldingLogicC>().pickUpAudio != null)
			{
				float pitch2 = UnityEngine.Random.Range(0.9f, 1.1f);
				base.GetComponent<AudioSource>().pitch = pitch2;
				this.placedAt.GetComponent<AudioSource>().PlayOneShot(this.placedAt.GetComponent<HoldingLogicC>().pickUpAudio, 0.7f);
			}
			if (this.particleObj != null)
			{
				this.particleObj.GetComponent<ParticleSystem>().Play();
			}
		}
		this.forceCollision = false;
		Collider[] array = new Collider[0];
		array = base.GetComponents<Collider>();
		foreach (Collider collider in array)
		{
			collider.isTrigger = true;
			collider.enabled = false;
		}
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding2 == null)
		{
			this.isTweenTransition = true;
			base.transform.parent = null;
			this._camera.GetComponent<DragRigidbodyC>().isHolding2 = base.gameObject;
			base.transform.MoveRotateTo(this._camera.GetComponent<DragRigidbodyC>().holdingParent2.position + this.positionAdjust, new Vector3(this._camera.GetComponent<DragRigidbodyC>().holdingParent3.localEulerAngles.x + this.setRotation.x, this._camera.transform.root.eulerAngles.y + this.setRotation.y, this._camera.GetComponent<DragRigidbodyC>().holdingParent3.localEulerAngles.z + this.setRotation.z), 0.2f, 0f, this, delegate()
			{
				this.MoveToSlot2();
			});
			return;
		}
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null && this._camera.GetComponent<DragRigidbodyC>().isHolding3 == null)
		{
			this.isTweenTransition = true;
			base.transform.parent = null;
			this._camera.GetComponent<DragRigidbodyC>().isHolding3 = base.gameObject;
			base.transform.MoveRotateTo(this._camera.GetComponent<DragRigidbodyC>().holdingParent3.position + this.positionAdjust, new Vector3(this._camera.GetComponent<DragRigidbodyC>().holdingParent2.localEulerAngles.x + this.setRotation.x, this._camera.transform.root.eulerAngles.y + this.setRotation.y, this._camera.GetComponent<DragRigidbodyC>().holdingParent2.localEulerAngles.z + this.setRotation.z), 0.2f, 0f, this, delegate()
			{
				this.MoveToSlot3();
			});
			return;
		}
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null)
		{
			this.isTweenTransition = true;
			base.transform.parent = null;
			this._camera.GetComponent<DragRigidbodyC>().isHolding1 = base.gameObject;
			base.transform.MoveRotateTo(this._camera.GetComponent<DragRigidbodyC>().holdingParent1.position + this.positionAdjust, new Vector3(this._camera.GetComponent<DragRigidbodyC>().holdingParent1.localEulerAngles.x + this.setRotation.x, this._camera.GetComponent<DragRigidbodyC>().holdingParent1.localEulerAngles.y + this.setRotation.y, this._camera.GetComponent<DragRigidbodyC>().holdingParent1.localEulerAngles.z + this.setRotation.z), 0.2f, 0f, this, delegate()
			{
				this.MoveToSlot1();
			});
		}
		else if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 == null)
		{
			this.isTweenTransition = true;
			base.transform.parent = null;
			this._camera.GetComponent<DragRigidbodyC>().isHolding2 = base.gameObject;
			base.transform.MoveRotateTo(this._camera.GetComponent<DragRigidbodyC>().holdingParent2.position + this.positionAdjust, new Vector3(this._camera.GetComponent<DragRigidbodyC>().holdingParent2.localEulerAngles.x + this.setRotation.x, this._camera.GetComponent<DragRigidbodyC>().holdingParent2.localEulerAngles.y + this.setRotation.y, this._camera.GetComponent<DragRigidbodyC>().holdingParent2.localEulerAngles.z + this.setRotation.z), 0.2f, 0f, this, delegate()
			{
				this.MoveToSlot2();
			});
		}
		else if (this._camera.GetComponent<DragRigidbodyC>().isHolding3 == null)
		{
			this.isTweenTransition = true;
			base.transform.parent = null;
			this._camera.GetComponent<DragRigidbodyC>().isHolding3 = base.gameObject;
			base.transform.MoveRotateTo(this._camera.GetComponent<DragRigidbodyC>().holdingParent3.position + this.positionAdjust, new Vector3(this._camera.GetComponent<DragRigidbodyC>().holdingParent3.localEulerAngles.x + this.setRotation.x, this._camera.GetComponent<DragRigidbodyC>().holdingParent3.localEulerAngles.y + this.setRotation.y, this._camera.GetComponent<DragRigidbodyC>().holdingParent3.localEulerAngles.z + this.setRotation.z), 0.2f, 0f, this, delegate()
			{
				this.MoveToSlot3();
			});
		}
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x000B9940 File Offset: 0x000B7D40
	public void BorderRemoveFromInventory()
	{
		if (this.inventoryPlacedAt != null)
		{
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().isOccupied = false;
			if (!this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().isHomeInventory && !this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().isCrateInventory)
			{
				GameObject gameObject = GameObject.FindWithTag("CarLogic");
				gameObject.GetComponent<CarPerformanceC>().carBootWeight -= this.rigidMass;
				gameObject.GetComponent<CarPerformanceC>().totalCarWeight -= this.rigidMass;
				gameObject.GetComponent<CarPerformanceC>().UpdateWeight();
				if (gameObject.GetComponent<CarPerformanceC>().frontLeftTyre != null)
				{
					EngineComponentC component = gameObject.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(1, component.roadGrip, component.Condition, component.durability, gameObject.GetComponent<CarPerformanceC>().frontLeftTyre, component.wetGrip, component.offRoadGrip);
				}
				if (gameObject.GetComponent<CarPerformanceC>().frontRightTyre != null)
				{
					EngineComponentC component2 = gameObject.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(2, component2.roadGrip, component2.Condition, component2.durability, gameObject.GetComponent<CarPerformanceC>().frontRightTyre, component2.wetGrip, component2.offRoadGrip);
				}
				if (gameObject.GetComponent<CarPerformanceC>().rearLeftTyre != null)
				{
					EngineComponentC component3 = gameObject.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(3, component3.roadGrip, component3.Condition, component3.durability, gameObject.GetComponent<CarPerformanceC>().rearLeftTyre, component3.wetGrip, component3.offRoadGrip);
				}
				if (gameObject.GetComponent<CarPerformanceC>().rearRightTyre != null)
				{
					EngineComponentC component4 = gameObject.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(4, component4.roadGrip, component4.Condition, component4.durability, gameObject.GetComponent<CarPerformanceC>().rearRightTyre, component4.wetGrip, component4.offRoadGrip);
				}
			}
			if (this.dimensionY == 2 && this.dimensionX == 1 && this.dimensionZ == 1)
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
			}
			if (this.inventoryPlacedAt.name == "2x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x1x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x2x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x1x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "3x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x1x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().AvailableSlotCount();
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().UpdateInventory();
			this.inventoryPlacedAt = null;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x000B9D94 File Offset: 0x000B8194
	public void MoveToSlot1()
	{
		this.isTweenTransition = false;
		if (this.placedAt != null && this.placedAt.GetComponent<Collider>())
		{
			this.placedAt.GetComponent<Collider>().enabled = true;
		}
		this.placedAt = null;
		foreach (GameObject gameObject in this.dropOffPoints)
		{
			if (gameObject != null && !gameObject.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject.GetComponent<Collider>().enabled = true;
				gameObject.GetComponent<HoldingLogicC>().targetObject = null;
			}
		}
		if (this.previousParent != null)
		{
			this.previousParent.GetComponent<Collider>().enabled = true;
			this.previousParent.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
			this.previousParent.GetComponent<HoldingLogicC>().isGlowing = true;
		}
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1;
		if (this.connectedTo == null)
		{
			UnityEngine.Object.Destroy(base.GetComponent<Rigidbody>());
		}
		else if (base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().isKinematic = true;
		}
		base.transform.localPosition = this.positionAdjust;
		this._camera.GetComponent<DragRigidbodyC>().holdingParent1.localEulerAngles = Vector3.zero;
		base.transform.localEulerAngles = this.setRotation;
		if (this.adjustScale != Vector3.zero)
		{
			Transform parent = base.transform.parent;
			base.transform.parent = null;
			base.transform.localScale = this.adjustScale;
			base.transform.parent = parent;
		}
		if (this.bootPlacedAt != null)
		{
			this.bootPlacedAt.SendMessage("RemoveFromBootSlot1");
			this.bootPlacedAt = null;
		}
		base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("PickUp");
		}
		foreach (GameObject gameObject2 in this.dropOffPoints)
		{
			if (gameObject2.activeInHierarchy && !gameObject2.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject2.gameObject.SendMessage("IsHolding");
			}
		}
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x000BA04C File Offset: 0x000B844C
	public void MoveToSlot2()
	{
		this.isTweenTransition = false;
		if (this.placedAt != null && this.placedAt.GetComponent<Collider>())
		{
			this.placedAt.GetComponent<Collider>().enabled = true;
		}
		this.placedAt = null;
		foreach (GameObject gameObject in this.dropOffPoints)
		{
			if (gameObject != null && !gameObject.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject.GetComponent<Collider>().enabled = false;
				gameObject.GetComponent<HoldingLogicC>().targetObject = null;
			}
		}
		if (this.previousParent != null)
		{
			this.previousParent.GetComponent<Collider>().enabled = true;
			this.previousParent.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
			this.previousParent.GetComponent<HoldingLogicC>().isGlowing = true;
		}
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent2;
		if (this.connectedTo == null)
		{
			UnityEngine.Object.Destroy(base.GetComponent<Rigidbody>());
		}
		else
		{
			base.GetComponent<Rigidbody>().isKinematic = true;
		}
		base.transform.localPosition = this.positionAdjust;
		this._camera.GetComponent<DragRigidbodyC>().holdingParent2.localEulerAngles = Vector3.zero;
		base.transform.localEulerAngles = this.setRotation;
		base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("PickUp");
		}
		if (this.adjustScale != Vector3.zero)
		{
			Transform parent = base.transform.parent;
			base.transform.parent = null;
			base.transform.localScale = this.adjustScale;
			base.transform.parent = parent;
		}
		if (this.bootPlacedAt != null)
		{
			this.bootPlacedAt.SendMessage("RemoveFromBootSlot2");
			this.bootPlacedAt = null;
		}
		foreach (GameObject gameObject2 in this.dropOffPoints)
		{
			if (gameObject2.activeInHierarchy && !gameObject2.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject2.gameObject.SendMessage("NoLongerHolding");
			}
		}
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x000BA2F4 File Offset: 0x000B86F4
	public void NoLongerHolding()
	{
		foreach (GameObject gameObject in this.dropOffPoints)
		{
			if (gameObject.activeInHierarchy && !gameObject.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject.gameObject.SendMessage("NoLongerHolding");
			}
		}
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x000BA34C File Offset: 0x000B874C
	public void MoveToSlot3()
	{
		this.isTweenTransition = false;
		if (this.placedAt != null && this.placedAt.GetComponent<Collider>())
		{
			this.placedAt.GetComponent<Collider>().enabled = true;
		}
		this.placedAt = null;
		foreach (GameObject gameObject in this.dropOffPoints)
		{
			if (gameObject != null && !gameObject.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject.GetComponent<Collider>().enabled = false;
				gameObject.GetComponent<HoldingLogicC>().targetObject = null;
			}
		}
		if (this.previousParent != null)
		{
			this.previousParent.GetComponent<Collider>().enabled = true;
			this.previousParent.GetComponent<HoldingLogicC>().engineGhostObj.SetActive(true);
			this.previousParent.GetComponent<HoldingLogicC>().isGlowing = true;
		}
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent3;
		if (this.connectedTo == null)
		{
			UnityEngine.Object.Destroy(base.GetComponent<Rigidbody>());
		}
		else
		{
			base.GetComponent<Rigidbody>().isKinematic = true;
		}
		base.transform.localPosition = this.positionAdjust;
		this._camera.GetComponent<DragRigidbodyC>().holdingParent3.localEulerAngles = Vector3.zero;
		base.transform.localEulerAngles = this.setRotation;
		base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("PickUp");
		}
		if (this.adjustScale != Vector3.zero)
		{
			Transform parent = base.transform.parent;
			base.transform.parent = null;
			base.transform.localScale = this.adjustScale;
			base.transform.parent = parent;
		}
		if (this.bootPlacedAt != null)
		{
			this.bootPlacedAt.SendMessage("RemoveFromBootSlot3");
			this.bootPlacedAt = null;
		}
		foreach (GameObject gameObject2 in this.dropOffPoints)
		{
			if (gameObject2.activeInHierarchy && !gameObject2.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject2.gameObject.SendMessage("NoLongerHolding");
			}
		}
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x000BA5F4 File Offset: 0x000B89F4
	public void ThrowLogic()
	{
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.positionAdjust;
		this._camera.GetComponent<DragRigidbodyC>().pickingUp = false;
		if (base.GetComponent<SpongeC>())
		{
			this.isTweenTransition = false;
			base.GetComponent<SpongeC>().ReturnToBucket();
			return;
		}
		if (base.GetComponent<TyreIronC>())
		{
			this.isTweenTransition = false;
			base.GetComponent<TyreIronC>().ReturnToJack();
			return;
		}
		if (base.GetComponent<RepairKitC>() && base.GetComponent<RepairKitC>().isToolRack)
		{
			this.dropOffPoints[0].GetComponent<HoldingLogicC>().targetObject = base.gameObject;
			this.DropOff();
			return;
		}
		if (this.returnObject != null)
		{
			this.DropNoRigidbody();
			this.isTweenTransition = false;
			return;
		}
		if (this.throwLogicTarget != null)
		{
			this.throwLogicTarget.SendMessage("ThrowLogic");
		}
		base.SendMessage("OutOfInventory");
		if (this._audio.Length != 0)
		{
			this.RandomAudio();
		}
		Collider[] array = new Collider[0];
		array = base.GetComponents<Collider>();
		foreach (Collider collider in array)
		{
			collider.enabled = true;
			collider.isTrigger = false;
		}
		foreach (GameObject gameObject in this.dropOffPoints)
		{
			if (gameObject.activeInHierarchy && !gameObject.GetComponent<HoldingLogicC>().isOccupied)
			{
				gameObject.gameObject.SendMessage("NoLongerHolding");
			}
		}
		base.transform.parent = null;
		if (this.adjustScale != Vector3.zero)
		{
			base.transform.localScale = this.adjustScale;
		}
		this.isTweenTransition = false;
		if (this.isInGarbageCollection == -1)
		{
			MainMenuC.Global.director.GetComponent<RouteGeneratorC>().cratesToBeCleanedUp.Add(base.gameObject);
			this.isInGarbageCollection = MainMenuC.Global.director.GetComponent<RouteGeneratorC>().cratesToBeCleanedUp.Count - 1;
		}
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x000BA824 File Offset: 0x000B8C24
	public void ReturnToShelf()
	{
		base.transform.parent = this.returnPosition.transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		if (base.GetComponent<Rigidbody>() && base.GetComponent<Rigidbody>().useGravity)
		{
			base.GetComponent<Rigidbody>().useGravity = false;
			base.GetComponent<Rigidbody>().isKinematic = true;
		}
		if (this.store.GetComponent<StoreC>().unPaidCatalogue.Count > 0)
		{
			this.store.GetComponent<StoreC>().unPaidCatalogue.RemoveAt(0);
		}
		this.isInUnpaidCatalogue = false;
		this.store.GetComponent<StoreC>().GateCheck();
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x000BA8E8 File Offset: 0x000B8CE8
	public void ReturnToShelfFromKart()
	{
		base.transform.parent = this.returnPosition.transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		if (base.GetComponent<Rigidbody>() && base.GetComponent<Rigidbody>().useGravity)
		{
			base.GetComponent<Rigidbody>().useGravity = false;
			base.GetComponent<Rigidbody>().isKinematic = true;
		}
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x000BA964 File Offset: 0x000B8D64
	public void DropNoRigidbody()
	{
		if (this.returnObject == null)
		{
			return;
		}
		base.transform.parent = this.returnObject.transform;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().posAdjust,
			"islocal",
			true,
			"time",
			1.0,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"SetToReturnObject",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().posAdjust,
			"islocal",
			true,
			"time",
			0.75,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x000BAAA8 File Offset: 0x000B8EA8
	public void SetToReturnObject()
	{
		base.transform.localPosition = Vector3.zero;
		base.transform.localEulerAngles = Vector3.zero;
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x000BAAF4 File Offset: 0x000B8EF4
	public void DropOff()
	{
		base.gameObject.layer = LayerMask.NameToLayer("Default");
		Transform[] componentsInChildren = base.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		base.transform.parent = this.targetDropOff.transform;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().posAdjust,
			"time",
			0.2,
			"islocal",
			true,
			"easetype",
			"easeinquint",
			"oncomplete",
			"DropOffSecure",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().rotAdjust,
			"time",
			0.15,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x000BAC74 File Offset: 0x000B9074
	public void DropOffSecure()
	{
		this.targetDropOff.SendMessage("DropOff");
		if (this.isEngineComponent)
		{
			base.transform.parent = this.targetDropOff.transform;
			base.transform.localPosition = this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().posAdjust;
			base.transform.localEulerAngles = this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().rotAdjust;
			if (base.GetComponent<EngineComponentC>() && base.GetComponent<EngineComponentC>().bolt != null)
			{
				base.GetComponent<EngineComponentC>().UnsecuredWheel();
			}
		}
		else
		{
			base.transform.parent = this.targetDropOff.transform;
			base.transform.localPosition = this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().posAdjust;
			base.transform.localEulerAngles = this.targetDropOff.gameObject.GetComponent<HoldingLogicC>().rotAdjust;
		}
		this.targetDropOff.GetComponent<HoldingLogicC>().targetObject = base.gameObject;
		base.gameObject.SendMessage("AllowFunctionality", SendMessageOptions.DontRequireReceiver);
		if (base.GetComponent<FixDoorScriptC>())
		{
			GameObject gameObject = GameObject.FindWithTag("CarLogic");
			gameObject.GetComponent<CarLogicC>().doorFitted = true;
		}
		this._camera.GetComponent<DragRigidbodyC>().droppingOff = false;
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x000BADE0 File Offset: 0x000B91E0
	public void RaycastEnter()
	{
		this.isGlowing = true;
		foreach (GameObject gameObject in this.renderTargets)
		{
			if (gameObject != null)
			{
				gameObject.GetComponent<Renderer>().material = this.glowMaterial;
			}
		}
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x000BAE30 File Offset: 0x000B9230
	public void RaycastExit()
	{
		this.isGlowing = false;
		foreach (GameObject gameObject in this.renderTargets)
		{
			if (gameObject != null)
			{
				gameObject.GetComponent<Renderer>().material = this.startMaterial;
			}
		}
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x000BAE80 File Offset: 0x000B9280
	public void LoadRendersFromSave()
	{
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.countryMat[this.tradeGoodCountryCode];
		}
		this.glowMaterial = this.glowMat[this.tradeGoodCountryCode];
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x000BAED8 File Offset: 0x000B92D8
	public void RandomAudio()
	{
		float pitch = UnityEngine.Random.Range(0.9f, 1.1f);
		base.GetComponent<AudioSource>().pitch = pitch;
		int num = UnityEngine.Random.Range(0, this._audio.Length);
		base.GetComponent<AudioSource>().PlayOneShot(this._audio[num], 1f);
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x000BAF28 File Offset: 0x000B9328
	public void ShopOutOfInventory()
	{
		if (this.inventoryPlacedAt != null)
		{
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().isOccupied = false;
			if (!this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().isHomeInventory && !this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().isCrateInventory)
			{
				GameObject gameObject = GameObject.FindWithTag("CarLogic");
				gameObject.GetComponent<CarPerformanceC>().carBootWeight -= this.rigidMass;
				gameObject.GetComponent<CarPerformanceC>().totalCarWeight -= this.rigidMass;
				gameObject.GetComponent<CarPerformanceC>().UpdateWeight();
				if (gameObject.GetComponent<CarPerformanceC>().frontLeftTyre != null)
				{
					EngineComponentC component = gameObject.GetComponent<CarPerformanceC>().frontLeftTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(1, component.roadGrip, component.Condition, component.durability, gameObject.GetComponent<CarPerformanceC>().frontLeftTyre, component.wetGrip, component.offRoadGrip);
				}
				if (gameObject.GetComponent<CarPerformanceC>().frontRightTyre != null)
				{
					EngineComponentC component2 = gameObject.GetComponent<CarPerformanceC>().frontRightTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(2, component2.roadGrip, component2.Condition, component2.durability, gameObject.GetComponent<CarPerformanceC>().frontRightTyre, component2.wetGrip, component2.offRoadGrip);
				}
				if (gameObject.GetComponent<CarPerformanceC>().rearLeftTyre != null)
				{
					EngineComponentC component3 = gameObject.GetComponent<CarPerformanceC>().rearLeftTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(3, component3.roadGrip, component3.Condition, component3.durability, gameObject.GetComponent<CarPerformanceC>().rearLeftTyre, component3.wetGrip, component3.offRoadGrip);
				}
				if (gameObject.GetComponent<CarPerformanceC>().rearRightTyre != null)
				{
					EngineComponentC component4 = gameObject.GetComponent<CarPerformanceC>().rearRightTyre.GetComponent<EngineComponentC>();
					gameObject.GetComponent<CarPerformanceC>().UpdateGrip(4, component4.roadGrip, component4.Condition, component4.durability, gameObject.GetComponent<CarPerformanceC>().rearRightTyre, component4.wetGrip, component4.offRoadGrip);
				}
			}
			if (this.dimensionY == 2 && this.dimensionX == 1 && this.dimensionZ == 1)
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().spaceAbove.GetComponent<InventoryRelayC>().isOccupied = false;
			}
			if (this.inventoryPlacedAt.name == "2x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "3x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x1x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x2x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "2x1x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "3x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x2")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x3")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x1x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			if (this.inventoryPlacedAt.name == "4x2x1")
			{
				this.inventoryPlacedAt.GetComponent<InventoryRelayC>().UnOccupy();
			}
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().AvailableSlotCount();
			this.inventoryPlacedAt.GetComponent<InventoryRelayC>().inventoryBase.GetComponent<InventoryLogicC>().UpdateInventory();
			this.inventoryPlacedAt = null;
		}
	}

	// Token: 0x04000B26 RID: 2854
	private GameObject director;

	// Token: 0x04000B27 RID: 2855
	private GameObject _camera;

	// Token: 0x04000B28 RID: 2856
	public int objectID;

	// Token: 0x04000B29 RID: 2857
	public int isInGarbageCollection = -1;

	// Token: 0x04000B2A RID: 2858
	public string supplyName = string.Empty;

	// Token: 0x04000B2B RID: 2859
	public Transform store;

	// Token: 0x04000B2C RID: 2860
	public Vector3 adjustScale;

	// Token: 0x04000B2D RID: 2861
	public Vector3 positionAdjust;

	// Token: 0x04000B2E RID: 2862
	public Vector3 setRotation;

	// Token: 0x04000B2F RID: 2863
	public Vector3 throwRotAdjustment;

	// Token: 0x04000B30 RID: 2864
	public GameObject returnObject;

	// Token: 0x04000B31 RID: 2865
	public GameObject[] renderTargets = new GameObject[1];

	// Token: 0x04000B32 RID: 2866
	public GameObject[] dropOffPoints = new GameObject[0];

	// Token: 0x04000B33 RID: 2867
	public GameObject targetDropOff;

	// Token: 0x04000B34 RID: 2868
	public Material glowMaterial;

	// Token: 0x04000B35 RID: 2869
	public bool isTransparent;

	// Token: 0x04000B36 RID: 2870
	public Material startMaterial;

	// Token: 0x04000B37 RID: 2871
	public bool isGlowing;

	// Token: 0x04000B38 RID: 2872
	public GameObject throwLogicTarget;

	// Token: 0x04000B39 RID: 2873
	public GameObject placedAt;

	// Token: 0x04000B3A RID: 2874
	public bool isEngineComponent;

	// Token: 0x04000B3B RID: 2875
	public bool isBeingRemoved;

	// Token: 0x04000B3C RID: 2876
	public bool isInEngine;

	// Token: 0x04000B3D RID: 2877
	public bool isInGateLock;

	// Token: 0x04000B3E RID: 2878
	private bool stillInGateLock;

	// Token: 0x04000B3F RID: 2879
	public Transform previousParent;

	// Token: 0x04000B40 RID: 2880
	public string engineString = string.Empty;

	// Token: 0x04000B41 RID: 2881
	public GameObject additionalLocObj;

	// Token: 0x04000B42 RID: 2882
	public Transform additionalLocObjTarget;

	// Token: 0x04000B43 RID: 2883
	public AudioClip[] _audio = new AudioClip[0];

	// Token: 0x04000B44 RID: 2884
	public GameObject particleObj;

	// Token: 0x04000B45 RID: 2885
	public bool locked;

	// Token: 0x04000B46 RID: 2886
	private bool animating;

	// Token: 0x04000B47 RID: 2887
	public int dimensionX = 1;

	// Token: 0x04000B48 RID: 2888
	public int dimensionY = 1;

	// Token: 0x04000B49 RID: 2889
	public int dimensionZ = 1;

	// Token: 0x04000B4A RID: 2890
	public Vector3 inventoryAdjustPosition;

	// Token: 0x04000B4B RID: 2891
	public Vector3 inventoryAdjustRotation;

	// Token: 0x04000B4C RID: 2892
	public Transform inventoryPlacedAt;

	// Token: 0x04000B4D RID: 2893
	public Transform bootPlacedAt;

	// Token: 0x04000B4E RID: 2894
	public float rigidMass;

	// Token: 0x04000B4F RID: 2895
	public bool isTweenTransition;

	// Token: 0x04000B50 RID: 2896
	public float distanceForDrop;

	// Token: 0x04000B51 RID: 2897
	public GameObject connectedTo;

	// Token: 0x04000B52 RID: 2898
	public bool isPurchased = true;

	// Token: 0x04000B53 RID: 2899
	public bool isInShoppingKart;

	// Token: 0x04000B54 RID: 2900
	public Transform returnPosition;

	// Token: 0x04000B55 RID: 2901
	public float shopValue;

	// Token: 0x04000B56 RID: 2902
	public float buyValue;

	// Token: 0x04000B57 RID: 2903
	public float sellValue;

	// Token: 0x04000B58 RID: 2904
	[HideInInspector]
	public float originalSellValue;

	// Token: 0x04000B59 RID: 2905
	public GameObject buyPriceObj;

	// Token: 0x04000B5A RID: 2906
	public GameObject sellPriceObj;

	// Token: 0x04000B5B RID: 2907
	[HideInInspector]
	public bool crateSpawned;

	// Token: 0x04000B5C RID: 2908
	public Vector3 dropOffPosAdjustment;

	// Token: 0x04000B5D RID: 2909
	public Vector3 dropOffRotAdjustment;

	// Token: 0x04000B5E RID: 2910
	public bool isTradeGood;

	// Token: 0x04000B5F RID: 2911
	[HideInInspector]
	public bool hasBeenTradeUpdated;

	// Token: 0x04000B60 RID: 2912
	public int tradeGoodCountryCode;

	// Token: 0x04000B61 RID: 2913
	public Material[] countryMat = new Material[0];

	// Token: 0x04000B62 RID: 2914
	public Material[] glowMat = new Material[0];

	// Token: 0x04000B63 RID: 2915
	public int supplyNumber;

	// Token: 0x04000B64 RID: 2916
	[HideInInspector]
	public bool forceCollision;

	// Token: 0x04000B65 RID: 2917
	public bool isToolRackComponent;

	// Token: 0x04000B66 RID: 2918
	private bool isInUnpaidCatalogue;

	// Token: 0x04000B67 RID: 2919
	public bool morningShop;

	// Token: 0x04000B68 RID: 2920
	public string componentHeader;

	// Token: 0x04000B69 RID: 2921
	public string flavourText;
}
