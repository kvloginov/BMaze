using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class PotatoBoxSpawner : MonoBehaviour
{
    public LevelOptions levelOptions;

    public Transform heroTransform;

    [Header("промежуток в секундах перед установокой новой пушки")]
    public AnimationCurve throwDelayCurve;

    public ScoreController scoreController;
    public MainCameraController cameraController;

    public float spawnersYOffset = 3;

    private float nextThrowTime = 0.0f;

    public MoveDirection[] potatoMoveDirections = new MoveDirection[] {MoveDirection.Left, MoveDirection.Right, MoveDirection.Down};


    void Start()
    {
        nextThrowTime = Time.time + ComplexityUtils.GetCurveValue(throwDelayCurve, levelOptions.MaxLevelScore, scoreController.GetScore());
    }

    void Update()
    {
        if (Time.time > nextThrowTime)
        {
            nextThrowTime += ComplexityUtils.GetCurveValue(throwDelayCurve, levelOptions.MaxLevelScore, scoreController.GetScore());

            InstantiatePotatoBox();
        }
    }

    // TODO проверить, не умрет ли герой соприкоснувшись с шипом до его создания
    private void InstantiatePotatoBox()
    {
        //GameObject potatoBox = Instantiate(potatoBoxPrefab, Vector3.zero, Quaternion.identity, transform);
        GameObject potatoBox = ObjectPooler.Instance.SpawnFromPool(ObjectPooler.TAG_POTATO_BOX, Vector3.zero, Quaternion.identity);

        PotatoBoxController boxController = potatoBox.GetComponent<PotatoBoxController>();
        boxController.scoreController = scoreController;
        boxController.levelOptions = levelOptions;
        boxController.cameraController = cameraController;

        int dirIndex = Random.Range(0, potatoMoveDirections.Length);
        boxController.throwDirection = potatoMoveDirections[dirIndex];

        var viewRect = cameraController.GetViewRectInWorld();
        if (boxController.throwDirection == MoveDirection.Right) 
        {
            potatoBox.transform.position = new Vector3(levelOptions.LevelStartX + 1, viewRect.yMax + spawnersYOffset, 0);
        } 
        else if (boxController.throwDirection == MoveDirection.Left)
        {
            potatoBox.transform.position = new Vector3(levelOptions.LevelEndX - 1, viewRect.yMax + spawnersYOffset, 0);
        } 
        else if (boxController.throwDirection == MoveDirection.Down)
        {
            potatoBox.transform.position = new Vector3(heroTransform.position.x, viewRect.yMax + spawnersYOffset, 0);
        }
    }


}
