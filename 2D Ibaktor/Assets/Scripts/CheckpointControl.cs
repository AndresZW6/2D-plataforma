using UnityEngine;

public class CheckpointControl : MonoBehaviour
{
    public static CheckpointControl instance;

    private CheckpointSystem[] checkpoints;

    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpoints = FindObjectsByType<CheckpointSystem>();

        spawnPoint = PlayerControl.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesactivateCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
