using UnityEngine;
using TMPro;

public class BinaryCounter : MonoBehaviour
{
    [Header("BITS")]
    public Bit Q0;
    public Bit Q1;
    public Bit Q2;
    public Bit Q3;

    [Header("VISUAL LEDS")]
    public Renderer ledQ0;
    public Renderer ledQ1;
    public Renderer ledQ2;
    public Renderer ledQ3;

    [Header("MATERIALS")]
    public Material onMaterial;
    public Material offMaterial;

    [Header("UI")]
    public TMP_Text counterText;
    public Color limitColor;
    public Color outLimitColor;

    [Header("LIMITS")]
    public int maxPeople = 15;

    public bool IsFull => GetDecimalValue() >= maxPeople;

    void Update()
    {
        UpdateVisuals();
    }

    // =========================
    // INCREMENT
    // =========================

    public void Increment()
    {
        if (IsFull)
            return;

        if (!Q0.state)
        {
            Q0.state = true;
        }
        else
        {
            Q0.state = false;

            if (!Q1.state)
            {
                Q1.state = true;
            }
            else
            {
                Q1.state = false;

                if (!Q2.state)
                {
                    Q2.state = true;
                }
                else
                {
                    Q2.state = false;

                    if (!Q3.state)
                    {
                        Q3.state = true;
                    }
                    else
                    {
                        Q3.state = false;
                    }
                }
            }
        }
    }

    // =========================
    // DECREMENT
    // =========================

    public void Decrement()
    {
        if (GetDecimalValue() <= 0)
            return;

        if (Q0.state)
        {
            Q0.state = false;
        }
        else
        {
            Q0.state = true;

            if (Q1.state)
            {
                Q1.state = false;
            }
            else
            {
                Q1.state = true;

                if (Q2.state)
                {
                    Q2.state = false;
                }
                else
                {
                    Q2.state = true;

                    if (Q3.state)
                    {
                        Q3.state = false;
                    }
                    else
                    {
                        Q3.state = true;
                    }
                }
            }
        }
    }

    // =========================
    // DECIMAL VALUE
    // =========================

    public int GetDecimalValue()
    {
        int value = 0;

        if (Q0.state) value += 1;
        if (Q1.state) value += 2;
        if (Q2.state) value += 4;
        if (Q3.state) value += 8;

        return value;
    }

    // =========================
    // VISUALS
    // =========================

    void UpdateVisuals()
    {
        if (ledQ0)
            ledQ0.material = Q0.state ? onMaterial : offMaterial;

        if (ledQ1)
            ledQ1.material = Q1.state ? onMaterial : offMaterial;

        if (ledQ2)
            ledQ2.material = Q2.state ? onMaterial : offMaterial;

        if (ledQ3)
            ledQ3.material = Q3.state ? onMaterial : offMaterial;

        if (counterText)
        {
            counterText.text =GetDecimalValue().ToString();
            if (GetDecimalValue() >= maxPeople)
            {
                counterText.color = outLimitColor;
            }
            else
            {
                counterText.color = limitColor;
            }
        }
    }
}