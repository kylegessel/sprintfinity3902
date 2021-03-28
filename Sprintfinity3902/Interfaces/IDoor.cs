using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IDoor : IBlock
    {
        IDoorState wallTop { get; set; }
        IDoorState wallBottom { get; set; }
        IDoorState wallLeft { get; set; }
        IDoorState wallRight { get; set; }
        IDoorState openDoorTop { get; set; }
        IDoorState openDoorBottom { get; set; }
        IDoorState openDoorLeft { get; set; }
        IDoorState openDoorRight { get; set; }
        IDoorState closedDoorTop { get; set; }
        IDoorState closedDoorBottom { get; set; }
        IDoorState closedDoorLeft { get; set; }
        IDoorState closedDoorRight { get; set; }
        IDoorState lockedDoorTop { get; set; }
        IDoorState lockedDoorBottom { get; set; }
        IDoorState lockedDoorLeft { get; set; }
        IDoorState lockedDoorRight { get; set; }
        IDoorState holeDoorTop { get; set; }
        IDoorState holeDoorBottom { get; set; }
        IDoorState holeDoorLeft { get; set; }
        IDoorState holeDoorRight { get; set; }
        int DoorDestination { get; set; }

        void SetState(IDoorState state);
        void Open();
        void Close();

    }
}
