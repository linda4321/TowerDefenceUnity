using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon {

    public GameObject explosion;


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
        Destroy(explosion.gameObject, duration);
    }
}
