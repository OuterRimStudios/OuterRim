using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SetCurrentSelected : MonoBehaviour
{
    public EventSystem es;
    public GameObject selectedGameobject;
    
	void Update ()
    {
	    if(es.currentSelectedGameObject == null)
        {
            es.SetSelectedGameObject(selectedGameobject);
        }
	}
}
