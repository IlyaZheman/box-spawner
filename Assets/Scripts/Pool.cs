using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Item poolObjectPrefab;
    [SerializeField] private Transform container;
    [Min(0)] [SerializeField] private int minCapacity;

    private List<Item> _pool;

    private void Start()
    {
        CreatePool();
    }

    public Item GetFreeElement()
    {
        return TryGetPoolObject(out var element) ? element : CreatePoolObject(true);
    }

    public Item GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        return element;
    }

    public Item GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }
    
    private void CreatePool()
    {
        _pool = new List<Item>(minCapacity);

        for (var i = 0; i < minCapacity; i++)
        {
            CreatePoolObject();
        }
    }

    private Item CreatePoolObject(bool isActiveByDefault = false)   
    {
        var createdObject = Instantiate(poolObjectPrefab, container);
        
        createdObject.gameObject.SetActive(isActiveByDefault);
        
        _pool.Add(createdObject);

        return createdObject;
    }

    private bool TryGetPoolObject(out Item element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);

                return true;
            }
        }

        element = null;
        return false;
    }
}