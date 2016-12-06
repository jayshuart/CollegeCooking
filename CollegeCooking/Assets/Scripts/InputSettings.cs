using UnityEngine;
using System.Collections;

public class InputSettings {

    #region Fields
    public float delay = 0.3f; //set delay for inputs

    //variables to hold inputs
    public float horizontalLStickIn = 0;
    public float verticalLStickIn = 0;
    public float horizontalRStickIn = 0;
    public float verticalRStickIn = 0;
    public float lTriggerIn = 0;
    public float rTriggerIn = 0;

    //bools for buttons
    public bool lBumper = false;
    public bool rBumper = false;

    //variables to hold input_axis
    public string HORIZONTAL_LSTICK_AXIS;
    public string HORIZONTAL_RSTICK_AXIS;

    public string VERTICAL_LSTICK_AXIS;
    public string VERTICAL_RSTICK_AXIS;

    public string LTRIGGER_AXIS;
    public string RTRIGGER_AXIS;

    public string LBUMPER;
    public string RBUMPER;
    #endregion

    #region Properties
    #endregion

    /// <summary>
    /// gets player number and assigns input to their controller
    /// </summary>
    /// <param name="playerNum"></param>
    public void ConfigureInput(int playerNum)
    {
        //assign unity input variables to this scripts input variables based on player number
        switch (playerNum)
        {
            //player 1
            case 1:
                //left stick
                HORIZONTAL_LSTICK_AXIS = "P1_Horizontal";
                VERTICAL_LSTICK_AXIS = "P1_Vertical";

                //right stick
                HORIZONTAL_RSTICK_AXIS = "P1_RStick_Horizontal";
                VERTICAL_RSTICK_AXIS = "P1_RStick_Vertical";

                //triggers
                LTRIGGER_AXIS = "P1_LTrigger";
                RTRIGGER_AXIS = "P1_RTrigger";

                //bumpers
                LBUMPER = "P1_LBumper";
                RBUMPER = "P1_RBumper";
                break;

            //player 2
            case 2:
                //left stick
                HORIZONTAL_LSTICK_AXIS = "P2_Horizontal";
                VERTICAL_LSTICK_AXIS = "P2_Vertical";

                //right stick
                HORIZONTAL_RSTICK_AXIS = "P2_RStick_Horizontal";
                VERTICAL_RSTICK_AXIS = "P2_RStick_Vertical";

                //triggers
                LTRIGGER_AXIS = "P2_LTrigger";
                RTRIGGER_AXIS = "P2_RTrigger";

                //bumpers
                LBUMPER = "P2_LBumper";
                RBUMPER = "P2_RBumper";
                break;
        }
    }

    /// <summary>
    /// gets current controller input and updates data
    /// </summary>
    public void UpdateInput()
    {
        //left stick
        horizontalLStickIn = Input.GetAxis(HORIZONTAL_LSTICK_AXIS);
        verticalLStickIn = Input.GetAxis(VERTICAL_LSTICK_AXIS);

        //rigth stick
        horizontalRStickIn = Input.GetAxis(HORIZONTAL_RSTICK_AXIS);
        verticalRStickIn = Input.GetAxis(VERTICAL_RSTICK_AXIS);

        //triggers
        lTriggerIn = Input.GetAxis(LTRIGGER_AXIS);
        rTriggerIn = Input.GetAxis(RTRIGGER_AXIS);

        //bumpers
        lBumper = Input.GetButton(LBUMPER);
        rBumper = Input.GetButton(RBUMPER);
    }
}
