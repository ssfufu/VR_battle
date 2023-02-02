using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100;

    public void TakeDamage(float amount, GameObject bodyPartHit)
    {
        Debug.Log("Hit ennemy " + health);
        float totalDamage = 0;
        if (bodyPartHit.tag == "Head")
        {
            totalDamage = amount * 3f;
        }
        if (bodyPartHit.tag == "Torso")
        {
            totalDamage = amount * 1.5f;
        }
        if (bodyPartHit.tag == "Legs")
        {
            totalDamage = amount * 0.5f;
        }
        if(bodyPartHit.tag == "Untagged")
        {
            totalDamage = amount;
        }
        health -= totalDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
