using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float startPostion;
    [SerializeField] float endPostion;

    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        
        if (transform.position.x <= endPostion)
        {
            transform.Translate(-1 * (endPostion - startPostion), 0, 0);

            SendMessage("ChangePosition", SendMessageOptions.DontRequireReceiver);
        }
    }
}
