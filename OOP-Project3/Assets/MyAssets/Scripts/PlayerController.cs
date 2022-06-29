using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    //3 - encapsulation
    private float verticalInput;
    private float horizontalInput;
    private float playerSpeed = 5f; 
    private float xRange = 8.2f;
    private float MaxRangeZ = 3.54f;
    private float MinRangeZ = -3.45f;

    private GameManager gameManagerP;
    [SerializeField] AudioSource playerAudio; //3 - encapsulation
    [SerializeField] AudioClip deathSound; //3 - encapsulation

    void Start(){
        gameManagerP = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update(){
        MovementController();
        BoundaryController(); 
    }

    private void MovementController(){
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
    }
    private void BoundaryController(){
        if (transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z > MaxRangeZ){
            transform.position = new Vector3(transform.position.x, transform.position.y, MaxRangeZ);
        }
        if (transform.position.z < MinRangeZ){
            transform.position = new Vector3(transform.position.x, transform.position.y, MinRangeZ);
        }
    }
    public void DeathController(){ //4 - Abstraction
        Destroy(GetComponent<MeshRenderer>()); 
        Destroy(GetComponent<BoxCollider>());
        playerAudio.PlayOneShot(deathSound, 0.5f);
        gameManagerP.GameOver();
    }
}
