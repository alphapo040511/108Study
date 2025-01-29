using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    //자원 데이터
    private int gold;
    private int gems;
    private float energy;

    //자원 최대량 데이터
    [SerializeField] private const int maxGold = 999;
    [SerializeField] private const int maxGems = 999;
    [SerializeField] private const float maxEnergy = 100f;

    //자원 최소량 데이터
    private const int minGold = 0;
    private const int minGems = 0;
    private const float minEnergy = 0f;

    // 이벤트 정의
    public event Action<int> OnGoldChanged;
    public event Action<int> OnGemsChanged;
    public event Action<float> OnEnergyChanged;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckingAllResources()
    {
        OnGoldChanged?.Invoke(gold);
        OnGemsChanged?.Invoke(gems);
        OnEnergyChanged?.Invoke(energy);
    }

    public bool AddGold(int amount)
    {
        int addedGold = gold + amount;

        if (gold >= maxGold)
        {
            Debug.LogWarning("골드를 더 이상 소지할 수 없습니다.");
            return false;
        }
        else if(addedGold > maxGold)
        {
            Debug.LogWarning($"골드를 더 이상 소지할 수 없어 {maxGold - gold}골드 만큼 획득하였습니다.");
        }

        gold = Mathf.Min(maxGold, addedGold);
        OnGoldChanged?.Invoke(gold);
        return true;
    }

    public bool SubtractGold(int amount)
    {
        int subtractedGold = gold - amount;
        if (subtractedGold < minGold)
        {
            Debug.LogWarning("골드가 부족합니다.");
            return false;
        }
        else
        {
            gold = subtractedGold;
            OnGoldChanged?.Invoke(gold);
            return true;
        }
    }

    public bool AddGems(int amount)
    {
        int addedGems = gems + amount;

        if (gems >= maxGems)
        {
            Debug.LogWarning("젬을 더 이상 소지할 수 없습니다.");
            return false;
        }
        else if (addedGems > maxGems)
        {
            Debug.LogWarning($"젬을 더 이상 소지할 수 없어 {maxGems - gems}젬 만큼 획득하였습니다.");
        }

        gems = Mathf.Min(maxGems, addedGems);
        OnGemsChanged?.Invoke(gems);
        return true;
    }

    public bool SubtractGems(int amount)
    {
        int subtractedGems = gems - amount;
        if (subtractedGems < minGems)
        {
            Debug.LogWarning("젬이 부족합니다.");
            return false;
        }
        else
        {
            gems = subtractedGems;
            OnGemsChanged?.Invoke(gems);
            return true;
        }
    }

    public bool AddEnergy(float amount)
    {
        float addedEnergy = energy + amount;

        if (energy >= maxEnergy)
        {
            Debug.LogWarning("에너지를 더 이상 획득할 수 없습니다.");
            return false;
        }
        else if (addedEnergy > maxEnergy)
        {
            Debug.LogWarning($"에너지를 더 이상 획득할 수 없어 {maxEnergy - energy}에너지 만큼 획득하였습니다.");
        }

        energy = Mathf.Min(maxEnergy, addedEnergy);
        OnEnergyChanged?.Invoke(energy);
        return true;
    }

    public bool SubtractEnergy(float amount)
    {
        float subtractedEnergy = energy - amount;
        if (subtractedEnergy < minEnergy)
        {
            Debug.LogWarning("에너가 부족합니다.");
            return false;
        }
        else
        {
            energy = subtractedEnergy;
            OnEnergyChanged?.Invoke(energy);
            return true;
        }
    }
}
