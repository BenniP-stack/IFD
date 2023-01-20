using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public GameObject treeMesh;
    public Vector3 growthRate;
    public float maxYScale;

    private GameObject treeInstance;
    private bool shouldGrow = true;

    public void spawnTree()
    {
        treeInstance = GameObject.Instantiate(treeMesh, transform.position, transform.rotation);
        treeInstance.transform.parent = this.gameObject.transform;
    }

    public void growTree()
    {
        if (shouldGrow)
        {
            Vector3 currentScale = treeInstance.transform.localScale;
            treeInstance.transform.localScale += growthRate;
            // Debug.Log(treeInstance.ToString() + treeInstance.transform.localScale.ToString());
            if (treeInstance.transform.localScale.y > maxYScale) { shouldGrow = false; }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnTree();
    }

    // Update is called once per frame
    void Update()
    {
        growTree();
    }
}
