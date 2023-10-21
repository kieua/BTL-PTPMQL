using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTL.Models;

    [Table("KhachHangs")]
    public class KhachHang
    {
     [Key]
    public string MaKH { get; set; }
    public string TenKH { get; set; }
    public string DiaChi { get; set; }
    }
