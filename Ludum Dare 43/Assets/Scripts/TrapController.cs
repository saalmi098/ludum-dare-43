using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    public GameObject knight;
    public Animator animator;

    KnightController knightController;

    void Start()
    {
        knightController = knight.transform.GetComponent<KnightController>();
    }

    void OnTriggerEnter2D()
    {
        animator.SetTrigger("TrapTrigger");

        if (knightController != null)
            knightController.TakeDamage(20);
    }
}
