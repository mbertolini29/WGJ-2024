using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Instancia única para el temporizador

    public float timerInit = 60f;
    public float timer = 60f;
    private bool isTimerRunning = false;

    public TMP_Text timeGame;

    //te quedaste sin tiempo.
    public GameObject sinTiempo;
    //public TMP_Text noTimeLeftMessage; // Texto para mostrar "Se quedó sin tiempo"

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //SceneManager.sceneLoaded += OnSceneLoaded;  // Registra el método OnSceneLoaded para cuando se cargue una nueva escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);

            if(timer <= 0f)
            {
                StopTimer();
                StartCoroutine(HandleTimeOut());
            }
        }
    }

    private void OnSceneLoaded(Scene scena, LoadSceneMode mode)
    {
        // Reasigna timeGame al componente TMP_Text de la nueva escena
        timeGame = GameObject.Find("TimeText")?.GetComponent<TMP_Text>();
        sinTiempo = GameObject.Find("SinTiempo");

        // Si existe el objeto "SinTiempo", lo desactiva al cargar la escena
        if (sinTiempo != null)
        {
            sinTiempo.SetActive(false);
        }

        if(scena.name == "Aldea")
        {
            ResetTimerForAldea();
        }
        else
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        //timer = timerInit; // Reiniciar el temporizador si es necesario
        //UpdateTimerDisplay(timer);
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
        
        if (timeGame != null)
        {
            timeGame.text = seconds.ToString("00");
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        timer = timerInit;
        UpdateTimerDisplay(timer);
    }

    public void ResetTimerForAldea()
    {
        timer = timerInit; 
    }

    public float GetElapsedTime()
    {
        return timer;
    }

    private IEnumerator HandleTimeOut()
    {
        if (sinTiempo != null)
        {
            sinTiempo.SetActive(true);
        }

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Aldea");
    }
}