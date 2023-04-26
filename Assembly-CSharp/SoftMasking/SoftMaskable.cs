using System;
using SoftMasking.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SoftMasking
{
	// Token: 0x0200014B RID: 331
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("")]
	public class SoftMaskable : UIBehaviour, IMaterialModifier
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000D0B RID: 3339 RVA: 0x0012DDAD File Offset: 0x0012C1AD
		// (set) Token: 0x06000D0C RID: 3340 RVA: 0x0012DDB5 File Offset: 0x0012C1B5
		public bool shaderIsNotSupported { get; private set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000D0D RID: 3341 RVA: 0x0012DDBE File Offset: 0x0012C1BE
		public bool isMaskingEnabled
		{
			get
			{
				return this.mask != null && this.mask.isAlive && this.mask.isMaskingEnabled;
			}
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0012DDEC File Offset: 0x0012C1EC
		public Material GetModifiedMaterial(Material baseMaterial)
		{
			if (this.isMaskingEnabled)
			{
				Material replacement = this.mask.GetReplacement(baseMaterial);
				this.replacement = replacement;
				if (this.replacement)
				{
					this.shaderIsNotSupported = false;
					return this.replacement;
				}
				if (!baseMaterial.HasDefaultUIShader())
				{
					this.SetShaderNotSupported(baseMaterial);
				}
			}
			else
			{
				this.shaderIsNotSupported = false;
				this.replacement = null;
			}
			return baseMaterial;
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0012DE5C File Offset: 0x0012C25C
		public void Invalidate()
		{
			if (this.graphic)
			{
				this.graphic.SetMaterialDirty();
			}
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0012DE79 File Offset: 0x0012C279
		public void MaskMightChanged()
		{
			if (this.FindMaskOrDie())
			{
				this.Invalidate();
			}
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0012DE8C File Offset: 0x0012C28C
		protected override void Awake()
		{
			base.Awake();
			base.hideFlags = HideFlags.HideInInspector;
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x0012DE9B File Offset: 0x0012C29B
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.FindMaskOrDie())
			{
				this.NotifyChildrenChanged();
			}
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x0012DEB4 File Offset: 0x0012C2B4
		protected override void OnDisable()
		{
			base.OnDisable();
			this.mask = null;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0012DEC3 File Offset: 0x0012C2C3
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._destroyed = true;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0012DED2 File Offset: 0x0012C2D2
		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			this.FindMaskOrDie();
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x0012DEE1 File Offset: 0x0012C2E1
		private void OnTransformChildrenChanged()
		{
			this.NotifyChildrenChanged();
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x0012DEE9 File Offset: 0x0012C2E9
		private void NotifyChildrenChanged()
		{
			if (this.mask != null)
			{
				this.mask.UpdateTransformChildren(base.transform);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x0012DF08 File Offset: 0x0012C308
		private Graphic graphic
		{
			get
			{
				Graphic result;
				if ((result = this._graphic) == null)
				{
					result = (this._graphic = base.GetComponent<Graphic>());
				}
				return result;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000D19 RID: 3353 RVA: 0x0012DF31 File Offset: 0x0012C331
		// (set) Token: 0x06000D1A RID: 3354 RVA: 0x0012DF3C File Offset: 0x0012C33C
		private Material replacement
		{
			get
			{
				return this._replacement;
			}
			set
			{
				if (this._replacement != value)
				{
					if (this._replacement != null && this.mask != null)
					{
						this.mask.ReleaseReplacement(this._replacement);
					}
					this._replacement = value;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x0012DF8E File Offset: 0x0012C38E
		// (set) Token: 0x06000D1C RID: 3356 RVA: 0x0012DF98 File Offset: 0x0012C398
		private ISoftMask mask
		{
			get
			{
				return this._mask;
			}
			set
			{
				if (this._mask != value)
				{
					if (this._mask != null)
					{
						this.replacement = null;
					}
					this._mask = ((value == null || !value.isAlive) ? null : value);
					this.Invalidate();
				}
			}
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0012DFE8 File Offset: 0x0012C3E8
		private bool FindMaskOrDie()
		{
			if (this._destroyed)
			{
				return false;
			}
			this.mask = SoftMaskable.NearestMask(base.transform.parent, true);
			if (this.mask == null)
			{
				this.mask = SoftMaskable.NearestMask(base.transform.parent, false);
			}
			if (this.mask == null)
			{
				this._destroyed = true;
				UnityEngine.Object.DestroyImmediate(this);
				return false;
			}
			return true;
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x0012E058 File Offset: 0x0012C458
		private static ISoftMask NearestMask(Transform transform, bool enabledOnly = true)
		{
			if (!transform)
			{
				return null;
			}
			ISoftMask component = transform.GetComponent<ISoftMask>();
			if (component != null && component.isAlive && (!enabledOnly || component.isMaskingEnabled))
			{
				return component;
			}
			return SoftMaskable.NearestMask(transform.parent, enabledOnly);
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0012E0A9 File Offset: 0x0012C4A9
		private void SetShaderNotSupported(Material material)
		{
			if (!this.shaderIsNotSupported)
			{
				Debug.LogWarningFormat(base.gameObject, "SoftMask will not work on {0} because material {1} doesn't support masking. Add masking support to your material or set Graphic's material to None to use a default one.", new object[]
				{
					this.graphic,
					material
				});
				this.shaderIsNotSupported = true;
			}
		}

		// Token: 0x04001183 RID: 4483
		private ISoftMask _mask;

		// Token: 0x04001184 RID: 4484
		private Graphic _graphic;

		// Token: 0x04001185 RID: 4485
		private Material _replacement;

		// Token: 0x04001186 RID: 4486
		private bool _destroyed;
	}
}
