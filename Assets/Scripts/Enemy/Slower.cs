using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float _speedAmount = 0.5f;
    protected override void PlayerImpact(Player player)
    {
        TankController tankController = player.GetComponent<TankController>();
        if (tankController != null)
        {
            tankController.MaxSpeed -= _speedAmount;
        }
    }
}
