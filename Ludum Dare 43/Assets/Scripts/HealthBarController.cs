using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

    public GameObject knight;
    KnightController knightController;

    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        knightController = knight.transform.GetComponent<KnightController>();
    }

    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        var health = knightController != null ? knightController.health : 0;

        // max constraint
        if (health > numberOfHearts * 10)
        {
            health = numberOfHearts * 10;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            // display full or empty heart
            if (i * 10 < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // in case that less hearts want to be displayed
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
