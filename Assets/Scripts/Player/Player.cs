using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxEnergy = 100;
    [SerializeField] private float _currentEnergy;
    [SerializeField] private float _energyWastePerSecond = 2;

    private Rigidbody2D _rigidBody;
    private Health _health;
    private PlayerCombat _combat;
    private PlayerMover _mover;
    private int _score;
    private int _record;

    public float CurrentEnergy => _currentEnergy;
    public float Score => _score;

    public event UnityAction<float> HealthChanged;
    public event UnityAction<float> EnergyChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private const float GravityScale = 0.05f;

    private void OnEnable()
    {
        _record = PlayerPrefs.GetInt("Record");

        _combat = GetComponent<PlayerCombat>();
        _mover = GetComponent<PlayerMover>();
        _health.Died += OnDied;

        Astronaut.AstronautSaved += OnAstronautSaved; 
    }
    private void OnDisable()
    {
        _health.Died -= OnDied;

        Astronaut.AstronautSaved -= OnAstronautSaved;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.gravityScale = 0;

        _currentEnergy = _maxEnergy;
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Energy energy))
        {
            ChangeEnergy(energy.AmountOfRestoredEnergy);
            energy.gameObject.SetActive(false);
        }

        if (collision.TryGetComponent(out Repair repair))
        {
            RestoreHelath(repair.AmountOfRestoredHealth);
            repair.gameObject.SetActive(false);
        }
    }

    private void OnAstronautSaved()
    {
        _score++;
        ScoreChanged?.Invoke(_score);

        if (_score > _record)
        {
            _record = _score;
            PlayerPrefs.SetInt("Record", _record);
        }
    }

    public void ChangeEnergy(float amountOfRestoredEnergy)
    {
        _currentEnergy = Mathf.Clamp(_currentEnergy + amountOfRestoredEnergy, 0, _maxEnergy);

        if (_currentEnergy > 0)
            _rigidBody.gravityScale = 0;

        EnergyChanged?.Invoke(_currentEnergy / _maxEnergy);
    }

    private void FixedUpdate()
    {
        if (_currentEnergy <= 0)
        {
            _rigidBody.gravityScale = GravityScale;
            return;
        }

        _currentEnergy -= Time.fixedDeltaTime * _energyWastePerSecond;
        EnergyChanged?.Invoke(_currentEnergy / _maxEnergy);
    }

    public void ApplyDamage(float damage)
    {
        _health.ApplyDamage(damage);
        HealthChanged?.Invoke(_health.Current / _health.Max);
    }

    public void RestoreHelath(float amountOfRestoredHP)
    {
        _health.RestoreHealth(amountOfRestoredHP);
        HealthChanged?.Invoke(_health.Current / _health.Max);
    }

    private void OnDied()
    {
        _combat.enabled = false;
        _mover.enabled = false;
        Died?.Invoke();
        gameObject.SetActive(false); // анимацию мб
    }
}