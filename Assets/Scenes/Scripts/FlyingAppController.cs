using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAppController : MonoBehaviour {

	public GameObject flyingApp;
	public List<GameObject> flyingApps = new List<GameObject>();

	// Use this for initialization
	void Start () {
		// Launch an app 1 seconds after starting, then every 3 seconds after that
		InvokeRepeating("CreateApp", 1.0f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// Move all flying apps in the list closer to the player
		foreach (GameObject flyingApp in flyingApps)
		{
			flyingApp.transform.position = new Vector3(flyingApp.transform.position.x, flyingApp.transform.position.y, flyingApp.transform.position.z - Time.deltaTime * 1.5f);
		}
	}

	// Spawn a new flying app and add it to the list
	void CreateApp()
    {
		flyingApp = Instantiate(Resources.Load("flyingAppPrefab")) as GameObject;
		flyingApp.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 0.85f, 3f);
		flyingApps.Add(flyingApp);
    }
}
