using System;
using UnityEngine;

// Token: 0x02000128 RID: 296
public class WalletC : MonoBehaviour
{
	// Token: 0x17000034 RID: 52
	// (get) Token: 0x06000C19 RID: 3097 RVA: 0x0012700A File Offset: 0x0012540A
	// (set) Token: 0x06000C1A RID: 3098 RVA: 0x00127012 File Offset: 0x00125412
	public float TotalWealth
	{
		get
		{
			return this.totalWealth;
		}
		set
		{
			this.totalWealth = Mathf.Round(value);
		}
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x00127020 File Offset: 0x00125420
	public void Start()
	{
		this.director = GameObject.FindGameObjectWithTag("Director");
		this.UpdateWealth();
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x00127038 File Offset: 0x00125438
	private void Update()
	{
		if (Application.isEditor && Input.GetKeyDown(KeyCode.U))
		{
			this.TotalWealth += 500f;
		}
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x00127062 File Offset: 0x00125462
	public void UpdateWealth()
	{
		this.ChangeMoney();
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x0012706C File Offset: 0x0012546C
	public void ChangeMoney()
	{
		if (this.noteObj.active)
		{
			iTween.MoveTo(this.noteObj, iTween.Hash(new object[]
			{
				"path",
				new Transform[]
				{
					this.path[0],
					this.path[1]
				},
				"time",
				0.75,
				"islocal",
				false,
				"easetype",
				"easeinoutexpo",
				"oncomplete",
				"ChangeMoneyPart2",
				"oncompletetarget",
				base.gameObject
			}));
		}
		else
		{
			base.StartCoroutine("ChangeMoneyPart2");
		}
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x00127138 File Offset: 0x00125538
	public void ChangeMoneyPart2()
	{
		this.TotalWealth += this.incomingFunds;
		this.incomingFunds = 0f;
		if (this.TotalWealth > 0f)
		{
			this.note2.transform.localPosition = this.path[2].transform.position;
			this.noteObj.active = true;
			this.moneyText.active = true;
		}
		if (this.TotalWealth < 5f)
		{
			if (this.TotalWealth == 1f)
			{
				this.moneyText.GetComponent<TextMesh>().text = "1";
				this.note2.active = false;
				this.note3.active = false;
				this.note4.active = false;
			}
			if (this.TotalWealth == 2f)
			{
				this.moneyText.GetComponent<TextMesh>().text = "2";
				this.note2.active = true;
				this.note3.active = false;
				this.note4.active = false;
			}
			if (this.TotalWealth == 3f)
			{
				this.moneyText.GetComponent<TextMesh>().text = "3";
				this.note2.active = true;
				this.note3.active = true;
				this.note4.active = false;
			}
			if (this.TotalWealth >= 4f)
			{
				this.moneyText.GetComponent<TextMesh>().text = "4";
				this.note2.active = true;
				this.note3.active = true;
				this.note4.active = true;
			}
		}
		if (this.TotalWealth <= 5f)
		{
			this.noteObj.GetComponent<Renderer>().material = this.lowValueNote;
			if (this.TotalWealth == 5f)
			{
				this.moneyText.GetComponent<TextMesh>().text = this.TotalWealth.ToString();
			}
		}
		if (this.TotalWealth > 5f && this.TotalWealth <= 10f)
		{
			this.moneyText.GetComponent<TextMesh>().text = this.TotalWealth.ToString();
			this.noteObj.GetComponent<Renderer>().material = this.midValueNote;
			this.note2.active = false;
			this.note3.active = false;
			this.note4.active = false;
		}
		if (this.TotalWealth > 10f)
		{
			this.moneyText.GetComponent<TextMesh>().text = this.TotalWealth.ToString();
			this.noteObj.GetComponent<Renderer>().material = this.highValueNote;
			this.note2.active = false;
			this.note3.active = false;
			this.note4.active = false;
		}
		if (this.TotalWealth == 0f)
		{
			this.moneyText.GetComponent<TextMesh>().text = this.TotalWealth.ToString();
			this.noteObj.active = false;
			this.moneyText.active = false;
			this.note2.active = false;
			this.note3.active = false;
			this.note4.active = false;
		}
		if (this.director != null)
		{
			this.director.GetComponent<DirectorC>().totalWealth = this.TotalWealth;
		}
		this.ReturnMoney();
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x001274C4 File Offset: 0x001258C4
	public void ReturnMoney()
	{
		iTween.MoveTo(this.noteObj, iTween.Hash(new object[]
		{
			"path",
			new Transform[]
			{
				this.path[0],
				this.path[2]
			},
			"time",
			0.75,
			"islocal",
			false,
			"easetype",
			"easeinoutexpo",
			"oncomplete",
			"PositionMoney",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x0012756D File Offset: 0x0012596D
	public void PositionMoney()
	{
		this.noteObj.transform.localPosition = new Vector3(0f, 0f, 0.1f);
		this.noteObj.transform.localRotation = Quaternion.identity;
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x001275A8 File Offset: 0x001259A8
	public void UnAction()
	{
		iTween.Stop(base.gameObject);
		base.transform.localPosition = this.position[1];
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[0],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1,
			"oncomplete",
			"UnActionPart2",
			"oncompletetarget",
			base.gameObject
		}));
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x00127678 File Offset: 0x00125A78
	public void UnActionPart2()
	{
		iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
		{
			"position",
			this.position[1],
			"islocal",
			true,
			"time",
			this.timeToComplete / 2f,
			"easetype",
			this.easeType1
		}));
	}

	// Token: 0x04001094 RID: 4244
	[HideInInspector]
	public GameObject director;

	// Token: 0x04001095 RID: 4245
	public float totalWealth;

	// Token: 0x04001096 RID: 4246
	public float incomingFunds;

	// Token: 0x04001097 RID: 4247
	public GameObject noteObj;

	// Token: 0x04001098 RID: 4248
	public GameObject moneyText;

	// Token: 0x04001099 RID: 4249
	public Vector3[] position = new Vector3[0];

	// Token: 0x0400109A RID: 4250
	public float timeToComplete;

	// Token: 0x0400109B RID: 4251
	public string easeType1 = string.Empty;

	// Token: 0x0400109C RID: 4252
	public Transform[] path = new Transform[0];

	// Token: 0x0400109D RID: 4253
	public Material lowValueNote;

	// Token: 0x0400109E RID: 4254
	public Material midValueNote;

	// Token: 0x0400109F RID: 4255
	public Material highValueNote;

	// Token: 0x040010A0 RID: 4256
	public GameObject note2;

	// Token: 0x040010A1 RID: 4257
	public GameObject note3;

	// Token: 0x040010A2 RID: 4258
	public GameObject note4;
}
