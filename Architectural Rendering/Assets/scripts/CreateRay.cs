using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRay : MonoBehaviour
{
    public int bounces = 5;
    public LayerMask _layerMask;
    public int lenghtOfRay;
    private void OnDrawGizmos()
    {
        
        Vector2 origin = transform.position;
        Vector2 dir = transform.right;

        Gizmos.DrawSphere(transform.position, 0.2f);
        Ray ray = new Ray(origin, dir);

        for (int i = 0; i < bounces; i++)
        {
            if (Physics.Raycast(ray,out RaycastHit hit))
             {

                Gizmos.color = Color.red;

                Gizmos.DrawLine(ray.origin, hit.point);

                Gizmos.color = Color.white;
                Gizmos.DrawSphere(hit.point, 0.25f);
                Vector2 reflectedVector = Reflected(ray.direction, hit.normal);
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(hit.point, (Vector2)hit.point + reflectedVector );

                ray.direction = reflectedVector;
                ray.origin = hit.point;


            }
            else
            {

                break;
            }
          


        }
        
     
    }

    Vector2 Reflected(Vector2 direction, Vector2 normal)
    {
        return direction - 2 * Vector2.Dot(direction,normal) * normal;

    }

}
