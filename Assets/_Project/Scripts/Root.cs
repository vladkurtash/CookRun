using UnityEngine;
using CookRun.Model;
using CookRun.View;
using CookRun.Presenter;
using CookRun.Systems;
using CookRun.Input;
using CookRun.Core;

namespace CookRun
{
    [DefaultExecutionOrder(+1)]
    public class Root : MonoBehaviour
    {
        [SerializeField] private PlayerRootView playerRootView;
        [SerializeField] private SlidingArea slidingArea;
        [SerializeField] private CameraPresenter cameraPresenter;
        private PlayerPresenter playerPresenter = null;
        private PlayerInputRouter playerInputRouter = null;

#if UNITY_EDITOR
        [SerializeField] private bool activePlayerInput = true;
#endif

        private void Awake()
        {
            playerRootView = FindObjectOfType<PlayerRootView>();
            slidingArea = FindObjectOfType<SlidingArea>();
            cameraPresenter = FindObjectOfType<CameraPresenter>();

            SetupPlayer();
            SetupMainCamera();
        }

        private void OnEnable()
        {
            playerPresenter.OnEnable();
            playerPresenter.RoadFinishEntered += OnPlayerEnteredRoadFinish;
            playerPresenter.LevelFinishEntered += OnPlayerEnteredLevelFinish;

#if UNITY_EDITOR
            if (!activePlayerInput)
                return;
#endif
            playerInputRouter.OnEnable();
        }

        private void SetupPlayer()
        {
            var model = new PlayerModel(PlayerConfigDataSO.Instance.Data);

            var moveSystem = new PlayerMoveSystem(PlayerMoveSystemDataSO.Instance.Data, model);
            var rotateSystem = new PlayerRotateSystem(PlayerRotateSystemDataSO.Instance.Data, model);

            PlayerAnimationSystemDataSO.Instance.Data.Setup();
            var animationSystem = new PlayerAnimationSystem
                (PlayerAnimationSystemDataSO.Instance.Data, playerRootView.Animator);
                
            var finishAutoPilot = new PlayerFinishAutoPilot
                (PlayerFinishAutoPilotDataSO.Instance.Data, moveSystem, rotateSystem, model);

            playerPresenter = new PlayerPresenter
                (model, playerRootView, animationSystem, finishAutoPilot, 
                moveSystem, rotateSystem);

            playerInputRouter = new PlayerInputRouter
                (slidingArea, moveSystem, rotateSystem, PlayerConfigDataSO.Instance.Data);
        }

        private void SetupMainCamera()
        {
            cameraPresenter.Target = playerRootView.transform;
            cameraPresenter.ConfigData = CameraConfigDataSO.Instance.Data;
        }

        private void OnDisable()
        {
            playerPresenter.OnDisable();
            playerInputRouter.OnDisable();
            playerPresenter.RoadFinishEntered -= OnPlayerEnteredRoadFinish;
            playerPresenter.LevelFinishEntered -= OnPlayerEnteredLevelFinish;
        }

        private void Update()
        {
            playerPresenter.UpdateLocal(Time.deltaTime);
            playerInputRouter.UpdateLocal(Time.deltaTime);
        }

        private void SetDefaultFrameRate()
        {
            //Application.targetFrameRate = Config.Instance.defaultFrameRate;
        }

        private void OnPlayerEnteredRoadFinish()
        {
            playerInputRouter.OnDisable();
        }

        private void OnPlayerEnteredLevelFinish()
        {
            //Activate GUI
        }
    }
}