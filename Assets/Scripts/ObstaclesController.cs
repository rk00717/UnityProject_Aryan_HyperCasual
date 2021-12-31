using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour{
    [SerializeField]
    private GameObject dartPrefab;

    [SerializeField, Range(0f, 20f)]
    private float cooldown;

    private float minOffset = -3f;
    private float maxOffset = 3f;

    [SerializeField]
    private int maxDartLimit = 20;
    [SerializeField]
    private float despawnPosition = -20f;

    private Vector3 spwanPosition = Vector3.zero;

    private List<GameObject> generatedDarts = new List<GameObject>();

    void Start(){
        spwanPosition = transform.position;
        StartCoroutine(StartController());
    }

    void Update(){
        CheckForDeSpawn();
    }

    IEnumerator StartController(){
        while(true){
            yield return new WaitForSeconds(cooldown);
            DecidePosition();
            GenerateDarts();
        }
    }

    void DecidePosition(){
        spwanPosition.y = Random.Range(minOffset, maxOffset); 
    }

    void GenerateDarts(){
        if(generatedDarts!=null){
            if(generatedDarts.Count<maxDartLimit){
                generatedDarts.Add(Instantiate(dartPrefab, spwanPosition, Quaternion.identity, transform));
            }
        }else{
            generatedDarts.Add(Instantiate(dartPrefab, spwanPosition, Quaternion.identity, transform));
        }
    }

    void CheckForDeSpawn(){
        foreach(GameObject dart in generatedDarts){
            if(dart.transform.position.x <= despawnPosition){
                Destroy(dart);
                generatedDarts.Remove(dart);
            }
        }
    }
}