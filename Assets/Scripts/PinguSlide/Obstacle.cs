using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private List<Sprite> _sprites;
    private float _speed;
    void Start()
    {
        _image.sprite = _sprites[Random.Range(0, _sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * PinguSlideManager.speed * Time.deltaTime);
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        if (transform.parent == null) return;

        var _rectTransform = transform.parent.GetComponent<RectTransform>().rect;

        if (transform.localPosition.y < (_rectTransform.height / -2))
        {
            PinguSlideManager.speed += 7;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
        if (collision.gameObject.tag != "Player") return;

        collision.gameObject.GetComponent<PinguSlide>().SufferDamage(_sprites.IndexOf(_image.sprite) + 1);
        Destroy(gameObject);
    }
}
