#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

using System.ComponentModel;
using System.Runtime.CompilerServices;
using MickyD.AreaCalculator.ViewModels.Annotations;

namespace MickyD.AreaCalculator.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Call to fire a property change event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the check notify.
        /// </summary>
        /// <typeparam name="T">the field type</typeparam>
        /// <param name="field">The field.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <returns></returns>
        protected bool SetCheckNotify<T>(ref T field, T newValue, [CallerMemberName] string callerMemberName = null)
        {
            if (Equals(field, newValue))
                return false;

            field = newValue;
            OnPropertyChanged(callerMemberName);
            return true;
        }
    }
}