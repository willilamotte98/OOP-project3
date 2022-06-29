using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour{
    protected GameManager gameManager;
    protected PlayerController pController;
    private float enemyOneSpeed = 4f;
    private float enemyTwoSpeed = 2.5f;
    void Start(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update(){
        MovingForwardMotion(); //4 - Abstraction
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Destroy(gameObject);
            IncreasePoints(); //changes score depending on the enemy hit
        }
        if(other.CompareTag("FinishLine")){ //once out of bound, enemy is destroyed from the game
            Destroy(gameObject);
        }
    }
    void MovingForwardMotion(){ //4 - Abstraction
        if (CompareTag("Enemy1")){
            transform.Translate(Vector3.left * Time.deltaTime * enemyOneSpeed);
        }
        if (CompareTag("Enemy2")||CompareTag("Enemy3")){
            transform.Translate(Vector3.left * Time.deltaTime * enemyTwoSpeed);
        }
    }
    public virtual void IncreasePoints(){
        gameManager.UpdateScore(1);
    } 
}
