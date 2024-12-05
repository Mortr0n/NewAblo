using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] EquippableAbility ability1;
    [SerializeField] EquippableAbility ability2;

    int factionID = 1;

    void Start()
    {
        // finds main controller gets the object it's attached to and then adds the controller.  Very Cool!  Instead of adding to it in the inspector so you could change it out
        CameraController cameraController = Camera.main.gameObject.AddComponent<CameraController>(); // in class they spelled both out and did not set it to a variable.  I felt like I wanted to try the var way
        cameraController.SetFollowTarget(gameObject); // run the CameraControllers SetFollowTarget
        //Camera.main.gameObject.GetComponent<CameraController>().SetFollowTarget(gameObject); // run the CameraControllers SetFollowTarget function original class way.

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ability1 != null) UseAbility1();
        if (Input.GetMouseButtonDown(1) && ability2 != null) UseAbility2();
    }

    void UseAbility1()
    {
        ability1.RunAbilityClicked(this);
    }

    void UseAbility2()
    {
        ability2.RunAbilityClicked(this);
    }

    #region Utility
    public PlayerMovement Movement()
    {
        return GetComponent<PlayerMovement>();
    }
    public PlayerAnimator GetAnimator()
    {
        return GetComponent<PlayerAnimator>();
    }
    public PlayerCharacterSheet GetCharacterSheet()
    {
        return GetComponent<PlayerCharacterSheet>();
    }
    public int GetFactionID()
    {
        return factionID;
    }
    #endregion
}
