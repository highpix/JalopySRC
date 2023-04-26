using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
public class RainCheck : MonoBehaviour
{
	// Token: 0x17000024 RID: 36
	// (get) Token: 0x06000248 RID: 584 RVA: 0x0001D820 File Offset: 0x0001BC20
	// (set) Token: 0x06000249 RID: 585 RVA: 0x0001D828 File Offset: 0x0001BC28
	public bool Outside
	{
		get
		{
			return this.outside;
		}
		set
		{
			this.outside = value;
			if (value)
			{
				if (this.route.rainType == 1)
				{
					this.route.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetLightRainWindows();
					this.route.uDayCycle.GetComponent<DNC_soundEffect>().SetLightRainAudio();
				}
				if (this.route.rainType == 2)
				{
					this.route.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetHeavyRainWindows();
					this.route.uDayCycle.GetComponent<DNC_soundEffect>().SetHeavyRainAudio();
				}
			}
			else
			{
				this.route.gameObject.GetComponent<DirectorC>().carLogic.GetComponent<CarLogicC>().SetDryWindows();
				this.route.uDayCycle.GetComponent<DNC_soundEffect>().SetFogAudio();
			}
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0001D908 File Offset: 0x0001BD08
	private void FixedUpdate()
	{
		Ray ray = new Ray(this.rayTarget.position, Vector3.up);
		RaycastHit raycastHit;
		this.Outside = !Physics.Raycast(ray, out raycastHit, float.PositiveInfinity);
		Debug.DrawRay(ray.origin, ray.direction, (!this.Outside) ? Color.red : Color.green);
	}

	// Token: 0x040003AB RID: 939
	private bool outside = true;

	// Token: 0x040003AC RID: 940
	public RouteGeneratorC route;

	// Token: 0x040003AD RID: 941
	public bool stillIn;

	// Token: 0x040003AE RID: 942
	public Transform rayTarget;
}
