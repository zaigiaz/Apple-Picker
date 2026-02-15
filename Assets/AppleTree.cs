using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    public GameObject applePrefab;
    public GameObject BranchPrefab;

    public float speed = 100000f;
    public float leftandRightEdge = 10f;

    public float chanceToChangeDirections = 0.000001f;
    public float secondBetweenAppleDrops = 2f;

    // Start is called before the first frame update
    void Start()
    {
	Invoke("DropBranch", 1f);
	Invoke("DropApple", 3f);
    }

    
    void DropApple() {
	GameObject apple = Instantiate<GameObject>(applePrefab);
	apple.transform.position = transform.position;
	Invoke("DropApple", 2f);
    }


    void DropBranch() {
	GameObject branch = Instantiate<GameObject>(BranchPrefab);
	branch.transform.position = transform.position;
	Invoke("DropBranch", 5f);
    }


    // Update is called once per frame
    void Update()
    {
	// speed and movement
        Vector3 pos = transform.position;
	pos.x += speed * Time.deltaTime;
	transform.position = pos;

	// change direction
	if(pos.x < -leftandRightEdge ) {
	    speed = Mathf.Abs(speed); // move right
	} else if(pos.x > leftandRightEdge) {
	    speed = -Mathf.Abs(speed); //move left
	} 
    }


    void FixedUpdate() {
	if(Random.value < chanceToChangeDirections) {
	    speed *= -1;
	}	
    }
}

