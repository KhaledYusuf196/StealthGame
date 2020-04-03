using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhostTracker : MonoBehaviour
{
    [SerializeField] Transform Player;
     float Sqr_range;
    [SerializeField] float range;
    Ray raycast;
    RaycastHit Hit;
    [SerializeField] LayerMask WallLayerMask;
    [SerializeField] float DetictDuration = 3;
    [SerializeField] bool deticted = false;
     float MaxDetictDuration;

    void Start()
    {
        MaxDetictDuration = DetictDuration;
        Sqr_range = range * range;
    }

    void Update()
    {
        deticted = false;
         if((Player.position - this.transform.position).sqrMagnitude<Sqr_range)
        {
            if(Vector3.Dot((Player.position - this.transform.position).normalized,transform.forward)>.7f)
            {
                raycast = new Ray(this.transform.position + new Vector3(0, .5f, 0), Player.position - this.transform.position);

                if(!Physics.Raycast(raycast,out Hit,(transform.position-Player.position).magnitude, WallLayerMask))
                {
                    deticted = true;
                    DetictDuration -= Time.deltaTime;
                    if(DetictDuration<=0)
                    Debug.Log("Lose");
                }

            }
        }

         if(deticted==false)
        {
                    DetictDuration = Mathf.Min(DetictDuration+ Time.deltaTime, MaxDetictDuration);
        }

        Debug.Log(DetictDuration);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawSphere(transform.position, range);
    }
}
