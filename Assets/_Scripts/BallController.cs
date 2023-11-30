using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _ballSpeed;
    private bool _directionZ;
    [SerializeField] private bool isGrounded = true;
    private Rigidbody rb;
    [SerializeField] private LayerMask _layerMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!GameManager.GameStarted) return;


        if (GameManager.isDead) return;

        if (_directionZ) TranslateZ();
        else TranslateX();
        

        if (Input.GetMouseButtonDown(0))
        {
            SwitchDirection();
        }

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 5, _layerMask);

        if (!isGrounded)
        {
            ScoreManager.CheckForNewHighScore(); //I know this is scuffed shush....
            GameManager.LoseGame?.Invoke();
        }

    }

    private void TranslateX()
    {
        transform.Translate(Vector3.forward * _ballSpeed * Time.deltaTime);
    }

    private void TranslateZ()
    {
        transform.Translate(Vector3.right * _ballSpeed * Time.deltaTime);
    }
    private void SwitchDirection()
    {
        _directionZ = !_directionZ;
    }

    private void _loseGame()
    {
        rb.useGravity = true;
    }
    private void OnEnable()
    {
        GameManager.LoseGame += _loseGame;
    }
    private void OnDisable()
    {
        GameManager.LoseGame -= _loseGame;
    }
}
