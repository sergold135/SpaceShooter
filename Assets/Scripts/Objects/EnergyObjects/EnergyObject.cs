using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObject : Obstacle
{
    [SerializeField] private ParticleSystem _energyBlinksPS;
    [SerializeField] private int _chanceToDrop;

    private EnergySpawner _energySpawner;
    private bool _isDroppingEnergy;

    protected override void OnEnable()
    {
        base.OnEnable();

        int minChance = 0;
        int maxChance = 100;

        _energyBlinksPS.gameObject.SetActive(false);
        _isDroppingEnergy = false;

        if (Random.Range(minChance, maxChance) <= _chanceToDrop)
        {
            _isDroppingEnergy = true;
            _energyBlinksPS.gameObject.SetActive(true);
        }
    }

    public void Initialize(EnergySpawner energySpawner)
    {
        _energySpawner = energySpawner;
    }

    protected override void OnDied()
    {
        if (_isDroppingEnergy)
        {
            _energySpawner.SpawnEnergy(transform.position);
        }

        base.OnDied();
    }
}

