using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000092 RID: 146
public class BoxContentsC : MonoBehaviour
{
	// Token: 0x0600048B RID: 1163 RVA: 0x0004DCD4 File Offset: 0x0004C0D4
	private void Start()
	{
		this.rndContents = UnityEngine.Random.Range(0, 6);
		this.SpawnContents();
		if (this.rndContents == 0)
		{
			this.alchol = true;
		}
		else if (this.rndContents == 1)
		{
			this.pharma = true;
		}
		else if (this.rndContents == 2)
		{
			this.machineParts = true;
		}
		else if (this.rndContents == 3)
		{
			this.textiles = true;
		}
		else if (this.rndContents == 4)
		{
			this.tobacco = true;
		}
		else if (this.rndContents == 5)
		{
			this.munitions = true;
		}
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0004DD80 File Offset: 0x0004C180
	public void SpawnContents()
	{
		this.itemsInBox = UnityEngine.Random.Range(0, this.slots.Length);
		if (this.itemsInBox == 0)
		{
			int num = UnityEngine.Random.Range(0, 100);
			if (num <= 75)
			{
				this.itemsInBox++;
			}
		}
		if (this.itemsInBox < this.slots.Length)
		{
			int num2 = UnityEngine.Random.Range(0, 100);
			if (num2 <= 50)
			{
				this.itemsInBox++;
			}
		}
		if (this.rndContents != 0)
		{
			for (int i = 0; i < this.slots.Length; i++)
			{
				if (this.spawnedItems >= this.itemsInBox)
				{
					return;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.supplies[this.rndContents], this.slots[i].position, this.slots[i].rotation);
				gameObject.transform.parent = this.slots[i];
				gameObject.name = this.supplies[this.rndContents].name;
				gameObject.GetComponent<ObjectPickupC>().crateSpawned = true;
				this.spawnedItems++;
			}
		}
		else if (this.boxSize == 2)
		{
			for (int j = 0; j < 6; j++)
			{
				if (this.spawnedItems >= this.itemsInBox)
				{
					return;
				}
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.supplies[this.rndContents], this.slots[j].position, this.slots[j].rotation);
				gameObject2.transform.parent = this.slots[j];
				gameObject2.name = this.supplies[this.rndContents].name;
				gameObject2.GetComponent<ObjectPickupC>().crateSpawned = true;
				this.spawnedItems++;
				gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
		}
		else if (this.boxSize == 1)
		{
			for (int k = 0; k < 3; k++)
			{
				if (this.spawnedItems >= this.itemsInBox)
				{
					return;
				}
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.supplies[this.rndContents], this.slots[k].position, this.slots[k].rotation);
				gameObject3.transform.parent = this.slots[k];
				gameObject3.name = this.supplies[this.rndContents].name;
				gameObject3.GetComponent<ObjectPickupC>().crateSpawned = true;
				this.spawnedItems++;
				gameObject3.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
		}
		else if (this.boxSize == 0)
		{
			if (this.spawnedItems >= this.itemsInBox)
			{
				return;
			}
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.supplies[this.rndContents], this.slots[0].position, this.slots[0].rotation);
			gameObject4.transform.parent = this.slots[0];
			gameObject4.name = this.supplies[this.rndContents].name;
			gameObject4.GetComponent<ObjectPickupC>().crateSpawned = true;
			this.spawnedItems++;
			gameObject4.transform.localPosition = new Vector3(-0.04f, 0f, 0f);
			gameObject4.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
		}
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0004E121 File Offset: 0x0004C521
	public void RemoveContent()
	{
		this.spawnedItems--;
		if (this.spawnedItems == 0)
		{
			base.gameObject.GetComponent<Animator>().SetBool("Die", true);
		}
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0004E154 File Offset: 0x0004C554
	public void PickUp()
	{
		if (this.padLock != null)
		{
			iTween.Stop(this.padLock);
			base.StartCoroutine("PlayLockAudio");
			iTween.RotateTo(this.padLock, iTween.Hash(new object[]
			{
				"rotation",
				this.padLockRotations[1],
				"islocal",
				true,
				"time",
				0.1,
				"delay",
				0.5,
				"easetype",
				"easeoutquad",
				"oncomplete",
				"PadlockRotateBack",
				"oncompletetarget",
				base.gameObject
			}));
		}
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x0004E23C File Offset: 0x0004C63C
	private IEnumerator PlayLockAudio()
	{
		yield return new WaitForSeconds(0.5f);
		base.GetComponent<AudioSource>().PlayOneShot(this.audioShake, 1f);
		yield break;
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x0004E258 File Offset: 0x0004C658
	public void PadlockRotateBack()
	{
		iTween.RotateTo(this.padLock, iTween.Hash(new object[]
		{
			"rotation",
			this.padLockRotations[0],
			"islocal",
			true,
			"time",
			0.4,
			"easetype",
			"easeoutbounce"
		}));
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x0004E2D6 File Offset: 0x0004C6D6
	public void Open()
	{
		base.gameObject.GetComponent<Animator>().SetBool("Open", true);
		UnityEngine.Object.Destroy(base.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(base.GetComponent<BoxCollider>());
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x0004E304 File Offset: 0x0004C704
	public void IntoInventory()
	{
		this.boxOpener.SendMessage("IntoInventory");
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0004E316 File Offset: 0x0004C716
	public void OutOfInventory()
	{
		this.boxOpener.SendMessage("OutOfInventory");
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x0004E328 File Offset: 0x0004C728
	private void Update()
	{
		if (base.transform.position.y < -4000f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400069C RID: 1692
	public int boxSize;

	// Token: 0x0400069D RID: 1693
	public bool alchol;

	// Token: 0x0400069E RID: 1694
	public bool pharma;

	// Token: 0x0400069F RID: 1695
	public bool machineParts;

	// Token: 0x040006A0 RID: 1696
	public bool textiles;

	// Token: 0x040006A1 RID: 1697
	public bool tobacco;

	// Token: 0x040006A2 RID: 1698
	public bool munitions;

	// Token: 0x040006A3 RID: 1699
	public GameObject[] supplies = new GameObject[0];

	// Token: 0x040006A4 RID: 1700
	public Transform[] slots = new Transform[0];

	// Token: 0x040006A5 RID: 1701
	public int spawnedItems;

	// Token: 0x040006A6 RID: 1702
	public GameObject boxOpener;

	// Token: 0x040006A7 RID: 1703
	public int rndContents;

	// Token: 0x040006A8 RID: 1704
	private int itemsInBox;

	// Token: 0x040006A9 RID: 1705
	public GameObject padLock;

	// Token: 0x040006AA RID: 1706
	public Vector3[] padLockRotations = new Vector3[0];

	// Token: 0x040006AB RID: 1707
	public AudioClip audioShake;
}
