using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargescript : MonoBehaviour
{
    public Image chargebar;
    public float charge = 0;
    public KeyCode ck;

    void Update()
    {
        if (Input.GetKey(ck))
        {
            charge += Time.deltaTime;
        }
        else
        {
            charge = 0;
        }

        if (charge > 2)
        {
            charge = 0;
        }

        chargebar.fillAmount = charge/2;
    }
}
