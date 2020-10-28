using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private const float FireCooldown = 1f;
    private float _lastfire;
    private float _lastChange;
    private const float changeCooldown = 0.1f;
    private float _bulletType = 0f;
    private int _charge = 10;
    // Start is called before the first frame update
    public void Fire(Vector2 Position, int flag) {
        float time = Time.time;
        if (flag == 0)
        {
            if (time < _lastfire + FireCooldown/5) { return; }
        }
        else if (flag == 1)
        {
            if (time < _lastfire + FireCooldown) { return; }
        }
        _lastfire = time;
        if (flag == 0) { Player.Bullets.BulletGenerator(_bulletType, Position, flag); }
        else if (flag == 1) { Enemy.Bullets.BulletGenerator(_bulletType, Position, flag); }
        var attackMusic = GetComponents<AudioSource>();
        attackMusic[0].PlayOneShot(attackMusic[0].clip);
    }

    public void Fire(Vector2 Position, int flag, int level, int speed, int number)
    {
        float time = Time.time;
        if (time < _lastfire + (FireCooldown/speed) || _charge == 0) { return; }
        _lastfire = time;
        _charge -= 1;
        Ally.Bullets.BulletGenerator(_bulletType, Position, flag, level, number);
        var attackMusic = GetComponents<AudioSource>();
        attackMusic[0].PlayOneShot(attackMusic[0].clip);
    }

    public void changeBullet()
    {
        float time = Time.time;
        if (time < _lastChange + changeCooldown) { return; }
        _lastChange = time;
        if (_bulletType < 4f)
        {
            _bulletType += 1f;
        }
        else {
            _bulletType = 0;
        }
    }

    public void charge() {
        _charge += 10;
        if (_charge > 50) _charge = 50;
    }
}
