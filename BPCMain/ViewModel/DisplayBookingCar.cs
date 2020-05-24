﻿using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.ViewModel
{
	class DisplayBookingCar : BookingVM
	{
		private ObservableCollection<Car> _cars = new ObservableCollection<Car>();

		#region DisplayBookingCar Methods

		public async void AcceptBookCar()
		{
			await GetAllCarBookingsTask();
			await GetAllCarsTask();
			CarBooking updatedCarBooking = new CarBooking();
			GetCurrentCar();
			foreach (CarBooking cb in CarBookings)
			{
				if (cb.OrderNo.Equals(SelectedBooking.OrderNo) && cb.CarId == 0)
				{
					cb.CarId = CurrentCar.Id;
					await UpdateCarBooking(cb);
					break;
				}
			}
			SelectedBooking.Status = Datastructures.Status.PendingClosing;
			await UpdateBooking(SelectedBooking);
			navigation.Navigate(typeof(View.DisplayBookingCar));
		}

		public async void DisplayMyBookings()
		{
			await GetAllCarBookingsTask();
			GetCurrentCar();
			foreach (CarBooking cb in CarBookings)
			{
				if (cb.CarId != CurrentCar.Id)
				{
					CarBookings.Remove(cb);
				}
			}

			foreach (Booking b in Bookings)
			{
				if (b.OrderNo != OrderNo)
				{
					Bookings.Remove(b);
				}
			}
		}





		public async void CancelJob()
		{
			SelectedBooking.Status = Datastructures.Status.Open;
			await UpdateBooking(SelectedBooking);
		}

		public async Task<bool> UpdateBooking(Booking updatedBooking)
		{
			var Task = await restworker.UpdateObjectAsync<Booking>(updatedBooking, updatedBooking.OrderNo,
				Datastructures.TableName.Booking);
			var result = Task;
			return result;
		}

		#endregion

		#region DisplayBookingCar RelayCommands



		#endregion
	}
}
