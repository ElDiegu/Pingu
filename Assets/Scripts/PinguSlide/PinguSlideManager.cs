using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinguSlideManager : MonoBehaviour
{
    public static PinguSlideManager Instance { get; private set; }

    [Header("Game Logic")]
    [SerializeField] private float _speed;
    public static float speed;
    private static float _storedSpeed;
    private static float _originalSpeed;
    public static bool playing;
    [SerializeField] private GameObject _gameOverScreen;

    [Header("Canvas")]
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Camera _camera;
    public static float cameraSize;

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
        cameraSize = _camera.orthographicSize;
        speed = _speed * (cameraSize / 2);
        _originalSpeed = speed;
        coinsCollected = 0;
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
        if(firstTime) GenerateObstacle();
        while (playing)
        {
            yield return new WaitForSeconds(_obstacleDelay * (_originalSpeed/speed));
            GenerateObstacle();
        }
    }
    private IEnumerator CoinGeneration()
    {
        while (playing)
        {
            yield return new WaitForSeconds(Random.Range(1, 5) * (_originalSpeed/speed));
            GenerateCoin();
        }
    }
    private void GenerateSpawnPosition()
    {
        _spawnPosition.y = _spawnPoint.transform.localPosition.y;
        var _screenSize = _spawnPoint.GetComponent<RectTransform>().rect.width;
        Debug.Log(_screenSize);
        _spawnPosition.x = Random.Range(-_screenSize/2, _screenSize/2);
        _spawnPosition.z = -1.0f;
    }
    private void GenerateObstacle()
    {
        GenerateSpawnPosition();
        Debug.Log(_spawnPosition);
        //Debug.Log(Instantiate(_obstaclePrefab, _spawnPosition, new Quaternion(), _canvas.transform).transform.localPosition);
        Instantiate(_obstaclePrefab, _canvas.transform).transform.localPosition = _spawnPosition;
        Debug.Log("Obstacle generated");
    }
    private void GenerateCoin()
    {
        GenerateSpawnPosition();
        //Instantiate(_coinPrefab, _camera.ScreenToWorldPoint(_spawnPosition), new Quaternion(), _canvas.transform);
        Instantiate(_coinPrefab, _canvas.transform).transform.localPosition = _spawnPosition;
        Debug.Log("Coin generated");
    }
    public static void StopGame()
    {
        Instance.StopAllCoroutines();
        _storedSpeed = speed;
        playing = false;
        speed = 0.0f;
    }
    public void ResumeGame()
    {
        speed = _storedSpeed;
        playing = true;
        StartCoroutine(ObstacleGeneration(false));
        StartCoroutine(CoinGeneration());
    }
    public static void GameOver()
    {
        StopGame();
        Instance._gameOverScreen.SetActive(true);
        GameManager.coins += coinsCollected;
        GameManager.SaveData();
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
