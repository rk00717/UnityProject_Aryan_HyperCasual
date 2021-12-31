using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour{
    private Rigidbody2D body;

    [SerializeField, Range(0, 10)]
    private float speed;
    [SerializeField]
    private float offsetParam;
    
    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        body.velocity = new Vector2(speed, 0f);

        if(transform.position.x>=offsetParam){
            transform.position = new Vector3(
                0f,
                transform.position.y,
                transform.position.z
            );
        }
    }
}