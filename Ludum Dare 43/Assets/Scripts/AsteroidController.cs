using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KnightController knight = collision.gameObject.GetComponent<KnightController>();
            knight.TakeDamage();
        }

        Destroy(gameObject);
    }
}
