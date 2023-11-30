using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformFab;

    private void Start()
    {
        for (int i = 0; i < 20;  i++)
        {
            SpawnBlock();
        }
        InvokeRepeating("SpawnBlock", 1, 0.2f);
        
    }
    private void Update()
    {
        if (GameManager.isDead)
            CancelInvoke();
    }
    private void SpawnBlock()
    {
        GameObject platform = Instantiate(_platformFab[Random.Range(0, _platformFab.Length)]);
        
        platform.transform.position = transform.position;

        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                transform.position = new Vector3(transform.position.x + 2, 0, transform.position.z);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x, 0, transform.position.z + 2);
                break;
        }
    }
}
