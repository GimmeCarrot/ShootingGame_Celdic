using UnityEngine;
using System.Collections;

public class MobPat1 : MonoBehaviour
{

    public float fSpeed;

    // Use this for initialization
    void Start()
    {
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float fMoveSpeed = Time.deltaTime * fSpeed;
        transform.Translate(0, -1 * fMoveSpeed, 0);
    }
}
