using UnityEngine;

public class shop : MonoBehaviour
{
    public BuildingBlueprint standardBuildingBlueprint;
    public BuildingBlueprint mark2BuildingBlueprint;
    public BuildingBlueprint laserBuildingBlueprint;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardBuilding()
    {
        Debug.Log("buying a standard turret");
        buildManager.SetBuildingToBuild(standardBuildingBlueprint);
    }

    public void PurchaseMark2Building()
    {
        Debug.Log("Bought a alternative building");
        buildManager.SetBuildingToBuild(mark2BuildingBlueprint);
    }

    public void PurchaseLaserBuilding()
    {
        buildManager.SetBuildingToBuild(laserBuildingBlueprint);
    }
}
