using UnityEngine;
using System.Collections;

public class ShopMenuOnCollision : MonoBehaviour {

    public GameObject shop;
    

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D (Collision2D shopMenu)
    {
        if (shopMenu.gameObject.tag == "Character")
        {
            shop.SetActive(true); 
        }
    }

    void OnCollisionExit2D (Collision2D shopMenu)
    {
        shop.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
