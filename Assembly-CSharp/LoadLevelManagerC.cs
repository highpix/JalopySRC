using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000C1 RID: 193
public class LoadLevelManagerC : MonoBehaviour
{
	// Token: 0x0600070E RID: 1806 RVA: 0x0008C094 File Offset: 0x0008A494
	private void Start()
	{
		base.InvokeRepeating("LoadNewToolTip", 0f, 5f);
		base.StartCoroutine("Background1");
		base.StartCoroutine(this.BannerTexture1());
		base.StartCoroutine("LoadThread");
		this.loadingText.GetComponent<UILabel>().text = Language.Get("tooltip_loading", "Inspector_UI");
		iTween.RotateBy(this.loadingSpinner, iTween.Hash(new object[]
		{
			"amount",
			new Vector3(0f, 0f, -1f),
			"delay",
			0.0,
			"islocal",
			true,
			"time",
			0.75,
			"easetype",
			"easeinoutquint",
			"looptype",
			"loop"
		}));
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0008C19C File Offset: 0x0008A59C
	private IEnumerator LoadThread()
	{
		DOTween.KillAll(false);
		this.splashImage.DOColor(Color.clear, 0.7f);
		this.loadingSprite.DOColor(Color.clear, 0.7f);
		this.loadingSprite.transform.DORotate(Vector3.forward * 90f, 0.3f, RotateMode.Fast).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
		Application.backgroundLoadingPriority = ThreadPriority.High;
		yield return new WaitForEndOfFrame();
		AsyncOperation async = Application.LoadLevelAsync(3);
		yield return new WaitForEndOfFrame();
		yield return async;
		yield break;
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0008C1B8 File Offset: 0x0008A5B8
	public void LoadNewToolTip()
	{
		int num = UnityEngine.Random.Range(0, this.toolTipStrings.Length - 1);
		this.toolTip.GetComponent<UILabel>().text = Language.Get(this.toolTipStrings[num], "Inspector_UI");
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0008C1F8 File Offset: 0x0008A5F8
	private IEnumerator Background1()
	{
		iTween.MoveTo(this.textureBackgrounds[0], iTween.Hash(new object[]
		{
			"x",
			-30,
			"islocal",
			true,
			"time",
			8.0,
			"easetype",
			"linear"
		}));
		yield return new WaitForSeconds(3.9f);
		TweenAlpha.Begin(this.textureBackgrounds[0], 3.7f, 0f);
		TweenAlpha.Begin(this.textureBackgrounds[1], 3.7f, 1f);
		base.StopCoroutine("Background2");
		base.StartCoroutine("Background2");
		yield return new WaitForSeconds(3.8f);
		iTween.Stop(this.textureBackgrounds[0]);
		this.textureBackgrounds[0].transform.localPosition.SetX(-80f);
		yield break;
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0008C214 File Offset: 0x0008A614
	private IEnumerator Background2()
	{
		iTween.MoveTo(this.textureBackgrounds[1], iTween.Hash(new object[]
		{
			"x",
			38,
			"islocal",
			true,
			"time",
			8.0,
			"easetype",
			"linear"
		}));
		yield return new WaitForSeconds(3.9f);
		TweenAlpha.Begin(this.textureBackgrounds[1], 3.7f, 0f);
		TweenAlpha.Begin(this.textureBackgrounds[0], 3.7f, 1f);
		base.StopCoroutine("Background1");
		base.StartCoroutine("Background1");
		yield return new WaitForSeconds(3.8f);
		iTween.Stop(this.textureBackgrounds[1]);
		this.textureBackgrounds[1].transform.localPosition.SetX(-12f);
		yield break;
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0008C230 File Offset: 0x0008A630
	private IEnumerator BannerTexture1()
	{
		this.bannerTextures[0].localScale = new Vector3(-1f, 1f, 1f);
		yield return new WaitForSeconds(0.1f);
		this.bannerTextures[0].localScale = new Vector3(-1f, -1f, 1f);
		yield return new WaitForSeconds(0.1f);
		this.bannerTextures[0].localScale = new Vector3(1f, -1f, 1f);
		yield return new WaitForSeconds(0.1f);
		this.bannerTextures[0].localScale = new Vector3(1f, 1f, 1f);
		yield return new WaitForSeconds(0.1f);
		base.StartCoroutine("BannerTexture1");
		yield break;
	}

	// Token: 0x0400098B RID: 2443
	public Image splashImage;

	// Token: 0x0400098C RID: 2444
	public Image loadingSprite;

	// Token: 0x0400098D RID: 2445
	public GameObject loadingSpinner;

	// Token: 0x0400098E RID: 2446
	public GameObject[] textureBackgrounds = new GameObject[0];

	// Token: 0x0400098F RID: 2447
	public string[] toolTipStrings = new string[0];

	// Token: 0x04000990 RID: 2448
	public GameObject toolTip;

	// Token: 0x04000991 RID: 2449
	public GameObject loadingText;

	// Token: 0x04000992 RID: 2450
	public Transform[] bannerTextures = new Transform[0];
}
