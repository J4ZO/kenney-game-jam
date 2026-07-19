using UnityEngine;
using UnityEngine.UI;

public class PigController : MonoBehaviour
{
    [SerializeField] private float incrementSize = 0f ;
    [SerializeField] private float limit = 100f;

    [SerializeField] private float incrementMultiplier = 0.25f;
    [SerializeField] private float incrementSizeValue = 0.0001f;
    
    [SerializeField] private Image barImage;
    public bool loseGame = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (incrementSize < limit)
        {
            Debug.Log(incrementSize);
            IncreaseSize();
            incrementSize += Time.deltaTime * incrementMultiplier;
            SetFillAmount(incrementSize);
        }
        else
        {
            loseGame = true;
        }
    }

    private void IncreaseSize()
    {
        transform.localScale += Vector3.one * incrementSizeValue;
    }
    
    private void SetFillAmount(float fillAmount)
    {
        barImage.fillAmount = fillAmount / limit;
    }

    public void ResetValues()
    {
        barImage.fillAmount = 0f;
        incrementSize = 0f;
    }
}
