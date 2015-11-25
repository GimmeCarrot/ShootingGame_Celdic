using UnityEngine;
using System.Collections;

public class BossStat1 : MonoBehaviour {

    enum NUMBERS
    {
        MAX_HP = 99999,
    };

    public int m_nHP;
    public int m_nEP;
    public int m_nCP;

    private GameObject m_playerObj;

    // Use this for initialization
    void Start()
    {
        if (m_nHP <= 0)
        {
            m_nHP = (int)NUMBERS.MAX_HP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( m_playerObj == null )
        {
            m_playerObj = GameObject.FindGameObjectWithTag("Player");
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        string sColliderTag = coll.gameObject.tag;

        if (sColliderTag == "PlayerAtk")
        {
            // Increase the player's CP
            if( m_playerObj )
                m_playerObj.SendMessage("IncCP", 1);

            m_nHP -= 1;
            if (m_nHP <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(coll.gameObject);
        }
        else if (sColliderTag == "Player")
        {
            // Increase the player's CP
            if( m_playerObj)
                m_playerObj.SendMessage("IncCP", 2);

            //Destroy(gameObject);
        }
    }
}
