using UnityEngine;
public class EVILVELOCITY : MonoBehaviour
{
    public float startSpeed;
    public GameObject target;
    Rigidbody rigidBody;
    GameObject Red;
    GameObject Blue;
    GameObject Green;
    GameObject Orange;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {

        Red = GameObject.Find("RedBall");
        Blue = GameObject.Find("BlueBall");
        Green = GameObject.Find("GreenBall");
        Orange = GameObject.Find("OrangeBall");

        target = GetClosestTarget();

        if (target != null)
        {
            transform.LookAt(target.transform.position, Vector3.left);
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rigidBody.velocity = direction * startSpeed;
        }

            
    }

    GameObject GetClosestTarget()
    {
        GameObject[] targets = { Red, Blue, Green, Orange };
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            if (obj != null)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = obj;
                }
            }
        }

        return closest;
    }
}
