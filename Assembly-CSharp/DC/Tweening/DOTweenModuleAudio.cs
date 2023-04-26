using System;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Audio;

namespace DG.Tweening
{
	// Token: 0x02000010 RID: 16
	public static class DOTweenModuleAudio
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00004298 File Offset: 0x00002698
		public static Tweener DOFade(this AudioSource target, float endValue, float duration)
		{
			if (endValue < 0f)
			{
				endValue = 0f;
			}
			else if (endValue > 1f)
			{
				endValue = 1f;
			}
			return DOTween.To(() => target.volume, delegate(float x)
			{
				target.volume = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004308 File Offset: 0x00002708
		public static Tweener DOPitch(this AudioSource target, float endValue, float duration)
		{
			return DOTween.To(() => target.pitch, delegate(float x)
			{
				target.pitch = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000434C File Offset: 0x0000274C
		public static Tweener DOSetFloat(this AudioMixer target, string floatName, float endValue, float duration)
		{
			return DOTween.To(delegate()
			{
				float result;
				target.GetFloat(floatName, out result);
				return result;
			}, delegate(float x)
			{
				target.SetFloat(floatName, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004397 File Offset: 0x00002797
		public static int DOComplete(this AudioMixer target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000043A0 File Offset: 0x000027A0
		public static int DOKill(this AudioMixer target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000043A9 File Offset: 0x000027A9
		public static int DOFlip(this AudioMixer target)
		{
			return DOTween.Flip(target);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000043B1 File Offset: 0x000027B1
		public static int DOGoto(this AudioMixer target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000043BB File Offset: 0x000027BB
		public static int DOPause(this AudioMixer target)
		{
			return DOTween.Pause(target);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000043C3 File Offset: 0x000027C3
		public static int DOPlay(this AudioMixer target)
		{
			return DOTween.Play(target);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000043CB File Offset: 0x000027CB
		public static int DOPlayBackwards(this AudioMixer target)
		{
			return DOTween.PlayBackwards(target);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000043D3 File Offset: 0x000027D3
		public static int DOPlayForward(this AudioMixer target)
		{
			return DOTween.PlayForward(target);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000043DB File Offset: 0x000027DB
		public static int DORestart(this AudioMixer target)
		{
			return DOTween.Restart(target, true, -1f);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000043E9 File Offset: 0x000027E9
		public static int DORewind(this AudioMixer target)
		{
			return DOTween.Rewind(target, true);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000043F2 File Offset: 0x000027F2
		public static int DOSmoothRewind(this AudioMixer target)
		{
			return DOTween.SmoothRewind(target);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000043FA File Offset: 0x000027FA
		public static int DOTogglePause(this AudioMixer target)
		{
			return DOTween.TogglePause(target);
		}
	}
}
