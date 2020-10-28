using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private const float MoveCooldown = 3f;
    private Rigidbody2D _rb;
    private Transform _tr;
    private Gun _gun;
    public static BulletManage Bullets;
    private float _lastMove;
    System.Random rm;
    private Quaternion rota;
    private int HP;
    public void Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = GetComponent<Transform>();
        _gun = GetComponent<Gun>();
        Bullets = new BulletManage();
        _lastMove = Time.time;
        rm = new System.Random();
        rota = new Quaternion();
        rota.eulerAngles = new Vector3(180, 0, 0);
        HP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        _gun.Fire(new Vector2(_tr.position.x, _tr.position.y), 1);
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
        if (_tr.position.x + x * MoveCooldown > 10f  ||  _tr.position.x + x * MoveCooldown < -10f) x = -x;
        if (_tr.position.y + y * MoveCooldown > 4f || _tr.position.y + y * MoveCooldown < -4f) y = -y;
        _rb.velocity = new Vector2(x, y);
    }

    internal void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.gameObject.name == "AllyBullet(Clone)")&& !(other.gameObject.name == "EnemyBullet(Clone)") && !(other.gameObject.name == "AllyBullet2(Clone)") && !(other.gameObject.name == "AllyBullet3(Clone)"))
        {
            FindObjectOfType<EnemyManage>().SpawnAlly();
            FindObjectOfType<Score>().AddScore(10);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.name == "AllyBullet(Clone)")
        {
            HP -= 1;
            Destroy(other.gameObject);
            if (HP == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<Score>().AddScore(5);
            }
        }
        else if (other.gameObject.name == "AllyBullet2(Clone)")
        {
            HP -= 2;
            Destroy(other.gameObject);
            if (HP == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<Score>().AddScore(5);
            }
        }
        else if (other.gameObject.name == "AllyBullet3(Clone)")
        {
            HP -= 3;
            Destroy(other.gameObject);
            if (HP == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<Score>().AddScore(5);
            }
        }
    }
}
