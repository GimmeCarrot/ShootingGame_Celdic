using UnityEngine;
using System.Collections;

public class player_atk_normal : MonoBehaviour
{
    public float fAtkSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float fMoveSpeed = Time.deltaTime * fAtkSpeed;
        transform.Translate(0, fMoveSpeed, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
