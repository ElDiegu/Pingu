using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguSlide : MonoBehaviour
{
    [Header("Pingu Data")]
    [SerializeField] private int _HP;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _hitbox;
    [SerializeField] private float _speed;

    [Header("Gyroscope Logic")]
    [SerializeField] private Gyroscope _gyroscope;
    [SerializeField] private Quaternion _gyroRotation;
    [SerializeField] private bool _gyroActive;

    [Header("Touch Screen Logic")]
    [SerializeField] private Vector2 _touchStartPos;
    [SerializeField] private float _touchDirection;

    void Start()
    {
        EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        #region Screen Touch Input Control
        if(Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPos = _touch.position;
                    Debug.Log("_startPos set at:" + _touchStartPos);
                    break;
                case TouchPhase.Moved:
                    _touchDirection = _touch.position.x - _touchStartPos.x;
                    break;
            }

            Debug.Log(_touchDirection / (_canvas.GetComponent<RectTransform>().rect.width / 2));
            MovePingu(_touchDirection / (_canvas.GetComponent<RectTransform>().rect.width / 2));
        }
        #endregion

        #region Key Input Control
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MovePingu(-1.0f);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MovePingu(1.0f);
        }
        #endregion

        #region Gyroscope Input Control
        if (_gyroActive)
        {
            _gyroRotation = _gyroscope.attitude;

            MovePingu(_gyroRotation.x);
        }
        #endregion
    }

    private void EnableGyro()
    {
        if (_gyroActive) return;

        if (SystemInfo.supportsGyroscope)
        {
            _gyroscope = Input.gyro;
            _gyroscope.enabled = true;
        }

        _gyroActive = _gyroscope.enabled;
    }

    public void SufferDamage(int damage)
    {
        _HP -= damage;

        if (_HP <= 0) PinguSlideManager.GameOver();
    }
    private void MovePingu(float direction)
    {
        if (!PinguSlideManager.playing) return;
        var _canvasSize = _canvas.GetComponent<RectTransform>().rect.width - 50;

        if (transform.localPosition.x > (_canvasSize - gameObject.GetComponent<RectTransform>().rect.width) / 2 && direction > 0) return;
        if(transform.localPosition.x < (-_canvasSize + gameObject.GetComponent<RectTransform>().rect.width) / 2 && direction < 0) return;

        transform.Translate(new Vector3(direction, 0, 0) * _speed * Time.deltaTime);
    }
}
