using System.Threading.Tasks;
using Microsoft.VisualBasic;
using WebApplication1.Enums;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class VehicleService : IVehicleService
    {
        readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;   
        }
        public async Task<int> AddVehicleAsync(VehicleModel vehicle)
        {
            using (var memoryStream = new MemoryStream())
            {
                vehicle.VehicleImage.CopyTo(memoryStream); // Copy image data to memory
                vehicle.VehicleImageBytes = memoryStream.ToArray();
                vehicle.VehicleImageContentType = vehicle.VehicleImage.ContentType;
                return await _vehicleRepository.AddVehicleAsync(vehicle);
            }

        }
        public async Task<VehicleModel> GetVehicleByVehicleIdAndUserIdAsync(int vehicleId, int userId)
        {
            return await _vehicleRepository.GetVehicleByVehicleIdAndUserIdAsync(vehicleId, userId);
        }
        public async Task<int> UpdateVehicleByIdAsync(VehicleModel vehicle)
        {
            return await _vehicleRepository.UpdateVehicleByIdAsync(vehicle);
        }
        public async Task<int> DeleteVehicleByIdAsync(int vehicleId, int userId)
        {
            return await _vehicleRepository.DeleteVehicleByIdAsync(vehicleId, userId);
        }
        public async Task<IEnumerable<VehicleModel>> GetAvailableVehicleAsync(SearchActiveVehicleModel searchActiveVehicle)
        {
            return await _vehicleRepository.GetAvailableVehicleAsync(searchActiveVehicle);
        }
        public async Task<int> AddBookingAsync(int id, int userId, decimal price, SearchActiveVehicleModel filter)
        {
            BookingModel booking = new BookingModel
            {
                VehicleId = id,
                UserId = (int)userId,
                StartLocation = filter.StartLocation,
                StartDate = filter.StartDate,
                EndDate = filter.EndDate,
                TotalAmount = (price / 1440) * ((decimal)(filter.EndDate - filter.StartDate).TotalMinutes),
                Status = (int)StatusType.Pending
            };
            return await _vehicleRepository.AddBookingAsync(booking);
        }
        public IEnumerable<BookingModel> GetBookingByUserIdAsync(int userId)
        {
            return _vehicleRepository.GetBookingByUserIdAsync(userId);
        }
        public async Task<IEnumerable<BookingModel>> GetRequestHistory(int userId)
        {
            return await _vehicleRepository.GetRequestHistory(userId);
        }
        public async Task<int> UpdateBookingByIdAsync(int id, int cancelType)
        {
            return await _vehicleRepository.UpdateBookingByIdAsync(id, cancelType);
        }
        public async Task<VehicleModel> GetVehicleByVehicleIdAsync(int vehicleId)
        {
            return await _vehicleRepository.GetVehicleByVehicleIdAsync(vehicleId);
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleByUserIdAsync(int userId)
        {
            return await _vehicleRepository.GetVehicleByUserIdAsync(userId);
        }
    }
}
