using System;
using UnityEngine;

// Token: 0x020000E3 RID: 227
public class PaintCanC : MonoBehaviour
{
	// Token: 0x060008E2 RID: 2274 RVA: 0x000BF2D8 File Offset: 0x000BD6D8
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		base.gameObject.name = "PaintCan";
		base.GetComponent<EngineComponentC>().Condition = this.ammo;
		base.GetComponent<EngineComponentC>().durability = 100f;
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x000BF328 File Offset: 0x000BD728
	private void Update()
	{
		if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKeyUp(MainMenuC.Global.assignedInputStrings[17]))
		{
			this.StopAction();
			return;
		}
		if (this.target != null)
		{
			if (this.target != this.lastTarget)
			{
				this.t = 0f;
				this.carStartingColor = this.target.GetComponent<Renderer>().material.color;
			}
			if ((double)this.ammo <= 0.0)
			{
				if (!this.canEmptyParticles.active && !this.canRegisteredEmpty)
				{
					this.canParticles.active = false;
					this.canEmptyParticles.active = true;
					base.GetComponent<AudioSource>().clip = this.sprayEmptyAudio;
					this.canRegisteredEmpty = true;
				}
				return;
			}
			if (this.canOn)
			{
				this.lerpedColor = Color.Lerp(this.carStartingColor, this.canColor, this.t);
				Color value = Color.Lerp(this.target.GetComponent<Renderer>().material.GetColor("_SpecColor"), Color.black, this.t);
				if (this.isMetalic)
				{
					this.target.GetComponent<Renderer>().material.SetColor("_SpecColor", this.lerpedColor);
				}
				else
				{
					this.target.GetComponent<Renderer>().material.color = this.lerpedColor;
					this.target.GetComponent<Renderer>().material.SetColor("_SpecColor", value);
				}
				this.ammo -= Time.deltaTime * this.ammoRate;
				base.GetComponent<EngineComponentC>().Condition = this.ammo;
				if (this.target.GetComponent<PaintCanRelayC>())
				{
					for (int i = 0; i < this.target.GetComponent<PaintCanRelayC>().targets.Length; i++)
					{
						if (this.isMetalic)
						{
							this.target.GetComponent<PaintCanRelayC>().targets[i].GetComponent<Renderer>().material.SetColor("_SpecColor", this.lerpedColor);
						}
						else
						{
							this.target.GetComponent<PaintCanRelayC>().targets[i].GetComponent<Renderer>().material.SetColor("_SpecColor", value);
							this.target.GetComponent<PaintCanRelayC>().targets[i].GetComponent<Renderer>().material.color = this.lerpedColor;
						}
					}
				}
				if (this.t < 1f)
				{
					this.t += Time.deltaTime / this.duration;
				}
			}
			this.lastTarget = this.target;
		}
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x000BF604 File Offset: 0x000BDA04
	public void Action()
	{
		if (this.isMetalic)
		{
			this.carStartingColor = this.target.GetComponent<Renderer>().material.GetColor("_SpecColor");
		}
		else
		{
			this.carStartingColor = this.target.GetComponent<Renderer>().material.color;
		}
		iTween.MoveTo(this.canLid, iTween.Hash(new object[]
		{
			"position",
			this.lidPositions[1],
			"islocal",
			true,
			"time",
			0.1,
			"easetype",
			"easeoutquad",
			"oncomplete",
			"ActionPart2",
			"oncompletetarget",
			base.gameObject
		}));
		iTween.RotateTo(this.canLid, iTween.Hash(new object[]
		{
			"rotation",
			this.lidRotations[1],
			"islocal",
			true,
			"time",
			0.12,
			"easetype",
			"easeoutquad"
		}));
		base.GetComponent<AudioSource>().PlayOneShot(this.lidAudio, 1f);
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x000BF77C File Offset: 0x000BDB7C
	public void ActionPart2()
	{
		if ((double)this.ammo <= 0.0)
		{
			this.canEmptyParticles.active = true;
			base.GetComponent<AudioSource>().clip = this.sprayEmptyAudio;
			base.GetComponent<AudioSource>().loop = true;
			base.GetComponent<AudioSource>().Play();
			this.canRegisteredEmpty = true;
			return;
		}
		this.canParticles.active = true;
		if (this.target != null)
		{
			this.canOn = true;
		}
		base.GetComponent<AudioSource>().clip = this.sprayAudio;
		base.GetComponent<AudioSource>().loop = true;
		base.GetComponent<AudioSource>().Play();
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x000BF828 File Offset: 0x000BDC28
	public void StopAction()
	{
		if (base.GetComponent<AudioSource>().clip == this.sprayAudio || base.GetComponent<AudioSource>().clip == this.sprayEmptyAudio)
		{
			base.GetComponent<AudioSource>().Stop();
		}
		this.canEmptyParticles.active = false;
		this.canParticles.active = false;
		this.t = 0f;
		if (this.target != null)
		{
			if (this.isMetalic)
			{
				this.carStartingColor = this.target.GetComponent<Renderer>().material.GetColor("_SpecColor");
			}
			else
			{
				this.carStartingColor = this.target.GetComponent<Renderer>().material.color;
			}
		}
		this.canOn = false;
		iTween.MoveTo(this.canLid, iTween.Hash(new object[]
		{
			"position",
			this.lidPositions[0],
			"islocal",
			true,
			"time",
			0.1,
			"easetype",
			"easeoutquad"
		}));
		iTween.RotateTo(this.canLid, iTween.Hash(new object[]
		{
			"rotation",
			this.lidRotations[0],
			"islocal",
			true,
			"time",
			0.12,
			"easetype",
			"easeoutquad"
		}));
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x000BF9E0 File Offset: 0x000BDDE0
	public void UnAction()
	{
		iTween.PunchPosition(base.gameObject, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, 0.6f, 0f),
			"time",
			0.5
		}));
		base.GetComponent<AudioSource>().clip = this.shakeAudio;
		base.GetComponent<AudioSource>().loop = false;
		base.GetComponent<AudioSource>().Play();
	}

