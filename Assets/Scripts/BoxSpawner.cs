using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnerTransform;
    [SerializeField] private DataManager data;
    [SerializeField] private Pool pool;

    private float _timer;

    private void Update()
    {
        if (_timer < data.SpawnTime)
        {
            _timer += Time.deltaTime;
            return;
        }

        _timer = 0;

        var item = pool.GetFreeElement(spawnerTransform.position, spawnerTransform.rotation);
        item.Init(data.Speed, data.Distance);
    }
}