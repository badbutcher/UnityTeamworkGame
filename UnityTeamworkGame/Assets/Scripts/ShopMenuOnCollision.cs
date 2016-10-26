using UnityEngine;
using System.Collections;

public class ShopMenuOnCollision : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D (Collision2D shopMenu)
    {
        if (shopMenu.gameObject.tag == "Character")
        {
            
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
