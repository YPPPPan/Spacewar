using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    private const float MoveCooldown = 3f;
    private Rigidbody2D _rb;
    private Transform _tr;
    private Gun _gun;
    public static BulletManage Bullets;
    private float _lastMove;
    System.Random rm;
    private Quaternion rota;
    private int HP;
    private int level;
    private int speed;
    private int number;
    // Start is called before the first frame update
    public void Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = GetComponent<Transform>();
        _gun = GetComponent<Gun>();
        Bullets = new BulletManage();
        _lastMove = Time.time;
        rm = new System.Random();
        rota = new Quaternion();
        rota.eulerAngles = new Vector3(0, 0, 0);
        HP = 3;
        level = 1;
        speed = 1;
        number = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _gun.Fire(new Vector2(_tr.position.x, _tr.position.y), 2, level, speed, number);
        if (Time.time > _lastMove + MoveCooldown)
        {
            _lastMove = Time.time;
            Move();
        }
        _tr.rotation = rota;
    }

    private void Move()
    {
        float x = (float)rm.NextDouble() - 0.5f;
        float y = (float)rm.NextDouble() - 0.5f;
        if (_tr.position.x + x * MoveCooldown > 10f || _tr.position.x + x * MoveCooldown < -10f) x = -x;
        if (_tr.position.y + y * MoveCooldown > 4f || _tr.position.y + y * MoveCooldown < -4f) y = -y;
        _rb.velocity = new Vector2(x, y);
    }

    internal void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EnemyBullet(Clone)")
        {
            HP -= 1;
            Destroy(other.gameObject);
            if (HP == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<Score>().AllyDestroy();
            }
        }

        else if (other.gameObject.name == "Meat(Clone)")
        {
            if (level < 3) level += 1;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.name == "Drink(Clone)")
        {
            if (speed < 4) speed *= 2;
            Destroy(other.gameObject);
        }

        else if(other.gameObject.name == "Cake(Clone)")
        {
            if (number < 3) number += 1;
            Destroy(other.gameObject);
        }

        else if(other.gameObject.name == "Fruit(Clone)")
        {
            _gun.charge();
            Destroy(other.gameObject);
        }

        else if(other.gameObject.name == "Vege(Clone)")
        {
            HP += 2;
            if (HP > 5) HP = 5;
            Destroy(other.gameObject);
        }
    }

    internal void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Enemy(Clone)")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            FindObjectOfType<Score>().AllyDestroy();
        }
    }
}
