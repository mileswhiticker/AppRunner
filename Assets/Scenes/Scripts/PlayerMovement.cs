using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMovement : MonoBehaviour
{
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
    public float MaxStrafeWidthDestination = 3.0f;
    public float DistanceTravelled = 0.0f;
    public float PlayerRunRate = 1.0f;
    public float PlayerRunRateMax = 2.0f;
    public float PlayerRunRateMin = 0.5f;
    public bool AtDestination = false;
    public float timeLeftDestinationCooldown = 0.0f;

    public float MoneyAmount = 80.0f;
    //
    public float SocialAmount = 40.0f;
    public float HappinessAmount = 40.0f;
    //
    public float HealthAmount = 40.0f;
    public float SleepAmount = 40.0f;

    //money does not decay
    public float SocialDecay = 1.0f;
    public float HappinessDecay = 2.0f;
    //
    public float HealthDecay = 1.0f;
    public float SleepDecay = 1.0f;

    public bool GameRunning = true;
    
    // Use this for initialization
    void Start ()
    {
        groundRenderer = GroundPlane.GetComponent<Renderer>();

        //GetComponent<MeshRenderer>().material.mainTexture = Resources.Load<Texture>("Sprites/Strava");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameRunning)
        {
            //strafing
            float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;
            // Debug.Log("horizontalMovement: " + horizontalMovement);
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
            this.transform.Translate(-horizontalMovement, 0, 0);

            //Leave a destination
            float vertAxis = Input.GetAxis("Vertical");
            if (AtDestination)
            {
                if (vertAxis > 0)
                {
                    //Debug.Log("LeaveDestination()");
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

            // Increase of Decrease Speed
            if (vertAxis != 0)
            {
                PlayerRunRate += vertAxis * Time.deltaTime;
                if (PlayerRunRate >= 2.0f)
                {
                    PlayerRunRate = 2.0f;
                }

                //// TODO clamp position
                //float PositionZ = this.transform.position.z * Time.deltaTime;
                //PositionZ += 0.2f;

                ////if (this.transform.position.z <= -6.0f) {
                ////    Mathf.Clamp(PositionZ, -4.0f, -6.0f);
                ////}             

                //this.transform.Translate(0.0f, 0.0f, PositionZ);

                //Debug.Log("Increasing: " + PlayerRunRate);
                //Debug.Log("PositionZ" + PositionZ);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayerRunRate -= 0.2f;
                if (PlayerRunRate <= 0.5f)
                {
                    PlayerRunRate = 0.5f;
                }

                //// TODO clamp position
                //float PositionZ = this.transform.position.z;
                //PositionZ -= 0.2f;

                //this.transform.Translate(0.0f, 0.0f, PositionZ);

                //Debug.Log("Decreasing: " + PlayerRunRate);
                //Debug.Log("PositionZ" + PositionZ);
            }

            //cooldown from leaving a destination so extra collisions dont trigger
            if (timeLeftDestinationCooldown > 0)
            {
                timeLeftDestinationCooldown -= Time.deltaTime;
            }


            SocialAmount -= SocialDecay * Time.deltaTime;
            HappinessAmount -= HappinessDecay * Time.deltaTime;
            //MoneyAmount -= decayRate * Time.deltaTime;
            HealthAmount -= HealthDecay * Time.deltaTime;
            SleepAmount -= SleepDecay * Time.deltaTime;

            //
            UpdateUI();

            if (SocialAmount + HappinessAmount <= 0)
            {
                GameOver("You are unhappy & have no social life.");
            }
            else if (HealthAmount + SleepAmount <= 0)
            {
                GameOver("You are unhealthy & have no sleep.");
            }
            else if (MoneyAmount <= 0)
            {
                GameOver("You have no money.");
            }
        }
    }
}
