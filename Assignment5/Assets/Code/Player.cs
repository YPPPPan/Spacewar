using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _tr;
    private Gun _gun;
    public static BulletManage Bullets;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = GetComponent<Transform>();
        _gun = GetComponent<Gun>();
        Bullets = new BulletManage();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInput();
        if (Input.GetAxis("Fire1") != 0)
        {
            Fire();
        }
        else if (Input.GetAxis("Fire2") != 0)
        {
            changeBullet();
        }
        _tr.rotation = new Quaternion();
    }

    internal void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Enemy(Clone)")
        {
            Object _menu = Resources.Load("Menu");
            GameObject menu = (GameObject)Object.Instantiate(_menu, FindObjectOfType<Canvas>().transform);
            menu.GetComponent<Menu>().Initialize();
            Time.timeScale = 0;
        }
    }

    internal void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EnemyBullet(Clone)")
        {
            Object _menu = Resources.Load("Menu");
            GameObject menu = (GameObject)Object.Instantiate(_menu, FindObjectOfType<Canvas>().transform);
            menu.GetComponent<Menu>().Initialize();
            Time.timeScale = 0;
        }
    }

    private void HandleInput() {
        _tr.Translate(new Vector3(Input.GetAxis("Horizontal")/10, Input.GetAxis("Vertical")/10, 0));
    }

    private void Fire()
    {
        _gun.Fire(new Vector2(_tr.position.x,_tr.position.y),0);
    }

    private void changeBullet() {
        _gun.changeBullet();
    }


}