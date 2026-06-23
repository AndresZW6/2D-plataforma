using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Variables para La UI sistema de vida
    public static UIController instance;

    public Image Heart1, Heart2,Heart3;

    public Sprite heartFull, heartEmpty, heartHalf;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthUI()
    {
        //Opciones a ejecutarse para actualizar la UI de vida
        switch(PlayerHealthSystem.instance.currentHealth)
        {
            case 6:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;

                break;

            case 5:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartHalf;

                break;

            case 4:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartEmpty;

                break;

            case 3:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartHalf;
                Heart3.sprite = heartEmpty;

                break;

            case 2:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;

            case 1:
                Heart1.sprite = heartHalf;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;

            case 0:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;
           
            //Caso a ejecutar cuando ninguno de los otros casos se resuelve
            default:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;

                break;
        }
    }
}
