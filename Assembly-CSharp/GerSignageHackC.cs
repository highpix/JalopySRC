using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class GerSignageHackC : MonoBehaviour
{
	// Token: 0x0600011A RID: 282 RVA: 0x000129BC File Offset: 0x00010DBC
	public void Start()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		if (gameObject.GetComponent<RouteGeneratorC>().routeChosen == 1)
		{
			if (gameObject.GetComponent<RouteGeneratorC>().route1StopOff == 1)
			{
				base.GetComponent<MeshFilter>().mesh = this.scrapMesh;
			}
		}
		else if (gameObject.GetComponent<RouteGeneratorC>().routeChosen == 2)
		{
			if (gameObject.GetComponent<RouteGeneratorC>().route2StopOff == 1)
			{
				base.GetComponent<MeshFilter>().mesh = this.scrapMesh;
			}
		}
		else if (gameObject.GetComponent<RouteGeneratorC>().routeChosen == 3 && gameObject.GetComponent<RouteGeneratorC>().route3StopOff == 1)
		{
			base.GetComponent<MeshFilter>().mesh = this.scrapMesh;
		}
	}

	// Token: 0x0400022A RID: 554
	public Mesh scrapMesh;
}
