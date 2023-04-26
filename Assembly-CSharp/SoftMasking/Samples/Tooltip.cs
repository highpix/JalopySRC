using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SoftMasking.Samples
{
	// Token: 0x0200013E RID: 318
	public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		// Token: 0x06000C8C RID: 3212 RVA: 0x0012C360 File Offset: 0x0012A760
		public void LateUpdate()
		{
			Vector2 a;
			if (this.tooltip.gameObject.activeInHierarchy && RectTransformUtility.ScreenPointToLocalPointInRectangle(this.tooltip.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out a))
			{
				this.tooltip.anchoredPosition = a + new Vector2(10f, -20f);
			}
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0012C3C9 File Offset: 0x0012A7C9
		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			this.tooltip.gameObject.SetActive(true);
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0012C3DC File Offset: 0x0012A7DC
		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			this.tooltip.gameObject.SetActive(false);
		}

		// Token: 0x04001140 RID: 4416
		public RectTransform tooltip;
	}
}
