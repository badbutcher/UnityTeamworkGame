using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Text CurrentMenuText;
    public Text PlayerGoldText;
    public Text PlayerHpText;
    public Text PlayerCannonBallsText;
    public GameObject WeaponsPanel;
    public GameObject UpdatePanel;
    public GameObject RepairShipPanel;
    public GameObject QuestPanel;
    public GameObject ExitShop;
    private AudioSource source;
    public AudioClip BuySound;
    public PlayerStats PlayerStats;
    public PlayerCannons PlayerCannons;

    void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        this.CurrentMenuText.text = "Welcome";
        this.Reset();
    }

    private void Update()
    {
        this.PlayerGoldText.text = " - " + PlayerStats.PlayerGold;
        this.PlayerHpText.text = " - " + PlayerStats.PlayerHealth + " / " + PlayerStats.PlayerMaxHealth;
        this.PlayerCannonBallsText.text = " - " + PlayerStats.PlayerCannonBalls + " / " + PlayerStats.PlayerMaxCannonBalls;
    }

    public void ShowWeapons()
    {
        this.CurrentMenuText.text = "Weapon Supplies";
        this.Reset();
        this.WeaponsPanel.SetActive(true);
    }

    public void ShowUpdates()
    {
        this.CurrentMenuText.text = "Ship Updates";
        this.Reset();
        this.UpdatePanel.SetActive(true);
    }

    public void ShowRepairShip()
    {
        this.CurrentMenuText.text = "Ship Repair";
        this.Reset();
        this.RepairShipPanel.SetActive(true);
    }

    public void ShowQuest()
    {
        this.CurrentMenuText.text = "Tavern";
        this.Reset();
        this.QuestPanel.SetActive(true);
    }

    public void Exit()
    {
        PlayerStats.isInShop = false;
        this.Reset();
        this.ExitShop.SetActive(false);
    }

    private void Reset()
    {
        this.WeaponsPanel.SetActive(false);
        this.UpdatePanel.SetActive(false);
        this.QuestPanel.SetActive(false);
        this.RepairShipPanel.SetActive(false);
    }

    public void BuyCannonBalls()
    {
        if (PlayerStats.PlayerGold >= 50 && PlayerStats.PlayerMaxCannonBalls > PlayerStats.PlayerCannonBalls)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 50;
            PlayerStats.PlayerCannonBalls++;
        }
    }

    public void BuyExtraCannon()
    {
        if (PlayerStats.PlayerGold >= 200f)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 200f;
            PlayerCannons.maxCannons -=1f;
        }
    }

    public void BuyCannonsReloadSpeed()
    {
        if (PlayerStats.PlayerGold >= 200f)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 200;
            PlayerCannons.shotCooldown -= 0.5f;
        }
    }

    public void ImproveSpeed()
    {
        if (PlayerStats.PlayerGold >= 100f)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 100f;
            PlayerStats.PlayerMoveSpeed += 0.5f;
        }
    }

    public void ImproveHealth()
    {
        if (PlayerStats.PlayerGold >= 100f)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 100f;
            PlayerStats.PlayerHealth += 50f;
            PlayerStats.PlayerMaxHealth += 50f;
        }
    }

    public void ImproveStorage()
    {
        if (PlayerStats.PlayerGold >= 100f)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 100f;
            PlayerStats.PlayerMaxCannonBalls += 5f;
        }
    }

    public void Repair25()
    {
        if (PlayerStats.PlayerGold >= 20 && PlayerStats.PlayerHealth < PlayerStats.PlayerMaxHealth)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 20;
            PlayerStats.PlayerHealth += 25;
            this.FixHealth();
        }
    }

    public void Repair50()
    {
        if (PlayerStats.PlayerGold >= 40 && PlayerStats.PlayerHealth < PlayerStats.PlayerMaxHealth)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 40;
            PlayerStats.PlayerHealth += 50;
            this.FixHealth();
        }
    }

    public void Repair75()
    {
        if (PlayerStats.PlayerGold >= 60 && PlayerStats.PlayerHealth < PlayerStats.PlayerMaxHealth)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerGold -= 60;
            PlayerStats.PlayerHealth += 75;
            this.FixHealth();
        }
    }

    private void FixHealth()
    {
        if (PlayerStats.PlayerHealth > PlayerStats.PlayerMaxHealth)
        {
            this.source.PlayOneShot(this.BuySound);
            PlayerStats.PlayerHealth = PlayerStats.PlayerMaxHealth;
        }
    }
}