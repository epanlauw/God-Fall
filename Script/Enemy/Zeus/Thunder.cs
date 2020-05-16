using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public Transform target;
    public float ProjectileSpeed = 20;
    private Vector3 dam;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //myTransform.LookAt(target);
        Destroy(this.gameObject, 3f);
    }
    void Update()
    {
        float amtToMove = ProjectileSpeed * Time.deltaTime;
        myTransform.Translate(Vector3.right * amtToMove);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        if(collision.gameObject.tag == "Player"){
            player_move_Test001.health-=5;
        }
    }
}
