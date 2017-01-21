using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public GameObject MonsterFish;

	void Start () {
       StartCoroutine(ActivateMonsterFish(3f));
	}

	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator ActivateMonsterFish(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        MonsterFish.SetActive(true);
    }



}
