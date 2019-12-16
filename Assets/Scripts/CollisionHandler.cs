using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] int enemyHealth = 5;
    [SerializeField] ParticleSystem damageFX;
    [SerializeField] ParticleSystem deathFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if (enemyHealth > 1)
        {
            enemyHealth -= 1;
            damageFX.Play();

        }
        else
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        var dFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        dFX.Play();
        float destroyDelay = dFX.main.duration;
        Destroy(dFX.gameObject, destroyDelay);

        Destroy(gameObject);
    }
}
