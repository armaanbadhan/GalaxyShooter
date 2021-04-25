using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpolsionEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

}
