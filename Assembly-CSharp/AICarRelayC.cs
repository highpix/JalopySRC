using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class AICarRelayC : MonoBehaviour
{
	// Token: 0x0600000C RID: 12 RVA: 0x000023C0 File Offset: 0x000007C0
	private void Start()
	{
		this.routeGenerator = GameObject.FindWithTag("Director");
		if (this.aiDestination == 1)
		{
			this.routeGenerator.GetComponent<RouteGeneratorC>().aiDestination1 = base.transform;
		}
		else if (this.aiDestination == 2)
		{
			this.routeGenerator.GetComponent<RouteGeneratorC>().aiDestination2 = base.transform;
		}
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002428 File Offset: 0x00000828
	private void OnTriggerEnter(Collider collision)
	{
		if ((this.aiDestination != 1 && this.aiDestination != 2) || collision.gameObject.tag == "AICar")
		{
		}
		if (this.aiDestination != 12 || collision.gameObject.tag == "AICar")
		{
		}
		if (this.aiDestination != 22 || collision.gameObject.tag == "AICar")
		{
		}
	}

	// Token: 0x0400000D RID: 13
	public GameObject routeGenerator;

	// Token: 0x0400000E RID: 14
	public int aiDestination;

	// Token: 0x0400000F RID: 15
	public Transform relayNode;
}
