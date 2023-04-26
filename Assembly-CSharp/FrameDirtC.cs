using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class FrameDirtC : MonoBehaviour
{
	// Token: 0x06000548 RID: 1352 RVA: 0x000594F4 File Offset: 0x000578F4
	public void Clean()
	{
		if (this.frontWindow)
		{
			this.director.GetComponent<DirectorC>().FrontWindowDirtDown();
		}
		if (this.leftFrontWindow)
		{
			this.director.GetComponent<DirectorC>().LeftFrontWindowDirtDown();
		}
		if (this.leftRearWindow)
		{
			this.director.GetComponent<DirectorC>().LeftRearWindowDirtDown();
		}
		if (this.rightFrontWindow)
		{
			this.director.GetComponent<DirectorC>().RightFrontWindowDirtDown();
		}
		if (this.rightRearWindow)
		{
			this.director.GetComponent<DirectorC>().RightRearWindowDirtDown();
		}
		if (this.rearWindow)
		{
			this.director.GetComponent<DirectorC>().RearWindowDirtDown();
		}
		if (this.frontFrame)
		{
			this.director.GetComponent<DirectorC>().FrontFrameDirtDown();
		}
		if (this.rearFrame)
		{
			this.director.GetComponent<DirectorC>().RearFrameDirtDown();
		}
		if (this.leftFrontFrame)
		{
			this.director.GetComponent<DirectorC>().LeftFrontFrameDirtDown();
		}
		if (this.leftDoorFrame)
		{
			this.director.GetComponent<DirectorC>().LeftDoorFrameDirtDown();
		}
		if (this.leftRearFrame)
		{
			this.director.GetComponent<DirectorC>().LeftRearFrameDirtDown();
		}
		if (this.rightFrontFrame)
		{
			this.director.GetComponent<DirectorC>().RightFrontFrameDirtDown();
		}
		if (this.rightDoorFrame)
		{
			this.director.GetComponent<DirectorC>().RightDoorFrameDirtDown();
		}
		if (this.rightRearFrame)
		{
			this.director.GetComponent<DirectorC>().RightRearFrameDirtDown();
		}
		if (this.leftFrontTyre)
		{
			this.director.GetComponent<DirectorC>().LeftFrontTyreDirtDown();
		}
		if (this.leftRearTyre)
		{
			this.director.GetComponent<DirectorC>().LeftRearTyreDirtDown();
		}
		if (this.rightFrontTyre)
		{
			this.director.GetComponent<DirectorC>().RightFrontTyreDirtDown();
		}
		if (this.rightRearTyre)
		{
			this.director.GetComponent<DirectorC>().RightRearTyreDirtDown();
		}
	}

	// Token: 0x040007B4 RID: 1972
	public GameObject director;

	// Token: 0x040007B5 RID: 1973
	public bool frontWindow;

	// Token: 0x040007B6 RID: 1974
	public bool leftFrontWindow;

	// Token: 0x040007B7 RID: 1975
	public bool leftRearWindow;

	// Token: 0x040007B8 RID: 1976
	public bool rightFrontWindow;

	// Token: 0x040007B9 RID: 1977
	public bool rightRearWindow;

	// Token: 0x040007BA RID: 1978
	public bool rearWindow;

	// Token: 0x040007BB RID: 1979
	public bool frontFrame;

	// Token: 0x040007BC RID: 1980
	public bool rearFrame;

	// Token: 0x040007BD RID: 1981
	public bool leftFrontFrame;

	// Token: 0x040007BE RID: 1982
	public bool leftDoorFrame;

	// Token: 0x040007BF RID: 1983
	public bool leftRearFrame;

	// Token: 0x040007C0 RID: 1984
	public bool rightFrontFrame;

	// Token: 0x040007C1 RID: 1985
	public bool rightDoorFrame;

	// Token: 0x040007C2 RID: 1986
	public bool rightRearFrame;

	// Token: 0x040007C3 RID: 1987
	public bool leftFrontTyre;

	// Token: 0x040007C4 RID: 1988
	public bool leftRearTyre;

	// Token: 0x040007C5 RID: 1989
	public bool rightFrontTyre;

	// Token: 0x040007C6 RID: 1990
	public bool rightRearTyre;
}
