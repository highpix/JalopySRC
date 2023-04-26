using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000107 RID: 263
public class StreetLightC : MonoBehaviour
{
	// Token: 0x06000A62 RID: 2658 RVA: 0x000F7FC8 File Offset: 0x000F63C8
	private void Start()
	{
		if (this.lightMaterial != null)
		{
			this.lightMatOff = this.lightMaterial.GetComponent<Renderer>().material;
		}
		this.player = Camera.main.gameObject;
		this.director = GameObject.FindWithTag("Director");
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				if (transform.name == "lightCone")
				{
					this.lightCone = transform.gameObject;
				}
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
		if (base.GetComponent<Light>())
		{
			base.GetComponent<Light>().shadows = LightShadows.Soft;
		}
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x000F80AC File Offset: 0x000F64AC
	private void Update()
	{
		if (this.player == null)
		{
			this.player = Camera.main.gameObject;
		}
		if (!this.director.GetComponent<DirectorC>().isDay)
		{
			float num = Vector3.Distance(this.player.transform.position, base.transform.position);
			if ((double)num < 400.0 && !this.lightOn)
			{
				this.lightOn = true;
				if (this.state >= 0 && this.state <= 75)
				{
					base.StartCoroutine("State1");
				}
				if (this.state >= 76 && this.state <= 90)
				{
					base.StartCoroutine("State1");
				}
				if (this.state >= 91 && this.state <= 95)
				{
					base.StartCoroutine("State1");
				}
			}
			else if ((double)num > 400.0 && this.lightOn)
			{
				base.StartCoroutine("LightOff");
			}
		}
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x000F81D0 File Offset: 0x000F65D0
	public void Illuminate()
	{
		if (this.fauxLight)
		{
			this.FakeIlluminate();
			return;
		}
		this.state = UnityEngine.Random.Range(0, 100);
		if (this.state >= 0 && this.state <= 75)
		{
			base.StartCoroutine("State1");
		}
		if (this.state >= 76 && this.state <= 90)
		{
			base.StartCoroutine("State1");
		}
		if (this.state >= 91 && this.state <= 95)
		{
			base.StartCoroutine("State1");
		}
		if (this.state >= 96)
		{
			base.StartCoroutine("State1");
		}
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x000F8288 File Offset: 0x000F6688
	public void FakeIlluminate()
	{
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOn;
		}
		if (this.lightCone != null)
		{
			this.lightCone.active = true;
		}
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x000F82DC File Offset: 0x000F66DC
	public void FakeIlluminateStop()
	{
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOff;
		}
		if (this.lightCone != null)
		{
			this.lightCone.active = false;
		}
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x000F8330 File Offset: 0x000F6730
	public void IlluminateStop()
	{
		base.StopCoroutine("FlickerLight");
		if (base.gameObject.GetComponent<Light>())
		{
			base.GetComponent<Light>().enabled = false;
		}
		if (this.lightCone != null)
		{
			this.lightCone.active = false;
		}
		this.lightOn = false;
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOff;
		}
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x000F83B4 File Offset: 0x000F67B4
	public void State0()
	{
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOn;
		}
		if (base.gameObject.GetComponent<Light>())
		{
			base.GetComponent<Light>().enabled = true;
		}
		if (this.lightCone != null)
		{
			this.lightCone.active = true;
		}
		this.lightOn = true;
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x000F8430 File Offset: 0x000F6830
	private IEnumerator State1()
	{
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOn;
		}
		base.StartCoroutine("FlickerLight");
		this.flickerSpeed = UnityEngine.Random.Range(0.04f, 0.07f);
		float randomLightWait = UnityEngine.Random.Range(0.5f, 1.5f);
		yield return new WaitForSeconds(randomLightWait);
		base.StopCoroutine("FlickerLight");
		if (base.gameObject.GetComponent<Light>())
		{
			base.GetComponent<Light>().enabled = true;
		}
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOn;
		}
		if (this.lightCone != null)
		{
			this.lightCone.active = true;
		}
		this.lightOn = true;
		yield break;
	}

	// Token: 0x06000A6A RID: 2666 RVA: 0x000F844C File Offset: 0x000F684C
	public void State2()
	{
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOn;
		}
		this.flickerSpeed = UnityEngine.Random.Range(0.04f, 0.07f);
		base.StartCoroutine("FlickerLight");
		this.lightOn = true;
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x000F84A8 File Offset: 0x000F68A8
	private IEnumerator FlickerLight()
	{
		if (ES3.Exists("preventFlickeringLights"))
		{
			bool flag = ES3.LoadBool("preventFlickeringLights");
			if (flag)
			{
				if (base.gameObject.GetComponent<Light>())
				{
					base.gameObject.GetComponent<Light>().enabled = false;
				}
				yield break;
			}
			yield break;
		}
		else
		{
			for (;;)
			{
				if ((double)this.randomizer <= 0.65)
				{
					if (base.gameObject.GetComponent<Light>())
					{
						base.gameObject.GetComponent<Light>().enabled = false;
					}
					if (this.lightCone != null)
					{
						this.lightCone.active = false;
					}
					if (this.lightMaterial != null)
					{
						this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOff;
					}
				}
				else
				{
					if (base.gameObject.GetComponent<Light>())
					{
						base.gameObject.GetComponent<Light>().enabled = true;
					}
					if (this.lightCone != null)
					{
						this.lightCone.active = true;
					}
					if (this.lightMaterial != null)
					{
						this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOn;
					}
				}
				this.randomizer = UnityEngine.Random.Range(0f, 3.1f);
				yield return new WaitForSeconds(this.flickerSpeed);
			}
		}
	}

	// Token: 0x06000A6C RID: 2668 RVA: 0x000F84C4 File Offset: 0x000F68C4
	public void LightOff()
	{
		if (this.lightMaterial != null)
		{
			this.lightMaterial.GetComponent<Renderer>().material = this.lightMatOff;
		}
		if (base.gameObject.GetComponent<Light>())
		{
			base.GetComponent<Light>().enabled = false;
		}
		if (this.lightCone != null)
		{
			this.lightCone.active = false;
		}
		this.lightOn = false;
	}

	// Token: 0x04000E7C RID: 3708
	private GameObject director;

	// Token: 0x04000E7D RID: 3709
	public GameObject lightMaterial;

	// Token: 0x04000E7E RID: 3710
	public Material lightMatOn;

	// Token: 0x04000E7F RID: 3711
	public Material lightMatOff;

	// Token: 0x04000E80 RID: 3712
	public bool lightOn;

	// Token: 0x04000E81 RID: 3713
	public float flickerSpeed = 0.07f;

	// Token: 0x04000E82 RID: 3714
	public GameObject lightCone;

	// Token: 0x04000E83 RID: 3715
	public bool fauxLight;

	// Token: 0x04000E84 RID: 3716
	public float randomizer;

	// Token: 0x04000E85 RID: 3717
	private GameObject player;

	// Token: 0x04000E86 RID: 3718
	private int state;
}
