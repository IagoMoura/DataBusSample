using DataBus.Domain.Commands.Base;
using DataBus.Domain.DataBus.Handles;
using DataBus.Domain.DataBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBus.Domain.DataBus
{
    public static class DataBusManager
    {
        #region Fields
        private static List<Registration> _registrations;
        #endregion

        #region Properties
        public static List<Registration> Registrations
        {
            get
            {
                if (_registrations == null)
                    _registrations = new List<Registration>();

                return _registrations;
            }
            private set
            {
                _registrations = value;
            }
        }
        #endregion

        #region Events
        public static event ExecuteCommandHandle ExecuteCommandEvent;
        #endregion

        #region Constructors
        static DataBusManager()
        {

        } 
        #endregion

        public static void ExecuteCommand(BaseCommand command)
        {
            // Get all command registrations
            var registrations = Registrations.Where(q => q.Command.GetType() .FullName.Equals(command.GetType().FullName))?.OrderBy(q => q.Order);

            foreach (var registration in Registrations.OrderBy(q => q.Order))
            {
                if (!registration.Command.FullName.Equals(registration.Command.FullName))
                    continue;

                ExecuteCommandEvent?.Invoke(registration, command);

                //registration.CommandReceiver.Execute(command);

                if (!command.Continue)
                    break;
            }
        }
    }
}
