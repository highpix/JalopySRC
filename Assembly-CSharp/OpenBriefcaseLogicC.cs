using System;
using UnityEngine;

// Token: 0x020000DC RID: 220
public class OpenBriefcaseLogicC : MonoBehaviour
{
	// Token: 0x060008A2 RID: 2210 RVA: 0x000BCFCB File Offset: 0x000BB3CB
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		base.gameObject.AddComponent<Rigidbody>();
		base.GetComponent<Rigidbody>().isKinematic = true;
		base.GetComponent<Rigidbody>().detectCollisions = false;
		OpenBriefcaseLogicC.isOpen = false;
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x000BD008 File Offset: 0x000BB408
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.glowTarget1.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			this.glowTarget2.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x000BD06C File Offset: 0x000BB46C
	public void CarTrigger()
	{
		base.transform.GetComponent<Collider>().enabled = false;
		if (this.currentPos == 0)
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Director");
			if (gameObject.GetComponent<RouteGeneratorC>().routeLevel <= this.letters.Length)
			{
				int num = gameObject.GetComponent<RouteGeneratorC>().routeLevel - 1;
				if (num < 0)
				{
					num = 0;
				}
				this.letters[num].active = true;
				iTween.Stop(base.gameObject.transform.parent.gameObject);
				this.currentPos = 2;
				iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"x",
					-0.3,
					"islocal",
					true,
					"time",
					this.openTimeToComplete,
					"easetype",
					this.easeType,
					"onComplete",
					"AllowCloseFunctionality",
					"onCompleteTarget",
					base.gameObject
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.breifcaseAudio, 0.7f);
			}
			OpenBriefcaseLogicC.isOpen = true;
			return;
		}
		if (this.currentPos == 2)
		{
			base.StartCoroutine("CloseBreifcaseCar");
		}
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x000BD1D0 File Offset: 0x000BB5D0
	public void CloseBreifcaseCar()
	{
		if (this.currentPos == 2)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 0;
			iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"x",
				0.3,
				"islocal",
				true,
				"time",
				this.closeTimeToComplete,
				"easetype",
				this.easeType2,
				"onComplete",
				"CloseComplete",
				"onCompleteTarget",
				base.gameObject
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.breifcaseAudio, 0.7f);
		}
		this.letters[0].active = false;
		this.letters[1].active = false;
		this.letters[2].active = false;
		this.letters[3].active = false;
		this.letters[4].active = false;
		this.letters[5].active = false;
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x000BD310 File Offset: 0x000BB710
	public void Trigger()
	{
		base.transform.GetComponent<Collider>().enabled = false;
		if (this.currentPos == 0)
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Director");
			if (gameObject.GetComponent<RouteGeneratorC>().routeLevel <= this.letters.Length)
			{
				this.letters[gameObject.GetComponent<RouteGeneratorC>().routeLevel].active = true;
				iTween.Stop(base.gameObject.transform.parent.gameObject);
				this.currentPos = 1;
				iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"x",
					-0.4,
					"islocal",
					true,
					"time",
					this.openTimeToComplete,
					"easetype",
					this.easeType,
					"onComplete",
					"AllowCloseFunctionality",
					"onCompleteTarget",
					base.gameObject
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.breifcaseAudio, 0.7f);
				OpenBriefcaseLogicC.isOpen = true;
			}
			return;
		}
		if (this.currentPos == 1)
		{
			base.StartCoroutine("CloseBreifcase");
		}
		if (this.currentPos == 2)
		{
			base.StartCoroutine("CloseBreifcaseCar");
		}
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x000BD47D File Offset: 0x000BB87D
	public void AllowCloseFunctionality()
	{
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x000BD480 File Offset: 0x000BB880
	public void CloseBreifcase()
	{
		if (this.currentPos == 1)
		{
			iTween.Stop(base.gameObject.transform.parent.gameObject);
			this.currentPos = 0;
			iTween.RotateBy(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
			{
				"x",
				0.4,
				"islocal",
				true,
				"time",
				this.closeTimeToComplete,
				"easetype",
				this.easeType2,
				"onComplete",
				"CloseComplete",
				"onCompleteTarget",
				base.gameObject
			}));
			base.GetComponent<AudioSource>().PlayOneShot(this.breifcaseAudio, 0.7f);
		}
		this.letters[0].active = false;
		this.letters[1].active = false;
		this.letters[2].active = false;
		this.letters[3].active = false;
		this.letters[4].active = false;
		this.letters[5].active = false;
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x000BD5BF File Offset: 0x000BB9BF
	public void CloseComplete()
	{
		base.transform.parent.localEulerAngles = Vector3.zero;
		this.openColliders[0].SendMessage("ReturnPickupFunctionality");
		OpenBriefcaseLogicC.isOpen = false;
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x000BD5F0 File Offset: 0x000BB9F0
	public void OnMouseOver()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().cursors[0].gameObject.active)
		{
			this.isGlowing = true;
			this.glowTarget1.GetComponent<Renderer>().material = this.glowMaterial;
			this.glowTarget2.GetComponent<Renderer>().material = this.glowMaterial;
		}
		else if (this.isGlowing)
		{
			this.isGlowing = false;
			this.glowTarget1.GetComponent<Renderer>().material = this.startMaterial;
			this.glowTarget2.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x000BD694 File Offset: 0x000BBA94
	public void OnMouseExit()
	{
		this.isGlowing = false;
		this.glowTarget1.GetComponent<Renderer>().material = this.startMaterial;
		this.glowTarget2.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000B7F RID: 2943
	private GameObject _camera;

	// Token: 0x04000B80 RID: 2944
	public GameObject[] letters = new GameObject[0];

	// Token: 0x04000B81 RID: 2945
	public GameObject glowTarget1;

	// Token: 0x04000B82 RID: 2946
	public GameObject glowTarget2;

	// Token: 0x04000B83 RID: 2947
	public float openTimeToComplete = 1.05f;

	// Token: 0x04000B84 RID: 2948
	public float closeTimeToComplete = 0.75f;

	// Token: 0x04000B85 RID: 2949
	public int currentPos;

	// Token: 0x04000B86 RID: 2950
	public Vector3[] positionRotation = new Vector3[0];

	// Token: 0x04000B87 RID: 2951
	public AudioClip breifcaseAudio;

	// Token: 0x04000B88 RID: 2952
	public Material glowMaterial;

	// Token: 0x04000B89 RID: 2953
	public Material startMaterial;

	// Token: 0x04000B8A RID: 2954
	public string easeType = "easeoutelastic";

	// Token: 0x04000B8B RID: 2955
	public string easeType2 = "easeoutelastic";

	// Token: 0x04000B8C RID: 2956
	public AudioClip errorAudio;

	// Token: 0x04000B8D RID: 2957
	public GameObject[] openColliders = new GameObject[0];

	// Token: 0x04000B8E RID: 2958
	private bool isGlowing;

	// Token: 0x04000B8F RID: 2959
	public static bool isOpen;
}
