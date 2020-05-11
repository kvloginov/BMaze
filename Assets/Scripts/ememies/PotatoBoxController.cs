using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PotatoBoxController : MonoBehaviour
{
    //public GameObject potatoPrefab;
    public LevelOptions levelOptions;

    [Header("промежуток в секундах между картохами")]
    public AnimationCurve throwDelayCurve;

    public ScoreController scoreController;
    public MainCameraController cameraController;

    public MoveDirection throwDirection;

    public AudioSource throwSound;

    private float nextThrowTime = 0.0f;

    void Start()
    {
        nextThrowTime = Time.time + ComplexityUtils.GetCurveValue(throwDelayCurve, levelOptions.MaxLevelScore, scoreController.GetScore());
    }


    void Update()
    {
        if (Time.time > nextThrowTime)
        {
            nextThrowTime += ComplexityUtils.GetCurveValue(throwDelayCurve, levelOptions.MaxLevelScore, scoreController.GetScore());

            InstantiatePotato();

        }
    }

    private void InstantiatePotato()
    {
        GameObject potato = ObjectPooler.Instance.SpawnFromPool(ObjectPooler.TAG_POTATO, transform.position, Quaternion.identity);
        //GameObject potato = Instantiate(potatoPrefab, transform.position, Quaternion.identity, transform);
        MoveScript move = potato.GetComponent<MoveScript>();
    
        move.moveDirection = throwDirection;

        throwSound.Play();

        //var viewRect = cameraController.GetViewRectInWorld();
    }
}
