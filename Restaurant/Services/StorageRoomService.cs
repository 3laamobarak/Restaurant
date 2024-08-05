using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class StorageRoomService : IStorageRoomService
    {
        private readonly RestDBcontext context;
        public StorageRoomService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<StorageRoom> GetAllStorageRooms()
        {
            return context.StorageRoom.ToList();
        }
        public StorageRoom GetById(string id)
        {
            return context.StorageRoom.FirstOrDefault(x => x.Id == id);
        }
        public int AddStorageRoom(StorageRoom storageRoom)
        {
            context.StorageRoom.Add(storageRoom);
            return context.SaveChanges();
        }
        public int updateStorageRoom(string ID, StorageRoom NewstorageRoom)
        {
            StorageRoom OldstorageRoom = context.StorageRoom.FirstOrDefault(x => x.Id == ID);
            OldstorageRoom.Name = NewstorageRoom.Name;
            OldstorageRoom.Address = NewstorageRoom.Address;
            OldstorageRoom.Item = NewstorageRoom.Item;
            return context.SaveChanges();
        }
        public int DeleteStorageRoom(string id)
        {
            StorageRoom storageRoom = context.StorageRoom.FirstOrDefault(x => x.Id == id);
            context.StorageRoom.Remove(storageRoom);
            return context.SaveChanges();
        }
    }
}
