using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StateUIManager : MonoBehaviour
{
    public static StateUIManager Instance { get; private set; }

    [Header("UI Referenaces")]
    public Slider hungerSlider;              //��� ������
    public Slider suitDurabilitySlider;      //���ֺ� ������ ������
    public TextMeshProUGUI hungerText;       //��� ��ġ �ؽ�Ʈ
    public TextMeshProUGUI durabilityText;   //������ ��ġ �ؽ�Ʈ

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
        //�����̴� �� ������Ʈ
        hungerSlider.value = survivalStats.currentHunger;
        suitDurabilitySlider.value = survivalStats.currentSuitDurability;

        //�ؽ�Ʈ ������Ʈ (�ۼ�Ʈ�� ǥ��)
        hungerText.text = $"��� : {survivalStats.GetHungerPercentage():F0}%";
        durabilityText.text = $"���ֺ�:{survivalStats.GetSuitDurabilityPercentage():F0}%";

        //���� ������ �� ���� ����
        hungerSlider.fillRect.GetComponent<Image>().color =
            survivalStats.currentHunger < survivalStats.maxHunger * 0.3f ? Color.red : Color.green;

        suitDurabilitySlider.fillRect.GetComponent<Image>().color =
            survivalStats.currentSuitDurability < survivalStats.maxSuitDurability * 0.3f ? Color.red : Color.blue;
    }
}
