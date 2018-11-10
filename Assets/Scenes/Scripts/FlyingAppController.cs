using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAppController : MonoBehaviour {

	public GameObject flyingApp;
	public List<GameObject> allFlyingApps = new List<GameObject()>();

	// Use this for initialization
	void Start () {
		// Launch an app 3 seconds after starting, then every 3 seconds after that
		InvokeRepeating("CreateApp", 3.0f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void CreateApp()
    {
		Debug.Log("Launch an app");
		flyingApp = Instantiate(Resources.Load("FlyingAppPrefab")) as GameObject;
		allFlyingApps.Add(flyingApp);
    }
}
