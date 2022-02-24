using MvcCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD.Controllers
{
    public class CalisanlarController : Controller
    {
        // GET: Calisanlar
        public ActionResult Index()
        {
            IEnumerable<MvcCalisanModel> calList;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Calisanlar").Result;

            calList = response.Content.ReadAsAsync<IEnumerable<MvcCalisanModel>>().Result;
            return View(calList);
        }
        [HttpGet]
        public ActionResult Ekle(int id = 0)
        {
            if (id == 0)
            {
                return View(new MvcCalisanModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Calisanlar/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcCalisanModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult Ekle(MvcCalisanModel calisan)
        {
            if (calisan.CalisanID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Calisanlar", calisan).Result;
                TempData["SuccessMessage"] = "Başarılı bir şekilde kaydedildi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Calisanlar/" + calisan.CalisanID, calisan).Result;
                TempData["SuccessMessage"] = "Güncelleme İşlemi Başarılı";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Calisanlar/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Silme İşlemi Başarılı";

            return RedirectToAction("Index");
        }

    }
}