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

    public GameObject standardBuildingPrefab;

    private GameObject buildingToBuild;

    void Start()
    {
        buildingToBuild = standardBuildingPrefab;
    }

    public GameObject GetBuildingToBuild()
    {
        return buildingToBuild;
    }

}
