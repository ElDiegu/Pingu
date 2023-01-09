using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        Debug.Log("Coin Collected");
        PinguSlideManager.coinsCollected++;
        FindObjectOfType<AudioManager>().Play("BuyItem");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coin destroyed");
        Destroy(gameObject);
    }
}
