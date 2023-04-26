using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class CurtainsLogicC : MonoBehaviour
{
	// Token: 0x06000021 RID: 33 RVA: 0x00003189 File Offset: 0x00001589
	public void Start()
	{
		this.startMaterial = this.renderTargets[0].GetComponent<Renderer>().material;
		this._camera = Camera.main.gameObject;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000031B4 File Offset: 0x000015B4
	public void Trigger()
	{
		if (!this.open)
		{
			if (!this.scaleCurtain)
			{
				this.curtain1.GetComponent<Animation>().Play("OpenCurtains0");
				this.curtain2.GetComponent<Animation>().Play("OpenCurtains0");
			}
			if (this.scaleCurtain)
			{
				iTween.ScaleTo(this.curtain1, iTween.Hash(new object[]
				{
					"scale",
					new Vector3(0.4f, 1f, 0.6f),
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				iTween.MoveTo(this.curtain1, iTween.Hash(new object[]
				{
					"x",
					-0.89,
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				iTween.ScaleTo(this.curtain2, iTween.Hash(new object[]
				{
					"scale",
					new Vector3(0.4f, 1f, 0.6f),
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				iTween.MoveTo(this.curtain2, iTween.Hash(new object[]
				{
					"x",
					1,
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				if (this._audio.Length > 0)
				{
					int num = UnityEngine.Random.Range(0, this._audio.Length);
					base.GetComponent<AudioSource>().PlayOneShot(this._audio[num], 1f);
				}
			}
			if (this.curtainSheath != null)
			{
				iTween.RotateTo(this.curtainSheath, iTween.Hash(new object[]
				{
					"rotation",
					this.rotTurn,
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
			}
			if (this.curtainSheath2 != null)
			{
				iTween.RotateTo(this.curtainSheath2, iTween.Hash(new object[]
				{
					"rotation",
					this.rotTurn2,
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
			}
			if (this._audio.Length > 0 && this._audio[0] != null)
			{
				int num2 = UnityEngine.Random.Range(0, this._audio.Length);
				base.GetComponent<AudioSource>().PlayOneShot(this._audio[num2], 1f);
			}
			this.open = true;
			return;
		}
		if (this.open)
		{
			if (!this.scaleCurtain)
			{
				this.curtain1.GetComponent<Animation>().Play("CloseCurtains0");
				this.curtain2.GetComponent<Animation>().Play("CloseCurtains0");
			}
			if (this.scaleCurtain)
			{
				iTween.ScaleTo(this.curtain1, iTween.Hash(new object[]
				{
					"scale",
					new Vector3(1f, 1f, 0.6f),
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				iTween.MoveTo(this.curtain1, iTween.Hash(new object[]
				{
					"x",
					0.052f,
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				iTween.ScaleTo(this.curtain2, iTween.Hash(new object[]
				{
					"scale",
					new Vector3(1f, 1f, 0.6f),
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				iTween.MoveTo(this.curtain2, iTween.Hash(new object[]
				{
					"x",
					0.023,
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
				if (this._audio[0] != null)
				{
					int num3 = UnityEngine.Random.Range(0, this._audio.Length);
					base.GetComponent<AudioSource>().PlayOneShot(this._audio[num3], 1f);
				}
			}
			if (this.curtainSheath != null)
			{
				iTween.RotateTo(this.curtainSheath, iTween.Hash(new object[]
				{
					"rotation",
					this.rotOriginal,
					"islocal",
					true,
					"time",
					0.6
				}));
			}
			if (this.curtainSheath2 != null)
			{
				iTween.RotateTo(this.curtainSheath2, iTween.Hash(new object[]
				{
					"rotation",
					this.rotOriginal2,
					"islocal",
					true,
					"easetype",
					this.sheathEaseType,
					"time",
					0.25
				}));
			}
			if (this._audio[0] != null)
			{
				int num4 = UnityEngine.Random.Range(0, this._audio.Length);
				base.GetComponent<AudioSource>().PlayOneShot(this._audio[num4], 1f);
			}
			this.open = false;
			return;
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x0000389C File Offset: 0x00001C9C
	public void OnMouseOver()
	{
		if (this._camera.GetComponent<DragRigidbodyC>().cursors[0].gameObject.active)
		{
			this.isGlowing = true;
			foreach (GameObject gameObject in this.renderTargets)
			{
				gameObject.GetComponent<Renderer>().material = this.glowMaterial;
			}
		}
		else if (this.isGlowing)
		{
			this.isGlowing = false;
			foreach (GameObject gameObject2 in this.renderTargets)
			{
				gameObject2.GetComponent<Renderer>().material = this.startMaterial;
			}
		}
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00003950 File Offset: 0x00001D50
	public void OnMouseExit()
	{
		this.isGlowing = false;
		foreach (GameObject gameObject in this.renderTargets)
		{
			gameObject.GetComponent<Renderer>().material = this.startMaterial;
		}
	}

	// Token: 0x04000020 RID: 32
	public bool scaleCurtain;

	// Token: 0x04000021 RID: 33
	private GameObject _camera;

	// Token: 0x04000022 RID: 34
	public GameObject curtain1;

	// Token: 0x04000023 RID: 35
	public GameObject curtain2;

	// Token: 0x04000024 RID: 36
	public GameObject curtainSheath;

	// Token: 0x04000025 RID: 37
	public GameObject curtainSheath2;

	// Token: 0x04000026 RID: 38
	public string sheathEaseType = string.Empty;

	// Token: 0x04000027 RID: 39
	public Vector3 rotOriginal;

	// Token: 0x04000028 RID: 40
	public Vector3 rotTurn;

	// Token: 0x04000029 RID: 41
	public Vector3 rotOriginal2;

	// Token: 0x0400002A RID: 42
	public Vector3 rotTurn2;

	// Token: 0x0400002B RID: 43
	public Material glowMaterial;

	// Token: 0x0400002C RID: 44
	public Material startMaterial;

	// Token: 0x0400002D RID: 45
	public bool open;

	// Token: 0x0400002E RID: 46
	private bool isGlowing;

	// Token: 0x0400002F RID: 47
	public AudioClip[] _audio;

	// Token: 0x04000030 RID: 48
	public GameObject[] renderTargets;
}
