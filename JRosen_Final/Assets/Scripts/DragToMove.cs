using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour
{

    public GameObject controller;

    private Rigidbody controllerRigidbody;

    public GameObject character;
    public GameObject HitBox;
    public GameObject Arrow;
    public GameObject SpotLight;
    public float dragConstant;
    public LayerMask layerMask;

    public float intensity = 0f;
    public float angle = 0f;

    bool debounce;
    bool isDragging = false;

    Camera mainCamera;
    Vector3 initialMousePosition;
    Vector3 initialObjectPosition;
    Vector3 offset;
    Vector3 directionMultiplier;
    Vector3 moveDirection;
    Vector3 VelocityDirection;
    ParticleSystem partEmit;
    Light SpotLight2;


    private CharacterController controllerCharacterController;

    // Start is called before the first frame update
    void Start()
    {

        mainCamera = Camera.main;

        if (controller != null)
        {
            controllerCharacterController = controller.GetComponent<CharacterController>();
        }
        else
        {
            Debug.LogError("NO CONTROLLER DUMBO!!");
        }

        int layerMask = LayerMask.GetMask("DragHitbox");

        partEmit = character.GetComponent<ParticleSystem>();

        SpotLight2 = SpotLight.GetComponent<Light>();

    }

    void UpdateDrag()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 mouseDelta = initialMousePosition - currentMousePosition;

        Vector3 direction = mouseDelta.normalized;

        intensity = mouseDelta.magnitude;

        Ray ray = mainCamera.ScreenPointToRay(currentMousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            //transform.position = hit.point + offset;
            offset = new Vector3(transform.position.x - hit.point.x, 2, transform.position.z - hit.point.z);
            Debug.Log(offset);
            directionMultiplier = offset.normalized;

            Vector3 horizontalDirection = new Vector3(directionMultiplier.x, 0, directionMultiplier.z);
            angle = Vector3.Angle(Vector3.forward, horizontalDirection);
            Debug.Log(angle);

            if (direction.x < 0)
            {
                angle = 360f - angle;
            }

            character.transform.eulerAngles = new Vector3(37.831f, -90f + angle, -90f);



            if (controllerCharacterController != null)
            {
                VelocityDirection = horizontalDirection.normalized;

                moveDirection = VelocityDirection * (intensity / 5f);
                controllerCharacterController.Move(moveDirection * Time.deltaTime);

            }

        }
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) == true)
        {
            debounce = true;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == character)
            {
                isDragging = true;
                initialMousePosition = Input.mousePosition;
                initialObjectPosition = transform.position;
                offset = transform.position - hit.point;
                Debug.Log("Dragging START");
                //Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            debounce = true;
            Debug.Log("Dragging STOPPED");



        }

        if (isDragging == false && debounce == true && controllerCharacterController != null)
        {
            //character.transform = 
           
            moveDirection = VelocityDirection * intensity;
                
            float rayDistance = intensity;
            

            
            Ray ray = new Ray(character.transform.position, moveDirection); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
            {
                Debug.Log($"Hit {hit.collider.name} at distance {hit.distance}");
                intensity = 0;
                angle = 0;
                debounce = false;
                OnRaycastHit(hit);
            }
            else
            {
                // Optional: logic for when no object is hit
                Debug.Log("No object hit.");
                controllerCharacterController.Move(moveDirection * Time.deltaTime);
            }
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

            


            intensity *= dragConstant;

            if (intensity <= 0.1)
            {
                intensity = 0;
                angle = 0;
                debounce = false;
            }
        }

        if (isDragging) // mostly for real time debugging
        {

            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseDelta = initialMousePosition - currentMousePosition;

            Vector3 direction = mouseDelta.normalized;

            intensity = mouseDelta.magnitude;

            UpdateDrag();

            //character.transform.rotation = new Vector3(0, direction, 0);

        }

        var mainModule = partEmit.main;
        var emissionModule = partEmit.emission;
        if (intensity > 0)
        {
            SpotLight2.intensity = intensity/80f;
            
            mainModule.startLifetime = intensity / 300f;
            partEmit.enableEmission = true;
            partEmit.startSpeed = intensity * 1.5f;
            mainModule.startSize = intensity / 75f;
            emissionModule.rateOverTime = intensity / 7f;
            Arrow.transform.localScale = new Vector3(intensity * 0.25f, intensity * 0.5f, intensity * 0.25f);
        }
        else
        {
            partEmit.enableEmission = false;
            SpotLight2.intensity = 0f;
            mainModule.startLifetime = 0f;
            mainModule.startSize = 0f;
            emissionModule.rateOverTime = 0f;
            Arrow.transform.localScale = new Vector3(0f, 0f, 0f);
        }

        transform.eulerAngles = new Vector3(0, 0, 0);

    }

    void OnRaycastHit(RaycastHit hit)
    {

        //reflects orientation across the surface normal
        //Vector3 incomingDirection = moveDirection;
        //Vector3 reflectedDirection = Vector3.Reflect(moveDirection, hit.normal);

        //moveDirection = reflectedDirection;

        //transform.rotation = Quaternion.LookRotation(reflectedDirection);

        moveDirection = -moveDirection;
        character.transform.rotation = Quaternion.LookRotation(moveDirection);
    }

}
