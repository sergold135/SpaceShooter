using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    [SerializeField] private float _current;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _restoreHP;

    public float Max => _max;
    public float Current => _current;

    public event UnityAction Died;
    public event UnityAction Damaged;

    protected virtual void OnEnable()
    {
        _current = _max;
    }

    public virtual void ApplyDamage(float damage)
    {
        _current -= damage;

        if (_current <= 0)
        {
            Died?.Invoke();
            AudioManager.Instance.PlayClip(_death);
        }
        else
        {
            AudioManager.Instance.PlayClip(_hit);
            Damaged?.Invoke();
        }
    }

    public virtual void RestoreHealth(float amountOfRestoredHealth)
    {
        _current = Mathf.Clamp(_current + amountOfRestoredHealth, 0, _max);
        AudioManager.Instance.PlayClip(_restoreHP);
    }
}
