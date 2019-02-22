using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gumshoot : MonoBehaviour
{
    public int GunDamage = 1;
    public float FireRate = 0.5f;
    public float Range = 50f;
    public float knockback = 100f;
    public Transform gunBarrel;
    private Camera guncam;
    private WaitForSeconds shotspeed = new WaitForSeconds(0.05f);
// private AudioSource Gunshot;
    private LineRenderer tester;
    private float nextF;
    // Start is called before the first frame update
    void Start()
    {
        tester = GetComponent<LineRenderer>();
        //Gunshot = GetComponent<AudioSource>();
        guncam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (Time.time > nextF) ;
            {
                nextF = Time.time + FireRate;
                StartCoroutine(ShotEffect());
                Vector3 RayOrigen = guncam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                tester.SetPosition(0, gunBarrel.position);
                if (Physics.Raycast(RayOrigen, guncam.transform.forward, out hit, Range))
                {
                    tester.SetPosition(1, hit.point);
                    EnemyHP hitpoints = hit.collider.GetComponent<EnemyHP>();
                    if (hitpoints != null)
                    {
                        Debug.Log("hit");
                   
                        hitpoints.Damage(GunDamage);
                    }
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * knockback);
                    }
                }
                else
                {
                    tester.SetPosition(1, RayOrigen + (guncam.transform.forward * Range));
                }
            }
        }
    }
    private IEnumerator ShotEffect()
    {
       // Gunshot.Play();
        tester.enabled = true;
        yield return shotspeed;
        tester.enabled = false;
    }
}

