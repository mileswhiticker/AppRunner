using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerMovement : MonoBehaviour
{
    public void ReachDestination()
    {
        AtDestination = true;
        MaxStrafeWidth = MaxStrafeWidthDestination;
        PlayerRunRate = 0;
    }
    public void LeaveDestination()
    {
        AtDestination = false;
        MaxStrafeWidth = MaxStrafeWidthNormal;
        PlayerRunRate = PlayerRunRateMin;
    }
}
