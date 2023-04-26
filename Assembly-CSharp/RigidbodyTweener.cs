using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200007D RID: 125
public static class RigidbodyTweener
{
	// Token: 0x0600024F RID: 591 RVA: 0x0001DA54 File Offset: 0x0001BE54
	public static void MoveRotateBy(this Transform o, Vector3 fedVector, Vector3 fedRotation, float duration, float delay, bool local, MonoBehaviour lol = null)
	{
		lol.StartCoroutine(RigidbodyTweener.CMoveRotateBy(o, fedVector, fedRotation, duration, delay, local));
	}

	// Token: 0x06000250 RID: 592 RVA: 0x0001DA6C File Offset: 0x0001BE6C
	public static IEnumerator CMoveRotateBy(Transform o, Vector3 fedVector, Vector3 fedRotation, float duration, float delay, bool local)
	{
		yield return new WaitForSeconds(delay);
		float t = 0f;
		fedRotation *= 360f;
		Vector3 destination = o.position + o.right * fedVector.x + o.forward * fedVector.z + o.up * fedVector.y;
		Vector3 startPos = o.position;
		Quaternion startRot = o.rotation;
		Quaternion rotDestination = Quaternion.Euler(o.eulerAngles + fedRotation);
		while (t < 1f)
		{
			o.position = Vector3.Lerp(startPos, destination, t);
			o.rotation = Quaternion.Lerp(startRot, rotDestination, t);
			t += Time.deltaTime / duration;
			yield return new WaitForEndOfFrame();
		}
		o.position = destination;
		o.rotation = rotDestination;
		yield break;
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0001DAA4 File Offset: 0x0001BEA4
	public static void RotateTo(this Transform o, Vector3 fedRotation, float duration, float delay, MonoBehaviour lol = null)
	{
		lol.StartCoroutine(RigidbodyTweener.CRotateTo(o, fedRotation, duration, delay));
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0001DAB8 File Offset: 0x0001BEB8
	public static IEnumerator CRotateTo(Transform o, Vector3 fedRotation, float duration, float delay)
	{
		yield return new WaitForSeconds(delay);
		float t = 0f;
		Quaternion startRot = o.rotation;
		Quaternion rotDestination = Quaternion.Euler(fedRotation);
		while (t < 1f)
		{
			o.rotation = Quaternion.Slerp(startRot, rotDestination, t);
			t += Time.deltaTime / duration;
			yield return new WaitForEndOfFrame();
		}
		o.rotation = rotDestination;
		yield break;
	}

	// Token: 0x06000253 RID: 595 RVA: 0x0001DAE8 File Offset: 0x0001BEE8
	public static void MoveRotateTo(this Transform o, Vector3 fedPosition, Vector3 fedRotation, float duration, float delay, MonoBehaviour lol = null, Action delegateTrigger = null)
	{
		lol.StartCoroutine(RigidbodyTweener.MoveRotateTo(o, fedPosition, fedRotation, duration, delay, delegateTrigger));
	}

	// Token: 0x06000254 RID: 596 RVA: 0x0001DAFF File Offset: 0x0001BEFF
	public static void MoveRotateToElasticOut(this Transform o, Vector3 fedPosition, Vector3 fedRotation, float duration, float delay, MonoBehaviour lol = null, Action delegateTrigger = null)
	{
		lol.StartCoroutine(RigidbodyTweener.MoveRotateToElasticOut(o, fedPosition, fedRotation, duration, delay, delegateTrigger));
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0001DB16 File Offset: 0x0001BF16
	public static void MoveRotateToElasticIn(this Transform o, Vector3 fedPosition, Vector3 fedRotation, float duration, float delay, MonoBehaviour lol = null, Action delegateTrigger = null)
	{
		lol.StartCoroutine(RigidbodyTweener.MoveRotateToElasticIn(o, fedPosition, fedRotation, duration, delay, delegateTrigger));
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0001DB30 File Offset: 0x0001BF30
	public static IEnumerator MoveRotateTo(Transform o, Vector3 fedPosition, Vector3 fedRotation, float duration, float delay, Action delegateTrigge)
	{
		yield return new WaitForSeconds(delay);
		float t = 0f;
		Quaternion startRot = o.rotation;
		Quaternion rotDestination = Quaternion.Euler(fedRotation);
		Vector3 startPosition = o.position;
		while (t < 1f)
		{
			o.position = Vector3.Slerp(startPosition, fedPosition, Quintic.InOut(t));
			o.rotation = Quaternion.Slerp(startRot, rotDestination, Quintic.InOut(t));
			t += Time.deltaTime / duration;
			yield return new WaitForEndOfFrame();
		}
		o.position = fedPosition;
		o.rotation = rotDestination;
		if (delegateTrigge != null)
		{
			delegateTrigge();
		}
		yield break;
	}

	// Token: 0x06000257 RID: 599 RVA: 0x0001DB70 File Offset: 0x0001BF70
	public static IEnumerator MoveRotateToElasticOut(Transform o, Vector3 fedPosition, Vector3 fedRotation, float duration, float delay, Action delegateTrigge)
	{
		yield return new WaitForSeconds(delay);
		float t = 0f;
		Quaternion startRot = o.rotation;
		Quaternion rotDestination = Quaternion.Euler(fedRotation);
		Vector3 startPosition = o.position;
		while (t < 1f)
		{
			o.position = Vector3.Slerp(startPosition, fedPosition, Elastic.Out(t));
			o.rotation = Quaternion.Slerp(startRot, rotDestination, Quintic.InOut(t));
			t += Time.deltaTime / duration;
			yield return new WaitForEndOfFrame();
		}
		o.position = fedPosition;
		o.rotation = rotDestination;
		if (delegateTrigge != null)
		{
			delegateTrigge();
		}
		yield break;
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0001DBB0 File Offset: 0x0001BFB0
	public static IEnumerator MoveRotateToElasticIn(Transform o, Vector3 fedPosition, Vector3 fedRotation, float duration, float delay, Action delegateTrigge)
	{
		yield return new WaitForSeconds(delay);
		float t = 0f;
		Quaternion startRot = o.rotation;
		Quaternion rotDestination = Quaternion.Euler(fedRotation);
		Vector3 startPosition = o.position;
		while (t < 1f)
		{
			o.position = Vector3.Slerp(startPosition, fedPosition, Elastic.In(t));
			o.rotation = Quaternion.Slerp(startRot, rotDestination, Quintic.InOut(t));
			t += Time.deltaTime / duration;
			yield return new WaitForEndOfFrame();
		}
		o.position = fedPosition;
		o.rotation = rotDestination;
		if (delegateTrigge != null)
		{
			delegateTrigge();
		}
		yield break;
	}
}
