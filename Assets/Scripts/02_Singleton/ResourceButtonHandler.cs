using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButtonHandler : MonoBehaviour
{
    public Slider goldValueSlider;
    public Slider gemsValueSlider;
    public Slider energyValueSlider;

    public Button goldModifierButton;
    public Button gemsModifierButtonB;
    public Button energyModifierButton;

    void Start()
    {
        goldModifierButton.onClick.AddListener(ModifierGold);
        gemsModifierButtonB.onClick.AddListener(ModifierGems);
        energyModifierButton.onClick.AddListener(ModifierEnergy);
    }

    public void ModifierGold()
    {
        if (goldValueSlider.value > 0)
        {
            if (ResourceManager.Instance.AddGold((int)goldValueSlider.value))
            {
                Debug.Log("골드 획득 완료");
            }
            else
            {
                Debug.Log("골드를 획득하지 못했습니다.");
            }
        }
        else if (goldValueSlider.value < 0)
        {
            if (ResourceManager.Instance.SubtractGold(-(int)goldValueSlider.value))
            {
                Debug.Log("골드 사용 완료");
            }
            else
            {
                Debug.Log("골드를 사용하지 못했습니다.");
            }
        }
    }

    public void ModifierGems()
    {
        if (gemsValueSlider.value > 0)
        {
            if (ResourceManager.Instance.AddGems((int)gemsValueSlider.value))
            {
                Debug.Log("젬 획득 완료");
            }
            else
            {
                Debug.Log("젬을 획득하지 못했습니다.");
            }
        }
        else if (gemsValueSlider.value < 0)
        {
            if (ResourceManager.Instance.SubtractGems(-(int)gemsValueSlider.value))
            {
                Debug.Log("젬 사용 완료");
            }
            else
            {
                Debug.Log("젬을 사용하지 못했습니다.");
            }
        }
    }

    public void ModifierEnergy()
    {
        if (energyValueSlider.value > 0)
        {
            if (ResourceManager.Instance.AddEnergy(energyValueSlider.value))
            {
                Debug.Log("에너지 획득 완료");
            }
            else
            {
                Debug.Log("에너지를 획득하지 못했습니다.");
            }
        }
        else if (energyValueSlider.value < 0)
        {
            if (ResourceManager.Instance.SubtractEnergy(-energyValueSlider.value))
            {
                Debug.Log("에너지 사용 완료");
            }
            else
            {
                Debug.Log("에너지를 사용하지 못했습니다.");
            }
        }
    }
}
