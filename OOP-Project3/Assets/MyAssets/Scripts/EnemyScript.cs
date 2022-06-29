using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Objects{ // 2 - Polymorphism 
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Destroy(gameObject);
            gameManager.UpdateLives(-1);
            gameManager.UpdateScore(-1);
            if(gameManager.lives == 0){
                pController.DeathController();
            }
            Debug.Log("Taking damage -1 health");
        }
    }
}
