using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL.Models;

    [Table("KhachHangs")]
    public class KhachHang
    {
     [Key]
    public int MaKH { get; set; }
    public string TenKH { get; set; }
    public string DiaChi { get; set; }
    }
