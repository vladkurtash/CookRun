using UnityEngine;
using CookRun.Model;
using CookRun.View;
using CookRun.Presenter;
using CookRun.Systems;
using CookRun.Input;
using CookRun.Core;

namespace CookRun
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private PlayerRootView playerRootView;
        [SerializeField] private SlidingArea slidingArea;
        [SerializeField] private CameraPresenter cameraPresenter;
        private PlayerPresenter playerPresenter = null;
        private PlayerInputRouter playerInputRouter = null;

        private void Awake()
        {
            playerRootView = FindObjectOfType<PlayerRootView>();
            slidingArea = FindObjectOfType<SlidingArea>();
            cameraPresenter = FindObjectOfType<CameraPresenter>();

            var model = new PlayerModel(PlayerConfigDataSO.Instance.Data);
            var moveSystem = new PlayerMoveSystem(PlayerMoveSystemDataSO.Instance.Data, model);
            var rotateSystem = new PlayerRotateSystem(PlayerRotateSystemDataSO.Instance.Data, model);
            var movementSystem = new PlayerMovementSystem(moveSystem, rotateSystem);

            playerPresenter = new PlayerPresenter(model, playerRootView, movementSystem);

            playerInputRouter = new PlayerInputRouter(slidingArea, movementSystem);

            SetupMainCamera();
        }

        private void SetupMainCamera()
        {
            cameraPresenter.Target = playerRootView.transform;
            cameraPresenter.ConfigData = CameraConfigDataSO.Instance.Data;
        }

        private void OnEnable()
        {
            playerPresenter.OnEnable();
            playerInputRouter.OnEnable();
        }

        private void Start()
        {
            
        }

        private void OnDisable()
        {
            playerPresenter.OnDisable();
            playerInputRouter.OnEnable();
        }

        private void Update()
        {
            playerPresenter.UpdateLocal(Time.deltaTime);
            playerInputRouter.UpdateLocal(Time.deltaTime);
        }
    }
}