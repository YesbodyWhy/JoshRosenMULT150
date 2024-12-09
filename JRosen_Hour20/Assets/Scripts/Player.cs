using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("References")]
    public GameManager manager;
    public Material normalMat;
    public Material phasedMat;

    [Header("Gameplay")]
    public float bounds = 3f;
    public float strafeSpeed = 4f;
    public float phaseDebounce = 0.5f;

    Renderer mesh;
    Collider collision;
    Animator anim;
    bool canPhase = true;
    private TrailRenderer trailvar;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        collision = GetComponent<Collider>();
        anim = GetComponent<Animator>();
        trailvar = GetComponent<TrailRenderer>();
    }

    float lastDir = 0;
    float TargetDir;
    float vel;

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            TargetDir = Mathf.Clamp(TargetDir + 0.02f * Mathf.Clamp(Input.GetAxis("Horizontal") * 10, -1f, 1f), -1f, 1f);
        }
        else
        {
            TargetDir = TargetDir * 0.98f;
            if (Mathf.Abs(TargetDir) < 0.05)
            {
                TargetDir = 0;
            }
        }


        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;

        Vector3 position = transform.position;
        position.x += xMove + vel;
        position.x = Mathf.Clamp(position.x, -bounds, bounds);
        transform.position = position;
        anim.SetFloat("Direction", TargetDir);


        if (Input.GetButtonDown("Jump") && Input.GetAxis("Horizontal") != 0 && canPhase)
        {
            if (Input.GetAxis("Horizontal") < 0) {
                lastDir = -1;
            }
            else
            {
                lastDir = 1;
            }
            canPhase = false;
            mesh.material = phasedMat;
            collision.enabled = false;

            vel += 0.04f * lastDir;

            trailvar.emitting = true;

            Invoke("PhaseIn", phaseDebounce);
        }

        vel *= 0.97f;

        if (Mathf.Abs(vel) <= 0.00001)
        {
            vel = 0;
            trailvar.emitting = false;
        }

        

    }

    void PhaseIn()
    {
        canPhase = true;
        mesh.material = normalMat;
        collision.enabled = true;
    }

}
