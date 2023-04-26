using System;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000017 RID: 23
	public static class DOTweenCYInstruction
	{
		// Token: 0x02000018 RID: 24
		public class WaitForCompletion : CustomYieldInstruction
		{
			// Token: 0x06000089 RID: 137 RVA: 0x00006BFE File Offset: 0x00004FFE
			public WaitForCompletion(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x17000001 RID: 1
			// (get) Token: 0x0600008A RID: 138 RVA: 0x00006C0D File Offset: 0x0000500D
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && !this.t.IsComplete();
				}
			}

			// Token: 0x04000055 RID: 85
			private readonly Tween t;
		}

		// Token: 0x02000019 RID: 25
		public class WaitForRewind : CustomYieldInstruction
		{
			// Token: 0x0600008B RID: 139 RVA: 0x00006C30 File Offset: 0x00005030
			public WaitForRewind(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x17000002 RID: 2
			// (get) Token: 0x0600008C RID: 140 RVA: 0x00006C40 File Offset: 0x00005040
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && (!this.t.playedOnce || this.t.position * (float)(this.t.CompletedLoops() + 1) > 0f);
				}
			}

			// Token: 0x04000056 RID: 86
			private readonly Tween t;
		}

		// Token: 0x0200001A RID: 26
		public class WaitForKill : CustomYieldInstruction
		{
			// Token: 0x0600008D RID: 141 RVA: 0x00006C94 File Offset: 0x00005094
			public WaitForKill(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x0600008E RID: 142 RVA: 0x00006CA3 File Offset: 0x000050A3
			public override bool keepWaiting
			{
				get
				{
					return this.t.active;
				}
			}

			// Token: 0x04000057 RID: 87
			private readonly Tween t;
		}

		// Token: 0x0200001B RID: 27
		public class WaitForElapsedLoops : CustomYieldInstruction
		{
			// Token: 0x0600008F RID: 143 RVA: 0x00006CB0 File Offset: 0x000050B0
			public WaitForElapsedLoops(Tween tween, int elapsedLoops)
			{
				this.t = tween;
				this.elapsedLoops = elapsedLoops;
			}

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000090 RID: 144 RVA: 0x00006CC6 File Offset: 0x000050C6
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && this.t.CompletedLoops() < this.elapsedLoops;
				}
			}

			// Token: 0x04000058 RID: 88
			private readonly Tween t;

			// Token: 0x04000059 RID: 89
			private readonly int elapsedLoops;
		}

		// Token: 0x0200001C RID: 28
		public class WaitForPosition : CustomYieldInstruction
		{
			// Token: 0x06000091 RID: 145 RVA: 0x00006CEE File Offset: 0x000050EE
			public WaitForPosition(Tween tween, float position)
			{
				this.t = tween;
				this.position = position;
			}

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000092 RID: 146 RVA: 0x00006D04 File Offset: 0x00005104
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && this.t.position * (float)(this.t.CompletedLoops() + 1) < this.position;
				}
			}

			// Token: 0x0400005A RID: 90
			private readonly Tween t;

			// Token: 0x0400005B RID: 91
			private readonly float position;
		}

		// Token: 0x0200001D RID: 29
		public class WaitForStart : CustomYieldInstruction
		{
			// Token: 0x06000093 RID: 147 RVA: 0x00006D3B File Offset: 0x0000513B
			public WaitForStart(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000094 RID: 148 RVA: 0x00006D4A File Offset: 0x0000514A
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && !this.t.playedOnce;
				}
			}

			// Token: 0x0400005C RID: 92
			private readonly Tween t;
		}
	}
}
