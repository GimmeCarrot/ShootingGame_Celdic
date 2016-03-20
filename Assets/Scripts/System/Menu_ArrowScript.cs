using UnityEngine;
using System.Collections;

public class Menu_ArrowScript : MonoBehaviour
{

    enum PAGES
    {
        PAGE_FIE = -1,
        PAGE_ELIOT = 0,
        PAGE_MACHIAS = 1,
    };

    private PAGES m_nPresentPage;
    private Vector3 m_vVelocity = Vector3.zero;
    private float m_fMenuMoveSpeed = 0.3F;

    // Use this for initialization
    void Start()
    {
        m_nPresentPage = PAGES.PAGE_ELIOT;
    }

    // Update is called once per frame
    void Update()
    {
        // 정확히 포지셔닝을 하고 싶은데 일단 이미지도 더미고... 해서 대충 지금 더미에 맞춰 잡는다.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (m_nPresentPage > PAGES.PAGE_FIE)
            {
                m_nPresentPage--;
                transform.Translate(-7, 0, 0);
                //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(-7, 0, 0), ref m_vVelocity, m_fMenuMoveSpeed);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (m_nPresentPage < PAGES.PAGE_MACHIAS)
            {
                m_nPresentPage++;
                transform.Translate(7, 0, 0);
            }
        }
    }
}
