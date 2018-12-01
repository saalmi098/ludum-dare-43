using UnityEngine;
using UnityEngine.UI;

public class KnightHealth : MonoBehaviour {

    public int maxHealth;
    public int health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // max constraint
        if (health > numberOfHearts * 10)
        {
            health = numberOfHearts * 10;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i * 10 <= health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

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

    public void TakeDamage(int damageValue)
    {
        health -= damageValue;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
