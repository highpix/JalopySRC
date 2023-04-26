using System;
using UnityEngine;

namespace SoftMasking.Samples
{
	// Token: 0x0200013B RID: 315
	public class Minimap : MonoBehaviour
	{
		// Token: 0x06000C82 RID: 3202 RVA: 0x0012C187 File Offset: 0x0012A587
		public void LateUpdate()
		{
			this.map.anchoredPosition = -this.marker.anchoredPosition * this._zoom;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0012C1AF File Offset: 0x0012A5AF
		public void ZoomIn()
		{
			this._zoom = this.Clamp(this._zoom + this.zoomStep);
			this.map.localScale = Vector3.one * this._zoom;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0012C1E5 File Offset: 0x0012A5E5
		public void ZoomOut()
		{
			this._zoom = this.Clamp(this._zoom - this.zoomStep);
			this.map.localScale = Vector3.one * this._zoom;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0012C21B File Offset: 0x0012A61B
		private float Clamp(float zoom)
		{
			return Mathf.Clamp(zoom, this.minZoom, this.maxZoom);
		}

		// Token: 0x04001136 RID: 4406
		public RectTransform map;

		// Token: 0x04001137 RID: 4407
		public RectTransform marker;

		// Token: 0x04001138 RID: 4408
		[Space]
		public float minZoom = 0.8f;

		// Token: 0x04001139 RID: 4409
		public float maxZoom = 1.4f;

		// Token: 0x0400113A RID: 4410
		public float zoomStep = 0.2f;

		// Token: 0x0400113B RID: 4411
		private float _zoom = 1f;
	}
}
