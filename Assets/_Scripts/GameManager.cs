using Cinemachine;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static Action LoseGame;
    public static bool isDead;

    public static bool GameStarted;
    public static Action StartGame;

    public static Action GemGained;
    public static int Gems;

    [SerializeField] private CinemachineVirtualCamera _vCam;

    private void Awake()
    {
        isDead = false;
        _vCam.Follow = FindObjectOfType<BallController>().gameObject.transform;
        GameStarted = false;
        Gems = 0;
    }

    private void _loseGame()
    {
        Debug.Log("You Lose");
        isDead = true;
        _vCam.Follow = null;
    }
    private void PrintGems()
    {
        Debug.Log(Gems);
    }
    private void OnEnable()
    {
        LoseGame += _loseGame;
        GemGained += PrintGems;
    }

    private void OnDisable()
    {
        LoseGame -= _loseGame;
        GemGained -= PrintGems;
    }

    private void Update()
    {
        if (!GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStarted = true;
                StartGame?.Invoke();
            }
        }
    }
}
