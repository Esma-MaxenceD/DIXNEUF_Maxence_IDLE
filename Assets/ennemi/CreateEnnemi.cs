using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "new_ennemi", menuName = "ennemi", order = 0)]

public class CreateEnnemi : ScriptableObject
{
    public string ennemiName;
    public float hpBase;
    public float spellCard;
    public Sprite cardImage;
    public int score;
}




