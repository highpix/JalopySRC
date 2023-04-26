using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000154 RID: 340
public class UncleBedTriggerC : MonoBehaviour
{
	// Token: 0x06000D4B RID: 3403 RVA: 0x0012F8C8 File Offset: 0x0012DCC8
	private void OnTriggerEnter(Collider uncle)
	{
		if (uncle.tag == "Uncle")
		{
			uncle.GetComponent<AIPath>().target = null;
			uncle.GetComponent<AIPath>().canMove = false;
			uncle.gameObject.GetComponent<CharacterController>().enabled = false;
			uncle.transform.parent = base.transform;
			uncle.transform.localEulerAngles = Vector3.zero;
			uncle.transform.localPosition = Vector3.zero;
			uncle.transform.parent = null;
			uncle.GetComponent<Animator>().SetBool("bedTime", true);
			base.StartCoroutine(uncle.GetComponent<UncleLogicC>().MotelSatOnBed());
		}
	}
}
