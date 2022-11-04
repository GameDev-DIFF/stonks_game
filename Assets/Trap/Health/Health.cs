using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable)
        {
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            Debug.Log("Damage: Je hebt 1 leven verloren");
        }
        else
        {
            if (!dead)
            {
                //Deactivates all attached component classes
                foreach (Behaviour comp in components)
                {
                    comp.enabled = false;
                }
            }
        }
    }
}
