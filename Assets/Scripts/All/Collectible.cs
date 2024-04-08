using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCollectible", menuName = "Collectibles/Collectible")]
public class Collectible : ScriptableObject
{
    public string collectibleName;
    public string questID;
    public Sprite icon;
}
