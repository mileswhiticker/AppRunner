using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public float SleepEffect = 0.0f;
    public float HealthEffect = 0.0f;
    public float SocialEffect = 0.0f;
    public float HappyEffect = 0.0f;
    public float MoneyEffect = 0.0f;

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

        if(this.transform.position.z < -1)
        {
            this.transform.Translate(-4.0f + Random.value * 8.0f, 0, 65.0f);
            //this.transform.Translate(-3.0f + Random.value * 6.0f, 0.0f, 0.0f);
        }
    }
}
