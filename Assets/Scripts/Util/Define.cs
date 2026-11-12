using UnityEngine;


public class Define
{

    public enum eSceneType
    {
        TiTleScene,
        GameScene,
    }


    public enum eMouseEvent
    {
        Click,
        Down,
        Up,
        Press,
    }

    public enum eCharacterType
    {
        CloverSoldier = 1,  //Right
        SpadeSoldier = 2,   //Left
        Judge = 3,
        Turnip = 4,
        Chef = 5,
        King = 6,
        Sandglass = 7,
        Clown = 8,


        PLAYER = 100,
    }


    public enum eCompanionSide
    {
        Left,
        Right,
    }


}