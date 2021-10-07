using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricksScripts : MonoBehaviour
{
    public int points;
    public int hitsParaQuebrar;
    public Sprite hitsSprite;
    public void BreakBrick(){
        hitsParaQuebrar--;
        GetComponent<SpriteRenderer>().sprite = hitsSprite;
    }
}
