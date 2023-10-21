using BTL.Data;
using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL.Controllers
{
    public class KhachHangController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public KhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.KhachHang.ToListAsync();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(KhachHang kh)
        {
            string strOutput = "Khach hang" + kh.MaKH + "-" +kh.TenKH + "-" +kh.DiaChi;
            ViewBag.infoKhachHang = strOutput;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKH,TenKH,DiaChi")] KhachHang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }
        public async Task<IActionResult> Edit(string kh)
        {
            if (kh == null || _context.KhachHang == null)
            {
                return NotFound();
            }
            var khachhang = await _context.KhachHang.FindAsync(kh);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string kh, [Bind("MaKH,TenKH,DiaChi")] KhachHang khachhang)
        {
           if (kh != khachhang.MaKH)
           {
            return NotFound();
           }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachhang.MaKH))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(khachhang);
            }

        }
        public async Task<IActionResult> Delete(string kh)
        {
            if (kh == null || _context.KhachHang == null)
            {
                return NotFound();
            }
            var khachhang = await _context.KhachHang.FirstOrDefaultAsync(m => m.MaKH == kh);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComfirmed(string kh)
        {
            if (_context.KhachHang == null)
            {
                return Problem("Entity set'ApplicationDbContext.Khachhang' is null.");
            }
            var khachhang = await _context.KhachHang.FindAsync(kh);
            if (khachhang == null)
            {
                _context.KhachHang.Remove(khachhang);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool KhachHangExists(string kh)
        {
            return (_context.KhachHang?.Any(e => e.MaKH == kh)).GetValueOrDefault();
        }

    }
}


