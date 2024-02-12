using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountFood : MonoBehaviour
{
    public int boxFood = 0;
    public int life = 3;
    public Image[] lifeImages;
    public TMP_Text boxText;
    public Sprite[] emptyBoxSprites; // Array of empty box sprites
    public Sprite[] filledBoxSprites; // Array of filled box sprites
    public SpriteRenderer boxSpriteRenderer; // Reference to the sprite renderer of the box GameObject

    // Start is called before the first frame update
    private void Start()
    {
        UpdateLifeUI();
        UpdateBoxSprite(); // Update box sprite initially
    }

    void Update()
    {
        // Update the TMP Text with the current score
        if (boxText != null)
        {
            boxText.text = boxFood.ToString();
            
        }
    }

    private void UpdateLifeUI()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < life)
                lifeImages[i].enabled = true;
            else
                lifeImages[i].enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (boxFood == 5)
        {
            
            Debug.Log(boxFood);
        }
        else
        {
            if (collision.gameObject.tag == "Food" && life <= 2)
            {
                Destroy(collision.gameObject);
                boxFood++;
                Debug.Log(boxFood);
                UpdateLifeUI();
                UpdateBoxSprite();
            }
            else if (collision.gameObject.tag == "BadFood")
            {
                Destroy(collision.gameObject);
                boxFood = 0;
                Debug.Log(boxFood);
                life--;
                UpdateLifeUI();
                UpdateBoxSprite(); // Update UI when life changes
            }
            else if (collision.gameObject.tag == "Food" && life >= 3)
            {
                Destroy(collision.gameObject);
                boxFood++;
                Debug.Log(boxFood);
                UpdateBoxSprite();
            }
        }
        UpdateBoxSprite(); // Update box sprite after each collision
    }

    private void ChangeBoxSprite()
    {
        // Choose a random sprite from filledBoxSprites array
        int randomIndex = Random.Range(0, filledBoxSprites.Length);
        // Assign the chosen sprite to the sprite renderer
        if (boxSpriteRenderer != null && filledBoxSprites.Length > 0)
        {
            boxSpriteRenderer.sprite = filledBoxSprites[randomIndex];
        }
    }

    public void UpdateBoxSprite()
    {
        // If boxFood is 5, change the box sprite to a filled box sprite, otherwise, use an empty box sprite
        if (boxFood == 5 && filledBoxSprites.Length > 0)
        {
            ChangeBoxSprite();
        }
        else if (boxFood < 5 && emptyBoxSprites.Length > 0) // Change the condition here
        {
            // Choose any empty box sprite, assuming they are the same
            boxSpriteRenderer.sprite = emptyBoxSprites[0];
        }
        else if (boxFood == 0 && emptyBoxSprites.Length > 0)
        {
            boxSpriteRenderer.sprite = emptyBoxSprites[0];
        }
    }
}