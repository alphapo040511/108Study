using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    public TextMeshProUGUI goldTMP;
    public TextMeshProUGUI gemsTMP;
    public TextMeshProUGUI energyTMP;


    // Start is called before the first frame update
    void Start()
    {
        ResourceManager.Instance.OnGoldChanged += GoldChange;
        ResourceManager.Instance.OnGemsChanged += GemsChange;
        ResourceManager.Instance.OnEnergyChanged += EnergyChange;
        ResourceManager.Instance.CheckingAllResources();
    }

    public void GoldChange(int newValue)
    {
        goldTMP.text = newValue.ToString() + "-Gold";
    }

    public void GemsChange(int newValue)
    {
        gemsTMP.text = newValue.ToString() + "-Gem";
    }

    public void EnergyChange(float newValue)
    {
        energyTMP.text = newValue.ToString() + "-Energy";
    }
}
