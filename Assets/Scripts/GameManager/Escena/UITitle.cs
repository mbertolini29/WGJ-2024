using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitle : MonoBehaviour
{
    [SerializeField] GameObject CreditOn;
    [SerializeField] bool paused = false;

    public void Credit()
    {
        paused = !paused;
        //Time.timeScale = paused ? 0 : 1;
        CreditOn.SetActive(paused);
    }

    public void ContinueGame()
    {
        paused = !paused;
        //Time.timeScale = paused ? 0 : 1;
        CreditOn.SetActive(paused);
    }
}
