using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000027 RID: 39
public class UploadDownloadTexture : MonoBehaviour
{
	// Token: 0x060000C4 RID: 196 RVA: 0x00007EF0 File Offset: 0x000062F0
	private void Start()
	{
		if (this.mode == UploadDownloadTexture.Mode.Upload)
		{
			Texture2D texture = this.GetTexture();
			if (texture == null)
			{
				Debug.LogError("There is no texture attached to this object.");
			}
			else
			{
				base.StartCoroutine(this.Upload(texture));
			}
		}
		else
		{
			base.StartCoroutine(this.Download());
		}
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00007F4C File Offset: 0x0000634C
	private IEnumerator Upload(Texture2D texture)
	{
		ES2Web web = new ES2Web(this.url, this.CreateSettings());
		yield return base.StartCoroutine(web.Upload<Texture2D>(texture));
		if (web.isError)
		{
			Debug.LogError(web.errorCode + ":" + web.error);
		}
		else
		{
			Debug.Log("Uploaded Successfully. Reload scene to load texture into blank object.");
		}
		yield break;
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00007F70 File Offset: 0x00006370
	private IEnumerator Download()
	{
		ES2Web web = new ES2Web(this.url, this.CreateSettings());
		yield return base.StartCoroutine(web.Download());
		if (!web.isError)
		{
			this.SetTexture(web.Load<Texture2D>(this.textureTag));
			yield return base.StartCoroutine(this.Delete());
			Debug.Log("Texture successfully downloaded and applied to blank object.");
			yield break;
		}
		if (web.errorCode == "05")
		{
			yield break;
		}
		Debug.LogError(web.errorCode + ":" + web.error);
		yield break;
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00007F8C File Offset: 0x0000638C
	private IEnumerator Delete()
	{
		ES2Web web = new ES2Web(this.url, this.CreateSettings());
		yield return base.StartCoroutine(web.Delete());
		if (web.isError)
		{
			Debug.LogError(web.errorCode + ":" + web.error);
		}
		yield break;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00007FA8 File Offset: 0x000063A8
	private ES2Settings CreateSettings()
	{
		return new ES2Settings
		{
			webFilename = this.filename,
			tag = this.textureTag,
			webUsername = this.webUsername,
			webPassword = this.webPassword
		};
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00007FEC File Offset: 0x000063EC
	private Texture2D GetTexture()
	{
		Renderer component = base.GetComponent<Renderer>();
		if (component.material != null && component.material.mainTexture != null)
		{
			return component.material.mainTexture as Texture2D;
		}
		return null;
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000803C File Offset: 0x0000643C
	private void SetTexture(Texture2D texture)
	{
		Renderer component = base.GetComponent<Renderer>();
		if (component.material != null)
		{
			component.material.mainTexture = texture;
		}
		else
		{
			Debug.LogError("There is no material attached to this object.");
		}
	}

	// Token: 0x0400006E RID: 110
	public UploadDownloadTexture.Mode mode;

	// Token: 0x0400006F RID: 111
	public string url = "http://www.server.com/ES2.php";

	// Token: 0x04000070 RID: 112
	public string filename = "textureFile.txt";

	// Token: 0x04000071 RID: 113
	public string textureTag = "textureTag";

	// Token: 0x04000072 RID: 114
	public string webUsername = "ES2";

	// Token: 0x04000073 RID: 115
	public string webPassword = "65w84e4p994z3Oq";

	// Token: 0x02000028 RID: 40
	public enum Mode
	{
		// Token: 0x04000075 RID: 117
		Upload,
		// Token: 0x04000076 RID: 118
		Download
	}
}
