﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetTripsByUsername(string username);
        IEnumerable<Trip> GetAllTrips();
        Trip GetTripByName(string tripName);
        Trip GetUserTripByName(string tripName, string username);

        void AddTrip(Trip newTrip);
        void AddStop(string tripName, Stop newStop, string username);

        Task<bool> SaveChangesAsync();
    }
}