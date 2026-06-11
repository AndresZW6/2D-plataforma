using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Declaramos variables publicas de tipo CanvasGroup
    public CanvasGroup MenuCanvas;
    public CanvasGroup OptionsCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Activamos y desactivamos el canvas a utilizar
        OptionsCanvas.gameObject.SetActive(false);
        MenuCanvas.gameObject.SetActive(true);
    }

    //Funcion para ejecutar escena de juego
    public void Play()
    {
        //Instruccion para poder ejecutar una escena distinta
        SceneManager.LoadScene("Game_001");
    }

    //Funcion para ingresar  al menu de opciones
    public void Options()
    {
        //Activamos y desactivamos el canvas a utilizar
        OptionsCanvas.gameObject.SetActive(true);
        MenuCanvas.gameObject.SetActive(false);
    }

    //Funcion para regresar al menu principal
    public void Return()
    {
        //Activamos y desactivamos el canvas a utilizar
        OptionsCanvas.gameObject.SetActive(false);
        MenuCanvas.gameObject.SetActive(true);
    }

    //Funcion para salir del juego
    public void Exit()
    {
        //Intruccion para cerrar aplicacion
        Application.Quit();
        Debug.Log("Cerrando el juego");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
