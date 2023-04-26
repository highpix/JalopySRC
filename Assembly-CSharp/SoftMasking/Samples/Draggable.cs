using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SoftMasking.Samples
{
	// Token: 0x02000137 RID: 311
	[RequireComponent(typeof(RectTransform))]
	public class Draggable : UIBehaviour, IDragHandler, IEventSystemHandler
	{
		// Token: 0x06000C76 RID: 3190 RVA: 0x0012BE9E File Offset: 0x0012A29E
		protected override void Awake()
		{
			base.Awake();
			this._rectTransform = base.GetComponent<RectTransform>();
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x0012BEB2 File Offset: 0x0012A2B2
		public void OnDrag(PointerEventData eventData)
		{
			this._rectTransform.anchoredPosition += eventData.delta;
		}

		// Token: 0x04001128 RID: 4392
		private RectTransform _rectTransform;
	}
}
