using UnityEngine;
public class VelocityScript : MonoBehaviour
{
    public float startSpeed = 50f;
    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(Random.Range(-1, 1) * startSpeed, 0, Random.Range(-1,1) * startSpeed);
    }
}
