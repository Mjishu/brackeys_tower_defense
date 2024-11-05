using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public NodeUI nodeUI;

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
    public GameObject sellEffect;

    private BuildingBlueprint buildingToBuild;
    private Node selectedNode;

    public bool CanBuild { get { return buildingToBuild != null; } }

    public bool hasMoney { get { return PlayerStats.Money >= buildingToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if (node == selectedNode)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        buildingToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void SetBuildingToBuild(BuildingBlueprint building)
    {
        buildingToBuild = building;
        DeselectNode();
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public BuildingBlueprint GetBuildingToBuild()
    {
        return buildingToBuild;
    }

}
