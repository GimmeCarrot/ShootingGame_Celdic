using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class BossStat1 : MonoBehaviour {

    enum NUMBERS
    {
        MAX_HP = 100,
    };

    private int m_nHP;
    private int m_nEP;
    private int m_nCP;

    private GameObject m_playerObj;

    private Image m_Bar_HPRed;
    private Image m_Bar_HPBG;

    // 보스 공격에 쓰이는 불렛....인데 이건 종류가 많겠지.
    private float fLastBulletTime;
    private float fBulletTimeGap;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        m_playerObj = GameObject.FindGameObjectWithTag("Player");
        m_nHP = (int)NUMBERS.MAX_HP;

        m_Bar_HPRed = GameObject.Find("Boss_Bar_HP_Red").GetComponent<Image>();
        m_Bar_HPRed.enabled = false;
        m_Bar_HPBG = GameObject.Find("Boss_Bar_HP").GetComponent<Image>();
        m_Bar_HPBG.enabled = false;

        fLastBulletTime = 0;
        fBulletTimeGap = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if( m_Bar_HPRed && m_Bar_HPRed.enabled == false && m_Bar_HPBG && m_Bar_HPBG.enabled == false
            && m_nHP < (int)NUMBERS.MAX_HP )
        {
            m_Bar_HPRed.enabled = true;
            m_Bar_HPBG.enabled = true;
        }

        m_Bar_HPRed.fillAmount = m_nHP / (float)NUMBERS.MAX_HP;

        CheckPhase();

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        string sColliderTag = coll.gameObject.tag;

        // If Player's attack hit this Boss
        if (sColliderTag == "PlayerAtk")
        {
            // Increase the player's CP
            if( m_playerObj )
                m_playerObj.SendMessage("IncCP", 1);

            // Decrease the Boss's HP
            IncHP(-1);
            if (m_nHP <= 0)
            {
                Destroy(gameObject);
            }

            // Destroy the Player's bullet
            Destroy(coll.gameObject);
        }
        else if (sColliderTag == "Player")
        {
            // Increase the player's CP
            if( m_playerObj)
                m_playerObj.SendMessage("IncCP", 2);
        }
    }

    // (Boss의) HP, CP 증감 함수. 물론 마이너스값 들어오면 감소한다.
    void IncHP(int nInc)
    {
        m_nHP += nInc;
    }

    void IncCP(int nInc)
    {
        m_nCP += nInc;
    }

    // Functions for the Boss's shooting pattern starts from here.
    void CheckPhase()
    {
        // 간단하게 HP량을 기준으로 두 개의 페이즈를 만들어 보자.
        // 페이즈에 따라 같은 bullet에 다른 스크립트를 붙이는 것도 괜찮을 것 같다...
        if( m_nHP > (float)NUMBERS.MAX_HP * 0.5 )
        {
            //Instantiate(bullet, transform.position, Quaternion.identity);
        }
        else
        {
            if (Time.time - fLastBulletTime > fBulletTimeGap)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                fLastBulletTime = Time.time;
            }
        }
    }
}
