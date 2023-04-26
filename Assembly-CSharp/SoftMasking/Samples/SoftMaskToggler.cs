using System;
using UnityEngine;
using UnityEngine.UI;

namespace SoftMasking.Samples
{
	// Token: 0x0200013D RID: 317
	public class SoftMaskToggler : MonoBehaviour
	{
		// Token: 0x06000C8A RID: 3210 RVA: 0x0012C2F4 File Offset: 0x0012A6F4
		public void Toggle(bool enabled)
		{
			if (this.mask)
			{
				this.mask.GetComponent<SoftMask>().enabled = enabled;
				this.mask.GetComponent<Mask>().enabled = !enabled;
				if (!this.doNotTouchImage)
				{
					this.mask.GetComponent<Image>().enabled = !enabled;
				}
			}
		}

		// Token: 0x0400113E RID: 4414
		public GameObject mask;

		// Token: 0x0400113F RID: 4415
		public bool doNotTouchImage;
	}
}
