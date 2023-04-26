using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000DB RID: 219
public class OilBottleC : MonoBehaviour
{
	// Token: 0x0600089A RID: 2202 RVA: 0x000BC2B9 File Offset: 0x000BA6B9
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x000BC2DC File Offset: 0x000BA6DC
	public void Action()
	{
		if (this.isInAction)
		{
			return;
		}
		this.isInAction = true;
		iTween.Stop(base.gameObject);
		base.transform.localPosition = base.GetComponent<ObjectPickupC>().positionAdjust;
		GameObject gameObject;
		if (base.GetComponent<ObjectInteractionsC>().target.transform.parent)
		{
			gameObject = base.GetComponent<ObjectInteractionsC>().target.transform.parent.gameObject;
		}
		else
		{
			gameObject = base.GetComponent<ObjectInteractionsC>().target;
		}
		GameObject target = base.GetComponent<ObjectInteractionsC>().target;
		if (gameObject.GetComponent<EngineComponentC>())
		{
			if (gameObject.GetComponent<EngineComponentC>().fuelMix == 3)
			{
				this.UnAction();
				return;
			}
			target.GetComponent<FuelSupplyRelayC>().fuelLid.transform.parent.SendMessage("LidOpen");
			base.transform.parent = target.transform;
			this.SetLayerRecursively(base.gameObject, 0);
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
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				this.rotation[0],
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
			if (this.animatedLidPos.Length > 0)
			{
				iTween.MoveTo(this.lidObject, iTween.Hash(new object[]
				{
					"position",
					this.animatedLidPos[0],
					"islocal",
					true,
					"time",
					this.timeToComplete / 2f,
					"easetype",
					this.easeType1
				}));
				iTween.RotateTo(this.lidObject, iTween.Hash(new object[]
				{
					"rotation",
					this.animatedLidRot[0],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType1
				}));
			}
			if (this.oilLevel > 0)
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.pourAudio, 1f);
				this.waterParticles.GetComponent<ParticleSystem>().Play();
				target.SendMessage("OilAction");
				this.oilLevel--;
				this.OilUpdate();
				gameObject.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
			}
			else
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.pourEmptyAudio, 1f);
			}
		}
		else if (base.GetComponent<ObjectInteractionsC>().target.GetComponent<PortableFuelC>() && ES3.Exists("uncleTutorialCompleted"))
		{
			base.GetComponent<ObjectInteractionsC>().target.GetComponent<PortableFuelC>().animationTarget.GetComponent<Animator>().SetBool("gasCanOpen", true);
			base.transform.parent = base.GetComponent<ObjectInteractionsC>().target.transform;
			this.SetLayerRecursively(base.gameObject, 0);
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				base.GetComponent<ObjectInteractionsC>().target.GetComponent<PortableFuelC>().oilBottlePosition.localPosition,
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
				base.GetComponent<ObjectInteractionsC>().target.GetComponent<PortableFuelC>().oilBottlePosition.localEulerAngles,
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
			if (this.animatedLidPos.Length > 0)
			{
				iTween.MoveTo(this.lidObject, iTween.Hash(new object[]
				{
					"position",
					this.animatedLidPos[0],
					"islocal",
					true,
					"time",
					this.timeToComplete / 2f,
					"easetype",
					this.easeType1
				}));
				iTween.RotateTo(this.lidObject, iTween.Hash(new object[]
				{
					"rotation",
					this.animatedLidRot[0],
					"islocal",
					true,
					"time",
					this.timeToComplete,
					"easetype",
					this.easeType1
				}));
			}
			if (this.oilLevel > 0 && base.GetComponent<ObjectInteractionsC>().target.GetComponent<PortableFuelC>().fuelMix < 3)
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.pourAudio, 1f);
				this.waterParticles.GetComponent<ParticleSystem>().Play();
				base.GetComponent<ObjectInteractionsC>().target.SendMessage("OilAction");
				this.oilLevel--;
				this.OilUpdate();
				if (gameObject.GetComponent<EngineComponentC>())
				{
					gameObject.GetComponent<EngineComponentC>().fuelTillOilDown = 3;
				}
				else if (gameObject.GetComponent<PortableFuelC>())
				{
					gameObject.GetComponent<PortableFuelC>().fuelTillOilDown = 3;
				}
			}
			else
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.pourEmptyAudio, 1f);
			}
		}
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x000BC9A4 File Offset: 0x000BADA4
	public void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
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

	// Token: 0x0600089D RID: 2205 RVA: 0x000BCA18 File Offset: 0x000BAE18
	public void ActionPart2()
	{
		if (!base.transform.parent.GetComponent<PortableFuelC>())
		{
			if (this.isTutorial)
			{
				GameObject installedFuelTank = this.carLogic.GetComponent<CarPerformanceC>().installedFuelTank;
				if (installedFuelTank.GetComponent<EngineComponentC>().fuelMix != 0)
				{
					GameObject gameObject = GameObject.FindWithTag("Uncle");
					gameObject.GetComponent<Scene1_LogicC>().StartCoroutine("DropHolding");
					gameObject.GetComponent<Scene1_LogicC>().fuelAndOilTutorialOilFinished = true;
					this.isTutorial = false;
				}
			}
		}
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1.transform;
		this.isInAction = false;
		this.SetLayerRecursively(base.gameObject, 11);
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[1],
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
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
		if (this.animatedLidPos.Length > 0)
		{
			iTween.MoveTo(this.lidObject, iTween.Hash(new object[]
			{
				"position",
				this.animatedLidPos[1],
				"islocal",
				true,
				"time",
				this.timeToComplete / 2f,
				"easetype",
				this.easeType1
			}));
			iTween.RotateTo(this.lidObject, iTween.Hash(new object[]
			{
				"rotation",
				this.animatedLidRot[1],
				"islocal",
				true,
				"time",
				this.timeToComplete,
				"easetype",
				this.easeType1
			}));
		}
		GameObject target = base.GetComponent<ObjectInteractionsC>().target;
		if (target.GetComponent<FuelSupplyRelayC>())
		{
			target.GetComponent<FuelSupplyRelayC>().fuelLid.transform.parent.SendMessage("LidClose");
		}
		else if (target.GetComponent<PortableFuelC>())
		{
			target.GetComponent<PortableFuelC>().SendMessage("LidClose");
		}
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x000BCD0C File Offset: 0x000BB10C
	public void UnAction()
	{
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[1];
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
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

	// Token: 0x0600089F RID: 2207 RVA: 0x000BCDDC File Offset: 0x000BB1DC
	public void UnActionPart2()
	{
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
		this.isInAction = false;
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x000BCE68 File Offset: 0x000BB268
	public void OilUpdate()
	{
		if (this.oilLevel == 3)
		{
			this.oilLowObject.SetActive(true);
			this.oilMedObject.SetActive(true);
			this.oilHighObject.SetActive(true);
		}
		if (this.oilLevel == 2)
		{
			this.oilLowObject.SetActive(true);
			this.oilMedObject.SetActive(true);
			this.oilHighObject.SetActive(false);
		}
		if (this.oilLevel == 1)
		{
			this.oilLowObject.SetActive(true);
			this.oilMedObject.SetActive(false);
			this.oilHighObject.SetActive(false);
		}
		if (this.oilLevel == 0)
		{
			this.oilLowObject.SetActive(false);
			this.oilMedObject.SetActive(false);
			this.oilHighObject.SetActive(false);
		}
		if (this._camera == null)
		{
			this._camera = Camera.main.gameObject;
		}
		this._camera.GetComponent<DragRigidbodyC>().SetEngineCompUI1();
	}

	// Token: 0x04000B6C RID: 2924
	private GameObject _camera;

	// Token: 0x04000B6D RID: 2925
	[HideInInspector]
	public GameObject carLogic;

	// Token: 0x04000B6E RID: 2926
	public GameObject lidObject;

	// Token: 0x04000B6F RID: 2927
	public int oilLevel;

	// Token: 0x04000B70 RID: 2928
	public GameObject waterParticles;

	// Token: 0x04000B71 RID: 2929
	public GameObject oilLowObject;

	// Token: 0x04000B72 RID: 2930
	public GameObject oilMedObject;

	// Token: 0x04000B73 RID: 2931
	public GameObject oilHighObject;

	// Token: 0x04000B74 RID: 2932
	public AudioClip pourAudio;

	// Token: 0x04000B75 RID: 2933
	public AudioClip pourEmptyAudio;

	// Token: 0x04000B76 RID: 2934
	public Vector3[] rotation = new Vector3[0];

	// Token: 0x04000B77 RID: 2935
	public Vector3[] position = new Vector3[0];

	// Token: 0x04000B78 RID: 2936
	public float timeToComplete;

	// Token: 0x04000B79 RID: 2937
	public string easeType1 = string.Empty;

	// Token: 0x04000B7A RID: 2938
	public string easeType2 = string.Empty;

	// Token: 0x04000B7B RID: 2939
	public Vector3[] animatedLidPos = new Vector3[0];

	// Token: 0x04000B7C RID: 2940
	public Vector3[] animatedLidRot = new Vector3[0];

	// Token: 0x04000B7D RID: 2941
	public bool isTutorial;

	// Token: 0x04000B7E RID: 2942
	private bool isInAction;
}
