using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.Collections;

public class DamageText : PoolAble
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float alphaSpeed;
    [SerializeField] private float duration = 2f;

    TextMeshPro text;
    Color alpha;

    private Vector3 moveDirection = Vector3.up;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;

    }

    public void Init(string damage)
    {
        text.text = damage;
        StartCoroutine(TextEffect());

    }


    IEnumerator TextEffect()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        { 

            transform.Translate(moveDirection);
            alpha.a = Mathf.Lerp(1f, 0f, elapsedTime / alphaSpeed);
            text.color = alpha;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        ReleaseObject();
    }


    
}
