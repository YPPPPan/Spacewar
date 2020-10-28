using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManage : MonoBehaviour
{
    private const float SpawnTime = 2f;
    private static Object _enemy;
    private static Object _ally;
    private float _lastspawn;
    private Transform _holder;
    System.Random rm;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = Resources.Load("Enemy");
        _ally = Resources.Load("Ally");
        _holder = transform;
        rm = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - _lastspawn) < SpawnTime) return;
        _lastspawn = Time.time;
        Spawn();
    }

    private void Spawn()
    {
        float x = (float)rm.NextDouble();
        float y = (float)rm.NextDouble();
        x = x * 20 - 10;
        y = y * 4;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(180, 0, 0);
        GameObject enemy = (GameObject)Object.Instantiate(_enemy, new Vector3(x,y,0), rotation);
        enemy.GetComponent<Enemy>().Initialize();
        enemy.GetComponent<Transform>().parent = _holder;
    }

    public void SpawnAlly()
    {
        float x = (float)rm.NextDouble();
        float y = (float)rm.NextDouble();
        x = x * 20 - 10;
        y = y * 4-4;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, 0);
        GameObject ally = (GameObject)Object.Instantiate(_ally, new Vector3(x, y, 0), rotation);
        ally.GetComponent<Ally>().Initialize();
        ally.GetComponent<Transform>().parent = _holder;
    }
}
