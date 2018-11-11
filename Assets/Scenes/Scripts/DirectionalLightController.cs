using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightController : MonoBehaviour {

    public float RotationSpeed = 50f;
    Vector3 angle;
    float rotation = 0f;
    public bool direction = true;

	// Use this for initialization
	void Start () {
        angle = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localEulerAngles = new Vector3(Rotation(), angle.y, angle.z);
	}

    float Rotation() {
        rotation += RotationSpeed * Time.deltaTime;
        return direction ? rotation : -rotation;
    }
}
