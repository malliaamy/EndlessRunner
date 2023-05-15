using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            TransitionDeath();
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    void TransitionDeath()
    {
        Destroy(gameObject);
        PlayerPrefs.SetFloat("distanceScore", playerController.distanceUnit);
        PlayerPrefs.SetInt("coinScore", playerController.coinAmount);
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            currentHealth = currentHealth - 1;
        }
    }
}
