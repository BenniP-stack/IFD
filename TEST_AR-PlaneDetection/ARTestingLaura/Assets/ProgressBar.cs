using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;

    private float currentProgress = 0;
    public float antiPress = 0.0002f;

    private void Start()
    {
        progressBar.value = currentProgress;
    }

    void Update()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        int treeCount = trees.Length;

        currentProgress += treeCount * 0.00008f;
        currentProgress -= antiPress;
        progressBar.value = currentProgress;
    }
}