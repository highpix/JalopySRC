using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011F RID: 287
public class TrafficLightManagerC : MonoBehaviour
{
	// Token: 0x06000B37 RID: 2871 RVA: 0x001053B8 File Offset: 0x001037B8
	private void Start()
	{
		this.state = UnityEngine.Random.Range(0, 2);
		if (this.state == 0)
		{
			base.StartCoroutine("State1Go");
		}
		else if (this.state == 1)
		{
			base.StartCoroutine("State2Go");
		}
	}

	// Token: 0x06000B38 RID: 2872 RVA: 0x00105408 File Offset: 0x00103808
	private IEnumerator ExitedRed()
	{
		this.hasExitedARed = true;
		yield return new WaitForSeconds(3f);
		this.hasExitedARed = false;
		yield break;
	}

	// Token: 0x06000B39 RID: 2873 RVA: 0x00105423 File Offset: 0x00103823
	public void PenaltyCheck()
	{
		if (this.hasExitedARed)
		{
			this.Penalty();
		}
	}

	// Token: 0x06000B3A RID: 2874 RVA: 0x00105438 File Offset: 0x00103838
	public void Penalty()
	{
		GameObject gameObject = GameObject.FindWithTag("CarLogic");
		gameObject.GetComponent<CarLogicC>().TrafficLightPenalty();
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x0010545C File Offset: 0x0010385C
	private IEnumerator State1Go()
	{
		for (int i = 0; i < this.trafficLight2GreenLights.Length; i++)
		{
			this.trafficLight2GreenLights[i].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int j = 0; j < this.trafficLight2OrangeLights.Length; j++)
		{
			this.trafficLight2OrangeLights[j].GetComponent<Renderer>().material = this.lightMats[1];
		}
		for (int k = 0; k < this.trafficLight2RedLights.Length; k++)
		{
			this.trafficLight2RedLights[k].GetComponent<Renderer>().material = this.lightMats[3];
		}
		yield return new WaitForSeconds(3f);
		for (int l = 0; l < this.trafficLight2OrangeLights.Length; l++)
		{
			this.trafficLight2OrangeLights[l].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int m = 0; m < this.trafficLight2RedLights.Length; m++)
		{
			this.trafficLight2RedLights[m].GetComponent<Renderer>().material = this.lightMats[2];
		}
		this.trafficLight2Triggers[0].GetComponent<TrafficLightsRelayC>().isRed = true;
		this.trafficLight2Triggers[1].GetComponent<TrafficLightsRelayC>().isRed = true;
		for (int n = 0; n < this.trafficLight1GreenLights.Length; n++)
		{
			this.trafficLight1GreenLights[n].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int num = 0; num < this.trafficLight1OrangeLights.Length; num++)
		{
			this.trafficLight1OrangeLights[num].GetComponent<Renderer>().material = this.lightMats[1];
		}
		for (int num2 = 0; num2 < this.trafficLight1RedLights.Length; num2++)
		{
			this.trafficLight1RedLights[num2].GetComponent<Renderer>().material = this.lightMats[2];
		}
		this.trafficLight1Triggers[0].GetComponent<TrafficLightsRelayC>().isRed = false;
		this.trafficLight1Triggers[1].GetComponent<TrafficLightsRelayC>().isRed = false;
		yield return new WaitForSeconds(1.5f);
		for (int num3 = 0; num3 < this.trafficLight1GreenLights.Length; num3++)
		{
			this.trafficLight1GreenLights[num3].GetComponent<Renderer>().material = this.lightMats[0];
		}
		for (int num4 = 0; num4 < this.trafficLight1OrangeLights.Length; num4++)
		{
			this.trafficLight1OrangeLights[num4].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int num5 = 0; num5 < this.trafficLight1RedLights.Length; num5++)
		{
			this.trafficLight1RedLights[num5].GetComponent<Renderer>().material = this.lightMats[3];
		}
		this.state = 0;
		yield break;
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x00105478 File Offset: 0x00103878
	private IEnumerator State2Go()
	{
		for (int i = 0; i < this.trafficLight1GreenLights.Length; i++)
		{
			this.trafficLight1GreenLights[i].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int j = 0; j < this.trafficLight1OrangeLights.Length; j++)
		{
			this.trafficLight1OrangeLights[j].GetComponent<Renderer>().material = this.lightMats[1];
		}
		for (int k = 0; k < this.trafficLight1RedLights.Length; k++)
		{
			this.trafficLight1RedLights[k].GetComponent<Renderer>().material = this.lightMats[3];
		}
		yield return new WaitForSeconds(3f);
		for (int l = 0; l < this.trafficLight1OrangeLights.Length; l++)
		{
			this.trafficLight1OrangeLights[l].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int m = 0; m < this.trafficLight1RedLights.Length; m++)
		{
			this.trafficLight1RedLights[m].GetComponent<Renderer>().material = this.lightMats[2];
		}
		this.trafficLight1Triggers[0].GetComponent<TrafficLightsRelayC>().isRed = true;
		this.trafficLight1Triggers[1].GetComponent<TrafficLightsRelayC>().isRed = true;
		for (int n = 0; n < this.trafficLight2GreenLights.Length; n++)
		{
			this.trafficLight2GreenLights[n].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int num = 0; num < this.trafficLight2OrangeLights.Length; num++)
		{
			this.trafficLight2OrangeLights[num].GetComponent<Renderer>().material = this.lightMats[1];
		}
		for (int num2 = 0; num2 < this.trafficLight2RedLights.Length; num2++)
		{
			this.trafficLight2RedLights[num2].GetComponent<Renderer>().material = this.lightMats[2];
		}
		this.trafficLight2Triggers[0].GetComponent<TrafficLightsRelayC>().isRed = false;
		this.trafficLight2Triggers[1].GetComponent<TrafficLightsRelayC>().isRed = false;
		yield return new WaitForSeconds(1.5f);
		for (int num3 = 0; num3 < this.trafficLight2GreenLights.Length; num3++)
		{
			this.trafficLight2GreenLights[num3].GetComponent<Renderer>().material = this.lightMats[0];
		}
		for (int num4 = 0; num4 < this.trafficLight2OrangeLights.Length; num4++)
		{
			this.trafficLight2OrangeLights[num4].GetComponent<Renderer>().material = this.lightMats[3];
		}
		for (int num5 = 0; num5 < this.trafficLight2RedLights.Length; num5++)
		{
			this.trafficLight2RedLights[num5].GetComponent<Renderer>().material = this.lightMats[3];
		}
		this.state = 1;
		yield break;
	}

	// Token: 0x06000B3D RID: 2877 RVA: 0x00105494 File Offset: 0x00103894
	public void LightChange()
	{
		if (this.state == 0)
		{
			this.state = 2;
			base.StartCoroutine("State2Go");
			return;
		}
		if (this.state == 1)
		{
			this.state = 2;
			base.StartCoroutine("State1Go");
			return;
		}
	}

	// Token: 0x04000FB5 RID: 4021
	public GameObject[] trafficLight1Triggers = new GameObject[0];

	// Token: 0x04000FB6 RID: 4022
	public GameObject[] trafficLight1GreenLights = new GameObject[0];

	// Token: 0x04000FB7 RID: 4023
	public GameObject[] trafficLight1OrangeLights = new GameObject[0];

	// Token: 0x04000FB8 RID: 4024
	public GameObject[] trafficLight1RedLights = new GameObject[0];

	// Token: 0x04000FB9 RID: 4025
	public GameObject[] trafficLight2Triggers = new GameObject[0];

	// Token: 0x04000FBA RID: 4026
	public GameObject[] trafficLight2GreenLights = new GameObject[0];

	// Token: 0x04000FBB RID: 4027
	public GameObject[] trafficLight2OrangeLights = new GameObject[0];

	// Token: 0x04000FBC RID: 4028
	public GameObject[] trafficLight2RedLights = new GameObject[0];

	// Token: 0x04000FBD RID: 4029
	public Material[] lightMats = new Material[0];

	// Token: 0x04000FBE RID: 4030
	public int state;

	// Token: 0x04000FBF RID: 4031
	public bool hasExitedARed;
}
