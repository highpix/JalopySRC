using System;
using UnityEngine;

namespace SoftMasking.Samples
{
	// Token: 0x02000138 RID: 312
	[RequireComponent(typeof(Camera))]
	public class HorizontalFovSetter : MonoBehaviour
	{
		// Token: 0x06000C79 RID: 3193 RVA: 0x0012BED8 File Offset: 0x0012A2D8
		public void Awake()
		{
			this._camera = base.GetComponent<Camera>();
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0012BEE6 File Offset: 0x0012A2E6
		public void Update()
		{
			this._camera.fieldOfView = this.horizontalFov / this._camera.aspect;
		}

		// Token: 0x04001129 RID: 4393
		public float horizontalFov;

		// Token: 0x0400112A RID: 4394
		private Camera _camera;
	}
}
