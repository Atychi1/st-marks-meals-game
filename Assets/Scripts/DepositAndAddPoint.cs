using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositAndAddPoint : MonoBehaviour
{
    // Tag of the GameObject with the CountFood script
    public string countFoodTag = "Box";

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            // Find the GameObject with the CountFood script attached
            GameObject countFoodObject = GameObject.FindWithTag(countFoodTag);
            GameObject pointsManager = GameObject.Find("PointsManager");

            if (countFoodObject != null)
            {
                CountFood countFood = countFoodObject.GetComponent<CountFood>();
                PointsManager pointsManagerpoints = pointsManager.GetComponent<PointsManager>();

                if (countFood != null && countFood.boxFood == 5)
                {
                    countFood.boxFood = 0;
                    pointsManagerpoints.points++;
                    countFood.UpdateBoxSprite(); // Update box sprite
                    Debug.Log("Box deposited! Current food count: " + countFood.boxFood + "points:" + pointsManagerpoints.points);
                }
                else
                {
                    Debug.Log("Not enough food to deposit!");
                }
            }
            else
            {
                Debug.LogError("GameObject with tag " + countFoodTag + " not found.");
            }
        }
    }
}
