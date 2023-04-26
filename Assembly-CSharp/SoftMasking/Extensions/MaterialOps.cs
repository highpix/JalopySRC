using System;
using UnityEngine;

namespace SoftMasking.Extensions
{
	// Token: 0x02000140 RID: 320
	public static class MaterialOps
	{
		// Token: 0x06000C94 RID: 3220 RVA: 0x0012C3EF File Offset: 0x0012A7EF
		public static bool SupportsSoftMask(this Material mat)
		{
			return mat.HasProperty("_SoftMask");
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x0012C3FC File Offset: 0x0012A7FC
		public static bool HasDefaultUIShader(this Material mat)
		{
			return mat.shader == Canvas.GetDefaultCanvasMaterial().shader;
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x0012C413 File Offset: 0x0012A813
		public static bool HasDefaultETC1UIShader(this Material mat)
		{
			return mat.shader == Canvas.GetETC1SupportedCanvasMaterial().shader;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x0012C42A File Offset: 0x0012A82A
		public static void EnableKeyword(this Material mat, string keyword, bool enabled)
		{
			if (enabled)
			{
				mat.EnableKeyword(keyword);
			}
			else
			{
				mat.DisableKeyword(keyword);
			}
		}
	}
}
