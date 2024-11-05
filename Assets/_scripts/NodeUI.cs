using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject canvas;

    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;

    public Button upgradeButton;

    public void UpgradeTurret()
    {
        target.UpgradeBuilding();
        BuildManager.instance.DeselectNode();
    }

    public void SellTurret()
    {
        target.SellBuilding();
        BuildManager.instance.DeselectNode();
    }

    public void SetTarget(Node nodeTarget)
    {
        target = nodeTarget;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.buildingBlueprint.UpgradeCost;
            upgradeButton.interactable = true;

        }
        else
        {
            upgradeCost.text = "BOUGHT";
            upgradeButton.interactable = false;
        }
        sellCost.text = "$" + target.buildingBlueprint.SellAmount;

        canvas.SetActive(true);
    }

    public void Hide()
    {
        canvas.SetActive(false);
    }
}
