using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguSlideManager : MonoBehaviour
{
    public static PinguSlideManager Instance { get; private set; }

    [Header("Game Logic")]
    [SerializeField] private float _speed;
    public static float speed;
    private static float _storedSpeed;
    public static bool playing;
    [SerializeField] private GameObject _gameOverScreen;

    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;

    [Header("Obstacles")]
    [SerializeField] private GameObject _obstaclePrefab;
    

    [Header("Coins")]
    [SerializeField] private GameObject _coinPrefab;
    public static int coinsCollected;
    [SerializeField] private int _coinsCollected;

    [Header("Spawn Control")]
    [SerializeField] private GameObject _spawnPoint;
    private Vector3 _spawnPosition;
    [SerializeField] private float _obstacleDelay;

    private void Start()
    {
        Instance = this;
        speed = _speed;
        playing = true;
        StartCoroutine(ObstacleGeneration(true));
        StartCoroutine(CoinGeneration());
    }
    private void Update()
    {
        _speed = speed;
        _coinsCollected = coinsCollected;
    }

    private IEnumerator ObstacleGeneration(bool firstTime)
    {
        var _originalSpeed = speed;
        if(firstTime) GenerateObstacle();
        while (playing)
        {
            yield return new WaitForSeconds(_obstacleDelay * (_originalSpeed/_speed));
            GenerateObstacle();
        }
    }
    private IEnumerator CoinGeneration()
    {
        var _originalSpeed = speed;
        while (playing)
        {
            yield return new WaitForSeconds(Random.Range(1, 5) * (_originalSpeed/_speed));
            GenerateCoin();
        }
    }
    private void GenerateSpawnPosition()
    {
        _spawnPosition.y = _spawnPoint.transform.position.y;
        var _screenSize = _canvas.GetComponent<RectTransform>().rect.width;
        _spawnPosition.x = Random.Range(_spawnPoint.transform.position.x, 
                                                _spawnPoint.transform.position.x + _screenSize - 
                                                (_obstaclePrefab.GetComponent<RectTransform>().rect.width * _obstaclePrefab.GetComponent<RectTransform>().localScale.x));
        _spawnPosition.z = -1.0f;
    }
    private void GenerateObstacle()
    {
        GenerateSpawnPosition();
        Instantiate(_obstaclePrefab, _spawnPosition, new Quaternion(), _canvas.transform);
        Debug.Log("Obstacle generated");
    }
    private void GenerateCoin()
    {
        GenerateSpawnPosition();
        Instantiate(_coinPrefab, _spawnPosition, new Quaternion(), _canvas.transform);
        Debug.Log("Coin generated");
    }
    private static void StopGame()
    {
        Instance.StopAllCoroutines();
        _storedSpeed = speed;
        playing = false;
        speed = 0.0f;
    }
    private void ResumeGame()
    {
        StartCoroutine(ObstacleGeneration(false));
        StartCoroutine(CoinGeneration());
        playing = true;
        speed = _storedSpeed;
    }
    public static void GameOver()
    {
        StopGame();
        Instance._gameOverScreen.SetActive(true);
    }
    
}
