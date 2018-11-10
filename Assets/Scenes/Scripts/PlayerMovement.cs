using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject GroundPlane;
    private Renderer groundRenderer;
    public float strafeSpeed = 0.5f;
    public float grassScrollSpeed = 0.008f;
    public Material myMaterial;
    public Vector2 textureOffset = new Vector2(0, 0);
    public List<FlyingApp> allFlyingApps = new List<FlyingApp>();
    public GameObject FlyingAppPrefab;
    public float MaxWidth = 9.0f;
    public float DistanceTravelled = 0.0f;
    public float PlayerRunRate = 1.0f;

    // Use this for initialization
    void Start ()
    {
        groundRenderer = GroundPlane.GetComponent<Renderer>();
	}

    // Update is called once per frame
    void Update()
    {
        //strafing
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;
        
        //clamp the value
        if (this.transform.position.x <= -MaxWidth)
        {
            horizontalMovement = Mathf.Max(horizontalMovement, 0);
        }
        if (this.transform.position.x >= MaxWidth)
        {
            horizontalMovement = Mathf.Min(horizontalMovement, 0);
        }

        //set it 
        {
            this.transform.Translate(horizontalMovement, 0, 0);
        }
        
        //running forward
        textureOffset.y -= grassScrollSpeed * PlayerRunRate;
        myMaterial = groundRenderer.material;
        myMaterial.SetTextureOffset("_MainTex", textureOffset);
        
        DistanceTravelled += PlayerRunRate * Time.deltaTime;

    }

    void CreateApp()
    {
        Instantiate(FlyingAppPrefab);
    }
}
