using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.0f;
    [SerializeField] private float _heightRange = 1.0f;
    [SerializeField] private GameObject _obst;

    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObst();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnObst();
            _timer = 0.0f;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnObst()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject obst = Instantiate(_obst, spawnPos, Quaternion.identity);

        obst.tag = "Obstacle";

        Destroy(obst, 10f);
    }
}
