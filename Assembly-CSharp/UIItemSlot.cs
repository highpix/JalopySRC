using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000045 RID: 69
public abstract class UIItemSlot : MonoBehaviour
{
	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000160 RID: 352
	protected abstract InvGameItem observedItem { get; }

	// Token: 0x06000161 RID: 353
	protected abstract InvGameItem Replace(InvGameItem item);

	// Token: 0x06000162 RID: 354 RVA: 0x00016A78 File Offset: 0x00014E78
	private void OnTooltip(bool show)
	{
		InvGameItem invGameItem = (!show) ? null : this.mItem;
		if (invGameItem != null)
		{
			InvBaseItem baseItem = invGameItem.baseItem;
			if (baseItem != null)
			{
				string text = string.Concat(new string[]
				{
					"[",
					NGUIText.EncodeColor(invGameItem.color),
					"]",
					invGameItem.name,
					"[-]\n"
				});
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"[AFAFAF]Level ",
					invGameItem.itemLevel,
					" ",
					baseItem.slot
				});
				List<InvStat> list = invGameItem.CalculateStats();
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					InvStat invStat = list[i];
					if (invStat.amount != 0)
					{
						if (invStat.amount < 0)
						{
							text = text + "\n[FF0000]" + invStat.amount;
						}
						else
						{
							text = text + "\n[00FF00]+" + invStat.amount;
						}
						if (invStat.modifier == InvStat.Modifier.Percent)
						{
							text += "%";
						}
						text = text + " " + invStat.id;
						text += "[-]";
					}
					i++;
				}
				if (!string.IsNullOrEmpty(baseItem.description))
				{
					text = text + "\n[FF9900]" + baseItem.description;
				}
				UITooltip.Show(text);
				return;
			}
		}
		UITooltip.Hide();
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00016C18 File Offset: 0x00015018
	private void OnClick()
	{
		if (UIItemSlot.mDraggedItem != null)
		{
			this.OnDrop(null);
		}
		else if (this.mItem != null)
		{
			UIItemSlot.mDraggedItem = this.Replace(null);
			if (UIItemSlot.mDraggedItem != null)
			{
				NGUITools.PlaySound(this.grabSound);
			}
			this.UpdateCursor();
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00016C6E File Offset: 0x0001506E
	private void OnDrag(Vector2 delta)
	{
		if (UIItemSlot.mDraggedItem == null && this.mItem != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			UIItemSlot.mDraggedItem = this.Replace(null);
			NGUITools.PlaySound(this.grabSound);
			this.UpdateCursor();
		}
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00016CB0 File Offset: 0x000150B0
	private void OnDrop(GameObject go)
	{
		InvGameItem invGameItem = this.Replace(UIItemSlot.mDraggedItem);
		if (UIItemSlot.mDraggedItem == invGameItem)
		{
			NGUITools.PlaySound(this.errorSound);
		}
		else if (invGameItem != null)
		{
			NGUITools.PlaySound(this.grabSound);
		}
		else
		{
			NGUITools.PlaySound(this.placeSound);
		}
		UIItemSlot.mDraggedItem = invGameItem;
		this.UpdateCursor();
	}

	// Token: 0x06000166 RID: 358 RVA: 0x00016D14 File Offset: 0x00015114
	private void UpdateCursor()
	{
		if (UIItemSlot.mDraggedItem != null && UIItemSlot.mDraggedItem.baseItem != null)
		{
			UICursor.Set(UIItemSlot.mDraggedItem.baseItem.iconAtlas, UIItemSlot.mDraggedItem.baseItem.iconName);
		}
		else
		{
			UICursor.Clear();
		}
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00016D68 File Offset: 0x00015168
	private void Update()
	{
		InvGameItem observedItem = this.observedItem;
		if (this.mItem != observedItem)
		{
			this.mItem = observedItem;
			InvBaseItem invBaseItem = (observedItem == null) ? null : observedItem.baseItem;
			if (this.label != null)
			{
				string text = (observedItem == null) ? null : observedItem.name;
				if (string.IsNullOrEmpty(this.mText))
				{
					this.mText = this.label.text;
				}
				this.label.text = ((text == null) ? this.mText : text);
			}
			if (this.icon != null)
			{
				if (invBaseItem == null || invBaseItem.iconAtlas == null)
				{
					this.icon.enabled = false;
				}
				else
				{
					this.icon.atlas = invBaseItem.iconAtlas;
					this.icon.spriteName = invBaseItem.iconName;
					this.icon.enabled = true;
					this.icon.MakePixelPerfect();
				}
			}
			if (this.background != null)
			{
				this.background.color = ((observedItem == null) ? Color.white : observedItem.color);
			}
		}
	}

	// Token: 0x04000278 RID: 632
	public UISprite icon;

	// Token: 0x04000279 RID: 633
	public UIWidget background;

	// Token: 0x0400027A RID: 634
	public UILabel label;

	// Token: 0x0400027B RID: 635
	public AudioClip grabSound;

	// Token: 0x0400027C RID: 636
	public AudioClip placeSound;

	// Token: 0x0400027D RID: 637
	public AudioClip errorSound;

	// Token: 0x0400027E RID: 638
	private InvGameItem mItem;

	// Token: 0x0400027F RID: 639
	private string mText = string.Empty;

	// Token: 0x04000280 RID: 640
	private static InvGameItem mDraggedItem;
}
