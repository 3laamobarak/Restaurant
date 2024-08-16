using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ReceiptController : Controller
    {
        IReceiptService receiptService;
        public ReceiptController(IReceiptService _receiptService)
        {
            receiptService = _receiptService;
        }
        public IActionResult ShowReceipts()
        {
            List<Receipt> receipts = receiptService.GetAllReceipts();
            return View(receipts);
        }
        public IActionResult AddReceipt()
        {
            return View();
        }
        public IActionResult SaveAddReceipt(Receipt receipt)
        {
            if(ModelState.IsValid)
            {
                receiptService.CreateReceipt(receipt);
                return RedirectToAction("ShowReceipts");
            }
            return View("AddReceipt",receipt);
        }
        public IActionResult Edit(string ID)
        {
            Receipt receipt = receiptService.getbyId(ID);
            return View(receipt);
        }
        public IActionResult SaveEditReceipt([FromRoute]string id,Receipt newreceipt)
        {
            receiptService.UpdateReceipt(id,newreceipt);
            return RedirectToAction("ShowReceipts");
        }
        public IActionResult Delete(string ID)
        {
            receiptService.DeleteReceipt(ID);
            return RedirectToAction("ShowReceipts");
        }
    }
}
