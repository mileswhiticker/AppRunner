using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GroundMovement gm;
    private Rigidbody rigidbody;
    public float speed = 10f;
    Renderer renderer;
    public float scrollSpeed = 0.5f;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        renderer = gm.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, 0.0f);
        renderer.material.shader.off

        rigidbody.AddForce(movement * speed);

    }
}
