using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StateUIManager : MonoBehaviour
{
    public static StateUIManager Instance { get; private set; }

    [Header("UI Referenaces")]
    public Slider hungerSlider;              //허기 게이지
    public Slider suitDurabilitySlider;      //우주복 내구도 게이지
    public TextMeshProUGUI hungerText;       //허기 수치 텍스트
    public TextMeshProUGUI durabilityText;   //내구도 수치 텍스트

    private SurvivalStats survivalStats;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        survivalStats = FindObjectOfType<SurvivalStats>();
        hungerSlider.maxValue = survivalStats.maxHunger;
        suitDurabilitySlider.maxValue = survivalStats.maxSuitDurability;
    }

    private void Update()
    {
        UpdateStatUI();
    }

    private void UpdateStatUI()
    {
        //슬라이더 값 업데이트
        hungerSlider.value = survivalStats.currentHunger;
        suitDurabilitySlider.value = survivalStats.currentSuitDurability;

        //텍스트 업데이트 (퍼센트로 표시)
        hungerText.text = $"허기 : {survivalStats.GetHungerPercentage():F0}%";
        durabilityText.text = $"우주복:{survivalStats.GetSuitDurabilityPercentage():F0}%";

        //위험 상태일 때 색상 변경
        hungerSlider.fillRect.GetComponent<Image>().color =
            survivalStats.currentHunger < survivalStats.maxHunger * 0.3f ? Color.red : Color.green;

        suitDurabilitySlider.fillRect.GetComponent<Image>().color =
            survivalStats.currentSuitDurability < survivalStats.maxSuitDurability * 0.3f ? Color.red : Color.blue;
    }
}
