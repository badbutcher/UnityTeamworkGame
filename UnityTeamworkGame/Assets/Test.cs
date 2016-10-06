using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("asdadasd");
        for (int i = 0; i < 111; i++)
        {
            transform.Translate(1, 1, 1);
        }
	}
}
