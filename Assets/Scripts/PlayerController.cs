using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private Rigidbody2D body;

    [SerializeField]
    private List<GameObject> coinObj;
    [SerializeField]
    private int coinScore = 20;
    [SerializeField, Range(0f, 1f)]
    private float coinSpwanChance;

    [SerializeField]
    private float velocityY = 1f;
    private bool gravity;
    private bool canJump = true;

    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump") && canJump){
            gravity = (gravity) ? false:true;
            canJump = false;
            SpwanCoin();
        }

        body.velocity = new Vector2(0, (gravity)?velocityY:-velocityY);
    }

    void SpwanCoin(){
        if(coinObj!=null){
            DisableAllCoin();
            float chance = Random.value;
            if(chance>coinSpwanChance){
                coinObj[(gravity)?0:1].SetActive(true);
            }
        }
    }

    void DisableAllCoin(){
        foreach(GameObject obj in coinObj){
            if(obj.activeSelf){
                obj.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            canJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Coin"){
            GameObject.FindWithTag("GameController").GetComponent<GameController>().score += coinScore;
            collider.gameObject.SetActive(false);
        }
    }
}
