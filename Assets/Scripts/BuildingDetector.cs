using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;               //������ ���� ����
    private Vector3 lastPosition;                  //�÷��̾��� ������ ��ġ ����
    private float moveThreshold = 0.1f;            //�̵����� �Ӱ谪
    private ConstructibleBuilding currentNearbyBuilding; //���� �����̿� �ִ� �Ǽ������� �ǹ�

    void Start()
    {
        lastPosition = transform.position;        //���� �� ���� ��ġ�� ������ ������ ����
        CheckForBuilding();                          //�ʱ� ������ üũ ����
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾ �����Ÿ� �̻� �̵��ߴ��� üũ
        if (Vector3.Distance(lastPosition, transform.position) > moveThreshold)
        {
            CheckForBuilding();                      //�̵��� ������ üũ
            lastPosition = transform.position;    //���� ��ġ�� ������ ��ġ�� ������Ʈ
        }

        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("�ȴ٤Ӥ�������������");
            currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());   //PlayerInventory�� �����Ͽ� ������ ����
        }
    }

    private void CheckForBuilding()
    {
        //���� ���� ���� ��� �ݶ��̴��� ã��
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        float closestDistance = float.MaxValue;  //���� ����� �Ÿ��� �ʱⰪ
        ConstructibleBuilding closestBuilding = null;      //���� ����� ������ �ʱⰪ

        //�� �ݶ��̴��� �˻��Ͽ� ���� ������ �������� ã��
        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();  //�������� ����
            if (building != null && building.canBuild && !building.isConstrcted)
            {
                float distance = Vector3.Distance(transform.position, building.transform.position);  //�Ÿ����
                if (distance < closestDistance)  //�� ����� �������� �߰� �� ������Ʈ
                {
                    closestDistance = distance;
                    closestBuilding = building;
                }
            }
        }
        if (closestBuilding != currentNearbyBuilding)
        {
            currentNearbyBuilding = closestBuilding;
            if (currentNearbyBuilding != null)
            {
                if (FloatingTextManager.instance != null)
                {
                    FloatingTextManager.instance.Show($"[F]Ű�� {currentNearbyBuilding.buildingName}�Ǽ� (���� {currentNearbyBuilding.requiredTree}�� �ʿ�)"
                        , currentNearbyBuilding.transform.position + Vector3.up);
                }
            }
        }
    }

}
