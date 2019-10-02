using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool goingRight = true;
    public Transform target;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(target.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (goingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                goingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                goingRight = true;
            }
        }

        RaycastHit2D wallinfo = Physics2D.Raycast(target.position, Vector2.left, distance);
        if (wallinfo.collider == true && wallinfo.transform.gameObject.tag != "Player")
        {
            if (goingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                goingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                goingRight = true;
            }
        }
    }
}
