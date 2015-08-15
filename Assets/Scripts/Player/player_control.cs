using UnityEngine;
using System.Collections;

public class player_control : MonoBehaviour
{

    public GameObject bullet;
    public float fSpeed;
    public float fBulletTimeGap;

    private float fLastBulletTime;

    // Use this for initialization
    void Start()
    {
        fLastBulletTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float fMoveSpeed = Input.GetAxis("Horizontal") * Time.deltaTime;
        fMoveSpeed *= Input.GetAxis("Slow") > 0 ? 1 : fSpeed;
        transform.Translate( fMoveSpeed, 0, 0);

        if ( Input.GetKey("space") )
        {
            if (Time.time - fLastBulletTime > fBulletTimeGap)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                fLastBulletTime = Time.time;
            }
        }
    }
}
