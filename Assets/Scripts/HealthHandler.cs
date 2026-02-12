using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float startingHealth = 10.0f;
    public Image healthBarForeground;
    private float currentHealth = 0.0f;

    public UnityEvent Health_Became_Zero;

    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float incoming_damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - incoming_damage, 0.0f, startingHealth);
        healthBarForeground.fillAmount = currentHealth / startingHealth;
        if(healthBarForeground.fillAmount == 0.0f)
        {
            Health_Became_Zero.Invoke();
        }
    }
}
