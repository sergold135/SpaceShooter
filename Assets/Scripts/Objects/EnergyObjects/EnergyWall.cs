using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWall : Obstacle
{
    [SerializeField] private int _energyNeededToPass;   

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player.CurrentEnergy > _energyNeededToPass)
            {
                player.ChangeEnergy(-_energyNeededToPass);
            }
            else
            {
                player.ApplyDamage(Damage);
            }
        }
    }
}
