using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFood : MonoBehaviour
{
    public int boxFood = 0;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (boxFood == 5){

            Destroy(collision.gameObject);
            Debug.Log(boxFood);
        }
        else
        {
            if (collision.gameObject.tag == "Food")
            {
                Destroy(collision.gameObject);
                boxFood++;
                Debug.Log(boxFood);
            }
        }
        
    }
}
