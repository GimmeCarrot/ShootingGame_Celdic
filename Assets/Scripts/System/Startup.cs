using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Screen.SetResolution(650, 900, false);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("space"))
        {
            Application.LoadLevel( 1 );
        }
    }
}
