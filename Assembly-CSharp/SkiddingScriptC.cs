using System;
using UnityEngine;

// Token: 0x02000158 RID: 344
public class SkiddingScriptC : MonoBehaviour
{
	// Token: 0x06000D54 RID: 3412 RVA: 0x0012FABC File Offset: 0x0012DEBC
	private void Start()
	{
		this._camera = Camera.main.gameObject;
		this.skidSmoke.transform.position = base.transform.position;
		this.skidSmoke.transform.position.SetY(this.skidSmoke.transform.position.y - this.smokeDepth);
		this.carLogic = GameObject.FindWithTag("CarLogic");
	}

	// Token: 0x06000D55 RID: 3413 RVA: 0x0012FB38 File Offset: 0x0012DF38
	private void Update()
	{
		this.passTime += Time.deltaTime;
		if (this.passTime < 20f)
		{
			return;
		}
		if (base.transform.GetComponent<WheelCollider>() == null || this.carLogic.GetComponent<CarLogicC>() == null || base.transform.GetComponent<WheelCollider>() == null)
		{
			return;
		}
		WheelHit wheelHit;
		base.transform.GetComponent<WheelCollider>().GetGroundHit(out wheelHit);
		if (this.debugMe)
		{
			MonoBehaviour.print(this.currentFrictionValue);
		}
		this.currentFrictionValue = Mathf.Abs(wheelHit.sidewaysSlip);
		float rpm = base.transform.GetComponent<WheelCollider>().rpm;
		GameObject carDriver = this.carLogic.GetComponent<CarLogicC>().carDriver;
		if (carDriver.GetComponent<CarControleScriptC>().currentSpeed > 10f)
		{
			if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt && !this.mudSmokeParticlesPlaying)
			{
				this.mudSmokeParticlesPlaying = true;
				if (this.skidMudSmoke)
				{
					this.skidMudSmoke.GetComponent<ParticleSystem>().Play();
				}
			}
			if (this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass && !this.grassSmokeParticlesPlaying)
			{
				this.grassSmokeParticlesPlaying = true;
				if (this.skidGrassSmoke)
				{
					this.skidGrassSmoke.GetComponent<ParticleSystem>().Play();
				}
			}
			if (!this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt && this.mudSmokeParticlesPlaying)
			{
				if (this.skidMudSmoke)
				{
					this.skidMudSmoke.GetComponent<ParticleSystem>().Stop();
				}
				this.mudSmokeParticlesPlaying = false;
			}
			if (!this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass && this.grassSmokeParticlesPlaying)
			{
				if (this.skidGrassSmoke)
				{
					this.skidGrassSmoke.GetComponent<ParticleSystem>().Stop();
				}
				this.grassSmokeParticlesPlaying = false;
			}
		}
		else
		{
			if (this.skidMudSmoke)
			{
				this.skidMudSmoke.GetComponent<ParticleSystem>().Stop();
			}
			this.mudSmokeParticlesPlaying = false;
			this.grassSmokeParticlesPlaying = false;
			if (this.skidGrassSmoke)
			{
				this.skidGrassSmoke.GetComponent<ParticleSystem>().Stop();
			}
		}
		if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || (this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass && this.isAmbientControlTyre))
		{
			float num = 0.3f;
			float num2 = 0.7f;
			num += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
			num2 += num;
			if (num > 0.75f)
			{
				num = 0.75f;
			}
			else if ((double)num <= 0.3)
			{
				num = 0f;
			}
			if ((double)num2 > 1.2)
			{
				num2 = 1.2f;
			}
			else if ((double)num2 < 0.7)
			{
				num2 = 0.7f;
			}
			this.carLogic.GetComponent<CarLogicC>().dirtTrackAudioTarget.GetComponent<AudioSource>().volume = num;
			this.carLogic.GetComponent<CarLogicC>().dirtTrackAudioTarget.GetComponent<AudioSource>().pitch = num2;
		}
		if ((this.skidAt <= this.currentFrictionValue && this.soundWait <= 0f) || (rpm < 300f && rpm > 10f && Input.GetKey(MainMenuC.Global.assignedInputStrings[8]) && this.soundWait <= 0f && this.startSkid && wheelHit.collider))
		{
			if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
			{
				if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.skidDirtSound, wheelHit.point, Quaternion.identity);
					float num3 = 0.7f;
					num3 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					float num4 = 0.7f;
					num4 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					if ((double)num4 > 1.0)
					{
						num3 = 1f;
						num4 = 1f;
					}
					else if ((double)num4 < 0.7)
					{
						num4 = 0.7f;
					}
					if ((double)num3 < 0.3)
					{
						num3 = 0.3f;
					}
					gameObject.GetComponent<AudioSource>().volume = num3;
					gameObject.GetComponent<AudioSource>().pitch = num4;
				}
				else
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.skidSound, wheelHit.point, Quaternion.identity);
					float num5 = 0.7f;
					num5 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					float num6 = 0.7f;
					num6 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					if ((double)num6 > 1.0)
					{
						num6 = 1f;
						num5 = 1f;
					}
					else if ((double)num6 < 0.7)
					{
						num6 = 0.7f;
					}
					if ((double)num5 < 0.3)
					{
						num5 = 0.3f;
					}
					gameObject2.GetComponent<AudioSource>().pitch = num6;
					gameObject2.GetComponent<AudioSource>().volume = num5;
				}
				if (!this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt && !this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.025f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
					}
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.025f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
				}
			}
			else if (this.carLogic.GetComponent<CarLogicC>().rainLvl >= 1)
			{
				if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.skidDirtSound, wheelHit.point, Quaternion.identity);
					float num7 = 0.7f;
					num7 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					float num8 = 0.7f;
					num8 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					if ((double)num8 > 1.0)
					{
						num8 = 1f;
						num7 = 1f;
					}
					else if ((double)num8 < 0.7)
					{
						num8 = 0.7f;
					}
					if ((double)num7 < 0.3)
					{
						num7 = 0.3f;
					}
					gameObject3.GetComponent<AudioSource>().pitch = num8;
					gameObject3.GetComponent<AudioSource>().volume = num7;
				}
				else
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.skidWetSound, wheelHit.point, Quaternion.identity);
					gameObject4.GetComponent<AudioSource>().volume = base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.01f;
				}
				if (!this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt && !this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.018f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.0025f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.012f * Time.deltaTime;
					}
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.012f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.018f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.012f * Time.deltaTime;
				}
			}
			this.soundWait = 1f;
		}
		else if ((this.skidAt <= this.currentFrictionValue && this.soundWait <= 0f) || (rpm < 300f && rpm > 10f && Input.GetKey(MainMenuC.Global.assignedInputStrings[9]) && this.soundWait <= 0f && this.startSkid && wheelHit.collider))
		{
			if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
			{
				if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.skidDirtSound, wheelHit.point, Quaternion.identity);
					float num9 = 0.7f;
					num9 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					float num10 = 0.7f;
					num10 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					if ((double)num10 > 1.0)
					{
						num9 = 1f;
						num10 = 1f;
					}
					else if ((double)num10 < 0.7)
					{
						num10 = 0.7f;
					}
					if ((double)num9 < 0.3)
					{
						num9 = 0.3f;
					}
					gameObject5.GetComponent<AudioSource>().volume = num9;
					gameObject5.GetComponent<AudioSource>().pitch = num10;
				}
				else
				{
					GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.skidSound, wheelHit.point, Quaternion.identity);
					float num11 = 0.7f;
					num11 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					float num12 = 0.7f;
					num12 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					if ((double)num12 > 1.0)
					{
						num12 = 1f;
						num11 = 1f;
					}
					else if ((double)num12 < 0.7)
					{
						num12 = 0.7f;
					}
					if ((double)num11 < 0.3)
					{
						num11 = 0.3f;
					}
					gameObject6.GetComponent<AudioSource>().pitch = num12;
					gameObject6.GetComponent<AudioSource>().volume = num11;
				}
				if (!this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt && !this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.025f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
					}
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.025f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.07f * Time.deltaTime;
				}
			}
			else if (this.carLogic.GetComponent<CarLogicC>().rainLvl >= 1)
			{
				if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.skidDirtSound, wheelHit.point, Quaternion.identity);
					float num13 = 0.7f;
					num13 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					float num14 = 0.7f;
					num14 += base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.005f;
					if ((double)num14 > 1.0)
					{
						num14 = 1f;
						num13 = 1f;
					}
					else if ((double)num14 < 0.7)
					{
						num14 = 0.7f;
					}
					if ((double)num13 < 0.3)
					{
						num13 = 0.3f;
					}
					gameObject7.GetComponent<AudioSource>().pitch = num14;
					gameObject7.GetComponent<AudioSource>().volume = num13;
				}
				else
				{
					GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.skidWetSound, wheelHit.point, Quaternion.identity);
					gameObject8.GetComponent<AudioSource>().volume = base.transform.root.GetComponent<CarControleScriptC>().currentSpeed * 0.01f;
				}
				if (!this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt && !this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
				{
					if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.018f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.0025f * Time.deltaTime;
					}
					else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
					{
						base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.012f * Time.deltaTime;
					}
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 0)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.012f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 1)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.018f * Time.deltaTime;
				}
				else if (base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().tyreType == 2)
				{
					base.GetComponent<WheelScriptPCC>().wheelTransform.GetComponent<EngineComponentC>().Condition -= 0.012f * Time.deltaTime;
				}
			}
			this.soundWait = 1f;
		}
		this.soundWait -= Time.deltaTime * this.soundEmition;
		if (this.skidAt <= this.currentFrictionValue || (rpm < 300f && rpm > 10f && Input.GetKey(MainMenuC.Global.assignedInputStrings[8]) && this.startSkid && wheelHit.collider))
		{
			if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
			{
				this.skidSmoke.GetComponent<ParticleEmitter>().emit = false;
				return;
			}
			if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
			{
				this.skidSmoke.GetComponent<ParticleEmitter>().emit = true;
			}
			else
			{
				this.skidWetSmoke.GetComponent<ParticleEmitter>().emit = true;
			}
			this.SkidMesh();
		}
		else if (this.skidAt <= this.currentFrictionValue || (rpm < 300f && rpm > 10f && Input.GetKey(MainMenuC.Global.assignedInputStrings[9]) && this.startSkid && wheelHit.collider))
		{
			if (this.carLogic.GetComponent<CarLogicC>().ridingThroughDirt || this.carLogic.GetComponent<CarLogicC>().ridingThroughGrass)
			{
				this.skidSmoke.GetComponent<ParticleEmitter>().emit = false;
				return;
			}
			if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
			{
				this.skidSmoke.GetComponent<ParticleEmitter>().emit = true;
			}
			else
			{
				this.skidWetSmoke.GetComponent<ParticleEmitter>().emit = true;
			}
			this.SkidMesh();
		}
		else
		{
			if (this.carLogic.GetComponent<CarLogicC>().rainLvl == 0)
			{
				this.skidSmoke.GetComponent<ParticleEmitter>().emit = false;
			}
			else
			{
				this.skidWetSmoke.GetComponent<ParticleEmitter>().emit = false;
			}
			this.skidding = 0;
		}
	}

	// Token: 0x06000D56 RID: 3414 RVA: 0x00130F8C File Offset: 0x0012F38C
	public void SkidMesh()
	{
		WheelHit wheelHit;
		base.transform.GetComponent<WheelCollider>().GetGroundHit(out wheelHit);
		GameObject gameObject = new GameObject("Mark");
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		Mesh mesh = new Mesh();
		Vector3[] array = new Vector3[4];
		int[] triangles = new int[6];
		if (this.skidding == 0)
		{
			array[0] = wheelHit.point + Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z) * new Vector3(this.markWidth, 0.01f, 0f);
			array[1] = wheelHit.point + Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z) * new Vector3(-this.markWidth, 0.01f, 0f);
			array[2] = wheelHit.point + Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z) * new Vector3(-this.markWidth, 0.01f, 0f);
			array[3] = wheelHit.point + Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z) * new Vector3(this.markWidth, 0.01f, 0f);
			this.lastPos[0] = array[2];
			this.lastPos[1] = array[3];
			this.skidding = 1;
		}
		else
		{
			array[1] = this.lastPos[0];
			array[0] = this.lastPos[1];
			array[2] = wheelHit.point + Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z) * new Vector3(-this.markWidth, 0.01f, 0f);
			array[3] = wheelHit.point + Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y, base.transform.eulerAngles.z) * new Vector3(this.markWidth, 0.01f, 0f);
			this.lastPos[0] = array[2];
			this.lastPos[1] = array[3];
		}
		triangles = new int[]
		{
			0,
			1,
			2,
			2,
			3,
			0
		};
		mesh.vertices = array;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		mesh.uv = new Vector2[]
		{
			new Vector2(1f, 0f),
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f)
		};
		meshFilter.mesh = mesh;
		gameObject.GetComponent<Renderer>().material = this.skidMaterial;
		gameObject.AddComponent<DestroyTimerScriptC>();
	}

	// Token: 0x040011D0 RID: 4560
	public bool isAmbientControlTyre;

	// Token: 0x040011D1 RID: 4561
	private GameObject _camera;

	// Token: 0x040011D2 RID: 4562
	private GameObject carLogic;

	// Token: 0x040011D3 RID: 4563
	private float currentFrictionValue;

	// Token: 0x040011D4 RID: 4564
	public float skidAt = 1.5f;

	// Token: 0x040011D5 RID: 4565
	public float soundEmition = 15f;

	// Token: 0x040011D6 RID: 4566
	private float soundWait;

	// Token: 0x040011D7 RID: 4567
	public GameObject skidSound;

	// Token: 0x040011D8 RID: 4568
	public GameObject skidWetSound;

	// Token: 0x040011D9 RID: 4569
	public GameObject skidDirtSound;

	// Token: 0x040011DA RID: 4570
	public GameObject skidSmoke;

	// Token: 0x040011DB RID: 4571
	public GameObject skidWetSmoke;

	// Token: 0x040011DC RID: 4572
	public GameObject skidMudSmoke;

	// Token: 0x040011DD RID: 4573
	public GameObject skidGrassSmoke;

	// Token: 0x040011DE RID: 4574
	public float smokeDepth = 0.4f;

	// Token: 0x040011DF RID: 4575
	public float markWidth = 0.2f;

	// Token: 0x040011E0 RID: 4576
	public bool startSkid;

	// Token: 0x040011E1 RID: 4577
	private int skidding;

	// Token: 0x040011E2 RID: 4578
	private Vector3[] lastPos = new Vector3[2];

	// Token: 0x040011E3 RID: 4579
	public Material skidMaterial;

	// Token: 0x040011E4 RID: 4580
	private bool mudSmokeParticlesPlaying;

	// Token: 0x040011E5 RID: 4581
	private bool grassSmokeParticlesPlaying;

	// Token: 0x040011E6 RID: 4582
	public bool debugMe;

	// Token: 0x040011E7 RID: 4583
	private float passTime;
}
