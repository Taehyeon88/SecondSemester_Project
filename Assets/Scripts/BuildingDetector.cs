using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;               //焼戚奴 姶走 骨是
    private Vector3 lastPosition;                  //巴傾戚嬢税 原走厳 是帖 煽舌
    private float moveThreshold = 0.1f;            //戚疑姶走 績域葵
    private ConstructibleBuilding currentNearbyBuilding; //薄仙 亜猿戚拭 赤澗 闇竺亜管廃 闇弘

    void Start()
    {
        lastPosition = transform.position;        //獣拙 獣 薄仙 是帖研 原走厳 是軒稽 竺舛
        CheckForBuilding();                          //段奄 焼戚奴 端滴 呪楳
    }

    // Update is called once per frame
    void Update()
    {
        //巴傾戚嬢亜 析舛暗軒 戚雌 戚疑梅澗走 端滴
        if (Vector3.Distance(lastPosition, transform.position) > moveThreshold)
        {
            CheckForBuilding();                      //戚疑獣 焼戚奴 端滴
            lastPosition = transform.position;    //薄仙 是帖研 原走厳 是帖稽 穣汽戚闘
        }

        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("吉陥びたたたたたたた");
            currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());   //PlayerInventory研 凧繕馬食 焼戚奴 呪増
        }
    }

    private void CheckForBuilding()
    {
        //姶走 骨是 鎧税 乞窮 紬虞戚希研 達製
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        float closestDistance = float.MaxValue;  //亜舌 亜猿錘 暗軒税 段奄葵
        ConstructibleBuilding closestBuilding = null;      //亜舌 亜猿錘 焼戚奴 段奄葵

        //唖 紬虞戚希研 伊紫馬食 呪増 亜管廃 焼戚奴聖 達製
        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();  //焼戚奴聖 姶走
            if (building != null && building.canBuild && !building.isConstrcted)
            {
                float distance = Vector3.Distance(transform.position, building.transform.position);  //暗軒域至
                if (distance < closestDistance)  //希 亜猿錘 焼戚奴聖 降胃 獣 穣汽戚闘
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
                    FloatingTextManager.instance.Show($"[F]徹稽 {currentNearbyBuilding.buildingName}闇竺 (蟹巷 {currentNearbyBuilding.requiredTree}鯵 琶推)"
                        , currentNearbyBuilding.transform.position + Vector3.up);
                }
            }
        }
    }

}
