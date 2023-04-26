using System;
using UnityEngine;

// Token: 0x0200008C RID: 140
public class AnimatedClock : MonoBehaviour
{
	// Token: 0x0600043C RID: 1084 RVA: 0x00046D1C File Offset: 0x0004511C
	private void Start()
	{
		if (this.uDayCycle == null)
		{
			this.uDayCycle = GameObject.FindWithTag("UDay");
		}
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x00046D40 File Offset: 0x00045140
	private void Update()
	{
		if (this.uDayCycle != null)
		{
			if (this.analog)
			{
				TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
				this.calc = Mathf.Floor(this.uDayCycle.GetComponent<DNC_DayNight>().timeInHours);
				this.timeInMinutes = this.uDayCycle.GetComponent<DNC_DayNight>().timeInHours - this.calc;
				this.timeInMinutes *= 100f;
				this.hours.localRotation = Quaternion.Euler(0f, this.uDayCycle.GetComponent<DNC_DayNight>().timeInHours / 12f * 360f, 0f);
				this.minutes.localRotation = Quaternion.Euler(0f, this.timeInMinutes / 100f * 360f, 0f);
			}
			else
			{
				DateTime now = DateTime.Now;
				this.hours.localRotation = Quaternion.Euler(0f, 0f, (float)now.Hour * -30f);
				this.minutes.localRotation = Quaternion.Euler(0f, 0f, (float)now.Minute * -6f);
				this.seconds.localRotation = Quaternion.Euler(0f, 0f, (float)now.Second * -6f);
			}
		}
	}

	// Token: 0x04000633 RID: 1587
	private const float hoursToDegrees = 30f;

	// Token: 0x04000634 RID: 1588
	private const float minutesToDegrees = 6f;

	// Token: 0x04000635 RID: 1589
	private const float secondsToDegrees = 6f;

	// Token: 0x04000636 RID: 1590
	public Transform hours;

	// Token: 0x04000637 RID: 1591
	public Transform minutes;

	// Token: 0x04000638 RID: 1592
	public Transform seconds;

	// Token: 0x04000639 RID: 1593
	public bool analog;

	// Token: 0x0400063A RID: 1594
	public GameObject uDayCycle;

	// Token: 0x0400063B RID: 1595
	private float timeInMinutes;

	// Token: 0x0400063C RID: 1596
	private float calc;
}
