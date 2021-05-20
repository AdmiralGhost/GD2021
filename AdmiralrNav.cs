using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AdmiralrNav : MonoBehaviour
{

    NavMeshAgent navi;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        navi = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            navi.SetDestination(hit.point);
        }
    }
}
