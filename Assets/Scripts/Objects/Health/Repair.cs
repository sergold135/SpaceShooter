using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField] private float _amountOfRestoredHealth = 25;
    [SerializeField] private float _speed = 1;

    public float AmountOfRestoredHealth => _amountOfRestoredHealth;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
