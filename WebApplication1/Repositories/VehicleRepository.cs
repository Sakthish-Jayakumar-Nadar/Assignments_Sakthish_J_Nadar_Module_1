using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Custom_Exceptions;
using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        readonly VechicleRentalSystemDbContext _context;
        public VehicleRepository(VechicleRentalSystemDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddVehicleAsync(VehicleModel vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            return await _context.SaveChangesAsync();
        }
        public async Task<VehicleModel> GetVehicleByVehicleIdAndUserIdAsync(int vehicleId, int userId)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.VehicleId == vehicleId && vehicle.UserId == userId);
        }
        public async Task<int> UpdateVehicleByIdAsync(VehicleModel vehicle)
        {
            VehicleModel vehicleToUpdate = await GetVehicleByVehicleIdAndUserIdAsync(vehicle.VehicleId, vehicle.UserId);
            vehicleToUpdate.Model = vehicle.Model;
            vehicleToUpdate.Brand = vehicle.Brand;
            vehicleToUpdate.Type = vehicle.Type;
            vehicleToUpdate.Location = vehicle.Location;
            vehicleToUpdate.RentalPricePerDay = vehicle.RentalPricePerDay;
            vehicleToUpdate.IsAvailable = vehicle.IsAvailable;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteVehicleByIdAsync(int vehicleId, int userId)
        {
             VehicleModel vehicleToDelete = await GetVehicleByVehicleIdAndUserIdAsync(vehicleId, userId);
            if(vehicleToDelete == null)
            {
                throw new NotFoundException("Vehicle not found");
            }
             _context.Vehicles.Remove(vehicleToDelete);
             return await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<VehicleModel>> GetAvailableVehicleAsync(SearchActiveVehicleModel searchActiveVehicle)
        {
            return await _context.Vehicles.Where(vehicle => vehicle.Location == searchActiveVehicle.StartLocation && vehicle.IsAvailable == true && !vehicle.Bookings.Any(booking => (searchActiveVehicle.StartDate >= booking.StartDate && searchActiveVehicle.StartDate <= booking.EndDate && booking.Status == (int)StatusType.Approved) || (searchActiveVehicle.EndDate < booking.EndDate && searchActiveVehicle.EndDate > booking.StartDate && booking.Status == (int)StatusType.Approved) || (searchActiveVehicle.StartDate < booking.StartDate && searchActiveVehicle.EndDate > booking.EndDate && booking.Status == (int)StatusType.Approved) || (booking.Status == (int)StatusType.Approved))).ToListAsync();
        }
        public async Task<int> AddBookingAsync(BookingModel booking)
        {
            await _context.Bookings.AddAsync(booking);
            return await _context.SaveChangesAsync();
        }
        public IEnumerable<BookingModel> GetBookingByUserIdAsync(int userId)
        {
            return _context.Bookings.Where(b => b.UserId == userId).OrderByDescending(b => b.BookingId);
        }
        public async Task<IEnumerable<BookingModel>> GetRequestHistory(int userId)
        {
            return await _context.Bookings.Include(b => b.Vehicle).Where(b => b.Vehicle.UserId == userId).OrderByDescending(b => b.BookingId).ToListAsync();
        }
        public async Task<int> UpdateBookingByIdAsync(int id, int cancelType)
        {
            BookingModel booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            booking.Status = cancelType;
            return await _context.SaveChangesAsync();
        }
        public async Task<VehicleModel> GetVehicleByVehicleIdAsync(int vehicleId)
        {
            VehicleModel vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleId == vehicleId);
            vehicle.User = await _context.Users.FirstOrDefaultAsync(u => u.UserId == vehicle.UserId);
            if(vehicle == null || vehicle.User == null)
            {
                throw new NotFoundException("Vehicle not found");
            }
            return vehicle;
        }
        public async Task<IEnumerable<VehicleModel>> GetVehicleByUserIdAsync(int userId)
        {
            IEnumerable<VehicleModel> vehicles = await _context.Vehicles.Where(v => v.UserId == userId).ToListAsync();
            if(vehicles == null)
            {
                throw new NotFoundException("Vehicles not found");
            }
            return vehicles;
        }
    }
}