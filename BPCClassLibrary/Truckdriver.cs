﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    public class Truckdriver
    {
        #region Instance fields

        private int _truckdriverId;
        private int _telephoneNo;
        private string _eMail;
        #endregion

        #region Constructors

        public Truckdriver(int truckdriverId, int telephoneNo, string eMail)
        {
            _truckdriverId = truckdriverId;
            _telephoneNo = telephoneNo;
            _eMail = eMail;
        }

        public Truckdriver()
        {

        }
        #endregion

        #region Properties

        public int TruckdriverId
        {
            get => _truckdriverId;
            set => _truckdriverId = value;
        }

        public int TelephoneNo
        {
            get => _telephoneNo;
            set => _telephoneNo = value;
        }

        public string EMail
        {
            get => _eMail;
            set => _eMail = value;
        }
        #endregion
    }
}
