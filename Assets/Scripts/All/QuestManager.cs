using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    public List<Quest> questList = new List<Quest>();
    [SerializeField]
    public GameObject player;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
       pc = player.GetComponent<PlayerController>(); 
    }

    void Awake()
    {
        foreach(Quest quest in questList)
        {
            quest.isComplete = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompletionStatus()
    {
        Debug.Log("checking staturs");
        foreach(Quest quest in questList)
        {
            Debug.Log("check" +quest.questID);
            if(quest.collectibleID != "empty")
            {
                if(pc.inventory.Contains(quest.collectibleID))
                {
                    quest.isComplete = true;
                }
            }
            else if(quest.duckToEat != "empty")
            {
                if(pc.stomach.Contains(quest.duckToEat))
                {
                    quest.isComplete = true;
                }
            }
            else if(quest.noDucksToEat != "empty")
            {
                Debug.Log("has to eat");
                if(pc.noDucksEaten >= int.Parse(quest.noDucksToEat))
                {
                    quest.isComplete = true;
                }
            }
        }
    }
}
