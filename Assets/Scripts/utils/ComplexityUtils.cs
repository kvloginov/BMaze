using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Обуславливаемся, что все графики в промежутке от 0 до 1
 */
public class ComplexityUtils
{
    private const float UPPER_BOUND_X = 1f;

    public static float GetCurveValue(AnimationCurve curve, int maxScore, int currentScore)
    {
        // возмонжно, это уже делается внутри, нужно проверить
        if (currentScore > maxScore) {
            return curve.Evaluate(UPPER_BOUND_X);
        }
       return curve.Evaluate((float)currentScore / maxScore);
    }

}
