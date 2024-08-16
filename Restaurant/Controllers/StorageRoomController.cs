using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class StorageRoomController : Controller
    {
        IStorageRoomService storageRoomService;
        public StorageRoomController(IStorageRoomService _storageRoomService)
        {
            storageRoomService = _storageRoomService;
        }
        public IActionResult ShowStorageRooms()
        {
            List<StorageRoom> storageRooms = storageRoomService.GetAllStorageRooms();
            return View(storageRooms);
        }
        public IActionResult AddStorageRoom()
        {
            return View();
        }
        public IActionResult SaveAddStorageRoom(StorageRoom storageRoom)
        {
            if(ModelState.IsValid)
            {
                storageRoomService.AddStorageRoom(storageRoom);
                return RedirectToAction("ShowStorageRooms");
            }
            return View("AddStorageRoom",storageRoom);
        }
        public IActionResult Edit(string ID)
        {
            StorageRoom storageRoom = storageRoomService.GetById(ID);
            return View(storageRoom);
        }
        public IActionResult SaveEditStorageRoom([FromRoute]string id,StorageRoom newStorageRoom)
        {
            storageRoomService.updateStorageRoom(id,newStorageRoom);
            return RedirectToAction("ShowStorageRooms");
        }
        public IActionResult Delete(string ID)
        {
            storageRoomService.DeleteStorageRoom(ID);
            return RedirectToAction("ShowStorageRooms");
        }
    }
}
