using Unity.Mathematics;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    private BuildingBlueprint buildingToBuild;

    public bool CanBuild { get { return buildingToBuild != null; } }

    public bool hasMoney { get { return PlayerStats.Money >= buildingToBuild.cost; } }

    public void BuildBuildingOn(node node)
    {
        if (PlayerStats.Money < buildingToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= buildingToBuild.cost;

        GameObject building = Instantiate(buildingToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);


        node.building = building;
    }

    public void SetBuildingToBuild(BuildingBlueprint building)
    {
        buildingToBuild = building;
    }

}
