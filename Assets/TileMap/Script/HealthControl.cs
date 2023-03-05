using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField]
    HealthBar healthBar;
    [SerializeField]
    GameObject deathGameobject;
    int health = 100;
    int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "creep")
        {
            health -= damage;
            healthBar.SetHeatlh(health);
        }
        if (health <= 0)
        {
            StartCoroutine(Dead());
        }
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject obj = Instantiate(deathGameobject,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
