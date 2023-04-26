using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000F9 RID: 249
public class SleepingBagLogicC : MonoBehaviour
{
	// Token: 0x060009E3 RID: 2531 RVA: 0x000EA3F1 File Offset: 0x000E87F1
	private void Start()
	{
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x000EA3F4 File Offset: 0x000E87F4
	private void PickUp()
	{
		this.rolledObject.layer = LayerMask.NameToLayer("PickUp");
		Transform[] componentsInChildren = this.rolledObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("PickUp");
		}
		this.unrolledObject.active = false;
		this.rolledObject.active = true;
	}

	// Token: 0x060009E5 RID: 2533 RVA: 0x000EA46C File Offset: 0x000E886C
	private IEnumerator ThrowLogic()
	{
		yield return new WaitForSeconds(0.15f);
		this.rolledObject.active = false;
		this.unrolledObject.active = true;
		base.gameObject.layer = LayerMask.NameToLayer("Default");
		Transform[] allChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in allChildren)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		yield break;
	}

	// Token: 0x04000D74 RID: 3444
	public GameObject rolledObject;

	// Token: 0x04000D75 RID: 3445
	public GameObject unrolledObject;
}
