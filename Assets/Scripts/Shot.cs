using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed_pistol = 50;
    public float bulletSpeed_shotgun = 10;
    public Texture2D cursorArrow;
    Vector2 lookDirection;
    float lookAngle;
    CoinController coincontroller;
    WeaponController weaponcontroller;

    public float recarga_escopeta;

    void Start()
    {
        coincontroller = this.GetComponent<CoinController>();
        weaponcontroller = this.GetComponent<WeaponController>();
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        recarga_escopeta = 0;
    }

    void Pistola()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed_pistol;
            Destroy(bulletClone.gameObject, 1f);
        }
    }

    void Escopeta()
    {
        if (Input.GetMouseButtonDown(0) && recarga_escopeta<=0)
        {
            recarga_escopeta = 1f;
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed_shotgun;
            Destroy(bulletClone.gameObject, 0.07f);

            GameObject bulletClone2 = Instantiate(bullet);
            bulletClone2.transform.position = new Vector2(firePoint.position.x, firePoint.position.y + 0.2f);
            //bulletClone2.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone2.GetComponent<Rigidbody2D>().velocity = new Vector3(firePoint.right.x, firePoint.right.y*2f, firePoint.right.z) * bulletSpeed_shotgun;
            Destroy(bulletClone2.gameObject, 0.07f);

            GameObject bulletClone3 = Instantiate(bullet);
            bulletClone3.transform.position = new Vector2(firePoint.position.x, firePoint.position.y - 0.2f);
            //bulletClone3.transform.rotation = Quaternion.Euler(0, -0, lookAngle);

            bulletClone3.GetComponent<Rigidbody2D>().velocity = new Vector3(firePoint.right.x, firePoint.right.y / 2f, firePoint.right.z) * bulletSpeed_shotgun;
            Destroy(bulletClone3.gameObject, 0.07f);
            if (lookDirection.x > 0f)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x - 1f, this.transform.position.y), 1f);
                //this.GetComponent<Rigidbody2D>().MovePosition(new Vector2(this.transform.position.x - 1f, this.transform.position.y));
                //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.position.x - 1f, this.transform.position.y), ForceMode2D.Impulse);
                //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.position.x - 1f, this.transform.position.y), ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log("Hola");
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x + 1f, this.transform.position.y), 1f);
                //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.position.x + 1f, this.transform.position.y), ForceMode2D.Impulse);
            }
            }
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Debug.Log(lookDirection);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        recarga_escopeta -= Time.deltaTime;
        if (weaponcontroller.arma_actual=="Escopeta") {
            Escopeta();
        } else
        {
            Pistola();
        }
        
    }
}
