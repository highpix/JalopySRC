using System;
using UnityEngine;

namespace SoftMasking
{
	// Token: 0x0200013F RID: 319
	public interface ISoftMask
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000C8F RID: 3215
		bool isAlive { get; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000C90 RID: 3216
		bool isMaskingEnabled { get; }

		// Token: 0x06000C91 RID: 3217
		Material GetReplacement(Material original);

		// Token: 0x06000C92 RID: 3218
		void ReleaseReplacement(Material replacement);

		// Token: 0x06000C93 RID: 3219
		void UpdateTransformChildren(Transform transform);
	}
}
