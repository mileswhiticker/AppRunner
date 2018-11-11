using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMovement : MonoBehaviour {

    public GameObject GroundPlane;
    private Renderer groundRenderer;
    public float strafeSpeed = 10.0f;
    public float grassScrollSpeed = 0.008f;
    public Material myMaterial;
    public Vector2 textureOffset = new Vector2(0, 0);
    public List<FlyingApp> allFlyingApps = new List<FlyingApp>();
    public GameObject FlyingAppPrefab;
    public float MaxStrafeWidth = 9.0f;
    public float MaxStrafeWidthNormal = 9.0f;
    public float MaxStrafeWidthDestination = 4.0f;
    public float DistanceTravelled = 0.0f;
    public float PlayerRunRate = 1.0f;
    public float PlayerRunRateMax = 2.0f;
    public float PlayerRunRateMin = 0.5f;
    public bool AtDestination = false;
    public float timeLeftDestinationCooldown = 0.0f;

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
        if (this.transform.position.x <= -MaxStrafeWidth)
        {
            horizontalMovement = Mathf.Max(horizontalMovement, 0);
        }
        if (this.transform.position.x >= MaxStrafeWidth)
        {
            horizontalMovement = Mathf.Min(horizontalMovement, 0);
        }

        //set it
        this.transform.Translate(horizontalMovement, 0, 0);

        //running forward
        if (AtDestination)
        {
            if(Input.GetAxis("Vertical") > 0)
            {
                Debug.Log("LeaveDestination()");
                LeaveDestination();
            }
        }
        else
        {
            textureOffset.y -= grassScrollSpeed * PlayerRunRate;
            myMaterial = groundRenderer.material;
            myMaterial.SetTextureOffset("_MainTex", textureOffset);
        }
        
        //track distance travelled
        DistanceTravelled += PlayerRunRate * Time.deltaTime;

        //cooldown from leaving a destination so extra collisions dont trigger
        if (timeLeftDestinationCooldown > 0)
        {
            timeLeftDestinationCooldown -= Time.deltaTime;
        }
    }

    void CreateApp()
    {
        Instantiate(FlyingAppPrefab);
    }
}
