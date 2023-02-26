using UnityEngine;

public class FCP_ExampleScript : MonoBehaviour {

    public bool getStartingColorFromMaterial;
    public FlexibleColorPicker fcp;
    public LineRenderer lineRenderer;
    bool callerGradient = false;
    private void Start() {
        fcp.onColorChange.AddListener(OnChangeColor);
    }

    private void OnChangeColor(Color co) {
        if(callerGradient)
        {
            lineRenderer.endColor = co;
        }
        else
        {
            lineRenderer.startColor = co;
            lineRenderer.endColor = co;
        }
    }

    public void OpenIt(bool b)
    {
        if (fcp.gameObject.activeInHierarchy)
        {

            HideIt();
            return;
        }
        callerGradient = b;
        fcp.gameObject.SetActive(true);
    }

    public void HideIt()
    {
        callerGradient = false;
        fcp.gameObject.SetActive(false);
    }
}
