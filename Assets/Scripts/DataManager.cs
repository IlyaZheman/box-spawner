using System;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField spawnTimeTmp;
    [Min(1f)] [SerializeField] private float defaultSpawnTime;

    [SerializeField] private TMP_InputField speedTmp;
    [Min(1f)] [SerializeField] private float defaultSpeed;

    [SerializeField] private TMP_InputField distanceTmp;
    [Min(1f)] [SerializeField] private float defaultDistance;

    public float SpawnTime { get; private set; }
    public float Speed { get; private set; }
    public float Distance { get; private set; }

    private void Awake()
    {
        SpawnTime = defaultSpawnTime;
        Speed = defaultSpeed;
        Distance = defaultDistance;
    }

    public void ChangeDate()
    {
        SpawnTime = GetFloatValue(spawnTimeTmp, defaultSpawnTime);
        Speed = GetFloatValue(speedTmp, defaultSpeed);
        Distance = GetFloatValue(distanceTmp, defaultDistance);
    }

    private static float GetFloatValue(TMP_InputField inputField, float defaultValue)
    {
        try
        {
            return float.Parse(inputField.text);
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
}