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

    // Update is called once per frame
    void Update()
    {
        foreach(Quest quest in questList)
        {
            if(quest.collectibleID != null)
            {

            }
            else if(quest.duckToEat != null)
            {

            }
            else if(quest.noDucksToEat != null)
            {

            }

        }
        
    }
}
