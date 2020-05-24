﻿using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.ViewModel
{
	class DisplayBookingCompany : BookingVM
	{

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

		public DisplayBookingCompany()
		{

		}


		public async void NewCarBooking()
		{
			for (int i = 0; i < NumOfCarsNeeded; i++)
			{
				CarBooking newCarBooking = new CarBooking(OrderNo);

				await CreateNewCarBooking(newCarBooking);
			}
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

	}
}
