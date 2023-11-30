using DG.Tweening;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) Invoke("BlockFall", 0.5f);
    }


    private void BlockFall()
    {
        rb.useGravity = true;
    }
}
