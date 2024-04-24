using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour
{

    [SerializeField]
    public string questID;
    [SerializeField]
    public QuestManager QM;
    [SerializeField]
    public BoxCollider boxCollider;
    [SerializeField]
    public MeshRenderer meshRenderer;
    [SerializeField]
    public bool isThoughtTrigger;
    [SerializeField]
    public Dialogue dialogue;
    public int passTimes;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      foreach(Quest quest in QM.questList)
      {
        // if((questID == quest.questID) && (quest.isComplete))
        // {
        //   Debug.Log("open sesame");
        //   boxCollider.enabled = false;
        // }

        if(questID == quest.questID)
        {
          // Debug.Log("made it"+questID + "jj" + quest.questID);
          QM.CompletionStatus();
          if(quest.isComplete)
          {
            Debug.Log("open sesame");
            boxCollider.enabled = false;
            meshRenderer.enabled = false;
          }
        }
      }  
    }

    public void OnTriggerEnter(Collider thing)
    {
      if(thing.tag == "Player" && passTimes == 0)
      {
        if(!DialogueManager.Instance.isTyping)
        {
          StartCoroutine(DialogueManager.Instance.ShowDialogue(dialogue));
        }
        passTimes++;
      }
    }
}
