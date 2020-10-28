using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManage
{
    private Transform holder;
    private Object _bullet;
    
    public BulletManage()
    {
        holder = GameObject.Find("Bullets").transform;
    }

    public void BulletGenerator(float BulletType, Vector2 Position, int flag) {
        if (flag == 0)
        {
            if (BulletType == 0)
            {
                _bullet = Resources.Load("Meat");
            }
            else if (BulletType == 1)
            {
                _bullet = Resources.Load("Drink");
            }
            else if (BulletType == 2)
            {
                _bullet = Resources.Load("Cake");
            }
            else if (BulletType == 3)
            {
                _bullet = Resources.Load("Fruit");
            }
            else
            {
                _bullet = Resources.Load("Vege");
            }
        }
        else if (flag == 1) {
            _bullet = Resources.Load("EnemyBullet");
        }
        GameObject bullet = (GameObject)Object.Instantiate(_bullet, Position, new Quaternion(0, 0, 0, 0));
        bullet.GetComponent<Bullet>().Initialize(BulletType,flag);
        bullet.GetComponent<Transform>().parent = holder;
    }

    public void BulletGenerator(float BulletType, Vector2 Position, int flag, int level, int number)
    {
        if (level == 1)
        {
            _bullet = Resources.Load("AllyBullet");
        }
        else if (level == 2)
        {
            _bullet = Resources.Load("AllyBullet2");
        }
        else if (level == 3)
        {
            _bullet = Resources.Load("AllyBullet3");
        }
        if (number == 1)
        {
            GameObject bullet = (GameObject)Object.Instantiate(_bullet, Position, new Quaternion(0, 0, 0, 0));
            bullet.GetComponent<Bullet>().Initialize(BulletType, flag);
            bullet.GetComponent<Transform>().parent = holder;
        }
        else if (number == 2)
        {
            Vector2 pos1 = new Vector2(Position.x + 0.5f, Position.y);
            Vector2 pos2 = new Vector2(Position.x - 0.5f, Position.y);
            GameObject bullet = (GameObject)Object.Instantiate(_bullet, pos1, new Quaternion(0, 0, 0, 0));
            bullet.GetComponent<Bullet>().Initialize(BulletType, flag);
            bullet.GetComponent<Transform>().parent = holder;
            GameObject bullet2 = (GameObject)Object.Instantiate(_bullet, pos2, new Quaternion(0, 0, 0, 0));
            bullet2.GetComponent<Bullet>().Initialize(BulletType, flag);
            bullet2.GetComponent<Transform>().parent = holder;
        }
        else if (number == 3)
        {
            Vector2 pos1 = new Vector2(Position.x + 0.8f, Position.y);
            Vector2 pos2 = new Vector2(Position.x - 0.8f, Position.y);
            GameObject bullet = (GameObject)Object.Instantiate(_bullet, pos1, new Quaternion(0, 0, 0, 0));
            bullet.GetComponent<Bullet>().Initialize(BulletType, flag);
            bullet.GetComponent<Transform>().parent = holder;
            GameObject bullet2 = (GameObject)Object.Instantiate(_bullet, pos2, new Quaternion(0, 0, 0, 0));
            bullet2.GetComponent<Bullet>().Initialize(BulletType, flag);
            bullet2.GetComponent<Transform>().parent = holder;
            GameObject bullet3 = (GameObject)Object.Instantiate(_bullet, Position, new Quaternion(0, 0, 0, 0));
            bullet3.GetComponent<Bullet>().Initialize(BulletType, flag);
            bullet3.GetComponent<Transform>().parent = holder;
        }
    }
}