	// Token: 0x04000BD2 RID: 3026
	private GameObject _camera;

	// Token: 0x04000BD3 RID: 3027
	public GameObject target;

	// Token: 0x04000BD4 RID: 3028
	private GameObject lastTarget;

	// Token: 0x04000BD5 RID: 3029
	public GameObject canParticles;

	// Token: 0x04000BD6 RID: 3030
	public GameObject canEmptyParticles;

	// Token: 0x04000BD7 RID: 3031
	public GameObject canLid;

	// Token: 0x04000BD8 RID: 3032
	public float ammo = 100f;

	// Token: 0x04000BD9 RID: 3033
	public float ammoRate = 2.5f;

	// Token: 0x04000BDA RID: 3034
	public AudioClip lidAudio;

	// Token: 0x04000BDB RID: 3035
	public AudioClip sprayAudio;

	// Token: 0x04000BDC RID: 3036
	public AudioClip shakeAudio;

	// Token: 0x04000BDD RID: 3037
	public AudioClip sprayEmptyAudio;

	// Token: 0x04000BDE RID: 3038
	public Vector3[] lidPositions = new Vector3[0];

	// Token: 0x04000BDF RID: 3039
	public Vector3[] lidRotations = new Vector3[0];

	// Token: 0x04000BE0 RID: 3040
	public Color carStartingColor = Color.white;

	// Token: 0x04000BE1 RID: 3041
	public Color canColor = Color.white;

	// Token: 0x04000BE2 RID: 3042
	public bool isMetalic;

	// Token: 0x04000BE3 RID: 3043
	public Color lerpedColor = Color.white;

	// Token: 0x04000BE4 RID: 3044
	public float duration = 5f;

	// Token: 0x04000BE5 RID: 3045
	private float t;

	// Token: 0x04000BE6 RID: 3046
	private bool canRegisteredEmpty;

	// Token: 0x04000BE7 RID: 3047
	public bool canOn;
}
