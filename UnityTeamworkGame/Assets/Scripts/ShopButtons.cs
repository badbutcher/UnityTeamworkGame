using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public GameObject WeaponsPanel;
    public GameObject SuppliesPanel;
    public GameObject UpgradesPanel;
    public GameObject PotionsPanel;
    public GameObject InnPanel;
    public GameObject RepairShipPanel;
    public GameObject ExitShop;


    void Update()
    {
        //EventSystem.current.currentSelectedGameObject.name;

    }
    public void ShowWeapons()
    {
        WeaponsPanel.SetActive(true);
    }

    public void ShowSupplies()
    {
        SuppliesPanel.SetActive(true);
    }

    public void ShowUpgrades()
    {
        UpgradesPanel.SetActive(true);
    }

    public void ShowPotions()
    {
        PotionsPanel.SetActive(true);
    }

    public void ShowInn()
    {
        InnPanel.SetActive(true);
    }

    public void ShowRepairShip()
    {
        RepairShipPanel.SetActive(true);
    }

    public void Exit()
    {
        ExitShop.SetActive(false);
    }
}