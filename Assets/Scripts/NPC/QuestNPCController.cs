using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestNPCController : MonoBehaviour, Interactable
{
    public Quest quest;
    [SerializeField] Dialogue dialogue;

    public IEnumerator Interact()
    {
        StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue));

        if (quest == null)
        {
            Debug.Log("No quest assigned.");
            yield break;
        }

        if (!quest.isComplete)
        {
            Debug.Log(quest.startDialouge);
            Debug.Log("Quest not completed yet: " + quest.description);
        }
        else
        {
            Debug.Log(quest.endDialouge);
        }
        
        yield return null;
    }


    
}
