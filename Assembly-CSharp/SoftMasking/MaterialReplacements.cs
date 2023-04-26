using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoftMasking
{
	// Token: 0x02000141 RID: 321
	internal class MaterialReplacements
	{
		// Token: 0x06000C98 RID: 3224 RVA: 0x0012C445 File Offset: 0x0012A845
		public MaterialReplacements(Func<Material, Material> replace, Action<Material> applyParameters)
		{
			this._replace = replace;
			this._applyParameters = applyParameters;
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x0012C468 File Offset: 0x0012A868
		public Material Get(Material original)
		{
			for (int i = 0; i < this._overrides.Count; i++)
			{
				MaterialReplacements.MaterialOverride materialOverride = this._overrides[i];
				if (object.ReferenceEquals(materialOverride.original, original))
				{
					Material material = materialOverride.Get();
					if (material)
					{
						material.CopyPropertiesFromMaterial(original);
						this._applyParameters(material);
					}
					return material;
				}
			}
			Material material2 = this._replace(original);
			if (material2)
			{
				material2.hideFlags = HideFlags.HideAndDontSave;
				this._applyParameters(material2);
			}
			this._overrides.Add(new MaterialReplacements.MaterialOverride(original, material2));
			return material2;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x0012C518 File Offset: 0x0012A918
		public void Release(Material replacement)
		{
			for (int i = 0; i < this._overrides.Count; i++)
			{
				MaterialReplacements.MaterialOverride materialOverride = this._overrides[i];
				if (materialOverride.replacement == replacement && materialOverride.Release())
				{
					UnityEngine.Object.DestroyImmediate(replacement);
					this._overrides.RemoveAt(i);
					return;
				}
			}
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x0012C580 File Offset: 0x0012A980
		public void ApplyAll()
		{
			for (int i = 0; i < this._overrides.Count; i++)
			{
				Material replacement = this._overrides[i].replacement;
				if (replacement)
				{
					this._applyParameters(replacement);
				}
			}
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x0012C5D4 File Offset: 0x0012A9D4
		public void DestroyAllAndClear()
		{
			for (int i = 0; i < this._overrides.Count; i++)
			{
				UnityEngine.Object.DestroyImmediate(this._overrides[i].replacement);
			}
			this._overrides.Clear();
		}

		// Token: 0x04001141 RID: 4417
		private Func<Material, Material> _replace;

		// Token: 0x04001142 RID: 4418
		private Action<Material> _applyParameters;

		// Token: 0x04001143 RID: 4419
		private readonly List<MaterialReplacements.MaterialOverride> _overrides = new List<MaterialReplacements.MaterialOverride>();

		// Token: 0x02000142 RID: 322
		private class MaterialOverride
		{
			// Token: 0x06000C9D RID: 3229 RVA: 0x0012C61E File Offset: 0x0012AA1E
			public MaterialOverride(Material original, Material replacement)
			{
				this.original = original;
				this.replacement = replacement;
				this._useCount = 1;
			}

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x06000C9E RID: 3230 RVA: 0x0012C63B File Offset: 0x0012AA3B
			// (set) Token: 0x06000C9F RID: 3231 RVA: 0x0012C643 File Offset: 0x0012AA43
			public Material original { get; private set; }

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x0012C64C File Offset: 0x0012AA4C
			// (set) Token: 0x06000CA1 RID: 3233 RVA: 0x0012C654 File Offset: 0x0012AA54
			public Material replacement { get; private set; }

			// Token: 0x06000CA2 RID: 3234 RVA: 0x0012C65D File Offset: 0x0012AA5D
			public Material Get()
			{
				this._useCount++;
				return this.replacement;
			}

			// Token: 0x06000CA3 RID: 3235 RVA: 0x0012C674 File Offset: 0x0012AA74
			public bool Release()
			{
				return --this._useCount == 0;
			}

			// Token: 0x04001144 RID: 4420
			private int _useCount;
		}
	}
}
