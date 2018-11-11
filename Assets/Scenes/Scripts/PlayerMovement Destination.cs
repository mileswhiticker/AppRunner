using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMovement : MonoBehaviour
{
    public int metaDataLost = 0;
    public void ReachDestination(GameObject otherGameObject, Destination otherDestination)
    {
        AtDestination = true;
        MaxStrafeWidth = MaxStrafeWidthDestination;
        PlayerRunRate = 0;
        this.transform.position = new Vector3(otherGameObject.transform.position.x, this.transform.position.y, otherGameObject.transform.position.z);

        MoneyAmount += otherDestination.MoneyEffect;
        //
        SocialAmount += otherDestination.SocialEffect;
        HappinessAmount += otherDestination.HappyEffect;
        //
        HealthAmount += otherDestination.HealthEffect;
        SleepAmount += otherDestination.SleepEffect;
        /*
    SleepEffect = 0.0f;
    HealthEffect = 0.0f;
    public float SocialEffect = 0.0f;
    public float HappyEffect = 0.0f;
    public float MoneyEffect = 0.0f;
    */
    }

    public void LeaveDestination()
    {
        AtDestination = false;
        MaxStrafeWidth = MaxStrafeWidthNormal;
        PlayerRunRate = PlayerRunRateMin;
        timeLeftDestinationCooldown = 5.0f;
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;
        Destination otherDestination = otherGameObject.GetComponent<Destination>();
        FlyingApp otherFlyingApp = otherGameObject.GetComponent<FlyingApp>();
        if (otherDestination)
        {
            if (!AtDestination)
            {
                if (timeLeftDestinationCooldown <= 0)
                {
                    ReachDestination(otherGameObject, otherDestination);
                }
            }
        }
        else if (otherFlyingApp)
        {
            MoneyAmount += otherFlyingApp.MoneyEffect;
            //
            SocialAmount += otherFlyingApp.SocialEffect;
            HappinessAmount += otherFlyingApp.HappyEffect;
            //
            HealthAmount += otherFlyingApp.HealthEffect;
            SleepAmount += otherFlyingApp.SleepEffect;

            if (otherFlyingApp.LeakYourData)
            {
                metaDataLost += 1;
            }
        }
    }
}
