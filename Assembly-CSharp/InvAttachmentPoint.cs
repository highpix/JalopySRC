using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
[AddComponentMenu("NGUI/Examples/Item Attachment Point")]
public class InvAttachmentPoint : MonoBehaviour
{
	// Token: 0x06000171 RID: 369 RVA: 0x000171B0 File Offset: 0x000155B0
	public GameObject Attach(GameObject prefab)
	{
		if (this.mPrefab != prefab)
		{
			this.mPrefab = prefab;
			if (this.mChild != null)
			{
				UnityEngine.Object.Destroy(this.mChild);
			}
			if (this.mPrefab != null)
			{
				Transform transform = base.transform;
				this.mChild = UnityEngine.Object.Instantiate<GameObject>(this.mPrefab, transform.position, transform.rotation);
				Transform transform2 = this.mChild.transform;
				transform2.parent = transform;
				transform2.localPosition = Vector3.zero;
				transform2.localRotation = Quaternion.identity;
				transform2.localScale = Vector3.one;
			}
		}
		return this.mChild;
	}

	// Token: 0x0400028B RID: 651
	public InvBaseItem.Slot slot;

	// Token: 0x0400028C RID: 652
	private GameObject mPrefab;

	// Token: 0x0400028D RID: 653
	private GameObject mChild;
}
