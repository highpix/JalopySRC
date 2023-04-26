using System;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class RopeConnectionC : MonoBehaviour
{
	// Token: 0x17000031 RID: 49
	// (get) Token: 0x0600099D RID: 2461 RVA: 0x000E3837 File Offset: 0x000E1C37
	// (set) Token: 0x0600099E RID: 2462 RVA: 0x000E383E File Offset: 0x000E1C3E
	public float ConnectionValue
	{
		get
		{
			return 10f;
		}
		set
		{
			this.connectionValue = value;
		}
	}

	// Token: 0x04000D27 RID: 3367
	private float connectionValue;

	// Token: 0x04000D28 RID: 3368
	public Transform connectedPoint;
}
