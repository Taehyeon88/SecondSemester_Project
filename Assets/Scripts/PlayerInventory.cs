using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //������ ������ ������ �����ϴ� ����
    public int crystalCount = 0;
    public int plantCount = 0;
    public int bushCount = 0;
    public int treeCount = 0;

    //�������� �߰��ϴ� �Լ�, ������ ������ ���� �ش� �������� ������ ������Ŵ
    public void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++;   //���簳������
                Debug.Log($"ũ����Ż ȹ��! ���� ���� : {crystalCount}");    //���簳�����
                break;

            case ItemType.Plant:
                plantCount++;
                Debug.Log($"ũ����Ż ȹ��! ���� ���� : {plantCount}");
                break;

            case ItemType.Bush:
                bushCount++;
                Debug.Log($"ũ����Ż ȹ��! ���� ���� : {bushCount}");
                break;

            case ItemType.Tree:
                treeCount++;
                Debug.Log($"ũ����Ż ȹ��! ���� ���� : {treeCount}");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }

    private void ShowInventory()
    {
        Debug.Log("====�κ��丮====");
        Debug.Log($"ũ����Ż + {crystalCount}��");
        Debug.Log($"�Ĺ� + {plantCount}��");
        Debug.Log($"��Ǯ + {bushCount}��");
        Debug.Log($"���� + {treeCount}��");
        Debug.Log("==================");

    }
}
