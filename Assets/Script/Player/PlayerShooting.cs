using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject regularBulletPrefab; //Prefab dan
    //------------ Thiet lap power up dan--------------//
    public GameObject doubleBulletPrefab;
    public GameObject multiBulletPrefab;
    //-------------------------------------------------//
    public Transform firePoint; //vi tri ban dan
    //------------- Logic -------------------------//
    private bool isDoubleShootActive = false;
    private bool isMultiAngleShootActive = false;
    //--------------------------------------------//
    public float powerUpDuration = 5f;
    public float bulletSpeed = 10f; //toc do vien dan
    //----------- Hieu ung toa ------------------//
    public float multiAngleSpread = 15f;
    public int multiAngleBulletCount = 5;
    //-------------------------------------------//
    void Update(){
        //neu nguoi choi an dau cach thi vien dan se duoc ban
        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }
    void Shoot(){
        if(isDoubleShootActive) {
            ShootTheBullet(doubleBulletPrefab,firePoint.position + new Vector3(-0.2f,0,0),firePoint.up);
            ShootTheBullet(doubleBulletPrefab,firePoint.position + new Vector3(0.2f,0,0),firePoint.up);
        }
        else if(isMultiAngleShootActive){
            ShootMultiAngle();
        }
        else{
            ShootTheBullet(regularBulletPrefab,firePoint.position,firePoint.up);
        }
        AudioManager.Instance.PlayShootSound();
    }
    void ShootTheBullet(GameObject bulletPrefab, Vector3 position, Vector2 direction){
        GameObject bullet = Instantiate(bulletPrefab,position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }
    void ShootMultiAngle(){
        float startAngle = -multiAngleSpread * (multiAngleBulletCount - 1)/2;

        for(int i = 0; i < multiAngleBulletCount; i++){
            float angle = startAngle + i * multiAngleSpread;
            Quaternion rotation = Quaternion.Euler(0,0,angle);
            GameObject bullet = Instantiate(multiBulletPrefab,firePoint.position,rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = rotation * Vector2.up * bulletSpeed;
        }
    }
    public void ActiveDoubleShoot(){
        isDoubleShootActive = true;
        isMultiAngleShootActive = false;
        Invoke(nameof(DeactivatePowerUp),powerUpDuration);
    }
    public void ActiveMultiShoot(){
        isDoubleShootActive = false;
        isMultiAngleShootActive = true;
        Invoke(nameof(DeactivatePowerUp),powerUpDuration);
    }
    void DeactivatePowerUp(){
        isDoubleShootActive = false;
        isMultiAngleShootActive = false;
    }
}
