using UnityEngine;
using System.Collections;

public class MobStat1 : MonoBehaviour {

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

    void OnTriggerEnter2D(Collider2D coll)
    {
        string sColliderTag = coll.gameObject.tag;

        if (sColliderTag == "PlayerAtk")
        {
            fHP -= 1;
            if (fHP <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(coll.gameObject);
        }
        else if (sColliderTag == "Player")
        {
            //Destroy(gameObject);
        }
    }
}
