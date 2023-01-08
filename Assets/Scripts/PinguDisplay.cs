using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguDisplay : MonoBehaviour
{
    [Header("Pingu parts")]
    [SerializeField] private SkinnedMeshRenderer _body;
    [SerializeField] private SkinnedMeshRenderer _hair;
    [SerializeField] private SkinnedMeshRenderer _feet;
    [SerializeField] private SkinnedMeshRenderer _eyes;

    [Header("Hat Game Objects")]
    [SerializeField] private List<GameObject> _hats;

    private void Start()
    {
        UpdatePingu();
    }
    private void OnEnable()
    {
        UpdatePingu();
    }
    public void UpdatePingu()
    {
        _body.material = GameManager.equipedBody;
        _hair.material = GameManager.equipedBody;
        _feet.material = GameManager.equipedBody;
        _eyes.material = GameManager.equipedEyes;
        foreach(GameObject hat in _hats) if(hat != null) hat.SetActive(false);
        if (GameManager.equipedHat != 0) _hats[GameManager.equipedHat].SetActive(true);

        if (GameManager.equipedHat == 4 || GameManager.equipedHat == 1) _hair.gameObject.SetActive(false);
        else _hair.gameObject.SetActive(true);
    }
    private void Update()
    {
        UpdatePingu();
    }
}
