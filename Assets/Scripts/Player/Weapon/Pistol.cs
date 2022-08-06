using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootPoint, Vector2 direction)
    {
        Bullet bullet = Instantiate(Bullet, shootPoint);
        bullet.Initialize(direction);
        AudioManager.Instance.PlayClip(ShotClip);
    }
}
