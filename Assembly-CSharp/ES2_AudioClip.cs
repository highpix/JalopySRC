using System;
using System.ComponentModel;
using UnityEngine;

// Token: 0x02000029 RID: 41
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class ES2_AudioClip : ES2Type
{
	// Token: 0x060000CB RID: 203 RVA: 0x000083DD File Offset: 0x000067DD
	public ES2_AudioClip() : base(typeof(AudioClip))
	{
		this.key = 25;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x000083F8 File Offset: 0x000067F8
	public override void Write(object data, ES2Writer writer)
	{
		AudioClip audioClip = (AudioClip)data;
		writer.Write(5);
		float[] array = new float[audioClip.samples * audioClip.channels];
		audioClip.GetData(array, 0);
		writer.Write(audioClip.name);
		writer.Write(audioClip.samples);
		writer.Write(audioClip.channels);
		writer.Write(audioClip.frequency);
		writer.Write<float>(array);
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00008468 File Offset: 0x00006868
	public override object Read(ES2Reader reader)
	{
		AudioClip audioClip = null;
		string name = string.Empty;
		int lengthSamples = 0;
		int channels = 0;
		int frequency = 0;
		int num = (int)reader.Read_byte();
		for (int i = 0; i < num; i++)
		{
			switch (i)
			{
			case 0:
				name = reader.Read_string();
				break;
			case 1:
				lengthSamples = reader.Read_int();
				break;
			case 2:
				channels = reader.Read_int();
				break;
			case 3:
				frequency = reader.Read_int();
				break;
			case 4:
				audioClip = AudioClip.Create(name, lengthSamples, channels, frequency, false, false);
				audioClip.SetData(reader.ReadArray<float>(new ES2_float()), 0);
				break;
			default:
				return audioClip;
			}
		}
		return audioClip;
	}
}
