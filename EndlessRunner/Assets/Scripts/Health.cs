using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Renderer rend;
    Color c;

    public int maxHealth;
    public int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 10, false);
        rend = GetComponent<Renderer>();
        c = rend.material.color;
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
            SoundManagerScript.PlaySound("hit");
            currentHealth = currentHealth - 1;
            StartCoroutine("Invulnerable");
        }
    }

    IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision (9, 10, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds (3f);
        Physics2D.IgnoreLayerCollision (9, 10, false);
        c.a = 1f;
        rend.material.color = c;
    }
}
