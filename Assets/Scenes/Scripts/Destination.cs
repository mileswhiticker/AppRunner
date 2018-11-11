using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject PlayerGameObject;
    private PlayerMovement PlayerMovementScript;

	// Use this for initialization
	void Start ()
    {
        PlayerMovementScript = PlayerGameObject.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update()
    {
        this.transform.Translate(0, 0, -PlayerMovementScript.PlayerRunRate * Time.deltaTime);
    }
}
