using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLLuong1.Models;

namespace QLLuong1.Controllers
{
    public class NhanVienController : ApiController
    {
        QLLuong1Entities1 db = new QLLuong1Entities1 ();

        [HttpGet] // lay nhan vien
        public List<NhanVien> laynhanvien()
        {
            return db.NhanViens.ToList();
        }

        [HttpGet]
        public NhanVien layNhanVienTheoMa(int manv)
        {
            return db.NhanViens.FirstOrDefault(x => x.manv == manv);
        }

        [HttpGet]
        public List<NhanVien> layNhanVienTheoMaDonVi(int madonvi)
        {
            return db.NhanViens.Where(x => x.madonvi == madonvi).ToList();
        }

        [HttpGet]
        public List<NhanVien> layNhanVienTheoGT(string gioitinh)
        {
            return db.NhanViens.Where(x => x.gioitinh == gioitinh).ToList();

        }

        [HttpGet]
        public List<NhanVien> layNhanVienTheoLuong(int minhsluong, int maxhsluong)
        {
            return db.NhanViens.Where(x => x.hsluong >= minhsluong && x.hsluong <= maxhsluong).ToList();
        }

        [HttpPost]
        // them nhan vien
        public bool themNhanVien(int manv,string hoten, string gioitinh, int hsluong, int madonvi)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.manv == manv);
            if(nv == null)
            {
                NhanVien nvmoi = new NhanVien();
                nvmoi.manv = manv;
                nvmoi.hoten = hoten;
                nvmoi.gioitinh = gioitinh;
                nvmoi.hsluong = hsluong;
                nvmoi.madonvi = madonvi;

                db.NhanViens.Add(nvmoi);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        // sua nhan vien
        public bool suaNhanVien(int manv, string hoten, string gioitinh, int hsluong, int madonvi)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.manv == manv);
            if(nv != null)
            {
                nv.manv = manv;
                nv.hoten = hoten;
                nv.gioitinh = gioitinh;
                nv.hsluong = hsluong;
                nv.madonvi = madonvi;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        // xoa nhan vien
        public bool xoaNhanVien(int manv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.manv == manv);
            if(nv != null )
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
