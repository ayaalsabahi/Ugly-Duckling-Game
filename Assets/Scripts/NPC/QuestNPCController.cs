using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestNPCController : MonoBehaviour, Interactable
{
    public Quest quest;
    [SerializeField] Dialogue dialogue;
    [SerializeField] QuestManager QM;

    public IEnumerator Interact()
    {

        Debug.Log("Dialogue is typing? " + DialogueManager.Instance.isTyping);
        if (!DialogueManager.Instance.isTyping)
            StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue));
        //else
        //    DialogueManager.Instance.CloseDialogueBox();

        if (quest == null)
        {
            Debug.Log("No quest assigned.");
            yield break;
        }

        QM.CompletionStatus();

        if(!quest.isComplete)
        {
            Debug.Log("1"+quest.startDialouge);
            // Debug.Log("Quest not completed yet: " + quest.description);
            dialogue.lines[0] = quest.startDialouge;

        }
        else
        {
            Debug.Log("2"+quest.endDialouge);
            // Debug.Log("U done");
            dialogue.lines[0] = quest.endDialouge;
        }
        
        yield return null;
    }


    
}
