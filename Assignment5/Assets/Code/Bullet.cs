using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public const float Lifetime = 3.5f; // bullets last this long
    public float bulletType;
    private float _deathtime;
    // Start is called before the first frame update
    public void Initialize(float bulletType, int flag)
    {
        _deathtime = Time.time + Lifetime;
        if(!(flag == 1))
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,5f);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,-5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _deathtime) { Die(); }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
