using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A0 RID: 160
public class CrowbarLogicC : MonoBehaviour
{
	// Token: 0x0600052E RID: 1326 RVA: 0x000582E5 File Offset: 0x000566E5
	private void Start()
	{
		base.gameObject.name = "crowbar";
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00058308 File Offset: 0x00056708
	private void Update()
	{
		if (Input.GetButtonUp("Fire1") && this._camera.GetComponent<DragRigidbodyC>().isHolding1 == base.gameObject && this.isOnLock)
		{
			this.isOnLock = false;
			iTween.Stop(base.gameObject);
			base.transform.localPosition = this.position[0];
			base.transform.localEulerAngles = this.rotation[0];
			base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) && this._camera.GetComponent<DragRigidbodyC>().isHolding1 == base.gameObject && this.isOnLock)
		{
			this.isOnLock = false;
			iTween.Stop(base.gameObject);
			base.transform.localPosition = this.position[0];
			base.transform.localEulerAngles = this.rotation[0];
			base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17]) && this._camera.GetComponent<DragRigidbodyC>().isHolding1 == base.gameObject && this.isOnLock)
		{
			this.isOnLock = false;
			iTween.Stop(base.gameObject);
			base.transform.localPosition = this.position[0];
			base.transform.localEulerAngles = this.rotation[0];
			base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		}
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x000584FC File Offset: 0x000568FC
	public IEnumerator Action()
	{
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		yield return new WaitForEndOfFrame();
		GameObject target = base.gameObject.GetComponent<ObjectInteractionsC>().target;
		if (target.GetComponent<PadLockC>())
		{
			target.SendMessage("Trigger");
			this.isOnLock = true;
			Transform crowbarLoc = target.GetComponent<PadLockC>().crowbarLoc;
			base.gameObject.layer = LayerMask.NameToLayer("Default");
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"position",
				crowbarLoc,
				"islocal",
				false,
				"time",
				0.3,
				"easetype",
				"easeoutbounce",
				"oncomplete",
				"ActionPart2",
				"oncompletetarget",
				base.gameObject
			}));
			iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
			{
				"rotation",
				crowbarLoc,
				"islocal",
				false,
				"time",
				0.3,
				"easetype",
				"easeoutbounce"
			}));
		}
		else
		{
			this.UnAction();
		}
		yield break;
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00058518 File Offset: 0x00056918
	private IEnumerator ActionPart2()
	{
		GameObject target = base.gameObject.GetComponent<ObjectInteractionsC>().target;
		Transform crowbarLoc = target.GetComponent<PadLockC>().crowbarLoc;
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"z",
			this.rotation[1].z,
			"islocal",
			false,
			"time",
			0.5,
			"easetype",
			"easeinquint",
			"oncomplete",
			"ActionPart3",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.MoveBy(base.gameObject, iTween.Hash(new object[]
		{
			"y",
			0.4,
			"islocal",
			false,
			"delay",
			0.3,
			"time",
			0.4,
			"easetype",
			"easeoutquint"
		}));
		yield break;
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x00058534 File Offset: 0x00056934
	private IEnumerator ActionPart3()
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
		iTween.RotateTo(base.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.rotation[0],
			"islocal",
			true,
			"time",
			0.3,
			"easetype",
			"easeoutquad"
		}));
		yield return new WaitForSeconds(0.3f);
		base.gameObject.layer = LayerMask.NameToLayer("PickUp");
		yield break;
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x00058550 File Offset: 0x00056950
	private IEnumerator UnAction()
	{
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[0];
		yield return new WaitForEndOfFrame();
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
		yield break;
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x0005856C File Offset: 0x0005696C
	private IEnumerator UnActionPart2()
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
		yield break;
	}

	// Token: 0x040007A0 RID: 1952
	public Vector3[] position = new Vector3[0];

	// Token: 0x040007A1 RID: 1953
	public Vector3[] rotation = new Vector3[0];

	// Token: 0x040007A2 RID: 1954
	private GameObject _camera;

	// Token: 0x040007A3 RID: 1955
	public bool isOnLock;
}
