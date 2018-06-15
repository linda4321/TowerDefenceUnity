using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon {

    public GameObject explosion;
   // private ParticleSystem[] particles;

  //  private float duration = 0;
    void Start()
    {
   //     particles = explosion.GetComponentsInChildren<ParticleSystem>();

   //     foreach (ParticleSystem p in particles)
   //         if (p.main.duration > duration)
   //             duration = p.main.duration;
    }

    //protected override void DestroyOnGroundCollision()
    //{
    //}

    //protected override void DestroyOnEnemyCollision()
    //{
    //}

    protected override void OnCollision()
    {
        GameObject explosion = GameObject.Instantiate(this.explosion, transform.position, transform.rotation);
        ParticleSystem[] particles = explosion.GetComponentsInChildren<ParticleSystem>();

        float duration = 0;
        foreach (ParticleSystem p in particles)
            if (p.main.duration > duration)
                duration = p.main.duration;

        foreach (ParticleSystem p in particles)
            if(!p.isPlaying)
                p.Play();

        Destroy(this.gameObject);
    }
}
