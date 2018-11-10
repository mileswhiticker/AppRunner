using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GroundMovement gm;
    private Rigidbody rigidbody;
    public float speed = 10f;
    public Renderer groundRenderer;
    public float scrollSpeed = 0.008f;
    public Material myMaterial;
    public Vector2 textureOffset;
    public List<FlyingApp> allFlyingApps = new List<FlyingApp>();
    public GameObject FlyingAppPrefab;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        groundRenderer = gm.GetComponent<Renderer>();
        textureOffset = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, 0.0f);
        //renderer.material.shader.off

        textureOffset.x += scrollSpeed; 

        //Shader shader = gm.GetComponent<Shader>();
        myMaterial = groundRenderer.material;
        myMaterial.SetTextureOffset("_MainTex", textureOffset);

        //Debug.Log("test");

        //Texture myTex = material.mainTexture;
        //myTex.SetTextureOffset("_MainTex",textureOffset);

        rigidbody.AddForce(movement * speed);

    }

    void CreateApp()
    {
        Instantiate(FlyingAppPrefab);
    }


}
