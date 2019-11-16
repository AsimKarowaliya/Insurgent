using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargescript : MonoBehaviour
{
    public Image chargebar;
    public float charge = 0;
    public KeyCode ck;
    public KeyCode ck1;

    void Update()
    {
        if (Input.GetKey(ck) || Input.GetKey(ck1))
        {
            charge += Time.deltaTime;
        }
        else
        {
            charge = 0;
        }

        if (charge > 1)
        {
            charge = 0;
        }

        chargebar.fillAmount = charge/1;
    }
}
