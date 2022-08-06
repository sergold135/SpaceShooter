using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private int _screenCenterX;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _screenCenterX = Screen.width / 2;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x < _screenCenterX)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition).y > transform.position.y ? Vector2.up : Vector2.down;
            _mover.Thrust(direction);
        }
        else if (Input.GetMouseButtonUp(0) && Input.mousePosition.x < _screenCenterX) 
        {           
            _mover.Stop();
        }
    }
}
