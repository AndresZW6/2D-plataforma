using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public SpriteRenderer theSR;

    public Sprite CheckPointOn, CheckPointOff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CheckpointControl.instance.DesactivateCheckpoints();

            theSR.sprite = CheckPointOn;

            CheckpointControl.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckPoint()
    {
        theSR.sprite = CheckPointOff;
    }
}
