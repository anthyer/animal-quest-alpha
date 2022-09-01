using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1001)]
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float offsetY;
    [SerializeField] float offsetZ;
    
    Vector3 offset;
    
    void Start()
    {
        offset = new Vector3(0, offsetY, offsetZ);
        GetTargetByTag("Player");
    }
    
    void LateUpdate()
    {
        if (target)
        {
            transform.position = new Vector3(target.transform.position.x,(target.transform.position.y + offset.y), offset.z);
        }
    }

    void ChangeTarget(GameObject _target)
    {
        target = _target;
    }

    void GetTargetByTag(string _tag)
    {
        GameObject obj = GameObject.FindWithTag(_tag);
        if (obj)
        {
            ChangeTarget(obj);
        }
        else
        {
            Debug.Log("Can't find object with tag " + _tag);
        }
    }
}