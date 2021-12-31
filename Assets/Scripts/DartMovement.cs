using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMovement : MonoBehaviour{
    private Rigidbody2D body;

    [SerializeField]
    private float moveSpeed = -5f;

    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        body.velocity = new Vector2(moveSpeed, 0f);
    }
}
