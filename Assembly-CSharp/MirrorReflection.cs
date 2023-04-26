using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000D0 RID: 208
public class MirrorReflection : MonoBehaviour
{
	// Token: 0x0600082E RID: 2094 RVA: 0x000AAF38 File Offset: 0x000A9338
	public void OnWillRenderObject()
	{
		int num = MirrorReflection.qualityValue;
		this.frameCount = 6;
		if (num == 1)
		{
			this.m_TextureSize = 128;
			this.frameCount = 5;
		}
		if (num == 2)
		{
			this.m_TextureSize = 256;
			this.frameCount = 4;
		}
		if (num == 3)
		{
			this.m_TextureSize = 512;
			this.frameCount = 2;
		}
		if (num == 4)
		{
			this.m_TextureSize = 1024;
			this.frameCount = 1;
		}
		if (!base.enabled || !base.GetComponent<Renderer>() || !base.GetComponent<Renderer>().sharedMaterial || !base.GetComponent<Renderer>().enabled || Time.frameCount % this.frameCount != 0)
		{
			return;
		}
		Camera current = Camera.current;
		if (!current)
		{
			return;
		}
		if (MirrorReflection.s_InsideRendering)
		{
			return;
		}
		MirrorReflection.s_InsideRendering = true;
		Camera camera;
		if (this.m_ReflectionCameras.ContainsKey(current))
		{
			camera = (this.m_ReflectionCameras[current] as Camera);
		}
		else
		{
			this.CreateMirrorObjects(current, out camera);
			this.UpdateCameraModes(current, camera);
			camera.farClipPlane = 4f;
			this.m_ReflectionCameras[current] = camera;
			this.ReflectionCamera = camera;
		}
		Vector3 position = base.transform.position;
		Vector3 up = base.transform.up;
		int pixelLightCount = QualitySettings.pixelLightCount;
		if (this.m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = 0;
		}
		float w = -Vector3.Dot(up, position) - this.m_ClipPlaneOffset;
		Vector4 plane = new Vector4(up.x, up.y, up.z, w);
		Matrix4x4 zero = Matrix4x4.zero;
		MirrorReflection.CalculateReflectionMatrix(ref zero, plane);
		Vector3 position2 = current.transform.position;
		Vector3 position3 = zero.MultiplyPoint(position2);
		camera.worldToCameraMatrix = current.worldToCameraMatrix * zero;
		Vector4 clipPlane = this.CameraSpacePlane(camera, position, up, 1f);
		camera.projectionMatrix = current.CalculateObliqueMatrix(clipPlane);
		float[] array = new float[32];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = this.m_FarClipDistance;
		}
		camera.layerCullDistances = array;
		camera.layerCullSpherical = true;
		camera.cullingMask = (-17 & this.m_ReflectLayers.value);
		Matrix4x4 projectionMatrix = current.projectionMatrix;
		camera.projectionMatrix = projectionMatrix;
		camera.cullingMask = (-17 & this.m_ReflectLayers.value);
		camera.targetTexture = this.m_ReflectionTexture;
		GL.SetRevertBackfacing(true);
		camera.transform.position = position3;
		Vector3 eulerAngles = current.transform.eulerAngles;
		camera.transform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
		camera.Render();
		camera.transform.position = position2;
		GL.SetRevertBackfacing(false);
		Material[] sharedMaterials = base.GetComponent<Renderer>().sharedMaterials;
		foreach (Material material in sharedMaterials)
		{
			if (material.HasProperty("_ReflectionTex"))
			{
				material.SetTexture("_ReflectionTex", this.m_ReflectionTexture);
			}
		}
		Matrix4x4 lhs = Matrix4x4.TRS(new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, new Vector3(0.5f, 0.5f, 0.5f));
		Vector3 lossyScale = base.transform.lossyScale;
		Matrix4x4 matrix4x = base.transform.localToWorldMatrix * Matrix4x4.Scale(new Vector3(1f / lossyScale.x, 1f / lossyScale.y, 1f / lossyScale.z));
		matrix4x = lhs * current.projectionMatrix * current.worldToCameraMatrix * matrix4x;
		foreach (Material material2 in sharedMaterials)
		{
			material2.SetMatrix("_ProjMatrix", matrix4x);
		}
		if (this.m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = pixelLightCount;
		}
		MirrorReflection.s_InsideRendering = false;
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x000AB360 File Offset: 0x000A9760
	private void OnDisable()
	{
		if (this.m_ReflectionTexture)
		{
			UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
			this.m_ReflectionTexture = null;
		}
		IDictionaryEnumerator enumerator = this.m_ReflectionCameras.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				UnityEngine.Object.DestroyImmediate(((Camera)((DictionaryEntry)obj).Value).gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		this.m_ReflectionCameras.Clear();
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x000AB404 File Offset: 0x000A9804
	private void UpdateCameraModes(Camera src, Camera dest)
	{
		if (dest == null)
		{
			return;
		}
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		if (src.clearFlags == CameraClearFlags.Skybox)
		{
			Skybox skybox = src.GetComponent(typeof(Skybox)) as Skybox;
			Skybox skybox2 = dest.GetComponent(typeof(Skybox)) as Skybox;
			if (!skybox || !skybox.material)
			{
				skybox2.enabled = false;
			}
			else
			{
				skybox2.enabled = true;
				skybox2.material = skybox.material;
			}
		}
		dest.farClipPlane = src.farClipPlane;
		dest.nearClipPlane = src.nearClipPlane;
		dest.orthographic = src.orthographic;
		dest.fieldOfView = src.fieldOfView;
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
		dest.useOcclusionCulling = false;
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x000AB4F8 File Offset: 0x000A98F8
	private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
	{
		reflectionCamera = null;
		if (!this.m_ReflectionTexture || this.m_OldReflectionTextureSize != this.m_TextureSize)
		{
			if (this.m_ReflectionTexture)
			{
				UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
			}
			this.m_ReflectionTexture = new RenderTexture(this.m_TextureSize, this.m_TextureSize, 16);
			this.m_ReflectionTexture.name = "__MirrorReflection" + base.GetInstanceID();
			this.m_ReflectionTexture.isPowerOfTwo = true;
			this.m_ReflectionTexture.hideFlags = HideFlags.DontSave;
			this.m_OldReflectionTextureSize = this.m_TextureSize;
		}
		reflectionCamera = (this.m_ReflectionCameras[currentCamera] as Camera);
		if (!reflectionCamera)
		{
			GameObject gameObject = new GameObject(string.Concat(new object[]
			{
				"Mirror Refl Camera id",
				base.GetInstanceID(),
				" for ",
				currentCamera.GetInstanceID()
			}), new Type[]
			{
				typeof(Camera),
				typeof(Skybox)
			});
			reflectionCamera = gameObject.GetComponent<Camera>();
			reflectionCamera.GetComponent<Camera>().fieldOfView += 10f;
			reflectionCamera.enabled = false;
			reflectionCamera.transform.position = base.transform.position;
			reflectionCamera.transform.rotation = base.transform.rotation;
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			this.m_ReflectionCameras[currentCamera] = reflectionCamera;
		}
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x000AB68A File Offset: 0x000A9A8A
	private static float sgn(float a)
	{
		if (a > 0f)
		{
			return 1f;
		}
		if (a < 0f)
		{
			return -1f;
		}
		return 0f;
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x000AB6B4 File Offset: 0x000A9AB4
	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Vector3 point = pos + normal * this.m_ClipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x000AB720 File Offset: 0x000A9B20
	private static void CalculateObliqueMatrix(ref Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 b = projection.inverse * new Vector4(MirrorReflection.sgn(clipPlane.x), MirrorReflection.sgn(clipPlane.y), 1f, 1f);
		Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
		projection[2] = vector.x - projection[3];
		projection[6] = vector.y - projection[7];
		projection[10] = vector.z - projection[11];
		projection[14] = vector.w - projection[15];
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x000AB7D0 File Offset: 0x000A9BD0
	private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
		reflectionMat.m01 = -2f * plane[0] * plane[1];
		reflectionMat.m02 = -2f * plane[0] * plane[2];
		reflectionMat.m03 = -2f * plane[3] * plane[0];
		reflectionMat.m10 = -2f * plane[1] * plane[0];
		reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
		reflectionMat.m12 = -2f * plane[1] * plane[2];
		reflectionMat.m13 = -2f * plane[3] * plane[1];
		reflectionMat.m20 = -2f * plane[2] * plane[0];
		reflectionMat.m21 = -2f * plane[2] * plane[1];
		reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
		reflectionMat.m23 = -2f * plane[3] * plane[2];
		reflectionMat.m30 = 0f;
		reflectionMat.m31 = 0f;
		reflectionMat.m32 = 0f;
		reflectionMat.m33 = 1f;
	}

	// Token: 0x04000AD0 RID: 2768
	public static int qualityValue;

	// Token: 0x04000AD1 RID: 2769
	public Camera ReflectionCamera;

	// Token: 0x04000AD2 RID: 2770
	public bool m_DisablePixelLights = true;

	// Token: 0x04000AD3 RID: 2771
	public int m_TextureSize = 1024;

	// Token: 0x04000AD4 RID: 2772
	public float m_ClipPlaneOffset = 0.07f;

	// Token: 0x04000AD5 RID: 2773
	public float m_FarClipDistance = 50f;

	// Token: 0x04000AD6 RID: 2774
	public LayerMask m_ReflectLayers = -1;

	// Token: 0x04000AD7 RID: 2775
	private Hashtable m_ReflectionCameras = new Hashtable();

	// Token: 0x04000AD8 RID: 2776
	private RenderTexture m_ReflectionTexture;

	// Token: 0x04000AD9 RID: 2777
	private int m_OldReflectionTextureSize;

	// Token: 0x04000ADA RID: 2778
	private static bool s_InsideRendering;

	// Token: 0x04000ADB RID: 2779
	private int frameCount = 1;
}
