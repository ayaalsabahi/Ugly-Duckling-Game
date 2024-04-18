using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : MonoBehaviour
{

    [SerializeField]
    public Quest quest;
    [SerializeField]
    public BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      if(quest.isComplete)
      {
        boxCollider.enabled = false;
      }  
    }
}
