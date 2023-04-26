using System;
using UnityEngine;

// Token: 0x020000CE RID: 206
public class MapRelayC : MonoBehaviour
{
	// Token: 0x0600081B RID: 2075 RVA: 0x000A952C File Offset: 0x000A792C
	private void Start()
	{
		if (Application.platform == RuntimePlatform.XboxOne && this.xboxDis)
		{
			base.transform.position = Vector3.up * 90000f;
		}
		this._camera = Camera.main.gameObject;
		this.director = GameObject.FindWithTag("Director");
		if (this.routeNumber == 1)
		{
			base.GetComponent<TextMesh>().text = Language.Get("ui_pickup_70", "Inspector_UI");
		}
		else if (this.routeNumber == 2)
		{
			base.GetComponent<TextMesh>().text = Language.Get("ui_pickup_80", "Inspector_UI");
		}
		else if (this.routeNumber == 3)
		{
			base.GetComponent<TextMesh>().text = Language.Get("ui_pickup_81", "Inspector_UI");
		}
		if (this.routeNumber < 5)
		{
			this.SetRouteToMap();
		}
		if (this.routeNumber < 5)
		{
			this.SetReturnRouteToMap();
		}
		if (this.routeNumber == 8)
		{
			if (this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
			{
				base.GetComponent<TextMesh>().text = Language.Get("ui_headback_02", "Inspector_UI");
			}
			else
			{
				base.GetComponent<TextMesh>().text = Language.Get("ui_headback_01", "Inspector_UI");
			}
		}
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x000A9684 File Offset: 0x000A7A84
	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && this.highlighted && this.routeNumber < 5)
		{
			this.LockMap();
			this.highlighted = false;
		}
		else if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && this.highlighted && this.routeNumber < 5)
		{
			this.LockMap();
			this.highlighted = false;
		}
		else if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) && this.highlighted && this.routeNumber < 5)
		{
			this.LockMap();
			this.highlighted = false;
		}
		else
		{
			if (Input.GetButtonDown("Fire1") && this.highlighted && this.routeNumber == 5)
			{
				this.map.GetComponent<MapLogicC>().StartCoroutine("RestartPageGo");
				this.OnMouseExit();
				this.highlighted = false;
				return;
			}
			if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && this.highlighted && this.routeNumber == 5)
			{
				this.map.GetComponent<MapLogicC>().StartCoroutine("RestartPageGo");
				this.OnMouseExit();
				this.highlighted = false;
				return;
			}
			if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) && this.highlighted && this.routeNumber == 5)
			{
				this.map.GetComponent<MapLogicC>().StartCoroutine("RestartPageGo");
				this.OnMouseExit();
				this.highlighted = false;
				return;
			}
			if (Input.GetButtonDown("Fire1") && this.highlighted && this.routeNumber == 6)
			{
				MainMenuC.Global.RestartDemo();
				this.highlighted = false;
				return;
			}
			if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && this.highlighted && this.routeNumber == 6)
			{
				MainMenuC.Global.RestartDemo();
				this.highlighted = false;
				return;
			}
			if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) && this.highlighted && this.routeNumber == 6)
			{
				MainMenuC.Global.RestartDemo();
				this.highlighted = false;
				return;
			}
			if (Input.GetButtonDown("Fire1") && this.highlighted && this.routeNumber == 7)
			{
				this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackHover", false);
				this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackGo", true);
				this.map.GetComponent<MapLogicC>().StartCoroutine("Page0Go");
				base.StartCoroutine("StopPageLeftTurn");
				this.highlighted = false;
				return;
			}
			if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && this.highlighted && this.routeNumber == 7)
			{
				this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackHover", false);
				this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackGo", true);
				this.map.GetComponent<MapLogicC>().StartCoroutine("Page0Go");
				base.StartCoroutine("StopPageLeftTurn");
				this.highlighted = false;
				return;
			}
			if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) && this.highlighted && this.routeNumber == 7)
			{
				this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackHover", false);
				this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackGo", true);
				this.map.GetComponent<MapLogicC>().StartCoroutine("Page0Go");
				base.StartCoroutine("StopPageLeftTurn");
				this.highlighted = false;
				return;
			}
			if (Input.GetButtonDown("Fire1") && this.highlighted && this.routeNumber == 8)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeGenerated)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6 && this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<DirectorC>().isSatAtBorder)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.routeNumber == 8)
				{
					if (this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
					{
						base.GetComponent<TextMesh>().text = Language.Get("ui_headback_01", "Inspector_UI");
						this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome = false;
						this.map.GetComponent<MapLogicC>().ChangeMap2();
					}
					else
					{
						base.GetComponent<TextMesh>().text = Language.Get("ui_headback_02", "Inspector_UI");
						this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome = true;
						this.map.GetComponent<MapLogicC>().ChangeMap1();
					}
				}
			}
			else if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[16]) && this.highlighted && this.routeNumber == 8)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeGenerated)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6 && this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<DirectorC>().isSatAtBorder)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.routeNumber == 8)
				{
					if (this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
					{
						base.GetComponent<TextMesh>().text = Language.Get("ui_headback_01", "Inspector_UI");
						this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome = false;
						this.map.GetComponent<MapLogicC>().ChangeMap2();
					}
					else
					{
						base.GetComponent<TextMesh>().text = Language.Get("ui_headback_02", "Inspector_UI");
						this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome = true;
						this.map.GetComponent<MapLogicC>().ChangeMap1();
					}
				}
			}
			else if (Input.GetKeyDown(MainMenuC.Global.assignedInputStrings[17]) && this.highlighted && this.routeNumber == 8)
			{
				if (this.director.GetComponent<RouteGeneratorC>().routeGenerated)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6 && this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
				{
					this.map.GetComponent<MapLogicC>().PlayError();
					return;
				}
				if (this.routeNumber == 8)
				{
					if (this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome)
					{
						base.GetComponent<TextMesh>().text = Language.Get("ui_headback_01", "Inspector_UI");
						this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome = false;
						this.map.GetComponent<MapLogicC>().ChangeMap2();
					}
					else
					{
						base.GetComponent<TextMesh>().text = Language.Get("ui_headback_02", "Inspector_UI");
						this.director.GetComponent<RouteGeneratorC>().drivingTowardsHome = true;
						this.map.GetComponent<MapLogicC>().ChangeMap1();
					}
				}
			}
		}
		if (this.redCross == null)
		{
			return;
		}
		if (this.mapIsLocked && !this.selectedRoute)
		{
			if ((double)this.cutOffValue > 0.1)
			{
				this.cutOffValue -= Time.deltaTime;
				this.redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", this.cutOffValue);
			}
			if ((double)this.cutOffValue < 0.09)
			{
				this.redCross.GetComponent<Renderer>().material.SetFloat("_Cutoff", 0.095f);
			}
		}
		else if (this.mapIsLocked && this.selectedRoute)
		{
			if ((double)this.cutOffValue >= 0.1)
			{
				this.cutOffValue -= Time.deltaTime;
				this.redCirc.GetComponent<Renderer>().material.SetFloat("_Cutoff", this.cutOffValue);
			}
			if ((double)this.cutOffValue < 0.1 && !this.loadRouteGo)
			{
				this.loadRouteGo = true;
				this.SpawnRoute();
			}
		}
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x000AA02C File Offset: 0x000A842C
	public void StopPageLeftTurn()
	{
		this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackHover", false);
		this.map.transform.GetChild(0).GetComponent<Animator>().SetBool("page2FoldBackGo", false);
		this.OnMouseExit();
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x000AA084 File Offset: 0x000A8484
	public void SetReturnRouteToMap()
	{
		int num = UnityEngine.Random.Range(0, 3);
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			if (this.distance == 3)
			{
				this.returnRoute = this.gerRoute3[num];
			}
			if (this.distance == 4)
			{
				this.returnRoute = this.gerRoute4[num];
			}
			if (this.distance == 5)
			{
				this.returnRoute = this.gerRoute5[num];
			}
			if (this.distance == 6)
			{
				this.returnRoute = this.gerRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			if (this.distance == 3)
			{
				this.returnRoute = this.csfrRoute3[num];
			}
			if (this.distance == 4)
			{
				this.returnRoute = this.csfrRoute4[num];
			}
			if (this.distance == 5)
			{
				this.returnRoute = this.csfrRoute5[num];
			}
			if (this.distance == 6)
			{
				this.returnRoute = this.csfrRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			if (this.distance == 3)
			{
				this.returnRoute = this.hunRoute3[num];
			}
			if (this.distance == 4)
			{
				this.returnRoute = this.hunRoute4[num];
			}
			if (this.distance == 5)
			{
				this.returnRoute = this.hunRoute5[num];
			}
			if (this.distance == 6)
			{
				this.returnRoute = this.hunRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			if (this.distance == 3)
			{
				this.returnRoute = this.yugoRoute3[num];
			}
			if (this.distance == 4)
			{
				this.returnRoute = this.yugoRoute4[num];
			}
			if (this.distance == 5)
			{
				this.returnRoute = this.yugoRoute5[num];
			}
			if (this.distance == 6)
			{
				this.returnRoute = this.yugoRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			if (this.distance == 3)
			{
				this.returnRoute = this.bulRoute3[num];
			}
			if (this.distance == 4)
			{
				this.returnRoute = this.bulRoute4[num];
			}
			if (this.distance == 5)
			{
				this.returnRoute = this.bulRoute5[num];
			}
			if (this.distance == 6)
			{
				this.returnRoute = this.bulRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			if (this.distance == 3)
			{
				this.returnRoute = this.turkRoute3[num];
			}
			if (this.distance == 4)
			{
				this.returnRoute = this.turkRoute4[num];
			}
			if (this.distance == 5)
			{
				this.returnRoute = this.turkRoute5[num];
			}
			if (this.distance == 6)
			{
				this.returnRoute = this.turkRoute6[num];
			}
		}
		this.SpawnMapRoute2();
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x000AA3B4 File Offset: 0x000A87B4
	public void SetRouteToMap()
	{
		int num = UnityEngine.Random.Range(0, 3);
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			if (this.distance == 3)
			{
				this.route = this.gerRoute3[num];
			}
			if (this.distance == 4)
			{
				this.route = this.gerRoute4[num];
			}
			if (this.distance == 5)
			{
				this.route = this.gerRoute5[num];
			}
			if (this.distance == 6)
			{
				this.route = this.gerRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 1)
		{
			if (this.distance == 3)
			{
				this.route = this.csfrRoute3[num];
			}
			if (this.distance == 4)
			{
				this.route = this.csfrRoute4[num];
			}
			if (this.distance == 5)
			{
				this.route = this.csfrRoute5[num];
			}
			if (this.distance == 6)
			{
				this.route = this.csfrRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 2)
		{
			if (this.distance == 3)
			{
				this.route = this.hunRoute3[num];
			}
			if (this.distance == 4)
			{
				this.route = this.hunRoute4[num];
			}
			if (this.distance == 5)
			{
				this.route = this.hunRoute5[num];
			}
			if (this.distance == 6)
			{
				this.route = this.hunRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 3)
		{
			if (this.distance == 3)
			{
				this.route = this.yugoRoute3[num];
			}
			if (this.distance == 4)
			{
				this.route = this.yugoRoute4[num];
			}
			if (this.distance == 5)
			{
				this.route = this.yugoRoute5[num];
			}
			if (this.distance == 6)
			{
				this.route = this.yugoRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 4)
		{
			if (this.distance == 3)
			{
				this.route = this.bulRoute3[num];
			}
			if (this.distance == 4)
			{
				this.route = this.bulRoute4[num];
			}
			if (this.distance == 5)
			{
				this.route = this.bulRoute5[num];
			}
			if (this.distance == 6)
			{
				this.route = this.bulRoute6[num];
			}
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 5)
		{
			if (this.distance == 3)
			{
				this.route = this.turkRoute3[num];
			}
			if (this.distance == 4)
			{
				this.route = this.turkRoute4[num];
			}
			if (this.distance == 5)
			{
				this.route = this.turkRoute5[num];
			}
			if (this.distance == 6)
			{
				this.route = this.turkRoute6[num];
			}
		}
		this.SpawnMapRoute();
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x000AA6E4 File Offset: 0x000A8AE4
	public void SpawnMapRoute()
	{
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 6)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.route);
		gameObject.transform.parent = this.map.transform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.transform.localRotation = Quaternion.identity;
		this.routeHolder = gameObject;
		if (this.spawnedRoute != null)
		{
			UnityEngine.Object.Destroy(this.spawnedRoute);
		}
		this.spawnedRoute = gameObject;
		this.spawnedRoute.SetActive(false);
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x000AA7C0 File Offset: 0x000A8BC0
	public void SpawnMapRoute2()
	{
		if (this.director == null)
		{
			this.director = GameObject.FindWithTag("Director");
		}
		if (this.director.GetComponent<RouteGeneratorC>().routeLevel == 0)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.returnRoute);
		gameObject.transform.parent = this.map.transform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.transform.localRotation = Quaternion.identity;
		this.routeHolder2 = gameObject;
		gameObject.SetActive(false);
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x000AA874 File Offset: 0x000A8C74
	public void SetText()
	{
		int num = this.distance * 70;
		this.distanceObj.GetComponent<TextMesh>().text = num.ToString() + " " + Language.Get("ui_kilomet_01", "Inspector_UI");
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x000AA8C4 File Offset: 0x000A8CC4
	public void EmptyText()
	{
		this.distanceObj.GetComponent<TextMesh>().text = Language.Get("ui_endline_01", "Inspector_UI");
		this.fuelIcon.SetActive(false);
		this.weatherIcon.SetActive(false);
		this.roadConditionIcon.SetActive(false);
		base.GetComponent<BoxCollider>().enabled = false;
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x000AA920 File Offset: 0x000A8D20
	public void ActiveText()
	{
		this.fuelIcon.SetActive(true);
		this.weatherIcon.SetActive(true);
		this.roadConditionIcon.SetActive(true);
		base.GetComponent<BoxCollider>().enabled = true;
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x000AA954 File Offset: 0x000A8D54
	public void SpawnRoute()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		gameObject.GetComponent<RouteGeneratorC>().routeChosenLength = this.distance;
		gameObject.GetComponent<RouteGeneratorC>().uDayCycle.GetComponent<DNC_DayNight>().isMorning = false;
		TweenAlpha.Begin(this.loadingText, 0.01f, 1f);
		GameObject.FindWithTag("Uncle").GetComponent<UncleLogicC>().StartCoroutine("OpenHomeGate");
		if (this.routeNumber == 1)
		{
			gameObject.GetComponent<RouteGeneratorC>().SpawnRoute1();
			TweenAlpha.Begin(this.loadingText, 0.5f, 0f);
			return;
		}
		if (this.routeNumber == 2)
		{
			gameObject.GetComponent<RouteGeneratorC>().SpawnRoute2();
			TweenAlpha.Begin(this.loadingText, 0.5f, 0f);
			return;
		}
		if (this.routeNumber == 3)
		{
			gameObject.GetComponent<RouteGeneratorC>().SpawnRoute3();
			TweenAlpha.Begin(this.loadingText, 0.5f, 0f);
			return;
		}
		if (this.routeNumber == 4)
		{
			gameObject.GetComponent<RouteGeneratorC>().SpawnRoute4();
			TweenAlpha.Begin(this.loadingText, 0.5f, 0f);
			return;
		}
		if (this.routeNumber == 5)
		{
			return;
		}
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x000AAA88 File Offset: 0x000A8E88
	public void LockMap()
	{
		GameObject gameObject = GameObject.FindWithTag("Director");
		GameObject gameObject2 = GameObject.FindWithTag("Uncle");
		if (!gameObject2.GetComponent<Scene1_LogicC>().hasGivenRouteSelectedTutorial)
		{
			gameObject2.GetComponent<Scene1_LogicC>().StartCoroutine("RouteSelectedTutorial");
		}
		gameObject.GetComponent<RouteGeneratorC>().routeGenerated = true;
		gameObject.GetComponent<RouteGeneratorC>().mapText1.GetComponent<MapRelayC>().mapIsLocked = true;
		gameObject.GetComponent<RouteGeneratorC>().mapText1.GetComponent<MapRelayC>().highlighted = false;
		gameObject.GetComponent<RouteGeneratorC>().mapText2.GetComponent<MapRelayC>().mapIsLocked = true;
		gameObject.GetComponent<RouteGeneratorC>().mapText2.GetComponent<MapRelayC>().highlighted = false;
		gameObject.GetComponent<RouteGeneratorC>().mapText3.GetComponent<MapRelayC>().mapIsLocked = true;
		gameObject.GetComponent<RouteGeneratorC>().mapText3.GetComponent<MapRelayC>().highlighted = false;
		base.gameObject.GetComponent<TextMesh>().color = new Color(15f, 15f, 15f);
		this.selectedRoute = true;
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x000AAB88 File Offset: 0x000A8F88
	public void OnMouseEnter()
	{
		if (this.mapIsLocked && this.routeNumber < 5)
		{
			return;
		}
		if (!this.routeDiscovered && this.routeNumber == 4)
		{
			return;
		}
		if (this.routeNumber == 5)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page1FoldHover", true);
		}
		if (this.spawnedRoute != null)
		{
			this.spawnedRoute.SetActive(true);
		}
		base.gameObject.GetComponent<TextMesh>().color = new Color(15f, 15f, 15f);
		this.highlighted = true;
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x000AAC30 File Offset: 0x000A9030
	public void OnMouseExit()
	{
		if (this.mapIsLocked && this.routeNumber < 5)
		{
			return;
		}
		if (this.routeNumber == 5)
		{
			this.mapAnim.GetComponent<Animator>().SetBool("page1FoldHover", false);
		}
		if (this.spawnedRoute != null)
		{
			this.spawnedRoute.SetActive(false);
		}
		base.gameObject.GetComponent<TextMesh>().color = Color.black;
		this.highlighted = false;
	}

	// Token: 0x04000A95 RID: 2709
	private GameObject _camera;

	// Token: 0x04000A96 RID: 2710
	public GameObject map;

	// Token: 0x04000A97 RID: 2711
	public GameObject director;

	// Token: 0x04000A98 RID: 2712
	public GameObject loadingText;

	// Token: 0x04000A99 RID: 2713
	public int routeNumber;

	// Token: 0x04000A9A RID: 2714
	[HideInInspector]
	public bool routeDiscovered;

	// Token: 0x04000A9B RID: 2715
	public bool isAvailable;

	// Token: 0x04000A9C RID: 2716
	public bool featuresPetrolStation;

	// Token: 0x04000A9D RID: 2717
	public bool highlighted;

	// Token: 0x04000A9E RID: 2718
	public GameObject distanceObj;

	// Token: 0x04000A9F RID: 2719
	public int distance;

	// Token: 0x04000AA0 RID: 2720
	public GameObject fuelIcon;

	// Token: 0x04000AA1 RID: 2721
	public GameObject weatherIcon;

	// Token: 0x04000AA2 RID: 2722
	public GameObject roadConditionIcon;

	// Token: 0x04000AA3 RID: 2723
	public Texture[] weatherTextures = new Texture[0];

	// Token: 0x04000AA4 RID: 2724
	public GameObject[] gerRoute6 = new GameObject[4];

	// Token: 0x04000AA5 RID: 2725
	public GameObject[] gerRoute5 = new GameObject[4];

	// Token: 0x04000AA6 RID: 2726
	public GameObject[] gerRoute4 = new GameObject[4];

	// Token: 0x04000AA7 RID: 2727
	public GameObject[] gerRoute3 = new GameObject[4];

	// Token: 0x04000AA8 RID: 2728
	public GameObject[] csfrRoute6 = new GameObject[4];

	// Token: 0x04000AA9 RID: 2729
	public GameObject[] csfrRoute5 = new GameObject[4];

	// Token: 0x04000AAA RID: 2730
	public GameObject[] csfrRoute4 = new GameObject[4];

	// Token: 0x04000AAB RID: 2731
	public GameObject[] csfrRoute3 = new GameObject[4];

	// Token: 0x04000AAC RID: 2732
	public GameObject[] hunRoute6 = new GameObject[4];

	// Token: 0x04000AAD RID: 2733
	public GameObject[] hunRoute5 = new GameObject[4];

	// Token: 0x04000AAE RID: 2734
	public GameObject[] hunRoute4 = new GameObject[4];

	// Token: 0x04000AAF RID: 2735
	public GameObject[] hunRoute3 = new GameObject[4];

	// Token: 0x04000AB0 RID: 2736
	public GameObject[] yugoRoute6 = new GameObject[4];

	// Token: 0x04000AB1 RID: 2737
	public GameObject[] yugoRoute5 = new GameObject[4];

	// Token: 0x04000AB2 RID: 2738
	public GameObject[] yugoRoute4 = new GameObject[4];

	// Token: 0x04000AB3 RID: 2739
	public GameObject[] yugoRoute3 = new GameObject[4];

	// Token: 0x04000AB4 RID: 2740
	public GameObject[] bulRoute6 = new GameObject[4];

	// Token: 0x04000AB5 RID: 2741
	public GameObject[] bulRoute5 = new GameObject[4];

	// Token: 0x04000AB6 RID: 2742
	public GameObject[] bulRoute4 = new GameObject[4];

	// Token: 0x04000AB7 RID: 2743
	public GameObject[] bulRoute3 = new GameObject[4];

	// Token: 0x04000AB8 RID: 2744
	public GameObject[] turkRoute6 = new GameObject[4];

	// Token: 0x04000AB9 RID: 2745
	public GameObject[] turkRoute5 = new GameObject[4];

	// Token: 0x04000ABA RID: 2746
	public GameObject[] turkRoute4 = new GameObject[4];

	// Token: 0x04000ABB RID: 2747
	public GameObject[] turkRoute3 = new GameObject[4];

	// Token: 0x04000ABC RID: 2748
	public GameObject route;

	// Token: 0x04000ABD RID: 2749
	public GameObject returnRoute;

	// Token: 0x04000ABE RID: 2750
	public GameObject spawnedRoute;

	// Token: 0x04000ABF RID: 2751
	public GameObject routeHolder;

	// Token: 0x04000AC0 RID: 2752
	public GameObject routeHolder2;

	// Token: 0x04000AC1 RID: 2753
	public GameObject redCross;

	// Token: 0x04000AC2 RID: 2754
	public GameObject redCirc;

	// Token: 0x04000AC3 RID: 2755
	public float cutOffValue = 1f;

	// Token: 0x04000AC4 RID: 2756
	public bool loadRouteGo;

	// Token: 0x04000AC5 RID: 2757
	public bool mapIsLocked;

	// Token: 0x04000AC6 RID: 2758
	public bool selectedRoute;

	// Token: 0x04000AC7 RID: 2759
	public GameObject mapAnim;

	// Token: 0x04000AC8 RID: 2760
	public bool xboxDis;

	// Token: 0x04000AC9 RID: 2761
	public bool imDebug;
}
