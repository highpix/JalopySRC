using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A5 RID: 165
public class EngineRepairKitC : MonoBehaviour
{
	// Token: 0x06000584 RID: 1412 RVA: 0x00071F29 File Offset: 0x00070329
	public void Start()
	{
		this._camera = Camera.main.gameObject;
		this.carLogic = GameObject.FindWithTag("CarLogic");
		base.GetComponent<ObjectPickupC>().dropOffPoints[0] = this.carLogic.GetComponent<CarLogicC>().engineObject;
	}

	// Token: 0x06000585 RID: 1413 RVA: 0x00071F68 File Offset: 0x00070368
	public void Update()
	{
		if (this.repairState && this.repairAction && Input.GetMouseButtonDown(0))
		{
			this.Repair();
		}
		if (this.repairState && this.repairAction && Input.GetMouseButtonDown(1))
		{
			this.Exit();
		}
		if (this.repairState && this.repairAction && Input.GetButtonDown("Pause"))
		{
			this.Exit();
		}
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x00071FF0 File Offset: 0x000703F0
	public void Exit()
	{
		this._camera.GetComponent<DragRigidbodyC>().isHolding1 = base.gameObject;
		this.repairState = false;
		this.repairAction = false;
		this.carLogic.GetComponent<CarLogicC>().engineObject.GetComponent<Collider>().enabled = true;
		base.gameObject.GetComponent<Collider>().enabled = true;
		this.spanner.transform.parent = base.transform;
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1;
		this.SetLayerRecursively(base.gameObject, 11);
		iTween.MoveTo(this.spanner, iTween.Hash(new object[]
		{
			"position",
			new Vector3(0.07198906f, 0.07198906f, -0.2206726f),
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(-25.05203f, 33.75714f, -96.08569f),
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			base.GetComponent<ObjectPickupC>().positionAdjust,
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeinquint",
			"oncomplete",
			"RepairStateExit",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			base.GetComponent<ObjectPickupC>().setRotation,
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x00072270 File Offset: 0x00070670
	public void Action()
	{
		this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
		this.carLogic.GetComponent<CarLogicC>().engineObject.GetComponent<Collider>().enabled = false;
		base.gameObject.GetComponent<Collider>().enabled = false;
		this.SetLayerRecursively(base.gameObject, 0);
		this.RepairStateGo();
		this.spanner.transform.parent = this.carLogic.GetComponent<CarLogicC>().engineBolt.transform;
		base.transform.parent = this.carLogic.GetComponent<CarLogicC>().repairKitLoc;
		this.ObjectsToEngine();
	}

	// Token: 0x06000588 RID: 1416 RVA: 0x00072314 File Offset: 0x00070714
	public void UnAction()
	{
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutbounce",
			"oncomplete",
			"UnActionPart2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000589 RID: 1417 RVA: 0x000723E0 File Offset: 0x000707E0
	public void UnActionPart2()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x00072460 File Offset: 0x00070860
	public void RepairStateGo()
	{
		this.repairState = true;
		Transform parent = this._camera.transform.parent;
		this._camera.GetComponent<DragRigidbodyC>().enabled = false;
		MainMenuC.Global.enabled = false;
		this._camera.GetComponent<MouseLook>().canZoomBreaker = true;
		this._camera.GetComponent<MouseLook>().enabled = false;
		this._camera.GetComponent<HeadBobberC>().enabled = false;
		parent.gameObject.GetComponent<MouseLook>().enabled = false;
		parent.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		parent.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = false;
		this.SetCamera();
	}

	// Token: 0x0600058B RID: 1419 RVA: 0x00072526 File Offset: 0x00070926
	public void SetCamera()
	{
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x00072528 File Offset: 0x00070928
	public void RepairActionGo()
	{
		this.repairAction = true;
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x00072534 File Offset: 0x00070934
	public void RepairStateExit()
	{
		this.repairState = false;
		this._camera.GetComponent<MouseLook>().canZoomBreaker = false;
		this.spanner.transform.parent = base.transform;
		base.transform.parent = this._camera.GetComponent<DragRigidbodyC>().holdingParent1;
		Transform parent = this._camera.transform.parent;
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		this._camera.GetComponent<MouseLook>().enabled = true;
		MainMenuC.Global.enabled = true;
		this.SetLayerRecursively(base.gameObject, 0);
		if (!this.carLogic.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().isSat)
		{
			this._camera.GetComponent<HeadBobberC>().enabled = true;
		}
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		parent.gameObject.GetComponent<MouseLook>().enabled = true;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = true;
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x00072638 File Offset: 0x00070A38
	public void ObjectsToEngine()
	{
		iTween.MoveTo(this.spanner, iTween.Hash(new object[]
		{
			"position",
			Vector3.zero,
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeinquint",
			"oncomplete",
			"RepairActionGo",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			Vector3.zero,
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			Vector3.zero,
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(90f, 0f, 0f),
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x00072810 File Offset: 0x00070C10
	public void Repair()
	{
		if (this.carLogic.GetComponent<CarLogicC>().damageLvl == 0)
		{
			this.Exit();
			return;
		}
		this.repairAction = false;
		this.repairKitAmmo--;
		if (this.repairKitAmmo == 0)
		{
			this.RepairFinal();
			return;
		}
		this.carLogic.GetComponent<CarLogicC>().LowerEngineDamage();
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[0], 1.9f);
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(50f, 0f, 0f),
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
		if (this.repairKitAmmo == 2)
		{
			iTween.FadeTo(this.spannerDamage, iTween.Hash(new object[]
			{
				"alpha",
				0.3,
				"time",
				0.3,
				"easetype",
				"easeoutquint"
			}));
		}
		else if (this.repairKitAmmo == 1)
		{
			iTween.FadeTo(this.spannerDamage, iTween.Hash(new object[]
			{
				"alpha",
				0.6,
				"time",
				0.3,
				"easetype",
				"easeoutquint"
			}));
		}
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x000729F0 File Offset: 0x00070DF0
	public void RepairFinal()
	{
		this.carLogic.GetComponent<CarLogicC>().LowerEngineDamage();
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[0], 1.9f);
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(50f, 0f, 0f),
			"time",
			0.3,
			"islocal",
			true,
			"easetype",
			"easeoutbounce",
			"oncomplete",
			"RepairFinal2",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.FadeTo(this.spannerDamage, iTween.Hash(new object[]
		{
			"alpha",
			1.0,
			"time",
			0.3,
			"easetype",
			"easeoutquint"
		}));
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x00072B18 File Offset: 0x00070F18
	public void RepairFinal2()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[2], 1f);
		this.PartsFlyIn();
		iTween.MoveTo(this.spanner, iTween.Hash(new object[]
		{
			"position",
			new Vector3(0f, 0f, -0.5f),
			"time",
			1.0,
			"islocal",
			true,
			"easetype",
			"easeoutquint",
			"oncomplete",
			"RepairEnd",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateBy(this.spanner, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(360f, 0f, 0f),
			"time",
			1.0,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"path",
			new Vector3(0.3548918f, -0.009764655f, 0.2612866f),
			new Vector3(0.6398705f, 0.022585f, -0.6042091f),
			"time",
			1.0,
			"islocal",
			true,
			"easetype",
			"easeoutquint"
		}));
		iTween.RotateBy(base.gameObject, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(360f, 0f, 0f),
			"time",
			1.0,
			"islocal",
			true,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x00072D58 File Offset: 0x00071158
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

	// Token: 0x06000593 RID: 1427 RVA: 0x00072DCC File Offset: 0x000711CC
	public void RepairEnd()
	{
		this.repairState = false;
		this.repairAction = false;
		Transform parent = this._camera.transform.parent;
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		this._camera.GetComponent<MouseLook>().enabled = true;
		MainMenuC.Global.enabled = true;
		this.SetLayerRecursively(base.gameObject, 0);
		if (!this.carLogic.GetComponent<CarLogicC>().playerSeat.GetComponent<SeatLogicC>().isSat)
		{
			this._camera.GetComponent<HeadBobberC>().enabled = true;
		}
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		parent.gameObject.GetComponent<MouseLook>().enabled = true;
		parent.gameObject.GetComponent<RigidbodyControllerC>().enabled = true;
		this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
		UnityEngine.Object.Destroy(this.spanner);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x00072EBC File Offset: 0x000712BC
	public void RepairPart2()
	{
		base.GetComponent<AudioSource>().PlayOneShot(this.repairAudio[1], 1f);
		this.PartsFlyIn();
		iTween.RotateTo(this.spanner, iTween.Hash(new object[]
		{
			"rotation",
			Vector3.zero,
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00072F50 File Offset: 0x00071350
	public IEnumerator PartsFlyIn()
	{
		int rndmPart = UnityEngine.Random.Range(0, this.parts.Length);
		GameObject spawnedPart = UnityEngine.Object.Instantiate<GameObject>(this.parts[rndmPart], base.transform.position, Quaternion.identity);
		spawnedPart.transform.parent = base.transform;
		spawnedPart.transform.position = Vector3.zero;
		iTween.MoveTo(spawnedPart, iTween.Hash(new object[]
		{
			"path",
			new Vector3(-0.4354584f, 0.0663947f, 0.2174097f),
			new Vector3(-0.4354581f, -0.0443571f, -0.2860264f),
			"time",
			0.6,
			"islocal",
			true,
			"easetype",
			"easeinquint"
		}));
		yield return new WaitForSeconds(0.6f);
		this.repairAction = true;
		UnityEngine.Object.Destroy(spawnedPart);
		yield break;
	}

	// Token: 0x0400081D RID: 2077
	public GameObject carLogic;

	// Token: 0x0400081E RID: 2078
	private GameObject _camera;

	// Token: 0x0400081F RID: 2079
	public GameObject spanner;

	// Token: 0x04000820 RID: 2080
	public GameObject spannerDamage;

	// Token: 0x04000821 RID: 2081
	public int kitCharges = 3;

	// Token: 0x04000822 RID: 2082
	public GameObject[] parts;

	// Token: 0x04000823 RID: 2083
	public AudioClip[] repairAudio;

	// Token: 0x04000824 RID: 2084
	private bool repairAction;

	// Token: 0x04000825 RID: 2085
	private bool repairState;

	// Token: 0x04000826 RID: 2086
	public int repairKitAmmo = 3;

	// Token: 0x04000827 RID: 2087
	public Vector3[] position;
}
