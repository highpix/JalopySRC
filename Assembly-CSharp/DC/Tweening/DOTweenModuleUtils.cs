using System;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x0200001E RID: 30
	public static class DOTweenModuleUtils
	{
		// Token: 0x06000095 RID: 149 RVA: 0x00006D6D File Offset: 0x0000516D
		public static void Init()
		{
			if (DOTweenModuleUtils._initialized)
			{
				return;
			}
			DOTweenModuleUtils._initialized = true;
			if (DOTweenModuleUtils.<>f__mg$cache0 == null)
			{
				DOTweenModuleUtils.<>f__mg$cache0 = new Action<PathOptions, Tween, Quaternion, Transform>(DOTweenModuleUtils.Physics.SetOrientationOnPath);
			}
			DOTweenExternalCommand.SetOrientationOnPath += DOTweenModuleUtils.<>f__mg$cache0;
		}

		// Token: 0x0400005D RID: 93
		private static bool _initialized;

		// Token: 0x0400005E RID: 94
		[CompilerGenerated]
		private static Action<PathOptions, Tween, Quaternion, Transform> <>f__mg$cache0;

		// Token: 0x0200001F RID: 31
		public static class Physics
		{
			// Token: 0x06000096 RID: 150 RVA: 0x00006DA2 File Offset: 0x000051A2
			public static void SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans)
			{
				if (options.isRigidbody)
				{
					((Rigidbody)t.target).rotation = newRot;
				}
				else
				{
					trans.rotation = newRot;
				}
			}

			// Token: 0x06000097 RID: 151 RVA: 0x00006DCD File Offset: 0x000051CD
			public static bool HasRigidbody2D(Component target)
			{
				return target.GetComponent<Rigidbody2D>() != null;
			}

			// Token: 0x06000098 RID: 152 RVA: 0x00006DDB File Offset: 0x000051DB
			public static bool HasRigidbody(Component target)
			{
				return target.GetComponent<Rigidbody>() != null;
			}

			// Token: 0x06000099 RID: 153 RVA: 0x00006DEC File Offset: 0x000051EC
			public static TweenerCore<Vector3, Path, PathOptions> CreateDOTweenPathTween(MonoBehaviour target, bool tweenRigidbody, bool isLocal, Path path, float duration, PathMode pathMode)
			{
				Rigidbody rigidbody = (!tweenRigidbody) ? null : target.GetComponent<Rigidbody>();
				TweenerCore<Vector3, Path, PathOptions> result;
				if (tweenRigidbody && rigidbody != null)
				{
					result = ((!isLocal) ? rigidbody.DOPath(path, duration, pathMode) : rigidbody.DOLocalPath(path, duration, pathMode));
				}
				else
				{
					result = ((!isLocal) ? target.transform.DOPath(path, duration, pathMode) : target.transform.DOLocalPath(path, duration, pathMode));
				}
				return result;
			}
		}
	}
}
