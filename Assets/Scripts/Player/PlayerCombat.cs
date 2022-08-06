using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Touchscreen _touchscreen;

    private void OnEnable()
    {
        _touchscreen.AttackButtonPressed += Shoot;
    }

    private void OnDisable()
    {
        _touchscreen.AttackButtonPressed -= Shoot;
    }

    public void Shoot()
    {
        _currentWeapon.Shoot(_shootPoint, Vector2.right);
    }
}
