using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMovement : MonoBehaviour
{
    public void ReachDestination(GameObject otherGameObject, Destination otherDestination)
    {
        AtDestination = true;
        MaxStrafeWidth = MaxStrafeWidthDestination;
        PlayerRunRate = 0;
        this.transform.position = otherGameObject.transform.position;
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
        if(otherDestination)
        {
            if (!AtDestination)
            {
                if (timeLeftDestinationCooldown <= 0)
                {
                    ReachDestination(otherGameObject, otherDestination);
                }
            }
        }
    }
}
