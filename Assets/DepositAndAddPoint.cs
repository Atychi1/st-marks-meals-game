using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositAndAddPoint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            //GameObject go = GameObject.Find("Box");
            //CountFood countFood = go.GetComponent<CountFood>();
            //float boxFood = countFood.boxFood;
            Debug.Log("hey yes i got the food");
        }
    }
}
