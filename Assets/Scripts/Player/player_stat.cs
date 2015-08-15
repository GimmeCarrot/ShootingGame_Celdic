using UnityEngine;
using System.Collections;

public class player_stat : MonoBehaviour {

    public float fHP;
    public float fEP;
    public float fCP;

	// Use this for initialization
	void Start () {
        if (fHP <= 0)
        {
            fHP = 5;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        string sColliderTag = coll.gameObject.tag;

        if (sColliderTag == "Mob")
        {
            fHP -= 1;
            if (fHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
