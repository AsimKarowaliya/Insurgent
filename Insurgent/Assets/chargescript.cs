using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargescript : MonoBehaviour
{
    public Image chargebar;
    public float charge = 0;
    private float tba;
    private float stba = 1;
    public KeyCode ck;
    public KeyCode ck1;

    void Update()
    {
        if(tba <= 0)
        {
            if (Input.GetKey(ck) || Input.GetKey(ck1))
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
                tba = stba;
            }

            chargebar.fillAmount = charge / 2;
        }
        else
        {
            tba -= Time.deltaTime;
        }
        
    }
}
