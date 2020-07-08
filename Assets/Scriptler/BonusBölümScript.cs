using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BonusBölümScript : MonoBehaviour
{
    [SerializeField] Text BonusBölüm;
    [SerializeField] Text helpText;
    private float zaman = 0;
   
    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman <= 5)
        {
            BonusBölüm.text = "Bonus Bölüm";
            helpText.text = "Dönen küpü yutarsan boyutun 2 kat artar!";

        }

        else
        {
            BonusBölüm.text = " ";
            helpText.text = " ";
        }

    }
}

