using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour {

    public float moveDistance = 3f;

	void FixedUpdate ()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, moveDistance), transform.position.y, transform.position.z);
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            collision.transform.parent = null;
        }
    }
}
