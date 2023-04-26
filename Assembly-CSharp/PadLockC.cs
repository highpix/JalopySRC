using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000DF RID: 223
public class PadLockC : MonoBehaviour
{
	// Token: 0x060008BF RID: 2239 RVA: 0x000BDE5C File Offset: 0x000BC25C
	private void Reset()
	{
		padLock component = base.GetComponent<padLock>();
		component.padlockRotations.Copy(ref this.padlockRotations);
		this.audioShake = component.audioShake;
		this.audioBreak = component.audioBreak;
		component.renderTargets.Copy(ref this.renderTargets);
		this.startMaterial = component.startMaterial;
		this.glowMaterial = component.glowMaterial;
		this.crowbarLoc = component.crowbarLoc;
		this.creakSFX = component.creakSFX;
		UnityEngine.Object.DestroyImmediate(component);
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x000BDEE0 File Offset: 0x000BC2E0
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.originalLock = this.padlock.transform.localEulerAngles;
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x000BDF08 File Offset: 0x000BC308
	private void Update()
	{
		if (this.isGlowing)
		{
			foreach (GameObject gameObject in this.renderTargets)
			{
				float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
				gameObject.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
		if (Input.GetButton("Fire1") || Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[17]))
		{
			this.mouseTimer += Time.deltaTime;
		}
		if (Input.GetButtonUp("Fire1") && (double)this.mouseTimer < 0.7)
		{
			this.mouseTimer = 0f;
			this.crateParent.GetComponent<AudioSource>().Stop();
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) && (double)this.mouseTimer < 0.7)
		{
			this.mouseTimer = 0f;
			this.crateParent.GetComponent<AudioSource>().Stop();
		}
		else if (Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17]) && (double)this.mouseTimer < 0.7)
		{
			this.mouseTimer = 0f;
			this.crateParent.GetComponent<AudioSource>().Stop();
		}
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x000BE094 File Offset: 0x000BC494
	private IEnumerator Trigger()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().isHolding1 == null || base.transform.root.gameObject != this.crateParent)
		{
			iTween.Stop(base.gameObject);
			this.crateParent.GetComponent<AudioSource>().PlayOneShot(this.audioShake, 1f);
			iTween.RotateTo(this.padlock, iTween.Hash(new object[]
			{
				"rotation",
				this.padlockRotations[1],
				"islocal",
				true,
				"time",
				0.1,
				"easetype",
				"easeoutquad",
				"oncomplete",
				"PadlockRotateBack",
				"oncompletetarget",
				base.gameObject
			}));
		}
		else if (this._camera.GetComponent<DragRigidbodyC>().isHolding1.name == "crowbar")
		{
			this.crateParent.GetComponent<AudioSource>().clip = this.creakSFX;
			this.crateParent.GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.7f);
			if (Input.GetButton("Fire1") && (double)this.mouseTimer >= 0.7)
			{
				this.crateParent.GetComponent<AudioSource>().PlayOneShot(this.audioBreak, 1f);
				iTween.MoveTo(this.padlock, iTween.Hash(new object[]
				{
					"position",
					new Vector3(0f, -100f, -10f),
					"islocal",
					true,
					"time",
					1.0,
					"easetype",
					"easeoutquad"
				}));
				iTween.RotateTo(this.lockPanel, iTween.Hash(new object[]
				{
					"z",
					120,
					"islocal",
					true,
					"time",
					0.2,
					"easetype",
					"easeoutquad",
					"oncomplete",
					"BreakPadLock",
					"oncompletetarget",
					base.gameObject
				}));
			}
			else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) && (double)this.mouseTimer >= 0.7)
			{
				this.crateParent.GetComponent<AudioSource>().PlayOneShot(this.audioBreak, 1f);
				iTween.MoveTo(this.padlock, iTween.Hash(new object[]
				{
					"position",
					new Vector3(0f, -100f, -10f),
					"islocal",
					true,
					"time",
					1.0,
					"easetype",
					"easeoutquad"
				}));
				iTween.RotateTo(this.lockPanel, iTween.Hash(new object[]
				{
					"z",
					120,
					"islocal",
					true,
					"time",
					0.2,
					"easetype",
					"easeoutquad",
					"oncomplete",
					"BreakPadLock",
					"oncompletetarget",
					base.gameObject
				}));
			}
			else if (Input.GetKey(MainMenuC.Global.assignedInputStrings[17]) && (double)this.mouseTimer >= 0.7)
			{
				this.crateParent.GetComponent<AudioSource>().PlayOneShot(this.audioBreak, 1f);
				iTween.MoveTo(this.padlock, iTween.Hash(new object[]
				{
					"position",
					new Vector3(0f, -100f, -10f),
					"islocal",
					true,
					"time",
					1.0,
					"easetype",
					"easeoutquad"
				}));
				iTween.RotateTo(this.lockPanel, iTween.Hash(new object[]
				{
					"z",
					120,
					"islocal",
					true,
					"time",
					0.2,
					"easetype",
					"easeoutquad",
					"oncomplete",
					"BreakPadLock",
					"oncompletetarget",
					base.gameObject
				}));
			}
		}
		yield break;
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x000BE0B0 File Offset: 0x000BC4B0
	public void PadlockRotateBack()
	{
		iTween.RotateTo(this.padlock, iTween.Hash(new object[]
		{
			"rotation",
			this.originalLock,
			"islocal",
			true,
			"time",
			0.4,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x000BE124 File Offset: 0x000BC524
	public void BreakPadLock()
	{
		iTween.RotateTo(this.lockPanel, iTween.Hash(new object[]
		{
			"z",
			45,
			"islocal",
			true,
			"time",
			1.0,
			"easetype",
			"easeoutquad"
		}));
		this.crateParent.SendMessage("Open");
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x000BE1A3 File Offset: 0x000BC5A3
	public void IntoInventory()
	{
		base.GetComponent<SphereCollider>().enabled = false;
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x000BE1B1 File Offset: 0x000BC5B1
	public void OutOfInventory()
	{
		base.GetComponent<SphereCollider>().enabled = true;
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x000BE1C0 File Offset: 0x000BC5C0
	public void RaycastEnter()
	{
		if (base.transform.root.gameObject == this.crateParent)
		{
			this.isGlowing = true;
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material = this.glowMaterial;
			}
		}
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x000BE224 File Offset: 0x000BC624
	public void RaycastExit()
	{
		if (base.transform.root.gameObject == this.crateParent)
		{
			this.isGlowing = false;
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material = this.startMaterial;
			}
		}
	}

	// Token: 0x04000BAF RID: 2991
	private GameObject _camera;

	// Token: 0x04000BB0 RID: 2992
	public GameObject crateParent;

	// Token: 0x04000BB1 RID: 2993
	public GameObject padlock;

	// Token: 0x04000BB2 RID: 2994
	public Vector3[] padlockRotations = new Vector3[0];

	// Token: 0x04000BB3 RID: 2995
	public GameObject lockPanel;

	// Token: 0x04000BB4 RID: 2996
	public AudioClip audioShake;

	// Token: 0x04000BB5 RID: 2997
	public AudioClip audioBreak;

	// Token: 0x04000BB6 RID: 2998
	public GameObject[] renderTargets = new GameObject[0];

	// Token: 0x04000BB7 RID: 2999
	private bool isGlowing;

	// Token: 0x04000BB8 RID: 3000
	public Material startMaterial;

	// Token: 0x04000BB9 RID: 3001
	public Material glowMaterial;

	// Token: 0x04000BBA RID: 3002
	[HideInInspector]
	private float mouseTimer;

	// Token: 0x04000BBB RID: 3003
	public Transform crowbarLoc;

	// Token: 0x04000BBC RID: 3004
	public AudioClip creakSFX;

	// Token: 0x04000BBD RID: 3005
	public Vector3 originalLock;
}
