using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationController : MonoBehaviour {
    public GameObject PlayerGameObject;
    private PlayerMovement PlayerMovementScript;
    public float DistanceBetweenDestinations = 15.0f;
    public float DistanceAtLastDestination = 0.0f;
    public GameObject DestinationHome;
    public GameObject DestinationWork;
    public GameObject DestinationSocial;

    // Use this for initialization
    void Start ()
    {
        /*
        PlayerMovementScript = PlayerGameObject.GetComponent<PlayerMovement>();
        Destination workDestination = DestinationWork.GetComponent<Destination>();
        Destination socialDestination = DestinationSocial.GetComponent<Destination>();
        Destination homeDestination = DestinationHome.GetComponent<Destination>();
        */
    }

    // Update is called once per frame
    void Update ()
    {
        /*
		if(PlayerMovementScript.DistanceTravelled > DistanceAtLastDestination + DistanceBetweenDestinations)
        {
            //
        }
        */
	}
}
