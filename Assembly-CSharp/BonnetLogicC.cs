using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200010D RID: 269
public class BonnetLogicC : MonoBehaviour
{
	// Token: 0x06000A9D RID: 2717 RVA: 0x000F95A3 File Offset: 0x000F79A3
	private void Start()
	{
		this.startMaterial = this.handle.GetComponent<Renderer>().material;
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x000F95BC File Offset: 0x000F79BC
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			this.handle.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x000F9608 File Offset: 0x000F7A08
	public void PopBonnet()
	{
		if (this.carLogic.GetComponent<CarLogicC>())
		{
			this.carLogic.GetComponent<CarLogicC>().bonnetPopped = true;
		}
		else
		{
			this.abandonBonnetPopped = true;
		}
		iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
		{
			"rotation",
			this.xyzPopped,
			"time",
			1.2,
			"islocal",
			true,
			"delay",
			0.2,
			"easetype",
			"easeoutelastic"
		}));
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x000F96D8 File Offset: 0x000F7AD8
	private IEnumerator Trigger()
	{
		if (this.carLogic.GetComponent<CarLogicC>())
		{
			if (!this.open && !this.carLogic.GetComponent<CarLogicC>().bonnetPopped)
			{
				iTween.Stop(this.carFrame, "PunchRotation");
				this.carFrame.transform.localEulerAngles = new Vector3(0f, this.carFrame.transform.localEulerAngles.y, this.carFrame.transform.localEulerAngles.z);
				iTween.PunchRotation(this.carFrame, iTween.Hash(new object[]
				{
					"x",
					-0.6,
					"easetype",
					"easeInCirc",
					"islocal",
					true,
					"time",
					1.75
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.shakeSFX, 0.7f);
				yield break;
			}
			if (!this.open && this.carLogic.GetComponent<CarLogicC>().bonnetPopped)
			{
				GameObject uncle = this.carLogic.GetComponent<CarLogicC>().uncle;
				uncle.SendMessage("BonnetOpened");
				base.GetComponent<AudioSource>().PlayOneShot(this.openSFX, 0.7f);
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.xyzOpen,
					"time",
					1.2,
					"islocal",
					true,
					"delay",
					0.2
				}));
				this.open = true;
				this.carLogic.GetComponent<CarLogicC>().bonnetOpen = true;
				this.carLogic.GetComponent<CarLogicC>().BonnetOpen();
				yield break;
			}
		}
		else
		{
			if (!this.open && !this.abandonBonnetPopped)
			{
				iTween.Stop(this.carFrame, "PunchRotation");
				this.carFrame.transform.localEulerAngles = new Vector3(0f, this.carFrame.transform.localEulerAngles.y, this.carFrame.transform.localEulerAngles.z);
				iTween.PunchRotation(this.carFrame, iTween.Hash(new object[]
				{
					"x",
					-0.6,
					"easetype",
					"easeInCirc",
					"islocal",
					true,
					"time",
					1.75
				}));
				base.GetComponent<AudioSource>().PlayOneShot(this.shakeSFX, 0.7f);
				yield break;
			}
			if (!this.open && this.abandonBonnetPopped)
			{
				base.GetComponent<AudioSource>().PlayOneShot(this.openSFX, 0.7f);
				iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
				{
					"rotation",
					this.xyzOpen,
					"time",
					1.2,
					"islocal",
					true,
					"delay",
					0.2
				}));
				this.open = true;
				if (this.carLogic.GetComponent<CarLogicC>())
				{
					this.carLogic.GetComponent<CarLogicC>().bonnetOpen = true;
					this.carLogic.GetComponent<CarLogicC>().BonnetOpen();
				}
				yield break;
			}
		}
		if (this.open)
		{
			if (this.carLogic.GetComponent<CarLogicC>() && this.carLogic.GetComponent<CarPerformanceC>().waterTankObj != null && this.carLogic.GetComponent<CarPerformanceC>().waterTankObj.GetComponent<EngineComponentC>().waterTankLid.GetComponent<WaterLidC>().currentPos == 1)
			{
				this.waterLid.GetComponent<WaterLidC>().StartCoroutine("Trigger");
			}
			iTween.RotateTo(base.gameObject.transform.parent.gameObject, iTween.Hash(new object[]
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
			base.GetComponent<AudioSource>().PlayOneShot(this.closeSFX, 0.7f);
			yield break;
		}
		yield break;
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x000F96F3 File Offset: 0x000F7AF3
	public void DoorClosed()
	{
		this.open = false;
		this.carLogic.GetComponent<CarLogicC>().bonnetPopped = false;
		this.carLogic.GetComponent<CarLogicC>().bonnetOpen = false;
		this.carLogic.GetComponent<CarLogicC>().BonnetClosed();
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x000F972E File Offset: 0x000F7B2E
	public void RaycastEnter()
	{
		this.isGlowing = true;
		this.handle.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x000F974D File Offset: 0x000F7B4D
	public void RaycastExit()
	{
		this.isGlowing = false;
		this.handle.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000EA8 RID: 3752
	public GameObject carLogic;

	// Token: 0x04000EA9 RID: 3753
	public GameObject waterLid;

	// Token: 0x04000EAA RID: 3754
	private bool open;

	// Token: 0x04000EAB RID: 3755
	public Vector3 xyzOpen;

	// Token: 0x04000EAC RID: 3756
	public Vector3 xyzPopped;

	// Token: 0x04000EAD RID: 3757
	public Vector3 xyzClosed;

	// Token: 0x04000EAE RID: 3758
	public AudioClip openSFX;

	// Token: 0x04000EAF RID: 3759
	public AudioClip closeSFX;

	// Token: 0x04000EB0 RID: 3760
	public AudioClip shakeSFX;

	// Token: 0x04000EB1 RID: 3761
	public GameObject carFrame;

	// Token: 0x04000EB2 RID: 3762
	public Material startMaterial;

	// Token: 0x04000EB3 RID: 3763
	public Material glowMaterial;

	// Token: 0x04000EB4 RID: 3764
	public GameObject handle;

	// Token: 0x04000EB5 RID: 3765
	private bool isGlowing;

	// Token: 0x04000EB6 RID: 3766
	[HideInInspector]
	public bool abandonBonnetPopped;
}
