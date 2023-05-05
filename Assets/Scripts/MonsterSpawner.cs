using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;
    
    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    void Start(){
        StartCoroutine( SpawnMonsters() ); //call coroutine
    }

    IEnumerator SpawnMonsters(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1,5)); //wait for random second seconds
        
            randomIndex = Random.Range(0, monsterReference.Length); //select a random monster
            randomSide = Random.Range(0,2); //select random side

            spawnedMonster = Instantiate(monsterReference[randomIndex]); //spawn monster

            //left side
            if(randomSide == 0 ){
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10);
            }
            //Right side
            else{
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
                spawnedMonster.transform.localScale = new Vector3(-1f,1f,1f);
            }
        }
    }

    
}//class
