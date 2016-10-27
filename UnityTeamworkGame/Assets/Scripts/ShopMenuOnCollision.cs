using UnityEngine;
using System.Collections;

public class ShopMenuOnCollision : MonoBehaviour
{
    public GameObject shop;

    void OnCollisionEnter2D(Collision2D shopMenu)
    {
        if (shopMenu.gameObject.tag == "Character")
        {
            shop.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D shopMenu)
    {
        shop.SetActive(false);
    }
}