using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPower : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float lifeTime = 7f;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime(lifeTime));
    }

    private void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.powerSFX();
            ScoreManager.instance.CandyPower();
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
