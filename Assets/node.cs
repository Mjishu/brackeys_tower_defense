using UnityEngine;

public class node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject building;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (building != null)
        {
            Debug.Log("Can not build here, TODO: add ui for this later");
            return;
        }
        GameObject buildingToBuild = BuildManager.instance.GetBuildingToBuild();
        building = Instantiate(buildingToBuild, transform.position + positionOffset, transform.rotation);

    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
