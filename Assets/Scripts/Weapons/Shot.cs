using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet_machine_gun;
    public AudioSource pistolSoundEffect;
    public AudioSource machinegunSoundEffect;
    public AudioSource shotgunSoundEffect;
    public Transform firePoint;
    public float bulletSpeed_pistol = 50;
    public float bulletSpeed_machine_gun = 50;
    public float bulletSpeed_shotgun = 10;
    public Texture2D cursorArrow;
    Vector2 lookDirection;
    float lookAngle;
    //CoinController coincontroller;
    private WeaponController weaponcontroller;
    CharacterController charactercontroller;

    public float recarga_escopeta;
    public float recarga_pistola;
    public float recarga_ametralladora;
    private PauseManager pm;

    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("gamecontroller").GetComponent<PauseManager>();
        charactercontroller = this.GetComponent<CharacterController>();
        //coincontroller = this.GetComponent<CoinController>();
        weaponcontroller = GameObject.FindGameObjectWithTag("gamecontroller").GetComponent<WeaponController>();
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        recarga_escopeta = 0;
        recarga_pistola=0;
        recarga_ametralladora = 0;
    }

    void Pistola()
    {
        if (Input.GetMouseButtonDown(0) && recarga_pistola <= 0)
        {
            pistolSoundEffect.Play();
            recarga_pistola = 0.5f;
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
            //Debug.Log(firePoint.position);
            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed_shotgun;
            //Destroy(bulletClone.gameObject, 0.1f);
            Destroy(bulletClone.gameObject, 1f);

            GameObject bulletClone2 = Instantiate(bullet);
            bulletClone2.transform.position = new Vector2(firePoint.position.x, firePoint.position.y + 0.3f);
            //bulletClone2.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone2.GetComponent<Rigidbody2D>().velocity = new Vector3(firePoint.right.x, firePoint.right.y*2f, firePoint.right.z) * bulletSpeed_shotgun;
            //Destroy(bulletClone.gameObject, 0.1f);
            Destroy(bulletClone.gameObject, 1f);

            GameObject bulletClone3 = Instantiate(bullet);
            bulletClone3.transform.position = new Vector2(firePoint.position.x, firePoint.position.y - 0.3f);
            //bulletClone3.transform.rotation = Quaternion.Euler(0, -0, lookAngle);

            bulletClone3.GetComponent<Rigidbody2D>().velocity = new Vector3(firePoint.right.x, firePoint.right.y / 2f, firePoint.right.z) * bulletSpeed_shotgun;
            //Destroy(bulletClone.gameObject, 0.1f);
            shotgunSoundEffect.Play();
            Destroy(bulletClone.gameObject, 1f);
            if (lookDirection.x > 0f)
            {
                Vector2 dir = this.transform.position;
                if(charactercontroller.rebotari==false && (lookDirection.x <-1.5f || lookDirection.x>1.5f))
                    this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x - 1f, this.transform.position.y), 1f);
            }
            else
            {
                if (charactercontroller.rebotar == false && (lookDirection.x < -1.5f || lookDirection.x > 1.5f))
                    this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x + 1f, this.transform.position.y), 1f);
            }
            }
    }

    void Ametralladora()
    {
        if (Input.GetMouseButton(0) && recarga_ametralladora <= 0)
        {
            recarga_ametralladora = 0.2f;
            GameObject bulletClone = Instantiate(bullet_machine_gun);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            //Debug.Log("Hola");
            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed_machine_gun;
            machinegunSoundEffect.Play();
            Destroy(bulletClone.gameObject, 1f);
        }
    }

    void Update()
    {
        if (!pm.pausa) //Si el juego no esta en pausa
        {
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
            recarga_escopeta -= Time.deltaTime;
            recarga_pistola -= Time.deltaTime;
            recarga_ametralladora -= Time.deltaTime;

            if (weaponcontroller.arma_actual == "Escopeta")
            {
                Escopeta();
            }
            else if (weaponcontroller.arma_actual == "Ametralladora")
            {
                Ametralladora();
            }
            else
            {
                Pistola();
            }
        }
    }
}
