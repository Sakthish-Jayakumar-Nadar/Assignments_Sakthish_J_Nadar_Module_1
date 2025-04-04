using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IVehicleService
    {
        public Task<int> AddVehicleAsync(VehicleModel vehicle);
        public Task<VehicleModel> GetVehicleByVehicleIdAndUserIdAsync(int vehicleId, int userId);
        public Task<int> UpdateVehicleByIdAsync(VehicleModel vehicle);
        public Task<int> DeleteVehicleByIdAsync(int vehicleId, int userId);
        public Task<IEnumerable<VehicleModel>> GetAvailableVehicleAsync(SearchActiveVehicleModel searchActiveVehicle);
        public Task<int> AddBookingAsync(int id, int userId, decimal price, SearchActiveVehicleModel filter);
        public IEnumerable<BookingModel> GetBookingByUserIdAsync(int userId);
        public Task<IEnumerable<BookingModel>> GetRequestHistory(int userId);
        public Task<int> UpdateBookingByIdAsync(int id, int cancelType);
        public Task<VehicleModel> GetVehicleByVehicleIdAsync(int vehicleId);
        public Task<IEnumerable<VehicleModel>> GetVehicleByUserIdAsync(int userId);
    }
}
