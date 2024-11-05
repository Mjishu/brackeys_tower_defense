using UnityEngine;

[System.Serializable]
public class BuildingBlueprint
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public int UpgradeCost = 100;
    // public GameObject buildEffect

    public int SellAmount = 50;
    public int UpgradedSellAmount = 100;
}
