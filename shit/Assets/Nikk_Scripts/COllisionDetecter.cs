using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class COllisionDetecter : MonoBehaviour
{
    [SerializeField]
    private string _coliderScript;

    [SerializeField]
    private UnityEvent _collisionEnter;

    [SerializeField]
    private UnityEvent _collisionExit;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(_coliderScript))
        {
            _collisionEnter?.Invoke();
        }
    }
}
