using System;
using System.Collections.Generic;
using System.Linq;
using SoftMasking.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SoftMasking
{
	// Token: 0x02000144 RID: 324
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/Soft Mask", 14)]
	[RequireComponent(typeof(RectTransform))]
	[HelpURL("https://docs.google.com/document/d/1BiPeOjypiEsxyls-yc6MwWCjTk4CyyVVTpm2ugyhbEo")]
	public class SoftMask : UIBehaviour, ICanvasRaycastFilter, ISoftMask
	{
		// Token: 0x06000CA5 RID: 3237 RVA: 0x0012C748 File Offset: 0x0012AB48
		public SoftMask()
		{
			this._materials = new MaterialReplacements(new Func<Material, Material>(this.Replace), delegate(Material m)
			{
				this._parameters.Apply(m);
			});
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x0012C794 File Offset: 0x0012AB94
		// (set) Token: 0x06000CA7 RID: 3239 RVA: 0x0012C79C File Offset: 0x0012AB9C
		public Shader defaultShader
		{
			get
			{
				return this._defaultShader;
			}
			set
			{
				this.SetShader(ref this._defaultShader, value, true);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x0012C7AC File Offset: 0x0012ABAC
		// (set) Token: 0x06000CA9 RID: 3241 RVA: 0x0012C7B4 File Offset: 0x0012ABB4
		public Shader defaultETC1Shader
		{
			get
			{
				return this._defaultETC1Shader;
			}
			set
			{
				this.SetShader(ref this._defaultETC1Shader, value, false);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x0012C7C4 File Offset: 0x0012ABC4
		// (set) Token: 0x06000CAB RID: 3243 RVA: 0x0012C7CC File Offset: 0x0012ABCC
		public SoftMask.MaskSource source
		{
			get
			{
				return this._source;
			}
			set
			{
				if (this._source != value)
				{
					this.Set<SoftMask.MaskSource>(ref this._source, value);
				}
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x0012C7E7 File Offset: 0x0012ABE7
		// (set) Token: 0x06000CAD RID: 3245 RVA: 0x0012C7EF File Offset: 0x0012ABEF
		public RectTransform separateMask
		{
			get
			{
				return this._separateMask;
			}
			set
			{
				if (this._separateMask != value)
				{
					this.Set<RectTransform>(ref this._separateMask, value);
					this._graphic = null;
					this._maskTransform = null;
				}
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x0012C81D File Offset: 0x0012AC1D
		// (set) Token: 0x06000CAF RID: 3247 RVA: 0x0012C825 File Offset: 0x0012AC25
		public Sprite sprite
		{
			get
			{
				return this._sprite;
			}
			set
			{
				if (this._sprite != value)
				{
					this.Set<Sprite>(ref this._sprite, value);
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x0012C845 File Offset: 0x0012AC45
		// (set) Token: 0x06000CB1 RID: 3249 RVA: 0x0012C84D File Offset: 0x0012AC4D
		public SoftMask.BorderMode spriteBorderMode
		{
			get
			{
				return this._spriteBorderMode;
			}
			set
			{
				if (this._spriteBorderMode != value)
				{
					this.Set<SoftMask.BorderMode>(ref this._spriteBorderMode, value);
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x0012C868 File Offset: 0x0012AC68
		// (set) Token: 0x06000CB3 RID: 3251 RVA: 0x0012C870 File Offset: 0x0012AC70
		public Texture2D texture
		{
			get
			{
				return this._texture;
			}
			set
			{
				if (this._texture != value)
				{
					this.Set<Texture2D>(ref this._texture, value);
				}
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x0012C890 File Offset: 0x0012AC90
		// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x0012C898 File Offset: 0x0012AC98
		public Rect textureUVRect
		{
			get
			{
				return this._textureUVRect;
			}
			set
			{
				if (this._textureUVRect != value)
				{
					this.Set<Rect>(ref this._textureUVRect, value);
				}
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x0012C8B8 File Offset: 0x0012ACB8
		// (set) Token: 0x06000CB7 RID: 3255 RVA: 0x0012C8C0 File Offset: 0x0012ACC0
		public Color channelWeights
		{
			get
			{
				return this._channelWeights;
			}
			set
			{
				if (this._channelWeights != value)
				{
					this.Set<Color>(ref this._channelWeights, value);
				}
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000CB8 RID: 3256 RVA: 0x0012C8E0 File Offset: 0x0012ACE0
		// (set) Token: 0x06000CB9 RID: 3257 RVA: 0x0012C8E8 File Offset: 0x0012ACE8
		public float raycastThreshold
		{
			get
			{
				return this._raycastThreshold;
			}
			set
			{
				this._raycastThreshold = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000CBA RID: 3258 RVA: 0x0012C8F1 File Offset: 0x0012ACF1
		public bool isMaskingEnabled
		{
			get
			{
				return base.isActiveAndEnabled && this.canvas;
			}
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x0012C90C File Offset: 0x0012AD0C
		public SoftMask.Errors PollErrors()
		{
			SoftMask.Errors errors = SoftMask.Errors.NoError;
			base.GetComponentsInChildren<SoftMaskable>(SoftMask._s_maskables);
			if (SoftMask._s_maskables.Any((SoftMaskable m) => m.shaderIsNotSupported))
			{
				errors |= SoftMask.Errors.UnsupportedShaders;
			}
			if (this.ThereAreNestedMasks())
			{
				errors |= SoftMask.Errors.NestedMasks;
			}
			errors |= SoftMask.CheckSprite(this.activeSprite);
			return errors | this.CheckImage();
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0012C980 File Offset: 0x0012AD80
		public bool IsRaycastLocationValid(Vector2 sp, Camera cam)
		{
			Vector2 vector;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.maskTransform, sp, cam, out vector))
			{
				return false;
			}
			if (!SoftMask.Mathr.Inside(vector, this.LocalMaskRect(Vector4.zero)))
			{
				return false;
			}
			if (!this._parameters.texture)
			{
				return true;
			}
			if (this._raycastThreshold <= 0f)
			{
				return true;
			}
			float num;
			if (!this._parameters.SampleMask(vector, out num))
			{
				Debug.LogError("raycastThreshold greater than 0 can't be used on SoftMask whose texture cannot be read.", this);
				return true;
			}
			return num >= this._raycastThreshold;
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0012CA10 File Offset: 0x0012AE10
		protected override void Start()
		{
			base.Start();
			this.WarnIfDefaultShaderIsNotSet();
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0012CA1E File Offset: 0x0012AE1E
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.DisableIfThereAreNestedMasks())
			{
				return;
			}
			this.SpawnMaskablesInChildren(base.transform);
			this.FindGraphic();
			if (this.isMaskingEnabled)
			{
				this.UpdateMask();
			}
			this.NotifyChildrenThatMaskMightChanged();
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0012CA5C File Offset: 0x0012AE5C
		protected override void OnDisable()
		{
			base.OnDisable();
			if (this._graphic)
			{
				this._graphic.UnregisterDirtyVerticesCallback(new UnityAction(this.OnGraphicDirty));
				this._graphic.UnregisterDirtyMaterialCallback(new UnityAction(this.OnGraphicDirty));
				this._graphic = null;
			}
			this.NotifyChildrenThatMaskMightChanged();
			this.DestroyMaterials();
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0012CAC0 File Offset: 0x0012AEC0
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._destroyed = true;
			this.NotifyChildrenThatMaskMightChanged();
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0012CAD8 File Offset: 0x0012AED8
		protected virtual void LateUpdate()
		{
			bool isMaskingEnabled = this.isMaskingEnabled;
			if (isMaskingEnabled)
			{
				if (this._maskingWasEnabled != isMaskingEnabled)
				{
					this.SpawnMaskablesInChildren(base.transform);
				}
				Graphic graphic = this._graphic;
				this.FindGraphic();
				if (this.maskTransform.hasChanged || this._dirty || !object.ReferenceEquals(this._graphic, graphic))
				{
					this.UpdateMask();
				}
			}
			this._maskingWasEnabled = isMaskingEnabled;
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0012CB50 File Offset: 0x0012AF50
		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			this._dirty = true;
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0012CB5F File Offset: 0x0012AF5F
		protected override void OnDidApplyAnimationProperties()
		{
			base.OnDidApplyAnimationProperties();
			this._dirty = true;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x0012CB6E File Offset: 0x0012AF6E
		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			this.DisableIfThereAreNestedMasks();
			this._canvas = null;
			this._dirty = true;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x0012CB8B File Offset: 0x0012AF8B
		protected override void OnCanvasHierarchyChanged()
		{
			base.OnCanvasHierarchyChanged();
			this._canvas = null;
			this._dirty = true;
			this.NotifyChildrenThatMaskMightChanged();
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0012CBA7 File Offset: 0x0012AFA7
		private void OnTransformChildrenChanged()
		{
			this.SpawnMaskablesInChildren(base.transform);
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0012CBB8 File Offset: 0x0012AFB8
		private RectTransform maskTransform
		{
			get
			{
				RectTransform result;
				if ((result = this._maskTransform) == null)
				{
					result = (this._maskTransform = ((!this._separateMask) ? base.GetComponent<RectTransform>() : this._separateMask));
				}
				return result;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x0012CBFC File Offset: 0x0012AFFC
		private Canvas canvas
		{
			get
			{
				Canvas result;
				if ((result = this._canvas) == null)
				{
					result = (this._canvas = this.NearestEnabledCanvas());
				}
				return result;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x0012CC25 File Offset: 0x0012B025
		private bool isBasedOnGraphic
		{
			get
			{
				return this._source == SoftMask.MaskSource.Graphic;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x0012CC30 File Offset: 0x0012B030
		private Sprite activeSprite
		{
			get
			{
				SoftMask.MaskSource source = this.source;
				if (source == SoftMask.MaskSource.Sprite)
				{
					return this._sprite;
				}
				if (source != SoftMask.MaskSource.Graphic)
				{
					return null;
				}
				Image image = this._graphic as Image;
				return (!image) ? null : image.sprite;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x0012CC82 File Offset: 0x0012B082
		bool ISoftMask.isAlive
		{
			get
			{
				return this && !this._destroyed;
			}
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x0012CC9B File Offset: 0x0012B09B
		Material ISoftMask.GetReplacement(Material original)
		{
			return this._materials.Get(original);
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x0012CCA9 File Offset: 0x0012B0A9
		void ISoftMask.ReleaseReplacement(Material replacement)
		{
			this._materials.Release(replacement);
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x0012CCB7 File Offset: 0x0012B0B7
		void ISoftMask.UpdateTransformChildren(Transform transform)
		{
			this.SpawnMaskablesInChildren(transform);
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x0012CCC0 File Offset: 0x0012B0C0
		private void OnGraphicDirty()
		{
			if (this.isBasedOnGraphic)
			{
				this._dirty = true;
			}
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x0012CCD4 File Offset: 0x0012B0D4
		private void FindGraphic()
		{
			if (!this._graphic)
			{
				this._graphic = this.maskTransform.GetComponent<Graphic>();
				if (this._graphic)
				{
					this._graphic.RegisterDirtyVerticesCallback(new UnityAction(this.OnGraphicDirty));
					this._graphic.RegisterDirtyMaterialCallback(new UnityAction(this.OnGraphicDirty));
				}
			}
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x0012CD40 File Offset: 0x0012B140
		private Canvas NearestEnabledCanvas()
		{
			Canvas[] componentsInParent = base.GetComponentsInParent<Canvas>(false);
			for (int i = 0; i < componentsInParent.Length; i++)
			{
				if (componentsInParent[i].isActiveAndEnabled)
				{
					return componentsInParent[i];
				}
			}
			return null;
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x0012CD7B File Offset: 0x0012B17B
		private void UpdateMask()
		{
			this.CalculateMaskParameters();
			this._materials.ApplyAll();
			this.maskTransform.hasChanged = false;
			this._dirty = false;
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x0012CDA4 File Offset: 0x0012B1A4
		private void SpawnMaskablesInChildren(Transform root)
		{
			for (int i = 0; i < root.childCount; i++)
			{
				Transform child = root.GetChild(i);
				if (!child.GetComponent<SoftMaskable>())
				{
					child.gameObject.AddComponent<SoftMaskable>();
				}
			}
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x0012CDEC File Offset: 0x0012B1EC
		private void InvalidateChildren()
		{
			base.transform.GetComponentsInChildren<SoftMaskable>(SoftMask._s_maskables);
			for (int i = 0; i < SoftMask._s_maskables.Count; i++)
			{
				SoftMaskable softMaskable = SoftMask._s_maskables[i];
				if (softMaskable)
				{
					softMaskable.Invalidate();
				}
			}
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x0012CE44 File Offset: 0x0012B244
		private void NotifyChildrenThatMaskMightChanged()
		{
			base.transform.GetComponentsInChildren<SoftMaskable>(SoftMask._s_maskables);
			for (int i = 0; i < SoftMask._s_maskables.Count; i++)
			{
				SoftMaskable softMaskable = SoftMask._s_maskables[i];
				if (softMaskable)
				{
					softMaskable.MaskMightChanged();
				}
			}
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x0012CE99 File Offset: 0x0012B299
		private void DestroyMaterials()
		{
			this._materials.DestroyAllAndClear();
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x0012CEA8 File Offset: 0x0012B2A8
		private Material Replace(Material original)
		{
			if (original == null || original.HasDefaultUIShader())
			{
				return SoftMask.Replace(original, this._defaultShader);
			}
			if (original.HasDefaultETC1UIShader())
			{
				return SoftMask.Replace(original, this._defaultETC1Shader);
			}
			if (original.SupportsSoftMask())
			{
				return new Material(original);
			}
			return null;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x0012CF04 File Offset: 0x0012B304
		private static Material Replace(Material original, Shader defaultReplacementShader)
		{
			Material material = (!defaultReplacementShader) ? null : new Material(defaultReplacementShader);
			if (material && original)
			{
				material.CopyPropertiesFromMaterial(original);
			}
			return material;
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x0012CF48 File Offset: 0x0012B348
		private void CalculateMaskParameters()
		{
			switch (this._source)
			{
			case SoftMask.MaskSource.Graphic:
				if (this._graphic is Image)
				{
					this.CalculateImageBased((Image)this._graphic);
				}
				else if (this._graphic is RawImage)
				{
					this.CalculateRawImageBased((RawImage)this._graphic);
				}
				else
				{
					this.CalculateSolidFill();
				}
				break;
			case SoftMask.MaskSource.Sprite:
				this.CalculateSpriteBased(this._sprite, this._spriteBorderMode);
				break;
			case SoftMask.MaskSource.Texture:
				this.CalculateTextureBased(this._texture, this._textureUVRect);
				break;
			default:
				Debug.LogErrorFormat("Unknown MaskSource: {0}", new object[]
				{
					this._source
				});
				this.CalculateSolidFill();
				break;
			}
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x0012D021 File Offset: 0x0012B421
		private SoftMask.BorderMode ToBorderMode(Image.Type imageType)
		{
			switch (imageType)
			{
			case Image.Type.Simple:
				return SoftMask.BorderMode.Simple;
			case Image.Type.Sliced:
				return SoftMask.BorderMode.Sliced;
			case Image.Type.Tiled:
				return SoftMask.BorderMode.Tiled;
			default:
				Debug.LogErrorFormat("SoftMask doesn't support image type {0}. Image type Simple will be used.", new object[]
				{
					imageType
				});
				return SoftMask.BorderMode.Simple;
			}
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0012D05A File Offset: 0x0012B45A
		private void CalculateImageBased(Image image)
		{
			this.CalculateSpriteBased(image.sprite, this.ToBorderMode(image.type));
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0012D074 File Offset: 0x0012B474
		private void CalculateRawImageBased(RawImage image)
		{
			this.CalculateTextureBased(image.texture as Texture2D, image.uvRect);
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x0012D090 File Offset: 0x0012B490
		private void CalculateSpriteBased(Sprite sprite, SoftMask.BorderMode borderMode)
		{
			Sprite lastUsedSprite = this._lastUsedSprite;
			this._lastUsedSprite = sprite;
			SoftMask.Errors errors = SoftMask.CheckSprite(sprite);
			if (errors != SoftMask.Errors.NoError)
			{
				if (lastUsedSprite != sprite)
				{
					this.WarnSpriteErrors(errors);
				}
				this.CalculateSolidFill();
				return;
			}
			if (!sprite)
			{
				this.CalculateSolidFill();
				return;
			}
			this.FillCommonParameters();
			Vector4 vector = SoftMask.Mathr.Move(SoftMask.Mathr.ToVector(sprite.rect), sprite.textureRect.position - sprite.rect.position - sprite.textureRectOffset);
			Vector4 vector2 = SoftMask.Mathr.ToVector(sprite.textureRect);
			Vector4 vector3 = SoftMask.Mathr.BorderOf(vector, vector2);
			Vector2 s = new Vector2((float)sprite.texture.width, (float)sprite.texture.height);
			Vector4 vector4 = this.LocalMaskRect(Vector4.zero);
			this._parameters.maskRectUV = SoftMask.Mathr.Div(vector2, s);
			if (borderMode == SoftMask.BorderMode.Simple)
			{
				Vector4 v = SoftMask.Mathr.Div(vector3, SoftMask.Mathr.Size(vector));
				this._parameters.maskRect = SoftMask.Mathr.ApplyBorder(vector4, SoftMask.Mathr.Mul(v, SoftMask.Mathr.Size(vector4)));
			}
			else
			{
				this._parameters.maskRect = SoftMask.Mathr.ApplyBorder(vector4, vector3 * this.GraphicToCanvas(sprite));
				Vector4 v2 = SoftMask.Mathr.Div(vector, s);
				Vector4 border = SoftMask.AdjustBorders(sprite.border * this.GraphicToCanvas(sprite), vector4);
				this._parameters.maskBorder = this.LocalMaskRect(border);
				this._parameters.maskBorderUV = SoftMask.Mathr.ApplyBorder(v2, SoftMask.Mathr.Div(sprite.border, s));
			}
			this._parameters.texture = sprite.texture;
			this._parameters.borderMode = borderMode;
			if (borderMode == SoftMask.BorderMode.Tiled)
			{
				this._parameters.tileRepeat = this.MaskRepeat(sprite, this._parameters.maskBorder);
			}
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0012D274 File Offset: 0x0012B674
		private static Vector4 AdjustBorders(Vector4 border, Vector4 rect)
		{
			Vector2 vector = SoftMask.Mathr.Size(rect);
			for (int i = 0; i <= 1; i++)
			{
				float num = border[i] + border[i + 2];
				if (vector[i] < num && num != 0f)
				{
					float num2 = vector[i] / num;
					ref Vector4 ptr = ref border;
					int index;
					border[index = i] = ptr[index] * num2;
					ptr = ref border;
					int index2;
					border[index2 = i + 2] = ptr[index2] * num2;
				}
			}
			return border;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0012D308 File Offset: 0x0012B708
		private void CalculateTextureBased(Texture2D texture, Rect uvRect)
		{
			this.FillCommonParameters();
			this._parameters.maskRect = this.LocalMaskRect(Vector4.zero);
			this._parameters.maskRectUV = SoftMask.Mathr.ToVector(uvRect);
			this._parameters.texture = texture;
			this._parameters.borderMode = SoftMask.BorderMode.Simple;
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x0012D35A File Offset: 0x0012B75A
		private void CalculateSolidFill()
		{
			this.CalculateTextureBased(null, SoftMask.DefaultUVRect);
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0012D368 File Offset: 0x0012B768
		private void FillCommonParameters()
		{
			this._parameters.worldToMask = this.WorldToMask();
			this._parameters.maskChannelWeights = this._channelWeights;
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x0012D38C File Offset: 0x0012B78C
		private float GraphicToCanvas(Sprite sprite)
		{
			float num = (!this.canvas) ? 100f : this.canvas.referencePixelsPerUnit;
			float num2 = (!sprite) ? 100f : sprite.pixelsPerUnit;
			return num / num2;
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0012D3DE File Offset: 0x0012B7DE
		private Matrix4x4 WorldToMask()
		{
			return this.maskTransform.worldToLocalMatrix * this.canvas.rootCanvas.transform.localToWorldMatrix;
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x0012D405 File Offset: 0x0012B805
		private Vector4 LocalMaskRect(Vector4 border)
		{
			return SoftMask.Mathr.ApplyBorder(SoftMask.Mathr.ToVector(this.maskTransform.rect), border);
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x0012D420 File Offset: 0x0012B820
		private Vector2 MaskRepeat(Sprite sprite, Vector4 centralPart)
		{
			Vector4 r = SoftMask.Mathr.ApplyBorder(SoftMask.Mathr.ToVector(sprite.textureRect), sprite.border);
			return SoftMask.Mathr.Div(SoftMask.Mathr.Size(centralPart) * this.GraphicToCanvas(sprite), SoftMask.Mathr.Size(r));
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x0012D461 File Offset: 0x0012B861
		private bool DisableIfThereAreNestedMasks()
		{
			if (this.ThereAreNestedMasks())
			{
				base.enabled = false;
				Debug.LogError("SoftMask is disabled because there are nested masks, which is not supported", this);
				return true;
			}
			return false;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0012D483 File Offset: 0x0012B883
		private void WarnIfDefaultShaderIsNotSet()
		{
			if (!this._defaultShader)
			{
				Debug.LogWarning("SoftMask may not work because its defaultShader is not set", this);
			}
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x0012D4A0 File Offset: 0x0012B8A0
		private void WarnSpriteErrors(SoftMask.Errors errors)
		{
			if ((errors & SoftMask.Errors.TightPackedSprite) != SoftMask.Errors.NoError)
			{
				Debug.LogError("SoftMask doesn't support tight packed sprites", this);
			}
			if ((errors & SoftMask.Errors.AlphaSplitSprite) != SoftMask.Errors.NoError)
			{
				Debug.LogError("SoftMask doesn't support sprites with an alpha split texture", this);
			}
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x0012D4C8 File Offset: 0x0012B8C8
		private bool ThereAreNestedMasks()
		{
			bool flag = false;
			Func<SoftMask, bool> predicate = (SoftMask m) => m != this && m.isMaskingEnabled;
			base.GetComponentsInParent<SoftMask>(false, SoftMask._s_masks);
			flag |= SoftMask._s_masks.Any(predicate);
			base.GetComponentsInChildren<SoftMask>(false, SoftMask._s_masks);
			return flag | SoftMask._s_masks.Any(predicate);
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0012D519 File Offset: 0x0012B919
		private void Set<T>(ref T field, T value)
		{
			field = value;
			this._dirty = true;
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x0012D529 File Offset: 0x0012B929
		private void SetShader(ref Shader field, Shader value, bool warnIfNotSet = true)
		{
			if (field != value)
			{
				field = value;
				if (warnIfNotSet)
				{
					this.WarnIfDefaultShaderIsNotSet();
				}
				this.DestroyMaterials();
				this.InvalidateChildren();
			}
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0012D554 File Offset: 0x0012B954
		private SoftMask.Errors CheckImage()
		{
			SoftMask.Errors errors = SoftMask.Errors.NoError;
			if (!this.isBasedOnGraphic)
			{
				return errors;
			}
			Image image = this._graphic as Image;
			if (image && image.type == Image.Type.Filled)
			{
				errors |= SoftMask.Errors.UnsupportedImageType;
			}
			return errors;
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0012D59C File Offset: 0x0012B99C
		private static SoftMask.Errors CheckSprite(Sprite sprite)
		{
			SoftMask.Errors errors = SoftMask.Errors.NoError;
			if (!sprite)
			{
				return errors;
			}
			if (sprite.packed && sprite.packingMode == SpritePackingMode.Tight)
			{
				errors |= SoftMask.Errors.TightPackedSprite;
			}
			if (sprite.associatedAlphaSplitTexture)
			{
				errors |= SoftMask.Errors.AlphaSplitSprite;
			}
			return errors;
		}

		// Token: 0x0400114C RID: 4428
		[SerializeField]
		private Shader _defaultShader;

		// Token: 0x0400114D RID: 4429
		[SerializeField]
		private Shader _defaultETC1Shader;

		// Token: 0x0400114E RID: 4430
		[SerializeField]
		private SoftMask.MaskSource _source;

		// Token: 0x0400114F RID: 4431
		[SerializeField]
		private RectTransform _separateMask;

		// Token: 0x04001150 RID: 4432
		[SerializeField]
		private Sprite _sprite;

		// Token: 0x04001151 RID: 4433
		[SerializeField]
		private SoftMask.BorderMode _spriteBorderMode;

		// Token: 0x04001152 RID: 4434
		[SerializeField]
		private Texture2D _texture;

		// Token: 0x04001153 RID: 4435
		[SerializeField]
		private Rect _textureUVRect = SoftMask.DefaultUVRect;

		// Token: 0x04001154 RID: 4436
		[SerializeField]
		private Color _channelWeights = MaskChannel.alpha;

		// Token: 0x04001155 RID: 4437
		[SerializeField]
		private float _raycastThreshold;

		// Token: 0x04001156 RID: 4438
		private MaterialReplacements _materials;

		// Token: 0x04001157 RID: 4439
		private SoftMask.MaterialParameters _parameters;

		// Token: 0x04001158 RID: 4440
		private Sprite _lastUsedSprite;

		// Token: 0x04001159 RID: 4441
		private bool _maskingWasEnabled;

		// Token: 0x0400115A RID: 4442
		private bool _destroyed;

		// Token: 0x0400115B RID: 4443
		private bool _dirty;

		// Token: 0x0400115C RID: 4444
		private RectTransform _maskTransform;

		// Token: 0x0400115D RID: 4445
		private Graphic _graphic;

		// Token: 0x0400115E RID: 4446
		private Canvas _canvas;

		// Token: 0x0400115F RID: 4447
		private static readonly Rect DefaultUVRect = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x04001160 RID: 4448
		private static readonly List<SoftMask> _s_masks = new List<SoftMask>();

		// Token: 0x04001161 RID: 4449
		private static readonly List<SoftMaskable> _s_maskables = new List<SoftMaskable>();

		// Token: 0x02000145 RID: 325
		[Serializable]
		public enum MaskSource
		{
			// Token: 0x04001164 RID: 4452
			Graphic,
			// Token: 0x04001165 RID: 4453
			Sprite,
			// Token: 0x04001166 RID: 4454
			Texture
		}

		// Token: 0x02000146 RID: 326
		[Serializable]
		public enum BorderMode
		{
			// Token: 0x04001168 RID: 4456
			Simple,
			// Token: 0x04001169 RID: 4457
			Sliced,
			// Token: 0x0400116A RID: 4458
			Tiled
		}

		// Token: 0x02000147 RID: 327
		[Flags]
		[Serializable]
		public enum Errors
		{
			// Token: 0x0400116C RID: 4460
			NoError = 0,
			// Token: 0x0400116D RID: 4461
			UnsupportedShaders = 1,
			// Token: 0x0400116E RID: 4462
			NestedMasks = 2,
			// Token: 0x0400116F RID: 4463
			TightPackedSprite = 4,
			// Token: 0x04001170 RID: 4464
			AlphaSplitSprite = 8,
			// Token: 0x04001171 RID: 4465
			UnsupportedImageType = 16
		}

		// Token: 0x02000148 RID: 328
		private static class Mathr
		{
			// Token: 0x06000CF2 RID: 3314 RVA: 0x0012D648 File Offset: 0x0012BA48
			public static Vector4 ToVector(Rect r)
			{
				return new Vector4(r.xMin, r.yMin, r.xMax, r.yMax);
			}

			// Token: 0x06000CF3 RID: 3315 RVA: 0x0012D66C File Offset: 0x0012BA6C
			public static Vector4 Div(Vector4 v, Vector2 s)
			{
				return new Vector4(v.x / s.x, v.y / s.y, v.z / s.x, v.w / s.y);
			}

			// Token: 0x06000CF4 RID: 3316 RVA: 0x0012D6BA File Offset: 0x0012BABA
			public static Vector2 Div(Vector2 v, Vector2 s)
			{
				return new Vector2(v.x / s.x, v.y / s.y);
			}

			// Token: 0x06000CF5 RID: 3317 RVA: 0x0012D6E0 File Offset: 0x0012BAE0
			public static Vector4 Mul(Vector4 v, Vector2 s)
			{
				return new Vector4(v.x * s.x, v.y * s.y, v.z * s.x, v.w * s.y);
			}

			// Token: 0x06000CF6 RID: 3318 RVA: 0x0012D72E File Offset: 0x0012BB2E
			public static Vector2 Size(Vector4 r)
			{
				return new Vector2(r.z - r.x, r.w - r.y);
			}

			// Token: 0x06000CF7 RID: 3319 RVA: 0x0012D754 File Offset: 0x0012BB54
			public static Vector4 Move(Vector4 v, Vector2 o)
			{
				return new Vector4(v.x + o.x, v.y + o.y, v.z + o.x, v.w + o.y);
			}

			// Token: 0x06000CF8 RID: 3320 RVA: 0x0012D7A4 File Offset: 0x0012BBA4
			public static Vector4 BorderOf(Vector4 outer, Vector4 inner)
			{
				return new Vector4(inner.x - outer.x, inner.y - outer.y, outer.z - inner.z, outer.w - inner.w);
			}

			// Token: 0x06000CF9 RID: 3321 RVA: 0x0012D7F4 File Offset: 0x0012BBF4
			public static Vector4 ApplyBorder(Vector4 v, Vector4 b)
			{
				return new Vector4(v.x + b.x, v.y + b.y, v.z - b.z, v.w - b.w);
			}

			// Token: 0x06000CFA RID: 3322 RVA: 0x0012D842 File Offset: 0x0012BC42
			public static Vector2 Min(Vector4 r)
			{
				return new Vector2(r.x, r.y);
			}

			// Token: 0x06000CFB RID: 3323 RVA: 0x0012D857 File Offset: 0x0012BC57
			public static Vector2 Max(Vector4 r)
			{
				return new Vector2(r.z, r.w);
			}

			// Token: 0x06000CFC RID: 3324 RVA: 0x0012D86C File Offset: 0x0012BC6C
			public static Vector2 Center(Vector4 r)
			{
				return new Vector2((r.x + r.z) * 0.5f, (r.y + r.w) * 0.5f);
			}

			// Token: 0x06000CFD RID: 3325 RVA: 0x0012D8A0 File Offset: 0x0012BCA0
			public static Vector2 Remap(Vector2 c, Vector4 r1, Vector4 r2)
			{
				Vector2 s = SoftMask.Mathr.Max(r1) - SoftMask.Mathr.Min(r1);
				Vector2 b = SoftMask.Mathr.Max(r2) - SoftMask.Mathr.Min(r2);
				return Vector2.Scale(SoftMask.Mathr.Div(c - SoftMask.Mathr.Min(r1), s), b) + SoftMask.Mathr.Min(r2);
			}

			// Token: 0x06000CFE RID: 3326 RVA: 0x0012D8F4 File Offset: 0x0012BCF4
			public static bool Inside(Vector2 v, Vector4 r)
			{
				return v.x >= r.x && v.y >= r.y && v.x <= r.z && v.y <= r.w;
			}
		}

		// Token: 0x02000149 RID: 329
		private struct MaterialParameters
		{
			// Token: 0x17000049 RID: 73
			// (get) Token: 0x06000CFF RID: 3327 RVA: 0x0012D950 File Offset: 0x0012BD50
			public Texture2D activeTexture
			{
				get
				{
					return (!this.texture) ? Texture2D.whiteTexture : this.texture;
				}
			}

			// Token: 0x06000D00 RID: 3328 RVA: 0x0012D974 File Offset: 0x0012BD74
			public bool SampleMask(Vector2 localPos, out float mask)
			{
				Vector2 vector = this.XY2UV(localPos);
				bool result;
				try
				{
					mask = this.MaskValue(this.texture.GetPixelBilinear(vector.x, vector.y));
					result = true;
				}
				catch (UnityException)
				{
					mask = 0f;
					result = false;
				}
				return result;
			}

			// Token: 0x06000D01 RID: 3329 RVA: 0x0012D9D4 File Offset: 0x0012BDD4
			public void Apply(Material mat)
			{
				mat.SetTexture(SoftMask.MaterialParameters.Ids.SoftMask, this.activeTexture);
				mat.SetVector(SoftMask.MaterialParameters.Ids.SoftMask_Rect, this.maskRect);
				mat.SetVector(SoftMask.MaterialParameters.Ids.SoftMask_UVRect, this.maskRectUV);
				mat.SetColor(SoftMask.MaterialParameters.Ids.SoftMask_ChannelWeights, this.maskChannelWeights);
				mat.SetMatrix(SoftMask.MaterialParameters.Ids.SoftMask_WorldToMask, this.worldToMask);
				mat.EnableKeyword("SOFTMASK_SIMPLE", this.borderMode == SoftMask.BorderMode.Simple);
				mat.EnableKeyword("SOFTMASK_SLICED", this.borderMode == SoftMask.BorderMode.Sliced);
				mat.EnableKeyword("SOFTMASK_TILED", this.borderMode == SoftMask.BorderMode.Tiled);
				if (this.borderMode != SoftMask.BorderMode.Simple)
				{
					mat.SetVector(SoftMask.MaterialParameters.Ids.SoftMask_BorderRect, this.maskBorder);
					mat.SetVector(SoftMask.MaterialParameters.Ids.SoftMask_UVBorderRect, this.maskBorderUV);
					if (this.borderMode == SoftMask.BorderMode.Tiled)
					{
						mat.SetVector(SoftMask.MaterialParameters.Ids.SoftMask_TileRepeat, this.tileRepeat);
					}
				}
			}

			// Token: 0x06000D02 RID: 3330 RVA: 0x0012DAC4 File Offset: 0x0012BEC4
			private Vector2 XY2UV(Vector2 localPos)
			{
				switch (this.borderMode)
				{
				case SoftMask.BorderMode.Simple:
					return this.MapSimple(localPos);
				case SoftMask.BorderMode.Sliced:
					return this.MapBorder(localPos, false);
				case SoftMask.BorderMode.Tiled:
					return this.MapBorder(localPos, true);
				default:
					Debug.LogError("Unknown BorderMode");
					return this.MapSimple(localPos);
				}
			}

			// Token: 0x06000D03 RID: 3331 RVA: 0x0012DB1A File Offset: 0x0012BF1A
			private Vector2 MapSimple(Vector2 localPos)
			{
				return SoftMask.Mathr.Remap(localPos, this.maskRect, this.maskRectUV);
			}

			// Token: 0x06000D04 RID: 3332 RVA: 0x0012DB30 File Offset: 0x0012BF30
			private Vector2 MapBorder(Vector2 localPos, bool repeat)
			{
				return new Vector2(this.Inset(localPos.x, this.maskRect.x, this.maskBorder.x, this.maskBorder.z, this.maskRect.z, this.maskRectUV.x, this.maskBorderUV.x, this.maskBorderUV.z, this.maskRectUV.z, (!repeat) ? 1f : this.tileRepeat.x), this.Inset(localPos.y, this.maskRect.y, this.maskBorder.y, this.maskBorder.w, this.maskRect.w, this.maskRectUV.y, this.maskBorderUV.y, this.maskBorderUV.w, this.maskRectUV.w, (!repeat) ? 1f : this.tileRepeat.y));
			}

			// Token: 0x06000D05 RID: 3333 RVA: 0x0012DC44 File Offset: 0x0012C044
			private float Inset(float v, float x1, float x2, float u1, float u2, float repeat = 1f)
			{
				float num = x2 - x1;
				return Mathf.Lerp(u1, u2, (num == 0f) ? 0f : this.Frac((v - x1) / num * repeat));
			}

			// Token: 0x06000D06 RID: 3334 RVA: 0x0012DC84 File Offset: 0x0012C084
			private float Inset(float v, float x1, float x2, float x3, float x4, float u1, float u2, float u3, float u4, float repeat = 1f)
			{
				if (v < x2)
				{
					return this.Inset(v, x1, x2, u1, u2, 1f);
				}
				if (v < x3)
				{
					return this.Inset(v, x2, x3, u2, u3, repeat);
				}
				return this.Inset(v, x3, x4, u3, u4, 1f);
			}

			// Token: 0x06000D07 RID: 3335 RVA: 0x0012DCD8 File Offset: 0x0012C0D8
			private float Frac(float v)
			{
				return v - Mathf.Floor(v);
			}

			// Token: 0x06000D08 RID: 3336 RVA: 0x0012DCE4 File Offset: 0x0012C0E4
			private float MaskValue(Color mask)
			{
				Color color = mask * this.maskChannelWeights;
				return color.a + color.r + color.g + color.b;
			}

			// Token: 0x04001172 RID: 4466
			public Vector4 maskRect;

			// Token: 0x04001173 RID: 4467
			public Vector4 maskBorder;

			// Token: 0x04001174 RID: 4468
			public Vector4 maskRectUV;

			// Token: 0x04001175 RID: 4469
			public Vector4 maskBorderUV;

			// Token: 0x04001176 RID: 4470
			public Vector2 tileRepeat;

			// Token: 0x04001177 RID: 4471
			public Color maskChannelWeights;

			// Token: 0x04001178 RID: 4472
			public Matrix4x4 worldToMask;

			// Token: 0x04001179 RID: 4473
			public Texture2D texture;

			// Token: 0x0400117A RID: 4474
			public SoftMask.BorderMode borderMode;

			// Token: 0x0200014A RID: 330
			private static class Ids
			{
				// Token: 0x0400117B RID: 4475
				public static readonly int SoftMask = Shader.PropertyToID("_SoftMask");

				// Token: 0x0400117C RID: 4476
				public static readonly int SoftMask_Rect = Shader.PropertyToID("_SoftMask_Rect");

				// Token: 0x0400117D RID: 4477
				public static readonly int SoftMask_UVRect = Shader.PropertyToID("_SoftMask_UVRect");

				// Token: 0x0400117E RID: 4478
				public static readonly int SoftMask_ChannelWeights = Shader.PropertyToID("_SoftMask_ChannelWeights");

				// Token: 0x0400117F RID: 4479
				public static readonly int SoftMask_WorldToMask = Shader.PropertyToID("_SoftMask_WorldToMask");

				// Token: 0x04001180 RID: 4480
				public static readonly int SoftMask_BorderRect = Shader.PropertyToID("_SoftMask_BorderRect");

				// Token: 0x04001181 RID: 4481
				public static readonly int SoftMask_UVBorderRect = Shader.PropertyToID("_SoftMask_UVBorderRect");

				// Token: 0x04001182 RID: 4482
				public static readonly int SoftMask_TileRepeat = Shader.PropertyToID("_SoftMask_TileRepeat");
			}
		}
	}
}
