using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200015D RID: 349
[AddComponentMenu("Cursors/Animated Cursor")]
public class VfAnimCursor : MonoBehaviour
{
	// Token: 0x06000D6D RID: 3437 RVA: 0x00131E7C File Offset: 0x0013027C
	public void Reset()
	{
		this.FrameTextures = new Texture2D[0];
		this.HotSpot = Vector2.zero;
		this.CursorMode = CursorMode.Auto;
		this.FramesPerSecond = 15f;
		this.PingPong = false;
		this.ResetFrameOnEnable = true;
		this.AutoSortTextures = true;
		this._prevFrameIndex = -1;
	}

	// Token: 0x06000D6E RID: 3438 RVA: 0x00131ED0 File Offset: 0x001302D0
	public void Awake()
	{
		this._prevFrameIndex = -1;
		this._frameIndex = 0;
		if (UnityEngine.Object.FindObjectOfType<VfCursorManager>() != null)
		{
			base.gameObject.SetActive(false);
		}
		if (this.AutoSortTextures)
		{
			TextureSorter textureSorter = new TextureSorter();
			textureSorter.Sort(this.FrameTextures);
		}
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x00131F24 File Offset: 0x00130324
	public void Start()
	{
		this._lm = UnityEngine.Object.FindObjectOfType<VfLabelManager>();
	}

	// Token: 0x06000D70 RID: 3440 RVA: 0x00131F34 File Offset: 0x00130334
	public void OnEnable()
	{
		if (this.ResetFrameOnEnable)
		{
			this._frameIndex = 0;
			this._frameTime = 0f;
			this._dir = 1;
		}
		this._prevFrameIndex = -1;
		if (this.FrameTextures.Length == 0)
		{
			if (this._lm != null)
			{
				this._lm.HotSpot = Vector2.zero;
				this._lm.CursorSize = new Vector2(32f, 32f);
			}
			Cursor.SetCursor(null, this.HotSpot, this.CursorMode);
			if (Application.platform == RuntimePlatform.XboxOne)
			{
				this.xboxCursor.enabled = false;
			}
		}
		else
		{
			this.UpdateCursor();
		}
	}

	// Token: 0x06000D71 RID: 3441 RVA: 0x00131FE9 File Offset: 0x001303E9
	public void Update()
	{
		if (this.FrameTextures.Length <= 1)
		{
			this._frameIndex = 0;
		}
		else
		{
			this.CalcNextFrameIndex();
		}
		this.UpdateCursor();
	}

	// Token: 0x06000D72 RID: 3442 RVA: 0x00132014 File Offset: 0x00130414
	private void UpdateCursor()
	{
		Cursor.visible = true;
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			this.xboxCursor.enabled = !VfAnimCursor.TurnOffXbox;
		}
		if (this._frameIndex == this._prevFrameIndex)
		{
			return;
		}
		if (this.FrameTextures.Length <= 0)
		{
			return;
		}
		Texture2D texture2D = this.FrameTextures[this._frameIndex];
		if (texture2D != null)
		{
			if (this._lm != null)
			{
				this._lm.HotSpot = this.HotSpot;
				int width = texture2D.width;
				int height = texture2D.height;
				this._lm.CursorSize = new Vector2((float)width, (float)height);
			}
			if (Application.platform == RuntimePlatform.XboxOne)
			{
				this.xboxCursor.texture = texture2D;
			}
			Cursor.SetCursor(texture2D, this.HotSpot, this.CursorMode);
			this._prevFrameIndex = this._frameIndex;
		}
	}

	// Token: 0x06000D73 RID: 3443 RVA: 0x00132104 File Offset: 0x00130504
	private void CalcNextFrameIndex()
	{
		float num = 1f / this.FramesPerSecond;
		this._frameTime += Time.deltaTime;
		if (this._frameTime >= num)
		{
			this._frameIndex += this._dir;
			if (this._frameIndex >= this.FrameTextures.Length)
			{
				if (this.PingPong)
				{
					this._dir = -1;
					this._frameIndex = this.FrameTextures.Length - 2;
				}
				else
				{
					this._dir = 1;
					this._frameIndex = 0;
				}
			}
			else if (this._frameIndex < 0)
			{
				this._frameIndex = 1;
				this._dir = 1;
			}
			this._frameTime -= num;
		}
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x001321C4 File Offset: 0x001305C4
	public void CursorOff()
	{
		this.FrameTextures[0] = this.FrameTexturesStorage[1];
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			this.xboxCursor.enabled = false;
		}
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x001321EE File Offset: 0x001305EE
	public void CursorOn()
	{
		this.FrameTextures[0] = this.FrameTexturesStorage[0];
		if (Application.platform == RuntimePlatform.XboxOne)
		{
			this.xboxCursor.enabled = true;
		}
	}

	// Token: 0x04001204 RID: 4612
	public RawImage xboxCursor;

	// Token: 0x04001205 RID: 4613
	public Texture2D[] FrameTextures;

	// Token: 0x04001206 RID: 4614
	public Texture2D[] FrameTexturesStorage;

	// Token: 0x04001207 RID: 4615
	public Vector2 HotSpot = Vector2.zero;

	// Token: 0x04001208 RID: 4616
	public CursorMode CursorMode;

	// Token: 0x04001209 RID: 4617
	public float FramesPerSecond = 15f;

	// Token: 0x0400120A RID: 4618
	public bool PingPong;

	// Token: 0x0400120B RID: 4619
	public bool ResetFrameOnEnable = true;

	// Token: 0x0400120C RID: 4620
	public bool AutoSortTextures = true;

	// Token: 0x0400120D RID: 4621
	private int _frameIndex;

	// Token: 0x0400120E RID: 4622
	private int _prevFrameIndex = -1;

	// Token: 0x0400120F RID: 4623
	private float _frameTime;

	// Token: 0x04001210 RID: 4624
	private int _dir = 1;

	// Token: 0x04001211 RID: 4625
	private VfLabelManager _lm;

	// Token: 0x04001212 RID: 4626
	public static bool TurnOffXbox;
}
