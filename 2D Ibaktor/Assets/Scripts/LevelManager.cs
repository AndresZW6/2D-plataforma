using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRepawn;

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

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        PlayerControl.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRepawn);

        PlayerControl.instance.gameObject.SetActive(true);

        PlayerControl.instance.transform.position = CheckpointControl.instance.spawnPoint;

        PlayerHealthSystem.instance.currentHealth = PlayerHealthSystem.instance.maxHealth;
        UIController.instance.UpdateHealthUI();
    }
}
