using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInstantation : MonoBehaviour
{
    public GameObject projectilePrefab; // prefabricat del projectil
    public KeyCode attackKey; // tecla per llançar l'atac
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            // Se instancia el objeto en la posición y rotación del objeto original
            GameObject newInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // Se establece el objeto instanciado como hijo del objeto
            newInstance.transform.parent = transform;
        }
    }
}
