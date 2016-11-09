using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class QuestObject : MonoBehaviour
{

    public QuestManager theQM;

    public DialogueManager theDM;

    public GameObject QuestPanel;
    public Text GatherQuest;
    public Text KillQuest;
    public Text ZoneQuest;
    public static int questReward;

    //For Gather Quest
    public GameObject items;
    public static int itemsCollected;
    public int itemsToCollect;
    private bool collectionQuestComplete = false;



    //For Kill Quest
    public static int enemiesKilled;
    public int enemiesToKill;
    private bool killQuestComplete = false;

    //For Location Quest
    public static int zonesFound;
    public static int zonesToFind;
    private bool zoneQuestComplete = false;

    




    void Start()
    {
        zonesToFind = 6;

    }


    void Update()
    {


        if (collectionQuestComplete)
        {
            GatherQuest.text = "";
        }
        else
        {
            string text = "You have gathered " + itemsCollected + "/" + itemsToCollect + " chests!";
            GatherQuest.text = text;
        }

        if (killQuestComplete)
        {
            KillQuest.text = "";
        }
        else
        {
            string text1 = "You have killed " + enemiesKilled + "/" + enemiesToKill + " pirates!";
            KillQuest.text = text1;
        }

        if (zoneQuestComplete)
        {
            ZoneQuest.text = "";
        }
        else
        {
            string text2 = "You have found " + zonesFound + "/" + zonesToFind + " islands!";
            ZoneQuest.text = text2;
        }


        if (itemsCollected == itemsToCollect)
        {
            string endText = "You have collected all chests!";
            PlayerStats.PlayerGold += 150f;
            collectionQuestComplete = true;
            theDM.ShowBox(endText);
            items.SetActive(false);
            itemsCollected = 0;


        }

        if (enemiesToKill == enemiesKilled)
        {
            string endText = "You have killed all pirate ships!";
            PlayerStats.PlayerGold += 150f;
            killQuestComplete = true;
            theDM.ShowBox(endText);
            enemiesKilled = 0;


        }

        if (zonesFound == zonesToFind)
        {
            string endText = "You have found all islands!";
            PlayerStats.PlayerGold += 150f;
            zoneQuestComplete = true;
            theDM.ShowBox(endText);
            zonesFound = 0;
        }

        if (collectionQuestComplete && killQuestComplete && zoneQuestComplete)
        {
            string endText = "Congratulations, you have completed all quests!";
            theDM.ShowBox(endText);
            PlayerStats.PlayerGold += 1500f;

        }


    }




}
