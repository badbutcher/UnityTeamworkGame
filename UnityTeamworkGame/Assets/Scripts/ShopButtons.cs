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

    private void Start()
    {
        this.Reset();
    }

    public void ShowWeapons()
    {
        this.Reset();
        this.WeaponsPanel.SetActive(true);
    }

    public void ShowSupplies()
    {
        this.Reset();
        this.SuppliesPanel.SetActive(true);
    }

    public void ShowUpgrades()
    {
        this.Reset();
        this.UpgradesPanel.SetActive(true);
    }

    public void ShowPotions()
    {
        this.Reset();
        this.PotionsPanel.SetActive(true);
    }

    public void ShowInn()
    {
        this.Reset();
        this.InnPanel.SetActive(true);
    }

    public void ShowRepairShip()
    {
        this.Reset();
        this.RepairShipPanel.SetActive(true);
    }

    public void Exit()
    {
        this.Reset();
        this.ExitShop.SetActive(false);
    }

    private void Reset()
    {
        this.WeaponsPanel.SetActive(false);
        this.SuppliesPanel.SetActive(false);
        this.UpgradesPanel.SetActive(false);
        this.PotionsPanel.SetActive(false);
        this.InnPanel.SetActive(false);
        this.RepairShipPanel.SetActive(false);
    }
}