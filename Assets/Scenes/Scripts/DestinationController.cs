using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour {
    public GameObject PlayerGameObject;
    private PlayerMovement PlayerMovementScript;
    public float DistanceBetweenDestinations = 15.0f;
    public float DistanceAtLastDestination = 0.0f;

	// Use this for initialization
	void Start ()
    {
        PlayerMovementScript = PlayerGameObject.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(PlayerMovementScript.DistanceTravelled > DistanceAtLastDestination + DistanceBetweenDestinations)
        {
            //
        }
	}
}
