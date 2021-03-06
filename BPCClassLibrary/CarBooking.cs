﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    public class CarBooking
    {
        private int _orderNo;
        private int _carId;
        private int _carBookingId;

        public CarBooking(int orderNo)
        {
            _orderNo = orderNo;
        }

        public CarBooking()
        {

        }

        public int OrderNo
        {
            get => _orderNo;
            set => _orderNo = value;
        }

        public int CarId
        {
            get => _carId;
            set => _carId = value;
        }

        public int CarBookingId
        {
            get => _carBookingId;
            set => _carBookingId = value;
        }
    }
}
