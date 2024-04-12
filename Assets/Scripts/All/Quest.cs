using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string questID;
    public string collectibleID;
    public string description;
    public string startDialouge;
    public string endDialouge;
    public bool isComplete;
    

}
