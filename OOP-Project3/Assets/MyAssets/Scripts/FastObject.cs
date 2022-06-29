using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastObject : Objects { //1 - Inheritance 
    public override void IncreasePoints(){
        gameManager.UpdateScore(3);
    }
}
