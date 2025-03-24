using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance {  get; private set; }

    [Header("UI References")]
    public GameObject inventoryPanel;      //인벤토리 패널
    public Transform itemContainer;        //아이템 슬롯들이 들아갈 켄테이너
    public GameObject itemSlotPrefab;      //아이템 슬롯 프리팹
    public Button closeButton;             //단기 버튼

    private PlayerInventory playerInventory;
    private SurvivalStats survivalStats;

    private void Awake()
    {
        Instance = this;
        inventoryPanel.SetActive(false);
    }

    public void RefreshInventory()
    {
        //기존 아이템 슬롯들을 제거 itemContainer 하위에 있는 모든 오브젝트 졔거
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }
        CreateItemSlot(ItemType.Crystal);
        CreateItemSlot(ItemType.Plant);
        CreateItemSlot(ItemType.Bush);
        CreateItemSlot(ItemType.Tree);
        CreateItemSlot(ItemType.VegetableStew);
        CreateItemSlot(ItemType.FruitSalad);
        CreateItemSlot(ItemType.RepairKit);
    }

    private void CreateItemSlot(ItemType type)
    {
        GameObject slotObj = Instantiate(itemSlotPrefab, itemContainer);
        ItemSlot slot = slotObj.GetComponent<ItemSlot>();
        slot.Setup(type, playerInventory.GetItemCount(type));
    }

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        survivalStats = FindObjectOfType<SurvivalStats>();
        closeButton.onClick.AddListener(HideUI);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanel.activeSelf)
            {
                HideUI();
            }
            else
            {
                ShowUI();
            }
        }
    }

    public void ShowUI()
    {
        inventoryPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        RefreshInventory();
    }

    public void HideUI()
    {
        inventoryPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
