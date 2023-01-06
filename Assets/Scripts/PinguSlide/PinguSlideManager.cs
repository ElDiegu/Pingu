using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguSlideManager : MonoBehaviour
{
    public static PinguSlideManager Instance { get; private set; }

    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _obstacleDelay;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private float _speed;
    public static float speed;
    private Vector3 _obstacleSpawnPosition;
    public bool playing;
    private void Start()
    {
        speed = _speed;

        playing = true;
        StartCoroutine(ObstacleGeneration());
    }

    private IEnumerator ObstacleGeneration()
    {
        var _originalSpeed = speed;
        GenerateObstacle();
        while (playing)
        {
            yield return new WaitForSeconds(_obstacleDelay * (_originalSpeed/_speed));
            GenerateObstacle();
        }
    }

    private void GenerateSpawnPosition()
    {
        _obstacleSpawnPosition.y = _spawnPoint.transform.position.y;
        var _screenSize = _canvas.GetComponent<RectTransform>().rect.width;
        _obstacleSpawnPosition.x = Random.Range(_spawnPoint.transform.position.x, 
                                                _spawnPoint.transform.position.x + _screenSize - 
                                                (_obstaclePrefab.GetComponent<RectTransform>().rect.width * _obstaclePrefab.GetComponent<RectTransform>().localScale.x));
        _obstacleSpawnPosition.z = -1.0f;
    }

    private void GenerateObstacle()
    {
        GenerateSpawnPosition();
        Instantiate(_obstaclePrefab, _obstacleSpawnPosition, new Quaternion(), _canvas.transform);
    }

    private void Update()
    {
        _speed = speed;
    }
}
