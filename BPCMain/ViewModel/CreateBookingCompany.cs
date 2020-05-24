﻿using BPCClassLibrary;
using BPCMain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BPCMain.Utilities.ConstraintMethods;
using BPCMain;
using BPCMain.Persistency;

namespace BPCMain.ViewModel
{
    class CreateBookingCompany : BookingVM
    {
		private RelayCommand _createBookingCompany;

		//if (ConstraintMethods.CreateBookingCheck(newBooking)) //metode i ConstraintMethods
		//	{
		//		//save newBooking in database
		//		await CreateNewBooking(newBooking);
		////save newCarBooking in database
		////await CreateNewCarBooking()
		////save new Truckdriver in database
		//await CreateTruckdriver(truckdriver);
		////evt. popup successful Booking
		//navigation.Navigate(typeof(BPCMain.View.DisplayBookingCompany));
		//	}
		//	else
		//	{
		//		string ErrorMessage = "Fejl i oplysninger"; //evt. bruge header til fejlmeddelelser
		//	}

		public CreateBookingCompany()
		{
			_createBookingCompany = new RelayCommand(NewBooking, null);
			
		}

        #region functions

        public async void NewBooking()
		{
			Booking newBooking = new Booking(0, _shared.UserUser, NumOfCarsNeeded, TypeOfGoods, TotalWidth, TotalLength, TotalHeight, TotalWeight, DateTime.Now, StartAddress, StartPostalCode, StartCity, StartCountry, DateTime.Now, EndAddress, EndPostalCode, EndCity, EndCountry, TruckdriverId, Contactperson, Comment);

			Truckdriver truckdriver = new Truckdriver(CompanyCvrNo, TruckDriverTelNo, TruckdriverEMail);

			if (CreateBookingCheck(newBooking))
			{
				await CreateNewBooking(newBooking);
				await GetAllBookingAsync();
				newBooking = GetNewBooking(_shared.UserUser);
				await NewCarBooking(newBooking.OrderNo);
			}
		}

		private Booking GetNewBooking(int cvrNo)
		{
			Booking newBooking = new Booking();
			DateTime date = DateTime.MinValue;
			foreach (Booking booking in Bookings)
			{
				if (booking.CompanyCvrNo == cvrNo && booking.StartDate > date)
				{
					newBooking = booking;
					date = booking.StartDate;
				}
			}
			return newBooking;
		}

		public async Task<bool> NewCarBooking(int orderNo)
		{
			for (int i = 0; i < NumOfCarsNeeded; i++)
			{
				CarBooking newCarBooking = new CarBooking(orderNo);

				await CreateNewCarBooking(newCarBooking);
			}
			return true;
		}

		public async Task<bool> CreateNewBooking(Booking newBooking)
		{
			bool created = await restworker.CreateObjectAsync<Booking>(newBooking, Datastructures.TableName.Booking);
			return created;
		}

		public async Task<bool> CreateTruckdriver(Truckdriver truckdriver)
		{
			bool created = await restworker.CreateObjectAsync<Truckdriver>(truckdriver, Datastructures.TableName.Truckdriver);
			return created;
		}

		public async Task<bool> CreateNewCarBooking(CarBooking newCarBooking)
		{
			bool created = await restworker.CreateObjectAsync<CarBooking>(newCarBooking, Datastructures.TableName.CarBooking);
			return created;
		}

		public async Task<bool> UpdateBooking(Booking updatedBooking)
		{
			var Task = await restworker.UpdateObjectAsync<Booking>(updatedBooking, updatedBooking.OrderNo,
				Datastructures.TableName.Booking);
			var result = Task;
			return result;
		}

		#endregion

		#region RelayCommands
		public RelayCommand CreateBookingCompanyRC
		{
			get { return _createBookingCompany; }
		}

        #endregion
    }
}