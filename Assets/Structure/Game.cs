using UnityEngine;

namespace Assets.Code.Structure
{
    public class Game : MonoBehaviour
    {
        /// <summary>
        /// The game context.
        /// A pointer to the currently active game (so that we don't have to use something slow like "Find").
        /// </summary>
        public static Game Ctx;

        /// <summary>
        /// The class that handles serialization/deserialization
        /// </summary>

        // 
        // all of the things that we can about saving/loading
        public static player1 Player1;
        public static BulletManager Bullets;


        internal void Start () {
            Ctx = this;

            Bullets = new BulletManager(GameObject.Find("Bullets").transform);
        }

        // all of this is done so that you can save/load with the Start/Back buttons
        private static string _saveAxis;
        private bool _locked;
        internal void Update () {
            float axis = Input.GetAxis(_saveAxis);
            if (_locked && Mathf.Abs(axis) < 0.1f) { _locked = false; }
            if (_locked) { return; }


        }

        /// <summary>
        /// Take the loaded data and initialize everything appropriately
        /// </summary>
        /// <param name="data">The GameData object containing all of the loaded values</param>
        

        private static bool IsMac () {
            return Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}