using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Player player;
    public override void PowerUp(Player player)
    {
        foreach (MeshRenderer g in player.GetComponentsInChildren<MeshRenderer>())
        {
            g.material.color = Color.cyan;
        }
        player.invincibleOn = true;
    }

    public override void PowerDown()
    {
        foreach (MeshRenderer g in player.GetComponentsInChildren<MeshRenderer>())
        {
            if (g.name == "Body" || g.name == "Turret")
            {
                g.material.color = new Color32(69, 195, 56, 255);
            } else
            {
                g.material.color = Color.black;
            }
        }
        player.invincibleOn = false;
    }
}
