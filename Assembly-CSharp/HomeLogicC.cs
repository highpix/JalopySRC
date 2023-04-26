using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class HomeLogicC : MonoBehaviour
{
	// Token: 0x06000692 RID: 1682 RVA: 0x0008446B File Offset: 0x0008286B
	private void OnDestroy()
	{
		HomeLogicC.Global = null;
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x00084473 File Offset: 0x00082873
	private void Awake()
	{
		HomeLogicC.Global = this;
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x0008447C File Offset: 0x0008287C
	public void ReturningHomeReadyUp()
	{
		iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
		{
			"z",
			-9.5,
			"time",
			8.0,
			"islocal",
			true,
			"easetype",
			"easeoutsine"
		}));
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x000844F4 File Offset: 0x000828F4
	public void GateClose()
	{
		iTween.MoveTo(this.gateObj, iTween.Hash(new object[]
		{
			"z",
			0.4188232,
			"time",
			2.0,
			"islocal",
			true,
			"easetype",
			"easeoutsine"
		}));
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		gameObject = gameObject.transform.parent.transform.parent.gameObject;
		gameObject.transform.parent = this.carStartLoc;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localEulerAngles = Vector3.zero;
		gameObject.transform.parent = null;
		this.ResetUncle();
		GameObject gameObject2 = GameObject.FindWithTag("Storage");
		gameObject2.transform.position = this.homeStorageLoc.position;
		gameObject2.transform.eulerAngles = this.homeStorageLoc.eulerAngles;
		GameObject gameObject3 = GameObject.FindWithTag("Director");
		gameObject3.GetComponent<RouteGeneratorC>().firstSegmentTarget = this.continueTarget;
		gameObject3.GetComponent<RouteGeneratorC>().spawnedHub = base.gameObject;
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x00084638 File Offset: 0x00082A38
	public void ResetUncle()
	{
		GameObject gameObject = GameObject.FindWithTag("Uncle");
		gameObject.transform.position = this.uncleStartLoc.position;
		gameObject.transform.eulerAngles = this.uncleStartLoc.eulerAngles;
		gameObject.transform.GetComponent<Animator>().SetBool("bedTime", false);
		gameObject.GetComponent<UncleLogicC>().isSat = false;
		gameObject.GetComponent<UncleLogicC>().sleepParticle.GetComponent<ParticleSystem>().Stop();
	}

	// Token: 0x040008D3 RID: 2259
	public Transform carStartLoc;

	// Token: 0x040008D4 RID: 2260
	public Transform homeStorageLoc;

	// Token: 0x040008D5 RID: 2261
	public Transform uncleStartLoc;

	// Token: 0x040008D6 RID: 2262
	public GameObject continueTarget;

	// Token: 0x040008D7 RID: 2263
	public GameObject gateObj;

	// Token: 0x040008D8 RID: 2264
	public GameObject bed;

	// Token: 0x040008D9 RID: 2265
	public static HomeLogicC Global;
}
