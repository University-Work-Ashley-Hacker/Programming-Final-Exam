using UnityEngine;

public class BallCollision : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            GameManager.Gems++;
            GameManager.GemGained?.Invoke();
        }
    }
}
