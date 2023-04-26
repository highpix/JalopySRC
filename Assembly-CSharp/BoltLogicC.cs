using System;
using UnityEngine;

// Token: 0x0200008E RID: 142
public class BoltLogicC : MonoBehaviour
{
	// Token: 0x0600044B RID: 1099 RVA: 0x00048D1A File Offset: 0x0004711A
	private void Start()
	{
		this.startMaterial = base.GetComponent<Renderer>().material;
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x00048D40 File Offset: 0x00047140
	private void Update()
	{
		if (this.isGlowing)
		{
			float value = Mathf.PingPong(Time.time, 0.75f) + 1.25f;
			base.GetComponent<Renderer>().material.SetFloat("_RimPower", value);
		}
		if (this.isLoose && this.isFitted)
		{
			if (!this.spriteTarget.activeSelf)
			{
				this.spriteTarget.SetActive(true);
			}
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
		else if (this.spriteTarget != null && this.spriteTarget.activeSelf)
		{
			this.spriteTarget.SetActive(false);
		}
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x00048F37 File Offset: 0x00047337
	public void RaycastEnter()
	{
		this.isGlowing = true;
		base.GetComponent<Renderer>().material = this.glowMaterial;
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x00048F51 File Offset: 0x00047351
	public void RaycastExit()
	{
		this.isGlowing = false;
		base.GetComponent<Renderer>().material = this.startMaterial;
	}

	// Token: 0x04000649 RID: 1609
	public int carBoltSide;

	// Token: 0x0400064A RID: 1610
	private GameObject _camera;

	// Token: 0x0400064B RID: 1611
	public bool isCarBolt;

	// Token: 0x0400064C RID: 1612
	public bool isLoose;

	// Token: 0x0400064D RID: 1613
	public bool isFitted;

	// Token: 0x0400064E RID: 1614
	public bool boltStateLoose = true;

	// Token: 0x0400064F RID: 1615
	public Sprite[] sprites = new Sprite[0];

	// Token: 0x04000650 RID: 1616
	public GameObject spriteTarget;

	// Token: 0x04000651 RID: 1617
	private float spriteTimer;

	// Token: 0x04000652 RID: 1618
	public float spriteTimerCheck = 0.15f;

	// Token: 0x04000653 RID: 1619
	public bool isGlowing;

	// Token: 0x04000654 RID: 1620
	public Material startMaterial;

	// Token: 0x04000655 RID: 1621
	public Material glowMaterial;
}
