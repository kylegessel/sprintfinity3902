using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IDoor: IEntity
    {
        public IDoorState wallTop { get; set; }
        public IDoorState wallBottom { get; set; }
        public IDoorState wallLeft { get; set; }
        public IDoorState wallRight { get; set; }
        public IDoorState openDoorTop { get; set; }
        public IDoorState openDoorBottom { get; set; }
        public IDoorState openDoorLeft { get; set; }
        public IDoorState openDoorRight { get; set; }
        public IDoorState closedDoorTop { get; set; }
        public IDoorState closedDoorBottom { get; set; }
        public IDoorState closedDoorLeft { get; set; }
        public IDoorState closedDoorRight { get; set; }
        public IDoorState lockedDoorTop { get; set; }
        public IDoorState lockedDoorBottom { get; set; }
        public IDoorState lockedDoorLeft { get; set; }
        public IDoorState lockedDoorRight { get; set; }
        public IDoorState holeDoorTop { get; set; }
        public IDoorState holeDoorBottom { get; set; }
        public IDoorState holeDoorLeft { get; set; }
        public IDoorState holeDoorRight { get; set; }
        public int DoorDestination { get; set; }
        public void Open();

        public void Close();

        public void SetState(IDoorState doorState);
    }
}
