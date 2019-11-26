using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultBarscript : MonoBehaviour
{
    public static float ultMeter = 0f;
    public float ultrate;
    private Transform ultimg;

    void Start()
    {
        ultimg = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ultrate = ultMeter;

        var um = ultMeter / 10;

        if (ultMeter >= 10)
        {
            ultMeter = 10f;
        }

        ultimg.localScale = new Vector3(um*12, 4.6f, 0);

        if(Input.GetButtonDown("Fire3") && ultMeter == 10f)
        {
            ultMeter = 0f;
        }

        
    }
}
