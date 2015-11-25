using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class player_stat : MonoBehaviour
{

    enum NUMBERS
    {
        MAX_HP = 5,
        MAX_CP = 200,
        MID_CP = 100,
    };

    public int m_nHP;
    public int m_nCP;

    public Image m_Bar_HPRed;
    public Image m_Bar_CPGreen;
    public Image m_Bar_CPGreen2;

    // Use this for initialization
    void Start()
    {
        if (m_nHP <= 0)
        {
            m_nHP = (int)NUMBERS.MAX_HP;
        }
        m_nCP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_Bar_HPRed.fillAmount = (float)m_nHP / (float)NUMBERS.MAX_HP;

        if ( m_nCP <= (int)NUMBERS.MID_CP )
        {
            m_Bar_CPGreen.fillAmount = (float)m_nCP / (float)NUMBERS.MID_CP;
            m_Bar_CPGreen2.fillAmount = 0;
        }
        else
        {
            m_Bar_CPGreen.fillAmount = 1;
            m_Bar_CPGreen2.fillAmount = (float)(m_nCP - (int)NUMBERS.MID_CP) / (float)NUMBERS.MID_CP;
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        string sColliderTag = coll.gameObject.tag;

        if (sColliderTag == "Mob")
        {
            m_nHP -= 1;
            if (m_nHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // HP, CP 증감 함수. 물론 마이너스값 들어오면 감소한다.
    void IncHP(int nInc)
    {
        m_nHP += nInc;
    }

    void IncCP(int nInc)
    {
        m_nCP += nInc;
    }
}
