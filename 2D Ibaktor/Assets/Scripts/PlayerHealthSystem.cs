using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public static PlayerHealthSystem instance;
    //Variables para hacer operaciones de la vida del jugador
    public int currentHealth, maxHealth;

    public float invincibleLenght;
    private float invincibleCounter;

    private SpriteRenderer theSR;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;       

        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }   
    }

    //Funcion para hacer la operacion de recibir daño
    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
        currentHealth --;

        if(currentHealth <= 0)
        {
            //gameObject.SetActive(false);

            LevelManager.instance.RespawnPlayer();
        }
        else
        {
            invincibleCounter = invincibleLenght;
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);

            PlayerControl.instance.KnockBack();
        }

        //Mandamos a llamar del script UIController la funcion para actualizar la UI
        UIController.instance.UpdateHealthUI();
        }
    }
}
