using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A1 RID: 161
public class DialogueStuffsC : MonoBehaviour
{
	// Token: 0x06000536 RID: 1334 RVA: 0x00058D84 File Offset: 0x00057184
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		DialogueStuffs component = base.GetComponent<DialogueStuffs>();
		this.target = component.target;
		this._camera = component._camera;
		component.sprites.Copy(ref this.sprites);
		this.spriteHolder = component.spriteHolder;
		this.letterPause = component.letterPause;
		component.sound.Copy(ref this.sound);
		component.talkSound.Copy(ref this.talkSound);
		component.yellSound.Copy(ref this.yellSound);
		this._nameHolder = component._nameHolder;
		this.word = component.word;
		this._name = component._name;
		this.skipLevel = component.skipLevel;
		component.enabled = false;
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x00058E50 File Offset: 0x00057250
	private void Start()
	{
		this.word = string.Empty;
		this._name = string.Empty;
		base.GetComponent<UILabel>().text = string.Empty;
		this.letterPausex2 = this.letterPause / 20f;
		this.letterPauseOriginal = this.letterPause;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			this.spriteHolder.transform.localScale *= 1.2f;
			this.sprites = this.xboxSprites;
		}
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x00058EDC File Offset: 0x000572DC
	private void Update()
	{
		if (this._camera == null)
		{
			this._camera = Camera.main.gameObject;
		}
		if (Input.GetButton("Fire1") || Input.GetKey(MainMenuC.Global.assignedInputStrings[16]) || Input.GetKey(MainMenuC.Global.assignedInputStrings[17]))
		{
			this.letterPause = 0f;
		}
		else
		{
			this.letterPause = this.letterPauseOriginal;
		}
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x00058F63 File Offset: 0x00057363
	public void StartTypeText(GameObject target1)
	{
		this.target = target1;
		this._camera.GetComponent<DragRigidbodyC>().inputRestrict = true;
		target1.SendMessage("StopInputRestrictStopper");
		base.StartCoroutine(this.TypeText());
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x00058F95 File Offset: 0x00057395
	public void StopTypeText()
	{
		base.StopCoroutine("TypeText");
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x00058FA4 File Offset: 0x000573A4
	private IEnumerator TypeText()
	{
		this._nameHolder.GetComponent<UILabel>().text = this._name;
		base.GetComponent<UILabel>().text = string.Empty;
		foreach (char letter in this.word.ToCharArray())
		{
			if (letter == '.' && this.elipsis)
			{
				float pauseLonger = this.letterPause * 5f;
				yield return new WaitForSeconds(pauseLonger);
			}
			if (letter == '.')
			{
				this.elipsis = true;
			}
			else
			{
				this.elipsis = false;
			}
			if (letter == '[')
			{
				this.skipLevel++;
			}
			else if (this.skipLevel == 1 && letter == 'b')
			{
				UILabel component = base.GetComponent<UILabel>();
				component.text += "[b]";
				this.skipLevel++;
			}
			else if (this.skipLevel == 1 && letter == '/')
			{
				UILabel component2 = base.GetComponent<UILabel>();
				component2.text += "[/b]";
				this.skipLevel += 10;
			}
			else if (this.skipLevel == 2)
			{
				this.skipLevel++;
			}
			else if (this.skipLevel == 11)
			{
				this.skipLevel++;
			}
			else if (this.skipLevel == 12)
			{
				this.skipLevel++;
			}
			else
			{
				this.skipLevel = 0;
				UILabel component3 = base.GetComponent<UILabel>();
				component3.text += letter;
				if (this.sound.Length > 0 && this.sound[0] != null)
				{
					int num = UnityEngine.Random.Range(0, this.sound.Length);
					base.GetComponent<AudioSource>().PlayOneShot(this.sound[num]);
				}
				if ((double)this.letterPause != 0.0)
				{
					yield return new WaitForSeconds(this.letterPause);
				}
			}
		}
		yield return new WaitForSeconds(0.2f);
		this.target.SendMessage("TextFinished");
		yield break;
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x00058FBF File Offset: 0x000573BF
	public void RightClickAnim()
	{
		base.InvokeRepeating("RightClickIcon", 0f, 0.5f);
		base.InvokeRepeating("RightClickIcon2", 0.25f, 0.5f);
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x00058FEB File Offset: 0x000573EB
	public void LeftClickAnim()
	{
		base.InvokeRepeating("LeftClickIcon", 0f, 0.5f);
		base.InvokeRepeating("LeftClickIcon2", 0.25f, 0.5f);
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x00059017 File Offset: 0x00057417
	public void DropAnim()
	{
		base.InvokeRepeating("DropIcon", 0f, 0.5f);
		base.InvokeRepeating("Drop2Icon", 0.25f, 0.5f);
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x00059043 File Offset: 0x00057443
	public void DropIcon()
	{
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = this.sprites[4];
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x0005905D File Offset: 0x0005745D
	public void Drop2Icon()
	{
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = this.sprites[5];
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x00059077 File Offset: 0x00057477
	public void DropAnimStop()
	{
		base.CancelInvoke();
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = null;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x00059090 File Offset: 0x00057490
	public void LeftClickAnimStop()
	{
		base.CancelInvoke();
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = null;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x000590A9 File Offset: 0x000574A9
	public void LeftClickIcon()
	{
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x000590C3 File Offset: 0x000574C3
	public void RightClickIcon()
	{
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = this.sprites[2];
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x000590DD File Offset: 0x000574DD
	public void RightClickIcon2()
	{
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = this.sprites[3];
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x000590F7 File Offset: 0x000574F7
	public void LeftClickIcon2()
	{
		this.spriteHolder.GetComponent<SpriteRenderer>().sprite = this.sprites[1];
	}

	// Token: 0x040007A4 RID: 1956
	public GameObject target;

	// Token: 0x040007A5 RID: 1957
	public GameObject _camera;

	// Token: 0x040007A6 RID: 1958
	public Sprite[] sprites = new Sprite[0];

	// Token: 0x040007A7 RID: 1959
	public Sprite[] xboxSprites = new Sprite[0];

	// Token: 0x040007A8 RID: 1960
	public GameObject spriteHolder;

	// Token: 0x040007A9 RID: 1961
	public float letterPause = 0.2f;

	// Token: 0x040007AA RID: 1962
	private float letterPausex2;

	// Token: 0x040007AB RID: 1963
	private float letterPauseOriginal;

	// Token: 0x040007AC RID: 1964
	public AudioClip[] sound = new AudioClip[0];

	// Token: 0x040007AD RID: 1965
	public AudioClip[] talkSound = new AudioClip[0];

	// Token: 0x040007AE RID: 1966
	public AudioClip[] yellSound = new AudioClip[0];

	// Token: 0x040007AF RID: 1967
	private bool elipsis;

	// Token: 0x040007B0 RID: 1968
	public GameObject _nameHolder;

	// Token: 0x040007B1 RID: 1969
	public string word = string.Empty;

	// Token: 0x040007B2 RID: 1970
	public string _name = string.Empty;

	// Token: 0x040007B3 RID: 1971
	public int skipLevel;
}
