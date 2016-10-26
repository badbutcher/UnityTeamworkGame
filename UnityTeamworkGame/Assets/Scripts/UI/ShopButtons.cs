using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Text CurrentMenu;
    public Text PlayerGold;
    public Text PlayerHp;
    public Text PlayerCannonBalls;
    public GameObject WeaponsPanel;
    public GameObject UpdatePanel;
    public GameObject RepairShipPanel;
    public GameObject QuestPanel;
    public GameObject ExitShop;
    private AudioSource source;
    public AudioClip[] Sounds;

    //Test

    public float Gold;
    public float Hp;
    public float MaxHp;
    public float CannonBalls;
    public float MaxCannonBalls;

    void Awake()
    {
        this.source = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.PlayerGold.text = " - " + this.Gold;
        this.PlayerHp.text = " - " + this.Hp + " / " + this.MaxHp;
        this.PlayerCannonBalls.text = " - " + this.CannonBalls + " / " + this.MaxCannonBalls;
    }

    private void Start()
    {
        this.source.PlayOneShot(this.Sounds[0]);
        this.CurrentMenu.text = "Welcome";
        this.Reset();
    }

    public void ShowWeapons()
    {
        this.CurrentMenu.text = "Weapon Supplies";
        this.Reset();
        this.WeaponsPanel.SetActive(true);
    }

    public void ShowUpdates()
    {
        this.CurrentMenu.text = "Ship Updates";
        this.Reset();
        this.UpdatePanel.SetActive(true);
    }

    public void ShowRepairShip()
    {
        this.CurrentMenu.text = "Ship Repair";
        this.Reset();
        this.RepairShipPanel.SetActive(true);
    }

    public void ShowQuest()
    {
        this.CurrentMenu.text = "Tavern";
        this.Reset();
        this.QuestPanel.SetActive(true);
    }

    public void Exit()
    {
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
        if (this.Gold >= 50 && this.MaxCannonBalls > this.CannonBalls)
        {
            this.source.PlayOneShot(this.Sounds[1]);
            this.Gold -= 50;
            this.CannonBalls++;
        }
    }

    public void BuyExtraCannon()
    {
        //TODO
    }

    public void BuyCannonsReloadSpeed()
    {
        //TODO
    }

    public void ImproveSpeed()
    {
        //TODO
    }

    public void ImproveHealth()
    {
        if (this.Gold >= 100)
        {
            this.source.PlayOneShot(this.Sounds[1]);
            this.Gold -= 100;
            this.Hp += 50;
            this.MaxHp += 50;
        }
    }

    public void ImproveStorage()
    {
        if (this.Gold >= 100)
        {
            this.source.PlayOneShot(this.Sounds[1]);
            this.Gold -= 100;
            this.MaxCannonBalls += 5;
        }
    }

    public void Repair25()
    {
        if (this.Gold >= 20 && this.Hp < this.MaxHp)
        {
            this.source.PlayOneShot(this.Sounds[1]);
            this.Gold -= 20;
            this.Hp += 25;
            this.FixHealth();
        }
    }

    public void Repair50()
    {
        if (this.Gold >= 40 && this.Hp < this.MaxHp)
        {
            this.source.PlayOneShot(this.Sounds[1]);
            this.Gold -= 40;
            this.Hp += 50;
            this.FixHealth();
        }
    }

    public void Repair75()
    {
        if (this.Gold >= 60 && this.Hp < this.MaxHp)
        {
            this.source.PlayOneShot(this.Sounds[1]);
            this.Gold -= 60;
            this.Hp += 75;
            this.FixHealth();
        }
    }

    private void FixHealth()
    {
        if (this.Hp > this.MaxHp)
        {
            this.source.PlayOneShot(this.Sounds[1]);
            this.Hp = this.MaxHp;
        }
    }
}