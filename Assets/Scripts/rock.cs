using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    private int damage = 20;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AI" && collision.relativeVelocity.magnitude > 17)
        {
            collision.gameObject.GetComponent<Military>().AddDamage(damage);
        }
        if (collision.gameObject.tag == "target")
        {
            collision.gameObject.GetComponent<Range_hit>().Hit();
        }
    }
}
