using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Astronaut : Obstacle
{
    public static event UnityAction AstronautSaved;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Health.ApplyDamage(Health.Max);
            AstronautSaved?.Invoke();
        }
    }
}
