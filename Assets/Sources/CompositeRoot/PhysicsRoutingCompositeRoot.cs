using Asteroids;
using Asteroids.Model;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompositeRoot
{
    public class PhysicsRoutingCompositeRoot : CompositeRoot
    {
        [SerializeField] private EnemiesCompositeRoot _enemiesRoot;
        [SerializeField] private ShipCompositeRoot _shipRoot;
        [SerializeField] private EndGameWindowView _endGameWindowView;
        [SerializeField] private PhysicsEventBroadcaster _shipEventsBroadcaster;

        private PhysicsRouter _router;
        private CollisionsRecords _records;

        public PhysicsRouter Model => _router;


        public override void Compose()
        {
            _records = new CollisionsRecords(_shipRoot.Bullets, _enemiesRoot.Simulation);
            _router = new PhysicsRouter(_records.Values);
            _shipEventsBroadcaster.Init(_router, _shipRoot.Model);

            StartCoroutine(GetRouterSteper());
        }

        private void OnEnable()
        {
            _records.GameEnd += OnGameEnd;
        }

        private void OnDisable()
        {
            _records.GameEnd -= OnGameEnd;
        }

        private int OnGameEnd()
        {
            _shipRoot.DisableShip();

            _endGameWindowView.Show(0, () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }

        private IEnumerator GetRouterSteper()
        {
            while (true)                                                   //Magic!
            {
                yield return new WaitForFixedUpdate();
                _router.Step();
            }
        }

    }
}
