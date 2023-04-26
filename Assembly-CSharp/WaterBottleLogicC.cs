using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200012A RID: 298
public class WaterBottleLogicC : MonoBehaviour
{
	// Token: 0x06000C27 RID: 3111 RVA: 0x001277F9 File Offset: 0x00125BF9
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x06000C28 RID: 3112 RVA: 0x0012781C File Offset: 0x00125C1C
	public void Action()
	{
		if (this.isInAction)
		{
			return;
		}
		this.isInAction = true;
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		if (this.hitTarget.GetComponent<EngineComponentC>().currentWaterCharges == this.hitTarget.GetComponent<EngineComponentC>().totalWaterCharges)
		{
			this.UnAction();
			return;
		}
		if (this.waterLevel == 0)
		{
			this.UnAction();
			return;
		}
		if (!this.hitTarget.transform.GetChild(0).GetComponent<WaterSupplyRelayC>().lidOpen)
		{
			this.hitTarget.transform.GetChild(0).gameObject.SetActive(true);
			this.hitTarget.transform.GetChild(0).SendMessage("LidUp");
		}
		base.transform.parent = this.hitTarget.transform;
		this.hitTarget.GetComponent<EngineComponentC>().WaterTankDurabilityCalc();
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
		if (this.waterLevel > 0)
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.pourAudio, 1f);
			this.waterParticles.GetComponent<ParticleSystem>().Play();
			this.hitTarget.SendMessage("Action");
			this.waterLevel--;
			this.WaterUpdate();
		}
		else
		{
			base.GetComponent<AudioSource>().PlayOneShot(this.pourEmptyAudio, 1f);
		}
		this.hitTarget = null;
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x00127BA0 File Offset: 0x00125FA0
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

	// Token: 0x06000C2A RID: 3114 RVA: 0x00127C14 File Offset: 0x00126014
	public void ActionPart2()
	{
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
		if (this.isTutorial)
		{
			GameObject waterTankObj = this.carLogic.GetComponent<CarPerformanceC>().waterTankObj;
			if (waterTankObj.GetComponent<EngineComponentC>().currentWaterCharges == waterTankObj.GetComponent<EngineComponentC>().totalWaterCharges)
			{
				GameObject gameObject = GameObject.FindWithTag("Uncle");
				gameObject.GetComponent<Scene1_LogicC>().StartCoroutine("DropHolding");
				gameObject.GetComponent<Scene1_LogicC>().fuelAndOilTutorialWaterFinished = true;
				this.isTutorial = false;
			}
		}
	}

	// Token: 0x06000C2B RID: 3115 RVA: 0x00127E94 File Offset: 0x00126294
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

	// Token: 0x06000C2C RID: 3116 RVA: 0x00127F64 File Offset: 0x00126364
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

	// Token: 0x06000C2D RID: 3117 RVA: 0x00127FF0 File Offset: 0x001263F0
	public void WaterUpdate()
	{
		if (this.waterLevel == 3)
		{
			this.waterLowObject.active = true;
			this.waterMedObject.active = true;
			this.waterHighObject.active = true;
			base.GetComponent<ObjectPickupC>().sellValue = 3f;
		}
		if (this.waterLevel == 2)
		{
			this.waterLowObject.active = true;
			this.waterMedObject.active = true;
			this.waterHighObject.active = false;
			base.GetComponent<ObjectPickupC>().sellValue = 2f;
		}
		if (this.waterLevel == 1)
		{
			this.waterLowObject.active = true;
			this.waterMedObject.active = false;
			this.waterHighObject.active = false;
			base.GetComponent<ObjectPickupC>().sellValue = 1f;
		}
		if (this.waterLevel == 0)
		{
			this.waterLowObject.active = false;
			this.waterMedObject.active = false;
			this.waterHighObject.active = false;
			base.GetComponent<ObjectPickupC>().sellValue = 0f;
		}
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x001280FC File Offset: 0x001264FC
	private IEnumerator FillBottleColdWater()
	{
		this.waterLowObject.gameObject.GetComponent<Renderer>().material.color = this.cleanColor;
		this.waterMedObject.gameObject.GetComponent<Renderer>().material.color = this.cleanColor;
		this.waterHighObject.gameObject.GetComponent<Renderer>().material.color = this.cleanColor;
		if (this.waterLevel == 0)
		{
			int random = UnityEngine.Random.Range(0, this.fillAudio.Length);
			this.waterLevel = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[random], 1f);
			this.waterLowObject.active = true;
			yield return new WaitForSeconds(0.2f);
		}
		if (this.waterLevel == 1)
		{
			int random2 = UnityEngine.Random.Range(0, this.fillAudio.Length);
			this.waterLevel = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[random2], 1f);
			this.waterLowObject.active = false;
			this.waterMedObject.active = true;
			yield return new WaitForSeconds(0.2f);
		}
		if (this.waterLevel == 2)
		{
			int num = UnityEngine.Random.Range(0, this.fillAudio.Length);
			this.waterLevel = 3;
			base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[num], 1f);
			this.waterLowObject.active = false;
			this.waterMedObject.active = false;
			this.waterHighObject.active = true;
		}
		yield break;
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x00128118 File Offset: 0x00126518
	private IEnumerator FillBottleHotWater()
	{
		if (this.waterLevel == 0)
		{
			this.waterLowObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterMedObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterHighObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.isDirty = true;
			int random = UnityEngine.Random.Range(0, this.fillAudio.Length);
			this.waterLevel = 1;
			base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[random], 1f);
			this.waterLowObject.active = true;
			yield return new WaitForSeconds(0.2f);
		}
		if (this.waterLevel == 1)
		{
			this.waterLowObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterMedObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterHighObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.isDirty = true;
			int random2 = UnityEngine.Random.Range(0, this.fillAudio.Length);
			this.waterLevel = 2;
			base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[random2], 1f);
			this.waterLowObject.active = false;
			this.waterMedObject.active = true;
			yield return new WaitForSeconds(0.2f);
		}
		int random3 = UnityEngine.Random.Range(0, this.fillAudio.Length);
		if (this.waterLevel == 2)
		{
			this.waterLowObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterMedObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterHighObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.isDirty = true;
			this.waterLevel = 3;
			base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[random3], 1f);
			this.waterLowObject.active = false;
			this.waterMedObject.active = false;
			this.waterHighObject.active = true;
		}
		if (this.waterLevel == 3 && !this.isDirty)
		{
			this.waterLowObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterMedObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.waterHighObject.gameObject.GetComponent<Renderer>().material.color = this.dirtyColor;
			this.isDirty = true;
			base.GetComponent<AudioSource>().PlayOneShot(this.fillAudio[random3], 1f);
		}
		yield break;
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x00128134 File Offset: 0x00126534
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

	// Token: 0x06000C31 RID: 3121 RVA: 0x001281B4 File Offset: 0x001265B4
	public void StopPlacedAnimate()
	{
		iTween.Stop(base.gameObject);
	}

	// Token: 0x040010A7 RID: 4263
	[HideInInspector]
	public GameObject carLogic;

	// Token: 0x040010A8 RID: 4264
	private GameObject _camera;

	// Token: 0x040010A9 RID: 4265
	public int waterLevel;

	// Token: 0x040010AA RID: 4266
	public GameObject waterLowObject;

	// Token: 0x040010AB RID: 4267
	public GameObject waterMedObject;

	// Token: 0x040010AC RID: 4268
	public GameObject waterHighObject;

	// Token: 0x040010AD RID: 4269
	public Vector3[] rotation = new Vector3[0];

	// Token: 0x040010AE RID: 4270
	public Vector3[] position = new Vector3[0];

	// Token: 0x040010AF RID: 4271
	public float timeToComplete;

	// Token: 0x040010B0 RID: 4272
	public string easeType1 = string.Empty;

	// Token: 0x040010B1 RID: 4273
	public string easeType2 = string.Empty;

	// Token: 0x040010B2 RID: 4274
	public GameObject waterParticles;

	// Token: 0x040010B3 RID: 4275
	public AudioClip[] fillAudio = new AudioClip[0];

	// Token: 0x040010B4 RID: 4276
	public AudioClip pourAudio;

	// Token: 0x040010B5 RID: 4277
	public AudioClip pourEmptyAudio;

	// Token: 0x040010B6 RID: 4278
	public bool isDirty;

	// Token: 0x040010B7 RID: 4279
	public Color dirtyColor;

	// Token: 0x040010B8 RID: 4280
	public Color cleanColor;

	// Token: 0x040010B9 RID: 4281
	public GameObject lidObject;

	// Token: 0x040010BA RID: 4282
	public Vector3[] animatedLidPos = new Vector3[0];

	// Token: 0x040010BB RID: 4283
	public Vector3[] animatedLidRot = new Vector3[0];

	// Token: 0x040010BC RID: 4284
	public bool isTutorial;

	// Token: 0x040010BD RID: 4285
	public GameObject hitTarget;

	// Token: 0x040010BE RID: 4286
	private bool isInAction;
}
