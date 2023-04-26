using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000111 RID: 273
public class DoorExitLogicC : MonoBehaviour
{
	// Token: 0x06000AC8 RID: 2760 RVA: 0x000FB4B0 File Offset: 0x000F98B0
	private void Start()
	{
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x06000AC9 RID: 2761 RVA: 0x000FB4C4 File Offset: 0x000F98C4
	private void Update()
	{
		this.spriteTarget.transform.LookAt(this._camera.transform.position, -Vector3.up);
		if (this.spriteTimer > this.spriteTimerCheck)
		{
			if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[0])
			{
				this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[1];
			}
			else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[1])
			{
				this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[2];
			}
			else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[2])
			{
				this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[3];
			}
			else if (this.spriteTarget.GetComponent<SpriteRenderer>().sprite == this.sprites[3])
			{
				this.spriteTarget.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
			}
			this.spriteTimer = 0f;
		}
		this.spriteTimer += Time.deltaTime;
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x000FB620 File Offset: 0x000F9A20
	public void Trigger()
	{
		this.seatObj.GetComponent<SeatLogicC>().isSat = false;
		this.player.GetComponent<RigidbodyControllerC>().isSat = false;
		this.player.GetComponent<MouseLook>().isSat = false;
		this._camera.GetComponent<MouseLook>().isSat = false;
		base.transform.parent.GetComponent<CarPerformanceC>().UpdateFuelEconomy();
		base.transform.parent.GetComponent<CarPerformanceC>().UpdateFuelInTank();
		this.player.transform.parent = null;
		this.seatObj.GetComponent<SeatLogicC>().StopInteriorRainAudio();
		this._camera.GetComponent<DragRigidbodyC>().enabled = false;
		if (this.player.GetComponent<CharacterController>())
		{
			this.player.GetComponent<CharacterController>().enabled = false;
		}
		if (this.player.GetComponent<Rigidbody>())
		{
			this.player.GetComponent<Rigidbody>().isKinematic = true;
			this.player.GetComponent<Rigidbody>().detectCollisions = false;
			this.player.GetComponent<CapsuleCollider>().enabled = false;
		}
		this._camera.GetComponent<MouseLook>().enabled = false;
		this.player.GetComponent<MouseLook>().enabled = false;
		this.player.transform.MoveRotateTo(base.transform.position, new Vector3(0f, this.player.transform.eulerAngles.y, 0f), this.tweenTime, 0f, this, delegate()
		{
			base.StartCoroutine(this.RestoreControl());
		});
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x000FB7B8 File Offset: 0x000F9BB8
	public IEnumerator RestoreControl()
	{
		this.seatObj.tag = "Interactor";
		if (MainMenuC.Global.mouseSmooth)
		{
			this._camera.GetComponent<MouseLook>().yTargetRotation = this._camera.transform.localRotation.y;
			this.player.GetComponent<MouseLook>().xTargetRotation = this.player.transform.localRotation.x;
		}
		this._camera.GetComponent<DragRigidbodyC>().enabled = true;
		this._camera.GetComponent<MouseLook>().enabled = true;
		this.player.GetComponent<MouseLook>().enabled = true;
		yield return new WaitForSeconds(0.1f);
		if (this.player.GetComponent<CharacterController>())
		{
			this.player.GetComponent<CharacterController>().enabled = true;
		}
		if (this.player.GetComponent<Rigidbody>())
		{
			this.player.GetComponent<CapsuleCollider>().enabled = true;
			this.player.GetComponent<Rigidbody>().detectCollisions = true;
			this.player.GetComponent<Rigidbody>().isKinematic = false;
		}
		this.player.transform.RSetLocalX(0f);
		this.player.transform.RSetLocalZ(0f);
		this.player.GetComponent<FootstepsC>().enabled = true;
		base.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x04000EDF RID: 3807
	private GameObject _camera;

	// Token: 0x04000EE0 RID: 3808
	public float tweenTime;

	// Token: 0x04000EE1 RID: 3809
	public string easeType = string.Empty;

	// Token: 0x04000EE2 RID: 3810
	public string rotEaseType = string.Empty;

	// Token: 0x04000EE3 RID: 3811
	public GameObject player;

	// Token: 0x04000EE4 RID: 3812
	public GameObject seatObj;

	// Token: 0x04000EE5 RID: 3813
	public GameObject spriteTarget;

	// Token: 0x04000EE6 RID: 3814
	public Sprite[] sprites;

	// Token: 0x04000EE7 RID: 3815
	public float spriteTimer;

	// Token: 0x04000EE8 RID: 3816
	public float spriteTimerCheck = 0.15f;
}
