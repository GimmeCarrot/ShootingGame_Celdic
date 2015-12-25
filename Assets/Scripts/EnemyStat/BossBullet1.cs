using UnityEngine;
using System.Collections;

public class BossBullet1 : MonoBehaviour {

    public float fAtkSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float fMoveSpeed = Time.deltaTime * fAtkSpeed * (-1);   // -1 multiplied to move down
        transform.Translate(0, fMoveSpeed, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
