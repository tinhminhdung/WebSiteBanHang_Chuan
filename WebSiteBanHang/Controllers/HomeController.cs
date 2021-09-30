﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace WebSiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index()
        {
            //Lần lượt tạo các viewbag để lấy list sản phẩm từ cơ sở dữ liệu
            //List Diện điện thoại mới nhất
            var lstDTM = db.SanPhams.Where(n => n.MaLoaiSP == 1 && n.Moi == 1 && n.DaXoa == false);
            //Gán vào ViewBag
            ViewBag.ListDTM = lstDTM;

            //List LapTop mới nhất
            var lstLT = db.SanPhams.Where(n => n.MaLoaiSP == 3 && n.Moi == 1 && n.DaXoa == false);
            //Gán vào ViewBag
            ViewBag.ListLTM = lstLT;

            //List Máy tính bảng mới nhất
            var lstMTB = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1 && n.DaXoa == false);
            //Gán vào ViewBag
            ViewBag.ListMTBM = lstMTB;

            return View();
        }

        public ActionResult MenuPartial()
        {
            //Truy vấn lấy về 1 list các sản phẩm
            var lstSP = db.SanPhams;
            return PartialView(lstSP); 
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());

            return View();
        }

        [HttpPost, CaptchaMvc.Attributes.CaptchaVerify("Captcha is not valid")]
        public ActionResult DangKy(ThanhVien tv,FormCollection f)
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            //Kiểm tra captcha hợp lệ
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                if (ModelState.IsValid)
                {
                    ViewBag.ThongBao = "Thêm thành công";
                    //Thêm khách hàng vào csdl
                    db.ThanhViens.Add(tv);
                    db.SaveChanges();
                }
                else
                { 
                    ViewBag.ThongBao = "Thêm thất bại";
                }
                return View();
            }
            TempData["Message"] = "Message: blahblah";
            ViewBag.ThongBao = "Sai mã captcha";

    
            return View();
        }
        [HttpGet]
        public ActionResult DangKy1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy1(ThanhVien tv)
        {
            return View();
        }
        //Load câu hỏi bí mật
        public List<string> LoadCauHoi()
        {
            List<string> lstCauHoi = new List<string>();
            lstCauHoi.Add("Con vật mà bạn yêu thích?");
            lstCauHoi.Add("Ca sĩ mà bạn yêu thích?");
            lstCauHoi.Add("Hiện tại bạn đang làm công việc gì?");
            return lstCauHoi;
        }

        //Xây dựng action đăng nhập
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            //Kiểm tra tên đăng nhập và mật khẩu
            string sTaiKhoan = f["txtTenDangNhap"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            ThanhVien tv = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (tv != null)
            {
                Session["TaiKhoan"] = tv;
                return Content("<script>window.location.reload();</script>");
            }
            return Content("Tài khoản hoặc mật khẩu không đúng!");
        }
       
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
	}
}