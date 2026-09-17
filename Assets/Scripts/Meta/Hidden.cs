using UnityEditor;
using UnityEngine;

public class Hidden : MonoBehaviour
{
    private void OnValidate() 
    {
        this.gameObject.hideFlags = HideFlags.HideInHierarchy;
    }

}
