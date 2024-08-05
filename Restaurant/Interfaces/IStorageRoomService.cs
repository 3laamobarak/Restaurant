using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IStorageRoomService
    {
        int AddStorageRoom(StorageRoom storageRoom);
        int DeleteStorageRoom(string id);
        List<StorageRoom> GetAllStorageRooms();
        StorageRoom GetById(string id);
        int updateStorageRoom(string ID, StorageRoom NewstorageRoom);
    }
}