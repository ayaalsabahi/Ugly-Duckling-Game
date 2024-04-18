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
          QM.CompletionStatus();
          if(quest.isComplete)
          {
            boxCollider.enabled = false;
          }
        }
      }  
    }
}
