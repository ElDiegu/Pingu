using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguSlide : MonoBehaviour
{
    public int HP;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _hitbox;
    [SerializeField] private float _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Screen Touch Input Control
        if(Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            Vector2 _startPos = new Vector2();
            

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = _touch.position;
                    break;
                case TouchPhase.Moved:
                    var _direction = _touch.position - _startPos;
                    MovePingu(_direction.x);
                    break;
            }
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
    }

    public void SufferDamage(int damage)
    {
        HP -= damage;
    }

    private void MovePingu(float direction)
    {
        Debug.Log("Move Pingu.");
        transform.Translate(new Vector3(direction, 0, 0) * _speed * Time.deltaTime);
    }
}
