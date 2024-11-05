using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color InsufficientFundsColor;
    public Vector3 positionOffset;

    BuildManager buildManager;
    [Header("Optional")]
    public GameObject building;

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

        buildManager.BuildBuildingOn(this);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
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
}
