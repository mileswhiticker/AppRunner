﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingAppController : MonoBehaviour {

	private PlayerMovement pm;
	public GameObject player;
	public GameObject flyingApp;
	public List<GameObject> flyingApps = new List<GameObject>();
	public List<GameObject> flyingAppsToRemove = new List<GameObject>();

    public SpriteRenderer spriteRenderer;
	public Sprite app1, app2;

    public float AppFlySpeed = 0.0f;
	
	public List<string> apps = new List<string>();

	// Use this for initialization
	void Start () {
		apps.Add("AppAirbnb");
		apps.Add("AppAirbnb2");
		apps.Add("AppAirtasker");
		apps.Add("AppAirtasker2");
		apps.Add("AppAmazon");
		apps.Add("AppCandycrush");
		apps.Add("AppEbay");
		apps.Add("AppFacebook");
		apps.Add("AppFiverr");
		apps.Add("AppFiverr2");
		apps.Add("AppGithub");
		apps.Add("AppGoogledocs");
		apps.Add("AppInstagram");
		apps.Add("AppMeditation");
		apps.Add("AppMicrosoft");
		apps.Add("AppMinecraft");
		
		pm = player.GetComponent<PlayerMovement>();
        AppFlySpeed = pm.PlayerRunRate;
        // Launch an app 1 seconds after starting, then every 3 seconds after that
        InvokeRepeating("CreateApp", 1.0f, 2.0f);
        apps.Add("AppAirbnb");
        apps.Add("AppAirbnb2");
        apps.Add("AppAmazon");
    }
	
	// Update is called once per frame
	void Update () {
		// Move all flying apps in the list closer to the player
		foreach (GameObject flyingApp in flyingApps)
		{
			flyingApp.transform.position = new Vector3(flyingApp.transform.position.x, flyingApp.transform.position.y, flyingApp.transform.position.z - 6 * Time.deltaTime * AppFlySpeed);
			
			if (flyingApp.transform.position.z < -6.0f)
			{
				// Debug.Log("Destroying");
				flyingAppsToRemove.Add(flyingApp);
			}
		}
		
		foreach (GameObject flyingAppToRemove in flyingAppsToRemove)
		{
			flyingApps.Remove(flyingAppToRemove);
			Destroy(flyingAppToRemove);
		}
	}

	// Spawn a new flying app and add it to the list
	void CreateApp()
    {
        int index = (int)Mathf.Round(Random.value * (apps.Count - 1));
        //Debug.Log("index: " + index);

        string chosenPrefab = apps[index];
        //Debug.Log("chosenPrefab: " + chosenPrefab);
        flyingApp = Instantiate(Resources.Load(chosenPrefab)) as GameObject;
		// Material flyingAppMaterial = flyingApp.GetComponent<Renderer>().AddComponent(typeof(Material)) as Material;
		// Material flyingAppMaterial = flyingApp.GetComponent<Material>();
		
		//flyingApp.GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>("Sprites/Materials/AirBnB");
		// flyingAppMaterial.mainTexture = Resources.Load<Texture>("Sprites/Strava");
		
		// flyingAppMaterial.SetTexture("_MainTex", app1Texture);
		// flyingApp.AddComponent<SpriteRenderer>();
		// spriteRenderer = flyingApp.GetComponent<SpriteRenderer>();
		// spriteRenderer.sprite = app1;
		flyingApp.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 0.85f, 20f);
        //flyingApp.GetComponent<Renderer>().materials[0].SetTexture("_MainText", Resources.Load<Texture>("Sprites/testtexture"));

        flyingApps.Add(flyingApp);
    }
	
	// void function WaitAndDestroy() {
	// 	yield WaitForSeconds(3);
	// 	Destroy(this);
	// }
}
