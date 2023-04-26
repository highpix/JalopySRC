using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011E RID: 286
public class TrafficLightC : MonoBehaviour
{
	// Token: 0x06000B31 RID: 2865 RVA: 0x00104C7C File Offset: 0x0010307C
	private void Update()
	{
		if (!this.lightsGreen)
		{
			for (int i = 0; i < this.raycastPoint.Length; i++)
			{
				Vector3 forward = this.raycastPoint[i].forward;
				if (Physics.Raycast(this.raycastPoint[i].position, forward, 30f))
				{
					this.lightsGreen = true;
					this.triggerZone.active = true;
					base.StartCoroutine(this.LightsGo());
				}
			}
		}
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x00104CF8 File Offset: 0x001030F8
	private void Start()
	{
		this.lights[0].GetComponent<Renderer>().material = this.mats[1];
		this.lights[1].GetComponent<Renderer>().material = this.mats[0];
		this.lights[2].GetComponent<Renderer>().material = this.mats[0];
		this.lights[3].GetComponent<Renderer>().material = this.mats[1];
		this.lights[4].GetComponent<Renderer>().material = this.mats[0];
		this.lights[5].GetComponent<Renderer>().material = this.mats[0];
		if (this.lightOrder == 0)
		{
			base.StartCoroutine(this.LightsGo());
		}
		else
		{
			base.StartCoroutine(this.LightsStop());
		}
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x00104DCC File Offset: 0x001031CC
	private IEnumerator LightsGo()
	{
		int rndmWaitTime = UnityEngine.Random.Range(1, 10);
		yield return new WaitForSeconds((float)rndmWaitTime);
		this.lights[0].GetComponent<Renderer>().material = this.mats[1];
		this.lights[1].GetComponent<Renderer>().material = this.mats[2];
		this.lights[2].GetComponent<Renderer>().material = this.mats[0];
		this.lights[3].GetComponent<Renderer>().material = this.mats[1];
		this.lights[4].GetComponent<Renderer>().material = this.mats[2];
		this.lights[5].GetComponent<Renderer>().material = this.mats[0];
		yield return new WaitForSeconds(3f);
		this.triggerZone.GetComponent<Collider>().enabled = false;
		this.lights[0].GetComponent<Renderer>().material = this.mats[0];
		this.lights[1].GetComponent<Renderer>().material = this.mats[0];
		this.lights[2].GetComponent<Renderer>().material = this.mats[3];
		this.lights[3].GetComponent<Renderer>().material = this.mats[0];
		this.lights[4].GetComponent<Renderer>().material = this.mats[0];
		this.lights[5].GetComponent<Renderer>().material = this.mats[3];
		yield return new WaitForSeconds(10f);
		yield break;
	}

	// Token: 0x06000B34 RID: 2868 RVA: 0x00104DE8 File Offset: 0x001031E8
	private IEnumerator LightsStop()
	{
		if (this.lightsGreen)
		{
			yield break;
		}
		this.lights[0].GetComponent<Renderer>().material = this.mats[0];
		this.lights[1].GetComponent<Renderer>().material = this.mats[2];
		this.lights[2].GetComponent<Renderer>().material = this.mats[0];
		this.lights[3].GetComponent<Renderer>().material = this.mats[0];
		this.lights[4].GetComponent<Renderer>().material = this.mats[2];
		this.lights[5].GetComponent<Renderer>().material = this.mats[0];
		yield return new WaitForSeconds(3f);
		this.lights[0].GetComponent<Renderer>().material = this.mats[1];
		this.lights[1].GetComponent<Renderer>().material = this.mats[0];
		this.lights[2].GetComponent<Renderer>().material = this.mats[0];
		this.lights[3].GetComponent<Renderer>().material = this.mats[1];
		this.lights[4].GetComponent<Renderer>().material = this.mats[0];
		this.lights[5].GetComponent<Renderer>().material = this.mats[0];
		this.lightsGreen = false;
		yield break;
	}

	// Token: 0x06000B35 RID: 2869 RVA: 0x00104E04 File Offset: 0x00103204
	public void Penalty()
	{
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		gameObject.GetComponent<CarLogicC>().TrafficLightPenalty();
	}

	// Token: 0x04000FAF RID: 4015
	public int lightOrder;

	// Token: 0x04000FB0 RID: 4016
	public GameObject triggerZone;

	// Token: 0x04000FB1 RID: 4017
	public Transform[] raycastPoint = new Transform[0];

	// Token: 0x04000FB2 RID: 4018
	public Material[] mats = new Material[0];

	// Token: 0x04000FB3 RID: 4019
	public GameObject[] lights = new GameObject[0];

	// Token: 0x04000FB4 RID: 4020
	private bool lightsGreen;
}
