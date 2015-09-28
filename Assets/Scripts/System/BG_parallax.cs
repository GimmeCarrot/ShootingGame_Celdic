using UnityEngine;
using System.Collections;

public class BG_parallax : MonoBehaviour {

    public Vector2 vSpeed = new Vector2(7, 7);
    public Vector2 vDirection = new Vector2(0, -1);

    public Transform mainCam;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vMovement = new Vector3(vSpeed.x * vDirection.x, vSpeed.y * vDirection.y, 0);
        vMovement *= Time.deltaTime;

        for (int  i = 0;  i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);

            if (childTransform != null)
            {
                childTransform.Translate(vMovement);
            }
        }

        /*
        if (transform.GetComponent<Renderer>().IsVisibleFrom(mainCam.GetComponent<Camera>()) == false)
        {
            Debug.Log("kyayayaya");
        }
        */

    }
}
