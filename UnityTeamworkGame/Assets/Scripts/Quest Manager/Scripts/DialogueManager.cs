using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentLine;


	void Start () {
	
	}
	
	void Update () {
        if(currentLine >= dialogueLines.Length)
        {
            currentLine = 0;
        }
	}

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void OnButtonClick()
    {
        PlayerStats.PlayerGold = PlayerStats.PlayerGold + QuestObject.questReward;
        dBox.SetActive(false);
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
    }
}
