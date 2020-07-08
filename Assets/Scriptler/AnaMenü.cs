using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenü : MonoBehaviour
{
    
    public void SahneDegis()
    {
        SceneManager.LoadScene("level1");
    }

    public void OyundanCik()
    {
        Application.Quit();
    }
}
