using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAhead : MonoBehaviour
{
    public GameObject Player;
    //public bool shortTeleInWall;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] objs;
        objs = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (Collider c in objs)
        {
            if ((c.gameObject.CompareTag("Wall")) || (c.gameObject.CompareTag("LeadWall")))
            {
                Debug.Log("Sphere in wall" + objs.Length + " collisions");
                Debug.Log("Object is " + c.gameObject.name);
            }
        }

        if (objs.Length > 0)
        {
            //shortTeleInWall = true;
            Player.GetComponent<ShortRangedTeleport>().cannotShortTele = true;
        }
        else
        {
            //shortTeleInWall = false;
            Player.GetComponent<ShortRangedTeleport>().cannotShortTele = false;
        }
    }

}
