using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyS : MonoBehaviour
{
    public float sec;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, sec);
    }
}
