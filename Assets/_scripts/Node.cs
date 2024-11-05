using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color InsufficientFundsColor;
    public Vector3 positionOffset;

    BuildManager buildManager;
    [HideInInspector]
    public GameObject building;
    [HideInInspector]
    public BuildingBlueprint buildingBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;


        if (building != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) return;

        BuildBuilding(buildManager.GetBuildingToBuild());
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildBuilding(BuildingBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _building = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        building = _building;

        buildingBlueprint = blueprint;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);



    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (!buildManager.hasMoney)
        {
            rend.material.color = InsufficientFundsColor;
        }
        else
        {
            rend.material.color = hoverColor;

        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void UpgradeBuilding()
    {
        if (isUpgraded)
        {
            Debug.Log("This building is already upgraded!");
            return;
        }
        if (PlayerStats.Money < buildingBlueprint.UpgradeCost)
        {
            Debug.Log("Not enough money to upgrade this building!");
            return;
        }

        PlayerStats.Money -= buildingBlueprint.UpgradeCost;

        //destroys old turret
        Destroy(building);

        GameObject _building = Instantiate(buildingBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        building = _building;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    public void SellBuilding()
    {
        if (isUpgraded)
        {
            PlayerStats.Money += buildingBlueprint.UpgradedSellAmount;
        }
        else
        {
            PlayerStats.Money += buildingBlueprint.SellAmount;
        }

        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(building);
    }
}
