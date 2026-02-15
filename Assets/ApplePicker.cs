using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List <GameObject> basketlist;

    // Start is called before the first frame update
    void Start()
    {
	basketlist = new List <GameObject>();
        for(int i=0; i<numBaskets; i++) {
	    GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
	    Vector3 pos = Vector3.zero;
	    pos.y = basketBottomY + (basketSpacingY * i);
	    tBasketGo.transform.position = pos;
	    basketlist.Add(tBasketGo);
	}
    }


    public void AppleDestroyed() {
	GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
	foreach(GameObject tGO in tAppleArray) {
	    Destroy(tGO);
	}	
	
	int basketIndex = basketlist.Count - 1;
	GameObject tBasketGo = basketlist[basketIndex];
	basketlist.RemoveAt(basketIndex);
	Destroy(tBasketGo);
      
	if (basketlist.Count == 0)
        {
	    SceneManager.LoadScene("GameOver");
        }

    }
}
