using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngryAliens
{
    public class Health : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float damage = 25f;
        public float painThreshold = 4f;
        public Sprite[] damageSprites; // Images that the sprite can be depending on health
        public SpriteRenderer rend; // Allows us to show or change what's being displayed

        private float currentHealth = 100f;
        private int spriteIndex = 0;

        void Die()
        {
            // Play partiles here
            // Play game over music
            // Destroy self
            Destroy(gameObject);
        }

        public void DealDamage(float damage)
        {
            // Reduce health by damage
            currentHealth -= damage;

            // Get percentage of health
            float percentage = currentHealth / maxHealth;
            // Use percentage to get index
            spriteIndex = (int)Mathf.Lerp(0, damageSprites.Length, percentage);
            // Update renderer's sprite to correspond with damage
            rend.sprite = damageSprites[spriteIndex];

            // If there's no more health
            if (currentHealth <= 0)
            {
                // Die
                Die();
            }
        }

        // Use this for initialization
        void Start()
        {
            currentHealth = maxHealth;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            // If the relative velocity reaches the pain threshold
            if (other.relativeVelocity.magnitude > painThreshold)
            {
                // Deal damage to object
                DealDamage(damage);
            }
        }
    }
}
