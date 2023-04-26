using System;
using System.Collections;
using Pathfinding;
using UnityEngine;

// Token: 0x020000A6 RID: 166
public class EnvironmentDoorsC : MonoBehaviour
{
	// Token: 0x06000597 RID: 1431 RVA: 0x00073130 File Offset: 0x00071530
	public void Start()
	{
		this._camera = Camera.main.gameObject;
		if (this.handle != null)
		{
			this.startMaterial = this.handle.GetComponent<Renderer>().material;
		}
		if (this.handle2 != null)
		{
			this.startMaterial2 = this.handle2.GetComponent<Renderer>().material;
		}
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x0007319C File Offset: 0x0007159C
	public void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.handle.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			if (this.handle2 != null)
			{
				this.handle2.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
			}
		}
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00073214 File Offset: 0x00071614
	private IEnumerator DoorBell()
	{
		if (this.doorBell != null)
		{
			iTween.Stop(this.doorBell);
			if (this.doorBell == null)
			{
				yield break;
			}
			iTween.PunchRotation(this.doorBell, iTween.Hash(new object[]
			{
				"z",
				-30.0,
				"easetype",
				"easeOutBounce",
				"islocal",
				true,
				"delay",
				0.2,
				"time",
				2.0
			}));
			yield return new WaitForSeconds(0.2f);
			this.doorBell.GetComponent<AudioSource>().PlayOneShot(this.doorBellAudio);
		}
		yield break;
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x00073230 File Offset: 0x00071630
	public IEnumerator Trigger()
	{
		if (this.isLocked)
		{
			GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
			if (isHolding != null && (this.keyName == isHolding.name || this.keyName == isHolding.name + "(Clone)"))
			{
				this.key = isHolding;
				this.key.transform.parent = this.lockTarget;
				UnityEngine.Object.Destroy(this.key.GetComponent<Collider>());
				UnityEngine.Object.Destroy(this.key.GetComponent<ObjectPickupC>());
				Transform transform = this.key.transform.Find("KeyJangle");
				UnityEngine.Object.Destroy(transform.GetComponent<KeyJangleC>());
				transform.transform.localEulerAngles = new Vector3(0f, -180f, -180f);
				iTween.MoveTo(this.key, iTween.Hash(new object[]
				{
					"position",
					new Vector3(0f, 0f, -0.1f),
					"time",
					0.5,
					"islocal",
					true,
					"easetype",
					"easeoutexpo",
					"oncomplete",
					"UnlockDoor",
					"oncompletetarget",
					base.gameObject
				}));
				iTween.RotateTo(this.key, iTween.Hash(new object[]
				{
					"rotation",
					new Vector3(-89f, -90f, 90f),
					"time",
					0.5,
					"islocal",
					true,
					"easetype",
					"easeoutexpo"
				}));
				Transform[] componentsInChildren = this.key.GetComponentsInChildren<Transform>();
				foreach (Transform transform2 in componentsInChildren)
				{
					transform2.gameObject.layer = LayerMask.NameToLayer("Default");
				}
				this._camera.GetComponent<DragRigidbodyC>().isHolding1 = null;
				this._camera.GetComponent<DragRigidbodyC>().MoveItemsRightInventory();
				yield break;
			}
			int num = UnityEngine.Random.Range(0, this.lockedAudio.Length);
			base.transform.parent.transform.parent.GetComponent<AudioSource>().Stop();
			base.transform.parent.transform.parent.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = this.lockedAudio[num];
			base.transform.parent.transform.parent.GetComponent<AudioSource>().Play();
			if (this.handle != null)
			{
				if (this.noHandleRotation)
				{
					yield break;
				}
				if (base.GetComponent<Animator>())
				{
					base.GetComponent<Animator>().SetTrigger("Locked");
				}
			}
			yield break;
		}
		else
		{
			if (!this.open)
			{
				base.transform.parent.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.openSFX, 0.7f);
				base.gameObject.transform.parent.transform.parent.gameObject.GetComponent<Collider>().isTrigger = true;
				this.RaycastExit();
				iTween.RotateTo(base.gameObject.transform.parent.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.xyzOpen,
					"time",
					1.2,
					"islocal",
					true,
					"delay",
					0.2,
					"oncomplete",
					"RestoreDoorCollisions",
					"oncompletetarget",
					base.gameObject
				}));
				this.open = true;
				base.StopCoroutine("DoorBell");
				base.StartCoroutine(this.DoorBell());
				if (this.motel != null)
				{
					GameObject gameObject = GameObject.FindWithTag("Uncle");
					if (!gameObject.GetComponent<UncleLogicC>().debugStopUncleWorking || !gameObject.GetComponent<UncleLogicC>().uncleAtHome || !gameObject.GetComponent<UncleLogicC>().uncleGoneForever)
					{
						gameObject.GetComponent<AIPath>().target = this.motel.GetComponent<MotelLogicC>().roomNodes[this.motel.GetComponent<MotelLogicC>().roomNumber];
					}
				}
				if (this.handle != null)
				{
					if (this.noHandleRotation)
					{
						yield break;
					}
					base.GetComponent<Animator>().SetTrigger("Open");
				}
				yield break;
			}
			if (this.open)
			{
				iTween.RotateTo(base.gameObject.transform.parent.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.xyzClosed,
					"time",
					0.3,
					"islocal",
					true,
					"easetype",
					"easeInCirc",
					"onComplete",
					"DoorClosed",
					"onCompleteTarget",
					base.gameObject
				}));
				yield return new WaitForSeconds(0.28f);
				base.transform.parent.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.closeSFX, 0.7f);
				yield break;
			}
			yield break;
		}
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x0007324B File Offset: 0x0007164B
	public void RestoreDoorCollisions()
	{
		base.gameObject.transform.parent.transform.parent.gameObject.GetComponent<Collider>().isTrigger = false;
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x00073278 File Offset: 0x00071678
	public void UnlockDoor()
	{
		base.transform.parent.transform.parent.GetComponent<AudioSource>().PlayOneShot(this.unlockAudio, 0.7f);
		iTween.RotateTo(this.key, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(-180f, -90f, 90f),
			"time",
			0.5,
			"islocal",
			true,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"ReturnKeyTurn",
			"oncompletetarget",
			base.gameObject
		}));
		this.isLocked = false;
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x00073350 File Offset: 0x00071750
	public void ReturnKeyTurn()
	{
		iTween.RotateTo(this.key, iTween.Hash(new object[]
		{
			"rotation",
			new Vector3(-90f, -90f, 90f),
			"time",
			0.75,
			"islocal",
			true,
			"easetype",
			"easeoutexpo"
		}));
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x000733D1 File Offset: 0x000717D1
	public void DoorClosed()
	{
		this.open = false;
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x000733DC File Offset: 0x000717DC
	public void RaycastEnter()
	{
		this.isGlowing = true;
		if (this.isLocked)
		{
			GameObject isHolding = this._camera.GetComponent<DragRigidbodyC>().isHolding1;
			if (isHolding != null)
			{
				if (this.keyName == isHolding.name || this.keyName == isHolding.name + "(Clone)")
				{
					if (this.lockTarget != null)
					{
						this.lockTarget.GetComponent<Renderer>().material = this.glowMaterial;
					}
				}
				else
				{
					if (this.handle != null)
					{
						this.handle.GetComponent<Renderer>().material = this.glowMaterial;
					}
					if (this.handle2 != null)
					{
						this.handle2.GetComponent<Renderer>().material = this.glowMaterial;
					}
				}
			}
			else
			{
				if (this.handle != null)
				{
					this.handle.GetComponent<Renderer>().material = this.glowMaterial;
				}
				if (this.handle2 != null)
				{
					this.handle2.GetComponent<Renderer>().material = this.glowMaterial;
				}
			}
		}
		else
		{
			if (this.handle != null)
			{
				this.handle.GetComponent<Renderer>().material = this.glowMaterial;
			}
			if (this.handle2 != null)
			{
				this.handle2.GetComponent<Renderer>().material = this.glowMaterial;
			}
		}
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x00073570 File Offset: 0x00071970
	public void RaycastExit()
	{
		this.isGlowing = false;
		if (this.handle != null)
		{
			this.handle.GetComponent<Renderer>().material = this.startMaterial;
		}
		if (this.handle2 != null)
		{
			this.handle2.GetComponent<Renderer>().material = this.startMaterial2;
		}
		if (this.lockTarget != null)
		{
			this.lockTarget.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x04000828 RID: 2088
	private GameObject _camera;

	// Token: 0x04000829 RID: 2089
	public bool noHandleRotation;

	// Token: 0x0400082A RID: 2090
	public bool isLocked;

	// Token: 0x0400082B RID: 2091
	public AudioClip[] lockedAudio;

	// Token: 0x0400082C RID: 2092
	public string keyName = string.Empty;

	// Token: 0x0400082D RID: 2093
	public GameObject key;

	// Token: 0x0400082E RID: 2094
	public Transform lockTarget;

	// Token: 0x0400082F RID: 2095
	public AudioClip unlockAudio;

	// Token: 0x04000830 RID: 2096
	[Header("Door Bells")]
	public GameObject doorBell;

	// Token: 0x04000831 RID: 2097
	public AudioClip doorBellAudio;

	// Token: 0x04000832 RID: 2098
	public bool open;

	// Token: 0x04000833 RID: 2099
	public Vector3 xyzOpen;

	// Token: 0x04000834 RID: 2100
	public Vector3 xyzClosed;

	// Token: 0x04000835 RID: 2101
	public GameObject handle;

	// Token: 0x04000836 RID: 2102
	public GameObject handle2;

	// Token: 0x04000837 RID: 2103
	public AudioClip openSFX;

	// Token: 0x04000838 RID: 2104
	public AudioClip closeSFX;

	// Token: 0x04000839 RID: 2105
	public Material startMaterial;

	// Token: 0x0400083A RID: 2106
	public Material startMaterial2;

	// Token: 0x0400083B RID: 2107
	public Material glowMaterial;

	// Token: 0x0400083C RID: 2108
	public bool isGlowing;

	// Token: 0x0400083D RID: 2109
	public GameObject motel;
}
