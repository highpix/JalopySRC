using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000F1 RID: 241
public class RepairKitC : MonoBehaviour
{
	// Token: 0x0600097D RID: 2429 RVA: 0x000E1B74 File Offset: 0x000DFF74
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		if (!this.isToolRack && !this.isTyreRepairKit)
		{
			this.spanner.transform.localPosition = this.position[0];
			this.spanner.transform.localEulerAngles = this.rotation[0];
		}
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x000E1BFC File Offset: 0x000DFFFC
	public void TyreRepairKitAction(GameObject engComp)
	{
		this.restrictAction = true;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		this.target = engComp;
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"TyreRepairKitRot",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[1],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x000E1D2F File Offset: 0x000E012F
	public void TyreRepairKitRot()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[0], 1.9f);
		this.target.GetComponent<EngineComponentC>().TyreRepairKitActions();
		this.Destroy();
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x000E1D60 File Offset: 0x000E0160
	public void ToolRackAction(GameObject engComp)
	{
		if (this.restrictAction)
		{
			return;
		}
		if ((double)engComp.GetComponent<EngineComponentC>().roadGrip > 0.0)
		{
			return;
		}
		this.restrictAction = true;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		this.target = engComp;
		this.carLogic.GetComponent<CarLogicC>().uncle.GetComponent<UncleLogicC>().PlayerRepairedCar();
		iTween.MoveTo(this.spanner, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"ToolRackSpannerRot",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[1],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x000E1ED4 File Offset: 0x000E02D4
	public void Action(GameObject engComp)
	{
		MonoBehaviour.print("repair kit action");
		if (!base.GetComponent<ObjectPickupC>().isPurchased)
		{
			return;
		}
		if (this.restrictAction)
		{
			return;
		}
		if (engComp.GetComponent<EngineComponentC>())
		{
			if (this.isTyreRepairKit)
			{
				if ((double)engComp.GetComponent<EngineComponentC>().roadGrip <= 0.0 && (double)engComp.GetComponent<EngineComponentC>().wetGrip <= 0.0 && (double)engComp.GetComponent<EngineComponentC>().offRoadGrip <= 0.0)
				{
					return;
				}
				if ((double)engComp.GetComponent<EngineComponentC>().Condition >= 1.0)
				{
					return;
				}
				if (engComp.GetComponent<ObjectPickupC>().isInEngine)
				{
					this.TyreRepairKitAction(engComp);
					return;
				}
				return;
			}
			else if ((double)engComp.GetComponent<EngineComponentC>().roadGrip > 0.0 || (double)engComp.GetComponent<EngineComponentC>().wetGrip > 0.0 || (double)engComp.GetComponent<EngineComponentC>().offRoadGrip > 0.0)
			{
				return;
			}
		}
		this.restrictAction = true;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = true;
		this.target = engComp;
		this.carLogic.GetComponent<CarLogicC>().uncle.GetComponent<UncleLogicC>().PlayerRepairedCar();
		iTween.MoveTo(this.spanner, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"SpannerRot",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[1],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x000E2138 File Offset: 0x000E0538
	public void SpannerRot()
	{
		float condition = this.target.GetComponent<EngineComponentC>().Condition;
		float durability = this.target.GetComponent<EngineComponentC>().durability;
		float num = durability - condition;
		if ((double)num > 1.0)
		{
			num = 1f;
		}
		this.spannerDamageLvl += num;
		if ((double)this.spannerDamageLvl > 3.0)
		{
			float num2 = this.spannerDamageLvl - 3f;
			this.spannerDamageLvl -= num2;
		}
		float num3 = this.spannerDamageLvl / 3f;
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[0], 1.9f);
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[2],
			"time",
			0.3f,
			"islocal",
			true,
			"easetype",
			"easeoutbounce",
			"oncomplete",
			"RepairPart2",
			"oncompletetarget",
			base.gameObject
		}));
		if (this.spannerDamage != null)
		{
			iTween.FadeTo(this.spannerDamage, iTween.Hash(new object[]
			{
				"alpha",
				num3,
				"time",
				0.3f,
				"easetype",
				"easeoutquint"
			}));
		}
		this.target.GetComponent<EngineComponentC>().Condition += num;
		this.target.GetComponent<EngineComponentC>().ReEnableFunctionality();
		this.carLogic.GetComponent<CarPerformanceC>().GetCarCondition();
		this.carLogic.GetComponent<CarLogicC>().CarDamageUp();
		this._camera.GetComponent<DragRigidbodyC>().SetEngineCompUI1();
		if (this.target.GetComponent<EngineComponentC>().TopSpeed != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
		}
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x000E2358 File Offset: 0x000E0758
	public void ToolRackSpannerRot()
	{
		float condition = this.target.GetComponent<EngineComponentC>().Condition;
		float durability = this.target.GetComponent<EngineComponentC>().durability;
		float num = durability * this.spannerDamageLvl;
		if (condition >= num)
		{
			this.restrictAction = false;
			this.StartEnd();
			return;
		}
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[0], 1.9f);
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[2],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutbounce",
			"oncomplete",
			"RepairPart2",
			"oncompletetarget",
			base.gameObject
		}));
		this.target.GetComponent<EngineComponentC>().Condition += 1f;
		if (this.target.GetComponent<EngineComponentC>().Condition > num)
		{
			this.target.GetComponent<EngineComponentC>().Condition = num;
		}
		this.target.GetComponent<EngineComponentC>().ReEnableFunctionality();
		this.carLogic.GetComponent<CarPerformanceC>().GetCarCondition();
		this.carLogic.GetComponent<CarLogicC>().CarDamageUp();
		this._camera.GetComponent<DragRigidbodyC>().SetEngineCompUI1();
		if (this.target.GetComponent<EngineComponentC>().TopSpeed != 0f)
		{
			this.carLogic.GetComponent<CarPerformanceC>().UpdatePerformanceTopSpeed();
		}
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x000E2500 File Offset: 0x000E0900
	public void Destroy()
	{
		GameObject obj = UnityEngine.Object.Instantiate<GameObject>(this.breakParticles, base.transform.position, Quaternion.identity);
		UnityEngine.Object.Destroy(obj, 0.82f);
		Transform parent = this._camera.transform.parent;
		this.SetLayerRecursively(base.gameObject, 0);
		this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding2 != null)
		{
			this._camera.GetComponent<DragRigidbodyC>().Holding2ToHands();
		}
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		GameObject gameObject = GameObject.FindWithTag("Director");
		gameObject.GetComponent<DirectorC>().repairKitsUsedStats++;
		if (this.spanner != null)
		{
			UnityEngine.Object.Destroy(this.spanner);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x000E25E4 File Offset: 0x000E09E4
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

	// Token: 0x06000986 RID: 2438 RVA: 0x000E2658 File Offset: 0x000E0A58
	public void RepairPart2()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[1], 1.9f);
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[1],
			"time",
			0.3f,
			"islocal",
			true,
			"easetype",
			"easeoutbounce",
			"oncomplete",
			"StartEnd",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x000E270F File Offset: 0x000E0B0F
	private void StartEnd()
	{
		base.StartCoroutine(this.RepairEnd());
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x000E2720 File Offset: 0x000E0B20
	private IEnumerator RepairEnd()
	{
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[0],
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
		iTween.MoveTo(this.spanner, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutquint"
		}));
		if (!this.isToolRack && (double)this.spannerDamageLvl == 3.0)
		{
			this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
			yield return new WaitForSeconds(0.1f);
			this.Destroy();
			yield break;
		}
		this.restrictAction = false;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrictDropPress = false;
		yield break;
	}

	// Token: 0x04000D00 RID: 3328
	private GameObject _camera;

	// Token: 0x04000D01 RID: 3329
	public bool isToolRack;

	// Token: 0x04000D02 RID: 3330
	public bool isTyreRepairKit;

	// Token: 0x04000D03 RID: 3331
	[HideInInspector]
	public GameObject carLogic;

	// Token: 0x04000D04 RID: 3332
	public GameObject spanner;

	// Token: 0x04000D05 RID: 3333
	public AudioClip[] repairAudio = new AudioClip[0];

	// Token: 0x04000D06 RID: 3334
	public GameObject spannerDamage;

	// Token: 0x04000D07 RID: 3335
	public Vector3[] position = new Vector3[0];

	// Token: 0x04000D08 RID: 3336
	public Vector3[] rotation = new Vector3[0];

	// Token: 0x04000D09 RID: 3337
	public float spannerDamageLvl;

	// Token: 0x04000D0A RID: 3338
	public GameObject breakParticles;

	// Token: 0x04000D0B RID: 3339
	public bool restrictAction;

	// Token: 0x04000D0C RID: 3340
	private GameObject target;
}
