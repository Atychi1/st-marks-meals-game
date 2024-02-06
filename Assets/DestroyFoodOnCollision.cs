using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFoodOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
        }
    }
}
