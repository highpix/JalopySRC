using System;
using UnityEngine;

// Token: 0x020000A8 RID: 168
public static class ExtensionMethods
{
	// Token: 0x060005A3 RID: 1443 RVA: 0x00073F4C File Offset: 0x0007234C
	public static void Copy(this Sprite[] array, ref Sprite[] into)
	{
		into = new Sprite[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00073F61 File Offset: 0x00072361
	public static void Copy(this string[] array, ref string[] into)
	{
		into = new string[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x00073F76 File Offset: 0x00072376
	public static void Copy(this int[] array, ref int[] into)
	{
		into = new int[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x00073F8B File Offset: 0x0007238B
	public static void Copy(this float[] array, ref float[] into)
	{
		into = new float[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x00073FA0 File Offset: 0x000723A0
	public static void Copy(this GameObject[] array, ref GameObject[] into)
	{
		into = new GameObject[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x00073FB5 File Offset: 0x000723B5
	public static void Copy(this Transform[] array, ref Transform[] into)
	{
		into = new Transform[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x00073FCC File Offset: 0x000723CC
	public static void Copy(this GameObject[] array, ref Transform[] into)
	{
		into = new Transform[array.Length];
		for (int i = 0; i < into.Length; i++)
		{
			into[i] = array[i].transform;
		}
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00074004 File Offset: 0x00072404
	public static void Copy(this AudioClip[] array, ref AudioClip[] into)
	{
		into = new AudioClip[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x00074019 File Offset: 0x00072419
	public static void Copy(this Texture[] array, ref Texture[] into)
	{
		into = new Texture[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x0007402E File Offset: 0x0007242E
	public static void Copy(this Material[] array, ref Material[] into)
	{
		into = new Material[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x00074043 File Offset: 0x00072443
	public static void Copy(this Vector3[] array, ref Vector3[] into)
	{
		into = new Vector3[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00074058 File Offset: 0x00072458
	public static void Copy(this Mesh[] array, ref Mesh[] into)
	{
		into = new Mesh[array.Length];
		array.CopyTo(into, 0);
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00074070 File Offset: 0x00072470
	public static void SetAlpha(this Material theMat, float value)
	{
		Color color = theMat.GetColor("_Color");
		theMat.SetColor("_Color", new Color(color.r, color.g, color.b, value));
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x000740AF File Offset: 0x000724AF
	public static void SetAlpha(this Color color, float value)
	{
		color = new Color(color.r, color.g, color.b, value);
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x000740CE File Offset: 0x000724CE
	public static void ReduceAlpha(this Color color, float value)
	{
		color = new Color(color.r, color.g, color.b, color.a - value);
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x000740F5 File Offset: 0x000724F5
	public static void IncreaseAlpha(this Color color, float value)
	{
		color = new Color(color.r, color.g, color.b, color.a + value);
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x0007411C File Offset: 0x0007251C
	public static void SetX(this Vector3 vector, float value)
	{
		vector = new Vector3(value, vector.y, vector.z);
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x00074134 File Offset: 0x00072534
	public static void SetY(this Vector3 vector, float value)
	{
		vector = new Vector3(vector.x, value, vector.z);
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x0007414C File Offset: 0x0007254C
	public static void SetZ(this Vector3 vector, float value)
	{
		vector = new Vector3(vector.x, vector.y, value);
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x00074164 File Offset: 0x00072564
	public static void Reset(this Transform trans)
	{
		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale = Vector3.one;
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x00074188 File Offset: 0x00072588
	public static void RSetLocalX(this Transform trans, float value)
	{
		trans.localEulerAngles = new Vector3(value, trans.localEulerAngles.y, trans.localEulerAngles.z);
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x000741C0 File Offset: 0x000725C0
	public static void RSetLocalY(this Transform trans, float value)
	{
		trans.localEulerAngles = new Vector3(trans.localEulerAngles.x, value, trans.localEulerAngles.z);
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x000741F8 File Offset: 0x000725F8
	public static void RSetLocalZ(this Transform trans, float value)
	{
		trans.localEulerAngles = new Vector3(trans.localEulerAngles.x, trans.localEulerAngles.y, value);
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x00074230 File Offset: 0x00072630
	public static void SetLocalX(this Transform trans, float value)
	{
		trans.localPosition = new Vector3(value, trans.localPosition.y, trans.localPosition.z);
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x00074268 File Offset: 0x00072668
	public static void SetLocalY(this Transform trans, float value)
	{
		trans.localPosition = new Vector3(trans.localPosition.x, value, trans.localPosition.z);
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x000742A0 File Offset: 0x000726A0
	public static void SetLocalZ(this Transform trans, float value)
	{
		trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, value);
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x000742D5 File Offset: 0x000726D5
	public static void DecreaseExtrenum(this WheelFrictionCurve curve, float value)
	{
		curve.ModifyExtrenum(curve.extremumValue - value);
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x000742E6 File Offset: 0x000726E6
	public static void IncreaseExtrenum(this WheelFrictionCurve curve, float value)
	{
		curve.ModifyExtrenum(curve.extremumValue + value);
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x000742F7 File Offset: 0x000726F7
	public static void IncreaseAsymptote(this WheelFrictionCurve curve, float value)
	{
		curve.ModifyAsmptote(curve.asymptoteValue + value);
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x00074308 File Offset: 0x00072708
	public static void DecreaseAsymptote(this WheelFrictionCurve curve, float value)
	{
		curve.ModifyAsmptote(curve.asymptoteValue - value);
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x0007431C File Offset: 0x0007271C
	public static void ModifyExtrenum(this WheelFrictionCurve curve, float value)
	{
		WheelFrictionCurve wheelFrictionCurve = default(WheelFrictionCurve);
		wheelFrictionCurve = curve;
		curve = wheelFrictionCurve;
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x00074338 File Offset: 0x00072738
	public static void ModifyAsmptote(this WheelFrictionCurve curve, float value)
	{
		WheelFrictionCurve wheelFrictionCurve = default(WheelFrictionCurve);
		wheelFrictionCurve = curve;
		curve = wheelFrictionCurve;
	}
}
